namespace ParishSystem
{
    partial class ORdetailsPopUp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.items_dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.or_label = new System.Windows.Forms.Label();
            this.total_label = new System.Windows.Forms.Label();
            this.controlBar_panel = new System.Windows.Forms.Panel();
            this.close_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.items_dgv)).BeginInit();
            this.controlBar_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // items_dgv
            // 
            this.items_dgv.AllowUserToAddRows = false;
            this.items_dgv.AllowUserToDeleteRows = false;
            this.items_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.items_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.items_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.items_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.items_dgv.Location = new System.Drawing.Point(12, 81);
            this.items_dgv.Name = "items_dgv";
            this.items_dgv.ReadOnly = true;
            this.items_dgv.RowHeadersVisible = false;
            this.items_dgv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.items_dgv.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.items_dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.items_dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.items_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.items_dgv.Size = new System.Drawing.Size(392, 144);
            this.items_dgv.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "OR:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(270, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // or_label
            // 
            this.or_label.AutoSize = true;
            this.or_label.BackColor = System.Drawing.Color.White;
            this.or_label.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.or_label.ForeColor = System.Drawing.Color.Black;
            this.or_label.Location = new System.Drawing.Point(66, 41);
            this.or_label.Name = "or_label";
            this.or_label.Size = new System.Drawing.Size(80, 32);
            this.or_label.TabIndex = 4;
            this.or_label.Text = "13458";
            this.or_label.Click += new System.EventHandler(this.or_label_Click);
            // 
            // total_label
            // 
            this.total_label.AutoSize = true;
            this.total_label.BackColor = System.Drawing.Color.White;
            this.total_label.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_label.ForeColor = System.Drawing.Color.Black;
            this.total_label.Location = new System.Drawing.Point(350, 229);
            this.total_label.Name = "total_label";
            this.total_label.Size = new System.Drawing.Size(54, 32);
            this.total_label.TabIndex = 5;
            this.total_label.Text = "500";
            this.total_label.Click += new System.EventHandler(this.total_label_Click);
            // 
            // controlBar_panel
            // 
            this.controlBar_panel.BackColor = System.Drawing.Color.DimGray;
            this.controlBar_panel.Controls.Add(this.close_button);
            this.controlBar_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlBar_panel.Location = new System.Drawing.Point(0, 0);
            this.controlBar_panel.Margin = new System.Windows.Forms.Padding(0);
            this.controlBar_panel.Name = "controlBar_panel";
            this.controlBar_panel.Size = new System.Drawing.Size(416, 33);
            this.controlBar_panel.TabIndex = 58;
            // 
            // close_button
            // 
            this.close_button.BackColor = System.Drawing.Color.DimGray;
            this.close_button.FlatAppearance.BorderSize = 0;
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_button.Image = global::ParishSystem.Properties.Resources.icons8_Delete_20;
            this.close_button.Location = new System.Drawing.Point(378, 4);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(40, 29);
            this.close_button.TabIndex = 0;
            this.close_button.UseVisualStyleBackColor = false;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // ORdetailsPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(416, 270);
            this.ControlBox = false;
            this.Controls.Add(this.controlBar_panel);
            this.Controls.Add(this.total_label);
            this.Controls.Add(this.or_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.items_dgv);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ORdetailsPopUp";
            this.Load += new System.EventHandler(this.ORdetailsPopUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.items_dgv)).EndInit();
            this.controlBar_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView items_dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label or_label;
        private System.Windows.Forms.Label total_label;
        private System.Windows.Forms.Panel controlBar_panel;
        private System.Windows.Forms.Button close_button;
    }
}