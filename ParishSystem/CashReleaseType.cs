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
    public partial class CashReleaseType : Form
    {
        int cashID;
        DataHandler dh;

        public CashReleaseType(DataHandler dh)
        {
            InitializeComponent();
            this.dh = dh;
        }

        public CashReleaseType(int cashReleaseID,DataHandler dh)
        {
            InitializeComponent();
            this.dh = dh;
            this.cashID = cashReleaseID;
        }

        private void CashRelease_Load(object sender, EventArgs e)
        {
            //DataTable dt = dh.getCashRelease(cashID);
            //name_textbox.Text = dt.Rows[0]["cashReleaseType"].ToString();
            //des
            refreshCashRelease();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
                if(name_textbox.Text.Trim()=="" ||
                   book_combobox.Text.Trim() == "")
                {
                Notification.Show(State.MissingFields);
                }
                else
                {
                    if (cashID == 0)
                    {
                        dh.addCashReleaseType(name_textbox.Text, details_textbox.Text,active_button.Checked,book_combobox.SelectedIndex);
                        cashID = dh.getMaxCashReleaseType();
                    }
                    else
                    {
                        dh.editCashReleaseType(cashID, name_textbox.Text, details_textbox.Text, active_button.Checked, book_combobox.SelectedIndex);
                    }
                this.Close();
            }
                
            
        }

        public void refreshCashRelease()
        {
            if (cashID != 0)
            {
                DataTable dt = dh.getCashRelease(cashID);
                name_textbox.Text = dt.Rows[0]["cashReleaseType"].ToString();
                details_textbox.Text = dt.Rows[0]["description"].ToString();
                book_combobox.SelectedIndex = int.Parse(dt.Rows[0]["bookType"].ToString());
                if (dt.Rows[0]["status"].ToString() == "1")
                    active_button.Checked = true;
                else
                    active_button.Checked = false;
            }
            else
            {
                name_textbox.Text = "";
                details_textbox.Text = "";
                active_button.Checked = true;
            }
            
        }

        private void active_button_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            refreshCashRelease();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
