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
            this.label7 = new System.Windows.Forms.Label();
            this.btnApply = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // txtGroomLN
            // 
            this.txtGroomLN.ForeColor = System.Drawing.Color.Gray;
            this.txtGroomLN.Location = new System.Drawing.Point(161, 77);
            this.txtGroomLN.MaxLength = 50;
            this.txtGroomLN.Name = "txtGroomLN";
            this.txtGroomLN.Size = new System.Drawing.Size(95, 20);
            this.txtGroomLN.TabIndex = 2;
            this.txtGroomLN.Tag = "";
            // 
            // txtGroomSuffix
            // 
            this.txtGroomSuffix.ForeColor = System.Drawing.Color.Gray;
            this.txtGroomSuffix.Location = new System.Drawing.Point(262, 77);
            this.txtGroomSuffix.MaxLength = 5;
            this.txtGroomSuffix.Name = "txtGroomSuffix";
            this.txtGroomSuffix.Size = new System.Drawing.Size(47, 20);
            this.txtGroomSuffix.TabIndex = 3;
            this.txtGroomSuffix.Tag = "Suffix";
            // 
            // txtGroomMI
            // 
            this.txtGroomMI.ForeColor = System.Drawing.Color.Gray;
            this.txtGroomMI.Location = new System.Drawing.Point(124, 77);
            this.txtGroomMI.MaxLength = 1;
            this.txtGroomMI.Name = "txtGroomMI";
            this.txtGroomMI.Size = new System.Drawing.Size(31, 20);
            this.txtGroomMI.TabIndex = 1;
            this.txtGroomMI.Tag = "";
            // 
            // txtGroomFN
            // 
            this.txtGroomFN.ForeColor = System.Drawing.Color.Gray;
            this.txtGroomFN.Location = new System.Drawing.Point(23, 77);
            this.txtGroomFN.MaxLength = 50;
            this.txtGroomFN.Name = "txtGroomFN";
            this.txtGroomFN.Size = new System.Drawing.Size(95, 20);
            this.txtGroomFN.TabIndex = 0;
            this.txtGroomFN.Tag = "";
            // 
            // dtpGroomBirthDate
            // 
            this.dtpGroomBirthDate.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dtpGroomBirthDate.Location = new System.Drawing.Point(23, 120);
            this.dtpGroomBirthDate.MaxDate = new System.DateTime(2017, 7, 16, 0, 0, 0, 0);
            this.dtpGroomBirthDate.MinimumSize = new System.Drawing.Size(0, 25);
            this.dtpGroomBirthDate.Name = "dtpGroomBirthDate";
            this.dtpGroomBirthDate.Size = new System.Drawing.Size(200, 25);
            this.dtpGroomBirthDate.TabIndex = 4;
            this.dtpGroomBirthDate.Value = new System.DateTime(2017, 7, 16, 0, 0, 0, 0);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(23, 350);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(286, 49);
            this.txtRemarks.TabIndex = 10;
            this.txtRemarks.Tag = "Remarks";
            // 
            // application_remarks_textBox
            // 
            this.application_remarks_textBox.AutoSize = true;
            this.application_remarks_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.application_remarks_textBox.Location = new System.Drawing.Point(20, 332);
            this.application_remarks_textBox.Name = "application_remarks_textBox";
            this.application_remarks_textBox.Size = new System.Drawing.Size(57, 15);
            this.application_remarks_textBox.TabIndex = 22;
            this.application_remarks_textBox.Text = "Remarks";
            this.application_remarks_textBox.Click += new System.EventHandler(this.application_remarks_textBox_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(23, 309);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "Groom";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "Birthdate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 32;
            this.label1.Text = "Bride";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 31;
            this.label2.Text = "Birthdate";
            // 
            // txtBrideLN
            // 
            this.txtBrideLN.ForeColor = System.Drawing.Color.Gray;
            this.txtBrideLN.Location = new System.Drawing.Point(161, 194);
            this.txtBrideLN.MaxLength = 50;
            this.txtBrideLN.Name = "txtBrideLN";
            this.txtBrideLN.Size = new System.Drawing.Size(95, 20);
            this.txtBrideLN.TabIndex = 7;
            this.txtBrideLN.Tag = "";
            // 
            // txtBrideSuffix
            // 
            this.txtBrideSuffix.ForeColor = System.Drawing.Color.Gray;
            this.txtBrideSuffix.Location = new System.Drawing.Point(262, 194);
            this.txtBrideSuffix.MaxLength = 5;
            this.txtBrideSuffix.Name = "txtBrideSuffix";
            this.txtBrideSuffix.Size = new System.Drawing.Size(47, 20);
            this.txtBrideSuffix.TabIndex = 8;
            this.txtBrideSuffix.Tag = "Suffix";
            // 
            // txtBrideMI
            // 
            this.txtBrideMI.ForeColor = System.Drawing.Color.Gray;
            this.txtBrideMI.Location = new System.Drawing.Point(124, 194);
            this.txtBrideMI.MaxLength = 1;
            this.txtBrideMI.Name = "txtBrideMI";
            this.txtBrideMI.Size = new System.Drawing.Size(31, 20);
            this.txtBrideMI.TabIndex = 6;
            this.txtBrideMI.Tag = "";
            // 
            // txtBrideFN
            // 
            this.txtBrideFN.ForeColor = System.Drawing.Color.Gray;
            this.txtBrideFN.Location = new System.Drawing.Point(23, 194);
            this.txtBrideFN.MaxLength = 50;
            this.txtBrideFN.Name = "txtBrideFN";
            this.txtBrideFN.Size = new System.Drawing.Size(95, 20);
            this.txtBrideFN.TabIndex = 5;
            this.txtBrideFN.Tag = "";
            // 
            // dtpBrideBirthDate
            // 
            this.dtpBrideBirthDate.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dtpBrideBirthDate.Location = new System.Drawing.Point(23, 237);
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
            this.label6.Location = new System.Drawing.Point(11, 270);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(328, 2);
            this.label6.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(105, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Marriage Application";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(124, 421);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnApply.TabIndex = 11;
            this.btnApply.Text = "Apply";
            this.btnApply.UseSelectable = true;
            this.btnApply.UseStyleColors = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // AddMarriageApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 458);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label7);
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
            this.Name = "AddMarriageApplication";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "AddMarriageApplication";
            this.Load += new System.EventHandler(this.AddMarriageApplication_Load);
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
        private System.Windows.Forms.Label label7;
        private MetroFramework.Controls.MetroButton btnApply;
    }
}