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
    public partial class BloodClaimView : Form
    {
        DataHandler dh = new DataHandler();
        public BloodClaimView()
        {
            InitializeComponent();
        }
        public void refresh()
        {
            bloodletting_dgv.DataSource = dh.getDonationClaims();
            foreach (DataGridViewColumn dc in bloodletting_dgv.Columns)
            {
                dc.Visible = false;
            }
            bloodletting_dgv.Columns["donationID"].HeaderText = "Donation ID";
            bloodletting_dgv.Columns["donationID"].Visible = true;
            bloodletting_dgv.Columns["Donor"].Visible = true;
            bloodletting_dgv.Columns["Claimant"].Visible = true;
        }
        private void BloodClaims_Load(object sender, EventArgs e)
        {
            //refresh();
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            if (search_button.Tag.ToString() == "s")
            {
                bloodletting_dgv.DataSource = dh.getDonationClaimsWhereDonationIDLike(search_textbox.Text);
                foreach (DataGridViewColumn dc in bloodletting_dgv.Columns)
                {
                    dc.Visible = false;
                }
                bloodletting_dgv.Columns["donationID"].HeaderText = "Donation ID";
                bloodletting_dgv.Columns["donationID"].Visible = true;
                bloodletting_dgv.Columns["Donor"].Visible = true;
                bloodletting_dgv.Columns["Claimant"].Visible = true;
                search_button.Tag = "c";
                search_button.Image = ParishSystem.Properties.Resources.icons8_Delete_Filled_20_666666;
                
            }
            else
            {
                bloodletting_dgv.DataSource = dh.getDonationClaims();
                foreach (DataGridViewColumn dc in bloodletting_dgv.Columns)
                {
                    dc.Visible = false;
                }
                bloodletting_dgv.Columns["donationID"].HeaderText = "Donation ID";
                bloodletting_dgv.Columns["donationID"].Visible = true;
                bloodletting_dgv.Columns["Donor"].Visible = true;
                bloodletting_dgv.Columns["Claimant"].Visible = true;
                search_button.Tag = "s";
                search_textbox.Clear();
                search_button.Image = ParishSystem.Properties.Resources.icons8_Search_Filled_20;
            }
        }

        private void search_textbox_TextChanged(object sender, EventArgs e)
        {
            if (search_textbox.Text == "")
            {
                refresh();
            }
            search_button.Tag = "s";
            search_button.Image = ParishSystem.Properties.Resources.icons8_Search_Filled_20;
        }

        private void BloodClaimView_VisibleChanged(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
