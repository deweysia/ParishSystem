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
            birthDate_dtp.Value = DateTime.Now;
            birthDate_dtp.MaxDate = DateTime.Now;
            expirationDate_dtp.Value = DateTime.Now;
            expirationDate_dtp.MinDate = DateTime.Now;
        }

        private void MinisterForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void firstName_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void licenseNum_textBox_TextChanged(object sender, EventArgs e)
        {
            addBtn.Enabled = !(string.IsNullOrWhiteSpace(firstName_textBox.Text)
                || string.IsNullOrWhiteSpace(mi_textBox.Text)
                || string.IsNullOrWhiteSpace(lastName_textBox.Text)
                || string.IsNullOrWhiteSpace(licenseNum_textBox.Text));
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            bool success = dh.addMinister(firstName_textBox.Text, mi_textBox.Text, lastName_textBox.Text, suffix_textBox.Text, 
                birthDate_dtp.Value, (MinistryType) (ministryType_cBox.SelectedIndex + 1), 
                (MinisterStatus) (status_cBox.SelectedIndex + 1), 
                licenseNum_textBox.Text, expirationDate_dtp.Value);

            if (success)
                Notification.Show("Minister Added!", NotificationType.success);
            else
                Notification.Show("Something went wrong!", NotificationType.error);
        }
    }
}
