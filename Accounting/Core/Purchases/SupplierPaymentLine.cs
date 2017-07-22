using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Purchases
{
    public class SupplierPaymentLine : Entity
    {
        internal SupplierPaymentLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mSupplierPaymentLineID;
        public int? SupplierPaymentLineID
        {
            get { return mSupplierPaymentLineID; }
            set
            {
                mSupplierPaymentLineID = value;
                NotifyPropertyChanged("SupplierPaymentLineID");
            }
        }


        public override Accounting.Core.RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("SupplierPaymentLineID", SupplierPaymentLineID);
            }
        }

        #region SupplierPayment
        private SupplierPayment mSupplierPayment = null;
        public SupplierPayment SupplierPayment
        {
            get
            {
                if (mSupplierPayment == null)
                {
                    mSupplierPayment = (SupplierPayment)BuildProperty(this, "SupplierPayment");
                }
                return mSupplierPayment;
            }
            set
            {
                mSupplierPayment = value;
                NotifyPropertyChanged("SupplierPayment");
            }
        }
        private int? mSupplierPaymentID;
        public int? SupplierPaymentID
        {
            get
            {
                if (mSupplierPayment != null)
                {
                    return mSupplierPayment.SupplierPaymentID;
                }
                return mSupplierPaymentID;
            }
            set
            {
                mSupplierPaymentID = value;
                NotifyPropertyChanged("SupplierPaymentID");
            }
        }
        #endregion

        private int? mLineNumber;
        public int? LineNumber
        {
            get
            {
                return mLineNumber;
            }
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
            get { return mAmountApplied; }
            set
            {
                mAmountApplied = value;
                NotifyPropertyChanged("AmountApplied");
            }
        }

        private string mIsDepositPayment = "N";
        public string IsDepositPayment
        {
            get { return mIsDepositPayment; }
            set
            {
                mIsDepositPayment = value;
                NotifyPropertyChanged("IsDepositPayment");
            }
        }
    }
}
