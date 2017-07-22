using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Transactions
{
    public class BankDepositLine : Entity
    {
        internal BankDepositLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mBankDepositLineID;
        public int? BankDepositLineID
        {
            get { return mBankDepositLineID; }
            set
            {
                mBankDepositLineID = value;
                NotifyPropertyChanged("BankDepositLineID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("BankDepositLineID", BankDepositLineID);
            }
        }

        #region BankDeposit
        private BankDeposit mBankDeposit = null;
        public BankDeposit BankDeposit
        {
            get
            {
                if (mBankDeposit == null) mBankDeposit = (BankDeposit)BuildProperty(this, "BankDeposit");
                return mBankDeposit;
            }
            set
            {
                mBankDeposit = value;
                NotifyPropertyChanged("BankDeposit");
            }
        }
        private int? mBankDepositID;
        public int? BankDepositID
        {
            get
            {
                if (mBankDeposit != null) return mBankDeposit.BankDepositID;
                return mBankDepositID;
            }
            set
            {
                mBankDepositID = value;
                NotifyPropertyChanged("BankDepositID");
            }
        }
        #endregion

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

        private int? mSourceID;
        public int? SourceID
        {
            get { return mSourceID; }
            set
            {
                mSourceID = value;
                NotifyPropertyChanged("SourceID");
            }
        }

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

        private double mAmountDeposited;
        public double AmountDeposited
        {
            get { return mAmountDeposited; }
            set
            {
                mAmountDeposited = value;
                NotifyPropertyChanged("AmountDeposited");
            }
        }

        #region DepositStatus
        private Definitions.DepositStatus mDepositStatus = null;
        public Definitions.DepositStatus DepositStatus
        {
            get
            {
                if (mDepositStatus == null) mDepositStatus = (Definitions.DepositStatus)BuildProperty(this, "DepositStatus");
                return mDepositStatus;
            }
            set
            {
                mDepositStatus = value;
                NotifyPropertyChanged("DepositStatus");
            }
        }
        private string mDepositStatusID;
        public string DepositStatusID
        {
            get
            {
                if (mBankDeposit != null) return mDepositStatus.DepositStatusID;
                return mDepositStatusID;
            }
            set
            {
                mDepositStatusID = value;
                NotifyPropertyChanged("DepositStatusID");
            }
        }
        #endregion


    }
}
