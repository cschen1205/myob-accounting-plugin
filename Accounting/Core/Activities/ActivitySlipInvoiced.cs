using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Activities
{
    public class ActivitySlipInvoiced : Entity
    {
        internal ActivitySlipInvoiced(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mActivitySlipInvoicedID;
        public int? ActivitySlipInvoicedID
        {
            get { return mActivitySlipInvoicedID; }
            set
            {
                mActivitySlipInvoicedID = value;
                NotifyPropertyChanged("ActivitySlipInvoicedID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ActivitySlipInvoicedID", ActivitySlipInvoicedID);
            }
        }

        #region ActivitySlip
        private ActivitySlip mActivitySlip = null;
        public ActivitySlip ActivitySlip
        {
            get
            {
                if (mActivitySlip == null) mActivitySlip = (ActivitySlip)BuildProperty(this, "ActivitySlip");
                return mActivitySlip;
            }
            set
            {
                mActivitySlip = value;
                NotifyPropertyChanged("ActivitySlip");
            }
        }
        private int? mActivitySlipID;
        public int? ActivitySlipID
        {
            get
            {
                if (mActivitySlip != null) return mActivitySlip.ActivitySlipID;
                return mActivitySlipID;
            }
            set
            {
                mActivitySlipID = value;
                NotifyPropertyChanged("ActivitySlipID");
            }
        }
        #endregion

        #region Sale
        private Sales.Sale mSale = null;
        public Sales.Sale Sale
        {
            get
            {
                if (mSale == null) mSale = (Sales.Sale)BuildProperty(this, "Sale");
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
                if (mSale != null) return mSale.SaleID;
                return mSaleID;
            }
            set
            {
                mSaleID = value;
                NotifyPropertyChanged("SaleID");
            }
        }
        #endregion

        private double mInvoicedUnits;
        public double InvoicedUnits
        {
            get { return mInvoicedUnits; }
            set
            {
                mInvoicedUnits = value;
                NotifyPropertyChanged("InvoicedUnits");
            }
        }

        private double mInvoicedDollars;
        public double InvoicedDollars
        {
            get { return mInvoicedDollars; }
            set
            {
                mInvoicedDollars = value;
                NotifyPropertyChanged("InvoicedDollars");
            }
        }
    }
}
