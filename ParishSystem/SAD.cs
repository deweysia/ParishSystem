using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
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
            home_panel.Show();

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

        private void profile_menu_button_Click(object sender, EventArgs e)
        {
            home_panel.Hide();
            profile_panel.Show();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #region Clearing of Textboxes

        private void firstname_textbox_MouseClick(object sender, MouseEventArgs e)
        {
            firstname_textbox.Text = "";
        }

      

        private void middlename_textbox_MouseClick(object sender, MouseEventArgs e)
        {
            middlename_textbox.Text = "";
        }

        private void lastname_textbox_MouseClick(object sender, MouseEventArgs e)
        {
            lastname_textbox.Text = "";
        }

        private void suffix_textbox_MouseClick(object sender, MouseEventArgs e)
        {
            suffix_textbox.Text = "";
        }
        #endregion

        private void SAD_Load(object sender, EventArgs e)
        {

        }

        #region Form Move Region
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
        #endregion

       
    }
}
