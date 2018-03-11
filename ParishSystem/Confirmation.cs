using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParishSystem
{
    public class Confirmation : Sacrament
    {
        public Confirmation(int applicationID, int ministerID, string registryNumber, string pageNumber, string recordNumber, string remarks, DateTime sacramentDate)
            : base(applicationID, ministerID, registryNumber, pageNumber, recordNumber, remarks, sacramentDate) { }
    }
}
