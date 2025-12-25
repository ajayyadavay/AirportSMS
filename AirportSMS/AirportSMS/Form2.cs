using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                    ["Curr_Yr_FM"] = new ChartStyleClass.SeriesStyleConfig
                    {
                        ShowSeries = PlotCurrFM,
                        ShowValueLabel = PlotCurrFM,
                        LegendText = "Monthly Flight Movement (" + TxtFMCurrentYear.Text + ") (Total = " + sum1 + ")",
                        ScottPlot_Chart_Type = "COLUMN",
                        AreaFillAbove = false,
                        YValues = Y1_axis.Take(rows).ToArray()
                    },
                    ["Prev_Yr_FM"] = new ChartStyleClass.SeriesStyleConfig
                    {
                        ShowSeries = PlotPrevFM,
                        ShowValueLabel = PlotPrevFM,
                        LegendText = "Monthly Flight Movement (" + TxtFMPrevYear.Text + ") (Total = " + sum2 + ")",
                        ScottPlot_Chart_Type = "COLUMN",
                        AreaFillAbove = false,
                        YValues = Y2_axis.Take(rows).ToArray()
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
    }
}
