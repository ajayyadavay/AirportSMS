using System;
using System.Drawing;
using System.Windows.Forms;

namespace AirportSMS
{
    public class ResolutionDialog : Form
    {
        public int WidthValue { get; private set; }
        public int HeightValue { get; private set; }

        private TextBox txtWidth;
        private TextBox txtHeight;
        private Button btnOK;
        private Button btnCancel;

        public ResolutionDialog(int defaultWidth = 1330, int defaultHeight = 490)
        {
            this.Text = "Enter Plot Resolution";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(300, 180);
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Labels
            Label lblWidth = new Label() { Text = "Width (px):", Location = new Point(20, 20), AutoSize = true };
            Label lblHeight = new Label() { Text = "Height (px):", Location = new Point(20, 60), AutoSize = true };

            // Textboxes
            txtWidth = new TextBox() { Location = new Point(120, 18), Width = 120, Text = defaultWidth.ToString() };
            txtHeight = new TextBox() { Location = new Point(120, 58), Width = 120, Text = defaultHeight.ToString() };

            // Buttons
            btnOK = new Button() { Text = "OK", Location = new Point(50, 100), DialogResult = DialogResult.OK };
            btnCancel = new Button() { Text = "Cancel", Location = new Point(150, 100), DialogResult = DialogResult.Cancel };

            // Add controls to form
            this.Controls.AddRange(new Control[] { lblWidth, lblHeight, txtWidth, txtHeight, btnOK, btnCancel });

            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (!int.TryParse(txtWidth.Text, out int w) || w <= 0)
                {
                    MessageBox.Show("Invalid width. Enter a positive integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
                if (!int.TryParse(txtHeight.Text, out int h) || h <= 0)
                {
                    MessageBox.Show("Invalid height. Enter a positive integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
                WidthValue = w;
                HeightValue = h;
            }
            base.OnClosing(e);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ResolutionDialog
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "ResolutionDialog";
            this.ResumeLayout(false);

        }
    }
}

