namespace ParishSystem
{
    partial class BloodClaim
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ln = new ParishSystem.CueTextBox();
            this.sf = new ParishSystem.CueTextBox();
            this.fn = new ParishSystem.CueTextBox();
            this.mi = new ParishSystem.CueTextBox();
            this.Claim_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DonationID_textbox = new ParishSystem.CueTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BloodDonationsDGV = new System.Windows.Forms.DataGridView();
            this.donationAdd = new System.Windows.Forms.Button();
            this.donationDelete = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clear_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BloodDonationsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // ln
            // 
            this.ln.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ln.Cue = "Lastname";
            this.ln.CueColor = System.Drawing.Color.Empty;
            this.ln.Location = new System.Drawing.Point(113, 90);
            this.ln.Name = "ln";
            this.ln.Size = new System.Drawing.Size(240, 22);
            this.ln.TabIndex = 2;
            this.ln.Text = "Lastname";
            this.ln.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ln.TextChanged += new System.EventHandler(this.ln_TextChanged);
            // 
            // sf
            // 
            this.sf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sf.Cue = "Sf";
            this.sf.CueColor = System.Drawing.Color.Empty;
            this.sf.Location = new System.Drawing.Point(370, 90);
            this.sf.Name = "sf";
            this.sf.Size = new System.Drawing.Size(90, 22);
            this.sf.TabIndex = 2;
            this.sf.Text = "Sf";
            this.sf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sf.TextChanged += new System.EventHandler(this.sf_TextChanged);
            // 
            // fn
            // 
            this.fn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fn.Cue = "Firtsname";
            this.fn.CueColor = System.Drawing.Color.Empty;
            this.fn.Location = new System.Drawing.Point(476, 90);
            this.fn.Name = "fn";
            this.fn.Size = new System.Drawing.Size(240, 22);
            this.fn.TabIndex = 2;
            this.fn.Text = "Firtsname";
            this.fn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fn.TextChanged += new System.EventHandler(this.fn_TextChanged);
            // 
            // mi
            // 
            this.mi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mi.Cue = "Mi";
            this.mi.CueColor = System.Drawing.Color.Empty;
            this.mi.Location = new System.Drawing.Point(728, 90);
            this.mi.Name = "mi";
            this.mi.Size = new System.Drawing.Size(90, 22);
            this.mi.TabIndex = 2;
            this.mi.Text = "Mi";
            this.mi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mi.TextChanged += new System.EventHandler(this.mi_TextChanged);
            // 
            // Claim_button
            // 
            this.Claim_button.BackColor = System.Drawing.Color.Gray;
            this.Claim_button.Enabled = false;
            this.Claim_button.FlatAppearance.BorderSize = 0;
            this.Claim_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Claim_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Claim_button.ForeColor = System.Drawing.Color.White;
            this.Claim_button.Location = new System.Drawing.Point(332, 437);
            this.Claim_button.Name = "Claim_button";
            this.Claim_button.Size = new System.Drawing.Size(286, 37);
            this.Claim_button.TabIndex = 4;
            this.Claim_button.Text = "Claim";
            this.Claim_button.UseVisualStyleBackColor = false;
            this.Claim_button.Click += new System.EventHandler(this.Claim_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(111, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(711, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "______________________________________________________________________________";
            // 
            // DonationID_textbox
            // 
            this.DonationID_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DonationID_textbox.Cue = "Donation ID";
            this.DonationID_textbox.CueColor = System.Drawing.Color.Empty;
            this.DonationID_textbox.Location = new System.Drawing.Point(332, 159);
            this.DonationID_textbox.Name = "DonationID_textbox";
            this.DonationID_textbox.Size = new System.Drawing.Size(277, 22);
            this.DonationID_textbox.TabIndex = 6;
            this.DonationID_textbox.Text = "Donation ID";
            this.DonationID_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DonationID_textbox.TextChanged += new System.EventHandler(this.DonationID_textbox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(319, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(306, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "_________________________________";
            // 
            // BloodDonationsDGV
            // 
            this.BloodDonationsDGV.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.BloodDonationsDGV.AllowUserToAddRows = false;
            this.BloodDonationsDGV.AllowUserToDeleteRows = false;
            this.BloodDonationsDGV.AllowUserToOrderColumns = true;
            this.BloodDonationsDGV.AllowUserToResizeRows = false;
            this.BloodDonationsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BloodDonationsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BloodDonationsDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BloodDonationsDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BloodDonationsDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.BloodDonationsDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BloodDonationsDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.BloodDonationsDGV.ColumnHeadersHeight = 40;
            this.BloodDonationsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.BloodDonationsDGV.ColumnHeadersVisible = false;
            this.BloodDonationsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.DonationID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BloodDonationsDGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.BloodDonationsDGV.EnableHeadersVisualStyles = false;
            this.BloodDonationsDGV.GridColor = System.Drawing.Color.White;
            this.BloodDonationsDGV.Location = new System.Drawing.Point(332, 204);
            this.BloodDonationsDGV.MultiSelect = false;
            this.BloodDonationsDGV.Name = "BloodDonationsDGV";
            this.BloodDonationsDGV.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Magenta;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BloodDonationsDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.BloodDonationsDGV.RowHeadersVisible = false;
            this.BloodDonationsDGV.RowHeadersWidth = 50;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DarkRed;
            this.BloodDonationsDGV.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.BloodDonationsDGV.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.BloodDonationsDGV.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BloodDonationsDGV.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.BloodDonationsDGV.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.BloodDonationsDGV.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.BloodDonationsDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BloodDonationsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BloodDonationsDGV.Size = new System.Drawing.Size(286, 165);
            this.BloodDonationsDGV.TabIndex = 11;
            this.BloodDonationsDGV.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BloodDonationsDGV_CellContentDoubleClick);
            this.BloodDonationsDGV.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.BloodDonationsDGV_RowsAdded);
            this.BloodDonationsDGV.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.BloodDonationsDGV_RowsRemoved);
            // 
            // donationAdd
            // 
            this.donationAdd.BackColor = System.Drawing.Color.Gray;
            this.donationAdd.Enabled = false;
            this.donationAdd.FlatAppearance.BorderSize = 0;
            this.donationAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.donationAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.donationAdd.ForeColor = System.Drawing.Color.White;
            this.donationAdd.Location = new System.Drawing.Point(631, 155);
            this.donationAdd.Name = "donationAdd";
            this.donationAdd.Size = new System.Drawing.Size(83, 37);
            this.donationAdd.TabIndex = 12;
            this.donationAdd.Tag = "a";
            this.donationAdd.Text = "Add";
            this.donationAdd.UseVisualStyleBackColor = false;
            this.donationAdd.Click += new System.EventHandler(this.donationAdd_Click);
            // 
            // donationDelete
            // 
            this.donationDelete.BackColor = System.Drawing.Color.Gray;
            this.donationDelete.Enabled = false;
            this.donationDelete.FlatAppearance.BorderSize = 0;
            this.donationDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.donationDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.donationDelete.ForeColor = System.Drawing.Color.White;
            this.donationDelete.Location = new System.Drawing.Point(807, 155);
            this.donationDelete.Name = "donationDelete";
            this.donationDelete.Size = new System.Drawing.Size(81, 37);
            this.donationDelete.TabIndex = 13;
            this.donationDelete.Text = "Delete";
            this.donationDelete.UseVisualStyleBackColor = false;
            this.donationDelete.Click += new System.EventHandler(this.donationDelete_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // DonationID
            // 
            this.DonationID.HeaderText = "";
            this.DonationID.Name = "DonationID";
            this.DonationID.ReadOnly = true;
            this.DonationID.Visible = false;
            // 
            // clear_button
            // 
            this.clear_button.BackColor = System.Drawing.Color.Gray;
            this.clear_button.FlatAppearance.BorderSize = 0;
            this.clear_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.clear_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear_button.ForeColor = System.Drawing.Color.White;
            this.clear_button.Location = new System.Drawing.Point(720, 155);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(81, 37);
            this.clear_button.TabIndex = 14;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = false;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // BloodClaim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 547);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.donationDelete);
            this.Controls.Add(this.donationAdd);
            this.Controls.Add(this.BloodDonationsDGV);
            this.Controls.Add(this.DonationID_textbox);
            this.Controls.Add(this.Claim_button);
            this.Controls.Add(this.mi);
            this.Controls.Add(this.fn);
            this.Controls.Add(this.sf);
            this.Controls.Add(this.ln);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BloodClaim";
            this.Text = "BloodClaim";
            ((System.ComponentModel.ISupportInitialize)(this.BloodDonationsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CueTextBox ln;
        private CueTextBox sf;
        private CueTextBox fn;
        private CueTextBox mi;
        private System.Windows.Forms.Button Claim_button;
        private System.Windows.Forms.Label label1;
        private CueTextBox DonationID_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView BloodDonationsDGV;
        private System.Windows.Forms.Button donationAdd;
        private System.Windows.Forms.Button donationDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonationID;
        private System.Windows.Forms.Button clear_button;
    }
}