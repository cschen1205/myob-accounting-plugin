using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Definitions
{
    public class PriceLevel : Entity
    {
        #region PriceLevel constructor
        internal PriceLevel(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region PriceLevelID
        private string mPriceLevelID="";
        public string PriceLevelID
        {
            get { return mPriceLevelID; }
            set 
            {
                mPriceLevelID = value;
                NotifyPropertyChanged("PriceLevelID");
            }
        }
        #endregion


        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("PriceLevelID", PriceLevelID);
            }
        }

        #region Description
        private string mDescription="";
        public string Description
        {
            get { return mDescription; }
            set 
            {
                mDescription = value;
                NotifyPropertyChanged("Description");
            }
        }
        #endregion

        #region ImportPriceLevel
        private string mImportPriceLevel="";
        public string ImportPriceLevel
        {
            get { return mImportPriceLevel; }
            set 
            {
                mImportPriceLevel = value;
                NotifyPropertyChanged("ImportPriceLevel");
            }
        }
        #endregion 

        #region ImportSalesTaxCalcMethod
        private string mImportSalesTaxCalcMethod="";
        public string ImportSalesTaxCalcMethod
        {
            get { return mImportSalesTaxCalcMethod; }
            set 
            {
                mImportSalesTaxCalcMethod = value;
                NotifyPropertyChanged("ImportSalesTaxCalcMethod");
            }
        }
        #endregion 

        #region Method
        public int? SalesTaxCalcMethod
        {
            get
            {
                int result;
                if (int.TryParse(ImportSalesTaxCalcMethod, out result))
                {
                    return result;
                }
                return null;
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override string ToString()
        {
            return mDescription;
        }

        public override bool Equals(object obj)
        {
            if (obj is PriceLevel)
            {
                PriceLevel _obj = (PriceLevel)obj;
                return _obj.PriceLevelID == mPriceLevelID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
