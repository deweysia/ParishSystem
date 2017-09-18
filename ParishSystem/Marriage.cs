using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParishSystem
{
    public class Marriage : Sacrament
    {
        private DateTime _licenseDate;
        private CivilStatus _groomStatus;
        private CivilStatus _brideStatus;

        public DateTime licenseDate { get { return _licenseDate; } }
        public CivilStatus groomStatus { get { return _groomStatus; } }
        public CivilStatus brideStatus { get { return _brideStatus;} }
        public Marriage(int applicationID, int ministerID, string registryNumber, string pageNumber, string recordNumber, string remarks, DateTime sacramentDate, DateTime licenseDate, CivilStatus groomStatus, CivilStatus brideStatus)
            : base (applicationID, ministerID, registryNumber, pageNumber, recordNumber, remarks, sacramentDate)
        {
            this._licenseDate = licenseDate;
            this._groomStatus = groomStatus;
            this._brideStatus = brideStatus;
        }
    }
}
