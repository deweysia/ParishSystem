namespace ParishSystem
{
    partial class CashReport_Module
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Reports_panel = new System.Windows.Forms.Panel();
            this.reportFilter_panel = new System.Windows.Forms.Panel();
            this.Open_button = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.input_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.date_pnl = new System.Windows.Forms.Panel();
            this.date_lbl = new System.Windows.Forms.Label();
            this.from_lbl = new System.Windows.Forms.Label();
            this.to_dtp_cashdisbursment = new System.Windows.Forms.DateTimePicker();
            this.to_lbl = new System.Windows.Forms.Label();
            this.from_dtp_cashdisbursment = new System.Windows.Forms.DateTimePicker();
            this.OR_lbl = new System.Windows.Forms.Label();
            this.searchbar_textbox_report_disbursment = new System.Windows.Forms.TextBox();
            this.CV_lbl = new System.Windows.Forms.Label();
            this.CV_textbox_report_disbursment = new System.Windows.Forms.TextBox();
            this.CN_lbl = new System.Windows.Forms.Label();
            this.CN_textbox_report_disbursment = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label41 = new System.Windows.Forms.Label();
            this.breakdown_radiobutton_cashdisbursment = new System.Windows.Forms.RadioButton();
            this.total_radiobutton_cashdisbursment = new System.Windows.Forms.RadioButton();
            this.panel10 = new System.Windows.Forms.Panel();
            this.grouped_radiobutton_cashdisbursment = new System.Windows.Forms.RadioButton();
            this.notGrouped_radiobutton_cashdisbursment = new System.Windows.Forms.RadioButton();
            this.label42 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.filterBy_combobox_disbursment = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.report_datagridview_cashdisbursment = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.summary_datagridview_report_disbursment = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Reports_panel.SuspendLayout();
            this.reportFilter_panel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.input_panel.SuspendLayout();
            this.date_pnl.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report_datagridview_cashdisbursment)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.summary_datagridview_report_disbursment)).BeginInit();
            this.SuspendLayout();
            // 
            // Reports_panel
            // 
            this.Reports_panel.BackColor = System.Drawing.Color.White;
            this.Reports_panel.Controls.Add(this.reportFilter_panel);
            this.Reports_panel.Controls.Add(this.tabControl1);
            this.Reports_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Reports_panel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reports_panel.Location = new System.Drawing.Point(0, 0);
            this.Reports_panel.Name = "Reports_panel";
            this.Reports_panel.Size = new System.Drawing.Size(935, 547);
            this.Reports_panel.TabIndex = 13;
            // 
            // reportFilter_panel
            // 
            this.reportFilter_panel.BackColor = System.Drawing.Color.White;
            this.reportFilter_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reportFilter_panel.Controls.Add(this.Open_button);
            this.reportFilter_panel.Controls.Add(this.flowLayoutPanel1);
            this.reportFilter_panel.Controls.Add(this.button1);
            this.reportFilter_panel.Controls.Add(this.label23);
            this.reportFilter_panel.Controls.Add(this.filterBy_combobox_disbursment);
            this.reportFilter_panel.Location = new System.Drawing.Point(542, 21);
            this.reportFilter_panel.Name = "reportFilter_panel";
            this.reportFilter_panel.Size = new System.Drawing.Size(368, 34);
            this.reportFilter_panel.TabIndex = 18;
            // 
            // Open_button
            // 
            this.Open_button.BackColor = System.Drawing.Color.Gray;
            this.Open_button.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Open_button.FlatAppearance.BorderSize = 0;
            this.Open_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Open_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Open_button.ForeColor = System.Drawing.Color.White;
            this.Open_button.Location = new System.Drawing.Point(0, -2);
            this.Open_button.Name = "Open_button";
            this.Open_button.Size = new System.Drawing.Size(366, 34);
            this.Open_button.TabIndex = 19;
            this.Open_button.Text = "Filter";
            this.Open_button.UseVisualStyleBackColor = false;
            this.Open_button.Click += new System.EventHandler(this.Open_button_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.input_panel);
            this.flowLayoutPanel1.Controls.Add(this.panel11);
            this.flowLayoutPanel1.Controls.Add(this.panel10);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(14, 53);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(349, 168);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // input_panel
            // 
            this.input_panel.Controls.Add(this.date_pnl);
            this.input_panel.Controls.Add(this.OR_lbl);
            this.input_panel.Controls.Add(this.searchbar_textbox_report_disbursment);
            this.input_panel.Controls.Add(this.CV_lbl);
            this.input_panel.Controls.Add(this.CV_textbox_report_disbursment);
            this.input_panel.Controls.Add(this.CN_lbl);
            this.input_panel.Controls.Add(this.CN_textbox_report_disbursment);
            this.input_panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.input_panel.Location = new System.Drawing.Point(3, 3);
            this.input_panel.Name = "input_panel";
            this.input_panel.Size = new System.Drawing.Size(338, 65);
            this.input_panel.TabIndex = 16;
            // 
            // date_pnl
            // 
            this.date_pnl.Controls.Add(this.date_lbl);
            this.date_pnl.Controls.Add(this.from_lbl);
            this.date_pnl.Controls.Add(this.to_dtp_cashdisbursment);
            this.date_pnl.Controls.Add(this.to_lbl);
            this.date_pnl.Controls.Add(this.from_dtp_cashdisbursment);
            this.date_pnl.Location = new System.Drawing.Point(3, 3);
            this.date_pnl.Name = "date_pnl";
            this.date_pnl.Size = new System.Drawing.Size(335, 62);
            this.date_pnl.TabIndex = 19;
            // 
            // date_lbl
            // 
            this.date_lbl.AutoSize = true;
            this.date_lbl.Location = new System.Drawing.Point(8, 0);
            this.date_lbl.Name = "date_lbl";
            this.date_lbl.Size = new System.Drawing.Size(42, 21);
            this.date_lbl.TabIndex = 25;
            this.date_lbl.Text = "Date";
            // 
            // from_lbl
            // 
            this.from_lbl.AutoSize = true;
            this.from_lbl.Location = new System.Drawing.Point(3, 2);
            this.from_lbl.Name = "from_lbl";
            this.from_lbl.Size = new System.Drawing.Size(47, 21);
            this.from_lbl.TabIndex = 19;
            this.from_lbl.Text = "From";
            // 
            // to_dtp_cashdisbursment
            // 
            this.to_dtp_cashdisbursment.CustomFormat = "MM/dd/yyyy";
            this.to_dtp_cashdisbursment.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.to_dtp_cashdisbursment.Location = new System.Drawing.Point(173, 24);
            this.to_dtp_cashdisbursment.Name = "to_dtp_cashdisbursment";
            this.to_dtp_cashdisbursment.Size = new System.Drawing.Size(157, 29);
            this.to_dtp_cashdisbursment.TabIndex = 18;
            this.to_dtp_cashdisbursment.Visible = false;
            // 
            // to_lbl
            // 
            this.to_lbl.AutoSize = true;
            this.to_lbl.Location = new System.Drawing.Point(174, 2);
            this.to_lbl.Name = "to_lbl";
            this.to_lbl.Size = new System.Drawing.Size(25, 21);
            this.to_lbl.TabIndex = 21;
            this.to_lbl.Text = "To";
            // 
            // from_dtp_cashdisbursment
            // 
            this.from_dtp_cashdisbursment.CustomFormat = "MM/dd/yyyy";
            this.from_dtp_cashdisbursment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.from_dtp_cashdisbursment.Location = new System.Drawing.Point(7, 26);
            this.from_dtp_cashdisbursment.Name = "from_dtp_cashdisbursment";
            this.from_dtp_cashdisbursment.Size = new System.Drawing.Size(157, 29);
            this.from_dtp_cashdisbursment.TabIndex = 17;
            this.from_dtp_cashdisbursment.Visible = false;
            // 
            // OR_lbl
            // 
            this.OR_lbl.AutoSize = true;
            this.OR_lbl.Location = new System.Drawing.Point(344, 0);
            this.OR_lbl.Name = "OR_lbl";
            this.OR_lbl.Size = new System.Drawing.Size(94, 21);
            this.OR_lbl.TabIndex = 22;
            this.OR_lbl.Text = "OR Number";
            // 
            // searchbar_textbox_report_disbursment
            // 
            this.searchbar_textbox_report_disbursment.Location = new System.Drawing.Point(344, 24);
            this.searchbar_textbox_report_disbursment.Name = "searchbar_textbox_report_disbursment";
            this.searchbar_textbox_report_disbursment.Size = new System.Drawing.Size(335, 29);
            this.searchbar_textbox_report_disbursment.TabIndex = 12;
            this.searchbar_textbox_report_disbursment.Visible = false;
            // 
            // CV_lbl
            // 
            this.CV_lbl.AutoSize = true;
            this.CV_lbl.Location = new System.Drawing.Point(685, 0);
            this.CV_lbl.Name = "CV_lbl";
            this.CV_lbl.Size = new System.Drawing.Size(92, 21);
            this.CV_lbl.TabIndex = 23;
            this.CV_lbl.Text = "CV Number";
            // 
            // CV_textbox_report_disbursment
            // 
            this.CV_textbox_report_disbursment.Location = new System.Drawing.Point(685, 24);
            this.CV_textbox_report_disbursment.Name = "CV_textbox_report_disbursment";
            this.CV_textbox_report_disbursment.Size = new System.Drawing.Size(335, 29);
            this.CV_textbox_report_disbursment.TabIndex = 19;
            this.CV_textbox_report_disbursment.Visible = false;
            // 
            // CN_lbl
            // 
            this.CN_lbl.AutoSize = true;
            this.CN_lbl.Location = new System.Drawing.Point(1026, 0);
            this.CN_lbl.Name = "CN_lbl";
            this.CN_lbl.Size = new System.Drawing.Size(114, 21);
            this.CN_lbl.TabIndex = 24;
            this.CN_lbl.Text = "Check Number";
            // 
            // CN_textbox_report_disbursment
            // 
            this.CN_textbox_report_disbursment.Location = new System.Drawing.Point(1026, 24);
            this.CN_textbox_report_disbursment.Name = "CN_textbox_report_disbursment";
            this.CN_textbox_report_disbursment.Size = new System.Drawing.Size(335, 29);
            this.CN_textbox_report_disbursment.TabIndex = 20;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.label41);
            this.panel11.Controls.Add(this.breakdown_radiobutton_cashdisbursment);
            this.panel11.Controls.Add(this.total_radiobutton_cashdisbursment);
            this.panel11.ForeColor = System.Drawing.Color.Black;
            this.panel11.Location = new System.Drawing.Point(3, 74);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(336, 41);
            this.panel11.TabIndex = 17;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.ForeColor = System.Drawing.Color.Black;
            this.label41.Location = new System.Drawing.Point(2, 10);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(60, 21);
            this.label41.TabIndex = 18;
            this.label41.Text = "Format";
            // 
            // breakdown_radiobutton_cashdisbursment
            // 
            this.breakdown_radiobutton_cashdisbursment.AutoSize = true;
            this.breakdown_radiobutton_cashdisbursment.ForeColor = System.Drawing.Color.Black;
            this.breakdown_radiobutton_cashdisbursment.Location = new System.Drawing.Point(107, 10);
            this.breakdown_radiobutton_cashdisbursment.Name = "breakdown_radiobutton_cashdisbursment";
            this.breakdown_radiobutton_cashdisbursment.Size = new System.Drawing.Size(106, 25);
            this.breakdown_radiobutton_cashdisbursment.TabIndex = 17;
            this.breakdown_radiobutton_cashdisbursment.Text = "Breakdown";
            this.breakdown_radiobutton_cashdisbursment.UseVisualStyleBackColor = true;
            // 
            // total_radiobutton_cashdisbursment
            // 
            this.total_radiobutton_cashdisbursment.AutoSize = true;
            this.total_radiobutton_cashdisbursment.Checked = true;
            this.total_radiobutton_cashdisbursment.ForeColor = System.Drawing.Color.Black;
            this.total_radiobutton_cashdisbursment.Location = new System.Drawing.Point(249, 10);
            this.total_radiobutton_cashdisbursment.Name = "total_radiobutton_cashdisbursment";
            this.total_radiobutton_cashdisbursment.Size = new System.Drawing.Size(60, 25);
            this.total_radiobutton_cashdisbursment.TabIndex = 17;
            this.total_radiobutton_cashdisbursment.TabStop = true;
            this.total_radiobutton_cashdisbursment.Text = "Total";
            this.total_radiobutton_cashdisbursment.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.grouped_radiobutton_cashdisbursment);
            this.panel10.Controls.Add(this.notGrouped_radiobutton_cashdisbursment);
            this.panel10.Controls.Add(this.label42);
            this.panel10.ForeColor = System.Drawing.Color.Black;
            this.panel10.Location = new System.Drawing.Point(3, 121);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(336, 40);
            this.panel10.TabIndex = 16;
            // 
            // grouped_radiobutton_cashdisbursment
            // 
            this.grouped_radiobutton_cashdisbursment.AutoSize = true;
            this.grouped_radiobutton_cashdisbursment.ForeColor = System.Drawing.Color.Black;
            this.grouped_radiobutton_cashdisbursment.Location = new System.Drawing.Point(107, 8);
            this.grouped_radiobutton_cashdisbursment.Name = "grouped_radiobutton_cashdisbursment";
            this.grouped_radiobutton_cashdisbursment.Size = new System.Drawing.Size(51, 25);
            this.grouped_radiobutton_cashdisbursment.TabIndex = 20;
            this.grouped_radiobutton_cashdisbursment.Text = "Yes";
            this.grouped_radiobutton_cashdisbursment.UseVisualStyleBackColor = true;
            // 
            // notGrouped_radiobutton_cashdisbursment
            // 
            this.notGrouped_radiobutton_cashdisbursment.AutoSize = true;
            this.notGrouped_radiobutton_cashdisbursment.Checked = true;
            this.notGrouped_radiobutton_cashdisbursment.ForeColor = System.Drawing.Color.Black;
            this.notGrouped_radiobutton_cashdisbursment.Location = new System.Drawing.Point(249, 8);
            this.notGrouped_radiobutton_cashdisbursment.Name = "notGrouped_radiobutton_cashdisbursment";
            this.notGrouped_radiobutton_cashdisbursment.Size = new System.Drawing.Size(49, 25);
            this.notGrouped_radiobutton_cashdisbursment.TabIndex = 21;
            this.notGrouped_radiobutton_cashdisbursment.TabStop = true;
            this.notGrouped_radiobutton_cashdisbursment.Text = "No";
            this.notGrouped_radiobutton_cashdisbursment.UseVisualStyleBackColor = true;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.ForeColor = System.Drawing.Color.Black;
            this.label42.Location = new System.Drawing.Point(3, 8);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(71, 21);
            this.label42.TabIndex = 19;
            this.label42.Text = "Grouped";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(49, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(277, 30);
            this.button1.TabIndex = 18;
            this.button1.Text = "Generate Report";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.generate_report);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(16, 20);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(66, 21);
            this.label23.TabIndex = 15;
            this.label23.Text = "Filter By";
            // 
            // filterBy_combobox_disbursment
            // 
            this.filterBy_combobox_disbursment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterBy_combobox_disbursment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filterBy_combobox_disbursment.ForeColor = System.Drawing.Color.Black;
            this.filterBy_combobox_disbursment.FormattingEnabled = true;
            this.filterBy_combobox_disbursment.Items.AddRange(new object[] {
            "Recent",
            "Day",
            "Month",
            "Year",
            "Date Range"});
            this.filterBy_combobox_disbursment.Location = new System.Drawing.Point(124, 17);
            this.filterBy_combobox_disbursment.Name = "filterBy_combobox_disbursment";
            this.filterBy_combobox_disbursment.Size = new System.Drawing.Size(234, 29);
            this.filterBy_combobox_disbursment.TabIndex = 13;
            this.filterBy_combobox_disbursment.SelectedIndexChanged += new System.EventHandler(this.filterBy_combobox_disbursment_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(23, 56);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(889, 473);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.report_datagridview_cashdisbursment);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(881, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "   Report   ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // report_datagridview_cashdisbursment
            // 
            this.report_datagridview_cashdisbursment.AllowUserToAddRows = false;
            this.report_datagridview_cashdisbursment.AllowUserToDeleteRows = false;
            this.report_datagridview_cashdisbursment.AllowUserToResizeRows = false;
            this.report_datagridview_cashdisbursment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.report_datagridview_cashdisbursment.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.report_datagridview_cashdisbursment.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.report_datagridview_cashdisbursment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.report_datagridview_cashdisbursment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.report_datagridview_cashdisbursment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.report_datagridview_cashdisbursment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.report_datagridview_cashdisbursment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.report_datagridview_cashdisbursment.GridColor = System.Drawing.Color.White;
            this.report_datagridview_cashdisbursment.Location = new System.Drawing.Point(3, 3);
            this.report_datagridview_cashdisbursment.Name = "report_datagridview_cashdisbursment";
            this.report_datagridview_cashdisbursment.ReadOnly = true;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.report_datagridview_cashdisbursment.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.report_datagridview_cashdisbursment.RowHeadersVisible = false;
            this.report_datagridview_cashdisbursment.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.report_datagridview_cashdisbursment.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.report_datagridview_cashdisbursment.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.report_datagridview_cashdisbursment.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.report_datagridview_cashdisbursment.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.report_datagridview_cashdisbursment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.report_datagridview_cashdisbursment.Size = new System.Drawing.Size(875, 433);
            this.report_datagridview_cashdisbursment.TabIndex = 0;
            this.report_datagridview_cashdisbursment.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.breakdown_datagridview_report_disbursment_CellContentDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.summary_datagridview_report_disbursment);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(881, 439);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "   Summary    ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // summary_datagridview_report_disbursment
            // 
            this.summary_datagridview_report_disbursment.AllowUserToAddRows = false;
            this.summary_datagridview_report_disbursment.AllowUserToDeleteRows = false;
            this.summary_datagridview_report_disbursment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.summary_datagridview_report_disbursment.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.summary_datagridview_report_disbursment.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.summary_datagridview_report_disbursment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.summary_datagridview_report_disbursment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.summary_datagridview_report_disbursment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this.summary_datagridview_report_disbursment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.summary_datagridview_report_disbursment.DefaultCellStyle = dataGridViewCellStyle29;
            this.summary_datagridview_report_disbursment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.summary_datagridview_report_disbursment.Location = new System.Drawing.Point(3, 3);
            this.summary_datagridview_report_disbursment.Name = "summary_datagridview_report_disbursment";
            this.summary_datagridview_report_disbursment.ReadOnly = true;
            this.summary_datagridview_report_disbursment.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.summary_datagridview_report_disbursment.RowHeadersDefaultCellStyle = dataGridViewCellStyle30;
            this.summary_datagridview_report_disbursment.RowHeadersVisible = false;
            this.summary_datagridview_report_disbursment.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.summary_datagridview_report_disbursment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.summary_datagridview_report_disbursment.Size = new System.Drawing.Size(875, 433);
            this.summary_datagridview_report_disbursment.TabIndex = 16;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CashReport_Module
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 547);
            this.Controls.Add(this.Reports_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CashReport_Module";
            this.Text = "CashReport_Module";
            this.Reports_panel.ResumeLayout(false);
            this.reportFilter_panel.ResumeLayout(false);
            this.reportFilter_panel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.input_panel.ResumeLayout(false);
            this.input_panel.PerformLayout();
            this.date_pnl.ResumeLayout(false);
            this.date_pnl.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.report_datagridview_cashdisbursment)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.summary_datagridview_report_disbursment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Reports_panel;
        private System.Windows.Forms.FlowLayoutPanel input_panel;
        private System.Windows.Forms.DateTimePicker from_dtp_cashdisbursment;
        private System.Windows.Forms.DateTimePicker to_dtp_cashdisbursment;
        private System.Windows.Forms.TextBox searchbar_textbox_report_disbursment;
        private System.Windows.Forms.TextBox CV_textbox_report_disbursment;
        private System.Windows.Forms.TextBox CN_textbox_report_disbursment;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.RadioButton breakdown_radiobutton_cashdisbursment;
        private System.Windows.Forms.RadioButton total_radiobutton_cashdisbursment;
        private System.Windows.Forms.ComboBox filterBy_combobox_disbursment;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.RadioButton grouped_radiobutton_cashdisbursment;
        private System.Windows.Forms.RadioButton notGrouped_radiobutton_cashdisbursment;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView report_datagridview_cashdisbursment;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView summary_datagridview_report_disbursment;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel reportFilter_panel;
        private System.Windows.Forms.Label from_lbl;
        private System.Windows.Forms.Label date_lbl;
        private System.Windows.Forms.Label to_lbl;
        private System.Windows.Forms.Label OR_lbl;
        private System.Windows.Forms.Label CV_lbl;
        private System.Windows.Forms.Label CN_lbl;
        private System.Windows.Forms.Panel date_pnl;
        private System.Windows.Forms.Button Open_button;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}