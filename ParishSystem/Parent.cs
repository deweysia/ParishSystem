using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParishSystem
{
    class Parent
    {
        private int _parentID = -1;
        private string _firstName, _midName, _lastName, _suffix;
        private Gender _g;
        private string _residence, _birthplace;

        public int parentID { get { return _parentID; } }
        public string firstName { get { return _firstName; } }
        public string midName { get { return _midName; } }
        public string lastName { get { return _lastName; } }
        public string suffix { get { return _suffix; } }
        public Gender g { get { return _g; } }
        public string residence { get { return _residence; } }
        public string birthplace { get { return _birthplace; } }

        public Parent(int parentID, string firstName, string midName, string lastName, string suffix, Gender g, string birthplace, string residence)
        {
            this._parentID = parentID;
            this._firstName = firstName;
            this._midName = midName;
            this._lastName = lastName;
            this._suffix = suffix;
            this._g = g;
            this._birthplace = birthplace;
            this._residence = residence;
        }
    }
}
