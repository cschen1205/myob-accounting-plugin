using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Inventory
{
    using Accounting.Core;
    using Accounting.Core.Inventory;
    using Accounting.Core.TaxCodes;
    using Accounting.Core.Cards;
    using Accounting.Core.Definitions;
    using Accounting.Core.Accounts;
    using System.ComponentModel;

    public class BOItem : BusinessObject
    {
        public static string ITEM_NUMBER = "ItemNumber";
        public static string ITEM_NAME = "ItemName";
        public static string ITEM_IS_SOLD = "ItemIsSold";
        public static string ITEM_IS_BOUGHT = "ItemIsBought";
        public static string ITEM_IS_INVENTORIED = "ItemIsInventoried";
        public static string QUANTITY_ON_HAND = "QuantityOnHand";
        public static string VALUE_ON_HAND = "ValueOnHand";
        public static string POSITIVE_AVERAGE_COST="PositiveAverageCost";
        public static string SELL_ON_ORDER="SellOnOrder";
        public static string PURCHASE_ON_ORDER="PurchaseOnOrder";
        public static string QUANTITY_AVAILABLE="QuantityAvailable";
        public static string LAST_UNIT_PRICE="LastUnitPrice";
        public static string BUY_UNIT_MEASURE="BuyUnitMeasure";
        public static string BUY_UNIT_QUANTITY="BuyUnitQuantity";
        public static string BASE_SELLING_PRICE="BaseSellingPrice";
        public static string SELL_UNIT_QUANTITY="SellUnitQuantity";
        public static string SELL_UNIT_MEASURE="SellUnitMeasure";
        public static string EXPIRY_DATE = "ExpiryDate";
        public static string PRICE_IS_INCLUSIVE = "PriceIsInclusive";
        public static string DEFAULT_REORDER_QUANITTY="DefaultReorderQuantity";
        public static string IS_INACTIVE="IsInactive";
        public static string MIN_LEVEL_BEFORE_REORDER="MinLevelBeforeReorder";
        public static string COLOR = "Color";
        public static string SUPPLIER_ITEM_NUMBER="SupplierItemNumber";
        public static string ITEM_DESCRIPTION="ItemDescription";
        public static string BATCH_NUMBER = "BatchNumber";
        public static string USE_DESCRIPTION="UseDescription";
        public static string PICTURE = "Picture";
        public static string PICTURE_PATH = "PicturePath";
        public static string INCOME_ACCOUNT="IncomeAccount";
        public static string EXPENSE_ACCOUNT = "ExpenseAccount";
        public static string INVENTORY_ACCOUNT = "InventoryAccount";
        public static string BUY_TAXCODE="BuyTaxCode";
        public static string SELL_TAXCODE="SellTaxCode";
        public static string BRAND = "Brand";
        public static string PRIMARY_SUPPLIER = "PrimarySupplier";
        public static string SERIAL_NUMBER="SerialNumber";
        public static string GENDER = "Gender";
        public static string ITEM_SIZE="ItemSize";
        public static string SALES_TAX_CALC_BASIS="SalesTaxCalcBasis";

        public static string CUSTOM_FIELD1 = "CustomField1";
        public static string CUSTOM_FIELD2 = "CustomField2";
        public static string CUSTOM_FIELD3 = "CustomField3";

        private Item mDataProxy = null;
        private Item mDataSource = null;

        public Item Data
        {
            get { return mDataProxy; }
        }

        public BOItem(Accountant accountant, Item _obj, BOContext _state)
            : base(accountant, _state)
        {
            mObjectID = BOType.BOItem;
            mDataSource = _obj;
            mDataProxy = _obj.Clone() as Item;
        }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();
            BOProperty record_property = GetProperty(PERSIST_OBJECT);
            if(record_property != null)
            {
                record_property.ValidateEnableHandler = delegate() { return true; };
            }

            #region ITEM_NUMBER
            AddProperty(ITEM_NUMBER,
                ITEM_NUMBER,
                delegate
                {
                    return mDataProxy.ItemNumber;
                },
                delegate(object value)
                {
                    mDataProxy.ItemNumber = value as string;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsAlphaNumeric(value as string, 1, 30, out error))
                        {
                            if (this.RecordContext == BOContext.Record_Create)
                            {
                                string itemNumber = value as string;
                                itemNumber = itemNumber.Trim();
                                if (mAccountant.ItemMgr.ExistsByItemNumber(itemNumber))
                                {
                                    error = DecorateEntityAlreadyExistError(ITEM_NUMBER, itemNumber);
                                    return false;
                                }
                            }
                            return true;
                        }
                        error = DecorateError(ITEM_NUMBER, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ITEM_NUMBER, "string");
                    }
                    return false;
                }
                );
            #endregion

            #region ITEM_NAME
            AddProperty(ITEM_NAME,
                ITEM_NAME,
                delegate()
                {
                    return mDataProxy.ItemName;
                },
                delegate(object value)
                {
                    mDataProxy.ItemName = value as string;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        string _obj = value as string;
                        if (IsWithinRange(_obj, 1, 30, out error))
                        {
                            if (this.RecordContext == BOContext.Record_Create)
                            {
                                string itemName = value as string;
                                itemName = itemName.Trim();
                                if (mAccountant.ItemMgr.ExistsByItemName(itemName))
                                {
                                    error = DecorateEntityAlreadyExistError(ITEM_NAME, itemName);
                                    return false;
                                }
                            }
                            return true;
                        }
                        error = DecorateError(ITEM_NAME, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ITEM_NAME, "string");
                    }
                    return false;
                });
            #endregion

            #region ITEM_IS_SOLD
            AddProperty(ITEM_IS_SOLD,
                ITEM_IS_SOLD,
                delegate()
                {
                    return mDataProxy.ItemIsSold.Equals("Y");
                },
                delegate(object value)
                {
                    mDataProxy.ItemIsSold = (bool)value ? "Y" : "N";
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is bool)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(ITEM_IS_SOLD, "bool");
                    return false;
                });
            #endregion

            #region ITEM_IS_BOUGHT
            AddProperty(ITEM_IS_BOUGHT,
                ITEM_IS_BOUGHT,
                delegate()
                {
                    return mDataProxy.ItemIsBought.Equals("Y");
                },
                delegate(object value)
                {
                    mDataProxy.ItemIsBought = (bool)value ? "Y" : "N";
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is bool)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(ITEM_IS_BOUGHT, "bool");
                    return false;
                });
            #endregion

            #region ITEM_IS_INVENTORIED
            AddProperty(ITEM_IS_INVENTORIED,
                ITEM_IS_INVENTORIED,
                delegate()
                {
                    return mDataProxy.ItemIsInventoried.Equals("Y");
                },
                delegate(object value)
                {
                    mDataProxy.ItemIsInventoried = (bool)value ? "Y" : "N";
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is bool)
                    {
                        return true;
                    }
                    error="Item.ItemIsInventoried must be of type bool";
                    return false;
                });
            #endregion

            #region QUANTITY_ON_HAND
            AddProperty(QUANTITY_ON_HAND,
                QUANTITY_ON_HAND,
                delegate()
                {
                    return mDataProxy.QuantityOnHand;
                },
                delegate(object value)
                {
                    
                },
                delegate()
                {
                    return false;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    return true;
                });
            #endregion

            #region VALUE_ON_HAND
            AddProperty(VALUE_ON_HAND,
                VALUE_ON_HAND,
                delegate()
                {
                    return mDataProxy.ValueOnHand;
                },
                delegate(object value)
                {
                },
                delegate()
                {
                    return false;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    return true;
                }
            );
            #endregion

            #region POSITIVE_AVERAGE_COST
            AddProperty(POSITIVE_AVERAGE_COST,
                POSITIVE_AVERAGE_COST,
                delegate()
                {
                    return mDataProxy.PositiveAverageCost;
                },
                delegate(object value)
                {
                  
                },
                delegate()
                {
                    return false;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    return true;
                });
            #endregion

            #region SELL_ON_ORDER
            AddProperty(SELL_ON_ORDER,
                SELL_ON_ORDER,
                delegate()
                {
                    return mDataProxy.SellOnOrder;
                },
                delegate(object value)
                {

                },
                delegate()
                {
                    return false;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    return true;
                });
            #endregion

            #region PURCHASE_ON_ORDER
            AddProperty(PURCHASE_ON_ORDER,
                PURCHASE_ON_ORDER,
                delegate()
                {
                    return mDataProxy.PurchaseOnOrder;
                },
                delegate(object value)
                {

                },
                delegate()
                {
                    return false;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    return true;
                }
            );
            #endregion 

            #region QUANTITY_AVAILABLE
            AddProperty(QUANTITY_AVAILABLE,
                QUANTITY_AVAILABLE,
                delegate()
                {
                    return mDataProxy.QuantityAvailable;
                },
                delegate(object value)
                {

                },
                delegate()
                {
                    return false;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    return true;
                });
            #endregion

            #region LAST_UNIT_PRICE
            AddProperty(LAST_UNIT_PRICE,
                LAST_UNIT_PRICE,
                delegate()
                {
                    return mDataProxy.LastUnitPrice;
                },
                delegate(object value)
                {
                    mDataProxy.LastUnitPrice = double.Parse(value as string);
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsNumeric(value as string, 13, 2, out error))
                        {
                            return true;
                        }
                        error = DecorateError(LAST_UNIT_PRICE, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(LAST_UNIT_PRICE, "double"); 
                    }
                    return false;
                });
            #endregion

            #region BUY_UNIT_MEASURE
            AddProperty(BUY_UNIT_MEASURE,
                BUY_UNIT_MEASURE,
                delegate()
                {
                    return mDataProxy.BuyUnitMeasure;
                },
                delegate(object value)
                {
                    mDataProxy.BuyUnitMeasure = value as string;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsAlphaNumeric(value as string, 0, 5, out error))
                        {
                            return true;
                        }
                        error = DecorateError(BUY_UNIT_MEASURE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(BUY_UNIT_MEASURE, "string");
                    }
                    return false;
                });
            #endregion

            #region BUY_UNIT_QUANTITY
            AddProperty(BUY_UNIT_QUANTITY,
                BUY_UNIT_QUANTITY,
                delegate()
                {
                    return mDataProxy.BuyUnitQuantity;
                },
                delegate(object value)
                {
                    mDataProxy.BuyUnitQuantity = int.Parse(value as string);
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if(IsInteger(value as string, 4, false, out error))
                        {
                            return true;
                        }
                        error=string.Format("Item.BuyUnitQuantity {0}", error);
                        return false;
                    }
                    error="Item.BuyUnitQuantity must be an string";
                    return false;
                });
            #endregion

            #region BASE_SELLING_PRICE
            AddProperty(BASE_SELLING_PRICE,
                BASE_SELLING_PRICE,
                delegate()
                {
                    return mDataProxy.BaseSellingPrice;
                },
                delegate(object value)
                {
                    mDataProxy.BaseSellingPrice = double.Parse(value as string);
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {

                    if (value is string)
                    {
                        if(IsNumeric(value as string, 11, 4, out error))
                        {
                            return true;
                        }
                        error=string.Format("Item.BaseSellingPrice {0}", error);
                    }
                    else
                    {
                        error=string.Format("Item.BaseSellingPrice must be input as string");
                    }
                    return false;
                });
            #endregion

            #region SELL_UNIT_QUANTITY
            AddProperty(SELL_UNIT_QUANTITY,
                SELL_UNIT_QUANTITY,
                delegate()
                {
                    return mDataProxy.SellUnitQuantity;
                },
                delegate(object value)
                {
                    mDataProxy.SellUnitQuantity = int.Parse(value as string);
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if(IsInteger(value as string, 4, false, out error))
                        {
                            return true;
                        }
                        error=string.Format("Item.SellUnitQuantity {0}", error);
                    }
                    else
                    {
                        error="Item.SellUnitQuantity must be input as string";
                    }
                    return false;
                });
            #endregion

            #region SELL_UNIT_MEASURE
            AddProperty(SELL_UNIT_MEASURE,
                SELL_UNIT_MEASURE,
                delegate()
                {
                    return mDataProxy.SellUnitMeasure;
                },
                delegate(object value)
                {
                    mDataProxy.SellUnitMeasure = value as string;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if(IsAlphaNumeric(value as string, 0, 5, out error))
                        {
                            return true;
                        }
                        error = DecorateError(SELL_UNIT_MEASURE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(SELL_UNIT_MEASURE, "string");
                    }
                    return false;
                });
            #endregion

            #region EXPIRY_DATE
            AddProperty(EXPIRY_DATE,
                EXPIRY_DATE,
                delegate()
                {
                    return mDataProxy.ItemAddOn.ExpiryDate;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.ItemAddOn.ExpiryDate = null;
                    }
                    else
                    {
                        mDataProxy.ItemAddOn.ExpiryDate = value as DateTime?;
                    }
                },
                delegate()
                {
                    return true;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value == null)
                    {
                        return true;
                    }
                    else if (value is DateTime?)
                    {
                        return true;
                    }
                    error="Item.ItemAddOn.ExpiryDate must be of type DateTime?";
                    return false;
                });
            #endregion

            #region PRICE_IS_INCLUSIVE
            AddProperty(PRICE_IS_INCLUSIVE,
                PRICE_IS_INCLUSIVE,
                delegate()
                {
                    return mDataProxy.PriceIsInclusive.Equals("Y");
                },
                delegate(object value)
                {
                    mDataProxy.PriceIsInclusive = (bool)value ? "Y" : "N";
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if(value is bool)
                    {
                        return true;
                    }
                    error="Item.PriceIsInclusive must be of type bool";
                    return false;
                });
            #endregion

            #region DEFAULT_REORDER_QUANITTY
            AddProperty(DEFAULT_REORDER_QUANITTY,
                DEFAULT_REORDER_QUANITTY,
                delegate()
                {
                    return mDataProxy.DefaultReorderQuantity;
                },
                delegate(object value)
                {
                    mDataProxy.DefaultReorderQuantity = double.Parse(value as string);
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if(IsNumeric(value as string, 10, 3, out error))
                        {
                            return true;
                        }
                        error=string.Format("Item.DefaultReorderQuantity {0}", error);
                    }
                    else
                    {
                        error=string.Format("Item.DefaultReorderQuantity must be input as string");
                    }
                    return false;
                });
            #endregion

            #region IS_INACTIVE
            AddProperty(IS_INACTIVE,
                IS_INACTIVE,
                delegate()
                {
                    return mDataProxy.IsInactive.Equals("Y");
                },
                delegate(object value)
                {
                    mDataProxy.IsInactive = (bool)value ? "Y" : "N";
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is bool)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(IS_INACTIVE, "bool");
                    return false;
                });
            #endregion

            #region MIN_LEVEL_BEFORE_REORDER
            AddProperty(MIN_LEVEL_BEFORE_REORDER,
                MIN_LEVEL_BEFORE_REORDER,
                delegate()
                {
                    return mDataProxy.MinLevelBeforeReorder;
                },
                delegate(object value)
                {
                    mDataProxy.MinLevelBeforeReorder = double.Parse(value as string);
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if(IsNumeric(value as string, 10, 3, out error))
                        {
                            return true;
                        }
                        error=string.Format("Item.MinLevelBeforeReorder {0}", error);
                    }
                    else
                    {
                        error="Item.MinLevelBeforeReorder must be input as string";
                    }
                    return false;
                });
            #endregion

            #region COLOR
            AddProperty(COLOR,
                COLOR,
                delegate()
                {
                    return mDataProxy.ItemAddOn.Color;
                },
                delegate(object value)
                {
                    mDataProxy.ItemAddOn.Color = value as string;
                },
                delegate()
                {
                    return true;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if(value is string)
                    {
                        if(IsAlphaNumeric(value as string, 0, 15, out error))
                        {
                            return true;
                        }
                        error=string.Format("Item.ItemAddOn.Color {0}", error);
                    }
                    else
                    {
                        error="Item.ItemAddOn.Color must be of type string";
                    }
                    return false;
                });
            #endregion

            #region SUPPLIER_ITEM_NUMBER
            AddProperty(SUPPLIER_ITEM_NUMBER,
                SUPPLIER_ITEM_NUMBER,
                delegate()
                {
                    return mDataProxy.SupplierItemNumber;
                },
                delegate(object value)
                {
                    mDataProxy.SupplierItemNumber = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsAlphaNumeric(value as string, 0, 30, out error))
                        {
                            return true;
                        }
                        error = DecorateError(SUPPLIER_ITEM_NUMBER, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(SUPPLIER_ITEM_NUMBER, error);
                    }
                    return false;
                });
            #endregion

            #region ITEM_DESCRIPTION
            AddProperty(ITEM_DESCRIPTION,
                ITEM_DESCRIPTION,
                delegate()
                {
                    return mDataProxy.ItemDescription;
                },
                delegate(object value)
                {
                    mDataProxy.ItemDescription = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if(IsAlphaNumeric(value as string, 0, 255, out error, " "))
                        {
                            return true;
                        }
                        error = DecorateError(ITEM_DESCRIPTION, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ITEM_DESCRIPTION, "string");
                    }
                    return false;
                });
            #endregion

            #region BATCH_NUMBER
            AddProperty(BATCH_NUMBER,
                BATCH_NUMBER,
                delegate()
                {
                    return mDataProxy.ItemAddOn.BatchNumber;
                },
                delegate(object value)
                {
                    mDataProxy.ItemAddOn.BatchNumber = (string)value;
                },
                delegate()
                {
                    return true;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsAlphaNumeric(value as string, 0, 25, out error))
                        {
                            return true;
                        }
                        error = DecorateError(BATCH_NUMBER, error); 
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(BATCH_NUMBER, "string");
                    }
                    return false;
                });
            #endregion

            #region USE_DESCRIPTION
            AddProperty(USE_DESCRIPTION,
                USE_DESCRIPTION,
                delegate()
                {
                    return mDataProxy.UseDescription.Equals("Y");
                },
                delegate(object value)
                {
                    mDataProxy.UseDescription = (bool)value ? "Y" : "N";
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is bool)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(USE_DESCRIPTION, "bool");
                    return false;
                });
            #endregion

            #region PICTURE
            AddProperty(PICTURE,
                PICTURE,
                delegate()
                {
                    return mDataProxy.Picture;
                },
                delegate(object value)
                {
                    mDataProxy.Picture = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 255, out error))
                        {
                            return true;
                        }
                        error = DecorateError(PICTURE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(PICTURE, "string");
                    }
                    return false;
                });
            #endregion

            #region INCOME_ACCOUNT
            AddProperty(INCOME_ACCOUNT,
                INCOME_ACCOUNT,
                delegate()
                {
                    return mDataProxy.IncomeAccount;
                },
                delegate(object value)
                {
                    mDataProxy.IncomeAccount = value as Account;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value == null)
                    {
                        return true;
                    }
                    else if (value is Account)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(INCOME_ACCOUNT, "Account");
                    }
                    return false;
                });
            #endregion

            #region EXPENSE_ACCOUNT
            AddProperty(EXPENSE_ACCOUNT,
                EXPENSE_ACCOUNT,
                delegate()
                {
                    return mDataProxy.ExpenseAccount;
                },
                delegate(object value)
                {
                    mDataProxy.ExpenseAccount = value as Account;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value == null)
                    {
                        return true;
                    }
                    else if (value is Account)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(EXPENSE_ACCOUNT, "Account");
                    }
                    return false;
                });
            #endregion

            #region INVENTORY_ACCOUNT
            AddProperty(INVENTORY_ACCOUNT,
                INVENTORY_ACCOUNT,
                delegate()
                {
                    return mDataProxy.InventoryAccount;
                },
                delegate(object value)
                {
                    mDataProxy.InventoryAccount = value as Account;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value == null)
                    {
                        return true;
                    }
                    else if (value is Account)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(INVENTORY_ACCOUNT, "Account");
                    }
                    return false;
                });
            #endregion

            #region BUY_TAXCODE
            AddProperty(BUY_TAXCODE,
                BUY_TAXCODE,
                delegate()
                {
                    return mDataProxy.BuyTaxCode;
                },
                delegate(object value)
                {
                    mDataProxy.BuyTaxCode = value as TaxCode;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value == null)
                    {
                        return true;
                    }
                    else if (value is TaxCode)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(BUY_TAXCODE, "TaxCode");
                    }
                    return false;
                });
            #endregion

            #region SELL_TAXCODE
            AddProperty(SELL_TAXCODE,
                SELL_TAXCODE,
                delegate()
                {
                    return mDataProxy.SellTaxCode;
                },
                delegate(object value)
                {
                    mDataProxy.SellTaxCode = value as TaxCode;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value == null)
                    {
                        return true;
                    }
                    else if (value is TaxCode)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(SELL_TAXCODE, "TaxCode");
                    }
                    return false;
                });
            #endregion

            #region BRAND
            AddProperty(BRAND,
                BRAND,
                delegate()
                {
                    return mDataProxy.ItemAddOn.Brand;
                },
                delegate(object value)
                {
                    mDataProxy.ItemAddOn.Brand = (string)value;
                },
                delegate()
                {
                    return true;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsAlphaNumeric(value as string, 0, 25, out error))
                        {
                            return true;
                        }
                        error = DecorateError(BRAND, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(BRAND, "string");
                    }
                    return false;
                });
            #endregion

            #region PRIMARY_SUPPLIER
            AddProperty(PRIMARY_SUPPLIER,
                PRIMARY_SUPPLIER,
                delegate()
                {
                    return mDataProxy.PrimarySupplier;
                },
                delegate(object value)
                {
                    mDataProxy.PrimarySupplier = value as Supplier;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value == null)
                    {
                        return true;
                    }
                    else if (value is Supplier)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(PRIMARY_SUPPLIER, "Supplier");
                    }
                    return false;
                });
            #endregion

            #region SERIAL_NUMBER
            AddProperty(SERIAL_NUMBER,
                SERIAL_NUMBER,
                delegate()
                {
                    return mDataProxy.ItemAddOn.SerialNumber;
                },
                delegate(object value)
                {
                    mDataProxy.ItemAddOn.SerialNumber = (string)value;
                },
                delegate()
                {
                    return true;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsAlphaNumeric(value as string, 0, 25, out error))
                        {
                            return true;
                        }
                        error = DecorateError(SERIAL_NUMBER, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(SERIAL_NUMBER, "string");
                    }
                    return false;
                });
            #endregion

            #region GENDER
            AddProperty(GENDER,
                GENDER,
                delegate()
                {
                    return mDataProxy.ItemAddOn.Gender;
                },
                delegate(object value)
                {
                    mDataProxy.ItemAddOn.Gender = value as Gender;
                },
                delegate()
                {
                    return true;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value == null)
                    {
                        return true;
                    }
                    else if (value is Gender)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(GENDER, "Gender");
                    }
                    return false;
                });
            #endregion

            #region ITEM_SIZE
            AddProperty(ITEM_SIZE,
                ITEM_SIZE,
                delegate()
                {
                    return mDataProxy.ItemAddOn.ItemSize;
                },
                delegate(object value)
                {
                    mDataProxy.ItemAddOn.ItemSize = value as ItemSize;
                },
                delegate()
                {
                    return true;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value == null)
                    {
                        return true;
                    }
                    else if (value is ItemSize)
                    {
                        return true;    
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ITEM_SIZE, "ItemSize"); 
                    }
                    return false;
                });
            #endregion

            #region SALES_TAX_CALC_BASIS
            AddProperty(SALES_TAX_CALC_BASIS,
                SALES_TAX_CALC_BASIS,
                delegate()
                {
                    return mDataProxy.SalesTaxCalcBasis;
                },
                delegate(object value)
                {
                    mDataProxy.SalesTaxCalcBasis = value as PriceLevel;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value == null)
                    {
                        return true;
                    }
                    else if (value is PriceLevel)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(SALES_TAX_CALC_BASIS, "PriceLevel"); 
                    }
                    return false;
                });
            #endregion

            #region CUSTOM_FIELD1
            AddProperty(CUSTOM_FIELD1,
                CUSTOM_FIELD1,
                delegate()
                {
                    return mDataProxy.CustomField1;
                },
                delegate(object value)
                {
                    mDataProxy.CustomField1 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 30, out error))
                        {
                            return true;
                        }
                        error = DecorateError(CUSTOM_FIELD1, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(CUSTOM_FIELD1, "string");
                    }
                    return false;
                });
            #endregion

            #region CUSTOM_FIELD2
            AddProperty(CUSTOM_FIELD2,
                CUSTOM_FIELD2,
                delegate()
                {
                    return mDataProxy.CustomField2;
                },
                delegate(object value)
                {
                    mDataProxy.CustomField2 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 30, out error))
                        {
                            return true;
                        }
                        error = DecorateError(CUSTOM_FIELD2, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(CUSTOM_FIELD2, "string");
                    }
                    return false;
                });
            #endregion

            #region CUSTOM_FIELD3
            AddProperty(CUSTOM_FIELD3,
                CUSTOM_FIELD3,
                delegate()
                {
                    return mDataProxy.CustomField3;
                },
                delegate(object value)
                {
                    mDataProxy.CustomField3 = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 30, out error))
                        {
                            return true;
                        }
                        error = DecorateError(CUSTOM_FIELD3, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(CUSTOM_FIELD3, "string");
                    }
                    return false;
                });
            #endregion

        }

        protected override void UpdateContent()
        {
            Item discovered = mDataSource.Discover() as Item;
            if (discovered != null)
            {
                mDataSource = discovered;
                mDataProxy = mDataSource.Clone() as Item;
            }
        }

        public override bool CanEdit
        {
            get
            {
                if (this.RecordContext == BOContext.Record_Create)
                {
                    return mDataProxy.AllowCreate;
                }
                else if (this.RecordContext == BOContext.Record_Update)
                {
                    return mDataProxy.AllowUpdate;
                }
                return false;
            }
        }

        public override bool CanDelete
        {
            get
            {
                return mDataProxy.AllowDelete;
            }
        }


        public BindingList<ItemDataFieldEntry> ItemDataFieldEntries
        {
            get
            {
                return mDataProxy.ItemDataFieldEntries;
            }
        }

        protected override OpResult _Record()
        {
            mDataSource.AssignFrom(mDataProxy);
            OpResult result = mAccountant.ItemMgr.Store(mDataSource);
            mDataSource.ItemAddOn.ItemNumber = mDataSource.ItemNumber;
            mAccountant.ItemAddOnMgr.Store(mDataSource.ItemAddOn);
            return result;
        }

        public string DefaultPicturePath
        {
            get
            {
                string picture_path = string.Format("{0}\\{1}", DefaultPictureDirectory, mDataProxy.Picture);
                if (System.IO.File.Exists(picture_path))
                {
                    return picture_path;
                }
                return null;
            }
        }

        public string DefaultPictureDirectory
        {
            get
            {
                string picture_directory = string.Format("{0}\\Graphics", mAccountant.DefaultMgrFactory_Directory);
                if (!System.IO.Directory.Exists(picture_directory))
                {
                    System.IO.Directory.CreateDirectory(picture_directory);
                }
                return picture_directory;
            }
        }
    }
}
