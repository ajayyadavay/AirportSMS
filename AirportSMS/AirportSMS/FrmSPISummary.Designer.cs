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
            this.DGV_SPI_Summary = new System.Windows.Forms.DataGridView();
            this.ColSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSPIs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSPIsType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSPIsProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSPIsTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortSummaryTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelPlotSPISummary = new System.Windows.Forms.Panel();
            this.ComboBoxSort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RadioAscending = new System.Windows.Forms.RadioButton();
            this.RadioDescending = new System.Windows.Forms.RadioButton();
            this.RadioDefault = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabSummarySPIs = new System.Windows.Forms.TabPage();
            this.TabDetailedSummary = new System.Windows.Forms.TabPage();
            this.DGV_SPI_Summary_ALL = new System.Windows.Forms.DataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColJan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFeb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColApr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColJun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColJul = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAug = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabMonthwise = new System.Windows.Forms.TabPage();
            this.BtnMnthAscend = new System.Windows.Forms.Button();
            this.PanelPlotMonth = new System.Windows.Forms.Panel();
            this.DGV_Summary_Monthly = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMonthTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnMnthDescend = new System.Windows.Forms.Button();
            this.BtnMnthDefault = new System.Windows.Forms.Button();
            this.BtnSortSummarySPI = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SPI_Summary)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabSummarySPIs.SuspendLayout();
            this.TabDetailedSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SPI_Summary_ALL)).BeginInit();
            this.TabMonthwise.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Summary_Monthly)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_SPI_Summary
            // 
            this.DGV_SPI_Summary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_SPI_Summary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSN,
            this.ColSPIs,
            this.ColSPIsType,
            this.ColSPIsProgress,
            this.ColSPIsTotal});
            this.DGV_SPI_Summary.Location = new System.Drawing.Point(18, 52);
            this.DGV_SPI_Summary.Name = "DGV_SPI_Summary";
            this.DGV_SPI_Summary.Size = new System.Drawing.Size(885, 487);
            this.DGV_SPI_Summary.TabIndex = 0;
            // 
            // ColSN
            // 
            this.ColSN.HeaderText = "SN";
            this.ColSN.Name = "ColSN";
            this.ColSN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            this.ColSPIsProgress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ColSPIsTotal
            // 
            this.ColSPIsTotal.HeaderText = "SPIs Total";
            this.ColSPIsTotal.Name = "ColSPIsTotal";
            this.ColSPIsTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1353, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortSummaryTableToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // sortSummaryTableToolStripMenuItem
            // 
            this.sortSummaryTableToolStripMenuItem.Name = "sortSummaryTableToolStripMenuItem";
            this.sortSummaryTableToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.sortSummaryTableToolStripMenuItem.Text = "Sort Summary Table";
            this.sortSummaryTableToolStripMenuItem.Click += new System.EventHandler(this.sortSummaryTableToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // PanelPlotSPISummary
            // 
            this.PanelPlotSPISummary.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PanelPlotSPISummary.Location = new System.Drawing.Point(18, 545);
            this.PanelPlotSPISummary.Name = "PanelPlotSPISummary";
            this.PanelPlotSPISummary.Size = new System.Drawing.Size(854, 569);
            this.PanelPlotSPISummary.TabIndex = 2;
            // 
            // ComboBoxSort
            // 
            this.ComboBoxSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxSort.FormattingEnabled = true;
            this.ComboBoxSort.Location = new System.Drawing.Point(170, 19);
            this.ComboBoxSort.Name = "ComboBoxSort";
            this.ComboBoxSort.Size = new System.Drawing.Size(212, 26);
            this.ComboBoxSort.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select column to sort";
            // 
            // RadioAscending
            // 
            this.RadioAscending.AutoSize = true;
            this.RadioAscending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioAscending.Location = new System.Drawing.Point(399, 22);
            this.RadioAscending.Name = "RadioAscending";
            this.RadioAscending.Size = new System.Drawing.Size(126, 20);
            this.RadioAscending.TabIndex = 5;
            this.RadioAscending.Text = "Ascending Order";
            this.RadioAscending.UseVisualStyleBackColor = true;
            // 
            // RadioDescending
            // 
            this.RadioDescending.AutoSize = true;
            this.RadioDescending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioDescending.Location = new System.Drawing.Point(540, 22);
            this.RadioDescending.Name = "RadioDescending";
            this.RadioDescending.Size = new System.Drawing.Size(135, 20);
            this.RadioDescending.TabIndex = 6;
            this.RadioDescending.Text = "Descending Order";
            this.RadioDescending.UseVisualStyleBackColor = true;
            // 
            // RadioDefault
            // 
            this.RadioDefault.AutoSize = true;
            this.RadioDefault.Checked = true;
            this.RadioDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioDefault.Location = new System.Drawing.Point(693, 22);
            this.RadioDefault.Name = "RadioDefault";
            this.RadioDefault.Size = new System.Drawing.Size(67, 20);
            this.RadioDefault.TabIndex = 7;
            this.RadioDefault.TabStop = true;
            this.RadioDefault.Text = "Default";
            this.RadioDefault.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabSummarySPIs);
            this.tabControl1.Controls.Add(this.TabDetailedSummary);
            this.tabControl1.Controls.Add(this.TabMonthwise);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1329, 1200);
            this.tabControl1.TabIndex = 8;
            // 
            // TabSummarySPIs
            // 
            this.TabSummarySPIs.Controls.Add(this.BtnSortSummarySPI);
            this.TabSummarySPIs.Controls.Add(this.RadioDefault);
            this.TabSummarySPIs.Controls.Add(this.DGV_SPI_Summary);
            this.TabSummarySPIs.Controls.Add(this.RadioDescending);
            this.TabSummarySPIs.Controls.Add(this.PanelPlotSPISummary);
            this.TabSummarySPIs.Controls.Add(this.RadioAscending);
            this.TabSummarySPIs.Controls.Add(this.label1);
            this.TabSummarySPIs.Controls.Add(this.ComboBoxSort);
            this.TabSummarySPIs.Location = new System.Drawing.Point(4, 25);
            this.TabSummarySPIs.Name = "TabSummarySPIs";
            this.TabSummarySPIs.Padding = new System.Windows.Forms.Padding(3);
            this.TabSummarySPIs.Size = new System.Drawing.Size(1321, 1171);
            this.TabSummarySPIs.TabIndex = 0;
            this.TabSummarySPIs.Text = "Summary - SPIs";
            this.TabSummarySPIs.UseVisualStyleBackColor = true;
            // 
            // TabDetailedSummary
            // 
            this.TabDetailedSummary.Controls.Add(this.DGV_SPI_Summary_ALL);
            this.TabDetailedSummary.Location = new System.Drawing.Point(4, 25);
            this.TabDetailedSummary.Name = "TabDetailedSummary";
            this.TabDetailedSummary.Padding = new System.Windows.Forms.Padding(3);
            this.TabDetailedSummary.Size = new System.Drawing.Size(1321, 1171);
            this.TabDetailedSummary.TabIndex = 1;
            this.TabDetailedSummary.Text = "Detailed Summary - SPIs";
            this.TabDetailedSummary.UseVisualStyleBackColor = true;
            // 
            // DGV_SPI_Summary_ALL
            // 
            this.DGV_SPI_Summary_ALL.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGV_SPI_Summary_ALL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_SPI_Summary_ALL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColName,
            this.ColJan,
            this.ColFeb,
            this.ColMar,
            this.ColApr,
            this.ColMay,
            this.ColJun,
            this.ColJul,
            this.ColAug,
            this.ColSep,
            this.ColOct,
            this.ColNov,
            this.ColDec,
            this.ColTotal});
            this.DGV_SPI_Summary_ALL.Location = new System.Drawing.Point(6, 54);
            this.DGV_SPI_Summary_ALL.Name = "DGV_SPI_Summary_ALL";
            this.DGV_SPI_Summary_ALL.Size = new System.Drawing.Size(1273, 436);
            this.DGV_SPI_Summary_ALL.TabIndex = 5;
            // 
            // ColID
            // 
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColID.Width = 40;
            // 
            // ColName
            // 
            this.ColName.HeaderText = "Name";
            this.ColName.Name = "ColName";
            this.ColName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColName.Width = 190;
            // 
            // ColJan
            // 
            this.ColJan.HeaderText = "Jan";
            this.ColJan.Name = "ColJan";
            this.ColJan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColJan.Width = 75;
            // 
            // ColFeb
            // 
            this.ColFeb.HeaderText = "Feb";
            this.ColFeb.Name = "ColFeb";
            this.ColFeb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColFeb.Width = 75;
            // 
            // ColMar
            // 
            this.ColMar.HeaderText = "Mar";
            this.ColMar.Name = "ColMar";
            this.ColMar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColMar.Width = 75;
            // 
            // ColApr
            // 
            this.ColApr.HeaderText = "Apr";
            this.ColApr.Name = "ColApr";
            this.ColApr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColApr.Width = 75;
            // 
            // ColMay
            // 
            this.ColMay.HeaderText = "May";
            this.ColMay.Name = "ColMay";
            this.ColMay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColMay.Width = 75;
            // 
            // ColJun
            // 
            this.ColJun.HeaderText = "Jun";
            this.ColJun.Name = "ColJun";
            this.ColJun.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColJun.Width = 75;
            // 
            // ColJul
            // 
            this.ColJul.HeaderText = "Jul";
            this.ColJul.Name = "ColJul";
            this.ColJul.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColJul.Width = 75;
            // 
            // ColAug
            // 
            this.ColAug.HeaderText = "Aug";
            this.ColAug.Name = "ColAug";
            this.ColAug.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColAug.Width = 75;
            // 
            // ColSep
            // 
            this.ColSep.HeaderText = "Sep";
            this.ColSep.Name = "ColSep";
            this.ColSep.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColSep.Width = 75;
            // 
            // ColOct
            // 
            this.ColOct.HeaderText = "Oct";
            this.ColOct.Name = "ColOct";
            this.ColOct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColOct.Width = 75;
            // 
            // ColNov
            // 
            this.ColNov.HeaderText = "Nov";
            this.ColNov.Name = "ColNov";
            this.ColNov.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColNov.Width = 75;
            // 
            // ColDec
            // 
            this.ColDec.HeaderText = "Dec";
            this.ColDec.Name = "ColDec";
            this.ColDec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColDec.Width = 75;
            // 
            // ColTotal
            // 
            this.ColTotal.HeaderText = "Total";
            this.ColTotal.Name = "ColTotal";
            this.ColTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColTotal.Width = 80;
            // 
            // TabMonthwise
            // 
            this.TabMonthwise.Controls.Add(this.BtnMnthDefault);
            this.TabMonthwise.Controls.Add(this.BtnMnthDescend);
            this.TabMonthwise.Controls.Add(this.BtnMnthAscend);
            this.TabMonthwise.Controls.Add(this.PanelPlotMonth);
            this.TabMonthwise.Controls.Add(this.DGV_Summary_Monthly);
            this.TabMonthwise.Location = new System.Drawing.Point(4, 25);
            this.TabMonthwise.Name = "TabMonthwise";
            this.TabMonthwise.Size = new System.Drawing.Size(1321, 1171);
            this.TabMonthwise.TabIndex = 2;
            this.TabMonthwise.Text = "Summary Monthwise - SPIs";
            this.TabMonthwise.UseVisualStyleBackColor = true;
            // 
            // BtnMnthAscend
            // 
            this.BtnMnthAscend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnMnthAscend.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnMnthAscend.FlatAppearance.BorderSize = 0;
            this.BtnMnthAscend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnMnthAscend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnMnthAscend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMnthAscend.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMnthAscend.ForeColor = System.Drawing.Color.White;
            this.BtnMnthAscend.Location = new System.Drawing.Point(35, 43);
            this.BtnMnthAscend.Name = "BtnMnthAscend";
            this.BtnMnthAscend.Size = new System.Drawing.Size(109, 35);
            this.BtnMnthAscend.TabIndex = 11;
            this.BtnMnthAscend.Text = "Ascending";
            this.BtnMnthAscend.UseVisualStyleBackColor = false;
            this.BtnMnthAscend.Click += new System.EventHandler(this.BtnMnthAscend_Click);
            // 
            // PanelPlotMonth
            // 
            this.PanelPlotMonth.BackColor = System.Drawing.Color.Gray;
            this.PanelPlotMonth.Location = new System.Drawing.Point(458, 93);
            this.PanelPlotMonth.Name = "PanelPlotMonth";
            this.PanelPlotMonth.Size = new System.Drawing.Size(847, 487);
            this.PanelPlotMonth.TabIndex = 10;
            // 
            // DGV_Summary_Monthly
            // 
            this.DGV_Summary_Monthly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Summary_Monthly.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.ColMonth,
            this.ColMonthTotal});
            this.DGV_Summary_Monthly.Location = new System.Drawing.Point(35, 93);
            this.DGV_Summary_Monthly.Name = "DGV_Summary_Monthly";
            this.DGV_Summary_Monthly.Size = new System.Drawing.Size(393, 487);
            this.DGV_Summary_Monthly.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "SN";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // ColMonth
            // 
            this.ColMonth.HeaderText = "Month";
            this.ColMonth.Name = "ColMonth";
            this.ColMonth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColMonth.Width = 120;
            // 
            // ColMonthTotal
            // 
            this.ColMonthTotal.HeaderText = "Month Total";
            this.ColMonthTotal.Name = "ColMonthTotal";
            this.ColMonthTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColMonthTotal.Width = 150;
            // 
            // BtnMnthDescend
            // 
            this.BtnMnthDescend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnMnthDescend.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnMnthDescend.FlatAppearance.BorderSize = 0;
            this.BtnMnthDescend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnMnthDescend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnMnthDescend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMnthDescend.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMnthDescend.ForeColor = System.Drawing.Color.White;
            this.BtnMnthDescend.Location = new System.Drawing.Point(175, 43);
            this.BtnMnthDescend.Name = "BtnMnthDescend";
            this.BtnMnthDescend.Size = new System.Drawing.Size(109, 35);
            this.BtnMnthDescend.TabIndex = 12;
            this.BtnMnthDescend.Text = "Descending";
            this.BtnMnthDescend.UseVisualStyleBackColor = false;
            this.BtnMnthDescend.Click += new System.EventHandler(this.BtnMnthDescend_Click);
            // 
            // BtnMnthDefault
            // 
            this.BtnMnthDefault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnMnthDefault.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnMnthDefault.FlatAppearance.BorderSize = 0;
            this.BtnMnthDefault.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnMnthDefault.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnMnthDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMnthDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMnthDefault.ForeColor = System.Drawing.Color.White;
            this.BtnMnthDefault.Location = new System.Drawing.Point(319, 43);
            this.BtnMnthDefault.Name = "BtnMnthDefault";
            this.BtnMnthDefault.Size = new System.Drawing.Size(109, 35);
            this.BtnMnthDefault.TabIndex = 13;
            this.BtnMnthDefault.Text = "Default";
            this.BtnMnthDefault.UseVisualStyleBackColor = false;
            this.BtnMnthDefault.Click += new System.EventHandler(this.BtnMnthDefault_Click);
            // 
            // BtnSortSummarySPI
            // 
            this.BtnSortSummarySPI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnSortSummarySPI.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnSortSummarySPI.FlatAppearance.BorderSize = 0;
            this.BtnSortSummarySPI.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnSortSummarySPI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnSortSummarySPI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSortSummarySPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSortSummarySPI.ForeColor = System.Drawing.Color.White;
            this.BtnSortSummarySPI.Location = new System.Drawing.Point(794, 11);
            this.BtnSortSummarySPI.Name = "BtnSortSummarySPI";
            this.BtnSortSummarySPI.Size = new System.Drawing.Size(109, 35);
            this.BtnSortSummarySPI.TabIndex = 12;
            this.BtnSortSummarySPI.Text = "Sort";
            this.BtnSortSummarySPI.UseVisualStyleBackColor = false;
            this.BtnSortSummarySPI.Click += new System.EventHandler(this.BtnSortSummarySPI_Click);
            // 
            // FrmSPISummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmSPISummary";
            this.Text = "SMS - SPI Summary";
            this.Load += new System.EventHandler(this.FrmSPISummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SPI_Summary)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TabSummarySPIs.ResumeLayout(false);
            this.TabSummarySPIs.PerformLayout();
            this.TabDetailedSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SPI_Summary_ALL)).EndInit();
            this.TabMonthwise.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Summary_Monthly)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_SPI_Summary;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel PanelPlotSPISummary;
        private System.Windows.Forms.ComboBox ComboBoxSort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RadioAscending;
        private System.Windows.Forms.RadioButton RadioDescending;
        private System.Windows.Forms.RadioButton RadioDefault;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSPIs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSPIsType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSPIsProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSPIsTotal;
        private System.Windows.Forms.ToolStripMenuItem sortSummaryTableToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabDetailedSummary;
        private System.Windows.Forms.TabPage TabSummarySPIs;
        private System.Windows.Forms.TabPage TabMonthwise;
        public System.Windows.Forms.DataGridView DGV_SPI_Summary_ALL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColJan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFeb;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColApr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColJun;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColJul;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAug;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSep;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOct;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNov;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotal;
        private System.Windows.Forms.DataGridView DGV_Summary_Monthly;
        private System.Windows.Forms.Panel PanelPlotMonth;
        private System.Windows.Forms.Button BtnMnthAscend;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMonthTotal;
        private System.Windows.Forms.Button BtnMnthDefault;
        private System.Windows.Forms.Button BtnMnthDescend;
        private System.Windows.Forms.Button BtnSortSummarySPI;
    }
}