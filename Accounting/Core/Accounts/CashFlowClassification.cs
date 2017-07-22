using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Accounts
{
    public class CashFlowClassification : Entity
    {
        #region CashFlowClassificationID
        private string mCashFlowClassID;
        public string CashFlowClassID
        {
            get { return mCashFlowClassID; }
            set 
            { 
                mCashFlowClassID = value;
                NotifyPropertyChanged("CashFlowClassID");
            }
        }
        #endregion


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("CashFlowClassID", CashFlowClassID);
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

        #region +(Constructor)
        internal CashFlowClassification(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {

        }
        #endregion

      

        #region -(Object Override Methods)
        public override string ToString()
        {
            return mDescription;
        }

        public override bool Equals(object obj)
        {
            if (obj is CashFlowClassification)
            {
                CashFlowClassification _obj = (CashFlowClassification)obj;
                return _obj.CashFlowClassID == mCashFlowClassID;
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
