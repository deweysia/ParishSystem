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
        private enum CabinetModule
        {
            Application,
            Sacrament,
            Profile,
            Scheduling,
            Minister,
            Bloodletting_DonorMode_EventMode,
            CashReceipt_BookModeFullPay,
            ReceiptReports_Disbursement_Release_Parish_Community_Postulancy,
            CashDisbursement_CashRealeaseMode,
            ItemTypes_CashReceipt_CashDisbursement,
            BloodlettingReports,
            BloodDonors,
            BloodClaim,
            ClaimView,
            Employee
        }

        private Color ButtonPressed = Color.FromArgb(115,115,115);
        private Color ButtonBackColor = Color.Transparent;
        private DataHandler dh = DataHandler.getDataHandler();

        private Dictionary<CabinetModule, Form> modules = new Dictionary<CabinetModule, Form>();
        private Dictionary<Button, Panel_Size_Pair> SubMenu = new Dictionary<Button, Panel_Size_Pair>();
        int UserID=-1;
        public SAD2()
        {
            InitializeComponent();
            addModules();
            UserID = 1;

        }

        private void addModules()
        {
            //Sacrament Module
            modules.Add(CabinetModule.Application, new ApplicationModule());
            modules.Add(CabinetModule.Scheduling, new ScheduleModule());
            modules.Add(CabinetModule.Sacrament, new SacramentModule());
            modules.Add(CabinetModule.Profile, new ProfileModule());
            modules.Add(CabinetModule.Minister, new MinisterModule());

            //Bloodletting Module
            modules.Add(CabinetModule.Bloodletting_DonorMode_EventMode, new Bloodletting_Module(1));
            modules.Add(CabinetModule.BloodClaim, new BloodClaim());
            modules.Add(CabinetModule.BloodlettingReports, new BloodlettingReports_Module());

            //Cash Module
            modules.Add(CabinetModule.CashDisbursement_CashRealeaseMode, new CashDisbursment(1));
            modules.Add(CabinetModule.ItemTypes_CashReceipt_CashDisbursement, new ItemTypes_Module(1));
            modules.Add(CabinetModule.CashReceipt_BookModeFullPay, new CashReciept(1));
            modules.Add(CabinetModule.ReceiptReports_Disbursement_Release_Parish_Community_Postulancy, new CashReport_Module(1, 1));

            modules.Add(CabinetModule.Employee, new EmployeeModule());
            
            
        }

        public SAD2(string  Username) : this()
        {
            this.username_Welcome_Text.Text = Username.ToUpper();
            this.UserID = int.Parse(dh.getEmployee(Username).Rows[0]["employeeID"].ToString());
        }

        private void SAD2_Load(object sender, EventArgs e)
        {
            Draggable drag = new Draggable(this);
            drag.makeDraggable(panel_controlbox);
            drag.makeDraggable(panel2);

            SubMenu.Add(sacrament_cabinet, new Panel_Size_Pair(255, 50,sacrament_cabinet_panel,false));
            SubMenu.Add(cash_cabinet, new Panel_Size_Pair(295, 50, cash_cabinet_panel, false));
            SubMenu.Add(bloodletting_cabinet, new Panel_Size_Pair(285, 50, bloodletting_cabinet_panel, false));
            SubMenu.Add(admin_cabinet, new Panel_Size_Pair(155, 50, admin_cabinet_panel, false));

          
            menu_flowlayout.HorizontalScroll.Maximum = 0;
            menu_flowlayout.AutoScroll = false;
            menu_flowlayout.VerticalScroll.Visible = false;
            menu_flowlayout.HorizontalScroll.Visible = false;
            menu_flowlayout.AutoScroll = true;

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
        int Menu_velocity = 1;
        bool Menu_open = true;
        private void MenuTimer_Tick(object sender, EventArgs e)
        {
            this.Update();
            if (!Menu_open)//menuopen== false 
            {
                if (Menu_panel.Size.Width < 232)
                {
                    Menu_panel.Size =  new Size(Menu_panel.Size.Width+Menu_velocity, Menu_panel.Size.Height);
                    Menu_panel.BackColor = Color.FromArgb(Menu_panel.BackColor.R-2, Menu_panel.BackColor.B-2, Menu_panel.BackColor.G-2);
                    Menu_velocity++;
                }
                else
                {
                    Menu_panel.Size = new Size(232, Menu_panel.Size.Height);
                    MenuTimer.Stop();
                    Menu_velocity = 0;
                    Menu_open = true;
                    OpenMenu_button.Enabled = true;
                    Menu_panel.BackColor = Color.FromArgb(65,65,65);
                }
            }
            else
            {
                if (Menu_panel.Size.Width > 0)
                {
                    Menu_panel.Size = new Size(Menu_panel.Size.Width- Menu_velocity, Menu_panel.Size.Height);
                    Menu_panel.BackColor = Color.FromArgb(Menu_panel.BackColor.R + 4, Menu_panel.BackColor.B + 4, Menu_panel.BackColor.G + 4);
                    Menu_velocity++;
                }
                else
                {
                    Menu_panel.Size = new Size(0 , Menu_panel.Size.Height);
                    MenuTimer.Stop();
                    Menu_velocity = 0;
                    Menu_open = false;
                    OpenMenu_button.Enabled = true;
                    Menu_panel.BackColor = Color.FromArgb(115,115,115);
                }
            }
        }
       
        private void OpenMenu_button_Click(object sender, EventArgs e)
        {
            MenuTimer.Start();
            OpenMenu_button.Enabled = false;
        }

        int temp_openSize;
        int temp_closeSize;
        Panel temp_panel;
        bool temp_open;
        private void SubmenuOpen_Click(object sender, EventArgs e)
        {
            menu_flowlayout.Enabled = false;
            Button c= new Button();
            if (sender is Button)
            {
                temp_panel = SubMenu[sender as Button].panel;
                c = sender as Button;
            }
            else if (sender is Label)
            {
                temp_panel=((Panel)((Label)sender).Parent);
                foreach (KeyValuePair<Button, Panel_Size_Pair> pair in SubMenu)
                {
                    if (pair.Value.panel == temp_panel)
                    {
                        c = pair.Key;
                    }

                }
            }
            else
            {
                temp_panel = sender as Panel;
                foreach(KeyValuePair<Button,Panel_Size_Pair> pair in SubMenu)
                {
                    if (pair.Value.panel == sender as Panel)
                    {
                        c = pair.Key;
                    }
                    
                }
            }
            temp_openSize = SubMenu[c].OpenSize;
            temp_closeSize = SubMenu[c].CloseSize;
            temp_open = SubMenu[c].open;
            SubMenu[c].open = !temp_open;
            Panel_Timer.Start();
        }

        int subPanel_velocity = 1;
        private void Panel_Timer_Tick(object sender, EventArgs e)
        {
            if (temp_open)
            {
                if (temp_panel.Size.Height > temp_closeSize)
                {
                    temp_panel.Size = new Size(temp_panel.Size.Width, temp_panel.Size.Height - subPanel_velocity);
                    subPanel_velocity++;
                }
                else
                {
                    temp_panel.Size = new Size(temp_panel.Size.Width, temp_closeSize);
                    Panel_Timer.Stop();
                    subPanel_velocity = 0;
                    menu_flowlayout.Enabled = true;
                }
            }
            else
            {
                if (temp_panel.Size.Height < temp_openSize)
                {
                    temp_panel.Size = new Size(temp_panel.Size.Width, temp_panel.Size.Height + subPanel_velocity);
                    subPanel_velocity++;
                }
                else
                {
                    temp_panel.Size = new Size(temp_panel.Size.Width, temp_openSize);
                    Panel_Timer.Stop();
                    subPanel_velocity = 0;
                    menu_flowlayout.Enabled = true;
                }
            }
        }

        private void btn_Close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void closeAllSubMenu()
        {
         
        }

        private void resetButtonColors()
        {
            scheduling_button_menu.BackColor = ButtonBackColor;
            sacrament_button_menu.BackColor = ButtonBackColor;
            profile_menu_button.BackColor = ButtonBackColor;
            application_button_menu.BackColor = ButtonBackColor;
            CRB_button_menu.BackColor = ButtonBackColor;
            CRBreport_button.BackColor = ButtonBackColor;
            CDBreport_button.BackColor = ButtonBackColor;
            CDB_button_menu.BackColor = ButtonBackColor;
            itemtypemenu_button.BackColor = ButtonBackColor;
            bloodlettingdonor_button.BackColor = ButtonBackColor;
            bloodlettingevent_button.BackColor = ButtonBackColor;
            bloodlettingreport_button.BackColor = ButtonBackColor;
            bloodClaim_menu_button.BackColor = ButtonBackColor;
            bloodClaimView_menu_button.BackColor = ButtonBackColor;
            Employee_button_menu.BackColor = ButtonBackColor;
            ministers_button_menu.BackColor = ButtonBackColor;
            
        }
        private void button_menu_MouseDown(object sender, MouseEventArgs e)
        {
            resetButtonColors();
            ((Button)sender).BackColor = ButtonPressed;
            OpenMenu_button.PerformClick();
        }

        private void scheduling_button_menu_Click(object sender, EventArgs e)
        {
            Form A = modules[CabinetModule.Scheduling];
            showForm(content_panel,A);
        }

        private void sacrament_button_menu_Click(object sender, EventArgs e)
        {
            Form A = modules[CabinetModule.Sacrament];
            showForm(content_panel, A);
        }

        private void profile_menu_button_Click(object sender, EventArgs e)
        {
            Form A = modules[CabinetModule.Profile];
            showForm(content_panel, A);
        }

        private void application_button_menu_Click(object sender, EventArgs e)
        {
            Form A = modules[CabinetModule.Application];
            showForm(content_panel, A);
        }

        private void CRB_button_menu_Click(object sender, EventArgs e)
        {
            //Form A = new CashReciept(1);
            Form A = modules[CabinetModule.CashReceipt_BookModeFullPay];
            showForm(content_panel, A);
        }

        private void CRBreport_button_Click(object sender, EventArgs e)
        {
            //Form A = new CashReport_Module(2,1);
            Form A = modules[CabinetModule.ReceiptReports_Disbursement_Release_Parish_Community_Postulancy];
            showForm(content_panel, A);
        }

        private void CDB_button_menu_Click(object sender, EventArgs e)
        {
            //Form A = new CashDisbursment(1);
            Form A = modules[CabinetModule.CashDisbursement_CashRealeaseMode];
            showForm(content_panel, A);
        }

        private void CDBreport_button_Click(object sender, EventArgs e)
        {
            //Form A = new CashReport_Module(1, 1);
            Form A = modules[CabinetModule.ReceiptReports_Disbursement_Release_Parish_Community_Postulancy];
            showForm(content_panel, A);
        }
        private void itemtypemenu_button_Click(object sender, EventArgs e)
        {
            //Form A = new ItemTypes_Module(1);
            Form A = modules[CabinetModule.ItemTypes_CashReceipt_CashDisbursement];
            showForm(content_panel, A);
        }

        private void bloodlettingreport_button_Click(object sender, EventArgs e)
        {
            //Form A = new BloodlettingReports_Module();
            Form A = modules[CabinetModule.BloodlettingReports];
            showForm(content_panel, A);
        }

        private void bloodlettingevent_button_Click(object sender, EventArgs e)
        {
            //Form A = new Bloodletting_Module(2);
            Form A = modules[CabinetModule.Bloodletting_DonorMode_EventMode];
            showForm(content_panel, A);
        }

        private void bloodlettingdonor_button_Click(object sender, EventArgs e)
        {
            //Form A = new Bloodletting_Module(1);
            Form A = modules[CabinetModule.Bloodletting_DonorMode_EventMode];
            showForm(content_panel, A);
        }

        private void ministers_button_menu_Click(object sender, EventArgs e)
        {
            //Form A = new MinisterModule();
            Form A = modules[CabinetModule.Minister];
            showForm(content_panel, A);
        }

        private void Employee_button_menu_Click(object sender, EventArgs e)
        {
            //Form A = new EmployeeModule();
            Form A = modules[CabinetModule.Employee];
            showForm(content_panel, A);
        }
        private void bloodClaim_menu_button_Click(object sender, EventArgs e)
        {
            //Form A = new BloodClaim();
            Form A = modules[CabinetModule.BloodClaim];
            showForm(content_panel, A);
        }
        private void bloodClaimView_menu_button_Click(object sender, EventArgs e)
        {
            //Form A = new BloodClaimView();
            Form A = modules[CabinetModule.BloodClaim];
            showForm(content_panel, A);
        }
        private void logout_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flowLayout_ControlButtons_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            
        }

        private void content_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!Menu_panel.Bounds.Contains(e.Location))
            {
                OpenMenu_button.PerformClick();
            }
        }


    }
}