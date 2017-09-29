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
    public partial class Bloodletting_Module : Form
    {
        DataHandler dh = new DataHandler();
        int Mode;
        public Bloodletting_Module(int donorMode_eventMode)
        {
            InitializeComponent();
            this.Mode = donorMode_eventMode;
        }

        private void refresh()
        {
            if (Mode == 1)
            {
                bloodletting_dgv.DataSource = dh.getBloodDonors();
                bloodletting_dgv.Columns[0].Visible = false;
                bloodletting_dgv.Columns[1].HeaderText = "Name";
                bloodletting_dgv.Columns[2].HeaderText = "Blood Type";
                bloodletting_dgv.Columns[3].HeaderText = "Quantity";
                bloodletting_dgv.Columns[4].HeaderText = "Contact Number";
                bloodletting_dgv.Columns[5].HeaderText = "Address";
            }
            else
            {
                bloodletting_dgv.DataSource = dh.getBloodlettingEvents();
                bloodletting_dgv.Columns["eventName"].HeaderText = "Name";
                bloodletting_dgv.Columns["startDateTime"].HeaderText = "Start";
                bloodletting_dgv.Columns["endDateTime"].HeaderText = "End";
                bloodletting_dgv.Columns["eventVenue"].HeaderText = "Venue";
                bloodletting_dgv.Columns["eventDetails"].HeaderText = "Details";
                bloodletting_dgv.Columns["bloodDonationEventID"].Visible = false;
            }
            search_textbox_blood.Clear();
        }
        private void add_button_donor_Click(object sender, EventArgs e)
        {
            if (Mode == 1)
            {
                Form A = new Bloodletting_Profile_Popup(dh);
                A.ShowDialog();
                refresh();
            }
            else
            {
                Form A = new BloodlettingEventPopUp(dh);
                A.ShowDialog();
                refresh();
            }
        }
      
        private void OpenEvent()
        {
            if (Mode == 1)
            {
                //try
                {
                    Form A = new Bloodletting_Profile_Popup(int.Parse(bloodletting_dgv.CurrentRow.Cells["blooddonorID"].Value.ToString()), dh);
                    A.ShowDialog();
                    refresh();
                }
               // catch { dh.conn.Close(); }
            }
            else
            {
              //  try
                {
                    Form A = new BloodlettingEventPopUp(int.Parse(bloodletting_dgv.CurrentRow.Cells["bloodDonationEventID"].Value.ToString()), dh);
                    A.ShowDialog();
                    refresh();
                }
             //   catch { dh.conn.Close(); }
            }
        }
        private void bloodletting_dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenEvent();
        }

        private void search_button_blood_Click(object sender, EventArgs e)
        {
            if (search_button_blood.Tag.ToString() == "s")
            {
         
                    if (Mode == 1)
                    {
                        bloodletting_dgv.DataSource = dh.getBloodDonorsLike(search_textbox_blood.Text);
                        bloodletting_dgv.Columns[0].Visible = false;
                        bloodletting_dgv.Columns[1].HeaderText = "Name";
                        bloodletting_dgv.Columns[2].HeaderText = "Blood Type";
                        bloodletting_dgv.Columns[3].HeaderText = "Quantity";
                        bloodletting_dgv.Columns[4].HeaderText = "Contact Number";
                        bloodletting_dgv.Columns[5].HeaderText = "Address";
                    }
                    else
                    {
                        bloodletting_dgv.DataSource = dh.getBloodlettingEventsLike(search_textbox_blood.Text);
                        bloodletting_dgv.Columns["eventName"].HeaderText = "Name";
                        bloodletting_dgv.Columns["startDateTime"].HeaderText = "Start";
                        bloodletting_dgv.Columns["endDateTime"].HeaderText = "End";
                        bloodletting_dgv.Columns["eventVenue"].HeaderText = "Venue";
                        bloodletting_dgv.Columns["eventDetails"].HeaderText = "Details";
                        bloodletting_dgv.Columns["bloodDonationEventID"].Visible = false;
                    }
                    search_button_blood.Tag = "c";
                    search_button_blood.Image = ParishSystem.Properties.Resources.icons8_Delete_Filled_20_666666;
                }
            
            else
            {
                search_textbox_blood.Text = "";
                search_button_blood.Image = ParishSystem.Properties.Resources.icons8_Search_Filled_20;
                search_button_blood.Tag = "s";
                if (Mode == 1)
                {
                    bloodletting_dgv.DataSource = dh.getBloodDonors();
                    bloodletting_dgv.Columns[0].Visible = false;
                    bloodletting_dgv.Columns[1].HeaderText = "Name";
                    bloodletting_dgv.Columns[2].HeaderText = "Blood Type";
                    bloodletting_dgv.Columns[3].HeaderText = "Quantity";
                    bloodletting_dgv.Columns[4].HeaderText = "Contact Number";
                    bloodletting_dgv.Columns[5].HeaderText = "Address";
                }
                else
                {
                    bloodletting_dgv.DataSource = dh.getBloodlettingEvents();
                    bloodletting_dgv.Columns["eventName"].HeaderText = "Name";
                    bloodletting_dgv.Columns["startDateTime"].HeaderText = "Start";
                    bloodletting_dgv.Columns["endDateTime"].HeaderText = "End";
                    bloodletting_dgv.Columns["eventVenue"].HeaderText = "Venue";
                    bloodletting_dgv.Columns["eventDetails"].HeaderText = "Details";
                    bloodletting_dgv.Columns["bloodDonationEventID"].Visible = false;
                }
            }
        }

        private void Bloodletting_Module_Load(object sender, EventArgs e)
        {
            //refresh();
            //label.Text = (Mode == 1 ? "Blood Donor" : "Blood Donation Event");
        }

        private void search_button_blood_TextChanged(object sender, EventArgs e)
        {
            if (search_textbox_blood.Text =="")
            {
                refresh();
            }
            search_button_blood.Tag = "s";
            search_button_blood.Image = ParishSystem.Properties.Resources.icons8_Search_Filled_20;
        }

        private void search_textbox_blood_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                search_button_blood.PerformClick();
            }
        }

        private void bloodletting_dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                OpenEvent();
            }
        }

        private void blooddonor_panel_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                refresh();
                search_textbox_blood.Clear();
                search_button_blood.Image = ParishSystem.Properties.Resources.icons8_Search_Filled_20;
                search_button_blood.Tag = "s";
                label.Text = (Mode == 1 ? "Blood Donor" : "Blood Donation Event");
            }
        }

        private void Bloodletting_Module_VisibleChanged(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
