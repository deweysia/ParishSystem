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
            this.no_button = new System.Windows.Forms.Button();
            this.yes_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.iconDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // messageText
            // 
            this.messageText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.messageText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageText.ForeColor = System.Drawing.Color.White;
            this.messageText.Location = new System.Drawing.Point(130, 31);
            this.messageText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.messageText.Multiline = true;
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(193, 94);
            this.messageText.TabIndex = 56;
            this.messageText.Text = "Do you wish to continue \r\nwith the operation?";
            // 
            // iconDisplay
            // 
            this.iconDisplay.Image = global::ParishSystem.Properties.Resources.messageBox_warning;
            this.iconDisplay.Location = new System.Drawing.Point(36, 28);
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
            this.btn_Close.Location = new System.Drawing.Point(304, 2);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(27, 25);
            this.btn_Close.TabIndex = 55;
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // no_button
            // 
            this.no_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(106)))), ((int)(((byte)(61)))));
            this.no_button.FlatAppearance.BorderSize = 0;
            this.no_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.no_button.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no_button.ForeColor = System.Drawing.Color.White;
            this.no_button.Location = new System.Drawing.Point(202, 130);
            this.no_button.Margin = new System.Windows.Forms.Padding(2);
            this.no_button.Name = "no_button";
            this.no_button.Size = new System.Drawing.Size(66, 32);
            this.no_button.TabIndex = 95;
            this.no_button.Text = "No";
            this.no_button.UseVisualStyleBackColor = false;
            this.no_button.Click += new System.EventHandler(this.no_button_Click);
            // 
            // yes_button
            // 
            this.yes_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(106)))), ((int)(((byte)(61)))));
            this.yes_button.FlatAppearance.BorderSize = 0;
            this.yes_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yes_button.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yes_button.ForeColor = System.Drawing.Color.White;
            this.yes_button.Location = new System.Drawing.Point(133, 130);
            this.yes_button.Margin = new System.Windows.Forms.Padding(2);
            this.yes_button.Name = "yes_button";
            this.yes_button.Size = new System.Drawing.Size(65, 32);
            this.yes_button.TabIndex = 96;
            this.yes_button.Text = "Yas";
            this.yes_button.UseVisualStyleBackColor = false;
            // 
            // messageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(335, 173);
            this.Controls.Add(this.no_button);
            this.Controls.Add(this.yes_button);
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
        private System.Windows.Forms.Button no_button;
        private System.Windows.Forms.Button yes_button;
    }
}