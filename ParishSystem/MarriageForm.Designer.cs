namespace ParishSystem
{
    partial class MarriageForm
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
            this.lblGName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbGStatus = new MetroFramework.Controls.MetroComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGBirthPlace = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbBStatus = new MetroFramework.Controls.MetroComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblBName = new System.Windows.Forms.Label();
            this.txtSponsorResidence = new System.Windows.Forms.TextBox();
            this.txtSponsorSuffix = new System.Windows.Forms.TextBox();
            this.txtSponsorLN = new System.Windows.Forms.TextBox();
            this.txtSponsorMI = new System.Windows.Forms.TextBox();
            this.txtSponsorFN = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dgvSponsor = new MetroFramework.Controls.MetroGrid();
            this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.midName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suffix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.residence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddSponsor = new MetroFramework.Controls.MetroButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioMale = new MetroFramework.Controls.MetroRadioButton();
            this.radioFemale = new MetroFramework.Controls.MetroRadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSubmit = new MetroFramework.Controls.MetroButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmbLicenseDate = new MetroFramework.Controls.MetroDateTime();
            this.dtpMarriageDate = new MetroFramework.Controls.MetroDateTime();
            this.cmbMinister = new MetroFramework.Controls.MetroComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cueTextBox1 = new ParishSystem.CueTextBox();
            this.txtBFSuffix = new ParishSystem.CueTextBox();
            this.txtBMSuffix = new ParishSystem.CueTextBox();
            this.txtBFLN = new ParishSystem.CueTextBox();
            this.txtBFMI = new ParishSystem.CueTextBox();
            this.txtBMLN = new ParishSystem.CueTextBox();
            this.txtBFFN = new ParishSystem.CueTextBox();
            this.txtBMMI = new ParishSystem.CueTextBox();
            this.txtBMFN = new ParishSystem.CueTextBox();
            this.txtBResidence = new ParishSystem.CueTextBox();
            this.txtBBirthPlace = new ParishSystem.CueTextBox();
            this.txtGMSuffix = new ParishSystem.CueTextBox();
            this.txtGFSuffix = new ParishSystem.CueTextBox();
            this.txtGMLN = new ParishSystem.CueTextBox();
            this.txtGFLN = new ParishSystem.CueTextBox();
            this.txtGMMI = new ParishSystem.CueTextBox();
            this.txtGFMI = new ParishSystem.CueTextBox();
            this.txtGResidence = new ParishSystem.CueTextBox();
            this.txtGMFN = new ParishSystem.CueTextBox();
            this.txtGFFN = new ParishSystem.CueTextBox();
            this.txtGBirthPlace = new ParishSystem.CueTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSponsor)).BeginInit();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGName
            // 
            this.lblGName.AutoSize = true;
            this.lblGName.Location = new System.Drawing.Point(52, 42);
            this.lblGName.Name = "lblGName";
            this.lblGName.Size = new System.Drawing.Size(35, 13);
            this.lblGName.TabIndex = 0;
            this.lblGName.Text = "Name";
            this.lblGName.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbGStatus);
            this.panel1.Controls.Add(this.txtGMSuffix);
            this.panel1.Controls.Add(this.txtGFSuffix);
            this.panel1.Controls.Add(this.txtGMLN);
            this.panel1.Controls.Add(this.txtGFLN);
            this.panel1.Controls.Add(this.txtGMMI);
            this.panel1.Controls.Add(this.txtGFMI);
            this.panel1.Controls.Add(this.txtGResidence);
            this.panel1.Controls.Add(this.txtGMFN);
            this.panel1.Controls.Add(this.txtGFFN);
            this.panel1.Controls.Add(this.txtGBirthPlace);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblGBirthPlace);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(8, 58);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(314, 219);
            this.panel1.TabIndex = 1;
            // 
            // cmbGStatus
            // 
            this.cmbGStatus.FormattingEnabled = true;
            this.cmbGStatus.ItemHeight = 23;
            this.cmbGStatus.Location = new System.Drawing.Point(78, 79);
            this.cmbGStatus.Name = "cmbGStatus";
            this.cmbGStatus.Size = new System.Drawing.Size(223, 29);
            this.cmbGStatus.TabIndex = 56;
            this.cmbGStatus.UseSelectable = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Father";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mother";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblGBirthPlace
            // 
            this.lblGBirthPlace.AutoSize = true;
            this.lblGBirthPlace.Location = new System.Drawing.Point(13, 30);
            this.lblGBirthPlace.Name = "lblGBirthPlace";
            this.lblGBirthPlace.Size = new System.Drawing.Size(58, 13);
            this.lblGBirthPlace.TabIndex = 2;
            this.lblGBirthPlace.Text = "Birth Place";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 87);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Civil Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Residence";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Groom";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Bride";
            this.label4.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbBStatus);
            this.panel2.Controls.Add(this.txtBFSuffix);
            this.panel2.Controls.Add(this.txtBMSuffix);
            this.panel2.Controls.Add(this.txtBFLN);
            this.panel2.Controls.Add(this.txtBFMI);
            this.panel2.Controls.Add(this.txtBMLN);
            this.panel2.Controls.Add(this.txtBFFN);
            this.panel2.Controls.Add(this.txtBMMI);
            this.panel2.Controls.Add(this.txtBMFN);
            this.panel2.Controls.Add(this.txtBResidence);
            this.panel2.Controls.Add(this.txtBBirthPlace);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(328, 58);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(314, 219);
            this.panel2.TabIndex = 1;
            // 
            // cmbBStatus
            // 
            this.cmbBStatus.FormattingEnabled = true;
            this.cmbBStatus.ItemHeight = 23;
            this.cmbBStatus.Location = new System.Drawing.Point(78, 84);
            this.cmbBStatus.Name = "cmbBStatus";
            this.cmbBStatus.Size = new System.Drawing.Size(223, 29);
            this.cmbBStatus.TabIndex = 56;
            this.cmbBStatus.UseSelectable = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Father";
            this.label6.Click += new System.EventHandler(this.label1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mother";
            this.label7.Click += new System.EventHandler(this.label1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Birth Place";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Civil Status";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Residence";
            // 
            // lblBName
            // 
            this.lblBName.AutoSize = true;
            this.lblBName.Location = new System.Drawing.Point(372, 42);
            this.lblBName.Name = "lblBName";
            this.lblBName.Size = new System.Drawing.Size(35, 13);
            this.lblBName.TabIndex = 0;
            this.lblBName.Text = "Name";
            this.lblBName.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtSponsorResidence
            // 
            this.txtSponsorResidence.Location = new System.Drawing.Point(13, 65);
            this.txtSponsorResidence.Name = "txtSponsorResidence";
            this.txtSponsorResidence.Size = new System.Drawing.Size(277, 20);
            this.txtSponsorResidence.TabIndex = 46;
            // 
            // txtSponsorSuffix
            // 
            this.txtSponsorSuffix.Location = new System.Drawing.Point(266, 23);
            this.txtSponsorSuffix.Name = "txtSponsorSuffix";
            this.txtSponsorSuffix.Size = new System.Drawing.Size(24, 20);
            this.txtSponsorSuffix.TabIndex = 41;
            this.txtSponsorSuffix.Tag = "o";
            // 
            // txtSponsorLN
            // 
            this.txtSponsorLN.Location = new System.Drawing.Point(155, 23);
            this.txtSponsorLN.Name = "txtSponsorLN";
            this.txtSponsorLN.Size = new System.Drawing.Size(105, 20);
            this.txtSponsorLN.TabIndex = 40;
            // 
            // txtSponsorMI
            // 
            this.txtSponsorMI.Location = new System.Drawing.Point(125, 23);
            this.txtSponsorMI.Name = "txtSponsorMI";
            this.txtSponsorMI.Size = new System.Drawing.Size(24, 20);
            this.txtSponsorMI.TabIndex = 39;
            // 
            // txtSponsorFN
            // 
            this.txtSponsorFN.Location = new System.Drawing.Point(13, 23);
            this.txtSponsorFN.Name = "txtSponsorFN";
            this.txtSponsorFN.Size = new System.Drawing.Size(106, 20);
            this.txtSponsorFN.TabIndex = 38;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 50;
            this.label12.Text = "Residence";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 51;
            this.label13.Text = "Name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(85, 413);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 13);
            this.label16.TabIndex = 49;
            this.label16.Text = "Sponsors";
            // 
            // dgvSponsor
            // 
            this.dgvSponsor.AllowUserToAddRows = false;
            this.dgvSponsor.AllowUserToDeleteRows = false;
            this.dgvSponsor.AllowUserToResizeRows = false;
            this.dgvSponsor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSponsor.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvSponsor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSponsor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvSponsor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSponsor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSponsor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSponsor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.firstName,
            this.midName,
            this.lastName,
            this.suffix,
            this.gender,
            this.residence});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSponsor.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSponsor.EnableHeadersVisualStyles = false;
            this.dgvSponsor.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvSponsor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvSponsor.Location = new System.Drawing.Point(11, 164);
            this.dgvSponsor.Name = "dgvSponsor";
            this.dgvSponsor.ReadOnly = true;
            this.dgvSponsor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSponsor.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSponsor.RowHeadersVisible = false;
            this.dgvSponsor.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSponsor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSponsor.Size = new System.Drawing.Size(612, 95);
            this.dgvSponsor.TabIndex = 52;
            this.dgvSponsor.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSponsor_CellFormatting);
            // 
            // firstName
            // 
            this.firstName.HeaderText = "First Name";
            this.firstName.Name = "firstName";
            this.firstName.ReadOnly = true;
            // 
            // midName
            // 
            this.midName.HeaderText = "Middle Name";
            this.midName.Name = "midName";
            this.midName.ReadOnly = true;
            // 
            // lastName
            // 
            this.lastName.HeaderText = "Last Name";
            this.lastName.Name = "lastName";
            this.lastName.ReadOnly = true;
            // 
            // suffix
            // 
            this.suffix.HeaderText = "Suffix";
            this.suffix.Name = "suffix";
            this.suffix.ReadOnly = true;
            this.suffix.Width = 50;
            // 
            // gender
            // 
            this.gender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.gender.HeaderText = "Gender";
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            this.gender.Width = 68;
            // 
            // residence
            // 
            this.residence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.residence.HeaderText = "Residence";
            this.residence.Name = "residence";
            this.residence.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAddSponsor);
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.dgvSponsor);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.txtSponsorResidence);
            this.panel3.Controls.Add(this.txtSponsorFN);
            this.panel3.Controls.Add(this.txtSponsorSuffix);
            this.panel3.Controls.Add(this.txtSponsorMI);
            this.panel3.Controls.Add(this.txtSponsorLN);
            this.panel3.Location = new System.Drawing.Point(11, 413);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(631, 269);
            this.panel3.TabIndex = 53;
            // 
            // btnAddSponsor
            // 
            this.btnAddSponsor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSponsor.Location = new System.Drawing.Point(511, 135);
            this.btnAddSponsor.Name = "btnAddSponsor";
            this.btnAddSponsor.Size = new System.Drawing.Size(95, 23);
            this.btnAddSponsor.TabIndex = 54;
            this.btnAddSponsor.Text = "Add Sponsor";
            this.btnAddSponsor.UseSelectable = true;
            this.btnAddSponsor.Click += new System.EventHandler(this.btnAddSponsor_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.radioMale);
            this.flowLayoutPanel1.Controls.Add(this.radioFemale);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 105);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(136, 28);
            this.flowLayoutPanel1.TabIndex = 53;
            // 
            // radioMale
            // 
            this.radioMale.AutoSize = true;
            this.radioMale.Checked = true;
            this.radioMale.Location = new System.Drawing.Point(3, 3);
            this.radioMale.Name = "radioMale";
            this.radioMale.Size = new System.Drawing.Size(49, 15);
            this.radioMale.TabIndex = 55;
            this.radioMale.TabStop = true;
            this.radioMale.Text = "Male";
            this.radioMale.UseSelectable = true;
            // 
            // radioFemale
            // 
            this.radioFemale.AutoSize = true;
            this.radioFemale.Location = new System.Drawing.Point(58, 3);
            this.radioFemale.Name = "radioFemale";
            this.radioFemale.Size = new System.Drawing.Size(61, 15);
            this.radioFemale.TabIndex = 55;
            this.radioFemale.Text = "Female";
            this.radioFemale.UseSelectable = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "Gender";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(284, 725);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 54;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseSelectable = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cueTextBox1);
            this.panel4.Controls.Add(this.cmbLicenseDate);
            this.panel4.Controls.Add(this.dtpMarriageDate);
            this.panel4.Controls.Add(this.cmbMinister);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Location = new System.Drawing.Point(8, 283);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(634, 111);
            this.panel4.TabIndex = 55;
            // 
            // cmbLicenseDate
            // 
            this.cmbLicenseDate.Location = new System.Drawing.Point(93, 76);
            this.cmbLicenseDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.cmbLicenseDate.Name = "cmbLicenseDate";
            this.cmbLicenseDate.Size = new System.Drawing.Size(206, 29);
            this.cmbLicenseDate.TabIndex = 57;
            // 
            // dtpMarriageDate
            // 
            this.dtpMarriageDate.Location = new System.Drawing.Point(94, 43);
            this.dtpMarriageDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpMarriageDate.Name = "dtpMarriageDate";
            this.dtpMarriageDate.Size = new System.Drawing.Size(206, 29);
            this.dtpMarriageDate.TabIndex = 57;
            // 
            // cmbMinister
            // 
            this.cmbMinister.FormattingEnabled = true;
            this.cmbMinister.ItemHeight = 23;
            this.cmbMinister.Location = new System.Drawing.Point(94, 11);
            this.cmbMinister.Name = "cmbMinister";
            this.cmbMinister.Size = new System.Drawing.Size(207, 29);
            this.cmbMinister.TabIndex = 56;
            this.cmbMinister.UseSelectable = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 86);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "License Date";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 53);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Marriage Date";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(333, 14);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Remarks";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Minister";
            // 
            // cueTextBox1
            // 
            this.cueTextBox1.Cue = null;
            this.cueTextBox1.CueColor = System.Drawing.Color.Empty;
            this.cueTextBox1.Location = new System.Drawing.Point(336, 30);
            this.cueTextBox1.Multiline = true;
            this.cueTextBox1.Name = "cueTextBox1";
            this.cueTextBox1.Size = new System.Drawing.Size(286, 75);
            this.cueTextBox1.TabIndex = 58;
            this.cueTextBox1.Tag = "o";
            // 
            // txtBFSuffix
            // 
            this.txtBFSuffix.Cue = null;
            this.txtBFSuffix.CueColor = System.Drawing.Color.Empty;
            this.txtBFSuffix.Location = new System.Drawing.Point(255, 182);
            this.txtBFSuffix.Name = "txtBFSuffix";
            this.txtBFSuffix.Size = new System.Drawing.Size(47, 20);
            this.txtBFSuffix.TabIndex = 55;
            this.txtBFSuffix.Tag = "o";
            // 
            // txtBMSuffix
            // 
            this.txtBMSuffix.Cue = null;
            this.txtBMSuffix.CueColor = System.Drawing.Color.Empty;
            this.txtBMSuffix.Location = new System.Drawing.Point(255, 140);
            this.txtBMSuffix.Name = "txtBMSuffix";
            this.txtBMSuffix.Size = new System.Drawing.Size(47, 20);
            this.txtBMSuffix.TabIndex = 55;
            this.txtBMSuffix.Tag = "o";
            // 
            // txtBFLN
            // 
            this.txtBFLN.Cue = null;
            this.txtBFLN.CueColor = System.Drawing.Color.Empty;
            this.txtBFLN.Location = new System.Drawing.Point(154, 182);
            this.txtBFLN.Name = "txtBFLN";
            this.txtBFLN.Size = new System.Drawing.Size(95, 20);
            this.txtBFLN.TabIndex = 55;
            // 
            // txtBFMI
            // 
            this.txtBFMI.Cue = null;
            this.txtBFMI.CueColor = System.Drawing.Color.Empty;
            this.txtBFMI.Location = new System.Drawing.Point(117, 182);
            this.txtBFMI.Name = "txtBFMI";
            this.txtBFMI.Size = new System.Drawing.Size(31, 20);
            this.txtBFMI.TabIndex = 55;
            // 
            // txtBMLN
            // 
            this.txtBMLN.Cue = null;
            this.txtBMLN.CueColor = System.Drawing.Color.Empty;
            this.txtBMLN.Location = new System.Drawing.Point(154, 140);
            this.txtBMLN.Name = "txtBMLN";
            this.txtBMLN.Size = new System.Drawing.Size(95, 20);
            this.txtBMLN.TabIndex = 55;
            // 
            // txtBFFN
            // 
            this.txtBFFN.Cue = null;
            this.txtBFFN.CueColor = System.Drawing.Color.Empty;
            this.txtBFFN.Location = new System.Drawing.Point(16, 182);
            this.txtBFFN.Name = "txtBFFN";
            this.txtBFFN.Size = new System.Drawing.Size(95, 20);
            this.txtBFFN.TabIndex = 55;
            // 
            // txtBMMI
            // 
            this.txtBMMI.Cue = null;
            this.txtBMMI.CueColor = System.Drawing.Color.Empty;
            this.txtBMMI.Location = new System.Drawing.Point(117, 140);
            this.txtBMMI.Name = "txtBMMI";
            this.txtBMMI.Size = new System.Drawing.Size(31, 20);
            this.txtBMMI.TabIndex = 55;
            // 
            // txtBMFN
            // 
            this.txtBMFN.Cue = null;
            this.txtBMFN.CueColor = System.Drawing.Color.Empty;
            this.txtBMFN.Location = new System.Drawing.Point(16, 140);
            this.txtBMFN.Name = "txtBMFN";
            this.txtBMFN.Size = new System.Drawing.Size(95, 20);
            this.txtBMFN.TabIndex = 55;
            // 
            // txtBResidence
            // 
            this.txtBResidence.Cue = null;
            this.txtBResidence.CueColor = System.Drawing.Color.Empty;
            this.txtBResidence.Location = new System.Drawing.Point(78, 54);
            this.txtBResidence.Name = "txtBResidence";
            this.txtBResidence.Size = new System.Drawing.Size(224, 20);
            this.txtBResidence.TabIndex = 4;
            // 
            // txtBBirthPlace
            // 
            this.txtBBirthPlace.Cue = null;
            this.txtBBirthPlace.CueColor = System.Drawing.Color.Empty;
            this.txtBBirthPlace.Location = new System.Drawing.Point(78, 30);
            this.txtBBirthPlace.Name = "txtBBirthPlace";
            this.txtBBirthPlace.Size = new System.Drawing.Size(224, 20);
            this.txtBBirthPlace.TabIndex = 4;
            // 
            // txtGMSuffix
            // 
            this.txtGMSuffix.Cue = null;
            this.txtGMSuffix.CueColor = System.Drawing.Color.Empty;
            this.txtGMSuffix.Location = new System.Drawing.Point(255, 140);
            this.txtGMSuffix.Name = "txtGMSuffix";
            this.txtGMSuffix.Size = new System.Drawing.Size(47, 20);
            this.txtGMSuffix.TabIndex = 55;
            this.txtGMSuffix.Tag = "o";
            // 
            // txtGFSuffix
            // 
            this.txtGFSuffix.Cue = null;
            this.txtGFSuffix.CueColor = System.Drawing.Color.Empty;
            this.txtGFSuffix.Location = new System.Drawing.Point(255, 182);
            this.txtGFSuffix.Name = "txtGFSuffix";
            this.txtGFSuffix.Size = new System.Drawing.Size(47, 20);
            this.txtGFSuffix.TabIndex = 55;
            this.txtGFSuffix.Tag = "o";
            // 
            // txtGMLN
            // 
            this.txtGMLN.Cue = null;
            this.txtGMLN.CueColor = System.Drawing.Color.Empty;
            this.txtGMLN.Location = new System.Drawing.Point(154, 140);
            this.txtGMLN.Name = "txtGMLN";
            this.txtGMLN.Size = new System.Drawing.Size(95, 20);
            this.txtGMLN.TabIndex = 55;
            // 
            // txtGFLN
            // 
            this.txtGFLN.Cue = null;
            this.txtGFLN.CueColor = System.Drawing.Color.Empty;
            this.txtGFLN.Location = new System.Drawing.Point(154, 182);
            this.txtGFLN.Name = "txtGFLN";
            this.txtGFLN.Size = new System.Drawing.Size(95, 20);
            this.txtGFLN.TabIndex = 55;
            // 
            // txtGMMI
            // 
            this.txtGMMI.Cue = null;
            this.txtGMMI.CueColor = System.Drawing.Color.Empty;
            this.txtGMMI.Location = new System.Drawing.Point(117, 140);
            this.txtGMMI.Name = "txtGMMI";
            this.txtGMMI.Size = new System.Drawing.Size(31, 20);
            this.txtGMMI.TabIndex = 55;
            // 
            // txtGFMI
            // 
            this.txtGFMI.Cue = null;
            this.txtGFMI.CueColor = System.Drawing.Color.Empty;
            this.txtGFMI.Location = new System.Drawing.Point(117, 182);
            this.txtGFMI.Name = "txtGFMI";
            this.txtGFMI.Size = new System.Drawing.Size(31, 20);
            this.txtGFMI.TabIndex = 55;
            // 
            // txtGResidence
            // 
            this.txtGResidence.Cue = null;
            this.txtGResidence.CueColor = System.Drawing.Color.Empty;
            this.txtGResidence.Location = new System.Drawing.Point(78, 54);
            this.txtGResidence.Name = "txtGResidence";
            this.txtGResidence.Size = new System.Drawing.Size(224, 20);
            this.txtGResidence.TabIndex = 4;
            // 
            // txtGMFN
            // 
            this.txtGMFN.Cue = null;
            this.txtGMFN.CueColor = System.Drawing.Color.Empty;
            this.txtGMFN.Location = new System.Drawing.Point(16, 140);
            this.txtGMFN.Name = "txtGMFN";
            this.txtGMFN.Size = new System.Drawing.Size(95, 20);
            this.txtGMFN.TabIndex = 55;
            // 
            // txtGFFN
            // 
            this.txtGFFN.Cue = null;
            this.txtGFFN.CueColor = System.Drawing.Color.Empty;
            this.txtGFFN.Location = new System.Drawing.Point(16, 182);
            this.txtGFFN.Name = "txtGFFN";
            this.txtGFFN.Size = new System.Drawing.Size(95, 20);
            this.txtGFFN.TabIndex = 55;
            // 
            // txtGBirthPlace
            // 
            this.txtGBirthPlace.Cue = null;
            this.txtGBirthPlace.CueColor = System.Drawing.Color.Empty;
            this.txtGBirthPlace.Location = new System.Drawing.Point(78, 30);
            this.txtGBirthPlace.Name = "txtGBirthPlace";
            this.txtGBirthPlace.Size = new System.Drawing.Size(224, 20);
            this.txtGBirthPlace.TabIndex = 4;
            // 
            // MarriageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 756);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblBName);
            this.Controls.Add(this.lblGName);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "MarriageForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "MarriageForm";
            this.Load += new System.EventHandler(this.MarriageForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSponsor)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGName;
        private System.Windows.Forms.Panel panel1;
        private CueTextBox txtGResidence;
        private CueTextBox txtGBirthPlace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGBirthPlace;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private CueTextBox txtBResidence;
        private CueTextBox txtBBirthPlace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblBName;
        private System.Windows.Forms.TextBox txtSponsorResidence;
        private System.Windows.Forms.TextBox txtSponsorSuffix;
        private System.Windows.Forms.TextBox txtSponsorLN;
        private System.Windows.Forms.TextBox txtSponsorMI;
        private System.Windows.Forms.TextBox txtSponsorFN;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private MetroFramework.Controls.MetroGrid dgvSponsor;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label11;
        private MetroFramework.Controls.MetroButton btnSubmit;
        private CueTextBox txtGMSuffix;
        private CueTextBox txtGFSuffix;
        private CueTextBox txtGMLN;
        private CueTextBox txtGFLN;
        private CueTextBox txtGMMI;
        private CueTextBox txtGFMI;
        private CueTextBox txtGMFN;
        private CueTextBox txtGFFN;
        private CueTextBox txtBFSuffix;
        private CueTextBox txtBMSuffix;
        private CueTextBox txtBFLN;
        private CueTextBox txtBFMI;
        private CueTextBox txtBMLN;
        private CueTextBox txtBFFN;
        private CueTextBox txtBMMI;
        private CueTextBox txtBMFN;
        private MetroFramework.Controls.MetroButton btnAddSponsor;
        private MetroFramework.Controls.MetroComboBox cmbGStatus;
        private System.Windows.Forms.Label label14;
        private MetroFramework.Controls.MetroComboBox cmbBStatus;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel4;
        private MetroFramework.Controls.MetroDateTime cmbLicenseDate;
        private MetroFramework.Controls.MetroDateTime dtpMarriageDate;
        private MetroFramework.Controls.MetroComboBox cmbMinister;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private CueTextBox cueTextBox1;
        private System.Windows.Forms.Label label20;
        private MetroFramework.Controls.MetroRadioButton radioMale;
        private MetroFramework.Controls.MetroRadioButton radioFemale;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn midName;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn suffix;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn residence;
    }
}