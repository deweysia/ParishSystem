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
    public partial class Home : Form
    {
        DataHandler dh;

        public Home() {
            InitializeComponent();
        } //temp

        public Home(DataHandler dh)
        {
            InitializeComponent();
            this.dh = dh;
      
        }

        private void Home_Load(object sender, EventArgs e)
        {
            this.username_label.Text = "username";

        }
    }
}
