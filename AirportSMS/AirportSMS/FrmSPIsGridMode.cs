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
using static AirportSMS.SMS_Project_Package_class;
using Xceed.Words.NET; // Updated namespace for v5+
using Xceed.Document.NET;

namespace AirportSMS
{
    public partial class FrmSPIsGridMode : Form
    {
        // 1. Create a DataTable to hold the data
        DataTable dt = new DataTable();

        public FrmSPIsGridMode()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void viewSPIsInGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];
            if(fm.TxtProjectLocation.Text == "")
            {
                MessageBox.Show("No valid project loaded");
            }
            else
            {
                string projectfolder = fm.TxtProjectLocation.Text;
                LoadALLSPIsJsonToGrid(projectfolder, DGV_ALL_SPIs_GridMode);
            }
        }

        private void FrmSPIsGridMode_Load(object sender, EventArgs e)
        {
            PopulateHeaderOfDt();

        }

        public void PopulateHeaderOfDt()
        {
            // 1. Initialize the DataTable
            dt = new DataTable();

            // --- Basic Information ---
            dt.Columns.Add("SPI Name", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Description", typeof(string));
           

            // --- Boolean Flags (Will appear as Checkboxes) ---
            dt.Columns.Add("Is Related To Objective", typeof(bool));
            dt.Columns.Add("Objective", typeof(string));
            dt.Columns.Add("Is Based On Date/Measure", typeof(bool));
            dt.Columns.Add("Is Specific/Quantifiable", typeof(bool));
            dt.Columns.Add("Is Realistic", typeof(bool));

            // --- Operational Details ---
            dt.Columns.Add("What it Manage", typeof(string));
            dt.Columns.Add("Who it Inform", typeof(string));
            dt.Columns.Add("Unit", typeof(string));
            dt.Columns.Add("Calculation", typeof(string));
            

            // --- Responsibilities ---
            dt.Columns.Add("Resp Collecting", typeof(string));
            dt.Columns.Add("Resp Validating", typeof(string));
            dt.Columns.Add("Resp Monitoring", typeof(string));
            dt.Columns.Add("Resp Reporting", typeof(string));
            dt.Columns.Add("Resp Acting", typeof(string));

            // --- Data Collection Methods ---
            dt.Columns.Add("Where Collected", typeof(string));
            dt.Columns.Add("How Collected", typeof(string));

            // --- Frequencies ---
            dt.Columns.Add("Freq Reporting", typeof(string));
            dt.Columns.Add("Freq Collecting", typeof(string));
            dt.Columns.Add("Freq Monitoring", typeof(string));
            dt.Columns.Add("Freq Analysis", typeof(string));

            // --- Arrays (Comma Separated Strings) ---
            dt.Columns.Add("Prev Year Observed", typeof(string));
            dt.Columns.Add("Curr Year Target %", typeof(string));
            dt.Columns.Add("Curr Year Target Val", typeof(string));
            dt.Columns.Add("Curr Year Observed", typeof(string));

            dt.Columns.Add("Remarks", typeof(string));
            // --- Scalar Values & Progress ---
            dt.Columns.Add("Value Prev Obs", typeof(string));     // SPI_Value_Prev_Obs
            dt.Columns.Add("Value Curr Target", typeof(string));  // SPI_Value_Curr_Target
            dt.Columns.Add("Value Curr Obs", typeof(string));     // SPI_Value_Curr_obs
            dt.Columns.Add("Progress %", typeof(string));

            dt.Columns.Add("SPI ID", typeof(string));
        }


        public void LoadALLSPIsJsonToGrid(string Projectfolder, DataGridView dgv)
        {
            dt.Clear();

           
            try
            {
                string spiFolder = Path.Combine(Projectfolder, "SPIs");

                // 3. Get all JSON files
                string[] files = Directory.GetFiles(spiFolder, "*.json");

                // Options to make JSON case-insensitive (safer)
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                foreach (string file in files)
                {
                    // 4. Read and Deserialize
                    string jsonContent = File.ReadAllText(file);
                    SPI spiData = JsonSerializer.Deserialize<SPI>(jsonContent, options);

                    if (spiData != null)
                    {
                        // 5. Create a new row
                        DataRow row = dt.NewRow();

                        // Map simple fields
                        // --- Basic Information ---
                        row["SPI Name"] = spiData.SPI_Name;
                        row["Type"] = spiData.SPI_Type;
                        row["Description"] = spiData.SPI_Des;

                        // --- Boolean Flags ---
                        row["Is Related To Objective"] = spiData.IsRelatedToObjective;
                        row["Objective"] = spiData.SPI_Related_Objective;
                        row["Is Based On Date/Measure"] = spiData.IsBasedOnDateAndMeasurement;
                        row["Is Specific/Quantifiable"] = spiData.IsSpecificQuantifiable;
                        row["Is Realistic"] = spiData.IsRealistic;

                        // --- Operational Details ---
                        row["What it Manage"] = spiData.SPI_Manage;
                        row["Who it Inform"] = spiData.SPI_Inform;
                        row["Unit"] = spiData.SPI_Unit;
                        row["Calculation"] = spiData.SPI_Calc;

                        // --- Responsibilities ---
                        row["Resp Collecting"] = spiData.SPI_Resp_for_Collecting;
                        row["Resp Validating"] = spiData.SPI_Resp_for_Validating;
                        row["Resp Monitoring"] = spiData.SPI_Resp_for_Monitoring;
                        row["Resp Reporting"] = spiData.SPI_Resp_for_Reporting;
                        row["Resp Acting"] = spiData.SPI_Resp_for_Acting;

                        // --- Data Collection Methods ---
                        row["Where Collected"] = spiData.SPI_Where_data_Collected;
                        row["How Collected"] = spiData.SPI_How_data_Collected;

                        // --- Frequencies ---
                        row["Freq Reporting"] = spiData.SPI_Frequency_of_Reporting;
                        row["Freq Collecting"] = spiData.SPI_Frequency_of_Collecting;
                        row["Freq Monitoring"] = spiData.SPI_Frequency_of_Monitoring;
                        row["Freq Analysis"] = spiData.SPI_Frequency_of_Analysis;

                        // 6. FLATTEN ARRAYS: Convert double[] to comma-separated string
                        // We use string.Join(", ", array) to combine them
                        row["Prev Year Observed"] = spiData.PrevYearObserved != null
                            ? string.Join(", ", spiData.PrevYearObserved)
                            : "";

                        row["Curr Year Target %"] = spiData.CurrYearTargetPercent != null
                            ? string.Join(", ", spiData.CurrYearTargetPercent)
                            : "";

                        row["Curr Year Target Val"] = spiData.CurrYearTargetValue != null
                            ? string.Join(", ", spiData.CurrYearTargetValue)
                            : "";

                        row["Curr Year Observed"] = spiData.CurrYearObserved != null
                            ? string.Join(", ", spiData.CurrYearObserved)
                            : "";

                        // --- Remarks & Scalars ---
                        row["Remarks"] = spiData.SPI_Remarks;

                        row["Value Prev Obs"] = spiData.SPI_Value_Prev_Obs;
                        row["Value Curr Target"] = spiData.SPI_Value_Curr_Target;
                        row["Value Curr Obs"] = spiData.SPI_Value_Curr_obs;
                        row["Progress %"] = spiData.SPI_Progress_Percentage;

                        row["SPI ID"] = spiData.SPI_Id;

                        // Add row to table
                        dt.Rows.Add(row);
                    }
                }

                // 7. Bind to DataGridView
                dgv.DataSource = dt;

                // Optional: Auto-resize columns to fit the new data
                dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                //Read only columns
                dgv.Columns["SPI ID"].ReadOnly = true;
                dgv.Columns["Remarks"].ReadOnly = true;
                dgv.Columns["Value Prev Obs"].ReadOnly = true;
                dgv.Columns["Value Curr Target"].ReadOnly = true;
                dgv.Columns["Value Curr Obs"].ReadOnly = true;
                dgv.Columns["Progress %"].ReadOnly = true;

                dgv.AllowUserToAddRows = false;
                dgv.Columns["SPI Name"].Frozen = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading SPIs: {ex.Message}");
            }
        }



        public void ExportSPIs_DocXv5(DataGridView dgv, bool combineIntoOneFile)
        {
            string exportPath=string.Empty;
            //string exportPath = Path.Combine(Application.StartupPath, "Exported_SPIs");

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // 2. Combine the user's selected path with your specific folder name
                    exportPath = folderDialog.SelectedPath;
                    //string exportPath = Path.Combine(rootFolder, "Exported_SPIs");

                   

                    // Now you can save your 15 pages into exportPath
                    // Example: File.WriteAllText(Path.Combine(exportPath, "page1.txt"), content);
                }
            }

            if(exportPath == string.Empty)
            {
                return;
            }

            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];
            string projectfolder = string.Empty;
            if (fm.TxtProjectLocation.Text == "")
            {
                MessageBox.Show("No valid project loaded...");
            }
            else
            {
                projectfolder = fm.TxtProjectLocation.Text;
                
            }

            string chartPath = Path.Combine(projectfolder, "PlotSPIs");
            //if (!Directory.Exists(exportPath)) Directory.CreateDirectory(exportPath);

            // Columns you want to hide in the Word Report
            string[] columnsToSkip = { "SPI ID" };

            DocX mainDoc = null;
            string mainFileName = Path.Combine(exportPath, "Complete_SPI_Report.docx");

            if (combineIntoOneFile)
            {
                mainDoc = DocX.Create(mainFileName);
            }

            // Process only selected rows from the grid
            var selectedRows = dgv.SelectedRows.Cast<DataGridViewRow>()
                                 .Where(r => !r.IsNewRow)
                                 .ToList();

            for (int idx = 0; idx < selectedRows.Count; idx++)
            {
                DataGridViewRow row = selectedRows[idx];
                string spiName = row.Cells["SPI Name"].Value?.ToString() ?? "Unnamed";
                string spiId = row.Cells["SPI ID"].Value?.ToString() ?? "";

                DocX doc;
                if (combineIntoOneFile)
                {
                    doc = mainDoc;
                }
                else
                {
                    string clean_Spi_Name = SanitizeFileName(spiName);
                    string path = Path.Combine(exportPath, $"{clean_Spi_Name}.docx");
                    // Basic duplicate filename handling
                    int count = 1;
                    while (File.Exists(path)) { path = Path.Combine(exportPath, $"{clean_Spi_Name}({count}).docx"); count++; }
                    doc = DocX.Create(path);
                }

                // --- TITLE ---
                doc.InsertParagraph("SPI for Monitoring")
                   .FontSize(18d).Bold().Color(Xceed.Drawing.Color.MidnightBlue).Alignment = Alignment.center;

                doc.InsertParagraph(spiName)
                   .FontSize(13d).Italic().Alignment = Alignment.center;

                doc.InsertParagraph().SpacingAfter(15d);

                // --- CHART IMAGE ---
                string imageFile = Path.Combine(chartPath, $"{spiId}.png");
                MessageBox.Show(imageFile);

                if (File.Exists(imageFile))
                {
                    Xceed.Document.NET.Image img = doc.AddImage(imageFile);
                    Picture pic = img.CreatePicture();

                    // Auto-scale to fit page width (roughly 500 units)
                    double ratio = (double)pic.Width / pic.Height;
                    pic.Width = 500;
                    pic.Height = (int)(500 / ratio);

                    doc.InsertParagraph().AppendPicture(pic).Alignment = Alignment.center;
                    doc.InsertParagraph().SpacingAfter(15d);
                    MessageBox.Show("Image added");
                }

                // --- DATA TABLE ---
                int visibleCount = dgv.Columns.Cast<DataGridViewColumn>().Count(c => !columnsToSkip.Contains(c.HeaderText));
                Table t = doc.AddTable(visibleCount + 1, 3);
                // 1. THIS PART AUTO-ADJUSTS TO WINDOW WIDTH
                t.AutoFit = AutoFit.Window;
                // 2. THIS PART SETS INDIVIDUAL COLUMN WIDTHS (Total must be 100)
                // SN = 10%, Items = 30%, Value = 60%
                float[] columnWidths = { 10f, 30f, 60f };
                t.SetWidthsPercentage(columnWidths);

                t.Design = TableDesign.TableGrid;
                t.Alignment = Alignment.center;



                // Header Styling
                t.Rows[0].Cells[0].Paragraphs[0].Append("SN").Bold();
                t.Rows[0].Cells[1].Paragraphs[0].Append("Items").Bold();
                t.Rows[0].Cells[2].Paragraphs[0].Append("Value").Bold();
                foreach (var cell in t.Rows[0].Cells) cell.FillColor = Xceed.Drawing.Color.LightSlateGray;

                // Fill Data
                int rowCounter = 1;
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    string header = dgv.Columns[i].HeaderText;
                    if (columnsToSkip.Contains(header)) continue;

                    t.Rows[rowCounter].Cells[0].Paragraphs[0].Append(rowCounter.ToString());
                    t.Rows[rowCounter].Cells[1].Paragraphs[0].Append(header).Bold();
                    t.Rows[rowCounter].Cells[2].Paragraphs[0].Append(row.Cells[i].Value?.ToString() ?? "-");

                    // Zebra Striping
                    if (rowCounter % 2 == 0)
                        foreach (var cell in t.Rows[rowCounter].Cells) cell.FillColor = Xceed.Drawing.Color.WhiteSmoke;

                    rowCounter++;
                }
                doc.InsertTable(t);

                // --- PAGE MANAGEMENT ---
                if (combineIntoOneFile)
                {
                    // If not the last SPI, insert a page break
                    if (idx < selectedRows.Count - 1)
                    {
                        doc.InsertSectionPageBreak();
                    }
                }
                else
                {
                    doc.Save(); // Save individual file immediately
                }
            }

            if (combineIntoOneFile)
            {
                mainDoc.Save();
                MessageBox.Show("All SPIs merged into a single document with page breaks.");
            }
            else
            {
                MessageBox.Show("Individual Word files created successfully.");
            }
        }

        private string SanitizeFileName(string fileName)
        {
            // List of characters not allowed in Windows filenames
            char[] invalidChars = Path.GetInvalidFileNameChars();

            foreach (char c in invalidChars)
            {
                // Replace each invalid character with an underscore
                fileName = fileName.Replace(c, '_');
            }

            return fileName;
        }

        private void selectedRowsToDocxAsMergedFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];
            if (fm.TxtProjectLocation.Text == "")
            {
                MessageBox.Show("No valid project loaded");
            }
            else
            {
                string projectfolder = fm.TxtProjectLocation.Text;

                if (DGV_ALL_SPIs_GridMode != null)
                    ExportSPIs_DocXv5(DGV_ALL_SPIs_GridMode, true);
            }
        }

        private void selectedRowsToDocxAsIndividualFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];
            if (fm.TxtProjectLocation.Text == "")
            {
                MessageBox.Show("No valid project loaded");
            }
            else
            {
                string projectfolder = fm.TxtProjectLocation.Text;

                if (DGV_ALL_SPIs_GridMode != null)
                    ExportSPIs_DocXv5(DGV_ALL_SPIs_GridMode, false);
            }
        }
    }
}
