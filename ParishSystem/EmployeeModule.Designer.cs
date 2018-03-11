namespace ParishSystem
{
    partial class EmployeeModule
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.EmployeeDGV = new System.Windows.Forms.DataGridView();
            this.userID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.midName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suffix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.privileges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel = new System.Windows.Forms.Panel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cmbEmployeeType = new MetroFramework.Controls.MetroComboBox();
            this.txtLastName = new MetroFramework.Controls.MetroTextBox();
            this.txtSuffix = new MetroFramework.Controls.MetroTextBox();
            this.txtMI = new MetroFramework.Controls.MetroTextBox();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.txtUsername = new MetroFramework.Controls.MetroTextBox();
            this.txtFirstName = new MetroFramework.Controls.MetroTextBox();
            this.employeeID_label = new System.Windows.Forms.Label();
            this.resetPassword_button = new System.Windows.Forms.Button();
            this.txtClear = new System.Windows.Forms.Button();
            this.txtAdd = new System.Windows.Forms.Button();
            this.active_checkbox = new System.Windows.Forms.CheckBox();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDGV)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EmployeeDGV
            // 
            this.EmployeeDGV.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.EmployeeDGV.AllowUserToAddRows = false;
            this.EmployeeDGV.AllowUserToDeleteRows = false;
            this.EmployeeDGV.AllowUserToOrderColumns = true;
            this.EmployeeDGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.EmployeeDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.EmployeeDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EmployeeDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EmployeeDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.EmployeeDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EmployeeDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.EmployeeDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EmployeeDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.EmployeeDGV.ColumnHeadersHeight = 40;
            this.EmployeeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.EmployeeDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userID,
            this.name,
            this.firstName,
            this.midName,
            this.lastName,
            this.suffix,
            this.username,
            this.status,
            this.privileges});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EmployeeDGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.EmployeeDGV.EnableHeadersVisualStyles = false;
            this.EmployeeDGV.GridColor = System.Drawing.Color.White;
            this.EmployeeDGV.Location = new System.Drawing.Point(30, 50);
            this.EmployeeDGV.MultiSelect = false;
            this.EmployeeDGV.Name = "EmployeeDGV";
            this.EmployeeDGV.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Magenta;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EmployeeDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.EmployeeDGV.RowHeadersVisible = false;
            this.EmployeeDGV.RowHeadersWidth = 50;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.DarkRed;
            this.EmployeeDGV.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.EmployeeDGV.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EmployeeDGV.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.EmployeeDGV.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.EmployeeDGV.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.EmployeeDGV.RowTemplate.Height = 35;
            this.EmployeeDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EmployeeDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EmployeeDGV.Size = new System.Drawing.Size(499, 582);
            this.EmployeeDGV.TabIndex = 4;
            this.EmployeeDGV.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EmployeeDGV_CellContentDoubleClick);
            this.EmployeeDGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.EmployeeDGV_CellFormatting);
            this.EmployeeDGV.VisibleChanged += new System.EventHandler(this.EmployeeDGV_VisibleChanged);
            // 
            // userID
            // 
            this.userID.DataPropertyName = "userID";
            this.userID.HeaderText = "userID";
            this.userID.Name = "userID";
            this.userID.ReadOnly = true;
            this.userID.Visible = false;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // firstName
            // 
            this.firstName.DataPropertyName = "firstName";
            this.firstName.HeaderText = "firstName";
            this.firstName.Name = "firstName";
            this.firstName.ReadOnly = true;
            this.firstName.Visible = false;
            // 
            // midName
            // 
            this.midName.DataPropertyName = "midName";
            this.midName.HeaderText = "midName";
            this.midName.Name = "midName";
            this.midName.ReadOnly = true;
            this.midName.Visible = false;
            // 
            // lastName
            // 
            this.lastName.DataPropertyName = "lastName";
            this.lastName.HeaderText = "lastName";
            this.lastName.Name = "lastName";
            this.lastName.ReadOnly = true;
            this.lastName.Visible = false;
            // 
            // suffix
            // 
            this.suffix.DataPropertyName = "suffix";
            this.suffix.HeaderText = "suffix";
            this.suffix.Name = "suffix";
            this.suffix.ReadOnly = true;
            this.suffix.Visible = false;
            // 
            // username
            // 
            this.username.DataPropertyName = "username";
            this.username.HeaderText = "Username";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // privileges
            // 
            this.privileges.DataPropertyName = "privileges";
            this.privileges.HeaderText = "Privilege";
            this.privileges.Name = "privileges";
            this.privileges.ReadOnly = true;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.metroLabel1);
            this.panel.Controls.Add(this.cmbEmployeeType);
            this.panel.Controls.Add(this.txtLastName);
            this.panel.Controls.Add(this.txtSuffix);
            this.panel.Controls.Add(this.txtMI);
            this.panel.Controls.Add(this.txtPassword);
            this.panel.Controls.Add(this.txtUsername);
            this.panel.Controls.Add(this.txtFirstName);
            this.panel.Controls.Add(this.employeeID_label);
            this.panel.Controls.Add(this.resetPassword_button);
            this.panel.Controls.Add(this.txtClear);
            this.panel.Controls.Add(this.txtAdd);
            this.panel.Controls.Add(this.active_checkbox);
            this.panel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel.Location = new System.Drawing.Point(535, 69);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(406, 492);
            this.panel.TabIndex = 5;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(149, 43);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(120, 25);
            this.metroLabel1.TabIndex = 55;
            this.metroLabel1.Text = "USER PROFILE";
            // 
            // cmbEmployeeType
            // 
            this.cmbEmployeeType.FormattingEnabled = true;
            this.cmbEmployeeType.ItemHeight = 23;
            this.cmbEmployeeType.Location = new System.Drawing.Point(105, 244);
            this.cmbEmployeeType.Name = "cmbEmployeeType";
            this.cmbEmployeeType.Size = new System.Drawing.Size(204, 29);
            this.cmbEmployeeType.Style = MetroFramework.MetroColorStyle.Silver;
            this.cmbEmployeeType.TabIndex = 51;
            this.cmbEmployeeType.UseSelectable = true;
            this.cmbEmployeeType.SelectedIndexChanged += new System.EventHandler(this.cmbEmployeeType_SelectedIndexChanged);
            // 
            // txtLastName
            // 
            // 
            // 
            // 
            this.txtLastName.CustomButton.Image = null;
            this.txtLastName.CustomButton.Location = new System.Drawing.Point(102, 1);
            this.txtLastName.CustomButton.Name = "";
            this.txtLastName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtLastName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLastName.CustomButton.TabIndex = 1;
            this.txtLastName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLastName.CustomButton.UseSelectable = true;
            this.txtLastName.CustomButton.Visible = false;
            this.txtLastName.Lines = new string[0];
            this.txtLastName.Location = new System.Drawing.Point(200, 113);
            this.txtLastName.MaxLength = 32767;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.PasswordChar = '\0';
            this.txtLastName.PromptText = "Last Name";
            this.txtLastName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLastName.SelectedText = "";
            this.txtLastName.SelectionLength = 0;
            this.txtLastName.SelectionStart = 0;
            this.txtLastName.ShortcutsEnabled = true;
            this.txtLastName.Size = new System.Drawing.Size(124, 23);
            this.txtLastName.TabIndex = 47;
            this.txtLastName.UseSelectable = true;
            this.txtLastName.WaterMark = "Last Name";
            this.txtLastName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLastName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtLastName.TextChanged += new System.EventHandler(this.txtFields_TextChanged);
            // 
            // txtSuffix
            // 
            // 
            // 
            // 
            this.txtSuffix.CustomButton.Image = null;
            this.txtSuffix.CustomButton.Location = new System.Drawing.Point(23, 1);
            this.txtSuffix.CustomButton.Name = "";
            this.txtSuffix.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSuffix.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSuffix.CustomButton.TabIndex = 1;
            this.txtSuffix.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSuffix.CustomButton.UseSelectable = true;
            this.txtSuffix.CustomButton.Visible = false;
            this.txtSuffix.Lines = new string[0];
            this.txtSuffix.Location = new System.Drawing.Point(330, 113);
            this.txtSuffix.MaxLength = 32767;
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.PasswordChar = '\0';
            this.txtSuffix.PromptText = "Suffix";
            this.txtSuffix.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSuffix.SelectedText = "";
            this.txtSuffix.SelectionLength = 0;
            this.txtSuffix.SelectionStart = 0;
            this.txtSuffix.ShortcutsEnabled = true;
            this.txtSuffix.Size = new System.Drawing.Size(45, 23);
            this.txtSuffix.TabIndex = 48;
            this.txtSuffix.UseSelectable = true;
            this.txtSuffix.WaterMark = "Suffix";
            this.txtSuffix.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSuffix.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtSuffix.TextChanged += new System.EventHandler(this.txtFields_TextChanged);
            // 
            // txtMI
            // 
            // 
            // 
            // 
            this.txtMI.CustomButton.Image = null;
            this.txtMI.CustomButton.Location = new System.Drawing.Point(23, 1);
            this.txtMI.CustomButton.Name = "";
            this.txtMI.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtMI.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMI.CustomButton.TabIndex = 1;
            this.txtMI.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMI.CustomButton.UseSelectable = true;
            this.txtMI.CustomButton.Visible = false;
            this.txtMI.Lines = new string[0];
            this.txtMI.Location = new System.Drawing.Point(149, 113);
            this.txtMI.MaxLength = 32767;
            this.txtMI.Name = "txtMI";
            this.txtMI.PasswordChar = '\0';
            this.txtMI.PromptText = "M.I.";
            this.txtMI.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMI.SelectedText = "";
            this.txtMI.SelectionLength = 0;
            this.txtMI.SelectionStart = 0;
            this.txtMI.ShortcutsEnabled = true;
            this.txtMI.Size = new System.Drawing.Size(45, 23);
            this.txtMI.TabIndex = 46;
            this.txtMI.UseSelectable = true;
            this.txtMI.WaterMark = "M.I.";
            this.txtMI.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMI.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtMI.TextChanged += new System.EventHandler(this.txtFields_TextChanged);
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.CustomButton.Image = null;
            this.txtPassword.CustomButton.Location = new System.Drawing.Point(182, 1);
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = 1;
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = false;
            this.txtPassword.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(105, 201);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PromptText = "Password";
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(204, 23);
            this.txtPassword.TabIndex = 50;
            this.tooltip.SetToolTip(this.txtPassword, "Password must be at least 8 characters long");
            this.txtPassword.UseSelectable = true;
            this.txtPassword.WaterMark = "Password";
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.TextChanged += new System.EventHandler(this.txtFields_TextChanged);
            // 
            // txtUsername
            // 
            // 
            // 
            // 
            this.txtUsername.CustomButton.Image = null;
            this.txtUsername.CustomButton.Location = new System.Drawing.Point(182, 1);
            this.txtUsername.CustomButton.Name = "";
            this.txtUsername.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtUsername.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUsername.CustomButton.TabIndex = 1;
            this.txtUsername.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUsername.CustomButton.UseSelectable = true;
            this.txtUsername.CustomButton.Visible = false;
            this.txtUsername.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtUsername.Lines = new string[0];
            this.txtUsername.Location = new System.Drawing.Point(105, 172);
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.PromptText = "Username";
            this.txtUsername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsername.SelectedText = "";
            this.txtUsername.SelectionLength = 0;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.ShortcutsEnabled = true;
            this.txtUsername.Size = new System.Drawing.Size(204, 23);
            this.txtUsername.TabIndex = 49;
            this.tooltip.SetToolTip(this.txtUsername, "User name must be 4 charactetrs long");
            this.txtUsername.UseSelectable = true;
            this.txtUsername.WaterMark = "Username";
            this.txtUsername.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUsername.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtUsername.TextChanged += new System.EventHandler(this.txtFields_TextChanged);
            // 
            // txtFirstName
            // 
            // 
            // 
            // 
            this.txtFirstName.CustomButton.Image = null;
            this.txtFirstName.CustomButton.Location = new System.Drawing.Point(102, 1);
            this.txtFirstName.CustomButton.Name = "";
            this.txtFirstName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtFirstName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFirstName.CustomButton.TabIndex = 1;
            this.txtFirstName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFirstName.CustomButton.UseSelectable = true;
            this.txtFirstName.CustomButton.Visible = false;
            this.txtFirstName.Lines = new string[0];
            this.txtFirstName.Location = new System.Drawing.Point(19, 113);
            this.txtFirstName.MaxLength = 32767;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.PasswordChar = '\0';
            this.txtFirstName.PromptText = "First Name";
            this.txtFirstName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFirstName.SelectedText = "";
            this.txtFirstName.SelectionLength = 0;
            this.txtFirstName.SelectionStart = 0;
            this.txtFirstName.ShortcutsEnabled = true;
            this.txtFirstName.Size = new System.Drawing.Size(124, 23);
            this.txtFirstName.TabIndex = 45;
            this.txtFirstName.UseSelectable = true;
            this.txtFirstName.WaterMark = "First Name";
            this.txtFirstName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFirstName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFields_TextChanged);
            // 
            // employeeID_label
            // 
            this.employeeID_label.AutoSize = true;
            this.employeeID_label.Location = new System.Drawing.Point(15, 21);
            this.employeeID_label.Name = "employeeID_label";
            this.employeeID_label.Size = new System.Drawing.Size(28, 21);
            this.employeeID_label.TabIndex = 37;
            this.employeeID_label.Text = "00";
            this.employeeID_label.Visible = false;
            // 
            // resetPassword_button
            // 
            this.resetPassword_button.BackColor = System.Drawing.Color.IndianRed;
            this.resetPassword_button.FlatAppearance.BorderSize = 0;
            this.resetPassword_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.resetPassword_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetPassword_button.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetPassword_button.ForeColor = System.Drawing.Color.White;
            this.resetPassword_button.Location = new System.Drawing.Point(315, 201);
            this.resetPassword_button.Name = "resetPassword_button";
            this.resetPassword_button.Size = new System.Drawing.Size(57, 23);
            this.resetPassword_button.TabIndex = 26;
            this.resetPassword_button.TabStop = false;
            this.resetPassword_button.Text = "Reset";
            this.tooltip.SetToolTip(this.resetPassword_button, "Resets password of employee");
            this.resetPassword_button.UseVisualStyleBackColor = false;
            this.resetPassword_button.Visible = false;
            this.resetPassword_button.Click += new System.EventHandler(this.resetPassword_button_Click);
            // 
            // txtClear
            // 
            this.txtClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtClear.FlatAppearance.BorderSize = 0;
            this.txtClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.txtClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtClear.ForeColor = System.Drawing.Color.White;
            this.txtClear.Location = new System.Drawing.Point(105, 394);
            this.txtClear.Name = "txtClear";
            this.txtClear.Size = new System.Drawing.Size(204, 37);
            this.txtClear.TabIndex = 54;
            this.txtClear.Text = "Clear";
            this.txtClear.UseVisualStyleBackColor = false;
            this.txtClear.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // txtAdd
            // 
            this.txtAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAdd.Enabled = false;
            this.txtAdd.FlatAppearance.BorderSize = 0;
            this.txtAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.txtAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtAdd.ForeColor = System.Drawing.Color.White;
            this.txtAdd.Location = new System.Drawing.Point(105, 342);
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(204, 37);
            this.txtAdd.TabIndex = 53;
            this.txtAdd.Tag = "a";
            this.txtAdd.Text = "Add";
            this.txtAdd.UseVisualStyleBackColor = false;
            this.txtAdd.Click += new System.EventHandler(this.addButton_Click);
            // 
            // active_checkbox
            // 
            this.active_checkbox.AutoSize = true;
            this.active_checkbox.Checked = true;
            this.active_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.active_checkbox.Enabled = false;
            this.active_checkbox.Location = new System.Drawing.Point(175, 279);
            this.active_checkbox.Name = "active_checkbox";
            this.active_checkbox.Size = new System.Drawing.Size(71, 25);
            this.active_checkbox.TabIndex = 52;
            this.active_checkbox.Text = "Active";
            this.active_checkbox.UseVisualStyleBackColor = true;
            // 
            // EmployeeModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(943, 669);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.EmployeeDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmployeeModule";
            this.Text = "EmployeeModule";
            this.Load += new System.EventHandler(this.EmployeeModule_Load);
            this.VisibleChanged += new System.EventHandler(this.EmployeeModule_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDGV)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView EmployeeDGV;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.CheckBox active_checkbox;
        private System.Windows.Forms.Button txtClear;
        private System.Windows.Forms.Button txtAdd;
        private System.Windows.Forms.Button resetPassword_button;
        private System.Windows.Forms.Label employeeID_label;
        private System.Windows.Forms.ToolTip tooltip;
        private MetroFramework.Controls.MetroTextBox txtLastName;
        private MetroFramework.Controls.MetroTextBox txtSuffix;
        private MetroFramework.Controls.MetroTextBox txtMI;
        private MetroFramework.Controls.MetroTextBox txtUsername;
        private MetroFramework.Controls.MetroTextBox txtFirstName;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn userID;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn midName;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn suffix;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn privileges;
        private MetroFramework.Controls.MetroComboBox cmbEmployeeType;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}