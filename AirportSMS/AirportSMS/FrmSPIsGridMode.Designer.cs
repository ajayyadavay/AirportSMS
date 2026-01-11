namespace AirportSMS
{
    partial class FrmSPIsGridMode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSPIsInGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedRowsToDocxAsIndividualFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedRowsToDocxAsMergedFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DGV_ALL_SPIs_GridMode = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtSPISummaryCurrYear = new System.Windows.Forms.TextBox();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardWithBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardWithoutBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ALL_SPIs_GridMode)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.settingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(961, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewSPIsInGridToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // viewSPIsInGridToolStripMenuItem
            // 
            this.viewSPIsInGridToolStripMenuItem.Name = "viewSPIsInGridToolStripMenuItem";
            this.viewSPIsInGridToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.viewSPIsInGridToolStripMenuItem.Text = "View SPIs in Grid";
            this.viewSPIsInGridToolStripMenuItem.Click += new System.EventHandler(this.viewSPIsInGridToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(185, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectedRowsToDocxAsIndividualFileToolStripMenuItem,
            this.selectedRowsToDocxAsMergedFileToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // selectedRowsToDocxAsIndividualFileToolStripMenuItem
            // 
            this.selectedRowsToDocxAsIndividualFileToolStripMenuItem.Name = "selectedRowsToDocxAsIndividualFileToolStripMenuItem";
            this.selectedRowsToDocxAsIndividualFileToolStripMenuItem.Size = new System.Drawing.Size(336, 24);
            this.selectedRowsToDocxAsIndividualFileToolStripMenuItem.Text = "Selected rows to docx as individual file";
            this.selectedRowsToDocxAsIndividualFileToolStripMenuItem.Click += new System.EventHandler(this.selectedRowsToDocxAsIndividualFileToolStripMenuItem_Click);
            // 
            // selectedRowsToDocxAsMergedFileToolStripMenuItem
            // 
            this.selectedRowsToDocxAsMergedFileToolStripMenuItem.Name = "selectedRowsToDocxAsMergedFileToolStripMenuItem";
            this.selectedRowsToDocxAsMergedFileToolStripMenuItem.Size = new System.Drawing.Size(336, 24);
            this.selectedRowsToDocxAsMergedFileToolStripMenuItem.Text = "Selected rows to docx as merged file";
            this.selectedRowsToDocxAsMergedFileToolStripMenuItem.Click += new System.EventHandler(this.selectedRowsToDocxAsMergedFileToolStripMenuItem_Click);
            // 
            // DGV_ALL_SPIs_GridMode
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_ALL_SPIs_GridMode.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DGV_ALL_SPIs_GridMode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_ALL_SPIs_GridMode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DGV_ALL_SPIs_GridMode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_ALL_SPIs_GridMode.DefaultCellStyle = dataGridViewCellStyle12;
            this.DGV_ALL_SPIs_GridMode.Location = new System.Drawing.Point(13, 70);
            this.DGV_ALL_SPIs_GridMode.Name = "DGV_ALL_SPIs_GridMode";
            this.DGV_ALL_SPIs_GridMode.Size = new System.Drawing.Size(936, 331);
            this.DGV_ALL_SPIs_GridMode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current Year";
            // 
            // TxtSPISummaryCurrYear
            // 
            this.TxtSPISummaryCurrYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSPISummaryCurrYear.Location = new System.Drawing.Point(120, 44);
            this.TxtSPISummaryCurrYear.Name = "TxtSPISummaryCurrYear";
            this.TxtSPISummaryCurrYear.ReadOnly = true;
            this.TxtSPISummaryCurrYear.Size = new System.Drawing.Size(142, 24);
            this.TxtSPISummaryCurrYear.TabIndex = 3;
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardWithBackgroundToolStripMenuItem,
            this.dashboardWithoutBackgroundToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // dashboardWithBackgroundToolStripMenuItem
            // 
            this.dashboardWithBackgroundToolStripMenuItem.Checked = true;
            this.dashboardWithBackgroundToolStripMenuItem.CheckOnClick = true;
            this.dashboardWithBackgroundToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dashboardWithBackgroundToolStripMenuItem.Name = "dashboardWithBackgroundToolStripMenuItem";
            this.dashboardWithBackgroundToolStripMenuItem.Size = new System.Drawing.Size(288, 24);
            this.dashboardWithBackgroundToolStripMenuItem.Text = "Dashboard with Background";
            this.dashboardWithBackgroundToolStripMenuItem.Click += new System.EventHandler(this.dashboardWithBackgroundToolStripMenuItem_Click);
            // 
            // dashboardWithoutBackgroundToolStripMenuItem
            // 
            this.dashboardWithoutBackgroundToolStripMenuItem.CheckOnClick = true;
            this.dashboardWithoutBackgroundToolStripMenuItem.Name = "dashboardWithoutBackgroundToolStripMenuItem";
            this.dashboardWithoutBackgroundToolStripMenuItem.Size = new System.Drawing.Size(288, 24);
            this.dashboardWithoutBackgroundToolStripMenuItem.Text = "Dashboard without Background";
            this.dashboardWithoutBackgroundToolStripMenuItem.Click += new System.EventHandler(this.dashboardWithoutBackgroundToolStripMenuItem_Click);
            // 
            // FrmSPIsGridMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 450);
            this.Controls.Add(this.TxtSPISummaryCurrYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGV_ALL_SPIs_GridMode);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmSPIsGridMode";
            this.Text = "SPIs Grid Mode";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSPIsGridMode_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ALL_SPIs_GridMode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewSPIsInGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView DGV_ALL_SPIs_GridMode;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedRowsToDocxAsIndividualFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedRowsToDocxAsMergedFileToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtSPISummaryCurrYear;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardWithBackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardWithoutBackgroundToolStripMenuItem;
    }
}