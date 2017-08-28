namespace ParishSystem
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
            this.txtGroomLN = new System.Windows.Forms.TextBox();
            this.txtGroomSuffix = new System.Windows.Forms.TextBox();
            this.txtGroomMI = new System.Windows.Forms.TextBox();
            this.txtGroomFN = new System.Windows.Forms.TextBox();
            this.dtpGroomBirthDate = new MetroFramework.Controls.MetroDateTime();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.application_remarks_textBox = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBrideLN = new System.Windows.Forms.TextBox();
            this.txtBrideSuffix = new System.Windows.Forms.TextBox();
            this.txtBrideMI = new System.Windows.Forms.TextBox();
            this.txtBrideFN = new System.Windows.Forms.TextBox();
            this.dtpBrideBirthDate = new MetroFramework.Controls.MetroDateTime();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.close_picturebox = new System.Windows.Forms.PictureBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close_picturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGroomLN
            // 
            this.txtGroomLN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGroomLN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroomLN.ForeColor = System.Drawing.Color.Gray;
            this.txtGroomLN.Location = new System.Drawing.Point(159, 69);
            this.txtGroomLN.MaxLength = 50;
            this.txtGroomLN.Name = "txtGroomLN";
            this.txtGroomLN.Size = new System.Drawing.Size(125, 19);
            this.txtGroomLN.TabIndex = 2;
            this.txtGroomLN.Tag = "Last Name";
            this.txtGroomLN.Text = "Last Name";
            this.txtGroomLN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGroomLN.Enter += new System.EventHandler(this.name_textBox_Enter);
            this.txtGroomLN.Leave += new System.EventHandler(this.name_textBox_Leave);
            // 
            // txtGroomSuffix
            // 
            this.txtGroomSuffix.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGroomSuffix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroomSuffix.ForeColor = System.Drawing.Color.Gray;
            this.txtGroomSuffix.Location = new System.Drawing.Point(290, 69);
            this.txtGroomSuffix.MaxLength = 5;
            this.txtGroomSuffix.Name = "txtGroomSuffix";
            this.txtGroomSuffix.Size = new System.Drawing.Size(47, 19);
            this.txtGroomSuffix.TabIndex = 3;
            this.txtGroomSuffix.Tag = "Sf";
            this.txtGroomSuffix.Text = "Sf";
            this.txtGroomSuffix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGroomSuffix.Enter += new System.EventHandler(this.name_textBox_Enter);
            this.txtGroomSuffix.Leave += new System.EventHandler(this.name_textBox_Leave);
            // 
            // txtGroomMI
            // 
            this.txtGroomMI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGroomMI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroomMI.ForeColor = System.Drawing.Color.Gray;
            this.txtGroomMI.Location = new System.Drawing.Point(122, 69);
            this.txtGroomMI.MaxLength = 1;
            this.txtGroomMI.Name = "txtGroomMI";
            this.txtGroomMI.Size = new System.Drawing.Size(31, 19);
            this.txtGroomMI.TabIndex = 1;
            this.txtGroomMI.Tag = "Mi";
            this.txtGroomMI.Text = "Mi";
            this.txtGroomMI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGroomMI.Enter += new System.EventHandler(this.name_textBox_Enter);
            this.txtGroomMI.Leave += new System.EventHandler(this.name_textBox_Leave);
            // 
            // txtGroomFN
            // 
            this.txtGroomFN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGroomFN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroomFN.ForeColor = System.Drawing.Color.Gray;
            this.txtGroomFN.Location = new System.Drawing.Point(9, 69);
            this.txtGroomFN.MaxLength = 50;
            this.txtGroomFN.Name = "txtGroomFN";
            this.txtGroomFN.Size = new System.Drawing.Size(107, 19);
            this.txtGroomFN.TabIndex = 0;
            this.txtGroomFN.Tag = "First Name";
            this.txtGroomFN.Text = "First Name";
            this.txtGroomFN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGroomFN.Enter += new System.EventHandler(this.name_textBox_Enter);
            this.txtGroomFN.Leave += new System.EventHandler(this.name_textBox_Leave);
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
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(9, 367);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(328, 36);
            this.txtRemarks.TabIndex = 10;
            this.txtRemarks.Tag = "Remarks";
            // 
            // application_remarks_textBox
            // 
            this.application_remarks_textBox.AutoSize = true;
            this.application_remarks_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.application_remarks_textBox.Location = new System.Drawing.Point(17, 347);
            this.application_remarks_textBox.Name = "application_remarks_textBox";
            this.application_remarks_textBox.Size = new System.Drawing.Size(63, 16);
            this.application_remarks_textBox.TabIndex = 22;
            this.application_remarks_textBox.Text = "Remarks";
            this.application_remarks_textBox.Click += new System.EventHandler(this.application_remarks_textBox_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPrice.Location = new System.Drawing.Point(9, 311);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(144, 26);
            this.txtPrice.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Groom";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "Birthdate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Bride";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "Birthdate";
            // 
            // txtBrideLN
            // 
            this.txtBrideLN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBrideLN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBrideLN.ForeColor = System.Drawing.Color.Gray;
            this.txtBrideLN.Location = new System.Drawing.Point(159, 185);
            this.txtBrideLN.MaxLength = 50;
            this.txtBrideLN.Name = "txtBrideLN";
            this.txtBrideLN.Size = new System.Drawing.Size(125, 19);
            this.txtBrideLN.TabIndex = 7;
            this.txtBrideLN.Tag = "Last Name";
            this.txtBrideLN.Text = "Last Name";
            this.txtBrideLN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBrideLN.Enter += new System.EventHandler(this.name_textBox_Enter);
            this.txtBrideLN.Leave += new System.EventHandler(this.name_textBox_Leave);
            // 
            // txtBrideSuffix
            // 
            this.txtBrideSuffix.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBrideSuffix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBrideSuffix.ForeColor = System.Drawing.Color.Gray;
            this.txtBrideSuffix.Location = new System.Drawing.Point(290, 185);
            this.txtBrideSuffix.MaxLength = 5;
            this.txtBrideSuffix.Name = "txtBrideSuffix";
            this.txtBrideSuffix.Size = new System.Drawing.Size(47, 19);
            this.txtBrideSuffix.TabIndex = 8;
            this.txtBrideSuffix.Tag = "Sf";
            this.txtBrideSuffix.Text = "Sf";
            this.txtBrideSuffix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBrideSuffix.Enter += new System.EventHandler(this.name_textBox_Enter);
            this.txtBrideSuffix.Leave += new System.EventHandler(this.name_textBox_Leave);
            // 
            // txtBrideMI
            // 
            this.txtBrideMI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBrideMI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBrideMI.ForeColor = System.Drawing.Color.Gray;
            this.txtBrideMI.Location = new System.Drawing.Point(122, 185);
            this.txtBrideMI.MaxLength = 1;
            this.txtBrideMI.Name = "txtBrideMI";
            this.txtBrideMI.Size = new System.Drawing.Size(31, 19);
            this.txtBrideMI.TabIndex = 6;
            this.txtBrideMI.Tag = "Mi";
            this.txtBrideMI.Text = "Mi";
            this.txtBrideMI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBrideMI.Enter += new System.EventHandler(this.name_textBox_Enter);
            this.txtBrideMI.Leave += new System.EventHandler(this.name_textBox_Leave);
            // 
            // txtBrideFN
            // 
            this.txtBrideFN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBrideFN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBrideFN.ForeColor = System.Drawing.Color.Gray;
            this.txtBrideFN.Location = new System.Drawing.Point(9, 185);
            this.txtBrideFN.MaxLength = 50;
            this.txtBrideFN.Name = "txtBrideFN";
            this.txtBrideFN.Size = new System.Drawing.Size(107, 19);
            this.txtBrideFN.TabIndex = 5;
            this.txtBrideFN.Tag = "First Name";
            this.txtBrideFN.Text = "First Name";
            this.txtBrideFN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBrideFN.Enter += new System.EventHandler(this.name_textBox_Enter);
            this.txtBrideFN.Leave += new System.EventHandler(this.name_textBox_Leave);
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
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(98, 413);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(150, 29);
            this.btnApply.TabIndex = 36;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(17, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(307, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "__________________________________________________";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(17, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(307, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "__________________________________________________";
            // 
            // AddMarriageApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(345, 458);
            this.ControlBox = false;
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBrideLN);
            this.Controls.Add(this.txtBrideSuffix);
            this.Controls.Add(this.txtBrideMI);
            this.Controls.Add(this.txtBrideFN);
            this.Controls.Add(this.dtpBrideBirthDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.application_remarks_textBox);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGroomLN);
            this.Controls.Add(this.txtGroomSuffix);
            this.Controls.Add(this.txtGroomMI);
            this.Controls.Add(this.txtGroomFN);
            this.Controls.Add(this.dtpGroomBirthDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddMarriageApplication";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Load += new System.EventHandler(this.AddMarriageApplication_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close_picturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGroomLN;
        private System.Windows.Forms.TextBox txtGroomSuffix;
        private System.Windows.Forms.TextBox txtGroomMI;
        private System.Windows.Forms.TextBox txtGroomFN;
        private MetroFramework.Controls.MetroDateTime dtpGroomBirthDate;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label application_remarks_textBox;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBrideLN;
        private System.Windows.Forms.TextBox txtBrideSuffix;
        private System.Windows.Forms.TextBox txtBrideMI;
        private System.Windows.Forms.TextBox txtBrideFN;
        private MetroFramework.Controls.MetroDateTime dtpBrideBirthDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox close_picturebox;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
    }
}