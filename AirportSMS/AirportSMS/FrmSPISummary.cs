using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static AirportSMS.FrmHazardMonitoring;
using static AirportSMS.FrmMain;
using sctplot = ScottPlot;
using sctplotwin = ScottPlot.WinForms;

namespace AirportSMS
{
    public partial class FrmSPISummary : Form
    {
        public sctplotwin.FormsPlot formsPlot2;
        public sctplotwin.FormsPlot formsPlot3;
        public sctplotwin.FormsPlot formsPlot4;
        double CurrentYear;

        public void InitializeScottPlot()
        {
            // Only if not already created
            if (formsPlot2 == null)
            {
                formsPlot2 = new sctplotwin.FormsPlot();
                formsPlot2.Dock = DockStyle.Fill;         // Fill the panel
                PanelPlotSPISummary.Controls.Add(formsPlot2);       // Add to your panel
            }

            if (formsPlot3 == null)
            {
                formsPlot3 = new sctplotwin.FormsPlot();
                formsPlot3.Dock = DockStyle.Fill;         // Fill the panel
                PanelPlotMonth.Controls.Add(formsPlot3);       // Add to your panel
            }

            if (formsPlot4 == null)
            {
                formsPlot4 = new sctplotwin.FormsPlot();
                formsPlot4.Dock = DockStyle.Fill;         // Fill the panel
                PanelPlotAllSummarySPI.Controls.Add(formsPlot4);       // Add to your panel
            }
        }

        public FrmSPISummary()
        {
            InitializeComponent();
            SetupDGVWrapping();
            LoadSPISummary();
            InitializeScottPlot();
            PlotGraphScottPlotSummary();
            PlotGraphScottPlotMonthly();
        }

        private void SetupDGVWrapping()
        {
            // Enable wrapping for entire grid
            DGV_SPI_Summary.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Auto adjust row height based on content
            DGV_SPI_Summary.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Optional: nicer appearance
            DGV_SPI_Summary.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DGV_SPI_Summary.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }


        private void LoadSPISummary()
        {
            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];
            DGV_SPI_Summary.Rows.Clear();
            DGV_SPI_Summary_ALL.Rows.Clear();
            DGV_Summary_Monthly.Rows.Clear();

            if (fm.TxtProjectLocation.Text == "")
            {
                MessageBox.Show("No valid project loaded...");
                //MessageBox.Show(fm.TxtProjectLocation.Text);
            }
            else
            {
                string projectFolder = fm.TxtProjectLocation.Text;

                var spiList = SPILoader.LoadSPISummary(projectFolder);

                int sn = 1;

                foreach (var spi in spiList)
                {
                    DGV_SPI_Summary.Rows.Add(
                        sn++,
                        spi.Name,
                        spi.Type,
                        spi.Progress,
                        spi.Total
                        //spi.CurrYear.ToString()
                    );
                    CurrentYear = spi.CurrYear;

                    //all summary data

                    // 1. Prepare the static lead data (SN and Name)
                    var rowData = new List<object> { sn, spi.Name };

                    // 2. Use LINQ to grab indices 1 through 12 from MonthlySPIObsData
                    var monthlyData = spi.MonthlySPIObsData.Skip(1).Take(12).Cast<object>();

                    // 3. Combine them: SN + Name + Jan...Dec + Total
                    rowData.AddRange(monthlyData);
                    rowData.Add(spi.Total);

                    // 4. Add the final array to the DataGridView
                    DGV_SPI_Summary_ALL.Rows.Add(rowData.ToArray());

                }

                DGV_SPI_Summary_ALL.Rows.Add();
                double sum1, sumTotal=0;
                int TotalRow = DGV_SPI_Summary_ALL.RowCount - 2;
                DGV_SPI_Summary_ALL.Rows[TotalRow].Cells[0].Value = TotalRow.ToString();
                DGV_SPI_Summary_ALL.Rows[TotalRow].Cells[1].Value = "Montly Total";

                //monthly summation
                for(int i = 2;i <= 13;i++)
                {
                    sum1 = 0;
                    for(int j = 0; j < TotalRow; j++)
                    {
                        sum1 += Convert.ToDouble(DGV_SPI_Summary_ALL.Rows[j].Cells[i].Value);
                        sumTotal += Convert.ToDouble(DGV_SPI_Summary_ALL.Rows[j].Cells[i].Value);
                    }

                    DGV_SPI_Summary_ALL.Rows[TotalRow].Cells[i].Value = sum1.ToString("0.00");
                    
                }
                DGV_SPI_Summary_ALL.Rows[TotalRow].Cells[14].Value = sumTotal.ToString("0.00");

                int idx = 0;
                //string[] mnth = { "JAN", "FEB", "MAR", "APR", "MAY" };
                //Datagridview monthly
                for (int i = 2; i <= 14; i++)
                {
                    DGV_Summary_Monthly.Rows.Add();
                    DGV_Summary_Monthly.Rows[idx].Cells[0].Value = (idx+1);
                    DGV_Summary_Monthly.Rows[idx].Cells[1].Value = DGV_SPI_Summary_ALL.Columns[i].HeaderText;
                    DGV_Summary_Monthly.Rows[idx].Cells[2].Value = Convert.ToDouble(DGV_SPI_Summary_ALL.Rows[TotalRow].Cells[i].Value);
                    idx++;
                }


            }

                
        }


