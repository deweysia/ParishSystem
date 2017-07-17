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

      
        public Person(int a, DataHandler b)
        {
            InitializeComponent();
            dh = b;
            ProfileID = a;
        }

        #region GUI basic

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Names_textbox_Leave(object sender, EventArgs e)
        {
            TextBox A = sender as TextBox;
            string B = A.Name.Split('_')[0];
            if (A.Text.Trim().Equals(""))
            {
                A.Text = B;
                A.ForeColor = Color.Gray;
            }
        }

        private void Names_textbox_MouseClick(object sender, EventArgs e)
        {
            TextBox A = sender as TextBox;
            if (A.Text.Equals(A.Name.Split('_')[0]))
            {
                A.Text = "";
                A.ForeColor = Color.Black;
            }
        }

        private void Names_textbox_profile_TextChanged(object sender, EventArgs e)
        {

            TextBox A = sender as TextBox;
            if (A.Text.Equals(A.Name.Split('_')[0]))
            {
                A.ForeColor = Color.Gray;
            }
            else
            {
                A.ForeColor = Color.Black;
            }
        }

        private void dateTimePicker_profile_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = sender as DateTimePicker;
            dtp.Format = DateTimePickerFormat.Long;
        }
        #endregion

        #region Profiles

       

       
        #endregion
        
        #region bloodletting
        //--------------bloodletting--------------------//
       
       

        private void load_bloodletting()
        {
            donation_datagridview_bloodletting.DataSource = dh.getBloodDonations(ProfileID);
            donation_datagridview_bloodletting.Columns["bloodDonationID"].Visible = false;
            quantityDonation_numericupdown_bloodletting.Value = 0;
            bloodDonationEvent_combobox_bloodletting.Text = "";
            delete_button_bloodletting.Enabled = false;
            add_button_bloodletting.Text = "Add";
            add_button_bloodletting.Enabled = false;
            totalDonation_label_bloodletting.Text = dh.getTotalBloodDonationOf(ProfileID).ToString();
            bloodDonationEvent_combobox_bloodletting.Items.Clear();
            foreach (DataRow row in dh.getBloodlettingEvents().Rows)
            {
                bloodDonationEvent_combobox_bloodletting.Items.Add(new ComboboxContent(int.Parse(row["bloodDonationEventID"].ToString()), row["eventName"].ToString()));
                
            }

        }

        private void add_button_bloodletting_Click(object sender, EventArgs e)// add edit 
        {
            Console.WriteLine("_--------------------------------------------" + ((ComboboxContent)bloodDonationEvent_combobox_bloodletting.SelectedItem).ID);
           
            if (add_button_bloodletting.Text.Equals("Add"))
            {
                dh.addBloodDonation(ProfileID,
                                    int.Parse(quantityDonation_numericupdown_bloodletting.Value.ToString()),
                                    ((ComboboxContent)bloodDonationEvent_combobox_bloodletting.SelectedItem).ID, DateTime.Now);
                load_bloodletting();

            }
            else if (add_button_bloodletting.Text.Equals("Edit"))
            {
                int A = ((ComboboxContent)bloodDonationEvent_combobox_bloodletting.SelectedItem).ID;
                dh.editBloodDonation(ProfileID,
                                    int.Parse(quantityDonation_numericupdown_bloodletting.Value.ToString()),
                                    A,
                                    DateTime.Now);
                load_bloodletting();
                add_button_bloodletting.Text = "Add";
                 
            }
            
        }
            
        
        
        
        private void delete_button_bloodletting_Click(object sender, EventArgs e)// delete
        {
            dh.deleteBloodDonation(int.Parse(donation_datagridview_bloodletting.SelectedRows[0].Cells["bloodDonationID"].Value.ToString()));
            load_bloodletting();
            add_button_bloodletting.Text = "Add";

        }

        private void donation_datagridview_bloodletting_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            quantityDonation_numericupdown_bloodletting.Value = decimal.Parse(donation_datagridview_bloodletting.SelectedRows[0].Cells["quantity"].Value.ToString());
            bloodDonationEvent_combobox_bloodletting.Text = donation_datagridview_bloodletting.SelectedRows[0].Cells["eventName"].Value.ToString();
            add_button_bloodletting.Enabled = false;
            add_button_bloodletting.Text = "Edit";
            delete_button_bloodletting.Enabled = true;

        }

        private void quantityDonation_numericupdown_bloodletting_ValueChanged(object sender, EventArgs e)
        {
            if (bloodDonationEvent_combobox_bloodletting.Text.Equals("") || quantityDonation_numericupdown_bloodletting.Value.ToString().Equals("0"))
            {
                add_button_bloodletting.Enabled = false;
            }
            else
            {
                add_button_bloodletting.Enabled = true;
            }
        }

        private void bloodDonationEvent_combobox_bloodletting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bloodDonationEvent_combobox_bloodletting.Text.Equals("") || quantityDonation_numericupdown_bloodletting.Value.ToString().Equals("0"))
            {
                add_button_bloodletting.Enabled = false;
            }
            else
            {
                add_button_bloodletting.Enabled = true;
            }
        }





        #endregion bloodletting   

        #region baptism
        private void baptism_button_Click(object sender, EventArgs e)
        {
            baptism_panel.BringToFront();
            refreshBaptismPage();
            float_panel_baptism.BringToFront();
        }

        private void details_button_baptism_Click(object sender, EventArgs e)
        {
            baptism_details_panel.BringToFront();
            refreshBaptismPage();
        }

        private void refreshBaptismPage()
        {
            //profile
            DataTable dt = dh.getBaptismOf(ProfileID);
            firstname_textbox_profile_baptism.Text = dt.Rows[0]["fng"].ToString();
            mi_textbox_profile_baptism.Text = dt.Rows[0]["mng"].ToString();
            lastname_textbox_profile_baptism.Text =  dt.Rows[0]["lng"].ToString();
            suffix_textbox_mother_baptism.Text =  dt.Rows[0]["sg"].ToString();
            address_textarea_profile_baptism.Text = dt.Rows[0]["address"].ToString();
            contactNumber_textbox_profile_baptism.Text = dt.Rows[0]["contactNumber"].ToString();
            if (dt.Rows[0]["gg"].ToString()=="M")
                { genderMale_radiobutton_profile_baptism.Checked = true; }
            else if (dt.Rows[0]["gg"].ToString() == "F")
                { genderFemale_radiobutton_profile_baptism.Checked = true; }
            else
                { genderMale_radiobutton_profile_baptism.Checked = false;
                  genderFemale_radiobutton_profile_baptism.Checked = false; }
            if (dt.Rows[0]["legitimacy"].ToString() == "L")
                { legitimate_radiobutton_baptism.Checked = true; }
            else if (dt.Rows[0]["legitimacy"].ToString() == "C")
                { civil_radiobutton_baptism.Checked = true; }
            else if (dt.Rows[0]["legitimacy"].ToString() == "N")
                { natural_radiobutton_baptism.Checked = true; }
            else
                { legitimate_radiobutton_baptism.Checked = false;
                  civil_radiobutton_baptism.Checked= false;
                  natural_radiobutton_baptism.Checked = false; }
            try
            {
                birthdate_dateTimePicker_profile_baptism.Value = dh.toDateTime(dt.Rows[0]["birthdate"].ToString(),false);
                birthdate_dateTimePicker_profile_baptism.Format = DateTimePickerFormat.Long;
            }
            catch
            {
                birthdate_dateTimePicker_profile_baptism.Format = DateTimePickerFormat.Custom;
            }
            //father
            try {
                DataTable fdt = dh.getFatherOf(ProfileID);
                father_checbox.Checked = true;
                firstname_textbox_father_baptism.Text= fdt.Rows[0]["firstname"].ToString();
                mi_textbox_father_baptism.Text = fdt.Rows[0]["midname"].ToString();
                lastname_textbox_father_baptism.Text = fdt.Rows[0]["lastname"].ToString();
                suffix_textbox_father_baptism.Text = fdt.Rows[0]["suffix"].ToString();
                residence_textbox_father_baptism.Text = fdt.Rows[0]["residence"].ToString();
            }
            catch
                { dh.conn.Close();
                  father_checbox.Checked = false;
                }
            //mother
            try
            {
                DataTable mdt = dh.getMotherOf(ProfileID);
                mother_checkbox.Checked = true;
                firstname_textbox_mother_baptism.Text = mdt.Rows[0]["firstname"].ToString();
                mi_textbox_mother_baptism.Text = mdt.Rows[0]["midname"].ToString();
                lastname_textbox_mother_baptism.Text = mdt.Rows[0]["lastname"].ToString();
                suffix_textbox_mother_baptism.Text = mdt.Rows[0]["suffix"].ToString();
                residence_textbox_mother_baptism.Text = mdt.Rows[0]["residence"].ToString();
            }
            catch
            {
                dh.conn.Close();
                mother_checkbox.Checked = false;
            }
            //godFather
            try
            {
                DataTable gfdt = dh.getFatherOf(ProfileID);
                godfather_checkbox.Checked = true;
                firstname_textbox_godFather_baptism.Text = gfdt.Rows[0]["firstname"].ToString();
                mi_textbox_godFather_baptism.Text = gfdt.Rows[0]["midname"].ToString();
                lastname_textbox_godFather_baptism.Text = gfdt.Rows[0]["lastname"].ToString();
                suffix_textbox_godFather_baptism.Text = gfdt.Rows[0]["suffix"].ToString();
                residence_textbox_godFather_baptism.Text = gfdt.Rows[0]["residence"].ToString();
            }
            catch
            {
                dh.conn.Close();
                godfather_checkbox.Checked = false;
                
            }

            //godMother
            try
            {
                DataTable gmdt = dh.getFatherOf(ProfileID);
                godMother_checkbox.Checked = true;
                firstname_textbox_godMother_baptism.Text = gmdt.Rows[0]["firstname"].ToString();
                mi_textbox_godMother_baptism.Text = gmdt.Rows[0]["midname"].ToString();
                lastname_textbox_godMother_baptism.Text = gmdt.Rows[0]["lastname"].ToString();
                suffix_textbox_godMother_baptism.Text = gmdt.Rows[0]["suffix"].ToString();
                residence_textbox_godMother_baptism.Text = gmdt.Rows[0]["residence"].ToString();
            }
            catch
            {
                dh.conn.Close();
                godMother_checkbox.Checked = false;
            }
            try
            {
                minister_combobox_baptism.Text = dt.Rows[0]["minister"].ToString();
                date_datetimepicker_baptism.Value =dh.toDateTime(dt.Rows[0]["baptismDate"].ToString(),false);
                date_datetimepicker_baptism.Format = DateTimePickerFormat.Long;
            }
            catch
            {
                minister_combobox_baptism.Text = "";
                date_datetimepicker_baptism.Format =DateTimePickerFormat.Custom;
            }
            
                registry_textbox_baptism.Text= dt.Rows[0]["registryNumber"].ToString();
                page_textbox_baptism.Text= dt.Rows[0]["pageNumber"].ToString();
                record_textbox_baptism.Text= dt.Rows[0]["recordNumber"].ToString();
                remarks_textbox_baptism.Text= dt.Rows[0]["remarks"].ToString();
            try
            {
                date_datetimepicker_baptism.Format = DateTimePickerFormat.Long;
                date_datetimepicker_baptism.Value = dh.toDateTime(dt.Rows[0]["baptismDate"].ToString(),false);
            }
            catch
            {
                date_datetimepicker_baptism.Format = DateTimePickerFormat.Custom;
            }

            minister_combobox_baptism.Items.Clear();
            DataTable ministers= dh.getMinisters();
            foreach(DataRow row in ministers.Rows)
            {
                minister_combobox_baptism.Items.Add(new ComboboxContent(int.Parse(row["ministerID"].ToString()), row["Name"].ToString()));
            }
           
        }

        private void godfather_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (godfather_checkbox.Checked == true)
                godFather_panel_baptism.Visible = true;
            else
                godFather_panel_baptism.Visible = false;
        }

        private void godMother_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (godMother_checkbox.Checked == true)
                godMother_panel_baptism.Visible = true;
            else
                godMother_panel_baptism.Visible = false;
        }

        private void father_checbox_CheckedChanged(object sender, EventArgs e)
        {
            if (father_checbox.Checked == true)
                father_panel_baptism.Visible = true;
            else
                father_panel_baptism.Visible = false;
        }

        private void mother_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (mother_checkbox.Checked == true)
                mother_panel_baptism.Visible = true;
            else
                mother_panel_baptism.Visible = false;
        }

        public bool isNameEmpty(TextBox A)
        {
            return A.Name.Split('_')[0] == A.Text;
        }

        private void save_button_baptism_Click(object sender, EventArgs e)
        {
            if (isNameEmpty(firstname_textbox_profile_baptism) ||
                isNameEmpty(mi_textbox_profile_baptism) ||
                isNameEmpty(lastname_textbox_profile_baptism) ||
                !(legitimate_radiobutton_baptism.Checked || civil_radiobutton_baptism.Checked || natural_radiobutton_baptism.Checked) ||
                birthdate_dateTimePicker_profile_baptism.Format.Equals(DateTimePickerFormat.Custom) ||
                !(genderMale_radiobutton_profile_baptism.Checked || genderFemale_radiobutton_profile_baptism.Checked))
            {

            }

            if (father_checbox.Checked && (isNameEmpty(firstname_textbox_father_baptism) ||
                isNameEmpty(mi_textbox_father_baptism) ||
                isNameEmpty(lastname_textbox_father_baptism) ||
                residence_textbox_father_baptism.Text == ""))
            {

            }


            if (
                mother_checkbox.Checked ||
                isNameEmpty(firstname_textbox_mother_baptism) ||
                isNameEmpty(mi_textbox_mother_baptism) ||
                isNameEmpty(lastname_textbox_mother_baptism) ||
                residence_textbox_mother_baptism.Text == "")
            {

            }
            if (
                godfather_checkbox.Checked ||
                isNameEmpty(firstname_textbox_godFather_baptism) ||
                isNameEmpty(mi_textbox_godFather_baptism) ||
                isNameEmpty(lastname_textbox_godFather_baptism) ||
                residence_textbox_godFather_baptism.Text == "")
            {

            }
            if (
                godMother_checkbox.Checked ||
                isNameEmpty(firstname_textbox_godMother_baptism) ||
                isNameEmpty(mi_textbox_godMother_baptism) ||
                isNameEmpty(lastname_textbox_godMother_baptism) ||
                residence_textbox_godMother_baptism.Text == "")
            {
                
            }
            

        }

        private void close_button_baptism_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region confirmation
        private void confirmation_button_Click(object sender, EventArgs e)
        {
            refreshConfirmation();
            confirmation_panel.BringToFront();
        }

        private void details_confirmation_button_Click(object sender, EventArgs e)
        {
            refreshConfirmation();
            confirmation_panel.BringToFront();
        }

        private void refreshConfirmation()
        {
            //profile
            DataTable dt= dh.getConfirmationOf(ProfileID);
            firstname_textbox_profile_confirmation.Text= dt.Rows[0]["fng"].ToString();
            mi_textbox_profile_confirmation.Text = dt.Rows[0]["mng"].ToString();
            lastname_textbox_profile_confirmation.Text = dt.Rows[0]["lng"].ToString();
            suffix_textbox_profile_confirmation.Text = dt.Rows[0]["sg"].ToString();
            //father
            try
            {
                DataTable fdt = dh.getFatherOf(ProfileID);
                father_checkbox_confirmation.Checked = true;
                firstname_textbox_father_confirmation.Text = fdt.Rows[0]["firstname"].ToString();
                mi_textbox_father_confirmation.Text = fdt.Rows[0]["midname"].ToString();
                lastname_textbox_father_confirmation.Text = fdt.Rows[0]["lastname"].ToString();
                suffix_textbox_father_confirmation.Text = fdt.Rows[0]["suffix"].ToString();
            }
            catch
            {
                dh.conn.Close();
                father_checkbox_confirmation.Checked = false;
            }
            //mother
            try
            {
                DataTable mdt = dh.getMotherOf(ProfileID);
                mother_checkbox_confirmation.Checked = true;
                firstname_textbox_mother_confirmation.Text = mdt.Rows[0]["firstname"].ToString();
                mi_textbox_mother_confirmation.Text = mdt.Rows[0]["midname"].ToString();
                lastname_textbox_mother_confirmation.Text = mdt.Rows[0]["lastname"].ToString();
                suffix_textbox_mother_confirmation.Text = mdt.Rows[0]["suffix"].ToString();
            }
            catch
            {
                dh.conn.Close();
                mother_checkbox_confirmation.Checked = false;
            }
            //godFather
            try
            {
                DataTable gfdt = dh.getFatherOf(ProfileID);
                godfather_checkbox_confirmation.Checked = true;
                firstname_textbox_godFather_confirmation.Text = gfdt.Rows[0]["firstname"].ToString();
                mi_textbox_godFather_confirmation.Text = gfdt.Rows[0]["midname"].ToString();
                lastname_textbox_godFather_confirmation.Text = gfdt.Rows[0]["lastname"].ToString();
                suffix_textbox_godFather_confirmation.Text = gfdt.Rows[0]["suffix"].ToString();
            }
            catch
            {
                dh.conn.Close();
                godfather_checkbox_confirmation.Checked = false;
            }
            //godMother
            try
            {
                DataTable gmdt = dh.getFatherOf(ProfileID);
                godMother_checkbox_confirmation.Checked = true;
                firstname_textbox_godMother_confirmation.Text = gmdt.Rows[0]["firstname"].ToString();
                mi_textbox_godMother_confirmation.Text = gmdt.Rows[0]["midname"].ToString();
                lastname_textbox_godMother_confirmation.Text = gmdt.Rows[0]["lastname"].ToString();
                suffix_textbox_godMother_confirmation.Text = gmdt.Rows[0]["suffix"].ToString();
            }
            catch
            {
                dh.conn.Close();
                godMother_checkbox_confirmation.Checked = false;
            }
            minister_combobox_confirmation.Text= dt.Rows[0]["minister"].ToString();
            registry_textbox_confirmation.Text = dt.Rows[0]["registryNumber"].ToString();   
            page_textbox_confirmation.Text= dt.Rows[0]["pageNumber"].ToString();
            record_textbox_confirmation.Text=dt.Rows[0]["recordNumber"].ToString();

            try
            {
                date_datetimepicker_confirmation.Format = DateTimePickerFormat.Long;
                date_datetimepicker_confirmation.Value = dh.toDateTime(dt.Rows[0]["confirmationDate"].ToString(), false);
            }
            catch
            {
                date_datetimepicker_confirmation.Format = DateTimePickerFormat.Custom;
            }

            DataTable ministers = dh.getMinisters();
            minister_combobox_confirmation.Items.Clear();
            foreach (DataRow row in ministers.Rows)
            {
                minister_combobox_confirmation.Items.Add(new ComboboxContent(int.Parse(row["ministerID"].ToString()), row["Name"].ToString()));
            }
        }

        private void father_checkbox_confirmation_CheckedChanged(object sender, EventArgs e)
        {
            if (father_checkbox_confirmation.Checked)
            {
                father_panel_confirmation.Visible = true;
            }
            else
            {
                father_panel_confirmation.Visible = false;
            }
        }

        private void mother_checkbox_confirmation_CheckedChanged(object sender, EventArgs e)
        {
            if (mother_checkbox_confirmation.Checked)
            {
                mother_panel_confirmation.Visible = true;
            }
            else
            {
                mother_panel_confirmation.Visible = false;
            }
        }

        private void godfather_checkbox_confirmation_CheckedChanged(object sender, EventArgs e)
        {
            if (godfather_checkbox_confirmation.Checked)
            {
                godFather_panel_confirmation.Visible = true;
            }
            else
            {
                godFather_panel_confirmation.Visible = false;
            }
        }

        private void godMother_checkbox_confirmation_CheckedChanged(object sender, EventArgs e)
        {
            if (godMother_checkbox_confirmation.Checked)
            {
                godMother_panel_confirmation.Visible = true;
            }
            else
            {
                godMother_panel_confirmation.Visible = false;
            }
        }


        #endregion

       
    }
}
