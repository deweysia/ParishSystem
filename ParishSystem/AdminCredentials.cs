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
    public partial class AdminCredentials : Form
    {
        Login login = new Login();
        public AdminCredentials()
        {
            InitializeComponent();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void check_button_Click(object sender, EventArgs e)
        {
            if (User.verify(username_textbox.Text,password_textbox.Text,true))
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            else
            {
                Notification.Show(State.WrongCredentials);
            }
        }
       

        private void AdminCredentials_Load(object sender, EventArgs e)
        {
            Draggable draggable = new Draggable(this);
            draggable.makeDraggable(controlBar_panel);
        }

        private void username_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                check_button.PerformClick();
            }
        }

        private void password_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                check_button.PerformClick();
            }
        }
    }

    public static class AdminCredentialDialog
    {
        public static DialogResult Show()
        {
            AdminCredentials ac = new AdminCredentials();
            return ac.ShowDialog();
          
        }
    }
}
