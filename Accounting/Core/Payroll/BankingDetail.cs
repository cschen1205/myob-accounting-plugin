using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Payroll
{
    public class BankingDetail : Entity
    {
        internal BankingDetail(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        #region Card
        private Cards.Card mCard = null;
        public Cards.Card Card
        {
            get
            {
                if (mCard == null) mCard = (Cards.Card)BuildProperty(this, "Card");
                return mCard;
            }
            set
            {
                mCard = value;
                NotifyPropertyChanged("Card");
            }
        }
        private int? mCardRecordID;
        public int? CardRecordID
        {
            get
            {
                if (mCard != null) return mCard.CardRecordID;
                return mCardRecordID;
            }
            set
            {
                mCardRecordID = value;
                NotifyPropertyChanged("CardRecordID");
            }
        }
        #endregion

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

        #region WritePaycheque
        private Transactions.WritePaycheque mWritePaycheque = null;
        public Transactions.WritePaycheque WritePaycheque
        {
            get
            {
                if (mWritePaycheque == null) mWritePaycheque = (Transactions.WritePaycheque)BuildProperty(this, "WritePaycheque");
                return mWritePaycheque;
            }
            set
            {
                mWritePaycheque = value;
                NotifyPropertyChanged("WritePaycheque");
            }
        }
        private int? mWritePaychequeID;
        public int? WritePaychequeID
        {
            get
            {
                if (mWritePaycheque != null) return mWritePaycheque.WritePaychequeID;
                return mWritePaychequeID;
            }
            set
            {
                mWritePaychequeID = value;
                NotifyPropertyChanged("WritePaychequeID");
            }
        }
        #endregion

        private int? mNumberBankAccounts;
        public int? NumberBankAccounts
        {
            get { return mNumberBankAccounts; }
            set
            {
                mNumberBankAccounts = value;
                NotifyPropertyChanged("NumberBankAccounts");
            }
        }

        private string mBSBCode1="";
        public string BSBCode1
        {
            get { return mBSBCode1; }
            set
            {
                mBSBCode1 = value;
                NotifyPropertyChanged("BSBCode1");
            }
        }

        private string mBankAccountNumber1 = "";
        public string BankAccountNumber1
        {
            get { return mBankAccountNumber1; }
            set
            {
                mBankAccountNumber1 = value;
                NotifyPropertyChanged("BankAccountNumber1");
            }
        }

        private string mBankAccountName1 = "";
        public string BankAccountName1
        {
            get { return mBankAccountName1; }
            set
            {
                mBankAccountName1 = value;
                NotifyPropertyChanged("BankAccountName1");
            }
        }

        private double mBank1Value;
        public double Bank1Value
        {
            get { return mBank1Value; }
            set
            {
                mBank1Value = value;
                NotifyPropertyChanged("Bank1Value");
            }
        }

        private string mBank1ValueTypeID = "";
        public string Bank1ValueTypeID
        {
            get { return mBank1ValueTypeID; }
            set
            {
                mBank1ValueTypeID = value;
                NotifyPropertyChanged("Bank1ValueTypeID");
            }
        }

        private double mBank1CalculatedAmount;
        public double Bank1CalculatedAmount
        {
            get { return mBank1CalculatedAmount; }
            set
            {
                mBank1CalculatedAmount = value;
                NotifyPropertyChanged("Bank1CalculatedAmount");
            }
        }

        private string mBSBCode2 = "";
        public string BSBCode2
        {
            get { return mBSBCode2; }
            set
            {
                mBSBCode2 = value;
                NotifyPropertyChanged("BSBCode2");
            }
        }

        private string mBankAccountNumber2 = "";
        public string BankAccountNumber2
        {
            get { return mBankAccountNumber2; }
            set
            {
                mBankAccountNumber2 = value;
                NotifyPropertyChanged("BankAccountNumber2");
            }
        }

        private string mBankAccountName2 = "";
        public string BankAccountName2
        {
            get { return mBankAccountName2; }
            set 
            {
                mBankAccountName2 = value;
                NotifyPropertyChanged("BankAccountName2");
            }
        }

        private double mBank2Value;
        public double Bank2Value
        {
            get { return mBank2Value; }
            set
            {
                mBank2Value = value;
                NotifyPropertyChanged("Bank2Value");
            }
        }

        private string mBank2ValueTypeID = "";
        public string Bank2ValueTypeID
        {
            get { return mBank2ValueTypeID; }
            set
            {
                mBank2ValueTypeID = value;
                NotifyPropertyChanged("Bank2ValueTypeID");
            }
        }

        private double mBank2CalculatedAmount;
        public double Bank2CalculatedAmount
        {
            get { return mBank2CalculatedAmount; }
            set
            {
                mBank2CalculatedAmount = value;
                NotifyPropertyChanged("Bank2CalculatedAmount");
            }
        }

        private string mBSBCode3 = "";
        public string BSBCode3
        {
            get { return mBSBCode3; }
            set
            {
                mBSBCode3 = value;
                NotifyPropertyChanged("BSBCode3");
            }
        }

        private string mBankAccountNumber3 = "";
        public string BankAccountNumber3
        {
            get { return mBankAccountNumber3; }
            set
            {
                mBankAccountNumber3 = value;
                NotifyPropertyChanged("BankAccountNumber3");
            }
        }

        private string mBankAccountName3 = "";
        public string BankAccountName3
        {
            get { return mBankAccountName3; }
            set
            {
                mBankAccountName3 = value;
            }
        }

        private double mBank3Value;
        public double Bank3Value
        {
            get { return mBank3Value; }
            set 
            {
                mBank3Value = value;
                NotifyPropertyChanged("Bank3Value");
            }
        }

        private string mBank3ValueTypeID = "";
        public string Bank3ValueTypeID
        {
            get { return mBank3ValueTypeID; }
            set
            {
                mBank3ValueTypeID = value;
                NotifyPropertyChanged("Bank3ValueTypeID");
            }
        }

        private double mBank3CalculatedAmount;
        public double Bank3CalculatedAmount
        {
            get { return mBank3CalculatedAmount; }
            set
            {
                mBank3CalculatedAmount = value;
                NotifyPropertyChanged("Bank3CalculatedAmount");
            }
        }

        private int? mBankingDetailID;
        public int? BankingDetailID
        {
            get { return mBankingDetailID; }
            set
            {
                mBankingDetailID = value;
                NotifyPropertyChanged("BankingDetailID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("BankingDetailID", BankingDetailID);
            }
        }

        public override string ToString()
        {
            return "Bank Details";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is BankingDetail)
            {
                BankingDetail _obj = obj as BankingDetail;
                return _obj.BankingDetailID == BankingDetailID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
