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
    public partial class AddApplication : Form
    {
        DataHandler dh;
        SacramentType sacramentType;
        DataTable sacramentItem;
        

        
        
        public AddApplication(SacramentType type)
        {
            InitializeComponent();
            sacramentType = type;

            this.dh = DataHandler.getDataHandler();

            Draggable drag = new Draggable(this);
            drag.makeDraggable(this);
            drag.makeDraggable(panel1);

            birthdate_dtp.MaxDate = DateTime.Now;
            label1.MouseDown += AddApplication_MouseDown;
            label1.MouseMove += AddApplication_MouseMove;

            this.sacramentType = type;
            label1.Text = sacramentType + " Application";
            sacramentItem = dh.getItem(sacramentType.ToString());
            nupPrice.Text = sacramentItem.Rows[0]["suggestedPrice"].ToString();
        }

        private void AddApplication_Load(object sender, EventArgs e)
        {
            
        }

        private void setFormEditable(bool editable)
        {
            txtFN.ReadOnly = editable;
            txtMI.ReadOnly = editable;
            txtLastName.ReadOnly = editable;
            txtSuffix.ReadOnly = editable;
            male_radio.Enabled = editable;
            female_radio.Enabled = editable;
            birthdate_dtp.Enabled = editable;
        }


        private void application_apply_button_Click(object sender, EventArgs e)
        {
            if (!allFilled())
            {
                Notification.Show(State.MissingFields);
                return;
            }
            
            string fn = txtFN.Text;
            string mn = txtMI.Text;
            string ln = txtLastName.Text;
            string suffix = txtSuffix.Text == "Suffix" ? "" : txtSuffix.Text;
            Gender gender = male_radio.Checked ? Gender.Male : Gender.Female;
            DateTime birthDate = birthdate_dtp.Value;

            int itemTypeID = int.Parse(sacramentItem.Rows[0]["itemTypeID"].ToString());
            double price = double.Parse(nupPrice.Text);

            bool success = true;
            int profileID = dh.getGeneralProfileID(fn, mn, ln, suffix, gender, birthDate);
            if(profileID != -1)//gen prof exists
            {
                //gen prof does not have active application
                if (!dh.hasActiveApplication(profileID, sacramentType))
                {
                    success &= dh.addNewApplicant(profileID, sacramentType);
                    int applicationID = dh.getLatestID("Application", "applicationID");
                    success &= dh.addSacramentIncome(applicationID, price, txtRemarks.Text);
                }
                else //gen prof has active application
                {
                    Notification.Show(State.ApplicationExists);
                    this.Close();
                    return;
                }
            }
            else //gen prof does not exist
            {
                //add genprof and add application

                success &= dh.addGeneralProfile(fn, mn, ln, suffix, gender, birthDate);
                profileID = dh.getLatestID("GeneralProfile", "profileID");
                success &= dh.addNewApplicant(profileID, sacramentType);
                int applicationID = dh.getLatestID("Application", "applicationID");
                success &= dh.addSacramentIncome(applicationID, price, txtRemarks.Text);
            }

            if (success)
                Notification.Show(State.ApplicationAddSuccess);
            else
                Notification.Show(State.ApplicationAddFail);
            this.Close();
        }



        private void AddApplication_MouseDown(object sender, MouseEventArgs e)
        {
            //lastClick = new Point(e.X, e.Y);
            
        }

        private void AddApplication_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    this.Left += e.X - lastClick.X;
            //    this.Top += e.Y - lastClick.Y;
            //}
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

        private void button1_Click(object sender, EventArgs e)
        {
            Notification.Show(State.GenericError);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {

        }
    }

    

}
