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
        treasurerBackend dh = new treasurerBackend();
        int Mode;
        public Bloodletting_Module(int Mode)
        {
            InitializeComponent();
            this.Mode = Mode;
        }

        private void refresh()
        {
            if (Mode == 1)
            {
                bloodletting_dgv.DataSource = dh.getBloodDonors();
                bloodletting_dgv.Columns[0].Visible = false;
                bloodletting_dgv.Columns[1].HeaderText = "Name";
                bloodletting_dgv.Columns[2].HeaderText = "Total Donated";
                bloodletting_dgv.Columns[3].HeaderText = "Address";
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
        private void button1_Click(object sender, EventArgs e)
        {
                refresh();
        }

        private void bloodletting_dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Mode == 1)
            {
                Form A = new Bloodletting_Profile_Popup(int.Parse(bloodletting_dgv.CurrentRow.Cells["profileid"].Value.ToString()), dh);
                A.ShowDialog();
                refresh();
            }
            else
            {
                Form A = new BloodlettingEventPopUp(int.Parse(bloodletting_dgv.CurrentRow.Cells["bloodDonationEventID"].Value.ToString()), dh);
                A.ShowDialog();
                refresh();
            }
        }

        private void search_button_blood_Click(object sender, EventArgs e)
        {
            if (Mode == 1)
            {
                bloodletting_dgv.DataSource = dh.getBloodlettingDonorsLike(search_textbox_blood.Text);
                bloodletting_dgv.DataSource = dh.getBloodDonors();
                bloodletting_dgv.Columns[0].Visible = false;
                bloodletting_dgv.Columns[1].HeaderText = "Name";
                bloodletting_dgv.Columns[2].HeaderText = "Total Donated";
                bloodletting_dgv.Columns[3].HeaderText = "Address";
            }
            else
            {
                bloodletting_dgv.DataSource= dh.getBloodlettingEventsLike(search_textbox_blood.Text);
                bloodletting_dgv.Columns["eventName"].HeaderText = "Name";
                bloodletting_dgv.Columns["startDateTime"].HeaderText = "Start";
                bloodletting_dgv.Columns["endDateTime"].HeaderText = "End";
                bloodletting_dgv.Columns["eventVenue"].HeaderText = "Venue";
                bloodletting_dgv.Columns["eventDetails"].HeaderText = "Details";
                bloodletting_dgv.Columns["bloodDonationEventID"].Visible = false;
            }
        }

        private void Bloodletting_Module_Load(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
