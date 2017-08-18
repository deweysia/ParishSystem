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
        DataHandler dh = DataHandler.getDataHandler();
        private int profileID, groomID, brideID;
        private int applicationID;
        public SacramentModule(DataHandler dh)
        {
            InitializeComponent();
            this.dh = dh;
            dgvBaptism.AutoGenerateColumns = false;
        }

        private void SacramentModule_Load(object sender, EventArgs e)
        {
            
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


        private void openAddReferences(SacramentType t)
        {
            AddReferences f;
            if(t == SacramentType.Baptism)
            {
                f = new AddReferences(t, lblNameBap.Text);
            }else if (t == SacramentType.Confirmation)
            {
                f = new AddReferences(t, lblNameCon.Text);
            }
            else
            {
                f = new AddReferences(t, lblNameGroom.Text, lblNameBride.Text);
            }

            f.ShowDialog();

        }
        private void btnAddReferencesBap_Click(object sender, EventArgs e)
        {
            openAddReferences(SacramentType.Baptism);
        }

        private void dgvBaptism_VisibleChanged(object sender, EventArgs e)
        {

        }
        
        private void loadSacrament(SacramentType t)
        {
            DataGridView dgv = getDGV(t);
            if(t == SacramentType.Baptism)
            {
                bsSacrament.DataSource = dh.getBaptisms();
                dgvBaptism.DataSource = bsSacrament;
                dgvBaptism.ClearSelection();
            }
        }

        //private GetSacrament getSacrament(SacramentType t)
        //{
        //    GetSacrament s;
        //    if (t == SacramentType.Baptism)
        //        s = dh.getBaptisms;
        //    else if (t == SacramentType.Confirmation)
        //        s = dh.getConfirmations;
        //    else
        //        s = dh.getMarriage
        //}

        private DataGridView getDGV(SacramentType t)
        {
            if (t == SacramentType.Baptism)
                return dgvBaptism;
            else if (t == SacramentType.Confirmation)
                return dgvConfirmation;
            else
                return dgvMarriage;
        }

        private void btnOpenProfileBap_Click(object sender, EventArgs e)
        {
            Form f = new PersonView(profileID, dh);
            f.ShowDialog();
        }

        private void dgvBaptism_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            openAddReferences(SacramentType.Confirmation);
        }

        private void btnSearchBap_Click(object sender, EventArgs e)
        {
            openAddReferences(SacramentType.Marriage);
        }
    }
}
