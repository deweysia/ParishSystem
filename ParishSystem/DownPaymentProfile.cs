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
    public partial class DownPaymentProfile : Form
    {
        DataHandler dh;
        public DownPaymentProfile(DataHandler dh)
        {
            InitializeComponent();
            this.dh = dh;
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textbox_Enter(object sender, EventArgs e)
        {
            TextBox A = sender as TextBox;
            if (A.Name.Split('_')[0].ToUpper() == A.Text.ToUpper())
            {
                A.Clear();
                A.ForeColor = Color.Black;
            }
            
        }

        public string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        private void textbox_Leave(object sender, EventArgs e)
        {
            TextBox A = sender as TextBox;
            if (A.Text.Trim()=="")
            {
                A.Text = FirstLetterToUpper(A.Name.Split('_')[0]);
                A.ForeColor = Color.Gray;
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            if ((firstname_textbox.Text.ToUpper() != firstname_textbox.Name.Split('_')[0].ToUpper()) && (mi_textbox.Text.ToUpper() != mi_textbox.Name.Split('_')[0].ToUpper()))
            {
                string a = (firstname_textbox.Text.ToUpper() == firstname_textbox.Name.Split('_')[0].ToUpper() ? null: firstname_textbox.Text);
                string b = (mi_textbox.Text.ToUpper() == mi_textbox.Name.Split('_')[0].ToUpper() ? null: mi_textbox.Text);
                string c = (lastname_textbox.Text.ToUpper() == lastname_textbox.Name.Split('_')[0].ToUpper() ? null:lastname_textbox.Text);
                string d = (sf_textbox.Text.ToUpper() == sf_textbox.Name.Split('_')[0].ToUpper() ? null: sf_textbox.Text );
                dh.addDownPaymentProfile(a, b, c, d, address_textbox.Text, contactNumber_textbox.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("shunga");
            }
        }
    }
}
