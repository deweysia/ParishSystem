namespace ParishSystem
{
    partial class topBarControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Min = new System.Windows.Forms.Button();
            this.btn_Max = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Min
            // 
            this.btn_Min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Min.BackgroundImage = global::SAD3.Properties.Resources.btn_minImage;
            this.btn_Min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Min.FlatAppearance.BorderSize = 0;
            this.btn_Min.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Min.Location = new System.Drawing.Point(928, 5);
            this.btn_Min.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Min.Name = "btn_Min";
            this.btn_Min.Size = new System.Drawing.Size(53, 41);
            this.btn_Min.TabIndex = 0;
            this.btn_Min.UseVisualStyleBackColor = true;
            // 
            // btn_Max
            // 
            this.btn_Max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Max.BackgroundImage = global::SAD3.Properties.Resources.btn_maxImage;
            this.btn_Max.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Max.FlatAppearance.BorderSize = 0;
            this.btn_Max.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Max.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Max.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Max.Location = new System.Drawing.Point(976, 5);
            this.btn_Max.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Max.Name = "btn_Max";
            this.btn_Max.Size = new System.Drawing.Size(53, 41);
            this.btn_Max.TabIndex = 0;
            this.btn_Max.UseVisualStyleBackColor = true;
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackgroundImage = global::SAD3.Properties.Resources.btn_closeImage;
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Location = new System.Drawing.Point(1024, 5);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(53, 41);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // topBarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.Controls.Add(this.btn_Min);
            this.Controls.Add(this.btn_Max);
            this.Controls.Add(this.btn_Close);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "topBarControl";
            this.Size = new System.Drawing.Size(1081, 49);
            this.Load += new System.EventHandler(this.topBarControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Max;
        private System.Windows.Forms.Button btn_Min;
    }
}
