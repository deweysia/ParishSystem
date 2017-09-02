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
        //#5587e0

        Color ButtonPressed = Color.FromArgb(68, 108, 179);
        Color ButtonBackColor = Color.Transparent;
        DataHandler dh = DataHandler.getDataHandler();
        Dictionary<Button, Panel_Size_Pair> SubMenu = new Dictionary<Button, Panel_Size_Pair>();
        int UserID=-1;
        public SAD2()
        {
            InitializeComponent();
        }//CRBreport_panel

        public SAD2(string  Username)
        {
            InitializeComponent();
            this.username_Welcome_Text.Text = Username.ToUpper();
            this.UserID = int.Parse(dh.getEmployee(Username).Rows[0]["employeeID"].ToString());
        }
        private void SAD2_Load(object sender, EventArgs e)
        {
            Draggable drag = new Draggable(this);
            drag.makeDraggable(panel_controlbox);
            drag.makeDraggable(panel2);

            SubMenu.Add(bloodletting_button_menu, new Panel_Size_Pair(234, 58, bloodlettingmenu_panel, false));
            SubMenu.Add(CRB_button_menu, new Panel_Size_Pair(234, 58, CRBmenu_panel, false));
            SubMenu.Add(CDB_button_menu, new Panel_Size_Pair(234, 58, CDB_menu_panel, false));
            SubMenu.Add(itemtypemenu_button, new Panel_Size_Pair(175, 58, itemtypemenu_panel, false));
            SubMenu.Add(CDBreport_button, new Panel_Size_Pair(234, 58, CDBreport_panel, false));
            SubMenu.Add(CRBreport_button, new Panel_Size_Pair(234, 58, CRBreport_panel, false));
        }
        #region Effects

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
        #endregion


        private void showForm(Panel sender, Form f)
        {
            sender.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            sender.Controls.Add(f);

            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            f.Show();
        }

        private void application_panel_VisibleChanged(object sender, EventArgs e)
        {
            // ApplicationModule f = new ApplicationModule(dh);
            // showForm(sender, f);

        }


        int coefficientOfChangeOfMenu = 1;//this for initial speed is for speed of timer, reset every stop
        private void MenuTimer_Tick(object sender, EventArgs e)
        {
            if (menuUp)
            {
                if (Menu_panel.Location.Y <= 0) { MenuTimer.Stop(); coefficientOfChangeOfMenu = 1; OpenMenu_button.Enabled = true; Menu_panel.BackColor = Color.FromArgb(115, 115, 115); menuUp = false; }
                else
                {
                    Menu_panel.Location = new Point(Menu_panel.Location.X, Menu_panel.Location.Y - coefficientOfChangeOfMenu);
                    Menu_panel.BackColor = Color.FromArgb(Menu_panel.BackColor.R - 4, Menu_panel.BackColor.G - 4, Menu_panel.BackColor.B - 4);
                    coefficientOfChangeOfMenu++;
                }
            }
            else
            {
                if (Menu_panel.Location.Y >= 545) { MenuTimer.Stop(); coefficientOfChangeOfMenu = 1; OpenMenu_button.Enabled = true; Menu_panel.BackColor = Color.FromArgb(255, 255, 255); menuUp = true; }
                else
                {
                    Menu_panel.Location = new Point(Menu_panel.Location.X, Menu_panel.Location.Y + coefficientOfChangeOfMenu);
                    Menu_panel.BackColor = Color.FromArgb(Menu_panel.BackColor.R + 3, Menu_panel.BackColor.G + 3, Menu_panel.BackColor.B + 3);
                    coefficientOfChangeOfMenu++;
                }
            }
        }
        bool menuUp = true;
        private void OpenMenu_button_Click(object sender, EventArgs e)
        {
            Menu_panel.BringToFront();
            OpenMenu_button.Enabled = false;
            MenuTimer.Start();

        }

        private void btn_Close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tile_Click(object sender, EventArgs e)
        {
            Button A = (sender as Button);
            opensize = SubMenu[A].OpenSize;
            closesize = SubMenu[A].CloseSize;
            PanelToMove = SubMenu[A].panel;
            open = SubMenu[A].open;
            SubMenu[A].open = !(SubMenu[A].open);
            Panel_Timer.Start();

        }
        int closesize = 0;
        int opensize = 0;
        Panel PanelToMove;
        bool open;
        int coefficientOfChangeOfPanel = 1;

        private void Panel_Timer_Tick(object sender, EventArgs e)
        {
            if (!open)
            {
                if (opensize >= PanelToMove.Height)
                {
                    PanelToMove.Height = PanelToMove.Height + coefficientOfChangeOfPanel;
                    coefficientOfChangeOfPanel++;

                }
                else
                {
                    Panel_Timer.Stop();
                    PanelToMove.Height = opensize;
                    coefficientOfChangeOfPanel = 1;
                }
            }
            else
            {

                if (PanelToMove.Height >= closesize)
                {
                    PanelToMove.Height = PanelToMove.Height - coefficientOfChangeOfPanel;
                    coefficientOfChangeOfPanel++;

                }
                else
                {
                    Panel_Timer.Stop();
                    PanelToMove.Height = closesize;
                    coefficientOfChangeOfPanel = 1;
                }
            }
        }



        private void SubMenuClick(object sender, MouseEventArgs e)
        {
            resetButtonColors();
            Button A = sender as Button;
            A.BackColor = ButtonPressed;
            OpenMenu_button.PerformClick();
            closeAllSubMenu();
        }

        private void closeAllSubMenu()
        {
            foreach (KeyValuePair<Button, Panel_Size_Pair> pair in SubMenu)
            {
                if ((pair.Value).open)
                {
                    pair.Key.PerformClick();
                }
            }
        }

        private void resetButtonColors()
        {
            application_button_menu.BackColor = ButtonBackColor;
            profile_menu_button.BackColor = ButtonBackColor;
            scheduling_button_menu.BackColor = ButtonBackColor;
            bloodlettingdonor_button.BackColor = ButtonBackColor;
            bloodlettingevent_button.BackColor = ButtonBackColor;
            bloodlettingreport_button.BackColor = ButtonBackColor;
            sacrament_button_menu.BackColor = ButtonBackColor;
            CRBparish_button_menu.BackColor = ButtonBackColor;
            CRBcommunity_button_menu.BackColor = ButtonBackColor;
            CRBpostulancy_button_menu.BackColor = ButtonBackColor;
            CDBparish_button_menu.BackColor = ButtonBackColor;
            CDBcommunity_button_menu.BackColor = ButtonBackColor;
            CDBpostulancy_button_menu.BackColor = ButtonBackColor;
            itemtypemenuCRB_button.BackColor = ButtonBackColor;
            itemtypemenuCDB_button.BackColor = ButtonBackColor;
            CDBreport_parish.BackColor = ButtonBackColor;
            CDBreport_community.BackColor = ButtonBackColor;
            CDBreport_postulancy.BackColor = ButtonBackColor;
            CRBparishreport_button.BackColor = ButtonBackColor;
            CRBcommunityreport_button.BackColor = ButtonBackColor;
            CRBpostulancyreport_button.BackColor = ButtonBackColor;
            itemtypemenu_button.BackColor = ButtonBackColor;
            CDB_button_menu.BackColor = ButtonBackColor;
            CRB_button_menu.BackColor = ButtonBackColor;
            bloodletting_button_menu.BackColor = ButtonBackColor;
            CRBreport_button.BackColor = ButtonBackColor;
            CDBreport_button.BackColor = ButtonBackColor;
            home_button_menu.BackColor = ButtonBackColor;
        }

        private void bloodlettingdonor_button_MouseClick(object sender, MouseEventArgs e)
        {
            bloodletting_button_menu.PerformClick();
            Bloodletting_Module f = new Bloodletting_Module(1);
            showForm(content_panel, f);
        }

        private void bloodlettingevent_button_MouseClick(object sender, MouseEventArgs e)
        {
            bloodletting_button_menu.PerformClick();
            Bloodletting_Module f = new Bloodletting_Module(2);
            showForm(content_panel, f);
        }

        private void bloodlettingreport_button_MouseClick(object sender, MouseEventArgs e)
        {
            bloodletting_button_menu.PerformClick();
            BloodlettingReports_Module f = new BloodlettingReports_Module();
            showForm(content_panel, f);
        }

        private void CRBparish_button_menu_MouseClick(object sender, MouseEventArgs e)
        {
            CRB_button_menu.PerformClick();
            CashDisbursment f = new CashDisbursment(1);
            showForm(content_panel, f);
        }

        private void CRBcommunity_button_menu_MouseClick(object sender, MouseEventArgs e)
        {
            CRB_button_menu.PerformClick();
            CashDisbursment f = new CashDisbursment(2);
            showForm(content_panel, f);
        }

        private void CRBpostulancy_button_menu_MouseClick(object sender, MouseEventArgs e)
        {
            CRB_button_menu.PerformClick();
            CashDisbursment f = new CashDisbursment(3);
            showForm(content_panel, f);
        }

        private void CDBparish_button_menu_MouseClick(object sender, MouseEventArgs e)
        {
            CDB_button_menu.PerformClick();
            CashReciept f = new CashReciept(1);
            showForm(content_panel, f);
        }

        private void CDBcommunity_button_menu_MouseClick(object sender, MouseEventArgs e)
        {
            CDB_button_menu.PerformClick();
            CashReciept f = new CashReciept(2);
            showForm(content_panel, f);
        }

        private void CDBpostulancy_button_menu_MouseClick(object sender, MouseEventArgs e)
        {
            CDB_button_menu.PerformClick();
            CashReciept f = new CashReciept(3);
            showForm(content_panel, f);
        }

        private void itemtypemenuCRB_button_MouseClick(object sender, MouseEventArgs e)
        {
            itemtypemenu_button.PerformClick();
            ItemTypes_Module f = new ItemTypes_Module(1);
            showForm(content_panel, f);
        }

        private void itemtypemenuCDB_button_MouseClick(object sender, MouseEventArgs e)
        {
            itemtypemenu_button.PerformClick();
            ItemTypes_Module f = new ItemTypes_Module(2);
            showForm(content_panel, f);
        }

        private void CDBreport_parish_MouseClick(object sender, MouseEventArgs e)
        {
            CDBreport_button.PerformClick();
            CashReport_Module f = new CashReport_Module(1, 1);
            showForm(content_panel, f);
        }

        private void CDBreport_community_MouseClick(object sender, MouseEventArgs e)
        {
            CDBreport_button.PerformClick();
            CashReport_Module f = new CashReport_Module(1, 2);
            showForm(content_panel, f);
        }

        private void CDBreport_postulancy_MouseClick(object sender, MouseEventArgs e)
        {
            CDBreport_button.PerformClick();
            CashReport_Module f = new CashReport_Module(1, 3);
            showForm(content_panel, f);
        }

        private void CRBparishreport_button_MouseClick(object sender, MouseEventArgs e)
        {
            CRBreport_button.PerformClick();
            CashReport_Module f = new CashReport_Module(2, 1);
            showForm(content_panel, f);
        }

        private void CRBcommunityreport_button_MouseClick(object sender, MouseEventArgs e)
        {
            CRBreport_button.PerformClick();
            CashReport_Module f = new CashReport_Module(2, 2);
            showForm(content_panel, f);
        }

        private void CRBpostulancyreport_button_MouseClick(object sender, MouseEventArgs e)
        {
            CRBreport_button.PerformClick();
            CashReport_Module f = new CashReport_Module(2, 3);
            showForm(content_panel, f);
        }


        private void application_button_menu_MouseUp(object sender, MouseEventArgs e)
        {
            ApplicationModule f = new ApplicationModule();
            showForm(content_panel, f);
        }

        private void profile_menu_button_MouseUp(object sender, MouseEventArgs e)
        {
            ProfileModule f = new ProfileModule();
            showForm(content_panel, f);
        }

        private void scheduling_button_menu_MouseUp(object sender, MouseEventArgs e)
        {
            ScheduleModule f = new ScheduleModule();
            showForm(content_panel, f);
        }

        private void sacrament_button_menu_MouseUp(object sender, MouseEventArgs e)
        {
            SacramentModule f = new SacramentModule();
            showForm(content_panel, f);
        }

        private void home_button_menu_MouseUp(object sender, MouseEventArgs e)
        {
            HomeModule f = new HomeModule();
            showForm(content_panel, f);
        }

        private void ministers_button_menu_MouseUp(object sender, MouseEventArgs e)
        {
            MinisterModule f = new MinisterModule();
            showForm(content_panel, f);
        }

        
    }
}