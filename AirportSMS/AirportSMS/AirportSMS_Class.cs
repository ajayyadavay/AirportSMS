using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static AirportSMS.FrmMain;
using static AirportSMS.SMS_Project_Package_class;

namespace AirportSMS
{
    internal class AirportSMS_Class
    {
        public Panel CreateSPICard(FlowLayoutPanel flowLayoutPanel1,
                           string spiName, string spiID, string spiValuePrevObs, string spiValCurrTarget, string spiValCurrObs, string spiType,
                           string spiProgressPercent)
        {
            Panel card = new Panel();
            card.Width = 250;
            card.Height = 250;
            card.Margin = new Padding(12);
            card.Padding = new Padding(10);
            card.BackColor = Color.White;
            card.Cursor = Cursors.Hand;

            card.Tag = new { 
                Name = spiName, 
                ID = spiID, 
                ValuePrevObs = spiValuePrevObs,
                ValueCurrTarget = spiValCurrTarget,
                ValueCurrObs = spiValCurrObs,
                Type = spiType };

            // ░░░ MAIN TABLE (3 ROWS) ░░░
            TableLayoutPanel main = new TableLayoutPanel();
            main.RowCount = 3;
            main.ColumnCount = 1;
            main.Dock = DockStyle.Fill;
            main.BackColor = Color.Transparent;

            main.RowStyles.Add(new RowStyle(SizeType.AutoSize));        // Row 1 - ID + Delete
            main.RowStyles.Add(new RowStyle(SizeType.AutoSize));        // Row 2 - Name
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));   // Row 3 - 3-column stats

