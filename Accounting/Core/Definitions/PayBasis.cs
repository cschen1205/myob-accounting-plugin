using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class PayBasis : Entity
    {
        internal PayBasis(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {

        }

        

        private string mPayBasisID = "";
        public string PayBasisID
        {
            get { return mPayBasisID; }
            set
            {
                mPayBasisID = value;
                NotifyPropertyChanged("PayBasisID");
            }
        }


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("PayBasisID", PayBasisID);
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
            if (obj is PayBasis)
            {
                PayBasis _obj = obj as PayBasis;
                return _obj.PayBasisID == PayBasisID;
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
