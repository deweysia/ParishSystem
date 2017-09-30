namespace ParishSystem
{
    partial class Bloodletting_Module
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bloodletting_Module));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.blooddonor_panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label = new System.Windows.Forms.Label();
            this.search_button_blood = new System.Windows.Forms.Button();
            this.search_textbox_blood = new System.Windows.Forms.TextBox();
            this.add_button_donor = new System.Windows.Forms.Button();
            this.bloodletting_dgv = new System.Windows.Forms.DataGridView();
            this.blooddonor_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bloodletting_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // blooddonor_panel
            // 
            this.blooddonor_panel.BackColor = System.Drawing.Color.White;
            this.blooddonor_panel.Controls.Add(this.panel1);
            this.blooddonor_panel.Controls.Add(this.label);
            this.blooddonor_panel.Controls.Add(this.search_button_blood);
            this.blooddonor_panel.Controls.Add(this.search_textbox_blood);
            this.blooddonor_panel.Controls.Add(this.add_button_donor);
            this.blooddonor_panel.Controls.Add(this.bloodletting_dgv);
            this.blooddonor_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blooddonor_panel.Location = new System.Drawing.Point(0, 0);
            this.blooddonor_panel.Name = "blooddonor_panel";
            this.blooddonor_panel.Size = new System.Drawing.Size(943, 669);
            this.blooddonor_panel.TabIndex = 68;
            this.blooddonor_panel.VisibleChanged += new System.EventHandler(this.blooddonor_panel_VisibleChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(39, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 1);
            this.panel1.TabIndex = 40;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.Black;
            this.label.Location = new System.Drawing.Point(35, 20);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(163, 32);
            this.label.TabIndex = 39;
            this.label.Text = "Blood Donors";
            // 
            // search_button_blood
            // 
            this.search_button_blood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_button_blood.BackColor = System.Drawing.Color.White;
            this.search_button_blood.FlatAppearance.BorderSize = 0;
            this.search_button_blood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_button_blood.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_button_blood.ForeColor = System.Drawing.Color.White;
            this.search_button_blood.Image = ((System.Drawing.Image)(resources.GetObject("search_button_blood.Image")));
            this.search_button_blood.Location = new System.Drawing.Point(861, 54);
            this.search_button_blood.Name = "search_button_blood";
            this.search_button_blood.Size = new System.Drawing.Size(35, 35);
            this.search_button_blood.TabIndex = 8;
            this.search_button_blood.Tag = "s";
            this.search_button_blood.UseVisualStyleBackColor = false;
            this.search_button_blood.Click += new System.EventHandler(this.search_button_blood_Click);
            // 
            // search_textbox_blood
            // 
            this.search_textbox_blood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_textbox_blood.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.search_textbox_blood.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_textbox_blood.Location = new System.Drawing.Point(41, 61);
            this.search_textbox_blood.Name = "search_textbox_blood";
            this.search_textbox_blood.Size = new System.Drawing.Size(814, 22);
            this.search_textbox_blood.TabIndex = 7;
            this.search_textbox_blood.TextChanged += new System.EventHandler(this.search_button_blood_TextChanged);
            this.search_textbox_blood.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_textbox_blood_KeyDown);
            // 
            // add_button_donor
            // 
            this.add_button_donor.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.add_button_donor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.add_button_donor.FlatAppearance.BorderSize = 0;
            this.add_button_donor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.add_button_donor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_button_donor.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_button_donor.ForeColor = System.Drawing.Color.White;
            this.add_button_donor.Location = new System.Drawing.Point(367, 604);
            this.add_button_donor.Name = "add_button_donor";
            this.add_button_donor.Size = new System.Drawing.Size(204, 37);
            this.add_button_donor.TabIndex = 4;
            this.add_button_donor.Text = "Add";
            this.add_button_donor.UseVisualStyleBackColor = false;
            this.add_button_donor.Click += new System.EventHandler(this.add_button_donor_Click);
            // 
            // bloodletting_dgv
            // 
            this.bloodletting_dgv.AllowUserToAddRows = false;
            this.bloodletting_dgv.AllowUserToDeleteRows = false;
            this.bloodletting_dgv.AllowUserToOrderColumns = true;
            this.bloodletting_dgv.AllowUserToResizeColumns = false;
            this.bloodletting_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bloodletting_dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bloodletting_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bloodletting_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bloodletting_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bloodletting_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bloodletting_dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.bloodletting_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bloodletting_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bloodletting_dgv.ColumnHeadersHeight = 40;
            this.bloodletting_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bloodletting_dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.bloodletting_dgv.EnableHeadersVisualStyles = false;
            this.bloodletting_dgv.Location = new System.Drawing.Point(41, 108);
            this.bloodletting_dgv.MultiSelect = false;
            this.bloodletting_dgv.Name = "bloodletting_dgv";
            this.bloodletting_dgv.ReadOnly = true;
            this.bloodletting_dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bloodletting_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.bloodletting_dgv.RowHeadersVisible = false;
            this.bloodletting_dgv.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bloodletting_dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bloodletting_dgv.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.bloodletting_dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.bloodletting_dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.bloodletting_dgv.RowTemplate.Height = 35;
            this.bloodletting_dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.bloodletting_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bloodletting_dgv.Size = new System.Drawing.Size(858, 476);
            this.bloodletting_dgv.TabIndex = 0;
            this.bloodletting_dgv.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bloodletting_dgv_CellContentDoubleClick);
            this.bloodletting_dgv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bloodletting_dgv_KeyDown);
            // 
            // Bloodletting_Module
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 669);
            this.Controls.Add(this.blooddonor_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Bloodletting_Module";
            this.Text = "Bloodletting_Module";
            this.Load += new System.EventHandler(this.Bloodletting_Module_Load);
            this.VisibleChanged += new System.EventHandler(this.Bloodletting_Module_VisibleChanged);
            this.blooddonor_panel.ResumeLayout(false);
            this.blooddonor_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bloodletting_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel blooddonor_panel;
        private System.Windows.Forms.Button search_button_blood;
        private System.Windows.Forms.TextBox search_textbox_blood;
        private System.Windows.Forms.Button add_button_donor;
        private System.Windows.Forms.DataGridView bloodletting_dgv;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Panel panel1;
    }
}