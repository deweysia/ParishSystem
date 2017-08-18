using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace ParishSystem
{
    class Draggable
    {
        Point lastClick;
        Control f;


        private Draggable(Form f)
        {
            this.f = f;
        }

        public void makeDraggable(Form ContainingForm, Control MakeDraggable)
        {

            MakeDraggable.MouseMove += this.controlMouseMove;
            MakeDraggable.MouseDown += this.controlMouseDown;
        }

        private void controlMouseMove(object sender, MouseEventArgs e)
        {
            
            //if (!(sender is Control))
            //    return;

            //Control c = sender as Control;
            //c.MouseMove += this.controlMouseDown;

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
