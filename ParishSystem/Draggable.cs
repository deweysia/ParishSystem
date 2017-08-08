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
    public partial class Draggable : Component
    {
        public Draggable()
        {
            InitializeComponent();
            TargetControls = new List<Control>();

        }

        public List<Control> TargetControls 
        {
            get; set;
        }


        public Draggable(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
