using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParishSystem
{
    public class Sacrament
    {
        private int _applicationID = -1;
        private int _ministerID = -1;
        private string _registryNumber, _recordNumber, _pageNumber, _remarks;
        private DateTime _sacramentDate;

        public int applicationID
        {
            get
            {
                if (this._applicationID <= 0)
                    return -1;
                else return this._applicationID;
            }
        }

        public int ministerID
        {
            get
            {
                if (this._ministerID <= 0)
                    return -1;
                else return this._ministerID;
            }
        }

        public string registryNumber { get { return _registryNumber; } }
        public string recordNumber { get { return _recordNumber; } }
        public string pageNumber { get { return _pageNumber; } }
        public string remarks { get { return _remarks; } }
        public DateTime sacramentDate { get { return _sacramentDate; } }

        protected Sacrament(int applicationID, int ministerID, string registryNumber, string pageNumber, string recordNumber, string remarks, DateTime sacramentDate)
        {
            this._applicationID = applicationID;
            this._ministerID = ministerID;
            this._recordNumber = registryNumber;
            this._recordNumber = recordNumber;
            this._pageNumber = pageNumber;
            this._remarks = remarks;
            this._sacramentDate = sacramentDate;
        }
    }
}
