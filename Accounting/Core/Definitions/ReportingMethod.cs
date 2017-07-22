using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class ReportingMethod : Entity
    {
        internal ReportingMethod(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private string mReportingMethodID = "";
        public string ReportingMethodID
        {
            get { return mReportingMethodID; }
            set
            {
                mReportingMethodID = value;
                NotifyPropertyChanged("ReportingMethodID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("ReportingMethodID", ReportingMethodID);
            }
        }

        private string mDescription="";
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
            if (obj is ReportingMethod)
            {
                ReportingMethod _obj = obj as ReportingMethod;
                return _obj.ReportingMethodID == ReportingMethodID;
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
