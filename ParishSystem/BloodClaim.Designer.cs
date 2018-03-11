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
            this.Claim_button = new System.Windows.Forms.Button();
            this.BloodDonationsDGV = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.donationAdd = new System.Windows.Forms.Button();
            this.donationDelete = new System.Windows.Forms.Button();
            this.clear_button = new System.Windows.Forms.Button();
            this.ln = new MetroFramework.Controls.MetroTextBox();
            this.sf = new MetroFramework.Controls.MetroTextBox();
            this.fn = new MetroFramework.Controls.MetroTextBox();
            this.mi = new MetroFramework.Controls.MetroTextBox();
            this.DonationID_textbox = new MetroFramework.Controls.MetroTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.donationPK = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BloodDonationsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // Claim_button
            // 
            this.Claim_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Claim_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Claim_button.Enabled = false;
            this.Claim_button.FlatAppearance.BorderSize = 0;
            this.Claim_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Claim_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Claim_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Claim_button.ForeColor = System.Drawing.Color.White;
            this.Claim_button.Location = new System.Drawing.Point(332, 570);
            this.Claim_button.Name = "Claim_button";
            this.Claim_button.Size = new System.Drawing.Size(293, 37);
            this.Claim_button.TabIndex = 4;
            this.Claim_button.Text = "Claim";
            this.Claim_button.UseVisualStyleBackColor = false;
            this.Claim_button.Click += new System.EventHandler(this.Claim_button_Click);
            // 
            // BloodDonationsDGV
            // 
            this.BloodDonationsDGV.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.BloodDonationsDGV.AllowUserToAddRows = false;
            this.BloodDonationsDGV.AllowUserToDeleteRows = false;
            this.BloodDonationsDGV.AllowUserToOrderColumns = true;
            this.BloodDonationsDGV.AllowUserToResizeRows = false;
            this.BloodDonationsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
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
            this.BloodDonationsDGV.ColumnHeadersHeight = 35;
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
            this.BloodDonationsDGV.Location = new System.Drawing.Point(332, 256);
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
            this.BloodDonationsDGV.RowTemplate.Height = 35;
            this.BloodDonationsDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BloodDonationsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BloodDonationsDGV.Size = new System.Drawing.Size(293, 297);
            this.BloodDonationsDGV.TabIndex = 11;
            this.BloodDonationsDGV.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BloodDonationsDGV_CellContentDoubleClick);
            this.BloodDonationsDGV.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.BloodDonationsDGV_RowsAdded);
            this.BloodDonationsDGV.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.BloodDonationsDGV_RowsRemoved);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // DonationID
            // 
            this.DonationID.HeaderText = "";
            this.DonationID.Name = "DonationID";
            this.DonationID.ReadOnly = true;
            // 
            // donationAdd
            // 
            this.donationAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.donationAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.donationAdd.Enabled = false;
            this.donationAdd.FlatAppearance.BorderSize = 0;
            this.donationAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.donationAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.donationAdd.ForeColor = System.Drawing.Color.White;
            this.donationAdd.Location = new System.Drawing.Point(632, 256);
            this.donationAdd.Name = "donationAdd";
            this.donationAdd.Size = new System.Drawing.Size(122, 37);
            this.donationAdd.TabIndex = 12;
            this.donationAdd.Tag = "a";
            this.donationAdd.Text = "Add";
            this.donationAdd.UseVisualStyleBackColor = false;
            this.donationAdd.Click += new System.EventHandler(this.donationAdd_Click);
            // 
            // donationDelete
            // 
            this.donationDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.donationDelete.BackColor = System.Drawing.Color.IndianRed;
            this.donationDelete.Enabled = false;
            this.donationDelete.FlatAppearance.BorderSize = 0;
            this.donationDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.donationDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.donationDelete.ForeColor = System.Drawing.Color.White;
            this.donationDelete.Location = new System.Drawing.Point(632, 342);
            this.donationDelete.Name = "donationDelete";
            this.donationDelete.Size = new System.Drawing.Size(120, 37);
            this.donationDelete.TabIndex = 13;
            this.donationDelete.Text = "Delete";
            this.donationDelete.UseVisualStyleBackColor = false;
            this.donationDelete.Click += new System.EventHandler(this.donationDelete_Click);
            // 
            // clear_button
            // 
            this.clear_button.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.clear_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.clear_button.FlatAppearance.BorderSize = 0;
            this.clear_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.clear_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear_button.ForeColor = System.Drawing.Color.White;
            this.clear_button.Location = new System.Drawing.Point(632, 299);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(120, 37);
            this.clear_button.TabIndex = 14;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = false;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // ln
            // 
            this.ln.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.ln.CustomButton.Image = null;
            this.ln.CustomButton.Location = new System.Drawing.Point(214, 1);
            this.ln.CustomButton.Name = "";
            this.ln.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ln.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ln.CustomButton.TabIndex = 1;
            this.ln.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ln.CustomButton.UseSelectable = true;
            this.ln.CustomButton.Visible = false;
            this.ln.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.ln.Lines = new string[0];
            this.ln.Location = new System.Drawing.Point(332, 156);
            this.ln.MaxLength = 32767;
            this.ln.Name = "ln";
            this.ln.PasswordChar = '\0';
            this.ln.PromptText = "Lastname";
            this.ln.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ln.SelectedText = "";
            this.ln.SelectionLength = 0;
            this.ln.SelectionStart = 0;
            this.ln.ShortcutsEnabled = true;
            this.ln.Size = new System.Drawing.Size(236, 23);
            this.ln.TabIndex = 15;
            this.ln.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ln.UseSelectable = true;
            this.ln.WaterMark = "Lastname";
            this.ln.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ln.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ln.TextChanged += new System.EventHandler(this.ln_TextChanged);
            // 
            // sf
            // 
            this.sf.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.sf.CustomButton.Image = null;
            this.sf.CustomButton.Location = new System.Drawing.Point(29, 1);
            this.sf.CustomButton.Name = "";
            this.sf.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.sf.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.sf.CustomButton.TabIndex = 1;
            this.sf.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.sf.CustomButton.UseSelectable = true;
            this.sf.CustomButton.Visible = false;
            this.sf.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.sf.Lines = new string[0];
            this.sf.Location = new System.Drawing.Point(574, 156);
            this.sf.MaxLength = 32767;
            this.sf.Name = "sf";
            this.sf.PasswordChar = '\0';
            this.sf.PromptText = "Sf";
            this.sf.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.sf.SelectedText = "";
            this.sf.SelectionLength = 0;
            this.sf.SelectionStart = 0;
            this.sf.ShortcutsEnabled = true;
            this.sf.Size = new System.Drawing.Size(51, 23);
            this.sf.TabIndex = 16;
            this.sf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sf.UseSelectable = true;
            this.sf.WaterMark = "Sf";
            this.sf.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.sf.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sf.TextChanged += new System.EventHandler(this.sf_TextChanged);
            // 
            // fn
            // 
            this.fn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.fn.CustomButton.Image = null;
            this.fn.CustomButton.Location = new System.Drawing.Point(214, 1);
            this.fn.CustomButton.Name = "";
            this.fn.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.fn.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.fn.CustomButton.TabIndex = 1;
            this.fn.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.fn.CustomButton.UseSelectable = true;
            this.fn.CustomButton.Visible = false;
            this.fn.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.fn.Lines = new string[0];
            this.fn.Location = new System.Drawing.Point(332, 117);
            this.fn.MaxLength = 32767;
            this.fn.Name = "fn";
            this.fn.PasswordChar = '\0';
            this.fn.PromptText = "Firtsname";
            this.fn.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.fn.SelectedText = "";
            this.fn.SelectionLength = 0;
            this.fn.SelectionStart = 0;
            this.fn.ShortcutsEnabled = true;
            this.fn.Size = new System.Drawing.Size(236, 23);
            this.fn.TabIndex = 17;
            this.fn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fn.UseSelectable = true;
            this.fn.WaterMark = "Firtsname";
            this.fn.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.fn.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fn.TextChanged += new System.EventHandler(this.fn_TextChanged);
            // 
            // mi
            // 
            this.mi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.mi.CustomButton.Image = null;
            this.mi.CustomButton.Location = new System.Drawing.Point(29, 1);
            this.mi.CustomButton.Name = "";
            this.mi.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mi.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mi.CustomButton.TabIndex = 1;
            this.mi.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mi.CustomButton.UseSelectable = true;
            this.mi.CustomButton.Visible = false;
            this.mi.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mi.Lines = new string[0];
            this.mi.Location = new System.Drawing.Point(574, 117);
            this.mi.MaxLength = 1;
            this.mi.Name = "mi";
            this.mi.PasswordChar = '\0';
            this.mi.PromptText = "Mi";
            this.mi.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mi.SelectedText = "";
            this.mi.SelectionLength = 0;
            this.mi.SelectionStart = 0;
            this.mi.ShortcutsEnabled = true;
            this.mi.Size = new System.Drawing.Size(51, 23);
            this.mi.TabIndex = 18;
            this.mi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mi.UseSelectable = true;
            this.mi.WaterMark = "Mi";
            this.mi.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mi.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mi.TextChanged += new System.EventHandler(this.mi_TextChanged);
            // 
            // DonationID_textbox
            // 
            this.DonationID_textbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // 
            // 
            // 
            this.DonationID_textbox.CustomButton.Image = null;
            this.DonationID_textbox.CustomButton.Location = new System.Drawing.Point(214, 1);
            this.DonationID_textbox.CustomButton.Name = "";
            this.DonationID_textbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.DonationID_textbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.DonationID_textbox.CustomButton.TabIndex = 1;
            this.DonationID_textbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.DonationID_textbox.CustomButton.UseSelectable = true;
            this.DonationID_textbox.CustomButton.Visible = false;
            this.DonationID_textbox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.DonationID_textbox.Lines = new string[0];
            this.DonationID_textbox.Location = new System.Drawing.Point(332, 215);
            this.DonationID_textbox.MaxLength = 32767;
            this.DonationID_textbox.Name = "DonationID_textbox";
            this.DonationID_textbox.PasswordChar = '\0';
            this.DonationID_textbox.PromptText = "Donation ID";
            this.DonationID_textbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DonationID_textbox.SelectedText = "";
            this.DonationID_textbox.SelectionLength = 0;
            this.DonationID_textbox.SelectionStart = 0;
            this.DonationID_textbox.ShortcutsEnabled = true;
            this.DonationID_textbox.Size = new System.Drawing.Size(236, 23);
            this.DonationID_textbox.TabIndex = 19;
            this.DonationID_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DonationID_textbox.UseSelectable = true;
            this.DonationID_textbox.WaterMark = "Donation ID";
            this.DonationID_textbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.DonationID_textbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DonationID_textbox.TextChanged += new System.EventHandler(this.DonationID_textbox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(68, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 32);
            this.label8.TabIndex = 37;
            this.label8.Text = "Blood Claim";
            // 
            // donationPK
            // 
            this.donationPK.AutoSize = true;
            this.donationPK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donationPK.Location = new System.Drawing.Point(245, 71);
            this.donationPK.Name = "donationPK";
            this.donationPK.Size = new System.Drawing.Size(27, 20);
            this.donationPK.TabIndex = 7;
            this.donationPK.Text = "00";
            this.donationPK.Visible = false;
            // 
            // BloodClaim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(943, 669);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DonationID_textbox);
            this.Controls.Add(this.mi);
            this.Controls.Add(this.fn);
            this.Controls.Add(this.sf);
            this.Controls.Add(this.ln);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.donationDelete);
            this.Controls.Add(this.donationAdd);
            this.Controls.Add(this.BloodDonationsDGV);
            this.Controls.Add(this.Claim_button);
            this.Controls.Add(this.donationPK);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BloodClaim";
            this.Text = "BloodClaim";
            this.Load += new System.EventHandler(this.BloodClaim_Load);
            this.VisibleChanged += new System.EventHandler(this.BloodClaim_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.BloodDonationsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Claim_button;
        private System.Windows.Forms.DataGridView BloodDonationsDGV;
        private System.Windows.Forms.Button donationAdd;
        private System.Windows.Forms.Button donationDelete;
        private System.Windows.Forms.Button clear_button;
        private MetroFramework.Controls.MetroTextBox ln;
        private MetroFramework.Controls.MetroTextBox sf;
        private MetroFramework.Controls.MetroTextBox fn;
        private MetroFramework.Controls.MetroTextBox mi;
        private MetroFramework.Controls.MetroTextBox DonationID_textbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label donationPK;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonationID;
    }
}