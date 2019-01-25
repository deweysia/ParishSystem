namespace ParishSystem
{
    partial class BloodlettingReports_Module
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bloodlettingreports_panel = new System.Windows.Forms.Panel();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.filterButton = new System.Windows.Forms.Button();
            this.PreviewButton = new System.Windows.Forms.Button();
            this.SaveExcelButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.from_label = new System.Windows.Forms.Label();
            this.from_bloodlettingeventreport_dtp = new System.Windows.Forms.DateTimePicker();
            this.to_label = new System.Windows.Forms.Label();
            this.to_bloodlettingeventreport_dtp = new System.Windows.Forms.DateTimePicker();
            this.event_label = new System.Windows.Forms.Label();
            this.bloodlettingeventreport_combobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.filterBy_combobox_bloodletting = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.summary_dgv_bloodletting = new System.Windows.Forms.DataGridView();
            this.bloodlettingeventreport_datagridview = new System.Windows.Forms.DataGridView();
            this.open_button = new System.Windows.Forms.Button();
            this.generateReport_button = new System.Windows.Forms.Button();
            this.animation = new System.Windows.Forms.Timer(this.components);
            this.panelOpen = new System.Windows.Forms.Timer(this.components);
            this.bloodlettingreports_panel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.summary_dgv_bloodletting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bloodlettingeventreport_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // bloodlettingreports_panel
            // 
            this.bloodlettingreports_panel.BackColor = System.Drawing.Color.White;
            this.bloodlettingreports_panel.Controls.Add(this.filterPanel);
            this.bloodlettingreports_panel.Controls.Add(this.label8);
            this.bloodlettingreports_panel.Controls.Add(this.summary_dgv_bloodletting);
            this.bloodlettingreports_panel.Controls.Add(this.bloodlettingeventreport_datagridview);
            this.bloodlettingreports_panel.Controls.Add(this.open_button);
            this.bloodlettingreports_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bloodlettingreports_panel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bloodlettingreports_panel.Location = new System.Drawing.Point(0, 0);
            this.bloodlettingreports_panel.Name = "bloodlettingreports_panel";
            this.bloodlettingreports_panel.Size = new System.Drawing.Size(943, 669);
            this.bloodlettingreports_panel.TabIndex = 37;
            this.bloodlettingreports_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.bloodlettingreports_panel_Paint);
            // 
            // filterPanel
            // 
            this.filterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filterPanel.Controls.Add(this.filterButton);
            this.filterPanel.Controls.Add(this.PreviewButton);
            this.filterPanel.Controls.Add(this.SaveExcelButton);
            this.filterPanel.Controls.Add(this.flowLayoutPanel1);
            this.filterPanel.Controls.Add(this.label3);
            this.filterPanel.Controls.Add(this.generateReport_button);
            this.filterPanel.Controls.Add(this.filterBy_combobox_bloodletting);
            this.filterPanel.Location = new System.Drawing.Point(552, 77);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(340, 34);
            this.filterPanel.TabIndex = 41;
            // 
            // filterButton
            // 
            this.filterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.filterButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.filterButton.FlatAppearance.BorderSize = 0;
            this.filterButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.filterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filterButton.ForeColor = System.Drawing.Color.White;
            this.filterButton.Location = new System.Drawing.Point(0, -1);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(338, 33);
            this.filterButton.TabIndex = 78;
            this.filterButton.Tag = "o";
            this.filterButton.Text = "View Options";
            this.filterButton.UseVisualStyleBackColor = false;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // PreviewButton
            // 
            this.PreviewButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PreviewButton.Enabled = false;
            this.PreviewButton.FlatAppearance.BorderSize = 0;
            this.PreviewButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PreviewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewButton.ForeColor = System.Drawing.Color.White;
            this.PreviewButton.Location = new System.Drawing.Point(13, 180);
            this.PreviewButton.Name = "PreviewButton";
            this.PreviewButton.Size = new System.Drawing.Size(158, 34);
            this.PreviewButton.TabIndex = 77;
            this.PreviewButton.Text = "Export as Excel";
            this.PreviewButton.UseVisualStyleBackColor = false;
            this.PreviewButton.Click += new System.EventHandler(this.PreviewButton_Click);
            // 
            // SaveExcelButton
            // 
            this.SaveExcelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SaveExcelButton.Enabled = false;
            this.SaveExcelButton.FlatAppearance.BorderSize = 0;
            this.SaveExcelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SaveExcelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveExcelButton.ForeColor = System.Drawing.Color.White;
            this.SaveExcelButton.Location = new System.Drawing.Point(179, 180);
            this.SaveExcelButton.Name = "SaveExcelButton";
            this.SaveExcelButton.Size = new System.Drawing.Size(158, 34);
            this.SaveExcelButton.TabIndex = 76;
            this.SaveExcelButton.Text = "Quick Save";
            this.SaveExcelButton.UseVisualStyleBackColor = false;
            this.SaveExcelButton.Click += new System.EventHandler(this.SaveExcelButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.from_label);
            this.flowLayoutPanel1.Controls.Add(this.from_bloodlettingeventreport_dtp);
            this.flowLayoutPanel1.Controls.Add(this.to_label);
            this.flowLayoutPanel1.Controls.Add(this.to_bloodlettingeventreport_dtp);
            this.flowLayoutPanel1.Controls.Add(this.event_label);
            this.flowLayoutPanel1.Controls.Add(this.bloodlettingeventreport_combobox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(14, 39);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(324, 95);
            this.flowLayoutPanel1.TabIndex = 42;
            // 
            // from_label
            // 
            this.from_label.AutoSize = true;
            this.from_label.Location = new System.Drawing.Point(0, 10);
            this.from_label.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.from_label.Name = "from_label";
            this.from_label.Size = new System.Drawing.Size(47, 21);
            this.from_label.TabIndex = 9;
            this.from_label.Text = "From";
            // 
            // from_bloodlettingeventreport_dtp
            // 
            this.from_bloodlettingeventreport_dtp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.from_bloodlettingeventreport_dtp.Location = new System.Drawing.Point(47, 10);
            this.from_bloodlettingeventreport_dtp.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.from_bloodlettingeventreport_dtp.Name = "from_bloodlettingeventreport_dtp";
            this.from_bloodlettingeventreport_dtp.Size = new System.Drawing.Size(277, 29);
            this.from_bloodlettingeventreport_dtp.TabIndex = 2;
            this.from_bloodlettingeventreport_dtp.Visible = false;
            this.from_bloodlettingeventreport_dtp.ValueChanged += new System.EventHandler(this.from_bloodlettingeventreport_dtp_ValueChanged);
            // 
            // to_label
            // 
            this.to_label.AutoSize = true;
            this.to_label.Location = new System.Drawing.Point(0, 59);
            this.to_label.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.to_label.Name = "to_label";
            this.to_label.Size = new System.Drawing.Size(49, 21);
            this.to_label.TabIndex = 10;
            this.to_label.Text = "     To ";
            // 
            // to_bloodlettingeventreport_dtp
            // 
            this.to_bloodlettingeventreport_dtp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.to_bloodlettingeventreport_dtp.Enabled = false;
            this.to_bloodlettingeventreport_dtp.Location = new System.Drawing.Point(49, 59);
            this.to_bloodlettingeventreport_dtp.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.to_bloodlettingeventreport_dtp.Name = "to_bloodlettingeventreport_dtp";
            this.to_bloodlettingeventreport_dtp.Size = new System.Drawing.Size(275, 29);
            this.to_bloodlettingeventreport_dtp.TabIndex = 4;
            this.to_bloodlettingeventreport_dtp.Visible = false;
            this.to_bloodlettingeventreport_dtp.ValueChanged += new System.EventHandler(this.to_bloodlettingeventreport_dtp_ValueChanged);
            // 
            // event_label
            // 
            this.event_label.AutoSize = true;
            this.event_label.Location = new System.Drawing.Point(0, 108);
            this.event_label.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.event_label.Name = "event_label";
            this.event_label.Size = new System.Drawing.Size(48, 21);
            this.event_label.TabIndex = 8;
            this.event_label.Text = "Event";
            // 
            // bloodlettingeventreport_combobox
            // 
            this.bloodlettingeventreport_combobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bloodlettingeventreport_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bloodlettingeventreport_combobox.FormattingEnabled = true;
            this.bloodlettingeventreport_combobox.Location = new System.Drawing.Point(48, 108);
            this.bloodlettingeventreport_combobox.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.bloodlettingeventreport_combobox.Name = "bloodlettingeventreport_combobox";
            this.bloodlettingeventreport_combobox.Size = new System.Drawing.Size(274, 29);
            this.bloodlettingeventreport_combobox.TabIndex = 0;
            this.bloodlettingeventreport_combobox.Visible = false;
            this.bloodlettingeventreport_combobox.SelectedIndexChanged += new System.EventHandler(this.bloodlettingeventreport_combobox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "Filter By";
            // 
            // filterBy_combobox_bloodletting
            // 
            this.filterBy_combobox_bloodletting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.filterBy_combobox_bloodletting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterBy_combobox_bloodletting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filterBy_combobox_bloodletting.FormattingEnabled = true;
            this.filterBy_combobox_bloodletting.Items.AddRange(new object[] {
            "Donations on Event",
            "Donations on Date",
            "Donations between Dates",
            "All Blood Donations",
            "All Blood Donors"});
            this.filterBy_combobox_bloodletting.Location = new System.Drawing.Point(91, 10);
            this.filterBy_combobox_bloodletting.Margin = new System.Windows.Forms.Padding(10);
            this.filterBy_combobox_bloodletting.Name = "filterBy_combobox_bloodletting";
            this.filterBy_combobox_bloodletting.Size = new System.Drawing.Size(246, 29);
            this.filterBy_combobox_bloodletting.TabIndex = 5;
            this.filterBy_combobox_bloodletting.SelectedIndexChanged += new System.EventHandler(this.filterBy_combobox_bloodletting_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(27, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(277, 32);
            this.label8.TabIndex = 40;
            this.label8.Text = "Blood Donation Reports";
            // 
            // summary_dgv_bloodletting
            // 
            this.summary_dgv_bloodletting.AllowUserToAddRows = false;
            this.summary_dgv_bloodletting.AllowUserToDeleteRows = false;
            this.summary_dgv_bloodletting.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.summary_dgv_bloodletting.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.summary_dgv_bloodletting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.summary_dgv_bloodletting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.summary_dgv_bloodletting.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.summary_dgv_bloodletting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.summary_dgv_bloodletting.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.summary_dgv_bloodletting.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.summary_dgv_bloodletting.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.summary_dgv_bloodletting.ColumnHeadersHeight = 40;
            this.summary_dgv_bloodletting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.summary_dgv_bloodletting.DefaultCellStyle = dataGridViewCellStyle3;
            this.summary_dgv_bloodletting.EnableHeadersVisualStyles = false;
            this.summary_dgv_bloodletting.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.summary_dgv_bloodletting.Location = new System.Drawing.Point(45, 117);
            this.summary_dgv_bloodletting.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.summary_dgv_bloodletting.MultiSelect = false;
            this.summary_dgv_bloodletting.Name = "summary_dgv_bloodletting";
            this.summary_dgv_bloodletting.ReadOnly = true;
            this.summary_dgv_bloodletting.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.summary_dgv_bloodletting.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.summary_dgv_bloodletting.RowHeadersVisible = false;
            this.summary_dgv_bloodletting.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.summary_dgv_bloodletting.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.summary_dgv_bloodletting.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.summary_dgv_bloodletting.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.summary_dgv_bloodletting.RowTemplate.Height = 35;
            this.summary_dgv_bloodletting.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.summary_dgv_bloodletting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.summary_dgv_bloodletting.Size = new System.Drawing.Size(485, 0);
            this.summary_dgv_bloodletting.TabIndex = 6;
            this.summary_dgv_bloodletting.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.summary_dgv_bloodletting_CellContentDoubleClick);
            // 
            // bloodlettingeventreport_datagridview
            // 
            this.bloodlettingeventreport_datagridview.AllowUserToAddRows = false;
            this.bloodlettingeventreport_datagridview.AllowUserToDeleteRows = false;
            this.bloodlettingeventreport_datagridview.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bloodlettingeventreport_datagridview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.bloodlettingeventreport_datagridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bloodlettingeventreport_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bloodlettingeventreport_datagridview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bloodlettingeventreport_datagridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bloodlettingeventreport_datagridview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.bloodlettingeventreport_datagridview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bloodlettingeventreport_datagridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.bloodlettingeventreport_datagridview.ColumnHeadersHeight = 40;
            this.bloodlettingeventreport_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bloodlettingeventreport_datagridview.DefaultCellStyle = dataGridViewCellStyle7;
            this.bloodlettingeventreport_datagridview.EnableHeadersVisualStyles = false;
            this.bloodlettingeventreport_datagridview.GridColor = System.Drawing.Color.White;
            this.bloodlettingeventreport_datagridview.Location = new System.Drawing.Point(45, 140);
            this.bloodlettingeventreport_datagridview.MultiSelect = false;
            this.bloodlettingeventreport_datagridview.Name = "bloodlettingeventreport_datagridview";
            this.bloodlettingeventreport_datagridview.ReadOnly = true;
            this.bloodlettingeventreport_datagridview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bloodlettingeventreport_datagridview.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.bloodlettingeventreport_datagridview.RowHeadersVisible = false;
            this.bloodlettingeventreport_datagridview.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bloodlettingeventreport_datagridview.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.bloodlettingeventreport_datagridview.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.bloodlettingeventreport_datagridview.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.bloodlettingeventreport_datagridview.RowTemplate.Height = 35;
            this.bloodlettingeventreport_datagridview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.bloodlettingeventreport_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bloodlettingeventreport_datagridview.Size = new System.Drawing.Size(855, 483);
            this.bloodlettingeventreport_datagridview.TabIndex = 1;
            this.bloodlettingeventreport_datagridview.DataSourceChanged += new System.EventHandler(this.bloodlettingeventreport_datagridview_DataSourceChanged);
            this.bloodlettingeventreport_datagridview.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bloodlettingeventreport_datagridview_CellContentDoubleClick);
            // 
            // open_button
            // 
            this.open_button.BackColor = System.Drawing.Color.White;
            this.open_button.FlatAppearance.BorderSize = 0;
            this.open_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.open_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.open_button.ForeColor = System.Drawing.Color.White;
            this.open_button.Image = global::ParishSystem.Properties.Resources.icons8_Expand_Arrow_20;
            this.open_button.Location = new System.Drawing.Point(45, 82);
            this.open_button.Name = "open_button";
            this.open_button.Size = new System.Drawing.Size(34, 29);
            this.open_button.TabIndex = 8;
            this.open_button.UseVisualStyleBackColor = false;
            this.open_button.Click += new System.EventHandler(this.open_button_Click);
            // 
            // generateReport_button
            // 
            this.generateReport_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.generateReport_button.FlatAppearance.BorderSize = 0;
            this.generateReport_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.generateReport_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateReport_button.ForeColor = System.Drawing.Color.White;
            this.generateReport_button.Location = new System.Drawing.Point(0, 140);
            this.generateReport_button.Name = "generateReport_button";
            this.generateReport_button.Size = new System.Drawing.Size(340, 34);
            this.generateReport_button.TabIndex = 7;
            this.generateReport_button.Text = "Generate";
            this.generateReport_button.UseVisualStyleBackColor = false;
            this.generateReport_button.Click += new System.EventHandler(this.generateReport_button_Click);
            // 
            // animation
            // 
            this.animation.Interval = 1;
            this.animation.Tick += new System.EventHandler(this.animation_Tick);
            // 
            // panelOpen
            // 
            this.panelOpen.Interval = 1;
            this.panelOpen.Tick += new System.EventHandler(this.panelOpen_Tick);
            // 
            // BloodlettingReports_Module
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 669);
            this.Controls.Add(this.bloodlettingreports_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BloodlettingReports_Module";
            this.Text = "CashReports_Module";
            this.Load += new System.EventHandler(this.BloodlettingReports_Module_Load);
            this.VisibleChanged += new System.EventHandler(this.BloodlettingReports_Module_VisibleChanged);
            this.bloodlettingreports_panel.ResumeLayout(false);
            this.bloodlettingreports_panel.PerformLayout();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.summary_dgv_bloodletting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bloodlettingeventreport_datagridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bloodlettingreports_panel;
        private System.Windows.Forms.DataGridView summary_dgv_bloodletting;
        private System.Windows.Forms.ComboBox filterBy_combobox_bloodletting;
        private System.Windows.Forms.DateTimePicker to_bloodlettingeventreport_dtp;
        private System.Windows.Forms.DateTimePicker from_bloodlettingeventreport_dtp;
        private System.Windows.Forms.DataGridView bloodlettingeventreport_datagridview;
        private System.Windows.Forms.ComboBox bloodlettingeventreport_combobox;
        private System.Windows.Forms.Button generateReport_button;
        private System.Windows.Forms.Button open_button;
        private System.Windows.Forms.Timer animation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label event_label;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label from_label;
        private System.Windows.Forms.Label to_label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button PreviewButton;
        private System.Windows.Forms.Button SaveExcelButton;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Timer panelOpen;
    }
}