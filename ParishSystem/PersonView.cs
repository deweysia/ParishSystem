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
    public partial class PersonView : Form
    {
        int ProfileID;
        DataHandler dh;
        DataTable Applications;
        DataTable Partners;
        public PersonView(int profileID, DataHandler DH)
        {
            InitializeComponent();
            ProfileID = profileID;
            dh = DH;
            Applications = dh.getApplicationsOf(ProfileID);
        }

        private void PersonView_Load(object sender, EventArgs e)
        {
            Draggable drag = new Draggable(this);
            drag.makeDraggable(controlBar_panel);

            foreach (DataRow dr in Applications.Rows)
            {
                if (int.Parse(dr["sacramentType"].ToString()) == (int)SacramentType.Baptism)
                {
                    baptism_label_menu.Enabled = true;
                }
                else if (int.Parse(dr["sacramentType"].ToString()) == (int)SacramentType.Confirmation)
                {
                    confirmation_label_menu.Enabled = true;
                }
                else if (int.Parse(dr["sacramentType"].ToString()) == (int)SacramentType.Marriage)
                {
                    marriage_label_menu.Enabled = true;
                }
            }
            DataTable temp = dh.getGeneralProfile(ProfileID);
            lastname_label.Text = temp.Rows[0]["lastname"].ToString();
            suffix_label.Text = temp.Rows[0]["suffix"].ToString();
            firstname_label.Text = temp.Rows[0]["firstname"].ToString();
            mi_label.Text = temp.Rows[0]["midname"].ToString();
            if (temp.Rows[0]["birthdate"].ToString()!="") { birthdate_label.Text = DateTime.Parse(temp.Rows[0]["birthdate"].ToString()).ToString("MMMM dd, yyyy");  } else { birthdate_panel.Visible = false; }

            if (temp.Rows[0]["gender"].ToString() != "")
            {
                if (int.Parse(temp.Rows[0]["gender"].ToString()) == (int)Gender.Male) gender_label.Text = "Male";
                else if (int.Parse(temp.Rows[0]["gender"].ToString()) == (int)Gender.Female) gender_label.Text = "Female";
            }
            else
            {
                gender_panel.Visible = false;
            }

           
            if (temp.Rows[0]["birthplace"].ToString() != "")
            {
                po_label.Text = temp.Rows[0]["birthplace"].ToString();
            }
            else
            {
                po_panel.Visible = false;
            }
            if (temp.Rows[0]["residence"].ToString()!="")
            {
                residence_label.Text = temp.Rows[0]["residence"].ToString();
            }
            else
            {
                residence_panel.Visible = false;
            }
            
           
            refreshParent();


        }

        private void baptism_menu_label_Click(object sender, EventArgs e)
        {
            blank_panel.Visible = false;
            baptism_panel.Visible = true;
            confirmation_panel.Visible = false;
            marriage_panel.Visible = false;
            baptism_label_menu.Font = new Font(baptism_label_menu.Font, FontStyle.Bold);
            confirmation_label_menu.Font = new Font(confirmation_label_menu.Font, FontStyle.Regular);
            marriage_label_menu.Font = new Font(marriage_label_menu.Font, FontStyle.Regular);
            refreshBaptism();
        }

        private void refreshBaptism()
        {
            foreach (DataRow dr in Applications.Rows)
            {
                if (dr["SacramentType"].ToString() == ((int)(SacramentType.Baptism)).ToString())
                {
                    
                    DataTable godFather = dh.getGodFatherOn(int.Parse(dr["applicationID"].ToString()));
                    if (godFather.Rows.Count>0)
                    {
                        name_label_godFather_baptism.Text = godFather.Rows[0]["Name"].ToString();
                        residence_label_godfather_baptism.Text = godFather.Rows[0]["residence"].ToString();
                    }
                    else
                    {
                        godfather_panel_baptism.Visible = false;
                    }
                    DataTable godMother = dh.getGodMotherOn(int.Parse(dr["applicationID"].ToString()));
                    if (godMother.Rows.Count > 0)
                    {
                        name_label_godMother_baptism.Text = godMother.Rows[0]["Name"].ToString();
                        residence_godMother_label_baptism.Text = godMother.Rows[0]["residence"].ToString();
                    }
                    else
                    {
                        godMother_panel_baptism.Visible = false;
                    }

                    DataTable temp = dh.getBaptism(int.Parse(dr["applicationID"].ToString()));
                    try
                    {
                        if( temp.Rows[0]["legitimacy"].ToString() == "1")
                        {
                            legitimacy_label_baptism.Text = "Legal";
                        }
                        else if (temp.Rows[0]["legitimacy"].ToString() == "2")
                        {
                            legitimacy_label_baptism.Text = "Civil";
                        }
                        else if (temp.Rows[0]["legitimacy"].ToString() == "3")
                        {
                            legitimacy_label_baptism.Text = "Natural";
                        }
                        date_label_baptism.Text = DateTime.Parse(temp.Rows[0]["baptismDate"].ToString()).ToString("MMMM dd yyyy");

                        name_label_minister_baptism.Text = dh.getMinister(int.Parse(dh.getBaptism(int.Parse(dr["applicationID"].ToString())).Rows[0]["ministerID"].ToString())).Rows[0]["name"].ToString();
                    }
                    catch { }
                    
                    try
                    {
                        registryNumber_label_baptism.Text = temp.Rows[0]["registryNumber"].ToString();

                        pageNumber_label_baptism.Text = temp.Rows[0]["pageNumber"].ToString();

                        recordNumber_label_baptism.Text = temp.Rows[0]["recordNumber"].ToString();
                    }
                    catch
                    {

                    }
                }
             }
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmation_label_menu_Click(object sender, EventArgs e)
        {
            blank_panel.Visible = false;
            baptism_panel.Visible = false;
            confirmation_panel.Visible = true;
            marriage_panel.Visible = false;
            baptism_label_menu.Font = new Font(baptism_label_menu.Font, FontStyle.Regular);
            confirmation_label_menu.Font = new Font(confirmation_label_menu.Font, FontStyle.Bold);
            marriage_label_menu.Font = new Font(marriage_label_menu.Font, FontStyle.Regular);
            refreshConfirmation();
            
        }

        private void refreshConfirmation()
        {
            foreach (DataRow dr in Applications.Rows)
            {
                if (dr["SacramentType"].ToString() == ((int)(SacramentType.Confirmation)).ToString())
                {
                   
                    DataTable godFather = dh.getGodFatherOn(int.Parse(dr["applicationID"].ToString()));
                    if (godFather.Rows.Count > 0)
                    {
                        name_label_godFather_confirmation.Text = godFather.Rows[0]["Name"].ToString();
                    }
                    else
                    {
                        godFather_panel_confirmation.Visible = false;
                    }
                    DataTable godMother = dh.getGodMotherOn(int.Parse(dr["applicationID"].ToString()));
                    if (godMother.Rows.Count > 0)
                    {
                        name_label_godMother_confirmation.Text = godMother.Rows[0]["Name"].ToString();
                    }
                    else
                    {
                        godMother_panel_confirmation.Visible = false;
                    }
                    DataTable temp = dh.getConfirmation(int.Parse(dr["applicationID"].ToString()));
                    try
                    {
                        date_label_confirmation.Text = DateTime.Parse(temp.Rows[0]["confirmationDate"].ToString()).ToString("MMMM dd yyyy");

                        name_label_minister_confirmation.Text = dh.getMinister(int.Parse(dh.getConfirmation(int.Parse(dr["applicationID"].ToString())).Rows[0]["ministerID"].ToString())).Rows[0]["name"].ToString();
                    }
                    catch { }
                    try
                    {
                        registryNumber_label_confirmation.Text = temp.Rows[0]["registryNumber"].ToString();

                        pageNumber_label_confirmation.Text = temp.Rows[0]["pageNumber"].ToString();

                        recordNumber_label_confirmation.Text = temp.Rows[0]["recordNumber"].ToString();
                    }
                    catch { }
                }
            }

        }

        bool marriageFirstClick = true;
        private void marriage_label_menu_Click(object sender, EventArgs e)
        {
            blank_panel.Visible = false;
            baptism_panel.Visible = false;
            confirmation_panel.Visible = false;
            marriage_panel.Visible = true;
            baptism_label_menu.Font = new Font(baptism_label_menu.Font, FontStyle.Regular);
            confirmation_label_menu.Font = new Font(confirmation_label_menu.Font, FontStyle.Regular);
            marriage_label_menu.Font = new Font(marriage_label_menu.Font, FontStyle.Bold);
            Partners = dh.getPartner(ProfileID);
            if (marriageFirstClick)
            {
                foreach (DataRow dr in Partners.Rows)
                {
                    name_spouse_combobox.Items.Add(new ComboboxContent((int.Parse(dr["profileID"].ToString())), (dr["name"].ToString())));
                }
                marriageFirstClick = false; //run this very heavy query only one time (optimization purpose only)
            }
            
        }
     
        private void name_spouse_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in Partners.Rows)
            {
                if (dr["ProfileID"].ToString()==(name_spouse_combobox.SelectedItem as ComboboxContent).ID.ToString()) {
                   
                    if (dr["birthdate"].ToString() != "")
                    {
                        birthdate_label_spouse_marriage.Text = DateTime.Parse((dr["birthdate"].ToString())).ToString("MMMM dd, yyyy");
                    }
                    else
                    {
                        birthdate_panel_spouse_marriage.Visible = false;
                    }

                    if (dr["gender"].ToString() != "")
                    {
                        if (int.Parse(dr["gender"].ToString()) == (int)Gender.Male) gender_label_spouse_marriage.Text = "Male";
                        else if (int.Parse(dr["gender"].ToString()) == (int)Gender.Female) gender_label_spouse_marriage.Text = "Female";
                    }
                    else
                    {
                        gender_panel_spouse_marriage.Visible = false;
                    }                   
                    if (dr["birthplace"].ToString() != "")
                    {
                        po_label_spouse_marriage.Text = dr["birthplace"].ToString();
                    }
                    else
                    {
                        placeOfOrigin_panel_spouse_marriage.Visible = false;
                    }
                    if (dr["residence"].ToString() != "")
                    {
                        residence_label_spouse_marriage.Text = dr["residence"].ToString();
                    }
                    else
                    {
                        residence_panel_spouse_marriage.Visible = false;
                    }
                   
                    
                    //father
                    DataTable Father = dh.getFatherOf(int.Parse(dr["profileID"].ToString()));
                    if (Father.Rows.Count > 0)
                    {
                        name_label_father_spouse_marriage.Text = Father.Rows[0]["Name"].ToString();
                        father_panel_spouse_marriage.Visible = true;
                    }
                  
                    //mother
                    DataTable Mother = dh.getMotherOf(int.Parse(dr["profileID"].ToString()));
                    if (Mother.Rows.Count > 0)
                    {
                        name_label_mother_spouse_marriage.Text = Mother.Rows[0]["Name"].ToString();
                        mother_panel_spouse_marriage.Visible = true;
                    }
                   
                    //godfather
                    DataTable godFather = dh.getGodFatherOn(int.Parse(dr["applicationID"].ToString()));
                    if (godFather.Rows.Count > 0)
                    {
                        godfather_panel_marriage.Visible = true;
                        name_label_godfather_marriage.Text = godFather.Rows[0]["Name"].ToString();
                    }
                    
                    //godmother
                    DataTable godMother = dh.getGodMotherOn(int.Parse(dr["applicationID"].ToString()));
                    if (godMother.Rows.Count > 0)
                    {
                        godmother_panel_marriage.Visible = true;
                        name_label_godmother_marriage.Text = godMother.Rows[0]["Name"].ToString();
                    }
                    DataTable temp = dh.getMarriage(int.Parse(dr["applicationID"].ToString()));
                    //minister
                    try
                    {
                        date_label_marriage.Text = DateTime.Parse(temp.Rows[0]["marriageDate"].ToString()).ToString("MMMM dd yyyy");

                        name_label_minister_marriage.Text = dh.getMinister(int.Parse(dh.getMarriage(int.Parse(dr["applicationID"].ToString())).Rows[0]["ministerID"].ToString())).Rows[0]["name"].ToString();
                    }
                    catch
                    {

                    }

                    try
                    {
                        registryNumber_label_marriage.Text = temp.Rows[0]["registryNumber"].ToString();

                        pageNumber_label_marriage.Text = temp.Rows[0]["pageNumber"].ToString();

                        recordNumber_label_marriage.Text = temp.Rows[0]["recordNumber"].ToString();
                    }
                    catch
                    {

                    }
                    try
                    { 
                        if (int.Parse(temp.Rows[0]["civilStatusGroom"].ToString()) == (int)CivilStatus.Single) civilStatus_self_marriage.Text = "Single";
                        else if (int.Parse(temp.Rows[0]["civilStatusGroom"].ToString()) == (int)CivilStatus.Widowed) civilStatus_self_marriage.Text = "Widowed";
                    }
                    catch
                    {
                        civilStatus_panel_marriage.Visible = false;
                    }
                    try
                    {
                            if (int.Parse(temp.Rows[0]["civilstatusBride"].ToString()) == (int)CivilStatus.Single) civilstatus_label_spouse_marriage.Text = "Single";
                            else if (int.Parse(temp.Rows[0]["civilstatusBride"].ToString()) == (int)CivilStatus.Widowed) civilstatus_label_spouse_marriage.Text = "Widowed";
                        
                    }
                    catch
                    {
                        civilstatus_panel_spouse_marriage.Visible = false;
                    }
                  
                }
            }
        }

        private void refreshParent()
        {
            DataTable Father = dh.getFatherOf(ProfileID);
            if (Father.Rows.Count > 0)
            {
                name_label_father_confirmation.Text = Father.Rows[0]["Name"].ToString();
                name_label_father_baptism.Text = Father.Rows[0]["Name"].ToString();
                po_label_father_baptism.Text = Father.Rows[0]["birthplace"].ToString();
                name_father_self_marriage.Text= Father.Rows[0]["Name"].ToString();
            }
            else
            {
                father_panel_confirmation.Visible = false;
                father_panel_baptism.Visible = false;
                father_panel_self_marriage.Visible = false;
            }
            DataTable Mother = dh.getMotherOf(ProfileID);
            if (Mother.Rows.Count > 0)
            {
                name_label_mother_confirmation.Text = Mother.Rows[0]["Name"].ToString();
                name_label_mother_baptism.Text = Mother.Rows[0]["Name"].ToString();
                po_label_mother_baptism.Text = Mother.Rows[0]["birthplace"].ToString();
                name_mother_self_marriage.Text = Mother.Rows[0]["Name"].ToString();
            }
            else
            {
                mother_panel_confirmation.Visible = false;
                mother_panel_baptism.Visible = false;
                mother_panel_self_marriage.Visible = false;
            }
           
                   
        }

        private void controlBar_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void menu_panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
