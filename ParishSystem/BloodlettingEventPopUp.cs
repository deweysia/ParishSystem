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
    public partial class BloodlettingEventPopUp : Form
    {
        int bloodlettingID;
        DataHandler dh;
        public BloodlettingEventPopUp(int bloodlettingID, DataHandler dh)
        {
            InitializeComponent();
            this.bloodlettingID = bloodlettingID;
            this.dh = dh;
        }
        
        private void BloodlettingEventPopUp_Load(object sender, EventArgs e)
        {
            
        }
    }
}
