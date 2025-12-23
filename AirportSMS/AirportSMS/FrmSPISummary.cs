using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AirportSMS.FrmHazardMonitoring;
using static AirportSMS.FrmMain;
using sctplot = ScottPlot;
using sctplotwin = ScottPlot.WinForms;

namespace AirportSMS
{
    public partial class FrmSPISummary : Form
    {
        public sctplotwin.FormsPlot formsPlot1;

        public void InitializeScottPlot()
        {
            // Only if not already created
            if (formsPlot1 == null)
            {
                formsPlot1 = new sctplotwin.FormsPlot();
                formsPlot1.Dock = DockStyle.Fill;         // Fill the panel
                PanelPlotSPISummary.Controls.Add(formsPlot1);       // Add to your panel
            }
        }

        public FrmSPISummary()
        {
            InitializeComponent();
            SetupDGVWrapping();
            LoadSPISummary();
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
                        spi.Total.ToString("0.00")
                    );
                }
            }

                
        }


        public void PlotGraphScottPlot()
        {
            if (formsPlot1 == null) return;

            // Clear previous plot
            formsPlot1.Plot.Clear();

            string[] X_axis = new string[100];
            string[] Y_axis = new string[100];

            for(int i =0;i<)

            // Collect data from DataGridView
            double[] XPos = Enumerable.Range(0, 12).Select(i => (double)i).ToArray();
            string[] Xs = X_axis.Skip(1).Take(12).ToArray(); // JAN, FEB, ...

            // Fill series data
            for (int i = 0; i < 12; i++)
            {
                Y1_axis_prev_year[i] = Convert.ToDouble(dataGridView1.Rows[0].Cells[i + 3].Value);
                Y1_axis_curr_year_target[i] = Convert.ToDouble(dataGridView1.Rows[2].Cells[i + 3].Value);
                Y1_axis_curr_year_obs[i] = Convert.ToDouble(dataGridView1.Rows[3].Cells[i + 3].Value);
            }

            // Define series
            var seriesConfig = new Dictionary<string, SeriesStyleConfig>()
            {
                ["Prv_Year_obs"] = new SeriesStyleConfig
                {
                    ShowSeries = true,
                    ShowValueLabel = true,
                    LegendText = "Observed value for previous year",
                    ScottPlot_Chart_Type = "COLUMN",
                    YValues = Y1_axis_prev_year.Take(12).ToArray()
                }
                
            };

            double maxval1 = Y1_axis_curr_year_target.Max();
            double maxval2 = Y1_axis_curr_year_obs.Max();
            double maxval = Math.Max(maxval1, maxval2);

            // Apply styling and plotting
            ScottPlotStyle(formsPlot1, Xs, XPos, maxval, seriesConfig);

            formsPlot1.Refresh();
        }






        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
