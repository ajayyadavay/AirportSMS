using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;
using static AirportSMS.SMS_Project_Package_class;

namespace AirportSMS
{
    internal class SPISummaryGirdAndDocxClass
    {

        public DataTable PopulateHeaderOfDt()
        {
            DataTable dt = new DataTable();
            // If dt is null, initialize it. If not, this line isn't strictly needed 
            // if you already did 'new DataTable()' in the Form.
            //if (dt == null) dt = new DataTable();

            // --- Basic Information ---
            dt.Columns.Add("SN", typeof(Int16));
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
            dt.Columns.Add("Responsible for Collecting", typeof(string));
            dt.Columns.Add("Responsible for Validating", typeof(string));
            dt.Columns.Add("Responsible for Monitoring", typeof(string));
            dt.Columns.Add("Responsible for Reporting", typeof(string));
            dt.Columns.Add("Responsible for Acting", typeof(string));

            // --- Data Collection Methods ---
            dt.Columns.Add("Where data is Collected", typeof(string));
            dt.Columns.Add("How data is Collected", typeof(string));

            // --- Frequencies ---
            dt.Columns.Add("Frequency of Reporting of SPI data", typeof(string));
            dt.Columns.Add("Frequency of Collecting of SPI data", typeof(string));
            dt.Columns.Add("Frequency of Monitoring of SPI data", typeof(string));
            dt.Columns.Add("Frequency of Analysis of SPI data", typeof(string));

            // --- Arrays (Comma Separated Strings) ---
            dt.Columns.Add("Previous Year Observed", typeof(string));
            dt.Columns.Add("Current Year Target %", typeof(string));
            dt.Columns.Add("Current Year Target Value", typeof(string));
            dt.Columns.Add("Current Year Observed", typeof(string));

            dt.Columns.Add("Remarks", typeof(string));
            // --- Scalar Values & Progress ---
            dt.Columns.Add("Mean of Previous Observed", typeof(double));     // SPI_Value_Prev_Obs
            dt.Columns.Add("Mean of Current Target", typeof(double));  // SPI_Value_Curr_Target
            dt.Columns.Add("Mean of Current Observed", typeof(double));     // SPI_Value_Curr_obs
            dt.Columns.Add("Progress %", typeof(double));

            dt.Columns.Add("SPI ID", typeof(string));

            dt.Columns.Add("Current Year Total", typeof(double));

            return dt;
        }

        public void LoadALLSPIsJsonToGrid(string Projectfolder, DataGridView dgv, DataTable dt)
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

                int sn = 1;
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
                        row["SN"] = sn;
                        sn++;
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
                        row["Responsible for Collecting"] = spiData.SPI_Resp_for_Collecting;
                        row["Responsible for Validating"] = spiData.SPI_Resp_for_Validating;
                        row["Responsible for Monitoring"] = spiData.SPI_Resp_for_Monitoring;
                        row["Responsible for Reporting"] = spiData.SPI_Resp_for_Reporting;
                        row["Responsible for Acting"] = spiData.SPI_Resp_for_Acting;

                        // --- Data Collection Methods ---
                        row["Where data is Collected"] = spiData.SPI_Where_data_Collected;
                        row["How data is Collected"] = spiData.SPI_How_data_Collected;

                        // --- Frequencies ---
                        row["Frequency of Reporting of SPI data"] = spiData.SPI_Frequency_of_Reporting;
                        row["Frequency of Collecting of SPI data"] = spiData.SPI_Frequency_of_Collecting;
                        row["Frequency of Monitoring of SPI data"] = spiData.SPI_Frequency_of_Monitoring;
                        row["Frequency of Analysis of SPI data"] = spiData.SPI_Frequency_of_Analysis;

                        // 6. FLATTEN ARRAYS: Convert double[] to comma-separated string
                        // We use string.Join(", ", array) to combine them
                        row["Previous Year Observed"] = spiData.PrevYearObserved != null
                            ? string.Join(", ", spiData.PrevYearObserved)
                            : "";

