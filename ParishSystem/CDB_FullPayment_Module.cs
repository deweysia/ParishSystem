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
            if(itemType_combobox_fullpay.Text=="Baptism"|| itemType_combobox_fullpay.Text == "Confirmation"|| itemType_combobox_fullpay.Text == "Marriage")
            {
                if (applicant_combox_fullpay.Text != "")
                {
                    if ((string)add_button_fullpay.Tag == "a")
                    {
                        /*
                        int index = item_dgv_fullpay.Rows.Add();
                        item_dgv_fullpay.Rows[index].Cells[0].Value = itemType_combobox_fullpay.SelectedItem.ToString();
                        item_dgv_fullpay.Rows[index].Cells[1].Value = suggestedPrice_nud_fullpay.Value.ToString();
                        item_dgv_fullpay.Rows[index].Cells[2].Value = quantity_nud_fullpay.Value.ToString();
                        item_dgv_fullpay.Rows[index].Cells[3].Value = subTotal_label_fullpay.Text;
                        item_dgv_fullpay.Rows[index].Cells[4].Value = itemType_combobox_fullpay.SelectedIndex;//hidden
                        */
                    }
                    else//edit mode
                    {
                        /*
                        item_dgv_fullpay.SelectedRows[0].Cells[0].Value = itemType_combobox_fullpay.SelectedItem.ToString();
                        item_dgv_fullpay.SelectedRows[0].Cells[1].Value = suggestedPrice_nud_fullpay.Value.ToString();
                        item_dgv_fullpay.SelectedRows[0].Cells[2].Value = quantity_nud_fullpay.Value.ToString();
                        item_dgv_fullpay.SelectedRows[0].Cells[3].Value = subTotal_label_fullpay.Text;
                        item_dgv_fullpay.SelectedRows[0].Cells[4].Value = itemType_combobox_fullpay.SelectedIndex;//hidden
                        delete_button_fullpay.Enabled = false;
                        */
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
            if (item_dgv_fullpay.Rows.Count > 0)
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
            if (itemType_combobox_fullpay.Text == "Baptism" || itemType_combobox_fullpay.Text == "Confirmation" || itemType_combobox_fullpay.Text == "Marriage")
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
                applicant_combox_fullpay.SelectedIndex = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    applicant_combox_fullpay.Items.Add(new ComboboxContent(int.Parse(dr["applicationID"].ToString()), dr["name"].ToString()));
                }
                applicant_combox_fullpay.Visible = true;
                name_label.Visible = true;
                subTotal_label_fullpay.Visible = false;
                sub_total.Visible = false;
            }
            else
            {
                applicant_combox_fullpay.Visible = false;
                name_label.Visible = false;
                subTotal_label_fullpay.Visible = true;
                sub_total.Visible = true;
            }
        }

        private void CDB_FullPayment_Module_Load(object sender, EventArgs e)
        {
            load_IncomePage();
        }

        private void applicant_combox_fullpay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
