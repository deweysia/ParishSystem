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
            this.Reports_panel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.from_dtp_cashdisbursment = new System.Windows.Forms.DateTimePicker();
            this.to_dtp_cashdisbursment = new System.Windows.Forms.DateTimePicker();
            this.searchbar_textbox_report_disbursment = new System.Windows.Forms.TextBox();
            this.CV_textbox_report_disbursment = new System.Windows.Forms.TextBox();
            this.CN_textbox_report_disbursment = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label41 = new System.Windows.Forms.Label();
            this.breakdown_radiobutton_cashdisbursment = new System.Windows.Forms.RadioButton();
            this.total_radiobutton_cashdisbursment = new System.Windows.Forms.RadioButton();
            this.filterBy_combobox_disbursment = new System.Windows.Forms.ComboBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.grouped_radiobutton_cashdisbursment = new System.Windows.Forms.RadioButton();
            this.notGrouped_radiobutton_cashdisbursment = new System.Windows.Forms.RadioButton();
            this.label42 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.report_datagridview_cashdisbursment = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.summary_datagridview_report_disbursment = new System.Windows.Forms.DataGridView();
            this.Reports_panel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
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
            this.Reports_panel.Controls.Add(this.panel3);
            this.Reports_panel.Controls.Add(this.tabControl1);
            this.Reports_panel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reports_panel.Location = new System.Drawing.Point(0, 0);
            this.Reports_panel.Name = "Reports_panel";
            this.Reports_panel.Size = new System.Drawing.Size(811, 549);
            this.Reports_panel.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.flowLayoutPanel2);
            this.panel3.Controls.Add(this.panel11);
            this.panel3.Controls.Add(this.filterBy_combobox_disbursment);
            this.panel3.Controls.Add(this.panel10);
            this.panel3.Controls.Add(this.label23);
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(-2, -5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(817, 94);
            this.panel3.TabIndex = 17;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.from_dtp_cashdisbursment);
            this.flowLayoutPanel2.Controls.Add(this.to_dtp_cashdisbursment);
            this.flowLayoutPanel2.Controls.Add(this.searchbar_textbox_report_disbursment);
            this.flowLayoutPanel2.Controls.Add(this.CV_textbox_report_disbursment);
            this.flowLayoutPanel2.Controls.Add(this.CN_textbox_report_disbursment);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(11, 13);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(232, 73);
            this.flowLayoutPanel2.TabIndex = 16;
            // 
            // from_dtp_cashdisbursment
            // 
            this.from_dtp_cashdisbursment.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.from_dtp_cashdisbursment.Location = new System.Drawing.Point(3, 3);
            this.from_dtp_cashdisbursment.Name = "from_dtp_cashdisbursment";
            this.from_dtp_cashdisbursment.Size = new System.Drawing.Size(221, 29);
            this.from_dtp_cashdisbursment.TabIndex = 17;
            this.from_dtp_cashdisbursment.ValueChanged += new System.EventHandler(this.from_dtp_cashdisbursment_ValueChanged);
            // 
            // to_dtp_cashdisbursment
            // 
            this.to_dtp_cashdisbursment.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.to_dtp_cashdisbursment.Location = new System.Drawing.Point(3, 38);
            this.to_dtp_cashdisbursment.Name = "to_dtp_cashdisbursment";
            this.to_dtp_cashdisbursment.Size = new System.Drawing.Size(221, 29);
            this.to_dtp_cashdisbursment.TabIndex = 18;
            this.to_dtp_cashdisbursment.ValueChanged += new System.EventHandler(this.to_dtp_cashdisbursment_ValueChanged);
            // 
            // searchbar_textbox_report_disbursment
            // 
            this.searchbar_textbox_report_disbursment.Location = new System.Drawing.Point(3, 73);
            this.searchbar_textbox_report_disbursment.Name = "searchbar_textbox_report_disbursment";
            this.searchbar_textbox_report_disbursment.Size = new System.Drawing.Size(221, 29);
            this.searchbar_textbox_report_disbursment.TabIndex = 12;
            this.searchbar_textbox_report_disbursment.TextChanged += new System.EventHandler(this.searchbar_textbox_report_disbursment_TextChanged);
            // 
            // CV_textbox_report_disbursment
            // 
            this.CV_textbox_report_disbursment.Location = new System.Drawing.Point(3, 108);
            this.CV_textbox_report_disbursment.Name = "CV_textbox_report_disbursment";
            this.CV_textbox_report_disbursment.Size = new System.Drawing.Size(221, 29);
            this.CV_textbox_report_disbursment.TabIndex = 19;
            this.CV_textbox_report_disbursment.TextChanged += new System.EventHandler(this.CV_textbox_report_disbursment_TextChanged);
            // 
            // CN_textbox_report_disbursment
            // 
            this.CN_textbox_report_disbursment.Location = new System.Drawing.Point(3, 143);
            this.CN_textbox_report_disbursment.Name = "CN_textbox_report_disbursment";
            this.CN_textbox_report_disbursment.Size = new System.Drawing.Size(221, 29);
            this.CN_textbox_report_disbursment.TabIndex = 20;
            this.CN_textbox_report_disbursment.TextChanged += new System.EventHandler(this.CN_textbox_report_disbursment_TextChanged);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.label41);
            this.panel11.Controls.Add(this.breakdown_radiobutton_cashdisbursment);
            this.panel11.Controls.Add(this.total_radiobutton_cashdisbursment);
            this.panel11.ForeColor = System.Drawing.Color.Black;
            this.panel11.Location = new System.Drawing.Point(535, 14);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(261, 41);
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
            this.breakdown_radiobutton_cashdisbursment.Location = new System.Drawing.Point(83, 8);
            this.breakdown_radiobutton_cashdisbursment.Name = "breakdown_radiobutton_cashdisbursment";
            this.breakdown_radiobutton_cashdisbursment.Size = new System.Drawing.Size(106, 25);
            this.breakdown_radiobutton_cashdisbursment.TabIndex = 17;
            this.breakdown_radiobutton_cashdisbursment.Text = "Breakdown";
            this.breakdown_radiobutton_cashdisbursment.UseVisualStyleBackColor = true;
            this.breakdown_radiobutton_cashdisbursment.CheckedChanged += new System.EventHandler(this.breakdown_radiobutton_cashdisbursment_CheckedChanged);
            // 
            // total_radiobutton_cashdisbursment
            // 
            this.total_radiobutton_cashdisbursment.AutoSize = true;
            this.total_radiobutton_cashdisbursment.Checked = true;
            this.total_radiobutton_cashdisbursment.ForeColor = System.Drawing.Color.Black;
            this.total_radiobutton_cashdisbursment.Location = new System.Drawing.Point(194, 8);
            this.total_radiobutton_cashdisbursment.Name = "total_radiobutton_cashdisbursment";
            this.total_radiobutton_cashdisbursment.Size = new System.Drawing.Size(60, 25);
            this.total_radiobutton_cashdisbursment.TabIndex = 17;
            this.total_radiobutton_cashdisbursment.TabStop = true;
            this.total_radiobutton_cashdisbursment.Text = "Total";
            this.total_radiobutton_cashdisbursment.UseVisualStyleBackColor = true;
            this.total_radiobutton_cashdisbursment.CheckedChanged += new System.EventHandler(this.total_radiobutton_cashdisbursment_CheckedChanged);
            // 
            // filterBy_combobox_disbursment
            // 
            this.filterBy_combobox_disbursment.ForeColor = System.Drawing.Color.Black;
            this.filterBy_combobox_disbursment.FormattingEnabled = true;
            this.filterBy_combobox_disbursment.Items.AddRange(new object[] {
            "Recent",
            "Day",
            "Month",
            "Year",
            "Date Range"});
            this.filterBy_combobox_disbursment.Location = new System.Drawing.Point(315, 14);
            this.filterBy_combobox_disbursment.Name = "filterBy_combobox_disbursment";
            this.filterBy_combobox_disbursment.Size = new System.Drawing.Size(203, 29);
            this.filterBy_combobox_disbursment.TabIndex = 13;
            this.filterBy_combobox_disbursment.SelectedIndexChanged += new System.EventHandler(this.filterBy_combobox_disbursment_SelectedIndexChanged);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.grouped_radiobutton_cashdisbursment);
            this.panel10.Controls.Add(this.notGrouped_radiobutton_cashdisbursment);
            this.panel10.Controls.Add(this.label42);
            this.panel10.ForeColor = System.Drawing.Color.Black;
            this.panel10.Location = new System.Drawing.Point(538, 54);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(259, 40);
            this.panel10.TabIndex = 16;
            // 
            // grouped_radiobutton_cashdisbursment
            // 
            this.grouped_radiobutton_cashdisbursment.AutoSize = true;
            this.grouped_radiobutton_cashdisbursment.ForeColor = System.Drawing.Color.Black;
            this.grouped_radiobutton_cashdisbursment.Location = new System.Drawing.Point(81, 7);
            this.grouped_radiobutton_cashdisbursment.Name = "grouped_radiobutton_cashdisbursment";
            this.grouped_radiobutton_cashdisbursment.Size = new System.Drawing.Size(51, 25);
            this.grouped_radiobutton_cashdisbursment.TabIndex = 20;
            this.grouped_radiobutton_cashdisbursment.Text = "Yes";
            this.grouped_radiobutton_cashdisbursment.UseVisualStyleBackColor = true;
            this.grouped_radiobutton_cashdisbursment.CheckedChanged += new System.EventHandler(this.grouped_radiobutton_cashdisbursment_CheckedChanged);
            // 
            // notGrouped_radiobutton_cashdisbursment
            // 
            this.notGrouped_radiobutton_cashdisbursment.AutoSize = true;
            this.notGrouped_radiobutton_cashdisbursment.Checked = true;
            this.notGrouped_radiobutton_cashdisbursment.ForeColor = System.Drawing.Color.Black;
            this.notGrouped_radiobutton_cashdisbursment.Location = new System.Drawing.Point(192, 7);
            this.notGrouped_radiobutton_cashdisbursment.Name = "notGrouped_radiobutton_cashdisbursment";
            this.notGrouped_radiobutton_cashdisbursment.Size = new System.Drawing.Size(49, 25);
            this.notGrouped_radiobutton_cashdisbursment.TabIndex = 21;
            this.notGrouped_radiobutton_cashdisbursment.TabStop = true;
            this.notGrouped_radiobutton_cashdisbursment.Text = "No";
            this.notGrouped_radiobutton_cashdisbursment.UseVisualStyleBackColor = true;
            this.notGrouped_radiobutton_cashdisbursment.CheckedChanged += new System.EventHandler(this.notGrouped_radiobutton_cashdisbursment_CheckedChanged);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.ForeColor = System.Drawing.Color.Black;
            this.label42.Location = new System.Drawing.Point(0, 8);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(71, 21);
            this.label42.TabIndex = 19;
            this.label42.Text = "Grouped";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(249, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(66, 21);
            this.label23.TabIndex = 15;
            this.label23.Text = "Filter By";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(23, 91);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(764, 438);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.report_datagridview_cashdisbursment);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(756, 404);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "   Report   ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // report_datagridview_cashdisbursment
            // 
            this.report_datagridview_cashdisbursment.AllowUserToAddRows = false;
            this.report_datagridview_cashdisbursment.AllowUserToDeleteRows = false;
            this.report_datagridview_cashdisbursment.BackgroundColor = System.Drawing.Color.White;
            this.report_datagridview_cashdisbursment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.report_datagridview_cashdisbursment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.report_datagridview_cashdisbursment.Location = new System.Drawing.Point(3, 3);
            this.report_datagridview_cashdisbursment.Name = "report_datagridview_cashdisbursment";
            this.report_datagridview_cashdisbursment.Size = new System.Drawing.Size(750, 398);
            this.report_datagridview_cashdisbursment.TabIndex = 0;
            this.report_datagridview_cashdisbursment.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.breakdown_datagridview_report_disbursment_CellContentDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.summary_datagridview_report_disbursment);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(756, 404);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "   Summary    ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // summary_datagridview_report_disbursment
            // 
            this.summary_datagridview_report_disbursment.BackgroundColor = System.Drawing.Color.White;
            this.summary_datagridview_report_disbursment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.summary_datagridview_report_disbursment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.summary_datagridview_report_disbursment.Location = new System.Drawing.Point(3, 3);
            this.summary_datagridview_report_disbursment.Name = "summary_datagridview_report_disbursment";
            this.summary_datagridview_report_disbursment.Size = new System.Drawing.Size(750, 398);
            this.summary_datagridview_report_disbursment.TabIndex = 16;
            // 
            // CashReport_Module
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 549);
            this.Controls.Add(this.Reports_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CashReport_Module";
            this.Text = "CashReport_Module";
            this.Reports_panel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
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
    }
}