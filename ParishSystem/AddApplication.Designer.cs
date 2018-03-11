namespace ParishSystem
{
    partial class AddApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddApplication));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.birthdate_dtp = new MetroFramework.Controls.MetroDateTime();
            this.male_radio = new MetroFramework.Controls.MetroRadioButton();
            this.female_radio = new MetroFramework.Controls.MetroRadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.application_remarks_textBox = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSuffix = new MetroFramework.Controls.MetroTextBox();
            this.txtLastName = new MetroFramework.Controls.MetroTextBox();
            this.txtMI = new MetroFramework.Controls.MetroTextBox();
            this.txtFN = new MetroFramework.Controls.MetroTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtRemarks = new MetroFramework.Controls.MetroTextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.nupPrice = new ParishSystem.HiddenNumericUpDown();
            this.cbMakeDonation = new MetroFramework.Controls.MetroCheckBox();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sacrament Application";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gender";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Birthdate";
            // 
            // birthdate_dtp
            // 
            this.birthdate_dtp.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.birthdate_dtp.Location = new System.Drawing.Point(9, 166);
            this.birthdate_dtp.MaxDate = new System.DateTime(2017, 7, 16, 0, 0, 0, 0);
            this.birthdate_dtp.MinimumSize = new System.Drawing.Size(0, 25);
            this.birthdate_dtp.Name = "birthdate_dtp";
            this.birthdate_dtp.Size = new System.Drawing.Size(200, 25);
            this.birthdate_dtp.Style = MetroFramework.MetroColorStyle.Silver;
            this.birthdate_dtp.TabIndex = 7;
            this.birthdate_dtp.Value = new System.DateTime(2017, 7, 16, 0, 0, 0, 0);
            // 
            // male_radio
            // 
            this.male_radio.AutoSize = true;
            this.male_radio.Checked = true;
            this.male_radio.ForeColor = System.Drawing.Color.Black;
            this.male_radio.Location = new System.Drawing.Point(3, 3);
            this.male_radio.Name = "male_radio";
            this.male_radio.Size = new System.Drawing.Size(49, 15);
            this.male_radio.Style = MetroFramework.MetroColorStyle.Silver;
            this.male_radio.TabIndex = 5;
            this.male_radio.TabStop = true;
            this.male_radio.Text = "Male";
            this.male_radio.UseCustomBackColor = true;
            this.male_radio.UseCustomForeColor = true;
            this.male_radio.UseSelectable = true;
            this.male_radio.UseStyleColors = true;
            // 
            // female_radio
            // 
            this.female_radio.AutoSize = true;
            this.female_radio.BackColor = System.Drawing.Color.Transparent;
            this.female_radio.ForeColor = System.Drawing.Color.Black;
            this.female_radio.Location = new System.Drawing.Point(58, 3);
            this.female_radio.Name = "female_radio";
            this.female_radio.Size = new System.Drawing.Size(61, 15);
            this.female_radio.Style = MetroFramework.MetroColorStyle.Silver;
            this.female_radio.TabIndex = 6;
            this.female_radio.Text = "Female";
            this.female_radio.UseCustomBackColor = true;
            this.female_radio.UseCustomForeColor = true;
            this.female_radio.UseSelectable = true;
            this.female_radio.UseStyleColors = true;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(10, 199);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(312, 2);
            this.label6.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Price";
            // 
            // application_remarks_textBox
            // 
            this.application_remarks_textBox.AutoSize = true;
            this.application_remarks_textBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.application_remarks_textBox.ForeColor = System.Drawing.Color.Black;
            this.application_remarks_textBox.Location = new System.Drawing.Point(8, 261);
            this.application_remarks_textBox.Name = "application_remarks_textBox";
            this.application_remarks_textBox.Size = new System.Drawing.Size(50, 13);
            this.application_remarks_textBox.TabIndex = 18;
            this.application_remarks_textBox.Text = "Remarks";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 34);
            this.panel1.TabIndex = 22;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.FlatAppearance.BorderSize = 0;
            this.pictureBox1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.pictureBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pictureBox1.Image = global::ParishSystem.Properties.Resources.icons8_Delete_20;
            this.pictureBox1.Location = new System.Drawing.Point(295, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 34);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.UseVisualStyleBackColor = true;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(7, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(205, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "_________________________________";
            // 
            // txtSuffix
            // 
            // 
            // 
            // 
            this.txtSuffix.CustomButton.Image = null;
            this.txtSuffix.CustomButton.Location = new System.Drawing.Point(28, 1);
            this.txtSuffix.CustomButton.Name = "";
            this.txtSuffix.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSuffix.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSuffix.CustomButton.TabIndex = 1;
            this.txtSuffix.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSuffix.CustomButton.UseSelectable = true;
            this.txtSuffix.CustomButton.Visible = false;
            this.txtSuffix.Lines = new string[0];
            this.txtSuffix.Location = new System.Drawing.Point(272, 62);
            this.txtSuffix.MaxLength = 32767;
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.PasswordChar = '\0';
            this.txtSuffix.PromptText = "Suffix";
            this.txtSuffix.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSuffix.SelectedText = "";
            this.txtSuffix.SelectionLength = 0;
            this.txtSuffix.SelectionStart = 0;
            this.txtSuffix.ShortcutsEnabled = true;
            this.txtSuffix.Size = new System.Drawing.Size(50, 23);
            this.txtSuffix.Style = MetroFramework.MetroColorStyle.Silver;
            this.txtSuffix.TabIndex = 4;
            this.txtSuffix.Tag = "NOT_REQUIRED";
            this.txtSuffix.UseSelectable = true;
            this.txtSuffix.WaterMark = "Suffix";
            this.txtSuffix.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSuffix.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtLastName
            // 
            // 
            // 
            // 
            this.txtLastName.CustomButton.Image = null;
            this.txtLastName.CustomButton.Location = new System.Drawing.Point(85, 1);
            this.txtLastName.CustomButton.Name = "";
            this.txtLastName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtLastName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLastName.CustomButton.TabIndex = 1;
            this.txtLastName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLastName.CustomButton.UseSelectable = true;
            this.txtLastName.CustomButton.Visible = false;
            this.txtLastName.Lines = new string[0];
            this.txtLastName.Location = new System.Drawing.Point(159, 62);
            this.txtLastName.MaxLength = 32767;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.PasswordChar = '\0';
            this.txtLastName.PromptText = "Last Name";
            this.txtLastName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLastName.SelectedText = "";
            this.txtLastName.SelectionLength = 0;
            this.txtLastName.SelectionStart = 0;
            this.txtLastName.ShortcutsEnabled = true;
            this.txtLastName.Size = new System.Drawing.Size(107, 23);
            this.txtLastName.Style = MetroFramework.MetroColorStyle.Silver;
            this.txtLastName.TabIndex = 3;
            this.txtLastName.UseSelectable = true;
            this.txtLastName.WaterMark = "Last Name";
            this.txtLastName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLastName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtMI
            // 
            // 
            // 
            // 
            this.txtMI.CustomButton.Image = null;
            this.txtMI.CustomButton.Location = new System.Drawing.Point(9, 1);
            this.txtMI.CustomButton.Name = "";
            this.txtMI.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtMI.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMI.CustomButton.TabIndex = 1;
            this.txtMI.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMI.CustomButton.UseSelectable = true;
            this.txtMI.CustomButton.Visible = false;
            this.txtMI.Lines = new string[0];
            this.txtMI.Location = new System.Drawing.Point(122, 62);
            this.txtMI.MaxLength = 32767;
            this.txtMI.Name = "txtMI";
            this.txtMI.PasswordChar = '\0';
            this.txtMI.PromptText = "M.I.";
            this.txtMI.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMI.SelectedText = "";
            this.txtMI.SelectionLength = 0;
            this.txtMI.SelectionStart = 0;
            this.txtMI.ShortcutsEnabled = true;
            this.txtMI.Size = new System.Drawing.Size(31, 23);
            this.txtMI.Style = MetroFramework.MetroColorStyle.Silver;
            this.txtMI.TabIndex = 2;
            this.txtMI.UseSelectable = true;
            this.txtMI.WaterMark = "M.I.";
            this.txtMI.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMI.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtFN
            // 
            // 
            // 
            // 
            this.txtFN.CustomButton.Image = null;
            this.txtFN.CustomButton.Location = new System.Drawing.Point(85, 1);
            this.txtFN.CustomButton.Name = "";
            this.txtFN.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtFN.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFN.CustomButton.TabIndex = 1;
            this.txtFN.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFN.CustomButton.UseSelectable = true;
            this.txtFN.CustomButton.Visible = false;
            this.txtFN.Lines = new string[0];
            this.txtFN.Location = new System.Drawing.Point(9, 62);
            this.txtFN.MaxLength = 32767;
            this.txtFN.Name = "txtFN";
            this.txtFN.PasswordChar = '\0';
            this.txtFN.PromptText = "First Name";
            this.txtFN.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFN.SelectedText = "";
            this.txtFN.SelectionLength = 0;
            this.txtFN.SelectionStart = 0;
            this.txtFN.ShortcutsEnabled = true;
            this.txtFN.Size = new System.Drawing.Size(107, 23);
            this.txtFN.Style = MetroFramework.MetroColorStyle.Silver;
            this.txtFN.TabIndex = 1;
            this.txtFN.UseSelectable = true;
            this.txtFN.WaterMark = "First Name";
            this.txtFN.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFN.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.male_radio);
            this.flowLayoutPanel1.Controls.Add(this.female_radio);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 111);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(126, 22);
            this.flowLayoutPanel1.TabIndex = 44;
            // 
            // txtRemarks
            // 
            // 
            // 
            // 
            this.txtRemarks.CustomButton.Image = null;
            this.txtRemarks.CustomButton.Location = new System.Drawing.Point(273, 1);
            this.txtRemarks.CustomButton.Name = "";
            this.txtRemarks.CustomButton.Size = new System.Drawing.Size(39, 39);
            this.txtRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRemarks.CustomButton.TabIndex = 1;
            this.txtRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRemarks.CustomButton.UseSelectable = true;
            this.txtRemarks.CustomButton.Visible = false;
            this.txtRemarks.Lines = new string[0];
            this.txtRemarks.Location = new System.Drawing.Point(9, 277);
            this.txtRemarks.MaxLength = 32767;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.PasswordChar = '\0';
            this.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRemarks.SelectedText = "";
            this.txtRemarks.SelectionLength = 0;
            this.txtRemarks.SelectionStart = 0;
            this.txtRemarks.ShortcutsEnabled = true;
            this.txtRemarks.Size = new System.Drawing.Size(313, 41);
            this.txtRemarks.TabIndex = 9;
            this.txtRemarks.Tag = "NOT_REQUIRED";
            this.txtRemarks.UseSelectable = true;
            this.txtRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(78, 324);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(188, 32);
            this.btnApply.TabIndex = 23;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.application_apply_button_Click);
            // 
            // nupPrice
            // 
            this.nupPrice.DecimalPlaces = 2;
            this.nupPrice.Location = new System.Drawing.Point(8, 230);
            this.nupPrice.Name = "nupPrice";
            this.nupPrice.ReadOnly = true;
            this.nupPrice.Size = new System.Drawing.Size(141, 20);
            this.nupPrice.TabIndex = 8;
            this.nupPrice.ThousandsSeparator = true;
            this.nupPrice.ValueChanged += new System.EventHandler(this.nupPrice_ValueChanged);
            this.nupPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nupPrice_KeyDown);
            this.nupPrice.Leave += new System.EventHandler(this.nupPrice_Leave);
            // 
            // cbMakeDonation
            // 
            this.cbMakeDonation.AutoSize = true;
            this.cbMakeDonation.Location = new System.Drawing.Point(40, 214);
            this.cbMakeDonation.Name = "cbMakeDonation";
            this.cbMakeDonation.Size = new System.Drawing.Size(109, 15);
            this.cbMakeDonation.TabIndex = 45;
            this.cbMakeDonation.Text = "Free Application";
            this.cbMakeDonation.UseSelectable = true;
            this.cbMakeDonation.CheckedChanged += new System.EventHandler(this.cbMakeDonation_CheckedChanged);
            // 
            // AddApplication
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(332, 373);
            this.Controls.Add(this.cbMakeDonation);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.nupPrice);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txtSuffix);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtMI);
            this.Controls.Add(this.txtFN);
            this.Controls.Add(this.birthdate_dtp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.application_remarks_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddApplication";
            this.Padding = new System.Windows.Forms.Padding(20, 20, 20, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddApplication";
            this.Load += new System.EventHandler(this.AddApplication_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddApplication_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroRadioButton female_radio;
        private MetroFramework.Controls.MetroRadioButton male_radio;
        private MetroFramework.Controls.MetroDateTime birthdate_dtp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label application_remarks_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button pictureBox1;
        private MetroFramework.Controls.MetroTextBox txtSuffix;
        private MetroFramework.Controls.MetroTextBox txtLastName;
        private MetroFramework.Controls.MetroTextBox txtMI;
        private MetroFramework.Controls.MetroTextBox txtFN;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private HiddenNumericUpDown nupPrice;
        private MetroFramework.Controls.MetroTextBox txtRemarks;
        private System.Windows.Forms.Button btnApply;
        private MetroFramework.Controls.MetroCheckBox cbMakeDonation;
    }
}