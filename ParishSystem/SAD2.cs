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
    public partial class SAD2 : Form
    {

        DataHandler dh = DataHandler.getDataHandler();
        Point lastClick;

        Dictionary<Button, Panel> navigation = new Dictionary<Button, Panel>();
        //Dictionary<Panel, Form> forms = new Dictionary<Panel, Form>();
        public SAD2()
        {
            InitializeComponent();
            //Add dictionary for navigation buttons
            navigation.Add(home_button_menu, profile_panel);
            navigation.Add(profile_menu_button, profile_panel);
            navigation.Add(bloodletting_button_menu, bloodletting_panel);
            navigation.Add(CDB_button_menu, CDB_panel);
            navigation.Add(CRB_button_menu, CRB_panel);
            navigation.Add(application_button_menu, application_panel);
            navigation.Add(sacrament_button_menu, sacrament_panel);
            navigation.Add(scheduling_button_menu, schedule_panel);

            

            
        }

        #region Effects
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        /// <summary>
        /// Changes panel based on Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void home_button_menu_Click(object sender, EventArgs e)
        {
            Button A = sender as Button;
            navigation[A].BringToFront();
        }

        #endregion


        #region Form
        //-------------------------Main Form---------------------------//

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Max_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel_controlbox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastClick.X;
                this.Top += e.Y - lastClick.Y;
            }
        }

        private void panel_controlbox_MouseDown(object sender, MouseEventArgs e)
        {
            lastClick = new Point(e.X, e.Y);
        }

        #endregion


        private void showForm(object sender, Form f)
        {
            Panel s = sender as Panel;
            f.TopLevel = false;
            f.AutoScroll = true;
            s.Controls.Add(f);

            f.FormBorderStyle = FormBorderStyle.None;
            
            f.Dock = DockStyle.Fill;
            f.Show();
        }

        private void application_panel_VisibleChanged(object sender, EventArgs e)
        {
            ApplicationModule f = new ApplicationModule(dh);
            showForm(sender, f);

        }

        private void profile_panel_VisibleChanged(object sender, EventArgs e)
        {
            ProfileModule f = new ProfileModule();
            showForm(sender, f);
        }

        private void sacrament_panel_VisibleChanged(object sender, EventArgs e)
        {
            SacramentModule f = new SacramentModule(dh);
            showForm(sender, f);
        }

        private void schedule_panel_VisibleChanged(object sender, EventArgs e)
        {
            ScheduleModule f = new ScheduleModule();
            showForm(sender, f);
        }

        private void CDB_panel_VisibleChanged(object sender, EventArgs e)
        {
            CDB_FullPayment_Module f = new CDB_FullPayment_Module(0);
            showForm(sender, f);
        }

        private void CRB_panel_VisibleChanged(object sender, EventArgs e)
        {
            CashRelease_Module f = new CashRelease_Module(0);
            showForm(sender, f);
        }

        private void home_panel_VisibleChanged(object sender, EventArgs e)
        {
            HomeModule f = new HomeModule();
            showForm(sender, f);
        }

        private void bloodletting_panel_VisibleChanged(object sender, EventArgs e)
        {
            Bloodletting_Module f = new Bloodletting_Module(0);
            showForm(sender, f);
        }
    }
}
