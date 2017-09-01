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
    public partial class BloodClaim : Form
    {
        treasurerBackend dh = new treasurerBackend();
        public BloodClaim()
        {
            InitializeComponent();
        }

        private void donationAdd_Click(object sender, EventArgs e)
        {
            if (donationAdd.Tag.ToString()=="a") {
                int a;
                a = dh.getDonationIDPrimaryKey(DonationID_textbox.Text);
                if (a!=-1)
                {
                    int index = BloodDonationsDGV.Rows.Add();
                    BloodDonationsDGV.Rows[index].Cells[0].Value = DonationID_textbox.Text;
                    BloodDonationsDGV.Rows[index].Cells[1].Value = a.ToString();
                    DonationID_textbox.Clear();
                    donationAdd.Enabled = false;
                }
                else
                {
                    Notification.Show(State.InnvalidDononationID);
                }
            }
            else
            {
                int a;
                a = dh.getDonationIDPrimaryKey(DonationID_textbox.Text);
                if (a != -1)
                {
                    BloodDonationsDGV.SelectedRows[0].Cells[0].Value = DonationID_textbox.Text;
                    BloodDonationsDGV.SelectedRows[0].Cells[1].Value = a.ToString();
                    DonationID_textbox.Clear();
                    donationAdd.Tag = "a";
                    donationAdd.Text = "Add";
                    donationDelete.Enabled = false;
                }
                else
                {
                    Notification.Show(State.InnvalidDononationID);
                }
            }
                
        }

        private void BloodDonationsDGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DonationID_textbox.Text = BloodDonationsDGV.SelectedRows[0].Cells[0].Value.ToString();
            donationDelete.Enabled = true;
            donationAdd.Text = "Edit";
            donationAdd.Tag = "e";
        }

        private void donationDelete_Click(object sender, EventArgs e)
        {
            BloodDonationsDGV.Rows.RemoveAt(BloodDonationsDGV.SelectedRows[0].Index);
            donationDelete.Enabled = false;
            donationAdd.Tag = "a";
            donationAdd.Text = "Add";
            DonationID_textbox.Clear();
        }

        private void DonationID_textbox_TextChanged(object sender, EventArgs e)
        {
            if (DonationID_textbox.Text != "")
            {
                donationAdd.Enabled = true;
            }
            else
            {
                donationAdd.Enabled = false;
            }
        }

        private void ln_TextChanged(object sender, EventArgs e)
        {
            checkForcontent();
        }

        private void sf_TextChanged(object sender, EventArgs e)
        {
            checkForcontent();
        }

        private void fn_TextChanged(object sender, EventArgs e)
        {
            checkForcontent();
        }

        private void mi_TextChanged(object sender, EventArgs e)
        {
            checkForcontent();
        }

        private void BloodDonationsDGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            checkForcontent();
        }

        private void BloodDonationsDGV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            checkForcontent();
        }
        private void checkForcontent()
        {
            if(fn.Text!="" && ln.Text != "" && BloodDonationsDGV.Rows.Count>0)
            {
                Claim_button.Enabled = true;
            }
            else
            {
                Claim_button.Enabled = false;
            }
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            DonationID_textbox.Clear();
            donationAdd.Tag = "a";
            donationAdd.Text = "Add";
        }

        private void Claim_button_Click(object sender, EventArgs e)
        {
            int a = dh.AddClaimant(fn.Text,mi.Text,ln.Text,sf.Text);
            foreach (DataGridViewRow dgvr in BloodDonationsDGV.Rows)
            {
                dh.ClaimBloodDonation(int.Parse(dgvr.Cells[1].Value.ToString()),a);
            }
            Claim_button.Enabled = false;
            BloodDonationsDGV.Rows.Clear();
            donationAdd.Tag = "a";
            donationAdd.Text = "Add";
            donationDelete.Enabled = false;
            fn.Clear();
            mi.Clear();
            ln.Clear();
            sf.Clear();
        }
    }
}
