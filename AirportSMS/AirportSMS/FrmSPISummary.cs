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




        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void FrmSPISummary_Load(object sender, EventArgs e)
        {
            ComboBoxSort.Items.Add("SPIs Total");
            ComboBoxSort.Items.Add("SPIs Progress");


        }

        private void sortSummaryTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Colname;
            if (RadioAscending.Checked==true || RadioDescending.Checked==true)
            {
                if(ComboBoxSort.Text == "")
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
            else if(RadioDefault.Checked)
            {
                Colname = "ColSN";
                DGV_SPI_Summary.Sort(DGV_SPI_Summary.Columns[Colname], ListSortDirection.Ascending);
            }

            PlotGraphScottPlotSummary();
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


        /*public static List<object[]> SortData(
            List<object[]> data,
            int sortColumnIndex,
            bool ascending)
        {
            return data
                .Select((row, originalIndex) => new { row, originalIndex })
                .OrderBy(x =>
                {
                    double d;
                    if (double.TryParse(
                        Convert.ToString(x.row[sortColumnIndex]), out d))
                        return d;

                    return x.row[sortColumnIndex]?.ToString();
                })
                .ThenBy(x => x.originalIndex)   // ⭐ THIS LINE FIXES IT
                .Select(x => x.row)
                .ToList();
        }*/



        public static List<object[]> SortData(
            List<object[]> data,
            int sortColumnIndex,
            bool ascending)
        {
           
            
            data.Sort((a, b) =>
            {
                object v1 = a[sortColumnIndex];
                object v2 = b[sortColumnIndex];

                double d1, d2;
                int result;

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

                return ascending ? result : -result;
            });

            return data;
            

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
    }
}
