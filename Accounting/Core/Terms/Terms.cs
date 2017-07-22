using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Terms
{
    public class Terms : Entity
    {
        #region -(Constructor)
        internal Terms(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region BalanceDueDate
        private string mBalanceDueDate;
        public string BalanceDueDate
        {
            get { return mBalanceDueDate; }
            set 
            {
                mBalanceDueDate = value;
                NotifyPropertyChanged("BalanceDueDate");
            }
        }
        #endregion

        #region DiscountDate
        private string mDiscountDate;
        public string DiscountDate
        {
            get { return mDiscountDate; }
            set 
            {
                mDiscountDate = value;
                NotifyPropertyChanged("DiscountDate");
            }
        }
        #endregion

        #region ImportPaymentIsDue
        private int? mImportPaymentIsDue;
        public int? ImportPaymentIsDue
        {
            set 
            {
                mImportPaymentIsDue = value;
                NotifyPropertyChanged("ImportPaymentIsDue");
            }
            get
            {
                return mImportPaymentIsDue; 
            }
        }
        #endregion

        #region LatePaymentChargePercent
        private double mLatePaymentChargePercent;
        public double LatePaymentChargePercent
        {
            set 
            {
                mLatePaymentChargePercent = value;
                NotifyPropertyChanged("LatePaymentChargePercent");
            }
            get { return mLatePaymentChargePercent; }
        }
        #endregion

        #region DiscountDays
        private int? mDiscountDays=0;
        public int? DiscountDays
        {
            get
            {
                return mDiscountDays;
            }
            set
            {
                mDiscountDays = value;
                NotifyPropertyChanged("DiscountDays");
            }
        }
        #endregion

        #region PaymentIsDue
        public int? PaymentIsDue
        {
            get
            {
                if (TermsOfPaymentID == "COD")
                {
                    return 0;
                }
                if (TermsOfPaymentID == "PPD")
                {
                    return 1;
                }
                if (TermsOfPaymentID == "GND")
                {
                    return 2;
                }
                if (TermsOfPaymentID == "DOM")
                {
                    return 3;
                }
                if (TermsOfPaymentID == "NDAE")
                {
                    return 4;
                }
                if (TermsOfPaymentID == "DMAE")
                {
                    return 5;
                }
                return 0;
            }
        }
        #endregion

        #region EarlyPaymentDiscountPercent
        private double mEarlyPaymentDiscountPercent;
        public double EarlyPaymentDiscountPercent
        {
            get { return mEarlyPaymentDiscountPercent; }
            set
            {
                mEarlyPaymentDiscountPercent = value;
                NotifyPropertyChanged("EarlyPaymentDiscountPercent");
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Terms))
            {
                return false;
            }

            Terms rhs=(Terms)obj;

            return this.mTermsID == rhs.TermsID;
        }

        public override string ToString()
        {
            //return PaymentDescription;
            return string.Format("{0}% {1} {2} {3}", EarlyPaymentDiscountPercent, DiscountDays, BalanceDueDays, TermsOfPaymentID);
        }
        #endregion

        #region TermsID
        private int? mTermsID;
        public int? TermsID
        {
            get { return mTermsID; }
            set 
            {
                mTermsID = value;
                NotifyPropertyChanged("TermsID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("TermsID", TermsID);
            }
        }

        #region BalanceDueDays
        private int? mBalanceDueDays;
        public int? BalanceDueDays
        {
            get { return mBalanceDueDays; }
            set
            {
                mBalanceDueDays = value;
                NotifyPropertyChanged("BalanceDueDays");
            }
        }
        #endregion

        #region PaymentDescription
        private string mPaymentDescription;
        public string PaymentDescription
        {
            get { return mPaymentDescription; }
            set 
            {
                mPaymentDescription = value;
                NotifyPropertyChanged("PaymentDescription");
            }
        }
        #endregion

        #region TermsOfPayment
        private string mTermsOfPaymentID;
        public string TermsOfPaymentID
        {
            get {
                if (mTermsOfPayment != null)
                {
                    return mTermsOfPayment.TermsOfPaymentID;
                }
                return mTermsOfPaymentID; }
            set
            {
                mTermsOfPaymentID = value;
                NotifyPropertyChanged("TermsOfPaymentID");
            }
        }
        private TermsOfPayment mTermsOfPayment;
        public TermsOfPayment TermsOfPayment
        {
            get
            {
                if (mTermsOfPayment == null)
                {
                    mTermsOfPayment = (TermsOfPayment)BuildProperty(this, "TermsOfPayment");
                }
                return mTermsOfPayment; 
            }
            set
            {
                mTermsOfPayment = value;
                NotifyPropertyChanged("TermsOfPayment");
            }
        }
        #endregion

        


    }
}
