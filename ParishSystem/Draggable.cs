using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace ParishSystem
{
    public class Draggable
    {
        Point lastClick;
        Control f;


        public Draggable(Form f)
        {
            this.f = f;
        }

        public void makeDraggable(Control MakeDraggable)
        {

            MakeDraggable.MouseMove += this.controlMouseMove;
            MakeDraggable.MouseDown += this.controlMouseDown;
        }

        private void controlMouseMove(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                f.Left += e.X - lastClick.X;
                f.Top += e.Y - lastClick.Y;
            }
        }

        private void controlMouseDown(object sender, MouseEventArgs e)
        {
            lastClick = new Point(e.X, e.Y);
        }
    }
}
