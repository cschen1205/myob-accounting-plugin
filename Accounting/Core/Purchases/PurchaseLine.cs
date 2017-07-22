using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.TaxCodes;

namespace Accounting.Core.Purchases
{
    public class PurchaseLine : Entity
    {
        #region -(Constructor)
        internal PurchaseLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region PurchaseLineID
        private int? mPurchaseLineID;
        public int? PurchaseLineID
        {
            get { return mPurchaseLineID; }
            set { mPurchaseLineID = value;
            NotifyPropertyChanged("PurchaseLineID");
            }
        }
        #endregion

     

        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("PurchaseLineID", PurchaseLineID);
            }
        }

        #region Purchase
        private int? mPurchaseID;
        public int? PurchaseID
        {
            get {
                if (mPurchase != null)
                {
                    return mPurchase.PurchaseID;
                }
                return mPurchaseID; }
            set { mPurchaseID = value;
            NotifyPropertyChanged("PurchaseID");
            }
        }
        private Purchase mPurchase = null;
        public Purchase Purchase
        {
            get
            {
                if (mPurchase == null)
                {
                    mPurchase = (Purchase)BuildProperty(this, "Purchase");
                }
                return mPurchase;
            }
            set
            {
                if (mPurchase != value)
                {
                    mPurchase = value;
                    NotifyPropertyChanged("Purchase");
                }
            }
        }
        #endregion

        #region LineNumber
        private int? mLineNumber;
        public int? LineNumber
        {
            get { return mLineNumber; }
            set { mLineNumber = value;
            NotifyPropertyChanged("LineNumber");
            }
        }
        #endregion

        #region LineType
        private string mLineTypeID="D";
        public string LineTypeID
        {
            get { return mLineTypeID; }
            set { mLineTypeID = value;
            NotifyPropertyChanged("LineTypeID");
            }
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

        #region TaxExclusiveAmount
        private double mTaxExclusiveAmount;
        public double TaxExclusiveAmount
        {
            get { return mTaxExclusiveAmount; }
            set 
            {
                if (mTaxExclusiveAmount != value)
                {
                    mTaxExclusiveAmount = value;
                    NotifyPropertyChanged("TaxExclusiveAmount");
                }
            }
        }
        #endregion

        #region TaxInclusiveAmount
        private double mTaxInclusiveAmount;
        public double TaxInclusiveAmount
        {
            get { return mTaxInclusiveAmount; }
            set 
            {
                if (mTaxInclusiveAmount != value)
                {
                    mTaxInclusiveAmount = value;
                    NotifyPropertyChanged("TaxInclusiveAmount");
                }
            }
        }
        #endregion

        #region IsMultipleJob
        private string mIsMultipleJob="N";
        public string IsMultipleJob
        {
            get { return mIsMultipleJob; }
            set { mIsMultipleJob = value;
            NotifyPropertyChanged("IsMultipleJob");
            }
        }
        #endregion

        #region Job
        private int? mJobID;
        public int? JobID
        {
            get {
                if (mJob != null)
                {
                    return mJob.JobID;
                }
                return mJobID; }
            set { mJobID = value;
            NotifyPropertyChanged("JobID");
            }
        }
        private Jobs.Job mJob;
        public Jobs.Job Job
        {
            get {
                if (mJob == null)
                {
                    mJob = (Jobs.Job)BuildProperty(this, "Job");
                }
                return mJob; 
            }
            set
            {
                mJob = value;
                NotifyPropertyChanged("Job");
                NotifyPropertyChanged("JobNumber");
            }
        }
        public string JobNumber
        {
            get
            {
                if (Job != null)
                {
                    return Job.JobNumber;
                }
                return "";
            }
        }
        #endregion

        #region TaxBasisAmount
        private double mTaxBasisAmount;
        public double TaxBasisAmount
        {
            get { return mTaxBasisAmount; }
            set { mTaxBasisAmount = value;
            NotifyPropertyChanged("TaxBasisAmount");
            }
        }
        #endregion

        #region TaxBasisAmountIsInclusive
        private string mTaxBasisAmountIsInclusive="N";
        public string TaxBasisAmountIsInclusive
        {
            get { return mTaxBasisAmountIsInclusive; }
            set 
            {
                if (mTaxBasisAmountIsInclusive != value)
                {
                    mTaxBasisAmountIsInclusive = value;
                    NotifyPropertyChanged("TaxBasisAmountIsInclusive");
                }
            }
        }
        #endregion

        #region TaxCode
        private int? mTaxCodeID;
        public int? TaxCodeID
        {
            get {
                if (mTaxCode != null)
                {
                    return mTaxCode.TaxCodeID;
                }
                return mTaxCodeID; }
            set 
            { 
                mTaxCodeID = value;
                NotifyPropertyChanged("TaxCodeID");
            }
        }

        private TaxCode mTaxCode=null;
        public TaxCode TaxCode
        {
            get {
                if (mTaxCode == null)
                {
                    mTaxCode = (TaxCode)BuildProperty(this, "TaxCode");
                }
                return mTaxCode; 
            }
             set 
             { 
                 mTaxCode=value;
                 NotifyPropertyChanged("TaxCode");
             }
        }

        public string _TaxCode
        {
            get
            {
                if (TaxCode != null)
                {
                    return TaxCode.Code;
                }
                return "";
            }
        }
        #endregion

        public string _Total
        {
            get
            {
                return Purchase.Currency.Format(TaxBasisAmount);
            }
        }

        #region -(Object Override Methods)
        public override bool Equals(object obj)
        {
            if (obj is PurchaseLine)
            {
                PurchaseLine _obj = (PurchaseLine)obj;
                return _obj.PurchaseLineID == PurchaseLineID;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("# {0} {1}", mLineNumber, mDescription);
        }
        #endregion

        public virtual void Evaluate()
        {
            if (TaxBasisAmountIsInclusive == "Y")
            {
                TaxBasisAmount = TaxInclusiveAmount;
            }
            else
            {
                TaxBasisAmount = TaxExclusiveAmount;
            }

            NotifyPropertyChanged("_Total");
        }
    }
}
