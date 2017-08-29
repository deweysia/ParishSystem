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
            string registry = string.IsNullOrWhiteSpace(txtRegistry.Text) ? "" : txtRegistry.Text.Trim();
            string page = string.IsNullOrWhiteSpace(txtPage.Text) ? "" : txtPage.Text.Trim();
            string record = string.IsNullOrWhiteSpace(txtRecord.Text) ? "" : txtRecord.Text.Trim();

            if (t == SacramentType.Marriage)
            {
                this.filter = string.Format(@"(groomName LIKE '%{0}%' OR brideName LIKE '%{0}%') 
                                                AND registryNumber LIKE '%{1}%' AND pageNumber LIKE '%{2}%' 
                                                AND recordNumber LIKE '%{3}%' ", 
                                                name, registry, page, record);
            }else
            {
                MessageBox.Show(string.Format("{0}, {1}, {2}", registry, page, record));
                this.filter = string.Format(@"(firstName LIKE '%{0}%' OR midName LIKE '%{0}%' OR lastName LIKE '%{0}%' OR suffix LIKE '%{0}%') 
                                                AND registryNumber LIKE '%{1}%' AND pageNumber LIKE '%{2}%' 
                                                AND recordNumber LIKE '%{3}%' ", name, registry, page, record);
            }

            if(cmbMinister.SelectedIndex != -1)
            {
                ComboboxContent cc = cmbMinister.SelectedItem as ComboboxContent;
                string minister = string.Format("AND ministerID = '{0}'", cc.id);
                this.filter += minister;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
