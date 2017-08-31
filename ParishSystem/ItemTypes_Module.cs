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
        int cashreceipt_cashdisbursment;

        public ItemTypes_Module(int cashreceipt_cashdisbursment)
        {
            InitializeComponent();
            this.cashreceipt_cashdisbursment = cashreceipt_cashdisbursment;
           
        }
        
        private void refreshItemTypes()
        {          
                itemType_dgv.DataSource = dh.getIncomeTypes(cashreceipt_cashdisbursment);
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
        private void itemType_dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
                Form A = new ItemType(int.Parse(itemType_dgv.SelectedRows[0].Cells["itemTypeID"].Value.ToString()), cashreceipt_cashdisbursment, dh);
                A.ShowDialog();
                refreshItemTypes();
        }
        private void add_button_itemType_Click(object sender, EventArgs e)
        {
                Form A = new ItemType(cashreceipt_cashdisbursment, dh);
                A.ShowDialog();
                refreshItemTypes();           
        }
        private void disable_button_itemType_Click(object sender, EventArgs e)
        {
                dh.disableIncomeType(int.Parse(itemType_dgv.SelectedRows[0].Cells["itemTypeID"].Value.ToString()), cashreceipt_cashdisbursment);
                refreshItemTypes();        
        }
        private void enable_button_itemType_Click(object sender, EventArgs e)
        {
                dh.enableIncomeType(int.Parse(itemType_dgv.SelectedRows[0].Cells["itemTypeID"].Value.ToString()), cashreceipt_cashdisbursment);
                refreshItemTypes();
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

        private void itemType_dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData== Keys.Enter)
            {
                Form A = new ItemType(int.Parse(itemType_dgv.SelectedRows[0].Cells["itemTypeID"].Value.ToString()), cashreceipt_cashdisbursment, dh);
                A.ShowDialog();
                refreshItemTypes();
            }
        }

        private void ItemTypes_Module_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Form A = new ItemType(int.Parse(itemType_dgv.SelectedRows[0].Cells["itemTypeID"].Value.ToString()), cashreceipt_cashdisbursment, dh);
                A.ShowDialog();
                refreshItemTypes();
            }
        }
    }
}
