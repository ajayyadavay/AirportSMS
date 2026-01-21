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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedRowsToDocxAsIndividualFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedRowsToDocxAsMergedFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardWithBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardWithoutBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DGV_ALL_SPIs_GridMode = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtSPISummaryCurrYear = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnSelectedMonthView = new System.Windows.Forms.Button();
            this.TxtSelectedMonth = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnDefault = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtNoOfFilteredData = new System.Windows.Forms.TextBox();
            this.BtnClearFilterAll = new System.Windows.Forms.Button();
            this.BtnDescendingAll = new System.Windows.Forms.Button();
            this.BtnAscendingAll = new System.Windows.Forms.Button();
            this.BtnFilterAll = new System.Windows.Forms.Button();
            this.ComboBoxFilterValueALL = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ComboBoxSummaryAllColName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ALL_SPIs_GridMode)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1370, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
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
            // DGV_ALL_SPIs_GridMode
            // 
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_ALL_SPIs_GridMode.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            this.DGV_ALL_SPIs_GridMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_ALL_SPIs_GridMode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.DGV_ALL_SPIs_GridMode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_ALL_SPIs_GridMode.DefaultCellStyle = dataGridViewCellStyle24;
            this.DGV_ALL_SPIs_GridMode.Location = new System.Drawing.Point(13, 70);
            this.DGV_ALL_SPIs_GridMode.Name = "DGV_ALL_SPIs_GridMode";
            this.DGV_ALL_SPIs_GridMode.Size = new System.Drawing.Size(1345, 380);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.BtnSelectedMonthView);
            this.groupBox2.Controls.Add(this.TxtSelectedMonth);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1021, 468);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 196);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Month to view";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(6, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(273, 80);
            this.label9.TabIndex = 25;
            this.label9.Text = "Enter month index to view those months only\r\nFor JAN, enter 1, FEB=2, DEC=12.\r\nIn" +
    "put format: For Single month: 2; \r\nFor range month: 3-8; For other months: 3,8,1" +
    "2\r\nLeave empty to show whole months";
            // 
            // BtnSelectedMonthView
            // 
            this.BtnSelectedMonthView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnSelectedMonthView.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnSelectedMonthView.FlatAppearance.BorderSize = 0;
            this.BtnSelectedMonthView.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnSelectedMonthView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnSelectedMonthView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelectedMonthView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSelectedMonthView.ForeColor = System.Drawing.Color.White;
            this.BtnSelectedMonthView.Location = new System.Drawing.Point(7, 147);
            this.BtnSelectedMonthView.Name = "BtnSelectedMonthView";
            this.BtnSelectedMonthView.Size = new System.Drawing.Size(281, 35);
            this.BtnSelectedMonthView.TabIndex = 24;
            this.BtnSelectedMonthView.Text = "View Selected Month";
            this.BtnSelectedMonthView.UseVisualStyleBackColor = false;
            this.BtnSelectedMonthView.Click += new System.EventHandler(this.BtnSelectedMonthView_Click);
            // 
            // TxtSelectedMonth
            // 
            this.TxtSelectedMonth.Location = new System.Drawing.Point(6, 30);
            this.TxtSelectedMonth.Name = "TxtSelectedMonth";
            this.TxtSelectedMonth.Size = new System.Drawing.Size(273, 24);
            this.TxtSelectedMonth.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnDefault);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.TxtNoOfFilteredData);
            this.groupBox1.Controls.Add(this.BtnClearFilterAll);
            this.groupBox1.Controls.Add(this.BtnDescendingAll);
            this.groupBox1.Controls.Add(this.BtnAscendingAll);
            this.groupBox1.Controls.Add(this.BtnFilterAll);
            this.groupBox1.Controls.Add(this.ComboBoxFilterValueALL);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ComboBoxSummaryAllColName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 468);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(966, 196);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter and Sort";
            // 
            // BtnDefault
            // 
            this.BtnDefault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnDefault.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnDefault.FlatAppearance.BorderSize = 0;
            this.BtnDefault.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnDefault.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDefault.ForeColor = System.Drawing.Color.White;
            this.BtnDefault.Location = new System.Drawing.Point(257, 96);
            this.BtnDefault.Name = "BtnDefault";
            this.BtnDefault.Size = new System.Drawing.Size(91, 35);
            this.BtnDefault.TabIndex = 23;
            this.BtnDefault.Text = "Default";
            this.BtnDefault.UseVisualStyleBackColor = false;
            this.BtnDefault.Click += new System.EventHandler(this.BtnDefault_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(755, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 18);
            this.label8.TabIndex = 22;
            this.label8.Text = "No. of filtered rows";
            // 
            // TxtNoOfFilteredData
            // 
            this.TxtNoOfFilteredData.Location = new System.Drawing.Point(758, 96);
            this.TxtNoOfFilteredData.Name = "TxtNoOfFilteredData";
            this.TxtNoOfFilteredData.Size = new System.Drawing.Size(187, 24);
            this.TxtNoOfFilteredData.TabIndex = 21;
            // 
            // BtnClearFilterAll
            // 
            this.BtnClearFilterAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnClearFilterAll.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnClearFilterAll.FlatAppearance.BorderSize = 0;
            this.BtnClearFilterAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnClearFilterAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnClearFilterAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClearFilterAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClearFilterAll.ForeColor = System.Drawing.Color.White;
            this.BtnClearFilterAll.Location = new System.Drawing.Point(593, 96);
            this.BtnClearFilterAll.Name = "BtnClearFilterAll";
            this.BtnClearFilterAll.Size = new System.Drawing.Size(140, 35);
            this.BtnClearFilterAll.TabIndex = 20;
            this.BtnClearFilterAll.Text = "Clear Filter";
            this.BtnClearFilterAll.UseVisualStyleBackColor = false;
            this.BtnClearFilterAll.Click += new System.EventHandler(this.BtnClearFilterAll_Click);
            // 
            // BtnDescendingAll
            // 
            this.BtnDescendingAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnDescendingAll.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnDescendingAll.FlatAppearance.BorderSize = 0;
            this.BtnDescendingAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnDescendingAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnDescendingAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDescendingAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDescendingAll.ForeColor = System.Drawing.Color.White;
            this.BtnDescendingAll.Location = new System.Drawing.Point(142, 96);
            this.BtnDescendingAll.Name = "BtnDescendingAll";
            this.BtnDescendingAll.Size = new System.Drawing.Size(109, 35);
            this.BtnDescendingAll.TabIndex = 19;
            this.BtnDescendingAll.Text = "Descending";
            this.BtnDescendingAll.UseVisualStyleBackColor = false;
            this.BtnDescendingAll.Click += new System.EventHandler(this.BtnDescendingAll_Click);
            // 
            // BtnAscendingAll
            // 
            this.BtnAscendingAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnAscendingAll.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnAscendingAll.FlatAppearance.BorderSize = 0;
            this.BtnAscendingAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnAscendingAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnAscendingAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAscendingAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAscendingAll.ForeColor = System.Drawing.Color.White;
            this.BtnAscendingAll.Location = new System.Drawing.Point(10, 96);
            this.BtnAscendingAll.Name = "BtnAscendingAll";
            this.BtnAscendingAll.Size = new System.Drawing.Size(126, 35);
            this.BtnAscendingAll.TabIndex = 18;
            this.BtnAscendingAll.Text = "Ascending";
            this.BtnAscendingAll.UseVisualStyleBackColor = false;
            this.BtnAscendingAll.Click += new System.EventHandler(this.BtnAscendingAll_Click);
            // 
            // BtnFilterAll
            // 
            this.BtnFilterAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnFilterAll.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnFilterAll.FlatAppearance.BorderSize = 0;
            this.BtnFilterAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnFilterAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnFilterAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFilterAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFilterAll.ForeColor = System.Drawing.Color.White;
            this.BtnFilterAll.Location = new System.Drawing.Point(382, 96);
            this.BtnFilterAll.Name = "BtnFilterAll";
            this.BtnFilterAll.Size = new System.Drawing.Size(205, 35);
            this.BtnFilterAll.TabIndex = 17;
            this.BtnFilterAll.Text = "Filter";
            this.BtnFilterAll.UseVisualStyleBackColor = false;
            this.BtnFilterAll.Click += new System.EventHandler(this.BtnFilterAll_Click);
            // 
            // ComboBoxFilterValueALL
            // 
            this.ComboBoxFilterValueALL.FormattingEnabled = true;
            this.ComboBoxFilterValueALL.Location = new System.Drawing.Point(382, 41);
            this.ComboBoxFilterValueALL.Name = "ComboBoxFilterValueALL";
            this.ComboBoxFilterValueALL.Size = new System.Drawing.Size(351, 26);
            this.ComboBoxFilterValueALL.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(379, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 18);
            this.label7.TabIndex = 2;
            this.label7.Text = "Column Value to filter";
            // 
            // ComboBoxSummaryAllColName
            // 
            this.ComboBoxSummaryAllColName.FormattingEnabled = true;
            this.ComboBoxSummaryAllColName.Location = new System.Drawing.Point(6, 43);
            this.ComboBoxSummaryAllColName.Name = "ComboBoxSummaryAllColName";
            this.ComboBoxSummaryAllColName.Size = new System.Drawing.Size(342, 26);
            this.ComboBoxSummaryAllColName.TabIndex = 1;
            this.ComboBoxSummaryAllColName.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSummaryAllColName_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Column Name";
            // 
            // FrmSPIsGridMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnSelectedMonthView;
        private System.Windows.Forms.TextBox TxtSelectedMonth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnDefault;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtNoOfFilteredData;
        private System.Windows.Forms.Button BtnClearFilterAll;
        private System.Windows.Forms.Button BtnDescendingAll;
        private System.Windows.Forms.Button BtnAscendingAll;
        private System.Windows.Forms.Button BtnFilterAll;
        private System.Windows.Forms.ComboBox ComboBoxFilterValueALL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ComboBoxSummaryAllColName;
        private System.Windows.Forms.Label label6;
    }
}