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
    public partial class AddReferences : Form
    {
        private Point lastClick;
        private DataHandler dh = DataHandler.getDataHandler();
        public AddReferences(SacramentType t, string name)
        {
            InitializeComponent();
            lblSacrament.Text = t.ToString();
            lblName.Text = name;
        }

        public AddReferences(SacramentType t, string groomName, string brideName)
        {
            InitializeComponent();
            lblSacrament.Text = t.ToString();
            lblName.Text = string.Format("{0} & {1}", groomName, brideName);
        }

        private bool hasEmptyFields()
        {
            return string.IsNullOrWhiteSpace(txtRegistry.Text) || string.IsNullOrWhiteSpace(txtRecord.Text) || string.IsNullOrWhiteSpace(txtPage.Text);
        }


        private void AddReferences_Load(object sender, EventArgs e)
        {
            
        }

        private void AddReferences_MouseDown(object sender, MouseEventArgs e)
        {
            lastClick = new Point(e.X, e.Y);
        }

        private void AddReferences_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastClick.X;
                this.Top += e.Y - lastClick.Y;
            }
        }

        private void txtRecord_TextChanged(object sender, EventArgs e)
        {
            btnSubmit.Enabled = !hasEmptyFields();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}
