using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Sales
{
    public class SettledCreditLine : Entity
    {
        internal SettledCreditLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mSettledCreditLineID;
        public int? SettledCreditLineID
        {
            get { return mSettledCreditLineID; }
            set
            {
                mSettledCreditLineID = value;
                NotifyPropertyChanged("SettledCreditLineID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("SettledCreditLineID", SettledCreditLineID);
            }
        }

        #region SettledCredit
        private SettledCredit mSettledCredit = null;
        public SettledCredit SettledCredit
        {
            get
            {
                if (mSettledCredit == null)
                {
                    mSettledCredit = (SettledCredit)BuildProperty(this, "SettledCredit");
                }
                return mSettledCredit;
            }
            set
            {
                mSettledCredit = value;
                NotifyPropertyChanged("SettledCredit");
            }
        }
        private int? mSettledCreditID;
        public int? SettledCreditID
        {
            get
            {
                if (mSettledCredit != null)
                {
                    return mSettledCredit.SettledCreditID;
                }
                return mSettledCreditID;
            }
            set
            {
                mSettledCreditID = value;
                NotifyPropertyChanged("SettledCreditID");
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

        private string mIsDiscount = "N";
        public string IsDiscount
        {
            get { return mIsDiscount; }
            set
            {
                mIsDiscount = value;
                NotifyPropertyChanged("IsDiscount");
            }
        }
    }
}
