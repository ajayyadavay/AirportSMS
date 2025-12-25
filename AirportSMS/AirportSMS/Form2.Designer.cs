namespace AirportSMS
{
    partial class FrmFlightMovement
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGV_FMs_CurrentYear = new System.Windows.Forms.DataGridView();
            this.ColSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDomArr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDomDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDomTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIntlArr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIntlDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIntlTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDIArr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDIDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDITotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtFMCurrentYear = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fMsOfCurrentYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fMsOfPreviousYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fMsOfBothYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabCurrYrFM = new System.Windows.Forms.TabPage();
            this.TabPrevYrFM = new System.Windows.Forms.TabPage();
            this.TxtFMPrevYear = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DGV_FMs_PreviousYear = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TabPlotFM = new System.Windows.Forms.TabPage();
            this.PanelPlotFM = new System.Windows.Forms.Panel();
            this.ColSN1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMonth1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDomArr1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDomDep1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDomTotal1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIntlArr1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIntlDep1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIntlTotal1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDIArr1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDIDep1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDITotal1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FMs_CurrentYear)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabCurrYrFM.SuspendLayout();
            this.TabPrevYrFM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FMs_PreviousYear)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.TabPlotFM.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV_FMs_CurrentYear
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            this.DGV_FMs_CurrentYear.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_FMs_CurrentYear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_FMs_CurrentYear.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSN,
            this.ColMonth,
            this.ColDomArr,
            this.ColDomDep,
            this.ColDomTotal,
            this.ColIntlArr,
            this.ColIntlDep,
            this.ColIntlTotal,
            this.ColDIArr,
            this.ColDIDep,
            this.ColDITotal});
            this.DGV_FMs_CurrentYear.ContextMenuStrip = this.contextMenuStrip1;
            this.DGV_FMs_CurrentYear.Location = new System.Drawing.Point(14, 81);
            this.DGV_FMs_CurrentYear.Name = "DGV_FMs_CurrentYear";
            this.DGV_FMs_CurrentYear.Size = new System.Drawing.Size(1214, 376);
            this.DGV_FMs_CurrentYear.TabIndex = 0;
            this.DGV_FMs_CurrentYear.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FMs_CurrentYear_CellValueChanged);
            // 
            // ColSN
            // 
            this.ColSN.HeaderText = "SN";
            this.ColSN.Name = "ColSN";
            this.ColSN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColSN.Width = 60;
            // 
            // ColMonth
            // 
            this.ColMonth.HeaderText = "Month";
            this.ColMonth.Name = "ColMonth";
            this.ColMonth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColMonth.Width = 80;
            // 
            // ColDomArr
            // 
            this.ColDomArr.HeaderText = "Domestic Arrival";
            this.ColDomArr.Name = "ColDomArr";
            this.ColDomArr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColDomDep
            // 
            this.ColDomDep.HeaderText = "Domestic Departure";
            this.ColDomDep.Name = "ColDomDep";
            this.ColDomDep.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColDomTotal
            // 
            this.ColDomTotal.HeaderText = "Domestic Total";
            this.ColDomTotal.Name = "ColDomTotal";
            this.ColDomTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColIntlArr
            // 
            this.ColIntlArr.HeaderText = "Int\'l Arrival";
            this.ColIntlArr.Name = "ColIntlArr";
            this.ColIntlArr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColIntlDep
            // 
            this.ColIntlDep.HeaderText = "Int\'l Departure";
            this.ColIntlDep.Name = "ColIntlDep";
            this.ColIntlDep.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColIntlTotal
            // 
            this.ColIntlTotal.HeaderText = "Int\'l Total";
            this.ColIntlTotal.Name = "ColIntlTotal";
            this.ColIntlTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColDIArr
            // 
            this.ColDIArr.HeaderText = "Dom+Int\'l Arrival";
            this.ColDIArr.Name = "ColDIArr";
            this.ColDIArr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColDIDep
            // 
            this.ColDIDep.HeaderText = "Dom+Int\'l Departure";
            this.ColDIDep.Name = "ColDIDep";
            this.ColDIDep.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColDITotal
            // 
            this.ColDITotal.HeaderText = "Dom+Int\'l Total";
            this.ColDITotal.Name = "ColDITotal";
            this.ColDITotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 52);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Flight Movement Data for Current Year:";
            // 
            // TxtFMCurrentYear
            // 
            this.TxtFMCurrentYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFMCurrentYear.Location = new System.Drawing.Point(295, 45);
            this.TxtFMCurrentYear.Name = "TxtFMCurrentYear";
            this.TxtFMCurrentYear.Size = new System.Drawing.Size(141, 24);
            this.TxtFMCurrentYear.TabIndex = 2;
            this.TxtFMCurrentYear.TextChanged += new System.EventHandler(this.TxtFMCurrentYear_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.plotToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
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
            // plotToolStripMenuItem
            // 
            this.plotToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fMsOfCurrentYearToolStripMenuItem,
            this.fMsOfPreviousYearToolStripMenuItem,
            this.fMsOfBothYearToolStripMenuItem});
            this.plotToolStripMenuItem.Name = "plotToolStripMenuItem";
            this.plotToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.plotToolStripMenuItem.Text = "Plot";
            // 
            // fMsOfCurrentYearToolStripMenuItem
            // 
            this.fMsOfCurrentYearToolStripMenuItem.CheckOnClick = true;
            this.fMsOfCurrentYearToolStripMenuItem.Name = "fMsOfCurrentYearToolStripMenuItem";
            this.fMsOfCurrentYearToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.fMsOfCurrentYearToolStripMenuItem.Text = "FMs of Current Year";
            this.fMsOfCurrentYearToolStripMenuItem.Click += new System.EventHandler(this.fMsOfCurrentYearToolStripMenuItem_Click);
            // 
            // fMsOfPreviousYearToolStripMenuItem
            // 
            this.fMsOfPreviousYearToolStripMenuItem.CheckOnClick = true;
            this.fMsOfPreviousYearToolStripMenuItem.Name = "fMsOfPreviousYearToolStripMenuItem";
            this.fMsOfPreviousYearToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.fMsOfPreviousYearToolStripMenuItem.Text = "FMs of Previous Year";
            this.fMsOfPreviousYearToolStripMenuItem.Click += new System.EventHandler(this.fMsOfPreviousYearToolStripMenuItem_Click);
            // 
            // fMsOfBothYearToolStripMenuItem
            // 
            this.fMsOfBothYearToolStripMenuItem.Checked = true;
            this.fMsOfBothYearToolStripMenuItem.CheckOnClick = true;
            this.fMsOfBothYearToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fMsOfBothYearToolStripMenuItem.Name = "fMsOfBothYearToolStripMenuItem";
            this.fMsOfBothYearToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.fMsOfBothYearToolStripMenuItem.Text = "FMs of both year";
            this.fMsOfBothYearToolStripMenuItem.Click += new System.EventHandler(this.fMsOfBothYearToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabCurrYrFM);
            this.tabControl1.Controls.Add(this.TabPrevYrFM);
            this.tabControl1.Controls.Add(this.TabPlotFM);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1261, 520);
            this.tabControl1.TabIndex = 7;
            // 
            // TabCurrYrFM
            // 
            this.TabCurrYrFM.Controls.Add(this.label1);
            this.TabCurrYrFM.Controls.Add(this.TxtFMCurrentYear);
            this.TabCurrYrFM.Controls.Add(this.DGV_FMs_CurrentYear);
            this.TabCurrYrFM.Location = new System.Drawing.Point(4, 27);
            this.TabCurrYrFM.Name = "TabCurrYrFM";
            this.TabCurrYrFM.Padding = new System.Windows.Forms.Padding(3);
            this.TabCurrYrFM.Size = new System.Drawing.Size(1253, 489);
            this.TabCurrYrFM.TabIndex = 0;
            this.TabCurrYrFM.Text = "Current Year FMs";
            this.TabCurrYrFM.UseVisualStyleBackColor = true;
            // 
            // TabPrevYrFM
            // 
            this.TabPrevYrFM.Controls.Add(this.TxtFMPrevYear);
            this.TabPrevYrFM.Controls.Add(this.label2);
            this.TabPrevYrFM.Controls.Add(this.DGV_FMs_PreviousYear);
            this.TabPrevYrFM.Location = new System.Drawing.Point(4, 27);
            this.TabPrevYrFM.Name = "TabPrevYrFM";
            this.TabPrevYrFM.Padding = new System.Windows.Forms.Padding(3);
            this.TabPrevYrFM.Size = new System.Drawing.Size(1253, 489);
            this.TabPrevYrFM.TabIndex = 1;
            this.TabPrevYrFM.Text = "Previous Year FM";
            this.TabPrevYrFM.UseVisualStyleBackColor = true;
            // 
            // TxtFMPrevYear
            // 
            this.TxtFMPrevYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFMPrevYear.Location = new System.Drawing.Point(287, 26);
            this.TxtFMPrevYear.Name = "TxtFMPrevYear";
            this.TxtFMPrevYear.Size = new System.Drawing.Size(141, 24);
            this.TxtFMPrevYear.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Flight Movement Data for Previous Year:";
            // 
            // DGV_FMs_PreviousYear
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.DGV_FMs_PreviousYear.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_FMs_PreviousYear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_FMs_PreviousYear.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSN1,
            this.ColMonth1,
            this.ColDomArr1,
            this.ColDomDep1,
            this.ColDomTotal1,
            this.ColIntlArr1,
            this.ColIntlDep1,
            this.ColIntlTotal1,
            this.ColDIArr1,
            this.ColDIDep1,
            this.ColDITotal1});
            this.DGV_FMs_PreviousYear.ContextMenuStrip = this.contextMenuStrip2;
            this.DGV_FMs_PreviousYear.Location = new System.Drawing.Point(6, 53);
            this.DGV_FMs_PreviousYear.Name = "DGV_FMs_PreviousYear";
            this.DGV_FMs_PreviousYear.Size = new System.Drawing.Size(1214, 376);
            this.DGV_FMs_PreviousYear.TabIndex = 7;
            this.DGV_FMs_PreviousYear.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_FMs_PreviousYear_CellValueChanged);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem1,
            this.pasteToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(113, 52);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(112, 24);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(112, 24);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.pasteToolStripMenuItem1_Click);
            // 
            // TabPlotFM
            // 
            this.TabPlotFM.Controls.Add(this.PanelPlotFM);
            this.TabPlotFM.Location = new System.Drawing.Point(4, 27);
            this.TabPlotFM.Name = "TabPlotFM";
            this.TabPlotFM.Size = new System.Drawing.Size(1253, 489);
            this.TabPlotFM.TabIndex = 2;
            this.TabPlotFM.Text = "Plot";
            this.TabPlotFM.UseVisualStyleBackColor = true;
            // 
            // PanelPlotFM
            // 
            this.PanelPlotFM.BackColor = System.Drawing.Color.Silver;
            this.PanelPlotFM.Location = new System.Drawing.Point(12, 37);
            this.PanelPlotFM.Name = "PanelPlotFM";
            this.PanelPlotFM.Size = new System.Drawing.Size(1203, 424);
            this.PanelPlotFM.TabIndex = 0;
            // 
            // ColSN1
            // 
            this.ColSN1.HeaderText = "SN";
            this.ColSN1.Name = "ColSN1";
            this.ColSN1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColSN1.Width = 60;
            // 
            // ColMonth1
            // 
            this.ColMonth1.HeaderText = "Month";
            this.ColMonth1.Name = "ColMonth1";
            this.ColMonth1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColMonth1.Width = 80;
            // 
            // ColDomArr1
            // 
            this.ColDomArr1.HeaderText = "Domestic Arrival";
            this.ColDomArr1.Name = "ColDomArr1";
            this.ColDomArr1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColDomDep1
            // 
            this.ColDomDep1.HeaderText = "Domestic Departure";
            this.ColDomDep1.Name = "ColDomDep1";
            this.ColDomDep1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColDomTotal1
            // 
            this.ColDomTotal1.HeaderText = "Domestic Total";
            this.ColDomTotal1.Name = "ColDomTotal1";
            this.ColDomTotal1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColIntlArr1
            // 
            this.ColIntlArr1.HeaderText = "Int\'l Arrival";
            this.ColIntlArr1.Name = "ColIntlArr1";
            this.ColIntlArr1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColIntlDep1
            // 
            this.ColIntlDep1.HeaderText = "Int\'l Departure";
            this.ColIntlDep1.Name = "ColIntlDep1";
            this.ColIntlDep1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColIntlTotal1
            // 
            this.ColIntlTotal1.HeaderText = "Int\'l Total";
            this.ColIntlTotal1.Name = "ColIntlTotal1";
            this.ColIntlTotal1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColDIArr1
            // 
            this.ColDIArr1.HeaderText = "Dom+Int\'l Arrival";
            this.ColDIArr1.Name = "ColDIArr1";
            this.ColDIArr1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColDIDep1
            // 
            this.ColDIDep1.HeaderText = "Dom+Int\'l Departure";
            this.ColDIDep1.Name = "ColDIDep1";
            this.ColDIDep1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColDITotal1
            // 
            this.ColDITotal1.HeaderText = "Dom+Int\'l Total";
            this.ColDITotal1.Name = "ColDITotal1";
            this.ColDITotal1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmFlightMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmFlightMovement";
            this.Text = "Flight Movement data";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FMs_CurrentYear)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TabCurrYrFM.ResumeLayout(false);
            this.TabCurrYrFM.PerformLayout();
            this.TabPrevYrFM.ResumeLayout(false);
            this.TabPrevYrFM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FMs_PreviousYear)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.TabPlotFM.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_FMs_CurrentYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtFMCurrentYear;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fMsOfCurrentYearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fMsOfPreviousYearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fMsOfBothYearToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDomArr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDomDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDomTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIntlArr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIntlDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIntlTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDIArr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDIDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDITotal;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabCurrYrFM;
        private System.Windows.Forms.TabPage TabPrevYrFM;
        private System.Windows.Forms.TextBox TxtFMPrevYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGV_FMs_PreviousYear;
        private System.Windows.Forms.TabPage TabPlotFM;
        private System.Windows.Forms.Panel PanelPlotFM;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSN1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMonth1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDomArr1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDomDep1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDomTotal1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIntlArr1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIntlDep1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIntlTotal1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDIArr1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDIDep1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDITotal1;
    }
}