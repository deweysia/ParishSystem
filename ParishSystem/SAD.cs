using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ParishSystem
{
    public partial class SAD : Form
    {
        DataHandler dh = new DataHandler("localhost", "sad2", "root", "root");
        Point lastClick;
        public SAD()
        {
            InitializeComponent();

        }


        #region Effects
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }


        #endregion


        #region Form
        //-------------------------Main Form---------------------------//

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel_menu_Click(object sender, EventArgs e)
        {
            Panel A = sender as Panel;
            if (A.Equals(home_panel_menu)) { home_panel.BringToFront(); }
            else if (A.Equals(profile_panel_menu)) { profile_panel.BringToFront(); }
            else if (A.Equals(bloodletting_panel_menu)) { bloodletting_panel.BringToFront(); }
            else if (A.Equals(CDB_panel_menu)) { CDB_panel.BringToFront(); }
            else if (A.Equals(report_panel_menu)) { }
            else if (A.Equals(CRB_panel_menu)) { CRB_panel.BringToFront(); }
            else if (A.Equals(application_panel_menu)) { application_panel.BringToFront(); }

        }

        private void panel_controlbox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastClick.X;
                this.Top += e.Y - lastClick.Y;
            }
        }

        private void panel_controlbox_MouseDown(object sender, MouseEventArgs e)
        {
            lastClick = new Point(e.X, e.Y);
        }

        private void navBarPanel_MouseEnter(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;

            p.BackColor = Color.SteelBlue;

        }

        private void narBar_MouseLeave(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;

            p.BackColor = Color.DodgerBlue;
        }
        #endregion


        #region Profiles

        private void resetProfilesVariables()
        {//reset variables used by profiles tab
            lastGeneralProfile = 0;
        }

        int lastGeneralProfile=0;

        private void refreshGeneralProfileTable()
        {//refresh general profile table
            DataTable dt = dh.getGeneralProfiles();
            generalprofile_datagridview.DataSource = dt;
            generalprofile_datagridview.Columns["profileID"].Visible = false;
            generalprofile_datagridview.Columns["firstName"].Visible = false;
            generalprofile_datagridview.Columns["midName"].Visible = false;
            generalprofile_datagridview.Columns["lastName"].Visible = false;
            generalprofile_datagridview.Columns["suffix"].Visible = false;
        }

        private void generalprofile_datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {//data grid cell click
            openProfile_button.Enabled = true;
            deleteProfile_button.Enabled = true;

            lastGeneralProfile = int.Parse(generalprofile_datagridview.CurrentRow.Cells["profileID"].Value.ToString());
            firstname_textbox.Text=generalprofile_datagridview.CurrentRow.Cells["firstname"].Value.ToString();
            middlename_textbox.Text=generalprofile_datagridview.CurrentRow.Cells["midname"].Value.ToString();
            lastname_textbox.Text = generalprofile_datagridview.CurrentRow.Cells["lastname"].Value.ToString();
            suffix_textbox.Text = generalprofile_datagridview.CurrentRow.Cells["suffix"].Value.ToString();

            Console.WriteLine(lastGeneralProfile);
        }
 
        private void addProfile_button_Click(object sender, EventArgs e)
        {//adds basic profile with name values only 
            if (dh.addGeneralProfile(firstname_textbox.Text, middlename_textbox.Text, lastname_textbox.Text, suffix_textbox.Text, '0',DateTime.MinValue , null, null, null)) { refreshGeneralProfileTable(); }
            else { MessageBox.Show("Entry not added"); }
            clearProfile();
        }

        private void openProfile_button_Click(object sender, EventArgs e)
        {//open person complete profile
           
            Form person = new Person(lastGeneralProfile, dh);
            person.ShowDialog();
            clearProfile();
        }

        private void deleteProfile_button_Click(object sender, EventArgs e)
        {
            dh.deleteGeneralProfile(lastGeneralProfile);
            refreshGeneralProfileTable();
        }

        private void firstname_textbox_MouseClick(object sender, MouseEventArgs e)
        {
            firstname_textbox.Text = "";
        }

        private void middlename_textbox_MouseClick(object sender, MouseEventArgs e)
        {
            middlename_textbox.Text = "";
        }

        private void lastname_textbox_MouseClick(object sender, MouseEventArgs e)
        {
            lastname_textbox.Text = "";
        }

        private void suffix_textbox_MouseClick(object sender, MouseEventArgs e)
        {
            suffix_textbox.Text = "";
        }

        private void clearProfile()
        {
            lastname_textbox.Text = "Last Name";
            middlename_textbox.Text = "Middle Name";
            firstname_textbox.Text = "First Name";
            suffix_textbox.Text = "Suffix";
            lastGeneralProfile = 0;
        }

        private void clear_profile_button_Click(object sender, EventArgs e)
        {
            clearProfile();
            deleteProfile_button.Enabled = false;
            openProfile_button.Enabled = false;
            addProfile_button.Enabled = false;

        }












        #endregion


        #region Application
        //----------------------APPLICATION------------------------//
        private void applicationMenu_labelClick(object sender, EventArgs e)
        {
            Label A = sender as Label;
            if (A.Equals(baptismApplication_label))
            {
                //label changes
                baptismApplication_label.Font = new Font(baptismApplication_label.Font, FontStyle.Bold);
                baptismApplication_label.ForeColor = Color.DodgerBlue;
                confirmationApplication_label.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                confirmationApplication_label.ForeColor = Color.Black;
                marriageApplication_label.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                marriageApplication_label.ForeColor = Color.Black;

                //panel changes
                baptismApplication_panel.BringToFront();

            }
            else if (A.Equals(confirmationApplication_label))
            {
                //label changes
                baptismApplication_label.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                baptismApplication_label.ForeColor = Color.Black;
                confirmationApplication_label.Font = new Font(baptismApplication_label.Font, FontStyle.Bold);
                confirmationApplication_label.ForeColor = Color.DodgerBlue;
                marriageApplication_label.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                marriageApplication_label.ForeColor = Color.Black;

                //panel changes
                confirmationApplication_panel.BringToFront();

            }
            else if (A.Equals(marriageApplication_label))
            {
                //label changes
                baptismApplication_label.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                baptismApplication_label.ForeColor = Color.Black;
                confirmationApplication_label.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                confirmationApplication_label.ForeColor = Color.Black;
                marriageApplication_label.Font = new Font(baptismApplication_label.Font, FontStyle.Bold);
                marriageApplication_label.ForeColor = Color.DodgerBlue;

                //panel changes
                marriageApplication_panel.BringToFront();

            }
        }

        private void newApplicant_checkbox_confirmationApplication_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox A = sender as CheckBox;
            //baptism application
            if (A.Equals(newApplicant_checkbox_baptismApplication))
            {
                if (A.Checked == true)
                {
                    existingName_panel_baptismApplication.Enabled = false;
                    newName_panel_baptismApplication.Visible = true;
                }
                else if (A.Checked == false)
                {
                    existingName_panel_baptismApplication.Enabled = true;
                    newName_panel_baptismApplication.Visible = false;
                }

            }
            //confirmation application
            else if (A.Equals(newApplicant_checkbox_confirmationApplication)) {
                if (A.Checked==true) {
                    existingName_panel_confirmationApplication.Enabled = false;
                    newName_panel_confirmationApplication.Visible = true;
                }
                else if(A.Checked == false)
                {
                    existingName_panel_confirmationApplication.Enabled = true;
                    newName_panel_confirmationApplication.Visible = false;
                }
                
            }
            //marriage application
            //-groom
            else if (A.Equals(newGroom_checkbox_marriageApplication))
            {
                if (A.Checked == true)
                {
                    groomExisting_panel_marriageApplication.Enabled = false;
                    groomNew_panel_marriageApplication.Visible = true;
                }
                else if (A.Checked == false)
                {
                    groomExisting_panel_marriageApplication.Enabled = true;
                    groomNew_panel_marriageApplication.Visible = false;
                }

            }
            //-bride
            else if (A.Equals(newBride_checkbox_marriageApplication))
            {
                if (A.Checked == true)
                {
                    brideExisting_panel_marriageApplication.Enabled = false;
                    brideNew_panel_marriageApplication.Visible = true;
                }
                else if (A.Checked == false)
                {
                    brideExisting_panel_marriageApplication.Enabled = true;
                    brideNew_panel_marriageApplication.Visible = false;
                }

            }

        }
        #endregion


        #region CDB
        //--------------------------CDB----------------------------//
        private void label_CD_Click(object sender, EventArgs e)
        {
            Label A = sender as Label;
            if (A.Equals(parish_label_CD)) {
                //label changes
                parish_label_CD.Font = new Font(baptismApplication_label.Font, FontStyle.Bold);
                parish_label_CD.ForeColor = Color.DodgerBlue;
                community_label_CD.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                community_label_CD.ForeColor = Color.Black;
                postulancy_label_CD.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                postulancy_label_CD.ForeColor = Color.Black;

                //panel changes
                parish_panel_CD.BringToFront();
            }
            else if (A.Equals(community_label_CD)) {
                //label changes
                parish_label_CD.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                parish_label_CD.ForeColor = Color.Black;
                community_label_CD.Font = new Font(baptismApplication_label.Font, FontStyle.Bold);
                community_label_CD.ForeColor = Color.DodgerBlue;
                postulancy_label_CD.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                postulancy_label_CD.ForeColor = Color.Black;

                //panel changes
                community_panel_CD.BringToFront();
            }
            else if (A.Equals(postulancy_label_CD)) {
                //label changes
                parish_label_CD.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                parish_label_CD.ForeColor = Color.Black;
                community_label_CD.Font = new Font(baptismApplication_label.Font, FontStyle.Regular);
                community_label_CD.ForeColor = Color.Black;
                postulancy_label_CD.Font = new Font(baptismApplication_label.Font, FontStyle.Bold);
                postulancy_label_CD.ForeColor = Color.DodgerBlue;

                //panel changes
                postulancy_panel_CD.BringToFront();
            }
        }
        #endregion
    

        #region CRB
        //--------------------------CRB----------------------------//

        #endregion

      

    }
}
