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
    public partial class AddMarriageApplication : Form
    {
        DataHandler dh;

        DataTable sacramentItem;
        public AddMarriageApplication(DataHandler dh)
        {
            InitializeComponent();
            this.dh = dh;
            
            sacramentItem = dh.getItem(SacramentType.Marriage.ToString());
            txtPrice.Text = sacramentItem.Rows[0]["suggestedPrice"].ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void application_remarks_textBox_Click(object sender, EventArgs e)
        {

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!allFilled())
            {
                Notification.Show("Please fill in all required details!", NotificationType.info);
                return;
            }

            string gFN = txtGroomFN.Text;
            string gMI = txtGroomMI.Text;
            string gLN = txtGroomLN.Text;
            string gSuffix = txtGroomSuffix.Text;
            DateTime gBD = dtpGroomBirthDate.Value;
            Gender gG = Gender.Male;

            string bFN = txtBrideFN.Text;
            string bMI = txtBrideMI.Text;
            string bLN = txtBrideLN.Text;
            string bSuffix = txtBrideSuffix.Text;
            DateTime bBD = dtpBrideBirthDate.Value;
            Gender bG = Gender.Female;

            int gID = dh.getGeneralProfileID(gFN, gMI, gLN, gSuffix, gG, gBD);
            int bID = dh.getGeneralProfileID(bFN, bMI, bLN, bSuffix, bG, bBD);

            
            

            bool success;
            if (gID != -1 && bID != -1)
            {
                //Check if they're in the same marriage already
                success = dh.addNewMarriageApplicants(gID, bID);
                
            }else if (gID != -1)
            {
                dh.addGeneralProfile(bFN, bMI, bLN, bSuffix, bG, bBD);
                bID = dh.getLatestID("GeneralProfile", "profileID");

                success = dh.addNewMarriageApplicants(bID, gID);

            }else if (bID != -1)
            {
                dh.addGeneralProfile(gFN, gMI, gLN, gSuffix, gG, gBD);
                gID = dh.getLatestID("GeneralProfile", "profileID");

                success = dh.addNewMarriageApplicants(bID, gID);
            }
            else
            {
                dh.addGeneralProfile(gFN, gMI, gLN, gSuffix, gG, gBD);
                gID = dh.getLatestID("GeneralProfile", "profileID");
                dh.addGeneralProfile(bFN, bMI, bLN, bSuffix, bG, bBD);
                bID = dh.getLatestID("GeneralProfile", "profileID");

                success = dh.addNewMarriageApplicants(gID, bID);
            }

            int applicationID = dh.getLatestID("Application", "applicationID");

            int itemTypeID = int.Parse(sacramentItem.Rows[0]["itemTypeID"].ToString());
            double price = double.Parse(txtPrice.Text.ToString());

            success &= dh.addSacramentIncome(applicationID, itemTypeID, price, txtRemarks.Text);

            if (success)
                Notification.Show("Successfully added marriage application!", NotificationType.success);
            else
                Notification.Show("Something went wrong!", NotificationType.error);

            this.Close();

        }

        private bool allFilled()
        {
            bool allFilled = true;
            foreach(Control c in this.Controls)
            {
                if(c is TextBox && c.Tag == null)
                {
                    TextBox t = c as TextBox;
                    allFilled &= !string.IsNullOrWhiteSpace(t.Text);
                    if (!allFilled)
                        return false;
                }
            }

            return allFilled;
        }


        private void AddMarriageApplication_Load(object sender, EventArgs e)
        {
            


        }
    }
}
