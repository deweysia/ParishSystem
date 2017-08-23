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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.birthdate_dtp = new MetroFramework.Controls.MetroDateTime();
            this.male_radio = new MetroFramework.Controls.MetroRadioButton();
            this.female_radio = new MetroFramework.Controls.MetroRadioButton();
            this.firstName_textBox = new System.Windows.Forms.TextBox();
            this.midName_textBox = new System.Windows.Forms.TextBox();
            this.lastName_textBox = new System.Windows.Forms.TextBox();
            this.suffix_textBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.price_textBox = new System.Windows.Forms.TextBox();
            this.application_remarks_textBox = new System.Windows.Forms.Label();
            this.remarks_textBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sacrament Application";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(24, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gender";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(22, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(24, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Birthdate";
            // 
            // birthdate_dtp
            // 
            this.birthdate_dtp.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.birthdate_dtp.Location = new System.Drawing.Point(26, 179);
            this.birthdate_dtp.MaxDate = new System.DateTime(2017, 7, 16, 0, 0, 0, 0);
            this.birthdate_dtp.MinimumSize = new System.Drawing.Size(0, 25);
            this.birthdate_dtp.Name = "birthdate_dtp";
            this.birthdate_dtp.Size = new System.Drawing.Size(200, 25);
            this.birthdate_dtp.TabIndex = 7;
            this.birthdate_dtp.Value = new System.DateTime(2017, 7, 16, 0, 0, 0, 0);
            // 
            // male_radio
            // 
            this.male_radio.AutoSize = true;
            this.male_radio.Checked = true;
            this.male_radio.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.male_radio.ForeColor = System.Drawing.Color.Black;
            this.male_radio.Location = new System.Drawing.Point(26, 122);
            this.male_radio.Name = "male_radio";
            this.male_radio.Size = new System.Drawing.Size(55, 19);
            this.male_radio.Style = MetroFramework.MetroColorStyle.Blue;
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
            this.female_radio.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.female_radio.ForeColor = System.Drawing.Color.Black;
            this.female_radio.Location = new System.Drawing.Point(106, 124);
            this.female_radio.Name = "female_radio";
            this.female_radio.Size = new System.Drawing.Size(68, 19);
            this.female_radio.Style = MetroFramework.MetroColorStyle.Blue;
            this.female_radio.TabIndex = 6;
            this.female_radio.Text = "Female";
            this.female_radio.UseCustomBackColor = true;
            this.female_radio.UseCustomForeColor = true;
            this.female_radio.UseSelectable = true;
            this.female_radio.UseStyleColors = true;
            // 
            // firstName_textBox
            // 
            this.firstName_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.firstName_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstName_textBox.ForeColor = System.Drawing.Color.Gray;
            this.firstName_textBox.Location = new System.Drawing.Point(21, 72);
            this.firstName_textBox.MaxLength = 50;
            this.firstName_textBox.Name = "firstName_textBox";
            this.firstName_textBox.Size = new System.Drawing.Size(104, 15);
            this.firstName_textBox.TabIndex = 1;
            this.firstName_textBox.Tag = "First Name";
            this.firstName_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.firstName_textBox.Enter += new System.EventHandler(this.name_textBox_Enter);
            this.firstName_textBox.Leave += new System.EventHandler(this.name_textBox_Leave);
            // 
            // midName_textBox
            // 
            this.midName_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.midName_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.midName_textBox.ForeColor = System.Drawing.Color.Gray;
            this.midName_textBox.Location = new System.Drawing.Point(131, 72);
            this.midName_textBox.MaxLength = 1;
            this.midName_textBox.Name = "midName_textBox";
            this.midName_textBox.Size = new System.Drawing.Size(22, 15);
            this.midName_textBox.TabIndex = 2;
            this.midName_textBox.Tag = "Mi";
            this.midName_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.midName_textBox.Enter += new System.EventHandler(this.name_textBox_Enter);
            this.midName_textBox.Leave += new System.EventHandler(this.name_textBox_Leave);
            // 
            // lastName_textBox
            // 
            this.lastName_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastName_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastName_textBox.ForeColor = System.Drawing.Color.Gray;
            this.lastName_textBox.Location = new System.Drawing.Point(159, 72);
            this.lastName_textBox.MaxLength = 50;
            this.lastName_textBox.Name = "lastName_textBox";
            this.lastName_textBox.Size = new System.Drawing.Size(111, 15);
            this.lastName_textBox.TabIndex = 3;
            this.lastName_textBox.Tag = "Last Name";
            this.lastName_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lastName_textBox.Enter += new System.EventHandler(this.name_textBox_Enter);
            this.lastName_textBox.Leave += new System.EventHandler(this.name_textBox_Leave);
            // 
            // suffix_textBox
            // 
            this.suffix_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.suffix_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suffix_textBox.ForeColor = System.Drawing.Color.Gray;
            this.suffix_textBox.Location = new System.Drawing.Point(276, 72);
            this.suffix_textBox.MaxLength = 5;
            this.suffix_textBox.Name = "suffix_textBox";
            this.suffix_textBox.Size = new System.Drawing.Size(31, 15);
            this.suffix_textBox.TabIndex = 4;
            this.suffix_textBox.Tag = "Sf";
            this.suffix_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.suffix_textBox.Enter += new System.EventHandler(this.name_textBox_Enter);
            this.suffix_textBox.Leave += new System.EventHandler(this.name_textBox_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ParishSystem.Properties.Resources.Delete_32px;
            this.pictureBox1.Location = new System.Drawing.Point(301, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(21, 219);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(290, 2);
            this.label6.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(27, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Price";
            // 
            // price_textBox
            // 
            this.price_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price_textBox.ForeColor = System.Drawing.Color.Black;
            this.price_textBox.Location = new System.Drawing.Point(25, 244);
            this.price_textBox.Name = "price_textBox";
            this.price_textBox.Size = new System.Drawing.Size(201, 26);
            this.price_textBox.TabIndex = 17;
            // 
            // application_remarks_textBox
            // 
            this.application_remarks_textBox.AutoSize = true;
            this.application_remarks_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.application_remarks_textBox.ForeColor = System.Drawing.Color.Black;
            this.application_remarks_textBox.Location = new System.Drawing.Point(24, 275);
            this.application_remarks_textBox.Name = "application_remarks_textBox";
            this.application_remarks_textBox.Size = new System.Drawing.Size(63, 16);
            this.application_remarks_textBox.TabIndex = 18;
            this.application_remarks_textBox.Text = "Remarks";
            // 
            // remarks_textBox
            // 
            this.remarks_textBox.ForeColor = System.Drawing.Color.Black;
            this.remarks_textBox.Location = new System.Drawing.Point(26, 292);
            this.remarks_textBox.Multiline = true;
            this.remarks_textBox.Name = "remarks_textBox";
            this.remarks_textBox.Size = new System.Drawing.Size(286, 38);
            this.remarks_textBox.TabIndex = 19;
            this.remarks_textBox.Tag = "Remarks";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(108)))), ((int)(((byte)(179)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 34);
            this.panel1.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(108)))), ((int)(((byte)(179)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(68, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 32);
            this.button1.TabIndex = 23;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.application_apply_button_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "______________";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "______________";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "______________";
            // 
            // AddApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(332, 383);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.remarks_textBox);
            this.Controls.Add(this.application_remarks_textBox);
            this.Controls.Add(this.price_textBox);
            this.Controls.Add(this.lastName_textBox);
            this.Controls.Add(this.suffix_textBox);
            this.Controls.Add(this.midName_textBox);
            this.Controls.Add(this.firstName_textBox);
            this.Controls.Add(this.female_radio);
            this.Controls.Add(this.male_radio);
            this.Controls.Add(this.birthdate_dtp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddApplication";
            this.Padding = new System.Windows.Forms.Padding(20, 20, 20, 0);
            this.Text = "AddApplication";
            this.Load += new System.EventHandler(this.AddApplication_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddApplication_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AddApplication_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.TextBox lastName_textBox;
        private System.Windows.Forms.TextBox suffix_textBox;
        private System.Windows.Forms.TextBox midName_textBox;
        private System.Windows.Forms.TextBox firstName_textBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox remarks_textBox;
        private System.Windows.Forms.Label application_remarks_textBox;
        private System.Windows.Forms.TextBox price_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}