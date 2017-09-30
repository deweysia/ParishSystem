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
            this.dh = dh;
            ProfileID =profileID;
            hasProfile = true;
            edit_button.Tag = "e";
            edit_button.Image = Properties.Resources.icons8_Pencil_32__1_;
            cover.Visible = false;
            loaddonationinfo();
        }

        public Bloodletting_Profile_Popup(DataHandler dh)
        {
            InitializeComponent();
            this.dh = dh;
            ProfileID = dh.getNextBloodlettingID();
            hasProfile = false;
            edit_button.Tag = "s";
            edit_button.Image= Properties.Resources.icons8_Save_Filled_32__1_;
            loaddonationinfo();


        }
        private void profileEditmode()
        {
            fn.Visible = true;
            mn.Visible = true;
            ln.Visible = true;
            sf.Visible = true;
            bloodtype_combobox.SelectedItem=bloodtype_label.Text;
            bloodtype_combobox.Visible = true;
            address_textbox.ReadOnly = false;
            contactNumber_textbox.ReadOnly = false;
            firstname_label_bloodletting.Visible = false;
            lastname_label_bloodletting.Visible = false;
            suffix_label_bloodletting.Visible = false;
            mi_label_bloodletting.Visible = false;
        }
        private void profileViewmode()
        {
            fn.Visible = false;
            mn.Visible = false;
            ln.Visible = false;
            sf.Visible = false;
            address_textbox.Text = addres;
            contactNumber_textbox.Text = contact;
            bloodtype_combobox.Visible = false;
            address_textbox.ReadOnly = true;
            contactNumber_textbox.ReadOnly = true;
            firstname_label_bloodletting.Visible = true;
            lastname_label_bloodletting.Visible = true;
            suffix_label_bloodletting.Visible = true;
            mi_label_bloodletting.Visible = true;
        }


        private void Bloodletting_Details_Popup_Load(object sender, EventArgs e)
        {
            Draggable draggable = new Draggable(this);
            draggable.makeDraggable(controlBar_panel);

            if (hasProfile)
            {
                profileViewmode();
                DataTable dt = dh.getBloodDonor(ProfileID);
                firstname_label_bloodletting.Text = dt.Rows[0]["firstname"].ToString();
                mi_label_bloodletting.Text = dt.Rows[0]["midname"].ToString();
                lastname_label_bloodletting.Text = dt.Rows[0]["lastname"].ToString();
                suffix_label_bloodletting.Text = dt.Rows[0]["suffix"].ToString();
                bloodtype_label.Text = bloodType[int.Parse(dt.Rows[0]["bloodtype"].ToString())-1];
                address_textbox.Text = dt.Rows[0]["address"].ToString();
                contactNumber_textbox.Text = dt.Rows[0]["contactNumber"].ToString();
            }
            else
            {
                profileEditmode();
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
           
                if (edit_button.Tag.ToString() == "s")
                {
                    cancel_button.Visible = false;
                    delete_button.Visible = false;
                    if (fn.Text != "" && mn.Text != "" && ln.Text != "" && address_textbox.Text != "" && contactNumber_textbox.MaskFull && bloodtype_combobox.Text != "")
                    {
                    if (hasProfile)//edit
                    {
                            if (dh.countSameDonor(fn.Text, mn.Text, ln.Text, sf.Text, address_textbox.Text, contactNumber_textbox.Text, bloodtype_combobox.SelectedIndex + 1) != 0)//someone exists
                            {
                                int from = dh.getBloodDonorWhere(fn.Text, mn.Text, ln.Text, sf.Text, address_textbox.Text, contactNumber_textbox.Text, bloodtype_combobox.SelectedIndex + 1);
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
                            dh.editBloodDonor(ProfileID, fn.Text, mn.Text, ln.Text, sf.Text, address_textbox.Text, contactNumber_textbox.Text, bloodtype_combobox.SelectedIndex + 1);
                            edit_button.Image = Properties.Resources.icons8_Pencil_32__1_;
                            edit_button.Tag = "e";
                            refreshPerson();                      
                    }
                    else//add
                    {

                            if (dh.countSameDonor(fn.Text, mn.Text, ln.Text, sf.Text, address_textbox.Text, contactNumber_textbox.Text, bloodtype_combobox.SelectedIndex) == 0)
                            {
                                dh.addBloodDonor(fn.Text, mn.Text, ln.Text, sf.Text, address_textbox.Text, contactNumber_textbox.Text, bloodtype_combobox.SelectedIndex + 1);
                                Notification.Show(State.ProfileAdded);
                                edit_button.Tag = "e";
                                edit_button.Image = Properties.Resources.icons8_Pencil_32__1_;
                                hasProfile = true;
                                refreshPerson();
                            }
                            else
                            {
                                Notification.Show(State.ProfileExists);
                                ClearProfile();
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
                if (AdminCredentialDialog.Show() == DialogResult.Yes)
                {
                    profileEditmode();
                    edit_button.Tag = "s";
                    edit_button.Image = Properties.Resources.icons8_Save_Filled_32__1_;
                    if (hasProfile)
                    {
                        fn.Text = firstname_label_bloodletting.Text;
                        ln.Text = lastname_label_bloodletting.Text;
                        sf.Text = suffix_label_bloodletting.Text;
                        mn.Text = mi_label_bloodletting.Text;

                        firstname = firstname_label_bloodletting.Text;
                        midname = mi_label_bloodletting.Text;
                        lastname = lastname_label_bloodletting.Text;
                        suffix = suffix_label_bloodletting.Text;
                        contact = contactNumber_textbox.Text;
                        addres = address_textbox.Text;
                    }
                    cover.Visible = true;
                    cancel_button.Visible = true;
                    delete_button.Visible = true;
                }
            }
           
        }
        private void ClearProfile()
        {
            fn.Clear();
            mn.Clear();
            ln.Clear();
            sf.Clear();
            bloodtype_combobox.SelectedIndex = 0;
            address_textbox.Clear();
            contactNumber_textbox.Clear();
        }
        private void refreshPerson()
        {
            if (hasProfile)
            {
                fn.Visible = false;
                mn.Visible = false;
                ln.Visible = false;
                sf.Visible = false;
                bloodtype_combobox.Visible = false;
                bloodtype_label.Text = bloodtype_combobox.Text;
                address_textbox.ReadOnly = true;
                contactNumber_textbox.ReadOnly = true;
                firstname_label_bloodletting.Text = fn.Text;
                lastname_label_bloodletting.Text = ln.Text;
                suffix_label_bloodletting.Text = sf.Text;
                mi_label_bloodletting.Text = mn.Text;
                firstname_label_bloodletting.Visible = true;
                lastname_label_bloodletting.Visible = true;
                suffix_label_bloodletting.Visible = true;
                mi_label_bloodletting.Visible = true;
                cover.Visible = false;
            }
        }
        private void cancel_button_Click(object sender, EventArgs e)
        {
            if (hasProfile)
            {
                profileViewmode();
                cancel_button.Visible = false;
                delete_button.Visible = false;
                edit_button.Image = Properties.Resources.icons8_Pencil_32__1_;
                edit_button.Tag = "e";
                cover.Visible = false;
            }
            else
            {
                ClearProfile();
            }
        }

        private void addDonation_button_bloodletting_Click(object sender, EventArgs e)
        {
            if (!dh.isBloodDonationIDExist(donationID_textbox.Text)) {
                if (addDonation_button_bloodletting.Text == "Add")
                {
                    dh.addBloodDonation(ProfileID, donationID_textbox.Text, ((ComboboxContent)event_combobox_bloodletting.SelectedItem).ID);

                }
                else if (addDonation_button_bloodletting.Text == "Edit")
                {
                    dh.editBloodDonation(int.Parse(blooddonation_dataGridView_bloodletting.CurrentRow.Cells["blooddonationid"].Value.ToString()), donationID_textbox.Text, ((ComboboxContent)event_combobox_bloodletting.SelectedItem).ID);
                    addDonation_button_bloodletting.Text = "Add";

                }
                clearAddInfo();
                loaddonationinfo();
                addDonation_button_bloodletting.Enabled = false;
                delete_button_bloodletting.Enabled = false;
            }
            else
            {
                Notification.Show(State.BloodDonationIDUsed);
            }
        }
        private void blooddonation_dataGridView_bloodletting_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            {
                donationID_textbox.Text = blooddonation_dataGridView_bloodletting.CurrentRow.Cells["DonationID"].Value.ToString();
                addDonation_button_bloodletting.Text = "Edit";
                addDonation_button_bloodletting.Enabled = true;
                delete_button_bloodletting.Enabled = true;
                event_combobox_bloodletting.SelectedItem = new ComboboxContent(int.Parse(blooddonation_dataGridView_bloodletting.CurrentRow.Cells["DonationID"].Value.ToString()), (blooddonation_dataGridView_bloodletting.CurrentRow.Cells["EventName"].Value.ToString()));
                event_combobox_bloodletting.Text = (blooddonation_dataGridView_bloodletting.CurrentRow.Cells["EventName"].Value.ToString());
            }
            //catch
            {

            }
        }
        private void clearAddInfo()
        {
            donationID_textbox.Clear();
            event_combobox_bloodletting.SelectedIndex = 0;
        }
       private void refreshBloodDonation()
        {
         /*   
            blooddonation_dataGridView_bloodletting.DataSource = dh.getBloodDonations(ProfileID);
            totalDonation_label.Text = dh.getTotalBloodDonationOf(ProfileID).ToString();
            foreach (DataGridViewColumn c in blooddonation_dataGridView_bloodletting.Columns)
            {
                c.Visible = false;
            }
            blooddonation_dataGridView_bloodletting.Columns["eventName"].HeaderText = "Event Name";
            blooddonation_dataGridView_bloodletting.Columns["eventName"].Visible = true;
            blooddonation_dataGridView_bloodletting.Columns["donationID"].HeaderText = "Donation ID";
            blooddonation_dataGridView_bloodletting.Columns["donationID"].Visible = true;
            */
            
            
            if (hasProfile) {
                blooddonation_dataGridView_bloodletting.Rows.Clear();
                int rows = 0;
                    foreach (DataRow dr in dh.getBloodDonations(ProfileID).Rows)
                    {
                    blooddonation_dataGridView_bloodletting.Rows.Add(dr["donationID"].ToString(), dr["eventName"].ToString(), dr["bloodDonationEventID"].ToString(),dr["bloodDonationID"].ToString());
                    var a = dr["bloodclaimant"].ToString();
                    if (!(dr["bloodclaimant"].ToString()==""))
                        {
                        blooddonation_dataGridView_bloodletting.Rows[rows].Cells[0].Style.BackColor = Color.LightCoral;
                        blooddonation_dataGridView_bloodletting.Rows[rows].Cells[1].Style.BackColor = Color.LightCoral;
                    }
                    rows++;
                    }
                    
            }
            
            
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
            if (AdminCredentialDialog.Show()== DialogResult.Yes) {
                if (!dh.isBloodDonationClaimed(int.Parse(blooddonation_dataGridView_bloodletting.CurrentRow.Cells["blooddonationID"].Value.ToString()))) {
                    dh.deleteBloodDonation(int.Parse(blooddonation_dataGridView_bloodletting.CurrentRow.Cells["blooddonationID"].Value.ToString()));
                    refreshBloodDonation();
                    delete_button_bloodletting.Enabled = false;
                    addDonation_button_bloodletting.Enabled = false;
                    clearAddInfo();
                    addDonation_button_bloodletting.Text = "Add";
                }
                else
                {
                    Notification.Show(State.CannotDeleteBloodAlreadyClaimed);
                }
            }
        }

        private void checkContent()
        {
            if (event_combobox_bloodletting.Text == "" || donationID_textbox.Text.Trim()=="")
            {
                addDonation_button_bloodletting.Enabled = false;
            }
            else
            {
                addDonation_button_bloodletting.Enabled = true;
            }
        }
        private void donationID_textbox_TextChanged(object sender, EventArgs e)
        {
            checkContent();
        }
        private void event_combobox_bloodletting_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkContent();
        }
       
        private void close_button_Click(object sender, EventArgs e)
        {
            if (edit_button.Tag.ToString() == "s")
            {
                if (MessageDialog.Show("Pending changes will not be saved. Are you sure you wish to close?",MessageDialogButtons.YesNo,MessageDialogIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

     
        bool firsttime = true;
        private void loaddonationinfo()
        {
            if (firsttime)
            {
                event_combobox_bloodletting.Items.Clear();
                DataTable dt = dh.getBloodlettingEvents();
                foreach (DataRow dr in dt.Rows)
                {
                    event_combobox_bloodletting.Items.Add(new ComboboxContent(int.Parse(dr[0].ToString()), dr[1].ToString()));
                }
                firsttime = false;
            }
            refreshBloodDonation();

        }

        private void cover_VisibleChanged(object sender, EventArgs e)
        {
            if (hasProfile && !cover.Visible)
            {
                refreshBloodDonation();
            }
        }

        private void Bloodletting_Profile_Popup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            CustomMessage msg = new CustomMessage();
            if (msg.Show("Are you sure you want to delete this profile?", MessageDialogButtons.YesNoCancel, MessageDialogIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    dh.deleteBloodDonor(ProfileID);
                    this.Close();
                }
                catch
                {
                    dh.conn.Close();
                    Notification.Show(State.PersonHasDonations);
                }
            }
        }
    }
}
