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

    public class BOServicePurchaseLine : BOPurchaseLine
    {
        public static string AMOUNT = "Amount";
        public static string TAXCODE = "TaxCode";
        public static string TAX_BASIS_AMOUNT_IS_INCLUSIVE = "TaxBasisAmountIsInclusive";
        public static string ACCOUNT = "Account";
        public static string JOB = "Job";
        public static string DESCRIPTION = "Description";

        private ServicePurchaseLine mServicePurchaseLine=null;
        private double mAmount = 0;

        public BOServicePurchaseLine(Accountant accountant, Purchase _purchase, ServicePurchaseLine _line, BOContext context)
            : base(accountant, _purchase, _line, context)
        {
            mObjectID = BOType.BOServicePurchaseLine;
            mServicePurchaseLine = _line.Clone() as ServicePurchaseLine;
            mServicePurchaseLine.Purchase = _purchase;

            if (mServicePurchaseLine.Purchase.IsTaxInclusive == "Y")
            {
                mAmount = mServicePurchaseLine.TaxInclusiveAmount;
            }
            else
            {
                mAmount = mServicePurchaseLine.TaxExclusiveAmount;
            }
        }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

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
                        error = DecorateTypeMismatchError(AMOUNT, "string");
                    }
                    return false;
                });
            #endregion

            #region TAXCODE
            AddProperty(TAXCODE,
                TAXCODE,
                delegate()
                {
                    return mServicePurchaseLine.TaxCode;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mServicePurchaseLine.TaxCode = null;
                    }
                    else if (value is TaxCode)
                    {
                        mServicePurchaseLine.TaxCode = value as TaxCode;
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
                    else if (value is TaxCode)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(TAXCODE, "TaxCode");
                    return false;
                });
            #endregion

            #region TAX_BASIS_AMOUNT_IS_INCLUSIVE
            AddProperty(TAX_BASIS_AMOUNT_IS_INCLUSIVE,
                TAX_BASIS_AMOUNT_IS_INCLUSIVE,
                delegate()
                {
                    return mServicePurchaseLine.TaxBasisAmountIsInclusive.Equals("Y");
                },
                delegate(object value)
                {
                    mServicePurchaseLine.TaxBasisAmountIsInclusive = (bool)value ? "Y" : "N";
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

            #region ACCOUNT
            AddProperty(ACCOUNT,
                ACCOUNT,
                delegate()
                {
                    return mServicePurchaseLine.Account;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mServicePurchaseLine.Account = null;
                    }
                    else if (value is Account)
                    {
                        mServicePurchaseLine.Account = value as Account;
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

            #region JOB
            AddProperty(JOB,
                JOB,
                delegate()
                {
                    return mServicePurchaseLine.Job;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mServicePurchaseLine.Job = null;
                    }
                    else if (value is Job)
                    {
                        mServicePurchaseLine.Job = value as Job;
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

            #region DESCRIPTION
            AddProperty(DESCRIPTION,
                DESCRIPTION,
                delegate()
                {
                    return mServicePurchaseLine.Description;
                },
                delegate(object value)
                {
                    mServicePurchaseLine.Description = (string)value;
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
        }

        public override void Update()
        {
            if (mServicePurchaseLine.Purchase.IsTaxInclusive == "Y")
            {
                mServicePurchaseLine.TaxInclusiveAmount = mAmount;
                mServicePurchaseLine.TaxExclusiveAmount = mServicePurchaseLine.TaxInclusiveAmount / (1 + mServicePurchaseLine.TaxCode.TaxPercentageRate / 100);
            }
            else
            {
                mServicePurchaseLine.TaxExclusiveAmount = mAmount;
                mServicePurchaseLine.TaxInclusiveAmount = mServicePurchaseLine.TaxExclusiveAmount * (1 + mServicePurchaseLine.TaxCode.TaxPercentageRate / 100);
            }

            mServicePurchaseLine.TaxBasisAmountIsInclusive = mServicePurchaseLine.Purchase.IsTaxInclusive;
            if (mServicePurchaseLine.TaxBasisAmountIsInclusive.Equals("Y"))
            {
                mServicePurchaseLine.TaxBasisAmount = mServicePurchaseLine.TaxInclusiveAmount;
            }
            else
            {
                mServicePurchaseLine.TaxBasisAmount = mServicePurchaseLine.TaxExclusiveAmount;
            }

            Update(mServicePurchaseLine);
        }

        
        
    }
}
