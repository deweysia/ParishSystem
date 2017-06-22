using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAD3
{
    public partial class sTransaction : Form
    {
        public sTransaction()
        {
            InitializeComponent();
        }

        private void sadTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void sTransaction_Load(object sender, EventArgs e)
        {
            topBarControl1.currentform = this;
        }
    }
}
