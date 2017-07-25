namespace ParishSystem
{
    partial class messageBox
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
            this.messageText = new System.Windows.Forms.TextBox();
            this.iconDisplay = new System.Windows.Forms.PictureBox();
            this.btn_Close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.iconDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // messageText
            // 
            this.messageText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.messageText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageText.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.messageText.ForeColor = System.Drawing.Color.White;
            this.messageText.Location = new System.Drawing.Point(122, 50);
            this.messageText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(163, 25);
            this.messageText.TabIndex = 56;
            this.messageText.Text = "ReportMessage";
            // 
            // iconDisplay
            // 
            this.iconDisplay.Image = global::ParishSystem.Properties.Resources.messageBox_success;
            this.iconDisplay.Location = new System.Drawing.Point(23, 30);
            this.iconDisplay.Name = "iconDisplay";
            this.iconDisplay.Size = new System.Drawing.Size(76, 69);
            this.iconDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconDisplay.TabIndex = 57;
            this.iconDisplay.TabStop = false;
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackgroundImage = global::ParishSystem.Properties.Resources.btn_closeImage;
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Location = new System.Drawing.Point(287, 2);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(27, 25);
            this.btn_Close.TabIndex = 55;
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // messageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(318, 128);
            this.Controls.Add(this.iconDisplay);
            this.Controls.Add(this.messageText);
            this.Controls.Add(this.btn_Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "messageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "messageBox";
            this.Load += new System.EventHandler(this.messageBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.TextBox messageText;
        private System.Windows.Forms.PictureBox iconDisplay;
    }
}