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
        int OR=0;
        int CN;
        int CV;
        int BookType;

        DataHandler dh;
        public ORdetailsPopUp(int OR,int BookType,DataHandler dh)
        {
            InitializeComponent();
            this.OR = OR;
            this.dh = dh;
            this.BookType = BookType;
            CV_label.Visible = false;
            CN_label.Visible = false;
            checkVoucherTextLabel.Visible = false;
            checkNumberTextLabel.Visible = false;

        }
        public ORdetailsPopUp(int CN,int CV, int BookType, DataHandler dh)
        {
            InitializeComponent();
            this.CN = CN;
            this.CV = CV;
            this.dh = dh;
            this.BookType = BookType;
            ORTextLabel.Visible = false;
            or_label.Visible = false;
        }
        private void ORdetailsPopUp_Load(object sender, EventArgs e)
        {
            Draggable draggable = new Draggable(this);
            draggable.makeDraggable(controlBar_panel);
            or_label.Text = OR.ToString();

            if (OR!=0)
            {
                details_dgv.DataSource = dh.getORdetails(BookType, OR);
                foreach (DataGridViewColumn dc in details_dgv.Columns)
                {
                    dc.Visible = false;
                }
                float sum = 0;
                foreach (DataGridViewRow dgvr in details_dgv.Rows)
                {
                    sum += float.Parse(dgvr.Cells["total"].Value.ToString());
                }
                total_label.Text = sum.ToString("0.00");

                source_name.Text = details_dgv.Rows[0].Cells["sourceName"].Value.ToString();
                or_label.Text = details_dgv.Rows[0].Cells["ORnum"].Value.ToString();
                datepaid_label.Text = details_dgv.Rows[0].Cells["primaryIncomeDateTime"].Value.ToString();
                remarks_textbox.Text = details_dgv.Rows[0].Cells["remarks"].Value.ToString();
                details_dgv.Columns["sourceName"].Visible = false;
                details_dgv.Columns["ORnum"].Visible = false;
                details_dgv.Columns["primaryIncomeDateTime"].Visible = false;
                details_dgv.Columns["remarks"].Visible = false;

                details_dgv.Columns["price"].Visible = true;
                details_dgv.Columns["quantity"].Visible = true;
                details_dgv.Columns["total"].Visible = true;
                details_dgv.Columns["itemType"].Visible = true;

                details_dgv.Columns["price"].HeaderText = "Price";
                details_dgv.Columns["quantity"].HeaderText = "Quantity";
                details_dgv.Columns["total"].HeaderText = "Total";
                details_dgv.Columns["itemType"].HeaderText = "Item";

            }
            else
            {
                details_dgv.DataSource = dh.getCVdetails(BookType,CV);
                foreach (DataGridViewColumn dc in details_dgv.Columns)
                {
                    dc.Visible = false;
                }
                float sum = 0;
                foreach (DataGridViewRow dgvr in details_dgv.Rows)
                {
                    sum += float.Parse(dgvr.Cells["releaseAmount"].Value.ToString());
                }
                total_label.Text = sum.ToString("0.00");
                source_name.Text = details_dgv.Rows[0].Cells["name"].Value.ToString();
                CN_label.Text = details_dgv.Rows[0].Cells["checknum"].Value.ToString();
                CV_label.Text = details_dgv.Rows[0].Cells["CVnum"].Value.ToString();
                datepaid_label.Text = details_dgv.Rows[0].Cells["cashReleaseDateTime"].Value.ToString();
                remarks_textbox.Text = details_dgv.Rows[0].Cells["remark"].Value.ToString();
                details_dgv.Columns["name"].Visible = false;
                details_dgv.Columns["checkNum"].Visible = false;
                details_dgv.Columns["CVnum"].Visible = false;
                details_dgv.Columns["cashReleaseDateTime"].Visible = false;
                details_dgv.Columns["remark"].Visible = false;
                foreach (DataGridViewColumn dgvr in details_dgv.Columns)
                {
                    dgvr.Visible = false;
                 }
                details_dgv.Columns["releaseAmount"].Visible = true;
                details_dgv.Columns["itemType"].Visible = true;
                details_dgv.Columns["releaseAmount"].HeaderText = "Caash Release Amount";
                details_dgv.Columns["itemType"].HeaderText = "Cash Item Type";
                /*
                details_dgv.Columns["price"].Visible = true;
                details_dgv.Columns["quantity"].Visible = true;
                details_dgv.Columns["total"].Visible = true;
                details_dgv.Columns["itemType"].Visible = true;

                details_dgv.Columns["price"].HeaderText = "Price";
                details_dgv.Columns["quantity"].HeaderText = "Quantity";
                details_dgv.Columns["total"].HeaderText = "Total";
                details_dgv.Columns["itemType"].HeaderText = "Item";
                */
            }
        }
        

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
    }
}
