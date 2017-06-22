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
    public partial class tCRB : Form
    {
        public tCRB()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_panel.Visible = true;
            view_panel.Visible = false;
        }

        private void view_btn_Click(object sender, EventArgs e)
        {
            add_panel.Visible = false;
            view_panel.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
