using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParishSystem
{
    class Enums
    {

    }
    
    public enum MarriageStatus { Active = 1, Inactive = 2 };
    public enum Legitimacy { Legal = 1, Civil = 2, Natural = 3 };

    public enum MinisterStatus { Active = 1, Inactive = 2, Retired = 3 };

    public enum Gender { Male = 1, Female = 2 };

    public enum SacramentType { Baptism = 1, Confirmation = 2, Marriage = 3 };

    public enum BookType
    {
        Parish = 1,
        Community,
        Postulancy
    }

    public enum ApplicationStatus
    {
        Pending = 1,
        Approved,
        Final,
        Revoked
    }

    public enum MinistryType
    {
        Priest = 1,
        Mosignor,
        Archbishop
    }

    public enum ItemTypeStatus
    {
        Active = 1, Inactive
    }

    public enum CivilStatus
    {
        Single = 1,
        Widowed
    }

    public enum ScheduleType
    {
        Unspecified,
        Appointment,
        BloodDonation
        
    }

    public enum OperationType
    {
        Add, Edit
    }

    
    

}
