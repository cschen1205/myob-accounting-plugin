using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Activities
{
    public class BillingRateUsed : Entity
    {
        #region BillingRateUsedID
        private string mBillingRateUsedID = "";
        public string BillingRateUsedID
        {
            get { return mBillingRateUsedID; }
            set
            {
                mBillingRateUsedID = value;
                NotifyPropertyChanged("BillingRateUsedID");
            }
        }
        #endregion


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("BillingRateUsedID", BillingRateUsedID);
            }
        }

        #region Description
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
        #endregion

        #region -(Constructor)
        internal BillingRateUsed(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

     

        #region Object Override Methods
        public override bool Equals(object obj)
        {
            if (obj is BillingRateUsed)
            {
                BillingRateUsed _obj = (BillingRateUsed)obj;
                return _obj.BillingRateUsedID == BillingRateUsedID;
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
        #endregion
    }
}
