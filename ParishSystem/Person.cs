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
        public int ProfileID;
        public DataHandler dh;
        public Person(int ProfileID,DataHandler dh)
        {
            InitializeComponent();
            this.ProfileID = ProfileID;
            this.dh = dh;
           
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

        private void save() {
            
        }
        private void saveGeneralProfile() {
            char gender='z';
            if (gender_radiobutton1_baptist.Checked == true) { gender = 'm'; }
            else if (gender_radiobutton2_baptist.Checked == true) { gender = 'f'; }
            dh.editGeneralProfile(
                ProfileID,
                firstname_textbox_baptist.Text,
                middlename_textbox_baptist.Text,
                lastname_textbox_baptist.Text,
                suffix_textbox_baptist.Text,
                gender,
                birthdate_datetimepicker_baptist.Value,
                contactNumber_textbox_baptist.Text,
                address_baptist_textarea.Text,
                birthplace_textbox_baptist.Text,
                bloodtype_combobox_baptist.SelectedValue.ToString());
        }



        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_button_Click(object sender, EventArgs e)
        {

        }
    }
}
