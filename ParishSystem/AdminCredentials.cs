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
            if (true)
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
