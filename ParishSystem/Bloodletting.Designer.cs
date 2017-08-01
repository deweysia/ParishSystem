namespace ParishSystem
{
    partial class Bloodletting
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
            this.donors_datagridview_bloodletting = new System.Windows.Forms.DataGridView();
            this.bloodletting_panel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.donors_datagridview_bloodletting)).BeginInit();
            this.bloodletting_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // donors_datagridview_bloodletting
            // 
            this.donors_datagridview_bloodletting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.donors_datagridview_bloodletting.Location = new System.Drawing.Point(25, 51);
            this.donors_datagridview_bloodletting.Name = "donors_datagridview_bloodletting";
            this.donors_datagridview_bloodletting.Size = new System.Drawing.Size(643, 342);
            this.donors_datagridview_bloodletting.TabIndex = 0;
            this.donors_datagridview_bloodletting.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.donors_datagridview_bloodletting_CellContentClick);
            // 
            // bloodletting_panel
            // 
            this.bloodletting_panel.Controls.Add(this.textBox1);
            this.bloodletting_panel.Controls.Add(this.donors_datagridview_bloodletting);
            this.bloodletting_panel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bloodletting_panel.Location = new System.Drawing.Point(106, 104);
            this.bloodletting_panel.Name = "bloodletting_panel";
            this.bloodletting_panel.Size = new System.Drawing.Size(701, 406);
            this.bloodletting_panel.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(643, 29);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Events";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Donors";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(466, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Bloodletting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 507);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bloodletting_panel);
            this.Name = "Bloodletting";
            this.Text = "Bloodletting";
            this.Load += new System.EventHandler(this.Bloodletting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.donors_datagridview_bloodletting)).EndInit();
            this.bloodletting_panel.ResumeLayout(false);
            this.bloodletting_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView donors_datagridview_bloodletting;
        private System.Windows.Forms.Panel bloodletting_panel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}