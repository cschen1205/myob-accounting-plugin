using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Sales
{
    public class ReferralSource : Entity
    {
        #region ReferralSourceID
        private int? mReferralSourceID;
        public int? ReferralSourceID
        {
            get { return mReferralSourceID; }
            set { mReferralSourceID = value;
            NotifyPropertyChanged("ReferralSourceID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ReferralSourceID", ReferralSourceID);
            }
        }

        #region -(Constructor)
        internal ReferralSource(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region Description
        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value;
            NotifyPropertyChanged("Description");
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override bool Equals(object obj)
        {
            if (obj is ReferralSource)
            {
                ReferralSource _obj = (ReferralSource)obj;
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
            return mDescription;
        }
        #endregion
    }
}
