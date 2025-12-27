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
using sctplot = ScottPlot;
using sctplotwin = ScottPlot.WinForms;


namespace AirportSMS
{
    public partial class FrmFlightMovement : Form
    {
        public sctplotwin.FormsPlot formsPlot4;

        public void InitializeScottPlot()
        {
            // Only if not already created
            if (formsPlot4 == null)
            {
                formsPlot4 = new sctplotwin.FormsPlot();
                formsPlot4.Dock = DockStyle.Fill;         // Fill the panel
                PanelPlotFM.Controls.Add(formsPlot4);       // Add to your panel
            }

        }

        public FrmFlightMovement()
        {
            InitializeComponent();
            InitializeScottPlot();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];
            TxtFMCurrentYear.Text = fm.TxtCurrentYear.Text;
            // Use the name of your specific DataGridView
            
            GenerateDGVWithMonthName(DGV_FMs_CurrentYear);
            GenerateDGVWithMonthName(DGV_FMs_PreviousYear);
            DGV_FMs_CurrentYear.CellValueChanged += DGV_FMs_CurrentYear_CellValueChanged;
            DGV_FMs_PreviousYear.CellValueChanged += DGV_FMs_PreviousYear_CellValueChanged;

            string projectFolder = string.Empty;
            if (fm.TxtProjectLocation.Text == "")
            {
                MessageBox.Show("No project found....Open project first");
            }
            else
            {
                projectFolder = fm.TxtProjectLocation.Text;
                LoadFMdataGridsFromJson(projectFolder);
            }

        }

        private void GenerateDGVWithMonthName(DataGridView DGV)
        {
            DGV.Rows.Clear();
            string[] Months = { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };

            for (int i = 0; i < 12; i++)
            {
                DGV.Rows.Add();
                DGV.Rows[i].Cells[0].Value = (i + 1);
                DGV.Rows[i].Cells[1].Value = Months[i];
            }
            DGV.Rows.Add();
            DGV.Rows[12].Cells[1].Value = "Total";
        }

