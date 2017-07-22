using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class Rounding : Entity
    {
        internal Rounding(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private string mRoundingID = "";
        public string RoundingID
        {
            get { return mRoundingID; }
            set
            {
                mRoundingID = value;
                NotifyPropertyChanged("RoundingID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("RoundingID", RoundingID);
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
            if (obj is Rounding)
            {
                Rounding _obj = obj as Rounding;
                return _obj.RoundingID == RoundingID;
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
    }
}
