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
    
    public partial class Bloodletting_Profile_Popup : Form
    {
        public static string[] bloodType = new string[] {"A+","A-","B+","B-","AB+","AB-","O+","O-"};

        int ProfileID;
        DataHandler dh;
        bool hasProfile;
        public Bloodletting_Profile_Popup(int profileID, DataHandler dh)
        {
            InitializeComponent();
            ProfileID = profileID;
            this.dh = dh;
            hasProfile = true;
        }
        public Bloodletting_Profile_Popup(DataHandler dh)
        {
            InitializeComponent();
            this.dh = dh;
            ProfileID = dh.getNextProfileID();
            hasProfile = false;
        }
        private void refreshBloodlettingInfo()
        {
            DataTable dt = dh.getGeneralProfile(ProfileID);
            firstname_label_bloodletting.Text = dt.Rows[0]["firstname"].ToString();
            mi_label_bloodletting.Text = dt.Rows[0]["midname"].ToString();
            lastname_label_bloodletting.Text = dt.Rows[0]["lastname"].ToString();
            suffix_label_bloodletting.Text = dt.Rows[0]["suffix"].ToString();
            try
            {
                bloodtype_label.Text = bloodType[int.Parse(dt.Rows[0]["bloodtype"].ToString()) - 1];
            }
            catch { }
            address_textbox.Text = dt.Rows[0]["address"].ToString();
            contactNumber_textbox.Text = dt.Rows[0]["contactNumber"].ToString();
        }
        private void refreshBloodDonation()
        {
            blooddonation_dataGridView_bloodletting.DataSource = dh.getBloodDonations(ProfileID);
            totalDonation_label.Text = dh.getTotalBloodDonationOf(ProfileID).ToString();
            foreach (DataGridViewColumn c in blooddonation_dataGridView_bloodletting.Columns)
            {
                c.Visible = false;
            }
            blooddonation_dataGridView_bloodletting.Columns["eventName"].HeaderText = "Event Name";
            blooddonation_dataGridView_bloodletting.Columns["eventName"].Visible = true;
            blooddonation_dataGridView_bloodletting.Columns["quantity"].HeaderText = "Quantity";
            blooddonation_dataGridView_bloodletting.Columns["quantity"].Visible = true;

        }

        private void Bloodletting_Details_Popup_Load(object sender, EventArgs e)
        {
            quantity_nud.Maximum = decimal.MaxValue;
            if (hasProfile == true)
            {
                refreshBloodlettingInfo();
                refreshBloodDonation();
            }
            else
            {
                edit_button.PerformClick();
            }
            DataTable dt = dh.getBloodlettingEvents();
            foreach (DataRow dr in dt.Rows)
            {
                event_combobox_bloodletting.Items.Add(new ComboboxContent(int.Parse(dr["bloodDonationEventID"].ToString()), dr["eventName"].ToString()));
            }
        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            if (edit_button.Tag.ToString() == "e")
            {
                bloodtype_combobox.Visible = true;
                cancel_button.Visible = true;
                edit_button.Tag = "s";
                edit_button.Image = Properties.Resources.icons8_Save_Filled_32;
                firstname_label_bloodletting.Visible = false;
                mi_label_bloodletting.Visible = false;
                lastname_label_bloodletting.Visible = false;
                suffix_label_bloodletting.Visible = false;

                firstname_textbox_bloodletting.Visible = true;
                mi_textbox_bloodletting.Visible = true;
                lastname_textbox_bloodletting.Visible = true;
                suffix_textbox_bloodletting.Visible = true;
                bloodtype_combobox.SelectedItem = bloodtype_label.Text;
                address_textbox.ReadOnly = false;
                contactNumber_textbox.ReadOnly = false;

                if (hasProfile == true)
                {
                    firstname_textbox_bloodletting.Text = firstname_label_bloodletting.Text;
                    mi_textbox_bloodletting.Text = mi_label_bloodletting.Text;
                    lastname_textbox_bloodletting.Text = lastname_label_bloodletting.Text;
                    suffix_textbox_bloodletting.Text = suffix_label_bloodletting.Text;
                }
                else
                {
                    firstname_textbox_bloodletting.Text = "Firstname";
                    mi_textbox_bloodletting.Text = "MI";
                    lastname_textbox_bloodletting.Text = "Lastname";
                    suffix_textbox_bloodletting.Text = "Suffix";
                }
            }
            else if (edit_button.Tag.ToString() == "s")
            {
                if ((firstname_textbox_bloodletting.Text != "" &&
                    mi_textbox_bloodletting.Text != "" &&
                    lastname_textbox_bloodletting.Text !=""&&
                    bloodtype_combobox.Text!="")&&(
                    firstname_textbox_bloodletting.Text != "Firstname" &&
                    mi_textbox_bloodletting.Text != "MI" &&
                    lastname_textbox_bloodletting.Text != "Lastname" 
                    )) { 
                    string suff;
                    if(suffix_textbox_bloodletting.Text == "Suffix")
                    {
                        suff = null;
                    }
                    else
                    {
                        suff = suffix_textbox_bloodletting.Text;
                    }
                    string add;
                    if (address_textbox.Text.Trim() == "")
                    {
                        add = null;
                    } else
                    {
                        add = address_textbox.Text;
                    }
                    string count;
                    if (!contactNumber_textbox.MaskFull && !string.IsNullOrEmpty(contactNumber_textbox.Text.Trim()))
                    {
                        MessageBox.Show("shungaII");
                         count = "";
                    }
                    else
                    {
                        count = (contactNumber_textbox.Text.Trim());
                    }
                    bloodtype_combobox.Visible = false;
                    edit_button.Tag = "e";
                    edit_button.Image = Properties.Resources.icons8_Pencil_32;
                    cancel_button.Visible = false;

                    

                    if (hasProfile == true)
                    { dh.editBloodDonor(ProfileID, firstname_textbox_bloodletting.Text, mi_textbox_bloodletting.Text, lastname_textbox_bloodletting.Text, suff,add,count, bloodtype_combobox.SelectedIndex + 1); }
                    else
                    {
                      dh.addBloodDonor(firstname_textbox_bloodletting.Text, mi_textbox_bloodletting.Text, lastname_textbox_bloodletting.Text, suff, add, count, bloodtype_combobox.SelectedIndex + 1);
                      hasProfile = true;
                    }
                    firstname_label_bloodletting.Visible = true;
                    mi_label_bloodletting.Visible = true;
                    lastname_label_bloodletting.Visible = true;
                    suffix_label_bloodletting.Visible = true;

                    firstname_textbox_bloodletting.Visible = false;
                    mi_textbox_bloodletting.Visible = false;
                    lastname_textbox_bloodletting.Visible = false;
                    suffix_textbox_bloodletting.Visible = false;
                    address_textbox.ReadOnly = true;
                    contactNumber_textbox.ReadOnly = true;
                    refreshBloodlettingInfo();
                }
                else
                {
                    MessageBox.Show("Shunga");
                }
            }
            

        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            bloodtype_combobox.Visible = false;
            cancel_button.Visible = false;
            firstname_label_bloodletting.Visible = true;
            mi_label_bloodletting.Visible = true;
            lastname_label_bloodletting.Visible = true;
            suffix_label_bloodletting.Visible = true;
            address_textbox.ReadOnly = true;
            contactNumber_textbox.ReadOnly = true;

            firstname_textbox_bloodletting.Visible = false;
            mi_textbox_bloodletting.Visible = false;
            lastname_textbox_bloodletting.Visible = false;
            suffix_textbox_bloodletting.Visible = false;

            firstname_textbox_bloodletting.Clear();
            mi_textbox_bloodletting.Clear();
            lastname_textbox_bloodletting.Clear();
            suffix_textbox_bloodletting.Clear();

            edit_button.Tag = "e";
            edit_button.Image = Properties.Resources.icons8_Pencil_32;
        }

        private void addDonation_button_bloodletting_Click(object sender, EventArgs e)
        {
            if (addDonation_button_bloodletting.Text == "Add")
            {
                dh.addBloodDonation(ProfileID, (int)quantity_nud.Value, ((ComboboxContent)event_combobox_bloodletting.SelectedItem).ID);
                
            }
            else if (addDonation_button_bloodletting.Text == "Edit")
            {
                dh.editBloodDonation(int.Parse(blooddonation_dataGridView_bloodletting.CurrentRow.Cells["bloodDonationID"].Value.ToString()), (int)quantity_nud.Value, ((ComboboxContent)event_combobox_bloodletting.SelectedItem).ID);
                
            }
            clearAddInfo();
            refreshBloodDonation();
            addDonation_button_bloodletting.Enabled = false;
            delete_button_bloodletting.Enabled = false;
        }
        private void blooddonation_dataGridView_bloodletting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addDonation_button_bloodletting.Text = "Edit";
            addDonation_button_bloodletting.Enabled = true;
            delete_button_bloodletting.Enabled = true;
            event_combobox_bloodletting.SelectedItem = new ComboboxContent(int.Parse(blooddonation_dataGridView_bloodletting.CurrentRow.Cells["bloodDonationEventID"].Value.ToString()), (blooddonation_dataGridView_bloodletting.CurrentRow.Cells["eventname"].Value.ToString()));
            event_combobox_bloodletting.Text = (blooddonation_dataGridView_bloodletting.CurrentRow.Cells["eventname"].Value.ToString());
            quantity_nud.Value = decimal.Parse(blooddonation_dataGridView_bloodletting.CurrentRow.Cells["quantity"].Value.ToString());
        }

       

        private void clear_button_bloodletting_Click(object sender, EventArgs e)
        {
            clearAddInfo();
            delete_button_bloodletting.Enabled = false;
            addDonation_button_bloodletting.Text = "Add";
            event_combobox_bloodletting.Text = "";
            
        }

        private void delete_button_bloodletting_Click(object sender, EventArgs e)
        {
            dh.deleteBloodDonation(int.Parse(blooddonation_dataGridView_bloodletting.CurrentRow.Cells["bloodDonationID"].Value.ToString()));
            refreshBloodDonation();
            delete_button_bloodletting.Enabled = false;
            addDonation_button_bloodletting.Enabled = false;
            clearAddInfo();
        }
        private void clearAddInfo()
        {
            event_combobox_bloodletting.SelectedIndex = 0;
            quantity_nud.Value = 0;
            blooddonation_dataGridView_bloodletting.ClearSelection();
        }

        private void quantity_nud_ValueChanged(object sender, EventArgs e)
        {
            checkContent();
        }
        private void event_combobox_bloodletting_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkContent();
        }
        private void checkContent()
        {
            if(event_combobox_bloodletting.Text=="" || quantity_nud.Value == 0)
            {
                addDonation_button_bloodletting.Enabled = false;
            }
            else
            {
                addDonation_button_bloodletting.Enabled = true;
            }
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private void textbox_bloodletting_MouseClick(object sender, MouseEventArgs e)
        {
            if (hasProfile == false)
            {
                TextBox A = sender as TextBox;
                A.Text = "";
            }   
        }

    
    }
}
