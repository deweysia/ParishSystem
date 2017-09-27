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
        public AuditModule()
        {
            InitializeComponent();
            dgvAudit.AutoGenerateColumns = false;
            
        }

        private void dgvBaptism_VisibleChanged(object sender, EventArgs e)
        {
            DataHandler dh = DataHandler.getDataHandler();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = dgvAudit.DataSource as DataTable;
            dt.DefaultView.RowFilter = string.Format("auditDate >= #{0}# AND auditDate <= #{1}#", dtpFrom.Value.ToString("yyyy-MM-dd"), dtpTo.Value.ToString("yyyy-MM-dd"));

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = dgvAudit.DataSource as DataTable;
            dt.DefaultView.RowFilter = "";
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
    }
}
