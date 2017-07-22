using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class ContributionType : Entity
    {
        internal ContributionType(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private string mContributionTypeID = "";
        public string ContributionTypeID
        {
            get { return mContributionTypeID; }
            set
            {
                mContributionTypeID = value;
                NotifyPropertyChanged("ContributionTypeID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("ContributionTypeID", ContributionTypeID);
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
            if (obj is ContributionType)
            {
                ContributionType _obj = obj as ContributionType;
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
