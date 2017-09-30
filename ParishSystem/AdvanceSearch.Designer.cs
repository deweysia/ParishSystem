namespace ParishSystem
{
    partial class AdvanceSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvanceSearch));
            this.dtpFrom = new MetroFramework.Controls.MetroDateTime();
            this.dtpTo = new MetroFramework.Controls.MetroDateTime();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tlpBetweenDates = new System.Windows.Forms.TableLayoutPanel();
            this.txtRegistry = new System.Windows.Forms.TextBox();
            this.cbBetweenDates = new MetroFramework.Controls.MetroCheckBox();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.txtRecord = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMinister = new MetroFramework.Controls.MetroComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tlpReference = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboxSearchWithoutRef = new MetroFramework.Controls.MetroCheckBox();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.tlpBetweenDates.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tlpReference.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.CalendarTitleBackColor = System.Drawing.Color.White;
            this.dtpFrom.CalendarTrailingForeColor = System.Drawing.Color.Black;
            this.dtpFrom.CustomFormat = "";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(3, 18);
            this.dtpFrom.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(130, 29);
            this.dtpFrom.Style = MetroFramework.MetroColorStyle.Silver;
            this.dtpFrom.TabIndex = 0;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.CalendarTitleBackColor = System.Drawing.Color.White;
            this.dtpTo.CalendarTrailingForeColor = System.Drawing.Color.Black;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(187, 18);
            this.dtpTo.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(130, 29);
            this.dtpTo.Style = MetroFramework.MetroColorStyle.Silver;
            this.dtpTo.TabIndex = 0;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(3, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(221, 25);
            this.txtName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Name containing";
            // 
            // tlpBetweenDates
            // 
            this.tlpBetweenDates.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tlpBetweenDates.ColumnCount = 2;
            this.tlpBetweenDates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBetweenDates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBetweenDates.Controls.Add(this.label2, 1, 0);
            this.tlpBetweenDates.Controls.Add(this.dtpTo, 1, 1);
            this.tlpBetweenDates.Controls.Add(this.dtpFrom, 0, 1);
            this.tlpBetweenDates.Controls.Add(this.label1, 0, 0);
            this.tlpBetweenDates.Enabled = false;
            this.tlpBetweenDates.Location = new System.Drawing.Point(12, 288);
            this.tlpBetweenDates.Name = "tlpBetweenDates";
            this.tlpBetweenDates.RowCount = 2;
            this.tlpBetweenDates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpBetweenDates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpBetweenDates.Size = new System.Drawing.Size(369, 50);
            this.tlpBetweenDates.TabIndex = 4;
            // 
            // txtRegistry
            // 
            this.txtRegistry.Location = new System.Drawing.Point(3, 18);
            this.txtRegistry.Name = "txtRegistry";
            this.txtRegistry.Size = new System.Drawing.Size(101, 20);
            this.txtRegistry.TabIndex = 2;
            this.txtRegistry.TextChanged += new System.EventHandler(this.txtRegistry_TextChanged);
            // 
            // cbBetweenDates
            // 
            this.cbBetweenDates.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbBetweenDates.AutoSize = true;
            this.cbBetweenDates.Location = new System.Drawing.Point(12, 265);
            this.cbBetweenDates.Name = "cbBetweenDates";
            this.cbBetweenDates.Size = new System.Drawing.Size(138, 15);
            this.cbBetweenDates.Style = MetroFramework.MetroColorStyle.Silver;
            this.cbBetweenDates.TabIndex = 6;
            this.cbBetweenDates.Text = "Search Between Dates";
            this.cbBetweenDates.UseSelectable = true;
            this.cbBetweenDates.CheckedChanged += new System.EventHandler(this.cbBetweenDates_CheckedChanged);
            // 
            // txtPage
            // 
            this.txtPage.Location = new System.Drawing.Point(245, 18);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(101, 20);
            this.txtPage.TabIndex = 2;
            // 
            // txtRecord
            // 
            this.txtRecord.Location = new System.Drawing.Point(124, 18);
            this.txtRecord.Name = "txtRecord";
            this.txtRecord.Size = new System.Drawing.Size(101, 20);
            this.txtRecord.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtName, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cmbMinister, 0, 3);
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(24, 52);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(346, 107);
            this.tableLayoutPanel2.TabIndex = 10;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Minister";
            // 
            // cmbMinister
            // 
            this.cmbMinister.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbMinister.FormattingEnabled = true;
            this.cmbMinister.ItemHeight = 19;
            this.cmbMinister.Location = new System.Drawing.Point(3, 72);
            this.cmbMinister.Name = "cmbMinister";
            this.cmbMinister.Size = new System.Drawing.Size(221, 25);
            this.cmbMinister.Style = MetroFramework.MetroColorStyle.Silver;
            this.cmbMinister.TabIndex = 3;
            this.cmbMinister.UseSelectable = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(393, 33);
            this.panel2.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(8, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 20);
            this.label6.TabIndex = 37;
            this.label6.Text = "Advanced Search";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(363, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(126, 344);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(143, 25);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tlpReference
            // 
            this.tlpReference.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tlpReference.ColumnCount = 3;
            this.tlpReference.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpReference.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpReference.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpReference.Controls.Add(this.label7, 2, 0);
            this.tlpReference.Controls.Add(this.txtRegistry, 0, 1);
            this.tlpReference.Controls.Add(this.txtPage, 2, 1);
            this.tlpReference.Controls.Add(this.label10, 0, 0);
            this.tlpReference.Controls.Add(this.txtRecord, 1, 1);
            this.tlpReference.Controls.Add(this.label11, 1, 0);
            this.tlpReference.Location = new System.Drawing.Point(18, 196);
            this.tlpReference.Name = "tlpReference";
            this.tlpReference.RowCount = 2;
            this.tlpReference.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpReference.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpReference.Size = new System.Drawing.Size(363, 50);
            this.tlpReference.TabIndex = 13;
            this.tlpReference.EnabledChanged += new System.EventHandler(this.tlpReference_EnabledChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(245, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Page Number";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Registry Number";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(124, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Record Number";
            // 
            // cboxSearchWithoutRef
            // 
            this.cboxSearchWithoutRef.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cboxSearchWithoutRef.AutoSize = true;
            this.cboxSearchWithoutRef.Location = new System.Drawing.Point(15, 175);
            this.cboxSearchWithoutRef.Name = "cboxSearchWithoutRef";
            this.cboxSearchWithoutRef.Size = new System.Drawing.Size(159, 15);
            this.cboxSearchWithoutRef.TabIndex = 15;
            this.cboxSearchWithoutRef.Text = "Search Without Reference";
            this.cboxSearchWithoutRef.UseSelectable = true;
            this.cboxSearchWithoutRef.CheckedChanged += new System.EventHandler(this.cboxSearchWithoutRef_CheckedChanged);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // AdvanceSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(393, 378);
            this.Controls.Add(this.cboxSearchWithoutRef);
            this.Controls.Add(this.tlpReference);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.cbBetweenDates);
            this.Controls.Add(this.tlpBetweenDates);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdvanceSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdvanceSearch";
            this.Load += new System.EventHandler(this.AdvanceSearch_Load);
            this.tlpBetweenDates.ResumeLayout(false);
            this.tlpBetweenDates.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tlpReference.ResumeLayout(false);
            this.tlpReference.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroDateTime dtpFrom;
        private MetroFramework.Controls.MetroDateTime dtpTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tlpBetweenDates;
        private System.Windows.Forms.TextBox txtRegistry;
        private MetroFramework.Controls.MetroCheckBox cbBetweenDates;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.TextBox txtRecord;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MetroFramework.Controls.MetroComboBox cmbMinister;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tlpReference;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private MetroFramework.Controls.MetroCheckBox cboxSearchWithoutRef;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
    }
}