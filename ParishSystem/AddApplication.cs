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
    public partial class AddApplication : Form
    {
        DataHandler dh;
        Point lastClick;
        SacramentType sacramentType;
        DataTable sacramentItem;

        Dictionary<TextBox, string> placeHolderText = new Dictionary<TextBox, string>();
        


        public AddApplication(SacramentType type, DataHandler dh)
        {
            InitializeComponent();
            sacramentType = type;

            this.dh = dh;

            birthdate_dtp.MaxDate = DateTime.Now;
            label1.MouseDown += AddApplication_MouseDown;
            label1.MouseMove += AddApplication_MouseMove;
            panel1.MouseDown += AddApplication_MouseDown;
            panel1.MouseMove += AddApplication_MouseMove;


            //Input up filler text
            placeHolderText.Add(firstName_textBox, "First Name");
            placeHolderText.Add(midName_textBox, "M.I.");
            placeHolderText.Add(lastName_textBox, "Last Name");
            placeHolderText.Add(suffix_textBox, "Suffix");

            //Load filler text
            firstName_textBox.Text = placeHolderText[firstName_textBox];
            midName_textBox.Text = placeHolderText[midName_textBox];
            lastName_textBox.Text = placeHolderText[lastName_textBox];
            suffix_textBox.Text = placeHolderText[suffix_textBox];

            Console.WriteLine("firstName_textBox.Text = placeHolderText[firstName_textBox]; NOT SAME {0}", Object.ReferenceEquals(firstName_textBox.Text, placeHolderText[firstName_textBox]));
            
            applicationNotice_label.MaximumSize = panel1.Size - panel1.Padding.Size;

            this.sacramentType = type;
            label1.Text = sacramentType + " Application";
            sacramentItem = dh.getItem(sacramentType.ToString());
            price_textBox.Text = sacramentItem.Rows[0]["suggestedPrice"].ToString();


            
        }

        private void AddApplication_Load(object sender, EventArgs e)
        {
            
        }

        private void setFormEditable(bool editable)
        {
            firstName_textBox.ReadOnly = editable;
            midName_textBox.ReadOnly = editable;
            lastName_textBox.ReadOnly = editable;
            suffix_textBox.ReadOnly = editable;
            male_radio.Enabled = editable;
            female_radio.Enabled = editable;
            birthdate_dtp.Enabled = editable;
        }


        private void application_apply_button_Click(object sender, EventArgs e)
        {
            if (!allFilled())
            {
                Notification.Show("Please fill in all required details!", NotificationType.info);
                return;
            }
            
            string fn = firstName_textBox.Text;
            string mn = midName_textBox.Text;
            string ln = lastName_textBox.Text;
            string suffix = suffix_textBox.Text == "Suffix" ? null : suffix_textBox.Text;
            Gender gender = male_radio.Checked ? Gender.Male : Gender.Female;
            DateTime birthDate = birthdate_dtp.Value;

            int id = dh.getGeneralProfileID(fn, mn, ln, suffix, gender, birthDate);

            int itemTypeID = int.Parse(sacramentItem.Rows[0]["itemTypeID"].ToString());
            double price = double.Parse(price_textBox.Text);

            if (id == -1) //-1 indicates no such profile exists in the database
            {
                dh.addGeneralProfile(fn, mn ,ln ,suffix ,gender ,birthDate,null,null,null);
                id = dh.getLatestID("GeneralProfile", "profileID");

                bool success = dh.addNewApplicant(id, sacramentType);
                id = dh.getLatestID("Application", "applicationID");
                dh.addSacramentIncome(id, itemTypeID, price, remarks_textBox.Text);
                displayMessage(success);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.AcceptButton = yes_button;
                hiddenTabControl1.SelectedIndex = 1;
            }
        }

        private void displayMessage(bool success)
        {
            if (success)
                Notification.Show("Application Successfully Added!", NotificationType.success);
            else
                Notification.Show("There was an error.", NotificationType.error);
        }

        private void AddApplication_MouseDown(object sender, MouseEventArgs e)
        {
            lastClick = new Point(e.X, e.Y);
            Console.WriteLine("DOWN");
        }

        private void AddApplication_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastClick.X;
                this.Top += e.Y - lastClick.Y;
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = ParishSystem.Properties.Resources.Delete_32px_Light;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = ParishSystem.Properties.Resources.Delete_32px;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = ParishSystem.Properties.Resources.Delete_32px_Gray;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void application_cancel_button_Click(object sender, EventArgs e)
        {
            hiddenTabControl1.SelectedIndex = 0;
        }

        private void application_createNewProfile_button_Click(object sender, EventArgs e)
        {
            string fn = firstName_textBox.Text;
            string mn = midName_textBox.Text;
            string ln = lastName_textBox.Text;
            string suffix = suffix_textBox.Text;
            Gender gender = male_radio.Checked ? Gender.Male : Gender.Female;
            DateTime birthDate = birthdate_dtp.Value;
            MessageBox.Show(birthDate.ToString());

            dh.addGeneralProfile(fn, mn, ln, suffix, gender, birthDate, null, null, null);
            bool success = dh.addNewApplicant(dh.getLatestID("GeneralProfile", "profileID"), sacramentType);

            displayMessage(success);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Notification.Show("HEEEEEEEEEEEEEEEELOOOOO MY BITCHESSSS");
        }

        private void name_textBox_Leave(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text.Trim().Length == 0)
            {
                t.Text = placeHolderText[t];
                t.ForeColor = Color.Gray;
            }
        }

        private void name_textBox_Enter(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.ForeColor == Color.Gray)
            {
                t.Text = "";
                t.ForeColor = Color.Black;
            }
        }

        private void yes_button_Click(object sender, EventArgs e)
        {

            string fn = firstName_textBox.Text;
            string mn = midName_textBox.Text;
            string ln = lastName_textBox.Text;
            string suffix = suffix_textBox.ForeColor == Color.Gray ? "" : suffix_textBox.Text;
            Gender gender = male_radio.Checked ? Gender.Male : Gender.Female;
            DateTime birthDate = birthdate_dtp.Value;

            int id = dh.getGeneralProfileID(fn, mn, ln, suffix, gender, birthDate);

            bool hasApplication = true;
            if (sacramentType == SacramentType.Baptism)
                hasApplication = dh.hasBaptismApplication(id);
            else
                hasApplication = dh.hasConfirmationApplication(id);

            if (hasApplication)
            {
                Notification.Show("Applicant already has a pending or approved application.", NotificationType.warning);
                this.Close();
                return;
            }

            int itemTypeID = int.Parse(sacramentItem.Rows[0]["itemTypeID"].ToString());
            double price = double.Parse(price_textBox.Text.ToString());
            
            bool success = dh.addNewApplicant(id, sacramentType);
            id = dh.getLatestID("Application", "applicationID");
            dh.addSacramentIncome(id, itemTypeID, price, remarks_textBox.Text);
            displayMessage(success);
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
                        return false;
                }
            }

            return allFilled;
        }
    }

    

}
