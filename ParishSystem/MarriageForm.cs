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
using System.Data;

namespace ParishSystem
{
    public partial class MarriageForm : Form
    {
        DataHandler dh;
        DataRow row;
        OperationType operation;

        private int sponsor1ID, sponsor2ID;
        //Some controls have Tag set to 'o' for optional
        public MarriageForm(OperationType operation, DataRow dr)
        {
            InitializeComponent();

            Draggable drag = new Draggable(this);
            drag.makeDraggable(controlBar_panel);

            this.dh = DataHandler.getDataHandler();
            this.row = dr;
            this.operation = operation;

            cmbBStatus.DataSource = Enum.GetValues(typeof(CivilStatus));
            cmbGStatus.DataSource = Enum.GetValues(typeof(CivilStatus));

            lblGName.Text = row[6].ToString();
            lblBName.Text = row[8].ToString();

            loadMinisters();
            loadParents();
            
            if (this.operation == OperationType.Edit)
            {
                loadSponsors();
                loadAdditionalDetails();
            }
        }

        private void loadMinisters()
        {
            DataTable dt = dh.getMinisters(MinisterStatus.Active);

            ComboboxContent empty = new ComboboxContent(-1, "");
            cmbMinister.Items.Add(empty);

            foreach (DataRow r in dt.Rows)
            {
                ComboboxContent cc = new ComboboxContent(int.Parse(r["ministerID"].ToString()), r["name"].ToString());
                cmbMinister.Items.Add(cc);
            }

            if(operation == OperationType.Edit)
            {
                int index = 0;
                int ministerID = Convert.ToInt32(row["ministerID"].ToString());
                //MessageBox.Show(string.Format("MinisterID is {0}: ", sacramentMinisterID.ToString()));
                foreach (ComboboxContent cc in cmbMinister.Items)
                {
                    //Console.WriteLine(string.Format("cc.id == sacramentMinisterID - {0} == {1}; Index is {2}", cc.id, sacramentMinisterID, index));
                    if (cc != null && cc.id == ministerID)
                    {
                        cmbMinister.SelectedIndex = index;

                        break;
                    }
                    index++;
                }
            }


        }


        private void loadSponsors()
        {
            int applicationID = int.Parse(row["applicationID"].ToString());
            DataTable dt = dh.getSponsors(applicationID);

            this.sponsor1ID = Convert.ToInt32(dt.Rows[0]["sponsorID"].ToString());
            txtSponsor1FN.Text = dt.Rows[0]["firstName"].ToString();
            txtSponsor1MI.Text = dt.Rows[0]["midName"].ToString();
            txtSponsor1LN.Text = dt.Rows[0]["lastName"].ToString();
            txtSponsor1Suffix.Text = dt.Rows[0]["suffix"].ToString();
            txtSponsor1Residence.Text = dt.Rows[0]["residence"].ToString();

            this.sponsor2ID = Convert.ToInt32(dt.Rows[1]["sponsorID"].ToString());
            txtSponsor2FN.Text = Text = dt.Rows[1]["firstName"].ToString();
            txtSponsor2MI.Text = dt.Rows[1]["midName"].ToString();
            txtSponsor2LN.Text = dt.Rows[1]["lastName"].ToString();
            txtSponsor2Suffix.Text = dt.Rows[1]["suffix"].ToString();
            txtSponsor2Residence.Text = dt.Rows[1]["residence"].ToString();
        }

        private void loadAdditionalDetails()
        {
            int groomID = Convert.ToInt32(row["groomID"].ToString());
            int brideID = Convert.ToInt32(row["brideID"].ToString());
            int applicationID = int.Parse(row["applicationID"].ToString());

            DataTable dt = dh.getGeneralProfile(groomID);
            txtGResidence.Text = dt.Rows[0]["residence"].ToString();
            txtGBirthPlace.Text = dt.Rows[0]["birthplace"].ToString();

            dt = dh.getGeneralProfile(brideID);
            txtBResidence.Text = dt.Rows[0]["residence"].ToString();
            txtBBirthPlace.Text = dt.Rows[0]["birthplace"].ToString();


            Marriage m = dh.getMarriageObject(applicationID);
            dtpMarriageDate.Value = m.sacramentDate;
            dtpLicenseDate.Value = m.licenseDate;
            txtRemarks.Text = m.remarks;
            cmbGStatus.SelectedIndex = ((int)m.groomStatus ) - 1;
            cmbBStatus.SelectedIndex = ((int)m.brideStatus) - 1;

            

        }



