using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Sales.SaleLines
{
    using Accounting.Core;
    using Accounting.Core.Sales;
    using Accounting.Core.Inventory;
    using Accounting.Core.Jobs;
    using Accounting.Core.TaxCodes;

    public class BOItemSaleLine : BOSaleLine
    {
        private ItemSaleLine mDataProxy=null;
        private double mPrice = 0;

        public static string DISCOUNT = "Discount";
        public static string JOB = "Job";
        public static string PRICE = "Price";
        public static string TAXCODE = "TaxCode";
        public static string QUANTITY = "Quantity";
        public static string ITEM = "Item";
        public static string TAX_BASIS_AMOUNT_IS_INCLUSIVE = "TaxBasisAmountIsInclusive";
        public static string LOCATION = "Location";

        public BOItemSaleLine(Accountant accountant, Sale _sale, ItemSaleLine _line, BOContext context)
            : base(accountant, _sale, _line, context)
        {
            mObjectID = BOType.BOItemSaleLine;
            mDataProxy=_line.Clone() as ItemSaleLine;
            mDataProxy.Sale = _sale;

            if (mDataProxy.Sale.IsTaxInclusive == "Y")
            {
                mPrice = mDataProxy.TaxInclusiveUnitPrice;
            }
            else
            {
                mPrice=mDataProxy.TaxExclusiveUnitPrice;
            }
        }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            #region DISCOUNT
            AddProperty(DISCOUNT,
                DISCOUNT,
                delegate()
                {
                    return mDataProxy.Discount;
                },
                delegate(object value)
                {
                    mDataProxy.Discount = double.Parse(value as string);
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
                        //9xN (with a maximum of two decimal places. Decimal point counts as one place.)
                        if (IsNumeric(value as string, 6, 2, out error))
                        {
                            return true;
                        }
                        error = DecorateError(DISCOUNT, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(DISCOUNT, "string");
                    }
                    return false;
                });
            #endregion

            #region JOB
            AddProperty(JOB,
                JOB,
                delegate()
                {
                    return mDataProxy.Job;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.Job = null;
                    }
                    else if (value is Job)
                    {
                        mDataProxy.Job = value as Job;
                    }
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
                    else if (value is Job)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(JOB, "Job");
                    return false;
                });
            #endregion

            #region PRICE
            AddProperty(PRICE,
                PRICE,
                delegate()
                {
                    return mPrice;
                },
                delegate(object value)
                {
                    mPrice = double.Parse(value as string);
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
                        if (IsNumeric(value as string, 11, 4, out error))
                        {
                            return true;
                        }
                        error = DecorateError(PRICE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(PRICE, "string");
                    }
                    return false;
                });
            #endregion

            #region TAXCODE
            AddProperty(TAXCODE,
                TAXCODE,
                delegate()
                {
                    return mDataProxy.TaxCode;
                },
                delegate(object value)
                {
                    if (value is TaxCode)
                    {
                        mDataProxy.TaxCode = value as TaxCode;
                    }
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
                        error = DecorateError(TAXCODE, "cannot be empty");
                        return false;
                    }
                    else if (value is TaxCode)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(TAXCODE, "TaxCode");
                    return false;
                });
            #endregion

            #region QUANTITY
            AddProperty(QUANTITY,
                QUANTITY,
                delegate()
                {
                    return mDataProxy.Quantity;
                },
                delegate(object value)
                {
                    mDataProxy.Quantity = double.Parse(value as string);
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
                        if (IsNumeric(value as string, 8, 3, out error))
                        {
                            double result = double.Parse(value as string);
                            if (result <= 0)
                            {
                                error = DecorateError(QUANTITY, "must be positive");
                                return false;
                            }
                            return true;
                        }
                        error = DecorateError(QUANTITY, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(QUANTITY, "string");
                    }
                    return false;
                });
            #endregion

            #region ITEM
            AddProperty(ITEM,
                ITEM,
                delegate()
                {
                    return mDataProxy.Item;
                },
                delegate(object value)
                {
                    if (value is Item)
                    {
                        mDataProxy.Item = value as Item;
                        if (value != null)
                            mDataProxy.SalesTaxCalBasisID = mDataProxy.Item.SalesTaxCalcBasisID;
                    }
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
                        error = DecorateError(ITEM, "cannot be empty");
                        return false;
                    }
                    else if (value is Item)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(ITEM, "Item");
                    return false;
                });
            #endregion

            #region TAX_BASIS_AMOUNT_IS_INCLUSIVE
            AddProperty(TAX_BASIS_AMOUNT_IS_INCLUSIVE,
                TAX_BASIS_AMOUNT_IS_INCLUSIVE,
                delegate()
                {
                    return mDataProxy.TaxBasisAmountIsInclusive.Equals("Y");
                },
                delegate(object value)
                {
                    mDataProxy.TaxBasisAmountIsInclusive = (bool)value ? "Y" : "N";
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
                    error = DecorateTypeMismatchError(TAX_BASIS_AMOUNT_IS_INCLUSIVE, "bool");
                    return false;
                });
            #endregion

            #region LOCATION
            AddProperty(LOCATION,
                LOCATION,
                delegate()
                {
                    return mDataProxy.Location;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.Location = null;
                    }
                    else if (value is Location)
                    {
                        mDataProxy.Location = value as Location;
                    }
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
                    else if (value is Location)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(LOCATION, "Location");
                    return false;
                });
            #endregion
        }

        public override void  Update()
        {
            if (mDataProxy.Item == null)
            {
                throw new NullReferenceException("ItemSaleLine.Item is null");
            }
            mDataProxy.Description = mDataProxy.Item.ItemName;

            double tax_rate = 0;
            if (mDataProxy.TaxCode != null)
            {
                tax_rate = mDataProxy.TaxCode.TaxPercentageRate / 100.0;
            }

            if (mDataProxy.Sale.IsTaxInclusive == "Y")
            {
                mDataProxy.TaxInclusiveUnitPrice = mPrice;
                mDataProxy.TaxExclusiveUnitPrice = mDataProxy.TaxInclusiveUnitPrice / (1 + tax_rate);
            }
            else
            {
                mDataProxy.TaxExclusiveUnitPrice = mPrice;
                mDataProxy.TaxInclusiveUnitPrice = mDataProxy.TaxExclusiveUnitPrice * (1 + tax_rate);
            }
            mDataProxy.TaxInclusiveTotal = mDataProxy.TaxInclusiveUnitPrice * mDataProxy.Quantity;
            mDataProxy.TaxExclusiveTotal = mDataProxy.TaxExclusiveUnitPrice * mDataProxy.Quantity;

            mDataProxy.TaxBasisAmountIsInclusive = mDataProxy.Sale.IsTaxInclusive;
            if (mDataProxy.TaxBasisAmountIsInclusive.Equals("Y"))
            {
                mDataProxy.TaxBasisAmount = mDataProxy.TaxInclusiveAmount;
            }
            else
            {
                mDataProxy.TaxBasisAmount = mDataProxy.TaxExclusiveAmount;
            }

            mDataProxy.CostOfGoodsSoldAmount = mDataProxy.Item.TaxExclusiveLastPurchasePrice * mDataProxy.Quantity;

            Update(mDataProxy);
        }

        
    }
}
