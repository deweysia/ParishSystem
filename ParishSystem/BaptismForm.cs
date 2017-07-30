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
    public partial class BaptismForm : Form
    {

        DataHandler dh;
        public BaptismForm(DataHandler dh)
        {
            this.dh = dh;
            InitializeComponent();
        }

        private void BaptismForm_Load(object sender, EventArgs e)
        {
            legitimacyCBox.DataSource = Enum.GetValues(typeof(Enums.Legitimacy));
            DataTable dt = dh.getMinisterWithStatus(MinisterStatus.Active);
            
            foreach(DataRow r in dt.Rows)
            {
                MinisterCBox.Items.Add(r["name"].ToString());
            }
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
