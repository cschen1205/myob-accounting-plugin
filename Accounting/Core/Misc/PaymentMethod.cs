using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Misc
{
    public class PaymentMethod : Entity
    {
        internal PaymentMethod(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {

        }

      

        private string mPaymentMethod="";
        public string Description
        {
            get
            {
                return mPaymentMethod;
            }
            set 
            {
                mPaymentMethod = value;
                NotifyPropertyChanged("Description");
            }
        }

        private int? mPaymentMethodID;
        public int? PaymentMethodID
        {
            get { return mPaymentMethodID; }
            set 
            {
                mPaymentMethodID = value;
                NotifyPropertyChanged("PaymentMethodID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("PaymentMethodID", PaymentMethodID);
            }
        }

        public override string ToString()
        {
            return Description;
        }

        private string mMethodType="";
        public string MethodType
        {
            get { return mMethodType; }
            set { mMethodType = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj is PaymentMethod)
            {
                PaymentMethod _obj = obj as PaymentMethod;
                if (_obj.FromDb && FromDb)
                {
                    return _obj.PaymentMethodID == PaymentMethodID;
                }
                return _obj.Description.Equals(Description);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
