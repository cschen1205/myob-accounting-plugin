using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class Alert : Entity
    {
        internal Alert(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private string mAlertID = "";
        public string AlertID
        {
            get { return mAlertID; }
            set { mAlertID = value; }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("AlertID", AlertID);
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
            if (obj is Alert)
            {
                Alert _obj = obj as Alert;
                return _obj.Description == Description;
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