        private void MarriageForm_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //private void btnAddSponsor_Click(object sender, EventArgs e)
        //{
        //    string fn = txtSponsor1FN.Text;
        //    string mi = txtSponsor1MI.Text;
        //    string ln = txtSponsor1LN.Text;
        //    string suffix = txtSponsor1Suffix.Text;

        //    string res = txtSponsor1Residence.Text;

        //    Gender g = radioSponsor1Male.Checked ? Gender.Male : Gender.Female;

        //    int i = dgvSponsor.Rows.Add();
            
        //    dgvSponsor.Rows[i].Cells["firstName"].Value = fn;
        //    dgvSponsor.Rows[i].Cells["midName"].Value = mi;
        //    dgvSponsor.Rows[i].Cells["lastName"].Value = ln;
        //    dgvSponsor.Rows[i].Cells["suffix"].Value = suffix;
        //    dgvSponsor.Rows[i].Cells["residence"].Value = res;
        //    dgvSponsor.Rows[i].Cells["gender"].Value = radioSponsor1Male.Checked ? 1 : 2;

        //    txtSponsor1FN.Text = "";
        //    txtSponsor1MI.Text = "";
        //    txtSponsor1LN.Text = "";
        //    txtSponsor1Suffix.Text = "";
        //    txtSponsor1Residence.Text = "";
        //    radioSponsor1Male.Select();

        //    btnAddSponsor.Enabled = !(dgvSponsor.Rows.Count == 2);
        //}

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!allFilled())
            {
                MessageDialog.Show("Please input all necessary fields!", "Missing fields", MessageDialogButtons.OK, MessageDialogIcon.Warning);
                return;
            }

            //get applicationID
            int applicationID = int.Parse(row["applicationID"].ToString());

            //get groomID, brideID
            int groomID = int.Parse(row["groomID"].ToString());
            int brideID = int.Parse(row["brideID"].ToString());
            
            DateTime licenseDate = dtpLicenseDate.Value;
            DateTime marriageDate = dtpMarriageDate.Value;
            CivilStatus groomCS = (CivilStatus)cmbGStatus.SelectedValue;
            CivilStatus brideCS = (CivilStatus)cmbBStatus.SelectedValue;
            int ministerID = Convert.ToInt32(((ComboboxContent)cmbMinister.SelectedItem).id);
            string remarks = txtRemarks.Text;

            bool success = true;

            //DataGridViewRowCollection sponsors = dgvSponsor.Rows;

            //update genprof for groom and bride to add residence and birthplace
            success &= dh.editGeneralProfile(groomID, txtGResidence.Text, txtGBirthPlace.Text);
            success &= dh.editGeneralProfile(brideID, txtBResidence.Text, txtBBirthPlace.Text);

            //MessageBox.Show(string.Format("GROOM {0} BRIDE {1}", txtGBirthPlace.Text, txtBBirthPlace.Text));
            //Adds or edits parents depending on whether they exist or not
            success &= dh.addEditParent(groomID, txtGFFN.Text, txtGFMI.Text, txtGFLN.Text, txtGFSuffix.Text, Gender.Male);
            success &= dh.addEditParent(groomID, txtGMFN.Text, txtGMMI.Text, txtGMLN.Text, txtGMSuffix.Text, Gender.Female);

            success &= dh.addEditParent(brideID, txtBFFN.Text, txtBFMI.Text, txtBFLN.Text, txtBFSuffix.Text, Gender.Male);
            success &= dh.addEditParent(brideID, txtBMFN.Text, txtBMMI.Text, txtBMLN.Text, txtBMSuffix.Text, Gender.Female);

            success &= dh.editApplication(applicationID, ApplicationStatus.Approved);
            if (operation == OperationType.Add)
            {
                success &= addOperation(applicationID, ministerID, licenseDate, marriageDate, groomCS, brideCS, remarks);
            }
            else
            {
                success &= editOperation(applicationID, ministerID, licenseDate, marriageDate, groomCS, brideCS, remarks);
            }
            
