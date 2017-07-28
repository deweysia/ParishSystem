using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParishSystem
{
    class Enums
    {

        public enum BloodType { A=1, B=2 , AB=3 , O=4 };
        public enum SacramentType { Baptism=1 , Confirmation=2, Marriage=3};
        public enum Legitimacy { Legal=1 , Civil=2 , Natural=3 };
        public enum MarriageStatus { Active=1, Inactive=2 };
        public enum MinisterStatus { Active=1, Inactive=2 };
        public enum Gender { Male=1 , Female=2  };
        public enum CivilStatus { Single=1, Widowed=2 };
        public enum Mode { GeneralProfile = 1, Applications = 2 };
    }


  
    public enum SacramentType { Baptism = 1, Confirmation = 2, Marriage = 3 };

    public enum BookType
    {
        Parish = 1,
        Community,
        Postulency
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
        Bishop
    }

    public enum ItemTypeStatus
    {
        Active = 1, Inactive
    }

    public enum CivilStatus
    {
        Single = 1,
        Divorced,
        Widowed
    }

}
