using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ParishSystem
{

    public class State
    {
        public string Message;
        public NotificationType Type;
        public State(string msg, NotificationType t)
        {
            this.Message = msg;
            this.Type = t;
        }

        
        public static State
            MissingFields = new State("Please fill in all necessary fields", NotificationType.info),
            GenericError = new State("Something went wrong", NotificationType.error),
            ProfileExists = new State("This profile already exists in the system", NotificationType.error),
            GroomExists = new State("Groom profile already exists in the system", NotificationType.error),
            BrideExists = new State("Bride profile already exists in the system", NotificationType.error),
            PaymentSuccess = new State("Payment successful", NotificationType.success),
            PaymentFail = new State("Payment failed", NotificationType.error),
            TransactionSuccess = new State("Transaction successful", NotificationType.success),
            TransactionFail = new State("Transaction Failed", NotificationType.error);
    }

    public static class SystemNotification
    {
        public static void Notify(State ss)
        {
            Notification.Show(ss.Message, ss.Type);
        }
    }


    

    
}
