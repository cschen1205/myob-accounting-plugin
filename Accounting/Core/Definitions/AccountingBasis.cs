using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class AccountingBasis : Entity
    {
        internal AccountingBasis(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private string mAccountingBasisID = "";
        public string AccountingBasisID
        {
            get { return mAccountingBasisID; }
            set
            {
                mAccountingBasisID = value;
                NotifyPropertyChanged("AccountingBasisID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("AccountingBasisID", AccountingBasisID);
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
            if (obj == null)
            {
                return false;
            }
            if (obj is AccountingBasis)
            {
                AccountingBasis _obj = obj as AccountingBasis;
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
