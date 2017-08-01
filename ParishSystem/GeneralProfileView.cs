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
    public partial class person : Form
    {
        int PersonID;
        DataHandler DH;
        DataTable Applications;
        public person(int personID, DataHandler dh)
        {
            InitializeComponent();

            PersonID = personID;
            DH = dh;
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void person_Load(object sender, EventArgs e)
        {
            DataTable temp = DH.getGeneralProfile(PersonID);
            birthdate_label.Text = DH.toDateTime(temp.Rows[0]["birthdate"].ToString(),false).ToString("MMMM dd, yyyy");
        }
    }
}
