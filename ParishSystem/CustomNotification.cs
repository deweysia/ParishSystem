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

            Draggable drag = new Draggable(this);
            drag.makeDraggable(this);
            drag.makeDraggable(messageLabel);
            drag.makeDraggable(pictureBox1);
            
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
            //MessageBox.Show("Huzzah!");
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
        private static void Notify(string message, NotificationType type =  NotificationType.info)
        {
            CustomNotification notif = new CustomNotification();
            notif.ShowNotif(message, type);
        }

        public static void Show(State ss)
        {
            Notify(ss.Message, ss.Type);
        }
    }


    public class State
    {
        public string Message;
        public NotificationType Type;
        private State(string msg, NotificationType t)
        {
            this.Message = msg;
            this.Type = t;
        }


        public static State
            invalidTime = new State("The time set is invalid", NotificationType.error),
            ItemTypeAdded = new State("Item Type has successfully been added", NotificationType.success),
            ChangesSaved = new State("Changes successfully saved", NotificationType.success),
            EventAdded = new State("Bloodletting event has been added", NotificationType.success),
            TransactionAdded = new State("Transaction successfully added", NotificationType.success),
            CannotDeleteBloodAlreadyClaimed = new State("Cannot delete blood donation that is already claimed", NotificationType.error),
            ItemTypeUsed = new State("This Item name is already used", NotificationType.error),
            BloodDonationIDUsed = new State("This Blood Donation ID is already used", NotificationType.error),
            PersonHasDonations = new State("Cannot delete person with donations", NotificationType.error),
            EventNameUsed = new State("Event name is already used", NotificationType.error),
            ExcelExported = new State("Excel file has been Exported", NotificationType.success),
            WrongCredentials = new State("Wrong username or password", NotificationType.warning),
            DuplicateUsername = new State("This username is taken", NotificationType.warning),
            InnvalidDononationID = new State("No donation ID was found", NotificationType.warning),
            InvalidTransaction = new State("Cannot add an entry with no items", NotificationType.warning),
            CannotDeleteBloodEvent = new State("Cannot delete blood donation events with donations", NotificationType.warning),
            MergingDone = new State("Merging Finished", NotificationType.warning),
            ProfileAdded = new State("Profile added", NotificationType.success),
            InvalidPayment = new State("The Price cannot be 0", NotificationType.error),
            InvalidPrice = new State("The Price cannot be lesser than the payment", NotificationType.error),
            HasTransaction = new State("This person already has a transaction", NotificationType.error),
            PaymentExceeded = new State("Selected payment has exceeded price", NotificationType.error),
            AlreadyPaid = new State("Person is already paid", NotificationType.error),
            InvalidContactNumber = new State("Contact number is Invalid", NotificationType.error),
            MissingPersonInCRB = new State("There is no person selected", NotificationType.error),
            MissingFields = new State("Please fill in all necessary fields", NotificationType.info),
            AddSuccess = new State("Entry successfully added", NotificationType.success),
            AddFail = new State("Entry failed to add", NotificationType.error),
            UpdateSuccess = new State("Changes successfully applied", NotificationType.success),
            UpdateFail = new State("Changes failed to apply", NotificationType.error),
            GenericError = new State("Something went wrong", NotificationType.error),
            ProfileExists = new State("This profile already exists in the system", NotificationType.error),
            GroomExists = new State("Groom profile already exists in the system", NotificationType.error),
            BrideExists = new State("Bride profile already exists in the system", NotificationType.error),
            PaymentSuccess = new State("Payment successful", NotificationType.success),
            PaymentFail = new State("Payment failed", NotificationType.error),
            PaymentZero = new State("Payment cannot be 0", NotificationType.warning),
            TransactionSuccess = new State("Transaction successful", NotificationType.success),
            TransactionFail = new State("Transaction failed", NotificationType.error),
            RevokeSucess = new State("Application has been revoked", NotificationType.success),
            RevokeFail = new State("Application revoke failed", NotificationType.error),
            ApplicationApproveSuccess = new State("Application successfully approved", NotificationType.success),
            ApplicationApproveFail = new State("Application approve failed", NotificationType.error),
            ApplicationExists = new State("Application already exists in the system", NotificationType.warning),
            ApplicationAddSuccess = new State("Application successfully added", NotificationType.success),
            ApplicationAddFail = new State("Application not added", NotificationType.warning),
            MinisterAddSuccess = new State("Minister successfully added", NotificationType.success),
            MinisterAddFail = new State("Minister was not added", NotificationType.warning),
            MinisterEditSuccess = new State("Minister changes successfully applied", NotificationType.success),
            MinisterEditFail = new State("Minister changes failed to apply", NotificationType.error),
            ScheduleMissingTitle = new State("Please add a title", NotificationType.info),
            ScheduleAddSuccess = new State("Successfully added to schedule", NotificationType.success),
            ScheduleAddFail = new State("Failed to add to schedule", NotificationType.error),
            ScheduleMinisterUnavailable = new State("The selected minister is currently unavailable", NotificationType.warning),
            GroomApplicationExists = new State("Groom already has an existing application", NotificationType.error),
            BrideApplicationExists = new State("Bride already has an existing application", NotificationType.error),
            ApplicationEditSuccess = new State("Application changes successfully applied", NotificationType.success),
            ApplicationEditFail = new State("Application changes failed to apply", NotificationType.error),
            NoMinisterSelected = new State("Please assign a minister to the appointment", NotificationType.warning),
            SacramentEditSuccess = new State("Successfully updated sacrament profile", NotificationType.success),
            SacramentEditFail = new State("Failed to update sacrament profile", NotificationType.error),
            NegativePrice = new State("Price cannot be zero", NotificationType.warning),
            UserUpdateSuccess = new State("User profile has successfully updated", NotificationType.success),
            UserUpdateFail = new State("User profile has failed to update", NotificationType.error),
            UserPasswordResetSuccess = new State("User password has successfully reset", NotificationType.success),
            UserPasswordResetFail = new State("User password has failed to reset", NotificationType.error);
    }
}