        public void PlotGraphScottPlotSummary()
        {
            if (formsPlot2 == null)
            {
                return;
            }

            ChartStyleClass ChartCls = new ChartStyleClass();

            // Clear previous plot
            formsPlot2.Plot.Clear();

            string[] X_axis = new string[100];
            double[] Y_axis = new double[100];

            int No_of_SPIs = DGV_SPI_Summary.RowCount-1;

            double sum = 0;
            // get data from datagridview
            for (int i = 0; i < No_of_SPIs; i++)
            {
                X_axis[i] = DGV_SPI_Summary.Rows[i].Cells[1].Value.ToString(); //SPIs name
                Y_axis[i] = Convert.ToDouble(DGV_SPI_Summary.Rows[i].Cells[4].Value); //SPIs total value
                sum += Y_axis[i];
            }

            double[] XPos = Enumerable.Range(0, No_of_SPIs).Select(i => (double)i).ToArray();
            string[] Xs = X_axis.Skip(0).Take(No_of_SPIs).ToArray(); // SPIs names...

            // Define series
            var seriesConfig = new Dictionary<string,ChartStyleClass.SeriesStyleConfig>()
            {
                ["SPIs_Total"] = new ChartStyleClass.SeriesStyleConfig
                {
                    ShowSeries = true,
                    ShowValueLabel = true,
                    LegendText = "Hazards reported (Total = " +sum + ")" ,
                    ScottPlot_Chart_Type = "COLUMN",
                    AreaFillAbove = false,
                    YValues = Y_axis.Take(No_of_SPIs).ToArray()
                }
                
            };

            double maxval = Y_axis.Max();

            string Plot_Title = "Categories of Hazard of " + CurrentYear;
            string Plot_YLabel = "Total Number";
            string Plot_XLabel = "Hazards";

            int X_Axis_Label_Rotation = -45;

           
            // Apply styling and plotting
            ChartCls.ScottPlotStyle(formsPlot2, Xs, XPos, maxval,
                Plot_Title, Plot_YLabel, Plot_XLabel, X_Axis_Label_Rotation,
                seriesConfig);

            formsPlot2.Refresh();
            //MessageBox.Show("Plotted");
        }

