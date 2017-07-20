using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParishSystem
{
    class Classifications
    {
    }

    public enum SacramentType
    {
        Baptism,
        Confirmation,
        Marriage
    }
    
    public enum ApplicationStatus
    {
        Pending,
        Approved,
        Cancelled,
        Rejected,
        Final
    }

    public enum MinistryType
    {
        Priest,
        Bishop
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum BookType
    {
        Parish,
        Community,
        Postulency
    }

    public enum ItemTypeStatus
    {
        IDK_ANO_MERON_DITO
    }

    public enum CivilStatus
    {
        Single,
        Divorced,
        Widowed
    }

    public enum MarriageStatus
    {
        Active,
        Divorced
    }
}
