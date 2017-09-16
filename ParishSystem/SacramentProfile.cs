using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParishSystem
{
    class SacramentProfile
    {
        private Profile _person;
        private Parent _mother;
        private Parent _father;
        private Sacrament _sacrament;
        private Minister _minister;

        public Profile person { get { return _person; } }
        public Parent mother { get { return _mother; } }
        public Parent father { get { return _father; } }
        public Sacrament sacrament { get { return _sacrament; } }
        public Minister minister { get { return _minister; } }

        public SacramentProfile(Profile person, Parent mother, Parent father, Sacrament sacrament, Minister minister)
        {
            this._person = person;
            this._mother = mother;
            this._father = father;
            this._sacrament = sacrament;
            this._minister = minister;
        }
        
    }
}
