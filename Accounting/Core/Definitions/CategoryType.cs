using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class CategoryType : Entity
    {
        internal CategoryType(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private string mCategoryTypeID = "";
        public string CategoryTypeID
        {
            get { return mCategoryTypeID; }
            set
            {
                mCategoryTypeID = value;
                NotifyPropertyChanged("CategoryTypeID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("CategoryTypeID", CategoryTypeID);
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
    }
}
