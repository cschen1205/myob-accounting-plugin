using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class CalculationMethod : Entity
    {
        internal CalculationMethod(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private string mCalculationMethodID = "";
        public string CalculationMethodID
        {
            get { return mCalculationMethodID; }
            set
            {
                mCalculationMethodID = value;
                NotifyPropertyChanged("CalculationMethodID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("CalculationMethodID", CalculationMethodID);
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
            if (obj is CalculationMethod)
            {
                CalculationMethod _obj = obj as CalculationMethod;
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