        public void PlotGraphScottPlotMonthly()
        {
            if (formsPlot3 == null)
            {
                return;
            }

            ChartStyleClass ChartCls = new ChartStyleClass();

            // Clear previous plot
            formsPlot3.Plot.Clear();

            string[] X_axis = new string[100];
            double[] Y_axis = new double[100];
            double[] Y_axis1 = new double[100];

            int No_of_SPIs = DGV_Summary_Monthly.RowCount - 2;

            double sum = 0;
            // get data from datagridview
            for (int i = 0; i < No_of_SPIs; i++)
            {
                X_axis[i] = DGV_Summary_Monthly.Rows[i].Cells[1].Value.ToString(); //Month
                Y_axis[i] = Convert.ToDouble(DGV_Summary_Monthly.Rows[i].Cells[2].Value); //Month total value
                Y_axis1[i] = Convert.ToDouble(DGV_Summary_Monthly.Rows[i].Cells[2].Value)*0.6; //Month total value
                sum += Y_axis[i];
            }

            double[] XPos = Enumerable.Range(0, No_of_SPIs).Select(i => (double)i).ToArray();
            string[] Xs = X_axis.Skip(0).Take(No_of_SPIs).ToArray(); // Month

            // Define series
            var seriesConfig = new Dictionary<string, ChartStyleClass.SeriesStyleConfig>()
            {
                ["Monthly_Total"] = new ChartStyleClass.SeriesStyleConfig
                {
                    ShowSeries = true,
                    ShowValueLabel = true,
                    LegendText = "Monthly reported Hazards (Total = " + sum + ")",
                    ScottPlot_Chart_Type = "COLUMN",
                    AreaFillAbove = false,
                    YValues = Y_axis.Take(No_of_SPIs).ToArray()
                },
                ["Monthly_Total_test"] = new ChartStyleClass.SeriesStyleConfig
                {
                    ShowSeries = false,
                    ShowValueLabel = false,
                    LegendText = "Monthly 0.6 (Total = " + sum + ")",
                    ScottPlot_Chart_Type = "COLUMN",
                    AreaFillAbove = false,
                    YValues = Y_axis1.Take(No_of_SPIs).ToArray()
                }

            };

            double maxval = Y_axis.Max();

            string Plot_Title = "Monthly hazard reporting of  " + CurrentYear;
            string Plot_YLabel = "Total Number";
            string Plot_XLabel = "Month";

            int X_Axis_Label_Rotation = 0;


            // Apply styling and plotting
            ChartCls.ScottPlotStyle(formsPlot3, Xs, XPos, maxval,
                Plot_Title, Plot_YLabel, Plot_XLabel, X_Axis_Label_Rotation,
                seriesConfig);

            formsPlot3.Refresh();
            //MessageBox.Show("Plotted");
        }

