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
            baptismApplication_birthDate.MaxDate = DateTime.Now;

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

            Form person = new PersonView(lastGeneralProfile,dh);
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


        public void loadBaptismApplications()
        {
            baptismApplication_dgv.AutoGenerateColumns = false;
            baptismApplication_dgv.DataSource = dh.getApplications(SacramentType.Baptism);
            baptismApplication_filter_comboBox.SelectedIndex = 0;


            //baptismApplication_dgv.Columns["profileID"].Visible = false;
            //baptismApplication_dgv.Columns["applicationID"].Visible = false;
        }

        public void loadConfirmationApplications()
        {
            baptismApplication_dgv.DataSource = dh.getApplications(SacramentType.Confirmation);
            //baptismApplication_dgv.Columns["profileID"].Visible = false;
            //baptismApplication_dgv.Columns["applicationID"].Visible = false;

        }

        public void loadBaptismApplicationDetails(DataGridView dgv)
        {

            


            string fn = dgv.SelectedRows[0].Cells["firstName"].Value.ToString();
            string mn = dgv.SelectedRows[0].Cells["midName"].Value.ToString();
            string ln = dgv.SelectedRows[0].Cells["lastName"].Value.ToString();
            string suffix = dgv.SelectedRows[0].Cells["suffix"].Value.ToString();
            DateTime birthdate = DateTime.ParseExact(dgv.SelectedRows[0].Cells["birthDate"].Value.ToString(), "yyyy-MM-dd", null);
            string gender = dgv.SelectedRows[0].Cells["gender"].Value.ToString();
            ApplicationStatus status = (ApplicationStatus)int.Parse(dgv.SelectedRows[0].Cells["status"].Value.ToString());
            string requirements = dgv.SelectedRows[0].Cells["requirements"].Value.ToString();
            int applicationID = int.Parse(dgv.SelectedRows[0].Cells["applicationID"].Value.ToString());

            bool isPending = status == ApplicationStatus.Pending;


            baptismApplicationDetailsPanel.Enabled = isPending;
            baptismApplication_buttons_panel.Enabled = isPending;
            baptismApplication_payment_groupbox.Enabled = isPending;

            baptismApplication_firstName_textbox.Text = fn;
            baptismApplication_midName_textbox.Text = mn;
            baptismApplication_lastName_textbox.Text = ln;
            baptismApplication_suffix_textbox.Text = suffix;
            baptismApplication_birthDate.Value = birthdate;
            baptismApplication_male_radio.Checked = gender == "1";
            baptismApplication_female_radio.Checked = gender == "2";
            baptismApplication_status_label.Text = status.ToString();

            tickRequirements(baptismApplication_requirements_tablePanel, requirements);

            DataTable dt = dh.getApplicationIncomeDetails(applicationID);

            //MessageBox.Show(dt.Rows[0]["price"].ToString());
            double price = double.Parse(dt.Rows[0]["price"].ToString());
            
            double totalPayment = double.Parse(dt.Rows[0]["totalPayment"].ToString());
            baptismApplication_payment_label.Text = (price - totalPayment).ToString("C");
            baptismApplication_payment_remarks.Text = dt.Rows[0]["remarks"].ToString();
        }

        public void loadConfirmationApplicationDetails(int applicationID)
        {

        }
        
        private void baptismApplication_filter_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = baptismApplication_dgv.DataSource as DataTable;
            if (baptismApplication_filter_comboBox.SelectedIndex == 0)
                dt.DefaultView.RowFilter = "";
            else
                dt.DefaultView.RowFilter = "status = " + baptismApplication_filter_comboBox.SelectedIndex;
        }


        private void baptismApplication_dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (!dgv.Focused || dgv.SelectedRows.Count == 0)
                return;
            
            

            loadBaptismApplicationDetails(dgv);
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

        private bool allRequirementsFulfilled(Panel p)
        {
            bool fulfilled = true;
            foreach(CheckBox c in p.Controls)
            {
                fulfilled = fulfilled && c.Checked;
            }

            return fulfilled;
        }

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

        private void metroButton5_Click(object sender, EventArgs e)
        {
            bool enabled = baptismApplication_requirements_groupbox.Enabled;


            baptismApplication_requirements_groupbox.Enabled = !enabled;
            if (!enabled)
            {
                baptismApplication_editReq_button.Text = "Save Changes";
            }
            else
            {
                baptismApplication_editReq_button.Text = "Edit Requirements";
                bool success = editRequirements_Baptism();

                if (success)
                    Notification.Show("Successfully Applied Edits!", NotificationType.success);
                else
                    Notification.Show("Something went wrong!", NotificationType.error);
            }
        }

        private bool editRequirements_Baptism()
        {
            int applicationID = int.Parse(baptismApplication_dgv.SelectedRows[0].Cells["applicationID"].Value.ToString());
            int profileID = int.Parse(baptismApplication_dgv.SelectedRows[0].Cells["profileID"].Value.ToString());
            string r = getRequirements(baptismApplication_requirements_tablePanel);
            bool a = dh.editApplication(applicationID, r);

            return a;
        }

        private void baptismApplication_checkAll_checkBox_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox cb = (CheckBox)sender;

            if (!cb.Focused)
                return;

            foreach (CheckBox c in baptismApplication_requirements_tablePanel.Controls)
            {
                c.Checked = cb.Checked;
            }
        }

        private void baptismApplication_requirement_checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox cb = (CheckBox)sender;

            if (!cb.Focused)
                return;

            bool allChecked = true;
            foreach (CheckBox c in baptismApplication_requirements_tablePanel.Controls)
            {
                allChecked = allChecked && c.Checked;
            }

            baptismApplication_checkAll_checkBox.Checked = allChecked;

        }

        private void loadMarriageApplications()
        {

        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl t = (TabControl)sender;
            if (t.SelectedIndex == 0)
                loadBaptismApplications();
            else if (t.SelectedIndex == 1)
                loadConfirmationApplications();
            else if (t.SelectedIndex == 2)
                loadMarriageApplications();
        }

        private void baptismApplication_revoke_button_Click(object sender, EventArgs e)
        {
            int applicationID = int.Parse(baptismApplication_dgv.SelectedRows[0].Cells["applicationID"].Value.ToString());
            bool success = dh.editApplication(applicationID, ApplicationStatus.Revoked);

            if (success)
                Notification.Show("Successfully Revoked Application.", NotificationType.success);
            else
                Notification.Show("Something went wrong!.", NotificationType.error);

            loadBaptismApplications();
        }
        #endregion

        #region CDB
        //--------------------------CDB----------------------------//
        /*private void label_CD_Click(object sender, EventArgs e)
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
        }*/






        #endregion

        #region CRB
        //--------------------------CRB----------------------------//

        #endregion

        private void AddBTN_Click(object sender, EventArgs e)
        {
            AddPNL.BringToFront();
            AddPNL.Visible = true;
        }

        private void home_button_menu_Click(object sender, EventArgs e)
        {
            Button A = sender as Button;
            navigation[A].BringToFront();
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


        private void checkAll_cb_baptismApplication_CheckedChanged(object sender, EventArgs e)
        {
            bool allChecked = true;

            if (!baptismApplication_checkAll_checkBox.Checked)
            {

                foreach (CheckBox c in baptismApplication_requirements_tablePanel.Controls)
                    allChecked = allChecked && c.Checked;
            }

            if (!allChecked) return;

            foreach (CheckBox c in baptismApplication_requirements_tablePanel.Controls)
            {
                c.Checked = baptismApplication_checkAll_checkBox.Checked;
                Console.WriteLine("ENTERED");
            }
        }

        private void baptismApplication_requirement_comboBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox temp = sender as CheckBox;
            if (!temp.Checked && baptismApplication_checkAll_checkBox.Checked)
                baptismApplication_checkAll_checkBox.Checked = false;
        }

        private void baptismApplication_add_button_Click(object sender, EventArgs e)
        {
            AddApplication aa = new AddApplication(SacramentType.Baptism);
            aa.ShowDialog();
        }

        private void confirmationApplication_add_button_Click(object sender, EventArgs e)
        {
            AddApplication aa = new AddApplication(SacramentType.Confirmation);
            DialogResult dr = aa.ShowDialog();
            
        }

        private void baptismApplication_addPayment_button_Click(object sender, EventArgs e)
        {

        }

        private void baptismApplication_approve_button_Click(object sender, EventArgs e)
        {
            int applicationID = int.Parse(baptismApplication_dgv.SelectedRows[0].Cells["applicationID"].Value.ToString());
            DataGridViewRow dgvr = baptismApplication_dgv.SelectedRows[0];
            DialogResult d = DialogResult.None;
            if (allRequirementsFulfilled(baptismApplication_requirements_tablePanel))
            {
                BaptismForm bf = new BaptismForm(dgvr, dh);
                d = bf.ShowDialog();
            }else
            {
                DialogResult dr = MessageDialog.Show("Not all requirements were fulfilled. Proceed anyway?", "Warning", MessageDialogButtons.YesNo, MessageDialogIcon.Warning);
                if(dr == DialogResult.Yes)
                {
                    BaptismForm bf = new BaptismForm(dgvr, dh);
                    d = bf.ShowDialog();
                }
            }
            
            if (d == DialogResult.OK)
                Notification.Show("Successfully Added Baptism!", NotificationType.success);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, "Hello", "MSG", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            MessageBox.Show(MessageDialog.Show("Hello", "Titleeee", MessageDialogButtons.OKCancel, MessageDialogIcon.Information) + "");

        }

        private void customControlBar1_Load(object sender, EventArgs e)
        {

        }

        private void baptismApplication_dgv_AllowUserToOrderColumnsChanged(object sender, EventArgs e)
        {

        }

        private void baptismApplication_dgv_Paint(object sender, PaintEventArgs e)
        {
            //loadBaptismApplications();
        }

        private void baptismApplication_dgv_VisibleChanged(object sender, EventArgs e)
        {
            loadBaptismApplications();
        }

        private void baptismApplication_dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            baptismApplication_dgv.ClearSelection();
        }
    }
}
