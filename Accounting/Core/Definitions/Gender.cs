using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class Gender : Entity
    {
        internal Gender(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

      

        private string mGenderID = "M";
        public string GenderID
        {
            get { return mGenderID; }
            set
            {
                mGenderID = value;
                NotifyPropertyChanged("GenderID");
            }
        }

        //public override void Copy2(Entity rhs)
        //{
        //    base.Copy2(rhs);
        //    Gender _rhs=rhs as Gender;
        //    mGenderID = _rhs.GenderID;
        //    mDescription = _rhs.Description;
        //}

        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("GenderID", GenderID);
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
            if (obj is Gender)
            {
                Gender _obj = obj as Gender;
                return _obj.GenderID == GenderID;
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
