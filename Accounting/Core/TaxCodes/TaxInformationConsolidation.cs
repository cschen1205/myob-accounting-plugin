using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.TaxCodes
{
    public class TaxInformationConsolidation : Entity
    {
        internal TaxInformationConsolidation(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mTaxInformationConsolidationID;
        public int? TaxInformationConsolidationID
        {
            get { return mTaxInformationConsolidationID; }
            set
            {
                mTaxInformationConsolidationID = value;
                NotifyPropertyChanged("TaxInformationConsolidationID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("TaxInformationConsolidationID", TaxInformationConsolidationID);
            }
        }

        #region ConsolidationTaxCode
        private TaxCode mConsolidationTaxCode = null;
        public TaxCode ConsolidationTaxCode
        {
            get
            {
                if (mConsolidationTaxCode == null)
                {
                    mConsolidationTaxCode = (TaxCode)BuildProperty(this, "ConsolidationTaxCode");
                }
                return mConsolidationTaxCode;
            }
            set
            {
                mConsolidationTaxCode = value;
                NotifyPropertyChanged("ConsolidationTaxCode");
            }
        }
        private int? mConsolidationTaxCodeID;
        public int? ConsolidationTaxCodeID
        {
            get
            {
                if(mConsolidationTaxCode != null)
                {
                    return mConsolidationTaxCode.TaxCodeID;
                }
                return mConsolidationTaxCodeID;
            }
            set
            {
                mConsolidationTaxCodeID=value;
                NotifyPropertyChanged("ConsolidationTaxCodeID");
            }
        }
        #endregion

        #region ElementTaxCode
        private TaxCode mElementTaxCode = null;
        public TaxCode ElementTaxCode
        {
            get
            {
                if (mElementTaxCode == null)
                {
                    mElementTaxCode = (TaxCode)BuildProperty(this, "ElementTaxCode");
                }
                return mElementTaxCode;
            }
            set
            {
                mElementTaxCode = value;
                NotifyPropertyChanged("ElementTaxCode");
            }
        }
        private int? mElementTaxCodeID;
        public int? ElementTaxCodeID
        {
            get
            {
                if (mElementTaxCode != null)
                {
                    return mElementTaxCode.TaxCodeID;
                }
                return mElementTaxCodeID;
            }
            set
            {
                mElementTaxCodeID = value;
                NotifyPropertyChanged("ElementTaxCodeID");
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

        private double mElementTaxableAmountAUS;
        public double ElementTaxableAmountAUS
        {
            get { return mElementTaxableAmountAUS; }
            set
            {
                mElementTaxableAmountAUS = value;
                NotifyPropertyChanged("ElementTaxableAmountAUS");
            }
        }

        private double mElementTaxableAmount;
        public double ElementTaxableAmount
        {
            get { return mElementTaxableAmount; }
            set
            {
                mElementTaxableAmount = value;
                NotifyPropertyChanged("ElementTaxableAmount");
            }
        }

        private double mElementTaxBasisAmountAUS;
        public double ElementTaxBasisAmountAUS
        {
            get { return mElementTaxBasisAmountAUS; }
            set
            {
                mElementTaxBasisAmountAUS = value;
                NotifyPropertyChanged("ElementTaxBasisAmountAUS");
            }
        }

        private double mElementTaxBasisAmount;
        public double ElementTaxBasisAmount
        {
            get { return mElementTaxBasisAmount; }
            set
            {
                mElementTaxBasisAmount = value;
                NotifyPropertyChanged("ElementTaxBasisAmount");
            }
        }

        private double mElementTaxAmountAUS;
        public double ElementTaxAmountAUS
        {
            get { return mElementTaxAmountAUS; }
            set
            {
                mElementTaxAmountAUS = value;
                NotifyPropertyChanged("ElementTaxAmountAUS");
            }
        }

        private double mElementTaxAmount;
        public double ElementTaxAmount
        {
            get { return mElementTaxAmount; }
            set
            {
                mElementTaxAmount = value;
                NotifyPropertyChanged("ElementTaxAmount");
            }
        }
    }
}
