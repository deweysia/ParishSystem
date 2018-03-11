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

        Dictionary<int, string> dateSuffix = new Dictionary<int, string>();

        public PersonView(int profileID, DataHandler DH)
        {
            InitializeComponent();
            ProfileID = profileID;
            dh = DH;
            Applications = dh.getApplicationsOf(ProfileID);


            dateSuffix.Add(1, "st");
            dateSuffix.Add(2, "th");
            dateSuffix.Add(3, "rd");
        }

        


        private string getDayOfMonthWithSuffix(DateTime date)
        {
            int day = Convert.ToInt32(date.ToString("dd"));

            int day_ones = day % 10;

            string dayOfMonth = day + dateSuffix.GetValueOrDefault(day_ones, "th");

            return dayOfMonth;
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
            btnMarriagePrint.Enabled = name_spouse_combobox.SelectedIndex != -1;
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

        private void menu_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMarriagePrint_Click(object sender, EventArgs e)
        {
            

            string groomName;
            DateTime groomBirthDate;
            string groomStatus;
            string groomFather;
            string groomMother;
            string groomResidency;
            string groomOrigin;
            string groomAge;

            string brideName;
            DateTime brideBirthDate;
            string brideStatus;
            string brideMother;
            string brideFather;
            string brideResidency;
            string brideOrigin;
            string brideAge;

            string minister = name_label_minister_marriage.Text;
            DateTime marriageDateTime = DateTime.ParseExact(date_label_marriage.Text, "MMMM dd yyyy", null);
            DateTime givenDateTime = DateTime.Now;
            string godFather = name_label_godfather_marriage.Text;
            string godMother = name_label_godmother_marriage.Text;

            string marriageDay = getDayOfMonthWithSuffix(marriageDateTime);
            string marriageMonthYear = marriageDateTime.ToString("MMMM yyyy");
            string givenDay = getDayOfMonthWithSuffix(givenDateTime);
            string givenMonthYear = givenDateTime.ToString("MMMM yyyy");


            if (gender_label.Text == "Male")
            {
                groomName = String.Join(" ", firstname_label.Text, mi_label.Text, lastname_label.Text, suffix_label.Text);
                groomBirthDate = DateTime.ParseExact(birthdate_label.Text, "MMMM dd, yyyy", null);
                groomStatus = civilStatus_self_marriage.Text;
                groomFather = name_father_self_marriage.Text;
                groomMother = name_mother_self_marriage.Text;
                groomResidency = residence_label.Text;
                groomOrigin = po_label.Text;

                int age = DateTime.Today.Year - groomBirthDate.Year;
                if (DateTime.Today < groomBirthDate.AddYears(age)) age--;
                groomAge = age.ToString();

                brideName = name_spouse_combobox.Text;
                brideBirthDate = DateTime.ParseExact(birthdate_label_spouse_marriage.Text, "MMMM dd, yyyy", null);
                brideStatus = civilstatus_label_spouse_marriage.Text;
                brideFather = name_label_father_spouse_marriage.Text;
                brideMother = name_label_mother_spouse_marriage.Text;
                brideResidency = residence_label_spouse_marriage.Text;
                brideOrigin = po_label_spouse_marriage.Text;

                age = DateTime.Today.Year - brideBirthDate.Year;
                if (DateTime.Today < brideBirthDate.AddYears(age)) age--;
                brideAge = age.ToString();
            }
            else
            {
                brideName = String.Join(" ", firstname_label.Text, mi_label.Text, lastname_label.Text, suffix_label.Text);
                brideBirthDate = DateTime.ParseExact(birthdate_label.Text, "MMMM dd, yyyy", null);
                brideStatus = civilStatus_self_marriage.Text;
                brideFather = name_father_self_marriage.Text;
                brideMother = name_mother_self_marriage.Text;
                brideResidency = residence_label.Text;
                brideOrigin = po_label.Text;

                int age = DateTime.Today.Year - brideBirthDate.Year;
                if (DateTime.Today < brideBirthDate.AddYears(age)) age--;
                brideAge = age.ToString();

                groomName = name_spouse_combobox.Text;
                groomBirthDate = DateTime.ParseExact(birthdate_label_spouse_marriage.Text, "MMMM dd, yyyy", null);
                groomStatus = civilstatus_label_spouse_marriage.Text;
                groomFather = name_label_father_spouse_marriage.Text;
                groomMother = name_label_mother_spouse_marriage.Text;
                groomResidency = residence_label_spouse_marriage.Text;
                groomOrigin = po_label_spouse_marriage.Text;

                age = DateTime.Today.Year - groomBirthDate.Year;
                if (DateTime.Today < groomBirthDate.AddYears(age)) age--;
                groomAge = age.ToString();
            }

            /*
             String groomname, String groomage, String groomstatus, String groommother, String groomfather,
            String groomresidency, String groombornin, String bridename, String brideage, String bridestatus, String bridemother,
            String bridefather, String brideresidency, String bridebornin, String priest, 
            String marriageDay, String marriageMonthYear, String givenDay, String givenMonthYear,
            String witness1, String witness2*/
            //string groomName = 

            MarriagePreview f = new MarriagePreview(groomName, groomAge, groomStatus, groomMother, groomFather, groomResidency, groomOrigin,
                brideName, brideAge, brideStatus, brideMother, brideFather, brideResidency, brideOrigin,
                minister, marriageDay, marriageMonthYear, givenDay, givenMonthYear, godFather, godMother);
            f.ShowDialog();
        }

        private void btnBaptismPrint_Click(object sender, EventArgs e)
        {
            string name = String.Join(" ", firstname_label.Text, mi_label.Text, lastname_label.Text, suffix_label.Text);
            string birthplace = po_label.Text;
            string birthdate = birthdate_label.Text;
            string fatherName = name_label_father_baptism.Text;
            string motherName = name_label_mother_baptism.Text;
            string fatherOrigin = po_label_father_baptism.Text;
            string motherOrigin = po_label_mother_baptism.Text;
            string baptismDate = date_label_baptism.Text;
            string sponsorName = name_label_godFather_baptism.Text + " " + name_label_godMother_baptism.Text;
            string issueDate = DateTime.Now.ToString("MM dd, yyyy");
            string registry = registryNumber_label_baptism.Text;
            string record = recordNumber_label_baptism.Text;
            string page = pageNumber_label_baptism.Text;
            string minister = name_label_minister_baptism.Text;

            CertificatePurpose cp = new CertificatePurpose();
            DialogResult dr = cp.ShowDialog();
            string purpose = cp.purpose;

            if (dr != DialogResult.OK)
                return;
            BaptismalPreview f = new BaptismalPreview(name, birthplace, birthdate, fatherName, motherName, fatherOrigin, motherOrigin, baptismDate, sponsorName, issueDate, registry, record, page, minister, purpose, birthplace);

            f.ShowDialog();
        }

        private void btnConfirmationPrint_Click(object sender, EventArgs e)
        {
            string name = String.Join(" ", firstname_label.Text, mi_label.Text, lastname_label.Text, suffix_label.Text);
            string birthplace = po_label.Text;
            string birthdate = birthdate_label.Text;
            string fatherName = name_label_father_confirmation.Text;
            string motherName = name_label_mother_confirmation.Text;

            DateTime confirmationDateTime = DateTime.ParseExact(date_label_confirmation.Text, "MMMM dd yyyy", null);
            string confirmationDay = getDayOfMonthWithSuffix(confirmationDateTime);
            string confirmationMonthYear = confirmationDateTime.ToString("MMMM yyyy");

            string godFather = name_label_godFather_confirmation.Text;
            string godMotherName = name_label_godMother_confirmation.Text;

            string issueDate = DateTime.Now.ToString("MM dd, yyyy");
            string minister = name_label_minister_confirmation.Text;

            ConfirmationPreview f = new ConfirmationPreview(name, confirmationDay, confirmationMonthYear, minister, fatherName, motherName, godFather, godMotherName);

            f.ShowDialog();
        }
    }

    static class DictionaryExtension //Class that declares an extension method for Dictionary
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultValue;
        }


    }
}
