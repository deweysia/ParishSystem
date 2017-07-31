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
    public partial class ExButton : Button
    {
        public ExButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.Delete_32px_Light;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.Delete_32px;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.Delete_32px_Gray;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
