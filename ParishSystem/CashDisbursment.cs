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
    public partial class CashDisbursment : Form
    {
        DataHandler dh = new DataHandler();
        int cashreleaseMode;
        public CashDisbursment(int cashReleaseMode)
        {
            InitializeComponent();
            this.cashreleaseMode = cashReleaseMode;
            price_nud_button_CRB.Maximum = decimal.MaxValue;
        }
        private void CashDisbursment_Module_Load(object sender, EventArgs e)
        {
            cashLoad();
        }
        private void cashLoad()
        {
            itemtype_combobox_CRB.Items.Clear();
            itemtype_combobox_CRB.Items.Add("");
            DataTable dt = dh.getItemsActive(cashreleaseMode, 2);
            foreach (DataRow dr in dt.Rows)
            {
                itemtype_combobox_CRB.Items.Add(new ComboboxContent(int.Parse(dr["itemTypeID"].ToString()), dr["itemType"].ToString(), dr["suggestedPrice"].ToString()));
            }
            CVNumber_CRB.Text = dh.getMaxCVNumber(cashreleaseMode).ToString();
            CNNumber_CRB.Text = dh.getMaxCNNumber(cashreleaseMode).ToString();
        }
        private void itemtype_combobox_CRB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemtype_combobox_CRB.Text != "")
            {
                price_nud_button_CRB.Value = Decimal.Parse(((ComboboxContent)itemtype_combobox_CRB.SelectedItem).Content2);
                if (Decimal.Parse(((ComboboxContent)itemtype_combobox_CRB.SelectedItem).Content2) != 0)
                {
                    paymentPanel.Visible = true;
                    priceHeader_label.Visible = true;
                    editPrice_button.Visible = true;
                    cancelPrice_button.Visible = false;
                    price_nud_button_CRB.Visible = false;
                    price_label.Visible = true;
                    editPrice_button.Tag = "e";
                }
                else
                {
                    paymentPanel.Visible = true;
                    priceHeader_label.Visible = true;
                    price_label.Visible = false;
                    price_nud_button_CRB.Visible = true;
                    editPrice_button.Visible = false;
                    cancelPrice_button.Visible = false;
                }
            }
            else
            {
                paymentPanel.Visible = false;
                add_button_CRB.Enabled = false;
            }
        }

        private void price_nud_button_CRB_ValueChanged(object sender, EventArgs e)
        {
            price_label.Text = price_nud_button_CRB.Value.ToString();
            if (price_nud_button_CRB.Value > 0)
            {
                add_button_CRB.Enabled = true;
            }
            else
            {
                add_button_CRB.Enabled = false;
            }
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
                    item_dgv_fullpay_CRB.Rows[index].Cells[3].Value = ((ComboboxContent)itemtype_combobox_CRB.SelectedItem).ID.ToString();//hidden
                }
                else
                {
                    item_dgv_fullpay_CRB.SelectedRows[0].Cells[0].Value = itemtype_combobox_CRB.SelectedItem.ToString();
                    item_dgv_fullpay_CRB.SelectedRows[0].Cells[1].Value = price_nud_button_CRB.Value.ToString();
                    item_dgv_fullpay_CRB.SelectedRows[0].Cells[2].Value = itemtype_combobox_CRB.SelectedIndex;//hidden            
                    delete_button_CRB.Enabled = false;
                }
                clearCRB();
                refreshCRBTotal();
            }
            else
            {
                Notification.Show(State.MissingFields);
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
            itemtype_combobox_CRB.SelectedIndex = 0;
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
                int cashReleaseID = dh.addCashRelease(remarks_textbox_CRB.Text, int.Parse(CNNumber_CRB.Text), int.Parse(CVNumber_CRB.Text), cashreleaseMode, name_textbox_CRB.Text);
                foreach (DataGridViewRow dgvr in item_dgv_fullpay_CRB.Rows)
                {
                    dh.addCashReleaseItem(cashReleaseID, int.Parse(dgvr.Cells[3].Value.ToString()), decimal.Parse(dgvr.Cells[1].Value.ToString()));
                }
                clearCRB();
                CNNumber_CRB.Text = (int.Parse(CNNumber_CRB.Text)+1).ToString();
                CVNumber_CRB.Text = (int.Parse(CVNumber_CRB.Text)+1).ToString();
                name_textbox_CRB.Clear();
                remarks_textbox_CRB.Clear();
                total_label_cashrelease.Text = "0.00";
                item_dgv_fullpay_CRB.Rows.Clear();
            }
            else
            {
                Notification.Show(State.InvalidTransaction);
            }
        }
        private void cancel_button_CRB_Click(object sender, EventArgs e)
        {
            clearCRB();
            name_textbox_CRB.Clear();
            remarks_textbox_CRB.Clear();
            total_label_cashrelease.Text = "0.00";
            item_dgv_fullpay_CRB.Rows.Clear();
        }
        decimal lastSet=0;
        private void editPrice_button_Click(object sender, EventArgs e)
        {
            if (editPrice_button.Tag.ToString() == "e")
            {
                cancelPrice_button.Visible = true;
                price_nud_button_CRB.Visible = true;
                price_label.Visible = false;
                editPrice_button.Tag = "s";
                lastSet = price_nud_button_CRB.Value;
            }
            else
            {
                cancelPrice_button.Visible = false;
                price_nud_button_CRB.Visible = false;
                price_label.Visible = true;
                editPrice_button.Tag = "e";
            }
        }

        private void cancelPrice_button_Click(object sender, EventArgs e)
        {
            cancelPrice_button.Visible = false;
            price_nud_button_CRB.Visible = false;
            price_label.Visible = true;
            editPrice_button.Tag = "e";
            price_nud_button_CRB.Value = lastSet;
        }

        private void item_dgv_fullpay_CRB_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (item_dgv_fullpay_CRB.Rows.Count > 0)
            {
                final_button_CRB.Enabled = true;
            }
            else
            {
                final_button_CRB.Enabled = false;
            }
        }

        private void item_dgv_fullpay_CRB_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (item_dgv_fullpay_CRB.Rows.Count > 0)
            {
                final_button_CRB.Enabled = true;
            }
            else
            {
                final_button_CRB.Enabled = false;
            }
        }

        private void parish_label_Click(object sender, EventArgs e)
        {
            this.cashreleaseMode = 1;
            cashLoad();
            parish_label.Font = new Font(parish_label.Font, FontStyle.Bold);
            community_label.Font = new Font(community_label.Font, FontStyle.Regular);
            postulancy_label.Font = new Font(postulancy_label.Font, FontStyle.Regular);
        }

        private void community_label_Click(object sender, EventArgs e)
        {
            this.cashreleaseMode = 2;
            cashLoad();
            parish_label.Font = new Font(parish_label.Font, FontStyle.Regular);
            community_label.Font = new Font(community_label.Font, FontStyle.Bold);
            postulancy_label.Font = new Font(postulancy_label.Font, FontStyle.Regular);
        }

        private void postulancy_label_Click(object sender, EventArgs e)
        {
            this.cashreleaseMode = 3;
            cashLoad();
            parish_label.Font = new Font(parish_label.Font, FontStyle.Regular);
            community_label.Font = new Font(community_label.Font, FontStyle.Regular);
            postulancy_label.Font = new Font(postulancy_label.Font, FontStyle.Bold);
        }

        private void CashDisbursment_VisibleChanged(object sender, EventArgs e)
        {
            cashLoad();
        }
    }
}
