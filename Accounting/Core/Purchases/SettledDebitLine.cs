using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Purchases
{
    public class SettledDebitLine : Entity
    {
        internal SettledDebitLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mSettledDebitLineID;
        public int? SettledDebitLineID
        {
            get { return mSettledDebitLineID; }
            set
            {
                mSettledDebitLineID = value;
                NotifyPropertyChanged("SettledDebitLineID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("SettledDebitLineID", SettledDebitLineID);
            }
        }

        #region SettledDebit
        private SettledDebit mSettledDebit = null;
        public SettledDebit SettledDebit
        {
            get
            {
                if (mSettledDebit == null)
                {
                    mSettledDebit = (SettledDebit)BuildProperty(this, "SettledDebit");
                }
                return mSettledDebit;
            }
            set
            {
                mSettledDebit = value;
                NotifyPropertyChanged("SettledDebit");
            }
        }
        private int? mSettledDebitID;
        public int? SettledDebitID
        {
            get
            {
                if (mSettledDebit != null)
                {
                    return mSettledDebit.SettledDebitID;
                }
                return mSettledDebitID;
            }
            set
            {
                mSettledDebitID = value;
                NotifyPropertyChanged("SettledDebitID");
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

        #region Purchase
        private Purchase mPurchase = null;
        public Purchase Purchase
        {
            get
            {
                if (mPurchase == null)
                {
                    mPurchase = (Purchase)BuildProperty(this, "Purchase");
                }
                return mPurchase;
            }
            set
            {
                mPurchase = value;
                NotifyPropertyChanged("Purchase");
            }
        }
        private int? mPurchaseID;
        public int? PurchaseID
        {
            get
            {
                if (mPurchase != null)
                {
                    return mPurchase.PurchaseID;
                }
                return mPurchaseID;
            }
            set
            {
                mPurchaseID = value;
                NotifyPropertyChanged("PurchaseID");
            }
        }
        #endregion

        private double mAmountApplied;
        public double AmountApplied
        {
            get
            {
                return mAmountApplied;
            }
            set
            {
                mAmountApplied = value;
                NotifyPropertyChanged("AmountApplied");
            }
        }

        private string mIsDepositPayment = "N";
        public string IsDepositPayment
        {
            get
            {
                return mIsDepositPayment;
            }
            set
            {
                mIsDepositPayment = value;
                NotifyPropertyChanged("IsDepositPayment");
            }
        }

        private string mIsDiscount = "N";
        public string IsDiscount
        {
            get
            {
                return mIsDiscount; 
            }
            set
            {
                mIsDiscount = value;
                NotifyPropertyChanged("IsDiscount");
            }
        }
    }
}
