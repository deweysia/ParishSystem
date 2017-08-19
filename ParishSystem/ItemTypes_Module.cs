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
    public partial class ItemTypes_Module : Form
    {
        treasurerBackend dh = new treasurerBackend();
        int selectedIncome = 0;
        int Mode;

        public ItemTypes_Module(int Mode)
        {
            InitializeComponent();
            this.Mode = Mode;
        }
        
        private void refreshItemTypes()
        {
            if (Mode == 1)
            {
                itemType_dgv.DataSource = dh.getIncomeTypes();
                itemType_dgv.Columns["itemTypeID"].Visible = false;
                itemType_dgv.Columns["itemType"].HeaderText = "Item Type";
                try
                {
                    itemType_dgv.Rows[selectedIncome].Selected = true;
                }
                catch
                {

                }
            }
            else
            {
                itemType_dgv.DataSource = dh.getCashReleaseTypes();
                itemType_dgv.Columns["cashReleaseTypeID"].Visible = false;
                itemType_dgv.Columns["cashReleaseType"].HeaderText = "Cash Release Type";
                itemType_dgv.Columns["description"].HeaderText = "Description";
                itemType_dgv.Columns["booktype"].HeaderText = "Book Type";
                itemType_dgv.Columns["status"].HeaderText = "Status";
                try
                {
                    itemType_dgv.Rows[selectedIncome].Selected = true;
                }
                catch { }
            }
        }
        private void itemType_dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Mode == 1)
            {
                Form A = new IncomeType(int.Parse(itemType_dgv.SelectedRows[0].Cells["itemTypeID"].Value.ToString()), dh);
                A.ShowDialog();
                refreshItemTypes();
            }
            else
            {
                Form A = new CashReleaseType(int.Parse(itemType_dgv.SelectedRows[0].Cells["cashReleaseTypeID"].Value.ToString()), dh);
                A.ShowDialog();
                refreshItemTypes();
            }
        }
        private void add_button_itemType_Click(object sender, EventArgs e)
        {
            if (Mode == 1)
            {
                Form A = new IncomeType(dh);
                A.ShowDialog();
                refreshItemTypes();
            }
            else
            {
                Form A = new CashReleaseType(dh);
                A.ShowDialog();
                refreshItemTypes();
            }
        }
        private void disable_button_itemType_Click(object sender, EventArgs e)
        {
            if (Mode == 1)
            {
                dh.disableIncomeType(int.Parse(itemType_dgv.SelectedRows[0].Cells["itemTypeID"].Value.ToString()));
                refreshItemTypes();
            }
            else
            {
                dh.disableCashReleaseType(int.Parse(itemType_dgv.SelectedRows[0].Cells["cashReleaseTypeID"].Value.ToString()));
                refreshItemTypes();
            }
        }
        private void enable_button_itemType_Click(object sender, EventArgs e)
        {
            if (Mode == 1)
            {
                dh.enableIncomeType(int.Parse(itemType_dgv.SelectedRows[0].Cells["itemTypeID"].Value.ToString()));
                refreshItemTypes();
            }
            else
            {
                dh.enableCashReleaseType(int.Parse(itemType_dgv.SelectedRows[0].Cells["cashReleaseTypeID"].Value.ToString()));
                refreshItemTypes();
            }
        }
        private void itemType_dgv_Click(object sender, EventArgs e)
        {
            try
            { 
            selectedIncome = itemType_dgv.SelectedRows[0].Index;
            }
            catch { }
        }

        private void ItemTypes_Module_Load(object sender, EventArgs e)
        {
            refreshItemTypes();
        }
      
    }
}
