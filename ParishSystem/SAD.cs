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
using MetroFramework.Controls;

namespace ParishSystem
{
    public partial class SAD : Form
    {
        DataHandler dh = new DataHandler("localhost", "sad2", "root", "root");
        Point lastClick;

        Dictionary<Button, Panel> navigation = new Dictionary<Button, Panel>();

        public SAD()
        {
            InitializeComponent();
            

            //Add dictionary for navigation buttons
            navigation.Add(home_button_menu, profile_panel);
            navigation.Add(profile_menu_button, profile_panel);
            navigation.Add(bloodletting_button_menu, bloodletting_panel);
            navigation.Add(CDB_button_menu, CDB_panel);
            navigation.Add(CRB_button_menu, CRB_panel);
            navigation.Add(application_button_menu, application_panel);
            navigation.Add(sacrament_button_menu, sacrament_panel);
            

        }

        #region generic Methods
        public void Names_textbox_Leave(object sender, EventArgs e)
        {
            TextBox A = sender as TextBox;
            string B = A.Name.Split('_')[0];
            if (A.Text.Trim().Equals(""))
            {
                A.Text = B;
                A.ForeColor = Color.Silver;
            }
        }

        public void Names_textbox_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox A = sender as TextBox;
            if (A.Text.Equals(A.Name.Split('_')[0]))
            {
                A.Text = "";
                A.ForeColor = Color.Black;
            }
        }

        #endregion

        #region Effects
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

        /// <summary>
        /// Changes panel based on Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void home_button_menu_Click(object sender, EventArgs e)
        {
            Button A = sender as Button;
            navigation[A].BringToFront();
        }


        #endregion


