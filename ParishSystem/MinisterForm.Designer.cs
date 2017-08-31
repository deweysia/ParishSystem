﻿namespace ParishSystem
{
    partial class MinisterForm
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
            this.txtFN = new System.Windows.Forms.TextBox();
            this.txtMI = new System.Windows.Forms.TextBox();
            this.lastName_textBox = new System.Windows.Forms.TextBox();
            this.suffix_textBox = new System.Windows.Forms.TextBox();
            this.birthDate_dtp = new MetroFramework.Controls.MetroDateTime();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.status_cBox = new MetroFramework.Controls.MetroComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ministryType_cBox = new MetroFramework.Controls.MetroComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.controlBar_panel = new System.Windows.Forms.Panel();
            this.close_button = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.controlBar_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFN
            // 
            this.txtFN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFN.Location = new System.Drawing.Point(100, 49);
            this.txtFN.Name = "txtFN";
            this.txtFN.Size = new System.Drawing.Size(100, 18);
            this.txtFN.TabIndex = 0;
            this.txtFN.TextChanged += new System.EventHandler(this.licenseNum_textBox_TextChanged);
            // 
            // txtMI
            // 
            this.txtMI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMI.Location = new System.Drawing.Point(206, 49);
            this.txtMI.Name = "txtMI";
            this.txtMI.Size = new System.Drawing.Size(25, 18);
            this.txtMI.TabIndex = 1;
            this.txtMI.TextChanged += new System.EventHandler(this.licenseNum_textBox_TextChanged);
            // 
            // lastName_textBox
            // 
            this.lastName_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastName_textBox.Location = new System.Drawing.Point(237, 49);
            this.lastName_textBox.Name = "lastName_textBox";
            this.lastName_textBox.Size = new System.Drawing.Size(100, 18);
            this.lastName_textBox.TabIndex = 2;
            this.lastName_textBox.TextChanged += new System.EventHandler(this.licenseNum_textBox_TextChanged);
            // 
            // suffix_textBox
            // 
            this.suffix_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.suffix_textBox.Location = new System.Drawing.Point(343, 49);
            this.suffix_textBox.Name = "suffix_textBox";
            this.suffix_textBox.Size = new System.Drawing.Size(35, 18);
            this.suffix_textBox.TabIndex = 3;
            // 
            // birthDate_dtp
            // 
            this.birthDate_dtp.Location = new System.Drawing.Point(104, 77);
            this.birthDate_dtp.MinimumSize = new System.Drawing.Size(0, 29);
            this.birthDate_dtp.Name = "birthDate_dtp";
            this.birthDate_dtp.Size = new System.Drawing.Size(233, 29);
            this.birthDate_dtp.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Birth Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ministry Type";
            // 
            // status_cBox
            // 
            this.status_cBox.FormattingEnabled = true;
            this.status_cBox.ItemHeight = 23;
            this.status_cBox.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.status_cBox.Location = new System.Drawing.Point(104, 147);
            this.status_cBox.Name = "status_cBox";
            this.status_cBox.Size = new System.Drawing.Size(140, 29);
            this.status_cBox.TabIndex = 7;
            this.status_cBox.UseSelectable = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "Minister";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.ministryType_cBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtFN);
            this.panel1.Controls.Add(this.txtMI);
            this.panel1.Controls.Add(this.lastName_textBox);
            this.panel1.Controls.Add(this.suffix_textBox);
            this.panel1.Controls.Add(this.birthDate_dtp);
            this.panel1.Controls.Add(this.status_cBox);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(11, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 200);
            this.panel1.TabIndex = 12;
            // 
            // ministryType_cBox
            // 
            this.ministryType_cBox.FormattingEnabled = true;
            this.ministryType_cBox.ItemHeight = 23;
            this.ministryType_cBox.Items.AddRange(new object[] {
            "Priest",
            "Bishop"});
            this.ministryType_cBox.Location = new System.Drawing.Point(104, 112);
            this.ministryType_cBox.Name = "ministryType_cBox";
            this.ministryType_cBox.Size = new System.Drawing.Size(140, 29);
            this.ministryType_cBox.TabIndex = 11;
            this.ministryType_cBox.UseSelectable = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(93, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(293, 17);
            this.label11.TabIndex = 12;
            this.label11.Text = "_________________________________________________________";
            // 
            // controlBar_panel
            // 
            this.controlBar_panel.BackColor = System.Drawing.Color.DimGray;
            this.controlBar_panel.Controls.Add(this.close_button);
            this.controlBar_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlBar_panel.Location = new System.Drawing.Point(0, 0);
            this.controlBar_panel.Margin = new System.Windows.Forms.Padding(0);
            this.controlBar_panel.Name = "controlBar_panel";
            this.controlBar_panel.Size = new System.Drawing.Size(421, 33);
            this.controlBar_panel.TabIndex = 57;
            // 
            // close_button
            // 
            this.close_button.BackColor = System.Drawing.Color.DimGray;
            this.close_button.FlatAppearance.BorderSize = 0;
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_button.Image = global::ParishSystem.Properties.Resources.icons8_Delete_20;
            this.close_button.Location = new System.Drawing.Point(378, 4);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(40, 29);
            this.close_button.TabIndex = 0;
            this.close_button.UseVisualStyleBackColor = false;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // addBtn
            // 
            this.addBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.addBtn.BackColor = System.Drawing.Color.Gray;
            this.addBtn.FlatAppearance.BorderSize = 0;
            this.addBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.ForeColor = System.Drawing.Color.White;
            this.addBtn.Location = new System.Drawing.Point(145, 261);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(128, 35);
            this.addBtn.TabIndex = 58;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // MinisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(421, 313);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.controlBar_panel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MinisterForm";
            this.Text = "MinisterForm";
            this.Load += new System.EventHandler(this.MinisterForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.controlBar_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFN;
        private System.Windows.Forms.TextBox txtMI;
        private System.Windows.Forms.TextBox lastName_textBox;
        private System.Windows.Forms.TextBox suffix_textBox;
        private MetroFramework.Controls.MetroDateTime birthDate_dtp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroComboBox status_cBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroComboBox ministryType_cBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel controlBar_panel;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Button addBtn;
    }
}