using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;

namespace ParishSystem
{
    public partial class AddMarriageApplication : Form
    {
        DataHandler dh;
        DataTable sacramentItem;

        
        public AddMarriageApplication()
        {
            InitializeComponent();
            this.dh = DataHandler.getDataHandler();

            Draggable draggable = new Draggable(this);
            draggable.makeDraggable(panel1);

            sacramentItem = dh.getItem(SacramentType.Marriage.ToString());
            nudPrice.Maximum = Int32.MaxValue;
            nudPrice.Text = sacramentItem.Rows[0]["suggestedPrice"].ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void application_remarks_textBox_Click(object sender, EventArgs e)
        {

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (txtGroomFN.Text=="First Name"||txtGroomMI.Text=="Mi"||txtGroomLN.Text=="Last Name"||
                txtBrideFN.Text == "First Name" || txtBrideMI.Text == "Mi" || txtGroomLN.Text == "Last Name" )
            {
                Notification.Show(State.MissingFields);
                return;
            }
            
            string gFN = txtGroomFN.Text;
            string gMI = txtGroomMI.Text;
            string gLN = txtGroomLN.Text;
            string gSuffix = (txtGroomSuffix.Text == "Sf" ? null : txtGroomSuffix.Text);
            DateTime gBD = dtpGroomBirthDate.Value;
            Gender gG = Gender.Male;

            string bFN = txtBrideFN.Text;
            string bMI = txtBrideMI.Text;
            string bLN = txtBrideLN.Text;
            string bSuffix = (txtBrideSuffix.Text == "Sf" ? null : txtBrideSuffix.Text);
            DateTime bBD = dtpBrideBirthDate.Value;
            Gender bG = Gender.Female;

            int gID = dh.getGeneralProfileID(gFN, gMI, gLN, gSuffix, gG, gBD);
            int bID = dh.getGeneralProfileID(bFN, bMI, bLN, bSuffix, bG, bBD);

            
            //Check if either bride or groom has a pending application
            if(dh.hasApplication(gID, SacramentType.Marriage, ApplicationStatus.Pending))
            {
                Notification.Show(State.GroomApplicationExists);
                return;
            }
            else if(dh.hasApplication(bID, SacramentType.Marriage, ApplicationStatus.Pending))
            {
                Notification.Show(State.BrideApplicationExists);
                return;
            }

            bool success;
            if (gID != -1 && bID != -1)
            {
                //Check if they're in the same marriage already
                success = dh.addNewMarriageApplicants(gID, bID);
            }
            else if (gID != -1)
            {
                dh.addGeneralProfile(bFN, bMI, bLN, bSuffix, bG, bBD);
                bID = dh.getLatestID("GeneralProfile", "profileID");
                
                success = dh.addNewMarriageApplicants(bID, gID);
            }
            else if (bID != -1)
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
            double price = double.Parse(nudPrice.Text.ToString());

            success &= dh.addSacramentIncome(applicationID, price, txtRemarks.Text);

            if (success)
                Notification.Show(State.ApplicationApproveSuccess);
            else
                Notification.Show(State.ApplicationApproveFail);

            this.Close();

        }

        


        private void AddMarriageApplication_Load(object sender, EventArgs e)
        {
            


        }

        private void close_picturebox_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void name_textBox_Leave(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text.Trim().Length == 0)
            {
                t.Text = t.Tag.ToString();
                t.ForeColor = Color.Gray;
            }
        }
        private void name_textBox_Enter(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.ForeColor == Color.Gray)
            {
                t.Text = "";
                t.ForeColor = Color.Black;
            }
        }

        private void AddMarriageApplication_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    this.Left += e.X - lastClick.X;
            //    this.Top += e.Y - lastClick.Y;
            //}
        }

        private void AddMarriageApplication_MouseDown(object sender, MouseEventArgs e)
        {
            //lastClick = new Point(e.X, e.Y);
        }

        private void AddMarriageApplication_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void nudPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Oemplus)
                e.SuppressKeyPress = true;
        }
        private void nudPrice_Leave(object sender, EventArgs e)
        {
            if (nudPrice.Text.Length == 0)
                nudPrice.Text = "0";
        }
    }
}
