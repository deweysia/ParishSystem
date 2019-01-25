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
        DataRow row;
        SacramentType type;
        OperationType operation;


        public SacramentForm(OperationType operation, SacramentType type, DataRow dr)
        {
            InitializeComponent();

            this.dh = DataHandler.getDataHandler();
            this.row = dr;
            this.type = type;
            this.operation = operation;

            Draggable drag = new Draggable(this);
            drag.makeDraggable(controlBar_panel);

            

            if (type == SacramentType.Confirmation)
            {
                legitimacyCBox.Hide();
                label3.Hide();
                sacramentDateLabel.Text = "Confirmation Date";
                this.Text = "Confirmation Fill-up Form";
            }

            int profileID = Convert.ToInt32(row["profileID"].ToString());
            DataTable dt = dh.getGeneralProfile(profileID);

            

            //4 - First Name 5 - MI 6 - Last Name   7 - Suffix
            nameLabel.Text = string.Format("{0} {1}. {2} {3}", row["firstName"], row["midName"], row["lastName"], row["suffix"]);
            //MessageBox.Show(dt.Rows[0]["birthDate"].ToString());
            //birthdateLabel.Text = DateTime.ParseExact(dt.Rows[0]["birthDate"].ToString(), "dd/MM/yyyy hh:mm:ss tt", null).ToString("yyyy-MM-dd");
            genderLabel.Text = dt.Rows[0]["gender"].ToString() == "1" ? "Male" : "Female";

            txtBirthplace.Text = dt.Rows[0]["birthplace"].ToString();
            legitimacyCBox.DataSource = Enum.GetValues(typeof(Legitimacy));
            loadMinisters();
            loadParents();

            if(operation == OperationType.Edit)
            {
                //Baptism Date or COnfirmation Date
                //sacramentDateDTP.MinDate = DateTime.ParseExact(dt.Rows[0]["birthdate"].ToString(), "dd/MM/yyyy hh:mm:ss tt", null);
                remarksText.Text = row["remarks"].ToString();
                loadSponsors();
            }

            
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

            ComboboxContent empty = new ComboboxContent(-1, "");
            MinisterCBox.Items.Add(empty); //First item of ministerCBox is empty
            foreach (DataRow r in dt.Rows)
            {
                int ministerID = int.Parse(r["ministerID"].ToString());
                ComboboxContent cc = new ComboboxContent(ministerID, r["name"].ToString());
                //MessageBox.Show("Minister = " + r["name"].ToString());
                MinisterCBox.Items.Add(cc);
            }

            MinisterCBox.SelectedIndex = 0;

            //If Operation is Edit, then load sacrament minister
            if (operation == OperationType.Edit)
            {
                int sacramentMinisterID = Convert.ToInt32(row["ministerID"].ToString());

                int index = 0;
                //MessageBox.Show(string.Format("MinisterID is {0}: ", sacramentMinisterID.ToString()));
                foreach (ComboboxContent cc in MinisterCBox.Items)
                {
                    //Console.WriteLine(string.Format("cc.id == sacramentMinisterID - {0} == {1}; Index is {2}", cc.id, sacramentMinisterID, index));
                    if(cc != null && cc.id == sacramentMinisterID)
                    {
                        MinisterCBox.SelectedIndex = index;
                        
                        break;
                    }
                    index++;
                }
                
            }
        }

        private void loadParents()
        {
            int profileID = int.Parse(row["profileID"].ToString());
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
            int applicationID = int.Parse(row["applicationID"].ToString());
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

            int applicationID = int.Parse(row["applicationID"].ToString());
            int profileID = int.Parse(row["profileID"].ToString());

            int ministerID = ((ComboboxContent)MinisterCBox.SelectedItem).ID;
            Legitimacy l = (Legitimacy)legitimacyCBox.SelectedItem;
            DateTime dt = sacramentDateDTP.Value;
            string remarks = remarksText.Text;
            //MessageBox.Show("VIOLA");


            bool success = dh.editPlaceOfBirth(profileID, txtBirthplace.Text.Trim());
            if (operation == OperationType.Add)
                success &= addOperation(applicationID, profileID, ministerID, l, dt, remarks);
            else success &= editOperation(applicationID, profileID, ministerID, l, dt, remarks);

            this.DialogResult = success ? DialogResult.OK : DialogResult.None;

        }

        private bool editOperation(int applicationID, int profileID, int ministerID, Legitimacy legitimacy, DateTime sacramentDate, string remarks)
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

            success &= dh.editApplication(applicationID, ApplicationStatus.Approved);

            return success;
            //this.DialogResult = success ? DialogResult.OK : DialogResult.None;
            //MessageBox.Show("I Should close now");
        }

        private bool addOperation(int applicationID, int profileID, int ministerID, Legitimacy legitimacy, DateTime sacramentDate, string remarks)
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

            success &= dh.editApplication(applicationID, ApplicationStatus.Approved);

            return success;
            //MessageBox.Show("I Should close now");
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
                        //MessageBox.Show("Error at " + t.Name.ToString());
                        return false;
                    }
                        
                }
            }

            allFilled &= MinisterCBox.SelectedIndex != 0;

            return allFilled;
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void baptismDateDTP_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
