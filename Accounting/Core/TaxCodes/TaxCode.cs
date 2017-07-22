using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.TaxCodes
{
    public class TaxCode : Entity
    {
        #region -(Constructor)
        internal TaxCode(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region SubTaxCode
        private string mSubTaxCode;
        public string SubTaxCode
        {
            get { return mSubTaxCode; }
            set 
            {
                mSubTaxCode = value;
                NotifyPropertyChanged("SubTaxCode");
            }
        }
        #endregion

        #region TaxCodeTypeID
        private string mTaxCodeTypeID;
        public string TaxCodeTypeID
        {
            get { return mTaxCodeTypeID; }
            set 
            {
                mTaxCodeTypeID = value;
                NotifyPropertyChanged("TaxCodeTypeID");
            }
        }
        #endregion


       

        #region TaxPercentageRate
        private double mTaxPercentageRate;
        public double TaxPercentageRate
        {
            get { return mTaxPercentageRate; }
            set 
            {
                mTaxPercentageRate = value;
                NotifyPropertyChanged("TaxPercentageRate");
            }
        }
        #endregion

        #region TaxCodeDescription
        private string mTaxCodeDescription;
        public string TaxCodeDescription
        {
            set 
            {
                mTaxCodeDescription = value;
                NotifyPropertyChanged("TaxCodeDescription");
            }
            get 
            {
                return mTaxCodeDescription;
            }
        }
        #endregion 

        #region TaxCode
        private string mTaxCode;
        public string Code
        {
            get { return mTaxCode; }
            set 
            {
                mTaxCode = value;
                NotifyPropertyChanged("Code");
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
            if (obj is TaxCode)
            {
                TaxCode rhs = (TaxCode)obj;

                return rhs.TaxCodeID == mTaxCodeID;
                
            }
            return false;

            
        }

        public override string ToString()
        {
            return mTaxCode;
        }
        #endregion

        #region TaxCodeID
        private int? mTaxCodeID;
        public int? TaxCodeID
        {
            get { return mTaxCodeID; }
            set 
            {
                mTaxCodeID = value;
                NotifyPropertyChanged("TaxCodeID");
            }
        }
        #endregion

        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("TaxCodeID", TaxCodeID);
            }
        }

        internal double CalculateTax(double p)
        {
            return TaxPercentageRate * p;
        }
    }
}
