using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAD3
{
    public partial class topBarControl : UserControl
    {
        public topBarControl()
        {
            InitializeComponent();
        }
        public Form currentform;

        private void btn_Close_Click(object sender, EventArgs e)
        {
            currentform.Close();
        }
    }
}
