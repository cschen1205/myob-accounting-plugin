using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class EmploymentBasis : Entity
    {
        internal EmploymentBasis(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

   

        private string mEmploymentBasisID = "";
        public string EmploymentBasisID
        {
            get { return mEmploymentBasisID; }
            set
            {
                mEmploymentBasisID = value;
                NotifyPropertyChanged("EmploymentBasisID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("EmploymentBasisID", EmploymentBasisID);
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
            if (obj == null)
            {
                return false;
            }
            if (obj is EmploymentBasis)
            {
                EmploymentBasis _obj = obj as EmploymentBasis;
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
