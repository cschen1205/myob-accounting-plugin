using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Purchases
{
    public class SupplierDiscountLine : Entity
    {
        internal SupplierDiscountLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mSupplierDiscountLineID;
        public int? SupplierDiscountLineID
        {
            get { return mSupplierDiscountLineID; }
            set
            {
                mSupplierDiscountLineID = value;
                NotifyPropertyChanged("SupplierDiscountLineID");
            }
        }

        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("SupplierDiscountLineID", SupplierDiscountLineID);
            }
        }

        #region SupplierDiscount
        private SupplierDiscount mSupplierDiscount = null;
        public SupplierDiscount SupplierDiscount
        {
            get
            {
                if (mSupplierDiscount == null)
                {
                    mSupplierDiscount = (SupplierDiscount)BuildProperty(this, "SupplierDiscount");
                }
                return mSupplierDiscount;
            }
            set
            {
                mSupplierDiscount = value;
                NotifyPropertyChanged("SupplierDiscount");
            }
        }
        private int? mSupplierDiscountID;
        public int? SupplierDiscountID
        {
            get
            {
                if (mSupplierDiscount != null)
                {
                    return mSupplierDiscount.SupplierDiscountID;
                }
                return mSupplierDiscountID;
            }
            set
            {
                mSupplierDiscountID = value;
                NotifyPropertyChanged("SupplierDiscountID");
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
    }
}
