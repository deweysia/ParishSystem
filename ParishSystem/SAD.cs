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
    public partial class SAD : Form
    {
        public SAD()
        {
            InitializeComponent();
        }

        private void home_menu_button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;


            if (button.Text == "Home") { }
            else if (button.Text == "Application") { }
            else if (button.Text == "Bloodlettig") { }
        }
    }
}
