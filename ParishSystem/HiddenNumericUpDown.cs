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
    public partial class HiddenNumericUpDown : NumericUpDown
    {
        public HiddenNumericUpDown()
        {
            Controls[0].Visible = false;
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(SystemColors.Window);
            base.OnPaint(e);
        }
    }
}
