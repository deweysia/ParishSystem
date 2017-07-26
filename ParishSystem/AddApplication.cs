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
        DataHandler dh = new DataHandler("localhost", "sad2", "root", "root");
        Point lastClick;
        char sacramentType;
        public AddApplication(SacramentType type)
        {
            InitializeComponent();
            application_birthdate_dtp.MaxDate = DateTime.Now;
            label1.MouseDown += AddApplication_MouseDown;
            label1.MouseMove += AddApplication_MouseMove;
            panel1.MouseDown += AddApplication_MouseDown;
            panel1.MouseMove += AddApplication_MouseMove;
            
            applicationNotice_label.MaximumSize = panel1.Size - panel1.Padding.Size;

            this.sacramentType = type == SacramentType.Baptism ? 'B' : 'C';
            this.label1.Text = type == SacramentType.Baptism ? "Baptism Application" : "Confirmation Application";
            
        }

        private void AddApplication_Load(object sender, EventArgs e)
        {
            
        }

        private void setFormEditable(bool editable)
        {
            application_firstName_textBox.ReadOnly = editable;
            application_midName_textBox.ReadOnly = editable;
            application_lastName_textBox.ReadOnly = editable;
            application_suffix_textBox.ReadOnly = editable;
            application_male_radio.Enabled = editable;
            application_female_radio.Enabled = editable;
            application_birthdate_dtp.Enabled = editable;
        }


        private void application_apply_button_Click(object sender, EventArgs e)
        {
            string fn = application_firstName_textBox.Text;
            string mn = application_midName_textBox.Text;
            string ln = application_lastName_textBox.Text;
            string suffix = application_suffix_textBox.Text;
            char gender = application_male_radio.Checked ? 'M' : 'F';
            DateTime birthDate = application_birthdate_dtp.Value;

            int id = dh.getGeneralProfileID(fn, mn, ln, suffix, gender, birthDate);

            if (id == -1) //-1 indicates no such profile exists in the database
            {
                dh.addGeneralProfile(fn, mn ,ln ,suffix ,gender ,birthDate,null,null,null,-1,-1,-1);
                id = dh.getLatestID("GeneralProfile", "profileID");

                bool success = dh.addNewApplicant(id, sacramentType);
                displayMessage(success);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.AcceptButton = application_yes_button;
                panel1.Show();
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

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void application_cancel_button_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void application_createNewProfile_button_Click(object sender, EventArgs e)
        {
            string fn = application_firstName_textBox.Text;
            string mn = application_midName_textBox.Text;
            string ln = application_lastName_textBox.Text;
            string suffix = application_suffix_textBox.Text;
            char gender = application_male_radio.Checked ? 'M' : 'F';
            DateTime birthDate = application_birthdate_dtp.Value;

            dh.addGeneralProfile(fn, mn, ln, suffix, gender, birthDate, null, null, null,-1,-1,-1);
            bool success = dh.addNewApplicant(dh.getLatestID("GeneralProfile", "profileID"), sacramentType);

            displayMessage(success);


        }

        private void application_yes_button_Click(object sender, EventArgs e)
        {
            string fn = application_firstName_textBox.Text;
            string mn = application_midName_textBox.Text;
            string ln = application_lastName_textBox.Text;
            string suffix = application_suffix_textBox.Text;
            char gender = application_male_radio.Checked ? 'M' : 'F';
            DateTime birthDate = application_birthdate_dtp.Value;

            int id = dh.getGeneralProfileID(fn, mn, ln, suffix, gender, birthDate);
            MessageBox.Show("WELCOME");
            bool hasApplication = true;
            if (sacramentType == 'B')
                hasApplication =  dh.hasBaptismApplication(id);
            else
                hasApplication = dh.hasConfirmationApplication(id);

            if (hasApplication)
            {
                MessageBox.Show("BITCH BE EXISTING!");
                Notification.Show("Applicant already has an active or approved application.", NotificationType.warning);
                return;
            }
                
                
            bool success = dh.addNewApplicant(id, sacramentType);
            displayMessage(success);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Notification.Show("HEEEEEEEEEEEEEEEELOOOOO MY BITCHESSSS");
        }

        private void application_apply_button_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

    

}
