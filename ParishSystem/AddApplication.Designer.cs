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
            this.components = new System.ComponentModel.Container();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.application_birthdate_dtp = new MetroFramework.Controls.MetroDateTime();
            this.application_male_radio = new MetroFramework.Controls.MetroRadioButton();
            this.application_female_radio = new MetroFramework.Controls.MetroRadioButton();
            this.application_firstName_textBox = new System.Windows.Forms.TextBox();
            this.application_midName_textBox = new System.Windows.Forms.TextBox();
            this.application_lastName_textBox = new System.Windows.Forms.TextBox();
            this.application_suffix_textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.hiddenTabControl1 = new ParishSystem.HiddenTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.application_apply_button = new MetroFramework.Controls.MetroButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.applicationNotice_label = new System.Windows.Forms.Label();
            this.application_createNewProfile_button = new MetroFramework.Controls.MetroButton();
            this.application_cancel_button = new MetroFramework.Controls.MetroButton();
            this.application_yes_button = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.hiddenTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sacrament Application";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gender";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Birthdate";
            // 
            // application_birthdate_dtp
            // 
            this.application_birthdate_dtp.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.application_birthdate_dtp.Location = new System.Drawing.Point(26, 163);
            this.application_birthdate_dtp.MaxDate = new System.DateTime(2017, 7, 16, 0, 0, 0, 0);
            this.application_birthdate_dtp.MinimumSize = new System.Drawing.Size(0, 25);
            this.application_birthdate_dtp.Name = "application_birthdate_dtp";
            this.application_birthdate_dtp.Size = new System.Drawing.Size(200, 25);
            this.application_birthdate_dtp.TabIndex = 7;
            this.application_birthdate_dtp.Value = new System.DateTime(2017, 7, 16, 0, 0, 0, 0);
            // 
            // application_male_radio
            // 
            this.application_male_radio.AutoSize = true;
            this.application_male_radio.Checked = true;
            this.application_male_radio.Location = new System.Drawing.Point(26, 115);
            this.application_male_radio.Name = "application_male_radio";
            this.application_male_radio.Size = new System.Drawing.Size(49, 15);
            this.application_male_radio.Style = MetroFramework.MetroColorStyle.Orange;
            this.application_male_radio.TabIndex = 5;
            this.application_male_radio.TabStop = true;
            this.application_male_radio.Text = "Male";
            this.application_male_radio.UseCustomBackColor = true;
            this.application_male_radio.UseCustomForeColor = true;
            this.application_male_radio.UseSelectable = true;
            this.application_male_radio.UseStyleColors = true;
            // 
            // application_female_radio
            // 
            this.application_female_radio.AutoSize = true;
            this.application_female_radio.BackColor = System.Drawing.Color.Transparent;
            this.application_female_radio.Location = new System.Drawing.Point(82, 115);
            this.application_female_radio.Name = "application_female_radio";
            this.application_female_radio.Size = new System.Drawing.Size(61, 15);
            this.application_female_radio.Style = MetroFramework.MetroColorStyle.Orange;
            this.application_female_radio.TabIndex = 6;
            this.application_female_radio.Text = "Female";
            this.application_female_radio.UseCustomBackColor = true;
            this.application_female_radio.UseCustomForeColor = true;
            this.application_female_radio.UseSelectable = true;
            this.application_female_radio.UseStyleColors = true;
            // 
            // application_firstName_textBox
            // 
            this.application_firstName_textBox.Location = new System.Drawing.Point(26, 65);
            this.application_firstName_textBox.MaxLength = 50;
            this.application_firstName_textBox.Name = "application_firstName_textBox";
            this.application_firstName_textBox.Size = new System.Drawing.Size(95, 20);
            this.application_firstName_textBox.TabIndex = 1;
            // 
            // application_midName_textBox
            // 
            this.application_midName_textBox.Location = new System.Drawing.Point(127, 65);
            this.application_midName_textBox.MaxLength = 1;
            this.application_midName_textBox.Name = "application_midName_textBox";
            this.application_midName_textBox.Size = new System.Drawing.Size(31, 20);
            this.application_midName_textBox.TabIndex = 2;
            // 
            // application_lastName_textBox
            // 
            this.application_lastName_textBox.Location = new System.Drawing.Point(164, 65);
            this.application_lastName_textBox.MaxLength = 50;
            this.application_lastName_textBox.Name = "application_lastName_textBox";
            this.application_lastName_textBox.Size = new System.Drawing.Size(95, 20);
            this.application_lastName_textBox.TabIndex = 3;
            // 
            // application_suffix_textBox
            // 
            this.application_suffix_textBox.Location = new System.Drawing.Point(265, 65);
            this.application_suffix_textBox.MaxLength = 5;
            this.application_suffix_textBox.Name = "application_suffix_textBox";
            this.application_suffix_textBox.Size = new System.Drawing.Size(39, 20);
            this.application_suffix_textBox.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ParishSystem.Properties.Resources.Delete_32px;
            this.pictureBox1.Location = new System.Drawing.Point(300, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // hiddenTabControl1
            // 
            this.hiddenTabControl1.Controls.Add(this.tabPage1);
            this.hiddenTabControl1.Controls.Add(this.tabPage2);
            this.hiddenTabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hiddenTabControl1.Location = new System.Drawing.Point(20, 208);
            this.hiddenTabControl1.Name = "hiddenTabControl1";
            this.hiddenTabControl1.SelectedIndex = 0;
            this.hiddenTabControl1.Size = new System.Drawing.Size(292, 120);
            this.hiddenTabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabPage1.Controls.Add(this.application_apply_button);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(284, 94);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // application_apply_button
            // 
            this.application_apply_button.Location = new System.Drawing.Point(103, 65);
            this.application_apply_button.Name = "application_apply_button";
            this.application_apply_button.Size = new System.Drawing.Size(75, 23);
            this.application_apply_button.Style = MetroFramework.MetroColorStyle.Orange;
            this.application_apply_button.TabIndex = 10;
            this.application_apply_button.Text = "Apply";
            this.application_apply_button.UseSelectable = true;
            this.application_apply_button.UseStyleColors = true;
            this.application_apply_button.Click += new System.EventHandler(this.application_apply_button_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(284, 94);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.applicationNotice_label);
            this.panel1.Controls.Add(this.application_createNewProfile_button);
            this.panel1.Controls.Add(this.application_cancel_button);
            this.panel1.Controls.Add(this.application_yes_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 88);
            this.panel1.TabIndex = 15;
            this.panel1.Visible = false;
            // 
            // applicationNotice_label
            // 
            this.applicationNotice_label.AutoSize = true;
            this.applicationNotice_label.Location = new System.Drawing.Point(3, 20);
            this.applicationNotice_label.Name = "applicationNotice_label";
            this.applicationNotice_label.Size = new System.Drawing.Size(415, 13);
            this.applicationNotice_label.TabIndex = 1;
            this.applicationNotice_label.Text = "A profile with the same name, gender, and birthdate already exists. Use existing " +
    "profile?";
            // 
            // application_createNewProfile_button
            // 
            this.application_createNewProfile_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.application_createNewProfile_button.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.application_createNewProfile_button.Location = new System.Drawing.Point(165, 62);
            this.application_createNewProfile_button.Name = "application_createNewProfile_button";
            this.application_createNewProfile_button.Size = new System.Drawing.Size(111, 23);
            this.application_createNewProfile_button.Style = MetroFramework.MetroColorStyle.Orange;
            this.application_createNewProfile_button.TabIndex = 0;
            this.application_createNewProfile_button.Text = "Create New Profile";
            this.application_createNewProfile_button.UseSelectable = true;
            this.application_createNewProfile_button.UseStyleColors = true;
            this.application_createNewProfile_button.Click += new System.EventHandler(this.application_createNewProfile_button_Click);
            // 
            // application_cancel_button
            // 
            this.application_cancel_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.application_cancel_button.Location = new System.Drawing.Point(3, 62);
            this.application_cancel_button.Name = "application_cancel_button";
            this.application_cancel_button.Size = new System.Drawing.Size(75, 23);
            this.application_cancel_button.Style = MetroFramework.MetroColorStyle.Orange;
            this.application_cancel_button.TabIndex = 0;
            this.application_cancel_button.Text = "Cancel";
            this.application_cancel_button.UseSelectable = true;
            this.application_cancel_button.UseStyleColors = true;
            // 
            // application_yes_button
            // 
            this.application_yes_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.application_yes_button.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.application_yes_button.Location = new System.Drawing.Point(84, 62);
            this.application_yes_button.Name = "application_yes_button";
            this.application_yes_button.Size = new System.Drawing.Size(75, 23);
            this.application_yes_button.Style = MetroFramework.MetroColorStyle.Orange;
            this.application_yes_button.TabIndex = 0;
            this.application_yes_button.Text = "Yes";
            this.application_yes_button.UseSelectable = true;
            this.application_yes_button.UseStyleColors = true;
            // 
            // AddApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(332, 328);
            this.Controls.Add(this.hiddenTabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.application_lastName_textBox);
            this.Controls.Add(this.application_suffix_textBox);
            this.Controls.Add(this.application_midName_textBox);
            this.Controls.Add(this.application_firstName_textBox);
            this.Controls.Add(this.application_female_radio);
            this.Controls.Add(this.application_male_radio);
            this.Controls.Add(this.application_birthdate_dtp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddApplication";
            this.Padding = new System.Windows.Forms.Padding(20, 20, 20, 0);
            this.Text = "AddApplication";
            this.Load += new System.EventHandler(this.AddApplication_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddApplication_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AddApplication_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.hiddenTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private MetroFramework.Controls.MetroRadioButton application_female_radio;
        private MetroFramework.Controls.MetroRadioButton application_male_radio;
        private MetroFramework.Controls.MetroDateTime application_birthdate_dtp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox application_lastName_textBox;
        private System.Windows.Forms.TextBox application_suffix_textBox;
        private System.Windows.Forms.TextBox application_midName_textBox;
        private System.Windows.Forms.TextBox application_firstName_textBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private HiddenTabControl hiddenTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MetroFramework.Controls.MetroButton application_apply_button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label applicationNotice_label;
        private MetroFramework.Controls.MetroButton application_createNewProfile_button;
        private MetroFramework.Controls.MetroButton application_cancel_button;
        private MetroFramework.Controls.MetroButton application_yes_button;
    }
}