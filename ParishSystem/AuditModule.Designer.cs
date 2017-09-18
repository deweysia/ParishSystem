namespace ParishSystem
{
    partial class AuditModule
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
            this.dgvBaptism = new MetroFramework.Controls.MetroGrid();
            this.baptismID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bapApplicationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bapProfileID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bapMinisterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baptismDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bapFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bapMI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bapLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bapSuffix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bapRegistryNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bapRecordNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bapPageNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bapRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaptism)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBaptism
            // 
            this.dgvBaptism.AllowUserToAddRows = false;
            this.dgvBaptism.AllowUserToDeleteRows = false;
            this.dgvBaptism.AllowUserToResizeRows = false;
            this.dgvBaptism.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBaptism.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaptism.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvBaptism.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBaptism.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvBaptism.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBaptism.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBaptism.ColumnHeadersHeight = 25;
            this.dgvBaptism.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBaptism.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.baptismID,
            this.bapApplicationID,
            this.bapProfileID,
            this.bapMinisterID,
            this.baptismDate,
            this.bapFirstName,
            this.bapMI,
            this.bapLastName,
            this.bapSuffix,
            this.bapRegistryNumber,
            this.bapRecordNumber,
            this.bapPageNumber,
            this.bapRemarks});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBaptism.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBaptism.EnableHeadersVisualStyles = false;
            this.dgvBaptism.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvBaptism.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvBaptism.Location = new System.Drawing.Point(12, 129);
            this.dgvBaptism.MultiSelect = false;
            this.dgvBaptism.Name = "dgvBaptism";
            this.dgvBaptism.ReadOnly = true;
            this.dgvBaptism.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBaptism.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBaptism.RowHeadersVisible = false;
            this.dgvBaptism.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBaptism.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaptism.Size = new System.Drawing.Size(906, 399);
            this.dgvBaptism.Style = MetroFramework.MetroColorStyle.Silver;
            this.dgvBaptism.TabIndex = 7;
            this.dgvBaptism.TabStop = false;
            this.dgvBaptism.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // baptismID
            // 
            this.baptismID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.baptismID.DataPropertyName = "baptismID";
            this.baptismID.HeaderText = "baptismID";
            this.baptismID.Name = "baptismID";
            this.baptismID.ReadOnly = true;
            this.baptismID.Visible = false;
            this.baptismID.Width = 82;
            // 
            // bapApplicationID
            // 
            this.bapApplicationID.DataPropertyName = "applicationID";
            this.bapApplicationID.HeaderText = "bapApplicationID";
            this.bapApplicationID.Name = "bapApplicationID";
            this.bapApplicationID.ReadOnly = true;
            this.bapApplicationID.Visible = false;
            // 
            // bapProfileID
            // 
            this.bapProfileID.DataPropertyName = "profileID";
            this.bapProfileID.HeaderText = "profileID";
            this.bapProfileID.Name = "bapProfileID";
            this.bapProfileID.ReadOnly = true;
            this.bapProfileID.Visible = false;
            // 
            // bapMinisterID
            // 
            this.bapMinisterID.DataPropertyName = "ministerID";
            this.bapMinisterID.HeaderText = "ministerID";
            this.bapMinisterID.Name = "bapMinisterID";
            this.bapMinisterID.ReadOnly = true;
            this.bapMinisterID.Visible = false;
            // 
            // baptismDate
            // 
            this.baptismDate.DataPropertyName = "baptismDate";
            this.baptismDate.HeaderText = "Baptism Date";
            this.baptismDate.Name = "baptismDate";
            this.baptismDate.ReadOnly = true;
            // 
            // bapFirstName
            // 
            this.bapFirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bapFirstName.DataPropertyName = "firstName";
            this.bapFirstName.HeaderText = "First Name";
            this.bapFirstName.Name = "bapFirstName";
            this.bapFirstName.ReadOnly = true;
            // 
            // bapMI
            // 
            this.bapMI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.bapMI.DataPropertyName = "midName";
            this.bapMI.HeaderText = "MI";
            this.bapMI.Name = "bapMI";
            this.bapMI.ReadOnly = true;
            this.bapMI.Width = 114;
            // 
            // bapLastName
            // 
            this.bapLastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bapLastName.DataPropertyName = "lastName";
            this.bapLastName.HeaderText = "Last Name";
            this.bapLastName.Name = "bapLastName";
            this.bapLastName.ReadOnly = true;
            // 
            // bapSuffix
            // 
            this.bapSuffix.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.bapSuffix.DataPropertyName = "suffix";
            this.bapSuffix.HeaderText = "Suffix";
            this.bapSuffix.Name = "bapSuffix";
            this.bapSuffix.ReadOnly = true;
            this.bapSuffix.Width = 114;
            // 
            // bapRegistryNumber
            // 
            this.bapRegistryNumber.DataPropertyName = "registryNumber";
            this.bapRegistryNumber.HeaderText = "Registry";
            this.bapRegistryNumber.Name = "bapRegistryNumber";
            this.bapRegistryNumber.ReadOnly = true;
            // 
            // bapRecordNumber
            // 
            this.bapRecordNumber.DataPropertyName = "recordNumber";
            this.bapRecordNumber.HeaderText = "Record";
            this.bapRecordNumber.Name = "bapRecordNumber";
            this.bapRecordNumber.ReadOnly = true;
            // 
            // bapPageNumber
            // 
            this.bapPageNumber.DataPropertyName = "pageNumber";
            this.bapPageNumber.HeaderText = "Page";
            this.bapPageNumber.Name = "bapPageNumber";
            this.bapPageNumber.ReadOnly = true;
            // 
            // bapRemarks
            // 
            this.bapRemarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bapRemarks.DataPropertyName = "remarks";
            this.bapRemarks.HeaderText = "Remarks";
            this.bapRemarks.Name = "bapRemarks";
            this.bapRemarks.ReadOnly = true;
            // 
            // AuditModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 540);
            this.Controls.Add(this.dgvBaptism);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AuditModule";
            this.Text = "AuditModule";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaptism)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroGrid dgvBaptism;
        private System.Windows.Forms.DataGridViewTextBoxColumn baptismID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bapApplicationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bapProfileID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bapMinisterID;
        private System.Windows.Forms.DataGridViewTextBoxColumn baptismDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn bapFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn bapMI;
        private System.Windows.Forms.DataGridViewTextBoxColumn bapLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn bapSuffix;
        private System.Windows.Forms.DataGridViewTextBoxColumn bapRegistryNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn bapRecordNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn bapPageNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn bapRemarks;
    }
}