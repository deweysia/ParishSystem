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
            this.dgvAudit = new MetroFramework.Controls.MetroGrid();
            this.auditLogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auditDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.details = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldRecord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newRecord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbFilter = new MetroFramework.Controls.MetroComboBox();
            this.dtpTo = new MetroFramework.Controls.MetroDateTime();
            this.dtpFrom = new MetroFramework.Controls.MetroDateTime();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudit)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAudit
            // 
            this.dgvAudit.AllowUserToAddRows = false;
            this.dgvAudit.AllowUserToDeleteRows = false;
            this.dgvAudit.AllowUserToResizeRows = false;
            this.dgvAudit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAudit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAudit.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvAudit.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvAudit.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAudit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAudit.ColumnHeadersHeight = 25;
            this.dgvAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAudit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.auditLogID,
            this.userID,
            this.tableName,
            this.operation,
            this.auditDate,
            this.name,
            this.details,
            this.oldRecord,
            this.newRecord});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAudit.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAudit.EnableHeadersVisualStyles = false;
            this.dgvAudit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvAudit.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvAudit.Location = new System.Drawing.Point(12, 66);
            this.dgvAudit.MultiSelect = false;
            this.dgvAudit.Name = "dgvAudit";
            this.dgvAudit.ReadOnly = true;
            this.dgvAudit.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAudit.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAudit.RowHeadersVisible = false;
            this.dgvAudit.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAudit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAudit.Size = new System.Drawing.Size(906, 462);
            this.dgvAudit.Style = MetroFramework.MetroColorStyle.Silver;
            this.dgvAudit.TabIndex = 7;
            this.dgvAudit.TabStop = false;
            this.dgvAudit.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dgvAudit.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAudit_CellFormatting);
            this.dgvAudit.VisibleChanged += new System.EventHandler(this.dgvBaptism_VisibleChanged);
            // 
            // auditLogID
            // 
            this.auditLogID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.auditLogID.DataPropertyName = "auditLogID";
            this.auditLogID.HeaderText = "auditLogID";
            this.auditLogID.Name = "auditLogID";
            this.auditLogID.ReadOnly = true;
            this.auditLogID.Visible = false;
            this.auditLogID.Width = 87;
            // 
            // userID
            // 
            this.userID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.userID.DataPropertyName = "userID";
            this.userID.HeaderText = "userID";
            this.userID.Name = "userID";
            this.userID.ReadOnly = true;
            this.userID.Visible = false;
            // 
            // tableName
            // 
            this.tableName.DataPropertyName = "tableName";
            this.tableName.HeaderText = "Source";
            this.tableName.Name = "tableName";
            this.tableName.ReadOnly = true;
            // 
            // operation
            // 
            this.operation.DataPropertyName = "operation";
            this.operation.HeaderText = "Operation";
            this.operation.Name = "operation";
            this.operation.ReadOnly = true;
            // 
            // auditDate
            // 
            this.auditDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.auditDate.DataPropertyName = "auditDate";
            this.auditDate.HeaderText = "Date";
            this.auditDate.Name = "auditDate";
            this.auditDate.ReadOnly = true;
            this.auditDate.Width = 114;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "User";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 114;
            // 
            // details
            // 
            this.details.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.details.DataPropertyName = "details";
            this.details.HeaderText = "Details";
            this.details.Name = "details";
            this.details.ReadOnly = true;
            // 
            // oldRecord
            // 
            this.oldRecord.DataPropertyName = "oldRecord";
            this.oldRecord.FillWeight = 250F;
            this.oldRecord.HeaderText = "Old Record";
            this.oldRecord.Name = "oldRecord";
            this.oldRecord.ReadOnly = true;
            // 
            // newRecord
            // 
            this.newRecord.DataPropertyName = "newRecord";
            this.newRecord.FillWeight = 250F;
            this.newRecord.HeaderText = "New Record";
            this.newRecord.Name = "newRecord";
            this.newRecord.ReadOnly = true;
            // 
            // cmbFilter
            // 
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.ItemHeight = 23;
            this.cmbFilter.Location = new System.Drawing.Point(12, 31);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(200, 29);
            this.cmbFilter.TabIndex = 9;
            this.cmbFilter.UseSelectable = true;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(555, 31);
            this.dtpTo.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 29);
            this.dtpTo.TabIndex = 10;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(349, 31);
            this.dtpFrom.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 29);
            this.dtpFrom.TabIndex = 11;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(761, 31);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 29);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseSelectable = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.Location = new System.Drawing.Point(349, 9);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(128, 19);
            this.metroLabel1.TabIndex = 13;
            this.metroLabel1.Text = "Check Logs Between";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel2.Location = new System.Drawing.Point(12, 9);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(38, 19);
            this.metroLabel2.TabIndex = 13;
            this.metroLabel2.Text = "Filter";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(843, 31);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 29);
            this.metroButton1.TabIndex = 12;
            this.metroButton1.Text = "Reset";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // AuditModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 540);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.dgvAudit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AuditModule";
            this.Text = "AuditModule";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroGrid dgvAudit;
        private System.Windows.Forms.DataGridViewTextBoxColumn auditLogID;
        private System.Windows.Forms.DataGridViewTextBoxColumn userID;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn operation;
        private System.Windows.Forms.DataGridViewTextBoxColumn auditDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn details;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn newRecord;
        private MetroFramework.Controls.MetroComboBox cmbFilter;
        private MetroFramework.Controls.MetroDateTime dtpTo;
        private MetroFramework.Controls.MetroDateTime dtpFrom;
        private MetroFramework.Controls.MetroButton btnSearch;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}