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
        DataHandler dh = new DataHandler("localhost" ,"sad2","root","root");
        public SAD()
        {
            InitializeComponent();

        }
        #region menu
        private void menu_select(object sender, EventArgs e)
        {
            profile_panel.Hide();
            home_panel.Hide();

            Button button = sender as Button;
            if (button.Text == "Home") { home_panel.Show(); }
            else if (button.Text == "Profiles") { profile_panel.Show(); }

        }

        private void openProfile_button_Click(object sender, EventArgs e)
        {
            Form person = new Person(1,dh);
            person.ShowDialog();
        }
        #endregion

        #region profiles
        private void addProfile_button_Click(object sender, EventArgs e)
        {
            if (dh.addGeneralProfile(firstname_textbox.Text, middlename_textbox.Text, lastname_textbox.Text, suffix_textbox.Text, '0', DateTime.MinValue, null, null, null)) { }
            else { MessageBox.Show("Entry not added"); }
        }
        #endregion 
    }
}
