using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Terms
{
    public class TermsOfPayment : Entity
    {
        #region -(Constructor)
        internal TermsOfPayment(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

    

        #region TermsOfPaymentID
        private string mTermsOfPaymentID;
        public string TermsOfPaymentID
        {
            get { return mTermsOfPaymentID; }
            set 
            {
                mTermsOfPaymentID = value;
                NotifyPropertyChanged("TermsOfPaymentID");
            }
        }
        #endregion


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("TermsOfPaymentID", TermsOfPaymentID);
            }
        }

        #region Description
        private string mDescription;
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

        #region -(Object Override Methods)
        public override string ToString()
        {
            return mDescription;
        }

        public override bool Equals(object obj)
        {
            if (obj is TermsOfPayment)
            {
                TermsOfPayment _obj = (TermsOfPayment)obj;
                return _obj.TermsOfPaymentID == mTermsOfPaymentID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
