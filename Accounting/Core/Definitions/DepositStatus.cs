using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class DepositStatus : Entity
    {
        internal DepositStatus(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private string mDepositStatusID = "";
        public string DepositStatusID
        {
            get { return mDepositStatusID; }
            set
            {
                mDepositStatusID = value;
                NotifyPropertyChanged("DepositStatusID");
            }
        }


        public override Accounting.Core.RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("DepositStatusID", DepositStatusID);
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
            if (obj is DepositStatus)
            {
                DepositStatus _obj = obj as DepositStatus;
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
