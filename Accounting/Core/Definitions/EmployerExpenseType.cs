using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class EmployerExpenseType : Entity
    {
        internal EmployerExpenseType(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private string mEmployerExpenseTypeID = "";
        public string EmployerExpenseTypeID
        {
            get { return mEmployerExpenseTypeID; }
            set
            {
                mEmployerExpenseTypeID = value;
                NotifyPropertyChanged("EmployerExpenseTypeID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("EmployerExpenseTypeID", EmployerExpenseTypeID);
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
            if (obj == null) return false;
            if (obj is EmployerExpenseType)
            {
                EmployerExpenseType _obj = obj as EmployerExpenseType;
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
