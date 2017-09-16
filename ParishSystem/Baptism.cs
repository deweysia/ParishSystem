using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParishSystem
{
    class Baptism : Sacrament
    {
        private Legitimacy _legitimacy;
        public Legitimacy legitimacy { get { return _legitimacy; } }
        Baptism(int applicationID, int ministerID, string registryNumber, string recordNumber, string pageNumber, string remarks, DateTime sacramentDate, Legitimacy legitimacy)
            : base (applicationID, ministerID, registryNumber, recordNumber, pageNumber, remarks, sacramentDate)
        {
            this._legitimacy = legitimacy;
        }
    }
}
