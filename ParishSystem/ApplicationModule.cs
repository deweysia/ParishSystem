using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace ParishSystem
{
    public partial class ApplicationModule : Form
    {
        DataHandler dh;
        private int profileID, groomID, brideID;
        private int applicationID;
        private int applicantID, groomApplicantID, brideApplicantID;
        public ApplicationModule()
        {
            InitializeComponent();
            this.dh = DataHandler.getDataHandler();

            baptismApplication_birthDate_dtp.MaxDate = DateTime.Now.Date;
            confirmationApplication_birthDate_dtp.MaxDate = DateTime.Now.Date;
            dtpGBirthDate.MaxDate = DateTime.Now.Date;
            dtpBBirthDate.MaxDate = DateTime.Now.Date;
            //applicationTabControl.TabPages[1].Enabled = false;
        }

        private void SacramentApplication_Load(object sender, EventArgs e)
        {
            
        }

        private DataGridView getDataGridView(SacramentType t)
        {
            if (t == SacramentType.Baptism)
                return baptismApplication_dgv;
            else if (t == SacramentType.Confirmation)
                return confirmationApplication_dgv;
            else
                return marriageApplication_dgv;
        }

        private TableLayoutPanel getRequirementTableLayoutPanel(SacramentType t)
        {
            if (t == SacramentType.Baptism)
                return baptismApplication_requirements_tlp;
            else if (t == SacramentType.Confirmation)
                return confirmationApplication_requirements_tlp;
            else
                return marriageApplication_requirements_tlp;
        }

        private ComboBox getFilter(SacramentType t)
        {
            if (t == SacramentType.Baptism)
                return baptismApplication_filter_cmb;
            else if (t == SacramentType.Confirmation)
                return confirmationApplication_filter_cmb;
            else
                return marriageApplication_filter_cmb;
        }

        private CheckBox getCheckAllCheckBox(SacramentType t)
        {
            if (t == SacramentType.Baptism)
                return baptismApplication_checkAll_checkBox;
            else if (t == SacramentType.Confirmation)
                return confirmationApplication_checkAll_checkBox;
            else
                return marriageApplication_checkAll_checkBox;
        }

        private Panel getApplicationDetailsPanel(SacramentType t)
        {
            if (t == SacramentType.Baptism)
                return baptismApplicationDetailsPanel;
            else if (t == SacramentType.Confirmation)
                return confirmationApplicationDetailsPanel;
            else
                return marriageApplicationDetailsPanel;
        }
        private Form getAddApplicationForm(SacramentType t)
        {
            if (t == SacramentType.Baptism)
                return new AddApplication(SacramentType.Baptism);
            else if (t == SacramentType.Confirmation)
                return new AddApplication(SacramentType.Confirmation);
            else
                return new AddMarriageApplication();
        }

        /// <summary>
        /// Loads all applications of given SacramentType
        /// </summary>
        /// <param name="t"></param>
        public void loadApplications(SacramentType t)
        {
            //Dewey naga cause ng error so temporarily i try catch ko pls fix this
            try
            {
                DataGridView dgv = getDataGridView(t);
                ComboBox filter = getFilter(t);
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = dh.getApplications(t);
                dgv.ClearSelection();
                filter.SelectedIndex = 0;
            }
            catch(Exception e)
            {
                //MessageBox.Show(e.ToString());
            }
        }


        private Form getApplicationForm(SacramentType t)
        {
            DataGridViewRow dgvr;
            if (t == SacramentType.Baptism)
            {
                dgvr = getDGVR(t);//baptismApplication_dgv.SelectedRows[0];
                DataRow dr = ((DataRowView)dgvr.DataBoundItem).Row;
                return new SacramentForm(OperationType.Add, SacramentType.Baptism, dr);
            }else if (t == SacramentType.Confirmation)
            {
                dgvr = getDGVR(t);//dgvr = confirmationApplication_dgv.SelectedRows[0];
                DataRow dr = ((DataRowView)dgvr.DataBoundItem).Row;
                return new SacramentForm(OperationType.Add, SacramentType.Confirmation, dr);
            }else
            {

                dgvr = getDGVR(t);//dgvr = marriageApplication_dgv.SelectedRows[0];
                DataRow dr = ((DataRowView)dgvr.DataBoundItem).Row;
                return new MarriageForm(OperationType.Add, dr);
            }
                
        }

        private void loadApplicationDetails(SacramentType t)
        {
            DataGridView dgv;
            LoadApplicationDetailsDelegate Load;
            if (t == SacramentType.Baptism)
            {
                
                dgv = baptismApplication_dgv;
                Load = loadBaptismApplicationDetails;

            }
            else if (t == SacramentType.Confirmation)
            {
                dgv = confirmationApplication_dgv;
                Load = loadConfirmationApplicationDetails;
            }
            else
            {
                dgv = marriageApplication_dgv;
                Load = loadMarriageApplicationDetails;
            }

            if (!dgv.Focused || dgv.SelectedRows.Count == 0)
                return;

            Load(dgv);
        }
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
            baptismApplication_filter_cmb.SelectedIndex = 0;
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
            confirmationApplication_filter_cmb.SelectedIndex = 0;
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
            marriageApplication_filter_cmb.SelectedIndex = 0;
        }

        private void loadApplicationPaymentDetails(SacramentType t)
        {
            Button btnPayment;
            Label lblPrice;
            Label lblRemarks;
            if(t == SacramentType.Baptism)
            {
                btnPayment = baptismApplication_addPayment_btn;
                lblPrice = baptismApplication_payment_label;
                lblRemarks = lblBapRemarks;
            }else if(t == SacramentType.Confirmation)
            {
                btnPayment = confirmationApplication_addPayment_btn;
                lblPrice = confirmationApplication_payment_label;
                lblRemarks = lblConRemarks;
            }else
            {
                btnPayment = marriageApplication_addPayment_btn;
                lblPrice = marriageApplication_price_label;
                lblRemarks = lblMarRemarks;
            }

            //MessageBox.Show("Application ID: " + this.applicationID);
            DataTable dt = dh.getApplicationIncomeDetails(this.applicationID);

            //MessageBox.Show(dt.Rows[0]["price"].ToString());
            double price = double.Parse(dt.Rows[0]["price"].ToString());

            double totalPayment = double.Parse(dt.Rows[0]["totalPayment"].ToString());
            btnPayment.Enabled = (price - totalPayment) != 0;
            lblRemarks.Text = dt.Rows[0]["remarks"].ToString();
            lblPrice.Text = (price - totalPayment).ToString("C");

        }

        /// <summary>
        /// Loads details of the SelectedRow in DataGridView to the Baptism Details Panel
        /// </summary>
        /// <param name="dgv"></param>
        public void loadBaptismApplicationDetails(DataGridView dgv)
        {

            baptismApplicationDetailsPanel.Enabled = true;
            this.applicationID = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            this.cbBapEdit.Tag = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            this.profileID = int.Parse(dgv.SelectedRows[0].Cells[1].Value.ToString());
            this.applicantID = int.Parse(dgv.SelectedRows[0].Cells[2].Value.ToString());
            string requirements = dgv.SelectedRows[0].Cells[3].Value.ToString();
            //MessageBox.Show(requirements);
            string fn = dgv.SelectedRows[0].Cells[4].Value.ToString();
            string mn = dgv.SelectedRows[0].Cells[5].Value.ToString();
            string ln = dgv.SelectedRows[0].Cells[6].Value.ToString();
            string suffix = dgv.SelectedRows[0].Cells[7].Value.ToString();
            string gender = dgv.SelectedRows[0].Cells[8].Value.ToString();
            DateTime birthdate = DateTime.ParseExact(dgv.SelectedRows[0].Cells[9].Value.ToString(), "yyyy-MM-dd", null);
            ApplicationStatus status = (ApplicationStatus)int.Parse(dgv.SelectedRows[0].Cells[10].Value.ToString());



            //Load into Edit Panel
            txtBapFN.Text = fn;
            txtBapMI.Text = mn;
            txtBapLN.Text = ln;
            txtBapSuffix.Text = suffix;
            baptismApplication_birthDate_dtp.Value = birthdate;
            baptismApplication_male_radio.Checked = gender == "1";
            baptismApplication_female_radio.Checked = gender == "2";
            baptismApplication_status_label.Text = status.ToString();

            //Load into Display Panel
            baptismApplication_name_lbl.Text = string.Format("{0} {1} {2} {3}", fn, mn, ln, suffix);
            baptismApplication_gender_lbl.Text = gender == "1" ? "Male" : "Female";
            baptismApplication_birthdate_lbl.Text = birthdate.ToString("yyyy-MM-dd");

            //Determine whether edit, approve, revoke is possible
            pnlBapApproveRevoke.Enabled = status == ApplicationStatus.Pending;
            cbBapEdit.Enabled = status == ApplicationStatus.Pending;

            tickRequirements(SacramentType.Baptism, requirements);
            loadApplicationPaymentDetails(SacramentType.Baptism);   
        }

        /// <summary>
        /// Loads details of the SelectedRow in DataGridView to the Confirmation Details Panel
        /// </summary>
        /// <param name="dgv"></param>
        private void loadConfirmationApplicationDetails(DataGridView dgv)
        {
            confirmationApplicationDetailsPanel.Enabled = true;
            this.applicationID = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            this.cbConEdit.Tag = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            this.profileID = int.Parse(dgv.SelectedRows[0].Cells[1].Value.ToString());
            this.applicantID = int.Parse(dgv.SelectedRows[0].Cells[2].Value.ToString());
            string requirements = dgv.SelectedRows[0].Cells[3].Value.ToString();
            string fn = dgv.SelectedRows[0].Cells[4].Value.ToString();
            string mn = dgv.SelectedRows[0].Cells[5].Value.ToString();
            string ln = dgv.SelectedRows[0].Cells[6].Value.ToString();
            string suffix = dgv.SelectedRows[0].Cells[7].Value.ToString();
            string gender = dgv.SelectedRows[0].Cells[8].Value.ToString();
            DateTime birthdate = DateTime.ParseExact(dgv.SelectedRows[0].Cells[9].Value.ToString(), "yyyy-MM-dd", null);
            ApplicationStatus status = (ApplicationStatus)int.Parse(dgv.SelectedRows[0].Cells[10].Value.ToString());

            confirmationApplication_name_lbl.Text = string.Format("{0} {1} {2} {3}", fn, mn, ln, suffix);
            confirmationApplication_gender_lbl.Text = gender == "1" ? "Male" : "Female";
            confirmationApplication_birthDate_lbl.Text = birthdate.ToString("yyyy-MM-dd");

            txtConFN.Text = fn;
            txtConLN.Text = ln;
            txtConMI.Text = mn;
            txtConSuffix.Text = suffix;
            confirmationApplication_birthDate_dtp.Value = birthdate;
            confirmationApplication_male_radio.Checked = gender == "1";
            confirmationApplication_female_radio.Checked = gender == "2";
            confirmationApplication_status_label.Text = status.ToString();


            pnlConApproveRevoke.Enabled = status == ApplicationStatus.Pending;
            cbConEdit.Enabled = status == ApplicationStatus.Pending;

            tickRequirements(SacramentType.Confirmation, requirements);
            loadApplicationPaymentDetails(SacramentType.Confirmation);
        }


        /// <summary>
        /// Loads details of the SelectedRow in DataGridView to the Marriage Details Panel
        /// </summary>
        /// <param name="dgv"></param>
        public void loadMarriageApplicationDetails(DataGridView dgv)
        {
            marriageApplicationDetailsPanel.Enabled = true;
            this.applicationID = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
            this.cbMarEdit.Tag = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());

            this.groomID = int.Parse(dgv.SelectedRows[0].Cells[1].Value.ToString());
            this.brideID = int.Parse(dgv.SelectedRows[0].Cells[2].Value.ToString());

            this.groomApplicantID = int.Parse(dgv.SelectedRows[0].Cells[3].Value.ToString());
            this.brideApplicantID = int.Parse(dgv.SelectedRows[0].Cells[4].Value.ToString());

            string requirements = dgv.SelectedRows[0].Cells[5].Value.ToString();

            string[] GName = dgv.SelectedRows[0].Cells[6].Value.ToString().Split(new char[] { ' ' });
            txtGFN.Text = GName[0];
            txtGMI.Text = GName[1];
            txtGLN.Text = GName[2];
            txtGSuffix.Text = GName[3];

            dtpGBirthDate.Value = DateTime.ParseExact(dgv.SelectedRows[0].Cells[7].Value.ToString(), "yyyy-MM-dd", null);

            string[] BName = dgv.SelectedRows[0].Cells[8].Value.ToString().Split(new char[] { ' ' });
            txtBFN.Text = BName[0];
            txtBMI.Text = BName[1];
            txtBLN.Text = BName[2];
            txtBSuffix.Text = BName[3];

            dtpBBirthDate.Value = DateTime.ParseExact(dgv.SelectedRows[0].Cells[9].Value.ToString(), "yyyy-MM-dd", null);

            ApplicationStatus status = (ApplicationStatus)int.Parse(dgv.SelectedRows[0].Cells[10].Value.ToString());

            marriageApplication_groomName_lbl.Text = string.Format("{0} {1} {2} {3}", GName[0], GName[1], GName[2], GName[3]);
            marriageApplication_groomBirthdate_lbl.Text = dtpGBirthDate.Value.ToString("yyyy-MM-dd");
            marriageApplication_brideName_lbl.Text = string.Format("{0} {1} {2} {3}", BName[0], BName[1], BName[2], BName[3]);
            marriageApplication_brideBirthDate_lbl.Text = dtpBBirthDate.Value.ToString("yyyy-MM-dd");
            marriageApplication_status_label.Text = status.ToString();



            pnlMarApproveRevoke.Enabled = status == ApplicationStatus.Pending;
            cbMarEdit.Enabled = status == ApplicationStatus.Pending;

            tickRequirements(SacramentType.Marriage, requirements);
            loadApplicationPaymentDetails(SacramentType.Marriage);
        }

        /// <summary>
        /// Approves and opens a certain SacramentForm based on SacramentType
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dgv"></param>
        /// <param name="tlp"></param>
        private void applicationApprove(SacramentType type)
        {

            DataGridViewRow dgvr = getDGVR(type); //getDataGridView(type).SelectedRows[0];
            TableLayoutPanel tlp = getRequirementTableLayoutPanel(type);
            DialogResult d = DialogResult.None;


            Form f = getApplicationForm(type);

            if (allRequirementsFulfilled(type))
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
            {
                Notification.Show(State.ApplicationApproveSuccess);
                loadApplications(type);
            }
        }

        /// <summary>
        /// Sets the status of an Application to Revoked
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dgv"></param>
        private void applicationRevoke(SacramentType type)
        {
            DataGridView dgv = getDataGridView(type);
            
            bool success = dh.editApplication(this.applicationID, ApplicationStatus.Revoked);

            if (success)
                Notification.Show(State.RevokeSucess);
            else
                Notification.Show(State.RevokeFail);

            loadApplications(type);
            
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
        private void applicationFilter(SacramentType t)
        {
            DataGridView dgv = getDataGridView(t);
            ComboBox filter = getFilter(t);
            
            
            DataTable dt = dgv.DataSource as DataTable;

            if (filter.SelectedIndex == 0)
                dt.DefaultView.RowFilter = "";
            else
                dt.DefaultView.RowFilter = "status = " + filter.SelectedIndex;

            
            Control parent = dgv.Parent;

            Panel applicationDetailsPanel = getApplicationDetailsPanel(t);

            RecursiveClearControl(applicationDetailsPanel);

            dgv.ClearSelection();
            applicationDetailsPanel.Enabled = false;
        }

        /// <summary>
        /// Returns the requirement Check Box objects in the Panel as a series of 1 and 0's
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string getRequirements(SacramentType t)
        {

            TableLayoutPanel tlpReq = getRequirementTableLayoutPanel(t);

            string r = "";
            foreach (CheckBox c in tlpReq.Controls)
                r += c.Checked ? "1" : "0";

            return r;

        }
        /// <summary>
        /// Checks if all requirement CheckBoxes are Checked
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private bool allRequirementsFulfilled(SacramentType t)
        {
            TableLayoutPanel tlp = getRequirementTableLayoutPanel(t);
            bool fulfilled = true;
            foreach (CheckBox c in tlp.Controls)
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
        private void tickRequirements(SacramentType t, string requirements)
        {
            TableLayoutPanel tlpReq = getRequirementTableLayoutPanel(t);

            bool allChecked = true;
            foreach (CheckBox c in tlpReq.Controls)
            {
                int i = tlpReq.Controls.GetChildIndex(c);
                c.Checked = requirements[i] == '1';
                allChecked &= c.Checked;
            }

            CheckBox checkAll = getCheckAllCheckBox(t);

            checkAll.Checked = allChecked;
        }



        /// <summary>
        /// Saves changes of requirements to the database
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="tb"></param>
        /// <returns></returns>
        private bool editRequirements(SacramentType t)
        {
            DataGridView dgv = getDataGridView(t);
            string r = getRequirements(t);
            bool a = dh.editApplication(this.applicationID, r);

            return a;
        }

        /// <summary>
        /// Opens an ApplicationPayment Form based on SacramentType
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dgv"></param>
        private void payApplication(SacramentType type)
        {
            DataGridView dgv = getDataGridView(type);
            DataGridViewRow dgvr = getDGVR(type);
            ApplicationPayment ap = new ApplicationPayment(type, dgvr, dh);
            DialogResult dr = ap.ShowDialog();
            Control parent = dgv.Parent;

            foreach (Control c in parent.Controls)
            {
                if (c.Tag != null && c.Tag.ToString() == "Details")
                {
                    RecursiveClearControl(c);
                    break;
                }
            }

            loadApplicationPaymentDetails(type);

        }

        private DataGridViewRow getDGVR(SacramentType type)
        {
            DataGridView dgv = getDataGridView(type);
            int applicationID = getApplicationID(type);
            foreach(DataGridViewRow dgvr in dgv.Rows)
            {
                if (Convert.ToInt32(dgvr.Cells[0].Value) == applicantID)
                    return dgvr;
            }

            return null;
        }

        private int getApplicationID(SacramentType type)
        {
            int applicationID = -1;
            if(type == SacramentType.Baptism)
            {
                applicantID = cbBapEdit.Tag != null ? Convert.ToInt32(cbBapEdit.Tag.ToString()) : -1; 
            }else if(type == SacramentType.Confirmation)
            {
                applicantID = cbConEdit.Tag != null ? Convert.ToInt32(cbConEdit.Tag.ToString()) : -1;
            }else
            {
                applicantID = cbMarEdit.Tag != null ? Convert.ToInt32(cbMarEdit.Tag.ToString()) : -1;
            }

            return applicantID;
        }

        /// <summary>
        /// Indicates whether the TextBox or CueTextBox controls in a Control has empty text or filler text
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool hasEmptyTextBoxes(Control c)
        {
            foreach (Control con in c.Controls)
            {
                if (con is CueTextBox)
                {
                    CueTextBox ctxt = con as CueTextBox;
                    if (ctxt.isEmpty())
                        return true;
                }
                else if (con is TextBox)
                {
                    TextBox t = con as TextBox;
                    if (string.IsNullOrWhiteSpace(t.Text))
                        return true;
                }
            }

            return false;
        }

        

        //public bool editApplicationProfile2(SacramentType type)
        //{
        //    bool success = true;
        //    if (type == SacramentType.Baptism)
        //    {
        //        if (hasEmptyTextBoxes(baptismApplication_profile_tlp))
        //        {
        //            Notification.Show(State.MissingFields);
        //            return false;
        //        }

        //        string fn = baptismApplication_firstName_textBox.Text;
        //        string mi = baptismApplication_midName_textBox.Text;
        //        string ln = baptismApplication_lastName_textBox.Text;
        //        string suffix = baptismApplication_suffix_textBox.Text;
        //        Gender g = baptismApplication_male_radio.Checked ? Gender.Male : Gender.Female;
        //        DateTime birthDate = baptismApplication_birthDate_dtp.Value;


        //        bool profileExists = dh.generalProfileExists(this.profileID, fn, mi, ln, suffix, g, birthDate);
        //        //if another generalprofile exists, and has no active application

        //        if (profileExists) //Another profile with same biodata exists
        //        {
        //            int existingProfileID = dh.getGeneralProfileID(fn, mi, ln, suffix, g, birthDate);
        //            DataTable dt = dh.getActiveApplicationOf(existingProfileID, type);
                    
        //            if (dt.Rows.Count != 0)
        //            {
        //                Notification.Show(State.ApplicationExists);
        //            }
        //            else
        //            {//edit applicant, add application
        //                success &= dh.addApplication(type);
        //                int newApplicationID = dh.getLatestID("Application", "applicationID");
        //                success &= dh.editApplicant(this.applicantID, existingProfileID, newApplicationID);
        //                success &= dh.editSacramentIncome(this.applicationID, newApplicationID);
        //            }

        //        }else
        //        {
        //            success &= dh.editGeneralProfile(this.profileID, fn, mi, ln, suffix, g, birthDate);
        //        }

        //        success &= dh.editApplication(this.applicationID, getRequirements(type));
                

        //    }
        //    else if (type == SacramentType.Confirmation)
        //    {
        //        if (hasEmptyTextBoxes(confirmationApplication_profile_tlp))
        //        {
        //            Notification.Show(State.MissingFields);
        //            return false;
        //        }

        //        string fn = confirmationApplication_firstName_textBox.Text;
        //        string mi = confirmationApplication_lastName_textBox.Text;
        //        string ln = confirmationApplication_midName_textBox.Text;
        //        string suffix = confirmationApplication_suffix_textBox.Text;
        //        Gender g = confirmationApplication_male_radio.Checked ? Gender.Male : Gender.Female;
        //        DateTime birthDate = confirmationApplication_birthDate_dtp.Value;

        //        bool profileExists = dh.generalProfileExists(this.profileID, fn, mi, ln, suffix, g, birthDate);
        //        if (profileExists) //Another profile with same biodata exists
        //        {
        //            int existingProfileID = dh.getGeneralProfileID(fn, mi, ln, suffix, g, birthDate);
        //            DataTable dt = dh.getActiveApplicationOf(existingProfileID, type);

        //            if (dt.Rows.Count != 0)
        //            {
        //                Notification.Show(State.ApplicationExists);
        //            }
        //            else
        //            {//edit applicant, add application
        //                success &= dh.addApplication(type);
        //                int newApplicationID = dh.getLatestID("Application", "applicationID");
        //                success &= dh.editApplicant(this.applicantID, existingProfileID, newApplicationID);
        //                success &= dh.editSacramentIncome(this.applicationID, newApplicationID);
        //            }

        //        }
        //        else
        //        {
        //            success &= dh.editGeneralProfile(this.profileID, fn, mi, ln, suffix, g, birthDate);
        //        }

        //        success &= dh.editApplication(this.applicationID, getRequirements(type));

        //    }
        //    else //Marriage
        //    {

        //        if (hasEmptyTextBoxes(marriageApplication_profile_tlp))
        //        {
        //            Notification.Show(State.MissingFields);
        //            return false;
        //        }


        //        string gfn = txtGFN.Text;
        //        string gmi = txtGMI.Text;
        //        string gln = txtGLN.Text;
        //        string gsuffix = txtGSuffix.Text;
        //        DateTime gbd = dtpGBirthDate.Value;
        //        bool groomExists = dh.generalProfileExists(this.groomID, gfn, gmi, gln, gsuffix, Gender.Male, gbd);

        //        if (groomExists)
        //        {
        //            Notification.Show(State.GroomExists);
        //            return false;
        //        }

        //        if (groomExists) //Another profile with same biodata exists
        //        {
        //            int existingProfileID = dh.getGeneralProfileID(gfn, gmi, gln, gsuffix, Gender.Male, gbd);

        //            //Map to the new general profile
        //            dh.editApplicant(this.applicantID, existingProfileID, this.applicantID);

        //        }
        //        else
        //        {
        //            success &= dh.editGeneralProfile(this.groomID, gfn, gmi, gln, gsuffix, Gender.Male, gbd);
        //        }

        //        string bfn = txtBFN.Text;
        //        string bmi = txtBMI.Text;
        //        string bln = txtBLN.Text;
        //        string bsuffix = txtBSuffix.Text;
        //        DateTime bbd = dtpBBirthDate.Value;

        //        bool brideExists = dh.generalProfileExists(this.brideID, bfn, bmi, bln, bsuffix, Gender.Female, bbd);

        //        if (brideExists)
        //        {
        //            int existingProfileID = dh.getGeneralProfileID(bfn, bmi, bln, bsuffix, Gender.Female, bbd);

        //            //Map to the new general profile
        //            dh.editApplicant(this.applicantID, existingProfileID, this.applicantID);
        //        }
        //        else
        //        {
        //            success &= dh.editGeneralProfile(this.brideID, bfn, bmi, bln, bsuffix, Gender.Female, bbd);
        //        }


        //        success &= dh.editApplication(this.applicationID, getRequirements(type));
        //        //success &= dh.editGeneralProfile(this.groomID, gfn, gmi, gln, gsuffix, Gender.Male, gbd);
        //        //success &= dh.editGeneralProfile(this.brideID, bfn, bmi, bln, bsuffix, Gender.Female, bbd);
        //    }

        //    if (success)
        //    {
        //        Notification.Show(State.MinisterAddSuccess);
        //        loadApplications(type);
        //        Panel p = getApplicationDetailsPanel(type);
        //        RecursiveClearControl(p);

        //    }
        //    else
        //    {
        //        Notification.Show(State.MinisterAddFail);
        //    }

        //    return success;
        //}

        public bool editApplicationProfile(SacramentType type)
        {

            bool success = true;
            
            if (type == SacramentType.Baptism)
            {
                if (hasEmptyTextBoxes(baptismApplication_profile_tlp))
                {
                    Notification.Show(State.MissingFields);
                    return false;
                }

                string fn = txtBapFN.Text;
                string mi = txtBapMI.Text;
                string ln = txtBapLN.Text;
                string suffix = txtBapSuffix.Text;
                Gender g = baptismApplication_male_radio.Checked ? Gender.Male : Gender.Female;
                DateTime birthDate = baptismApplication_birthDate_dtp.Value;

                bool profileExists = dh.generalProfileExists(this.profileID, fn, mi, ln, suffix, g, birthDate);

                //If another person with same info exists,
                if (profileExists) 
                {
                    DialogResult dr = MessageDialog.Show(MessageDialog.State.ProfileExists);
                    if (dr == DialogResult.Cancel)
                        return false;

                    //Get the GeneralProfileID of the other person
                    int existingProfileID = dh.getGeneralProfileID(fn, mi, ln, suffix, g, birthDate);

                    //Retrieve active baptism application of the other person
                    DataTable dt = dh.getActiveApplicationOf(existingProfileID, type);

                    //If he has an existing baptism application, by checking if an active application is returned
                    if (dt.Rows.Count != 0)
                    {
                        //If the other person has active application, process failed. Return.
                        Notification.Show(State.ApplicationExists);
                        return false;
                    }
                    else
                    {//If other person has no active application, 
                        //Add new application
                        success &= dh.addApplication(type);
                        int newApplicationID = dh.getLatestID("Application", "applicationID");
                        //Rereference the applicant record of current person to point to the ID of the other person. Also reference new application
                        success &= dh.editApplicant(this.applicantID, existingProfileID, newApplicationID);
                        //Rereference sacrament income to point to new application
                        success &= dh.editSacramentIncome(this.applicationID, newApplicationID);
                    }

                }else
                {
                    //If no profile with same info exists, simply update person's info
                    success &= dh.editGeneralProfile(this.profileID, fn, mi, ln, suffix, g, birthDate);
                }
                //Update the requirements
                success &= dh.editApplication(this.applicationID, getRequirements(type));
                
            }
            else if (type == SacramentType.Confirmation)
            {
                if (hasEmptyTextBoxes(confirmationApplication_profile_tlp))
                {
                    Notification.Show(State.MissingFields);
                    return false;
                }

                string fn = txtConFN.Text;
                string mi = txtConLN.Text;
                string ln = txtConMI.Text;
                string suffix = txtConSuffix.Text;
                Gender g = confirmationApplication_male_radio.Checked ? Gender.Male : Gender.Female;
                DateTime birthDate = confirmationApplication_birthDate_dtp.Value;

                bool profileExists = dh.generalProfileExists(this.profileID, fn, mi, ln, suffix, g, birthDate);
                if (profileExists)
                {
                    int existingProfileID = dh.getGeneralProfileID(fn, mi, ln, suffix, g, birthDate);
                    //MessageBox.Show("Existing profileID: " + existingProfileID);
                    DataTable dt = dh.getActiveApplicationOf(existingProfileID, type);
                    //MessageBox.Show("Existing Application of Confirmation: " + dt.Rows.Count);
                    //Has active application
                    if (dt.Rows.Count != 0)
                    {
                        Notification.Show(State.ApplicationExists);
                        return false;
                    }
                    else
                    {//edit applicant, add application
                        //success &= dh.addNewApplicant(existingProfileID, type);

                        success &= dh.addApplication(type);

                        int newApplicationID = dh.getLatestID("Application", "applicationID");
                        //MessageBox.Show("newApplicationID: " + newApplicationID);
                        success &= dh.editApplicant(this.applicantID, existingProfileID, newApplicationID);
                        success &= dh.editSacramentIncome(this.applicationID, newApplicationID);
                    }
                }
                else
                {
                    success &= dh.editGeneralProfile(this.profileID, fn, mi, ln, suffix, g, birthDate);
                }

                success &= dh.editApplication(this.applicationID, getRequirements(type));
                //success &= dh.editGeneralProfile(this.profileID, fn, mi, ln, suffix, g, birthDate);
                
            }
            else //Marriage
            {

                if (hasEmptyTextBoxes(marriageApplication_profile_tlp))
                {
                    Notification.Show(State.MissingFields);
                    return false;
                }


                string gfn = txtGFN.Text;
                string gmi = txtGMI.Text;
                string gln = txtGLN.Text;
                string gsuffix = txtGSuffix.Text;
                DateTime gbd = dtpGBirthDate.Value;
                bool groomExists = dh.generalProfileExists(this.groomID, gfn, gmi, gln, gsuffix, Gender.Male, gbd);

                if (groomExists)
                {
                    int existingProfileID = dh.getGeneralProfileID(gfn, gmi, gln, gsuffix, Gender.Male, gbd);
                    success &= dh.editApplicant(this.groomApplicantID, existingProfileID, this.applicationID);
                }
                else
                {
                    success &= success &= dh.editGeneralProfile(this.groomID, gfn, gmi, gln, gsuffix, Gender.Male, gbd);
                }

                string bfn = txtBFN.Text;
                string bmi = txtBMI.Text;
                string bln = txtBLN.Text;
                string bsuffix = txtBSuffix.Text;
                DateTime bbd = dtpBBirthDate.Value;

                bool brideExists = dh.generalProfileExists(this.brideID, bfn, bmi, bln, bsuffix, Gender.Female, bbd);
                if (brideExists)
                {
                    int existingProfileID = dh.getGeneralProfileID(bfn, bmi, bln, bsuffix, Gender.Female, bbd);
                    success &= dh.editApplicant(this.brideApplicantID, existingProfileID, this.applicationID);
                }
                else
                {
                    success &= dh.editGeneralProfile(this.brideID, bfn, bmi, bln, bsuffix, Gender.Female, bbd);
                }

                success &= dh.editApplication(this.applicationID, getRequirements(type));
            }

            if (success)
            {
                Notification.Show(State.ApplicationEditSuccess);
                loadApplications(type);
                Panel p = getApplicationDetailsPanel(type);
                RecursiveClearControl(p);

            }
            else
            {
                Notification.Show(State.ApplicationEditFail);
            }

            return success;
        }


        // DGV CELL FORMATTING ==================================================================================================
        private void baptismApplication_dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {//Might be really slow!
            if (e.ColumnIndex == 8)//Gender
                e.Value = e.Value.ToString() == "1" ? "M" : "F";
            else if (e.ColumnIndex == 10)
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
            if (e.ColumnIndex == 10)
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
            applicationApprove(SacramentType.Confirmation);
        }

        private void marriageApplication_approve_btn_Click(object sender, EventArgs e)
        {
            applicationApprove(SacramentType.Marriage);
        }

        private void baptismApplication_approve_button_Click(object sender, EventArgs e)
        {
            applicationApprove(SacramentType.Baptism);
        }
        //=====================================================================================================================




        // APPLICATION CHECKALL CHECK CHANGED =================================================================================

        private void baptismApplication_checkAll_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            checkAllCheckChanged(baptismApplication_checkAll_checkBox, baptismApplication_requirements_tlp);
        }

        private void confirmationApplication_checkAll_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            checkAllCheckChanged(confirmationApplication_checkAll_checkBox, confirmationApplication_requirements_tlp);
        }

        private void marriageApplication_checkAll_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            checkAllCheckChanged(marriageApplication_checkAll_checkBox, marriageApplication_requirements_tlp);
        }
        //=====================================================================================================================





        // APPLICATION REQUIREMENT CHECK CHANGED =================================================================================
        private void baptismApplication_requirement_checkBox_CheckedChanged(object sender, EventArgs e)
        {

            requirementCheckChanged((CheckBox)sender, baptismApplication_checkAll_checkBox, baptismApplication_requirements_tlp);

        }

        private void confirmationApplication_requirement_checkBox_CheckChanged(object sender, EventArgs e)
        {
            requirementCheckChanged((CheckBox)sender, confirmationApplication_checkAll_checkBox, confirmationApplication_requirements_tlp);
        }

        private void marriage_requirement_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            requirementCheckChanged((CheckBox)sender, marriageApplication_checkAll_checkBox, marriageApplication_requirements_tlp);
        }

        //=====================================================================================================================





        // APPLICATION REVOKE BUTTON CLICK=====================================================================================
        private void baptismApplication_revoke_button_Click(object sender, EventArgs e)
        {
            applicationRevoke(SacramentType.Baptism);
        }

        private void confirmationApplication_revoke_btn_Click(object sender, EventArgs e)
        {
            applicationRevoke(SacramentType.Confirmation);
        }


        private void marriageApplication_revoke_btn_Click(object sender, EventArgs e)
        {
            applicationRevoke(SacramentType.Marriage);
        }

        //======================================================================================================================







        #endregion

        // APPLICATION ADD BUTTON CLICK=====================================================================================

        

        private void baptismApplication_add_button_Click(object sender, EventArgs e)
        {
            Form f = getAddApplicationForm(SacramentType.Baptism);
            f.ShowDialog();

            loadApplications(SacramentType.Baptism);
            
        }

        private void confirmationApplication_add_btn_Click(object sender, EventArgs e)
        {
            Form f = getAddApplicationForm(SacramentType.Confirmation);
            f.ShowDialog();

            loadApplications(SacramentType.Confirmation);

        }

        private void marriageApplication_add_button_Click(object sender, EventArgs e)
        {
            Form f = getAddApplicationForm(SacramentType.Marriage);
            f.ShowDialog();

            loadApplications(SacramentType.Marriage);

        }
        //======================================================================================================================





        // APPLICATION ADD PAYMENT BUTTON CLICK=================================================================================
        private void baptismApplication_addPayment_button_Click(object sender, EventArgs e)
        {
            payApplication(SacramentType.Baptism);
        }

        private void confirmationApplication_addPayment_btn_Click(object sender, EventArgs e)
        {
            payApplication(SacramentType.Confirmation);
        }


        private void marriageApplication_addPayment_btn_Click(object sender, EventArgs e)
        {
            payApplication(SacramentType.Marriage);
        }
        //======================================================================================================================






        //APPLICATION DGV VISIBLE CHANGED========================================================================================
        private void baptismApplication_dgv_VisibleChanged(object sender, EventArgs e)
        {
            if (cbBapEdit.Checked)
                applicationEditCheckChanged(SacramentType.Baptism);
            //clearApplicationsDetailsPanel((SacramentType)(applicationTabControl.SelectedIndex + 1));

            loadApplications(SacramentType.Baptism);
            

        }

        private void confirmationApplication_dgv_VisibleChanged(object sender, EventArgs e)
        {
            if (cbConEdit.Checked)
                applicationEditCheckChanged(SacramentType.Confirmation);
            //clearApplicationsDetailsPanel((SacramentType)(applicationTabControl.SelectedIndex + 1));
            loadApplications(SacramentType.Confirmation);
        }

        private void marriageApplication_dgv_VisibleChanged(object sender, EventArgs e)
        {
            if (cbMarEdit.Checked)
                applicationEditCheckChanged(SacramentType.Marriage);
            //clearApplicationsDetailsPanel((SacramentType)(applicationTabControl.SelectedIndex + 1));

            loadApplications(SacramentType.Marriage);
        }
        //========================================================================================================================


        //APPLICATION FILTER COMBOBOX SELECTED INDEX CHANGED======================================================================
        private void baptismApplication_filter_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control c = sender as Control;
            if(c.Focused)
                applicationFilter(SacramentType.Baptism);
        }

        private void confirmationApplication_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control c = sender as Control;
            if (c.Focused)
                applicationFilter(SacramentType.Confirmation);
        }

        private void marriageApplication_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control c = sender as Control;
            if (c.Focused)
                applicationFilter(SacramentType.Marriage);
        }
        //========================================================================================================================



        // APPLICATION EDIT CHECK CHANGED=======================================================================================
        private void baptismApplication_edit_check_CheckedChanged(object sender, EventArgs e)
        {
            applicationEditCheckChanged(SacramentType.Baptism);
        }
        private void confirmationApplication_edit_check_CheckedChanged(object sender, EventArgs e)
        {
            applicationEditCheckChanged(SacramentType.Confirmation);
        }

        private void marriageApplication_edit_check_CheckedChanged(object sender, EventArgs e)
        {
            applicationEditCheckChanged(SacramentType.Marriage);
        }

        //=======================================================================================================================

        

        

        //APPLICATION DGV CELL ENTER==============================================================================================
        private void baptismApplication_dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            loadApplicationDetails(SacramentType.Baptism);
        }

        private void confirmationApplication_dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            loadApplicationDetails(SacramentType.Confirmation);
        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void marriageApplication_dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            loadApplicationDetails(SacramentType.Marriage);
        }

        //=========================================================================================================================

        /// <summary>
        /// Recursively clears the Controls inside a Control
        /// </summary>
        /// <param name="c"></param>
        private void RecursiveClearControl(Control c)
        {
            //Console.WriteLine("ENTERED RECURSIVE CLEAR");
            if (c.Controls.Count == 0)
                return;
            else
            {
                foreach (Control con in c.Controls)
                {

                    if (con is TextBox)
                    {
                        TextBox a = con as TextBox;
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
                    else if (con.Tag != null && con.Tag.ToString() == "detail" && con is Label)
                    {
                        Console.WriteLine("ENTERED LABEL");
                        Label a = con as Label;
                        a.Text = "";
                    }
                    else if (con.Controls.Count > 0)
                    {
                        RecursiveClearControl(con);
                    }
                }
            }
        }

        private void cbMarEdit_VisibleChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Edit visible changed! mar");

            //if (cbMarEdit.Checked)
            //{
            //    applicationEditCheckChanged(SacramentType.Marriage);
            //}
        }

        private void cbConEdit_VisibleChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Edit visible changed! con");

            //if (cbConEdit.Checked)
            //{
            //    applicationEditCheckChanged(SacramentType.Confirmation);
            //}
        }

        private void cbBapEdit_VisibleChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Edit visible changed! bap");

            //if (cbBapEdit.Checked)
            //{
            //    applicationEditCheckChanged(SacramentType.Baptism);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuditModule f = new AuditModule();
            f.Show();
        }

        private void applicationTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void clearApplicationsDetailsPanel(SacramentType t)
        {
            Panel applicataionDetailsPanel;

            if (t == SacramentType.Baptism)
                applicataionDetailsPanel = baptismApplicationDetailsPanel;
            else if (t == SacramentType.Confirmation)
                applicataionDetailsPanel = confirmationApplicationDetailsPanel;
            else
                applicataionDetailsPanel = marriageApplicationDetailsPanel;


            applicataionDetailsPanel.Enabled = false;
            RecursiveClearControl(applicataionDetailsPanel);
        }

        private void applicationEditCheckChanged(SacramentType type)
        {


            TableLayoutPanel tlpProfile;
            GroupBox gbReq;
            CheckBox checkEdit;
            Panel approveRevokePanel;
            if (type == SacramentType.Baptism)
            {
                tlpProfile = baptismApplication_profile_tlp;
                gbReq = baptismApplication_requirements_groupbox;
                checkEdit = cbBapEdit;
                approveRevokePanel = baptismApplication_buttons_panel;

            }
            else if (type == SacramentType.Confirmation)
            {
                tlpProfile = confirmationApplication_profile_tlp;
                gbReq = confirmationApplication_requirements_groupbox;
                checkEdit = cbConEdit;
                approveRevokePanel = confirmationApplication_buttons_panel;
            }
            else
            {
                tlpProfile = marriageApplication_profile_tlp;
                gbReq = marriageApplication_requirements_groupbox;
                checkEdit = cbMarEdit;
                approveRevokePanel = marriageApplication_buttons_panel;
            }
            

            if (!checkEdit.Checked)
            {
                if (!allFilled(type))
                {
                    Notification.Show(State.MissingFields);
                    return;
                }

                checkEdit.Text = "Edit";
                editApplicationProfile(type);
                clearApplicationsDetailsPanel(type);
            }
            else
            {
                checkEdit.Text = "Save";
            }

            tlpProfile.Visible = checkEdit.Checked;
            gbReq.Enabled = checkEdit.Checked;
            approveRevokePanel.Enabled = !checkEdit.Enabled;
        }

        /// <summary>
        /// Indicates whether the required name fields of an application detail panel is filled
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private bool allFilled(SacramentType t)
        {
            bool success;
            if (t == SacramentType.Baptism)
                success = string.IsNullOrWhiteSpace(txtBapFN.Text) || string.IsNullOrWhiteSpace(txtBapMI.Text) || string.IsNullOrWhiteSpace(txtBapLN.Text);
            else if (t == SacramentType.Confirmation)
                success = string.IsNullOrWhiteSpace(txtConFN.Text) || string.IsNullOrWhiteSpace(txtConMI.Text) || string.IsNullOrWhiteSpace(txtConLN.Text);
            else
                success = string.IsNullOrWhiteSpace(txtGFN.Text) || string.IsNullOrWhiteSpace(txtGMI.Text) || string.IsNullOrWhiteSpace(txtGLN.Text)
                    && string.IsNullOrWhiteSpace(txtBFN.Text) || string.IsNullOrWhiteSpace(txtBMI.Text) || string.IsNullOrWhiteSpace(txtBLN.Text);
            return !success;
        }
    }
}
