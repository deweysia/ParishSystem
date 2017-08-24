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
    public partial class MarriageForm : Form
    {
        DataHandler dh;
        DataGridViewCellCollection row;
        //Some controls have Tag set to 'o' for optional
        public MarriageForm(DataGridViewRow dgvr)
        {
            InitializeComponent();

            this.dh = DataHandler.getDataHandler();
            this.row = dgvr.Cells;

            cmbBStatus.DataSource = Enum.GetValues(typeof(CivilStatus));
            cmbGStatus.DataSource = cmbBStatus.DataSource;

            DataTable dt = dh.getMinisterWithStatus(MinisterStatus.Active);

            foreach (DataRow r in dt.Rows)
            {
                ComboboxContent cc = new ComboboxContent(int.Parse(r["ministerID"].ToString()), r["name"].ToString());
                cmbMinister.Items.Add(cc);
            }

            lblGName.Text = row[4].Value.ToString();
            lblBName.Text = row[6].Value.ToString();

            loadParents();

        }

        private void MarriageForm_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddSponsor_Click(object sender, EventArgs e)
        {
            string fn = txtSponsorFN.Text;
            string mi = txtSponsorMI.Text;
            string ln = txtSponsorLN.Text;
            string suffix = txtSponsorSuffix.Text;

            string res = txtSponsorResidence.Text;

            Gender g = radioMale.Checked ? Gender.Male : Gender.Female;

            int i = dgvSponsor.Rows.Add();
            
            dgvSponsor.Rows[i].Cells["firstName"].Value = fn;
            dgvSponsor.Rows[i].Cells["midName"].Value = mi;
            dgvSponsor.Rows[i].Cells["lastName"].Value = ln;
            dgvSponsor.Rows[i].Cells["suffix"].Value = suffix;
            dgvSponsor.Rows[i].Cells["residence"].Value = res;
            dgvSponsor.Rows[i].Cells["gender"].Value = radioMale.Checked ? 1 : 2;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!allFilled())
            {
                MessageDialog.Show("Please input all necessary fields!", "Missing fields", MessageDialogButtons.OK, MessageDialogIcon.Warning);
                return;
            }

            //get applicationID
            int applicationID = int.Parse(row[0].Value.ToString());

            //get groomID, brideID
            int groomID = int.Parse(row[1].Value.ToString());
            int brideID = int.Parse(row[2].Value.ToString());
            int ministerID = Convert.ToInt32(((ComboboxContent)cmbMinister.SelectedItem).ID);
            DateTime licenseDate = dtpLicenseDate.Value;
            DateTime marriageDate = dtpMarriageDate.Value;
            CivilStatus groomCS = (CivilStatus)cmbGStatus.SelectedValue;
            CivilStatus brideCS = (CivilStatus)cmbBStatus.SelectedValue;

            bool success = true;

            DataGridViewRowCollection sponsors = dgvSponsor.Rows;

            //update genprof for groom and bride to add residence and birthplace
            success &= dh.editGeneralProfile(groomID, txtGResidence.Text, txtGBirthPlace.Text);
            success &= dh.editGeneralProfile(brideID, txtBResidence.Text, txtBBirthPlace.Text);

            //Adds or edits parents depending on whether they exist or not
            success &= dh.addEditParent(groomID, txtGFFN.Text, txtGFMI.Text, txtGFLN.Text, txtGFSuffix.Text, Gender.Male);
            success &= dh.addEditParent(groomID, txtGMFN.Text, txtGMMI.Text, txtGMLN.Text, txtGMSuffix.Text, Gender.Female);

            success &= dh.addEditParent(brideID, txtBFFN.Text, txtBFMI.Text, txtBFLN.Text, txtBFSuffix.Text, Gender.Male);
            success &= dh.addEditParent(brideID, txtBMFN.Text, txtBMMI.Text, txtBMLN.Text, txtBMSuffix.Text, Gender.Female);

            foreach (DataGridViewRow r in sponsors)
            {
                string fn = r.Cells[0].Value.ToString();
                string mi = r.Cells[1].Value.ToString();
                string ln = r.Cells[2].Value.ToString();
                string suffix = r.Cells[3].Value.ToString();
                Gender g = (Gender)r.Cells[4].Value;
                string residence = r.Cells[5].Value.ToString();
                success &= dh.addSponsor(applicationID, fn, mi, ln, suffix, g, residence);
            }

            dh.editApplication(applicationID, ApplicationStatus.Approved);
            dh.addMarriage(applicationID, ministerID, licenseDate, marriageDate, groomCS, brideCS);
            this.DialogResult = success ? DialogResult.OK : DialogResult.None;
        }

        private bool allFilled()
        {
            bool allFilled = true;
            foreach (Control c in this.Controls)
            {
                if (c is TextBox && c.Tag == null)
                {
                    TextBox t = c as TextBox;
                    allFilled &= !string.IsNullOrWhiteSpace(t.Text);
                    if (!allFilled)
                    {
                        MessageBox.Show("Error at " + t.Name.ToString());
                        return false;
                    }

                }
            }

            allFilled &= cmbMinister.SelectedIndex != -1;

            return allFilled;
        }

        private void dgvSponsor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 7)//Gender
                e.Value = e.Value.ToString() == "1" ? "M" : "F";
        }

        private void loadParents()
        {
            int groomID = int.Parse(row[2].Value.ToString());
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

            int brideID = int.Parse(row[3].Value.ToString());
            dt = dh.getParentsOf(groomID);

            if (dt.Rows.Count == 2)
            {
                txtGFFN.Text = dt.Rows[0]["firstName"].ToString();
                txtGFFN.Text = dt.Rows[0]["midName"].ToString();
                txtGFFN.Text = dt.Rows[0]["lastName"].ToString();
                txtGFFN.Text = dt.Rows[0]["suffix"].ToString();
                txtGFFN.Text = dt.Rows[0]["birthplace"].ToString();


                txtGMFN.Text = dt.Rows[1]["firstName"].ToString();
                txtGMFN.Text = dt.Rows[1]["midName"].ToString();
                txtGMFN.Text = dt.Rows[1]["lastName"].ToString();
                txtGMFN.Text = dt.Rows[1]["suffix"].ToString();
                txtGMFN.Text = dt.Rows[1]["birthplace"].ToString();
            }

        }
    }
}
