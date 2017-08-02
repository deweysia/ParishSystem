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
    public partial class MarriageForm : Form
    {
        DataHandler dh;
        DataGridViewCellCollection row;
        public MarriageForm(DataGridViewRow dgvr, DataHandler dh)
        {
            InitializeComponent();

            this.dh = dh;
            this.row = dgvr.Cells;
        }

        private void MarriageForm_Load(object sender, EventArgs e)
        {

        }
    }
}
