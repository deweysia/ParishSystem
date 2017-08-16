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
            baptismApplication_birthDate.MaxDate = DateTime.Now.Date;

            //Add dictionary for navigation buttons
            navigation.Add(home_button_menu, profile_panel);
            navigation.Add(profile_menu_button, profile_panel);
            navigation.Add(bloodletting_button_menu, bloodletting_panel);
            navigation.Add(CDB_button_menu, CDB_panel);
            navigation.Add(CRB_button_menu, CRB_panel);
            navigation.Add(application_button_menu, application_panel);
            navigation.Add(sacrament_button_menu, sacrament_panel);
            baptismApplication_dgv.Size = new Size(493, 380);
            baptismApplication_dgv.Location = new Point(3, 56);

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












        #endregion


        /*
                                         =============================================================
                                                ================ APPLICATION TAB =================
                                         =============================================================
        */

        #region Application

        /// <summary>
        /// Loads all baptism applications to Baptism DataGridView
        /// </summary>
        public void loadBaptismApplications()
        {
            baptismApplication_dgv.AutoGenerateColumns = false;
            BindingSource bs = new BindingSource();
            bs.DataSource = dh.getApplications(SacramentType.Baptism);
            baptismApplication_dgv.DataSource = bs;
            baptismApplication_filter_comboBox.SelectedIndex = 0;
        }
        /// <summary>
        /// Loads all confirmation applications to Confirmation DataGridView
        /// </summary>
        public void loadConfirmationApplications()
        {
            confirmationApplication_dgv.AutoGenerateColumns = false;
            BindingSource bs = new BindingSource();
            bs.DataSource = dh.getApplications(SacramentType.Confirmation);
            confirmationApplication_dgv.DataSource = bs;
            confirmationApplication_filter.SelectedIndex = 0;
        }

        /// <summary>
        /// Loads all marriage applications to Marriage DataGridView
        /// </summary>
        private void loadMarriageApplications()
        {
            marriageApplication_dgv.AutoGenerateColumns = false;
            BindingSource bs = new BindingSource();
            bs.DataSource = dh.getApplications(SacramentType.Marriage);
            marriageApplication_dgv.DataSource = bs;
            marriageApplication_filter.SelectedIndex = 0;
        }
        /// <summary>
        /// Loads details of the SelectedRow in DataGridView to the Baptism Details Panel
        /// </summary>
        /// <param name="dgv"></param>
        public void loadBaptismApplicationDetails(DataGridView dgv)
        {
            
            int applicationID = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            string requirements = dgv.SelectedRows[0].Cells[2].Value.ToString();
            //MessageBox.Show(requirements);
            string fn = dgv.SelectedRows[0].Cells[3].Value.ToString();
            string mn = dgv.SelectedRows[0].Cells[4].Value.ToString();
            string ln = dgv.SelectedRows[0].Cells[5].Value.ToString();
            string suffix = dgv.SelectedRows[0].Cells[6].Value.ToString();
            string gender = dgv.SelectedRows[0].Cells[7].Value.ToString();
            DateTime birthdate = DateTime.ParseExact(dgv.SelectedRows[0].Cells[8].Value.ToString(), "yyyy-MM-dd", null);
            ApplicationStatus status = (ApplicationStatus)int.Parse(dgv.SelectedRows[0].Cells[9].Value.ToString());

            bool isPending = status == ApplicationStatus.Pending;

            if(baptismApplication_edit_btn.Tag.ToString() == "Save State")
            {
                baptismApplication_edit_btn.Tag = "Edit State";
            }

            baptismApplicationDetailsPanel.Enabled = isPending;
            baptismApplication_buttons_panel.Enabled = isPending;
            baptismApplication_payment_groupbox.Enabled = isPending;

            baptismApplication_firstName_textBox.Text = fn;
            baptismApplication_midName_textBox.Text = mn;
            baptismApplication_lastName_textBox.Text = ln;
            baptismApplication_suffix_textBox.Text = suffix;
            baptismApplication_birthDate.Value = birthdate;
            baptismApplication_male_radio.Checked = gender == "1";
            baptismApplication_female_radio.Checked = gender == "2";
            baptismApplication_status_label.Text = status.ToString();

            baptismApplication_name_lbl.Text = string.Format("{0} {1} {2} {3}", fn, mn, ln, suffix);
            baptismApplication_birthdate_lbl.Text = birthdate.ToString("yyyy-MM-dd");
            baptismApplication_gender_lbl.Text = gender == "1" ? "Male" : "Female";

            tickRequirements(baptismApplication_requirements_tablePanel, requirements);
            DataTable dt = dh.getApplicationIncomeDetails(applicationID);

            double price = double.Parse(dt.Rows[0]["price"].ToString());

            double totalPayment = double.Parse(dt.Rows[0]["totalPayment"].ToString());
            baptismApplication_addPayment_btn.Enabled = (price - totalPayment) != 0;
            baptismApplication_payment_label.Text = (price - totalPayment).ToString("C");
            baptismApplication_payment_remarks.Text = dt.Rows[0]["remarks"].ToString();
        }

        /// <summary>
        /// Loads details of the SelectedRow in DataGridView to the Confirmation Details Panel
        /// </summary>
        /// <param name="dgv"></param>
        private void loadConfirmationApplicationDetails(DataGridView dgv)
        {
            int applicationID = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            string requirements = dgv.SelectedRows[0].Cells[2].Value.ToString();
            string fn = dgv.SelectedRows[0].Cells[3].Value.ToString();
            string mn = dgv.SelectedRows[0].Cells[4].Value.ToString();
            string ln = dgv.SelectedRows[0].Cells[5].Value.ToString();
            string suffix = dgv.SelectedRows[0].Cells[6].Value.ToString();
            string gender = dgv.SelectedRows[0].Cells[7].Value.ToString();
            DateTime birthdate = DateTime.ParseExact(dgv.SelectedRows[0].Cells[8].Value.ToString(), "yyyy-MM-dd", null);
            ApplicationStatus status = (ApplicationStatus)int.Parse(dgv.SelectedRows[0].Cells[9].Value.ToString());

            bool isPending = status == ApplicationStatus.Pending;


            confirmationApplicationDetailsPanel.Enabled = isPending;
            confirmationApplication_buttons_panel.Enabled = isPending;
            confirmationApplication_payment_groupbox.Enabled = isPending;


            confirmationApplication_firstName_textBox.Text = fn;
            confirmationApplication_mi_textBox.Text = mn;
            confirmationApplication_lastname_textBox.Text = ln;
            confirmationApplication_suffix_textBox.Text = suffix;
            confirmationApplication_birthDate_dtp.Value = birthdate;
            confirmationApplication_male_radio.Checked = gender == "1";
            confirmationApplication_female_radio.Checked = gender == "2";
            confirmationApplication_status_label.Text = status.ToString();

            tickRequirements(confirmationApplication_requirements_tablePanel, requirements);

            
            DataTable dt = dh.getApplicationIncomeDetails(applicationID);

            double price = double.Parse(dt.Rows[0]["price"].ToString());

            double totalPayment = double.Parse(dt.Rows[0]["totalPayment"].ToString());
            confirmationApplication_addPayment_btn.Enabled = (price - totalPayment) != 0;
            confirmationApplication_payment_label.Text = (price - totalPayment).ToString("C");
            confirmationApplication_payment_remarks.Text = dt.Rows[0]["remarks"].ToString();
        }


        /// <summary>
        /// Loads details of the SelectedRow in DataGridView to the Marriage Details Panel
        /// </summary>
        /// <param name="dgv"></param>
        public void loadMarriageApplicationDetails(DataGridView dgv)
        {
            int applicationID = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            
            string requirements = dgv.SelectedRows[0].Cells[3].Value.ToString();

            string[] GName = dgv.SelectedRows[0].Cells[4].Value.ToString().Split(new char[] { ' ' });
            txtGFN.Text = GName[0];
            txtGMI.Text = GName[1];
            txtGLN.Text = GName[2];
            txtGSuffix.Text = GName[3];

            dtpGBirthDate.Value = DateTime.ParseExact(dgv.SelectedRows[0].Cells[5].Value.ToString(), "yyyy-MM-dd", null);

            string[] BName = dgv.SelectedRows[0].Cells[6].Value.ToString().Split(new char[] { ' ' });
            txtBFN.Text = BName[0];
            txtBMI.Text = BName[1];
            txtBLN.Text = BName[2];
            txtBSuffix.Text = BName[3];

            dtpBBirthDate.Value = DateTime.ParseExact(dgv.SelectedRows[0].Cells[7].Value.ToString(), "yyyy-MM-dd", null);

            ApplicationStatus status = (ApplicationStatus)int.Parse(dgv.SelectedRows[0].Cells[8].Value.ToString());

            bool isPending = status == ApplicationStatus.Pending;


            marriageApplicationDetailsPanel.Enabled = isPending;
            marriageApplication_buttons_panel.Enabled = isPending;
            marriageApplication_payment_groupbox.Enabled = isPending;


            tickRequirements(marriageApplication_requirements_tablePanel, requirements);
            
            DataTable dt = dh.getApplicationIncomeDetails(applicationID);

            double price = double.Parse(dt.Rows[0]["price"].ToString());

            double totalPayment = double.Parse(dt.Rows[0]["totalPayment"].ToString());
            marriageApplication_addPayment_btn.Enabled = (price - totalPayment) != 0;
            marriageApplication_price_label.Text = (price - totalPayment).ToString("C");
            marriageApplication_payment_remarks.Text = dt.Rows[0]["remarks"].ToString();
        }

        /// <summary>
        /// Approves and opens a certain SacramentForm based on SacramentType
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dgv"></param>
        /// <param name="tlp"></param>
        private void applicationApprove(SacramentType type, DataGridView dgv, TableLayoutPanel tlp)
        {

            int applicationID = int.Parse(dgv.SelectedRows[0].Cells[2].Value.ToString());
            DataGridViewRow dgvr = dgv.SelectedRows[0];
            DialogResult d = DialogResult.None;


            Form f;

            if (type == SacramentType.Baptism)
                f = new SacramentForm(SacramentType.Baptism ,dgvr, dh);
            else if (type == SacramentType.Confirmation)
                f = new SacramentForm(SacramentType.Confirmation, dgvr, dh);
            else
                f = new MarriageForm(dgvr, dh);

            if (allRequirementsFulfilled(tlp))
            {
                d = f.ShowDialog();
            }
            else
            {
                DialogResult dr = MessageDialog.Show("Not all requirements were fulfilled. Proceed anyway?", "Warning", MessageDialogButtons.YesNo, MessageDialogIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    d = f.ShowDialog();
                }
            }

            if (d == DialogResult.OK)
                Notification.Show(string.Format("Successfully Added {0}!", SacramentType.Marriage.ToString()), NotificationType.success);
        }

        /// <summary>
        /// Sets the status of an Application to Revoked
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dgv"></param>
        private void applicationRevoke(SacramentType type, DataGridView dgv)
        {
            int applicationID = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            bool success = dh.editApplication(applicationID, ApplicationStatus.Revoked);

            if (success)
                Notification.Show("Successfully revoked application.", NotificationType.success);
            else
                Notification.Show("Something went wrong!.", NotificationType.error);

            switch (type)
            {
                case SacramentType.Baptism:
                    loadBaptismApplications();
                    return;
                case SacramentType.Confirmation:
                    loadConfirmationApplications();
                    return;
                case SacramentType.Marriage:
                    loadMarriageApplications();
                    return;
            }
        }

        /// <summary>
        /// Applies Check property of CheckAll to the CheckBoxes in the TableLayout
        /// </summary>
        /// <param name="checkAll"></param>
        /// <param name="tlp"></param>
        private void checkAllCheckChanged(CheckBox checkAll, TableLayoutPanel tlp)
        {
            if (!checkAll.Focused)
                return;

            foreach (CheckBox c in tlp.Controls)
            {
                c.Checked = checkAll.Checked;
            }
        }

        /// <summary>
        /// Filters DataGridView on based on ComboBox SelectedIndex
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cb"></param>
        private void applicationFilter(DataGridView dgv, ComboBox cb)
        {
            BindingSource bs = dgv.DataSource as BindingSource;
            DataTable dt = bs.DataSource as DataTable;
            
            if(cb.SelectedIndex == 0)
                dt.DefaultView.RowFilter = "";
            else
                dt.DefaultView.RowFilter = "status = " + cb.SelectedIndex;

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
        /*
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
        */
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



        // APPLICATION ADD BUTTON CLICK=====================================================================================
        private void baptismApplication_add_button_Click(object sender, EventArgs e)
        {
            AddApplication aa = new AddApplication(SacramentType.Baptism, dh);
            aa.ShowDialog();
            
            loadBaptismApplications();
        }

        private void confirmationApplication_add_btn_Click(object sender, EventArgs e)
        {
            AddApplication aa = new AddApplication(SacramentType.Confirmation, dh);
            aa.ShowDialog();
            loadConfirmationApplications();
        }

        private void marriageApplication_add_btn_Click(object sender, EventArgs e)
        {
            
            AddMarriageApplication ama = new AddMarriageApplication(dh);
            ama.ShowDialog();
            loadMarriageApplications();
        }
        //======================================================================================================================





        // APPLICATION ADD PAYMENT BUTTON CLICK=================================================================================
        private void baptismApplication_addPayment_button_Click(object sender, EventArgs e)
        {
            payApplication(SacramentType.Baptism, baptismApplication_dgv);
            
        }

        private void confirmationApplication_addPayment_btn_Click(object sender, EventArgs e)
        {
            payApplication(SacramentType.Confirmation, confirmationApplication_dgv);
        }

        private void marriageApplication_addPayment_btn_Click(object sender, EventArgs e)
        {
            payApplication(SacramentType.Marriage, marriageApplication_dgv);
        }
        //======================================================================================================================





        
        //APPLICATION DGV VISIBLE CHANGED========================================================================================
        private void baptismApplication_dgv_VisibleChanged(object sender, EventArgs e)
        {
            loadBaptismApplications();
        }

        private void confirmationApplication_dgv_VisibleChanged(object sender, EventArgs e)
        {
            loadConfirmationApplications();
        }

        private void marriageApplication_dgv_VisibleChanged(object sender, EventArgs e)
        {
            loadMarriageApplications();
        }
        //========================================================================================================================


        //APPLICATION FILTER COMBOBOX SELECTED INDEX CHANGED======================================================================
        private void baptismApplication_filter_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            applicationFilter(baptismApplication_dgv, baptismApplication_filter_comboBox);
        }

        private void confirmationApplication_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            applicationFilter(confirmationApplication_dgv, confirmationApplication_filter);
        }

        private void marriageApplication_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            applicationFilter(marriageApplication_dgv, marriageApplication_filter);
        }
        //========================================================================================================================






        //APPLICATION DGV CELL ENTER==============================================================================================
        private void baptismApplication_dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (!dgv.Focused || dgv.SelectedRows.Count == 0)
                return;

            loadBaptismApplicationDetails(dgv);
        }

        private void confirmationApplication_dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (!dgv.Focused || dgv.SelectedRows.Count == 0)
                return;
            loadConfirmationApplicationDetails(dgv);
        }

        private void marriageApplication_dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (!dgv.Focused || dgv.SelectedRows.Count == 0)
                return;
            loadMarriageApplicationDetails(dgv);
        }

        /// <summary>
        /// Recursively clears the Controls inside a Control
        /// </summary>
        /// <param name="c"></param>
        private void RecursiveClearControl(Control c)
        {
            if (c.Controls.Count == 0)
                return;
            else
            {
                foreach (Control con in c.Controls)
                {
                    
                    if (con is TextBox)
                    {
                        TextBox a = con as TextBox;
                        a.Enabled = false;
                        a.Text = "";
                    }
                    else if (con is ComboBox)
                    {
                        ComboBox a = con as ComboBox;
                        a.SelectedIndex = 0;
                    }
                    else if (con is DateTimePicker)
                    {
                        DateTimePicker a = con as DateTimePicker;
                        a.Value = DateTime.Now.Date;
                    }
                    else if (con is Button)
                    {
                        Button a = con as Button;
                        
                    }
                    else if (con is RadioButton)
                    {
                        RadioButton a = con as RadioButton;
                        a.Checked = false;
                    }
                    else if (con is CheckBox)
                    {
                        CheckBox a = con as CheckBox;
                        a.Checked = false;
                    }
                    else if (con.Controls.Count > 0)
                    {
                        RecursiveClearControl(con);
                    }
                }
            }
        }

        private void baptismApplication_editReq_button_EnabledChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            b.Text = "Edit Requirements";
        }

        private void applicationTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (applicationTabControl.SelectedIndex == 0)
                RecursiveClearControl(baptismApplicationDetailsPanel);
            else if (applicationTabControl.SelectedIndex == 0)
                RecursiveClearControl(confirmationApplicationDetailsPanel);
            else
                RecursiveClearControl(marriageApplicationDetailsPanel);
        }

        private void baptismApplication_dgv_Resize(object sender, EventArgs e)
        {
            //MessageBox.Show(sender.ToString());
            Control c = sender as Control;
            //if(c.Width != 493)
            //{
            //    c.Width = 493;
            //    c.Height = 380;
            //}
        }

        private void applicationTabControl_Enter(object sender, EventArgs e)
        {

        }

        private void sacrament_panel_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void panelSacrament_VisibleChanged(object sender, EventArgs e)
        {
            while (panelSacrament.Controls.Count > 0)
            {
                panelSacrament.Controls[0].Dispose();
            }

            Sacrament s = new Sacrament(dh);
            s.FormBorderStyle = FormBorderStyle.None;
            s.TopLevel = false;
            s.AutoScroll = true;
            panelSacrament.Controls.Add(s);
            s.Dock = DockStyle.Fill;
            s.Show();
        }

        private void baptismApplication_edit_btn_Click(object sender, EventArgs e)
        {

        }

        private void label94_Click(object sender, EventArgs e)
        {

        }
        //========================================================================================================================
    }
}
