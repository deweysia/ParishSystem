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
    public partial class ConfirmationForm : Form
    {

        DataHandler dh;
        DataGridViewCellCollection row;
        public ConfirmationForm(DataGridViewRow dgvr, DataHandler dh)
        {
            InitializeComponent();
            this.dh = dh;
            this.row = dgvr.Cells;
        }

        private void ConfirmationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
