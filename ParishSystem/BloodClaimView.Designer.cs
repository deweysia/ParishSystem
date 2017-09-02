namespace ParishSystem
{
    partial class BloodClaimView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bloodletting_dgv = new System.Windows.Forms.DataGridView();
            this.search_textbox = new System.Windows.Forms.TextBox();
            this.search_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bloodletting_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // bloodletting_dgv
            // 
            this.bloodletting_dgv.AllowUserToAddRows = false;
            this.bloodletting_dgv.AllowUserToDeleteRows = false;
            this.bloodletting_dgv.AllowUserToOrderColumns = true;
            this.bloodletting_dgv.AllowUserToResizeColumns = false;
            this.bloodletting_dgv.AllowUserToResizeRows = false;
            this.bloodletting_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bloodletting_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bloodletting_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bloodletting_dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.bloodletting_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bloodletting_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.bloodletting_dgv.ColumnHeadersHeight = 40;
            this.bloodletting_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.bloodletting_dgv.EnableHeadersVisualStyles = false;
            this.bloodletting_dgv.Location = new System.Drawing.Point(41, 73);
            this.bloodletting_dgv.MultiSelect = false;
            this.bloodletting_dgv.Name = "bloodletting_dgv";
            this.bloodletting_dgv.ReadOnly = true;
            this.bloodletting_dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bloodletting_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.bloodletting_dgv.RowHeadersVisible = false;
            this.bloodletting_dgv.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bloodletting_dgv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bloodletting_dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bloodletting_dgv.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.bloodletting_dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.bloodletting_dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.bloodletting_dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.bloodletting_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bloodletting_dgv.Size = new System.Drawing.Size(845, 423);
            this.bloodletting_dgv.TabIndex = 1;
            // 
            // search_textbox
            // 
            this.search_textbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_textbox.Location = new System.Drawing.Point(41, 29);
            this.search_textbox.Name = "search_textbox";
            this.search_textbox.Size = new System.Drawing.Size(724, 29);
            this.search_textbox.TabIndex = 2;
            this.search_textbox.TextChanged += new System.EventHandler(this.search_textbox_TextChanged);
            // 
            // search_button
            // 
            this.search_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_button.Location = new System.Drawing.Point(784, 28);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(102, 29);
            this.search_button.TabIndex = 3;
            this.search_button.Tag = "s";
            this.search_button.Text = "Search";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // BloodClaimView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(930, 540);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.search_textbox);
            this.Controls.Add(this.bloodletting_dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BloodClaimView";
            this.Text = "BloodClaims";
            this.Load += new System.EventHandler(this.BloodClaims_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bloodletting_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView bloodletting_dgv;
        private System.Windows.Forms.TextBox search_textbox;
        private System.Windows.Forms.Button search_button;
    }
}