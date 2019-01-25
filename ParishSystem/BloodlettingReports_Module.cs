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
            if (bloodlettingeventreport_combobox.Items.Count > 0)
            {
                bloodlettingeventreport_combobox.SelectedIndex = 0;
            }
                filterBy_combobox_bloodletting.SelectedIndex = 3;

        }
       

        private void filterBy_combobox_bloodletting_SelectedIndexChanged(object sender, EventArgs e)
        {
            to_bloodlettingeventreport_dtp.Enabled = false;
            if (filterBy_combobox_bloodletting.Text == "Donations on Event")
            {
                from_label.Visible = false;
                from_bloodlettingeventreport_dtp.Visible = false;
                to_label.Visible = false;
                to_bloodlettingeventreport_dtp.Visible = false;
                event_label.Visible = true;
                bloodlettingeventreport_combobox.Visible = true;
            }
            else if (filterBy_combobox_bloodletting.Text == "Donations on Date")
            {
               
                from_label.Visible = true;
                from_bloodlettingeventreport_dtp.Visible = true;
                to_label.Visible = false;
                to_bloodlettingeventreport_dtp.Visible = false;
                event_label.Visible = false;
                bloodlettingeventreport_combobox.Visible = false;
            }
            else if (filterBy_combobox_bloodletting.Text == "Donations between Dates")
            {
                from_label.Visible = true;
                from_bloodlettingeventreport_dtp.Visible = true;
                to_label.Visible = true;
                to_bloodlettingeventreport_dtp.Visible = true;
                event_label.Visible = false;
                bloodlettingeventreport_combobox.Visible = false;
            }
            else
            {
                from_label.Visible = false;
                from_bloodlettingeventreport_dtp.Visible = false;
                to_label.Visible = false;
                to_bloodlettingeventreport_dtp.Visible = false;
                event_label.Visible = false;
                bloodlettingeventreport_combobox.Visible = false;
            }
            
            }

        private void BloodlettingReports_Module_Load(object sender, EventArgs e)
        {
            from_bloodlettingeventreport_dtp.MaxDate = DateTime.Now;
            to_bloodlettingeventreport_dtp.MaxDate = DateTime.Now;
            refreshBloodEvenReport();
            
        }
        private void refreshResults()
        {
            summary_dgv_bloodletting.DataSource = null;
            bloodlettingeventreport_datagridview.DataSource = null;
            DataTable dt;
           if (filterBy_combobox_bloodletting.Text == "Donations on Event")
            {
                if (bloodlettingeventreport_combobox.Text!="") {
                    dt = dh.getBloodDonorsOnEvent(((ComboboxContent)bloodlettingeventreport_combobox.SelectedItem).ID);
                    summary_dgv_bloodletting.DataSource = dh.getsummaryOfBloodleting(dt);
                    bloodlettingeventreport_datagridview.DataSource = dt;
                    bloodlettingeventreport_datagridview.Columns["blooddonorID"].Visible = false;
                    bloodlettingeventreport_datagridview.Columns["eventname"].HeaderText = "Event Name";
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
                bloodlettingeventreport_datagridview.Columns["eventname"].HeaderText = "Event Name";
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
                //summary_dgv_bloodletting.Columns["bloodDonationEventID"].Visible = false;
                bloodlettingeventreport_datagridview.DataSource = dt;
                bloodlettingeventreport_datagridview.Columns["blooddonorID"].Visible = false;
                bloodlettingeventreport_datagridview.Columns["eventname"].HeaderText = "Event Name";
                bloodlettingeventreport_datagridview.Columns["name"].HeaderText = "Name";
                bloodlettingeventreport_datagridview.Columns["bloodt"].HeaderText = "Blood Type";
                bloodlettingeventreport_datagridview.Columns["address"].HeaderText = "Address";
                bloodlettingeventreport_datagridview.Columns["donationID"].HeaderText = "Donation ID";
                bloodlettingeventreport_datagridview.Columns["contactnumber"].HeaderText = "Contact Number";
            }
           else if (filterBy_combobox_bloodletting.Text == "All Blood Donations")
            {
                dt = dh.getAllDonations();
                summary_dgv_bloodletting.DataSource = dh.getTotalDonationsOnEvents();
                bloodlettingeventreport_datagridview.DataSource = dt;
                summary_dgv_bloodletting.Columns["eventname"].HeaderText = "Event";
                summary_dgv_bloodletting.Columns["total"].HeaderText = "Total";
                summary_dgv_bloodletting.Columns["bloodDonationEventID"].Visible = false;
                bloodlettingeventreport_datagridview.Columns["blooddonorID"].Visible = false;
                bloodlettingeventreport_datagridview.Columns["eventName"].HeaderText = "Event Name";
                bloodlettingeventreport_datagridview.Columns["name"].HeaderText = "Name";
                bloodlettingeventreport_datagridview.Columns["bloodt"].HeaderText = "Blood Type";
                bloodlettingeventreport_datagridview.Columns["address"].HeaderText = "Address";
                //bloodlettingeventreport_datagridview.Columns["count(donationID)"].HeaderText = "Quantity";
                bloodlettingeventreport_datagridview.Columns["contactnumber"].HeaderText = "Contact Number";
            }
            else
            {
                dt = dh.getBloodDonors();
                summary_dgv_bloodletting.DataSource = dh.getTotalDonationsOnEvents();
                summary_dgv_bloodletting.Columns["eventname"].HeaderText = "Event";
                summary_dgv_bloodletting.Columns["total"].HeaderText = "Total";
                summary_dgv_bloodletting.Columns["bloodDonationEventID"].Visible = false;
                //summary_dgv_bloodletting.Columns["bloodDonationEventID"].Visible = false;
                bloodlettingeventreport_datagridview.DataSource = dt;
                bloodlettingeventreport_datagridview.Columns["blooddonorID"].Visible = false;
                bloodlettingeventreport_datagridview.Columns["name"].HeaderText = "Name";
                bloodlettingeventreport_datagridview.Columns["bloodt"].HeaderText = "Blood Type";
                bloodlettingeventreport_datagridview.Columns["address"].HeaderText = "Address";
                bloodlettingeventreport_datagridview.Columns["count(bloodDonationID)"].HeaderText = "Quantity";
                bloodlettingeventreport_datagridview.Columns["contactnumber"].HeaderText = "Contact Number";
            }

        }

        private void from_bloodlettingeventreport_dtp_ValueChanged(object sender, EventArgs e)
        {
            to_bloodlettingeventreport_dtp.MinDate = from_bloodlettingeventreport_dtp.Value;
            to_bloodlettingeventreport_dtp.Enabled = true;
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
                refreshResults();
            }
            catch { }
        }

        private void summary_dgv_bloodletting_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
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
                    open_button.Image = ParishSystem.Properties.Resources.icons8_Collapse_Arrow_20;
                    summary_dgv_bloodletting.Size = new Size(summary_dgv_bloodletting.Width  , summary_dgv_bloodletting.Height + velocity);
                    bloodlettingeventreport_datagridview.Location = new Point(bloodlettingeventreport_datagridview.Location.X , bloodlettingeventreport_datagridview.Location.Y + velocity);
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
                    open_button.Image = ParishSystem.Properties.Resources.icons8_Expand_Arrow_20;
                    summary_dgv_bloodletting.Size = new Size(summary_dgv_bloodletting.Width  , summary_dgv_bloodletting.Height - velocity);
                    bloodlettingeventreport_datagridview.Location = new Point(bloodlettingeventreport_datagridview.Location.X , bloodlettingeventreport_datagridview.Location.Y - velocity);
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
            filterButton.PerformClick();
            refreshResults();
        }


        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
          
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            panelOpen.Start();
        }

        int velocityII;
        private void panelOpen_Tick(object sender, EventArgs e)
        {
            if (filterButton.Tag.ToString() == "c")
            {
                if (filterPanel.Size.Height <= 35)
                {
                    filterButton.Tag = "o";
                    filterPanel.Size = new Size(filterPanel.Width, 35);
                    velocityII = 0;
                    panelOpen.Stop();
                }
                else
                {
                    filterPanel.Size = new Size(filterPanel.Width, filterPanel.Height-velocityII);
                    velocityII++;
                }
            }
            else
            {
                if (filterPanel.Size.Height >= 270)
                {
                    filterButton.Tag = "c";
                    filterPanel.Size = new Size(filterPanel.Width, 270);
                    velocityII = 0;
                    panelOpen.Stop();
                }
                else
                {
                    filterPanel.Size = new Size(filterPanel.Width, filterPanel.Height + velocityII);
                    velocityII++;
                }
            }
        }

        private void SaveExcelButton_Click(object sender, EventArgs e)
        {
            dh.ExcelBloodlettingReports(bloodlettingeventreport_datagridview, summary_dgv_bloodletting, 2);
        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {
            dh.ExcelBloodlettingReports(bloodlettingeventreport_datagridview,summary_dgv_bloodletting, 1);
        }

        private void bloodlettingeventreport_datagridview_DataSourceChanged(object sender, EventArgs e)
        {
            if (summary_dgv_bloodletting.Rows.Count > 0)
            {
                PreviewButton.Enabled = true;
                SaveExcelButton.Enabled = true;
            }
            else
            {
                PreviewButton.Enabled = false;
                SaveExcelButton.Enabled = false;
            }
        }

        private void bloodlettingreports_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BloodlettingReports_Module_VisibleChanged(object sender, EventArgs e)
        {
            bloodlettingeventreport_datagridview.DataSource = null;
            summary_dgv_bloodletting.DataSource = null;
        }
    }
}
