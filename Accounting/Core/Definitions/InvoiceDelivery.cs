using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class InvoiceDelivery : Entity
    {
        private string mInvoiceDeliveryID;
        private string mDescription;

        internal InvoiceDelivery(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

       
        public string InvoiceDeliveryID
        {
            get { return mInvoiceDeliveryID; }
            set
            {
                mInvoiceDeliveryID = value;
                NotifyPropertyChanged("InvoiceDeliveryID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("InvoiceDeliveryID", InvoiceDeliveryID);
            }
        }

        public string Description
        {
            get { return mDescription; }
            set
            {
                mDescription = value;
                NotifyPropertyChanged("Description");
            }
        }

        public override string ToString()
        {
            return mDescription;
        }

        public override bool Equals(object obj)
        {
            if (obj is InvoiceDelivery)
            {
                InvoiceDelivery _obj = (InvoiceDelivery)obj;
                return _obj.InvoiceDeliveryID == mInvoiceDeliveryID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
