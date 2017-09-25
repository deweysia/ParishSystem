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
            Draggable draggable = new Draggable(this);
            draggable.makeDraggable(controlBar_panel);
            or_label.Text = OR.ToString();

            details_dgv.DataSource = dh.getORdetails(BookType,OR);
            foreach(DataGridViewColumn dc in details_dgv.Columns)
            {
                dc.Visible = false;
            }
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

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
    }
}
