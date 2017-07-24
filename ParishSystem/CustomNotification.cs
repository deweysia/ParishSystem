using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ParishSystem
{
    public partial class CustomNotification : Form
    {

        public CustomNotification()
        {
            InitializeComponent();
            messageLabel.MaximumSize = this.Size - this.Padding.Size;
            
        }

        public void ShowNotif(string message, NotificationType type)
        {
            switch (type)
            {
                case NotificationType.success:
                    this.BackColor = Color.FromArgb(223, 240, 216);
                    messageLabel.ForeColor = Color.FromArgb(60, 118, 61);
                    pictureBox1.Image = Properties.Resources.Ok_32px;
                    break;
                case NotificationType.warning:
                    this.BackColor = Color.FromArgb(252, 248, 227);
                    messageLabel.ForeColor = Color.FromArgb(138, 109, 59);
                    pictureBox1.Image = Properties.Resources.Error_32px;
                    break;
                case NotificationType.error:
                    this.BackColor = Color.FromArgb(242, 222, 222);
                    messageLabel.ForeColor = Color.FromArgb(169, 68, 66);
                    pictureBox1.Image = Properties.Resources.Cancel_32px;
                    break;
                default: //NotificationType.info
                    this.BackColor = Color.FromArgb(217, 237, 247);
                    messageLabel.ForeColor = Color.FromArgb(49, 112, 143);
                    pictureBox1.Image = Properties.Resources.Info_32px;
                    break;
            }
            messageLabel.Text = message;

            this.Show();
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            this.Top = -60;
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 60;
            interval = 0;
            startTimer.Start();
        }

        


        int interval = 0;
        private void startTimer_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine(this.Top);
            if (this.Top >= 60)
            {
                startTimer.Stop();
                waitTimer.Start();
            }

            this.Top += interval;
            interval += 2;

        }

        private void stopTimer_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine("STOP TICK");
            if (this.Opacity == 0)
                this.Close();

            this.Opacity -= 0.05;
        }

        private void waitTimer_Tick(object sender, EventArgs e)
        {
            waitTimer.Stop();
            stopTimer.Start();
            //Console.WriteLine("WAIT TICK");
        }

        private void CustomNotification_MouseEnter(object sender, EventArgs e)
        {
            waitTimer.Stop();
            stopTimer.Stop();
            this.Opacity = 1;
            Console.WriteLine("MOUSE ENTER");
        }

        private void CustomNotification_MouseLeave(object sender, EventArgs e)
        {
            waitTimer.Start();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.Delete_32px_Light;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.Delete_32px_Gray;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.Delete_32px;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public enum NotificationType
    {
        success, info, warning, error
    }

    public static class Notification
    {
        public static void Show(string message, NotificationType type =  NotificationType.info)
        {
            CustomNotification notif = new CustomNotification();
            notif.ShowNotif(message, type);
        }
    }
}