                        row["Current Year Target %"] = spiData.CurrYearTargetPercent != null
                            ? string.Join(", ", spiData.CurrYearTargetPercent)
                            : "";

                        row["Current Year Target Value"] = spiData.CurrYearTargetValue != null
                            ? string.Join(", ", spiData.CurrYearTargetValue)
                            : "";

                        row["Current Year Observed"] = spiData.CurrYearObserved != null
                            ? string.Join(", ", spiData.CurrYearObserved)
                            : "";

                        //to calculate sum
                        /*string CurrYearData = spiData.CurrYearObserved != null
                            ? string.Join(", ", spiData.CurrYearObserved)
                            : "";*/

                        // --- Remarks & Scalars ---
                        row["Remarks"] = spiData.SPI_Remarks;

                        row["Mean of Previous Observed"] = Convert.ToDouble(spiData.SPI_Value_Prev_Obs);
                        row["Mean of Current Target"] = Convert.ToDouble(spiData.SPI_Value_Curr_Target);
                        row["Mean of Current Observed"] = Convert.ToDouble(spiData.SPI_Value_Curr_obs);
                        row["Progress %"] = Convert.ToDouble(spiData.SPI_Progress_Percentage);

                        row["SPI ID"] = spiData.SPI_Id;

                        double SPI_Total_currYr = SumSPITotal(spiData.CurrYearObserved);

                        row["Current Year Total"] = SPI_Total_currYr;

