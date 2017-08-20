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
    public partial class SacramentForm : Form
    {

        DataHandler dh;
        DataGridViewCellCollection row;
        SacramentType type;
        public SacramentForm(SacramentType type, DataGridViewRow dr)
        {
            InitializeComponent();

            this.dh = DataHandler.getDataHandler();
            this.row = dr.Cells;
            this.type = type;

            if (type == SacramentType.Confirmation)
            {
                legitimacyCBox.Hide();
                label3.Hide();
                sacramentDateLabel.Text = "Confirmation Date";
                this.Text = "Confirmation Fill-up Form";
            }

            //3 - Last Name    4 - First Name   5 - MI  6 - Suffix
            nameLabel.Text = string.Format("{0} {1}. {2} {3}", row[4].Value, row[5].Value, row[3].Value, row[6].Value);
            birthdateLabel.Text = row[8].Value.ToString();
            genderLabel.Text = row[7].ToString() == "1" ? "Male" : "Female";
        }

        private void SacramentForm_Load(object sender, EventArgs e)
        {
            legitimacyCBox.DataSource = Enum.GetValues(typeof(Legitimacy));
            DataTable dt = dh.getMinisterWithStatus(MinisterStatus.Active);
            
            foreach(DataRow r in dt.Rows)
            {
                
                ComboboxContent cc = new ComboboxContent(int.Parse(r["ministerID"].ToString()), r["name"].ToString());
                //MessageBox.Show(cc.ToString());
                MinisterCBox.Items.Add(cc);
            }

            loadParents();
           
        }

        private void loadParents()
        {
            int profileID = int.Parse(row[1].Value.ToString());
            DataTable dt = dh.getParentsOf(profileID);
            if(dt.Rows.Count == 2)
            {
                fatherFirstNameText.Text = dt.Rows[0]["firstName"].ToString();
                fatherMiText.Text = dt.Rows[0]["midName"].ToString();
                fatherLastNameText.Text = dt.Rows[0]["lastName"].ToString();
                fatherSuffixText.Text = dt.Rows[0]["suffix"].ToString();
                fatherBirthPlaceText.Text = dt.Rows[0]["birthplace"].ToString();

                motherFirstNameText.Text = dt.Rows[1]["firstName"].ToString();
                motherMiText.Text = dt.Rows[1]["midName"].ToString();
                motherLastNameText.Text = dt.Rows[1]["lastName"].ToString();
                motherSuffixText.Text = dt.Rows[1]["suffix"].ToString();
                motherBirthPlaceText.Text = dt.Rows[1]["birthplace"].ToString();
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (!allFilled())
            {
                MessageDialog.Show("Please input all necessary fields!", "Missing fields", MessageDialogButtons.OK, MessageDialogIcon.Warning);
                return;
            }

            int applicationID = int.Parse(row[0].Value.ToString());
            int profileID = int.Parse(row[1].Value.ToString());

            int ministerID = ((ComboboxContent)MinisterCBox.SelectedItem).ID;
            Legitimacy l = (Legitimacy)legitimacyCBox.SelectedItem;
            DateTime dt = baptismDateDTP.Value;
            string remarks = remarksText.Text;


            bool success = true;
            if (type == SacramentType.Baptism)
                success &= dh.addBaptism(applicationID, ministerID, l, dt, remarks);
            else
                success &= dh.addConfirmation(applicationID, ministerID, dt, remarks);


            //Add Mother
            success &= dh.addEditParent(profileID, motherFirstNameText.Text, motherMiText.Text, motherLastNameText.Text, motherSuffixText.Text, Gender.Female, motherBirthPlaceText.Text);
            //Add Father
            success &= dh.addEditParent(profileID, fatherFirstNameText.Text, fatherMiText.Text, fatherLastNameText.Text, fatherSuffixText.Text, Gender.Male, fatherBirthPlaceText.Text);

            //Add God Mother
            success &= dh.addSponsor(applicationID, gMotherFirstNameText.Text, gMotherMiText.Text, gMotherLastNameText.Text, gMotherSuffixText.Text, Gender.Female, gMotherResidenceText.Text);
            //Add God Father
            success &= dh.addSponsor(applicationID, gFatherFirstNameText.Text, gFatherMiText.Text, gFatherLastNameText.Text, gFatherSuffixText.Text, Gender.Male, gFatherResidenceText.Text);

            dh.editApplication(applicationID, ApplicationStatus.Approved);

            this.DialogResult = success ? DialogResult.OK : DialogResult.None;
        }

        private bool allFilled()
        {
            bool allFilled = true;
            foreach(Control c in this.Controls)
            {
                if(c is TextBox && c.Tag == null)
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

            allFilled &= MinisterCBox.SelectedIndex != -1;

            return allFilled;
        }
    }
}
