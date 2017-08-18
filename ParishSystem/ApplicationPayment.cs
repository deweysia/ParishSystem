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
    public partial class ApplicationPayment : Form
    {
        DataHandler dh;
        DataGridViewCellCollection row;
        SacramentType type;
        int sacramentIncomeID;
        double remainingBalance;
        public ApplicationPayment(SacramentType type, DataGridViewRow dr, DataHandler dh)
        {
            InitializeComponent();
            this.dh = dh;
            this.type = type;
            this.row = dr.Cells;


            int applicationID = int.Parse(row[0].Value.ToString());
            sacramentIncomeID = dh.getSacramentIncomeID(applicationID);

            if (type == SacramentType.Marriage)
            {
                lblName.Text = row[4].Value + " & " + row[6].Value;

            }
            else
                lblName.Text = string.Join(" ", row[3].Value, row[4].Value, row[5].Value, row[6].Value);

            DataTable sacramentIncome = dh.getSacramentIncome(applicationID);

            lblPaymentFor.Text = type.ToString();
            lblOR.Text = dh.getNextOR(BookType.Parish).ToString();
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            lblPrice.Text = string.Format("{0:C}", double.Parse(sacramentIncome.Rows[0]["price"].ToString()));
            remainingBalance = dh.getBalanceOfSacramentIncome(sacramentIncomeID);
            lblBalance.Text = string.Format("{0:C}", remainingBalance);

            dgvPaymentHistory.AutoGenerateColumns = false;
            dgvPaymentHistory.DataSource = dh.getPaymentHistory(sacramentIncomeID);

            nudPayment.Maximum = decimal.MaxValue;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ApplicationPayment_Load(object sender, EventArgs e)
        {

        }

        private void dgvPaymentHistory_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            double payment = Convert.ToDouble(nudPayment.Value);
            uint ORnum = uint.Parse(lblOR.Text);
            string remarks = txtRemarks.Text;
            DateTime dt = DateTime.ParseExact(lblDate.Text, "yyyy-MM-dd", null);
            bool success = dh.addPayment(sacramentIncomeID, payment, int.Parse(lblOR.Text), txtRemarks.Text, dt);

            if(success)
                Notification.Show("Successfully added payment!", NotificationType.success);
            else
                Notification.Show("Something went wrong!", NotificationType.warning);

            this.Close();
        }

        private void dgvPaymentHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                e.Value = Convert.ToDouble(e.Value).ToString("C");
            }
        }

        private void nudPayment_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nudPayment.Value.ToString()))
            {
                nudPayment.Value = 0;
            }

            
        }

        private void nudPayment_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(nudPayment.Value) > remainingBalance)
                nudPayment.Value = (decimal)remainingBalance;
        }
    }
}