        public void PlotGraphScottPlotAllSummary()
        {
            if (formsPlot4 == null || DGV_SPI_Summary_ALL.SelectedRows.Count == 0)
                return;

            ChartStyleClass ChartCls = new ChartStyleClass();
            formsPlot4.Plot.Clear();

            // ---- CONSTANTS ----
            int monthStartCol = 2;        // JAN
            int monthCount = 12;          // JAN–DEC
            int lastDataRow = DGV_SPI_Summary_ALL.RowCount - 2; // ignore TOTAL row

            string[] Xs = { "JAN","FEB","MAR","APR","MAY","JUN",
                    "JUL","AUG","SEP","OCT","NOV","DEC" };

            double[] XPos = Enumerable.Range(0, monthCount)
                                      .Select(i => (double)i)
                                      .ToArray();

            var seriesConfig = new Dictionary<string, ChartStyleClass.SeriesStyleConfig>();

            double globalMax = 0;
            int seriesIndex = 0;

            // ---- SELECTED SPI ROWS ONLY ----
            var selectedRows = DGV_SPI_Summary_ALL.SelectedRows
                .Cast<DataGridViewRow>()
                .Where(r => r.Index < lastDataRow) // ignore TOTAL row
                .OrderBy(r => r.Index)
                .ToList();

           
            foreach (var row in selectedRows)
            {
                string spiName = row.Cells[1].Value.ToString();

                double[] yVals = new double[monthCount];
                double sum = 0;

                for (int m = 0; m < monthCount; m++)
                {
                    yVals[m] = Convert.ToDouble(row.Cells[monthStartCol + m].Value);
                    sum += yVals[m];
                    globalMax = Math.Max(globalMax, yVals[m]);
                }

                // ---- ADD SERIES ----
                seriesConfig[$"SPI_{row.Index}"] =
                    new ChartStyleClass.SeriesStyleConfig
                    {
                        ShowSeries = true,
                        ShowValueLabel = true,
                        LegendText = $"{spiName} (Total = {sum})",
                        ScottPlot_Chart_Type = "COLUMN",
                        AreaFillAbove = false,
                        YValues = yVals,

                        // 🔑 REQUIRED for grouped columns
                        SeriesIndex = seriesIndex,
                        TotalSeries = selectedRows.Count
                    };

                seriesIndex++;
            }

            if (seriesConfig.Count == 0)
                return;

            // ---- TITLES ----
            string Plot_Title = "Monthly SPI for " + CurrentYear;
            string Plot_YLabel = "Total Number";
            string Plot_XLabel = "Month";
            int X_Axis_Label_Rotation = 0;

            // ---- APPLY STYLE ----
            ChartCls.ScottPlotStyle(
                formsPlot4,
                Xs,
                XPos,
                globalMax,
                Plot_Title,
                Plot_YLabel,
                Plot_XLabel,
                X_Axis_Label_Rotation,
                seriesConfig
            );

            formsPlot4.Refresh();
        }





        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void FrmSPISummary_Load(object sender, EventArgs e)
        {
            ComboBoxSort.Items.Add("SPIs");
            ComboBoxSort.Items.Add("SPIs Type");
            ComboBoxSort.Items.Add("SPIs Progress");
            ComboBoxSort.Items.Add("SPIs Total");
           


        }

        private void sortbycolName()
        {
            string Colname;
            if (RadioAscending.Checked == true || RadioDescending.Checked == true)
            {
                if (ComboBoxSort.Text == "")
                {
                    MessageBox.Show("Select Column to sort from dropdown");
                }
                else
                {
                    if (RadioAscending.Checked == true)
                    {
                        Colname = $"Col{ComboBoxSort.Text.Replace(" ", "")}";
                        // Set this during form initialization
                        DGV_SPI_Summary.Sort(DGV_SPI_Summary.Columns[Colname], ListSortDirection.Ascending);
                    }
                    else if (RadioDescending.Checked == true)
                    {
                        Colname = $"Col{ComboBoxSort.Text.Replace(" ", "")}";
                        DGV_SPI_Summary.Sort(DGV_SPI_Summary.Columns[Colname], ListSortDirection.Descending);
                    }

                }

            }
            else if (RadioDefault.Checked)
            {
                Colname = "ColSN";
                DGV_SPI_Summary.Sort(DGV_SPI_Summary.Columns[Colname], ListSortDirection.Ascending);
            }

            PlotGraphScottPlotSummary();
        }
        private void sortSummaryTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnMnthAscend_Click(object sender, EventArgs e)
        {
            int fromRow = 0;
            int toRow = 11;           // <-- rows to sort
            int sortColumn = 2;
            bool ascending = true;

            var data = ReadDgvRows(DGV_Summary_Monthly, fromRow, toRow);
            var sorted = SortData(data, sortColumn, ascending);
            WriteDgvRows(DGV_Summary_Monthly, sorted, fromRow);

            PlotGraphScottPlotMonthly();

        }

        private void BtnMnthDescend_Click(object sender, EventArgs e)
        {
            int fromRow = 0;
            int toRow = 11;           // <-- rows to sort
            int sortColumn = 2;
            bool ascending = false;

            var data = ReadDgvRows(DGV_Summary_Monthly, fromRow, toRow);
            var sorted = SortData(data, sortColumn, ascending);
            WriteDgvRows(DGV_Summary_Monthly, sorted, fromRow);

            PlotGraphScottPlotMonthly();
        }

