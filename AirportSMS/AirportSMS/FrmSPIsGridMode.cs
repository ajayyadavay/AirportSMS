using ScottPlot.DataSources;
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
using System.Windows.Forms.DataVisualization.Charting;
using Xceed.Document.NET;
using Xceed.Words.NET; // Updated namespace for v5+
using static AirportSMS.SMS_Project_Package_class;

namespace AirportSMS
{
    public partial class FrmSPIsGridMode : Form
    {
        SPISummaryGirdAndDocxClass sumgridocx = new SPISummaryGirdAndDocxClass();

        // 1. Create a DataTable to hold the data
        DataTable dt1 = new DataTable();
        DataTable DT_Summary_All1 = new DataTable();
        DataTable dt_filter_monthly1 = new DataTable();

        bool IsMonthlyFilter = false;

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

        }

        private void LoadAllSPIDatainGridview()
        {

            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];
            if (fm.TxtProjectLocation.Text == "")
            {
                MessageBox.Show("No valid project loaded");
            }
            else
            {
                string projectfolder = fm.TxtProjectLocation.Text;
                sumgridocx.LoadALLSPIsJsonToGrid(projectfolder, DGV_ALL_SPIs_GridMode, dt1);
            }
        }


        private void FrmSPIsGridMode_Load(object sender, EventArgs e)
        {
            
            dt1 = sumgridocx.PopulateHeaderOfDt();

            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];
            if (fm.TxtCurrentYear.Text == "")
                TxtSPISummaryCurrYear.Text = "";
            else
                TxtSPISummaryCurrYear.Text = fm.TxtCurrentYear.Text;

            LoadAllSPIDatainGridview();

            //load to combobox
            ComboBoxSummaryAllColName.Items.Add(DGV_ALL_SPIs_GridMode.Columns["Type"].Name);
            ComboBoxSummaryAllColName.Items.Add(DGV_ALL_SPIs_GridMode.Columns["SPI Name"].Name);
            ComboBoxSummaryAllColName.Items.Add(DGV_ALL_SPIs_GridMode.Columns["Progress %"].Name);
            ComboBoxSummaryAllColName.SelectedIndex = 0;

            FrmSPISummary fsmry = new FrmSPISummary();
            fsmry.PopulateDataTableStructureFromDGV(DGV_ALL_SPIs_GridMode, DT_Summary_All1);
            fsmry.CopyDataFromDGVToDTWithoutColumName(DGV_ALL_SPIs_GridMode, DT_Summary_All1);//copies data in dt from dgv
        }

        
        public void ExportSPIs_DocXv5(DataGridView dgv, bool combineIntoOneFile)
        {
            string exportPath = string.Empty;
            string mainFileName = string.Empty;

            if(combineIntoOneFile)
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Title = "Select location and filename for Complete SPI Report";
                    saveDialog.Filter = "Word Document (*.docx)|*.docx";
                    saveDialog.FileName = "Complete_SPI_Report.docx"; // default name

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Get full path including filename
                        mainFileName = saveDialog.FileName;

                        // Extract folder path
                        exportPath = Path.GetDirectoryName(mainFileName);
                    }
                }

                if (string.IsNullOrEmpty(exportPath) || string.IsNullOrEmpty(mainFileName))
                {
                    return; // user canceled
                }
            }
            else
            {
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        exportPath = folderDialog.SelectedPath;
                    }
                }

                if (exportPath == string.Empty)
                {
                    return;
                }
            }


                // Now mainFileName contains full path + filename
                // exportPath contains folder path
                // Example:
                // mainFileName = "C:\Users\User\Documents\Complete_SPI_Report.docx"
                // exportPath = "C:\Users\User\Documents"


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

            // 🔹 SECTION → COLUMN MAPPING (UPDATED)
            Dictionary<string, List<string>> sectionMap = new Dictionary<string, List<string>>()
            {
                { "A. Basic Information", new List<string>{
                    "SPI Name", "Type"
                }},
                { "B. Selecting SPI", new List<string>{
                    "Is Related To Objective", "Objective", "Is Based On Date/Measure",
                    "Is Specific/Quantifiable", "Is Realistic", "What it Manage", "Who it Inform"
                }},
                { "C. Defining SPI", new List<string>{
                    "Description", "Unit", "Calculation", "Responsible for Collecting", 
                    "Responsible for Validating", "Responsible for Monitoring",
                    "Responsible for Reporting", "Responsible for Acting",
                    "Where data is Collected", "How data is Collected", 
                    "Frequency of Reporting of SPI data",
                    "Frequency of Collecting of SPI data", "Frequency of Monitoring of SPI data",
                    "Frequency of Analysis of SPI data"
                }},
                { "D. Monitoring & Review", new List<string>{
                    "Previous Year Observed","Current Year Target %",
                    "Current Year Target Value", "Current Year Observed",
                    "Remarks", "Mean of Previous Observed", "Mean of Current Target",
                    "Mean of Current Observed", "Progress %"
                }}
            };

            DocX mainDoc = null;
            
            //string mainFileName = Path.Combine(exportPath, "Complete_SPI_Report.docx");

            if (combineIntoOneFile)
            {
                mainDoc = DocX.Create(mainFileName);
                int reportYear = Convert.ToInt32(TxtSPISummaryCurrYear.Text);
                AddCoverPage(mainDoc, reportYear);
                AddTOCPage(mainDoc);
                AddSPIDescriptionPage(mainDoc);
                AddSPISummaryTables(mainDoc, dgv);

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
               /* doc.InsertParagraph("Safety Performance Indicator (SPI)")
                   .FontSize(18d).Bold().Color(Xceed.Drawing.Color.MidnightBlue).Alignment = Alignment.center;
               */

                var spititles = doc.InsertParagraph(spiName)
                   .FontSize(13d)
                   //.Italic()
                   .Heading(HeadingType.Heading1)
                   .Alignment = Alignment.center;
                

                doc.InsertParagraph().SpacingAfter(15d);

                // --- CHART IMAGE ---
                string imageFile = Path.Combine(chartPath, $"{spiId}.png");

                /*if (File.Exists(imageFile))
                {
                    Xceed.Document.NET.Image img = doc.AddImage(imageFile);
                    Picture pic = img.CreatePicture();

                    // Auto-scale to fit page width (roughly 500 units)
                    double ratio = (double)pic.Width / pic.Height;
                    pic.Width = 500;
                    pic.Height = (int)(500 / ratio);

                    doc.InsertParagraph().AppendPicture(pic).Alignment = Alignment.center;
                    doc.InsertParagraph().SpacingAfter(15d);
                }*/

                if (File.Exists(imageFile))
                {
                    var img = doc.AddImage(imageFile);
                    var pic = img.CreatePicture();

                    // Get available page width (approx, minus margins)
                    float pageWidth = doc.PageWidth - doc.MarginLeft - doc.MarginRight;

                    // Maintain aspect ratio
                    double ratio = (double)pic.Width / pic.Height;
                    pic.Width = (int)pageWidth;
                    pic.Height = (int)(pageWidth / ratio);

                    doc.InsertParagraph().AppendPicture(pic).Alignment = Alignment.center;
                    doc.InsertParagraph().SpacingAfter(8d);
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
                /*int rowCounter = 1;
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
                }*/



                // ================== SECTION MAPPED DATA ==================
                int rowCounter = 1;
                int sn = 1;

                // Create a lookup for column index by header
                Dictionary<string, int> columnIndexMap = dgv.Columns
                    .Cast<DataGridViewColumn>()
                    .ToDictionary(c => c.HeaderText, c => c.Index);

                foreach (var section in sectionMap)
                {
                    // 🔹 Section Header (Merged 3 Columns)
                    t.Rows[rowCounter].Cells[0].Paragraphs[0]
                        .Append(section.Key)
                        .Bold()
                        .FontSize(11);

                    t.Rows[rowCounter].MergeCells(0, 2);
                    t.Rows[rowCounter].Cells[0].FillColor = Xceed.Drawing.Color.LightGray;

                    rowCounter++;

                    // 🔹 Section Items
                    foreach (string columnName in section.Value)
                    {
                        if (!columnIndexMap.ContainsKey(columnName)) continue;

                        if (rowCounter >= t.RowCount)
                            t.InsertRow();

                        int colIndex = columnIndexMap[columnName];

                        t.Rows[rowCounter].Cells[0].Paragraphs[0].Append(sn.ToString());
                        t.Rows[rowCounter].Cells[1].Paragraphs[0].Append(columnName).Bold();
                        t.Rows[rowCounter].Cells[2].Paragraphs[0]
                            .Append(row.Cells[colIndex].Value?.ToString() ?? "-");

                        // Zebra striping
                        if (rowCounter % 2 == 0)
                            foreach (var cell in t.Rows[rowCounter].Cells)
                                cell.FillColor = Xceed.Drawing.Color.WhiteSmoke;

                        rowCounter++;
                        sn++;
                    }
                }
                // ================== END SECTION MAPPED DATA ==================


                doc.InsertTable(t);

                // --- PAGE MANAGEMENT ---
                if (combineIntoOneFile)
                {
                    // If not the last SPI, insert a page break
                    /*if (idx < selectedRows.Count - 1)
                    {
                        doc.InsertSectionPageBreak();
                    }*/
                    doc.InsertSectionPageBreak();
                }
                else
                {
                    doc.Save(); // Save individual file immediately
                }
            }

            if (combineIntoOneFile)
            {
                //AddDashboardPage(mainDoc, dgv);
                AddDashboardCards(mainDoc, dgv);
                mainDoc.Save();
                MessageBox.Show("All SPIs merged into a single document with page breaks.");
            }
            else
            {
                MessageBox.Show("Individual Word files created successfully.");
            }
        }


        private void AddTOCPage(DocX doc)
        {
            // Title of the TOC
            doc.InsertParagraph("TABLE OF CONTENTS")
                .FontSize(18)
                .Bold()
                .Alignment = Alignment.center;

            doc.InsertParagraph(); // spacing

            // DocX v2021+ requires a dictionary for switches
            var tocSwitches = new Dictionary<TableOfContentsSwitches, string>()
                {
                    { TableOfContentsSwitches.O, "" }, // Include page numbers
                    { TableOfContentsSwitches.U, "" }, // Add hyperlinks
                    { TableOfContentsSwitches.Z, "" }  // Hide web formatting
                };

            // Insert TOC for Heading1 only
            doc.InsertTableOfContents(
                "Click to update Table of Contents", // placeholder text for Word
                tocSwitches,
                "1", // start heading
                1  // end heading
            );

                // Add a page break after TOC
                doc.InsertSectionPageBreak();

                // Enable auto-update when Word opens
                //doc.CoreDocument.Settings.UpdateFieldsOnOpen = true;
        }




        private void AddCoverPage(DocX doc, int year)
        {
            doc.InsertParagraph("\n\n\n");

            var title = doc.InsertParagraph("SAFETY PERFORMANCE INDICATORS (SPI)")
                .FontSize(26)
                .Bold()
                .Color(Xceed.Drawing.Color.MidnightBlue)
                .Alignment = Alignment.center;

            doc.InsertParagraph("\n\n\n\n");

            doc.InsertParagraph("Safety Office")
                .FontSize(18)
                .Italic()
                .Alignment = Alignment.center;

            doc.InsertParagraph("\n\n\n\n\n\n\n\n");

            // Decorative aviation-style line
            var line = doc.InsertParagraph("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━")
                .FontSize(10)
                .Color(Xceed.Drawing.Color.DarkSlateGray)
                .Alignment = Alignment.center;

            doc.InsertParagraph("\n");

            doc.InsertParagraph("SPIs Monitoring Report")
                .FontSize(16)
                .Bold()
                .Alignment = Alignment.center;

            doc.InsertParagraph("\n\n\n\n\n\n");

            doc.InsertParagraph($"Year: {year}")
                .FontSize(14)
                .Bold()
                .Alignment = Alignment.center;


            /* doc.InsertParagraph($"Generated On: {DateTime.Now:dd MMM yyyy}")
                .FontSize(10)
                .Alignment = Alignment.center;*/
           
            // Page break
            doc.InsertSectionPageBreak();
        }

        private void AddSPIDescriptionPage(DocX doc)
        {
            // Title
            doc.InsertParagraph("Safety performance Indicators (SPIs)")
                .Heading(HeadingType.Heading1)
                .FontSize(15)
                .Bold()
                .SpacingAfter(12);

            // 1. Definition
            doc.InsertParagraph("1. Definition: Safety Performance Indicators (SPIs) are")
                .Bold()
                .FontSize(11)
                .SpacingAfter(6);

            doc.InsertParagraph("• measurable metrics used to monitor and assess an organization's safety performance,")
                .FontSize(11);
            doc.InsertParagraph("• helping to verify safety goals,")
                .FontSize(11);
            doc.InsertParagraph("• identify trends,")
                .FontSize(11);
            doc.InsertParagraph("• detect risks, and")
                .FontSize(11);
            doc.InsertParagraph("• check SMS effectiveness through data like incident rates, audit findings, and training compliance")
                .FontSize(11)
                .SpacingAfter(12);

            // 2. Types
            doc.InsertParagraph("2. Types")
                .Bold()
                .FontSize(11)
                .SpacingAfter(6);

            // A. Quantitative and Qualitative
            doc.InsertParagraph("A. Quantitative and Qualitative")
                .Bold()
                .FontSize(11)
                .SpacingAfter(4);

            doc.InsertParagraph("i. Qualitative: descriptive e.g. employee perception of safety culture")
                .FontSize(11)
                .SpacingAfter(4);

            doc.InsertParagraph("ii. Quantitative:")
                .FontSize(11)
                .SpacingAfter(2);

            doc.InsertParagraph("• expressed as number (e.g. 10 incursions)")
                .FontSize(11);
            doc.InsertParagraph("• expressed as rate (e.g. 10 incursions per 1000 movement)")
                .FontSize(11)
                .SpacingAfter(10);

            // B. Leading and lagging
            doc.InsertParagraph("B. Leading and lagging")
                .Bold()
                .FontSize(11)
                .SpacingAfter(4);

            doc.InsertParagraph("i. Lagging:")
                .FontSize(11)
                .SpacingAfter(2);

            doc.InsertParagraph("• SPIs that have already occurred")
                .FontSize(11);
            doc.InsertParagraph("• Outcome based")
                .FontSize(11);
            doc.InsertParagraph("• Reactive")
                .FontSize(11);
            doc.InsertParagraph("• Normally negative outcomes organization aim to avoid")
                .FontSize(11);
            doc.InsertParagraph("• Types:")
                .FontSize(11);

            doc.InsertParagraph("o Low probability/high severity (lagging SPIs): accidents or serious incidents e.g. aircraft damage due to bird strike")
                .FontSize(11);
            doc.InsertParagraph("o High probability/low severity (Precursor SPIS): help detect risk building up before an accident happens e.g. bird radar detection which indicates level of bird activity rather than actual bird strikes")
                .FontSize(11)
                .SpacingAfter(8);

            doc.InsertParagraph("ii. Leading")
                .FontSize(11)
                .SpacingAfter(2);

            doc.InsertParagraph("• Measures process and inputs")
                .FontSize(11);
            doc.InsertParagraph("• Activity or process SPIs")
                .FontSize(11);
            doc.InsertParagraph("• Proactive")
                .FontSize(11);
            doc.InsertParagraph("• Monitors and measures condition that have potential to lead or to contribute to a specific outcome")
                .FontSize(11);
            doc.InsertParagraph("• E.g. Percentage of staff who have successfully completed safety training on time")
                .FontSize(11);
            doc.InsertParagraph("• E.g. frequency of bird scaring activities")
                .FontSize(11)
                .SpacingAfter(12);

            // 3. Link between leading, precursor and lagging SPIs
            doc.InsertParagraph("3. Link between leading, precursor and lagging SPIs")
                .Bold()
                .FontSize(11)
                .SpacingAfter(4);

            doc.InsertParagraph("For Bird hazard management:")
                .FontSize(11)
                .SpacingAfter(2);

            doc.InsertParagraph("• Leading SPI: Bird scaring activities (Actions)")
                .FontSize(11);
            doc.InsertParagraph("• Precursor SPI: Bird sightings or radar detections (Warning)")
                .FontSize(11);
            doc.InsertParagraph("• Lagging SPI: No. of bird strikes (Outcome)")
                .FontSize(11);
            doc.InsertParagraph("• Note: If leading activities decrease, precursor spikes and lagging incidents increase.")
                .FontSize(11)
                .SpacingAfter(6);

            doc.InsertParagraph("Sequence of defining: Lagging → Precursor → Leading")
                .FontSize(11)
                .SpacingAfter(4);

            doc.InsertParagraph("Note: The only real mistake is the one from which we learn nothing. – John Powell")
                .Italic()
                .FontSize(11)
                .SpacingAfter(12);

            // 4. Selecting SPI
            doc.InsertParagraph("4. Selecting SPI")
                .Bold()
                .FontSize(11)
                .SpacingAfter(4);

            doc.InsertParagraph("SPIs should focus on parameters that are important indicators of safety performance, rather than on those that are easy to attain.")
                .FontSize(11)
                .SpacingAfter(4);

            doc.InsertParagraph("SPIs should be:")
                .FontSize(11)
                .SpacingAfter(2);

            doc.InsertParagraph("a) related to the safety objective they aim to indicate;")
                .FontSize(11);
            doc.InsertParagraph("b) selected or developed based on available data and reliable measurement;")
                .FontSize(11);
            doc.InsertParagraph("c) appropriately specific and quantifiable; and")
                .FontSize(11);
            doc.InsertParagraph("d) realistic, by taking into account the possibilities and constraints of the organization.")
                .FontSize(11);

            doc.InsertParagraph("A combination of SPIs is usually required to provide a clear indication of safety performance. There should be a clear link between lagging and leading SPIs. Ideally lagging SPIs should be defined before determining leading SPIs.")
                .FontSize(11)
                .SpacingAfter(12);

            // 5. Defining SPIs
            doc.InsertParagraph("5. Defining SPIs")
                .Bold()
                .FontSize(11)
                .SpacingAfter(4);

            doc.InsertParagraph("The contents of each SPI should include:")
                .FontSize(11)
                .SpacingAfter(2);

            doc.InsertParagraph("a) a description of what the SPI measures;")
                .FontSize(11);
            doc.InsertParagraph("b) the purpose of the SPI (what it is intended to manage and who it is intended to inform);")
                .FontSize(11);
            doc.InsertParagraph("c) the units of measurement and any requirements for its calculation;")
                .FontSize(11);
            doc.InsertParagraph("d) who is responsible for collecting, validating, monitoring, reporting and acting on the SPI (these may be staff from different parts of the organization);")
                .FontSize(11);
            doc.InsertParagraph("where or how the data should be collected; and")
                .FontSize(11);
            doc.InsertParagraph("f) the frequency of reporting, collecting, monitoring and analysis of the SPI data.")
                .FontSize(11)
                .SpacingAfter(12);

            // 6. SPIs and safety reporting
            doc.InsertParagraph("6. SPIs and safety reporting")
                .Bold()
                .FontSize(11)
                .SpacingAfter(4);

            doc.InsertParagraph("In simple terms, reporting bias happens when the number of safety reports goes up or down for the wrong reasons, making data less accurate:")
                .FontSize(11);

            doc.InsertParagraph("Underreporting: People may stop reporting hazards if they are confused by new rules or don't trust them yet.")
                .FontSize(11);
            doc.InsertParagraph("Over-reporting: People might report too much if new laws give them extra protection or incentives.")
                .FontSize(11);

            doc.InsertParagraph("The Bottom Line: Even though these biases can \"mess up\" the data used to measure safety, reports are still very useful as long as managers look at them carefully and understand the context.")
                .FontSize(11)
                .SpacingAfter(10);

            // Closing
            doc.InsertParagraph("This document contains monitoring report of SPI with graphs, table and summary.")
                .FontSize(11);

            doc.InsertSectionPageBreak();
        }



        private int CalculateSPITotal(string currentObs)
        {
            if (string.IsNullOrWhiteSpace(currentObs))
                return 0;

            var parts = currentObs.Split(',');
            int total = 0;

            // Skip Year → start from index 1
            for (int i = 1; i < parts.Length; i++)
            {
                if (int.TryParse(parts[i].Trim(), out int val))
                    total += val;
            }
            return total;
        }

        private void AddSPISummaryTables(DocX doc, DataGridView dgv)
        {
            var spiGroups = dgv.Rows.Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .GroupBy(r => r.Cells["Type"].Value?.ToString() ?? "Unknown");

            foreach (var group in spiGroups)
            {
                doc.InsertParagraph($"SPI SUMMARY – {group.Key}")
                    .Heading(HeadingType.Heading1)
                    .FontSize(15)
                    .Bold();

                Table t = doc.AddTable(group.Count() + 1, 5);
                t.Design = TableDesign.TableGrid;
                t.AutoFit = AutoFit.Window;

                // Header
                t.Rows[0].Cells[0].Paragraphs[0].Append("SN").Bold();
                t.Rows[0].Cells[1].Paragraphs[0].Append("SPI Name").Bold();
                t.Rows[0].Cells[2].Paragraphs[0].Append("Description").Bold();
                t.Rows[0].Cells[3].Paragraphs[0].Append("SPI Total (Current Year)").Bold();
                t.Rows[0].Cells[4].Paragraphs[0].Append("Progress %").Bold();

                int sn = 1;
                int r = 1;

                foreach (var row in group)
                {
                    int spiTotal = CalculateSPITotal(
                        row.Cells["Current Year Observed"].Value?.ToString()
                        );

                    t.Rows[r].Cells[0].Paragraphs[0].Append(sn.ToString());
                    t.Rows[r].Cells[1].Paragraphs[0].Append(row.Cells["SPI Name"].Value?.ToString());
                    t.Rows[r].Cells[2].Paragraphs[0].Append(row.Cells["Description"].Value?.ToString());
                    t.Rows[r].Cells[3].Paragraphs[0].Append(spiTotal.ToString());
                    t.Rows[r].Cells[4].Paragraphs[0]
                        .Append(row.Cells["Progress %"].Value?.ToString());

                    r++;
                    sn++;
                }

                doc.InsertTable(t);
                doc.InsertSectionPageBreak();
            }
        }

        private void AddDashboardPage(DocX doc, DataGridView dgv)
        {
            //doc.InsertSectionPageBreak();
            doc.InsertParagraph("SPI DASHBOARD")
                .Heading(HeadingType.Heading1)
                .FontSize(15)
                .Bold()
                .Alignment = Alignment.center;

            doc.InsertParagraph();

            Table t = doc.AddTable(dgv.Rows.Count + 1, 4);
            t.Design = TableDesign.LightGridAccent2;
            t.AutoFit = AutoFit.Window;

            // Header
            t.Rows[0].Cells[0].Paragraphs[0].Append("SPI Name").Bold();
            t.Rows[0].Cells[1].Paragraphs[0].Append("Type").Bold();
            t.Rows[0].Cells[2].Paragraphs[0].Append("SPI Total").Bold();
            t.Rows[0].Cells[3].Paragraphs[0].Append("Progress %").Bold();

            int r = 1;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                int spiTotal = CalculateSPITotal(
                    row.Cells["Current Year Observed"].Value?.ToString()
                );

                double.TryParse(row.Cells["Progress %"].Value?.ToString(), out double progress);

                t.Rows[r].Cells[0].Paragraphs[0].Append(row.Cells["SPI Name"].Value?.ToString());
                t.Rows[r].Cells[1].Paragraphs[0].Append(row.Cells["Type"].Value?.ToString());
                t.Rows[r].Cells[2].Paragraphs[0].Append(spiTotal.ToString());
                t.Rows[r].Cells[3].Paragraphs[0].Append($"{progress}%");

                // Dashboard coloring
                var color =
                    progress >= 80 ? Xceed.Drawing.Color.LightGreen :
                    progress >= 50 ? Xceed.Drawing.Color.Khaki :
                                     Xceed.Drawing.Color.LightSalmon;

                foreach (var cell in t.Rows[r].Cells)
                    cell.FillColor = color;

                r++;
            }

            doc.InsertTable(t);
        }

        private void AddDashboardCards(DocX doc, DataGridView dgv)
        {
            //doc.InsertSectionPageBreak();
            // 1. Add Dashboard Title
            doc.InsertParagraph("SPI DASHBOARD")
                .Heading(HeadingType.Heading1)
                .FontSize(15)
                //.Color(Xceed.Drawing.Color.DarkSlateGray)
                .Bold()
                //.Font("Segoe UI") // Web-like font
                .Alignment = Alignment.center;

            doc.InsertParagraph(""); // Spacing below title

            // 2. Filter valid rows (exclude new row placeholder)
            var dataRows = dgv.Rows.Cast<DataGridViewRow>()
                                   .Where(r => !r.IsNewRow)
                                   .ToList();

            if (dataRows.Count == 0) return;

            // 3. Calculate Table Dimensions
            int columnsPerRow = 3;
            int totalRows = (int)Math.Ceiling((double)dataRows.Count / columnsPerRow);

            // 4. Create the Table
            // We create a table with specific width logic. 
            // Note: In DocX, tables usually expand to page width by default.
            var table = doc.AddTable(totalRows, columnsPerRow);
            table.Design = TableDesign.TableGrid; // Standard grid to start
            table.Alignment = Alignment.center;

            // 5. Global Table Styling (The "Card Gap" Trick)
            // We set all borders to White and Thick to simulate space between cards
            Xceed.Document.NET.Border BorderColor;
            if (dashboardWithBackgroundToolStripMenuItem.Checked)
                BorderColor = new Xceed.Document.NET.Border(Xceed.Document.NET.BorderStyle.Tcbs_single, BorderSize.seven, 0, Xceed.Drawing.Color.White);
            else
                BorderColor = new Xceed.Document.NET.Border(Xceed.Document.NET.BorderStyle.Tcbs_single, BorderSize.seven, 0, Xceed.Drawing.Color.LightSlateGray);

            table.SetBorder(TableBorderType.InsideH, BorderColor);
            table.SetBorder(TableBorderType.InsideV, BorderColor);
            table.SetBorder(TableBorderType.Top, BorderColor);
            table.SetBorder(TableBorderType.Bottom, BorderColor);
            table.SetBorder(TableBorderType.Left, BorderColor);
            table.SetBorder(TableBorderType.Right, BorderColor);

            // 6. Loop and Fill Cards
            for (int i = 0; i < dataRows.Count; i++)
            {
                int r = i / columnsPerRow;
                int c = i % columnsPerRow;
                var dgvRow = dataRows[i];

                // --- Extract Data ---
                string spiName = dgvRow.Cells["SPI Name"].Value?.ToString() ?? "N/A";
                string type = dgvRow.Cells["Type"].Value?.ToString() ?? "-";

                // Handle parsing safely
                double.TryParse(dgvRow.Cells["Progress %"].Value?.ToString(), out double progress);
                string currentObserved = dgvRow.Cells["Current Year Observed"].Value?.ToString();

                // (Assuming you have this method, otherwise replace with direct value)
                // int spiTotal = CalculateSPITotal(currentObserved); 
                string displayTotal = currentObserved; // specific display logic

                // --- Determine Color (Traffic Light System) ---
                Xceed.Drawing.Color cardColor_fg;
                Xceed.Drawing.Color cardColor;


                //Dark foreground color on card without background
                // 0 → 50  (Red → Blue)
                if (progress <= 50)
                {
                    double t = progress / 50.0;   // 0 to 1

                    int r1 = (int)(255 * (1 - t));         // 255 → 0
                    int g = 0;                            // stays 0
                    int b = (int)(255 * t);               // 0 → 255

                    cardColor_fg = Xceed.Drawing.Color.Parse(r1, g, b);
                }
                // 50 → 100 (Blue → Green)
                else
                {
                    double t = (progress - 50) / 50.0; // 0 to 1

                    int r1 = 0;                                // stays 0
                    int g = (int)(255 * t);                   // 0 → 255
                    int b = (int)(255 * (1 - t));             // 255 → 0

                    cardColor_fg = Xceed.Drawing.Color.Parse(r1, g, b);
                }

                //softer card color
                // 0 → 50 (Pastel Red → Pastel Blue)
                if (progress <= 50)
                {
                    double t = progress / 50.0;

                    // Base of 200 ensures it's always a light pastel
                    int r1 = (int)(200 + (55 * (1 - t))); // 255 → 200
                    int g = 200;                         // Stays light
                    int b = (int)(200 + (55 * t));       // 200 → 255

                    cardColor = Xceed.Drawing.Color.Parse(r1, g, b);
                }
                // 50 → 100 (Pastel Blue → Pastel Green)
                else
                {
                    double t = (progress - 50) / 50.0;

                    int r1 = 200;                         // Stays light
                    int g = (int)(200 + (55 * t));       // 200 → 255
                    int b = (int)(200 + (55 * (1 - t))); // 255 → 200

                    cardColor = Xceed.Drawing.Color.Parse(r1, g, b);
                }


                /*if (progress >= 80) cardColor = Xceed.Drawing.Color.Parse(220, 255, 220);  //LightGreen; // Light Pastel Green
                else if (progress >= 50) cardColor = Xceed.Drawing.Color.Parse(255, 250, 205); // Lemon Chiffon (Khaki-ish)
                else cardColor = Xceed.Drawing.Color.Parse(255, 228, 225); // Misty Rose (Red-ish)
                */
                // --- Style the "Card" (Cell) ---
                var cell = table.Rows[r].Cells[c];

                if(dashboardWithBackgroundToolStripMenuItem.Checked)
                    cell.FillColor = cardColor;
                else
                    cell.FillColor = Xceed.Drawing.Color.White;

                cell.VerticalAlignment = VerticalAlignment.Center;

                // Add Padding (Margin inside cell)
                cell.MarginTop = 10;
                cell.MarginBottom = 10;
                cell.MarginLeft = 10;
                cell.MarginRight = 10;

                // --- Content Formatting ---
                // Line 1: SPI Name (Bold, Larger)
                var pName = cell.InsertParagraph(spiName);
                

                // Line 2: Type (Smaller, Gray)
                var pType = cell.InsertParagraph($"Type: {type}");
                

                // Line 3: Metrics
                var pMetrics = cell.InsertParagraph($"Progress: {progress}%");
               

                if(dashboardWithBackgroundToolStripMenuItem.Checked)
                {
                    pName.Bold().FontSize(12d).Color(Xceed.Drawing.Color.Black).Font("Segoe UI").Alignment = Alignment.center;
                    pType.FontSize(9d).Italic().Color(Xceed.Drawing.Color.DimGray).Alignment = Alignment.center;
                    pMetrics.FontSize(11d).Color(Xceed.Drawing.Color.Black).Bold().Alignment = Alignment.center;
                }
                else
                {
                    pName.Bold().FontSize(12d).Color(Xceed.Drawing.Color.Black).Font("Segoe UI").Alignment = Alignment.center;
                    pType.FontSize(9d).Italic().Color(Xceed.Drawing.Color.DimGray).Alignment = Alignment.center;
                    pMetrics.FontSize(11d).Color(cardColor_fg).Bold().Alignment = Alignment.center;
                }

                // Optional: Add visual bar using pipe characters if shapes fail
                // string progressBar = new string('█', (int)(progress / 10)) + new string('░', 10 - (int)(progress / 10));
                // cell.InsertParagraph(progressBar).Color(System.Drawing.Color.Gray).Alignment = Alignment.center;
            }

            // 7. Insert the table into the document
            doc.InsertTable(table);
            doc.InsertParagraph(""); // Bottom spacing
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

        private void dashboardWithBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dashboardWithBackgroundToolStripMenuItem.Checked = true;
            dashboardWithoutBackgroundToolStripMenuItem.Checked = false;
        }

        private void dashboardWithoutBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dashboardWithBackgroundToolStripMenuItem.Checked = false;
            dashboardWithoutBackgroundToolStripMenuItem.Checked = true;
        }

        private void ComboBoxSummaryAllColName_SelectedIndexChanged(object sender, EventArgs e)
        {
            AirportSMS_Class acls = new AirportSMS_Class();
            if (ComboBoxSummaryAllColName.SelectedItem == null)
                return;

            string columnName = ComboBoxSummaryAllColName.SelectedItem.ToString();

            acls.LoadDistinctValuesFromDT(
               dt1,
                columnName,
                ComboBoxFilterValueALL
            );
        }

        private void BtnAscendingAll_Click(object sender, EventArgs e)
        {
            //FrmSPISummary fsmry = new FrmSPISummary();
            int fromRow = 0; //rowindex
            int toRow = DGV_ALL_SPIs_GridMode.RowCount - 1;   //rowindex        // <-- rows to sort -1 as there is no row summation at last row
        
            int sortColumn = 0;
            bool ascending = true;

            if (ComboBoxSummaryAllColName.Text == null)
                return;

            string colname = ComboBoxSummaryAllColName.Text;

            sortColumn = DGV_ALL_SPIs_GridMode.Columns[colname].Index;


            var data = FrmSPISummary.ReadDgvRows(DGV_ALL_SPIs_GridMode, fromRow, toRow);
            var sorted = FrmSPISummary.SortData(data, sortColumn, ascending);
            FrmSPISummary.WriteDgvRows(DGV_ALL_SPIs_GridMode, sorted, fromRow);
        }

        private void BtnDescendingAll_Click(object sender, EventArgs e)
        {
            int fromRow = 0; //rowindex
            int toRow = DGV_ALL_SPIs_GridMode.RowCount - 1;   //rowindex        // <-- rows to sort -1 instead of -2
         
            int sortColumn = 0;
            bool ascending = false;

            if (ComboBoxSummaryAllColName.Text == null)
                return;

            string colname = ComboBoxSummaryAllColName.Text;

            sortColumn = DGV_ALL_SPIs_GridMode.Columns[colname].Index;


            var data = FrmSPISummary.ReadDgvRows(DGV_ALL_SPIs_GridMode, fromRow, toRow);
            var sorted = FrmSPISummary.SortData(data, sortColumn, ascending);
            FrmSPISummary.WriteDgvRows(DGV_ALL_SPIs_GridMode, sorted, fromRow);
        }

        private void BtnDefault_Click(object sender, EventArgs e)
        {
            int fromRow = 0; //rowindex
            int toRow = DGV_ALL_SPIs_GridMode.RowCount - 1;   //rowindex        // <-- rows to sort -1 instead of -2
           
            int sortColumn = 0;
            bool ascending = true;


            var data = FrmSPISummary.ReadDgvRows(DGV_ALL_SPIs_GridMode, fromRow, toRow);
            var sorted = FrmSPISummary.SortData(data, sortColumn, ascending);
            FrmSPISummary.WriteDgvRows(DGV_ALL_SPIs_GridMode, sorted, fromRow);
        }

        private void BtnFilterAll_Click(object sender, EventArgs e)
        {
            AirportSMS_Class acls = new AirportSMS_Class();
            if (ComboBoxSummaryAllColName.SelectedItem == null ||
                    ComboBoxFilterValueALL.SelectedItem == null)
                return;


            if (IsMonthlyFilter)
            {
                acls.FilterDGV_DT(
                    DGV_ALL_SPIs_GridMode,
                    dt_filter_monthly1,
                    ComboBoxSummaryAllColName.SelectedItem.ToString(),
                    ComboBoxFilterValueALL.SelectedItem.ToString()
                );

            }
            else
            {
                acls.FilterDGV_DT(
                    DGV_ALL_SPIs_GridMode,
                    DT_Summary_All1,
                    ComboBoxSummaryAllColName.SelectedItem.ToString(),
                    ComboBoxFilterValueALL.SelectedItem.ToString()
                );
            }

            sumgridocx.DGV_SPI_Summary_GridMode_Settings(DGV_ALL_SPIs_GridMode);
            TxtNoOfFilteredData.Text = "Total filtered rows = " + DGV_ALL_SPIs_GridMode.RowCount;

        }

        private void BtnClearFilterAll_Click(object sender, EventArgs e)
        {
            //IsMonthlyFilter = false;
            AirportSMS_Class acls = new AirportSMS_Class();
            if (IsMonthlyFilter)
            {
                acls.ClearFilter(DGV_ALL_SPIs_GridMode, dt_filter_monthly1);
            }
            else
            {
                acls.ClearFilter(DGV_ALL_SPIs_GridMode, DT_Summary_All1);
            }

            sumgridocx.DGV_SPI_Summary_GridMode_Settings(DGV_ALL_SPIs_GridMode);
            TxtNoOfFilteredData.Text = "Total rows =" + DGV_ALL_SPIs_GridMode.RowCount;
           
        }

        

        public void ApplyMonthFilter_GridMode(List<int> selectedMonthCols)
        {
            FrmSPISummary fsmry = new FrmSPISummary();

            DataTable dtFiltered = DT_Summary_All1.Copy();

            int totalRowIndex = dtFiltered.Rows.Count - 1;

            // Reset total row
            /*for (int c = 4; c <= 16; c++)
                dtFiltered.Rows[totalRowIndex][c] = 0*/
            int CurrColIndex = dtFiltered.Columns.IndexOf("Current Year Observed");
            double[] MonthData = null;
            //double[] TempMonthData = null;
            for (int r = 0; r <= totalRowIndex; r++)
            { 
                //double rowTotal = 0;
                MonthData = sumgridocx.ReadingCommaSparatedMonthlyDataFromDGV(DGV_ALL_SPIs_GridMode, r, "Current Year Observed");
                for(int c = 1; c<=12; c++)
                {
                    if (!selectedMonthCols.Contains(c))
                    {
                        //dtFiltered.Rows[r][c] = 0;
                        MonthData[c] = 0;
                    }
                    else
                    {
                        //double val = Convert.ToDouble(dtFiltered.Rows[r][c]);
                        //rowTotal += val;
                        //dtFiltered.Rows[totalRowIndex][c] = Convert.ToDouble(dtFiltered.Rows[totalRowIndex][c]) + val;
                    }
                    
                }

                //Join the Year + the 12 modified doubles into one comma-separated string
                string formattedString = string.Join(",", MonthData);

                //Save back to the DataTable
                dtFiltered.Rows[r][CurrColIndex] = formattedString;

                //dtFiltered.Rows[r][16] = rowTotal;
                //dtFiltered.Rows[totalRowIndex][16] = Convert.ToDouble(dtFiltered.Rows[totalRowIndex][16]) + rowTotal;
            }

            
            fsmry.BindDTtoDGV(DGV_ALL_SPIs_GridMode, dtFiltered);
        }

        private void BtnSelectedMonthView_Click(object sender, EventArgs e)
        {
            FrmSPISummary fsmry = new FrmSPISummary();

            if (string.IsNullOrWhiteSpace(TxtSelectedMonth.Text))
            {
                fsmry.BindDTtoDGV(DGV_ALL_SPIs_GridMode, DT_Summary_All1);
                IsMonthlyFilter = false;
                return;
            }

            try
            {
                List<int> selectedMonths = fsmry.ParseSelectedMonths(TxtSelectedMonth.Text,0);

                ApplyMonthFilter_GridMode(selectedMonths);

                //MessageBox.Show("Filtered = " + TxtSelectedMonth.Text);

                IsMonthlyFilter = true;
                //FillingDataSPISummaryDGV_DT();
                //FillingDataInMonthlySummaryDGV_DT();

                //PlotGraphScottPlotSummary();
                //PlotGraphScottPlotMonthly();

                fsmry.PopulateDataTableStructureFromDGV(DGV_ALL_SPIs_GridMode, dt_filter_monthly1);//creates column in dt from dgv
                fsmry.CopyDataFromDGVToDTWithoutColumName(DGV_ALL_SPIs_GridMode, dt_filter_monthly1);//copies data in dt from dgv

            }
            catch
            {
                MessageBox.Show("Invalid month format.\nExamples:\n1-12\n8-10\n2,8,11,12");
            }
        }
    }
}