        #region Form
        //-------------------------Main Form---------------------------//

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Max_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel_controlbox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastClick.X;
                this.Top += e.Y - lastClick.Y;
            }
        }

        private void panel_controlbox_MouseDown(object sender, MouseEventArgs e)
        {
            lastClick = new Point(e.X, e.Y);
        }

        #endregion


        #region Profiles

        private void resetProfilesVariables()
        {//reset variables used by profiles tab
            lastGeneralProfile = 0;
        }

        int lastGeneralProfile = 0;

        private void refreshGeneralProfileTable()
        {//refresh general profile table
            DataTable dt = dh.getGeneralProfiles();
            generalprofile_datagridview.DataSource = dt;
            generalprofile_datagridview.Columns["profileID"].Visible = false;
            generalprofile_datagridview.Columns["firstName"].Visible = false;
            generalprofile_datagridview.Columns["midName"].Visible = false;
            generalprofile_datagridview.Columns["lastName"].Visible = false;
            generalprofile_datagridview.Columns["suffix"].Visible = false;
            generalprofile_datagridview.Columns["gender"].Visible = false;
            generalprofile_datagridview.Columns["birthdate"].Visible = false;
            generalprofile_datagridview.Columns["contactNumber"].Visible = false;
            generalprofile_datagridview.Columns["address"].Visible = false;
            generalprofile_datagridview.Columns["birthplace"].Visible = false;
            generalprofile_datagridview.Columns["bloodtype"].Visible = false;
            generalprofile_datagridview.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void generalprofile_datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {//data grid cell click
            openProfile_button.Enabled = true;
            deleteProfile_button.Enabled = true;
            lastGeneralProfile = int.Parse(generalprofile_datagridview.CurrentRow.Cells["profileID"].Value.ToString());
            //label changes
            firstname_label_profile.Text = generalprofile_datagridview.CurrentRow.Cells["firstname"].Value.ToString();
            middlename_label_profile.Text = generalprofile_datagridview.CurrentRow.Cells["midname"].Value.ToString();
            lastname_label_profile.Text = generalprofile_datagridview.CurrentRow.Cells["lastname"].Value.ToString();
            suffix_label_profile.Text = generalprofile_datagridview.CurrentRow.Cells["suffix"].Value.ToString();

            if (!generalprofile_datagridview.CurrentRow.Cells["gender"].Value.ToString().Equals("0"))
                gender_label_profiles.Text = generalprofile_datagridview.CurrentRow.Cells["gender"].Value.ToString().ToUpper();
            else
                gender_label_profiles.Text = "";

            Console.WriteLine(DateTime.MinValue.ToString());
            Console.WriteLine(generalprofile_datagridview.CurrentRow.Cells["birthdate"].Value.ToString());
            Console.WriteLine(DateTime.MinValue.ToString().Equals(generalprofile_datagridview.CurrentRow.Cells["birthdate"].Value.ToString()));

            if (!generalprofile_datagridview.CurrentRow.Cells["birthdate"].Value.ToString().Equals(DateTime.MinValue.ToString()))
                birthday_label_profile.Text = generalprofile_datagridview.CurrentRow.Cells["birthdate"].Value.ToString();
            else
                birthday_label_profile.Text = "";

            contactNumber_label_profile.Text = generalprofile_datagridview.CurrentRow.Cells["contactnumber"].Value.ToString();
            address_label_profile.Text = generalprofile_datagridview.CurrentRow.Cells["address"].Value.ToString();
            birthplace_label_profile.Text = generalprofile_datagridview.CurrentRow.Cells["birthplace"].Value.ToString();
            bloodtype_label_profile.Text = generalprofile_datagridview.CurrentRow.Cells["bloodtype"].Value.ToString();
            Console.WriteLine(lastGeneralProfile);
        }

        private void addProfile_button_Click(object sender, EventArgs e)
        {//adds basic profile with name values only 
            if (suffix_textbox.Text.Equals("suffix")) { suffix_textbox.Text = null; }
            if (firstname_textbox.Text.Equals("firstname")) { firstname_tooltip_profiles.Active = true; suffix_textbox.Text = "suffix"; }
            if (middlename_textbox.Text.Equals("middlename")) { middlename_tooltip_profiles.Active = true; suffix_textbox.Text = "suffix"; }
            if (lastname_textbox.Text.Equals("lastname")) { lastname_tooltip_profiles.Active = true; suffix_textbox.Text = "suffix"; }


            if (!firstname_textbox.Text.Equals("firstname") && !middlename_textbox.Text.Equals("middlename") && !lastname_textbox.Text.Equals("lastname"))
            {
                //dh.addGeneralProfile(firstname_textbox.Text, middlename_textbox.Text, lastname_textbox.Text, suffix_textbox.Text, '0', DateTime.MinValue, null, null, null);
                refreshGeneralProfileTable();
                AddPNL.Visible = false;
            }

        }




        private void openProfile_button_Click(object sender, EventArgs e)
        {//open person complete profile

            Form person = new PersonView(lastGeneralProfile, dh);
            person.ShowDialog();



        }

        private void deleteProfile_button_Click(object sender, EventArgs e)
        {
            dh.deleteGeneralProfile(lastGeneralProfile);
            refreshGeneralProfileTable();
            lastGeneralProfile = 0;
            deleteProfile_button.Enabled = false;
            openProfile_button.Enabled = false;
        }


        private void clearProfile()
        {
            lastname_textbox.Text = "lastname";
            middlename_textbox.Text = "middlename";
            firstname_textbox.Text = "firstname";
            suffix_textbox.Text = "suffix";
            lastGeneralProfile = 0;
        }

        private void clear_profile_button_Click(object sender, EventArgs e)
        {
            AddPNL.Visible = false;

        }
        
        //======================================================================================================================




        #endregion

        private void AddBTN_Click(object sender, EventArgs e)
        {
            AddPNL.BringToFront();
            AddPNL.Visible = true;
        }

        private void Name_textbox_Profile_TextChanged(object sender, EventArgs e)
        {
            if (firstname_textbox.Text != "firstname" && firstname_textbox.Text.Trim() != "" &&
               middlename_textbox.Text != "middlename" && middlename_textbox.Text.Trim() != "" &&
               lastname_textbox.Text != "lastname" && lastname_textbox.Text.Trim() != "")
            {
                save_button_profile.Enabled = true;
            }
            else
            {
                save_button_profile.Enabled = false;
            }
        }

        private void sacrament_panel_VisibleChanged(object sender, EventArgs e)
        {

        }

        
        private void panelSacrament_VisibleChanged(object sender, EventArgs e)
        {
            while (sacrament_panel.Controls.Count > 0)
            {
                sacrament_panel.Controls[0].Dispose();
            }

            SacramentModule s = new SacramentModule(dh);
            s.FormBorderStyle = FormBorderStyle.None;
            s.TopLevel = false;
            s.AutoScroll = true;
            sacrament_panel.Controls.Add(s);
            s.Dock = DockStyle.Fill;
            s.Show();
        }

        private void application_panel_VisibleChanged(object sender, EventArgs e)
        {

            while (application_panel.Controls.Count > 0)
            {
                application_panel.Controls[0].Dispose();
            }

            ApplicationModule s = new ApplicationModule(dh);
            s.FormBorderStyle = FormBorderStyle.None;
            s.TopLevel = false;
            s.AutoScroll = true;
            application_panel.Controls.Add(s);
            s.Dock = DockStyle.Fill;
            s.Show();
        }

        private void panel_controlbox_Paint(object sender, PaintEventArgs e)
        {

        }






        /*private bool sacramentApplicationApplyChanges(SacramentType type, TableLayoutPanel tlpProfile, GroupBox gbReq)
        {
            bool success;

            //Checks for Empty TextBoxes
            foreach (Control con in tlpProfile.Controls)
            {
                if (con is CueTextBox)
                {
                    CueTextBox ctxt = con as CueTextBox;
                    if (ctxt.isEmpty())
                        return false;
                }
            }

            string fn, mn, ln, suffix;
            DateTime bdate;
            Gender gender;
            if(type == SacramentType.Baptism)
            {
                fn = baptismApplication_firstName_textBox.Text;
                mn = baptismApplication_midName_textBox.Text;
                ln = baptismApplication_lastName_textBox.Text;
                suffix = baptismApplication_suffix_textBox.Text;
                bdate = baptismApplication_birthDate_dtp.Value;
                gender = baptismApplication_male_radio.Checked ? Gender.Male : Gender.Female;
            }else if(type == SacramentType.Confirmation)
            {
                fn = confirmationApplication_firstName_textBox.Text;
                mn = confirmationApplication_midName_textBox.Text;
                ln = confirmationApplication_lastName_textBox.Text;
                suffix = confirmationApplication_suffix_textBox.Text;
                bdate = confirmationApplication_birthDate_dtp.Value;
                gender = confirmationApplication_male_radio.Checked ? Gender.Male : Gender.Female;

            }else
            {
                string gFN, gMN, gLN, gSuffix, bFN, bMN, bLN, bSuffix;
                DateTime gBD, bBD;
                gFN = txtGFN.Text;
                gMN = txtGMI.Text;
                gLN = txtGLN.Text;
                gSuffix = txtGSuffix.Text;
                gBD = dtpGBirthDate.Value;

                bFN = txtBFN.Text;
                bMN = txtBMI.Text;
                bLN = txtBLN.Text;
                bSuffix = txtBSuffix.Text;
                bBD = dtpBBirthDate.Value;

                
            }


        }*/






    }
}
