namespace ParishSystem
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
            this.dtpBirthdate = new MetroFramework.Controls.MetroDateTime();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStatus = new MetroFramework.Controls.MetroComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLN = new MetroFramework.Controls.MetroTextBox();
            this.txtSuffix = new MetroFramework.Controls.MetroTextBox();
            this.txtMI = new MetroFramework.Controls.MetroTextBox();
            this.txtFN = new MetroFramework.Controls.MetroTextBox();
            this.cmbMinistryType = new MetroFramework.Controls.MetroComboBox();
            this.controlBar_panel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.close_button = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.controlBar_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpBirthdate
            // 
            this.dtpBirthdate.Location = new System.Drawing.Point(104, 77);
            this.dtpBirthdate.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpBirthdate.Name = "dtpBirthdate";
            this.dtpBirthdate.Size = new System.Drawing.Size(233, 29);
            this.dtpBirthdate.TabIndex = 17;
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
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.ItemHeight = 23;
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cmbStatus.Location = new System.Drawing.Point(104, 147);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(177, 29);
            this.cmbStatus.TabIndex = 19;
            this.cmbStatus.UseSelectable = true;
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
            this.panel1.Controls.Add(this.txtLN);
            this.panel1.Controls.Add(this.txtSuffix);
            this.panel1.Controls.Add(this.txtMI);
            this.panel1.Controls.Add(this.txtFN);
            this.panel1.Controls.Add(this.cmbMinistryType);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpBirthdate);
            this.panel1.Controls.Add(this.cmbStatus);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(11, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 200);
            this.panel1.TabIndex = 12;
            // 
            // txtLN
            // 
            // 
            // 
            // 
            this.txtLN.CustomButton.Image = null;
            this.txtLN.CustomButton.Location = new System.Drawing.Point(88, 1);
            this.txtLN.CustomButton.Name = "";
            this.txtLN.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtLN.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLN.CustomButton.TabIndex = 1;
            this.txtLN.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLN.CustomButton.UseSelectable = true;
            this.txtLN.CustomButton.Visible = false;
            this.txtLN.Lines = new string[0];
            this.txtLN.Location = new System.Drawing.Point(265, 48);
            this.txtLN.MaxLength = 32767;
            this.txtLN.Name = "txtLN";
            this.txtLN.PasswordChar = '\0';
            this.txtLN.PromptText = "Last Name";
            this.txtLN.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLN.SelectedText = "";
            this.txtLN.SelectionLength = 0;
            this.txtLN.SelectionStart = 0;
            this.txtLN.ShortcutsEnabled = true;
            this.txtLN.Size = new System.Drawing.Size(110, 23);
            this.txtLN.TabIndex = 15;
            this.txtLN.UseSelectable = true;
            this.txtLN.WaterMark = "Last Name";
            this.txtLN.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLN.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtLN.TextChanged += new System.EventHandler(this.licenseNum_textBox_TextChanged);
            // 
            // txtSuffix
            // 
            // 
            // 
            // 
            this.txtSuffix.CustomButton.Image = null;
            this.txtSuffix.CustomButton.Location = new System.Drawing.Point(17, 1);
            this.txtSuffix.CustomButton.Name = "";
            this.txtSuffix.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSuffix.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSuffix.CustomButton.TabIndex = 1;
            this.txtSuffix.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSuffix.CustomButton.UseSelectable = true;
            this.txtSuffix.CustomButton.Visible = false;
            this.txtSuffix.Lines = new string[0];
            this.txtSuffix.Location = new System.Drawing.Point(381, 48);
            this.txtSuffix.MaxLength = 5;
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.PasswordChar = '\0';
            this.txtSuffix.PromptText = "Suffix";
            this.txtSuffix.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSuffix.SelectedText = "";
            this.txtSuffix.SelectionLength = 0;
            this.txtSuffix.SelectionStart = 0;
            this.txtSuffix.ShortcutsEnabled = true;
            this.txtSuffix.Size = new System.Drawing.Size(39, 23);
            this.txtSuffix.TabIndex = 16;
            this.txtSuffix.UseSelectable = true;
            this.txtSuffix.WaterMark = "Suffix";
            this.txtSuffix.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSuffix.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtMI
            // 
            // 
            // 
            // 
            this.txtMI.CustomButton.Image = null;
            this.txtMI.CustomButton.Location = new System.Drawing.Point(17, 1);
            this.txtMI.CustomButton.Name = "";
            this.txtMI.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtMI.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMI.CustomButton.TabIndex = 1;
            this.txtMI.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMI.CustomButton.UseSelectable = true;
            this.txtMI.CustomButton.Visible = false;
            this.txtMI.Lines = new string[0];
            this.txtMI.Location = new System.Drawing.Point(220, 48);
            this.txtMI.MaxLength = 1;
            this.txtMI.Name = "txtMI";
            this.txtMI.PasswordChar = '\0';
            this.txtMI.PromptText = "M.I.";
            this.txtMI.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMI.SelectedText = "";
            this.txtMI.SelectionLength = 0;
            this.txtMI.SelectionStart = 0;
            this.txtMI.ShortcutsEnabled = true;
            this.txtMI.Size = new System.Drawing.Size(39, 23);
            this.txtMI.TabIndex = 14;
            this.txtMI.UseSelectable = true;
            this.txtMI.WaterMark = "M.I.";
            this.txtMI.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMI.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtMI.TextChanged += new System.EventHandler(this.licenseNum_textBox_TextChanged);
            // 
            // txtFN
            // 
            // 
            // 
            // 
            this.txtFN.CustomButton.Image = null;
            this.txtFN.CustomButton.Location = new System.Drawing.Point(88, 1);
            this.txtFN.CustomButton.Name = "";
            this.txtFN.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtFN.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFN.CustomButton.TabIndex = 1;
            this.txtFN.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFN.CustomButton.UseSelectable = true;
            this.txtFN.CustomButton.Visible = false;
            this.txtFN.Lines = new string[0];
            this.txtFN.Location = new System.Drawing.Point(104, 48);
            this.txtFN.MaxLength = 32767;
            this.txtFN.Name = "txtFN";
            this.txtFN.PasswordChar = '\0';
            this.txtFN.PromptText = "First Name";
            this.txtFN.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFN.SelectedText = "";
            this.txtFN.SelectionLength = 0;
            this.txtFN.SelectionStart = 0;
            this.txtFN.ShortcutsEnabled = true;
            this.txtFN.Size = new System.Drawing.Size(110, 23);
            this.txtFN.TabIndex = 13;
            this.txtFN.UseSelectable = true;
            this.txtFN.WaterMark = "First Name";
            this.txtFN.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFN.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtFN.TextChanged += new System.EventHandler(this.licenseNum_textBox_TextChanged);
            // 
            // cmbMinistryType
            // 
            this.cmbMinistryType.FormattingEnabled = true;
            this.cmbMinistryType.ItemHeight = 23;
            this.cmbMinistryType.Items.AddRange(new object[] {
            "Priest",
            "Bishop"});
            this.cmbMinistryType.Location = new System.Drawing.Point(104, 112);
            this.cmbMinistryType.Name = "cmbMinistryType";
            this.cmbMinistryType.Size = new System.Drawing.Size(177, 29);
            this.cmbMinistryType.TabIndex = 18;
            this.cmbMinistryType.UseSelectable = true;
            // 
            // controlBar_panel
            // 
            this.controlBar_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.controlBar_panel.Controls.Add(this.label4);
            this.controlBar_panel.Controls.Add(this.close_button);
            this.controlBar_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlBar_panel.Location = new System.Drawing.Point(0, 0);
            this.controlBar_panel.Margin = new System.Windows.Forms.Padding(0);
            this.controlBar_panel.Name = "controlBar_panel";
            this.controlBar_panel.Size = new System.Drawing.Size(459, 33);
            this.controlBar_panel.TabIndex = 57;
            this.controlBar_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.controlBar_panel_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Minister Application";
            // 
            // close_button
            // 
            this.close_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.close_button.FlatAppearance.BorderSize = 0;
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_button.Image = global::ParishSystem.Properties.Resources.icons8_Delete_20;
            this.close_button.Location = new System.Drawing.Point(416, 0);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(40, 33);
            this.close_button.TabIndex = 0;
            this.close_button.TabStop = false;
            this.close_button.UseVisualStyleBackColor = false;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // addBtn
            // 
            this.addBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addBtn.FlatAppearance.BorderSize = 0;
            this.addBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.ForeColor = System.Drawing.Color.White;
            this.addBtn.Location = new System.Drawing.Point(164, 261);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(128, 35);
            this.addBtn.TabIndex = 20;
            this.addBtn.Text = "Apply";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // MinisterForm
            // 
            this.AcceptButton = this.addBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(459, 313);
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
            this.controlBar_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroDateTime dtpBirthdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroComboBox cmbStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroComboBox cmbMinistryType;
        private System.Windows.Forms.Panel controlBar_panel;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroTextBox txtLN;
        private MetroFramework.Controls.MetroTextBox txtSuffix;
        private MetroFramework.Controls.MetroTextBox txtMI;
        private MetroFramework.Controls.MetroTextBox txtFN;
    }
}