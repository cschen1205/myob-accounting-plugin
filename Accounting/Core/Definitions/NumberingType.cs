using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class NumberingType : Entity
    {
        internal NumberingType(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private string mNumberingTypeID = "";
        public string NumberingTypeID
        {
            get { return mNumberingTypeID; }
            set
            {
                mNumberingTypeID = value;
                NotifyPropertyChanged("NumberingTypeID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("NumberingTypeID", NumberingTypeID);
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
            if (obj is NumberingType)
            {
                NumberingType _obj = obj as NumberingType;
                return _obj.NumberingTypeID == NumberingTypeID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
