namespace ParishSystem
{
    partial class MinisterModule
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
            this.flpEditDeleteMinister = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.events_btn = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvMinister = new System.Windows.Forms.DataGridView();
            this.ministerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.midname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suffix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bitthdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ministrytype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.licensenumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpEditDeleteMinister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMinister)).BeginInit();
            this.SuspendLayout();
            // 
            // flpEditDeleteMinister
            // 
            this.flpEditDeleteMinister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flpEditDeleteMinister.Controls.Add(this.btnEdit);
            this.flpEditDeleteMinister.Controls.Add(this.btnDelete);
            this.flpEditDeleteMinister.Controls.Add(this.events_btn);
            this.flpEditDeleteMinister.Location = new System.Drawing.Point(218, 584);
            this.flpEditDeleteMinister.Name = "flpEditDeleteMinister";
            this.flpEditDeleteMinister.Size = new System.Drawing.Size(539, 44);
            this.flpEditDeleteMinister.TabIndex = 13;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(3, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(173, 37);
            this.btnEdit.TabIndex = 15;
            this.btnEdit.Tag = "a";
            this.btnEdit.Text = "Edit Minister";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(182, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(173, 37);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete Minister";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // events_btn
            // 
            this.events_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.events_btn.Enabled = false;
            this.events_btn.FlatAppearance.BorderSize = 0;
            this.events_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.events_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.events_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.events_btn.ForeColor = System.Drawing.Color.White;
            this.events_btn.Location = new System.Drawing.Point(361, 3);
            this.events_btn.Name = "events_btn";
            this.events_btn.Size = new System.Drawing.Size(173, 37);
            this.events_btn.TabIndex = 16;
            this.events_btn.Tag = "a";
            this.events_btn.Text = "Upcoming Events";
            this.events_btn.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(42, 586);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(173, 37);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Tag = "a";
            this.btnAdd.Text = "Add Miister";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvMinister
            // 
            this.dgvMinister.AllowUserToAddRows = false;
            this.dgvMinister.AllowUserToDeleteRows = false;
            this.dgvMinister.AllowUserToOrderColumns = true;
            this.dgvMinister.AllowUserToResizeColumns = false;
            this.dgvMinister.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMinister.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMinister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMinister.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMinister.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMinister.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMinister.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMinister.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMinister.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMinister.ColumnHeadersHeight = 40;
            this.dgvMinister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMinister.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ministerID,
            this.firstname,
            this.midname,
            this.lastname,
            this.suffix,
            this.bitthdate,
            this.ministrytype,
            this.status,
            this.licensenumber});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMinister.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMinister.EnableHeadersVisualStyles = false;
            this.dgvMinister.Location = new System.Drawing.Point(42, 58);
            this.dgvMinister.MultiSelect = false;
            this.dgvMinister.Name = "dgvMinister";
            this.dgvMinister.ReadOnly = true;
            this.dgvMinister.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMinister.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMinister.RowHeadersVisible = false;
            this.dgvMinister.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvMinister.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Empty;
            this.dgvMinister.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMinister.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvMinister.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvMinister.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvMinister.RowTemplate.Height = 35;
            this.dgvMinister.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMinister.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMinister.Size = new System.Drawing.Size(858, 490);
            this.dgvMinister.TabIndex = 14;
            this.dgvMinister.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMinister_CellEnter);
            this.dgvMinister.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMinister_CellFormatting);
            // 
            // ministerID
            // 
            this.ministerID.DataPropertyName = "ministerID";
            this.ministerID.HeaderText = "ministerID";
            this.ministerID.Name = "ministerID";
            this.ministerID.ReadOnly = true;
            this.ministerID.Visible = false;
            // 
            // firstname
            // 
            this.firstname.DataPropertyName = "firstname";
            this.firstname.HeaderText = "Firstname";
            this.firstname.Name = "firstname";
            this.firstname.ReadOnly = true;
            // 
            // midname
            // 
            this.midname.DataPropertyName = "midname";
            this.midname.HeaderText = "M.I";
            this.midname.Name = "midname";
            this.midname.ReadOnly = true;
            // 
            // lastname
            // 
            this.lastname.DataPropertyName = "lastname";
            this.lastname.HeaderText = "Last Name";
            this.lastname.Name = "lastname";
            this.lastname.ReadOnly = true;
            // 
            // suffix
            // 
            this.suffix.DataPropertyName = "suffix";
            this.suffix.HeaderText = "Suffix";
            this.suffix.Name = "suffix";
            this.suffix.ReadOnly = true;
            // 
            // bitthdate
            // 
            this.bitthdate.DataPropertyName = "bitthdate";
            this.bitthdate.HeaderText = "Birthdate";
            this.bitthdate.Name = "bitthdate";
            this.bitthdate.ReadOnly = true;
            // 
            // ministrytype
            // 
            this.ministrytype.DataPropertyName = "ministrytype";
            this.ministrytype.HeaderText = "Ministry Type";
            this.ministrytype.Name = "ministrytype";
            this.ministrytype.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // licensenumber
            // 
            this.licensenumber.DataPropertyName = "licensenumber";
            this.licensenumber.HeaderText = "License Number";
            this.licensenumber.Name = "licensenumber";
            this.licensenumber.ReadOnly = true;
            // 
            // MinisterModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(943, 669);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvMinister);
            this.Controls.Add(this.flpEditDeleteMinister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MinisterModule";
            this.Text = "MinisterModule";
            this.Load += new System.EventHandler(this.MinisterModule_Load);
            this.flpEditDeleteMinister.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMinister)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpEditDeleteMinister;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button events_btn;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvMinister;
        private System.Windows.Forms.DataGridViewTextBoxColumn ministerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn midname;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn suffix;
        private System.Windows.Forms.DataGridViewTextBoxColumn bitthdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ministrytype;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn licensenumber;
    }
}