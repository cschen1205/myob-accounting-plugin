using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class OrderStatus : Entity
    {
        #region -(Constructor)
        internal OrderStatus(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region OrderStatusID
        private string mOrderStatusID;
        public string OrderStatusID
        {
            get { return mOrderStatusID; }
            set 
            {
                mOrderStatusID = value;
                NotifyPropertyChanged("OrderStatusID");
            }
        }
        #endregion


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("OrderStatusID", OrderStatusID);
            }
        }

        #region Description
        private string mDescription;
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
            if (obj is OrderStatus)
            {
                OrderStatus _obj = (OrderStatus)obj;
                return _obj.OrderStatusID == mOrderStatusID;
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
