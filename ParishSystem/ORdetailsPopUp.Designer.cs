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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ORdetailsPopUp));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.or_label = new System.Windows.Forms.Label();
            this.total_label = new System.Windows.Forms.Label();
            this.controlBar_panel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.close_button = new System.Windows.Forms.Button();
            this.details_dgv = new System.Windows.Forms.DataGridView();
            this.remarks_textbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.source_name = new System.Windows.Forms.Label();
            this.datepaid_label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ORTextLabel = new System.Windows.Forms.Label();
            this.checkNumberTextLabel = new System.Windows.Forms.Label();
            this.CN_label = new System.Windows.Forms.Label();
            this.checkVoucherTextLabel = new System.Windows.Forms.Label();
            this.CV_label = new System.Windows.Forms.Label();
            this.controlBar_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.details_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(358, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total:";
            // 
            // or_label
            // 
            this.or_label.AutoSize = true;
            this.or_label.BackColor = System.Drawing.Color.White;
            this.or_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.or_label.ForeColor = System.Drawing.Color.Black;
            this.or_label.Location = new System.Drawing.Point(162, 101);
            this.or_label.Name = "or_label";
            this.or_label.Size = new System.Drawing.Size(55, 21);
            this.or_label.TabIndex = 4;
            this.or_label.Text = "13458";
            // 
            // total_label
            // 
            this.total_label.AutoSize = true;
            this.total_label.BackColor = System.Drawing.Color.White;
            this.total_label.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_label.ForeColor = System.Drawing.Color.Black;
            this.total_label.Location = new System.Drawing.Point(426, 435);
            this.total_label.Name = "total_label";
            this.total_label.Size = new System.Drawing.Size(85, 32);
            this.total_label.TabIndex = 5;
            this.total_label.Text = "500.00";
            // 
            // controlBar_panel
            // 
            this.controlBar_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.controlBar_panel.Controls.Add(this.label3);
            this.controlBar_panel.Controls.Add(this.close_button);
            this.controlBar_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlBar_panel.Location = new System.Drawing.Point(0, 0);
            this.controlBar_panel.Margin = new System.Windows.Forms.Padding(0);
            this.controlBar_panel.Name = "controlBar_panel";
            this.controlBar_panel.Size = new System.Drawing.Size(585, 33);
            this.controlBar_panel.TabIndex = 58;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Transaction Details";
            // 
            // close_button
            // 
            this.close_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.close_button.FlatAppearance.BorderSize = 0;
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_button.Image = ((System.Drawing.Image)(resources.GetObject("close_button.Image")));
            this.close_button.Location = new System.Drawing.Point(545, 2);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(40, 33);
            this.close_button.TabIndex = 0;
            this.close_button.UseVisualStyleBackColor = false;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // details_dgv
            // 
            this.details_dgv.AllowUserToAddRows = false;
            this.details_dgv.AllowUserToDeleteRows = false;
            this.details_dgv.AllowUserToOrderColumns = true;
            this.details_dgv.AllowUserToResizeColumns = false;
            this.details_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.details_dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.details_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.details_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.details_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.details_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.details_dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.details_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.details_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.details_dgv.ColumnHeadersHeight = 40;
            this.details_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.details_dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.details_dgv.EnableHeadersVisualStyles = false;
            this.details_dgv.Location = new System.Drawing.Point(43, 263);
            this.details_dgv.MultiSelect = false;
            this.details_dgv.Name = "details_dgv";
            this.details_dgv.ReadOnly = true;
            this.details_dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.details_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.details_dgv.RowHeadersVisible = false;
            this.details_dgv.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.details_dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.details_dgv.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.details_dgv.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.details_dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.details_dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.details_dgv.RowTemplate.Height = 35;
            this.details_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.details_dgv.Size = new System.Drawing.Size(510, 152);
            this.details_dgv.TabIndex = 59;
            // 
            // remarks_textbox
            // 
            this.remarks_textbox.Enabled = false;
            this.remarks_textbox.Location = new System.Drawing.Point(137, 180);
            this.remarks_textbox.Multiline = true;
            this.remarks_textbox.Name = "remarks_textbox";
            this.remarks_textbox.Size = new System.Drawing.Size(416, 67);
            this.remarks_textbox.TabIndex = 60;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 61;
            this.label4.Text = "Remarks:";
            // 
            // source_name
            // 
            this.source_name.AutoSize = true;
            this.source_name.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.source_name.Location = new System.Drawing.Point(32, 54);
            this.source_name.Name = "source_name";
            this.source_name.Size = new System.Drawing.Size(218, 37);
            this.source_name.TabIndex = 63;
            this.source_name.Text = "Helsinki Finkster";
            // 
            // datepaid_label
            // 
            this.datepaid_label.AutoSize = true;
            this.datepaid_label.Location = new System.Drawing.Point(133, 137);
            this.datepaid_label.Name = "datepaid_label";
            this.datepaid_label.Size = new System.Drawing.Size(137, 21);
            this.datepaid_label.TabIndex = 65;
            this.datepaid_label.Text = "12/10/2017 20:40";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 21);
            this.label8.TabIndex = 64;
            this.label8.Text = "Date Paid:";
            // 
            // ORTextLabel
            // 
            this.ORTextLabel.AutoSize = true;
            this.ORTextLabel.Location = new System.Drawing.Point(36, 101);
            this.ORTextLabel.Name = "ORTextLabel";
            this.ORTextLabel.Size = new System.Drawing.Size(35, 21);
            this.ORTextLabel.TabIndex = 66;
            this.ORTextLabel.Text = "OR:";
            // 
            // checkNumberTextLabel
            // 
            this.checkNumberTextLabel.AutoSize = true;
            this.checkNumberTextLabel.Location = new System.Drawing.Point(39, 101);
            this.checkNumberTextLabel.Name = "checkNumberTextLabel";
            this.checkNumberTextLabel.Size = new System.Drawing.Size(117, 21);
            this.checkNumberTextLabel.TabIndex = 68;
            this.checkNumberTextLabel.Text = "Check Number:";
            // 
            // CN_label
            // 
            this.CN_label.AutoSize = true;
            this.CN_label.BackColor = System.Drawing.Color.White;
            this.CN_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CN_label.ForeColor = System.Drawing.Color.Black;
            this.CN_label.Location = new System.Drawing.Point(162, 101);
            this.CN_label.Name = "CN_label";
            this.CN_label.Size = new System.Drawing.Size(55, 21);
            this.CN_label.TabIndex = 67;
            this.CN_label.Text = "13458";
            // 
            // checkVoucherTextLabel
            // 
            this.checkVoucherTextLabel.AutoSize = true;
            this.checkVoucherTextLabel.Location = new System.Drawing.Point(239, 101);
            this.checkVoucherTextLabel.Name = "checkVoucherTextLabel";
            this.checkVoucherTextLabel.Size = new System.Drawing.Size(116, 21);
            this.checkVoucherTextLabel.TabIndex = 70;
            this.checkVoucherTextLabel.Text = "Check Voucher:";
            // 
            // CV_label
            // 
            this.CV_label.AutoSize = true;
            this.CV_label.BackColor = System.Drawing.Color.White;
            this.CV_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CV_label.ForeColor = System.Drawing.Color.Black;
            this.CV_label.Location = new System.Drawing.Point(361, 101);
            this.CV_label.Name = "CV_label";
            this.CV_label.Size = new System.Drawing.Size(55, 21);
            this.CV_label.TabIndex = 69;
            this.CV_label.Text = "13458";
            // 
            // ORdetailsPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(585, 493);
            this.ControlBox = false;
            this.Controls.Add(this.checkVoucherTextLabel);
            this.Controls.Add(this.CV_label);
            this.Controls.Add(this.checkNumberTextLabel);
            this.Controls.Add(this.CN_label);
            this.Controls.Add(this.ORTextLabel);
            this.Controls.Add(this.datepaid_label);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.source_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.remarks_textbox);
            this.Controls.Add(this.details_dgv);
            this.Controls.Add(this.controlBar_panel);
            this.Controls.Add(this.total_label);
            this.Controls.Add(this.or_label);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ORdetailsPopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ORdetailsPopUp_Load);
            this.controlBar_panel.ResumeLayout(false);
            this.controlBar_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.details_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label or_label;
        private System.Windows.Forms.Label total_label;
        private System.Windows.Forms.Panel controlBar_panel;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView details_dgv;
        private System.Windows.Forms.TextBox remarks_textbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label source_name;
        private System.Windows.Forms.Label datepaid_label;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label ORTextLabel;
        private System.Windows.Forms.Label checkNumberTextLabel;
        private System.Windows.Forms.Label CN_label;
        private System.Windows.Forms.Label checkVoucherTextLabel;
        private System.Windows.Forms.Label CV_label;
    }
}