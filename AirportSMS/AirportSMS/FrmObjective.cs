using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AirportSMS.FrmFlightMovement;

namespace AirportSMS
{
    public partial class FrmObjective : Form
    {
        public FrmObjective()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AirportSMS_Class asmscls = new AirportSMS_Class();
                asmscls.CopySelectedtoClipboard(DGV_Objective);
            }
            catch
            {

            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AirportSMS_Class asmscls = new AirportSMS_Class();
                asmscls.PasteClipboardToDatagridview(DGV_Objective);
            }
            catch
            {

            }
        }

        private void TxtNoOfRowsGen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DGV_Objective.Rows.Clear();
                int n;
                if(TxtNoOfRowsGen.Text == "")
                {
                    n = 0;
                }
                else
                {
                    n = Convert.ToInt32(TxtNoOfRowsGen.Text);
                    for(int i=0; i<n;i++)
                    {
                        DGV_Objective.Rows.Add();
                        DGV_Objective.Rows[i].Cells[0].Value = i + 1;
                    }
                }
                   
            }
            catch
            {

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];
            string projectFolder = string.Empty;
            if (fm.TxtProjectLocation.Text == "")
            {
                MessageBox.Show("No project found....Open project first");
            }
            else
            {
                projectFolder = fm.TxtProjectLocation.Text;
                SaveOrCreateObjective(projectFolder);
                MessageBox.Show("Objective data saved successfully");
            }
        }

        public class Objective
        {
            public int SN { get; set; }
            public string ObjectiveText { get; set; } // renamed to avoid conflict with class name
        }

        private void SaveOrCreateObjective(string projectFolder)
        {
            string folderPath = Path.Combine(projectFolder, "SMSObjective");
            string filePath = Path.Combine(folderPath, "SMSObjective.json");

            bool exists = Directory.Exists(folderPath) && File.Exists(filePath);
            string confirmMessage = exists
                ? "File already exists. Are you sure you want to overwrite it?"
                : "Are you sure you want to save the data?";

            // 1. Ask user for confirmation
            DialogResult result = MessageBox.Show(confirmMessage, "Confirm Save",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                // 2. Ensure folder exists
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                // 3. Extract data from DGV_Objective
                List<Objective> dataToSave = new List<Objective>();
                foreach (DataGridViewRow row in DGV_Objective.Rows)
                {
                    if (row.IsNewRow) continue; // skip the new row at the bottom

                    dataToSave.Add(new Objective
                    {
                        SN = Convert.ToInt32(row.Cells["SN"].Value),
                        ObjectiveText = row.Cells["Objective"].Value?.ToString() ?? ""
                    });
                }

                // 4. Serialize and write
                string jsonString = JsonSerializer.Serialize(dataToSave, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(filePath, jsonString);

                MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmObjective_Load(object sender, EventArgs e)
        {
            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];
            TxtObjCurrentYear.Text = fm.TxtCurrentYear.Text;
            // Use the name of your specific DataGridView

            string projectFolder = string.Empty;
            if (fm.TxtProjectLocation.Text == "")
            {
                MessageBox.Show("No project found....Open project first");
            }
            else
            {
                projectFolder = fm.TxtProjectLocation.Text;
                LoadObjectiveGridsFromJson(projectFolder);
            }
        }

        private void LoadObjectiveGridsFromJson(string projectFolder)
        {
            string folderPath = Path.Combine(projectFolder, "SMSObjective");
            string filePath = Path.Combine(folderPath, "SMSObjective.json");

            if (!File.Exists(filePath))
            {
                // Optional: clear the grid if file doesn't exist
                DGV_Objective.DataSource = null;
                return;
            }

            try
            {
                string json = File.ReadAllText(filePath);

                // Deserialize JSON into a list of Objective
                List<Objective> objectives = JsonSerializer.Deserialize<List<Objective>>(json);

                if (objectives == null)
                {
                    DGV_Objective.DataSource = null;
                    return;
                }

                // Bind to DataGridView
                DGV_Objective.DataSource = objectives;

                // Optional: set nice column headers
                if (DGV_Objective.Columns["ObjectiveText"] != null)
                    DGV_Objective.Columns["ObjectiveText"].HeaderText = "Objective";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading objectives: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /*private void LoadObjectiveGridsFromJson1(string projectFolder)
        {
            string filePath = Path.Combine(projectFolder, "SMSObjective", "SMSObjective.json");

            // 1. Check if file exists
            if (!File.Exists(filePath))
            {
                MessageBox.Show("No objective file found", "File Missing",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Read the file
                string jsonString = File.ReadAllText(filePath);

                // 3. Deserialize back to our class structure
                List<Objective> objectives = JsonSerializer.Deserialize<List<Objective>>(json);

                if (objectives != null)
                {
                    // 4. Populate both grids
                    PopulateGrid(DGV_Objective, loadedData.);
                    

                    MessageBox.Show("Objective loaded successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                       
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        // Helper method to map List data back into specific DGV cells
        private void PopulateGrid(DataGridView dgv, List<Dictionary<string, object>> dataList)
        {
            if (dataList == null) return;

            for (int i = 0; i < dataList.Count; i++)
            {
                // Safety check: Don't exceed row index 12 or the grid's capacity
                if (i > 12 || i >= dgv.Rows.Count) break;

                var rowData = dataList[i];
                int[] targetColumns = { 2, 3, 5, 6 };

                foreach (int colIndex in targetColumns)
                {
                    string colName = dgv.Columns[colIndex].Name;
                    if (string.IsNullOrEmpty(colName)) colName = $"Col{colIndex}";

                    if (rowData.ContainsKey(colName))
                    {
                        // Convert the JsonElement back to a usable value (double/int)
                        dgv.Rows[i].Cells[colIndex].Value = rowData[colName]?.ToString();
                    }
                }
            }
        }













    }
}
