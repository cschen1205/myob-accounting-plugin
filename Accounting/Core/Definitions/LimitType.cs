using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class LimitType : Entity
    {
        internal LimitType(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

    

        private string mLimitTypeID = "";
        public string LimitTypeID
        {
            get { return mLimitTypeID; }
            set
            {
                mLimitTypeID = value;
                NotifyPropertyChanged("LimitTypeID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("LimitTypeID", LimitTypeID);
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
            if (obj is LimitType)
            {
                LimitType _obj = obj as LimitType;
                return _obj.LimitTypeID == LimitTypeID;
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
