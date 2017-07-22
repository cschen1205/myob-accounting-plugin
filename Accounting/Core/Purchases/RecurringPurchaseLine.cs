using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.TaxCodes;

namespace Accounting.Core.Purchases
{
    public class RecurringPurchaseLine : RecurringEntity
    {
        #region -(Constructor)
        internal RecurringPurchaseLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        //protected virtual RecurringPurchaseLine CreateLine()
        //{
        //    return new RecurringPurchaseLine(false, EntityBuilder);
        //}

        //public RecurringPurchaseLine CloneLine(bool is_exact_copy)
        //{
        //    RecurringPurchaseLine line = CreateLine();
        //    if (is_exact_copy)
        //    {
        //        line.AssignFrom(this);
        //    }
        //    else
        //    {
        //        line.Copy2(this);
        //    }
        //    return line;
        //}

        #region RecurringPurchaseLineID
        private int? mRecurringPurchaseLineID;
        public int? RecurringPurchaseLineID
        {
            get { return mRecurringPurchaseLineID; }
            set
            {
                mRecurringPurchaseLineID = value;
                NotifyPropertyChanged("RecurringPurchaseLineID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("RecurringPurchaseLineID", RecurringPurchaseLineID);
            }
        }

        #region RecurringPurchase
        private int? mRecurringPurchaseID;
        public int? RecurringPurchaseID
        {
            get {
                if (mRecurringPurchase != null)
                {
                    return mRecurringPurchase.RecurringPurchaseID;
                }
                return mRecurringPurchaseID; }
            set 
            {
                mRecurringPurchaseID = value;
                NotifyPropertyChanged("RecurringPurchaseID");
            }
        }
        private RecurringPurchase mRecurringPurchase = null;
        public RecurringPurchase RecurringPurchase
        {
            get
            {
                if (mRecurringPurchase == null)
                {
                    mRecurringPurchase = (RecurringPurchase)BuildProperty(this, "RecurringPurchase");
                }
                return mRecurringPurchase;
            }
            set
            {
                mRecurringPurchase = value;
                NotifyPropertyChanged("RecurringPurchase");
            }
        }
        #endregion

        #region LineNumber
        private int? mLineNumber;
        public int? LineNumber
        {
            get { return mLineNumber; }
            set 
            {
                mLineNumber = value;
                NotifyPropertyChanged("LineNumber");
            }
        }
        #endregion

        #region LineType
        private string mLineTypeID;
        public string LineTypeID
        {
            get { return mLineTypeID; }
            set
            {
                mLineTypeID = value;
                NotifyPropertyChanged("LineTypeID");
            }
        }
        #endregion

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

        #region TaxExclusiveAmount
        private double mTaxExclusiveAmount;
        public double TaxExclusiveAmount
        {
            get { return mTaxExclusiveAmount; }
            set 
            {
                mTaxExclusiveAmount=value;
                NotifyPropertyChanged("TaxExclusiveAmount");
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
                mTaxInclusiveAmount=value;
                NotifyPropertyChanged("TaxInclusiveAmount");
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
            set 
            {
                mJobID = value;
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
            }
        }
        #endregion

        #region TaxBasisAmount
        private double mTaxBasisAmount;
        public double TaxBasisAmount
        {
            get { return mTaxBasisAmount; }
            set 
            {
                mTaxBasisAmount = value;
                NotifyPropertyChanged("TaxBasisAmount");
            }
        }
        #endregion

        #region TaxBasisAmountIsInclusive
        private string mTaxBasisAmountIsInclusive;
        public string TaxBasisAmountIsInclusive
        {
            get { return mTaxBasisAmountIsInclusive; }
            set
            {
                mTaxBasisAmountIsInclusive = value;
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
            set 
            {
                mTaxCodeID = value;
                NotifyPropertyChanged("TaxCodeID");
            }
        }

        private TaxCode mTaxCode;
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
        #endregion

        #region -(Object Override Methods)
        public override bool Equals(object obj)
        {
            if (obj is RecurringPurchaseLine)
            {
                RecurringPurchaseLine _obj = (RecurringPurchaseLine)obj;
                return _obj.RecurringPurchaseLineID == RecurringPurchaseLineID;
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

        //#region Entity Override Methods
        //public override void AssignFrom(Entity rhs)
        //{
        //    base.AssignFrom(rhs);
        //    Copy2(rhs);

        //    RecurringPurchaseLine _obj = (RecurringPurchaseLine)rhs;
        //    RecurringPurchaseLineID = _obj.RecurringPurchaseLineID;
        //    RecurringPurchase = _obj.RecurringPurchase;
        //}
        //public override void Copy2(Entity rhs)
        //{
        //    base.Copy2(rhs);

        //    RecurringPurchaseLine _obj = rhs as RecurringPurchaseLine;

        //    LineNumber = _obj.LineNumber;
        //    LineTypeID = _obj.LineTypeID;
        //    Description = _obj.Description;
        //    TaxExclusiveAmount = _obj.TaxExclusiveAmount;
        //    TaxInclusiveAmount = _obj.TaxInclusiveAmount;
        //    JobID = _obj.JobID;
        //    Job = _obj.Job;
        //    TaxBasisAmount = _obj.TaxBasisAmount;
        //    TaxBasisAmountIsInclusive = _obj.TaxBasisAmountIsInclusive;
        //    TaxCodeID = _obj.TaxCodeID;
        //    TaxCode = _obj.TaxCode;
        //}
        //#endregion

       
    }
}
