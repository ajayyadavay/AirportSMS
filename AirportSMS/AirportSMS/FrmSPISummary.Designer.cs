namespace AirportSMS
{
    partial class FrmSPISummary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGV_SPI_Summary = new System.Windows.Forms.DataGridView();
            this.ColSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSPIs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSPIsType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSPIsProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSPIsTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelPlotSPISummary = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SPI_Summary)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV_SPI_Summary
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_SPI_Summary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_SPI_Summary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_SPI_Summary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSN,
            this.ColSPIs,
            this.ColSPIsType,
            this.ColSPIsProgress,
            this.ColSPIsTotal});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SPI_Summary.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGV_SPI_Summary.Location = new System.Drawing.Point(12, 77);
            this.DGV_SPI_Summary.Name = "DGV_SPI_Summary";
            this.DGV_SPI_Summary.Size = new System.Drawing.Size(854, 580);
            this.DGV_SPI_Summary.TabIndex = 0;
            // 
            // ColSN
            // 
            this.ColSN.HeaderText = "SN";
            this.ColSN.Name = "ColSN";
            this.ColSN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColSPIs
            // 
            this.ColSPIs.HeaderText = "SPIs";
            this.ColSPIs.Name = "ColSPIs";
            this.ColSPIs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColSPIs.Width = 250;
            // 
            // ColSPIsType
            // 
            this.ColSPIsType.HeaderText = "SPIs Type";
            this.ColSPIsType.Name = "ColSPIsType";
            this.ColSPIsType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColSPIsType.Width = 250;
            // 
            // ColSPIsProgress
            // 
            this.ColSPIsProgress.HeaderText = "SPIs Progress";
            this.ColSPIsProgress.Name = "ColSPIsProgress";
            this.ColSPIsProgress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColSPIsTotal
            // 
            this.ColSPIsTotal.HeaderText = "SPIs Total";
            this.ColSPIsTotal.Name = "ColSPIsTotal";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(881, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plotToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // plotToolStripMenuItem
            // 
            this.plotToolStripMenuItem.Name = "plotToolStripMenuItem";
            this.plotToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.plotToolStripMenuItem.Text = "Plot";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // PanelPlotSPISummary
            // 
            this.PanelPlotSPISummary.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PanelPlotSPISummary.Location = new System.Drawing.Point(20, 671);
            this.PanelPlotSPISummary.Name = "PanelPlotSPISummary";
            this.PanelPlotSPISummary.Size = new System.Drawing.Size(846, 450);
            this.PanelPlotSPISummary.TabIndex = 2;
            // 
            // FrmSPISummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(898, 749);
            this.Controls.Add(this.PanelPlotSPISummary);
            this.Controls.Add(this.DGV_SPI_Summary);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmSPISummary";
            this.Text = "SMS - SPI Summary";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SPI_Summary)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_SPI_Summary;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSPIs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSPIsType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSPIsProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSPIsTotal;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plotToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel PanelPlotSPISummary;
    }
}