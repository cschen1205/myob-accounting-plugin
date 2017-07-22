using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.TaxCodes
{
    public class TaxCodeConsolidation : Entity
    {
        internal TaxCodeConsolidation(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mTaxCodeConsolidationID;
        public int? TaxCodeConsolidationID
        {
            get { return mTaxCodeConsolidationID; }
            set
            {
                mTaxCodeConsolidationID = value;
                NotifyPropertyChanged("TaxCodeConsolidationID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("TaxCodeConsolidationID", TaxCodeConsolidationID);
            }
        }

        #region ConsolidatedTaxCode
        private TaxCode mConsolidatedTaxCode = null;
        public TaxCode ConsolidatedTaxCode
        {
            get
            {
                if (mConsolidatedTaxCode == null)
                {
                    mConsolidatedTaxCode = (TaxCode)BuildProperty(this, "ConsolidatedTaxCode");
                }
                return mConsolidatedTaxCode;
            }
            set
            {
                mConsolidatedTaxCode = value;
                NotifyPropertyChanged("ConsolidatedTaxCode");
            }
        }
        private int? mConsolidatedTaxCodeID;
        public int? ConsolidatedTaxCodeID
        {
            get
            {
                if (mConsolidatedTaxCode != null)
                {
                    return mConsolidatedTaxCode.TaxCodeID;
                }
                return mConsolidatedTaxCodeID;
            }
            set
            {
                mConsolidatedTaxCodeID = value;
                NotifyPropertyChanged("ConsolidatedTaxCodeID");
            }
        }
        #endregion

        #region ElementTaxCode
        private TaxCode mElementTaxCode = null;
        public TaxCode ElementTaxCode
        {
            get
            {
                if (mElementTaxCode == null)
                {
                    mElementTaxCode = (TaxCode)BuildProperty(this, "ElementTaxCode");
                }
                return mElementTaxCode;
            }
            set
            {
                mElementTaxCode = value;
                NotifyPropertyChanged("ElementTaxCode");
            }
        }
        private int? mElementTaxCodeID;
        public int? ElementTaxCodeID
        {
            get
            {
                if (mElementTaxCode != null)
                {
                    return mElementTaxCode.TaxCodeID;
                }
                return mElementTaxCodeID;
            }
            set
            {
                mElementTaxCodeID = value;
                NotifyPropertyChanged("ElementTaxCodeID");
            }
        }
        #endregion
    }
}
