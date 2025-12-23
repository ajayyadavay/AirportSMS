namespace AirportSMS
{
    partial class FrmHazardMonitoring
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewSPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.importTemplateSPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtPercentTarget = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtCurrentYear = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TxtProgressPercent = new System.Windows.Forms.TextBox();
            this.TxtSPI_Value_Current = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.TxtSPI_Value_Target = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtSPI_Value = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtSPI_ID = new System.Windows.Forms.TextBox();
            this.TxtSPI_Calc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Txt_SPI_Unit = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtSPI_Inform = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Txt_SPI_Manage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtSPI_Description = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtSPI_Type = new System.Windows.Forms.TextBox();
            this.ComboBoxSPI_Type = new System.Windows.Forms.ComboBox();
            this.TxtSPI_Name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PanelPlot = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.Chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.Chart1.Legends.Add(legend2);
            this.Chart1.Location = new System.Drawing.Point(7, 940);
            this.Chart1.Name = "Chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.Chart1.Series.Add(series2);
            this.Chart1.Size = new System.Drawing.Size(1340, 493);
            this.Chart1.TabIndex = 1;
            this.Chart1.Text = "chart1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColDes,
            this.ColYear,
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
            this.ColDec});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(8, 787);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1340, 147);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // ColID
            // 
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColID.Width = 50;
            // 
            // ColDes
            // 
            this.ColDes.HeaderText = "Description";
            this.ColDes.Name = "ColDes";
            this.ColDes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColDes.Width = 200;
            // 
            // ColYear
            // 
            this.ColYear.HeaderText = "Year";
            this.ColYear.Name = "ColYear";
            this.ColYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColYear.Width = 80;
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1353, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewSPIToolStripMenuItem,
            this.saveSPIToolStripMenuItem,
            this.toolStripMenuItem2,
            this.importTemplateSPIToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createNewSPIToolStripMenuItem
            // 
            this.createNewSPIToolStripMenuItem.Name = "createNewSPIToolStripMenuItem";
            this.createNewSPIToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.createNewSPIToolStripMenuItem.Text = "Create New SPI";
            this.createNewSPIToolStripMenuItem.Click += new System.EventHandler(this.createNewSPIToolStripMenuItem_Click);
            // 
            // saveSPIToolStripMenuItem
            // 
            this.saveSPIToolStripMenuItem.Name = "saveSPIToolStripMenuItem";
            this.saveSPIToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.saveSPIToolStripMenuItem.Text = "Save SPI";
            this.saveSPIToolStripMenuItem.Click += new System.EventHandler(this.saveSPIToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(260, 6);
            // 
            // importTemplateSPIToolStripMenuItem
            // 
            this.importTemplateSPIToolStripMenuItem.Name = "importTemplateSPIToolStripMenuItem";
            this.importTemplateSPIToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.importTemplateSPIToolStripMenuItem.Text = "Import Template SPI (*.json)";
            this.importTemplateSPIToolStripMenuItem.Click += new System.EventHandler(this.importTemplateSPIToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter % of reduced by (-)/increased by (+)";
            // 
            // TxtPercentTarget
            // 
            this.TxtPercentTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPercentTarget.Location = new System.Drawing.Point(297, 73);
            this.TxtPercentTarget.Name = "TxtPercentTarget";
            this.TxtPercentTarget.Size = new System.Drawing.Size(128, 24);
            this.TxtPercentTarget.TabIndex = 6;
            this.TxtPercentTarget.TextChanged += new System.EventHandler(this.TxtPercentTarget_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(431, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "%";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtCurrentYear);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtPercentTarget);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 678);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1328, 103);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Info";
            // 
            // TxtCurrentYear
            // 
            this.TxtCurrentYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCurrentYear.Location = new System.Drawing.Point(297, 33);
            this.TxtCurrentYear.Name = "TxtCurrentYear";
            this.TxtCurrentYear.Size = new System.Drawing.Size(128, 24);
            this.TxtCurrentYear.TabIndex = 7;
            this.TxtCurrentYear.TextChanged += new System.EventHandler(this.TxtCurrentYear_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Current Year";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(7, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1328, 86);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selecting SPIs";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(543, 51);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(589, 22);
            this.checkBox4.TabIndex = 11;
            this.checkBox4.Text = "d. Is it realistic, by taking into account the possibilities and constraints of o" +
    "rganization?";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(543, 23);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(320, 22);
            this.checkBox3.TabIndex = 10;
            this.checkBox3.Text = "c. Is it appropriately specific and quantifiable?";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(21, 51);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(392, 22);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "b. Is it based on avaiable data and reliable measurment?";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(21, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(264, 22);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "a. Is SPI related to Safety Objective?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.TxtProgressPercent);
            this.groupBox3.Controls.Add(this.TxtSPI_Value_Current);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.TxtSPI_Value_Target);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.TxtSPI_Value);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.TxtSPI_ID);
            this.groupBox3.Controls.Add(this.TxtSPI_Calc);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.Txt_SPI_Unit);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.TxtSPI_Inform);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.Txt_SPI_Manage);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.TxtSPI_Description);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.TxtSPI_Type);
            this.groupBox3.Controls.Add(this.ComboBoxSPI_Type);
            this.groupBox3.Controls.Add(this.TxtSPI_Name);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(7, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1328, 538);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Defining SPIs";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(803, 192);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(151, 18);
            this.label16.TabIndex = 30;
            this.label16.Text = "Progress Percent (%)";
            // 
            // TxtProgressPercent
            // 
            this.TxtProgressPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProgressPercent.Location = new System.Drawing.Point(958, 189);
            this.TxtProgressPercent.Name = "TxtProgressPercent";
            this.TxtProgressPercent.ReadOnly = true;
            this.TxtProgressPercent.Size = new System.Drawing.Size(344, 24);
            this.TxtProgressPercent.TabIndex = 29;
            // 
            // TxtSPI_Value_Current
            // 
            this.TxtSPI_Value_Current.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSPI_Value_Current.Location = new System.Drawing.Point(958, 159);
            this.TxtSPI_Value_Current.Name = "TxtSPI_Value_Current";
            this.TxtSPI_Value_Current.ReadOnly = true;
            this.TxtSPI_Value_Current.Size = new System.Drawing.Size(344, 24);
            this.TxtSPI_Value_Current.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(819, 159);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 18);
            this.label15.TabIndex = 27;
            this.label15.Text = "Value Current Obs:";
            // 
            // TxtSPI_Value_Target
            // 
            this.TxtSPI_Value_Target.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSPI_Value_Target.Location = new System.Drawing.Point(958, 129);
            this.TxtSPI_Value_Target.Name = "TxtSPI_Value_Target";
            this.TxtSPI_Value_Target.ReadOnly = true;
            this.TxtSPI_Value_Target.Size = new System.Drawing.Size(344, 24);
            this.TxtSPI_Value_Target.TabIndex = 26;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(857, 133);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 18);
            this.label14.TabIndex = 25;
            this.label14.Text = "Value Target:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(806, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 18);
            this.label13.TabIndex = 24;
            this.label13.Text = "Value Prev Observed";
            // 
            // TxtSPI_Value
            // 
            this.TxtSPI_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSPI_Value.Location = new System.Drawing.Point(958, 99);
            this.TxtSPI_Value.Name = "TxtSPI_Value";
            this.TxtSPI_Value.ReadOnly = true;
            this.TxtSPI_Value.Size = new System.Drawing.Size(344, 24);
            this.TxtSPI_Value.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(806, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 18);
            this.label12.TabIndex = 22;
            this.label12.Text = "ID:";
            // 
            // TxtSPI_ID
            // 
            this.TxtSPI_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSPI_ID.Location = new System.Drawing.Point(860, 68);
            this.TxtSPI_ID.Name = "TxtSPI_ID";
            this.TxtSPI_ID.ReadOnly = true;
            this.TxtSPI_ID.Size = new System.Drawing.Size(442, 24);
            this.TxtSPI_ID.TabIndex = 21;
            // 
            // TxtSPI_Calc
            // 
            this.TxtSPI_Calc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSPI_Calc.Location = new System.Drawing.Point(212, 315);
            this.TxtSPI_Calc.Multiline = true;
            this.TxtSPI_Calc.Name = "TxtSPI_Calc";
            this.TxtSPI_Calc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtSPI_Calc.Size = new System.Drawing.Size(523, 44);
            this.TxtSPI_Calc.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(27, 323);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 36);
            this.label11.TabIndex = 19;
            this.label11.Text = "c2. Requirement for\r\n     Calculation";
            // 
            // Txt_SPI_Unit
            // 
            this.Txt_SPI_Unit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_SPI_Unit.Location = new System.Drawing.Point(212, 265);
            this.Txt_SPI_Unit.Multiline = true;
            this.Txt_SPI_Unit.Name = "Txt_SPI_Unit";
            this.Txt_SPI_Unit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txt_SPI_Unit.Size = new System.Drawing.Size(523, 44);
            this.Txt_SPI_Unit.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(27, 287);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 18);
            this.label10.TabIndex = 17;
            this.label10.Text = "c1. Units of measurement";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(78, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 36);
            this.label9.TabIndex = 16;
            this.label9.Text = "Who it intends \r\nto inform";
            // 
            // TxtSPI_Inform
            // 
            this.TxtSPI_Inform.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSPI_Inform.Location = new System.Drawing.Point(212, 215);
            this.TxtSPI_Inform.Multiline = true;
            this.TxtSPI_Inform.Name = "TxtSPI_Inform";
            this.TxtSPI_Inform.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtSPI_Inform.Size = new System.Drawing.Size(523, 44);
            this.TxtSPI_Inform.TabIndex = 15;
            this.TxtSPI_Inform.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(75, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 36);
            this.label6.TabIndex = 14;
            this.label6.Text = "What it intends \r\nto manage";
            // 
            // Txt_SPI_Manage
            // 
            this.Txt_SPI_Manage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_SPI_Manage.Location = new System.Drawing.Point(212, 162);
            this.Txt_SPI_Manage.Multiline = true;
            this.Txt_SPI_Manage.Name = "Txt_SPI_Manage";
            this.Txt_SPI_Manage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txt_SPI_Manage.Size = new System.Drawing.Size(523, 47);
            this.Txt_SPI_Manage.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "b. Purpose of SPI";
            // 
            // TxtSPI_Description
            // 
            this.TxtSPI_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSPI_Description.Location = new System.Drawing.Point(212, 96);
            this.TxtSPI_Description.Multiline = true;
            this.TxtSPI_Description.Name = "TxtSPI_Description";
            this.TxtSPI_Description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtSPI_Description.Size = new System.Drawing.Size(523, 48);
            this.TxtSPI_Description.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 36);
            this.label4.TabIndex = 10;
            this.label4.Text = "a. Description of what the \r\n    SPI measures";
            // 
            // TxtSPI_Type
            // 
            this.TxtSPI_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSPI_Type.Location = new System.Drawing.Point(212, 57);
            this.TxtSPI_Type.Name = "TxtSPI_Type";
            this.TxtSPI_Type.Size = new System.Drawing.Size(523, 24);
            this.TxtSPI_Type.TabIndex = 9;
            // 
            // ComboBoxSPI_Type
            // 
            this.ComboBoxSPI_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxSPI_Type.FormattingEnabled = true;
            this.ComboBoxSPI_Type.Location = new System.Drawing.Point(212, 25);
            this.ComboBoxSPI_Type.Name = "ComboBoxSPI_Type";
            this.ComboBoxSPI_Type.Size = new System.Drawing.Size(523, 26);
            this.ComboBoxSPI_Type.TabIndex = 8;
            this.ComboBoxSPI_Type.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSPI_Type_SelectedIndexChanged);
            // 
            // TxtSPI_Name
            // 
            this.TxtSPI_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSPI_Name.Location = new System.Drawing.Point(860, 23);
            this.TxtSPI_Name.Multiline = true;
            this.TxtSPI_Name.Name = "TxtSPI_Name";
            this.TxtSPI_Name.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtSPI_Name.Size = new System.Drawing.Size(442, 39);
            this.TxtSPI_Name.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(802, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 18);
            this.label8.TabIndex = 3;
            this.label8.Text = "Types of SPI";
            // 
            // PanelPlot
            // 
            this.PanelPlot.BackColor = System.Drawing.Color.LightGray;
            this.PanelPlot.Location = new System.Drawing.Point(7, 1439);
            this.PanelPlot.Name = "PanelPlot";
            this.PanelPlot.Size = new System.Drawing.Size(1330, 490);
            this.PanelPlot.TabIndex = 10;
            // 
            // FrmHazardMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.PanelPlot);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Chart1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmHazardMonitoring";
            this.Text = "Airport SMS - Hazard monitoring";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmHazardMonitoring_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Chart1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColYear;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtPercentTarget;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtCurrentYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ComboBoxSPI_Type;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox TxtSPI_Name;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox TxtSPI_ID;
        public System.Windows.Forms.TextBox TxtSPI_Value;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem saveSPIToolStripMenuItem;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.CheckBox checkBox2;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.CheckBox checkBox3;
        public System.Windows.Forms.CheckBox checkBox4;
        public System.Windows.Forms.TextBox TxtSPI_Type;
        public System.Windows.Forms.TextBox TxtSPI_Description;
        public System.Windows.Forms.TextBox TxtSPI_Inform;
        public System.Windows.Forms.TextBox Txt_SPI_Manage;
        public System.Windows.Forms.TextBox Txt_SPI_Unit;
        public System.Windows.Forms.TextBox TxtSPI_Calc;
        public System.Windows.Forms.ToolStripMenuItem createNewSPIToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem importTemplateSPIToolStripMenuItem;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox TxtSPI_Value_Current;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox TxtSPI_Value_Target;
        public System.Windows.Forms.TextBox TxtProgressPercent;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.Panel PanelPlot;
    }
}