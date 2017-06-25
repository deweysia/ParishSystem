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
  
    public partial class sApplicant : Form
    {
        DataHandler dh = new DataHandler();
        public sApplicant()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form father = new sParent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form mother = new sParent();
        }

        private void sApplicant_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Form a = new sBaptism(/*max + 1 gen profile*/);
            a.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form a = new sConifirmation();
            a.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form a = new sMarriage();
            a.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dh.addGeneralProfile(firstname_textbox.Text, middlename_textbox.Text, lastname_textbox.Text, suffix_textbox.Text, null, DateTime.MinValue)) { }
            else { MessageBox.Show("Returned False", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
    }
}