        private void BtnMnthDefault_Click(object sender, EventArgs e)
        {
            int fromRow = 0;
            int toRow = 11;           // <-- rows to sort
            int sortColumn = 0;
            bool ascending = true;

            var data = ReadDgvRows(DGV_Summary_Monthly, fromRow, toRow);
            var sorted = SortData(data, sortColumn, ascending);
            WriteDgvRows(DGV_Summary_Monthly, sorted, fromRow);

            PlotGraphScottPlotMonthly();
        }

        public static List<object[]> ReadDgvRows(
            DataGridView dgv,
            int fromRow,
            int toRow)
        {
            var data = new List<object[]>();

            for (int r = fromRow; r <= toRow; r++)
            {
                object[] row = new object[dgv.Columns.Count];
                for (int c = 0; c < dgv.Columns.Count; c++)
                    row[c] = dgv.Rows[r].Cells[c].Value;

                data.Add(row);
            }

            return data;
        }


        private class IndexedRow
        {
            public object[] Row { get; set; }
            public int OriginalIndex { get; set; }
        }


        public static List<object[]> SortData(
            List<object[]> data,
            int sortColumnIndex,
            bool ascending)
        {
            var indexed = data
                .Select((row, index) => new IndexedRow
                {
                    Row = row,
                    OriginalIndex = index
                })
                .ToList();

            indexed.Sort((x, y) =>
            {
                object v1 = x.Row[sortColumnIndex];
                object v2 = y.Row[sortColumnIndex];

                int result;

                double d1, d2;
                if (double.TryParse(Convert.ToString(v1), out d1) &&
                    double.TryParse(Convert.ToString(v2), out d2))
                {
                    result = d1.CompareTo(d2);
                }
                else
                {
                    result = string.Compare(
                        Convert.ToString(v1),
                        Convert.ToString(v2),
                        StringComparison.CurrentCulture);
                }

                if (!ascending)
                    result = -result;

                // ⭐ stability: tie-breaker
                if (result == 0)
                    result = x.OriginalIndex.CompareTo(y.OriginalIndex);

                return result;
            });

            return indexed.Select(x => x.Row).ToList();
        }



        public static void WriteDgvRows(
            DataGridView dgv,
            List<object[]> data,
            int startRow)
        {
            for (int r = 0; r < data.Count; r++)
            {
                for (int c = 0; c < dgv.Columns.Count; c++)
                    dgv.Rows[startRow + r].Cells[c].Value = data[r][c];
            }
        }

        private void BtnSortSummarySPI_Click(object sender, EventArgs e)
        {

            int fromRow = 0;
            int toRow = DGV_SPI_Summary.RowCount - 2;           // <-- rows to sort
            int sortColumn=0;
            bool ascending = true;

            //ComboBoxSort.Items.Add("SPIs");
            //ComboBoxSort.Items.Add("SPIs Type");
            //ComboBoxSort.Items.Add("SPIs Total");
            //ComboBoxSort.Items.Add("SPIs Progress");

            if (RadioDescending.Checked)
            {
                ascending = false;
                if (ComboBoxSort.Text == "SPIs Total")
                {
                    sortColumn = 4;
                }
                else if (ComboBoxSort.Text == "SPIs Progress")
                {
                    sortColumn = 3;
                }
                else if (ComboBoxSort.Text == "SPIs Type")
                {
                    sortColumn = 2;
                }
                else if (ComboBoxSort.Text == "SPIs")
                {
                    sortColumn = 1;
                }

            }
            else if(RadioAscending.Checked)
            {
                ascending = true;
                if (ComboBoxSort.Text == "SPIs Total")
                {
                    sortColumn = 4;
                }
                else if (ComboBoxSort.Text == "SPIs Progress")
                {
                    sortColumn = 3;
                }
                else if (ComboBoxSort.Text == "SPIs Type")
                {
                    sortColumn = 2;
                }
                else if (ComboBoxSort.Text == "SPIs")
                {
                    sortColumn = 1;
                }
            }
            else
            {
                ascending = true;
                sortColumn = 0;
            }

            var data = ReadDgvRows(DGV_SPI_Summary, fromRow, toRow);
            var sorted = SortData(data, sortColumn, ascending);
            WriteDgvRows(DGV_SPI_Summary, sorted, fromRow);

            PlotGraphScottPlotSummary();
        }

