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
                search_button.Text = "Clear";
                search_button.Tag = "c";
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
                search_button.Text = "Search";
                search_button.Tag = "s";
                search_textbox.Clear();
            }
        }

        private void ProfileModule_Load(object sender, EventArgs e)
        {
            profile_dgv.DataSource=dh.getGeneralProfilesProper();
            profile_dgv.Columns["profileid"].Visible = false;
            profile_dgv.Columns["Name"].HeaderText = "Name";
            profile_dgv.Columns["Birthdate"].HeaderText = "Birthdate";
            profile_dgv.Columns["gender"].HeaderText = "Gender";
            profile_dgv.Columns["birthplace"].HeaderText = "Birthplace";
            profile_dgv.Columns["residence"].HeaderText = "Residence";
        }

        private void profile_dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form A = new PersonView(int.Parse(profile_dgv.SelectedRows[0].Cells["profileid"].Value.ToString()),dh);
            A.ShowDialog();
        }
    }
}
