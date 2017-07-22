using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class TaxScale : Entity
    {
        internal TaxScale(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mTaxScaleID;
        public int? TaxScaleID
        {
            get { return mTaxScaleID; }
            set
            {
                mTaxScaleID = value;
                NotifyPropertyChanged("TaxScaleID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("TaxScaleID", TaxScaleID);
            }
        }

        public string Description;

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is TaxScale)
            {
                TaxScale _obj = obj as TaxScale;
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
