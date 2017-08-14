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
    public partial class Sacraments : Form
    {
        DataHandler dh;
        public Sacraments()
        {
            InitializeComponent();
            //this.dh = dh;
            
            
            this.TopLevel = false;

            dgvBaptism.AutoGenerateColumns = false;

            
        }

        private void Sacraments_Load(object sender, EventArgs e)
        {
            //bsSacrament.DataSource = dh.getBaptisms();
            //dgvBaptism.DataSource = bsSacrament;
        }

        private void baptismApplication_dgv_VisibleChanged(object sender, EventArgs e)
        {
            

            

        }
    }
}
