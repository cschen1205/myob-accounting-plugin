using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Transactions
{
    public class ElectronicPaymentLine : Entity
    {
        internal ElectronicPaymentLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mElectronicPaymentLineID;
        public int? ElectronicPaymentLineID
        {
            get { return mElectronicPaymentLineID; }
            set
            {
                mElectronicPaymentLineID = value;
                NotifyPropertyChanged("ElectronicPaymentLineID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ElectronicPaymentLineID", ElectronicPaymentLineID);
            }
        }

        #region ElectronicPayment
        private ElectronicPayment mElectronicPayment = null;
        public ElectronicPayment ElectronicPayment
        {
            get
            {
                if (mElectronicPayment == null) mElectronicPayment = (ElectronicPayment)BuildProperty(this, "ElectronicPayment");
                return mElectronicPayment;
            }
            set
            {
                mElectronicPayment = value;
                NotifyPropertyChanged("ElectronicPayment");
            }
        }
        private int? mElectronicPaymentID;
        public int? ElectronicPaymentID
        {
            get
            {
                if (mElectronicPayment != null) return mElectronicPayment.ElectronicPaymentID;
                return mElectronicPaymentID;
            }
            set
            {
                mElectronicPaymentID = value;
                NotifyPropertyChanged("ElectronicPaymentID");
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

        private double mAmountPaid;
        public double AmountPaid
        {
            get { return mAmountPaid; }
            set
            {
                mAmountPaid = value;
                NotifyPropertyChanged("AmountPaid");
            }
        }

        #region PaymentStatus
        private Definitions.DepositStatus mPaymentStatus = null;
        public Definitions.DepositStatus PaymentStatus
        {
            get
            {
                if (mPaymentStatus == null) return mPaymentStatus = (Definitions.DepositStatus)BuildProperty(this, "PaymentStatus");
                return mPaymentStatus;
            }
            set
            {
                mPaymentStatus = value;
                NotifyPropertyChanged("PaymentStatus");
            }
        }
        private string mPaymentStatusID;
        public string PaymentStatusID
        {
            get
            {
                if (mPaymentStatus != null) return mPaymentStatus.DepositStatusID;
                return mPaymentStatusID;
            }
            set
            {
                mPaymentStatusID = value;
                NotifyPropertyChanged("PaymentStatusID");
            }
        }
        #endregion
    }
}