            // ░░░ ROW 1: 2 COLUMN TABLE (ID + DELETE BUTTON) ░░░
            TableLayoutPanel row1 = new TableLayoutPanel();
            row1.RowCount = 1;
            row1.ColumnCount = 2;
            row1.Dock = DockStyle.Top;
            row1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F)); // grows
            row1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 28));   // Delete fixed width
            row1.AutoSize = true;  // Row height = max of controls

            /*
            Label lblID = new Label();
            int maxIDLength = 10;  // maximum characters to show
            string displayID = spiID.Length > maxIDLength
                                 ? spiID.Substring(0, maxIDLength) + "…"
                                 : spiID;
            lblID.Text = $"ID: {displayID}";
            lblID.Font = new Font("Segoe UI", 9);
            lblID.ForeColor = Color.FromArgb(120, 120, 120);
            lblID.AutoSize = true;
            lblID.MaximumSize = new Size(card.Width - 40, 0); // WRAP enabled
            lblID.Anchor = AnchorStyles.Left | AnchorStyles.Top; // important to prevent row grow
            //lblID.Dock = DockStyle.Fill;
            */

            Label lblType = new Label();
            int maxIDLength = 50;  // maximum characters to show
            string displayType = spiType.Length > maxIDLength
                                 ? spiType.Substring(0, maxIDLength) + "…"
                                 : spiType;
            lblType.Text = $"Type: {displayType}";
            lblType.Font = new Font("Segoe UI", 10);
            lblType.ForeColor = Color.FromArgb(120, 120, 120);
            lblType.AutoSize = true;
            lblType.MaximumSize = new Size(card.Width - 40, 0); // WRAP enabled
            lblType.Anchor = AnchorStyles.Left | AnchorStyles.Top; // important to prevent row grow
            //lblID.Dock = DockStyle.Fill;

            Button btnDelete = new Button();
            btnDelete.Text = "×";
            btnDelete.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.BackColor = Color.FromArgb(200, 60, 70);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Size = new Size(28, 28);
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right; // fixed size, does not affect row height
            btnDelete.Margin = new Padding(0, 0, 0, 0);


            btnDelete.Click += (s, e) =>
            {
                if (MessageBox.Show("Delete this SPI?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    flowLayoutPanel1.Controls.Remove(card);
                    card.Dispose();

                    FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];

                    if (fm.TxtProjectLocation.Text == "")
                    {
                        MessageBox.Show("No valid project loaded...");
                    }
                    else
                    {
                        string project_folder = fm.TxtProjectLocation.Text;
                        string spiFolders = Path.Combine(project_folder, "SPIs");
                        string thisfilename_del = "SPI_" + spiID + ".json";
                        string filePath_del = Path.Combine(spiFolders, thisfilename_del);

                        if (File.Exists(filePath_del))
                        {
                            File.Delete(filePath_del);
                            MessageBox.Show("File deleted successfully.");
                        }

                    }

                }
            };

            //row1.Controls.Add(lblID, 0, 0);
            row1.Controls.Add(lblType, 0, 0);
            row1.Controls.Add(btnDelete, 1, 0);

            // ░░░ ROW 2: SPI NAME WRAP ░░░
            Label lblName = new Label();
            int maxNameLength = 75;  // maximum characters to show
            string displayName = spiName.Length > maxNameLength
                                 ? spiName.Substring(0, maxNameLength) + "…"
                                 : spiName;

            lblName.Text = displayName;
            lblName.Font = new Font("Segoe UI Semibold", 12);
            lblName.ForeColor = Color.FromArgb(45, 45, 45);
            lblName.AutoSize = true;
            lblName.MaximumSize = new Size(card.Width - 20, 0);
            lblName.Dock = DockStyle.Top;

            // ░░░ ROW 3: THREE COLUMNS (Prev, Target, Obs) ░░░
            TableLayoutPanel row3 = new TableLayoutPanel();
            row3.RowCount = 1;
            row3.ColumnCount = 3;
            row3.Dock = DockStyle.Fill;

            row3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
            row3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
            row3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));

            Label lblPrev = new Label();
            lblPrev.Text = "Prev:\n" + spiValuePrevObs;
            lblPrev.Font = new Font("Segoe UI", 9);
            //lblPrev.ForeColor = Color.FromArgb(0, 90, 158);
            lblPrev.ForeColor = Color.Red;
            lblPrev.AutoSize = true;
            lblPrev.Dock = DockStyle.Fill;

            Label lblTarget = new Label();
            lblTarget.Text = "Target:\n"+spiValCurrTarget;
            lblTarget.Font = new Font("Segoe UI", 9);
            lblTarget.ForeColor = Color.Green;
            lblTarget.AutoSize = true;
            lblTarget.Dock = DockStyle.Fill;

            Label lblCurrent = new Label();
            lblCurrent.Text = "Curr:\n"+spiValCurrObs;
            lblCurrent.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblCurrent.ForeColor = Color.Blue;
            lblCurrent.AutoSize = true;
            lblCurrent.Dock = DockStyle.Fill;

            row3.Controls.Add(lblPrev, 0, 0);
            row3.Controls.Add(lblTarget, 1, 0);
            row3.Controls.Add(lblCurrent, 2, 0);

            // ░░░ ADD ROWS TO MAIN LAYOUT ░░░
            main.Controls.Add(row1, 0, 0);
            main.Controls.Add(lblName, 0, 1);
            main.Controls.Add(row3, 0, 2);

            // Add to card
            card.Controls.Add(main);

            // Click opens detail form
            void openDetails(object s, EventArgs e)
            {
                var info = (dynamic)card.Tag;
                //OpenDetailForm(info.Name, info.ID, info.Value);
                OpenDetailForm(info.ID, false);
            }

            //lblID.Click += openDetails;
            lblType.Click += openDetails;
            lblName.Click += openDetails;
            lblPrev.Click += openDetails;
            lblTarget.Click += openDetails;
            lblCurrent.Click += openDetails;
            card.Click += openDetails;


            
            // ░░░ ADD ROW 4 SAFELY: PROGRESS CIRCLE ░░░
            // Increase main rows without altering previous 3 rows
            main.RowCount = 4;
            main.RowStyles.Add(new RowStyle(SizeType.Absolute, 85));   // fixed row - prevents overlap

            // container so drawing never spills outside
            Panel progressContainer = new Panel();
            progressContainer.Dock = DockStyle.Fill;
            progressContainer.BackColor = Color.Transparent;

            // the circle itself
            Panel progressPanel = new Panel();
            progressPanel.Size = new Size(70, 70); //circle size
            progressPanel.BackColor = Color.Transparent;
            progressPanel.Anchor = AnchorStyles.None; // center automatically
            progressPanel.Location = new Point(
                (progressContainer.Width - progressPanel.Width) / 2,
                (progressContainer.Height - progressPanel.Height) / 2);

            progressContainer.Resize += (s, e) =>
            {
                progressPanel.Location = new Point(
                    (progressContainer.Width - progressPanel.Width) / 2,
                    (progressContainer.Height - progressPanel.Height) / 2);
            };

            //MessageBox.Show("% = " + spiProgressPercent);
            double Progress_Percent = Convert.ToDouble(spiProgressPercent);// user parameter


            progressPanel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int size = Math.Min(progressPanel.Width, progressPanel.Height) - 10;
                Rectangle rect = new Rectangle(4, 4, size, size);

                // background ring
                using (Pen bg = new Pen(Color.LightGray, 10))
                    e.Graphics.DrawEllipse(bg, rect);

                // percent color red → blue → green
                Color progressColor;

                // 0 → 50  (Red → Blue)
                if (Progress_Percent <= 50)
                {
                    double t = Progress_Percent / 50.0;   // 0 to 1

                    int r = (int)(255 * (1 - t));         // 255 → 0
                    int g = 0;                            // stays 0
                    int b = (int)(255 * t);               // 0 → 255

                    progressColor = Color.FromArgb(r, g, b);
                }
                // 50 → 100 (Blue → Green)
                else
                {
                    double t = (Progress_Percent - 50) / 50.0; // 0 to 1

                    int r = 0;                                // stays 0
                    int g = (int)(255 * t);                   // 0 → 255
                    int b = (int)(255 * (1 - t));             // 255 → 0

                    progressColor = Color.FromArgb(r, g, b);
                }


                // ---- Click opens detail form on circle, text, and inside area ----
                //progressContainer.Click += openDetails;
                //progressPanel.Click += openDetails;

                // Transparent overlay to allow clicking the text area drawn inside the circle
                Label lblProgressClick = new Label();
                lblProgressClick.Dock = DockStyle.Fill;
                lblProgressClick.BackColor = Color.Transparent;
                lblProgressClick.Click += openDetails;

                // Add the overlay label to the circle panel
                progressPanel.Controls.Add(lblProgressClick);

                using (Pen pen = new Pen(progressColor, 8))
                {
                    pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    float sweep = (float)(Progress_Percent * 3.6);
                    e.Graphics.DrawArc(pen, rect, -90, sweep);
                }

                // text inside
                Brush TxtProgressBrush = new SolidBrush(progressColor);
                string txt = Progress_Percent.ToString("0") + "%";
                using (Font f = new Font("Segoe UI", 11, FontStyle.Bold))
                {
                    SizeF t = e.Graphics.MeasureString(txt, f);
                    e.Graphics.DrawString(txt, f,TxtProgressBrush, //Brushes.Black
                        (progressPanel.Width - t.Width) / 2,
                        (progressPanel.Height - t.Height) / 2);
                }
            };

            // add circle into container
            progressContainer.Controls.Add(progressPanel);

            // add container to new row 4
            main.Controls.Add(progressContainer, 0, 3);



            return card;
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

        public static SMS_Project_Package_class.SPI Get_Individual_SPI_Data(string projectFolder,
            string SPI_filename_to_Open)
        {
            string spiFolder = Path.Combine(projectFolder, "SPIs");

            if (!Directory.Exists(spiFolder))
            {
                MessageBox.Show("SPI folder does not exist...");
                return null;
            }

            string filePath = Path.Combine(spiFolder, SPI_filename_to_Open);

            if (!File.Exists(filePath))
            {
                MessageBox.Show("SPI file not found...");
                return null;
            }

            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<SMS_Project_Package_class.SPI>(
                json,
                jsonOptions
            );
        }

        public void CheckOnIfTrue(CheckBox chk, bool IsCheckOn)
        {
            if (IsCheckOn)
                chk.Checked = true;
            else
                chk.Checked = false;
        }


        public void OpenDetailForm(string id, bool IsTemplate)
        {
            FrmHazardMonitoring fhm = new FrmHazardMonitoring();
            //FrmMain fm = new FrmMain();
            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];

            if (fm.TxtProjectLocation.Text == "")
            {
                MessageBox.Show("No valid project loaded...");
                //MessageBox.Show(fm.TxtProjectLocation.Text);
            }
            else
            {
                string project_folder = fm.TxtProjectLocation.Text;
                string thisfilename = "SPI_" + id + ".json";

                var spi = Get_Individual_SPI_Data(project_folder, thisfilename);

                if (spi != null)
                {
                    //Selecting SPIs
                    CheckOnIfTrue(fhm.checkBox1, spi.IsRelatedToObjective);
                    CheckOnIfTrue(fhm.checkBox2, spi.IsBasedOnDateAndMeasurement);
                    CheckOnIfTrue(fhm.checkBox3, spi.IsSpecificQuantifiable);
                    CheckOnIfTrue(fhm.checkBox4, spi.IsRealistic);

                    //SPI info
                    fhm.TxtSPI_ID.Text = spi.SPI_Id;
                    fhm.TxtSPI_Name.Text = spi.SPI_Name;
                    fhm.TxtSPI_Value.Text = spi.SPI_Value_Prev_Obs;
                    fhm.TxtSPI_Value_Target.Text = spi.SPI_Value_Curr_Target;
                    fhm.TxtSPI_Value_Current.Text = spi.SPI_Value_Curr_obs;

                    //Defining SPIs
                    fhm.TxtSPI_Type.Text = spi.SPI_Type;
                    fhm.TxtSPI_Description.Text = spi.SPI_Des;
                    fhm.Txt_SPI_Manage.Text = spi.SPI_Manage;
                    fhm.TxtSPI_Inform.Text = spi.SPI_Inform;
                    fhm.Txt_SPI_Unit.Text = spi.SPI_Unit;
                    fhm.TxtSPI_Calc.Text = spi.SPI_Calc;

                    //SPIs data
                    for (int i = 0; i < 13; i++)
                    {
                        
                        //MessageBox.Show("dgv " + i + " : " + spi.PrevYearObserved[i]);
                        fhm.dataGridView1.Rows[0].Cells[i + 2].Value = spi.PrevYearObserved[i].ToString();
                        fhm.dataGridView1.Rows[1].Cells[i + 2].Value = spi.CurrYearTargetPercent[i];
                        fhm.dataGridView1.Rows[2].Cells[i + 2].Value = spi.CurrYearTargetValue[i];
                        fhm.dataGridView1.Rows[3].Cells[i + 2].Value = spi.CurrYearObserved[i];
                    }

                    fhm.PlotGraph();
                    fhm.createNewSPIToolStripMenuItem.Enabled = false;
                    fhm.importTemplateSPIToolStripMenuItem.Enabled = false;
                
                }

            }
            if(IsTemplate == false)
            {
                fhm.ShowDialog();
            }
            
        }



        public void CopyAlltoClipboard(DataGridView dataGridView1)
        {
            //required when exporting to all to excel
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        public void CopySelectedtoClipboard(DataGridView dataGridView1)
        {
            //dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridView1.MultiSelect = true;
            //datagridview1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        public void PasteClipboardToDatagridview(DataGridView dgv)
        {
            if (dgv.SelectedCells.Count == 0) return;

            // Find top-left selected cell (Excel behavior)
            int startRow = dgv.SelectedCells.Cast<DataGridViewCell>().Min(c => c.RowIndex);
            int startCol = dgv.SelectedCells.Cast<DataGridViewCell>().Min(c => c.ColumnIndex);

            string clipboardText = Clipboard.GetText();
            if (string.IsNullOrWhiteSpace(clipboardText)) return;

            // IMPORTANT: Remove empty trailing lines
            string[] lines = clipboardText
                .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            int row = startRow;

            foreach (string line in lines)
            {
                if (row >= dgv.Rows.Count || dgv.Rows[row].IsNewRow)
                    break;

                string[] values = line.Split('\t');
                int col = startCol;

                foreach (string value in values)
                {
                    if (col >= dgv.Columns.Count)
                        break;

                    dgv.Rows[row].Cells[col].Value = value;
                    col++;
                }

                row++;
            }
        }


        /*public void PasteClipboardToDatagridview(DataGridView dataGridView1)
        {
            if (dataGridView1.SelectedCells.Count < 1) return;

            string[] lines;

            int row = dataGridView1.SelectedCells[0].RowIndex;
            int col = dataGridView1.SelectedCells[0].ColumnIndex;

            //get copied values
            lines = Clipboard.GetText().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            string[] values;
            for (int i = 0; i < lines.Length; i++)
            {
                values = lines[i].Split('\t');

                if (row >= dataGridView1.Rows.Count || dataGridView1.Rows[row].IsNewRow) continue;
                //if (row >= dataGridView1.Rows.Count || dataGridView1.Rows[row].IsNewRow) dataGridView1.Rows.Add();
                for (int j = 0; j < values.Length; j++)
                {
                    if (col + j >= dataGridView1.Columns.Count) continue;
                    dataGridView1.Rows[row].Cells[col + j].Value = values[j];
                }

                row++;
            }


        }*/






    }
}
