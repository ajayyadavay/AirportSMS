using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AirportSMS
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void hazardMonitoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private static JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            AllowTrailingCommas = false,
            ReadCommentHandling = JsonCommentHandling.Skip,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            UnknownTypeHandling = JsonUnknownTypeHandling.JsonNode
        };


        public static void CreateProject(string rootFolder, SMS_Project_Package_class.SMSProject project)
        {
            // Example rootFolder: "C:\\AirportProjects\\Airport_2025"
            //Directory.CreateDirectory(rootFolder);
            Directory.CreateDirectory(Path.Combine(rootFolder, "SPIs"));

            // Manifest
            var manifest = new SMS_Project_Package_class.Manifest
            {
                CreatedOn = DateTime.UtcNow,
                Sections = new List<string> { "Project", "SPIs" },
                Required = new List<string> { "Manifest.json", "Project.json" }
            };

            File.WriteAllText(Path.Combine(rootFolder, "Manifest.json"),
                              JsonSerializer.Serialize(manifest, jsonOptions));

            // Project metadata
            File.WriteAllText(Path.Combine(rootFolder, "Project.json"),
                              JsonSerializer.Serialize(project, jsonOptions));
        }


        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string RootFolderPath="";

            //Create Root Folder
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select or create a SMS Project folder";
                folderDialog.ShowNewFolderButton = true;

                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    RootFolderPath = folderDialog.SelectedPath;
                    // You can now use RootFolderPath variable later
                    MessageBox.Show("Selected Folder: " + RootFolderPath);
                    TxtProjectLocation.Text = RootFolderPath;
                }
                else if (result == DialogResult.Cancel)
                {
                    return; // User cancelled
                }
            }

            //Write project name
            SMS_Project_Package_class.SMSProject smsproj = new SMS_Project_Package_class.SMSProject();

            smsproj.ProjectName = "This_Project" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");

            //creating project
            CreateProject(RootFolderPath, smsproj);


        }

        public static SMS_Project_Package_class.SMSProject LoadProject(string projectFolder)
        {
            string filePath = Path.Combine(projectFolder, "Project.json");

            if (!File.Exists(filePath))
                return null;

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<SMS_Project_Package_class.SMSProject>(json, jsonOptions);
        }

        public class SPILoadResult
        {
            public string FileName_1 { get; set; }
            public string SPI_Name_1 { get; set; }
            public string SPI_Id_1 { get; set; }
            public string SPI_Type_1 { get; set; }
        }


        public static List<SPILoadResult> LoadSPIMetadata(string projectFolder)
        {
            List<SPILoadResult> list = new List<SPILoadResult>();
            string spiFolder = Path.Combine(projectFolder, "SPIs");

            if (!Directory.Exists(spiFolder))
                return list;

            foreach (var file in Directory.GetFiles(spiFolder, "*.json"))
            {
                string json = File.ReadAllText(file);
                var spi = JsonSerializer.Deserialize<SMS_Project_Package_class.SPI>(json, jsonOptions);

                if (spi != null)
                {
                    list.Add(new SPILoadResult
                    {
                        FileName_1 = Path.GetFileName(file),
                        SPI_Name_1 = spi.SPI_Name,
                        SPI_Id_1 = spi.SPI_Id,
                        SPI_Type_1 = spi.SPI_Type
                    });
                }
            }

            return list;
        }


        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select SMS Project Folder";

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string projectFolder = fbd.SelectedPath;

                    // 1. Load Project.json
                    var project = LoadProject(projectFolder);

                    if (project == null)
                    {
                        MessageBox.Show("Invalid project folder! Project.json not found.");
                        return;
                    }

                    TxtProjectLocation.Text = projectFolder;
                    // Show Project Name
                    TxtProjectName.Text = project.ProjectName;

                    // Show Modified Date
                    TxtProjModified.Text = project.ModifiedOn.ToString("yyyy-MM-dd HH:mm:ss");

                    /*
                    // 2. Load SPI metadata (filename, name, id)
                    var spiList = LoadSPIMetadata(projectFolder);

                    //listSPIs.Items.Clear();

                    ClearAllFlowLayoutPanel(flowLayoutPanel1);
                    //Panel newCard = CreateSPICard(name, id, value);
                    AirportSMS_Class asms_cls = new AirportSMS_Class();

                    // Display SPI filenames + SPI name + ID
                    foreach (var spi in spiList)
                    {
                        //listSPIs.Items.Add($"{spi.FileName} | {spi.SPI_Name} | {spi.SPI_Id}");
                        Panel newCard = asms_cls.CreateSPICard(flowLayoutPanel1, spi.SPI_Name_1, spi.SPI_Id_1, "35", spi.SPI_Type_1);
                        flowLayoutPanel1.Controls.Add(newCard);
                    }
                    */
                    updateSPICardToolStripMenuItem_Click(null, null);
                    MessageBox.Show("Project loaded successfully");
                }
            }


        }

        public void UpdateSPICard(string projectFolder, string filterType = null)
        {
            // 2. Load SPI metadata (filename, name, id)
            var spiList = LoadSPIMetadata(projectFolder);

            //listSPIs.Items.Clear();

            ClearAllFlowLayoutPanel(flowLayoutPanel1);
            //Panel newCard = CreateSPICard(name, id, value);
            AirportSMS_Class asms_cls = new AirportSMS_Class();

            flowLayoutPanel1.SuspendLayout();
            // Display SPI filenames + SPI name + ID
            foreach (var spi in spiList)
            {
                //listSPIs.Items.Add($"{spi.FileName} | {spi.SPI_Name} | {spi.SPI_Id}");
                // If filtering is requested, skip non-matching types
                if (!string.IsNullOrEmpty(filterType) && spi.SPI_Type_1 != filterType)
                    continue;

                Panel newCard = asms_cls.CreateSPICard(flowLayoutPanel1, spi.SPI_Name_1, spi.SPI_Id_1, "35", spi.SPI_Type_1);
                flowLayoutPanel1.Controls.Add(newCard);
            }
            flowLayoutPanel1.ResumeLayout(true);

        }

        public void ClearAllFlowLayoutPanel(FlowLayoutPanel thisflowlayout)
        {
            // Dispose each control before clearing the collection to release resources
            foreach (Control control in thisflowlayout.Controls)
            {
                control.Dispose();
            }
            thisflowlayout.Controls.Clear();

        }

        private void openNewSPIsFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHazardMonitoring fhm = new FrmHazardMonitoring();
            fhm.Show();
            fhm.saveSPIToolStripMenuItem.Enabled = false;
        }

        public void updateSPICardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TxtProjectLocation.Text == "")
            {
                MessageBox.Show("No valid project loaded...");
            }
            else
            {
                string projectFolder = TxtProjectLocation.Text;
                TxtFilterSPIType.Text = "";
                UpdateSPICard(projectFolder);
            }
        }

        private void ComboBoxFilterSPI_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtFilterSPIType.Text = ComboBoxFilterSPI_Type.Text;
        }

        private void filterBySelectedSPITypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TxtProjectLocation.Text == "")
            {
                MessageBox.Show("No valid project loaded...");
                return;
            }

            string filterType = TxtFilterSPIType.Text.Trim();

            if (string.IsNullOrEmpty(filterType))
            {
                MessageBox.Show("Select SPI Type to filter...");
                return;
            }

            UpdateSPICard(TxtProjectLocation.Text, filterType);  // ← Pass filter

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //SPI Type combobox
            ComboBoxFilterSPI_Type.Items.Add("Lagging SPIs: Low Probability/High Severity");
            ComboBoxFilterSPI_Type.Items.Add("Precursor SPIs: High Probability/Low Severity");
            ComboBoxFilterSPI_Type.Items.Add("Leading SPIs: Proactive");
        }
    }
}
