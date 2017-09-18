using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParishSystem
{
    public class Baptism : Sacrament
    {
        private Legitimacy _legitimacy;
        public Legitimacy legitimacy { get { return _legitimacy; } }
        public Baptism(int applicationID, int ministerID, string registryNumber, string pageNumber, string recordNumber, string remarks, DateTime sacramentDate, Legitimacy legitimacy)
            : base (applicationID, ministerID, registryNumber, pageNumber, recordNumber, remarks, sacramentDate)
        {
            this._legitimacy = legitimacy;
        }
    }
}
