using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParishSystem
{
    public partial class EmployeeModule : Form
    {
        DataHandler login = DataHandler.getDataHandler();
        User user = User.getCurrentUser();
        public EmployeeModule()
        {
            InitializeComponent();
            EmployeeDGV.AutoGenerateColumns = false;

            cmbEmployeeType.Items.Add("");

            //cmbEmployeeType.DataSource = Enum.GetValues(typeof(UserPrivileges));
            //cmbEmployeeType.DataSource = cmbEmployeeType.DataSource;

            cmbEmployeeType.Items.Add(UserPrivileges.Supervisor);
            cmbEmployeeType.Items.Add(UserPrivileges.Treasurer);
            cmbEmployeeType.Items.Add(UserPrivileges.Secretary);

            if(this.user.userPrivilegeLevel == UserPrivileges.Admin)
                cmbEmployeeType.Items.Add(UserPrivileges.Admin);

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            bool success = false;
            bool isDisablingOwnAcc = false;
            try
            {
                UserPrivileges privilege = (UserPrivileges)cmbEmployeeType.SelectedIndex;
                if (txtAdd.Tag.ToString()=="a") {
                    success = login.AddUser(txtFirstName.Text, txtMI.Text, txtLastName.Text, txtSuffix.Text, txtUsername.Text, txtPassword.Text, privilege);
                    refresEmployees();
                    clearFields();
                }
                else
                {
                    UserStatus status = active_checkbox.Checked ? UserStatus.Active : UserStatus.Inactive;
                    int _userID = Convert.ToInt32(employeeID_label.Text);
                    
                    if (user.userID == _userID && status == UserStatus.Inactive)
                    {
                        DialogResult dr = MessageDialog.Show("Disabling your account will cause you to log out. Proceed?", MessageDialogButtons.YesNo, MessageDialogIcon.Warning);

                        isDisablingOwnAcc = dr == DialogResult.Yes;
                    }

                    if (txtPassword.Enabled)
                    {
                        success = login.editUserResetPassword(txtFirstName.Text, txtMI.Text, txtLastName.Text, txtSuffix.Text, txtUsername.Text, txtPassword.Text, status, privilege, int.Parse(employeeID_label.Text));
                    }
                    else
                    {
                        
                        success = login.editEmployee(txtFirstName.Text, txtMI.Text, txtLastName.Text, txtSuffix.Text, txtUsername.Text, status, privilege, int.Parse(employeeID_label.Text));
                    }
                    txtAdd.Tag = "a";
                    txtAdd.Text = "Add";
                    refresEmployees();
                    clearFields();
                }
            }
            catch
            {
                Notification.Show(State.DuplicateUsername);
                
            }

            if (success)
                Notification.Show(State.UserUpdateSuccess);
            else
                Notification.Show(State.UserUpdateFail);

            if (isDisablingOwnAcc)
            {
                this.Owner.Close();
            }

        }

        private void clearFields()
        {
            employeeID_label.Text = "";
            txtFirstName.Clear();
            txtMI.Clear();
            txtLastName.Clear();
            txtSuffix.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            active_checkbox.Checked = true;
            active_checkbox.Enabled = false;
            resetPassword_button.Visible = false;
            txtPassword.Enabled = true;
            cmbEmployeeType.SelectedIndex = 0;
           

        }
        private void clear_button_Click(object sender, EventArgs e)
        {
            clearFields();
            txtAdd.Tag = "a";
            txtAdd.Text = "Add";
        }
        public void refresEmployees()
        {
            EmployeeDGV.AutoGenerateColumns = false;
            if (user.userPrivilegeLevel == UserPrivileges.Admin)
                EmployeeDGV.DataSource = login.getEmployees();
            else
                EmployeeDGV.DataSource = login.getEmployeesNoSuperUser();

            //EmployeeDGV.Columns["name"].HeaderText = "Name";
            //EmployeeDGV.Columns["WStatus"].HeaderText = "Status";
            //EmployeeDGV.Columns["userID"].Visible = false;
            //EmployeeDGV.Columns["firstname"].Visible = false;
            //EmployeeDGV.Columns["midname"].Visible = false;
            //EmployeeDGV.Columns["lastname"].Visible = false;
            //EmployeeDGV.Columns["suffix"].Visible = false;
            //EmployeeDGV.Columns["username"].Visible = false;
            //EmployeeDGV.Columns["pass"].Visible = false;
            //EmployeeDGV.Columns["status"].Visible = false;
            //EmployeeDGV.Columns["addedBy"].Visible = false;
            //EmployeeDGV.Columns["privileges"].Visible = false;
        }

        private void EmployeeModule_Load(object sender, EventArgs e)
        {
            refresEmployees();
        }

        private void EmployeeDGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAdd.Text = "Edit";
            txtAdd.Tag = "e";
            employeeID_label.Text = EmployeeDGV.SelectedRows[0].Cells["userID"].Value.ToString();
            txtFirstName.Text = EmployeeDGV.SelectedRows[0].Cells["firstname"].Value.ToString();
            txtMI.Text = EmployeeDGV.SelectedRows[0].Cells["midname"].Value.ToString();
            txtLastName.Text = EmployeeDGV.SelectedRows[0].Cells["lastname"].Value.ToString();
            txtSuffix.Text = EmployeeDGV.SelectedRows[0].Cells["suffix"].Value.ToString();
            txtUsername.Text = EmployeeDGV.SelectedRows[0].Cells["username"].Value.ToString();
            active_checkbox.Checked = (EmployeeDGV.SelectedRows[0].Cells["status"].Value.ToString() == "1");
            txtPassword.Text = "********";
            cmbEmployeeType.SelectedIndex = int.Parse(EmployeeDGV.SelectedRows[0].Cells["privileges"].Value.ToString());
            txtPassword.Enabled = false;
            resetPassword_button.Visible = true;
            active_checkbox.Enabled = true;
        }

        private void resetPassword_button_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtPassword.Enabled = true;
            addButtonValidation();

        }

        
        private void employeeType_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void addButtonValidation()
        {
            string firstName = txtFirstName.Text.Trim();
            string midName = txtMI.Text.Trim();
            string suffix = txtSuffix.Text.Trim();
            string lastName = txtLastName.Text.Trim();
           
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            bool namesFilled = firstName.Length != 0 && midName.Length != 0 && lastName.Length != 0;

            txtAdd.Enabled = namesFilled && cmbEmployeeType.SelectedIndex != 0 && username.Length >= 4 && password.Length >= 8;
        }

        private void lastname_textbox_Click(object sender, EventArgs e)
        {

        }

        private void txtFields_TextChanged(object sender, EventArgs e)
        {
            addButtonValidation();
        }

        private void EmployeeDGV_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void cmbEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            addButtonValidation();
        }

        private void EmployeeDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if(e.ColumnIndex == 7)
            {
                e.Value = ((UserStatus)Convert.ToInt32(e.Value)).ToString();
            }
            else if(e.ColumnIndex == 8)
            {
                e.Value = ((UserPrivileges)Convert.ToInt32(e.Value)).ToString();
            }
        }

        private void EmployeeModule_VisibleChanged(object sender, EventArgs e)
        {
           
        }
    }
}
