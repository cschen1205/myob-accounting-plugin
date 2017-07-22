using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class EmploymentStatus : Entity
    {
        internal EmploymentStatus(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private string mEmploymentStatusID = "";
        public string EmploymentStatusID
        {
            get { return mEmploymentStatusID; }
            set
            {
                mEmploymentStatusID = value;
                NotifyPropertyChanged("EmploymentStatusID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("EmploymentStatusID", EmploymentStatusID);
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
            if (obj is EmploymentStatus)
            {
                EmploymentStatus _obj = obj as EmploymentStatus;
                return _obj.Description == Description;
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
