using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.ShippingMethods
{
    public class ShippingMethod: Entity
    {
        #region ShippingMethod constructor
        internal ShippingMethod(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

       

        #region ShippingMethodID
        private int? mShippingMethodID;
        public int? ShippingMethodID
        {
            get { return mShippingMethodID; }
            set 
            {
                mShippingMethodID = value;
                NotifyPropertyChanged("ShippingMethodID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ShippingMethodID", ShippingMethodID);
            }
        }

        #region Method
        private string mShippingMethod;
        public string Method
        {
            get { return mShippingMethod; }
            set 
            {
                mShippingMethod = value;
                NotifyPropertyChanged("Method");
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override string ToString()
        {
            return mShippingMethod;
        }

        public override bool Equals(object obj)
        {
            if (obj is ShippingMethod)
            {
                ShippingMethod _obj = (ShippingMethod)obj;
                return _obj.ShippingMethodID == mShippingMethodID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
