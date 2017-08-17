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
    public partial class SacramentModule : Form
    {
        DataHandler dh = new DataHandler("localhost", "sad2", "root", "root");
        public SacramentModule(DataHandler dh)
        {
            InitializeComponent();
            this.dh = dh;
            dgvBaptism.AutoGenerateColumns = false;
        }

        private void Sacrament_Load(object sender, EventArgs e)
        {
            bsSacrament.DataSource = dh.getBaptisms();
            dgvBaptism.DataSource = bsSacrament;
            dgvBaptism.ClearSelection();
        }

        private void dgvBaptism_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (!dgv.Focused || dgv.SelectedRows.Count == 0)
                return;

            
        }

        private void dgvBaptism_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (!dgv.Focused || dgv.SelectedRows.Count == 0)
                return;

            string fn = dgvBaptism.SelectedRows[0].Cells["bapFirstName"].Value.ToString();
            string mn = dgvBaptism.SelectedRows[0].Cells["bapMI"].Value.ToString();
            string ln = dgvBaptism.SelectedRows[0].Cells["bapLastName"].Value.ToString();
            string suffix = dgvBaptism.SelectedRows[0].Cells["bapSuffix"].Value.ToString();
            lblNameBap.Text = string.Format("{0} {1} {2} {3}", fn, mn, ln, suffix);
        }

        private void dgvBaptism_DataSourceChanged(object sender, EventArgs e)
        {
            dgvBaptism.ClearSelection();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(metroTabControl1.SelectedIndex == 0)
            {
                bsSacrament.DataSource = dh.getBaptisms();
            }else if(metroTabControl1.SelectedIndex == 1)
            {
                bsSacrament.DataSource = dh.getConfirmations();
            }
            else
            {
                //bsSacrament.DataSource = dh.getMarriage();
            }
        }

        private void btnResetBap_Click(object sender, EventArgs e)
        {

        }

        private void btnAddReferencesBap_Click(object sender, EventArgs e)
        {

        }
    }
}
