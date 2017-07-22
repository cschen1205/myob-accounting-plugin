using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class TerminationMethod : Entity
    {
        internal TerminationMethod(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private string mTerminationMethodID = "";
        public string TerminationMethodID
        {
            get { return mTerminationMethodID; }
            set
            {
                mTerminationMethodID = value;
                NotifyPropertyChanged("TerminationMethodID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("TerminationMethodID", TerminationMethodID);
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
            if (obj is TerminationMethod)
            {
                TerminationMethod _obj = obj as TerminationMethod;
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
