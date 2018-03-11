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
        private int sacramentID;
        public SacramentModule()
        {
            InitializeComponent();
            dgvBaptism.AutoGenerateColumns = false;
            dgvConfirmation.AutoGenerateColumns = false;
            dgvMarriage.AutoGenerateColumns = false;
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


            this.sacramentID = Convert.ToInt32(dgvBaptism.SelectedRows[0].Cells["baptismID"].Value);
            this.profileID = Convert.ToInt32(dgvBaptism.SelectedRows[0].Cells["bapProfileID"].Value);
            this.applicationID = Convert.ToInt32(dgvBaptism.SelectedRows[0].Cells["bapApplicationID"].Value);

            DataTable dt = ((BindingSource)dgv.DataSource).DataSource as DataTable;

            string fn = dgvBaptism.SelectedRows[0].Cells["bapFirstName"].Value.ToString();
            string mn = dgvBaptism.SelectedRows[0].Cells["bapMI"].Value.ToString();
            string ln = dgvBaptism.SelectedRows[0].Cells["bapLastName"].Value.ToString();
            string suffix = dgvBaptism.SelectedRows[0].Cells["bapSuffix"].Value.ToString();
            lblNameBap.Text = string.Format("{0} {1} {2} {3}", fn, mn, ln, suffix);


            int pageIndex = dgvBaptism.SelectedRows[0].Cells.Count - 3;
            btnAddReferencesBap.Enabled = string.IsNullOrWhiteSpace(dgvBaptism.SelectedRows[0].Cells[pageIndex].Value.ToString());
            //MessageBox.Show("add ref enabled " + btnAddReferencesBap.Enabled);

            tlpProfileBap.Enabled = true;


        }

        private void dgvConfirmation_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (!dgv.Focused || dgv.SelectedRows.Count == 0)
                return;

            this.sacramentID = Convert.ToInt32(dgvConfirmation.SelectedRows[0].Cells["confirmationID"].Value);
            this.profileID = Convert.ToInt32(dgvConfirmation.SelectedRows[0].Cells["conProfileID"].Value);
            this.applicationID = Convert.ToInt32(dgvConfirmation.SelectedRows[0].Cells["conApplicationID"].Value);

            DataTable dt = ((BindingSource)dgv.DataSource).DataSource as DataTable;

            string fn = dgvConfirmation.SelectedRows[0].Cells["conFirstName"].Value.ToString();
            string mn = dgvConfirmation.SelectedRows[0].Cells["conMI"].Value.ToString();
            string ln = dgvConfirmation.SelectedRows[0].Cells["conLastName"].Value.ToString();
            string suffix = dgvConfirmation.SelectedRows[0].Cells["conSuffix"].Value.ToString();
            lblNameCon.Text = string.Format("{0} {1} {2} {3}", fn, mn, ln, suffix);

            int pageIndex = dgvConfirmation.SelectedRows[0].Cells.Count - 3;
            btnAddReferencesCon.Enabled = string.IsNullOrWhiteSpace(dgvConfirmation.SelectedRows[0].Cells[pageIndex].Value.ToString());
            //MessageBox.Show("add ref enabled " + btnAddReferencesCon.Enabled);

            tlpProfileCon.Enabled = true;
        }

        private void dgvMarriage_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (!dgv.Focused || dgv.SelectedRows.Count == 0)
                return;

            this.sacramentID = Convert.ToInt32(dgvMarriage.SelectedRows[0].Cells["marriageID"].Value);
            this.applicationID = Convert.ToInt32(dgvMarriage.SelectedRows[0].Cells["marApplicationID"].Value);
            this.groomID = Convert.ToInt32(dgvMarriage.SelectedRows[0].Cells["marGroomID"].Value);
            this.brideID = Convert.ToInt32(dgvMarriage.SelectedRows[0].Cells["marBrideID"].Value);
            //MessageBox.Show(groomID + " " + brideID);

            DataTable dt = ((BindingSource)dgv.DataSource).DataSource as DataTable;

            //MessageBox.Show(string.Format("{0} - {1} - {2}", dgvMarriage.SelectedRows[0].Cells["marRegistryNumber"].Value.ToString(), dgvMarriage.SelectedRows[0].Cells["marPageNumber"].Value.ToString(), dgvMarriage.SelectedRows[0].Cells["marRecordNumber"].Value.ToString()));
            string groomName = dgvMarriage.SelectedRows[0].Cells["groomName"].Value.ToString();
            string brideName = dgvMarriage.SelectedRows[0].Cells["brideName"].Value.ToString();
            lblNameGroom.Text = groomName;
            lblNameBride.Text = brideName;

            int pageIndex = dgvMarriage.SelectedRows[0].Cells.Count - 3;
            btnAddReferencesMar.Enabled = string.IsNullOrWhiteSpace(dgvMarriage.SelectedRows[0].Cells[pageIndex].Value.ToString());
            //MessageBox.Show("add ref enabled " + btnAddReferencesMar.Enabled);

            tlpProfileMar.Enabled = true;
        }

        private void dgvBaptism_DataSourceChanged(object sender, EventArgs e)
        {
            dgvBaptism.ClearSelection();
        }

        private void btnResetBap_Click(object sender, EventArgs e)
        {
            resetDGV(SacramentType.Baptism);
        }

        private void resetDGV(SacramentType t)
        {
            DataGridView dgv = getDGV(t);
            DataTable dt = ((BindingSource)dgv.DataSource).DataSource as DataTable;
            dt.DefaultView.RowFilter = "";
        }


        private void openAddReferences(SacramentType t)
        {
            AddReferences f;
            if(t == SacramentType.Baptism)
            {
                f = new AddReferences(t, this.sacramentID, lblNameBap.Text);
            }else if (t == SacramentType.Confirmation)
            {
                f = new AddReferences(t, this.sacramentID,lblNameCon.Text);
            }
            else
            {
                f = new AddReferences(t, this.sacramentID, lblNameGroom.Text, lblNameBride.Text);
            }

            DialogResult r = f.ShowDialog();
            if(r == DialogResult.OK)
            {
                dh.editApplication(this.applicationID, ApplicationStatus.Final);
                loadSacrament(t);
            }
        }

        private void btnAddReferencesBap_Click(object sender, EventArgs e)
        {
            openAddReferences(SacramentType.Baptism);
        }

        private void btnAddReferencesCon_Click(object sender, EventArgs e)
        {
            openAddReferences(SacramentType.Confirmation);
        }

        private void btnAddReferencesMar_Click(object sender, EventArgs e)
        {
            openAddReferences(SacramentType.Marriage);
        }

        private void dgvBaptism_VisibleChanged(object sender, EventArgs e)
        {
            loadSacrament(SacramentType.Baptism);
        }
        private void dgvConfirmation_VisibleChanged(object sender, EventArgs e)
        {
            loadSacrament(SacramentType.Confirmation);
        }

        private void dgvMarriage_VisibleChanged(object sender, EventArgs e)
        {
            loadSacrament(SacramentType.Marriage);
        }

        private void loadSacrament(SacramentType t)
        {
            DataGridView dgv;
            GetSacrament gs;
            TableLayoutPanel tlp;
            if (t == SacramentType.Baptism)
            {
                gs = dh.getBaptisms;
                dgv = dgvBaptism;
                tlp = tlpProfileBap;
            }else if (t == SacramentType.Confirmation)
            {
                gs = dh.getConfirmations;
                dgv = dgvConfirmation;
                tlp = tlpProfileCon;
            }
            else
            {
                gs = dh.getMarriages;
                dgv = dgvMarriage;
                tlp = tlpProfileMar;
                
            }
            try
            {
                bsSacrament.DataSource = gs();
                dgv.DataSource = bsSacrament;
            }
            catch (Exception e) { /* Causes an error when closing*/}

            clearAndDisable(t);
        }

        private void clearAndDisable(SacramentType t)
        {
            TableLayoutPanel tlp;
            DataGridView dgv;
            if(t == SacramentType.Baptism)
            {
                tlp = tlpProfileBap;
                dgv = dgvBaptism;
                lblNameBap.Text = "";
            }
            else if(t == SacramentType.Confirmation)
            {
                tlp = tlpProfileCon;
                dgv = dgvConfirmation;
                lblNameCon.Text = "";
            }
            else
            {
                tlp = tlpProfileMar;
                dgv = dgvMarriage;
                lblNameBride.Text = "";
                lblNameGroom.Text = "";
            }

            tlp.Enabled = false;
            dgv.ClearSelection();
        }

        private GetSacrament getSacrament(SacramentType t)
        {
            GetSacrament s;
            if (t == SacramentType.Baptism)
                s = dh.getBaptisms;
            else if (t == SacramentType.Confirmation)
                s = dh.getConfirmations;
            else
                s = dh.getMarriages;

            return s;
        }

        private DataGridView getDGV(SacramentType t)
        {
            if (t == SacramentType.Baptism)
                return dgvBaptism;
            else if (t == SacramentType.Confirmation)
                return dgvConfirmation;
            else
                return dgvMarriage;
        }

        private void openPersonView(int profileID)
        {
            PersonView pv = new PersonView(profileID,dh);
            pv.ShowDialog();
        }

        private void openAdvanceSearch(SacramentType t)
        {

            using (AdvanceSearch s = new AdvanceSearch(t))
            {
                DialogResult dr = s.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    DataGridView dgv = getDGV(t);
                    DataTable dt = ((BindingSource)dgv.DataSource).DataSource as DataTable;
                    
                    dt.DefaultView.RowFilter = s.filter;
                    clearAndDisable(t);
                }
            }
        }

        private void btnOpenProfileBap_Click(object sender, EventArgs e)
        {
            openPersonView(this.profileID);
        }

        private void btnOpenProfileConf_Click(object sender, EventArgs e)
        {
            openPersonView(this.profileID);
        }

        private void btnSearchCon_Click(object sender, EventArgs e)
        {
            searchDVG(SacramentType.Confirmation);
        }

        private void btnSearchMar_Click(object sender, EventArgs e)
        {
            searchDVG(SacramentType.Marriage);
        }

        private void btnResetCon_Click(object sender, EventArgs e)
        {
            resetDGV(SacramentType.Confirmation);
        }

        private void btnResetMar_Click(object sender, EventArgs e)
        {
            resetDGV(SacramentType.Marriage);
        }

        private void txtSearchBap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                searchDVG(SacramentType.Baptism);
        }

        private void txtSearchCon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                searchDVG(SacramentType.Confirmation);
        }

        private void txtSearchMar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                searchDVG(SacramentType.Marriage);
        }

        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            openAdvanceSearch(SacramentType.Baptism);
            
        }

        private void btnOpenGroomProfile_Click(object sender, EventArgs e)
        {
            openPersonView(this.groomID);
        }

        private void btnOpenBrideProfile_Click(object sender, EventArgs e)
        {
            openPersonView(this.brideID);
        }

        private void btnAdvanceSearchCon_Click(object sender, EventArgs e)
        {
            openAdvanceSearch(SacramentType.Confirmation);
        }

        private void btnAdvanceSearchMar_Click(object sender, EventArgs e)
        {
            openAdvanceSearch(SacramentType.Marriage);
        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnEditBap_Click(object sender, EventArgs e)
        {
            

            DataGridViewRow dgvr = dgvBaptism.SelectedRows[0];
            DataRow dr = ((DataRowView)dgvr.DataBoundItem).Row;
            editSacrament(SacramentType.Baptism, dr);
            
        }

        private void editSacrament(SacramentType sacrament, DataRow dr)
        {
            User user = User.getCurrentUser();
            if(user.userPrivilegeLevel == UserPrivileges.Supervisor)
            if (AdminCredentialDialog.Show() != DialogResult.Yes)
                return;

            SacramentForm f = new SacramentForm(OperationType.Edit, sacrament, dr);
            DialogResult result = f.ShowDialog();

            if (result == DialogResult.OK)
            {
                Notification.Show(State.SacramentEditSuccess);
            }
            else if (result != DialogResult.Cancel)
            {
                Notification.Show(State.SacramentEditFail);
            }

            loadSacrament(sacrament);
        }
        private void btnEditCon_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvr = dgvConfirmation.SelectedRows[0];
            DataRow dr = ((DataRowView)dgvr.DataBoundItem).Row;
            editSacrament(SacramentType.Confirmation, dr);
        }

        private void btnEditMar_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvr = dgvMarriage.SelectedRows[0];
            DataRow dr = ((DataRowView)dgvr.DataBoundItem).Row;
            
            MarriageForm f = new MarriageForm(OperationType.Edit, dr);

            DialogResult result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                Notification.Show(State.SacramentEditSuccess);
            }
            else if (result != DialogResult.Cancel)
            {
                Notification.Show(State.SacramentEditFail);
            }

            loadSacrament(SacramentType.Marriage);
        }

        private void btnSearchBap_Click(object sender, EventArgs e)
        {
            searchDVG(SacramentType.Baptism);
        }

        private void searchDVG(SacramentType t)
        {
            DataGridView dgv = getDGV(t);
            DataTable dt;
            string filter = "";
            if (t == SacramentType.Baptism)
            {
                dt = ((BindingSource)dgvBaptism.DataSource).DataSource as DataTable;
                filter = string.Format("firstName LIKE '%{0}%' OR midName LIKE '%{0}%' OR lastName LIKE '%{0}%' OR suffix LIKE '%{0}%'", txtSearchBap.Text);
            }
            else if (t == SacramentType.Confirmation)
            {
                dt = ((BindingSource)dgvConfirmation.DataSource).DataSource as DataTable;
                filter = string.Format("firstName LIKE '%{0}%' OR midName LIKE '%{0}%' OR lastName LIKE '%{0}%' OR suffix LIKE '%{0}%'", txtSearchCon.Text);
            }
            else
            {
                dt = ((BindingSource)dgvMarriage.DataSource).DataSource as DataTable;
                filter = string.Format("groomName LIKE '%{0}%' OR brideName LIKE '%{0}%'", txtSearchMar.Text);
            }
            
            dt.DefaultView.RowFilter = filter;
            clearAndDisable(t);
        }
    }
}
