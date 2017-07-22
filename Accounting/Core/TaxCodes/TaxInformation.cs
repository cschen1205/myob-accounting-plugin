using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.TaxCodes
{
    public class TaxInformation : Entity
    {
        internal TaxInformation(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mTaxInformationID;
        public int? TaxInformationID
        {
            get { return mTaxInformationID; }
            set
            {
                mTaxInformationID = value;
                NotifyPropertyChanged("TaxInformationID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("TaxInformationID", TaxInformationID);
            }
        }

        #region TaxCode
        private TaxCode mTaxCode = null;
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
                mTaxCode = value;
                NotifyPropertyChanged("TaxCode");
            }
        }
        private int? mTaxCodeID;
        public int? TaxCodeID
        {
            get
            {
                if (mTaxCode != null)
                {
                    return mTaxCode.TaxCodeID;
                }
                return mTaxCodeID;
            }
            set
            {
                mTaxCodeID = value;
                NotifyPropertyChanged("TaxCodeID");
            }
        }
        #endregion

        #region JournalType
        private JournalRecords.JournalType mJournalType = null;
        public JournalRecords.JournalType JournalType
        {
            get
            {
                if (mJournalType == null)
                {
                    mJournalType = (JournalRecords.JournalType)BuildProperty(this, "JournalType");
                }
                return mJournalType;
            }
            set
            {
                mJournalType = value;
                NotifyPropertyChanged("JournalType");
            }
        }
        private string mJournalTypeID;
        public string JournalTypeID
        {
            get
            {
                if (mJournalType != null)
                {
                    return mJournalType.JournalTypeID;
                }
                return mJournalTypeID;
            }
            set
            {
                mJournalTypeID = value;
                NotifyPropertyChanged("JournalTypeID");
            }
        }
        #endregion

        private int? mTransactionID;
        public int? TransactionID
        {
            get { return mTransactionID; }
            set
            {
                mTransactionID = value;
                NotifyPropertyChanged("TransactionID");
            }
        }

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

        private double mTaxableAmount;
        public double TaxableAmount
        {
            get { return mTaxableAmount; }
            set
            {
                mTaxableAmount = value;
                NotifyPropertyChanged("TaxableAmount");
            }
        }

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

        private double mTaxBasisAmountAUS;
        public double TaxBasisAmountAUS
        {
            get { return mTaxBasisAmountAUS; }
            set
            {
                mTaxBasisAmountAUS = value;
                NotifyPropertyChanged("TaxBasisAmountAUS");
            }
        }

        private double mTaxAmountAUS;
        public double TaxAmountAUS
        {
            get { return mTaxAmountAUS; }
            set
            {
                mTaxAmountAUS = value;
                NotifyPropertyChanged("TaxAmountAUS");
            }
        }


        private double mTaxAmount;
        public double TaxAmount
        {
            get { return mTaxAmount; }
            set
            {
                mTaxAmount=value;
                NotifyPropertyChanged("TaxAmount");
            }
        }

        private string mTaxAmountIsChanged = "";
        public string TaxAmountIsChanged
        {
            get { return mTaxAmountIsChanged; }
            set
            {
                mTaxAmountIsChanged = value;
                NotifyPropertyChanged("TaxAmountIsChanged");
            }
        }

        #region ReportTaxAs
        private string mReportTaxAsID;
        public string ReportTaxAsID
        {
            get
            {
                if(mReportTaxAs != null)
                {
                    return mReportTaxAs.ReportingMethodID;
                }
                return mReportTaxAsID;
            }
            set{
                mReportTaxAsID=value;
                NotifyPropertyChanged("ReportTaxAsID");
            }
        }
        private Definitions.ReportingMethod mReportTaxAs=null;
        public Definitions.ReportingMethod ReportTaxAs
        {
            get
            {
                if (mReportTaxAs == null)
                {
                    mReportTaxAs = (Definitions.ReportingMethod)BuildProperty(this, "ReportTaxAs");
                }
                return mReportTaxAs;
            }
            set
            {
                mReportTaxAs = value;
                NotifyPropertyChanged("ReportTaxAs");
            }
        }
        #endregion
    }

}
