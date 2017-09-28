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

            Draggable drag = new Draggable(this);
            drag.makeDraggable(panel1);

            int applicationID = int.Parse(row[0].Value.ToString());
            sacramentIncomeID = dh.getSacramentIncomeID(applicationID);

            
            if (type == SacramentType.Marriage)
            {
                //Escaped ampersand by &&
                lblName.Text = row["groomName"].Value + " && " + row["brideName"].Value;

            }
            else
                lblName.Text = string.Join(" ", row[4].Value, row[5].Value, row[6].Value, row[7].Value);

            DataTable sacramentIncome = dh.getSacramentIncome(applicationID);

            lblPaymentFor.Text = type.ToString();
            lblOR.Text = dh.getNextOR(BookType.Parish).ToString();
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            lblPrice.Text = string.Format("{0:C}", double.Parse(sacramentIncome.Rows[0]["price"].ToString()));
            remainingBalance = dh.getBalanceOfSacramentIncome(sacramentIncomeID);
            lblBalance.Text = string.Format("{0:C}", remainingBalance);

            dgvPaymentHistory.AutoGenerateColumns = false;
            dgvPaymentHistory.DataSource = dh.getPaymentHistory(sacramentIncomeID);

            nudPayment.Maximum = Convert.ToDecimal(remainingBalance);
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

            if (payment == 0)
            {
                Notification.Show(State.PaymentZero);
                return;
            }

            if (Convert.ToInt32(nudPayment.Value) < 0)
            {
                Notification.Show(State.NegativePrice);
                return;
            }


            uint ORnum = uint.Parse(lblOR.Text);
            string remarks = txtRemarks.Text;
            DateTime dt = DateTime.ParseExact(lblDate.Text, "yyyy-MM-dd", null);
            bool success = dh.addSacramentPayment(sacramentIncomeID, payment, int.Parse(lblOR.Text), txtRemarks.Text, dt);

            if (success)
                Notification.Show(State.PaymentSuccess);
            else
                Notification.Show(State.PaymentFail);

            this.Close();
        }

        private void dgvPaymentHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                e.Value = Convert.ToDouble(e.Value).ToString("C");
            }
        }

        private void nudPayment_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(nudPayment.Value) > remainingBalance)
                nudPayment.Value = (decimal)remainingBalance;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nudPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Oemplus)
                e.SuppressKeyPress = true;
        }

        private void nudPayment_Leave(object sender, EventArgs e)
        {
            if (nudPayment.Text.Length == 0)
                nudPayment.Text = "0";
        }
    }
}
