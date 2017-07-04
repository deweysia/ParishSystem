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
			if (gender_radiobutton1_baptist.Checked == true) { gender = 'm'; }
			else if (gender_radiobutton2_baptist.Checked == true) { gender = 'f'; }
			dh.editGeneralProfile(
				ProfileID,
				firstname_textbox.Text,
				middlename_textbox.Text,
				lastname_textbox.Text,
				suffix_textbox.Text,
				gender,
				birthdate_datetimepicker_baptist.Value,
				contactNumber_textbox_baptist.Text,
				address_baptist_textarea.Text,
				birthplace_textbox_baptist.Text,
				bloodtype_combobox_baptist.SelectedValue.ToString());
		}
        #endregion

        #region Loads
        private void load_Biodata()
        {

            DataTable TempDT = dh.getGeneralProfile(ProfileID);
            //LOAD PERSON
            if (!(TempDT.Rows[0]["gender"].Equals(null)))
            {
                if (TempDT.Rows[0]["gender"].ToString() == "m")
                    gender_radiobutton1_baptist.Checked = true;
                else if (TempDT.Rows[0]["gender"].ToString() == "f")
                    gender_radiobutton2_baptist.Checked = true;
            }
            firstname_textbox.Text = TempDT.Rows[0]["firstname"].ToString();
            middlename_textbox.Text = TempDT.Rows[0]["midname"].ToString();
            lastname_textbox.Text = TempDT.Rows[0]["lastname"].ToString();
            suffix_textbox.Text = TempDT.Rows[0]["suffix"].ToString();
            birthplace_textbox_baptist.Text = TempDT.Rows[0]["birthplace"].ToString();
            address_baptist_textarea.Text = TempDT.Rows[0]["address"].ToString();
            contactNumber_textbox_baptist.Text = TempDT.Rows[0]["contactNumber"].ToString();
            bloodtype_combobox_baptist.SelectedItem = TempDT.Rows[0]["bloodType"].ToString();
            //birthdate_datetimepicker_baptist.Value = dh.toDateTime(TempDT.Rows[0]["birthdate"].ToString(),false);<<<<<<<<<<<<<<<<<<<<<<<<DEWEY HERE

            //LOAD FATHER
            if (dh.getFatherOf(ProfileID).Rows.Count != 0)
            {
                DataTable TempFatherDT = dh.getFatherOf(ProfileID);
                firstname_textbox_father.Text = TempFatherDT.Rows[0]["firstname"].ToString();
                middlename_textbox_father.Text = TempFatherDT.Rows[0]["midname"].ToString();
                lastname_textbox_father.Text = TempFatherDT.Rows[0]["lastname"].ToString();
                suffix_textbox_father.Text = TempFatherDT.Rows[0]["suffix"].ToString();
                birthplace_textbox_father.Text = TempFatherDT.Rows[0]["birthplace"].ToString();
                residence_textbox_father.Text = TempFatherDT.Rows[0]["residence"].ToString();
            }

            //LOAD MOTHER
            if (dh.getFatherOf(ProfileID).Rows.Count != 0)
            {
                DataTable TempMotherDT = dh.getMotherOf(ProfileID);
                firstname_textbox_mother.Text = TempMotherDT.Rows[0]["firstname"].ToString();
                middlename_textbox_mother.Text = TempMotherDT.Rows[0]["midname"].ToString();
                lastname_textbox_mother.Text = TempMotherDT.Rows[0]["lastname"].ToString();
                suffix_textbox_mother.Text = TempMotherDT.Rows[0]["suffix"].ToString();
                birthplace_textbox_mother.Text = TempMotherDT.Rows[0]["birthplace"].ToString();
                residence_textbox_mother.Text = TempMotherDT.Rows[0]["residence"].ToString();

            }
        }


        

        public void load_Baptism()
        {
            baptism_sponsor_dgv.DataSource = dh.getSponsors("bap",ProfileID);



           

        }

        public void load_Confirmation()
        {

        }

        public void load_Marriage()
        {

        }


        #endregion

        #region DGV clicks
        int sponsorBaptismLastClick;

        private void baptism_sponsor_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sponsorBaptismLastClick = int.Parse(baptism_sponsor_dgv.CurrentRow.Cells["sponsorID"].Value.ToString());
            firstname_textbox_sponsor_baptism.Text = baptism_sponsor_dgv.CurrentRow.Cells["firstName"].Value.ToString();
            middlename_textbox_sponsor_baptism.Text = baptism_sponsor_dgv.CurrentRow.Cells["middleName"].Value.ToString();
            lastname_textbox_sponsor_baptism.Text = baptism_sponsor_dgv.CurrentRow.Cells["lastName"].Value.ToString();
            suffix_textbox_sponsor_baptism.Text = baptism_sponsor_dgv.CurrentRow.Cells["suffix"].Value.ToString();
            residence_textbox_sponsor_baptism.Text = baptism_sponsor_dgv.CurrentRow.Cells["residence"].Value.ToString();

            if (baptism_sponsor_dgv.CurrentRow.Cells["gender"].Value != null)
            {
                if (baptism_sponsor_dgv.CurrentRow.Cells["gender"].Value.ToString().Equals("m"))
                {
                    genderM_radiobutton_sponsor_baptism.Checked = true;
                }
                else if (baptism_sponsor_dgv.CurrentRow.Cells["gender"].Value.ToString().Equals("f"))
                {
                    genderF_radiobutton_sponsor_baptism.Checked = false;
                }
            }
        }
        #endregion

        #region Menu_Clicks

        private void biodata_button_Click(object sender, EventArgs e)
		{
            load_Biodata();
            basic_panel.Visible = true;
            baptism_panel.Visible = false;
            confirmation_panel.Visible = false;
            marriage_panel.Visible = false;
            balance_panel.Visible = false;
            bloodletting_panel.Visible = false;
            
		}

		private void baptism_button_Click(object sender, EventArgs e)
		{
            if (dh.hasBaptismApplication(ProfileID))
            {
                load_Baptism();
                basic_panel.Visible = false;
                baptism_panel.Visible = true;
                confirmation_panel.Visible = false;
                marriage_panel.Visible = false;
                balance_panel.Visible = false;
                bloodletting_panel.Visible = false;
            }
            else
            {
                dh.addApplication(ProfileID, "bap");      
            }

        }

        private void confirmation_button_Click(object sender, EventArgs e)
        {
            if (dh.hasConfirmaionApplication(ProfileID))
            {
                load_Confirmation();
                basic_panel.Visible = false;
                baptism_panel.Visible = false;
                confirmation_panel.Visible = true;
                marriage_panel.Visible = false;
                balance_panel.Visible = false;
                bloodletting_panel.Visible = false;
            }
            else
            {
                dh.addApplication(ProfileID, "conf");
            }
        }

        private void marriage_button_Click(object sender, EventArgs e)
        {
            if (dh.hasMarriageApplication(ProfileID))
            {
                load_Marriage();
                basic_panel.Visible = false;
                baptism_panel.Visible = false;
                confirmation_panel.Visible = false;
                marriage_panel.Visible = true;
                balance_panel.Visible = false;
                bloodletting_panel.Visible = false;
            }
            else
            {
                dh.addApplication(ProfileID, "mar");
            }
        }


        #endregion


        private void Person_Load(object sender, EventArgs e)
        {
            if (dh.hasBaptismApplication(ProfileID)) { baptism_button.BackColor = Color.Green; } else { baptism_button.BackColor = Color.Red; }
            if (dh.hasMarriageApplication(ProfileID)) { marriage_button.BackColor = Color.Green; } else { marriage_button.BackColor = Color.Red; }
            if (dh.hasConfirmaionApplication(ProfileID)) { confirmation_button.BackColor = Color.Green; } else { confirmation_button.BackColor = Color.Red; }

        }
    }
}
