﻿namespace ParishSystem
{
    partial class AddMarriageApplication
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
            this.dtpGroomBirthDate = new MetroFramework.Controls.MetroDateTime();
            this.application_remarks_textBox = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpBrideBirthDate = new MetroFramework.Controls.MetroDateTime();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.close_picturebox = new System.Windows.Forms.PictureBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtGroomFN = new MetroFramework.Controls.MetroTextBox();
            this.txtGroomMI = new MetroFramework.Controls.MetroTextBox();
            this.txtGroomLN = new MetroFramework.Controls.MetroTextBox();
            this.txtGroomSuffix = new MetroFramework.Controls.MetroTextBox();
            this.txtBrideFN = new MetroFramework.Controls.MetroTextBox();
            this.txtBrideMI = new MetroFramework.Controls.MetroTextBox();
            this.txtBrideLN = new MetroFramework.Controls.MetroTextBox();
            this.txtBrideSuffix = new MetroFramework.Controls.MetroTextBox();
            this.txtPrice = new ParishSystem.HiddenNumericUpDown();
            this.txtRemarks = new MetroFramework.Controls.MetroTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close_picturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpGroomBirthDate
            // 
            this.dtpGroomBirthDate.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dtpGroomBirthDate.Location = new System.Drawing.Point(9, 121);
            this.dtpGroomBirthDate.MaxDate = new System.DateTime(2017, 7, 16, 0, 0, 0, 0);
            this.dtpGroomBirthDate.MinimumSize = new System.Drawing.Size(0, 25);
            this.dtpGroomBirthDate.Name = "dtpGroomBirthDate";
            this.dtpGroomBirthDate.Size = new System.Drawing.Size(200, 25);
            this.dtpGroomBirthDate.TabIndex = 4;
            this.dtpGroomBirthDate.Value = new System.DateTime(2017, 7, 16, 0, 0, 0, 0);
            // 
            // application_remarks_textBox
            // 
            this.application_remarks_textBox.AutoSize = true;
            this.application_remarks_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.application_remarks_textBox.Location = new System.Drawing.Point(6, 348);
            this.application_remarks_textBox.Name = "application_remarks_textBox";
            this.application_remarks_textBox.Size = new System.Drawing.Size(49, 13);
            this.application_remarks_textBox.TabIndex = 22;
            this.application_remarks_textBox.Text = "Remarks";
            this.application_remarks_textBox.Click += new System.EventHandler(this.application_remarks_textBox_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Groom";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Birthdate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Bride";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Birthdate";
            // 
            // dtpBrideBirthDate
            // 
            this.dtpBrideBirthDate.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dtpBrideBirthDate.Location = new System.Drawing.Point(9, 234);
            this.dtpBrideBirthDate.MaxDate = new System.DateTime(2017, 7, 16, 0, 0, 0, 0);
            this.dtpBrideBirthDate.MinimumSize = new System.Drawing.Size(0, 25);
            this.dtpBrideBirthDate.Name = "dtpBrideBirthDate";
            this.dtpBrideBirthDate.Size = new System.Drawing.Size(200, 25);
            this.dtpBrideBirthDate.TabIndex = 30;
            this.dtpBrideBirthDate.Value = new System.DateTime(2017, 7, 16, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(9, 277);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(328, 2);
            this.label6.TabIndex = 33;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.close_picturebox);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 34);
            this.panel1.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(7, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 20);
            this.label8.TabIndex = 36;
            this.label8.Text = "Marriage Application";
            // 
            // close_picturebox
            // 
            this.close_picturebox.Image = global::ParishSystem.Properties.Resources.Delete_32px;
            this.close_picturebox.Location = new System.Drawing.Point(313, 4);
            this.close_picturebox.Name = "close_picturebox";
            this.close_picturebox.Size = new System.Drawing.Size(25, 25);
            this.close_picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.close_picturebox.TabIndex = 35;
            this.close_picturebox.TabStop = false;
            this.close_picturebox.Click += new System.EventHandler(this.close_picturebox_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.Gray;
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(98, 413);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(150, 29);
            this.btnApply.TabIndex = 36;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtGroomFN
            // 
            // 
            // 
            // 
            this.txtGroomFN.CustomButton.Image = null;
            this.txtGroomFN.CustomButton.Location = new System.Drawing.Point(85, 1);
            this.txtGroomFN.CustomButton.Name = "";
            this.txtGroomFN.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtGroomFN.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtGroomFN.CustomButton.TabIndex = 1;
            this.txtGroomFN.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtGroomFN.CustomButton.UseSelectable = true;
            this.txtGroomFN.CustomButton.Visible = false;
            this.txtGroomFN.Lines = new string[0];
            this.txtGroomFN.Location = new System.Drawing.Point(9, 69);
            this.txtGroomFN.MaxLength = 32767;
            this.txtGroomFN.Name = "txtGroomFN";
            this.txtGroomFN.PasswordChar = '\0';
            this.txtGroomFN.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtGroomFN.SelectedText = "";
            this.txtGroomFN.SelectionLength = 0;
            this.txtGroomFN.SelectionStart = 0;
            this.txtGroomFN.ShortcutsEnabled = true;
            this.txtGroomFN.Size = new System.Drawing.Size(107, 23);
            this.txtGroomFN.TabIndex = 39;
            this.txtGroomFN.UseSelectable = true;
            this.txtGroomFN.WaterMark = "First Name";
            this.txtGroomFN.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtGroomFN.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtGroomMI
            // 
            // 
            // 
            // 
            this.txtGroomMI.CustomButton.Image = null;
            this.txtGroomMI.CustomButton.Location = new System.Drawing.Point(9, 1);
            this.txtGroomMI.CustomButton.Name = "";
            this.txtGroomMI.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtGroomMI.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtGroomMI.CustomButton.TabIndex = 1;
            this.txtGroomMI.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtGroomMI.CustomButton.UseSelectable = true;
            this.txtGroomMI.CustomButton.Visible = false;
            this.txtGroomMI.Lines = new string[0];
            this.txtGroomMI.Location = new System.Drawing.Point(122, 69);
            this.txtGroomMI.MaxLength = 32767;
            this.txtGroomMI.Name = "txtGroomMI";
            this.txtGroomMI.PasswordChar = '\0';
            this.txtGroomMI.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtGroomMI.SelectedText = "";
            this.txtGroomMI.SelectionLength = 0;
            this.txtGroomMI.SelectionStart = 0;
            this.txtGroomMI.ShortcutsEnabled = true;
            this.txtGroomMI.Size = new System.Drawing.Size(31, 23);
            this.txtGroomMI.TabIndex = 39;
            this.txtGroomMI.UseSelectable = true;
            this.txtGroomMI.WaterMark = "M.I.";
            this.txtGroomMI.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtGroomMI.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtGroomLN
            // 
            // 
            // 
            // 
            this.txtGroomLN.CustomButton.Image = null;
            this.txtGroomLN.CustomButton.Location = new System.Drawing.Point(85, 1);
            this.txtGroomLN.CustomButton.Name = "";
            this.txtGroomLN.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtGroomLN.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtGroomLN.CustomButton.TabIndex = 1;
            this.txtGroomLN.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtGroomLN.CustomButton.UseSelectable = true;
            this.txtGroomLN.CustomButton.Visible = false;
            this.txtGroomLN.Lines = new string[0];
            this.txtGroomLN.Location = new System.Drawing.Point(159, 69);
            this.txtGroomLN.MaxLength = 32767;
            this.txtGroomLN.Name = "txtGroomLN";
            this.txtGroomLN.PasswordChar = '\0';
            this.txtGroomLN.SelectionLength = 0;
            this.txtGroomLN.SelectionStart = 0;
            this.txtGroomLN.ShortcutsEnabled = true;
            this.txtGroomLN.Size = new System.Drawing.Size(107, 23);
            this.txtGroomLN.TabIndex = 39;
            this.txtGroomLN.UseSelectable = true;
            this.txtGroomLN.WaterMark = "Last Name";
            this.txtGroomLN.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtGroomLN.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtGroomSuffix
            // 
            // 
            // 
            // 
            this.txtGroomSuffix.CustomButton.Image = null;
            this.txtGroomSuffix.CustomButton.Location = new System.Drawing.Point(28, 1);
            this.txtGroomSuffix.CustomButton.Name = "";
            this.txtGroomSuffix.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtGroomSuffix.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtGroomSuffix.CustomButton.TabIndex = 1;
            this.txtGroomSuffix.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtGroomSuffix.CustomButton.UseSelectable = true;
            this.txtGroomSuffix.CustomButton.Visible = false;
            this.txtGroomSuffix.Lines = new string[0];
            this.txtGroomSuffix.Location = new System.Drawing.Point(272, 69);
            this.txtGroomSuffix.MaxLength = 32767;
            this.txtGroomSuffix.Name = "txtGroomSuffix";
            this.txtGroomSuffix.PasswordChar = '\0';
            this.txtGroomSuffix.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtGroomSuffix.SelectedText = "";
            this.txtGroomSuffix.SelectionLength = 0;
            this.txtGroomSuffix.SelectionStart = 0;
            this.txtGroomSuffix.ShortcutsEnabled = true;
            this.txtGroomSuffix.Size = new System.Drawing.Size(50, 23);
            this.txtGroomSuffix.TabIndex = 39;
            this.txtGroomSuffix.UseSelectable = true;
            this.txtGroomSuffix.WaterMark = "Suffix";
            this.txtGroomSuffix.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtGroomSuffix.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtBrideFN
            // 
            // 
            // 
            // 
            this.txtBrideFN.CustomButton.Image = null;
            this.txtBrideFN.CustomButton.Location = new System.Drawing.Point(85, 1);
            this.txtBrideFN.CustomButton.Name = "";
            this.txtBrideFN.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBrideFN.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBrideFN.CustomButton.TabIndex = 1;
            this.txtBrideFN.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBrideFN.CustomButton.UseSelectable = true;
            this.txtBrideFN.CustomButton.Visible = false;
            this.txtBrideFN.Lines = new string[0];
            this.txtBrideFN.Location = new System.Drawing.Point(9, 182);
            this.txtBrideFN.MaxLength = 32767;
            this.txtBrideFN.Name = "txtBrideFN";
            this.txtBrideFN.PasswordChar = '\0';
            this.txtBrideFN.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBrideFN.SelectedText = "";
            this.txtBrideFN.SelectionLength = 0;
            this.txtBrideFN.SelectionStart = 0;
            this.txtBrideFN.ShortcutsEnabled = true;
            this.txtBrideFN.Size = new System.Drawing.Size(107, 23);
            this.txtBrideFN.TabIndex = 39;
            this.txtBrideFN.UseSelectable = true;
            this.txtBrideFN.WaterMark = "First Name";
            this.txtBrideFN.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBrideFN.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtBrideMI
            // 
            // 
            // 
            // 
            this.txtBrideMI.CustomButton.Image = null;
            this.txtBrideMI.CustomButton.Location = new System.Drawing.Point(9, 1);
            this.txtBrideMI.CustomButton.Name = "";
            this.txtBrideMI.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBrideMI.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBrideMI.CustomButton.TabIndex = 1;
            this.txtBrideMI.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBrideMI.CustomButton.UseSelectable = true;
            this.txtBrideMI.CustomButton.Visible = false;
            this.txtBrideMI.Lines = new string[0];
            this.txtBrideMI.Location = new System.Drawing.Point(122, 182);
            this.txtBrideMI.MaxLength = 32767;
            this.txtBrideMI.Name = "txtBrideMI";
            this.txtBrideMI.PasswordChar = '\0';
            this.txtBrideMI.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBrideMI.SelectedText = "";
            this.txtBrideMI.SelectionLength = 0;
            this.txtBrideMI.SelectionStart = 0;
            this.txtBrideMI.ShortcutsEnabled = true;
            this.txtBrideMI.Size = new System.Drawing.Size(31, 23);
            this.txtBrideMI.TabIndex = 39;
            this.txtBrideMI.UseSelectable = true;
            this.txtBrideMI.WaterMark = "M.I.";
            this.txtBrideMI.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBrideMI.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtBrideLN
            // 
            // 
            // 
            // 
            this.txtBrideLN.CustomButton.Image = null;
            this.txtBrideLN.CustomButton.Location = new System.Drawing.Point(85, 1);
            this.txtBrideLN.CustomButton.Name = "";
            this.txtBrideLN.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBrideLN.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBrideLN.CustomButton.TabIndex = 1;
            this.txtBrideLN.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBrideLN.CustomButton.UseSelectable = true;
            this.txtBrideLN.CustomButton.Visible = false;
            this.txtBrideLN.Lines = new string[0];
            this.txtBrideLN.Location = new System.Drawing.Point(159, 182);
            this.txtBrideLN.MaxLength = 32767;
            this.txtBrideLN.Name = "txtBrideLN";
            this.txtBrideLN.PasswordChar = '\0';
            this.txtBrideLN.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBrideLN.SelectedText = "";
            this.txtBrideLN.SelectionLength = 0;
            this.txtBrideLN.SelectionStart = 0;
            this.txtBrideLN.ShortcutsEnabled = true;
            this.txtBrideLN.Size = new System.Drawing.Size(107, 23);
            this.txtBrideLN.TabIndex = 39;
            this.txtBrideLN.UseSelectable = true;
            this.txtBrideLN.WaterMark = "Last Name";
            this.txtBrideLN.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBrideLN.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtBrideSuffix
            // 
            // 
            // 
            // 
            this.txtBrideSuffix.CustomButton.Image = null;
            this.txtBrideSuffix.CustomButton.Location = new System.Drawing.Point(28, 1);
            this.txtBrideSuffix.CustomButton.Name = "";
            this.txtBrideSuffix.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBrideSuffix.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBrideSuffix.CustomButton.TabIndex = 1;
            this.txtBrideSuffix.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBrideSuffix.CustomButton.UseSelectable = true;
            this.txtBrideSuffix.CustomButton.Visible = false;
            this.txtBrideSuffix.Lines = new string[0];
            this.txtBrideSuffix.Location = new System.Drawing.Point(272, 182);
            this.txtBrideSuffix.MaxLength = 32767;
            this.txtBrideSuffix.Name = "txtBrideSuffix";
            this.txtBrideSuffix.PasswordChar = '\0';
            this.txtBrideSuffix.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBrideSuffix.SelectedText = "";
            this.txtBrideSuffix.SelectionLength = 0;
            this.txtBrideSuffix.SelectionStart = 0;
            this.txtBrideSuffix.ShortcutsEnabled = true;
            this.txtBrideSuffix.Size = new System.Drawing.Size(50, 23);
            this.txtBrideSuffix.TabIndex = 39;
            this.txtBrideSuffix.UseSelectable = true;
            this.txtBrideSuffix.WaterMark = "Suffix";
            this.txtBrideSuffix.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBrideSuffix.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtPrice
            // 
            this.txtPrice.DecimalPlaces = 2;
            this.txtPrice.Location = new System.Drawing.Point(9, 309);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(120, 20);
            this.txtPrice.TabIndex = 41;
            // 
            // txtRemarks
            // 
            // 
            // 
            // 
            this.txtRemarks.CustomButton.Image = null;
            this.txtRemarks.CustomButton.Location = new System.Drawing.Point(273, 2);
            this.txtRemarks.CustomButton.Name = "";
            this.txtRemarks.CustomButton.Size = new System.Drawing.Size(35, 35);
            this.txtRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRemarks.CustomButton.TabIndex = 1;
            this.txtRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRemarks.CustomButton.UseSelectable = true;
            this.txtRemarks.CustomButton.Visible = false;
            this.txtRemarks.Lines = new string[0];
            this.txtRemarks.Location = new System.Drawing.Point(11, 367);
            this.txtRemarks.MaxLength = 32767;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.PasswordChar = '\0';
            this.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRemarks.SelectedText = "";
            this.txtRemarks.SelectionLength = 0;
            this.txtRemarks.SelectionStart = 0;
            this.txtRemarks.ShortcutsEnabled = true;
            this.txtRemarks.Size = new System.Drawing.Size(311, 40);
            this.txtRemarks.TabIndex = 42;
            this.txtRemarks.UseSelectable = true;
            this.txtRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // AddMarriageApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(345, 458);
            this.ControlBox = false;
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtBrideSuffix);
            this.Controls.Add(this.txtGroomSuffix);
            this.Controls.Add(this.txtBrideLN);
            this.Controls.Add(this.txtGroomLN);
            this.Controls.Add(this.txtBrideMI);
            this.Controls.Add(this.txtGroomMI);
            this.Controls.Add(this.txtBrideFN);
            this.Controls.Add(this.txtGroomFN);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpBrideBirthDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.application_remarks_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpGroomBirthDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddMarriageApplication";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Load += new System.EventHandler(this.AddMarriageApplication_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddMarriageApplication_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AddMarriageApplication_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close_picturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroDateTime dtpGroomBirthDate;
        private System.Windows.Forms.Label application_remarks_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroDateTime dtpBrideBirthDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox close_picturebox;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label8;
        private MetroFramework.Controls.MetroTextBox txtGroomFN;
        private MetroFramework.Controls.MetroTextBox txtGroomMI;
        private MetroFramework.Controls.MetroTextBox txtGroomLN;
        private MetroFramework.Controls.MetroTextBox txtGroomSuffix;
        private MetroFramework.Controls.MetroTextBox txtBrideFN;
        private MetroFramework.Controls.MetroTextBox txtBrideMI;
        private MetroFramework.Controls.MetroTextBox txtBrideLN;
        private MetroFramework.Controls.MetroTextBox txtBrideSuffix;
        private HiddenNumericUpDown txtPrice;
        private MetroFramework.Controls.MetroTextBox txtRemarks;
    }
}