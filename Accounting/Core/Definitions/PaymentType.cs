using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class PaymentType : Entity
    {
        internal PaymentType(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private string mPaymentTypeID = "";
        public string PaymentTypeID
        {
            get { return mPaymentTypeID; }
            set
            {
                mPaymentTypeID = value;
                NotifyPropertyChanged("PaymentTypeID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("PaymentTypeID", PaymentTypeID);
            }
        }

        private string mDescription = "";
        public string Description
        {
            get { return mDescription; }
            set
            {
                mDescription = value;
                NotifyPropertyChanged("Description");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is PaymentType)
            {
                PaymentType _obj = obj as PaymentType;
                return _obj.PaymentTypeID == PaymentTypeID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Description;
        }

        public bool IsCash
        {
            get { return PaymentTypeID == "C"; }
        }

        public bool IsElectronic
        {
            get { return PaymentTypeID == "E"; }
        }

        public bool IsCheque
        {
            get { return PaymentTypeID == "Q"; }
        }

        public int ToInt()
        {
            if (IsCash) return 1;
            if (IsCheque) return 2;
            if (IsElectronic) return 3;
            return 1;
        }
    }
}
