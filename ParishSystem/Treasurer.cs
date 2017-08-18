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
            filterBy_combobox_bloodletting.SelectedIndex = 0;
        }
       
        #region Income Type
        
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
            cashRelease_dgv.Columns["description"].HeaderText = "Description";
            cashRelease_dgv.Columns["booktype"].HeaderText = "Book Type";
            cashRelease_dgv.Columns["status"].HeaderText = "Status";
            try
            {
                cashRelease_dgv.Rows[selectedCashRelease].Selected = true;
            }
            catch { }
        }
        private void cashRelease_dgv_Click(object sender, EventArgs e)
        {
            selectedCashRelease = cashRelease_dgv.SelectedRows[0].Index;
        }
        #endregion

        #region Full Pay
        private void fullpay_label_Click(object sender, EventArgs e)
        {
            fullpay_panel_CDB.BringToFront();
            sacramentPayment_label.ForeColor = Color.DimGray;
            fullpay_label.ForeColor = Color.Black;
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
            add_button_fullpay.Text = "Add";
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

        private void item_dgv_fullpay_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            itemType_combobox_fullpay.SelectedIndex = int.Parse(item_dgv_fullpay.SelectedRows[0].Cells[4].Value.ToString());
            suggestedPrice_nud_fullpay.Value = decimal.Parse(item_dgv_fullpay.SelectedRows[0].Cells[1].Value.ToString());
            quantity_nud_fullpay.Value = decimal.Parse(item_dgv_fullpay.SelectedRows[0].Cells[2].Value.ToString());
            add_button_fullpay.Tag = "e";
            add_button_fullpay.Text = "Edit";
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
            sacramentpay_panel_CDB.BringToFront();
            sacramentPayment_label.ForeColor = Color.Black;
            fullpay_label.ForeColor = Color.DimGray;
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
        private void add_button_sacramentpayment_Click(object sender, EventArgs e)
        {
            //reset the form kasi combobox needs to be selected again =(
            if (paid_nud_sacramentpayment.Value != 0)
            {
                int primaryincomeID = dh.addPrimaryIncome(null, int.Parse(((ComboboxContent)profileID_combobox_sacrament.SelectedItem).content5), int.Parse(ornumber_label_sacramentpayment.Text), null);
                dh.addPayment(int.Parse(((ComboboxContent)profileID_combobox_sacrament.SelectedItem).content4), primaryincomeID, paid_nud_sacramentpayment.Value);
                refreshPayments();
            }
            else
            {
                MessageBox.Show("SHUNGA");
            }
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
                //paid_datagridview_sacramentpayment.DataSource = dt2;
                paid_datagridview_sacramentpayment.Rows.Clear();
                foreach (DataRow dr in dt2.Rows)
                {
                    paid_datagridview_sacramentpayment.Rows.Add(dr["ORnum"].ToString(), dr["amount"].ToString(), dr["primaryIncomeDateTime"].ToString(), dr["remarks"].ToString());
                }

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
                max += (decimal.Parse(dr.Cells[1].Value.ToString()));
            }
            totalpaid_label_sacramentpayment.Text = max.ToString();
            balance_label_sacramentpayment.Text = (max - int.Parse(totalprice_label_sacramentpayment.Text)).ToString();
            //balance_label_sacramentpayment.ForeColor = (int.Parse(balance_label_sacramentpayment.Text) == 0 ? Color.Black : Color.IndianRed);
        }

        #endregion

        #region Reports
        
       
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
            if (filterBy_combobox_disbursment.Text == "Recent")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = false;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = false;
            }
            else if (filterBy_combobox_disbursment.Text == "Day")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = true;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = false;
            }
            else if (filterBy_combobox_disbursment.Text == "Month")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = true;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = false;
            }
            else if (filterBy_combobox_disbursment.Text == "Year")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = true;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = false;
            }
            else if (filterBy_combobox_disbursment.Text == "Date Range")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = true;
                to_dtp_cashdisbursment.Visible = true;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = false;
            }
            else if (filterBy_combobox_disbursment.Text == "OR Number")
            {
                searchbar_textbox_report_disbursment.Visible = true;
                from_dtp_cashdisbursment.Visible = false;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = false;
            }
            else if (filterBy_combobox_disbursment.Text == "CV num")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = false;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = true;
                CN_textbox_report_disbursment.Visible = false;
            }
            else if (filterBy_combobox_disbursment.Text == "CN num")
            {
                searchbar_textbox_report_disbursment.Visible = false;
                from_dtp_cashdisbursment.Visible = false;
                to_dtp_cashdisbursment.Visible = false;
                CV_textbox_report_disbursment.Visible = false;
                CN_textbox_report_disbursment.Visible = true;
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
        private void CDBParishReport_button_Click(object sender, EventArgs e)
        {
            cashDisbursmentMode = (int)BookType.Parish;
            refreshReports();
            Reports_panel.BringToFront();

        }
        private void CDBCommunityReport_button_Click(object sender, EventArgs e)
        {
            cashDisbursmentMode = (int)BookType.Community;
            refreshReports();
            Reports_panel.BringToFront();
        }
        private void CDBPostulancyReport_button_Click(object sender, EventArgs e)
        {
            cashDisbursmentMode = (int)BookType.Postulancy;
            refreshReports();
            Reports_panel.BringToFront();
        }
        private void CRBParishReport_button_Click(object sender, EventArgs e)
        {
            cashDisbursmentMode = (int)BookType.Parish;
            refreshReports();
            Reports_panel.BringToFront();
        }
        private void CRBCommunityReport_button_Click(object sender, EventArgs e)
        {
            cashDisbursmentMode = (int)BookType.Community;
            refreshReports();
            Reports_panel.BringToFront();
        }
        private void CRBPostulancyReport_button_Click(object sender, EventArgs e)
        {
            cashDisbursmentMode = (int)BookType.Postulancy;
            refreshReports();
            Reports_panel.BringToFront();
        }
        #endregion

        #region CRB Tab
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
            add_button_CRB.Text = "Add";
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
            add_button_CRB.Text = "Edit";
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

        #region Menu
        bool CDB_button_toggle = true;
        private void CDB_button_menu_Click(object sender, EventArgs e)
        {
            if (CDB_button_toggle)
            {
                CDBparish_button.Visible = true;
                CDBcommunity_button.Visible = true;
                CDBpostulancy_button.Visible = true;
                CDB_button_toggle = false;
                CDB_button_menu.BackColor = Color.FromArgb(31, 62, 89);
            }
            else
            {
                CDBparish_button.Visible = false;
                CDBcommunity_button.Visible = false;
                CDBpostulancy_button.Visible = false;
                CDB_button_toggle = true;
                CDB_button_menu.BackColor = Color.FromArgb(42, 91, 132);
            }
            /*CDB_parish_panel.BringToFront();
            load_IncomePage();*/
        }
        bool CRB_button_toggle = true;
        private void CRB_button_menu_Click(object sender, EventArgs e)
        {
            // CRB_panel.BringToFront();
            if (CRB_button_toggle)
            {
                CRBparish_button.Visible = true;
                CRBcommunity_button.Visible = true;
                CRBpostulancy_button.Visible = true;
                CRB_button_toggle = false;
            }
            else
            {
                CRBparish_button.Visible = false;
                CRBcommunity_button.Visible = false;
                CRBpostulancy_button.Visible = false;
                CRB_button_toggle = true;
            }
        }
        bool items_button_toggle = true;
        private void item_button_menu_Click(object sender, EventArgs e)
        {
            // CRB_panel.BringToFront();
            if (items_button_toggle)
            {
                CDBitem_button.Visible = true;
                CRBitem_button.Visible = true;
                items_button_toggle = false;
            }
            else
            {
                CDBitem_button.Visible = false;
                CRBitem_button.Visible = false;
                items_button_toggle = true;
            }
            // refreshItemTypes();
            //IncomeCashReleaseType_panel.BringToFront();
        }
        bool reports_button_toggle = true;
        private void reports_button_Click(object sender, EventArgs e)
        {
            if (reports_button_toggle)
            {
                CDBReport_button.Visible = true;
                CRBReport_button.Visible = true;
                reports_button_toggle = false;
            }
            else
            {
                CDBReport_button.Visible = false;
                CRBReport_button.Visible = false;
                reports_button_toggle = true;
            }
        }
        bool CDBReport_button_toggle = true;
        int bookReportMode = 0;
        private void CDBReport_button_Click(object sender, EventArgs e)
        {
            // CRB_panel.BringToFront();
            if (CDBReport_button_toggle)
            {
                bookReportMode = 1;
                CDBParishReport_button.Visible = true;
                CDBCommunityReport_button.Visible = true;
                CDBPostulancyReport_button.Visible = true;
                CDBReport_button_toggle = false;
                filterBy_combobox_disbursment.Items.Remove("CV num");
                filterBy_combobox_disbursment.Items.Remove("CN num");
                filterBy_combobox_disbursment.Items.Add("OR num");
            }
            else
            {
                bookReportMode = 1;
                CDBParishReport_button.Visible = false;
                CDBCommunityReport_button.Visible = false;
                CDBPostulancyReport_button.Visible = false;
                CDBReport_button_toggle = true;
                filterBy_combobox_disbursment.Items.Remove("CV num");
                filterBy_combobox_disbursment.Items.Remove("CN num");
                filterBy_combobox_disbursment.Items.Remove("OR num");
            }

        }
        bool CRBReport_button_toggle = true;
        private void CRBReport_button_Click(object sender, EventArgs e)
        {
            if (CRBReport_button_toggle)
            {
                bookReportMode = 2;
                CRBParishReport_button.Visible = true;
                CRBCommunityReport_button.Visible = true;
                CRBPostulancyReport_button.Visible = true;
                CRBReport_button_toggle = false;
                filterBy_combobox_disbursment.Items.Add("CV num");
                filterBy_combobox_disbursment.Items.Add("CN num");
                filterBy_combobox_disbursment.Items.Remove("OR num");
            }
            else
            {
                bookReportMode =2;
                CRBParishReport_button.Visible = false;
                CRBCommunityReport_button.Visible = false;
                CRBPostulancyReport_button.Visible = false;
                CRBReport_button_toggle = true;
                filterBy_combobox_disbursment.Items.Remove("CV num");
                filterBy_combobox_disbursment.Items.Remove("CN num");
                filterBy_combobox_disbursment.Items.Remove("OR num");
            }
        }

        int bookModeFullPay;
        private void CDBparish_button_Click(object sender, EventArgs e)
        {
            bookModeFullPay = (int)BookType.Parish;
            load_IncomePage();
            fullpay_label.Visible = true;
            sacramentPayment_label.Visible = true;
            //CDB_panel.BringToFront();
        }
        private void CDBcommunity_button_Click(object sender, EventArgs e)
        {
            bookModeFullPay = (int)BookType.Community;
            sacramentPayment_label.Visible = false;
            load_IncomePage();
            fullpay_panel_CDB.BringToFront();
            fullpay_label.ForeColor = Color.Black;
            //CDB_panel.BringToFront();
        }
        private void CDBpostulancy_button_Click(object sender, EventArgs e)
        {
            bookModeFullPay = (int)BookType.Postulancy;
            sacramentPayment_label.Visible = false;
            load_IncomePage();
            fullpay_panel_CDB.BringToFront();
            fullpay_label.ForeColor = Color.Black;
            //CDB_panel.BringToFront();
        }
        int cashDisbursmentMode = 1;
        
        int cashreleaseMode = 1;
        private void CRBparish_button_Click(object sender, EventArgs e)
        {
            cashreleaseMode = (int)BookType.Parish;
            refreshCashRelease();
            CRB_panel.BringToFront();
        }
        private void CRBcommunity_button_Click(object sender, EventArgs e)
        {
            cashreleaseMode = (int)BookType.Community;
            refreshCashRelease();
            CRB_panel.BringToFront();
        }
        private void CRBpostulancy_button_Click(object sender, EventArgs e)
        {
            cashreleaseMode = (int)BookType.Postulancy;
            refreshCashRelease();
            CRB_panel.BringToFront();
        }
        private void CDBitem_button_Click(object sender, EventArgs e)
        {
            IncomeCashReleaseType_TabControl.SelectedTab = IncomeTypeTab;
            refreshItemTypes();
            IncomeCashReleaseType_panel.BringToFront();
        }
        private void CRBitem_button_Click(object sender, EventArgs e)
        {
            IncomeCashReleaseType_TabControl.SelectedTab = CashReleaseTypeTab;
            refreshCashReleaseTypes();
            IncomeCashReleaseType_panel.BringToFront();
        }
        #endregion

        #region Bloodletting

        private void refreshBloodDonors()
        {
            donor_dgv.DataSource = dh.getBloodDonors();
            donor_dgv.Columns[0].Visible = false;
            donor_dgv.Columns[1].HeaderText = "Name";
            donor_dgv.Columns[2].HeaderText = "Total Donated";
            donor_dgv.Columns[3].HeaderText = "Address";
        }
        private void add_button_donor_Click(object sender, EventArgs e)
        {
            Form A = new Bloodletting_Profile_Popup(dh);
            A.ShowDialog();
            refreshBloodDonors();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            refreshBloodDonors();

        }
        private void donor_dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form A = new Bloodletting_Profile_Popup(int.Parse(donor_dgv.CurrentRow.Cells["profileid"].Value.ToString()), dh);
            A.ShowDialog();
            refreshBloodDonors();
        }


        #endregion

        #region bloodletting event
        private void refreshEvents()
        {
            bloodletingevents_dgv.DataSource = dh.getBloodlettingEvents();
            bloodletingevents_dgv.Columns["eventName"].HeaderText = "Name";
            bloodletingevents_dgv.Columns["startDateTime"].HeaderText = "Start";
            bloodletingevents_dgv.Columns["endDateTime"].HeaderText = "End";
            bloodletingevents_dgv.Columns["eventVenue"].HeaderText = "Venue";
            bloodletingevents_dgv.Columns["eventDetails"].HeaderText = "Details";
            bloodletingevents_dgv.Columns["bloodDonationEventID"].Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            refreshEvents();
        }
        private void Add_button_bloodlettingevent_Click(object sender, EventArgs e)
        {
            Form A = new BloodlettingEventPopUp(dh);
            A.ShowDialog();
            refreshEvents();
        }
        private void bloodletingevents_dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form A = new BloodlettingEventPopUp(int.Parse(bloodletingevents_dgv.CurrentRow.Cells["bloodDonationEventID"].Value.ToString()), dh);
            A.ShowDialog();
            refreshEvents();
        }
        #endregion

        #region bloodletting event report
        private void refreshBloodEvenReport()
        {
            DataTable dt = dh.getBloodlettingEvents();
            foreach (DataRow dr in dt.Rows)
            {
                bloodlettingeventreport_combobox.Items.Add(new ComboboxContent(int.Parse(dr["bloodDonationEventID"].ToString()), dr["eventName"].ToString()));
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            refreshBloodEvenReport();
        }

        private void bloodlettingeventreport_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void filterBy_combobox_bloodletting_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt;
            if (filterBy_combobox_bloodletting.Text == "Recent")
            {
                dt = dh.getBloodDonorsRecent();
            }
            else if (filterBy_combobox_bloodletting.Text == "Donations on Event")
            {
                dt = dh.getBloodDonorsOnEvent(((ComboboxContent)bloodlettingeventreport_combobox.SelectedItem).ID);
            }
            else if (filterBy_combobox_bloodletting.Text == "Donations on Date")
            {
                dt = dh.getBloodDonorsOnDate(from_bloodlettingeventreport_dtp.Value);
            }
            else if (filterBy_combobox_bloodletting.Text == "Donations between Dates")
            {
                dt = dh.getBloodDonorsOnDateRange(from_bloodlettingeventreport_dtp.Value, to_bloodlettingeventreport_dtp.Value);
            }
            else
            {
                dt = dh.getBloodDonors();
            }
            bloodlettingeventreport_datagridview.DataSource = dt;
            summary_dgv_bloodletting.DataSource = dh.getsummaryOfBloodleting(dt);
        }
        #endregion
    }

}
