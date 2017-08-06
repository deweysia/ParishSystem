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
    public partial class Treasurer : Form
    {
        int selectedIncome = 0;
        DataHandler dh = new DataHandler("localhost", "sad2", "root", "root");

        public Treasurer()
        {
            InitializeComponent();
            suggestedPrice_nud_fullpay.Maximum = decimal.MaxValue;           
        }
       
        #region Income Type
        private void item_button_menu_Click(object sender, EventArgs e)
        {
            refreshItemTypes();
            IncomeCashReleaseType_panel.BringToFront();
        }
        private void refreshItemTypes()
        { 
            itemType_dgv.DataSource = dh.getIncomeTypes();
            itemType_dgv.Columns["itemTypeID"].Visible = false;
            itemType_dgv.Columns["itemType"].HeaderText = "Item Type";
            itemType_dgv.Rows[selectedIncome].Selected = true;
        }
        private void itemType_dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form A = new IncomeType(int.Parse(itemType_dgv.SelectedRows[0].Cells["itemTypeID"].Value.ToString()), dh);
            A.ShowDialog();
            refreshItemTypes();
        }
        private void add_button_itemType_Click(object sender, EventArgs e)
        {
            Form A = new IncomeType(dh);
            A.ShowDialog();
            refreshItemTypes();
        }
        private void disable_button_itemType_Click(object sender, EventArgs e)
        {
            dh.disableIncomeType(int.Parse(itemType_dgv.SelectedRows[0].Cells["itemTypeID"].Value.ToString()));
            refreshItemTypes();
        }
        private void enable_button_itemType_Click(object sender, EventArgs e)
        {
            dh.enableIncomeType(int.Parse(itemType_dgv.SelectedRows[0].Cells["itemTypeID"].Value.ToString()));
            refreshItemTypes();
        }
        private void itemType_dgv_Click(object sender, EventArgs e)
        {
            selectedIncome = itemType_dgv.SelectedRows[0].Index;
        }
        #endregion

        #region Cash Release Type


        int selectedCashRelease = 0;
        private void add_button_CashRelease_Click(object sender, EventArgs e)
        {
            Form A = new CashReleaseType(dh);
            A.ShowDialog();
            refreshCashReleaseTypes();
        }
        private void disable_button_CashRelease_Click(object sender, EventArgs e)
        {
            dh.disableCashReleaseType(int.Parse(cashRelease_dgv.SelectedRows[0].Cells["cashReleaseTypeID"].Value.ToString()));
            refreshCashReleaseTypes();
        }
        private void enable_button_CashRelease_Click(object sender, EventArgs e)
        {
            dh.enableCashReleaseType(int.Parse(cashRelease_dgv.SelectedRows[0].Cells["cashReleaseTypeID"].Value.ToString()));
            refreshCashReleaseTypes();
        }
        private void cashRelease_dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form A = new CashReleaseType(int.Parse(cashRelease_dgv.SelectedRows[0].Cells["cashReleaseTypeID"].Value.ToString()), dh);
            A.ShowDialog();
            refreshCashReleaseTypes();
        }
        private void refreshCashReleaseTypes()
        {
            cashRelease_dgv.DataSource = dh.getCashReleaseTypes();
            cashRelease_dgv.Columns["cashReleaseTypeID"].Visible = false;
            cashRelease_dgv.Columns["cashReleaseType"].HeaderText = "Cash Release Type";
            cashRelease_dgv.Rows[selectedCashRelease].Selected = true;
        }
        private void incomeType_label_Click(object sender, EventArgs e)
        {
            IncomeCashReleaseType_TabControl.SelectedTab = IncomeTypeTab;
            refreshItemTypes();
        }
        private void cashReleaseType_label_Click(object sender, EventArgs e)
        {
            IncomeCashReleaseType_TabControl.SelectedTab = CashReleaseTypeTab;
            refreshCashReleaseTypes();
        }
        private void cashRelease_dgv_Click(object sender, EventArgs e)
        {
            selectedCashRelease = cashRelease_dgv.SelectedRows[0].Index;
        }
        #endregion

        #region Full Pay
        int bookModeFullPay;
        private void fullpay_label_Click(object sender, EventArgs e)
        {
           //TabControl.SelectedTab = fullPayment_tab;
        }
        private void load_IncomePage()
        {//make generic 
            cancelTransaction_button_fullpay.PerformClick();
            itemType_combobox_fullpay.Items.Clear();
            itemType_combobox_fullpay.Items.Add("");
           
                orNumber_label_fullpay.Text = dh.getnextORof(bookModeFullPay).ToString();
                DataTable dt = dh.getIncomeTypesOf(bookModeFullPay);
                foreach (DataRow dr in dt.Rows)
                {
                    itemType_combobox_fullpay.Items.Add(new ComboboxContent(int.Parse(dr["itemTypeID"].ToString()), dr["itemType"].ToString(), dr["suggestedPrice"].ToString()));
                }
        }
        private void suggestedPrice_nud_fullpay_parish_ValueChanged(object sender, EventArgs e)
        {
            if (quantity_nud_fullpay.Value!=0 && itemType_combobox_fullpay.Text!="")
            {
                subTotal_label_fullpay.Text = (suggestedPrice_nud_fullpay.Value * quantity_nud_fullpay.Value).ToString();
            }
        }
        private void quantity_nud_fullpay_parish_ValueChanged(object sender, EventArgs e)
        {
            if (quantity_nud_fullpay.Value != 0 && itemType_combobox_fullpay.Text != "")
            {
                subTotal_label_fullpay.Text = (suggestedPrice_nud_fullpay.Value * quantity_nud_fullpay.Value).ToString();
            }
        }
        private void refreshTotalLabel()
        {
            decimal sum = 0;
            foreach (DataGridViewRow dr in item_dgv_fullpay.Rows)
            {
                sum += decimal.Parse(dr.Cells["TotalDataGridViewColumn"].Value.ToString());
            }
            total_label_fullpay.Text = sum.ToString();
        }
        private void add_button_fullpay_parish_Click(object sender, EventArgs e)
        {
            if (itemType_combobox_fullpay.Text!="" && quantity_nud_fullpay.Value!=0 ) {
                if ((string)add_button_fullpay.Tag == "a")
                {
                    int index = item_dgv_fullpay.Rows.Add();
                    item_dgv_fullpay.Rows[index].Cells[0].Value = itemType_combobox_fullpay.SelectedItem.ToString();
                    item_dgv_fullpay.Rows[index].Cells[1].Value = suggestedPrice_nud_fullpay.Value.ToString();
                    item_dgv_fullpay.Rows[index].Cells[2].Value = quantity_nud_fullpay.Value.ToString();
                    item_dgv_fullpay.Rows[index].Cells[3].Value = subTotal_label_fullpay.Text;
                    item_dgv_fullpay.Rows[index].Cells[4].Value = itemType_combobox_fullpay.SelectedIndex;//hidden
                }
                else
                {
                    item_dgv_fullpay.SelectedRows[0].Cells[0].Value = itemType_combobox_fullpay.SelectedItem.ToString();
                    item_dgv_fullpay.SelectedRows[0].Cells[1].Value = suggestedPrice_nud_fullpay.Value.ToString();
                    item_dgv_fullpay.SelectedRows[0].Cells[2].Value = quantity_nud_fullpay.Value.ToString();
                    item_dgv_fullpay.SelectedRows[0].Cells[3].Value = subTotal_label_fullpay.Text;
                    item_dgv_fullpay.SelectedRows[0].Cells[4].Value = itemType_combobox_fullpay.SelectedIndex;//hidden
                    delete_button_fullpay.Enabled = false;                  
                }
                clearIncomeTab();
                refreshTotalLabel();
            }
            else
            {
                MessageBox.Show("shunga");
            }
        }
        private void clearIncomeTab()
        {
            itemType_combobox_fullpay.SelectedIndex = 0;
            suggestedPrice_nud_fullpay.Value = 0;
            quantity_nud_fullpay.Value = 1;
            subTotal_label_fullpay.Text = "";
            remarks_textbox_fullpay.Text = "";
            add_button_fullpay.Text = "+";
            add_button_fullpay.Tag = "a";
        }
        private void cancel_button_fullpay_parish_Click(object sender, EventArgs e)
        {
            clearIncomeTab();
        }
        private void delete_button_fullpay_parish_Click(object sender, EventArgs e)
        {
            delete_button_fullpay.Enabled = false;
            item_dgv_fullpay.Rows.RemoveAt(item_dgv_fullpay.SelectedRows[0].Index);
            clearIncomeTab();
            refreshTotalLabel();
        }
        private void cancelTransaction_button_fullpay_parish_Click(object sender, EventArgs e)
        {
            clearIncomeTab();
            item_dgv_fullpay.Rows.Clear();
            sourceName_textbox_fullpay.Text = "";
            remarks_textbox_fullpay.Text = "";
            total_label_fullpay.Text = "";
            
        }
        private void parish_label_fullpay_Click(object sender, EventArgs e)
        {
            bookModeFullPay = (int)BookType.Parish;
            load_IncomePage();
        }
        private void community_label_fullpay_Click(object sender, EventArgs e)
        {
            bookModeFullPay = (int)BookType.Community;
            load_IncomePage();
        }
        private void postulancy_label_fullpay_Click(object sender, EventArgs e)
        {
            bookModeFullPay = (int)BookType.Postulancy;
            load_IncomePage();
        }
        private void CDB_button_menu_Click(object sender, EventArgs e)
        {
            CDB_parish_panel.BringToFront();
        } 
        private void item_dgv_fullpay_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            itemType_combobox_fullpay.SelectedIndex = int.Parse(item_dgv_fullpay.SelectedRows[0].Cells[4].Value.ToString());
            suggestedPrice_nud_fullpay.Value = decimal.Parse(item_dgv_fullpay.SelectedRows[0].Cells[1].Value.ToString());
            quantity_nud_fullpay.Value = decimal.Parse(item_dgv_fullpay.SelectedRows[0].Cells[2].Value.ToString());
            add_button_fullpay.Tag = "e";
            add_button_fullpay.Text = "+=";
            delete_button_fullpay.Enabled = true;
        }
        private void itemType_combobox_fullpay_SelectedValueChanged(object sender, EventArgs e)
        {
            if (itemType_combobox_fullpay.SelectedIndex != 0)
            {
                suggestedPrice_nud_fullpay.Value = decimal.Parse(((ComboboxContent)(itemType_combobox_fullpay.SelectedItem)).Content2);

                if (quantity_nud_fullpay.Value != 0 && itemType_combobox_fullpay.Text != "0")
                {
                    subTotal_label_fullpay.Text = (suggestedPrice_nud_fullpay.Value * quantity_nud_fullpay.Value).ToString();
                }
            }
            else
            {
                clearIncomeTab();
            }
        }
        private void final_button_fullpay_Click(object sender, EventArgs e)
        {
            if (item_dgv_fullpay.Rows.Count>0)
            {
                int primaryIncomeID = dh.addPrimaryIncome(sourceName_textbox_fullpay.Text, bookModeFullPay, int.Parse(orNumber_label_fullpay.Text), remarks_textbox_fullpay.Text);
                foreach (DataGridViewRow dgvr in item_dgv_fullpay.Rows)
                {
                    dh.addItem(((ComboboxContent)itemType_combobox_fullpay.Items[int.Parse(dgvr.Cells[4].Value.ToString())]).ID, primaryIncomeID, decimal.Parse(dgvr.Cells["priceDataGridViewColumn"].Value.ToString()), int.Parse(dgvr.Cells["QuantityDataGridViewColumn"].Value.ToString()));
                }
                load_IncomePage();
            }
            else
            {
                MessageBox.Show("shunga");
            }
           
        }


        #endregion

        private void sacramentPayment_label_Click(object sender, EventArgs e)
        {
            refreshSacramentPaymentDataGrid();
            CashDisbursment.SelectedTab = sacramentpay;
            
        }
        private void refreshSacramentPaymentDataGrid()
        {
            applicant_datagridview_sacramentpay.DataSource = dh.getPendingApplications();
            foreach (DataGridViewColumn dc in applicant_datagridview_sacramentpay.Columns)
            {
                dc.Visible = false;
            }
            applicant_datagridview_sacramentpay.Columns["name"].Visible = true;
        }
        
        private void applicant_datagridview_sacramentpay_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            firstname_label_sacramentpayment.Text = applicant_datagridview_sacramentpay.SelectedRows[0].Cells["firstname"].Value.ToString();
            middleinitiall_label_sacramentpayment.Text = applicant_datagridview_sacramentpay.SelectedRows[0].Cells["midname"].Value.ToString();
            lastname_label_sacramentpayment.Text= applicant_datagridview_sacramentpay.SelectedRows[0].Cells["lastname"].Value.ToString();
            suffix_label_sacramentpayment.Text= applicant_datagridview_sacramentpay.SelectedRows[0].Cells["suffix"].Value.ToString();
            address_textarea_sacramentpayment.Text= applicant_datagridview_sacramentpay.SelectedRows[0].Cells["address"].Value.ToString();
            contactnumber_textbox_sacramentpayment.Text= applicant_datagridview_sacramentpay.SelectedRows[0].Cells["contactnumber"].Value.ToString();

        }

     

        private void add_button_sacramentpayment_Click(object sender, EventArgs e)
        {
            
        }
    }
}