            //dh.addMarriage(applicationID, ministerID, licenseDate, marriageDate, groomCS, brideCS);
            this.DialogResult = success ? DialogResult.OK : DialogResult.None;
        }


        private bool addOperation(int applicationID, int ministerID, DateTime licenseDate, DateTime marriageDate, CivilStatus groomCS, CivilStatus brideCS, string remarks)
        {
            bool success = true;

            Gender sponsorGender = radioSponsor1Male.Checked ? Gender.Male : Gender.Female;
            success &= dh.addSponsor(applicationID, txtSponsor1FN.Text, txtSponsor1MI.Text, txtSponsor1LN.Text, txtSponsor1Suffix.Text, sponsorGender, txtSponsor1Residence.Text);
            sponsorGender = radioSponsor2Male.Checked ? Gender.Male : Gender.Female;
            success &= dh.addSponsor(applicationID, txtSponsor2FN.Text, txtSponsor2MI.Text, txtSponsor2LN.Text, txtSponsor2Suffix.Text, sponsorGender, txtSponsor2Residence.Text);
            success &= dh.editApplication(applicationID, ApplicationStatus.Approved);
            success &= dh.addMarriage(applicationID, ministerID, licenseDate, marriageDate, groomCS, brideCS, remarks);

            return success;
        }

        private bool editOperation(int applicationID, int ministerID, DateTime licenseDate, DateTime marriageDate, CivilStatus groomCS, CivilStatus brideCS, string remarks)
        {
            bool success = true;
            //MessageBox.Show(ministerID.ToString());
            Gender sponsorGender = radioSponsor1Male.Checked ? Gender.Male : Gender.Female;
            success &= dh.editSponsor(this.sponsor1ID, applicationID, txtSponsor1FN.Text, txtSponsor1MI.Text, txtSponsor1LN.Text, txtSponsor1Suffix.Text, sponsorGender, txtSponsor1Residence.Text);
            sponsorGender = radioSponsor2Male.Checked ? Gender.Male : Gender.Female;
            success &= dh.editSponsor(this.sponsor2ID, applicationID, txtSponsor2FN.Text, txtSponsor2MI.Text, txtSponsor2LN.Text, txtSponsor2Suffix.Text, sponsorGender, txtSponsor2Residence.Text);
            success &= dh.editApplication(applicationID, ApplicationStatus.Approved);
            success &= dh.editMarriage(applicationID, ministerID, licenseDate, marriageDate, groomCS, brideCS, remarks);

            return success;
        }

        private bool allFilled()
        {
            
            bool allFilled = true;

            IEnumerable<Control> controls = panelGroom.Controls.Cast<Control>().Concat(panelBride.Controls.Cast<Control>());

            foreach (Control c in controls)
            {
                Console.WriteLine("Is MetroTextBox? {0} - {1}", c.Name, c is MetroTextBox);
                if (c is MetroTextBox && c.Tag == null)
                {
                    MetroTextBox t = c as MetroTextBox;
                    allFilled &= !string.IsNullOrWhiteSpace(t.Text);
                    Console.WriteLine("All filled? {0}", allFilled);
                    if (!allFilled)
                    {
                        MessageBox.Show("Error at " + t.Name.ToString());
                        return false;
                    }

                }
            }

            allFilled &= cmbMinister.SelectedIndex > 0; //SelectedIndex must not be -1 or 0
            //allFilled &= dgvSponsor.Rows.Count >= 2;

            return allFilled;
        }

        private void dgvSponsor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 7)//Gender
                e.Value = e.Value.ToString() == "1" ? "M" : "F";
        }

        private void loadParents()
        {
            int groomID = int.Parse(row[1].ToString());

            DataTable dt = dh.getParentsOf(groomID);
            if (dt.Rows.Count == 2)
            {
                txtBFFN.Text = dt.Rows[0]["firstName"].ToString();
                txtBFMI.Text = dt.Rows[0]["midName"].ToString();
                txtBFLN.Text = dt.Rows[0]["lastName"].ToString();
                txtBFSuffix.Text = dt.Rows[0]["suffix"].ToString();

                txtBMFN.Text = dt.Rows[1]["firstName"].ToString();
                txtBMMI.Text = dt.Rows[1]["midName"].ToString();
                txtBMLN.Text = dt.Rows[1]["lastName"].ToString();
                txtBMSuffix.Text = dt.Rows[1]["suffix"].ToString();
            }

            int brideID = int.Parse(row[2].ToString());
            dt = dh.getParentsOf(brideID);

            if (dt.Rows.Count == 2)
            {
                txtGFFN.Text = dt.Rows[0]["firstName"].ToString();
                txtGFMI.Text = dt.Rows[0]["midName"].ToString();
                txtGFLN.Text = dt.Rows[0]["lastName"].ToString();
                txtGFSuffix.Text = dt.Rows[0]["suffix"].ToString();

                txtGMFN.Text = dt.Rows[1]["firstName"].ToString();
                txtGMMI.Text = dt.Rows[1]["midName"].ToString();
                txtGMLN.Text = dt.Rows[1]["lastName"].ToString();
                txtGMSuffix.Text = dt.Rows[1]["suffix"].ToString();
            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
