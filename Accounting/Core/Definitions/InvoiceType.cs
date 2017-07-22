using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class InvoiceType : Entity
    {
        #region -(Constructor)
        internal InvoiceType(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region InvoiceTypeID
        private string mInvoiceTypeID="I";
        public string InvoiceTypeID
        {
            get { return mInvoiceTypeID; }
            set 
            {
                mInvoiceTypeID = value;
                NotifyPropertyChanged("InvoiceTypeID");
            }
        }
        #endregion


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("InvoiceTypeID", InvoiceTypeID);
            }
        }

        #region Description
        private string mDescription="Item";
        public string Description
        {
            get { return mDescription; }
            set 
            {
                mDescription = value;
                NotifyPropertyChanged("Description");
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override string ToString()
        {
            return mDescription;
        }

        public override bool Equals(object obj)
        {
            if (obj is InvoiceType)
            {
                InvoiceType _obj = (InvoiceType)obj;
                return _obj.InvoiceTypeID == mInvoiceTypeID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region Comparers
        public bool IsService
        {
            get { return mInvoiceTypeID=="S"; }
        }

        public bool IsItem
        {
            get { return mInvoiceTypeID=="I"; }
        }

        public bool IsProfessional
        {
            get { return mInvoiceTypeID=="P"; }
        }

        public bool IsTimeBilling
        {
            get { return mInvoiceTypeID=="T"; }
        }

        public bool IsMisc
        {
            get { return mInvoiceTypeID=="M"; }
        }

        public bool IsNoDefault
        {
            get { return mInvoiceTypeID == "N"; }
        }
        #endregion
    }
}
