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
    public partial class BloodlettingReports_Module : Form
    {
        DataHandler dh = new DataHandler();
        public BloodlettingReports_Module()
        {
            InitializeComponent();
        }

        private void refreshBloodEvenReport()
        {
            DataTable dt = dh.getBloodlettingEvents();
            bloodlettingeventreport_combobox.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                bloodlettingeventreport_combobox.Items.Add(new ComboboxContent(int.Parse(dr["bloodDonationEventID"].ToString()), dr["eventName"].ToString()));
            }
            try
            {
                bloodlettingeventreport_combobox.SelectedIndex = 0;
            }
            catch { }
        }
       

        private void filterBy_combobox_bloodletting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterBy_combobox_bloodletting.Text == "Recent")
            {
                to_bloodlettingeventreport_dtp.Visible = false;
                from_bloodlettingeventreport_dtp.Visible = false;
                bloodlettingeventreport_combobox.Visible = false;
            }
            else if (filterBy_combobox_bloodletting.Text == "Donations on Event")
            {
                to_bloodlettingeventreport_dtp.Visible = false;
                from_bloodlettingeventreport_dtp.Visible = false;
                bloodlettingeventreport_combobox.Visible = true;
            }
            else if (filterBy_combobox_bloodletting.Text == "Donations on Date")
            {
                to_bloodlettingeventreport_dtp.Visible = false;
                from_bloodlettingeventreport_dtp.Visible = true;
                bloodlettingeventreport_combobox.Visible = false;
            }
            else if (filterBy_combobox_bloodletting.Text == "Donations between Dates")
            {
                to_bloodlettingeventreport_dtp.Visible = true;
                from_bloodlettingeventreport_dtp.Visible = true;
                bloodlettingeventreport_combobox.Visible = false;
            }
            else
            {
                to_bloodlettingeventreport_dtp.Visible = false;
                from_bloodlettingeventreport_dtp.Visible = false;
                bloodlettingeventreport_combobox.Visible = false;
            }
            
            }

        private void BloodlettingReports_Module_Load(object sender, EventArgs e)
        {
            refreshBloodEvenReport();
        }
        private void refreshResults()
        {
            DataTable dt;
            if (filterBy_combobox_bloodletting.Text == "Recent")
            {
                /*
                dt = dh.getBloodDonorsRecent();
                summary_dgv_bloodletting.DataSource = dh.getsummaryOfBloodleting(dt);
                bloodlettingeventreport_datagridview.DataSource = dt;
                bloodlettingeventreport_datagridview.Columns["profileid"].Visible = false;
                bloodlettingeventreport_datagridview.Columns["name"].HeaderText = "Name";
                bloodlettingeventreport_datagridview.Columns["bloodt"].HeaderText = "Blood Type";
                bloodlettingeventreport_datagridview.Columns["address"].HeaderText = "Address";
                bloodlettingeventreport_datagridview.Columns["donationID"].HeaderText = "Donation ID";
                bloodlettingeventreport_datagridview.Columns["Eventname"].HeaderText = "Event";
                */
            }
            else if (filterBy_combobox_bloodletting.Text == "Donations on Event")
            {
                if (bloodlettingeventreport_combobox.Text!="") {
                    dt = dh.getBloodDonorsOnEvent(((ComboboxContent)bloodlettingeventreport_combobox.SelectedItem).ID);
                    summary_dgv_bloodletting.DataSource = dh.getsummaryOfBloodleting(dt);
                    bloodlettingeventreport_datagridview.DataSource = dt;
                    bloodlettingeventreport_datagridview.Columns["blooddonorID"].Visible = false;
                    bloodlettingeventreport_datagridview.Columns["eventname"].Visible = false;
                    bloodlettingeventreport_datagridview.Columns["name"].HeaderText = "Name";
                    bloodlettingeventreport_datagridview.Columns["bloodt"].HeaderText = "Blood Type";
                    bloodlettingeventreport_datagridview.Columns["address"].HeaderText = "Address";
                    bloodlettingeventreport_datagridview.Columns["donationID"].HeaderText = "Donation ID";
                    bloodlettingeventreport_datagridview.Columns["contactnumber"].HeaderText = "Contact Number";
                }
            }
            else if (filterBy_combobox_bloodletting.Text == "Donations on Date")
            {
                dt = dh.getBloodDonorsOnDate(from_bloodlettingeventreport_dtp.Value);
                summary_dgv_bloodletting.DataSource = dh.getsummaryOfBloodleting(dt);
                bloodlettingeventreport_datagridview.DataSource = dt;
                bloodlettingeventreport_datagridview.Columns["blooddonorID"].Visible = false;
                bloodlettingeventreport_datagridview.Columns["eventname"].Visible = false;
                bloodlettingeventreport_datagridview.Columns["name"].HeaderText = "Name";
                bloodlettingeventreport_datagridview.Columns["bloodt"].HeaderText = "Blood Type";
                bloodlettingeventreport_datagridview.Columns["address"].HeaderText = "Address";
                bloodlettingeventreport_datagridview.Columns["donationID"].HeaderText = "Donation ID";
                bloodlettingeventreport_datagridview.Columns["contactnumber"].HeaderText = "Contact Number";
            }
            else if (filterBy_combobox_bloodletting.Text == "Donations between Dates")
            {
                dt = dh.getBloodDonorsOnDateRange(from_bloodlettingeventreport_dtp.Value, to_bloodlettingeventreport_dtp.Value);
                summary_dgv_bloodletting.DataSource = dh.getsummaryOfBloodleting(dt);
                bloodlettingeventreport_datagridview.DataSource = dt;
                bloodlettingeventreport_datagridview.Columns["blooddonorID"].Visible = false;
                bloodlettingeventreport_datagridview.Columns["eventname"].Visible = false;
                bloodlettingeventreport_datagridview.Columns["name"].HeaderText = "Name";
                bloodlettingeventreport_datagridview.Columns["bloodt"].HeaderText = "Blood Type";
                bloodlettingeventreport_datagridview.Columns["address"].HeaderText = "Address";
                bloodlettingeventreport_datagridview.Columns["donationID"].HeaderText = "Donation ID";
                bloodlettingeventreport_datagridview.Columns["contactnumber"].HeaderText = "Contact Number";
            }
            else
            {
                dt = dh.getBloodDonors();
                summary_dgv_bloodletting.DataSource = dh.getTotalDonationsOnEvents();
                summary_dgv_bloodletting.Columns["eventname"].HeaderText = "Event";
                summary_dgv_bloodletting.Columns["total"].HeaderText = "Total";
                summary_dgv_bloodletting.Columns["bloodDonationEventID"].Visible = false;
                bloodlettingeventreport_datagridview.DataSource = dt;
                bloodlettingeventreport_datagridview.Columns["blooddonorID"].Visible = false;
                bloodlettingeventreport_datagridview.Columns["name"].HeaderText = "Name";
                bloodlettingeventreport_datagridview.Columns["bloodt"].HeaderText = "Blood Type";
                bloodlettingeventreport_datagridview.Columns["address"].HeaderText = "Address";
                bloodlettingeventreport_datagridview.Columns["count(bloodDonationID)"].HeaderText = "Donation ID";
                bloodlettingeventreport_datagridview.Columns["contactnumber"].HeaderText = "Contact Number";
            }

        }

        private void from_bloodlettingeventreport_dtp_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void to_bloodlettingeventreport_dtp_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void bloodlettingeventreport_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void bloodlettingeventreport_datagridview_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Form A = new Bloodletting_Profile_Popup(int.Parse(bloodlettingeventreport_datagridview.CurrentRow.Cells[0].Value.ToString()), dh);
                A.ShowDialog();
            }
            catch { }
        }

        private void summary_dgv_bloodletting_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Form A = new BloodlettingEventPopUp(int.Parse(summary_dgv_bloodletting.CurrentRow.Cells[0].Value.ToString()), dh);
                A.ShowDialog();
            }
            catch { }
        }
        bool open = true;
        private void open_button_Click(object sender, EventArgs e)
        {
            animation.Start();
        }
        int velocity = 0;
        private void animation_Tick(object sender, EventArgs e)
        {
            
            if (open) {
                if (summary_dgv_bloodletting.Height <= 350)
                {
                    open_button.Image = ParishSystem.Properties.Resources.icons8_Expand_Arrow_20;
                    summary_dgv_bloodletting.Size = new Size(576, summary_dgv_bloodletting.Height  + velocity);
                    //bloodlettingeventreport_datagridview.Size = new Size(884, bloodlettingeventreport_datagridview.Height +velocity);
                }
                else
                {
                    
                    summary_dgv_bloodletting.Height = 350;
                    animation.Stop();
                    velocity = 0;
                    open = false;
                }
                velocity++;
            }
            else
            {
                if (summary_dgv_bloodletting.Height >= 1)
                {
                    open_button.Image = ParishSystem.Properties.Resources.icons8_Collapse_Arrow_20;
                    summary_dgv_bloodletting.Size = new Size(576, summary_dgv_bloodletting.Height  - velocity);
                }
                else
                {
                    summary_dgv_bloodletting.Height = 0;
                    animation.Stop();
                    velocity = 0;
                    
                    open = true;
                }
                velocity++;
            }
        }

        private void generateReport_button_Click(object sender, EventArgs e)
        {
            refreshResults();
        }


        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
          
        }
    }
}
