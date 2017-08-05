using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParishSystem
{
    public partial class CDemo : Component
    {
        private List<Control> con;
        public CDemo()
        {
            InitializeComponent();
            con = new List<Control>();

        }

        public List<Control> TargetControls
        {
            get
            {
                return con;
            }

            set
            {
                con = value;
            }
        }

        public CDemo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        int num = 0;
        public int n
        {
            get
            {
                return num;
            }

            set
            {
                num = value;
            }
        }

        

        

    }
}
