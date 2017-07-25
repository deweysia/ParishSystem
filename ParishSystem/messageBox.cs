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
    public partial class messageBox : Form
    {
        public messageBox(String a, String b)
        {
            InitializeComponent();
            status = a;
            message = b;
        }
        private String status = "";
        private String message = "";

        private void messageBox_Load(object sender, EventArgs e)
        {
            if(status == "s")
            {
                iconDisplay.Image = ParishSystem.Properties.Resources.messageBox_success;
                no_button.Visible = false;
                yes_button.Text = "Ok"
            }
            else if(status == "e")
            {
                iconDisplay.Image = ParishSystem.Properties.Resources.messageBox_error;
                no_button.Visible = true;
                yes_button.Visible = true;

            }
            else if (status == "w")
            {
                iconDisplay.Image = ParishSystem.Properties.Resources.messageBox_warning;
                no_button.Visible = false;
                yes_button.Text = "Ok"
            }

            messageText.Text = message;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void no_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
