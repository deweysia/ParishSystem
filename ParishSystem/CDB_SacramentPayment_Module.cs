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
    public partial class CDB_SacramentPayment_Module : Form
    {
        treasurerBackend dh = new treasurerBackend();
        public CDB_SacramentPayment_Module()
        {
            InitializeComponent();
        }

        private void sacramentPayment_label_Click(object sender, EventArgs e)
        {
            refreshSacramentPaymentDataGrid();
            sacramentpay_panel_CDB.BringToFront();
        }
        private void refreshSacramentPaymentDataGrid()
        {
            DataTable dt = dh.getPendingApplications();
            profileID_combobox_sacrament.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                profileID_combobox_sacrament.Items.Add(new ComboboxContent(int.Parse(dr["profileID"].ToString()), dr["name"].ToString(), dr["address"].ToString(), dr["contactnumber"].ToString(), dr["applicationID"].ToString(), dr["sacramentType"].ToString()));
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
            refreshPayments();

            /*catch
            {
                address_textarea_sacramentpayment.Clear();
                contactnumber_textbox_sacramentpayment.Clear();
            }*/

        }
        public void refreshPayments()
        {
            try { 
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
                totalprice_label_sacramentpayment.Text = "";
                remarks_textbox_sacramentPayment.Text = "";
                paid_datagridview_sacramentpayment.DataSource = null;
                totalpaid_label_sacramentpayment.Text = "";
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

        private void CDB_SacramentPayment_Module_Load(object sender, EventArgs e)
        {
            refreshSacramentPaymentDataGrid();
        }
    }
}
