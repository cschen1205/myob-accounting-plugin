using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class Schedule : Entity
    {
        internal Schedule(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private string mScheduleID = "";
        public string ScheduleID
        {
            get { return mScheduleID; }
            set
            {
                mScheduleID = value;
                NotifyPropertyChanged("ScheduleID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("ScheduleID", ScheduleID);
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
            if (obj is Schedule)
            {
                Schedule _obj = obj as Schedule;
                return _obj.ScheduleID == ScheduleID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
