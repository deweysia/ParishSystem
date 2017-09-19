using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParishSystem
{
    public class Privilege
    {
        public bool BloodlettingReport { get; }
        public bool CashReport { get; }
        public bool CashReportParish { get; }
        public bool CashReceipt { get; }
        public bool CashReceiptParish { get; }
        public bool CashDisbursement { get; }
        public bool Employee { get; }
        public bool Minister { get; }
        public bool Schedule { get; }
        public bool ItemType { get; }
        public bool Bloodletting { get; }

        public Privilege(UserPrivileges privileges)
        {
            if (privileges == UserPrivileges.Supervisor)
                this.BloodlettingReport =
                this.CashReport =
                this.CashReportParish =
                this.Employee =
                this.Minister =
                this.Schedule = true;
            else if (privileges == UserPrivileges.Treasurer)
                this.CashReport =
                this.CashReportParish =
                this.CashReceipt =
                this.CashReceiptParish =
                this.CashDisbursement =
                this.ItemType = true;
            else
                this.CashReportParish =
                this.CashReceiptParish =
                this.Bloodletting =
                this.BloodlettingReport =
                this.Schedule = true;
        }
    }
}
