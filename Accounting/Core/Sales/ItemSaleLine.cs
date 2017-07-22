using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Sales
{
    public class ItemSaleLine : SaleLine
    {
        #region -(Constructor)
        internal ItemSaleLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {

        }
        #endregion

        //protected override SaleLine CreateLine()
        //{
        //    return new ItemSaleLine(false, EntityBuilder);
        //}

        #region ItemSaleLineID
        private int? mItemSaleLineID;
        public int? ItemSaleLineID
        {
            get { return mItemSaleLineID; }
            set { mItemSaleLineID = value;
            NotifyPropertyChanged("ItemSaleLineID");
            }
        }
        #endregion

        #region Item
        private int? mItemID;
        public int? ItemID
        {
            get {
                if (mItem != null)
                {
                    return mItem.ItemID;
                }
                return mItemID; }
            set { mItemID = value;
            NotifyPropertyChanged("ItemID");
            }
        }
        private Inventory.Item mItem;
        public Inventory.Item Item
        {
            get
            {
                if (mItem == null)
                {
                    mItem = (Inventory.Item)BuildProperty(this, "Item");
                }
                return mItem;
            }
            set
            {
                mItem = value;
                NotifyPropertyChanged("Item");
                NotifyPropertyChanged("ItemNumber");
                NotifyPropertyChanged("ItemName");
            }
        }
        public string ItemNumber
        {
            get
            {
                if (Item != null) return Item.ItemNumber;
                return "";
            }
        }
        public string ItemName
        {
            get
            {
                if (Item != null) return Item.ItemName;
                return "";
            }
        }
        #endregion

        #region Quantity
        private double mQuantity;
        public double Quantity
        {
            get { return mQuantity; }
            set { mQuantity = value;
            NotifyPropertyChanged("Quantity");
            }
        }
        #endregion

        public double _Ordered
        {
            get { return Quantity; }
        }

        public double _Invoiced
        {
            get { return Quantity; }
        }


        #region TaxExclusiveUnitPrice
        private double mTaxExclusiveUnitPrice;
        public double TaxExclusiveUnitPrice
        {
            get { return mTaxExclusiveUnitPrice; }
            set { mTaxExclusiveUnitPrice = value;
            NotifyPropertyChanged("TaxExclusiveUnitPrice");
            }
        }
        #endregion

        #region TaxInclusiveUnitPrice
        private double mTaxInclusiveUnitPrice;
        public double TaxInclusiveUnitPrice
        {
            get { return mTaxInclusiveUnitPrice; }
            set { mTaxInclusiveUnitPrice = value;
            NotifyPropertyChanged("TaxInclusiveUnitPrice");
            }
        }
        #endregion

        #region TaxExclusiveTotal
        private double mTaxExclusiveTotal;
        public double TaxExclusiveTotal
        {
            get { return mTaxExclusiveTotal; }
            set 
            { 
                mTaxExclusiveTotal = value;
                NotifyPropertyChanged("TaxExclusiveTotal");
                TaxExclusiveAmount = value;
            }
        }
        #endregion

        #region TaxInclusiveTotal
        private double mTaxInclusiveTotal;
        public double TaxInclusiveTotal
        {
            get { return mTaxInclusiveTotal; }
            set 
            {
                mTaxInclusiveTotal = value;
                NotifyPropertyChanged("TaxInclusiveTotal");
                TaxInclusiveAmount = value;
            }
        }
        #endregion

        #region Discount
        private double mDiscount;
        public double Discount
        {
            get { return mDiscount; }
            set { mDiscount = value;
            NotifyPropertyChanged("Discount");
            }
        }
        #endregion)

        #region CostOfGoodsSoldAmount
        private double mCostOfGoodsSoldAmount;
        public double CostOfGoodsSoldAmount
        {
            get { return mCostOfGoodsSoldAmount; }
            set { mCostOfGoodsSoldAmount = value;
            NotifyPropertyChanged("CostOfGoodsSoldAmount");
            }
        }
        #endregion

        #region SalesTaxCalBasis
        private string mSalesTaxCalBasisID;
        public string SalesTaxCalBasisID
        {
            set
            {
                mSalesTaxCalBasisID = value;
                NotifyPropertyChanged("SalesTaxCalBasisID");
            }
            get
            {
                if (mSalesTaxCalcBasis != null)
                {
                    return mSalesTaxCalcBasis.PriceLevelID;
                }
                return mSalesTaxCalBasisID;
            }
        }
        private Definitions.PriceLevel mSalesTaxCalcBasis;
        public Definitions.PriceLevel SalesTaxCalcBasis
        {
            get 
            {
                if (mSalesTaxCalcBasis == null)
                {
                    mSalesTaxCalcBasis = (Definitions.PriceLevel)BuildProperty(this, "SalesTaxCalcBasis");
                }
                return mSalesTaxCalcBasis; 
            }
            set
            {
                mSalesTaxCalcBasis = value;
                NotifyPropertyChanged("SalesTaxCalcBasis");
            }
        }
        #endregion


        #region Location
        private int? mLocationID;
        public int? LocationID
        {
            get {
                if (mLocation != null)
                {
                    return mLocation.LocationID;
                }
                return mLocationID; }
            set 
            {
                mLocationID = value;
                NotifyPropertyChanged("LocationID");
            }
        }
        private Inventory.Location mLocation;
        public Inventory.Location Location
        {
            get 
            {
                if (mLocation == null)
                {
                    mLocation = (Inventory.Location)BuildProperty(this, "Location");
                }
                return mLocation; 
            }
            set 
            { 
                mLocation = value;
                NotifyPropertyChanged("Location");
            }
        }
        #endregion

        public double Price
        {
            get
            {
                if (TaxBasisAmountIsInclusive == "Y")
                {
                    return TaxInclusiveUnitPrice;
                }
                else
                {
                    return TaxExclusiveUnitPrice;
                }
            }
        }

        public string _Price
        {
            get
            {
                return this.Sale.Currency.Format(Price);
            }
        }

        public override void Evaluate()
        {
            TaxInclusiveAmount = TaxInclusiveTotal = TaxInclusiveUnitPrice * Quantity;
            TaxExclusiveAmount = TaxExclusiveTotal = TaxExclusiveUnitPrice * Quantity;

            if (TaxBasisAmountIsInclusive == "Y")
            {
                TaxBasisAmount = TaxInclusiveAmount;

            }
            else
            {
                TaxBasisAmount = TaxExclusiveAmount;
            }

            NotifyPropertyChanged("Price");
            NotifyPropertyChanged("_Price");
            NotifyPropertyChanged("_Total");
        }
    }
}
