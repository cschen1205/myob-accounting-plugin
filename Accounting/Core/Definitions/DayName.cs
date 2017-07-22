using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class DayName : Entity
    {
        internal DayName(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private string mDayNameID = "";
        public string DayNameID
        {
            get { return mDayNameID; }
            set
            {
                mDayNameID = value;
                NotifyPropertyChanged("DayNameID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("DayNameID", DayNameID);
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

        public override string ToString()
        {
            return Description;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is DayName)
            {
                DayName _obj = obj as DayName;
                return _obj.Description == Description;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
