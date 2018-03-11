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
    public partial class CertificatePurpose : Form
    {
        public string purpose { get { return txtPurpose.Text; } }
        public CertificatePurpose()
        {
            InitializeComponent();
            Draggable drag = new Draggable(this);
            drag.makeDraggable(this);
            drag.makeDraggable(metroLabel1);
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
