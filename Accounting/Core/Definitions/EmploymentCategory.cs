using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class EmploymentCategory : Entity
    {
        internal EmploymentCategory(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private string mEmploymentCategoryID = "";
        public string EmploymentCategoryID
        {
            get { return mEmploymentCategoryID; }
            set
            {
                mEmploymentCategoryID = value;
                NotifyPropertyChanged("EmploymentCategoryID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("EmploymentCategoryID", EmploymentCategoryID);
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
            if(obj is EmploymentCategory)
            {
                EmploymentCategory _obj = obj as EmploymentCategory;
                return _obj.Description == Description;
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
