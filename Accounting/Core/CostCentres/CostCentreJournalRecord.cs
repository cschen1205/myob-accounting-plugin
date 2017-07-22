using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.CostCentres
{
    public class CostCentreJournalRecord : Entity
    {
        internal CostCentreJournalRecord(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mCostCentreJournalRecordID;
        public int? CostCentreJournalRecordID
        {
            get { return mCostCentreJournalRecordID; }
            set
            {
                mCostCentreJournalRecordID = value;
                NotifyPropertyChanged("CostCentreJournalRecordID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("CostCentreJournalRecordID", CostCentreJournalRecordID);
            }
        }

        private string mTransactionNumber = "";
        public string TransactionNumber
        {
            get { return mTransactionNumber; }
            set
            {
                mTransactionNumber = value;
                NotifyPropertyChanged("TransactionNumber");
            }
        }

        private DateTime? mDate;
        public DateTime? Date
        {
            get { return mDate; }
            set
            {
                mDate = value;
                NotifyPropertyChanged("Date");
            }
        }

        private DateTime? mTransactionDate;
        public DateTime? TransactionDate
        {
            get { return mTransactionDate; }
            set
            {
                mTransactionDate = value;
                NotifyPropertyChanged("TransactionDate");
            }
        }

        private string mIsThirteenthPeriod = "N";
        public string IsThirteenthPeriod
        {
            get { return mIsThirteenthPeriod; }
            set
            {
                mIsThirteenthPeriod = value;
                NotifyPropertyChanged("IsThirteenthPeriod");
            }
        }

        #region CostCentre
        private CostCentre mCostCentre = null;
        public CostCentre CostCentre
        {
            get
            {
                if (mCostCentre == null) mCostCentre = (CostCentre)BuildProperty(this, "CostCentre");
                return mCostCentre;
            }
            set
            {
                mCostCentre = value;
                NotifyPropertyChanged("CostCentre");
            }
        }
        private int? mCostCentreID;
        public int? CostCentreID
        {
            get
            {
                if (mCostCentre != null) return mCostCentre.CostCentreID;
                return mCostCentreID;
            }
            set
            {
                mCostCentreID = value;
                NotifyPropertyChanged("CostCentreID");
            }
        }
        #endregion

        #region Account
        private Accounts.Account mAccount = null;
        public Accounts.Account Account
        {
            get
            {
                if (mAccount == null) mAccount = (Accounts.Account)BuildProperty(this, "Account");
                return mAccount;
            }
            set
            {
                mAccount = value;
                NotifyPropertyChanged("Account");
            }
        }
        private int? mAccountID;
        public int? AccountID
        {
            get
            {
                if (mAccount != null) return mAccount.AccountID;
                return mAccountID;
            }
            set
            {
                mAccountID = value;
                NotifyPropertyChanged("AccountID");
            }
        }
        #endregion

        private double mTaxExclusiveAmount;
        public double TaxExclusiveAmount
        {
            get { return mTaxExclusiveAmount; }
            set
            {
                mTaxExclusiveAmount = value;
                NotifyPropertyChanged("TaxExclusiveAmount");
            }
        }

        #region JournalRecord
        private JournalRecords.JournalRecord mJournalRecord = null;
        public JournalRecords.JournalRecord JournalRecord
        {
            get
            {
                if (mJournalRecord == null) mJournalRecord = (JournalRecords.JournalRecord)BuildProperty(this, "JournalRecord");
                return mJournalRecord;
            }
            set
            {
                mJournalRecord = value;
                NotifyPropertyChanged("JournalRecord");
            }
        }
        private int? mJournalRecordID;
        public int? JournalRecordID
        {
            get
            {
                if (mJournalRecord != null) return mJournalRecord.JournalRecordID;
                return mJournalRecordID;
            }
            set
            {
                mJournalRecordID = value;
                NotifyPropertyChanged("JournalRecordID");
            }
        }
        #endregion

        #region JournalType
        private JournalRecords.JournalType mJournalType = null;
        public JournalRecords.JournalType JournalType
        {
            get
            {
                if (mJournalType == null) mJournalType = (JournalRecords.JournalType)BuildProperty(this, "JournalType");
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
                if (mJournalType != null) return mJournalType.JournalTypeID;
                return mJournalTypeID;
            }
            set
            {
                mJournalTypeID = value;
                NotifyPropertyChanged("JournalTypeID");
            }
        }
        #endregion


    }
}
