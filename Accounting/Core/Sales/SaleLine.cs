using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.TaxCodes;

namespace Accounting.Core.Sales
{
    public class SaleLine : Entity
    {
        #region -(Constructor)
        internal SaleLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        protected virtual SaleLine CreateLine()
        {
            return new SaleLine(false, EntityBuilder);
        }

        #region SaleLineID
        private int? mSaleLineID;
        public int? SaleLineID
        {
            get { return mSaleLineID; }
            set { mSaleLineID = value;
            NotifyPropertyChanged("SaleLineID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("SaleLineID", SaleLineID);
            }
        }

        #region Sale
        private int? mSaleID;
        public int? SaleID
        {
            get 
            {
                if (mSale != null)
                {
                    return mSale.SaleID;
                }
                return mSaleID; 
            }
            set { mSaleID = value;
            NotifyPropertyChanged("SaleID");
            }
        }
        private Sale mSale;
        public Sale Sale
        {
            get 
            {
                if (mSale == null)
                {
                    mSale = (Sale)BuildProperty(this, "Sale");
                }
                return mSale; 
            }
            set
            {
                if (mSale != value)
                {
                    mSale = value;
                    NotifyPropertyChanged("Sale");
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
            set { mTaxExclusiveAmount=value;
            NotifyPropertyChanged("TaxExclusiveAmount");
            }
        }
        #endregion

        #region TaxInclusiveAmount
        private double mTaxInclusiveAmount;
        public double TaxInclusiveAmount
        {
            get { return mTaxInclusiveAmount; }
            set { mTaxInclusiveAmount=value;
            NotifyPropertyChanged("TaxInclusiveAmount");
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
            get 
            {
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
            set { mTaxBasisAmountIsInclusive = value;
            NotifyPropertyChanged("TaxBasisAmountIsInclusive");
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
            set { mTaxCodeID = value;
            NotifyPropertyChanged("TaxCodeID");
            }
        }

        private TaxCode mTaxCode;
        public TaxCode TaxCode
        {
            get 
            {
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
                return Sale.Currency.Format(TaxBasisAmount);
            }
        }

        #region Object Override Methods
        public override bool Equals(object obj)
        {
            if (obj is SaleLine)
            {
                SaleLine _obj = (SaleLine)obj;
                if (FromDb && _obj.FromDb)
                {
                    return _obj.SaleLineID == SaleLineID;
                }
                if (Sale.Equals(_obj.Sale))
                {
                    return _obj.LineNumber == LineNumber;
                }
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("{0}", LineNumber);
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
