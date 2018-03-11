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
    public partial class AdvanceSearch : Form
    {
        public string filter = "";
        DataHandler dh = DataHandler.getDataHandler();
        SacramentType t;
        public AdvanceSearch(SacramentType t)
        {
            InitializeComponent();
            DataTable dt = dh.getMinisters();
            this.t = t;

            Draggable drag = new Draggable(this);
            drag.makeDraggable(panel2);

            foreach (DataRow dr in dt.Rows)
            {
                ComboboxContent cc = new ComboboxContent(int.Parse(dr["ministerID"].ToString()), dr["name"].ToString());
                cmbMinister.Items.Add(cc);
            }


        }

        private void AdvanceSearch_Load(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            

            if (t == SacramentType.Marriage)
            {
                this.filter = string.Format(@"(groomName LIKE '%{0}%' OR brideName LIKE '%{0}%') AND ", name);
                if (cbBetweenDates.Checked)
                    this.filter += string.Format("AND marriageDate >= '{0}' AND marriageDate <= '{1}'", dtpFrom.Value.ToString("yyyy-MM-dd"), dtpTo.Value.ToString("yyyy-MM-dd"));
            }
            else if(t == SacramentType.Baptism)
            {
                //MessageBox.Show(string.Format("{0}, {1}, {2}", registry, page, record));
                this.filter = string.Format(@"(firstName LIKE '%{0}%' OR midName LIKE '%{0}%' OR lastName LIKE '%{0}%' OR suffix LIKE '%{0}%') AND ", name);
                if (cbBetweenDates.Checked)
                    this.filter += string.Format("AND baptismDate >= '{0}' AND baptismDate <= '{1}'", dtpFrom.Value.ToString("yyyy-MM-dd"), dtpTo.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                this.filter = string.Format(@"(firstName LIKE '%{0}%' OR midName LIKE '%{0}%' OR lastName LIKE '%{0}%' OR suffix LIKE '%{0}%') AND ", name);
                if(cbBetweenDates.Checked)
                    this.filter += string.Format("AND confirmationDate >= '{0}' AND confirmationDate <= '{1}'", dtpFrom.Value.ToString("yyyy-MM-dd"), dtpTo.Value.ToString("yyyy-MM-dd"));
            }

            this.filter += getReferenceFilter();

            if(cmbMinister.SelectedIndex != -1)
            {
                ComboboxContent cc = cmbMinister.SelectedItem as ComboboxContent;
                string minister = string.Format("AND ministerID = '{0}'", cc.id);
                this.filter += minister;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private string getReferenceFilter()
        {
            string s;
            string registry = string.IsNullOrWhiteSpace(txtRegistry.Text) ? "" : txtRegistry.Text.Trim();
            string page = string.IsNullOrWhiteSpace(txtPage.Text) ? "" : txtPage.Text.Trim();
            string record = string.IsNullOrWhiteSpace(txtRecord.Text) ? "" : txtRecord.Text.Trim();
            if (cboxSearchWithoutRef.Checked)
                s = "NOT (Isnull(registryNumber,'') <> '' AND Isnull(pageNumber,'') <> '' AND Isnull(recordNumber,'') <> '')";
            else
                s = string.Format(@"registryNumber LIKE '%{0}%' OR pageNumber LIKE '%{1}%' OR recordNumber LIKE '%{2}%' ", registry, page, record);

            return s;
        }

        private void cbBetweenDates_CheckedChanged(object sender, EventArgs e)
        {
            tlpBetweenDates.Enabled = cbBetweenDates.Checked;
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
                dtpTo.Value = dtpFrom.Value;
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if(dtpFrom.Value.Date > dtpTo.Value.Date)
                dtpFrom.Value = dtpTo.Value;
        }

        private void txtRegistry_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbtnWithReference_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void tlpReference_EnabledChanged(object sender, EventArgs e)
        {
            if (!tlpReference.Enabled)
            {
                txtRegistry.Clear();
                txtPage.Clear();
                txtRecord.Clear();
            }
        }

        private void cboxSearchWithoutRef_CheckedChanged(object sender, EventArgs e)
        {
            tlpReference.Enabled = !cboxSearchWithoutRef.Checked;
        }
    }
}
