using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Sales
{
    public class RecurringItemSaleLine : RecurringSaleLine
    {
        #region -(Constructor)
        internal RecurringItemSaleLine(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {

        }
        #endregion

        //protected override RecurringSaleLine CreateLine()
        //{
        //    return new RecurringItemSaleLine(false, EntityBuilder);
        //}
        

        #region RecurringItemSaleLineID
        private int? mRecurringItemSaleLineID;
        public int? RecurringItemSaleLineID
        {
            get { return mRecurringItemSaleLineID; }
            set { mRecurringItemSaleLineID = value; }
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
            }
        }
        #endregion

        #region Quantity
        private double mQuantity;
        public double Quantity
        {
            get { return mQuantity; }
            set
            {
                mQuantity = value;
                NotifyPropertyChanged("Quantity");
            }
        }
        #endregion

        #region TaxExclusiveUnitPrice
        private double mTaxExclusiveUnitPrice;
        public double TaxExclusiveUnitPrice
        {
            get { return mTaxExclusiveUnitPrice; }
            set 
            {
                mTaxExclusiveUnitPrice = value;
                NotifyPropertyChanged("TaxExclusiveUnitPrice");
            }
        }
        #endregion

        #region TaxInclusiveUnitPrice
        private double mTaxInclusiveUnitPrice;
        public double TaxInclusiveUnitPrice
        {
            get { return mTaxInclusiveUnitPrice; }
            set 
            {
                mTaxInclusiveUnitPrice = value;
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
            }
        }
        #endregion

        #region Discount
        private double mDiscount;
        public double Discount
        {
            get { return mDiscount; }
            set 
            {
                mDiscount = value;
                NotifyPropertyChanged("TaxInclusiveTotal");
            }
        }
        #endregion)

        #region CostOfGoodsSoldAmount
        private double mCostOfGoodsSoldAmount;
        public double CostOfGoodsSoldAmount
        {
            get { return mCostOfGoodsSoldAmount; }
            set 
            {
                mCostOfGoodsSoldAmount = value;
                NotifyPropertyChanged("TaxInclusiveTotal");
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

        //#region Entity Override Methods
        //public override void AssignFrom(Entity rhs)
        //{
        //    base.AssignFrom(rhs);
        //    Copy2(rhs);

        //    RecurringItemSaleLine _obj = (RecurringItemSaleLine)rhs;
        //    RecurringItemSaleLineID = _obj.RecurringItemSaleLineID;
        //}
        //public override void Copy2(Entity rhs)
        //{
        //    base.Copy2(rhs);
        //    RecurringItemSaleLine _obj = (RecurringItemSaleLine)rhs;
        //    ItemID = _obj.ItemID;
        //    Item = _obj.Item;
        //    Quantity = _obj.Quantity;
        //    TaxExclusiveUnitPrice = _obj.TaxExclusiveUnitPrice;
        //    TaxInclusiveUnitPrice = _obj.TaxInclusiveUnitPrice;
        //    TaxInclusiveTotal = _obj.TaxInclusiveTotal;
        //    TaxInclusiveTotal = _obj.TaxInclusiveTotal;
        //    Discount = _obj.Discount;
        //    CostOfGoodsSoldAmount = _obj.CostOfGoodsSoldAmount;
        //    SalesTaxCalBasisID = _obj.SalesTaxCalBasisID;
        //    SalesTaxCalcBasis = _obj.SalesTaxCalcBasis;
        //}
        //#endregion
    }
}
