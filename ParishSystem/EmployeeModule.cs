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
        public EmployeeModule()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (add_button.Tag.ToString()=="a") {
                    login.AddUser(firstname_textbox.Text, middleinitial_textbox.Text, lastname_textbox.Text, suffix_textbox.Text, username_textbox.Text, password_textbox.Text, employeeType_combobox.SelectedIndex);
                    refresEmployees();
                    clearFields();
            }
            else
            {
               
                    if (password_textbox.Enabled)
                    {
                        login.editEmployeeResetPassword(firstname_textbox.Text, middleinitial_textbox.Text, lastname_textbox.Text, suffix_textbox.Text, username_textbox.Text, password_textbox.Text,active_checkbox.Checked, employeeType_combobox.SelectedIndex,int.Parse(employeeID_label.Text));
                    }
                    else
                    {
                        login.editEmployee(firstname_textbox.Text, middleinitial_textbox.Text, lastname_textbox.Text, suffix_textbox.Text, username_textbox.Text,active_checkbox.Checked, employeeType_combobox.SelectedIndex, int.Parse(employeeID_label.Text));
                    }
                    add_button.Tag = "a";
                    add_button.Text = "Add";
                    refresEmployees();
                    clearFields();
            }
            }
            catch
            {
                Notification.Show(State.DuplicateUsername);
                
            }
        }
        private void clearFields()
        {
            employeeID_label.Text = "";
            firstname_textbox.Clear();
            middleinitial_textbox.Clear();
            lastname_textbox.Clear();
            suffix_textbox.Clear();
            username_textbox.Clear();
            password_textbox.Clear();
            active_checkbox.Checked = true;
            active_checkbox.Enabled = false;
            resetPassword_button.Visible = false;
            password_textbox.Enabled = true;
            employeeType_combobox.SelectedIndex = 0;
           

        }
        private void clear_button_Click(object sender, EventArgs e)
        {
            clearFields();
            add_button.Tag = "a";
            add_button.Text = "Add";
        }
        public void refresEmployees()
        {
            EmployeeDGV.DataSource= login.getEmployees();
            EmployeeDGV.Columns["name"].HeaderText = "Name";
            EmployeeDGV.Columns["WStatus"].HeaderText = "Status";
            EmployeeDGV.Columns["employeeid"].Visible = false;
            EmployeeDGV.Columns["firstname"].Visible = false;
            EmployeeDGV.Columns["midname"].Visible = false;
            EmployeeDGV.Columns["lastname"].Visible = false;
            EmployeeDGV.Columns["suffix"].Visible = false;
            EmployeeDGV.Columns["username"].Visible = false;
            EmployeeDGV.Columns["pass"].Visible = false;
            EmployeeDGV.Columns["status"].Visible = false;
            EmployeeDGV.Columns["addedBy"].Visible = false;
            EmployeeDGV.Columns["privileges"].Visible = false;
        }

        private void EmployeeModule_Load(object sender, EventArgs e)
        {
            refresEmployees();
        }

        private void EmployeeDGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            add_button.Text = "Edit";
            add_button.Tag = "e";
            employeeID_label.Text = EmployeeDGV.SelectedRows[0].Cells["employeeid"].Value.ToString();
            firstname_textbox.Text = EmployeeDGV.SelectedRows[0].Cells["firstname"].Value.ToString();
            middleinitial_textbox.Text = EmployeeDGV.SelectedRows[0].Cells["midname"].Value.ToString();
            lastname_textbox.Text = EmployeeDGV.SelectedRows[0].Cells["lastname"].Value.ToString();
            suffix_textbox.Text = EmployeeDGV.SelectedRows[0].Cells["suffix"].Value.ToString();
            username_textbox.Text = EmployeeDGV.SelectedRows[0].Cells["username"].Value.ToString();
            active_checkbox.Checked = (EmployeeDGV.SelectedRows[0].Cells["status"].Value.ToString() == "1");
            password_textbox.Text = "********";
            employeeType_combobox.SelectedIndex = int.Parse(EmployeeDGV.SelectedRows[0].Cells["privileges"].Value.ToString());
            password_textbox.Enabled = false;
            resetPassword_button.Visible = true;
            active_checkbox.Enabled = true;
        }

        private void resetPassword_button_Click(object sender, EventArgs e)
        {
            password_textbox.Clear();
            password_textbox.Enabled = true;
            addButtonValidation();

        }

        private void lastname_textbox_TextChanged(object sender, EventArgs e)
        {
            addButtonValidation();
        }

        private void suffix_textbox_TextChanged(object sender, EventArgs e)
        {
            addButtonValidation();
        }

        private void firstname_textbox_TextChanged(object sender, EventArgs e)
        {
            addButtonValidation();
        }

        private void middleinitial_textbox_TextChanged(object sender, EventArgs e)
        {
            addButtonValidation();
        }

        private void username_textbox_TextChanged(object sender, EventArgs e)
        {
            addButtonValidation();
        }

        private void password_textbox_TextChanged(object sender, EventArgs e)
        {
            addButtonValidation();
        }
        private void employeeType_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addButtonValidation();
        }
        private void addButtonValidation()
        {
            if(lastname_textbox.Text!="" && firstname_textbox.Text != "" && middleinitial_textbox.Text != "" && employeeType_combobox.SelectedIndex!=0)
            {
                if (password_textbox.Enabled==true)
                {
                    if(password_textbox.Text.Length >= 8 && username_textbox.Text!="")
                    {
                        add_button.Enabled = true;
                    }
                    else
                    {
                        add_button.Enabled = false;
                    }
                }
                else
                {
                    add_button.Enabled = true;
                }
               
            }
            else
            {
                add_button.Enabled = false;
            }
        }

        private void lastname_textbox_Click(object sender, EventArgs e)
        {

        }

        
    }
}
