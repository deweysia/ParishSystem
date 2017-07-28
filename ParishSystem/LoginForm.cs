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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            usernameBox.BackColor = Color.Transparent;
            passwordBox.BackColor = Color.Transparent;
        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
