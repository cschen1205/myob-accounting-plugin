using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class ReconciliationStatus : Entity
    {
        internal ReconciliationStatus(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private string mReconciliationStatusID = "";
        public string ReconciliationStatusID
        {
            get { return mReconciliationStatusID; }
            set
            {
                mReconciliationStatusID = value;
                NotifyPropertyChanged("ReconciliationStatusID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("ReconciliationStatusID", ReconciliationStatusID);
            }
        }

        private string mDescription = "";
        public string Description
        {
            get { return mDescription; }
            set
            {
                mDescription = value;
                NotifyPropertyChanged("Description");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is ReconciliationStatus)
            {
                ReconciliationStatus _obj = obj as ReconciliationStatus;
                return _obj.ReconciliationStatusID == ReconciliationStatusID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
