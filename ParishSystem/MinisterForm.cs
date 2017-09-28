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
    public partial class MinisterForm : Form
    {

        DataHandler dh = DataHandler.getDataHandler();
        private Minister minister = null;
        private DataGridViewRow dgvr = null;
        public MinisterForm()
        {
            InitializeComponent();

            Draggable drag = new Draggable(this);
            drag.makeDraggable(controlBar_panel);

            dtpBirthdate.Value = DateTime.Now;
            dtpBirthdate.MaxDate = DateTime.Now;


            cmbMinistryType.DataSource = Enum.GetValues(typeof(MinistryType));
            cmbStatus.DataSource = Enum.GetValues(typeof(MinisterStatus));
        }

        /*public MinisterForm(Minister minister) : this()
        {

            this.minister = minister;

            dtpBirthdate.Value = minister.birthdate;
            dtpBirthdate.MaxDate = DateTime.Now;

            cmbMinistryType.DataSource = Enum.GetValues(typeof(MinistryType));
            cmbMinistryType.SelectedIndex = Convert.ToInt32(minister.ministryType) - 1;

            cmbStatus.DataSource = Enum.GetValues(typeof(MinisterStatus));
            cmbStatus.SelectedIndex = Convert.ToInt32(minister.status) - 1;
        }*/

        public MinisterForm(DataGridViewRow dgvr) : this()
        {
            this.dgvr = dgvr;
            loadMinisterDetails();
        }

        private void loadMinisterDetails()
        {
            int ministerID = Convert.ToInt32(dgvr.Cells["ministerID"].Value);
            string fn = Convert.ToString(dgvr.Cells["firstName"].Value);
            string mi = Convert.ToString(dgvr.Cells["midName"].Value);
            string ln = Convert.ToString(dgvr.Cells["lastName"].Value);
            string suffix = Convert.ToString(dgvr.Cells["suffix"].Value);
            DateTime birthdate = Convert.ToDateTime(dgvr.Cells["birthdate"].Value);
            MinistryType mtype = (MinistryType)Convert.ToInt32(dgvr.Cells["ministryType"].Value);
            MinisterStatus status = (MinisterStatus)Convert.ToInt32(dgvr.Cells["status"].Value);

            txtFN.Text = fn;
            txtMI.Text = mi;
            txtLN.Text = ln;
            txtSuffix.Text = suffix;
            dtpBirthdate.Value = birthdate;
            cmbMinistryType.SelectedIndex = cmbMinistryType.Items.IndexOf(mtype);
            cmbStatus.SelectedIndex = cmbStatus.Items.IndexOf(status);
        }


        private void licenseNum_textBox_TextChanged(object sender, EventArgs e)
        {
            addBtn.Enabled = !(string.IsNullOrWhiteSpace(txtFN.Text)
                || string.IsNullOrWhiteSpace(txtMI.Text)
                || string.IsNullOrWhiteSpace(txtLN.Text));
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (!allFilled())
            {
                Notification.Show(State.MissingFields);
                return;
            }

            if (this.dgvr == null)
                addMinister();
            else
                editMinister();

            this.Close();
        }

        private bool allFilled()
        {
            bool success = !string.IsNullOrWhiteSpace(txtFN.Text);
            success &= !string.IsNullOrWhiteSpace(txtMI.Text);
            success &= !string.IsNullOrWhiteSpace(txtLN.Text);
            return success;
        }

        
        private void addMinister()
        {
            bool success = dh.addMinister(txtFN.Text, txtMI.Text, txtLN.Text, txtSuffix.Text,
                dtpBirthdate.Value, (MinistryType)(cmbMinistryType.SelectedIndex + 1),
                (MinisterStatus)(cmbStatus.SelectedIndex + 1));
            if (success)
                Notification.Show(State.MinisterAddSuccess);
            else
                Notification.Show(State.MinisterAddFail);
        }

        private void editMinister()
        {
            int ministerID = Convert.ToInt32(dgvr.Cells["ministerID"].Value);
            bool success = dh.editMinister(ministerID, txtFN.Text, txtMI.Text, txtLN.Text, txtSuffix.Text,
                dtpBirthdate.Value, (MinistryType)(cmbMinistryType.SelectedItem),
                (MinisterStatus)(cmbStatus.SelectedItem));
            if (success)
                Notification.Show(State.MinisterEditSuccess);
            else
                Notification.Show(State.MinisterEditFail);
        }



        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinisterForm_Load(object sender, EventArgs e)
        {

        }

        private void controlBar_panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
