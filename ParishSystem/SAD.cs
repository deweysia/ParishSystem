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
        DataHandler dh = new DataHandler("localhost", "sad2", "root", "root");
        Point lastClick;

        public SAD()
        {
            InitializeComponent();
            BaptismApplication_birthDate.MaxDate = DateTime.Now;


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

        private void panel_menu_Click(object sender, EventArgs e)
        {
            Panel A = sender as Panel;
            if (A.Equals(home_button_menu)) { home_panel.BringToFront(); }
            else if (A.Equals(profile_button_menu))
            {
                profile_panel.BringToFront();
                refreshGeneralProfileTable();
            }
            else if (A.Equals(bloodletting_button_menu)) { bloodletting_panel.BringToFront(); }
            else if (A.Equals(CDB_button_menu)) { CDB_panel.BringToFront(); }
            else if (A.Equals(CRB_button_menu)) { CRB_panel.BringToFront(); }
            else if (A.Equals(application_button_menu)) { application_panel.BringToFront(); }

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

        private void navBarPanel_MouseEnter(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;

            p.BackColor = Color.SteelBlue;

        }

        private void narBar_MouseLeave(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;

            p.BackColor = Color.DodgerBlue;
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
                dh.addGeneralProfile(firstname_textbox.Text, middlename_textbox.Text, lastname_textbox.Text, suffix_textbox.Text, '0', DateTime.MinValue, null, null, null);
                refreshGeneralProfileTable();
                AddPNL.Visible = false;
            }

        }




        private void openProfile_button_Click(object sender, EventArgs e)
        {//open person complete profile

            Form person = new Person(lastGeneralProfile, dh);
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












        #endregion


        #region Application
        //----------------------APPLICATION------------------------//
        private void applicationMenu_labelClick(object sender, EventArgs e)
        {
            Label A = sender as Label;
            if (A.Equals(baptismApplication_label))
            {
                //label changes
                baptismApplication_label.Font = new Font(baptismApplication_label.Font, FontStyle.Bold);
                baptismApplication_label.ForeColor = Color.DodgerBlue;
                confirmationApplication_label.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                confirmationApplication_label.ForeColor = Color.Black;
                marriageApplication_label.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                marriageApplication_label.ForeColor = Color.Black;

                //panel changes
                // sacramentApplication_panel.BringToFront();
                Console.WriteLine("BA)P");
                applicationsHiddenTabControl.se
                baptismApplicationTab.Focus();

            }
            else if (A.Equals(confirmationApplication_label))
            {
                //label changes
                baptismApplication_label.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                baptismApplication_label.ForeColor = Color.Black;
                confirmationApplication_label.Font = new Font(baptismApplication_label.Font, FontStyle.Bold);
                confirmationApplication_label.ForeColor = Color.DodgerBlue;
                marriageApplication_label.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                marriageApplication_label.ForeColor = Color.Black;

                //panel changes
                //sacramentApplication_panel.BringToFront();
                confirmationApplicationTab.Focus();

            }
            else if (A.Equals(marriageApplication_label))
            {
                //label changes
                baptismApplication_label.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                baptismApplication_label.ForeColor = Color.Black;
                confirmationApplication_label.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                confirmationApplication_label.ForeColor = Color.Black;
                marriageApplication_label.Font = new Font(baptismApplication_label.Font, FontStyle.Bold);
                marriageApplication_label.ForeColor = Color.DodgerBlue;

                //panel changes
                //marriageApplication_panel.BringToFront();
                marriageApplicationTab.Focus();

            }
        }

        private void newApplicant_checkbox_confirmationApplication_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox A = sender as CheckBox;
            //baptism application
            /*if (A.Equals(newApplicant_checkbox_baptismApplication))
            {
                if (A.Checked == true)
                {
                    existingName_panel_baptismApplication.Enabled = false;
                    newName_panel_baptismApplication.Visible = true;
                }
                else if (A.Checked == false)
                {
                    existingName_panel_baptismApplication.Enabled = true;
                    newName_panel_baptismApplication.Visible = false;
                }

            }*/
            //confirmation application
            /*if (A.Equals(newApplicant_checkbox_confirmationApplication)) {
                if (A.Checked==true) {
                    existingName_panel_confirmationApplication.Enabled = false;
                    newName_panel_confirmationApplication.Visible = true;
                }
                else if(A.Checked == false)
                {
                    existingName_panel_confirmationApplication.Enabled = true;
                    newName_panel_confirmationApplication.Visible = false;
                }
                
            }
            //marriage application
            //-groom
            else */
            if (A.Equals(newGroom_checkbox_marriageApplication))
            {
                if (A.Checked == true)
                {
                    groomExisting_panel_marriageApplication.Enabled = false;
                    groomNew_panel_marriageApplication.Visible = true;
                }
                else if (A.Checked == false)
                {
                    groomExisting_panel_marriageApplication.Enabled = true;
                    groomNew_panel_marriageApplication.Visible = false;
                }

            }
            //-bride
            else if (A.Equals(newBride_checkbox_marriageApplication))
            {
                if (A.Checked == true)
                {
                    brideExisting_panel_marriageApplication.Enabled = false;
                    brideNew_panel_marriageApplication.Visible = true;
                }
                else if (A.Checked == false)
                {
                    brideExisting_panel_marriageApplication.Enabled = true;
                    brideNew_panel_marriageApplication.Visible = false;
                }

            }

        }
        #endregion


        #region CDB
        //--------------------------CDB----------------------------//
        private void label_CD_Click(object sender, EventArgs e)
        {
            Label A = sender as Label;
            if (A.Equals(parish_label_CD))
            {
                //label changes
                parish_label_CD.Font = new Font(baptismApplication_label.Font, FontStyle.Bold);
                parish_label_CD.ForeColor = Color.DodgerBlue;
                community_label_CD.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                community_label_CD.ForeColor = Color.Black;
                postulancy_label_CD.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                postulancy_label_CD.ForeColor = Color.Black;

                //panel changes
                parish_panel_CD.BringToFront();
            }
            else if (A.Equals(community_label_CD))
            {
                //label changes
                parish_label_CD.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                parish_label_CD.ForeColor = Color.Black;
                community_label_CD.Font = new Font(baptismApplication_label.Font, FontStyle.Bold);
                community_label_CD.ForeColor = Color.DodgerBlue;
                postulancy_label_CD.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                postulancy_label_CD.ForeColor = Color.Black;

                //panel changes
                community_panel_CD.BringToFront();
            }
            else if (A.Equals(postulancy_label_CD))
            {
                //label changes
                parish_label_CD.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                parish_label_CD.ForeColor = Color.Black;
                community_label_CD.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                community_label_CD.ForeColor = Color.Black;
                postulancy_label_CD.Font = new Font(baptismApplication_label.Font, FontStyle.Bold);
                postulancy_label_CD.ForeColor = Color.DodgerBlue;

                //panel changes
                postulancy_panel_CD.BringToFront();
            }
        }






        #endregion

        #region CRB
        //--------------------------CRB----------------------------//

        #endregion

        private void AddBTN_Click(object sender, EventArgs e)
        {
            AddPNL.BringToFront();
            AddPNL.Visible = true;
        }

        private void panel_controlbox_Paint(object sender, PaintEventArgs e)
        {

        }

        private void home_button_menu_Click(object sender, EventArgs e)
        {
            Button A = sender as Button;
            if (A.Equals(home_button_menu)) { home_panel.BringToFront(); }
            else if (A.Equals(profile_button_menu))
            {
                profile_panel.BringToFront();
                refreshGeneralProfileTable();
            }
            else if (A.Equals(bloodletting_button_menu)) { bloodletting_panel.BringToFront(); }
            else if (A.Equals(CDB_button_menu)) { CDB_panel.BringToFront(); }
            else if (A.Equals(CRB_button_menu)) { CRB_panel.BringToFront(); }
            else if (A.Equals(application_button_menu)) {
                application_panel.BringToFront();
                refreshApplicationProfile();
            }
            else if (A.Equals(sacrament_button_menu)) { sacrament_panel.BringToFront(); }
        }
        private void refreshApplicationProfile()
        {
            sacramentApplication_dgv.DataSource = dh.getApplications();
        }

        private void firstname_textbox_Click(object sender, EventArgs e)
        {


        }



        private void firstname_textbox_TextChanged(object sender, EventArgs e)
        {


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



        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void libraryBaptismButton_Click(object sender, EventArgs e)
        {
            DataTable dt = dh.getBaptisms();
            //dgvSacraments.DataSource = dt;
            metroGrid1.DataSource = dt;
        }

        private void libraryConfirmationButton_Click(object sender, EventArgs e)
        {
            DataTable dt = dh.getConfirmations();
            //dgvSacraments.DataSource = dt;
            metroGrid1.DataSource = dt;
        }

        private void libraryMarriageButton_Click(object sender, EventArgs e)
        {

            //dgvSacraments.DataSource = dt;

        }

        private void generalprofile_datagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void baptismApplication_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkAll_cb_baptismApplication_CheckedChanged(object sender, EventArgs e)
        {
            bool allChecked = true;

            if (!baptismApplication_checkAll_comboBox.Checked)
            {

                foreach (CheckBox c in BaptismApplication_Requirements_tablePanel.Controls)
                    allChecked = allChecked && c.Checked;
            }

            if (!allChecked) return;

            foreach (CheckBox c in BaptismApplication_Requirements_tablePanel.Controls)
            {
                c.Checked = baptismApplication_checkAll_comboBox.Checked;
                Console.WriteLine("ENTERED");
            }
        }

        private void baptismApplication_requirement_comboBox_CheckedChanged(object sender, EventArgs e)
        {
            //baptismApplication_checkAll_comboBox.Checked = !(sender as CheckBox).Checked;

            CheckBox temp = sender as CheckBox;
            if (!temp.Checked && baptismApplication_checkAll_comboBox.Checked)
                baptismApplication_checkAll_comboBox.Checked = false;


        }

        private void sacramentApplication_add_button_Click(object sender, EventArgs e)
        {
            AddApplication aa = new AddApplication(SacramentType.Baptism);
            DialogResult dr = aa.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddApplication aa = new AddApplication(SacramentType.Confirmation);
            DialogResult dr = aa.ShowDialog();
            MessageBox.Show("Bitch done");


        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form A = new Person(int.Parse(sacramentApplication_dgv.SelectedRows[0].Cells["profileID"].Value.ToString()),dh);
            A.ShowDialog();
        }
    }
}
