namespace ParishSystem
{
    partial class SystemSettings
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
            this.txtPDF = new MetroFramework.Controls.MetroTextBox();
            this.txtExcel = new MetroFramework.Controls.MetroTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPDF = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPDF
            // 
            // 
            // 
            // 
            this.txtPDF.CustomButton.Image = null;
            this.txtPDF.CustomButton.Location = new System.Drawing.Point(494, 1);
            this.txtPDF.CustomButton.Name = "";
            this.txtPDF.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPDF.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPDF.CustomButton.TabIndex = 1;
            this.txtPDF.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPDF.CustomButton.UseSelectable = true;
            this.txtPDF.CustomButton.Visible = false;
            this.txtPDF.Lines = new string[0];
            this.txtPDF.Location = new System.Drawing.Point(171, 19);
            this.txtPDF.MaxLength = 32767;
            this.txtPDF.Name = "txtPDF";
            this.txtPDF.PasswordChar = '\0';
            this.txtPDF.ReadOnly = true;
            this.txtPDF.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPDF.SelectedText = "";
            this.txtPDF.SelectionLength = 0;
            this.txtPDF.SelectionStart = 0;
            this.txtPDF.ShortcutsEnabled = true;
            this.txtPDF.Size = new System.Drawing.Size(516, 23);
            this.txtPDF.TabIndex = 0;
            this.txtPDF.TabStop = false;
            this.txtPDF.UseSelectable = true;
            this.txtPDF.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPDF.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtExcel
            // 
            // 
            // 
            // 
            this.txtExcel.CustomButton.Image = null;
            this.txtExcel.CustomButton.Location = new System.Drawing.Point(494, 1);
            this.txtExcel.CustomButton.Name = "";
            this.txtExcel.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtExcel.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtExcel.CustomButton.TabIndex = 1;
            this.txtExcel.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtExcel.CustomButton.UseSelectable = true;
            this.txtExcel.CustomButton.Visible = false;
            this.txtExcel.Lines = new string[0];
            this.txtExcel.Location = new System.Drawing.Point(171, 48);
            this.txtExcel.MaxLength = 32767;
            this.txtExcel.Name = "txtExcel";
            this.txtExcel.PasswordChar = '\0';
            this.txtExcel.ReadOnly = true;
            this.txtExcel.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtExcel.SelectedText = "";
            this.txtExcel.SelectionLength = 0;
            this.txtExcel.SelectionStart = 0;
            this.txtExcel.ShortcutsEnabled = true;
            this.txtExcel.Size = new System.Drawing.Size(516, 23);
            this.txtExcel.TabIndex = 0;
            this.txtExcel.TabStop = false;
            this.txtExcel.UseSelectable = true;
            this.txtExcel.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtExcel.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnExcel);
            this.groupBox1.Controls.Add(this.btnPDF);
            this.groupBox1.Controls.Add(this.txtPDF);
            this.groupBox1.Controls.Add(this.txtExcel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(906, 101);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exports";
            // 
            // btnPDF
            // 
            this.btnPDF.Location = new System.Drawing.Point(693, 19);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(75, 23);
            this.btnPDF.TabIndex = 1;
            this.btnPDF.Text = "Change";
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(693, 48);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 1;
            this.btnExcel.Text = "Change";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sacrament PDF Export Location";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Finance Excel Export Location";
            // 
            // SystemSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 540);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SystemSettings";
            this.Text = "SystemSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtPDF;
        private MetroFramework.Controls.MetroTextBox txtExcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
    }
}