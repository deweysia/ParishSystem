using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParishSystem
{
    public class Minister
    {
        private int _ministerID = -1;
        private string _firstName, _midName, _lastName, _suffix;
        private DateTime _birthdate;
        private MinistryType _ministryType;
        private MinisterStatus _status;
        public int ministerID
        {
            get
            {
                if (this._ministerID <= 0)
                    return -1;
                else return _ministerID;
            }
        }
        public string firstName { get { return _firstName; } }
        public string midName { get { return _midName; } }
        public string lastName { get { return _lastName; } }
        public string suffix { get { return _suffix; } }
        public DateTime birthdate { get { return _birthdate; } }
        public MinistryType ministryType { get { return _ministryType; } }
        public MinisterStatus status { get { return _status; } }

        public Minister(int ministerID, string firstName, string midName, string lastName, string suffix, DateTime birthDate, MinistryType ministryType, MinisterStatus status)
        {
            this._ministerID = ministerID;
            this._firstName = firstName;
            this._midName = midName;
            this._lastName = lastName;
            this._suffix = suffix;
            this._birthdate = birthdate;
            this._ministryType = ministryType;
            this._status = status;

        }
    }
}
