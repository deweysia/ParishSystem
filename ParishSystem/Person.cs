using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//button.performclick()
namespace ParishSystem
{
    public partial class Person : Form
    {
        public int ProfileID;
        public DataHandler dh;
        private List<Panel> panelList = new List<Panel>();
        private Dictionary<string, Panel> panelDict = new Dictionary<string, Panel>();
        public int mode;
        public int initialPageOpened = 0;
        public int ApplicationID = 0;
        public Person(int a, DataHandler b, int mode)
        {
            InitializeComponent();
            dh = b;
            ProfileID = a;
            this.mode = mode;
        }

        public Person(int applicationID, DataHandler dh, int mode,int initialPageOpened)//for those with initial opened pages
        {
            InitializeComponent();
            this.dh = dh;
            this.ApplicationID = applicationID;
            this.initialPageOpened = initialPageOpened;
            this.mode = mode;
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
            if (A.Text.Trim().Equals("")&&A.ReadOnly==false)
            {
              
                A.Text = B;
             
            }
        }

        private void Names_textbox_MouseClick(object sender, EventArgs e)
        {
            TextBox A = sender as TextBox;
            if (A.Text.Equals(A.Name.Split('_')[0]))
            {
                A.Text = "";
              

            }
        }

        private void Names_textbox_profile_TextChanged(object sender, EventArgs e)
        {
            TextBox A = sender as TextBox;
            if (A.Text.Equals(A.Name.Split('_')[0]))
            {

            }
            else
            {

            }

        }

        private void dateTimePicker_profile_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = sender as DateTimePicker;
            dtp.Format = DateTimePickerFormat.Long;
        }
        #endregion

        private void DisableControlsInParent(Control control)
        {
            foreach (Control ctl in control.Controls)
            {
                   if(ctl is TextBox)
                {
                    TextBox a = ctl as TextBox;
                    a.ForeColor = Color.Black;
                    a.ReadOnly = true;
                }
                   else if(ctl is ComboBox|| ctl is CheckBox || ctl is DateTimePicker || ctl is RadioButton)
                {
                    ctl.Enabled = false;
                   
                }          
                DisableControlsInParent(ctl);
                }
        }
        

        #region Profiles



        private void Person_Load(object sender, EventArgs e)
        {

            load_parents();
            if (mode == (int)Enums.Mode.GeneralProfile)
            {
                DisableControlsInParent(baptism_panel);
                DisableControlsInParent(confirmation_panel);
                DisableControlsInParent(marriage_panel);

                Applications_datagridview.DataSource = dh.getApplicationsOf(ProfileID);
                foreach (DataGridViewRow dgvr in Applications_datagridview.Rows)
                {
                    if (dgvr.Cells["sacramentType"].Value.ToString().Equals(Enums.SacramentType.Baptism.ToString()))
                    {
                        baptism_button.Visible = false;
                        baptism_panel.Visible = false;
                    }
                    if (dgvr.Cells["sacramentType"].Value.ToString().Equals(Enums.SacramentType.Confirmation.ToString()))
                    {
                        confirmation_button.Visible = false;
                        confirmation_panel.Visible = false;
                    }
                    if (dgvr.Cells["sacramentType"].Value.ToString().Equals(Enums.SacramentType.Marriage.ToString()))
                    {
                        marriage_button.Visible = false;
                        marriage_panel.Visible = false;
                    }
                }
               
            }

            else if (mode == (int)Enums.Mode.Applications)
            {
                if (initialPageOpened == 1)
                {
                    baptism_button.PerformClick();
                }
                else if (initialPageOpened == 2)
                {
                    confirmation_button.PerformClick();
                }
                else if (initialPageOpened == 3)
                {
                    marriage_button.PerformClick();
                }
            }
            DataTable DT = dh.getGeneralProfile(ProfileID);

            firstname_textbox.Text = DT.Rows[0]["firstname"].ToString();
            mi_textbox.Text = DT.Rows[0]["midname"].ToString();
            lastname_textbox.Text = DT.Rows[0]["lastname"].ToString();
            suffix_textbox.Text = DT.Rows[0]["suffix"].ToString();
            contactNumber_textbox.Text = DT.Rows[0]["contactNumber"].ToString();
            address_textbox.Text = DT.Rows[0]["address"].ToString();
            //   .Text = DT.Rows[0]["birthplace"].ToString();
            try
            {
                if (int.Parse(DT.Rows[0]["gender"].ToString()) == (int)Enums.Gender.Male)
                { gender_label.Text = "Male"; }
                else if (int.Parse(DT.Rows[0]["gender"].ToString()) == (int)Enums.Gender.Female)
                { gender_label.Text = "Female"; }
              
            }
            catch { }
            try
            {
                if (int.Parse(DT.Rows[0]["legitimacy"].ToString()) == (int)Legitimacy.Legal)
                { legitimate_radiobutton_baptism.Checked = true; }
                else if (int.Parse(DT.Rows[0]["legitimacy"].ToString()) == (int)Legitimacy.Civil)
                { civil_radiobutton_baptism.Checked = true; }
                else if (int.Parse(DT.Rows[0]["legitimacy"].ToString()) == (int)Legitimacy.Natural)
                { natural_radiobutton_baptism.Checked = true; }
                else
                {
                    legitimate_radiobutton_baptism.Checked = false;
                    civil_radiobutton_baptism.Checked = false;
                    natural_radiobutton_baptism.Checked = false;
                }
            }
            catch { }
            try
            {
                if (int.Parse(DT.Rows[0]["civilStatus"].ToString()) == (int)Enums.CivilStatus.Single)
                    civilStatus_label.Text = "Single";
                else if (int.Parse(DT.Rows[0]["civilStatus"].ToString()) == (int)Enums.CivilStatus.Widowed)
                    civilStatus_label.Text = "Widowed";
            }
            catch { }
            try
            { birthdate_dateTimePicker.Text = (DateTimePickerFormat.Long).ToString("MMMM, dd, yyyy");}
            catch
            {}
            
             
        }


