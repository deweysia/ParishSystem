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
        private List<Panel> panelList = new List<Panel>();
        private Dictionary<string, Panel> panelDict = new Dictionary<string, Panel>();

        public Person(int ProfileID, DataHandler dh)
        {
            InitializeComponent();
            this.ProfileID = ProfileID;
            this.dh = dh;

            panelDict.Add("baptism_panel", baptism_panel);
            panelDict.Add("confirmation_panel", confirmation_panel);
            panelDict.Add("profile_panel", profile_panel);
            panelDict.Add("bloodletting_panel", bloodletting_panel);
            panelDict.Add("marriage_panel", marriage_panel);
            panelDict.Add("balance_panel", balance_panel);

        }

        
        #region GUI basic


        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Saves
        private void saveGeneralProfile(object sender, EventArgs e)
        {
            char gender = 'z';
            if (gender_Male_radiobutton_profile.Checked == true) { gender = 'm'; }
            else if (gender_female_radiobutton_profile.Checked == true) { gender = 'f'; }
            dh.editGeneralProfile(
                ProfileID,
                firstname_textbox_profile.Text,
                middlename_textbox_profile.Text,
                lastname_textbox_profile.Text,
                suffix_textbox_profile.Text,
                gender,
                birthdate_datetimepicker_profile.Value,
                contactNumber_textbox_profile.Text,
                address_textarea_profile.Text,
                birthplace_textbox_profile.Text,
                bloodtype_combobox_profile.Text
                );


            if (father_checkbox_profile.Checked == true)
            {
                try
                {

                    int fatherID = int.Parse(dh.getFatherOf(ProfileID).Rows[0]["parentID"].ToString());
                    dh.editParent(fatherID, firstname_textbox_father_profile.Text, middlename_textbox_father_profile.Text, lastname_textbox_father_profile.Text, suffix_textbox_father_profile.Text, 'm', birthplace_textbox_father_profile.Text);
                }
                catch
                {
                    dh.conn.Close();
                    dh.addParent(ProfileID, firstname_textbox_father_profile.Text, middlename_textbox_father_profile.Text, lastname_textbox_father_profile.Text, suffix_textbox_father_profile.Text, 'm', birthplace_textbox_father_profile.Text);
                }
            }

            if (mother_checkbox_profile.Checked == true)
            {
                try
                {
                    int motherID = int.Parse(dh.getMotherOf(ProfileID).Rows[0]["parentID"].ToString());
                    dh.editParent(motherID, firstname_textbox_father_profile.Text, middlename_textbox_father_profile.Text, lastname_textbox_father_profile.Text, suffix_textbox_father_profile.Text, 'f', birthplace_textbox_father_profile.Text);
                }
                catch
                {
                    dh.conn.Close();
                    dh.addParent(ProfileID, firstname_textbox_father_profile.Text, middlename_textbox_father_profile.Text, lastname_textbox_father_profile.Text, suffix_textbox_father_profile.Text, 'f', birthplace_textbox_father_profile.Text);
                }
            }
        }

        #endregion

        #region Loads
        private void load_Biodata()
        {

            DataTable TempDT = dh.getGeneralProfile(ProfileID);
            
            //LOAD PERSON
            if (!(TempDT.Rows[0]["gender"] == null))
            {
                if (TempDT.Rows[0]["gender"].ToString() == "m")
                    gender_Male_radiobutton_profile.Checked = true;
                else if (TempDT.Rows[0]["gender"].ToString() == "f")
                    gender_female_radiobutton_profile.Checked = true;
            }
            firstname_textbox_profile.Text = TempDT.Rows[0]["firstname"].ToString();
            middlename_textbox_profile.Text = TempDT.Rows[0]["midname"].ToString();
            lastname_textbox_profile.Text = TempDT.Rows[0]["lastname"].ToString();
            suffix_textbox_profile.Text = TempDT.Rows[0]["suffix"].ToString();
            birthplace_textbox_profile.Text = TempDT.Rows[0]["birthplace"].ToString();
            address_textarea_profile.Text = TempDT.Rows[0]["address"].ToString();
            contactNumber_textbox_profile.Text = TempDT.Rows[0]["contactNumber"].ToString();
            bloodtype_combobox_profile.SelectedItem = TempDT.Rows[0]["bloodType"].ToString();
            try
            {
                birthdate_datetimepicker_profile.Format = DateTimePickerFormat.Short;
                birthdate_datetimepicker_profile.Value = dh.toDateTime(TempDT.Rows[0]["birthdate"].ToString(), false);
            }
            catch
            {
                birthdate_datetimepicker_profile.Format = DateTimePickerFormat.Custom;
            }
            //Console.WriteLine(TempDT.Rows[0]["birthdate"].ToString());


            //LOAD FATHER
            if (dh.getFatherOf(ProfileID).Rows.Count != 0)
            {
                DataTable TempFatherDT = dh.getFatherOf(ProfileID);
                firstname_textbox_father_profile.Text = TempFatherDT.Rows[0]["firstname"].ToString();
                middlename_textbox_father_profile.Text = TempFatherDT.Rows[0]["midname"].ToString();
                lastname_textbox_father_profile.Text = TempFatherDT.Rows[0]["lastname"].ToString();
                suffix_textbox_father_profile.Text = TempFatherDT.Rows[0]["suffix"].ToString();
                birthplace_textbox_father_profile.Text = TempFatherDT.Rows[0]["birthplace"].ToString();
                residence_textbox_father_profile.Text = TempFatherDT.Rows[0]["residence"].ToString();
                father_checkbox_profile.Checked = true;
                father_checkbox_profile.Enabled = false;

            }

            //LOAD MOTHER
            if (dh.getFatherOf(ProfileID).Rows.Count != 0)
            {
                DataTable TempMotherDT = dh.getMotherOf(ProfileID);
                firstname_textbox_mother_profile.Text = TempMotherDT.Rows[0]["firstname"].ToString();
                middlename_textbox_mother_profile.Text = TempMotherDT.Rows[0]["midname"].ToString();
                lastname_textbox_mother_profile.Text = TempMotherDT.Rows[0]["lastname"].ToString();
                suffix_textbox_mother_profile.Text = TempMotherDT.Rows[0]["suffix"].ToString();
                birthplace_textbox_mother_profile.Text = TempMotherDT.Rows[0]["birthplace"].ToString();
                residence_textbox_mother_profile.Text = TempMotherDT.Rows[0]["residence"].ToString();
                mother_checkbox_profile.Checked = true;
                mother_checkbox_profile.Enabled = false;

            }
        }




        public void load_Baptism()
        {

            DataTable dt = dh.getBaptismOf(ProfileID);

            int ministerID = int.Parse(dt.Rows[0]["ministerID"].ToString());
            int applicationID = int.Parse(dt.Rows[0]["applicationID"].ToString());
            int baptismID = int.Parse(dt.Rows[0]["baptismID"].ToString());

            registry_textbox_baptism.Text = dt.Rows[0]["registryNumber"].ToString();
            page_textbox_baptism.Text = dt.Rows[0]["pageNumber"].ToString();
            record_textbox_baptism.Text = dt.Rows[0]["recordNumber"].ToString();
            Console.WriteLine("Date: " + dt.Rows[0]["baptismID"].ToString());
            date_datetimepicker_baptism.Value = dh.toDateTime(dt.Rows[0]["baptismDate"].ToString(), false);
            remarks_textbox_baptism.Text = dt.Rows[0]["remarks"].ToString();

            //MessageBox.Show("loading");
            dt = dh.getMinister(ministerID);

            minister_combobox_baptism.Text = dt.Rows[0]["lastName"].ToString() + ", "
                + dt.Rows[0]["firstName"].ToString() + " " + dt.Rows[0]["midName"].ToString()
                + " " + dt.Rows[0]["suffix"].ToString();

            dt = dh.getSponsors(baptismID, "B");

            firstname_textbox_sponsor_baptism.Text = dt.Rows[0]["firstName"].ToString();
            middlename_textbox_sponsor_baptism.Text = dt.Rows[0]["midName"].ToString();
            lastname_textbox_sponsor_baptism.Text = dt.Rows[0]["lastName"].ToString();
            suffix_textbox_sponsor_baptism.Text = dt.Rows[0]["suffix"].ToString();
            residence_textbox_sponsor_baptism.Text = dt.Rows[0]["residence"].ToString();


            string gender = dt.Rows[0]["gender"].ToString();

            gender_male_radiobutton_sponsor_baptism.Checked = gender == "M";
            gender_female_radiobutton_sponsor_baptism.Checked = gender == "F";


        }


        public void load_Confirmation()
        {
            DataTable dt = dh.getConfirmationOf(ProfileID);

            int ministerID = int.Parse(dt.Rows[0]["ministerID"].ToString());
            int applicationID = int.Parse(dt.Rows[0]["applicationID"].ToString());
            int confirmationID = int.Parse(dt.Rows[0]["confirmationID"].ToString());

            registryNumber_textbox_confirmation.Text = dt.Rows[0]["registryNumber"].ToString();
            pageNumber_textbox_confirmation.Text = dt.Rows[0]["pageNumber"].ToString();
            recordNumber_textbox_confirmation.Text = dt.Rows[0]["recordNumber"].ToString();
            Console.WriteLine("Date: " + dt.Rows[0]["confirmationDate"].ToString());
            date_datetimepicker_baptism.Value = dh.toDateTime(dt.Rows[0]["confirmationDate"].ToString(), false);
            remarks_textbox_confirmation.Text = dt.Rows[0]["remarks"].ToString();

            MessageBox.Show("loading");
            dt = dh.getMinister(ministerID);

            minister_combobox_confirmation.Text = dt.Rows[0]["lastName"].ToString() + ", "
                + dt.Rows[0]["firstName"].ToString() + " " + dt.Rows[0]["midName"].ToString()
                + " " + dt.Rows[0]["suffix"].ToString();

            dt = dh.getSponsors(confirmationID, "C");

            firstname_textbox_sponsor_confirmation.Text = dt.Rows[0]["firstName"].ToString();
            middlename_textbox_sponsor_confirmation.Text = dt.Rows[0]["midName"].ToString();
            lastname_textbox_sponsor_confirmation.Text = dt.Rows[0]["lastName"].ToString();
            suffix_textbox_sponsor_confirmation.Text = dt.Rows[0]["suffix"].ToString();
            residence_textbox_sponsor_confirmation_textbox.Text = dt.Rows[0]["residence"].ToString();


            string gender = dt.Rows[0]["gender"].ToString();

            gender_male_radiobutton_confirmation.Checked = gender == "M";
            gender_female_radiobutton_confirmation.Checked = gender == "F";
        }

        public void load_Marriage()
        {

        }


        #endregion

        #region DGV clicks
        int sponsorBaptismLastClick;

        private void baptism_sponsor_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sponsorBaptismLastClick = int.Parse(sponsor_datagridview_baptism.CurrentRow.Cells["sponsorID"].Value.ToString());
            firstname_textbox_sponsor_baptism.Text = sponsor_datagridview_baptism.CurrentRow.Cells["firstName"].Value.ToString();
            middlename_textbox_sponsor_baptism.Text = sponsor_datagridview_baptism.CurrentRow.Cells["middleName"].Value.ToString();
            lastname_textbox_sponsor_baptism.Text = sponsor_datagridview_baptism.CurrentRow.Cells["lastName"].Value.ToString();
            suffix_textbox_sponsor_baptism.Text = sponsor_datagridview_baptism.CurrentRow.Cells["suffix"].Value.ToString();
            residence_textbox_sponsor_baptism.Text = sponsor_datagridview_baptism.CurrentRow.Cells["residence"].Value.ToString();

            if (sponsor_datagridview_baptism.CurrentRow.Cells["gender"].Value != null)
            {
                if (sponsor_datagridview_baptism.CurrentRow.Cells["gender"].Value.ToString().Equals("m"))
                {
                    gender_male_radiobutton_sponsor_baptism.Checked = true;
                }
                else if (sponsor_datagridview_baptism.CurrentRow.Cells["gender"].Value.ToString().Equals("f"))
                {
                    gender_female_radiobutton_sponsor_baptism.Checked = false;
                }
            }
        }
        #endregion

        #region Menu_Clicks


        private void biodata_button_Click(object sender, EventArgs e)
        {
            load_Biodata();

            panelDict["profile_panel"].BringToFront();

            //profile_panel.Visible = true;
            //baptism_panel.Visible = false;
            //confirmation_panel.Visible = false;
            //marriage_panel.Visible = false;
            //balance_panel.Visible = false;
            //bloodletting_panel.Visible = false;

        }

        private void baptism_button_Click(object sender, EventArgs e)
        {
            if (dh.hasBaptismApplication(ProfileID))
            {

                load_Baptism();
                panelDict["baptism_panel"].BringToFront();
                //profile_panel.Visible = false;
                //baptism_panel.Visible = true;
                //confirmation_panel.Visible = false;
                //marriage_panel.Visible = false;
                //balance_panel.Visible = false;
                //bloodletting_panel.Visible = false;
            }
            else
            {
                //dh.addApplication(ProfileID, "B");
            }

        }

        private void confirmation_button_Click(object sender, EventArgs e)
        {
            if (dh.hasConfirmationApplication(ProfileID))
            {
                load_Confirmation();
                panelDict["confirmation_panel"].BringToFront();
                //profile_panel.Visible = false;
                //baptism_panel.Visible = false;
                //confirmation_panel.Visible = true;
                //marriage_panel.Visible = false;
                //balance_panel.Visible = false;
                //bloodletting_panel.Visible = false;
            }
            else
            {
                dh.addApplication(ProfileID, "C");
            }
        }

        private void marriage_button_Click(object sender, EventArgs e)
        {
            if (dh.hasMarriageApplication(ProfileID))
            {
                load_Marriage();
                panelDict["marriage_panel"].BringToFront();
                //profile_panel.Visible = false;
                //baptism_panel.Visible = false;
                //confirmation_panel.Visible = false;
                //marriage_panel.Visible = true;
                //balance_panel.Visible = false;
                //bloodletting_panel.Visible = false;
            }
            else
            {
                dh.addApplication(ProfileID, "M");
            }
        }


        #endregion


        private void Person_Load(object sender, EventArgs e)
        {
            // if (dh.hasBaptismApplication(ProfileID)) { baptism_button.BackColor = Color.Green; } else { baptism_button.BackColor = Color.Red; }
            //if (dh.hasMarriageApplication(ProfileID)) { marriage_button.BackColor = Color.Green; } else { marriage_button.BackColor = Color.Red; }
            //if (dh.hasConfirmationApplication(ProfileID)) { confirmation_button.BackColor = Color.Green; } else { confirmation_button.BackColor = Color.Red; }

        }

        private void birthdate_datetimepicker_baptist_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = sender as DateTimePicker;
            try
            {
                birthdate_datetimepicker_profile.Format = DateTimePickerFormat.Short;
            }
            catch
            {
                birthdate_datetimepicker_profile.Format = DateTimePickerFormat.Custom;
            }
        }

        private void add_button_sponsor_baptism_Click(object sender, EventArgs e)
        {
            if (add_button_sponsor_baptism.Text.Equals("Add"))
            {
                int baptismID = dh.getBaptismID(ProfileID);
                char gender = '0';
                if (gender_male_radiobutton_sponsor_baptism.Checked)
                {
                    gender = 'm';
                }
                else if (gender_female_radiobutton_sponsor_baptism.Checked)
                {
                    gender = 'f';
                }
                dh.addSponsor(firstname_textbox_sponsor_baptism.Text, middlename_textbox_sponsor_baptism.Text, lastname_textbox_sponsor_baptism.Text, suffix_textbox_sponsor_baptism.Text, "B", residence_textbox_sponsor_baptism.Text, gender);
            }
            else
            {
                int baptismID = dh.getBaptismID(ProfileID);
                char gender = '0';
                if (gender_male_radiobutton_sponsor_baptism.Checked)
                {
                    gender = 'm';
                }
                else if (gender_female_radiobutton_sponsor_baptism.Checked)
                {
                    gender = 'f';
                }
                dh.editSponsor(sponsorBaptismLastClick, firstname_textbox_sponsor_baptism.Text, middlename_textbox_sponsor_baptism.Text, lastname_textbox_sponsor_baptism.Text, suffix_textbox_sponsor_baptism.Text, "bap", residence_textbox_sponsor_baptism.Text, gender);
            }

        }

        private void registry_baptism_textbox_TextChanged(object sender, EventArgs e)
        {
            // dh.addBaptism(int.Parse(dh.getApplications(ProfileID, "B").Rows[0]["applicationID"].ToString()), minister_baptism_combobox.SelectedIndex,dh.toDateTime(baptism_date_dtp.Value.ToString(),false));
        }

        private void delete_button_sponsor_baptism_Click(object sender, EventArgs e)
        {

        }

        #region MENU COLOR
        Color BackColorOnClick = Color.FromArgb(255, 255, 255);
        Color ForeColorOnClick = Color.FromArgb(21, 40, 54);

        private void approve_baptism_button_Click(object sender, EventArgs e)
        {
            baptism_details_panel.Enabled = true;
        }


        private void menu_button_Enter(object sender, EventArgs e)
        {
            Button a = sender as Button;
            a.Font = new Font(biodata_button.Font, FontStyle.Bold);
            a.ForeColor = ForeColorOnClick;
            a.BackColor = BackColorOnClick;
        }

        private void menu_button_Leave(object sender, EventArgs e)
        {
            Button a = sender as Button;
            a.Font = new Font(biodata_button.Font, FontStyle.Regular);
            a.ForeColor = BackColorOnClick;
            a.BackColor = ForeColorOnClick;
        }
        #endregion
        #region CONFIRMATION MENU
        Color submenu_front = Color.FromArgb(255, 255, 255);
        Color submenu_back = Color.FromArgb(39, 74, 99);
        private void confirmation_menu_button_Click(object sender, EventArgs e)
        {
            Button a = sender as Button;
            a.BackColor = submenu_back;
            a.ForeColor = submenu_front;
            if (a.Name.Equals("confirmation_application_button"))
            {
                confirmation_details_panel.Visible = false;
                confirmation_application_panel.Visible = true;
            }
            else if (a.Name.Equals("confirmation_details_button"))
            {
                confirmation_details_panel.Visible = true;
                confirmation_application_panel.Visible = false;
            }

        }
        private void confirmation_menu_button_Leave(object sender, EventArgs e)
        {
            Button a = sender as Button;
            a.BackColor = submenu_front;
            a.ForeColor = submenu_back;
        }
        #endregion


        private void balance_button_Click(object sender, EventArgs e)
        {
            profile_panel.Visible = false;
            baptism_panel.Visible = false;
            confirmation_panel.Visible = false;
            marriage_panel.Visible = false;
            balance_panel.Visible = true;
            bloodletting_panel.Visible = false;
        }

        private void bloodletting_button_Click(object sender, EventArgs e)
        {
            profile_panel.Visible = false;
            baptism_panel.Visible = false;
            confirmation_panel.Visible = false;
            marriage_panel.Visible = false;
            balance_panel.Visible = false;
            bloodletting_panel.Visible = true;
        }

        private void baptism_menu_button_Click(object sender, EventArgs e)
        {
            Button a = sender as Button;
            if (a.Name.Equals("application_baptism_button"))
            {
                baptism_details_panel.Visible = false;
                baptism_application_panel.Visible = true;
            }
            else if (a.Name.Equals("details_baptism_button"))
            {
                baptism_details_panel.Visible = true;
                baptism_application_panel.Visible = false;
            }

            a.BackColor = submenu_back;
            a.ForeColor = submenu_front;
        }

        private void baptism_menu_button_Leave(object sender, EventArgs e)
        {
            Button a = sender as Button;
            a.BackColor = submenu_front;
            a.ForeColor = submenu_back;
        }

        private void sponsor_panel_confirmation_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label65_Click(object sender, EventArgs e)
        {

        }

        private void date_textbox_baptism_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
