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
    public partial class tCDB : Form
    {
        public tCDB()
        {
            InitializeComponent();
        }

        private void tCDB_Load(object sender, EventArgs e)
        {

















        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            

            while (panel14.Controls.Count > 0)
            {
                panel14.Controls[0].Dispose();
            }
            

            Form1 f = new Form1();
            f.FormBorderStyle = FormBorderStyle.None;
            f.TopLevel = false;
            f.AutoScroll = true;
            panel14.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.Show();
        }
    }
}
