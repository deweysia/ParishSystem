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

        DataHandler dh = new DataHandler("localhost", "sad2", "root", "root");

        public MinisterForm()
        {
            InitializeComponent();

            Draggable drag = new Draggable(this);
            drag.makeDraggable(controlBar_panel);

            birthDate_dtp.Value = DateTime.Now;
            birthDate_dtp.MaxDate = DateTime.Now;
        }

 
        private void licenseNum_textBox_TextChanged(object sender, EventArgs e)
        {
            addBtn.Enabled = !(string.IsNullOrWhiteSpace(txtFN.Text)
                || string.IsNullOrWhiteSpace(txtMI.Text)
                || string.IsNullOrWhiteSpace(lastName_textBox.Text)
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            bool success = dh.addMinister(txtFN.Text, txtMI.Text, lastName_textBox.Text, suffix_textBox.Text,
                birthDate_dtp.Value, (MinistryType)(ministryType_cBox.SelectedIndex + 1),
                (MinisterStatus)(status_cBox.SelectedIndex + 1);
            if (success)
                Notification.Show(State.MinisterAddSuccess);
            else
                Notification.Show(State.MinisterAddFail);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
