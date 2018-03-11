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
    public partial class AuditModule : Form
    {
        private DataHandler dh = DataHandler.getDataHandler();
        private string searchString = "";
        private string sourceSearchString = "";
        private string dateSearchString = "";
        private string userSearchString = "";

        public AuditModule()
        {
            InitializeComponent();
            dgvAudit.AutoGenerateColumns = false;
            loadAuditTypes();
        }

        private void loadAuditTypes()
        {
            DataTable dt = dh.getAuditTypes();
            cmbFilter.Items.Add("All Sources");
            foreach (DataRow row in dt.Rows)
            {
                cmbFilter.Items.Add(row["tableName"].ToString());
            }

            cmbFilter.SelectedIndex = 0;
        }

        private void dgvBaptism_VisibleChanged(object sender, EventArgs e)
        {
            DataTable dt = dh.getAuditLogs();
            dgvAudit.DataSource = dt;
        }

        

        private void dgvAudit_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == 3)
            {
                switch (e.Value.ToString())
                {
                    case "1":
                        e.Value = "Add";
                        break;
                    case "2":
                        e.Value = "Update";
                        break;
                    default:
                        e.Value = "Delete";
                        break;
                }
            }
        }

        private string getSearchString()
        {
            string search = dateSearchString;
            if (search.Length != 0 && sourceSearchString.Length != 0)
                search += " AND ";
            search += sourceSearchString;

            if (search.Length != 0 && userSearchString.Length != 0)
                search += " AND ";
            search += userSearchString;

            return search;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = dgvAudit.DataSource as DataTable;
            dateSearchString = string.Format("auditDate >= #{0}# AND auditDate <= #{1}#", dtpFrom.Value.ToString("yyyy-MM-dd"), dtpTo.Value.ToString("yyyy-MM-dd"));
            userSearchString = string.Format("username LIKE '%{0}%'", txtUser.Text.Trim());
            dt.DefaultView.RowFilter = getSearchString();


        }

        private void reset_Click(object sender, EventArgs e)
        {
            DataTable dt = dgvAudit.DataSource as DataTable;
            sourceSearchString = "";
            userSearchString = "";
            dateSearchString = "";


            dtpFrom.Value = DateTime.Today.Date;
            dtpTo.Value = DateTime.Today.Date;

            txtUser.Text = "";

            dt.DefaultView.RowFilter = "";
            cmbFilter.SelectedIndex = 0;
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
                dtpTo.Value = dtpFrom.Value.Date;
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
                dtpFrom.Value = dtpTo.Value.Date;
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cmbFilter.SelectedItem.ToString());
            DataTable dt = dgvAudit.DataSource as DataTable;
            if (cmbFilter.SelectedIndex == 0)
                sourceSearchString = "";
            else
                sourceSearchString = string.Format("tableName = '{0}'", cmbFilter.SelectedItem.ToString());
            dt.DefaultView.RowFilter = getSearchString();
        }
    }
}
