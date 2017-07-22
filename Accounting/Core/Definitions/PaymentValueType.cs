using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class PaymentValueType : Entity
    {
        internal PaymentValueType(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private string mValueTypeID = "";
        public string ValueTypeID
        {
            get { return mValueTypeID; }
            set
            {
                mValueTypeID = value;
                NotifyPropertyChanged("ValueTypeID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("ValueTypeID", ValueTypeID);
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
            if (obj is PaymentValueType)
            {
                PaymentValueType _obj = obj as PaymentValueType;
                return _obj.ValueTypeID == ValueTypeID;
            }
            return false;
        }

        public override string ToString()
        {
            return Description;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
