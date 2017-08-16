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
        treasurerBackend dh = new treasurerBackend();

        public Treasurer()
        {
            InitializeComponent();
            suggestedPrice_nud_fullpay.Maximum = decimal.MaxValue;
            price_nud_button_CRB.Maximum = decimal.MaxValue;
            filterBy_combobox_disbursment.SelectedIndex = 0;
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
            try
            {
                cashRelease_dgv.Rows[selectedCashRelease].Selected = true;
            }
            catch { }
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
            CashDisbursment.SelectedTab = fullpay;
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
            load_IncomePage();
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
        private void itemType_combobox_fullpay_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (itemType_combobox_fullpay.Text == "Baptism")
            {
                dt = dh.getPendingApplicationsOfType((int)SacramentType.Baptism);

            }
            else if (itemType_combobox_fullpay.Text == "Confirmation")
            {
                dt = dh.getPendingApplicationsOfType((int)SacramentType.Confirmation);
            }
            else if (itemType_combobox_fullpay.Text == "Marriage")
            {
                dt = dh.getPendingApplicationsOfType((int)SacramentType.Marriage);
            }
            applicant_combox_fullpay.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                applicant_combox_fullpay.Items.Add(new ComboboxContent(int.Parse(dr["profileID"].ToString()), dr["name"].ToString(), dr["address"].ToString(), dr["contactnumber"].ToString(), dr["applicationID"].ToString(), dr["sacramentType"].ToString()));
            }
        }

        #endregion

        #region sacramentPay
        private void sacramentPayment_label_Click(object sender, EventArgs e)
        {
            refreshSacramentPaymentDataGrid();
            CashDisbursment.SelectedTab = sacramentpay;
        }
        private void refreshSacramentPaymentDataGrid()
        {
            DataTable dt = dh.getPendingApplications();
            profileID_combobox_sacrament.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                profileID_combobox_sacrament.Items.Add(new ComboboxContent(int.Parse(dr["profileID"].ToString()), dr["name"].ToString(), dr["address"].ToString(),dr["contactnumber"].ToString(),dr["applicationID"].ToString(), dr["sacramentType"].ToString()));
            }
            ornumber_label_sacramentpayment.Text = dh.getnextORof((int)BookType.Parish).ToString();
        }
        private void applicant_datagridview_sacramentpay_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           // firstname_label_sacramentpayment.Text = applicant_datagridview_sacramentpay.SelectedRows[0].Cells["firstname"].Value.ToString();
           // middleinitiall_label_sacramentpayment.Text = applicant_datagridview_sacramentpay.SelectedRows[0].Cells["midname"].Value.ToString();
           // lastname_label_sacramentpayment.Text= applicant_datagridview_sacramentpay.SelectedRows[0].Cells["lastname"].Value.ToString();
           // suffix_label_sacramentpayment.Text= applicant_datagridview_sacramentpay.SelectedRows[0].Cells["suffix"].Value.ToString();
            //address_textarea_sacramentpayment.Text= applicant_datagridview_sacramentpay.SelectedRows[0].Cells["address"].Value.ToString();
            //contactnumber_textbox_sacramentpayment.Text= applicant_datagridview_sacramentpay.SelectedRows[0].Cells["contactnumber"].Value.ToString();

        }
        private void add_button_sacramentpayment_Click(object sender, EventArgs e)
        {
            //reset the form kasi combobox needs to be selected again =(
            int primaryincomeID = dh.addPrimaryIncome(null, int.Parse(((ComboboxContent)profileID_combobox_sacrament.SelectedItem).content5),int.Parse(ornumber_label_sacramentpayment.Text),null);
            dh.addPayment(int.Parse(((ComboboxContent)profileID_combobox_sacrament.SelectedItem).content4), primaryincomeID, paid_nud_sacramentpayment.Value);
            refreshPayments();
        }
        private void profileID_combobox_sacrament_SelectedValueChanged(object sender, EventArgs e)
        {
           
                address_textarea_sacramentpayment.Text = ((ComboboxContent)profileID_combobox_sacrament.SelectedItem).Content2;
                contactnumber_textbox_sacramentpayment.Text = ((ComboboxContent)profileID_combobox_sacrament.SelectedItem).Content3;
                refreshPayments();
           
            /*catch
            {
                address_textarea_sacramentpayment.Clear();
                contactnumber_textbox_sacramentpayment.Clear();
            }*/

        }
        public void refreshPayments()
        {
            
            try
            {
                
                ornumber_label_sacramentpayment.Text = dh.getnextORof((int)BookType.Parish).ToString();
                DataTable dt = dh.getSacramentIncome(int.Parse(((ComboboxContent)profileID_combobox_sacrament.SelectedItem).content4));
                totalprice_label_sacramentpayment.Text = dt.Rows[0]["price"].ToString();
                remarks_textbox_sacramentPayment.Text = dt.Rows[0]["remarks"].ToString();

                DataTable dt2 = dh.getPayments(int.Parse(((ComboboxContent)profileID_combobox_sacrament.SelectedItem).content4)); 
                paid_datagridview_sacramentpayment.DataSource = dt2;
                foreach (DataGridViewColumn dgvr in paid_datagridview_sacramentpayment.Columns)
                {
                    dgvr.Visible = false;
                }
                paid_datagridview_sacramentpayment.Columns["ORnum"].Visible = true;
                paid_datagridview_sacramentpayment.Columns["amount"].Visible = true;
                paid_datagridview_sacramentpayment.Columns["primaryincomedatetime"].Visible = true;
                paid_datagridview_sacramentpayment.Columns["remarks"].Visible = true;

                paid_datagridview_sacramentpayment.Columns["ORnum"].HeaderText = "OR Number";
                paid_datagridview_sacramentpayment.Columns["remarks"].HeaderText = "Remarks";
                paid_datagridview_sacramentpayment.Columns["primaryincomedatetime"].HeaderText = "Date and Time Paid";
                paid_datagridview_sacramentpayment.Columns["amount"].HeaderText = "Amount";

                cover_panel.Visible = false;
                refreshTotalPaymentSacrament();
                add_button_sacramentpayment.Enabled = true;
                paid_nud_sacramentpayment.Enabled = true;

            }
            catch
            {
                ornumber_label_sacramentpayment.Text = "";
                totalprice_label_sacramentpayment.Text="";
                remarks_textbox_sacramentPayment.Text = "";
                paid_datagridview_sacramentpayment.DataSource = null;
                totalpaid_label_sacramentpayment.Text ="";
                balance_label_sacramentpayment.Text = "";
                add_button_sacramentpayment.Enabled = false;
                paid_nud_sacramentpayment.Enabled = false;
            }
            }   
        private void refreshTotalPaymentSacrament()
        {
            decimal max = 0;
            foreach (DataGridViewRow dr in paid_datagridview_sacramentpayment.Rows)
            {
                max += (decimal.Parse(dr.Cells["amount"].Value.ToString()));
            }
            totalpaid_label_sacramentpayment.Text = max.ToString();
            balance_label_sacramentpayment.Text = (max - int.Parse(totalprice_label_sacramentpayment.Text)).ToString();
            //balance_label_sacramentpayment.ForeColor = (int.Parse(balance_label_sacramentpayment.Text) == 0 ? Color.Black : Color.IndianRed);
        }

        #endregion

        #region CDB report
        int cashDisbursmentMode = 1;
        private void parish_label_report_Click(object sender, EventArgs e)
                {
            cashDisbursmentMode = (int)BookType.Parish;
            refreshReports();
                }
        private void community_label_report_Click(object sender, EventArgs e)
                {
            cashDisbursmentMode = (int)BookType.Community;
                    refreshReports();
                }
        private void postulancy_label_report_Click(object sender, EventArgs e)
                {
            cashDisbursmentMode = (int)BookType.Postulancy;
                    refreshReports();
                }
        private void CRB_button_Click(object sender, EventArgs e)
                {
                    Reports_panel.BringToFront();
                }
        private void breakdown_datagridview_report_disbursment_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
                {
                    Form A = new ORdetailsPopUp(int.Parse(report_datagridview_cashdisbursment.CurrentRow.Cells["ORnum"].Value.ToString()), cashDisbursmentMode, dh);
                    A.ShowDialog();
                }
        private void searchbar_textbox_report_disbursment_TextChanged(object sender, EventArgs e)
        {
            refreshReports();
        }
        private void from_dtp_cashdisbursment_ValueChanged(object sender, EventArgs e)
        {
            refreshReports();
        }
        private void to_dtp_cashdisbursment_ValueChanged(object sender, EventArgs e)
        {
            refreshReports();
        }
        private void filterBy_combobox_disbursment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterBy_combobox_disbursment.SelectedIndex == 0)
            {
                //refreshReports();
            }
            /*
            if(filterBy_combobox_disbursment.SelectedIndex == 1|| filterBy_combobox_disbursment.SelectedIndex == 2|| filterBy_combobox_disbursment.SelectedIndex == 3 || filterBy_combobox_disbursment.SelectedIndex == 4 || filterBy_combobox_disbursment.SelectedIndex == 6) { from_dtp_cashdisbursment.Visible = true; } else { from_dtp_cashdisbursment.Visible = false; }
            if (filterBy_combobox_disbursment.SelectedIndex == 0) { }
            if (filterBy_combobox_disbursment.SelectedIndex == 1) { }
            if (filterBy_combobox_disbursment.SelectedIndex == 2) { }
            if (filterBy_combobox_disbursment.SelectedIndex == 3) { to_dtp_cashdisbursment.Visible = true; } else { to_dtp_cashdisbursment.Visible = false; }
            if (filterBy_combobox_disbursment.SelectedIndex == 4) { searchbar_textbox_report_disbursment.Visible = true; } else { searchbar_textbox_report_disbursment.Visible = false; }
            if (filterBy_combobox_disbursment.SelectedIndex == 5) { }
            if (filterBy_combobox_disbursment.SelectedIndex == 6) { }
            if (filterBy_combobox_disbursment.SelectedIndex == 7) { }
            if (filterBy_combobox_disbursment.SelectedIndex == 8) { }
            refreshReports();
            */
        }
        private void breakdown_radiobutton_cashdisbursment_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void total_radiobutton_cashdisbursment_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void refreshReports()
        {
            try
            {
                if (bookReportMode == 1)
                {

                    report_datagridview_cashdisbursment.DataSource = null;
                    if (grouped_radiobutton_cashdisbursment.Checked)
                    {
                        if (total_radiobutton_cashdisbursment.Checked)
                        {
                            if (filterBy_combobox_disbursment.SelectedIndex == 0)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatRecent(cashDisbursmentMode);
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 1)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByDay(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("dd")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 2)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByMonth(cashDisbursmentMode,
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 3)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByYear(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 4)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatBetweenDates(cashDisbursmentMode,
                                                                                                    from_dtp_cashdisbursment.Value,
                                                                                                    to_dtp_cashdisbursment.Value);
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 5)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByOrNumber(cashDisbursmentMode,
                                                                                                 int.Parse(searchbar_textbox_report_disbursment.Text));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                        }
                        else if (breakdown_radiobutton_cashdisbursment.Checked)
                        {
                            if (filterBy_combobox_disbursment.SelectedIndex == 0)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatRecent(cashDisbursmentMode);
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 1)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByDay(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("dd")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 2)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByMonth(cashDisbursmentMode,
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 3)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByYear(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 4)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatBetweenDates(cashDisbursmentMode,
                                                                                                    from_dtp_cashdisbursment.Value,
                                                                                                    to_dtp_cashdisbursment.Value);
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 5)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByOrNumber(cashDisbursmentMode,
                                                                                                 int.Parse(searchbar_textbox_report_disbursment.Text));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                        }

                    }
                    else if (notGrouped_radiobutton_cashdisbursment.Checked)
                    {
                        if (total_radiobutton_cashdisbursment.Checked)
                        {
                            if (filterBy_combobox_disbursment.SelectedIndex == 0)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatRecent(cashDisbursmentMode);
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 1)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByDay(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("dd")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 2)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByMonth(cashDisbursmentMode,
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 3)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByYear(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 4)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatBetweenDates(cashDisbursmentMode,
                                                                                                    from_dtp_cashdisbursment.Value,
                                                                                                    to_dtp_cashdisbursment.Value);
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 5)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByOrNumber(cashDisbursmentMode,
                                                                                                 int.Parse(searchbar_textbox_report_disbursment.Text));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashDisbursment(dt);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                        }
                        else if (breakdown_radiobutton_cashdisbursment.Checked)
                        {
                            if (filterBy_combobox_disbursment.SelectedIndex == 0)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatRecent(cashDisbursmentMode);
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 1)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByDay(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("dd")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 2)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByMonth(cashDisbursmentMode,
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                               int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 3)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByYear(cashDisbursmentMode,
                                                                                             int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 4)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatBetweenDates(cashDisbursmentMode,
                                                                                                    from_dtp_cashdisbursment.Value,
                                                                                                    to_dtp_cashdisbursment.Value);
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }
                            else if (filterBy_combobox_disbursment.SelectedIndex == 5)
                            {
                                DataTable dt = dh.getTransactionsByAccountingBookFormatByOrNumber(cashDisbursmentMode,
                                                                                                 int.Parse(searchbar_textbox_report_disbursment.Text));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashDisbursment(dt, cashDisbursmentMode);
                                summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashDisbursment(dt, cashDisbursmentMode);
                            }

                        }
                    }
                }

                else if (bookReportMode == 2)
                {
                        report_datagridview_cashdisbursment.DataSource = null;
                        if (grouped_radiobutton_cashdisbursment.Checked)
                        {
                            if (total_radiobutton_cashdisbursment.Checked)
                            {
                                if (filterBy_combobox_disbursment.SelectedIndex == 0)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatRecent(cashDisbursmentMode);
                                    report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashRelease(dt);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 1)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByDay(cashDisbursmentMode,
                                                                                                 int.Parse(from_dtp_cashdisbursment.Value.ToString("dd")),
                                                                                                 int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                                 int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                    report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashRelease(dt);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 2)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByMonth(cashDisbursmentMode,
                                                                                                   int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                                   int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                    report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashRelease(dt);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 3)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByYear(cashDisbursmentMode,
                                                                                                 int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                    report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashRelease(dt);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 4)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatBetweenDates(cashDisbursmentMode,
                                                                                                        from_dtp_cashdisbursment.Value,
                                                                                                        to_dtp_cashdisbursment.Value);
                                    report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashRelease(dt);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 5)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByOrNumber(cashDisbursmentMode,
                                                                                                     int.Parse(CN_textbox_report_disbursment.Text),
                                                                                                     int.Parse(CV_textbox_report_disbursment.Text));
                                    report_datagridview_cashdisbursment.DataSource = dh.getTotalGroupedCashDisbursment(dt);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                            }
                            else if (breakdown_radiobutton_cashdisbursment.Checked)
                            {
                                if (filterBy_combobox_disbursment.SelectedIndex == 0)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatRecent(cashDisbursmentMode);
                                    report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashRelease(dt, cashDisbursmentMode);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 1)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByDay(cashDisbursmentMode,
                                                                                                 int.Parse(from_dtp_cashdisbursment.Value.ToString("dd")),
                                                                                                 int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                                 int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                    report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashRelease(dt, cashDisbursmentMode);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 2)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByMonth(cashDisbursmentMode,
                                                                                                   int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                                   int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                    report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashRelease(dt, cashDisbursmentMode);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 3)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByYear(cashDisbursmentMode,
                                                                                                 int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                    report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashRelease(dt, cashDisbursmentMode);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 4)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatBetweenDates(cashDisbursmentMode,
                                                                                                        from_dtp_cashdisbursment.Value,
                                                                                                        to_dtp_cashdisbursment.Value);
                                    report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashRelease(dt, cashDisbursmentMode);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 5)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByOrNumber(cashDisbursmentMode,
                                                                                                     int.Parse(CN_textbox_report_disbursment.Text),
                                                                                                     int.Parse(CV_textbox_report_disbursment.Text));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownGroupedCashRelease(dt, cashDisbursmentMode);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                            }

                        }
                        else if (notGrouped_radiobutton_cashdisbursment.Checked)
                        {
                            if (total_radiobutton_cashdisbursment.Checked)
                            {
                                if (filterBy_combobox_disbursment.SelectedIndex == 0)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatRecent(cashDisbursmentMode);
                                    report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashRelease(dt);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 1)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByDay(cashDisbursmentMode,
                                                                                                 int.Parse(from_dtp_cashdisbursment.Value.ToString("dd")),
                                                                                                 int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                                 int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                    report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashRelease(dt);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 2)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByMonth(cashDisbursmentMode,
                                                                                                   int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                                   int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                    report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashRelease(dt);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 3)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByYear(cashDisbursmentMode,
                                                                                                 int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                    report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashRelease(dt);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 4)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatBetweenDates(cashDisbursmentMode,
                                                                                                        from_dtp_cashdisbursment.Value,
                                                                                                        to_dtp_cashdisbursment.Value);
                                    report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashRelease(dt);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 5)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByOrNumber(cashDisbursmentMode,
                                                                                                     int.Parse(CN_textbox_report_disbursment.Text),
                                                                                                     int.Parse(CV_textbox_report_disbursment.Text));
                                report_datagridview_cashdisbursment.DataSource = dh.getTotalUngroupedCashRelease(dt);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                            }
                            else if (breakdown_radiobutton_cashdisbursment.Checked)
                            {
                                if (filterBy_combobox_disbursment.SelectedIndex == 0)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatRecent(cashDisbursmentMode);
                                    report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashRelease(dt, cashDisbursmentMode);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 1)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByDay(cashDisbursmentMode,
                                                                                                 int.Parse(from_dtp_cashdisbursment.Value.ToString("dd")),
                                                                                                 int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                                 int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                    report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashRelease(dt, cashDisbursmentMode);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 2)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByMonth(cashDisbursmentMode,
                                                                                                   int.Parse(from_dtp_cashdisbursment.Value.ToString("MM")),
                                                                                                   int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                    report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashRelease(dt, cashDisbursmentMode);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 3)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByYear(cashDisbursmentMode,
                                                                                                 int.Parse(from_dtp_cashdisbursment.Value.ToString("yyyy")));
                                    report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashRelease(dt, cashDisbursmentMode);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 4)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatBetweenDates(cashDisbursmentMode,
                                                                                                        from_dtp_cashdisbursment.Value,
                                                                                                        to_dtp_cashdisbursment.Value);
                                    report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashRelease(dt, cashDisbursmentMode);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }
                                else if (filterBy_combobox_disbursment.SelectedIndex == 5)
                                {
                                    DataTable dt = dh.getTransactionsCRBByAccountingBookFormatByOrNumber(cashDisbursmentMode,
                                                                                                     int.Parse(CN_textbox_report_disbursment.Text),
                                                                                                     int.Parse(CV_textbox_report_disbursment.Text));
                                report_datagridview_cashdisbursment.DataSource = dh.getBreakdownUngroupedCashRelease(dt, cashDisbursmentMode);
                                    summary_datagridview_report_disbursment.DataSource = dh.getSummaryCashRelease(dt, cashDisbursmentMode);
                                }

                            }
                        }
                    }
            }
            catch { }


        }
        private void grouped_radiobutton_cashdisbursment_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void notGrouped_radiobutton_cashdisbursment_CheckedChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region CRB Tab
        int cashreleaseMode = 1;
        private void parish_label_CRB_Click(object sender, EventArgs e)
        {
            cashreleaseMode = (int)BookType.Parish;
            refreshCashRelease();
        }
        private void community_label_CRB_Click(object sender, EventArgs e)
        {
            cashreleaseMode = (int)BookType.Community;
            refreshCashRelease();
        }
        private void postulancy_label_CRB_Click(object sender, EventArgs e)
        {
            cashreleaseMode = (int)BookType.Postulancy;
            refreshCashRelease();
        }
        private void refreshCashRelease()
        {
            CVNumber_CRB.Text = dh.getMaxCVNumber(cashreleaseMode).ToString();
            CNNumber_CRB.Text = dh.getMaxCNNumber(cashreleaseMode).ToString();
            itemtype_combobox_CRB.Items.Clear();
            itemtype_combobox_CRB.Items.Add("");
            DataTable dt = dh.getItemTypesCashRelease(cashreleaseMode);
            foreach (DataRow dr in dt.Rows)
            {
                itemtype_combobox_CRB.Items.Add(new ComboboxContent(int.Parse(dr["cashReleaseTypeID"].ToString()),dr["cashReleaseType"].ToString()));
            }
            
        }
        private void itemtype_combobox_CRB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void price_nud_button_CRB_ValueChanged(object sender, EventArgs e)
        {

        }
        private void CRB_button_menu_Click(object sender, EventArgs e)
        {
            CRB_panel.BringToFront();
        }
        private void add_button_CRB_Click(object sender, EventArgs e)
        {
            if (itemtype_combobox_CRB.Text != "")
            {
                if ((string)add_button_CRB.Tag == "a")
                {
                    int index = item_dgv_fullpay_CRB.Rows.Add();
                    item_dgv_fullpay_CRB.Rows[index].Cells[0].Value = itemtype_combobox_CRB.SelectedItem.ToString();
                    item_dgv_fullpay_CRB.Rows[index].Cells[1].Value = price_nud_button_CRB.Value.ToString();
                    item_dgv_fullpay_CRB.Rows[index].Cells[2].Value = itemtype_combobox_CRB.SelectedIndex;//hidden
                }
                else
                {
                    item_dgv_fullpay_CRB.SelectedRows[0].Cells[0].Value = itemtype_combobox_CRB.SelectedItem.ToString();
                    item_dgv_fullpay_CRB.SelectedRows[0].Cells[1].Value = price_nud_button_CRB.Value.ToString();
                    item_dgv_fullpay_CRB.SelectedRows[0].Cells[2].Value = itemtype_combobox_CRB.SelectedIndex;//hidden
                    delete_button_fullpay.Enabled = false;
                }
                clearCRB();
                refreshCRBTotal();
            }
            else
            {
                MessageBox.Show("shunga");
            }
        }
        private void clearCRB()
        {
            
            itemtype_combobox_CRB.SelectedIndex = 0;
            price_nud_button_CRB.Value = 0;
            add_button_CRB.Text = "+";
            add_button_CRB.Tag = "a";
        }
        private void refreshCRBTotal()
        {
            decimal sum = 0;
            foreach (DataGridViewRow dr in item_dgv_fullpay_CRB.Rows)
            {
                sum += decimal.Parse(dr.Cells[1].Value.ToString());
            }
            total_label_cashrelease.Text = sum.ToString();
        }
        private void item_dgv_fullpay_CRB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            itemtype_combobox_CRB.SelectedIndex = int.Parse(item_dgv_fullpay_CRB.SelectedRows[0].Cells[2].Value.ToString());
            price_nud_button_CRB.Value = decimal.Parse(item_dgv_fullpay_CRB.SelectedRows[0].Cells[1].Value.ToString());
            add_button_CRB.Tag = "e";
            add_button_CRB.Text = "+=";
            delete_button_CRB.Enabled = true;
        }
        private void clear_button_CRB_Click(object sender, EventArgs e)
        {
            clearCRB();
        }
        private void delete_button_CRB_Click(object sender, EventArgs e)
        {
            delete_button_CRB.Enabled = false;
            item_dgv_fullpay_CRB.Rows.RemoveAt(item_dgv_fullpay_CRB.SelectedRows[0].Index);
            clearCRB();
            refreshCRBTotal();
        }
        private void final_button_CRB_Click(object sender, EventArgs e)
        {
            if (item_dgv_fullpay_CRB.Rows.Count > 0)
            {
                int cashReleaseID = dh.addCashRelease(remarks_textbox_CRB.Text,int.Parse(CNNumber_CRB.Text),int.Parse(CVNumber_CRB.Text),cashreleaseMode, name_textbox_CRB.Text);
                foreach (DataGridViewRow dgvr in item_dgv_fullpay_CRB.Rows)
                {
                    dh.addCashReleaseItem(cashReleaseID, int.Parse(dgvr.Cells[2].Value.ToString()), decimal.Parse(dgvr.Cells[1].Value.ToString()));
                }
                clearCRB();
                refreshCashRelease();
                name_textbox_CRB.Clear();
                remarks_textbox_CRB.Clear();
                total_label_cashrelease.Text = "";
                item_dgv_fullpay_CRB.Rows.Clear();
            }
            else
            {
                MessageBox.Show("shunga");
            }
        }
        private void cancel_button_CRB_Click(object sender, EventArgs e)
        {
            clearCRB();
            refreshCashRelease();
            name_textbox_CRB.Clear();
            remarks_textbox_CRB.Clear();
            total_label_cashrelease.Text = "";
            item_dgv_fullpay_CRB.Rows.Clear();
        }



        //make reports for CRB
        #endregion
        int bookReportMode = 0;
        private void CDB_Label_Click(object sender, EventArgs e)
        {
             bookReportMode = 1;
        }

        private void CRB_Label_Click(object sender, EventArgs e)
        {
             bookReportMode = 2;
        }
    }
}
