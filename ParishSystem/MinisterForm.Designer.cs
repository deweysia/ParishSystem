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
            this.firstName_textBox = new System.Windows.Forms.TextBox();
            this.mi_textBox = new System.Windows.Forms.TextBox();
            this.lastName_textBox = new System.Windows.Forms.TextBox();
            this.suffix_textBox = new System.Windows.Forms.TextBox();
            this.birthDate_dtp = new MetroFramework.Controls.MetroDateTime();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.status_cBox = new MetroFramework.Controls.MetroComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.licenseNum_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.expirationDate_dtp = new MetroFramework.Controls.MetroDateTime();
            this.label7 = new System.Windows.Forms.Label();
            this.addBtn = new MetroFramework.Controls.MetroButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ministryType_cBox = new MetroFramework.Controls.MetroComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // firstName_textBox
            // 
            this.firstName_textBox.Location = new System.Drawing.Point(104, 50);
            this.firstName_textBox.Name = "firstName_textBox";
            this.firstName_textBox.Size = new System.Drawing.Size(100, 21);
            this.firstName_textBox.TabIndex = 0;
            this.firstName_textBox.TextChanged += new System.EventHandler(this.licenseNum_textBox_TextChanged);
            // 
            // mi_textBox
            // 
            this.mi_textBox.Location = new System.Drawing.Point(210, 50);
            this.mi_textBox.Name = "mi_textBox";
            this.mi_textBox.Size = new System.Drawing.Size(25, 21);
            this.mi_textBox.TabIndex = 1;
            this.mi_textBox.TextChanged += new System.EventHandler(this.licenseNum_textBox_TextChanged);
            // 
            // lastName_textBox
            // 
            this.lastName_textBox.Location = new System.Drawing.Point(241, 50);
            this.lastName_textBox.Name = "lastName_textBox";
            this.lastName_textBox.Size = new System.Drawing.Size(100, 21);
            this.lastName_textBox.TabIndex = 2;
            this.lastName_textBox.TextChanged += new System.EventHandler(this.licenseNum_textBox_TextChanged);
            // 
            // suffix_textBox
            // 
            this.suffix_textBox.Location = new System.Drawing.Point(347, 50);
            this.suffix_textBox.Name = "suffix_textBox";
            this.suffix_textBox.Size = new System.Drawing.Size(35, 21);
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
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Birth Date";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ministry Type";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(0, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(408, 2);
            this.label4.TabIndex = 4;
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
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Status";
            // 
            // licenseNum_textBox
            // 
            this.licenseNum_textBox.Location = new System.Drawing.Point(110, 31);
            this.licenseNum_textBox.Name = "licenseNum_textBox";
            this.licenseNum_textBox.Size = new System.Drawing.Size(116, 21);
            this.licenseNum_textBox.TabIndex = 8;
            this.licenseNum_textBox.TextChanged += new System.EventHandler(this.licenseNum_textBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "License Number";
            // 
            // expirationDate_dtp
            // 
            this.expirationDate_dtp.Location = new System.Drawing.Point(110, 61);
            this.expirationDate_dtp.MinimumSize = new System.Drawing.Size(0, 29);
            this.expirationDate_dtp.Name = "expirationDate_dtp";
            this.expirationDate_dtp.Size = new System.Drawing.Size(233, 29);
            this.expirationDate_dtp.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "Expiration Date";
            // 
            // addBtn
            // 
            this.addBtn.Enabled = false;
            this.addBtn.Location = new System.Drawing.Point(150, 411);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(87, 27);
            this.addBtn.TabIndex = 9;
            this.addBtn.Text = "Add";
            this.addBtn.UseSelectable = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "Minister";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "License";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ministryType_cBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.firstName_textBox);
            this.panel1.Controls.Add(this.mi_textBox);
            this.panel1.Controls.Add(this.lastName_textBox);
            this.panel1.Controls.Add(this.suffix_textBox);
            this.panel1.Controls.Add(this.birthDate_dtp);
            this.panel1.Controls.Add(this.status_cBox);
            this.panel1.Location = new System.Drawing.Point(11, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 200);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.licenseNum_textBox);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.expirationDate_dtp);
            this.panel2.Location = new System.Drawing.Point(11, 279);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(397, 100);
            this.panel2.TabIndex = 13;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(334, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MinisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(421, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MinisterForm";
            this.Text = "MinisterForm";
            this.Load += new System.EventHandler(this.MinisterForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox firstName_textBox;
        private System.Windows.Forms.TextBox mi_textBox;
        private System.Windows.Forms.TextBox lastName_textBox;
        private System.Windows.Forms.TextBox suffix_textBox;
        private MetroFramework.Controls.MetroDateTime birthDate_dtp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroComboBox status_cBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox licenseNum_textBox;
        private System.Windows.Forms.Label label6;
        private MetroFramework.Controls.MetroDateTime expirationDate_dtp;
        private System.Windows.Forms.Label label7;
        private MetroFramework.Controls.MetroButton addBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroComboBox ministryType_cBox;
        private System.Windows.Forms.Button btnClose;
    }
}