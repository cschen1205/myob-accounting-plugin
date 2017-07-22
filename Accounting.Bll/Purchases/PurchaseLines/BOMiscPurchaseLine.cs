using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Purchases.PurchaseLines
{
    using Accounting.Core;
    using Accounting.Core.Purchases;
    using Accounting.Core.Jobs;
    using Accounting.Core.TaxCodes;
    using Accounting.Core.Inventory;
    using Accounting.Core.Accounts;

    public class BOMiscPurchaseLine : BOPurchaseLine
    {
        public static string ACCOUNT = "Account";
        public static string DESCRIPTION = "Description";
        public static string JOB = "Job";
        public static string TAX_BASIS_AMOUNT_IS_INCLUSIVE = "TaxBasisAmountIsInclusive";
        public static string TAXCODE = "TaxCode";
        public static string AMOUNT = "Amount";

        private MiscPurchaseLine mMiscPurchaseLine=null;
        private double mAmount = 0;

        public BOMiscPurchaseLine(Accountant accountant, Purchase _purchase, MiscPurchaseLine _line, BOContext context)
            : base(accountant, _purchase, _line, context)
        {
            mObjectID = BOType.BOMiscPurchaseLine;
            mMiscPurchaseLine = _line.Clone() as MiscPurchaseLine;
            mMiscPurchaseLine.Purchase = _purchase;

            if (mMiscPurchaseLine.Purchase.IsTaxInclusive == "Y")
            {
                mAmount = mMiscPurchaseLine.TaxInclusiveAmount;
            }
            else
            {
                mAmount = mMiscPurchaseLine.TaxExclusiveAmount;
            }
        }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            #region ACCOUNT
            AddProperty(ACCOUNT,
                ACCOUNT,
                delegate()
                {
                    return mMiscPurchaseLine.Account;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mMiscPurchaseLine.Account = null;
                    }
                    else if (value is Account)
                    {
                        mMiscPurchaseLine.Account = value as Account;
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
                        error = DecorateError(ACCOUNT, "cannot be empty");
                        return false;
                    }
                    else if (value is Account)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ACCOUNT, "Account");
                    }
                    return false;
                });
            #endregion

            #region DESCRIPTION
            AddProperty(DESCRIPTION,
                DESCRIPTION,
                delegate()
                {
                    return mMiscPurchaseLine.Description;
                },
                delegate(object value)
                {
                    mMiscPurchaseLine.Description = (string)value;
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
                        if (IsWithinRange(value as string, 1, 255, out error))
                        {
                            return true;
                        }
                        error = DecorateError(DESCRIPTION, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(DESCRIPTION, "string");
                    }
                    return false;
                });
            #endregion

            #region JOB
            AddProperty(JOB,
                JOB,
                delegate()
                {
                    return mMiscPurchaseLine.Job;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mMiscPurchaseLine.Job = null;
                    }
                    else if (value is Job)
                    {
                        mMiscPurchaseLine.Job = value as Job;
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

            #region TAX_BASIS_AMOUNT_IS_INCLUSIVE
            AddProperty(TAX_BASIS_AMOUNT_IS_INCLUSIVE,
                TAX_BASIS_AMOUNT_IS_INCLUSIVE,
                delegate()
                {
                    return mMiscPurchaseLine.TaxBasisAmountIsInclusive.Equals("Y");
                },
                delegate(object value)
                {
                    mMiscPurchaseLine.TaxBasisAmountIsInclusive = (bool)value ? "Y" : "N";
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

            #region TAXCODE
            AddProperty(TAXCODE,
                TAXCODE,
                delegate()
                {
                    return mMiscPurchaseLine.TaxCode;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mMiscPurchaseLine.TaxCode = null;
                    }
                    else if (value is TaxCode)
                    {
                        mMiscPurchaseLine.TaxCode = value as TaxCode;
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
                    else if(value is TaxCode)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(TAXCODE, "TaxCode");
                    return false;
                });
            #endregion

            #region AMOUNT
            AddProperty(AMOUNT,
                AMOUNT,
                delegate()
                {
                    return mAmount;
                },
                delegate(object value)
                {
                    mAmount = double.Parse(value as string);
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
                        error = DecorateError(AMOUNT, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(AMOUNT, "string");
                    }
                    return false;
                });
            #endregion
        }

        public override void  Update()
        {
            if (mMiscPurchaseLine.Purchase.IsTaxInclusive == "Y")
            {
                mMiscPurchaseLine.TaxInclusiveAmount = mAmount;
                mMiscPurchaseLine.TaxExclusiveAmount = mMiscPurchaseLine.TaxInclusiveAmount / (1 + mMiscPurchaseLine.TaxCode.TaxPercentageRate / 100);
            }
            else
            {
                mMiscPurchaseLine.TaxExclusiveAmount = mAmount;
                mMiscPurchaseLine.TaxInclusiveAmount = mMiscPurchaseLine.TaxExclusiveAmount * (1 + mMiscPurchaseLine.TaxCode.TaxPercentageRate / 100);
            }

            mMiscPurchaseLine.TaxBasisAmountIsInclusive = mMiscPurchaseLine.Purchase.IsTaxInclusive;
            if (mMiscPurchaseLine.TaxBasisAmountIsInclusive.Equals("Y"))
            {
                mMiscPurchaseLine.TaxBasisAmount = mMiscPurchaseLine.TaxInclusiveAmount;
            }
            else
            {
                mMiscPurchaseLine.TaxBasisAmount = mMiscPurchaseLine.TaxExclusiveAmount;
            }

            Update(mMiscPurchaseLine);
        }

        
    }
}
