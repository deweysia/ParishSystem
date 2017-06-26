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
    public partial class Person : Form
    {
        public Person()
        {
            InitializeComponent();
        }

        private void panel_change(object sender, EventArgs e)
        {
            basic_panel.Hide();
            baptism_panel.Hide();
            confirmation_panel.Hide();
            marriage_panel.Hide();
            balance_panel.Hide();
            bloodletting_panel.Hide();

            Button button = sender as Button;
            if (button.Text == "Biodata") { basic_panel.Show(); }
            else if (button.Text == "Baptism") { baptism_panel.Show(); }
            else if (button.Text == "Confirmation") { confirmation_panel.Show(); }
            else if (button.Text == "Marriage") { marriage_panel.Show(); }
            else if (button.Text == "Balance") { balance_panel.Show(); }
            else if (button.Text == "Bloodletting") { bloodletting_panel.Show(); }

        }

        private void label101_Click(object sender, EventArgs e)
        {

        }
    }
}
