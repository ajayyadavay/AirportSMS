using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirportSMS
{
    internal class AirportSMS_Class
    {
        public Panel CreateSPICard(FlowLayoutPanel flowLayoutPanel1,
                           string spiName, string spiID, string spiValue)
        {
            Panel card = new Panel();
            card.Width = 250;
            card.Height = 150;
            card.Margin = new Padding(12);
            card.Padding = new Padding(10);
            card.BackColor = Color.White;
            card.Cursor = Cursors.Hand;

            card.Tag = new { Name = spiName, ID = spiID, Value = spiValue };

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
                }
            };

            row1.Controls.Add(lblID, 0, 0);
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
            lblPrev.Text = "Prev:\n" + spiValue;
            lblPrev.Font = new Font("Segoe UI", 9);
            lblPrev.ForeColor = Color.FromArgb(0, 90, 158);
            lblPrev.AutoSize = true;
            lblPrev.Dock = DockStyle.Fill;

            Label lblTarget = new Label();
            lblTarget.Text = "Target:\n—";
            lblTarget.Font = new Font("Segoe UI", 9);
            lblTarget.ForeColor = Color.Green;
            lblTarget.AutoSize = true;
            lblTarget.Dock = DockStyle.Fill;

            Label lblCurrent = new Label();
            lblCurrent.Text = "Obs:\n—";
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
                OpenDetailForm(info.Name, info.ID, info.Value);
            }

            //open form with full details of SPIs
            void OpenSPIFormDetails(string projectFolder)
            {
                // 2. Load SPI metadata (filename, name, id)
                var spiList = Load_Individual_SPI_Data(projectFolder);

                //listSPIs.Items.Clear();
                

            }

            lblID.Click += openDetails;
            lblName.Click += openDetails;
            lblPrev.Click += openDetails;
            lblTarget.Click += openDetails;
            lblCurrent.Click += openDetails;
            card.Click += openDetails;

            return card;
        }




        public void OpenDetailForm(string name, string id, string value)
        {
            FrmHazardMonitoring fhm = new FrmHazardMonitoring();
            fhm.TxtSPI_Name.Text = name;
            fhm.TxtSPI_ID.Text = id;
            fhm.TxtSPI_Value.Text = value;

            fhm.ShowDialog();
        }









    }
}
