using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.TaxCodes;

namespace Accounting.Core.Sales
{
    public class RecurringSaleLine : RecurringEntity
    {
        #region -(Constructor)
        internal RecurringSaleLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region RecurringSaleLineID
        private int? mRecurringSaleLineID;
        public int? RecurringSaleLineID
        {
            get { return mRecurringSaleLineID; }
            set { mRecurringSaleLineID = value;
            NotifyPropertyChanged("RecurringSaleLineID");
            }
        }
        #endregion

        //protected virtual RecurringSaleLine CreateLine()
        //{
        //    return new RecurringSaleLine(false, EntityBuilder);
        //}

        //public RecurringSaleLine CloneLine(bool is_exact_copy)
        //{
        //    RecurringSaleLine line = CreateLine();
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


        public override Accounting.Core.RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("RecurringSaleLineID", RecurringSaleLineID);
            }
        }

        #region RecurringSale
        private int? mRecurringSaleID;
        public int? RecurringSaleID
        {
            get 
            {
                if (mRecurringSale != null)
                {
                    return mRecurringSale.RecurringSaleID;
                }
                return mRecurringSaleID; 
            }
            set { mRecurringSaleID = value;
            NotifyPropertyChanged("RecurringSaleID");
            }
        }
        private RecurringSale mRecurringSale;
        public RecurringSale RecurringSale
        {
            get 
            {
                if (mRecurringSale == null)
                {
                    mRecurringSale = (RecurringSale)BuildProperty(this, "RecurringSale");
                }
                return mRecurringSale; 
            }
            set
            {
                mRecurringSale = value;
                NotifyPropertyChanged("RecurringSale");
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
        private string mLineTypeID;
        public string LineTypeID
        {
            get { return mLineTypeID; }
            set {
                mLineTypeID = value;
                NotifyPropertyChanged("LineTypeID");
            }
        }
        #endregion

        #region Description
        private string mDescription="";
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
        #endregion

        //#region Entity Override Methods
        //public override void AssignFrom(Entity rhs)
        //{
        //    base.AssignFrom(rhs);
        //    Copy2(this);

        //    RecurringSaleLine _obj = (RecurringSaleLine)rhs;
        //    RecurringSaleLineID = _obj.RecurringSaleLineID;
        //    RecurringSaleID = _obj.RecurringSaleID;
        //    RecurringSale = _obj.RecurringSale;
        //}
        //public override void Copy2(Entity rhs)
        //{
        //    base.Copy2(rhs);
        //    RecurringSaleLine _obj = (RecurringSaleLine)rhs;

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

        #region Object Override Methods
        public override bool Equals(object obj)
        {
            if (obj is RecurringSaleLine)
            {
                RecurringSaleLine _obj = (RecurringSaleLine)obj;
                if (FromDb && _obj.FromDb)
                {
                    return _obj.RecurringSaleLineID == RecurringSaleLineID;
                }
                if (RecurringSale.Equals(_obj.RecurringSale))
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
    }
}
