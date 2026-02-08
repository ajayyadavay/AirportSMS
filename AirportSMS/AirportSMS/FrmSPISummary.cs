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
        SPISummaryGirdAndDocxClass sumgridocx = new SPISummaryGirdAndDocxClass();
        // 1. Create a DataTable to hold the data for gridmode new spi data
        DataTable dt1 = new DataTable(); //eq to DT_Summary_All
        //DataTable DT_Summary_All1 = new DataTable(); //eq to DT_Summary_All
        DataTable dt_filter_monthly1 = new DataTable(); //eq to dt_filter_monthly

        DataTable DT_Summary = new DataTable();
        DataTable DT_Monthly = new DataTable();

        //DataTable DT_Summary_All = new DataTable();
        //DataTable dt_filter_monthly = new DataTable();

        public sctplotwin.FormsPlot formsPlot2;
        public sctplotwin.FormsPlot formsPlot3;
        public sctplotwin.FormsPlot formsPlot4;

        double CurrentYear;
        bool IsMonthlyFilter = false;

        public void PopulateDataTableStructureFromDGV(DataGridView dgv, DataTable dt)
        {
            dt.Clear();
            dt.Columns.Clear();

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (!col.Visible) continue;   // optional

                // Column name stays exactly same as DGV
                dt.Columns.Add(col.Name, typeof(string));
            }

            /*string isTotalColumnName = dgv.Name + "_IsTotalRow"; // unique per DGV

            // Add only if it does not exist
            if (!dt.Columns.Contains(isTotalColumnName))
            {
                dt.Columns.Add(isTotalColumnName, typeof(bool));
            }*/
        }



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

            //PopulateDataTableStructureFromDGV(DGV_ALL_SPIs_GridMode, DT_Summary_All1);
            //CopyDataFromDGVToDTWithoutColumName(DGV_ALL_SPIs_GridMode, DT_Summary_All1);//copies data in dt from dgv


            //populate columns in dt as per dgv
            //PopulateDataTableStructureFromDGV(DGV_SPI_Summary_ALL, DT_Summary_All);

            PopulateDataTableStructureFromDGV(DGV_SPI_Summary, DT_Summary);
            PopulateDataTableStructureFromDGV(DGV_Summary_Monthly, DT_Monthly);

            LoadAllSPIDatainGridview();
            //LoadSPISummaries();
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


       /* private void LoadSPISummaries()
        {
            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];

            DGV_SPI_Summary.DataSource = null;
            DGV_SPI_Summary_ALL.DataSource = null;
            //DGV_Summary_Monthly.DataSource = null;

            DT_Summary.Clear();
            DT_Summary_All.Clear();
            //DT_Monthly.Clear();

            //DGV_SPI_Summary.Rows.Clear();
            //DGV_SPI_Summary_ALL.Rows.Clear();
            //DGV_Summary_Monthly.Rows.Clear();

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
                    //Summary
                    //DGV_SPI_Summary.Rows.Add(
                   /* DT_Summary.Rows.Add(
                     //  sn++,
                       // spi.Name,
                       // spi.Type,
                       // spi.Progress,
                       // spi.Total
                        //false
                        //spi.CurrYear.ToString()
                   // );
                    CurrentYear = spi.CurrYear;

                    //all summary data............
                    // 1. Prepare the static lead data (SN and Name)
                    sn++;
                    var rowData = new List<object> { sn-1, spi.Name, spi.Type, spi.Progress };

                    // 2. Use LINQ to grab indices 1 through 12 from MonthlySPIObsData
                    var monthlyData = spi.MonthlySPIObsData.Skip(1).Take(12).Cast<object>();

                    // 3. Combine them: SN + Name + Jan...Dec + Total
                    rowData.AddRange(monthlyData);
                    rowData.Add(spi.Total);
                    // 🔹 4. Add IsTotalRow = false for normal row
                    //rowData.Add(false);

                    // 4. Add the final array to the DataGridView
                    //DGV_SPI_Summary_ALL.Rows.Add(rowData.ToArray());
                    DT_Summary_All.Rows.Add(rowData.ToArray());

                }

                // ===== TOTAL ROW =====

                //DGV_SPI_Summary_ALL.Rows.Add();


                /*int TotalRow = DGV_SPI_Summary_ALL.RowCount - 2;
                DGV_SPI_Summary_ALL.Rows[TotalRow].Cells[0].Value = TotalRow.ToString();
                DGV_SPI_Summary_ALL.Rows[TotalRow].Cells[1].Value = "Montly Total";

                DT_Summary_All.Rows.Add();
                double sum1, sumTotal = 0;
                int TotalRow = DT_Summary_All.Rows.Count - 1;
                DT_Summary_All.Rows[TotalRow][0] = TotalRow + 1;
                DT_Summary_All.Rows[TotalRow][1] = "Montly Total";
                DT_Summary_All.Rows[TotalRow][2] = "NA";
                DT_Summary_All.Rows[TotalRow][3] = "NA";

                //monthly summation
                for (int i = 4;i <= 15;i++)
                {
                    sum1 = 0;
                    for(int j = 0; j < TotalRow; j++)
                    {
                        sum1 += Convert.ToDouble(DT_Summary_All.Rows[j][i]);
                        sumTotal += Convert.ToDouble(DT_Summary_All.Rows[j][i]);
                        //sum1 += Convert.ToDouble(DGV_SPI_Summary_ALL.Rows[j].Cells[i].Value);
                        //sumTotal += Convert.ToDouble(DGV_SPI_Summary_ALL.Rows[j].Cells[i].Value);
                    }

                    DT_Summary_All.Rows[TotalRow][i] = sum1;
                    //DGV_SPI_Summary_ALL.Rows[TotalRow].Cells[i].Value = sum1.ToString("0.00");
                    
                }

                DT_Summary_All.Rows[TotalRow][16] = sumTotal;
                //DT_Summary_All.Rows[TotalRow][16] = true;
                //DGV_SPI_Summary_ALL.Rows[TotalRow].Cells[14].Value = sumTotal.ToString("0.00");


                //Datagridview monthly
                /*int idx = 0;
                for (int i = 3; i <= 15; i++)
                {
                    //DGV_Summary_Monthly.Rows.Add();
                    //DGV_Summary_Monthly.Rows[idx].Cells[0].Value = (idx+1);
                    //DGV_Summary_Monthly.Rows[idx].Cells[1].Value = DGV_SPI_Summary_ALL.Columns[i].HeaderText;
                    //DGV_Summary_Monthly.Rows[idx].Cells[2].Value = Convert.ToDouble(DGV_SPI_Summary_ALL.Rows[TotalRow].Cells[i].Value);

                    DT_Monthly.Rows.Add();
                    DT_Monthly.Rows[idx][0] = idx + 1;
                    DT_Monthly.Rows[idx][1] = DGV_SPI_Summary_ALL.Columns[i].HeaderText;
                    DT_Monthly.Rows[idx][2] = Convert.ToDouble(DT_Summary_All.Rows[TotalRow][i]);
                    if(i==15)
                    {
                        DT_Monthly.Rows[idx][3] = true;
                    }
                    else
                    {
                        DT_Monthly.Rows[idx][3] = false;
                    }

                        idx++;
                }*/
                //BindDTtoDGV(DGV_SPI_Summary, DT_Summary);
                //BindDTtoDGV(DGV_SPI_Summary_ALL, DT_Summary_All);

                //FillingDataSPISummaryDGV_DT();
                //FillingDataInMonthlySummaryDGV_DT();

            //}

            // ================= BINDING (FINAL STEP) =================
            /*DGV_SPI_Summary.AllowUserToAddRows = false;
            DGV_SPI_Summary_ALL.AllowUserToAddRows = false;
            DGV_Summary_Monthly.AllowUserToAddRows = false;

            DGV_SPI_Summary.AutoGenerateColumns = false;
            DGV_SPI_Summary_ALL.AutoGenerateColumns = false;
            DGV_Summary_Monthly.AutoGenerateColumns = false;

            DGV_SPI_Summary.DataSource = DT_Summary;
            DGV_SPI_Summary_ALL.DataSource = DT_Summary_All;
            DGV_Summary_Monthly.DataSource = DT_Monthly;


            //BindDTtoDGV(DGV_Summary_Monthly, DT_Monthly);
        }*/

       /* public void FillingDataSPISummaryDGV_DT()
        {
            DGV_SPI_Summary.DataSource = null;
            DT_Summary.Clear();

            int TotalRow = DGV_SPI_Summary_ALL.RowCount - 1;

            int idx = 0;

            //int[] all_idx = { 0, 1, 2, 3, 16 };
            //int i;
            //Datagridview SPI summary
            for(int r = 0; r<TotalRow; r++) //last row is total so not needed here
            {
                
                DT_Summary.Rows.Add();
                DT_Summary.Rows[r][0] = Convert.ToInt32(DGV_SPI_Summary_ALL.Rows[r].Cells[0].Value);//SN
                DT_Summary.Rows[r][1] = DGV_SPI_Summary_ALL.Rows[r].Cells[1].Value;//SPI Name
                DT_Summary.Rows[r][2] = DGV_SPI_Summary_ALL.Rows[r].Cells[2].Value;//SPI Type
                DT_Summary.Rows[r][3] = Convert.ToDouble(DGV_SPI_Summary_ALL.Rows[r].Cells[3].Value);//Progress
                DT_Summary.Rows[r][4] = Convert.ToDouble(DGV_SPI_Summary_ALL.Rows[r].Cells[16].Value);//Total
                idx++;
            }
            


            BindDTtoDGV(DGV_SPI_Summary, DT_Summary);
        }*/





        /*public void FillingDataInMonthlySummaryDGV_DT()
        {
            DGV_Summary_Monthly.DataSource = null;
            DT_Monthly.Clear();

            int TotalRow = DGV_SPI_Summary_ALL.RowCount - 1;

            int idx = 0;
            string[] MonthName = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", "Total"};
            //Datagridview monthly
            for (int i = 4; i <= 16; i++)
            {
                DT_Monthly.Rows.Add();
                DT_Monthly.Rows[idx][0] = idx + 1;
                DT_Monthly.Rows[idx][1] = MonthName[idx]; //DGV_SPI_Summary_ALL.Columns[i].HeaderText;
                DT_Monthly.Rows[idx][2] = Convert.ToDouble(DGV_SPI_Summary_ALL.Rows[TotalRow].Cells[i].Value);
                
                /*if (i == 15)
                {
                    DT_Monthly.Rows[idx][3] = true;
                }
                else
                {
                    DT_Monthly.Rows[idx][3] = false;
                }

                idx++;
            }


            BindDTtoDGV(DGV_Summary_Monthly, DT_Monthly);
        }*/


        public void FillingDataSPISummaryDGV_DT_GridMode()
        {
            DGV_SPI_Summary.DataSource = null;
            DT_Summary.Clear();

            int TotalRow = DGV_ALL_SPIs_GridMode.RowCount - 1;

            int idx = 0;

            //int[] all_idx = { 0, 1, 2, 3, 16 };
            //int i;
            //Datagridview SPI summary
            for (int r = 0; r < TotalRow; r++) //last row is total so not needed here
            {
                DT_Summary.Rows.Add();
                DT_Summary.Rows[r][0] = Convert.ToInt32(DGV_ALL_SPIs_GridMode.Rows[r].Cells["SN"].Value);//SN
                DT_Summary.Rows[r][1] = DGV_ALL_SPIs_GridMode.Rows[r].Cells["SPI Name"].Value;//SPI Name
                DT_Summary.Rows[r][2] = DGV_ALL_SPIs_GridMode.Rows[r].Cells["Type"].Value;//SPI Type
                DT_Summary.Rows[r][3] = Convert.ToDouble(DGV_ALL_SPIs_GridMode.Rows[r].Cells["Progress %"].Value);//Progress
                DT_Summary.Rows[r][4] = Convert.ToDouble(DGV_ALL_SPIs_GridMode.Rows[r].Cells["Current Year Total"].Value);//Total
                idx++;
            }



            BindDTtoDGV(DGV_SPI_Summary, DT_Summary);
        }


        public void FillingDataInMonthlySummaryDGV_DT_GridMode()
        {
            DGV_Summary_Monthly.DataSource = null;
            DT_Monthly.Clear();

            int TotalRow = DGV_ALL_SPIs_GridMode.RowCount - 1;

            //int idx = 0;
            string[] MonthName = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", "Total" };
            //Datagridview monthly
            double[] MonthData = sumgridocx.ReadingCommaSparatedMonthlyDataFromDGV(DGV_ALL_SPIs_GridMode, TotalRow, "Current Year Observed");
            for (int idx = 0; idx <= 11; idx++)
            {
                DT_Monthly.Rows.Add();
                DT_Monthly.Rows[idx][0] = idx + 1;
                DT_Monthly.Rows[idx][1] = MonthName[idx]; //DGV_SPI_Summary_ALL.Columns[i].HeaderText;
                DT_Monthly.Rows[idx][2] = MonthData[idx + 1]; //skip 0 as it contains year data

                //MessageBox.Show("idx = " + idx.ToString() + " = " + MonthData[idx + 1].ToString());

            }
            DT_Monthly.Rows.Add();
            DT_Monthly.Rows[12][0] = 13;
            DT_Monthly.Rows[12][1] = "Total";
            //DT_Monthly.Rows[12][2] = Convert.ToDouble(DGV_ALL_SPIs_GridMode.Rows[TotalRow].Cells["Current Year Total"].Value);
            string rawValue = DGV_ALL_SPIs_GridMode.Rows[TotalRow].Cells["Current Year Total"].Value?.ToString();

            if (double.TryParse(rawValue, out double result))
            {
                DT_Monthly.Rows[12][2] = result;
            }
            else
            {
                DT_Monthly.Rows[12][2] = 0.0; // Default value if cell is empty or invalid
            }


            BindDTtoDGV(DGV_Summary_Monthly, DT_Monthly);
        }

        public void BindDTtoDGV(DataGridView dgv, DataTable dt)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = dt;
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

            int No_of_SPIs = DGV_SPI_Summary.RowCount;

            //int No_of_SPIs = DGV_SPI_Summary.Rows.GetRowCount(DataGridViewElementStates.Visible)-1;

            if (No_of_SPIs == 0)
                return;

            double sum = 0;
            // get data from datagridview
            /*for (int i = 0; i < No_of_SPIs; i++)
            {
                X_axis[i] = DGV_SPI_Summary.Rows[i].Cells[1].Value.ToString(); //SPIs name
                Y_axis[i] = Convert.ToDouble(DGV_SPI_Summary.Rows[i].Cells[4].Value); //SPIs total value
                sum += Y_axis[i];
            }*/
            int idx = 0;
            foreach (DataGridViewRow row in DGV_SPI_Summary.Rows)
            {
                if (!row.Visible || row.IsNewRow) continue;

                X_axis[idx] = row.Cells[1].Value?.ToString();   // SPIs name
                Y_axis[idx] = Convert.ToDouble(row.Cells[4].Value); // SPIs total

                sum += Y_axis[idx];
                idx++;
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

            if (TxtSPISummaryCurrYear.Text == "")
            {
                CurrentYear = 0;
            }
            else
            {
                CurrentYear = Convert.ToInt32(TxtSPISummaryCurrYear.Text);
            }

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

            int No_of_SPIs = DGV_Summary_Monthly.RowCount - 1;

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

            if (TxtSPISummaryCurrYear.Text == "")
            {
                CurrentYear = 0;
            }
            else
            {
                CurrentYear = Convert.ToInt32(TxtSPISummaryCurrYear.Text);
            }


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

        /*public void PlotGraphScottPlotAllSummary()
        {
            if (formsPlot4 == null || DGV_SPI_Summary_ALL.SelectedRows.Count == 0)
                return;

            ChartStyleClass ChartCls = new ChartStyleClass();
            formsPlot4.Plot.Clear();

            // ---- CONSTANTS ----
            int monthStartCol = 4;        // JAN
            int monthCount = 12;          // JAN–DEC
            int lastDataRow = DGV_SPI_Summary_ALL.RowCount - 1; // ignore TOTAL row -1 instead of -2

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
        }*/

        public void PlotGraphScottPlotAllSummary_GridMode()
        {
            if (formsPlot4 == null || DGV_ALL_SPIs_GridMode.SelectedRows.Count == 0)
                return;

            ChartStyleClass ChartCls = new ChartStyleClass();
            formsPlot4.Plot.Clear();

            // ---- CONSTANTS ----
            //int monthStartCol = 4;        // JAN
            int monthCount = 12;          // JAN–DEC
            int lastDataRow = DGV_ALL_SPIs_GridMode.RowCount - 1; // ignore TOTAL row -1 instead of -2

            string[] Xs = { "JAN","FEB","MAR","APR","MAY","JUN",
                    "JUL","AUG","SEP","OCT","NOV","DEC" };

            double[] XPos = Enumerable.Range(0, monthCount)
                                      .Select(i => (double)i)
                                      .ToArray();

            var seriesConfig = new Dictionary<string, ChartStyleClass.SeriesStyleConfig>();

            double globalMax = 0;
            int seriesIndex = 0;

            // ---- SELECTED SPI ROWS ONLY ----
            var selectedRows = DGV_ALL_SPIs_GridMode.SelectedRows
                .Cast<DataGridViewRow>()
                .Where(r => r.Index < lastDataRow) // ignore TOTAL row
                .OrderBy(r => r.Index)
                .ToList();


            foreach (var row in selectedRows)
            {
                string spiName = row.Cells["SPI Name"].Value.ToString();
                string currYearObs = row.Cells["Current Year Observed"].Value?.ToString() ?? "";

                // Extract into a double array
                double[] yVals = sumgridocx.ExtractMonthlyData(currYearObs);

                //double[] yVals = new double[monthCount];
                //double[] yVals = null;
                //MonthData = sumgridocx.ReadingCommaSparatedMonthlyDataFromDGV(DGV_ALL_SPIs_GridMode, r, "Current Year Observed");
                double sum = 0;

                for (int m = 0; m < monthCount; m++)
                {
                    //yVals[m] = Convert.ToDouble(row.Cells[monthStartCol + m].Value);
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

            if (TxtSPISummaryCurrYear.Text == "")
            {
                CurrentYear = 0;
            }
            else
            {
                CurrentYear = Convert.ToInt32(TxtSPISummaryCurrYear.Text);
            }

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

        private void LoadAllSPIDatainGridview()
        {
            //Tab summary all
            //All SPIs data new----------------------------------
            dt1 = sumgridocx.PopulateHeaderOfDt();

            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];
            if (fm.TxtCurrentYear.Text == "")
                TxtSPISummaryCurrYear.Text = "";
            else
                TxtSPISummaryCurrYear.Text = fm.TxtCurrentYear.Text;

            //FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];
            if (fm.TxtProjectLocation.Text == "")
            {
                MessageBox.Show("No valid project loaded");
            }
            else
            {
                string projectfolder = fm.TxtProjectLocation.Text;
                sumgridocx.LoadALLSPIsJsonToGrid(projectfolder, DGV_ALL_SPIs_GridMode, dt1);
                FillingDataSPISummaryDGV_DT_GridMode();
                FillingDataInMonthlySummaryDGV_DT_GridMode();
            }
        }

        

        private void FrmSPISummary_Load(object sender, EventArgs e)
        {
            //gridview spi summary
            //LoadAllSPIDatainGridview();

            //load to combobox
            ComboBoxSummaryAllColName.Items.Add(DGV_ALL_SPIs_GridMode.Columns["Type"].Name);
            ComboBoxSummaryAllColName.Items.Add(DGV_ALL_SPIs_GridMode.Columns["SPI Name"].Name);
            ComboBoxSummaryAllColName.Items.Add(DGV_ALL_SPIs_GridMode.Columns["Progress %"].Name);
            ComboBoxSummaryAllColName.SelectedIndex = 0;

            //FrmSPISummary fsmry = new FrmSPISummary();
            //fsmry.PopulateDataTableStructureFromDGV(DGV_ALL_SPIs_GridMode, DT_Summary_All1);
            //fsmry.CopyDataFromDGVToDTWithoutColumName(DGV_ALL_SPIs_GridMode, DT_Summary_All1);//copies data in dt from dgv

            //End all spi data new--------------------------


            //tab summary by spi
            ComboBoxSort.Items.Add("SPIs");
            ComboBoxSort.Items.Add("SPIs Type");
            ComboBoxSort.Items.Add("SPIs Progress");
            ComboBoxSort.Items.Add("SPIs Total");

            //ColSN, ColSPIs,  ColSPIsType, ColSPIsProgress, ColSPIsTotal
            /*ComboBoxSPIsummaryColName.Items.Add("ColSN");
            ComboBoxSPIsummaryColName.Items.Add("ColSPIs");
            ComboBoxSPIsummaryColName.Items.Add("ColSPIsType");
            ComboBoxSPIsummaryColName.Items.Add("ColSPIsProgress");
            ComboBoxSPIsummaryColName.Items.Add("ColSPIsTotal");*/



            AirportSMS_Class acls = new AirportSMS_Class();
            acls.LoadColumnNames(DGV_SPI_Summary, ComboBoxSPIsummaryColName);

            CurrentYear = Convert.ToDouble(TxtSPISummaryCurrYear.Text);
            //ComboBoxSummaryAllColName.Items.Add(DGV_SPI_Summary_ALL.Columns[0].Name);
            /*ComboBoxSummaryAllColName.Items.Add(DGV_SPI_Summary_ALL.Columns[1].Name);
            ComboBoxSummaryAllColName.Items.Add(DGV_SPI_Summary_ALL.Columns[2].Name);
            ComboBoxSummaryAllColName.Items.Add(DGV_SPI_Summary_ALL.Columns[16].Name);
            ComboBoxSummaryAllColName.SelectedIndex = 0;*/

        }

        /*private void sortbycolName()
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
            
        }*/

        private void BtnMnthAscend_Click(object sender, EventArgs e)
        {
            int fromRow = 0;
            int toRow = 11;           // <-- rows to sort
            int sortColumn = 2;
            bool ascending = true;

            var data = ReadDgvRows(DGV_Summary_Monthly, fromRow, toRow);
            var sorted = SortData(data, sortColumn, ascending);
            WriteDgvRows(DGV_Summary_Monthly, sorted, fromRow);

            /*DataView DV_Monthly;

            DV_Monthly = new DataView(DT_Monthly);

            DGV_Summary_Monthly.AutoGenerateColumns = false;
            DGV_Summary_Monthly.DataSource = DV_Monthly;

            string sortColumn = DGV_Summary_Monthly.Columns[0].Name;
            string sortDirection = "ASC"; //"DESC" for descending

            // 🔑 Keep Total row at bottom
            DV_Monthly.Sort = $"IsTotalRow ASC, {sortColumn} {sortDirection}";*/

            /*string SortcolumnName = DGV_Summary_Monthly.Columns[2].Name;
            AirportSMS_Class acls = new AirportSMS_Class();
            acls.SortDataTableWithTotalRow(DGV_Summary_Monthly, DT_Monthly, SortcolumnName, true);*/

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

            /*DataView DV_Monthly;
            DV_Monthly = new DataView(DT_Monthly);
            DGV_Summary_Monthly.AutoGenerateColumns = false;
            DGV_Summary_Monthly.DataSource = DV_Monthly;
            string sortColumn = DGV_Summary_Monthly.Columns[0].Name;
            string sortDirection = "DESC"; //"DESC" for descending

            // 🔑 Keep Total row at bottom
            DV_Monthly.Sort = $"IsTotalRow ASC, {sortColumn} {sortDirection}";*/

            /*string SortcolumnName = DGV_Summary_Monthly.Columns[2].Name;
            AirportSMS_Class acls = new AirportSMS_Class();
            acls.SortDataTableWithTotalRow(DGV_Summary_Monthly, DT_Monthly, SortcolumnName, false);
            */
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

            /*string SortcolumnName = DGV_Summary_Monthly.Columns[0].Name;
            AirportSMS_Class acls = new AirportSMS_Class();
            acls.SortDataTableWithTotalRow(DGV_Summary_Monthly, DT_Monthly, SortcolumnName, true);
            */

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

        /*public static List<object[]> ReadDgvRows(
            DataGridView dgv,
            int fromVisibleRow,
            int toVisibleRow)
        { //recentfinal
            // 1️⃣ Take SNAPSHOT of visible rows (CRITICAL)
            var visibleRows = dgv.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Visible && !r.IsNewRow)
                .ToList();

            if (visibleRows.Count == 0)
                return new List<object[]>();

            // 2️⃣ Clamp range safely
            fromVisibleRow = Math.Max(0, fromVisibleRow);
            toVisibleRow = Math.Min(visibleRows.Count - 2, toVisibleRow);

            if (fromVisibleRow > toVisibleRow)
                return new List<object[]>();

            // 3️⃣ Read only requested visible range
            var data = new List<object[]>();

            for (int i = fromVisibleRow; i <= toVisibleRow; i++)
            {
                var dgRow = visibleRows[i];
                object[] row = new object[dgv.Columns.Count];

                for (int c = 0; c < dgv.Columns.Count; c++)
                    row[c] = dgRow.Cells[c].Value;

                data.Add(row);
            }

            return data;
        }*/


        /*public static List<object[]> ReadDgvRows(
            DataGridView dgv,
            int fromVisibleRow,
            int toVisibleRow)
        {
            var data = new List<object[]>();

            int visibleIndex = 0;

            foreach (DataGridViewRow dgRow in dgv.Rows)
            {
                if (!dgRow.Visible || dgRow.IsNewRow)
                    continue;

                if (visibleIndex >= fromVisibleRow && visibleIndex <= toVisibleRow)
                {
                    object[] row = new object[dgv.Columns.Count];
                    for (int c = 0; c < dgv.Columns.Count; c++)
                        row[c] = dgRow.Cells[c].Value;

                    data.Add(row);
                }

                visibleIndex++;

                if (visibleIndex > toVisibleRow)
                    break;
            }

            return data;
        }*/


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
            int toRow = DGV_SPI_Summary.RowCount - 1;           // <-- rows to sort -1 instead of -2
            //int toRow = DGV_SPI_Summary.Rows.GetRowCount(DataGridViewElementStates.Visible) - 2;
            // <-- rows to sort
            //MessageBox.Show("torow = " + toRow);
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
            //PlotGraphScottPlotAllSummary();
            PlotGraphScottPlotAllSummary_GridMode();

        }

        private void BtnClearPlotArea_Click(object sender, EventArgs e)
        {
            //if (formsPlot4 == null || DGV_SPI_Summary_ALL.SelectedRows.Count == 0)
             if (formsPlot4 == null || DGV_ALL_SPIs_GridMode.SelectedRows.Count == 0)
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
                if (tophz > DGV_Summary_Monthly.RowCount - 1)
                {
                    MessageBox.Show("Enter valid number of top hazard");
                }
                else
                {
                    HighHazardCategoryCircleClass hazcatcir = new HighHazardCategoryCircleClass();
                    string monthcentertxt = string.Empty;
                    if (TxtCentercircletextMonthhazard.Text == "")
                        monthcentertxt = "Month \nHazard";
                    else
                        monthcentertxt = TxtCentercircletextMonthhazard.Text;


                    hazcatcir.DrawHazardCircle(
                        PanelHighHazardMonth,
                        DGV_Summary_Monthly,
                        fromRowIndex: 0,
                        toRowIndex: tophz - 1,
                        HazCatNameColIndex: 1,  // e.g. Month / Hazard Category
                        HazCatValColIndex: 2,
                        centerText: monthcentertxt// e.g. Total / Count
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
                if (tophz> DGV_SPI_Summary.RowCount)
                {
                    MessageBox.Show("Enter valid number of top hazard");
                }
                else
                {
                    HighHazardCategoryCircleClass hazcatcir = new HighHazardCategoryCircleClass();
                    string centertext = string.Empty;
                    if (TxtCentralCircleTextHazard.Text == "")
                        centertext = "Hazard Category";
                    else
                        centertext = TxtCentralCircleTextHazard.Text;


                        hazcatcir.DrawHazardCircle(
                            PanelHighHazardSPI,
                            DGV_SPI_Summary,
                            fromRowIndex: 0,
                            toRowIndex: tophz - 1, //4 means 5 will be shown i.e. 0 to 4 = 5 numbers
                            HazCatNameColIndex: 1,  // e.g. Month / Hazard Category
                            HazCatValColIndex: 4,
                            centerText: centertext// e.g. Total / Count
                                                                       //centerText: "High Hazard \nCategory"// e.g. Total / Count
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

        private void BtnFilterSPISummary_Click(object sender, EventArgs e)
        {

            //acls.FilterDataGridView(DGV_SPI_Summary, ComboBoxSPIsummaryColName.Text, ComboBoxSPISummaryValue.Text);
            /*if (TxtFilterSPISummary.Text == "")
            {
                
            }
            else
            {
                MessageBox.Show("Enter query to filer...");
            }*/
            /*
           if (ComboBoxSPIsummaryColName.SelectedItem == null ||
        ComboBoxSPISummaryValue.SelectedItem == null)
                return;

            acls.ApplyFilterDGV(
                DGV_SPI_Summary,
                ComboBoxSPIsummaryColName.SelectedItem.ToString(),
                ComboBoxSPISummaryValue.SelectedItem.ToString()
            );

            int visibleCount = DGV_SPI_Summary.Rows.GetRowCount(DataGridViewElementStates.Visible) - 1;
            */
            AirportSMS_Class acls = new AirportSMS_Class();
            if (ComboBoxSPIsummaryColName.SelectedItem == null ||
                    ComboBoxSPISummaryValue.SelectedItem == null)
                return;

            acls.FilterDGV_DT(
                DGV_SPI_Summary, 
                DT_Summary, 
                ComboBoxSPIsummaryColName.SelectedItem.ToString(),
                ComboBoxSPISummaryValue.SelectedItem.ToString()
            );

            TxtFilterSPISummary.Text = "Total filtered rows =" + DGV_SPI_Summary.RowCount;
            PlotGraphScottPlotSummary();

        }

        private void BtnClearFilter_Click(object sender, EventArgs e)
        {
            AirportSMS_Class acls = new AirportSMS_Class();
            acls.ClearFilter(DGV_SPI_Summary, DT_Summary);

            //int visibleCount = DGV_SPI_Summary.Rows.GetRowCount(DataGridViewElementStates.Visible) - 1;

            TxtFilterSPISummary.Text = "Total rows =" + DGV_SPI_Summary.RowCount;

            PlotGraphScottPlotSummary();
        }

        private void ComboBoxSPIsummaryColName_SelectedIndexChanged(object sender, EventArgs e)
        {
            AirportSMS_Class acls = new AirportSMS_Class();
            if (ComboBoxSPIsummaryColName.SelectedItem == null)
                return;

            string columnName = ComboBoxSPIsummaryColName.SelectedItem.ToString();

            acls.LoadDistinctValuesFromDT(
                DT_Summary,
                columnName,
                ComboBoxSPISummaryValue
            );
        }

        private void ComboBoxSummaryAllColName_SelectedIndexChanged(object sender, EventArgs e)
        {
            AirportSMS_Class acls = new AirportSMS_Class();
            if (ComboBoxSummaryAllColName.SelectedItem == null)
                return;

            string columnName = ComboBoxSummaryAllColName.SelectedItem.ToString();

            acls.LoadDistinctValuesFromDT(
               //DT_Summary_All,
               dt1,
                columnName,
                ComboBoxFilterValueALL
            );
        }

        public void CopyDataFromDGVToDTWithoutColumName(DataGridView dgv, DataTable dt)
        {
            try
            {
                dt.Clear();
                // --- 2. POPULATE DATA (The Extension) ---
                foreach (DataGridViewRow dgvRow in dgv.Rows)
                {
                    // Skip the blank 'new row' at the bottom of the grid
                    if (dgvRow.IsNewRow) continue;

                    DataRow dr = dt.NewRow();

                    // We only loop through the columns we actually added to the DataTable
                    foreach (DataColumn dc in dt.Columns)
                    {
                        // Pull the cell value based on the column name
                        object cellValue = dgvRow.Cells[dc.ColumnName].Value;

                        // C# 7.3 Null Coalescing: use DBNull if cell is empty
                        dr[dc.ColumnName] = cellValue ?? DBNull.Value;
                    }

                    dt.Rows.Add(dr);
                }
            }
            catch
            {

            }

            
        }

        private void BtnFilterAll_Click(object sender, EventArgs e)
        {
            AirportSMS_Class acls = new AirportSMS_Class();
            if (ComboBoxSummaryAllColName.SelectedItem == null ||
                    ComboBoxFilterValueALL.SelectedItem == null)
                return;


            /*if(IsMonthlyFilter)
            {
                acls.FilterDGV_DT(
                    DGV_SPI_Summary_ALL,
                    dt_filter_monthly,
                    ComboBoxSummaryAllColName.SelectedItem.ToString(),
                    ComboBoxFilterValueALL.SelectedItem.ToString()
                );

            }
            else
            {
                acls.FilterDGV_DT(
                    DGV_SPI_Summary_ALL,
                    DT_Summary_All,
                    ComboBoxSummaryAllColName.SelectedItem.ToString(),
                    ComboBoxFilterValueALL.SelectedItem.ToString()
                );
            }

            TxtNoOfFilteredData.Text = "Total filtered rows = " + DGV_SPI_Summary_ALL.RowCount;*/

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
                    dt1,
                    ComboBoxSummaryAllColName.SelectedItem.ToString(),
                    ComboBoxFilterValueALL.SelectedItem.ToString()
                );
            }

            
            TxtNoOfFilteredData.Text = "Total filtered rows = " + DGV_ALL_SPIs_GridMode.RowCount;

            //acls.AddLastSumRow_DGV(DGV_SPI_Summary_ALL, 4, 16);
            acls.AddLastSumRow_DGV_GridMode(DGV_ALL_SPIs_GridMode, "Current Year Observed");

            /*
            // Get the index of the column named "Current Year Observed"
            int CurrColIndex = DGV_ALL_SPIs_GridMode.Columns["Current Year Observed"].Index;
            double[] MonthData = sumgridocx.ReadingCommaSparatedMonthlyDataFromDGV(DGV_ALL_SPIs_GridMode, DGV_ALL_SPIs_GridMode.RowCount-1, "Current Year Observed");
            double spitotal = sumgridocx.SumSPITotal(MonthData);

            dt.Rows[TotalRow]["Current Year Total"] = spitotal;*/


            sumgridocx.DGV_SPI_Summary_GridMode_Settings(DGV_ALL_SPIs_GridMode);
            //FillingDataInMonthlySummaryDGV_DT();
            FillingDataInMonthlySummaryDGV_DT_GridMode();

            PlotGraphScottPlotMonthly();
        }

        private void BtnClearFilterAll_Click(object sender, EventArgs e)
        {

            //IsMonthlyFilter = false;
            AirportSMS_Class acls = new AirportSMS_Class();
            if (IsMonthlyFilter)
            {
                //acls.ClearFilter(DGV_SPI_Summary_ALL, dt_filter_monthly);
                acls.ClearFilter(DGV_ALL_SPIs_GridMode, dt_filter_monthly1);
            }
            else
            {
                //acls.ClearFilter(DGV_SPI_Summary_ALL, DT_Summary_All);
                acls.ClearFilter(DGV_ALL_SPIs_GridMode, dt1);
            }


            sumgridocx.DGV_SPI_Summary_GridMode_Settings(DGV_ALL_SPIs_GridMode);
            TxtNoOfFilteredData.Text = "Total rows =" + DGV_ALL_SPIs_GridMode.RowCount;
            //int visibleCount = DGV_SPI_Summary.Rows.GetRowCount(DataGridViewElementStates.Visible) - 1;

            //TxtNoOfFilteredData.Text = "Total rows =" + DGV_SPI_Summary_ALL.RowCount;
            FillingDataInMonthlySummaryDGV_DT_GridMode();
            //FillingDataInMonthlySummaryDGV_DT();
            PlotGraphScottPlotMonthly();
        }

        private void BtnAscendingAll_Click(object sender, EventArgs e)
        {

            int fromRow = 0; //rowindex
            //int toRow = DGV_SPI_Summary_ALL.RowCount - 2;   //rowindex        // <-- rows to sort -1 instead of -2
            int toRow = DGV_ALL_SPIs_GridMode.RowCount - 2;

            //int toRow = DGV_SPI_Summary.Rows.GetRowCount(DataGridViewElementStates.Visible) - 2;
            // <-- rows to sort
            //MessageBox.Show("torow = " + toRow);
            int sortColumn = 0;
            bool ascending = true;

            if (ComboBoxSummaryAllColName.Text == null)
                return;

            string colname = ComboBoxSummaryAllColName.Text;

            sortColumn = DGV_ALL_SPIs_GridMode.Columns[colname].Index;

            var data = ReadDgvRows(DGV_ALL_SPIs_GridMode, fromRow, toRow);
            var sorted = SortData(data, sortColumn, ascending);
            WriteDgvRows(DGV_ALL_SPIs_GridMode, sorted, fromRow);

            /*sortColumn = DGV_SPI_Summary_ALL.Columns[colname].Index;
            var data = ReadDgvRows(DGV_SPI_Summary_ALL, fromRow, toRow);
            var sorted = SortData(data, sortColumn, ascending);
            WriteDgvRows(DGV_SPI_Summary_ALL, sorted, fromRow);*/
        }

        private void BtnDescendingAll_Click(object sender, EventArgs e)
        {
            int fromRow = 0; //rowindex
            //int toRow = DGV_SPI_Summary_ALL.RowCount - 2;   //rowindex        // <-- rows to sort -1 instead of -2
            int toRow = DGV_ALL_SPIs_GridMode.RowCount - 2;
            //int toRow = DGV_SPI_Summary.Rows.GetRowCount(DataGridViewElementStates.Visible) - 2;
            // <-- rows to sort
            //MessageBox.Show("torow = " + toRow);
            int sortColumn = 0;
            bool ascending = false;

            if (ComboBoxSummaryAllColName.Text == null)
                return;

            string colname = ComboBoxSummaryAllColName.Text;

            sortColumn = DGV_ALL_SPIs_GridMode.Columns[colname].Index;

            var data = ReadDgvRows(DGV_ALL_SPIs_GridMode, fromRow, toRow);
            var sorted = SortData(data, sortColumn, ascending);
            WriteDgvRows(DGV_ALL_SPIs_GridMode, sorted, fromRow);

            /*sortColumn = DGV_SPI_Summary_ALL.Columns[colname].Index;
            var data = ReadDgvRows(DGV_SPI_Summary_ALL, fromRow, toRow);
            var sorted = SortData(data, sortColumn, ascending);
            WriteDgvRows(DGV_SPI_Summary_ALL, sorted, fromRow);*/
        }

        private void Default_Click(object sender, EventArgs e)
        {
            int fromRow = 0; //rowindex
            //int toRow = DGV_SPI_Summary_ALL.RowCount - 2;   //rowindex        // <-- rows to sort -1 instead of -2
            int toRow = DGV_ALL_SPIs_GridMode.RowCount - 2;
            //int toRow = DGV_SPI_Summary.Rows.GetRowCount(DataGridViewElementStates.Visible) - 2;
            // <-- rows to sort
            //MessageBox.Show("torow = " + toRow);
            int sortColumn = 0;
            bool ascending = true;

            /*if (ComboBoxSummaryAllColName.Text == null)
                return;

            string colname = ComboBoxSummaryAllColName.Text;

            sortColumn = DGV_SPI_Summary_ALL.Columns[colname].Index;*/


            /*var data = ReadDgvRows(DGV_SPI_Summary_ALL, fromRow, toRow);
            var sorted = SortData(data, sortColumn, ascending);
            WriteDgvRows(DGV_SPI_Summary_ALL, sorted, fromRow);*/

            var data = ReadDgvRows(DGV_ALL_SPIs_GridMode, fromRow, toRow);
            var sorted = SortData(data, sortColumn, ascending);
            WriteDgvRows(DGV_ALL_SPIs_GridMode, sorted, fromRow);
        }

        /*private void ApplyMonthFilter(List<int> selectedMonthCols)
        {
            DataTable dtFiltered = DT_Summary_All.Copy();
            int totalRowIndex = dtFiltered.Rows.Count - 1;

            // Reset total row
            for (int c = 4; c <= 16; c++)
                dtFiltered.Rows[totalRowIndex][c] = 0;

            for (int r = 0; r < totalRowIndex; r++)
            {
                double rowTotal = 0;

                for (int c = 4; c <= 15; c++)
                {
                    if (!selectedMonthCols.Contains(c))
                    {
                        dtFiltered.Rows[r][c] = 0;
                    }
                    else
                    {
                        double val = Convert.ToDouble(dtFiltered.Rows[r][c]);
                        rowTotal += val;
                        dtFiltered.Rows[totalRowIndex][c] =
                            Convert.ToDouble(dtFiltered.Rows[totalRowIndex][c]) + val;
                    }
                }

                dtFiltered.Rows[r][16] = rowTotal;
                dtFiltered.Rows[totalRowIndex][16] =
                    Convert.ToDouble(dtFiltered.Rows[totalRowIndex][16]) + rowTotal;
            }

            BindDTtoDGV(DGV_SPI_Summary_ALL, dtFiltered);
        }*/

        public List<int> ParseSelectedMonths(string input, int shiftindexby = 3)
        {
            HashSet<int> monthCols = new HashSet<int>();

            input = input.Replace(" ", "");

            // Range format: 8-10
            if (input.Contains("-"))
            {
                string[] parts = input.Split('-');
                int start = int.Parse(parts[0]);
                int end = int.Parse(parts[1]);

                for (int m = start; m <= end; m++)
                    monthCols.Add(shiftindexby + m);   // 4 = JAN
            }
            // Comma separated: 2,8,11,12
            else if (input.Contains(","))
            {
                foreach (string s in input.Split(','))
                {
                    int m = int.Parse(s);
                    monthCols.Add(shiftindexby + m);
                }
            }
            // Single month
            else
            {
                int m = int.Parse(input);
                monthCols.Add(shiftindexby + m);
            }

            return monthCols.ToList();
        }

        public void ApplyMonthFilter_GridMode(List<int> selectedMonthCols)
        {
            DataTable dtFiltered = dt1.Copy();

            int totalRowIndex = dtFiltered.Rows.Count - 1;

            // Reset total row
            /*for (int c = 4; c <= 16; c++)
                dtFiltered.Rows[totalRowIndex][c] = 0*/

            int CurrColIndex = dtFiltered.Columns.IndexOf("Current Year Observed");
            double[] MonthData = null;
            //double[] TempMonthData = null;
            //double GrandTotalData = 0;

            // Join the list items into a string separated by commas
            //string message = "Selected Months: " + string.Join(", ", selectedMonthCols);
            // Display the MessageBox
            //MessageBox.Show(message, "Month Selection");


            for (int r = 0; r <= totalRowIndex; r++)
            {
                //double rowTotal = 0;
                MonthData = sumgridocx.ReadingCommaSparatedMonthlyDataFromDT(dt1, r, "Current Year Observed");
                for (int c = 1; c <= 12; c++)
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


                double sum = formattedString.Split(',')           // 1. Split into array
                                    .Skip(1)              // 2. Skip the 'Year'
                                    .Select(s => {        // 3. Convert to double safely
                                        double.TryParse(s.Trim(), out double val);
                                        return val;
                                    })
                                    .Sum();               // 4. Add them all up
                                                          //double[] YrMonthData 
                                                          //double total = fspgrdox.SumSPITotal(YrMonthData);
                                                          //"Current Year Total"
                                                          //totalRow["Current Year Total"] = sum;
                dtFiltered.Rows[r]["Current Year Total"] = sum;
                //GrandTotalData += sum;
                //dtFiltered.Rows[r][16] = rowTotal;
                //dtFiltered.Rows[totalRowIndex][16] = Convert.ToDouble(dtFiltered.Rows[totalRowIndex][16]) + rowTotal;
            }

           
            //string lastrowCurrTotal = sumgridocx.GetMonthlySPISummationString(dtFiltered, "Current Year Observed");
            //dtFiltered.Rows[totalRowIndex+1]["Current Year Observed"] = lastrowCurrTotal;
            //dtFiltered.Rows[totalRowIndex+1]["Current Year Total"] = GrandTotalData;
            //totalRow[CurrColIndex] = lastrowCurrTotal;

            BindDTtoDGV(DGV_ALL_SPIs_GridMode, dtFiltered);
        }

        private void BtnSelectedMonthView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtSelectedMonth.Text))
            {
                //BindDTtoDGV(DGV_SPI_Summary_ALL, DT_Summary_All);
                BindDTtoDGV(DGV_ALL_SPIs_GridMode, dt1);

                FillingDataSPISummaryDGV_DT_GridMode();
                FillingDataInMonthlySummaryDGV_DT_GridMode();

                PlotGraphScottPlotSummary();
                PlotGraphScottPlotMonthly();

                IsMonthlyFilter = false;
                return;
            }

            try
            {
                //List<int> selectedMonths = ParseSelectedMonths(TxtSelectedMonth.Text);
                List<int> selectedMonths = ParseSelectedMonths(TxtSelectedMonth.Text, 0);
                
                //ApplyMonthFilter(selectedMonths);
                ApplyMonthFilter_GridMode(selectedMonths);

                //MessageBox.Show("Filtered = " + TxtSelectedMonth.Text);

                IsMonthlyFilter = true;
                
                FillingDataSPISummaryDGV_DT_GridMode();
                FillingDataInMonthlySummaryDGV_DT_GridMode();

                //FillingDataSPISummaryDGV_DT();
                //FillingDataInMonthlySummaryDGV_DT();

                PlotGraphScottPlotSummary();
                PlotGraphScottPlotMonthly();

                //PopulateDataTableStructureFromDGV(DGV_SPI_Summary_ALL, dt_filter_monthly);//creates column in dt from dgv
                //CopyDataFromDGVToDTWithoutColumName(DGV_SPI_Summary_ALL, dt_filter_monthly);//copies data in dt from dgv

                PopulateDataTableStructureFromDGV(DGV_ALL_SPIs_GridMode, dt_filter_monthly1);//creates column in dt from dgv
                CopyDataFromDGVToDTWithoutColumName(DGV_ALL_SPIs_GridMode, dt_filter_monthly1);//copies data in dt from dgv

            }
            catch
            {
                MessageBox.Show("Invalid month format.\nExamples:\n1-12\n8-10\n2,8,11,12");
            }
        }

        private void selectedRowsToDocxAsIndividualFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectedRowsToDocxAsMergedFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void selectedRowsToDocxAsIndividualFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];
            if (fm.TxtProjectLocation.Text == "")
            {
                MessageBox.Show("No valid project loaded");
            }
            else
            {
                //string projectfolder = fm.TxtProjectLocation.Text;
                //is with background for dashboard in wordfile
                bool iswithbackground;
                if (dashboardWithBackgroundToolStripMenuItem.Checked)
                    iswithbackground = true;
                else
                    iswithbackground = false;

                //current year
                int curryear = Convert.ToInt16(TxtSPISummaryCurrYear.Text);

                if (DGV_ALL_SPIs_GridMode != null)
                    sumgridocx.ExportSPIs_DocXv5(DGV_ALL_SPIs_GridMode, false, curryear, iswithbackground);
            }
        }

        private void selectedRowsToDocxAsMergedFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];
            if (fm.TxtProjectLocation.Text == "")
            {
                MessageBox.Show("No valid project loaded");
            }
            else
            {
                //string projectfolder = fm.TxtProjectLocation.Text;

                bool iswithbackground;
                if (dashboardWithBackgroundToolStripMenuItem.Checked)
                    iswithbackground = true;
                else
                    iswithbackground = false;

                //current year
                int curryear = Convert.ToInt16(TxtSPISummaryCurrYear.Text);
                if (DGV_ALL_SPIs_GridMode != null)
                    sumgridocx.ExportSPIs_DocXv5(DGV_ALL_SPIs_GridMode, true, curryear, iswithbackground);
            }
        }
    }
}
