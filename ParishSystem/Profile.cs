using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParishSystem
{
    class Profile
    {
        private int _profileID = -1;
        private string _firstName, _midName, _lastName, _suffix;
        private Gender _g;
        private DateTime _birthdate;
        private string _residence, _birthplace;

        public int profileID {
            get {
                if (this._profileID <= 0)
                    return -1;
                else return _profileID;
            }
        }

        public string firstName { get { return _firstName; } }
        public string midName { get { return _midName; } }
        public string lastName { get { return _lastName; } }
        public string suffix { get { return _suffix; } }
        public Gender g { get { return _g; } }
        public DateTime birthdate { get { return _birthdate; } }
        public string residence { get { return _residence; } }
        public string birthplace { get { return _birthplace; } }
            
        //Profile(string firstName, string midName, string lastName, string suffix, Gender g, DateTime birthdate)
        //{
        //    this._firstName = firstName;
        //    this._midName = midName;
        //    this._lastName = lastName;
        //    this._suffix = suffix;
        //    this._g = g;
        //    this._birthdate = birthdate;
        //}

        Profile(int profileID, string firstName, string midName, string lastName, string suffix, Gender g, DateTime birthdate)
        {
            this._profileID = profileID;
            this._firstName = firstName;
            this._midName = midName;
            this._lastName = lastName;
            this._suffix = suffix;
            this._g = g;
            this._birthdate = birthdate;
        }

        //Profile(string firstName, string midName, string lastName, string suffix, Gender g, DateTime birthdate, string residence, string birthplace) 
        //    : this(firstName, midName, lastName, suffix, g, birthdate)
        //{
        //    this._residence = residence;
        //    this._birthplace = birthplace;
        //}

        Profile(int profileID, string firstName, string midName, string lastName, string suffix, Gender g, DateTime birthdate, string residence, string birthplace)
            : this(profileID, firstName, midName, lastName, suffix, g, birthdate)
        {
            this._residence = residence;
            this._birthplace = birthplace;
        }


    }
}
