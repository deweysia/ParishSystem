namespace ParishSystem
{
    partial class CertificatePurpose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CertificatePurpose));
            this.txtPurpose = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnContinue = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // txtPurpose
            // 
            // 
            // 
            // 
            this.txtPurpose.CustomButton.Image = null;
            this.txtPurpose.CustomButton.Location = new System.Drawing.Point(231, 1);
            this.txtPurpose.CustomButton.Name = "";
            this.txtPurpose.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPurpose.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPurpose.CustomButton.TabIndex = 1;
            this.txtPurpose.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPurpose.CustomButton.UseSelectable = true;
            this.txtPurpose.CustomButton.Visible = false;
            this.txtPurpose.Lines = new string[0];
            this.txtPurpose.Location = new System.Drawing.Point(11, 31);
            this.txtPurpose.MaxLength = 32767;
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.PasswordChar = '\0';
            this.txtPurpose.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPurpose.SelectedText = "";
            this.txtPurpose.SelectionLength = 0;
            this.txtPurpose.SelectionStart = 0;
            this.txtPurpose.ShortcutsEnabled = true;
            this.txtPurpose.Size = new System.Drawing.Size(253, 23);
            this.txtPurpose.TabIndex = 0;
            this.txtPurpose.UseSelectable = true;
            this.txtPurpose.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPurpose.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.Location = new System.Drawing.Point(12, 9);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(218, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Please specify purpose of certificate";
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(12, 60);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(120, 23);
            this.btnContinue.TabIndex = 3;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseSelectable = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(144, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CertificatePurpose
            // 
            this.AcceptButton = this.btnContinue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(276, 94);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtPurpose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CertificatePurpose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CertificatePurpose";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtPurpose;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnContinue;
        private MetroFramework.Controls.MetroButton btnCancel;
    }
}