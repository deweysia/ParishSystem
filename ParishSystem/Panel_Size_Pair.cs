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
    class Panel_Size_Pair
    {
        public int OpenSize { get; set; }
        public int CloseSize { get; set; }
        public Panel panel { get; set; }
        public bool open { get; set; }
        public Panel_Size_Pair(int openSize, int closeSize, Panel p,bool o)
        {
            this.OpenSize = openSize;
            this.CloseSize = closeSize;
            this.panel = p;
            this.open = o;
        }
    }
}
