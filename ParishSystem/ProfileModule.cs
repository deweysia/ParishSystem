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
    public partial class ProfileModule : Form
    {
        DataHandler dh = new DataHandler();
        public ProfileModule()
        {
            InitializeComponent();
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            if (search_button.Tag.ToString() == "s")
            {
                profile_dgv.DataSource = dh.getGeneralProfilesProperLike(search_textbox.Text);
                profile_dgv.Columns["profileid"].Visible = false;
                profile_dgv.Columns["Name"].HeaderText = "Name";
                profile_dgv.Columns["Birthdate"].HeaderText = "Birthdate";
                profile_dgv.Columns["gender"].HeaderText = "Gender";
                profile_dgv.Columns["birthplace"].HeaderText = "Birthplace";
                profile_dgv.Columns["residence"].HeaderText = "Residence";
                search_button.Tag = "c";
                search_button.Image = ParishSystem.Properties.Resources.icons8_Delete_Filled_20_666666;
            }
            else
            {
                profile_dgv.DataSource = dh.getGeneralProfiles();
                profile_dgv.Columns["profileid"].Visible = false;
                profile_dgv.Columns["Name"].HeaderText = "Name";
                profile_dgv.Columns["Birthdate"].HeaderText = "Birthdate";
                profile_dgv.Columns["gender"].HeaderText = "Gender";
                profile_dgv.Columns["birthplace"].HeaderText = "Birthplace";
                profile_dgv.Columns["residence"].HeaderText = "Residence";
                search_button.Tag = "s";
                search_textbox.Clear();
                search_button.Image = ParishSystem.Properties.Resources.icons8_Search_Filled_20;
               
            }
        }
        public void refresh()
        {
            profile_dgv.DataSource = dh.getGeneralProfilesProper();
            profile_dgv.Columns["profileid"].Visible = false;
            profile_dgv.Columns["Name"].HeaderText = "Name";
            profile_dgv.Columns["Birthdate"].HeaderText = "Birthdate";
            profile_dgv.Columns["gender"].HeaderText = "Gender";
            profile_dgv.Columns["birthplace"].HeaderText = "Birthplace";
            profile_dgv.Columns["residence"].HeaderText = "Residence";
        }
        private void ProfileModule_Load(object sender, EventArgs e)
        {
            //refresh();
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

        private void profile_dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                try
                {
                    Form A = new PersonView(int.Parse(profile_dgv.SelectedRows[0].Cells["profileid"].Value.ToString()), dh);
                    A.ShowDialog();
                }
                catch { }
            }
        }

        private void profile_dgv_MouseDoubleClick(object sender, EventArgs e)
        {
            Form A = new PersonView(int.Parse(profile_dgv.SelectedRows[0].Cells["profileid"].Value.ToString()), dh);
            A.ShowDialog();
        }

        private void ProfileModule_VisibleChanged(object sender, EventArgs e)
        {
            refresh();
            search_button.Tag = "s";
            search_textbox.Clear();
            search_button.Image = ParishSystem.Properties.Resources.icons8_Search_Filled_20;
        }
    }
}
