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
    public partial class BaptismForm : Form
    {

        DataHandler dh;
        DataGridViewCellCollection row;
        public BaptismForm(DataGridViewRow dr, DataHandler dh)
        {
            this.dh = dh;
            this.row = dr.Cells;

            

            InitializeComponent();

            nameLabel.Text = string.Format("{0} {1}. {2} {3}", row["firstName"].Value, row["midName"].Value, row["lastName"].Value, row["suffix"].Value);
            birthdateLabel.Text = row["birthdate"].Value.ToString();
            genderLabel.Text = row["gender"].ToString() == "1" ? "Male" : "Female";
        }

        private void BaptismForm_Load(object sender, EventArgs e)
        {
            legitimacyCBox.DataSource = Enum.GetValues(typeof(Legitimacy));
            DataTable dt = dh.getMinisterWithStatus(MinisterStatus.Active);
            
            foreach(DataRow r in dt.Rows)
            {
                
                ComboboxContent cc = new ComboboxContent(int.Parse(r["ministerID"].ToString()), r["name"].ToString());
                //MessageBox.Show(cc.ToString());
                MinisterCBox.Items.Add(cc);
            }
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (!allFilled())
            {
                MessageDialog.Show("Please input all necessary fields!", "Missing fields", MessageDialogButtons.OK, MessageDialogIcon.Warning);
                return;
            }

            int applicationID = int.Parse(row["applicationID"].Value.ToString());
            int profileID = int.Parse(row["profileID"].Value.ToString());

            int ministerID = ((ComboboxContent)MinisterCBox.SelectedItem).ID;
            Legitimacy l = (Legitimacy)legitimacyCBox.SelectedItem;
            DateTime dt = baptismDateDTP.Value;
            string remarks = remarksText.Text;


            bool success = true;
            success &= dh.addBaptism(applicationID, ministerID, l, dt, remarks);

            //Add Mother
            success &= dh.addParent(profileID, motherFirstNameText.Text, motherMiText.Text, motherLastNameText.Text, motherSuffixText.Text, Gender.Female, motherBirthPlaceText.Text);
            //Add Father
            success &= dh.addParent(profileID, fatherFirstNameText.Text, fatherMiText.Text, fatherLastNameText.Text, fatherSuffixText.Text, Gender.Male, fatherBirthPlaceText.Text);

            //Add God Mother
            success &= dh.addSponsor(applicationID, gMotherFirstNameText.Text, gMotherMiText.Text, gMotherLastNameText.Text, gMotherSuffixText.Text, Gender.Female, gMotherResidenceText.Text);
            //Add God Father
            success &= dh.addSponsor(applicationID, gFatherFirstNameText.Text, gFatherMiText.Text, gFatherLastNameText.Text, gFatherSuffixText.Text, Gender.Male, gFatherResidenceText.Text);

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
