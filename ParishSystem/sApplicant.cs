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
    public DataHandler dh;
       
        public sApplicant(DataHandler dh)
        {
            InitializeComponent();
            this.dh = dh;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Form a = new sBaptism();
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
           
        }
    }
}
