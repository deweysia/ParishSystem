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
            this.flpEditDeleteMinister = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvMinister = new MetroFramework.Controls.MetroGrid();
            this.button1 = new System.Windows.Forms.Button();
            this.ministerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.midName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suffix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ministryType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.licenseNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpEditDeleteMinister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMinister)).BeginInit();
            this.SuspendLayout();
            // 
            // flpEditDeleteMinister
            // 
            this.flpEditDeleteMinister.Controls.Add(this.btnEdit);
            this.flpEditDeleteMinister.Controls.Add(this.btnDelete);
            this.flpEditDeleteMinister.Controls.Add(this.button1);
            this.flpEditDeleteMinister.Location = new System.Drawing.Point(93, 400);
            this.flpEditDeleteMinister.Name = "flpEditDeleteMinister";
            this.flpEditDeleteMinister.Size = new System.Drawing.Size(331, 32);
            this.flpEditDeleteMinister.TabIndex = 13;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(3, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit Minister";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(84, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete Minister";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 403);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add Minister";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvMinister
            // 
            this.dgvMinister.AllowUserToAddRows = false;
            this.dgvMinister.AllowUserToDeleteRows = false;
            this.dgvMinister.AllowUserToResizeRows = false;
            this.dgvMinister.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMinister.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvMinister.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMinister.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMinister.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMinister.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMinister.ColumnHeadersHeight = 25;
            this.dgvMinister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMinister.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ministerID,
            this.firstName,
            this.midName,
            this.lastName,
            this.suffix,
            this.birthdate,
            this.ministryType,
            this.status,
            this.licenseNumber});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMinister.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMinister.EnableHeadersVisualStyles = false;
            this.dgvMinister.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvMinister.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvMinister.Location = new System.Drawing.Point(9, 12);
            this.dgvMinister.MultiSelect = false;
            this.dgvMinister.Name = "dgvMinister";
            this.dgvMinister.ReadOnly = true;
            this.dgvMinister.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMinister.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMinister.RowHeadersVisible = false;
            this.dgvMinister.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvMinister.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMinister.Size = new System.Drawing.Size(909, 382);
            this.dgvMinister.Style = MetroFramework.MetroColorStyle.Silver;
            this.dgvMinister.TabIndex = 11;
            this.dgvMinister.TabStop = false;
            this.dgvMinister.UseStyleColors = true;
            this.dgvMinister.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMinister_CellEnter);
            this.dgvMinister.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMinister_CellFormatting);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Upcoming appointments";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ministerID
            // 
            this.ministerID.DataPropertyName = "ministerID";
            this.ministerID.HeaderText = "ministerID";
            this.ministerID.Name = "ministerID";
            this.ministerID.ReadOnly = true;
            this.ministerID.Visible = false;
            // 
            // firstName
            // 
            this.firstName.DataPropertyName = "firstName";
            this.firstName.HeaderText = "First Name";
            this.firstName.Name = "firstName";
            this.firstName.ReadOnly = true;
            // 
            // midName
            // 
            this.midName.DataPropertyName = "midName";
            this.midName.HeaderText = "M.I.";
            this.midName.Name = "midName";
            this.midName.ReadOnly = true;
            // 
            // lastName
            // 
            this.lastName.DataPropertyName = "lastName";
            this.lastName.HeaderText = "Last Name";
            this.lastName.Name = "lastName";
            this.lastName.ReadOnly = true;
            // 
            // suffix
            // 
            this.suffix.DataPropertyName = "suffix";
            this.suffix.HeaderText = "Suffix";
            this.suffix.Name = "suffix";
            this.suffix.ReadOnly = true;
            // 
            // birthdate
            // 
            this.birthdate.DataPropertyName = "birthdate";
            this.birthdate.HeaderText = "Birthdate";
            this.birthdate.Name = "birthdate";
            this.birthdate.ReadOnly = true;
            // 
            // ministryType
            // 
            this.ministryType.DataPropertyName = "ministryType";
            this.ministryType.HeaderText = "Ministry Type";
            this.ministryType.Name = "ministryType";
            this.ministryType.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // licenseNumber
            // 
            this.licenseNumber.DataPropertyName = "licenseNumber";
            this.licenseNumber.HeaderText = "License Number";
            this.licenseNumber.Name = "licenseNumber";
            this.licenseNumber.ReadOnly = true;
            // 
            // MinisterModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 513);
            this.Controls.Add(this.flpEditDeleteMinister);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvMinister);
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
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private MetroFramework.Controls.MetroGrid dgvMinister;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ministerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn midName;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn suffix;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ministryType;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn licenseNumber;
    }
}