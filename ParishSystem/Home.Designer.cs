namespace ParishSystem
{
    partial class Home
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
            this.username_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Min = new System.Windows.Forms.Button();
            this.btn_Max = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.Profiles = new System.Windows.Forms.Button();
            this.BL = new System.Windows.Forms.Button();
            this.RKeeping = new System.Windows.Forms.Button();
            this.BKeeping = new System.Windows.Forms.Button();
            this.PLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Corbel", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome";
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Font = new System.Drawing.Font("Corbel", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.username_label.Location = new System.Drawing.Point(130, 16);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(157, 35);
            this.username_label.TabIndex = 3;
            this.username_label.Text = "USERNAME";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.BKeeping);
            this.panel1.Controls.Add(this.RKeeping);
            this.panel1.Controls.Add(this.BL);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.PLabel);
            this.panel1.Controls.Add(this.Profiles);
            this.panel1.Location = new System.Drawing.Point(12, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 368);
            this.panel1.TabIndex = 7;
            // 
            // btn_Min
            // 
            this.btn_Min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Min.BackgroundImage = global::ParishSystem.Properties.Resources.btn_minImage;
            this.btn_Min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Min.FlatAppearance.BorderSize = 0;
            this.btn_Min.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Min.Location = new System.Drawing.Point(625, 8);
            this.btn_Min.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Min.Name = "btn_Min";
            this.btn_Min.Size = new System.Drawing.Size(40, 32);
            this.btn_Min.TabIndex = 4;
            this.btn_Min.UseVisualStyleBackColor = true;
            // 
            // btn_Max
            // 
            this.btn_Max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Max.BackgroundImage = global::ParishSystem.Properties.Resources.btn_maxImage;
            this.btn_Max.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Max.FlatAppearance.BorderSize = 0;
            this.btn_Max.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Max.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Max.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Max.Location = new System.Drawing.Point(663, 8);
            this.btn_Max.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Max.Name = "btn_Max";
            this.btn_Max.Size = new System.Drawing.Size(40, 32);
            this.btn_Max.TabIndex = 5;
            this.btn_Max.UseVisualStyleBackColor = true;
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
            this.btn_Close.Location = new System.Drawing.Point(701, 8);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(40, 32);
            this.btn_Close.TabIndex = 6;
            this.btn_Close.UseVisualStyleBackColor = true;
            // 
            // Profiles
            // 
            this.Profiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Profiles.BackColor = System.Drawing.Color.Transparent;
            this.Profiles.BackgroundImage = global::ParishSystem.Properties.Resources.UIcon;
            this.Profiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Profiles.FlatAppearance.BorderSize = 0;
            this.Profiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Profiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Profiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Profiles.Location = new System.Drawing.Point(16, 20);
            this.Profiles.Margin = new System.Windows.Forms.Padding(4);
            this.Profiles.Name = "Profiles";
            this.Profiles.Size = new System.Drawing.Size(73, 73);
            this.Profiles.TabIndex = 8;
            this.Profiles.UseVisualStyleBackColor = false;
            this.Profiles.Click += new System.EventHandler(this.Profiles_Click);
            // 
            // BL
            // 
            this.BL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BL.BackColor = System.Drawing.Color.Transparent;
            this.BL.BackgroundImage = global::ParishSystem.Properties.Resources.BLIcon;
            this.BL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BL.FlatAppearance.BorderSize = 0;
            this.BL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BL.Location = new System.Drawing.Point(16, 101);
            this.BL.Margin = new System.Windows.Forms.Padding(4);
            this.BL.Name = "BL";
            this.BL.Size = new System.Drawing.Size(73, 73);
            this.BL.TabIndex = 8;
            this.BL.UseVisualStyleBackColor = false;
            this.BL.Click += new System.EventHandler(this.button1_Click);
            // 
            // RKeeping
            // 
            this.RKeeping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RKeeping.BackColor = System.Drawing.Color.Transparent;
            this.RKeeping.BackgroundImage = global::ParishSystem.Properties.Resources.RIcon;
            this.RKeeping.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RKeeping.FlatAppearance.BorderSize = 0;
            this.RKeeping.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RKeeping.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RKeeping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RKeeping.Location = new System.Drawing.Point(16, 182);
            this.RKeeping.Margin = new System.Windows.Forms.Padding(4);
            this.RKeeping.Name = "RKeeping";
            this.RKeeping.Size = new System.Drawing.Size(73, 73);
            this.RKeeping.TabIndex = 8;
            this.RKeeping.UseVisualStyleBackColor = false;
            this.RKeeping.Click += new System.EventHandler(this.button2_Click);
            // 
            // BKeeping
            // 
            this.BKeeping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BKeeping.BackColor = System.Drawing.Color.Transparent;
            this.BKeeping.BackgroundImage = global::ParishSystem.Properties.Resources.FIcon;
            this.BKeeping.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BKeeping.FlatAppearance.BorderSize = 0;
            this.BKeeping.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BKeeping.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BKeeping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BKeeping.Location = new System.Drawing.Point(16, 263);
            this.BKeeping.Margin = new System.Windows.Forms.Padding(4);
            this.BKeeping.Name = "BKeeping";
            this.BKeeping.Size = new System.Drawing.Size(73, 73);
            this.BKeeping.TabIndex = 8;
            this.BKeeping.UseVisualStyleBackColor = false;
            this.BKeeping.Click += new System.EventHandler(this.button3_Click);
            // 
            // PLabel
            // 
            this.PLabel.AutoSize = true;
            this.PLabel.BackColor = System.Drawing.Color.Transparent;
            this.PLabel.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PLabel.ForeColor = System.Drawing.Color.Black;
            this.PLabel.Location = new System.Drawing.Point(97, 39);
            this.PLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PLabel.Name = "PLabel";
            this.PLabel.Size = new System.Drawing.Size(73, 24);
            this.PLabel.TabIndex = 2;
            this.PLabel.Text = "Profiles";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(97, 127);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bloodletting";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(97, 208);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Record Keeping";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(97, 289);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "Finance";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(754, 432);
            this.Controls.Add(this.btn_Min);
            this.Controls.Add(this.btn_Max);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.username_label);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.Button btn_Min;
        private System.Windows.Forms.Button btn_Max;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Profiles;
        private System.Windows.Forms.Button BKeeping;
        private System.Windows.Forms.Button RKeeping;
        private System.Windows.Forms.Button BL;
        private System.Windows.Forms.Label PLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}