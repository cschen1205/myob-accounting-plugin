using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class EmploymentClassification : Entity
    {
        internal EmploymentClassification(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mEmploymentClassificationID;
        public int? EmploymentClassificationID
        {
            get { return mEmploymentClassificationID; }
            set
            {
                mEmploymentClassificationID = value;
                NotifyPropertyChanged("EmploymentClassificationID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("EmploymentClassificationID", EmploymentClassificationID);
            }
        }

        private string mEmploymentClassificationName = "";
        public string EmploymentClassificationName
        {
            get { return mEmploymentClassificationName; }
            set
            {
                mEmploymentClassificationName = value;
                NotifyPropertyChanged("EmploymentClassificationName");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is EmploymentClassification)
            {
                EmploymentClassification _obj = obj as EmploymentClassification;
                return _obj.EmploymentClassificationName == EmploymentClassificationName;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return EmploymentClassificationName;
        }
    }
}
