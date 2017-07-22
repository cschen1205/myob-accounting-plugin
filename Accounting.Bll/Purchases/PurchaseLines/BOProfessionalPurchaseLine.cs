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

    public class BOProfessionalPurchaseLine : BOPurchaseLine
    {
        public static string ACCOUNT = "Account";
        public static string LINE_DATE = "LineDate";
        public static string DESCRIPTION = "Description";
        public static string JOB = "Job";
        public static string AMOUNT = "Amount";
        public static string TAXCODE = "TaxCode";
        public static string TAX_BASIS_AMOUNT_IS_INCLUSIVE = "TaxBasisAmountIsInclusive";

        private ProfessionalPurchaseLine mDataProxy=null;
        private double mAmount = 0;

        public BOProfessionalPurchaseLine(Accountant accountant, Purchase _purchase, ProfessionalPurchaseLine _line, BOContext context)
            : base(accountant, _purchase, _line, context)
        {
            mObjectID = BOType.BOProfessionalPurchaseLine;
            mDataProxy = _line.Clone() as ProfessionalPurchaseLine;
            mDataProxy.Purchase = _purchase;

            if (mDataProxy.Purchase.IsTaxInclusive == "Y")
            {
                mAmount = mDataProxy.TaxInclusiveAmount;
            }
            else
            {
                mAmount = mDataProxy.TaxExclusiveAmount;
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
                    return mDataProxy.Account;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.Account = null;
                    }
                    else if (value is Account)
                    {
                        mDataProxy.Account = value as Account;
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
                    error = DecorateTypeMismatchError(ACCOUNT, "Account");
                    return false;
                });
            #endregion

            #region LINE_DATE
            AddProperty(LINE_DATE,
                LINE_DATE,
                delegate()
                {
                    return mDataProxy.LineDate;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.LineDate = null;
                    }
                    else if (value is DateTime?)
                    {
                        mDataProxy.LineDate = (DateTime?)value;
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
                    else if (value is DateTime?)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(LINE_DATE, "DateTime?");
                    return false;
                });
            #endregion

            #region DESCRIPTION
            AddProperty(DESCRIPTION,
                DESCRIPTION,
                delegate()
                {
                    return mDataProxy.Description;
                },
                delegate(object value)
                {
                    mDataProxy.Description = (string)value;
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

            #region TAXCODE
            AddProperty(TAXCODE,
                TAXCODE,
                delegate()
                {
                    return mDataProxy.TaxCode;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.TaxCode = null;
                    }
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
                    return mDataProxy.TaxBasisAmountIsInclusive.Equals("Y");
                },
                delegate(object value)
                {
                    mDataProxy.TaxBasisAmountIsInclusive = (bool)value ? "Y" : "N";
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
                    if (value is bool)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(TAX_BASIS_AMOUNT_IS_INCLUSIVE, "bool");
                    return false;
                });
            #endregion
        }

        public override void Update()
        {
            if (mDataProxy.Purchase.IsTaxInclusive == "Y")
            {
                mDataProxy.TaxInclusiveAmount = mAmount;
                mDataProxy.TaxExclusiveAmount = mDataProxy.TaxInclusiveAmount / (1 + mDataProxy.TaxCode.TaxPercentageRate / 100);
            }
            else
            {
                mDataProxy.TaxExclusiveAmount = mAmount;
                mDataProxy.TaxInclusiveAmount = mDataProxy.TaxExclusiveAmount * (1 + mDataProxy.TaxCode.TaxPercentageRate / 100);
            }

            mDataProxy.TaxBasisAmountIsInclusive = mDataProxy.Purchase.IsTaxInclusive;
            if (mDataProxy.TaxBasisAmountIsInclusive.Equals("Y"))
            {
                mDataProxy.TaxBasisAmount = mDataProxy.TaxInclusiveAmount;
            }
            else
            {
                mDataProxy.TaxBasisAmount = mDataProxy.TaxExclusiveAmount;
            }

            Update(mDataProxy);
        }

        
    }
}
