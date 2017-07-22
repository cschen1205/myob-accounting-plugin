using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Inventory
{
    using System.ComponentModel;

    using Accounting.Core.Misc;
    using Accounting.Core.Definitions;

    public class Item : Entity
    {
        #region -(Constructor)
        internal Item(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {

        }
        #endregion

        public override void AssignFrom(Entity rhs)
        {
            base.AssignFrom(rhs);

            Item _obj=rhs as Item;
            BindingList<ItemDataFieldEntry> _oldEntries = _obj.ItemDataFieldEntries;
            mItemDataFieldEntries = new BindingList<ItemDataFieldEntry>();
            foreach (ItemDataFieldEntry entry in _oldEntries)
            {
                mItemDataFieldEntries.Add(entry);
            }

        }

        private BindingList<ItemDataFieldEntry> mItemDataFieldEntries=null;
        public BindingList<ItemDataFieldEntry> ItemDataFieldEntries
        {
            get
            {
                if (mItemDataFieldEntries == null)
                {
                    mItemDataFieldEntries = new BindingList<ItemDataFieldEntry>();
                    IList<ItemDataFieldEntry> entries=RepositoryMgr.ItemDataFieldEntryMgr.FindCollectionByItemNumber(ItemNumber);
                    foreach (ItemDataFieldEntry entry in entries)
                    {
                        mItemDataFieldEntries.Add(entry);
                    }
                }
                return mItemDataFieldEntries;
            }
        }

        public ItemSize ItemSize
        {
            get { return ItemAddOn.ItemSize; }
            set { ItemAddOn.ItemSize=value; }
        }

        public bool Match(bool sold, bool bought, bool inventoried, Dictionary<string, string> keywords)
        {
            if (sold && ItemIsSold == "N") return false;
            if (bought && ItemIsBought == "N") return false;
            if (inventoried && ItemIsInventoried == "N") return false;

            foreach (string fieldname in keywords.Keys)
            {
                if (fieldname == "ItemName")
                {
                    if (!ItemName.Contains(keywords[fieldname]))
                    {
                        return false;
                    }
                }
                else if (fieldname == "ItemNumber")
                {
                    if (!ItemNumber.Contains(keywords[fieldname]))
                    {
                        return false;
                    }
                }
                else if (fieldname == "ItemDescription")
                {
                    if (!ItemDescription.Contains(keywords[fieldname]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public string LastCostText
        {
            get
            {
                Currencies.Currency currency = RepositoryMgr.CurrencyMgr.DefaultCurrency;
                return currency.Format(LastUnitPrice);
            }
        }

        public string SellPriceText
        {
            get
            {
                Currencies.Currency currency = RepositoryMgr.CurrencyMgr.DefaultCurrency;
                return currency.Format(BaseSellingPrice);
            }
        }

        public string ExpiryDateText
        {
            get
            {
                if (ExpiryDate == null) return "";
                else
                {
                    return ExpiryDate.Value.ToString("yyyy-MMM-dd");
                }
            }
        }

        public Gender Gender
        {
            get { return ItemAddOn.Gender; }
            set { ItemAddOn.Gender=value; }
        }

        public string Color
        {
            get { return ItemAddOn.Color; }
            set { ItemAddOn.Color=value; }
        }

        public string SerialNumber
        {
            get { return ItemAddOn.SerialNumber; }
            set { ItemAddOn.SerialNumber=value; }
        }

        public string BatchNumber
        {
            get { return ItemAddOn.BatchNumber; }
            set { ItemAddOn.BatchNumber=value; }
        }

        public string Brand
        {
            get { return ItemAddOn.Brand; }
            set { ItemAddOn.Brand=value; }
        }

        public DateTime? ExpiryDate
        {
            get { return ItemAddOn.ExpiryDate; }
            set { ItemAddOn.ExpiryDate=value; }
        }

        #region Picture
        private string mPicture="";
        public string Picture
        {
            get { return mPicture; }
            set 
            {
                mPicture = value;
                NotifyPropertyChanged("Picture");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("ItemID", ItemID);
            }
        }

        public override RecordKeyString TextId
        {
            get
            {
                return new RecordKeyString("ItemNumber", ItemNumber);
            }
        }

        #region ChangeControl
        private string mChangeControl;
        public string ChangeControl
        {
            set 
            {
                mChangeControl = value;
                NotifyPropertyChanged("ChangeControl");
            }
            get 
            {
                return mChangeControl; 
            }
        }
        #endregion

        #region DefaultSellLocation
        private int? mDefaultSellLocationID;
        public int? DefaultSellLocationID
        {
            set 
            {
                mDefaultSellLocationID=value;
                NotifyPropertyChanged("DefaultSellLocationID");
            }
            get {
                if (mDefaultSellLocation != null)
                {
                    return mDefaultSellLocation.LocationID;
                }
                return mDefaultSellLocationID; }
        }
        private Inventory.Location mDefaultSellLocation;
        public Inventory.Location DefaultSellLocation
        {
            get 
            {
                if (mDefaultSellLocation == null)
                {
                    mDefaultSellLocation = (Inventory.Location)BuildProperty(this, "DefaultSellLocation");
                }
                return mDefaultSellLocation; 
            }
            set
            {
                mDefaultSellLocation = value;
                NotifyPropertyChanged("DefaultSellLocation");
            }
        }
        #endregion

        #region DefaultReceiveLocation
        private int? mDefaultReceiveLocationID;
        public int? DefaultReceiveLocationID
        {
            set 
            {
                mDefaultReceiveLocationID = value;
                NotifyPropertyChanged("DefaultReceiveLocationID");
            }
            get {
                if (mDefaultReceiveLocation != null)
                {
                    return mDefaultReceiveLocation.LocationID;
                }
                return mDefaultReceiveLocationID; }
        }
        private Inventory.Location mDefaultReceiveLocation;
        public Inventory.Location DefaultReceiveLocation
        {
            get 
            {
                if (mDefaultReceiveLocation == null)
                {
                    mDefaultReceiveLocation = (Inventory.Location)BuildProperty(this, "DefaultReceiveLocation");
                }
                return mDefaultReceiveLocation; 
            }
            set
            {
                mDefaultReceiveLocation = value;
                NotifyPropertyChanged("DefaultReceiveLocation");
            }
        }
        #endregion

        #region DefaultReorderQuantity
        private double mDefaultReorderQuantity;
        public double DefaultReorderQuantity
        {
            get { return mDefaultReorderQuantity; }
            set 
            {
                mDefaultReorderQuantity = value;
                NotifyPropertyChanged("DefaultReorderQuantity");
            }
        }
        #endregion

        #region MinLevelBeforeReorder
        private double mMinLevelBeforeReorder;
        public double MinLevelBeforeReorder
        {
            get { return mMinLevelBeforeReorder; }
            set 
            {
                mMinLevelBeforeReorder = value;
                NotifyPropertyChanged("MinLevelBeforeReorder");
            }
        }
        #endregion

        #region SupplierItemNumber
        private string mSupplierItemNumber;
        public string SupplierItemNumber
        {
            get { return mSupplierItemNumber; }
            set 
            {
                mSupplierItemNumber=value;
                NotifyPropertyChanged("SupplierItemNumber");
            }
        }
        #endregion

        #region PrimarySupplier;
        private int? mPrimarySupplierID;
        public int? PrimarySupplierID
        {
            set 
            {
                mPrimarySupplierID = value;
                NotifyPropertyChanged("PrimarySupplierID");
            }
            get {
                if (mPrimarySupplier != null)
                {
                    return mPrimarySupplier.CardRecordID;
                }
                return mPrimarySupplierID; }
        }
        private Cards.Supplier mPrimarySupplier;
        public Cards.Supplier PrimarySupplier
        {
            get 
            {
                if (mPrimarySupplier == null)
                {
                    mPrimarySupplier = (Cards.Supplier)BuildProperty(this, "PrimarySupplier");
                }
                return mPrimarySupplier; 
            }
            set
            {
                mPrimarySupplier = value;
                NotifyPropertyChanged("PrimarySupplier");
            }
        }
        #endregion

        #region BuyUnitQuantity
        private int? mBuyUnitQuantity=0;
        public int? BuyUnitQuantity
        {
            get { return mBuyUnitQuantity; }
            set 
            {
                mBuyUnitQuantity = value;
                NotifyPropertyChanged("BuyUnitQuantity");
            }
        }
        #endregion

        #region BuyUnitMeasure
        private string mBuyUnitMeasure;
        public string BuyUnitMeasure
        {
            get { return mBuyUnitMeasure; }
            set 
            {
                mBuyUnitMeasure = value;
                NotifyPropertyChanged("BuyUnitMeasure");
            }
        }
        #endregion

        #region BuyTaxCode
        private int? mBuyTaxCodeID;
        public int? BuyTaxCodeID
        {
            get {
                if (mBuyTaxCode != null)
                {
                    return mBuyTaxCode.TaxCodeID;
                }
                return mBuyTaxCodeID; }
            set 
            {
                mBuyTaxCodeID = value;
                NotifyPropertyChanged("BuyTaxCodeID");
            }
        }
        private TaxCodes.TaxCode mBuyTaxCode;
        public TaxCodes.TaxCode BuyTaxCode
        {
            get 
            {
                if (mBuyTaxCode == null)
                {
                    mBuyTaxCode = (TaxCodes.TaxCode)BuildProperty(this, "BuyTaxCode");
                }
                return mBuyTaxCode; 
            }
            set
            {
                mBuyTaxCode = value;
                NotifyPropertyChanged("BuyTaxCode");
            }
        }
        #endregion

        #region TaxExclusiveStandardCost
        private double mTaxExclusiveStandardCost;
        public double TaxExclusiveStandardCost
        {
            get { return mTaxExclusiveStandardCost; }
            set 
            {
                mTaxExclusiveStandardCost = value;
                NotifyPropertyChanged("TaxExclusiveStandardCost");
            }
        }
        #endregion

        #region TaxInclusiveStandardCost
        private double mTaxInclusiveStandardCost;
        public double TaxInclusiveStandardCost
        {
            get { return mTaxInclusiveStandardCost; }
            set 
            {
                mTaxInclusiveStandardCost=value;
                NotifyPropertyChanged("TaxInclusiveStandardCost");
            }
        }
        #endregion

        #region TaxExclusiveLastPurchasePrice
        private double mTaxExclusiveLastPurchasePrice;
        public double TaxExclusiveLastPurchasePrice
        {
            get { return mTaxExclusiveLastPurchasePrice; }
            set 
            {
                mTaxExclusiveLastPurchasePrice = value;
                NotifyPropertyChanged("TaxExclusiveLastPurchasePrice");
            }
        }
        #endregion

        #region TaxInclusiveLastPurchasePrice
        private double mTaxInclusiveLastPurchasePrice;
        public double TaxInclusiveLastPurchasePrice
        {
            get { return mTaxInclusiveLastPurchasePrice; }
            set 
            {
                mTaxInclusiveLastPurchasePrice = value;
                NotifyPropertyChanged("TaxInclusiveLastPurchasePrice");
            }
        }
        #endregion

        #region SellUnitQuantity
        private int? mSellUnitQuantity=0;
        public int? SellUnitQuantity
        {
            get { return mSellUnitQuantity; }
            set 
            {
                mSellUnitQuantity = value;
                NotifyPropertyChanged("SellUnitQuantity");
            }
        }
        #endregion

        #region SellUnitMeasure
        private string mSellUnitMeasure;
        public string SellUnitMeasure
        {
            get { return mSellUnitMeasure; }
            set 
            {
                mSellUnitMeasure = value;
                NotifyPropertyChanged("SellUnitMeasure");
            }
        }
        #endregion

        #region BaseSellingPrice
        private double mBaseSellingPrice;
        public double BaseSellingPrice
        {
            get { return mBaseSellingPrice; }
            set 
            {
                mBaseSellingPrice = value;
                NotifyPropertyChanged("BaseSellingPrice");
            }
        }
        #endregion

        #region ItemDescription
        private string mItemDescription;
        public string ItemDescription
        {
            set 
            {
                mItemDescription = value;
                NotifyPropertyChanged("ItemDescription");
            }
            get { return mItemDescription; }
        }
        #endregion

        #region UseDescription
        private string mUseDescription="Y";
        public string UseDescription
        {
            get { return mUseDescription; }
            set 
            {
                mUseDescription = value;
                NotifyPropertyChanged("UseDescription");
            }
        }
        #endregion

        #region SellTaxCode
        private int? mSellTaxCodeID;
        public int? SellTaxCodeID
        {
            set 
            {
                mSellTaxCodeID = value;
                NotifyPropertyChanged("SellTaxCodeID");
            }
            get {
                if (mSellTaxCode != null)
                {
                    return SellTaxCode.TaxCodeID;
                }
                return mSellTaxCodeID; }
        }
        private TaxCodes.TaxCode mSellTaxCode;
        public TaxCodes.TaxCode SellTaxCode
        {
            get 
            {
                if (mSellTaxCode == null)
                {
                    mSellTaxCode = (TaxCodes.TaxCode)BuildProperty(this, "SellTaxCode");
                }
                return mSellTaxCode; 
            }
            set
            {
                mSellTaxCode = value;
                NotifyPropertyChanged("SellTaxCode");
            }
        }
        #endregion

        #region InventoryAccount
        private int? mInventoryAccountID;
        public int? InventoryAccountID
        {
            set 
            {
                mInventoryAccountID = value;
                NotifyPropertyChanged("InventoryAccountID");
            }
            get {
                if (mInventoryAccount != null)
                {
                    return mInventoryAccount.AccountID;
                }
                return mInventoryAccountID; }
        }
        private Accounts.Account mInventoryAccount;
        public Accounts.Account InventoryAccount
        {
            get 
            {
                if (mInventoryAccount == null)
                {
                    mInventoryAccount = (Accounts.Account)BuildProperty(this, "InventoryAccount");
                }
                return mInventoryAccount; 
            }
            set
            {
                mInventoryAccount = value;
                NotifyPropertyChanged("InventoryAccount");
            }
        }
        #endregion

        #region IncomeAccount
        private int? mIncomeAccountID;
        public int? IncomeAccountID
        {
            set 
            {
                mIncomeAccountID = value;
                NotifyPropertyChanged("IncomeAccountID");
            }
            get {
                if (mIncomeAccount != null)
                {
                    return mIncomeAccount.AccountID;
                }
                return mIncomeAccountID; }
        }
        private Accounts.Account mIncomeAccount;
        public Accounts.Account IncomeAccount
        {
            get 
            {
                if (mIncomeAccount == null)
                {
                    mIncomeAccount = (Accounts.Account)BuildProperty(this, "IncomeAccount");
                }
                return mIncomeAccount; 
            }
            set
            {
                mIncomeAccount = value;
                NotifyPropertyChanged("IncomeAccount");
            }
        }
        #endregion

        #region ExpenseAccount
        private int? mExpenseAccountID;
        public int? ExpenseAccountID
        {
            set 
            {
                mExpenseAccountID = value;
                NotifyPropertyChanged("ExpenseAccountID");
            }
            get {
                if (mExpenseAccount != null)
                {
                   return mExpenseAccount.AccountID;
                }
                return mExpenseAccountID; }
        }
        private Accounts.Account mExpenseAccount;
        public Accounts.Account ExpenseAccount
        {
            get 
            {
                if (mExpenseAccount == null)
                {
                    mExpenseAccount = (Accounts.Account)BuildProperty(this, "ExpenseAccount");
                }
                return mExpenseAccount; 
            }
            set
            {
                mExpenseAccount = value;
                NotifyPropertyChanged("ExpenseAccount");
            }
        }
        #endregion

        #region ItemIsInventoried
        private string mItemIsInventoried="N";
        public string ItemIsInventoried
        {
            get { return mItemIsInventoried; }
            set 
            {
                mItemIsInventoried = value;
                NotifyPropertyChanged("ItemIsInventoried");
            }
        }
        #endregion

        #region ItemIsBought
        private string mItemIsBought = "N";
        public string ItemIsBought
        {
            get { return mItemIsBought; }
            set 
            {
                mItemIsBought = value;
                NotifyPropertyChanged("ItemIsBought");
            }
        }
        #endregion

        #region ItemIsSold
        private string mItemIsSold = "N";
        public string ItemIsSold
        {
            get { return mItemIsSold; }
            set 
            {
                mItemIsSold=value;
                NotifyPropertyChanged("ItemIsSold");
            }
        }
        #endregion

        #region NegativeAverageCost
        private double mNegativeAverageCost;
        public double NegativeAverageCost
        {
            get { return mNegativeAverageCost; }
            set 
            {
                mNegativeAverageCost = value;
                NotifyPropertyChanged("NegativeAverageCost");
            }
        }
        #endregion

        #region NegativeQuantityOnHand
        private double mNegativeQuantityOnHand;
        public double NegativeQuantityOnHand
        {
            get { return mNegativeQuantityOnHand; }
            set 
            {
                mNegativeQuantityOnHand = value;
                NotifyPropertyChanged("NegativeQuantityOnHand");
            }
        }
        #endregion

        #region LastUnitPrice
        private double mLastUnitPrice;
        public double LastUnitPrice
        {
            get { return mLastUnitPrice; }
            set 
            {
                mLastUnitPrice = value;
                NotifyPropertyChanged("LastUnitPrice");
            }
        }
        #endregion

        #region QuantityAvailable
        private double mQuantityAvailable;
        public double QuantityAvailable
        {
            get { return mQuantityAvailable; }
            set 
            {
                mQuantityAvailable = value;
                NotifyPropertyChanged("QuantityAvailable");
            }
        }
        #endregion 

        #region ReceivedOnOrder
        private double mReceivedOnOrder;
        public double ReceivedOnOrder
        {
            get { return mReceivedOnOrder; }
            set
            {
                mReceivedOnOrder = value;
                NotifyPropertyChanged("ReceivedOnOrder");
            }
        }
        #endregion

        #region QuantityOnHand
        private double mQuantityOnHand;
        public double QuantityOnHand
        {
            get { return mQuantityOnHand; }
            set 
            {
                mQuantityOnHand = value;
                NotifyPropertyChanged("QuantityOnHand");
            }
        }
        #endregion

        #region ValueOnHand
        private double mValueOnHand;
        public double ValueOnHand
        {
            get { return mValueOnHand; }
            set 
            {
                mValueOnHand = value;
                NotifyPropertyChanged("ValueOnHand");
            }
        }
        #endregion

        #region PositiveAverageCost
        private double mPositiveAverageCost;
        public double PositiveAverageCost
        {
            get { return mPositiveAverageCost; }
            set 
            {
                mPositiveAverageCost = value;
                NotifyPropertyChanged("PositiveAverageCost");
            }
        }
        #endregion

        #region SellOnOrder
        private double mSellOnOrder;
        public double SellOnOrder
        {
            get { return mSellOnOrder; }
            set 
            {
                mSellOnOrder = value;
                NotifyPropertyChanged("SellOnOrder");
            }
        }
        #endregion

        #region PurchaseOnOrder
        private double mPurchaseOnOrder;
        public double PurchaseOnOrder
        {
            get { return mPurchaseOnOrder; }
            set 
            {
                mPurchaseOnOrder = value;
                NotifyPropertyChanged("PurchaseOnOrder");
            }
        }
        #endregion

        #region ItemID
        private int? mItemID;
        public int? ItemID
        {
            get { return mItemID; }
            set 
            {
                mItemID = value;
                NotifyPropertyChanged("ItemID");
            }
        }
        #endregion

        #region IsInactive
        private string mIsInactive="N";
        public string IsInactive
        {
            get { return mIsInactive; }
            set 
            {
                mIsInactive = value;
                NotifyPropertyChanged("IsInactive");
            }
        }
        #endregion

        #region ItemName
        private string mItemName;
        public string ItemName
        {
            get { return mItemName; }
            set
            {
                mItemName = value;
                NotifyPropertyChanged("ItemName");
            }
        }
        #endregion

        #region ItemNumber
        private string mItemNumber;
        public string ItemNumber
        {
            get { return mItemNumber; }
            set
            {
                mItemNumber = value;
                NotifyPropertyChanged("ItemNumber");
            }
        }
        #endregion

        #region ItemAddOn
        private ItemAddOn mItemAddOn = null;
        public ItemAddOn ItemAddOn
        {
            get
            {
                if (mItemAddOn == null)
                {
                    mItemAddOn = (ItemAddOn)BuildProperty(this, "ItemAddOn");
                    if (mItemAddOn == null)
                    {
                        mItemAddOn = RepositoryMgr.ItemAddOnMgr.CreateEntity();
                        mItemAddOn.ItemNumber = ItemNumber;
                    }
                }
                return mItemAddOn;
            }
        }
        #endregion

        #region PriceIsInclusive
        private string mPriceIsInclusive="N"; //is tax inclusive
        public string PriceIsInclusive
        {
            get { return mPriceIsInclusive; }
            set 
            {
                mPriceIsInclusive = value;
                NotifyPropertyChanged("PriceIsInclusive");
            }
        }
        #endregion

        #region SalesTaxCalcBasis
        private string mSalesTaxCalcBasisID;
        public string SalesTaxCalcBasisID
        {
            get {
                if (mSalesTaxCalcBasis != null)
                {
                    return mSalesTaxCalcBasis.PriceLevelID;
                }
                return mSalesTaxCalcBasisID; }
            set
            {
                mSalesTaxCalcBasisID = value;
                NotifyPropertyChanged("SalesTaxCalcBasisID");
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

        #region CustomField1
        private string mCustomField1 = "";
        public string CustomField1
        {
            get { return mCustomField1; }
            set 
            {
                mCustomField1 = value;
                NotifyPropertyChanged("CustomField1");
            }
        }
        #endregion

        #region CustomList1ID
        private CustomList mCustomList1 = null;
        public CustomList CustomList1
        {
            get
            {
                if (mCustomList1 == null)
                {
                    mCustomList1 = (CustomList)BuildProperty(this, "CustomList1");
                }
                return mCustomList1;
            }
            set
            {
                mCustomList1 = value;
                NotifyPropertyChanged("CustomList1");
            }
        }
        private int? mCustomList1ID = null;
        public int? CustomList1ID
        {
            get
            {
                if (mCustomList1 != null)
                {
                    return mCustomList1.CustomListID;
                }
                return mCustomList1ID;
            }
            set 
            {
                mCustomList1ID = value;
                NotifyPropertyChanged("CustomList1ID");
            }
        }
        #endregion

        #region CustomField2
        private string mCustomField2 = "";
        public string CustomField2
        {
            get { return mCustomField2; }
            set 
            {
                mCustomField2 = value;
                NotifyPropertyChanged("CustomField2");
            }
        }
        #endregion

        #region CustomList2ID
        private CustomList mCustomList2 = null;
        public CustomList CustomList2
        {
            get
            {
                if (mCustomList2 == null)
                {
                    mCustomList2 = (CustomList)BuildProperty(this, "CustomList2");
                }
                return mCustomList2;
            }
            set
            {
                mCustomList2 = value;
                NotifyPropertyChanged("CustomList2");
            }
        }
        private int? mCustomList2ID = null;
        public int? CustomList2ID
        {
            get
            {
                if (mCustomList2 != null)
                {
                    return mCustomList2.CustomListID;
                }
                return mCustomList2ID;
            }
            set 
            {
                mCustomList2ID = value;
                NotifyPropertyChanged("CustomList2ID");
            }
        }
        #endregion

        #region CustomField3
        private string mCustomField3 = "";
        public string CustomField3
        {
            get { return mCustomField3; }
            set 
            {
                mCustomField3 = value;
                NotifyPropertyChanged("CustomField3");
            }
        }
        #endregion

        #region CustomList3ID
        private CustomList mCustomList3 = null;
        public CustomList CustomList3
        {
            get
            {
                if (mCustomList3 == null)
                {
                    mCustomList3 = (CustomList)BuildProperty(this, "CustomList3");
                }
                return mCustomList3;
            }
            set
            {
                mCustomList3 = value;
                NotifyPropertyChanged("CustomList3");
            }
        }
        private int? mCustomList3ID;
        public int? CustomList3ID
        {
            get
            {
                if (mCustomList3 != null)
                {
                    return mCustomList3.CustomListID;
                }
                return mCustomList3ID;
            }
            set 
            {
                mCustomList3ID = value;
                NotifyPropertyChanged("CustomList3ID");
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override bool Equals(object obj)
        {
            if (obj is Item)
            {
                Item _obj = (Item)obj;
                return _obj.ItemID == mItemID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return ItemName;
        }
        #endregion
    }
}
