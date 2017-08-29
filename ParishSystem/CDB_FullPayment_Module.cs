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
    public partial class CDB_FullPayment_Module : Form
    {
        int bookModeFullPay;
        treasurerBackend dh = new treasurerBackend();
        public CDB_FullPayment_Module(int bookModeFullPay)
        {
            InitializeComponent();
            this.bookModeFullPay = bookModeFullPay;
            suggestedPrice_nud_fullpay.Maximum = decimal.MaxValue;
            targetPriceNUD.Maximum = decimal.MaxValue;
        }


        private void load_IncomePage()
        {//make generic 
            cancelTransaction_button_fullpay.PerformClick();
            itemType_combobox_fullpay.Items.Clear();
            itemType_combobox_fullpay.Items.Add("");
            targetPriceNUD.Tag = "a";
            orNumber_label_fullpay.Text = dh.getnextORof(bookModeFullPay).ToString();
            DataTable dt = dh.getIncomeTypesOf(bookModeFullPay);

            foreach (DataRow dr in dt.Rows)
            {

                itemType_combobox_fullpay.Items.Add(new ComboboxContent(int.Parse(dr["itemTypeID"].ToString()), dr["itemType"].ToString(), dr["suggestedPrice"].ToString()));
            }
        }
        private void suggestedPrice_nud_fullpay_parish_ValueChanged(object sender, EventArgs e)
        {

            if (quantity_nud_fullpay.Value != 0 && itemType_combobox_fullpay.Text != "")
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
            if (suggestedPrice_nud_fullpay.Value!=0) {
                if ((itemType_combobox_fullpay.Text == "Baptism" || itemType_combobox_fullpay.Text == "Confirmation" || itemType_combobox_fullpay.Text == "Marriage") && bookModeFullPay == (int)BookType.Parish)
                {


                    if (applicant_combox_fullpay.Text != "")
                    {
                        if ((string)add_button_fullpay.Tag == "a")
                        {

                            int index = item_dgv_fullpay.Rows.Add();
                            item_dgv_fullpay.Rows[index].Cells[0].Value = itemType_combobox_fullpay.SelectedItem.ToString();
                            item_dgv_fullpay.Rows[index].Cells[1].Value = suggestedPrice_nud_fullpay.Value.ToString();
                            item_dgv_fullpay.Rows[index].Cells[2].Value = 1;
                            item_dgv_fullpay.Rows[index].Cells[3].Value = subTotal_label_fullpay.Text;
                            item_dgv_fullpay.Rows[index].Cells[4].Value = itemType_combobox_fullpay.SelectedIndex;//hidden
                            item_dgv_fullpay.Rows[index].Cells[5].Value = ((ComboboxContent)applicant_combox_fullpay.SelectedItem).ID.ToString();//hidden
                            item_dgv_fullpay.Rows[index].Cells[6].Value = applicant_combox_fullpay.SelectedIndex;
                            item_dgv_fullpay.Rows[index].Cells[7].Value = targetPrice_label.Text;
                        }
                        else//edit mode
                        {
                            item_dgv_fullpay.SelectedRows[0].Cells[0].Value = itemType_combobox_fullpay.SelectedItem.ToString();
                            item_dgv_fullpay.SelectedRows[0].Cells[1].Value = suggestedPrice_nud_fullpay.Value.ToString();
                            item_dgv_fullpay.SelectedRows[0].Cells[2].Value = 1;
                            item_dgv_fullpay.SelectedRows[0].Cells[3].Value = subTotal_label_fullpay.Text;
                            item_dgv_fullpay.SelectedRows[0].Cells[4].Value = itemType_combobox_fullpay.SelectedIndex;//hidden
                            item_dgv_fullpay.SelectedRows[0].Cells[5].Value = ((ComboboxContent)applicant_combox_fullpay.SelectedItem).ID.ToString();//hidden
                            item_dgv_fullpay.SelectedRows[0].Cells[6].Value = applicant_combox_fullpay.SelectedIndex;
                            item_dgv_fullpay.SelectedRows[0].Cells[7].Value = targetPrice_label.Text;
                            delete_button_fullpay.Enabled = false;
                        }
                        clearIncomeTab();
                        refreshTotalLabel();

                    }
                    else
                    {
                        Notification.Show(State.MissingPersonInCRB);
                    }

                }
                else {
                    if (itemType_combobox_fullpay.Text != "" && quantity_nud_fullpay.Value != 0)
                    {
                        if ((string)add_button_fullpay.Tag == "a")
                        {
                            int index = item_dgv_fullpay.Rows.Add();
                            item_dgv_fullpay.Rows[index].Cells[0].Value = itemType_combobox_fullpay.SelectedItem.ToString();
                            item_dgv_fullpay.Rows[index].Cells[1].Value = suggestedPrice_nud_fullpay.Value.ToString();
                            item_dgv_fullpay.Rows[index].Cells[2].Value = quantity_nud_fullpay.Value.ToString();
                            item_dgv_fullpay.Rows[index].Cells[3].Value = subTotal_label_fullpay.Text;
                            item_dgv_fullpay.Rows[index].Cells[4].Value = itemType_combobox_fullpay.SelectedIndex;//hidden
                            item_dgv_fullpay.Rows[index].Cells[5].Value = null;
                            item_dgv_fullpay.Rows[index].Cells[6].Value = null;
                            item_dgv_fullpay.Rows[index].Cells[7].Value = null;
                        }
                        else
                        {
                            item_dgv_fullpay.SelectedRows[0].Cells[0].Value = itemType_combobox_fullpay.SelectedItem.ToString();
                            item_dgv_fullpay.SelectedRows[0].Cells[1].Value = suggestedPrice_nud_fullpay.Value.ToString();
                            item_dgv_fullpay.SelectedRows[0].Cells[2].Value = quantity_nud_fullpay.Value.ToString();
                            item_dgv_fullpay.SelectedRows[0].Cells[3].Value = subTotal_label_fullpay.Text;
                            item_dgv_fullpay.SelectedRows[0].Cells[4].Value = itemType_combobox_fullpay.SelectedIndex;//hidden
                            item_dgv_fullpay.SelectedRows[0].Cells[5].Value = null;
                            item_dgv_fullpay.SelectedRows[0].Cells[6].Value = null;
                            item_dgv_fullpay.SelectedRows[0].Cells[7].Value = null;
                            delete_button_fullpay.Enabled = false;
                        }
                        clearIncomeTab();
                        refreshTotalLabel();
                    }
                    else
                    {
                        Notification.Show(State.MissingFields);
                    }
                }
            }
            else { Notification.Show(State.InvalidPayment); }
        }
        private void clearIncomeTab()
        {
            itemType_combobox_fullpay.SelectedIndex = 0;
            itemType_combobox_fullpay.Enabled = true;
            suggestedPrice_nud_fullpay.Value = 0;
            quantity_nud_fullpay.Value = 1;
            subTotal_label_fullpay.Text = "";
            add_button_fullpay.Text = "Add";
            add_button_fullpay.Tag = "a";
            suggestedPrice_nud_fullpay.Maximum = decimal.MaxValue;
            clearProfile();
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
            total_label_fullpay.Text = "0";

        }

        private void item_dgv_fullpay_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            itemType_combobox_fullpay.SelectedIndex = int.Parse(item_dgv_fullpay.SelectedRows[0].Cells[4].Value.ToString());
            itemType_combobox_fullpay.Enabled = false;
            suggestedPrice_nud_fullpay.Value = decimal.Parse(item_dgv_fullpay.SelectedRows[0].Cells[1].Value.ToString());
            quantity_nud_fullpay.Value = decimal.Parse(item_dgv_fullpay.SelectedRows[0].Cells[2].Value.ToString());
            add_button_fullpay.Tag = "e";
            add_button_fullpay.Text = "Edit";
            delete_button_fullpay.Enabled = true;
            if (item_dgv_fullpay.SelectedRows[0].Cells[5].Value != null)
            {
                applicant_combox_fullpay.SelectedIndex = int.Parse(item_dgv_fullpay.SelectedRows[0].Cells[6].Value.ToString());
            }
            targetPrice_label.Text = item_dgv_fullpay.SelectedRows[0].Cells[7].Value.ToString();
            suggestedPrice_nud_fullpay.Maximum = decimal.Parse(targetPrice_label.Text)- decimal.Parse(pricePaid_label.Text);
        }
        private void itemType_combobox_fullpay_SelectedValueChanged(object sender, EventArgs e)
        {
          
            if (itemType_combobox_fullpay.SelectedIndex != 0)
            {
                suggestedPrice_nud_fullpay.Maximum = decimal.Parse(((ComboboxContent)itemType_combobox_fullpay.SelectedItem).Content2);
                suggestedPrice_nud_fullpay.Value = decimal.Parse(((ComboboxContent)(itemType_combobox_fullpay.SelectedItem)).Content2);

            }
            else
            {
                clearIncomeTab();
            }
            
        }
        private void final_button_fullpay_Click(object sender, EventArgs e)
        {
            if (item_dgv_fullpay.Rows.Count > 0)
            {
                int primaryIncomeID = dh.addPrimaryIncome(sourceName_textbox_fullpay.Text, bookModeFullPay, int.Parse(orNumber_label_fullpay.Text), remarks_textbox_fullpay.Text);
                foreach (DataGridViewRow dgvr in item_dgv_fullpay.Rows)
                {
                    bool normal = true;
                    try
                    {
                        int.Parse(dgvr.Cells[5].Value.ToString());
                        normal = false;
                    }
                    catch
                    {
                        normal = true;
                    }
                    if (normal)
                    {
                        dh.addItem(((ComboboxContent)itemType_combobox_fullpay.Items[int.Parse(dgvr.Cells[4].Value.ToString())]).ID, primaryIncomeID, decimal.Parse(dgvr.Cells["priceDataGridViewColumn"].Value.ToString()), int.Parse(dgvr.Cells["QuantityDataGridViewColumn"].Value.ToString()));
                    }
                    else
                    {
                        int sacramentincomeID = dh.getSacramentIncomeID(int.Parse(dgvr.Cells[5].Value.ToString()));
                        if (sacramentincomeID == -1)
                        {
                            dh.addSacramentIncome(int.Parse(dgvr.Cells[5].Value.ToString()), double.Parse(dgvr.Cells[7].Value.ToString()), "");
                            sacramentincomeID = dh.getLastSacramentIncome();
                        }
                        else if (sacramentincomeID != -1 && targetPriceNUD.Tag.ToString() != "a")
                        {
                            dh.editSacramentIncome(decimal.Parse(dgvr.Cells[7].Value.ToString()), sacramentincomeID);
                        }
                        dh.addPayment(sacramentincomeID, primaryIncomeID, decimal.Parse(dgvr.Cells[3].Value.ToString()));
                    }
                }
                load_IncomePage();
            }
            else
            {
                Notification.Show(State.InvalidTransaction);
            }

        }
        private void itemType_combobox_fullpay_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (bookModeFullPay == 1 && (itemType_combobox_fullpay.Text == "Baptism" || itemType_combobox_fullpay.Text == "Confirmation" || itemType_combobox_fullpay.Text == "Marriage"))
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
                applicant_combox_fullpay.Items.Add("");

                foreach (DataRow dr in dt.Rows)
                {
                    applicant_combox_fullpay.Items.Add(new ComboboxContent(int.Parse(dr["applicationID"].ToString()), dr["name"].ToString()));

                }

                applicant_combox_fullpay.Visible = true;
                name_label.Visible = true;
                subtotal_panel.Visible = false;
                Person_panel.Visible = true;

            }
            else
            {
                applicant_combox_fullpay.Visible = false;
                name_label.Visible = false;
                subtotal_panel.Visible = true;
                Person_panel.Visible = false;
                subtotal_panel.Visible = true;

            }
            //suggestedPrice_nud_fullpay.Maximum = decimal.MaxValue;
            if (itemType_combobox_fullpay.SelectedIndex != 0)
            {
                suggestedPrice_nud_fullpay.Value = decimal.Parse(((ComboboxContent)itemType_combobox_fullpay.SelectedItem).Content2);
            }
            else
            {
                suggestedPrice_nud_fullpay.Value = 0;
            }
            clearProfile();
        }
        private void clearProfile()
        {
            itemType_combobox_fullpay.SelectedIndex = itemType_combobox_fullpay.SelectedIndex;
            pricePaid_label.Text = "0";
            targetPriceNUD.Value = 0;
            targetPrice_label.Text = "0";
            edit = true;
            targetPriceNUD.Value = 0;
            targetPriceNUD.Visible = false;
        }
        private void CDB_FullPayment_Module_Load(object sender, EventArgs e)
        {
            load_IncomePage();
        }

        private void applicant_combox_fullpay_SelectedIndexChanged(object sender, EventArgs e)
        {

            add_button_fullpay.Enabled = true;
            bool notExist = true;
        
            clearProfile();
            if (applicant_combox_fullpay.Items.Count > 0)
            {

                if (add_button_fullpay.Tag.ToString() == "a") {
                    if (applicant_combox_fullpay.SelectedIndex != 0)
                    {
                        foreach (DataGridViewRow dr in item_dgv_fullpay.Rows)
                        {
                        
                            if ((dr.Cells[5].Value == null ? "-" : dr.Cells[5].Value.ToString()) == ((ComboboxContent)applicant_combox_fullpay.SelectedItem).ID.ToString())
                            {
                                notExist = false;
                            }
                        }
                    }
                }

            }



            if (notExist)
            {

                if (applicant_combox_fullpay.SelectedIndex != 0)
                {
                    DataTable paymentDetails = dh.getApplicationPaymentOf(((ComboboxContent)applicant_combox_fullpay.SelectedItem).ID);
                    if (paymentDetails.Rows[0][0].ToString() != "")
                    {
                        if (decimal.Parse(paymentDetails.Rows[0][0].ToString()) <= (paymentDetails.Rows[0][1].ToString() == "" ? 0 : decimal.Parse(paymentDetails.Rows[0][1].ToString())))
                        {
                            Notification.Show(State.AlreadyPaid);
                            Person_panel.Visible = false;
                            itemType_combobox_fullpay.SelectedIndex = 0;
                        }
                        else
                        {
                            targetPrice_label.Text = paymentDetails.Rows[0][0].ToString();
                            pricePaid_label.Text = (paymentDetails.Rows[0][1].ToString() == "" ? "0" : paymentDetails.Rows[0][1].ToString());
                            if (add_button_fullpay.Tag.ToString() == "a")
                            {
                                suggestedPrice_nud_fullpay.Maximum = decimal.Parse(targetPrice_label.Text) - decimal.Parse(pricePaid_label.Text);
                                suggestedPrice_nud_fullpay.Value = decimal.Parse(targetPrice_label.Text) - decimal.Parse(pricePaid_label.Text);
                            }
                        }
                    }
                    else
                    {
                        if (add_button_fullpay.Tag.ToString() == "a") {
                            targetPrice_label.Text = ((ComboboxContent)itemType_combobox_fullpay.SelectedItem).content2;
                            pricePaid_label.Text = 0.ToString();
                        }
                    }
                }
            }

            else
            {
                Notification.Show(State.HasTransaction);
                add_button_fullpay.Enabled = false;

            }
        }

    
    

        
        private void targetPriceNUD_ValueChanged(object sender, EventArgs e)
        {
            
            targetPriceNUD.Tag = "b";
            
        }

        bool edit=true;
        decimal lastargetprice;
        private void editPrice_button_Click(object sender, EventArgs e)
        {
            lastargetprice = decimal.Parse(targetPrice_label.Text);
            if (edit)
            {
                targetPriceNUD.Visible = true;
                targetPriceNUD.Value = decimal.Parse(targetPrice_label.Text);
                edit = false;
            }
            else
            {
              
                if (suggestedPrice_nud_fullpay.Value + decimal.Parse(pricePaid_label.Text)  <= targetPriceNUD.Value )
                {
                    targetPrice_label.Text = targetPriceNUD.Value.ToString();
                    suggestedPrice_nud_fullpay.Maximum = targetPriceNUD.Value;
                    suggestedPrice_nud_fullpay.Value = targetPriceNUD.Value - decimal.Parse(pricePaid_label.Text);
                    targetPriceNUD.Visible = false;
                    targetPriceNUD.Value = 0;
                    edit = true;
                }
                else
                {
                    Notification.Show(State.InvalidPrice);
                    edit = true;
                }

            }
            
        }

        private void applicant_combox_fullpay_SelectedValueChanged(object sender, EventArgs e)
        {
            
            if (applicant_combox_fullpay.Text == "")
            {
                Person_panel.Visible = false;
            }
           else
            {
                Person_panel.Visible = true;
            }
            
        }

        private void Person_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            targetPriceNUD.Visible = false;
            targetPrice_label.Text = lastargetprice.ToString();

        }

        private void targetPriceNUD_VisibleChanged(object sender, EventArgs e)
        {
            if (targetPriceNUD.Visible)
            {
                Cancel_button.Enabled = true;
            }
            else
            {
                Cancel_button.Enabled = false;
            }
        }
    }
}
