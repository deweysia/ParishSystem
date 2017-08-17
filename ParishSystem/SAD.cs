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

        /// <summary>
        /// Returns the requirement Check Box objects in the Panel as a series of 1 and 0's
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string getRequirements(Panel p)
        {
            string r = "";
            foreach (CheckBox c in p.Controls)
                r += c.Checked ? "1" : "0";

            return r;
        }
        /// <summary>
        /// Checks if all requirement CheckBoxes are Checked
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private bool allRequirementsFulfilled(Panel p)
        {
            bool fulfilled = true;
            foreach (CheckBox c in p.Controls)
            {
                fulfilled = fulfilled && c.Checked;
            }

            return fulfilled;
        }

        /// <summary>
        /// Changes the Check property of checkAll according to the Check state of TableLayoutPanel CheckBoxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="checkAll"></param>
        /// <param name="tlp"></param>
        private void requirementCheckChanged(CheckBox sender, CheckBox checkAll, TableLayoutPanel tlp)
        {
            if (!sender.Focused)
                return;

            bool allChecked = true;
            foreach (CheckBox c in tlp.Controls)
            {
                allChecked = allChecked && c.Checked;
            }

            checkAll.Checked = allChecked;
        }

        /// <summary>
        /// Loads the 1 and 0's of requirements into their respective CheckBox objects.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="requirements"></param>
        private void tickRequirements(Panel p, string requirements)
        {
            bool allChecked = true;
            foreach (CheckBox c in p.Controls)
            {
                int i = p.Controls.GetChildIndex(c);
                c.Checked = requirements[i] == '1';
                allChecked &= c.Checked;
            }

            baptismApplication_checkAll_checkBox.Checked = allChecked;
        }

        



        /// <summary>
        /// Saves changes of requirements to the database
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="tb"></param>
        /// <returns></returns>
        private bool editRequirements(DataGridView dgv, TableLayoutPanel tb)
        {
            int applicationID = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            int profileID = int.Parse(dgv.SelectedRows[0].Cells[1].Value.ToString());
            string r = getRequirements(tb);
            bool a = dh.editApplication(applicationID, r);

            return a;
        }

        /// <summary>
        /// Opens an ApplicationPayment Form based on SacramentType
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dgv"></param>
        private void payApplication(SacramentType type, DataGridView dgv)
        {
            DataGridViewRow dgvr = dgv.SelectedRows[0];
            ApplicationPayment ap = new ApplicationPayment(type, dgvr, dh);
            DialogResult dr = ap.ShowDialog();
            Control parent = dgv.Parent;

            foreach(Control c in parent.Controls)
            {
                if(c.Tag != null && c.Tag.ToString() == "Details")
                {
                    RecursiveClearControl(c);
                    break;
                }
            }
            
        }




        /// <summary>
        /// Handles process for Edit Requirements button
        /// </summary>
        /// <param name="type"></param>
        private void applicationEditRequirementsClick(SacramentType type)
        {
            Button editBtn;
            DataGridView dgv;
            GroupBox gb;
            TableLayoutPanel tlpRequirements;
            TableLayoutPanel tlpProfile = null;
            FlowLayoutPanel flp;
            switch (type)
            {
                case SacramentType.Baptism:
                    editBtn = baptismApplication_editReq_button;
                    dgv = baptismApplication_dgv;
                    gb = baptismApplication_requirements_groupbox;
                    tlpRequirements = baptismApplication_requirements_tablePanel;
                    tlpProfile = baptismApplication_profile_tlp;
                    flp = baptismApplication_approveRevoke_panel;
                    break;
                case SacramentType.Confirmation:
                    editBtn = confirmationApplication_editReq_btn;
                    dgv = confirmationApplication_dgv;
                    gb = confirmationApplication_requirements_groupbox;
                    tlpRequirements = confirmationApplication_requirements_tablePanel;
                    flp = confirmationApplication_approveRevoke_panel;
                    break;
                default:
                    editBtn = marriageApplication_editReq_btn;
                    dgv = marriageApplication_dgv;
                    gb = marriageApplication_requirements_groupbox;
                    tlpRequirements = marriageApplication_requirements_tablePanel;
                    flp = marriageApplication_approveRevoke_panel;
                    break;
            }

            MessageBox.Show(editBtn.Tag.ToString());
            bool inSaveState = editBtn.Tag.ToString() == "Save State";
            gb.Enabled = !inSaveState;
            flp.Enabled = inSaveState;
            tlpProfile.Visible = inSaveState;

            if (!inSaveState)
            {
                editBtn.Text = "Save Changes";
                editBtn.Tag = "Save State";
                
            }
            else
            {
                editBtn.Text = "Edit Requirements";
                editBtn.Tag = "Edit State";
                bool success = editRequirements(dgv, tlpRequirements);

                if (success)
                    Notification.Show("Successfully Applied Edits!", NotificationType.success);
                else
                    Notification.Show("Something went wrong!", NotificationType.error);
            }
        }

        public void editApplicationProfile(SacramentType type)
        {
            TableLayoutPanel tlpProfile;
            GroupBox gbRequirements;
            FlowLayoutPanel flpApproveRevoke;
            Button btnEdit = new Button();
            

            string fn;
            
            
            if(type == SacramentType.Baptism)
            {
                btnEdit = baptismApplication_edit_btn;
                tlpProfile = baptismApplication_profile_tlp;
                flpApproveRevoke = baptismApplication_approveRevoke_panel;
                gbRequirements = baptismApplication_requirements_groupbox;
            }else if(type == SacramentType.Confirmation)
            {
                btnEdit = confirmationApplication_edit_btn;
                tlpProfile = confirmationApplication_profile_tlp;
                flpApproveRevoke = confirmationApplication_approveRevoke_panel;
                gbRequirements = confirmationApplication_requirements_groupbox;
            }else
            {
                //MARRIAGE
                btnEdit = marriageApplication_edit_btn;
                tlpProfile = marriageApplication_profile_tlp;
                flpApproveRevoke = marriageApplication_approveRevoke_panel;
                gbRequirements = marriageApplication_requirements_groupbox;
            }

            //If in view state, enter edit state by negation
            bool enableEdit = btnEdit.Tag.ToString() == "Edit";

            flpApproveRevoke.Enabled = !enableEdit;
            //If Tag is View, do Edits and change Tag to Edit
            if (enableEdit)
            {
                tlpProfile.BringToFront();
                btnEdit.Text = "Save";
                btnEdit.Tag = "Save";
                
            }
            else
            {
                tlpProfile.SendToBack();
                btnEdit.Text = "Edit";
                btnEdit.Tag = "Edit";

            }
        }

        public bool editApplicationProfile(SacramentType type)
        {
            bool success = true;
            if (type == SacramentType.Baptism)
            {
                string fn = baptismApplication_firstName_textBox.Text;
                string mi = baptismApplication_midName_textBox.Text;
                string ln = baptismApplication_lastName_textBox.Text;
                string suffix = baptismApplication_suffix_textBox.Text;
                Gender g = baptismApplication_male_radio.Checked ? Gender.Male : Gender.Female;
                DateTime birthDate = baptismApplication_birthDate.Value;

                int profileID = dh.getGeneralProfileID(fn, mi, ln, suffix, g, birthDate);

                if (profileID != -1)
                {
                    Notification.Show("Profile already exists", NotificationType.error);
                    return false;
                }

                success &= dh.editGeneralProfile(profileID, fn, mi, ln, suffix, g, birthDate);
            }
            else if(type == SacramentType.Confirmation)
            {
                string fn = confirmationApplication_firstName_textBox.Text;
                string mi = confirmationApplication_mi_textBox.Text;
                string ln = confirmationApplication_lastname_textBox.Text;
                string suffix = confirmationApplication_suffix_textBox.Text;
                Gender g = confirmationApplication_male_radio.Checked ? Gender.Male : Gender.Female;
                DateTime birthDate = confirmationApplication_birthDate_dtp.Value;

                int profileID = dh.getGeneralProfileID(fn, mi, ln, suffix, g, birthDate);

                if (profileID != -1){
                    Notification.Show("Profile already exists", NotificationType.error);
                    return false;
                }

                success &= dh.editGeneralProfile(profileID, fn, mi, ln, suffix, g, birthDate);
            }
            else //Marriage
            {
                string gfn = txtGFN.Text;
                string gmi = txtGMI.Text;
                string gln = txtGLN.Text;
                string gsuffix = txtGSuffix.Text;
                DateTime gbd = dtpGBirthDate.Value;
                int gID = dh.getGeneralProfileID(gfn, gmi, gln, gsuffix, Gender.Male, gbd);

                if(gID != -1)
                {
                    Notification.Show("Groom profile already exists", NotificationType.error);
                    return false;
                }

                string bfn = txtBFN.Text;
                string bmi = txtBMI.Text;
                string bln = txtBLN.Text;
                string bsuffix = txtBSuffix.Text;
                DateTime bbd = dtpBBirthDate.Value;
                int bID = dh.getGeneralProfileID(bfn, bmi, bln, bsuffix, Gender.Female, bbd);

                if (bID != -1)
                {
                    Notification.Show("Bride profile already exists", NotificationType.error);
                    return false;
                }

                success &= dh.editGeneralProfile(gID, gfn, gmi, gln, gsuffix, Gender.Male, gbd);
                success &= dh.editGeneralProfile(bID, bfn, bmi, bln, bsuffix, Gender.Female, bbd);
            }

            if (success)
            {
                Notification.Show("Successfully applied changes", NotificationType.success);
            }
            else
            {
                Notification.Show("Something went wrong", NotificationType.warning);
            }

            return success;
        }

        public bool generalProfileExistsPrompt(string firstName, string midName, string lastName, string suffix, Gender gender, DateTime birthDate)
        {
            if(dh.generalProfileExists(firstName, midName, lastName, suffix, gender, birthDate)){
                Notification.Show("Profile already exists", NotificationType.error);
                return true;
            }
            else
            {
                Notification.Show("Successfully applied changes", NotificationType.success);
                return false;
            }
        }







        // APPLICATION EDIT BUTTON CLICK=========================================================================================
        private void baptismApplication_editReq_button_Click(object sender, EventArgs e)
        {

            applicationEditRequirementsClick(SacramentType.Baptism);
        }

        private void confirmationApplication_editReq_btn_Click(object sender, EventArgs e)
        {
            applicationEditRequirementsClick(SacramentType.Confirmation);
        }

        private void marriageApplication_editReq_btn_Click(object sender, EventArgs e)
        {

            applicationEditRequirementsClick(SacramentType.Marriage);
        }
        // =======================================================================================================================







        // DGV CELL FORMATTING ==================================================================================================
        private void baptismApplication_dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {//Might be really slow!
            if (e.ColumnIndex == 7)//Gender
                e.Value = e.Value.ToString() == "1" ? "M" : "F";
            else
            {
                switch (e.Value.ToString())
                {
                    case "1":
                        e.Value = "P";
                        break;
                    case "2":
                        e.Value = "A";
                        break;
                    case "3":
                        e.Value = "F";
                        break;
                    case "4":
                        e.Value = "R";
                        break;
                }
            }
        }

        private void confirmationApplication_dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            baptismApplication_dgv_CellFormatting(sender, e);
        }

        private void marriageApplication_dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                switch (e.Value.ToString())
                {
                    case "1":
                        e.Value = "P";
                        break;
                    case "2":
                        e.Value = "A";
                        break;
                    case "3":
                        e.Value = "F";
                        break;
                    case "4":
                        e.Value = "R";
                        break;
                }
            }
        }
        //=====================================================================================================================





        // APPROVE BUTTON CLICK ===============================================================================================

        private void confirmationApplication_approve_btn_Click(object sender, EventArgs e)
        {
            applicationApprove(SacramentType.Confirmation, confirmationApplication_dgv, confirmationApplication_requirements_tablePanel);
        }

        private void marriageApplication_approve_btn_Click(object sender, EventArgs e)
        {
            applicationApprove(SacramentType.Marriage, marriageApplication_dgv, marriageApplication_requirements_tablePanel);
        }

        private void baptismApplication_approve_button_Click(object sender, EventArgs e)
        {
            applicationApprove(SacramentType.Baptism, baptismApplication_dgv, baptismApplication_requirements_tablePanel);
        }
        //=====================================================================================================================




        // APPLICATION CHECKALL CHECK CHANGED =================================================================================

        private void baptismApplication_checkAll_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            checkAllCheckChanged(baptismApplication_checkAll_checkBox, baptismApplication_requirements_tablePanel);
        }

        private void confirmationApplication_checkAll_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            checkAllCheckChanged(confirmationApplication_checkAll_checkBox, confirmationApplication_requirements_tablePanel);
        }

        private void marriageApplication_checkAll_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            checkAllCheckChanged(marriageApplication_checkAll_checkBox, marriageApplication_requirements_tablePanel);
        }
        //=====================================================================================================================





        // APPLICATION REQUIREMENT CHECK CHANGED =================================================================================
        private void baptismApplication_requirement_checkBox_CheckedChanged(object sender, EventArgs e)
        {

            requirementCheckChanged((CheckBox)sender, baptismApplication_checkAll_checkBox, baptismApplication_requirements_tablePanel);

        }

        private void confirmationApplication_requirement_checkBox_CheckChanged(object sender, EventArgs e)
        {
            requirementCheckChanged((CheckBox)sender, confirmationApplication_checkAll_checkBox, confirmationApplication_requirements_tablePanel);
        }

        private void marriage_requirement_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            requirementCheckChanged((CheckBox)sender, marriageApplication_checkAll_checkBox, marriageApplication_requirements_tablePanel);
        }

        //=====================================================================================================================





        // APPLICATION REVOKE BUTTON CLICK=====================================================================================
        private void baptismApplication_revoke_button_Click(object sender, EventArgs e)
        {
            applicationRevoke(SacramentType.Baptism, baptismApplication_dgv);
        }

        private void confirmationApplication_revoke_btn_Click(object sender, EventArgs e)
        {
            applicationRevoke(SacramentType.Confirmation, confirmationApplication_dgv);
        }


        private void marriageApplication_revoke_btn_Click(object sender, EventArgs e)
        {
            applicationRevoke(SacramentType.Marriage, marriageApplication_dgv);
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

            Sacrament s = new Sacrament(dh);
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

            SacramentApplication s = new SacramentApplication(dh);
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
