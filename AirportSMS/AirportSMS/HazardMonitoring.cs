using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AirportSMS
{
    public partial class FrmHazardMonitoring : Form
    {
        string[] X_axis = new string[13];
        double [] Y1_axis_prev_year = new double[100];
        double [] Y1_axis_curr_year_target = new double[100];
        double [] Y1_axis_curr_year_obs = new double[100];
        

        public FrmHazardMonitoring()
        {
            InitializeComponent();

            GenerateRowsDGV();

            // X axis data
            X_axis[0] = "YEAR";
            X_axis[1] = "JAN";
            X_axis[2] = "FEB";
            X_axis[3] = "MAR";
            X_axis[4] = "APR";
            X_axis[5] = "MAY";
            X_axis[6] = "JUN";
            X_axis[7] = "JUL";
            X_axis[8] = "AUG";
            X_axis[9] = "SEP";
            X_axis[10] = "OCT";
            X_axis[11] = "NOV";
            X_axis[12] = "DEC";
        }

        public void GenerateRowsDGV()
        {
            // generate rows
            string[] descript = { "Prv_Year_obs", "Curr_Year_Target_%", "Curr_Year_Target_val",
            "Curr_Year_obs"};

            for (int i = 0; i < 4; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["ColDes"].Value = descript[i];
                dataGridView1.Rows[i].Cells["ColID"].Value = i + 1;
            }

            // Assuming you have dataGridView1 already populated

            // Row 0 -> Red
            foreach (DataGridViewCell cell in dataGridView1.Rows[0].Cells)
            {
                cell.Style.ForeColor = Color.Red;
            }

            // Row 2 -> Green
            foreach (DataGridViewCell cell in dataGridView1.Rows[2].Cells)
            {
                cell.Style.ForeColor = Color.Green;
            }

            // Row 3 -> Blue
            foreach (DataGridViewCell cell in dataGridView1.Rows[3].Cells)
            {
                cell.Style.ForeColor = Color.Blue;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        public void ChartStyle1(Chart chart)
        {
            var chartArea = chart.ChartAreas[0];
            var legend = chart.Legends[0];

            // -----------------------------------------------------
            // Background
            // -----------------------------------------------------
            chart.BackColor = Color.White;
            chartArea.BackColor = Color.White;
            chartArea.BorderWidth = 0;

            // -----------------------------------------------------
            // Grid Lines (light grey modern look)
            // -----------------------------------------------------
            chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(220, 220, 220);
            chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(220, 220, 220);

            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Solid;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Solid;

            chartArea.AxisX.MinorGrid.Enabled = false;
            chartArea.AxisY.MinorGrid.Enabled = false;

            // -----------------------------------------------------
            // Axis Style
            // -----------------------------------------------------
            chartArea.AxisX.LineColor = Color.FromArgb(180, 180, 180);
            chartArea.AxisY.LineColor = Color.FromArgb(180, 180, 180);

            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            chartArea.AxisX.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            chartArea.AxisY.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);

            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.IsLabelAutoFit = false;

            // -----------------------------------------------------
            // Legend (Modern top bar)
            // -----------------------------------------------------
            legend.Docking = Docking.Top;
            legend.Alignment = StringAlignment.Center;
            legend.LegendStyle = LegendStyle.Row;
            legend.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            legend.BackColor = Color.White;
            legend.BorderColor = Color.Transparent;

            // -----------------------------------------------------
            // Title
            // -----------------------------------------------------
            chart.Titles.Clear();
            chart.Titles.Add("Monthly Performance Overview");
            chart.Titles[0].Font = new Font("Segoe UI Semibold", 14);
            chart.Titles[0].Alignment = ContentAlignment.TopCenter;



            // -------------------- X Axis Title --------------------
            chart.ChartAreas[0].AxisX.Title = "Months";
            chart.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 10, FontStyle.Bold);
            chart.ChartAreas[0].AxisX.TitleForeColor = Color.Black;


            // -------------------- Y Axis Title --------------------
            chart.ChartAreas[0].AxisY.Title = "values";
            chart.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 10, FontStyle.Bold);
            chart.ChartAreas[0].AxisY.TitleForeColor = Color.Black;



            // -----------------------------------------------------
            // Series Colors (Modern Color Palette)
            // -----------------------------------------------------
            Color[] modernColors =
            {
                Color.FromArgb(231, 76, 60),    // Red
                Color.FromArgb(46, 204, 113),   // Green
                Color.FromArgb(52, 152, 219),   // Blue
                Color.FromArgb(241, 196, 15),   // Yellow
                Color.FromArgb(155, 89, 182)    // Purple
            };

            int ci = 0;
            foreach (var s in chart.Series)
            {
                s.Color = modernColors[ci % modernColors.Length];
                s.BorderWidth = 3;
                s.ChartType = SeriesChartType.Line;
                s.BorderDashStyle = ChartDashStyle.Solid;
                s.MarkerStyle = MarkerStyle.Circle;
                s.MarkerSize = 7;
                s.MarkerColor = s.Color;
                s.MarkerBorderColor = Color.White;
                ci++;
            }
        }



        public void PlotGraph()
        {
            Chart1.Series.Clear();
            Chart1.Series.Add("Prv_Year_obs");
            Chart1.Series.Add("Curr_Year_Target_val");
            Chart1.Series.Add("Curr_Year_obs");

            for (int i = 0; i < 12; i++)
            {
                //input from datagridview1
                Y1_axis_prev_year[i] = Convert.ToDouble(dataGridView1.Rows[0].Cells[i+3].Value);
                Y1_axis_curr_year_target[i] = Convert.ToDouble(dataGridView1.Rows[2].Cells[i + 3].Value);
                Y1_axis_curr_year_obs[i] = Convert.ToDouble(dataGridView1.Rows[3].Cells[i + 3].Value);

                Chart1.Series["Prv_Year_obs"].Points.AddXY(X_axis[i+1], Y1_axis_prev_year[i]);
                Chart1.Series["Curr_Year_Target_val"].Points.AddXY(X_axis[i+1], Y1_axis_curr_year_target[i]);
                Chart1.Series["Curr_Year_obs"].Points.AddXY(X_axis[i+1], Y1_axis_curr_year_obs[i]);
            }

            Chart1.Series["Prv_Year_obs"].Color = Color.Red;
            Chart1.Series["Curr_Year_Target_val"].Color = Color.Green;
            Chart1.Series["Curr_Year_obs"].Color = Color.Blue;

            Chart1.Series["Prv_Year_obs"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            //Chart1.Series["Curr_Year_Target_val"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;

            var ax = Chart1.ChartAreas[0].AxisX;

            ax.Interval = 1;                   // Force all labels
            ax.IsLabelAutoFit = false;         // Disable auto hiding
            ax.LabelStyle.Angle = -45;         // Optional (better fit)
            //ax.MajorGrid.Enabled = false;      // Cleaner look

            ChartStyle1(Chart1);

            //Chart1.Series["Line"].Points.AddXY(2, 2);
            Chart1.Series["Prv_Year_obs"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Chart1.Series["Curr_Year_Target_val"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Chart1.Series["Curr_Year_obs"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            Chart1.Invalidate();
            Chart1.Update();
        }

        private void FrmHazardMonitoring_Load(object sender, EventArgs e)
        {
            /*// generate rows
            string[] descript = { "Prv_Year_obs", "Curr_Year_Target_%", "Curr_Year_Target_val",
            "Curr_Year_obs"};

            for(int i =0;i<4;i++)
            {
                //dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["ColDes"].Value = descript[i];
                dataGridView1.Rows[i].Cells["ColID"].Value = i + 1;
            }*/

            

           


            //SPI Type combobox
            ComboBoxSPI_Type.Items.Add("Lagging SPIs: Low Probability/High Severity");
            ComboBoxSPI_Type.Items.Add("Precursor SPIs: High Probability/Low Severity");
            ComboBoxSPI_Type.Items.Add("Leading SPIs: Proactive");



        }


        private void TxtPercentTarget_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double per_trgt;
                if(TxtPercentTarget.Text == "")
                {
                    per_trgt = 0.0;
                }
                else
                {
                    per_trgt = Convert.ToDouble(TxtPercentTarget.Text);
                }
                for (int i = 3; i <= 14; i++)
                {
                    dataGridView1.Rows[1].Cells[i].Value = per_trgt;
                }
                
            }
            catch
            {

            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Only watch Row 0 and Row 1
            if (e.RowIndex != 0 && e.RowIndex != 1 && e.RowIndex != 3) return;

            // Only columns 3 to 14
            if (e.ColumnIndex < 3 || e.ColumnIndex > 14) return;

            try
            {
                // Read Row0
                double row0 = 0;
                var val0 = dataGridView1[e.ColumnIndex, 0].Value;
                if (val0 != null && val0.ToString().Trim() != "")
                    double.TryParse(val0.ToString(), out row0);

                // Read Row1
                double row1 = 0;
                var val1 = dataGridView1[e.ColumnIndex, 1].Value;
                if (val1 != null && val1.ToString().Trim() != "")
                    double.TryParse(val1.ToString(), out row1);

                // Calculate Row2
                double result = row0 * (100 + row1) / 100.0;

                // Write result to Row2
                dataGridView1[e.ColumnIndex, 2].Value = result;



                // ----- NEW STYLING LOGIC -----
                // Make Row3 cell bold and larger if Row3 > Row2
                
                
                var cellRow2 = dataGridView1[e.ColumnIndex, 2];
                var cellRow3 = dataGridView1[e.ColumnIndex, 3];

                if (double.TryParse(cellRow2.Value?.ToString(), out double valRow2) &&
                    double.TryParse(cellRow3.Value?.ToString(), out double valRow3))
                {
                    if (valRow3 > valRow2)
                    {
                        var currentFont = cellRow3.Style.Font ?? dataGridView1.DefaultCellStyle.Font;
                        cellRow3.Style.Font = new Font(currentFont.FontFamily, 12f, FontStyle.Bold);
                        cellRow3.Style.ForeColor = Color.Blue; // keep blue color
                        cellRow3.Style.BackColor = Color.FromArgb(221, 235, 247);
                    }
                    else
                    {
                        cellRow3.Style.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular);
                        cellRow3.Style.ForeColor = Color.Blue; // keep blue color
                        cellRow3.Style.BackColor = Color.White;
                    }
                }

                // ----- END NEW LOGIC -----

                //Plot graph on changing any cells of row0, row2, row3
                PlotGraph();


            }
            catch 
            { 

            }
        }

        private void TxtCurrentYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtCurrentYear.Text == "")
                {
                    dataGridView1.Rows[0].Cells[2].Value = "";
                    dataGridView1.Rows[1].Cells[2].Value = "";
                    dataGridView1.Rows[2].Cells[2].Value = "";
                    dataGridView1.Rows[3].Cells[2].Value = "";
                }
                else
                {
                    dataGridView1.Rows[0].Cells[2].Value = Convert.ToInt32(TxtCurrentYear.Text) - 1;
                    dataGridView1.Rows[1].Cells[2].Value = Convert.ToInt32(TxtCurrentYear.Text);
                    dataGridView1.Rows[2].Cells[2].Value = Convert.ToInt32(TxtCurrentYear.Text);
                    dataGridView1.Rows[3].Cells[2].Value = Convert.ToInt32(TxtCurrentYear.Text);
                }
                    
            }
            catch
            {

            }
        }

        private void ComboBoxSPI_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtSPI_Type.Text = ComboBoxSPI_Type.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void createSPICardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public static void WriteToSPIFile(string projectFolder, SMS_Project_Package_class.SPI spi)
        {
            //if filename is same, it will be overwritten
            //if filename is different, it will be created as new file
            string spiFolder = Path.Combine(projectFolder, "SPIs");

            if (!Directory.Exists(spiFolder))
                Directory.CreateDirectory(spiFolder);

            // SPI ID for filename: SPI_001.json, SPI_002.json, etc.
            string fileName = $"SPI_{spi.SPI_Id}.json";

            string fullPath = Path.Combine(spiFolder, fileName);

            File.WriteAllText(fullPath, JsonSerializer.Serialize(spi, jsonOptions));
        }

        private static JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            AllowTrailingCommas = false,
            ReadCommentHandling = JsonCommentHandling.Skip,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            UnknownTypeHandling = JsonUnknownTypeHandling.JsonNode
        };

        private bool IsChecked(CheckBox chk)
        {
            if (chk.Checked == true)
                return true;
            else
                return false;
        }

        private void SaveOrCreateNewSPIFinal(bool IsCreateNew, string projectfolder)
        {
            //This gets the already opened / running instance of FrmMain
            //FrmMain fm = new FrmMain(); //New form is created but not shown
            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];
            //string projectfolder = fm.TxtProjectLocation.Text;

            //SPI values from form

            //SPI selection
            bool ISobj, ISdata, ISspec, ISreal;
            ISobj = IsChecked(checkBox1);
            ISdata = IsChecked(checkBox2);
            ISspec = IsChecked(checkBox3);
            ISreal = IsChecked(checkBox4);

            //SPI info
            string spiID;

            if (IsCreateNew)
                spiID = Guid.NewGuid().ToString();
            else
                spiID = TxtSPI_ID.Text;

            //SPI data for previous and current year
            double[] prev_year_Obs = new double[13];
            double[] curr_year_targetPer = new double[13];
            double[] curr_year_targetVal = new double[13];
            double[] curr_year_obs = new double[13];

            for (int i = 0; i < 13; i++)
            {
                //input from datagridview1
                prev_year_Obs[i] = Convert.ToDouble(dataGridView1.Rows[0].Cells[i + 2].Value);
                curr_year_targetPer[i] = Convert.ToDouble(dataGridView1.Rows[1].Cells[i + 2].Value);
                curr_year_targetVal[i] = Convert.ToDouble(dataGridView1.Rows[2].Cells[i + 2].Value);
                curr_year_obs[i] = Convert.ToDouble(dataGridView1.Rows[3].Cells[i + 2].Value);

            }

            // 2. Create the project object
            var thisSPI = new SMS_Project_Package_class.SPI
            {
                // Selecting SPIs
                IsRelatedToObjective = ISobj,
                IsBasedOnDateAndMeasurement = ISdata,
                IsSpecificQuantifiable = ISspec,
                IsRealistic = ISreal,

                // SPI Info
                SPI_Id = spiID,
                SPI_Name = TxtSPI_Name.Text,

                // Defining SPI
                SPI_Type = TxtSPI_Type.Text,
                SPI_Des = TxtSPI_Description.Text,
                SPI_Manage = Txt_SPI_Manage.Text,
                SPI_Inform = TxtSPI_Inform.Text,
                SPI_Unit = Txt_SPI_Unit.Text,
                SPI_Calc = TxtSPI_Calc.Text,

                // Data arrays (each 13 elements: index 0 unused or 1–12 months)
                PrevYearObserved = prev_year_Obs,
                CurrYearTargetPercent = curr_year_targetPer,
                CurrYearTargetValue = curr_year_targetVal,
                CurrYearObserved = curr_year_obs
            };

            //write to existing spi file or create new and write to it
            WriteToSPIFile(projectfolder, thisSPI);

            //creating card
            string name = TxtSPI_Name.Text;
            string id = spiID;
            string value = TxtSPI_Value.Text;


            if(IsCreateNew)
            {
                //Panel newCard = CreateSPICard(name, id, value);
                AirportSMS_Class asms_cls = new AirportSMS_Class();
                Panel newCard = asms_cls.CreateSPICard(fm.flowLayoutPanel1, name, id, value);
                fm.flowLayoutPanel1.Controls.Add(newCard);
            }
            
        }

        private void saveSPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];
            if(fm.TxtProjectLocation.Text == "")
            {
                MessageBox.Show("No valid project loaded...");
            }
            else
            {
                string projectfolder = fm.TxtProjectLocation.Text;
                SaveOrCreateNewSPIFinal(false, projectfolder);
                fm.updateSPICardToolStripMenuItem_Click(null, null);
                MessageBox.Show("SPI saved successfully");
            }
               
        }

        private void createNewSPIToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];

            if (fm.TxtProjectLocation.Text == "")
            {
                MessageBox.Show("No valid project loaded...");
            }
            else
            {
                string projectfolder = fm.TxtProjectLocation.Text;
                SaveOrCreateNewSPIFinal(true, projectfolder);
                fm.updateSPICardToolStripMenuItem_Click(null, null);
                MessageBox.Show("New SPI created successfully");
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //PlotGraph();
        }

        private void importTemplateSPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "";
            OpenFileDialog openfiledialog1 = new OpenFileDialog();
            openfiledialog1.Filter = "SPI Template (*.json)|*.json";//"Text File(*.txt)|*.txt|Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            openfiledialog1.FilterIndex = 1;

            if (openfiledialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = openfiledialog1.FileName;
            }
            else if (openfiledialog1.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;

            string json = File.ReadAllText(path); 

            SMS_Project_Package_class.SPI spi = JsonSerializer.Deserialize<SMS_Project_Package_class.SPI>(
                json,
                jsonOptions
            );

            AirportSMS_Class asms = new AirportSMS_Class();
            if (spi != null)
            {
                //Selecting SPIs
                asms.CheckOnIfTrue(checkBox1, spi.IsRelatedToObjective);
                asms.CheckOnIfTrue(checkBox2, spi.IsBasedOnDateAndMeasurement);
                asms.CheckOnIfTrue(checkBox3, spi.IsSpecificQuantifiable);
                asms.CheckOnIfTrue(checkBox4, spi.IsRealistic);

                //SPI info
                TxtSPI_ID.Text = spi.SPI_Id;
                TxtSPI_Name.Text = spi.SPI_Name;
                TxtSPI_Value.Text = "5200";

                //Defining SPIs
                TxtSPI_Type.Text = spi.SPI_Type;
                TxtSPI_Description.Text = spi.SPI_Des;
                Txt_SPI_Manage.Text = spi.SPI_Manage;
                TxtSPI_Inform.Text = spi.SPI_Inform;
                Txt_SPI_Unit.Text = spi.SPI_Unit;
                TxtSPI_Calc.Text = spi.SPI_Calc;

                //SPIs data
                for (int i = 0; i < 13; i++)
                {

                    //MessageBox.Show("dgv " + i + " : " + spi.PrevYearObserved[i]);
                    dataGridView1.Rows[0].Cells[i + 2].Value = spi.PrevYearObserved[i].ToString();
                    dataGridView1.Rows[1].Cells[i + 2].Value = spi.CurrYearTargetPercent[i];
                    dataGridView1.Rows[2].Cells[i + 2].Value = spi.CurrYearTargetValue[i];
                    dataGridView1.Rows[3].Cells[i + 2].Value = spi.CurrYearObserved[i];
                }

                PlotGraph();
                //createNewSPIToolStripMenuItem.Enabled = false;

            }



        }
    }
}
