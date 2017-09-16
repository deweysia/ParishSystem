using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParishSystem
{
    class Marriage : Sacrament
    {
        private DateTime _licenseDate;
        private CivilStatus _groomStatus;
        private CivilStatus _brideStatus;

        public DateTime licenseDate { get { return _licenseDate; } }
        public CivilStatus groomStatus { get { return _groomStatus; } }
        public CivilStatus brideStatus { get { return _brideStatus;} }
        Marriage(int applicationID, int ministerID, string registryNumber, string recordNumber, string pageNumber, string remarks, DateTime sacramentDate, DateTime licenseDate, CivilStatus groomStatus, CivilStatus brideStatus)
            : base (applicationID, ministerID, registryNumber, recordNumber, pageNumber, remarks, sacramentDate)
        {
            this._licenseDate = licenseDate;
            this._groomStatus = groomStatus;
            this._brideStatus = brideStatus;
        }
    }
}