        private double GetVal(object cellValue)
        {
            if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString()))
                return 0;

            return double.TryParse(cellValue.ToString(), out double result) ? result : 0;
        }



        private void SumFlightMovements(DataGridView DGV)
        {
            for (int i = 0; i < 12; i++)
            {
                // Skip the "New Row" at the bottom if it's enabled
                if (DGV.Rows[i].IsNewRow) continue;

                // 4 = 2 + 3 Domestic
                DGV.Rows[i].Cells[4].Value = GetVal(DGV.Rows[i].Cells[2].Value) + GetVal(DGV.Rows[i].Cells[3].Value);

                // 7 = 5 + 6 International
                DGV.Rows[i].Cells[7].Value = GetVal(DGV.Rows[i].Cells[5].Value) + GetVal(DGV.Rows[i].Cells[6].Value);

                // 8 = 2 + 5 Dom+Intl Arr
                DGV.Rows[i].Cells[8].Value = GetVal(DGV.Rows[i].Cells[2].Value) + GetVal(DGV.Rows[i].Cells[5].Value);

                // 9 = 3 + 6 Dom+Intl Dep
                DGV.Rows[i].Cells[9].Value = GetVal(DGV.Rows[i].Cells[3].Value) + GetVal(DGV.Rows[i].Cells[6].Value);

                // 10 = 8 + 9 Dom+Intl Total
                DGV.Rows[i].Cells[10].Value = GetVal(DGV.Rows[i].Cells[8].Value) + GetVal(DGV.Rows[i].Cells[9].Value);
            }

            // 2. Create the Summary Row
            //int summaryRowIndex = DGV.Rows.Add();
            DataGridViewRow summaryRow = DGV.Rows[12];
            //summaryRow.Cells[1].Value = "TOTAL"; // Label the row

            // 3. Loop through columns 2 to 10 to calculate vertical sums
            for (int col = 2; col <= 10; col++)
            {
                double columnSum = 0;
                for (int row = 0; row < 12; row++)
                {
                    if (DGV.Rows[row].IsNewRow || row == 12) continue;
                    columnSum += GetVal(DGV.Rows[row].Cells[col].Value);
                }
                summaryRow.Cells[col].Value = columnSum;
            }
        }

        private void DGV_FMs_CurrentYear_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Only run if a valid row is edited (not the header)
            if (e.RowIndex < 0) return;

            // 2. Only run if the change happened in your "input" columns
            int[] inputColumns = { 2, 3, 5, 6 };
            if (inputColumns.Contains(e.ColumnIndex))
            {
                // 3. Temporarily detach the event to avoid a recursive infinite loop
                DGV_FMs_CurrentYear.CellValueChanged -= DGV_FMs_CurrentYear_CellValueChanged;

                try
                {
                    // Call your calculation function
                    SumFlightMovements(DGV_FMs_CurrentYear);
                    PlotFMGraphScottPlot();
                }
                finally
                {
                    // 4. Re-attach the event so future user edits are caught
                    DGV_FMs_CurrentYear.CellValueChanged += DGV_FMs_CurrentYear_CellValueChanged;
                }
            }

            
        }

        public void PlotFMGraphScottPlot()
        {
            if (formsPlot4 == null)
            {
                return;
            }

            ChartStyleClass ChartCls = new ChartStyleClass();

            // Clear previous plot
            formsPlot4.Plot.Clear();

            string[] X_axis = new string[100];
            double[] Y1_axis = new double[100];//Current year FM
            double[] Y2_axis = new double[100];//Previous Year FM

            //int No_of_SPIs = DGV_SPI_Summary.RowCount - 1;
            int rows = 12;

            double sum1 = 0;
            double sum2 = 0;
            // get data from datagridview
            for (int i = 0; i < rows; i++)
            {
                X_axis[i] = DGV_FMs_CurrentYear.Rows[i].Cells[1].Value.ToString(); //Month names
                Y1_axis[i] = Convert.ToDouble(DGV_FMs_CurrentYear.Rows[i].Cells[10].Value); //Curr year total FM
                Y2_axis[i] = Convert.ToDouble(DGV_FMs_PreviousYear.Rows[i].Cells[10].Value); //Curr year total FM
                sum1 += Y1_axis[i];
                sum2 += Y2_axis[i];
            }

            double[] XPos = Enumerable.Range(0, rows).Select(i => (double)i).ToArray();
            string[] Xs = X_axis.Skip(0).Take(rows).ToArray(); // Month names

            bool PlotCurrFM, PlotPrevFM;

            if (fMsOfCurrentYearToolStripMenuItem.Checked)
            {
                PlotCurrFM = true;
                PlotPrevFM = false;
            }
            else if (fMsOfPreviousYearToolStripMenuItem.Checked)
            {
                PlotCurrFM = false;
                PlotPrevFM = true;
            }
            else
            {
                PlotCurrFM = true;
                PlotPrevFM = true;
            }

                // Define series
                var seriesConfig = new Dictionary<string, ChartStyleClass.SeriesStyleConfig>()
                {
                    ["Prev_Yr_FM"] = new ChartStyleClass.SeriesStyleConfig
                    {
                        ShowSeries = PlotPrevFM,
                        ShowValueLabel = PlotPrevFM,
                        LegendText = "Monthly Flight Movement (" + TxtFMPrevYear.Text + ") (Total = " + sum2 + ")",
                        ScottPlot_Chart_Type = "COLUMN",
                        AreaFillAbove = false,
                        YValues = Y2_axis.Take(rows).ToArray()
                    },
                    ["Curr_Yr_FM"] = new ChartStyleClass.SeriesStyleConfig
                    {
                        ShowSeries = PlotCurrFM,
                        ShowValueLabel = PlotCurrFM,
                        LegendText = "Monthly Flight Movement (" + TxtFMCurrentYear.Text + ") (Total = " + sum1 + ")",
                        ScottPlot_Chart_Type = "COLUMN",
                        AreaFillAbove = false,
                        YValues = Y1_axis.Take(rows).ToArray()
                    }
                    
                };

            double maxval = Y1_axis.Max();

            string Plot_Title = "Monthly Flight Movement";
            string Plot_YLabel = "No. of Fligh movements";
            string Plot_XLabel = "Month";

            int X_Axis_Label_Rotation = 0;


            // Apply styling and plotting
            ChartCls.ScottPlotStyle(formsPlot4, Xs, XPos, maxval,
                Plot_Title, Plot_YLabel, Plot_XLabel, X_Axis_Label_Rotation,
                seriesConfig);

            formsPlot4.Refresh();
            //MessageBox.Show("Plotted");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtFMCurrentYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtFMCurrentYear.Text == "")
                {
                    TxtFMPrevYear.Text = "";
                }
                else
                {
                    TxtFMPrevYear.Text = (Convert.ToInt32(TxtFMCurrentYear.Text) - 1).ToString();
                }
            }
            catch
            {

            }
            
        }

        private void DGV_FMs_PreviousYear_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Only run if a valid row is edited (not the header)
            if (e.RowIndex < 0) return;

            // 2. Only run if the change happened in your "input" columns
            int[] inputColumns = { 2, 3, 5, 6 };
            if (inputColumns.Contains(e.ColumnIndex))
            {
                // 3. Temporarily detach the event to avoid a recursive infinite loop
                DGV_FMs_PreviousYear.CellValueChanged -= DGV_FMs_PreviousYear_CellValueChanged;

                try
                {
                    // Call your calculation function
                    SumFlightMovements(DGV_FMs_PreviousYear);
                    PlotFMGraphScottPlot();
                }
                finally
                {
                    // 4. Re-attach the event so future user edits are caught
                    DGV_FMs_PreviousYear.CellValueChanged += DGV_FMs_PreviousYear_CellValueChanged;
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //current year
            try
            {
                AirportSMS_Class asmscls = new AirportSMS_Class();
                asmscls.CopySelectedtoClipboard(DGV_FMs_CurrentYear);
            }
            catch
            {

            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //current year
            try
            {
                AirportSMS_Class asmscls = new AirportSMS_Class();
                asmscls.PasteClipboardToDatagridview(DGV_FMs_CurrentYear);
            }
            catch
            {

            }
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //previous year
            try
            {
                AirportSMS_Class asmscls = new AirportSMS_Class();
                asmscls.CopySelectedtoClipboard(DGV_FMs_PreviousYear);
            }
            catch
            {

            }
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //previous year
            try
            {
                AirportSMS_Class asmscls = new AirportSMS_Class();
                asmscls.PasteClipboardToDatagridview(DGV_FMs_PreviousYear);
            }
            catch
            {

            }
        }

        private void fMsOfCurrentYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fMsOfCurrentYearToolStripMenuItem.Checked = true;
            fMsOfPreviousYearToolStripMenuItem.Checked = false;
            fMsOfBothYearToolStripMenuItem.Checked = false;

            PlotFMGraphScottPlot();
        }

        private void fMsOfPreviousYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fMsOfCurrentYearToolStripMenuItem.Checked = false;
            fMsOfPreviousYearToolStripMenuItem.Checked = true;
            fMsOfBothYearToolStripMenuItem.Checked = false;

            PlotFMGraphScottPlot();
        }

        private void fMsOfBothYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fMsOfCurrentYearToolStripMenuItem.Checked = false;
            fMsOfPreviousYearToolStripMenuItem.Checked = false;
            fMsOfBothYearToolStripMenuItem.Checked = true;

            PlotFMGraphScottPlot();
        }

        public class FMDataWrapper
        {
            public List<Dictionary<string, object>> CurrentYear { get; set; } = new List<Dictionary<string, object>>();
            public List<Dictionary<string, object>> PreviousYear { get; set; } = new List<Dictionary<string, object>>();
        }


        private void SaveOrCreateFMData(string projectFolder)
        {
            string folderPath = Path.Combine(projectFolder, "FMData");
            string filePath = Path.Combine(folderPath, "FMData.json");

            bool exists = Directory.Exists(folderPath) && File.Exists(filePath);
            string confirmMessage = exists
                ? "File already exists. Are you sure you want to overwrite it?"
                : "Are you sure you want to save the data?";

            // 1. Ask User for confirmation
            DialogResult result = MessageBox.Show(confirmMessage, "Confirm Save",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return; // Do nothing
            }

            try
            {
                // 2. Ensure Folder exists
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // 3. Prepare the data object
                FMDataWrapper dataToSave = new FMDataWrapper
                {
                    CurrentYear = GetGridData(DGV_FMs_CurrentYear),
                    PreviousYear = GetGridData(DGV_FMs_PreviousYear)
                };

                // 4. Serialize and Write (File.WriteAllText overwrites by default)
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

        private List<Dictionary<string, object>> GetGridData(DataGridView dgv)
        {
            var list = new List<Dictionary<string, object>>();

            // Loop through row index 0 to 12
            for (int i = 0; i <= 12; i++)
            {
                // Safety: Ensure the row exists and skip the 'New Row' placeholder
                if (i >= dgv.Rows.Count || dgv.Rows[i].IsNewRow) continue;

                var dict = new Dictionary<string, object>();
                //int[] targetColumns = { 2, 3, 5, 6 };
                int[] targetColumns = { 2, 3, 5, 6 };

                foreach (int colIndex in targetColumns)
                {
                    string columnName = dgv.Columns[colIndex].Name;
                    if (string.IsNullOrEmpty(columnName)) columnName = $"Col{colIndex}";

                    // Access the cell value
                    object rawValue = dgv.Rows[i].Cells[colIndex].Value;

                    // Handle Null: If null or DBNull, use GetVal to convert to 0, 
                    // otherwise use the value directly.
                    dict[columnName] = (rawValue == null || rawValue == DBNull.Value)
                                       ? 0
                                       : GetVal(rawValue);
                }

                list.Add(dict);
            }
            return list;
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];
            string projectFolder = string.Empty;
            if(fm.TxtProjectLocation.Text == "")
            {
                MessageBox.Show("No project found....Open project first");
            }
            else
            {
                projectFolder = fm.TxtProjectLocation.Text;
                SaveOrCreateFMData(projectFolder);
                MessageBox.Show("Flight movement data saved successfully");
            }

        }

        //Loading fligh movement data files
        private void LoadFMdataGridsFromJson(string projectFolder)
        {
            string filePath = Path.Combine(projectFolder, "FMData", "FMData.json");

            // 1. Check if file exists
            if (!File.Exists(filePath))
            {
                MessageBox.Show("No Flight movement data file found", "File Missing",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Read the file
                string jsonString = File.ReadAllText(filePath);

                // 3. Deserialize back to our class structure
                FMDataWrapper loadedData = JsonSerializer.Deserialize<FMDataWrapper>(jsonString);

                if (loadedData != null)
                {
                    // 4. Populate both grids
                    PopulateGrid(DGV_FMs_CurrentYear, loadedData.CurrentYear);
                    PopulateGrid(DGV_FMs_PreviousYear, loadedData.PreviousYear);

                    MessageBox.Show("Data loaded successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Optional: Re-run your summation logic here to refresh the totals
                    SumFlightMovements(DGV_FMs_CurrentYear);
                    SumFlightMovements(DGV_FMs_PreviousYear);
                    //plot graph
                    PlotFMGraphScottPlot();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
