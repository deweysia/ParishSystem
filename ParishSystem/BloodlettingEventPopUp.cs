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
    public partial class BloodlettingEventPopUp : Form
    {
        int bloodlettingID;
        DataHandler dh;
        public BloodlettingEventPopUp(int bloodlettingID, DataHandler dh)
        {
            InitializeComponent();
            this.bloodlettingID = bloodlettingID;
            this.dh = dh;
        }

        public BloodlettingEventPopUp( DataHandler dh)
        {
            InitializeComponent();
            this.dh = dh;
        }

        private void BloodlettingEventPopUp_Load(object sender, EventArgs e)
        {
            refreshEvent();
        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            if (edit_button.Tag.ToString() == "e")
            {
                event_name.ReadOnly = false;
                start_dateTimePicker.Enabled = true;
                end_DateTimePicker.Enabled = true;
                venue_textbox.ReadOnly = false;
                details_textarea.ReadOnly = false;
                edit_button.Tag = "s";
                edit_button.Image = Properties.Resources.icons8_Save_Filled_32;
                
            }
            else
            {
                if (event_name.Text.Trim()=="" ||(start_dateTimePicker.Value.Date>end_DateTimePicker.Value.Date))
                {
                    MessageBox.Show("shunga");
                }
                else{
                    if (bloodlettingID.Equals(0)) {
                        dh.addBloodDonationEvent(event_name.Text, start_dateTimePicker.Value, end_DateTimePicker.Value, venue_textbox.Text, details_textarea.Text);
                        bloodlettingID = dh.getMaxBloodEvent()+1;
                    }
                    else {
                        dh.editBloodDonationEvent(bloodlettingID,event_name.Text,start_dateTimePicker.Value,end_DateTimePicker.Value,venue_textbox.Text,details_textarea.Text);
                    }
                    edit_button.Tag = "e";
                    edit_button.Image = Properties.Resources.icons8_Pencil_32;
                    event_name.ReadOnly = true;
                    start_dateTimePicker.Enabled = false;
                    end_DateTimePicker.Enabled = false;
                    venue_textbox.ReadOnly = true;
                    details_textarea.ReadOnly = true;

                }
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            refreshEvent();
        }
        private void refreshEvent()
        {
            if (bloodlettingID.Equals(0))
            {
                event_name.Clear();
                start_dateTimePicker.Value = DateTime.Now;
                end_DateTimePicker.Value = DateTime.Now;
                venue_textbox.Clear();
                details_textarea.Clear();

                event_name.ReadOnly = false;
                start_dateTimePicker.Enabled = true;
                end_DateTimePicker.Enabled = true;
                venue_textbox.ReadOnly = false;
                details_textarea.ReadOnly = false;
             
                edit_button.Tag = "s";
                edit_button.Image = Properties.Resources.icons8_Save_Filled_32;
            }
            else
            {
                event_name.ReadOnly = true;
                start_dateTimePicker.Enabled = false;
                end_DateTimePicker.Enabled = false;
                venue_textbox.ReadOnly = true;
                details_textarea.ReadOnly = true;

                DataTable dt = dh.getbloodlettingEvent(bloodlettingID);
                edit_button.Tag = "e";
                edit_button.Image = Properties.Resources.icons8_Pencil_32;
                event_name.Text = dt.Rows[0]["eventName"].ToString();
                start_dateTimePicker.Value = dh.toDateTime(dt.Rows[0]["startDateTime"].ToString(), false);
                end_DateTimePicker.Value = dh.toDateTime(dt.Rows[0]["endDateTime"].ToString(), false);
                venue_textbox.Text = dt.Rows[0]["eventVenue"].ToString();
                details_textarea.Text = dt.Rows[0]["eventDetails"].ToString();
            }
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            try
            {
                dh.deleteBloodDonationEvent(bloodlettingID);
                close_button.PerformClick();
            }
            catch
            {
                dh.conn.Close();
                MessageBox.Show("Shunga");
            }
        }

        private void controlBar_panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