        private void load_parents()
        {
            //father
            DataTable fdt = dh.getFatherOf(ProfileID);
            try
            {
                
                firstname_textbox_father_baptism.Text = fdt.Rows[0]["firstname"].ToString();
                mi_textbox_father_baptism.Text = fdt.Rows[0]["midname"].ToString();
                lastname_textbox_father_baptism.Text = fdt.Rows[0]["lastname"].ToString();
                suffix_textbox_father_baptism.Text = fdt.Rows[0]["suffix"].ToString();
                residence_textbox_father_baptism.Text = fdt.Rows[0]["residence"].ToString();
                father_checbox.Checked = true;

            }
            catch { }
            try
            {
                
                firstname_textbox_father_confirmation.Text = fdt.Rows[0]["firstname"].ToString();
                mi_textbox_father_confirmation.Text = fdt.Rows[0]["midname"].ToString();
                lastname_textbox_father_confirmation.Text = fdt.Rows[0]["lastname"].ToString();
                suffix_textbox_father_confirmation.Text = fdt.Rows[0]["suffix"].ToString();
                father_checkbox_confirmation.Checked = true;
               
            }
            catch { }
            try
            {
                
                firstname_textbox_father_self_marriage.Text = fdt.Rows[0]["firstname"].ToString();
                mi_textbox_father_self_marriage.Text = fdt.Rows[0]["midname"].ToString();
                lastname_textbox_father_self_marriage.Text = fdt.Rows[0]["lastname"].ToString();
                suffix_textbox_father_self_marriage.Text = fdt.Rows[0]["suffix"].ToString();
                residence_textbox_father_self_marriage.Text = fdt.Rows[0]["residence"].ToString();
                father_checkbox_self_marriage.Checked = true;
               
            }
            catch { }


            //mother
       
                DataTable mdt = dh.getMotherOf(ProfileID);
                try
                {
                   
                firstname_textbox_mother_baptism.Text = mdt.Rows[0]["firstname"].ToString();
                mi_textbox_mother_baptism.Text = mdt.Rows[0]["midname"].ToString();
                lastname_textbox_mother_baptism.Text = mdt.Rows[0]["lastname"].ToString();
                suffix_textbox_mother_baptism.Text = mdt.Rows[0]["suffix"].ToString();
                residence_textbox_mother_baptism.Text = mdt.Rows[0]["residence"].ToString();
                mother_checkbox.Checked = true;
            }
                catch { }
                try
                {
                
                firstname_textbox_mother_confirmation.Text = mdt.Rows[0]["firstname"].ToString();
                mi_textbox_mother_confirmation.Text = mdt.Rows[0]["midname"].ToString();
                lastname_textbox_mother_confirmation.Text = mdt.Rows[0]["lastname"].ToString();
                suffix_textbox_mother_confirmation.Text = mdt.Rows[0]["suffix"].ToString();
                mother_checkbox_confirmation.Checked = true;
            }
                catch { }
                try
                {
                
                firstname_textbox_mother_self_marriage.Text = mdt.Rows[0]["firstname"].ToString();
                mi_textbox_mother_self_marriage.Text = mdt.Rows[0]["midname"].ToString();
                lastname_textbox_mother_self_marriage.Text = mdt.Rows[0]["lastname"].ToString();
                suffix_textbox_mother_self_marriage.Text = mdt.Rows[0]["suffix"].ToString();
                residence_textbox_mother_self_marriage.Text = mdt.Rows[0]["residence"].ToString();
                mother_checkbox_self_marriage.Checked = true;
            }
                catch { }
            
            }
            
        


