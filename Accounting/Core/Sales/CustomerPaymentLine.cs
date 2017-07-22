using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Sales
{
    public class CustomerPaymentLine : Entity
    {
        internal CustomerPaymentLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mCustomerPaymentLineID;
        public int? CustomerPaymentLineID
        {
            get { return mCustomerPaymentLineID; }
            set
            {
                mCustomerPaymentLineID = value;
                NotifyPropertyChanged("CustomerPaymentLineID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("CustomerPaymentLineID", CustomerPaymentLineID);
            }
        }

        #region CustomerPayment
        private CustomerPayment mCustomerPayment = null;
        public CustomerPayment CustomerPayment
        {
            get
            {
                if (mCustomerPayment == null)
                {
                    mCustomerPayment = (CustomerPayment)BuildProperty(this, "CustomerPayment");
                }
                return mCustomerPayment;
            }
            set
            {
                mCustomerPayment = value;
                NotifyPropertyChanged("CustomerPayment");
            }
        }
        private int? mCustomerPaymentID;
        public int? CustomerPaymentID
        {
            get
            {
                if (mCustomerPayment != null)
                {
                    return mCustomerPayment.CustomerPaymentID;
                }
                return mCustomerPaymentID;
            }
            set
            {
                mCustomerPaymentID = value;
                NotifyPropertyChanged("CustomerPaymentID");
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

        private string mIsDepositPayment="";
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
