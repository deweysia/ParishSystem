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
    public partial class MinisterModule : Form
    {
        DataHandler dh = DataHandler.getDataHandler();
        public MinisterModule()
        {
            InitializeComponent();
            flpEditDeleteMinister.Enabled = false;
            dgvMinister.AutoGenerateColumns = false;
            
        }

        private void loadMinisters()
        {
            dgvMinister.DataSource = dh.getMinisters();
            dgvMinister.ClearSelection();
            flpEditDeleteMinister.Enabled = false;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form f = new MinisterForm();
            f.ShowDialog();
            loadMinisters();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvr = dgvMinister.SelectedRows[0];
            Form f = new MinisterForm(dgvr);
            f.ShowDialog();
            loadMinisters();
        }

        private void dgvMinister_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Control c = sender as Control;
            //if (!c.Focused)
            //    return;

            flpEditDeleteMinister.Enabled = true;
        }

        private void MinisterModule_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvMinister_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6)//Ministry Type
                e.Value = ((MinistryType)Convert.ToInt32(e.Value)).ToString();
            else if (e.ColumnIndex == 7)
            {
                e.Value = ((MinisterStatus)Convert.ToInt32(e.Value)).ToString();
            }
        }

        private void dgvMinister_VisibleChanged(object sender, EventArgs e)
        {
            loadMinisters();
        }
    }
}