        private void BtnPlotAllSelectedSPIs_Click(object sender, EventArgs e)
        {
            PlotGraphScottPlotAllSummary();

        }

        private void BtnClearPlotArea_Click(object sender, EventArgs e)
        {
            if (formsPlot4 == null || DGV_SPI_Summary_ALL.SelectedRows.Count == 0)
                return;

            formsPlot4.Plot.Clear();
            formsPlot4.Refresh();
        }

        private void BtnHighHazardMonth_Click(object sender, EventArgs e)
        {
            int tophz;
            if (TxtMonthHzNumber.Text == "")
            {
                MessageBox.Show("Enter valid number of top hazard");
            }
            else
            {
                tophz = Convert.ToInt32(TxtMonthHzNumber.Text);
                if (tophz > DGV_Summary_Monthly.RowCount - 2)
                {
                    MessageBox.Show("Enter valid number of top hazard");
                }
                else
                {
                    HighHazardCategoryCircleClass hazcatcir = new HighHazardCategoryCircleClass();

                    hazcatcir.DrawHazardCircle(
                        PanelHighHazardMonth,
                        DGV_Summary_Monthly,
                        fromRowIndex: 0,
                        toRowIndex: tophz - 1,
                        HazCatNameColIndex: 1,  // e.g. Month / Hazard Category
                        HazCatValColIndex: 2,
                        centerText: "High Hazard \nMonth"// e.g. Total / Count
                    );
                }
            }
            //HighHazardCategoryCircleClass hazcatcir = new HighHazardCategoryCircleClass();

            

        }

        private void BtnSaveHighCatMonth_Click(object sender, EventArgs e)
        {
            HighHazardCategoryCircleClass hcc = new HighHazardCategoryCircleClass();
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg";
                sfd.Title = "Save Hazard Circle as Image";
                sfd.FileName = "HazardCircle.png";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    hcc.SavePanelAsImage(PanelHighHazardMonth, sfd.FileName);
                    MessageBox.Show("Image saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnPlotHazardCircleSPI_Click(object sender, EventArgs e)
        {
            int tophz;
            if(TxtSummarySIPTopHz.Text == "")
            {
                MessageBox.Show("Enter valid number of top hazard");
            }
            else
            {
                tophz = Convert.ToInt32(TxtSummarySIPTopHz.Text);
                if (tophz> DGV_SPI_Summary.RowCount-1)
                {
                    MessageBox.Show("Enter valid number of top hazard");
                }
                else
                {
                    HighHazardCategoryCircleClass hazcatcir = new HighHazardCategoryCircleClass();

                    hazcatcir.DrawHazardCircle(
                        PanelHighHazardSPI,
                        DGV_SPI_Summary,
                        fromRowIndex: 0,
                        toRowIndex: tophz-1, //4 means 5 will be shown i.e. 0 to 4 = 5 numbers
                        HazCatNameColIndex: 1,  // e.g. Month / Hazard Category
                        HazCatValColIndex: 4,
                        centerText: "High Hazard \nCategory"// e.g. Total / Count
                    );
                }
            }

           
        }

        private void BtnSaveHazardCircleSPI_Click(object sender, EventArgs e)
        {
            HighHazardCategoryCircleClass hcc = new HighHazardCategoryCircleClass();
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg";
                sfd.Title = "Save Hazard Circle as Image";
                sfd.FileName = "HazardCateogrySPI.png";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    hcc.SavePanelAsImage(PanelHighHazardSPI, sfd.FileName);
                    MessageBox.Show("Image saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
