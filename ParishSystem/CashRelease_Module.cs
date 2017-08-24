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
    public partial class CashRelease_Module : Form
    {
        treasurerBackend dh = new treasurerBackend();
        int cashreleaseMode;
        public CashRelease_Module(int cashReleaseMode)
        {
            InitializeComponent();
            this.cashreleaseMode = cashReleaseMode;
            price_nud_button_CRB.Maximum = decimal.MaxValue;
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
                itemtype_combobox_CRB.Items.Add(new ComboboxContent(int.Parse(dr["cashReleaseTypeID"].ToString()), dr["cashReleaseType"].ToString()));
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
                int cashReleaseID = dh.addCashRelease(remarks_textbox_CRB.Text, int.Parse(CNNumber_CRB.Text), int.Parse(CVNumber_CRB.Text), cashreleaseMode, name_textbox_CRB.Text);
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
        private void CashDisbursment_Module_Load(object sender, EventArgs e)
        {
            refreshCashRelease();
        }

        private void total_label_cashrelease_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void remarks_textbox_CRB_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_textbox_CRB_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void item_dgv_fullpay_CRB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
