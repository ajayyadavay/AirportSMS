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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelPlotSPISummary = new System.Windows.Forms.Panel();
            this.ComboBoxSort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RadioAscending = new System.Windows.Forms.RadioButton();
            this.RadioDescending = new System.Windows.Forms.RadioButton();
            this.RadioDefault = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabSummarySPIs = new System.Windows.Forms.TabPage();
            this.BtnSaveHazardCircleSPI = new System.Windows.Forms.Button();
            this.BtnPlotHazardCircleSPI = new System.Windows.Forms.Button();
            this.PanelHighHazardSPI = new System.Windows.Forms.Panel();
            this.BtnSortSummarySPI = new System.Windows.Forms.Button();
            this.TabDetailedSummary = new System.Windows.Forms.TabPage();
            this.BtnClearPlotArea = new System.Windows.Forms.Button();
            this.BtnPlotAllSelectedSPIs = new System.Windows.Forms.Button();
            this.PanelPlotAllSummarySPI = new System.Windows.Forms.Panel();
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
            this.BtnSaveHighCatMonth = new System.Windows.Forms.Button();
            this.BtnHighHazardMonth = new System.Windows.Forms.Button();
            this.PanelHighHazardMonth = new System.Windows.Forms.Panel();
            this.BtnMnthDefault = new System.Windows.Forms.Button();
            this.BtnMnthDescend = new System.Windows.Forms.Button();
            this.BtnMnthAscend = new System.Windows.Forms.Button();
            this.PanelPlotMonth = new System.Windows.Forms.Panel();
            this.DGV_Summary_Monthly = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMonthTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtSummarySIPTopHz = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtMonthHzNumber = new System.Windows.Forms.TextBox();
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
            this.DGV_SPI_Summary.Location = new System.Drawing.Point(6, 16);
            this.DGV_SPI_Summary.Name = "DGV_SPI_Summary";
            this.DGV_SPI_Summary.Size = new System.Drawing.Size(885, 516);
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
            this.ColSPIs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColSPIs.Width = 250;
            // 
            // ColSPIsType
            // 
            this.ColSPIsType.HeaderText = "SPIs Type";
            this.ColSPIsType.Name = "ColSPIsType";
            this.ColSPIsType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            // PanelPlotSPISummary
            // 
            this.PanelPlotSPISummary.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PanelPlotSPISummary.Location = new System.Drawing.Point(10, 545);
            this.PanelPlotSPISummary.Name = "PanelPlotSPISummary";
            this.PanelPlotSPISummary.Size = new System.Drawing.Size(1292, 543);
            this.PanelPlotSPISummary.TabIndex = 2;
            // 
            // ComboBoxSort
            // 
            this.ComboBoxSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxSort.FormattingEnabled = true;
            this.ComboBoxSort.Location = new System.Drawing.Point(922, 127);
            this.ComboBoxSort.Name = "ComboBoxSort";
            this.ComboBoxSort.Size = new System.Drawing.Size(380, 26);
            this.ComboBoxSort.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(921, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select column to sort";
            // 
            // RadioAscending
            // 
            this.RadioAscending.AutoSize = true;
            this.RadioAscending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioAscending.Location = new System.Drawing.Point(924, 195);
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
            this.RadioDescending.Location = new System.Drawing.Point(924, 265);
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
            this.RadioDefault.Location = new System.Drawing.Point(924, 321);
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
            this.tabControl1.Size = new System.Drawing.Size(1329, 1800);
            this.tabControl1.TabIndex = 8;
            // 
            // TabSummarySPIs
            // 
            this.TabSummarySPIs.Controls.Add(this.label2);
            this.TabSummarySPIs.Controls.Add(this.TxtSummarySIPTopHz);
            this.TabSummarySPIs.Controls.Add(this.BtnSaveHazardCircleSPI);
            this.TabSummarySPIs.Controls.Add(this.BtnPlotHazardCircleSPI);
            this.TabSummarySPIs.Controls.Add(this.PanelHighHazardSPI);
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
            this.TabSummarySPIs.Size = new System.Drawing.Size(1321, 1771);
            this.TabSummarySPIs.TabIndex = 0;
            this.TabSummarySPIs.Text = "Summary - SPIs";
            this.TabSummarySPIs.UseVisualStyleBackColor = true;
            // 
            // BtnSaveHazardCircleSPI
            // 
            this.BtnSaveHazardCircleSPI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnSaveHazardCircleSPI.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnSaveHazardCircleSPI.FlatAppearance.BorderSize = 0;
            this.BtnSaveHazardCircleSPI.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnSaveHazardCircleSPI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnSaveHazardCircleSPI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveHazardCircleSPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveHazardCircleSPI.ForeColor = System.Drawing.Color.White;
            this.BtnSaveHazardCircleSPI.Location = new System.Drawing.Point(863, 1214);
            this.BtnSaveHazardCircleSPI.Name = "BtnSaveHazardCircleSPI";
            this.BtnSaveHazardCircleSPI.Size = new System.Drawing.Size(246, 35);
            this.BtnSaveHazardCircleSPI.TabIndex = 15;
            this.BtnSaveHazardCircleSPI.Text = "Save";
            this.BtnSaveHazardCircleSPI.UseVisualStyleBackColor = false;
            this.BtnSaveHazardCircleSPI.Click += new System.EventHandler(this.BtnSaveHazardCircleSPI_Click);
            // 
            // BtnPlotHazardCircleSPI
            // 
            this.BtnPlotHazardCircleSPI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnPlotHazardCircleSPI.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnPlotHazardCircleSPI.FlatAppearance.BorderSize = 0;
            this.BtnPlotHazardCircleSPI.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnPlotHazardCircleSPI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnPlotHazardCircleSPI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPlotHazardCircleSPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlotHazardCircleSPI.ForeColor = System.Drawing.Color.White;
            this.BtnPlotHazardCircleSPI.Location = new System.Drawing.Point(863, 1161);
            this.BtnPlotHazardCircleSPI.Name = "BtnPlotHazardCircleSPI";
            this.BtnPlotHazardCircleSPI.Size = new System.Drawing.Size(246, 35);
            this.BtnPlotHazardCircleSPI.TabIndex = 14;
            this.BtnPlotHazardCircleSPI.Text = "High Hazard Catergory";
            this.BtnPlotHazardCircleSPI.UseVisualStyleBackColor = false;
            this.BtnPlotHazardCircleSPI.Click += new System.EventHandler(this.BtnPlotHazardCircleSPI_Click);
            // 
            // PanelHighHazardSPI
            // 
            this.PanelHighHazardSPI.BackColor = System.Drawing.Color.White;
            this.PanelHighHazardSPI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelHighHazardSPI.Location = new System.Drawing.Point(10, 1094);
            this.PanelHighHazardSPI.Name = "PanelHighHazardSPI";
            this.PanelHighHazardSPI.Size = new System.Drawing.Size(832, 669);
            this.PanelHighHazardSPI.TabIndex = 13;
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
            this.BtnSortSummarySPI.Location = new System.Drawing.Point(922, 383);
            this.BtnSortSummarySPI.Name = "BtnSortSummarySPI";
            this.BtnSortSummarySPI.Size = new System.Drawing.Size(380, 35);
            this.BtnSortSummarySPI.TabIndex = 12;
            this.BtnSortSummarySPI.Text = "Sort";
            this.BtnSortSummarySPI.UseVisualStyleBackColor = false;
            this.BtnSortSummarySPI.Click += new System.EventHandler(this.BtnSortSummarySPI_Click);
            // 
            // TabDetailedSummary
            // 
            this.TabDetailedSummary.Controls.Add(this.BtnClearPlotArea);
            this.TabDetailedSummary.Controls.Add(this.BtnPlotAllSelectedSPIs);
            this.TabDetailedSummary.Controls.Add(this.PanelPlotAllSummarySPI);
            this.TabDetailedSummary.Controls.Add(this.DGV_SPI_Summary_ALL);
            this.TabDetailedSummary.Location = new System.Drawing.Point(4, 25);
            this.TabDetailedSummary.Name = "TabDetailedSummary";
            this.TabDetailedSummary.Padding = new System.Windows.Forms.Padding(3);
            this.TabDetailedSummary.Size = new System.Drawing.Size(1321, 1771);
            this.TabDetailedSummary.TabIndex = 1;
            this.TabDetailedSummary.Text = "Detailed Summary - SPIs";
            this.TabDetailedSummary.UseVisualStyleBackColor = true;
            // 
            // BtnClearPlotArea
            // 
            this.BtnClearPlotArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnClearPlotArea.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnClearPlotArea.FlatAppearance.BorderSize = 0;
            this.BtnClearPlotArea.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnClearPlotArea.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnClearPlotArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClearPlotArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClearPlotArea.ForeColor = System.Drawing.Color.White;
            this.BtnClearPlotArea.Location = new System.Drawing.Point(300, 460);
            this.BtnClearPlotArea.Name = "BtnClearPlotArea";
            this.BtnClearPlotArea.Size = new System.Drawing.Size(277, 35);
            this.BtnClearPlotArea.TabIndex = 15;
            this.BtnClearPlotArea.Text = "Clear Plot area";
            this.BtnClearPlotArea.UseVisualStyleBackColor = false;
            this.BtnClearPlotArea.Click += new System.EventHandler(this.BtnClearPlotArea_Click);
            // 
            // BtnPlotAllSelectedSPIs
            // 
            this.BtnPlotAllSelectedSPIs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnPlotAllSelectedSPIs.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnPlotAllSelectedSPIs.FlatAppearance.BorderSize = 0;
            this.BtnPlotAllSelectedSPIs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnPlotAllSelectedSPIs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnPlotAllSelectedSPIs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPlotAllSelectedSPIs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlotAllSelectedSPIs.ForeColor = System.Drawing.Color.White;
            this.BtnPlotAllSelectedSPIs.Location = new System.Drawing.Point(6, 460);
            this.BtnPlotAllSelectedSPIs.Name = "BtnPlotAllSelectedSPIs";
            this.BtnPlotAllSelectedSPIs.Size = new System.Drawing.Size(277, 35);
            this.BtnPlotAllSelectedSPIs.TabIndex = 14;
            this.BtnPlotAllSelectedSPIs.Text = "Plot selected rows";
            this.BtnPlotAllSelectedSPIs.UseVisualStyleBackColor = false;
            this.BtnPlotAllSelectedSPIs.Click += new System.EventHandler(this.BtnPlotAllSelectedSPIs_Click);
            // 
            // PanelPlotAllSummarySPI
            // 
            this.PanelPlotAllSummarySPI.BackColor = System.Drawing.Color.Gainsboro;
            this.PanelPlotAllSummarySPI.Location = new System.Drawing.Point(6, 505);
            this.PanelPlotAllSummarySPI.Name = "PanelPlotAllSummarySPI";
            this.PanelPlotAllSummarySPI.Size = new System.Drawing.Size(1309, 442);
            this.PanelPlotAllSummarySPI.TabIndex = 6;
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
            this.DGV_SPI_Summary_ALL.Location = new System.Drawing.Point(6, 14);
            this.DGV_SPI_Summary_ALL.Name = "DGV_SPI_Summary_ALL";
            this.DGV_SPI_Summary_ALL.Size = new System.Drawing.Size(1309, 436);
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
            this.ColName.Width = 160;
            // 
            // ColJan
            // 
            this.ColJan.HeaderText = "Jan";
            this.ColJan.Name = "ColJan";
            this.ColJan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColJan.Width = 80;
            // 
            // ColFeb
            // 
            this.ColFeb.HeaderText = "Feb";
            this.ColFeb.Name = "ColFeb";
            this.ColFeb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColFeb.Width = 80;
            // 
            // ColMar
            // 
            this.ColMar.HeaderText = "Mar";
            this.ColMar.Name = "ColMar";
            this.ColMar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColMar.Width = 80;
            // 
            // ColApr
            // 
            this.ColApr.HeaderText = "Apr";
            this.ColApr.Name = "ColApr";
            this.ColApr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColApr.Width = 80;
            // 
            // ColMay
            // 
            this.ColMay.HeaderText = "May";
            this.ColMay.Name = "ColMay";
            this.ColMay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColMay.Width = 80;
            // 
            // ColJun
            // 
            this.ColJun.HeaderText = "Jun";
            this.ColJun.Name = "ColJun";
            this.ColJun.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColJun.Width = 80;
            // 
            // ColJul
            // 
            this.ColJul.HeaderText = "Jul";
            this.ColJul.Name = "ColJul";
            this.ColJul.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColJul.Width = 80;
            // 
            // ColAug
            // 
            this.ColAug.HeaderText = "Aug";
            this.ColAug.Name = "ColAug";
            this.ColAug.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColAug.Width = 80;
            // 
            // ColSep
            // 
            this.ColSep.HeaderText = "Sep";
            this.ColSep.Name = "ColSep";
            this.ColSep.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColSep.Width = 80;
            // 
            // ColOct
            // 
            this.ColOct.HeaderText = "Oct";
            this.ColOct.Name = "ColOct";
            this.ColOct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColOct.Width = 80;
            // 
            // ColNov
            // 
            this.ColNov.HeaderText = "Nov";
            this.ColNov.Name = "ColNov";
            this.ColNov.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColNov.Width = 80;
            // 
            // ColDec
            // 
            this.ColDec.HeaderText = "Dec";
            this.ColDec.Name = "ColDec";
            this.ColDec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColDec.Width = 80;
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
            this.TabMonthwise.Controls.Add(this.TxtMonthHzNumber);
            this.TabMonthwise.Controls.Add(this.label3);
            this.TabMonthwise.Controls.Add(this.BtnSaveHighCatMonth);
            this.TabMonthwise.Controls.Add(this.BtnHighHazardMonth);
            this.TabMonthwise.Controls.Add(this.PanelHighHazardMonth);
            this.TabMonthwise.Controls.Add(this.BtnMnthDefault);
            this.TabMonthwise.Controls.Add(this.BtnMnthDescend);
            this.TabMonthwise.Controls.Add(this.BtnMnthAscend);
            this.TabMonthwise.Controls.Add(this.PanelPlotMonth);
            this.TabMonthwise.Controls.Add(this.DGV_Summary_Monthly);
            this.TabMonthwise.Location = new System.Drawing.Point(4, 25);
            this.TabMonthwise.Name = "TabMonthwise";
            this.TabMonthwise.Size = new System.Drawing.Size(1321, 1771);
            this.TabMonthwise.TabIndex = 2;
            this.TabMonthwise.Text = "Summary Monthwise - SPIs";
            this.TabMonthwise.UseVisualStyleBackColor = true;
            // 
            // BtnSaveHighCatMonth
            // 
            this.BtnSaveHighCatMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnSaveHighCatMonth.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnSaveHighCatMonth.FlatAppearance.BorderSize = 0;
            this.BtnSaveHighCatMonth.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnSaveHighCatMonth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnSaveHighCatMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveHighCatMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveHighCatMonth.ForeColor = System.Drawing.Color.White;
            this.BtnSaveHighCatMonth.Location = new System.Drawing.Point(1103, 758);
            this.BtnSaveHighCatMonth.Name = "BtnSaveHighCatMonth";
            this.BtnSaveHighCatMonth.Size = new System.Drawing.Size(202, 45);
            this.BtnSaveHighCatMonth.TabIndex = 16;
            this.BtnSaveHighCatMonth.Text = "Save";
            this.BtnSaveHighCatMonth.UseVisualStyleBackColor = false;
            this.BtnSaveHighCatMonth.Click += new System.EventHandler(this.BtnSaveHighCatMonth_Click);
            // 
            // BtnHighHazardMonth
            // 
            this.BtnHighHazardMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnHighHazardMonth.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnHighHazardMonth.FlatAppearance.BorderSize = 0;
            this.BtnHighHazardMonth.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnHighHazardMonth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnHighHazardMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnHighHazardMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHighHazardMonth.ForeColor = System.Drawing.Color.White;
            this.BtnHighHazardMonth.Location = new System.Drawing.Point(1103, 692);
            this.BtnHighHazardMonth.Name = "BtnHighHazardMonth";
            this.BtnHighHazardMonth.Size = new System.Drawing.Size(202, 45);
            this.BtnHighHazardMonth.TabIndex = 15;
            this.BtnHighHazardMonth.Text = "High Hazard Month";
            this.BtnHighHazardMonth.UseVisualStyleBackColor = false;
            this.BtnHighHazardMonth.Click += new System.EventHandler(this.BtnHighHazardMonth_Click);
            // 
            // PanelHighHazardMonth
            // 
            this.PanelHighHazardMonth.BackColor = System.Drawing.Color.White;
            this.PanelHighHazardMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelHighHazardMonth.Location = new System.Drawing.Point(202, 595);
            this.PanelHighHazardMonth.Name = "PanelHighHazardMonth";
            this.PanelHighHazardMonth.Size = new System.Drawing.Size(891, 605);
            this.PanelHighHazardMonth.TabIndex = 14;
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
            // TxtSummarySIPTopHz
            // 
            this.TxtSummarySIPTopHz.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSummarySIPTopHz.Location = new System.Drawing.Point(1112, 1115);
            this.TxtSummarySIPTopHz.Name = "TxtSummarySIPTopHz";
            this.TxtSummarySIPTopHz.Size = new System.Drawing.Size(190, 24);
            this.TxtSummarySIPTopHz.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(861, 1119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Enter no. of Top Hazard to draw";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1100, 608);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "Enter no. of top hazard month";
            // 
            // TxtMonthHzNumber
            // 
            this.TxtMonthHzNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMonthHzNumber.Location = new System.Drawing.Point(1103, 641);
            this.TxtMonthHzNumber.Name = "TxtMonthHzNumber";
            this.TxtMonthHzNumber.Size = new System.Drawing.Size(202, 24);
            this.TxtMonthHzNumber.TabIndex = 18;
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
            this.TabMonthwise.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabDetailedSummary;
        private System.Windows.Forms.TabPage TabSummarySPIs;
        private System.Windows.Forms.TabPage TabMonthwise;
        public System.Windows.Forms.DataGridView DGV_SPI_Summary_ALL;
        private System.Windows.Forms.DataGridView DGV_Summary_Monthly;
        private System.Windows.Forms.Panel PanelPlotMonth;
        private System.Windows.Forms.Button BtnMnthAscend;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMonthTotal;
        private System.Windows.Forms.Button BtnMnthDefault;
        private System.Windows.Forms.Button BtnMnthDescend;
        private System.Windows.Forms.Button BtnSortSummarySPI;
        private System.Windows.Forms.Panel PanelPlotAllSummarySPI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSPIs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSPIsType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSPIsProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSPIsTotal;
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
        private System.Windows.Forms.Button BtnPlotAllSelectedSPIs;
        private System.Windows.Forms.Button BtnClearPlotArea;
        private System.Windows.Forms.Panel PanelHighHazardMonth;
        private System.Windows.Forms.Button BtnHighHazardMonth;
        private System.Windows.Forms.Button BtnSaveHighCatMonth;
        private System.Windows.Forms.Panel PanelHighHazardSPI;
        private System.Windows.Forms.Button BtnSaveHazardCircleSPI;
        private System.Windows.Forms.Button BtnPlotHazardCircleSPI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtSummarySIPTopHz;
        private System.Windows.Forms.TextBox TxtMonthHzNumber;
        private System.Windows.Forms.Label label3;
    }
}