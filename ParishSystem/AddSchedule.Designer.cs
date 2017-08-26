namespace ParishSystem
{
    partial class AddSchedule
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbScheduleType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dtpDateEnd = new MetroFramework.Controls.MetroDateTime();
            this.dtpDateStart = new MetroFramework.Controls.MetroDateTime();
            this.dtpTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tabScheduleType = new ParishSystem.HiddenTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbMinister = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtDescription = new ParishSystem.CueTextBox();
            this.txtTitle = new ParishSystem.CueTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabScheduleType.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Schedule Type";
            // 
            // cmbScheduleType
            // 
            this.cmbScheduleType.FormattingEnabled = true;
            this.cmbScheduleType.Items.AddRange(new object[] {
            "Unspecified",
            "Appointment",
            "Blood Donation Event"});
            this.cmbScheduleType.Location = new System.Drawing.Point(18, 41);
            this.cmbScheduleType.Name = "cmbScheduleType";
            this.cmbScheduleType.Size = new System.Drawing.Size(121, 21);
            this.cmbScheduleType.TabIndex = 3;
            this.cmbScheduleType.SelectedIndexChanged += new System.EventHandler(this.cmbScheduleType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Start Time";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "End Time";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Title";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.88235F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.11765F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.Controls.Add(this.dtpTimeStart, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpDateEnd, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpDateStart, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpTimeEnd, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 149);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(372, 117);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // dtpTimeStart
            // 
            this.dtpTimeStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpTimeStart.CustomFormat = "hh:mm tt";
            this.dtpTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeStart.Location = new System.Drawing.Point(235, 14);
            this.dtpTimeStart.Name = "dtpTimeStart";
            this.dtpTimeStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpTimeStart.ShowUpDown = true;
            this.dtpTimeStart.Size = new System.Drawing.Size(72, 20);
            this.dtpTimeStart.TabIndex = 7;
            this.dtpTimeStart.ValueChanged += new System.EventHandler(this.dtpTimeStart_ValueChanged);
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpDateEnd.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dtpDateEnd.Location = new System.Drawing.Point(59, 59);
            this.dtpDateEnd.MinimumSize = new System.Drawing.Size(0, 25);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(156, 25);
            this.dtpDateEnd.TabIndex = 7;
            this.dtpDateEnd.ValueChanged += new System.EventHandler(this.dtpDateEnd_ValueChanged);
            // 
            // dtpDateStart
            // 
            this.dtpDateStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpDateStart.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dtpDateStart.Location = new System.Drawing.Point(59, 11);
            this.dtpDateStart.MinimumSize = new System.Drawing.Size(0, 25);
            this.dtpDateStart.Name = "dtpDateStart";
            this.dtpDateStart.Size = new System.Drawing.Size(156, 25);
            this.dtpDateStart.TabIndex = 7;
            this.dtpDateStart.ValueChanged += new System.EventHandler(this.dtpDateStart_ValueChanged);
            // 
            // dtpTimeEnd
            // 
            this.dtpTimeEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpTimeEnd.CustomFormat = "hh:mm tt";
            this.dtpTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeEnd.Location = new System.Drawing.Point(235, 62);
            this.dtpTimeEnd.Name = "dtpTimeEnd";
            this.dtpTimeEnd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpTimeEnd.ShowUpDown = true;
            this.dtpTimeEnd.Size = new System.Drawing.Size(72, 20);
            this.dtpTimeEnd.TabIndex = 7;
            this.dtpTimeEnd.ValueChanged += new System.EventHandler(this.dtpTimeEnd_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Description";
            this.label5.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(136, 416);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(115, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add Schedule";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tabScheduleType
            // 
            this.tabScheduleType.Controls.Add(this.tabPage1);
            this.tabScheduleType.Controls.Add(this.tabPage2);
            this.tabScheduleType.Controls.Add(this.tabPage3);
            this.tabScheduleType.Location = new System.Drawing.Point(184, 25);
            this.tabScheduleType.Name = "tabScheduleType";
            this.tabScheduleType.SelectedIndex = 0;
            this.tabScheduleType.Size = new System.Drawing.Size(200, 100);
            this.tabScheduleType.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 74);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Unspecified";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.cmbMinister);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Appt";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Location = new System.Drawing.Point(3, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Minister";
            // 
            // cmbMinister
            // 
            this.cmbMinister.BackColor = System.Drawing.SystemColors.Control;
            this.cmbMinister.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmbMinister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMinister.FormattingEnabled = true;
            this.cmbMinister.Location = new System.Drawing.Point(3, 50);
            this.cmbMinister.Name = "cmbMinister";
            this.cmbMinister.Size = new System.Drawing.Size(186, 21);
            this.cmbMinister.TabIndex = 7;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(192, 74);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Blood Event";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label7.Location = new System.Drawing.Point(3, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Venue";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(3, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 20);
            this.textBox1.TabIndex = 9;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescription.Cue = null;
            this.txtDescription.CueColor = System.Drawing.Color.Gray;
            this.txtDescription.Location = new System.Drawing.Point(12, 300);
            this.txtDescription.MaxLength = 1000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(365, 85);
            this.txtDescription.TabIndex = 5;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTitle.Cue = null;
            this.txtTitle.CueColor = System.Drawing.Color.Gray;
            this.txtTitle.Location = new System.Drawing.Point(18, 101);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(157, 20);
            this.txtTitle.TabIndex = 5;
            // 
            // AddSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 451);
            this.Controls.Add(this.tabScheduleType);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbScheduleType);
            this.Controls.Add(this.label1);
            this.Name = "AddSchedule";
            this.Text = "AddSchedule";
            this.Load += new System.EventHandler(this.AddSchedule_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabScheduleType.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbScheduleType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CueTextBox txtTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroDateTime dtpDateEnd;
        private MetroFramework.Controls.MetroDateTime dtpDateStart;
        private System.Windows.Forms.Label label5;
        private CueTextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dtpTimeStart;
        private System.Windows.Forms.DateTimePicker dtpTimeEnd;
        private System.Windows.Forms.Button btnAdd;
        private HiddenTabControl tabScheduleType;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbMinister;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
    }
}