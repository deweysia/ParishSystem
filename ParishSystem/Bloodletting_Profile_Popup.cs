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
           
        }
        public Bloodletting_Profile_Popup(DataHandler dh)
        {
            InitializeComponent();
            this.dh = dh;
            ProfileID = dh.getNextBloodlettingID();
            hasProfile = false;
            edit_button.Tag = "s";
            edit_button.Image= Properties.Resources.icons8_Save_Filled_32__1_;
            
        }
        
    

        private void Bloodletting_Details_Popup_Load(object sender, EventArgs e)
        {
            quantity_nud.Maximum = decimal.MaxValue;
            if (hasProfile == true)
            {
                bloodtype_combobox.Visible = false;
                contactNumber_textbox.ReadOnly = true;
                address_textbox.ReadOnly = true;

            }

            
        }
        string firstname;
        string midname;
        string lastname;
        string suffix;
        string contact;
        string addres;

        private void edit_button_Click(object sender, EventArgs e)
        {
            firstname = firstname_label_bloodletting.Text;
            midname = mi_label_bloodletting.Text;
            lastname = lastname_label_bloodletting.Text;
            suffix = suffix_label_bloodletting.Text;
            contact = contactNumber_textbox.Text;
            addres = address_textbox.Text;
            if (edit_button.Tag.ToString() == "s")
            {
                if (fn.Text != "" && mn.Text != "" && ln.Text != "" && address_textbox.Text != "" && contactNumber_textbox.MaskFull && bloodtype_combobox.Text != "")
                {
                    if (hasProfile)//edit
                    {
                        if (dh.countSameDonor(fn.Text, mn.Text, ln.Text, sf.Text, address_textbox.Text, contactNumber_textbox.Text, bloodtype_combobox.SelectedIndex) != 0)//someone exists
                        {
                            int from = dh.getBloodDonorWhere(fn.Text, mn.Text, ln.Text, sf.Text, address_textbox.Text, contactNumber_textbox.Text, bloodtype_combobox.SelectedIndex);
                            if (from != ProfileID)
                            {
                                DialogResult result = MessageBox.Show("A profile is already existing do you wish to merge the donations?", "", MessageBoxButtons.YesNoCancel);
                                if (result == DialogResult.Yes)
                                {
                                    dh.mergeDonations(from, ProfileID);
                                    Notification.Show(State.MergingDone); 
                                }
                            }
                        }
                        dh.editBloodDonor(ProfileID, fn.Text, mn.Text, ln.Text, sf.Text, address_textbox.Text, contactNumber_textbox.Text, bloodtype_combobox.SelectedIndex);
                        ln.Visible = false;//has visibility change 
                        edit_button.Image = Properties.Resources.icons8_Pencil_32__1_;
                        edit_button.Tag = "e";
                    }
                    else//add
                    {
                        if (dh.countSameDonor(fn.Text, mn.Text, ln.Text, sf.Text, address_textbox.Text, contactNumber_textbox.Text, bloodtype_combobox.SelectedIndex) == 0)
                        {
                            dh.addBloodDonor(fn.Text, mn.Text, ln.Text, sf.Text, address_textbox.Text, contactNumber_textbox.Text, bloodtype_combobox.SelectedIndex);
                            Notification.Show(State.ProfileAdded);
                            ln.Visible = false;//has visibility change 
                            edit_button.Tag = "e";
                            edit_button.Image = Properties.Resources.icons8_Pencil_32__1_;
                            hasProfile = true;
                            
                        }
                        else
                        {
                            Notification.Show(State.ProfileExists);
                            fn.Clear();
                            mn.Clear();
                            ln.Clear();
                            sf.Clear();
                            address_textbox.Clear();
                            contactNumber_textbox.Clear();
                        }
                    }

                }
                else
                {
                    Notification.Show(State.MissingFields);
                }
            }
            else
            {
                ln.Visible = true;
                edit_button.Tag = "s";
                edit_button.Image = Properties.Resources.icons8_Save_Filled_32__1_;
            }
        }
           

        private void cancel_button_Click(object sender, EventArgs e)
        {
            ln.Visible = true;
            if (hasProfile)
            {
                firstname_label_bloodletting.Text= firstname;
                mi_label_bloodletting.Text= midname;
                lastname_label_bloodletting.Text= lastname;
                suffix_label_bloodletting.Text= suffix;
                contactNumber_textbox.Text= contact;
                address_textbox.Text= addres;
            }
            else
            {
                fn.Clear();
                mn.Clear();
                ln.Clear();
                sf.Clear();
                address_textbox.Clear();
                contactNumber_textbox.Clear();
            }
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
           
        }
        private void clearAddInfo()
        {
            quantity_nud.Value = 0;
            event_combobox_bloodletting.SelectedIndex = 0;
        }
       private void refreshBloodDonation()
        {
            blooddonation_dataGridView_bloodletting.DataSource = dh.getBloodDonations(ProfileID);

        }

        private void clear_button_bloodletting_Click(object sender, EventArgs e)
        {
           
        }

        private void delete_button_bloodletting_Click(object sender, EventArgs e)
        {
            
        }
       

        private void quantity_nud_ValueChanged(object sender, EventArgs e)
        {
         
        }
        private void event_combobox_bloodletting_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
       
        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ln_VisibleChanged(object sender, EventArgs e)
        {
            if (ln.Visible)
            {
                fn.Visible = true;
                mn.Visible = true;
                sf.Visible = true;
                firstname_label_bloodletting.Visible = false;
                lastname_label_bloodletting.Visible = false;
                suffix_label_bloodletting.Visible = false;
                mi_label_bloodletting.Visible = false;

            }
            else
            {
                fn.Visible = false;
                mn.Visible = false;
                sf.Visible = false;
                firstname_label_bloodletting.Text = fn.Text;
                lastname_label_bloodletting.Text = ln.Text;
                suffix_label_bloodletting.Text = sf.Text;
                mi_label_bloodletting.Text = mn.Text;
                firstname_label_bloodletting.Visible = true;
                lastname_label_bloodletting.Visible = true;
                suffix_label_bloodletting.Visible = true;
                mi_label_bloodletting.Visible = true;
            }
        }
        bool firsttime = true;
        private void cover_VisibleChanged(object sender, EventArgs e)
        {
            if (firsttime)
            {
                DataTable dt = dh.getBloodlettingEvents();
                foreach (DataRow dr in dt.Rows)
                {
                    event_combobox_bloodletting.Items.Add(new ComboboxContent(int.Parse(dr[0].ToString()), dr[1].ToString()));
                }
            }
            refreshBloodDonation();

        }
    }
}
