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
        OperationType operation;
        
        public SacramentForm(OperationType operation, SacramentType type, DataGridViewRow dr)
        {
            InitializeComponent();

            this.dh = DataHandler.getDataHandler();
            this.row = dr.Cells;
            this.type = type;
            this.operation = operation;

            Draggable drag = new Draggable(this);
            drag.makeDraggable(controlBar_panel);

            sacramentDateDTP.MinDate = DateTime.ParseExact(row[9].Value.ToString(), "yyyy-MM-dd", null);

            if (type == SacramentType.Confirmation)
            {
                legitimacyCBox.Hide();
                label3.Hide();
                sacramentDateLabel.Text = "Confirmation Date";
                this.Text = "Confirmation Fill-up Form";
            }

            //4 - First Name 5 - MI 6 - Last Name   7 - Suffix
            nameLabel.Text = string.Format("{0} {1}. {2} {3}", row[4].Value, row[5].Value, row[6].Value, row[7].Value);
            birthdateLabel.Text = row[9].Value.ToString();
            genderLabel.Text = row[8].Value.ToString() == "1" ? "Male" : "Female";


            legitimacyCBox.DataSource = Enum.GetValues(typeof(Legitimacy));
            loadMinisters();
            loadParents();

            if(operation == OperationType.Edit)
            {
                loadSponsors();
            }

            MinisterCBox.SelectedIndex = 0;
        }

        private void SacramentForm_Load(object sender, EventArgs e)
        {
            
           
        }

        /// <summary>
        /// Loads ministers into a combobox
        /// </summary>
        private void loadMinisters()
        {
            
            DataTable dt;
            if (type == SacramentType.Confirmation)
            {//Only Archbishop and Mosignor can perform confirmation
                dt = dh.getMinisters(MinistryType.Archbishop, MinisterStatus.Active);
                DataTable dt2 = dh.getMinisters(MinistryType.Mosignor, MinisterStatus.Active);
                dt.Merge(dt2);
            }
            else
            {//All ministers can perform baptism
                dt = dh.getMinisters(MinisterStatus.Active);
            }

            MinisterCBox.Items.Add(""); //First item of ministerCBox is empty
            foreach (DataRow r in dt.Rows)
            {
                ComboboxContent cc = new ComboboxContent(int.Parse(r["ministerID"].ToString()), r["name"].ToString());
                MinisterCBox.Items.Add(cc);
            }
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

        private void loadSponsors()
        {
            int applicationID = int.Parse(row[0].Value.ToString());
            DataTable dt = dh.getSponsors(applicationID);

            gFatherFirstNameText.Text = dt.Rows[0]["firstName"].ToString();
            gFatherMiText.Text = dt.Rows[0]["midName"].ToString();
            gFatherLastNameText.Text = dt.Rows[0]["lastName"].ToString();
            gFatherSuffixText.Text = dt.Rows[0]["suffix"].ToString();
            gFatherResidenceText.Text = dt.Rows[0]["residence"].ToString();

            gMotherFirstNameText.Text = dt.Rows[1]["firstName"].ToString();
            gMotherMiText.Text = dt.Rows[1]["midName"].ToString();
            gMotherLastNameText.Text = dt.Rows[1]["lastName"].ToString();
            gMotherSuffixText.Text = dt.Rows[1]["suffix"].ToString();
            gMotherResidenceText.Text = dt.Rows[1]["residence"].ToString();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (!allFilled())
            {
                Notification.Show(State.MissingFields);
                return;
            }

            int applicationID = int.Parse(row[0].Value.ToString());
            int profileID = int.Parse(row[1].Value.ToString());

            int ministerID = ((ComboboxContent)MinisterCBox.SelectedItem).ID;
            Legitimacy l = (Legitimacy)legitimacyCBox.SelectedItem;
            DateTime dt = sacramentDateDTP.Value;
            string remarks = remarksText.Text;


            if (operation == OperationType.Add)
                addOperation(applicationID, profileID, ministerID, l, dt, remarks);
            else editOperation(applicationID, profileID, ministerID, l, dt, remarks);
               
        }

        private void editOperation(int applicationID, int profileID, int ministerID, Legitimacy legitimacy, DateTime sacramentDate, string remarks)
        {
            bool success = true;
            if (type == SacramentType.Baptism)
                success &= dh.editBaptism(applicationID, ministerID, sacramentDate, legitimacy, remarks);
            else
                success &= dh.editConfirmation(applicationID, ministerID, sacramentDate, remarks);


            //Add Mother
            success &= dh.addEditParent(profileID, motherFirstNameText.Text, motherMiText.Text, motherLastNameText.Text, motherSuffixText.Text, Gender.Female, motherBirthPlaceText.Text);
            //Add Father
            success &= dh.addEditParent(profileID, fatherFirstNameText.Text, fatherMiText.Text, fatherLastNameText.Text, fatherSuffixText.Text, Gender.Male, fatherBirthPlaceText.Text);

            //Add God Mother
            success &= dh.editSponsor(applicationID, gMotherFirstNameText.Text, gMotherMiText.Text, gMotherLastNameText.Text, gMotherSuffixText.Text, Gender.Female, gMotherResidenceText.Text);
            //Add God Father
            success &= dh.editSponsor(applicationID, gFatherFirstNameText.Text, gFatherMiText.Text, gFatherLastNameText.Text, gFatherSuffixText.Text, Gender.Male, gFatherResidenceText.Text);

            dh.editApplication(applicationID, ApplicationStatus.Approved);

            this.DialogResult = success ? DialogResult.OK : DialogResult.None;
        }

        private void addOperation(int applicationID, int profileID, int ministerID, Legitimacy legitimacy, DateTime sacramentDate, string remarks)
        {
            
            bool success = true;
            if (type == SacramentType.Baptism)
                success &= dh.addBaptism(applicationID, ministerID, legitimacy, sacramentDate, remarks);
            else
                success &= dh.addConfirmation(applicationID, ministerID, sacramentDate, remarks);


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

            allFilled &= MinisterCBox.SelectedIndex != 0;

            return allFilled;
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void baptismDateDTP_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
