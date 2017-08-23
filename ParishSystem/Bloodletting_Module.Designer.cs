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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.blooddonor_panel = new System.Windows.Forms.Panel();
            this.search_button_blood = new System.Windows.Forms.Button();
            this.search_textbox_blood = new System.Windows.Forms.TextBox();
            this.add_button_donor = new System.Windows.Forms.Button();
            this.bloodletting_dgv = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.blooddonor_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bloodletting_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // blooddonor_panel
            // 
            this.blooddonor_panel.BackColor = System.Drawing.Color.White;
            this.blooddonor_panel.Controls.Add(this.search_button_blood);
            this.blooddonor_panel.Controls.Add(this.search_textbox_blood);
            this.blooddonor_panel.Controls.Add(this.add_button_donor);
            this.blooddonor_panel.Controls.Add(this.bloodletting_dgv);
            this.blooddonor_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blooddonor_panel.Location = new System.Drawing.Point(0, 0);
            this.blooddonor_panel.Name = "blooddonor_panel";
            this.blooddonor_panel.Size = new System.Drawing.Size(930, 540);
            this.blooddonor_panel.TabIndex = 68;
            // 
            // search_button_blood
            // 
            this.search_button_blood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(108)))), ((int)(((byte)(179)))));
            this.search_button_blood.FlatAppearance.BorderSize = 0;
            this.search_button_blood.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(135)))), ((int)(((byte)(224)))));
            this.search_button_blood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_button_blood.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_button_blood.ForeColor = System.Drawing.Color.White;
            this.search_button_blood.Location = new System.Drawing.Point(765, 33);
            this.search_button_blood.Name = "search_button_blood";
            this.search_button_blood.Size = new System.Drawing.Size(122, 30);
            this.search_button_blood.TabIndex = 8;
            this.search_button_blood.Tag = "s";
            this.search_button_blood.Text = "Search";
            this.search_button_blood.UseVisualStyleBackColor = false;
            this.search_button_blood.Click += new System.EventHandler(this.search_button_blood_Click);
            // 
            // search_textbox_blood
            // 
            this.search_textbox_blood.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_textbox_blood.Location = new System.Drawing.Point(42, 35);
            this.search_textbox_blood.Name = "search_textbox_blood";
            this.search_textbox_blood.Size = new System.Drawing.Size(700, 29);
            this.search_textbox_blood.TabIndex = 7;
            // 
            // add_button_donor
            // 
            this.add_button_donor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(108)))), ((int)(((byte)(179)))));
            this.add_button_donor.FlatAppearance.BorderSize = 0;
            this.add_button_donor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(135)))), ((int)(((byte)(224)))));
            this.add_button_donor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_button_donor.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_button_donor.ForeColor = System.Drawing.Color.White;
            this.add_button_donor.Location = new System.Drawing.Point(362, 487);
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
            this.bloodletting_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bloodletting_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bloodletting_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bloodletting_dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.bloodletting_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bloodletting_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.bloodletting_dgv.ColumnHeadersHeight = 40;
            this.bloodletting_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.bloodletting_dgv.EnableHeadersVisualStyles = false;
            this.bloodletting_dgv.Location = new System.Drawing.Point(42, 77);
            this.bloodletting_dgv.MultiSelect = false;
            this.bloodletting_dgv.Name = "bloodletting_dgv";
            this.bloodletting_dgv.ReadOnly = true;
            this.bloodletting_dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bloodletting_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bloodletting_dgv.RowHeadersVisible = false;
            this.bloodletting_dgv.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bloodletting_dgv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bloodletting_dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bloodletting_dgv.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.bloodletting_dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.bloodletting_dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.bloodletting_dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.bloodletting_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bloodletting_dgv.Size = new System.Drawing.Size(845, 390);
            this.bloodletting_dgv.TabIndex = 0;
            this.bloodletting_dgv.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bloodletting_dgv_CellContentDoubleClick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Bloodletting_Module
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 540);
            this.Controls.Add(this.blooddonor_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Bloodletting_Module";
            this.Text = "Bloodletting_Module";
            this.Load += new System.EventHandler(this.Bloodletting_Module_Load);
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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}