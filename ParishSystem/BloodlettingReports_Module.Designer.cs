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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bloodlettingreports_panel = new System.Windows.Forms.Panel();
            this.summary_dgv_bloodletting = new System.Windows.Forms.DataGridView();
            this.filterBy_combobox_bloodletting = new System.Windows.Forms.ComboBox();
            this.to_bloodlettingeventreport_dtp = new System.Windows.Forms.DateTimePicker();
            this.from_bloodlettingeventreport_dtp = new System.Windows.Forms.DateTimePicker();
            this.bloodlettingeventreport_datagridview = new System.Windows.Forms.DataGridView();
            this.bloodlettingeventreport_combobox = new System.Windows.Forms.ComboBox();
            this.bloodlettingreports_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.summary_dgv_bloodletting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bloodlettingeventreport_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // bloodlettingreports_panel
            // 
            this.bloodlettingreports_panel.BackColor = System.Drawing.Color.White;
            this.bloodlettingreports_panel.Controls.Add(this.summary_dgv_bloodletting);
            this.bloodlettingreports_panel.Controls.Add(this.filterBy_combobox_bloodletting);
            this.bloodlettingreports_panel.Controls.Add(this.to_bloodlettingeventreport_dtp);
            this.bloodlettingreports_panel.Controls.Add(this.from_bloodlettingeventreport_dtp);
            this.bloodlettingreports_panel.Controls.Add(this.bloodlettingeventreport_datagridview);
            this.bloodlettingreports_panel.Controls.Add(this.bloodlettingeventreport_combobox);
            this.bloodlettingreports_panel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bloodlettingreports_panel.Location = new System.Drawing.Point(0, 0);
            this.bloodlettingreports_panel.Name = "bloodlettingreports_panel";
            this.bloodlettingreports_panel.Size = new System.Drawing.Size(811, 549);
            this.bloodlettingreports_panel.TabIndex = 37;
            // 
            // summary_dgv_bloodletting
            // 
            this.summary_dgv_bloodletting.AllowUserToAddRows = false;
            this.summary_dgv_bloodletting.AllowUserToDeleteRows = false;
            this.summary_dgv_bloodletting.AllowUserToOrderColumns = true;
            this.summary_dgv_bloodletting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.summary_dgv_bloodletting.BackgroundColor = System.Drawing.Color.White;
            this.summary_dgv_bloodletting.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.summary_dgv_bloodletting.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(91)))), ((int)(((byte)(132)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.summary_dgv_bloodletting.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.summary_dgv_bloodletting.ColumnHeadersHeight = 40;
            this.summary_dgv_bloodletting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.summary_dgv_bloodletting.EnableHeadersVisualStyles = false;
            this.summary_dgv_bloodletting.GridColor = System.Drawing.Color.White;
            this.summary_dgv_bloodletting.Location = new System.Drawing.Point(193, 393);
            this.summary_dgv_bloodletting.MultiSelect = false;
            this.summary_dgv_bloodletting.Name = "summary_dgv_bloodletting";
            this.summary_dgv_bloodletting.ReadOnly = true;
            this.summary_dgv_bloodletting.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.summary_dgv_bloodletting.RowHeadersVisible = false;
            this.summary_dgv_bloodletting.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.summary_dgv_bloodletting.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.summary_dgv_bloodletting.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.summary_dgv_bloodletting.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(118)))), ((int)(((byte)(140)))));
            this.summary_dgv_bloodletting.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.summary_dgv_bloodletting.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.summary_dgv_bloodletting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.summary_dgv_bloodletting.Size = new System.Drawing.Size(424, 130);
            this.summary_dgv_bloodletting.TabIndex = 6;
            this.summary_dgv_bloodletting.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.summary_dgv_bloodletting_CellContentDoubleClick);
            // 
            // filterBy_combobox_bloodletting
            // 
            this.filterBy_combobox_bloodletting.FormattingEnabled = true;
            this.filterBy_combobox_bloodletting.Items.AddRange(new object[] {
            "Recent",
            "Donations on Event",
            "Donations on Date",
            "Donations between Dates",
            "All Blood Donations"});
            this.filterBy_combobox_bloodletting.Location = new System.Drawing.Point(326, 54);
            this.filterBy_combobox_bloodletting.Name = "filterBy_combobox_bloodletting";
            this.filterBy_combobox_bloodletting.Size = new System.Drawing.Size(256, 29);
            this.filterBy_combobox_bloodletting.TabIndex = 5;
            this.filterBy_combobox_bloodletting.SelectedIndexChanged += new System.EventHandler(this.filterBy_combobox_bloodletting_SelectedIndexChanged);
            // 
            // to_bloodlettingeventreport_dtp
            // 
            this.to_bloodlettingeventreport_dtp.Location = new System.Drawing.Point(326, 16);
            this.to_bloodlettingeventreport_dtp.Name = "to_bloodlettingeventreport_dtp";
            this.to_bloodlettingeventreport_dtp.Size = new System.Drawing.Size(276, 29);
            this.to_bloodlettingeventreport_dtp.TabIndex = 4;
            this.to_bloodlettingeventreport_dtp.Visible = false;
            this.to_bloodlettingeventreport_dtp.ValueChanged += new System.EventHandler(this.to_bloodlettingeventreport_dtp_ValueChanged);
            // 
            // from_bloodlettingeventreport_dtp
            // 
            this.from_bloodlettingeventreport_dtp.Location = new System.Drawing.Point(44, 16);
            this.from_bloodlettingeventreport_dtp.Name = "from_bloodlettingeventreport_dtp";
            this.from_bloodlettingeventreport_dtp.Size = new System.Drawing.Size(276, 29);
            this.from_bloodlettingeventreport_dtp.TabIndex = 2;
            this.from_bloodlettingeventreport_dtp.Visible = false;
            this.from_bloodlettingeventreport_dtp.ValueChanged += new System.EventHandler(this.from_bloodlettingeventreport_dtp_ValueChanged);
            // 
            // bloodlettingeventreport_datagridview
            // 
            this.bloodlettingeventreport_datagridview.AllowUserToAddRows = false;
            this.bloodlettingeventreport_datagridview.AllowUserToDeleteRows = false;
            this.bloodlettingeventreport_datagridview.AllowUserToOrderColumns = true;
            this.bloodlettingeventreport_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bloodlettingeventreport_datagridview.BackgroundColor = System.Drawing.Color.White;
            this.bloodlettingeventreport_datagridview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.bloodlettingeventreport_datagridview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(91)))), ((int)(((byte)(132)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bloodlettingeventreport_datagridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bloodlettingeventreport_datagridview.ColumnHeadersHeight = 40;
            this.bloodlettingeventreport_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.bloodlettingeventreport_datagridview.EnableHeadersVisualStyles = false;
            this.bloodlettingeventreport_datagridview.GridColor = System.Drawing.Color.White;
            this.bloodlettingeventreport_datagridview.Location = new System.Drawing.Point(22, 96);
            this.bloodlettingeventreport_datagridview.MultiSelect = false;
            this.bloodlettingeventreport_datagridview.Name = "bloodlettingeventreport_datagridview";
            this.bloodlettingeventreport_datagridview.ReadOnly = true;
            this.bloodlettingeventreport_datagridview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.bloodlettingeventreport_datagridview.RowHeadersVisible = false;
            this.bloodlettingeventreport_datagridview.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bloodlettingeventreport_datagridview.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.bloodlettingeventreport_datagridview.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.bloodlettingeventreport_datagridview.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(118)))), ((int)(((byte)(140)))));
            this.bloodlettingeventreport_datagridview.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.bloodlettingeventreport_datagridview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.bloodlettingeventreport_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bloodlettingeventreport_datagridview.Size = new System.Drawing.Size(767, 289);
            this.bloodlettingeventreport_datagridview.TabIndex = 1;
            this.bloodlettingeventreport_datagridview.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bloodlettingeventreport_datagridview_CellContentDoubleClick);
            // 
            // bloodlettingeventreport_combobox
            // 
            this.bloodlettingeventreport_combobox.FormattingEnabled = true;
            this.bloodlettingeventreport_combobox.Location = new System.Drawing.Point(44, 55);
            this.bloodlettingeventreport_combobox.Name = "bloodlettingeventreport_combobox";
            this.bloodlettingeventreport_combobox.Size = new System.Drawing.Size(244, 29);
            this.bloodlettingeventreport_combobox.TabIndex = 0;
            this.bloodlettingeventreport_combobox.Visible = false;
            this.bloodlettingeventreport_combobox.SelectedIndexChanged += new System.EventHandler(this.bloodlettingeventreport_combobox_SelectedIndexChanged);
            // 
            // BloodlettingReports_Module
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 549);
            this.Controls.Add(this.bloodlettingreports_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BloodlettingReports_Module";
            this.Text = "CashReports_Module";
            this.Load += new System.EventHandler(this.BloodlettingReports_Module_Load);
            this.bloodlettingreports_panel.ResumeLayout(false);
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
    }
}