        #endregion

       

        #region baptism
        private void baptism_button_Click(object sender, EventArgs e)
        {
            baptism_panel.BringToFront();
            refreshBaptism();
        }

        private void refreshBaptism()
        {
            
            //profile
            DataTable dt = dh.getBaptismOf(ProfileID);

           
            registry_textbox_baptism.Text = dt.Rows[0]["registryNumber"].ToString();
            page_textbox_baptism.Text = dt.Rows[0]["pageNumber"].ToString();
            record_textbox_baptism.Text = dt.Rows[0]["recordNumber"].ToString();
            remarks_textbox_baptism.Text = dt.Rows[0]["remarks"].ToString();

           
            DataTable sponsors = dh.getSponsors(int.Parse(dt.Rows[0]["applicationID"].ToString()));
            //godFather
            try
            {
                godfather_checkbox.Checked = true;
                firstname_textbox_godFather_baptism.Text = sponsors.Rows[0]["firstname"].ToString();
                mi_textbox_godFather_baptism.Text = sponsors.Rows[0]["midname"].ToString();
                lastname_textbox_godFather_baptism.Text = sponsors.Rows[0]["lastname"].ToString();
                suffix_textbox_godFather_baptism.Text = sponsors.Rows[0]["suffix"].ToString();
                residence_textbox_godFather_baptism.Text = sponsors.Rows[0]["residence"].ToString();
            }
            catch
            {
                godfather_checkbox.Checked = false;
            }

            //godMother
            try
            {
                godMother_checkbox.Checked = true;
                firstname_textbox_godMother_baptism.Text = sponsors.Rows[1]["firstname"].ToString();
                mi_textbox_godMother_baptism.Text = sponsors.Rows[1]["midname"].ToString();
                lastname_textbox_godMother_baptism.Text = sponsors.Rows[1]["lastname"].ToString();
                suffix_textbox_godMother_baptism.Text = sponsors.Rows[1]["suffix"].ToString();
                residence_textbox_godMother_baptism.Text = sponsors.Rows[1]["residence"].ToString();
            }
            catch
            {
                godMother_checkbox.Checked = false;
            }


            date_datetimepicker_baptism.Value = dh.toDateTime(dt.Rows[0]["baptismDate"].ToString(), false);
            date_datetimepicker_baptism.Format = DateTimePickerFormat.Long;
            minister_combobox_baptism.Text = dt.Rows[0]["minister"].ToString();


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


        #endregion

        #region confirmation
        private void confirmation_button_Click(object sender, EventArgs e)
        {
            confirmation_panel.BringToFront();
            refreshConfirmation();
        }


        private void refreshConfirmation()
        {
         
            //profile
            DataTable dt = dh.getConfirmationOf(ProfileID);



          
            DataTable sponsors = dh.getSponsors(int.Parse(dt.Rows[0]["applicationID"].ToString()));
            //godFather
            try
            {
                godfather_checkbox_confirmation.Checked = true;
                firstname_textbox_godFather_confirmation.Text = sponsors.Rows[0]["firstname"].ToString();
                mi_textbox_godFather_confirmation.Text = sponsors.Rows[0]["midname"].ToString();
                lastname_textbox_godFather_confirmation.Text = sponsors.Rows[0]["lastname"].ToString();
                suffix_textbox_godFather_confirmation.Text = sponsors.Rows[0]["suffix"].ToString();
            }
            catch
            {
                godfather_checkbox_confirmation.Checked = false;
            }
            //godMother
            try
            {
                godMother_checkbox_confirmation.Checked = true;
                firstname_textbox_godMother_confirmation.Text = sponsors.Rows[0]["firstname"].ToString();
                mi_textbox_godMother_confirmation.Text = sponsors.Rows[0]["midname"].ToString();
                lastname_textbox_godMother_confirmation.Text = sponsors.Rows[0]["lastname"].ToString();
                suffix_textbox_godMother_confirmation.Text = sponsors.Rows[0]["suffix"].ToString();
            }
            catch
            {
                dh.conn.Close();
                godMother_checkbox_confirmation.Checked = false;
            }
            minister_combobox_confirmation.Text = dt.Rows[0]["minister"].ToString();
            registry_textbox_confirmation.Text = dt.Rows[0]["registryNumber"].ToString();
            page_textbox_confirmation.Text = dt.Rows[0]["pageNumber"].ToString();
            record_textbox_confirmation.Text = dt.Rows[0]["recordNumber"].ToString();


            date_datetimepicker_confirmation.Format = DateTimePickerFormat.Long;
            date_datetimepicker_confirmation.Value = dh.toDateTime(dt.Rows[0]["confirmationDate"].ToString(), false);

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

        #region marriage

        private void marriage_button_Click(object sender, EventArgs e)
        {
            if (mode ==(int) Enums.Mode.GeneralProfile)
            {
                spouse_combobox_marriage.Enabled = true;
            }
            marriage_panel.BringToFront();
            refreshMarriage();
        }

        private void refreshMarriage()
        {
            DataTable temp = dh.getMarriageApplications(ProfileID);


            DataTable Partners = dh.getPartners(int.Parse(temp.Rows[0]["applicationID"].ToString()), ProfileID);
            spouse_combobox_marriage.Items.Clear();
            foreach (DataRow dr in Partners.Rows)
            {
                spouse_combobox_marriage.Items.Add(new ComboboxContent(int.Parse(dr["profileID"].ToString()), dr["Name"].ToString(), dr["applicationID"].ToString()));
            }
            spouse_combobox_marriage.Text = "";

        }

        private void cancel_button_marriage_Click(object sender, EventArgs e)
        {
            load_parents();
            refreshMarriage();
        }

        private void spouse_combobox_marriage_TextChanged(object sender, EventArgs e)
        {
            if (spouse_combobox_marriage.Text != "")
            {
                DataTable dt = dh.getGeneralProfile((spouse_combobox_marriage.SelectedItem as ComboboxContent).ID, (int)Enums.SacramentType.Marriage);
                int spouseID = (spouse_combobox_marriage.SelectedItem as ComboboxContent).ID;
                if (int.Parse(dt.Rows[0]["civilStatus"].ToString()) == (int)Enums.CivilStatus.Single)
                    single_radiobutton_spouse_marriage.Checked = true;
                else if (int.Parse(dt.Rows[0]["civilStatus"].ToString()) == (int)Enums.CivilStatus.Widowed)
                    widowed_radiobutton_spouse_marriage.Checked = true;
                try
                {
                    birthdate_datetimepicker_spouse_marriage.Value = dh.toDateTime(dt.Rows[0]["birthdate"].ToString(), false);
                    birthdate_datetimepicker_spouse_marriage.Format = DateTimePickerFormat.Long;
                }
                catch
                {
                    birthdate_datetimepicker_spouse_marriage.Format = DateTimePickerFormat.Custom;
                }
                contactNumber_textbox_spouse_marriage.Text = dt.Rows[0]["contactNumber"].ToString();
                address_textbox_spouse_marriage.Text = dt.Rows[0]["address"].ToString();

                try
                {
                    DataTable df = dh.getFatherOf(spouseID);
                    firstname_textbox_father_spouse_marriage.Text = df.Rows[0]["firstname"].ToString();
                    mi_textbox_father_spouse_marriage.Text = df.Rows[0]["midname"].ToString();
                    lastname_textbox_father_spouse_marriage.Text = df.Rows[0]["lastname"].ToString();
                    suffix_textbox_father_spouse_marriage.Text = df.Rows[0]["suffix"].ToString();
                    residence_textbox_father_spouse_marriage.Text = df.Rows[0]["residence"].ToString();
                    father_checkbox_spouse_marriage.Checked = true;
                }
                catch
                {}
                try
                {
                    DataTable dm = dh.getMotherOf(spouseID);
                    
                    firstname_textbox_mother_spouse_marriage.Text = dm.Rows[0]["firstname"].ToString();
                    mi_textbox_mother_spouse_marriage.Text = dm.Rows[0]["midname"].ToString();
                    lastname_textbox_mother_spouse_marriage.Text = dm.Rows[0]["lastname"].ToString();
                    suffix_textbox_mother_spouse_marriage.Text = dm.Rows[0]["suffix"].ToString();
                    residence_textbox_mother_spouse_marriage.Text = dm.Rows[0]["residence"].ToString();
                    mother_checkbox_spouse_marriage.Checked = true;
                }
                catch
                {}// DataTable dt = dh.getGeneralProfile((spouse_combobox_marriage.SelectedItem as ComboboxContent).ID);
                DataTable a = dh.getMarriage(int.Parse((spouse_combobox_marriage.SelectedItem as ComboboxContent).Content2));
                recordNumber_textbox_marriage.Text = a.Rows[0]["recordNumber"].ToString();
                pageNumber_textbox_marriage.Text = a.Rows[0]["pageNumber"].ToString();
                registryNumber_textbox_marriage.Text = a.Rows[0]["registryNumber"].ToString();
                pageNumber_textbox_marriage.Text = a.Rows[0]["pageNumber"].ToString();
                recordNumber_textbox_marriage.Text = a.Rows[0]["recordNumber"].ToString();
                minister_combobox_marriage.Text = a.Rows[0]["ministername"].ToString();
                date_dateTimePicker_marriage.Format = DateTimePickerFormat.Long;
                date_dateTimePicker_marriage.Value = dh.toDateTime(a.Rows[0]["marriageDate"].ToString(), false);


                DataTable sponsors = dh.getSponsors(int.Parse(dt.Rows[0]["applicationID"].ToString()));
                try
                {
                   
                    firstname_textbox_godMother_marriage.Text = sponsors.Rows[1]["firstname"].ToString();
                    mi_textbox_godMother_marriage.Text = sponsors.Rows[1]["midname"].ToString();
                    lastname_textbox_godMother_marriage.Text = sponsors.Rows[1]["lastname"].ToString();
                    suffix_textbox_godMother_marriage.Text = sponsors.Rows[1]["suffix"].ToString();
                    residence_textbox_godMother_marriage.Text = sponsors.Rows[1]["residence"].ToString();
                    godFather_checkbox_marriage.Checked = true;
                }
                catch
                {

                }
                try
                {
                   
                    firstname_textbox_godFather_marriage.Text = sponsors.Rows[0]["firstname"].ToString();
                    mi_textbox_godFather_marriage.Text = sponsors.Rows[0]["midname"].ToString();
                    lastname_textbox_godFather_marriage.Text = sponsors.Rows[0]["lastname"].ToString();
                    suffix_textbox_godFather_marriage.Text = sponsors.Rows[0]["suffix"].ToString();
                    residence_textbox_godFather_marriage.Text = sponsors.Rows[0]["residence"].ToString();
                    godMother_checkbox_marriage.Checked = true;
                }
                catch
                {

                }
            }
            else
            {
               
               
            }
        }



        #endregion



        private void father_panel_baptism_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void label67_Click(object sender, EventArgs e)
        {

        }

        //here justin <<<
        private void father_checkbox_self_marriage_CheckedChanged(object sender, EventArgs e)
        {
            if (father_checbox.Checked == true)
                father_panel_baptism.Visible = true;
            else
                father_panel_baptism.Visible = false;
        }

        private void mother_checkbox_self_marriage_CheckedChanged(object sender, EventArgs e)
        {
            if (father_checbox.Checked == true)
                father_panel_baptism.Visible = true;
            else
                father_panel_baptism.Visible = false;
        }

        private void father_checkbox_spouse_marriage_CheckedChanged(object sender, EventArgs e)
        {
            if (father_checbox.Checked == true)
                father_panel_baptism.Visible = true;
            else
                father_panel_baptism.Visible = false;
        }

        private void mother_checkbox_spouse_marriage_CheckedChanged(object sender, EventArgs e)
        {
            if (father_checbox.Checked == true)
                father_panel_baptism.Visible = true;
            else
                father_panel_baptism.Visible = false;
        }

        private void godFather_checkbox_marriage_CheckedChanged(object sender, EventArgs e)
        {
            if (father_checbox.Checked == true)
                father_panel_baptism.Visible = true;
            else
                father_panel_baptism.Visible = false;
        }

        private void godMother_checkbox_marriage_CheckedChanged(object sender, EventArgs e)
        {
            if (father_checbox.Checked == true)
                father_panel_baptism.Visible = true;
            else
                father_panel_baptism.Visible = false;
        }
    }
}
