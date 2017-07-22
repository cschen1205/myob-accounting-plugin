using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Sales
{
    public class CustomerDiscountLine : Entity
    {
        internal CustomerDiscountLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mCustomerDiscountLineID;
        public int? CustomerDiscountLineID
        {
            get { return mCustomerDiscountLineID; }
            set
            {
                mCustomerDiscountLineID = value;
                NotifyPropertyChanged("CustomerDiscountLineID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("CustomerDiscountLineID", CustomerDiscountLineID);
            }
        }

        #region CustomerDiscount
        private CustomerDiscount mCustomerDiscount = null;
        public CustomerDiscount CustomerDiscount
        {
            get
            {
                if (mCustomerDiscount == null)
                {
                    mCustomerDiscount = (CustomerDiscount)BuildProperty(this, "CustomerDiscount");
                }
                return mCustomerDiscount;
            }
            set
            {
                mCustomerDiscount = value;
                NotifyPropertyChanged("CustomerDiscount");
            }
        }
        private int? mCustomerDiscountID;
        public int? CustomerDiscountID
        {
            get
            {
                if (mCustomerDiscount != null)
                {
                    return mCustomerDiscount.CustomerDiscountID;
                }
                return mCustomerDiscountID;
            }
            set
            {
                mCustomerDiscountID = value;
                NotifyPropertyChanged("CustomerDiscountID");
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

        #region Sale
        private Sale mSale = null;
        public Sale Sale
        {
            get
            {
                if (mSale == null)
                {
                    mSale = (Sale)BuildProperty(this, "Sale");
                }
                return mSale;
            }
            set
            {
                mSale = value;
                NotifyPropertyChanged("Sale");
            }
        }
        private int? mSaleID;
        public int? SaleID
        {
            get
            {
                if (mSale != null)
                {
                    return mSale.SaleID;
                }
                return mSaleID;
            }
            set
            {
                mSaleID = value;
                NotifyPropertyChanged("SaleID");
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
