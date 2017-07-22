using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class Frequency : Entity
    {
        internal Frequency(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private string mFrequencyID = "";
        public string FrequencyID
        {
            get { return mFrequencyID; }
            set
            {
                mFrequencyID = value;
                NotifyPropertyChanged("FrequencyID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("FrequencyID", FrequencyID);
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
            if (obj is Frequency)
            {
                Frequency _obj = obj as Frequency;
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
