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
    public partial class ORdetailsPopUp : Form
    {
        int OR;
        int BookType;
        DataHandler dh;
        public ORdetailsPopUp(int OR,int BookType,DataHandler dh)
        {
            InitializeComponent();
            this.OR = OR;
            this.dh = dh;
            this.BookType = BookType;
        }

        private void ORdetailsPopUp_Load(object sender, EventArgs e)
        {
            or_label.Text = OR.ToString();
           
                DataTable trial1 =dh.getItemsOfIncomeFromItems(int.Parse(or_label.Text),BookType);
                if (trial1.Rows.Count != 0)
            {
                items_dgv.DataSource = trial1;
                decimal total = 0;
                foreach (DataGridViewRow dgvr in items_dgv.Rows)
                {
                    total += decimal.Parse(dgvr.Cells["price"].Value.ToString());
                }
                total_label.Text = total.ToString();
            }
            else
            {
                DataTable trial2 = dh.getItemsOfIncomeFromSacramentIncome(int.Parse(or_label.Text),BookType);
                items_dgv.DataSource = trial2;
                decimal total = 0;
                foreach (DataGridViewRow dgvr in items_dgv.Rows)
                {
                    total += decimal.Parse(dgvr.Cells["amount"].Value.ToString());
                }
                total_label.Text = total.ToString();
            }

            

                
            
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void or_label_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void total_label_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