                        // Add row to table
                        dt.Rows.Add(row);
                    }


                }

                string lastrowCurrTotal = GetMonthlySPISummationString(dt, "Current Year Observed");

                //Add last total row
                dt.Rows.Add();
                int TotalRow = dt.Rows.Count - 1;
                dt.Rows[TotalRow][0] = TotalRow + 1; //SN
                dt.Rows[TotalRow][1] = "Montly Total"; //SPI Name
                dt.Rows[TotalRow]["Current Year Observed"] = lastrowCurrTotal;


                // dt.Columns.Add("Current Year Total", typeof(double));
                int CurrColIndex = dt.Columns.IndexOf("Current Year Observed");
                double[] MonthData = ReadingCommaSparatedMonthlyDataFromDT(dt, TotalRow, "Current Year Observed");
                double spitotal = SumSPITotal(MonthData);

                dt.Rows[TotalRow]["Current Year Total"] = spitotal;

                // 7. Bind to DataGridView
                dgv.DataSource = dt;

                DGV_SPI_Summary_GridMode_Settings(dgv);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading SPIs: {ex.Message}");
            }
        }



        /// <summary>
        /// Reads comma-separated SPI data (Year, Jan...Dec) from each row of a DataTable,
        /// sums all Jan, Feb, ... Dec values, and returns a single comma-separated string:
        /// YearOfFirstRow, SumJan, SumFeb, ... SumDec
        /// </summary>
        public string GetMonthlySPISummationString(DataTable dt, string colName)
        {
            if (dt == null || dt.Rows.Count == 0 || !dt.Columns.Contains(colName))
                return null;

            double[] monthSums = new double[13]; // [0]=Year (ignored for sum), [1..12]=Months
            bool firstValidRowFound = false;
            string firstYear = "";

            foreach (DataRow row in dt.Rows)
            {
                var parsed = ParseCommaSeparatedMonthlyData(row[colName]);
                if (parsed == null) continue;

                // Capture year from first valid SPI row
                if (!firstValidRowFound)
                {
                    firstYear = parsed[0].ToString();
                    firstValidRowFound = true;
                }

                // Sum Jan..Dec (index 1 to 12)
                for (int i = 1; i <= 12; i++)
                {
                    monthSums[i] += parsed[i];
                }
            }

            if (!firstValidRowFound)
                return null;

            // Build output string: Year, SumJan, SumFeb, ..., SumDec
            StringBuilder sb = new StringBuilder();
            sb.Append(firstYear);

            for (int i = 1; i <= 12; i++)
            {
                sb.Append(",");
                sb.Append(monthSums[i]);
            }

            return sb.ToString();
        }


        public double SumSPITotal(double[] spimontlydata)
        {
            //sum from index 1 to 12 
            //skip index 0 as it is year
            double SPI_sum = 0;
            for (int i = 1; i <= 12; i++)
            {
                SPI_sum += spimontlydata[i];
            }


            return SPI_sum;
        }

        public void DGV_SPI_Summary_GridMode_Settings(DataGridView dgv)
        {
            // Optional: Auto-resize columns to fit the new data
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            //Read only columns
            dgv.Columns["SN"].ReadOnly = true;
            dgv.Columns["SPI ID"].ReadOnly = true;
            dgv.Columns["Remarks"].ReadOnly = true;
            dgv.Columns["Mean of Previous Observed"].ReadOnly = true;
            dgv.Columns["Mean of Current Target"].ReadOnly = true;
            dgv.Columns["Mean of Current Observed"].ReadOnly = true;
            dgv.Columns["Progress %"].ReadOnly = true;

            dgv.AllowUserToAddRows = false;
            dgv.Columns["SPI Name"].Frozen = true;
        }


        /// <summary>
        /// Parses a comma-separated string (Year, Jan...Dec)
        /// and returns an array of 13 doubles if valid.
        /// </summary>
        private double[] ParseCommaSeparatedMonthlyData(object cellValue)
        {
            if (cellValue == null || cellValue == DBNull.Value) return null;

            string rawData = cellValue.ToString();
            string[] parts = rawData.Split(',');

            // Expect exactly 13 values (Year + 12 months)
            if (parts.Length != 13) return null;

            double[] monthlyData = new double[13];

            for (int i = 0; i < parts.Length; i++)
            {
                if (double.TryParse(parts[i].Trim(), out double val))
                {
                    monthlyData[i] = val;
                }
                else
                {
                    // Same behavior as your original code
                    monthlyData[i] = 0;
                    // Or use: double.NaN;
                }
            }

            return monthlyData;
        }

        public double[] ReadingCommaSparatedMonthlyDataFromDGV(
            DataGridView dgv, int rowIndex, string colName)
        {
            if (dgv.Rows.Count <= rowIndex || rowIndex < 0) return null;

            var cell = dgv.Rows[rowIndex].Cells[colName];
            return ParseCommaSeparatedMonthlyData(cell?.Value);
        }

        public double[] ReadingCommaSparatedMonthlyDataFromDT(
            DataTable dt, int rowIndex, string colName)
        {
            if (dt.Rows.Count <= rowIndex || rowIndex < 0) return null;

            return ParseCommaSeparatedMonthlyData(dt.Rows[rowIndex][colName]);
        }


        public double[] ExtractMonthlyData(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return new double[0];

            return input.Split(',')             // 1. Split by comma
                        .Skip(1)                // 2. Skip the 'Year' (first element)
                        .Select(val => {        // 3. Attempt to convert each string to double
                            double.TryParse(val.Trim(), out double result);
                            return result;
                        })
                        .ToArray();             // 4. Return as an array
        }



        /*/// <summary>
        /// Reads a comma-separated string (Year, Jan...Dec) from a DataGridView and 
        /// returns an array of 12 doubles if the format is valid.
        /// </summary>
        public double[] ReadingCommaSparatedMonthlyDataFromDGV(DataGridView dgv, int rowIndex, string ColName)
        {
            // 1. Basic safety checks
            if (dgv.Rows.Count <= rowIndex || rowIndex < 0) return null;

            //var cell = dgv.Rows[rowIndex].Cells["Current Year Observed"];
            var cell = dgv.Rows[rowIndex].Cells[ColName];
            if (cell.Value == null) return null;

            // 2. Extract and Split the data
            string rawData = cell.Value.ToString();
            string[] parts = rawData.Split(',');

            // 3. Ensure exactly 13 parts (1 Year + 12 Months)
            if (parts.Length == 13)
            {
                double[] monthlyData = new double[13];

                for (int i = 0; i < parts.Length; i++)
                {
                    // Try to parse starting from index 1 (January)
                    if (double.TryParse(parts[i].Trim(), out double val))
                    {
                        // Store in array index 0 to 11
                        monthlyData[i] = val;
                    }
                    else
                    {
                        // If any data is non-numeric, return null (do nothing)
                        //return null;
                        monthlyData[i] = 0;
                        // Instead of returning null, mark this specific month as "Not a Number"
                        //monthlyData[i] = double.NaN;
                    }
                }

                return monthlyData; // Returns the double array variable
            }

            // 4. If length is not 13, do nothing and return null
            return null;
        }*/

        /*public double CalculateMonthlySumFromCommaSeparatedData(double[] monthData)
        {
            // 1. Check if the array is null or has no month data (less than index 1)
            if (monthData == null || monthData.Length <= 13)
            {
                return 0;
            }

            double sum = 0;

            // Start loop at 1 to ignore the Year at index 0
            for (int i = 1; i < monthData.Length; i++)
            {
                // Only add if the value is a valid number (not NaN)
                if (!double.IsNaN(monthData[i]))
                {
                    sum += monthData[i];
                }
            }

            return sum;
        }*/


        /////.........................Docx code here...........................///

        public void ExportSPIs_DocXv5(DataGridView dgv, bool combineIntoOneFile, int reportYear, bool IsdashboardWithBackgroundChecked)
        {
            string exportPath = string.Empty;
            string mainFileName = string.Empty;

            if (combineIntoOneFile)
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
                //int reportYear = Convert.ToInt32(TxtSPISummaryCurrYear.Text);
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

                var spititles = doc.InsertParagraph(spiName)
                   .FontSize(13d)
                   //.Italic()
                   .Heading(HeadingType.Heading1)
                   .Alignment = Alignment.center;


                doc.InsertParagraph().SpacingAfter(15d);

                // --- CHART IMAGE ---
                string imageFile = Path.Combine(chartPath, $"{spiId}.png");

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
                AddDashboardCards(mainDoc, dgv, IsdashboardWithBackgroundChecked);
                mainDoc.Save();
                MessageBox.Show("All SPIs merged into a single document with page breaks.");
            }
            else
            {
                MessageBox.Show("Individual Word files created successfully.");
            }
        }



        private void AddDashboardCards(DocX doc, DataGridView dgv, bool IsdashboardWithBackgroundChecked)
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
            //var dataRows = dgv.Rows
            /*var dataRows = dgv.SelectedRows
                .Cast<DataGridViewRow>()
                //.Where(r => !r.IsNewRow)
                .Where(r => !r.IsNewRow && r.Index < dgv.Rows.Count - 1)
                .ToList();*/

            var dataRows = dgv.Rows
                  .Cast<DataGridViewRow>()
                  .Where(r => r.Selected &&
                              !r.IsNewRow &&
                              r.Index < dgv.Rows.Count - 1)
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
            //if (dashboardWithBackgroundToolStripMenuItem.Checked) 
            if (IsdashboardWithBackgroundChecked)
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

                //if (dashboardWithBackgroundToolStripMenuItem.Checked)
                if (IsdashboardWithBackgroundChecked)
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


                //if (dashboardWithBackgroundToolStripMenuItem.Checked)
                if (IsdashboardWithBackgroundChecked)
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

        private void AddSPISummaryTables(DocX doc, DataGridView dgv)
        {
            var spiGroups = dgv.Rows.Cast<DataGridViewRow>()
                //.Where(r => !r.IsNewRow)
                .Where(r => !r.IsNewRow && r.Index < dgv.Rows.Count - 1)
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











    }
}
