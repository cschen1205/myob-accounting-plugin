using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Sales.SaleLines
{
    using Accounting.Core;
    using Accounting.Core.Sales;
    using Accounting.Core.Jobs;
    using Accounting.Core.TaxCodes;
    using Accounting.Core.Inventory;
    using Accounting.Core.Accounts;

    public class BOMiscSaleLine : BOSaleLine
    {
        private MiscSaleLine mMiscSaleLine=null;
        private double mAmount = 0;

        public static string ACCOUNT = "Account";
        public static string DESCRIPTION = "Description";
        public static string JOB = "Job";
        public static string AMOUNT = "Amount";
        public static string TAXCODE = "TaxCode";
        public static string TAX_BASIS_AMOUNT_IS_INCLUSIVE= "TaxBasisAmountIsInclusive";

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            #region ACCOUNT
            AddProperty(ACCOUNT,
                ACCOUNT,
                delegate()
                {
                    return mMiscSaleLine.Account;
                },
                delegate(object value)
                {
                    if (value is Account)
                    {
                        mMiscSaleLine.Account = value as Account;
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

            #region DESCRIPTION
            AddProperty(DESCRIPTION,
                DESCRIPTION,
                delegate()
                {
                    return mMiscSaleLine.Description;
                },
                delegate(object value)
                {
                    mMiscSaleLine.Description = (string)value;
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
                        if(IsWithinRange(value as string, 1, 255, out error))
                        {
                            return true;
                        }
                        error=string.Format("MiscSaleLine.{0} {1}", DESCRIPTION, error);
                    }
                    else
                    {
                        error=string.Format("MiscSaleLine.{0} must be of type string", DESCRIPTION);
                    }
                    return false;
                });
            #endregion

            #region JOB
            AddProperty(JOB,
                JOB,
                delegate()
                {
                    return mMiscSaleLine.Job;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mMiscSaleLine.Job = null;
                    }
                    else if (value is Job)
                    {
                        mMiscSaleLine.Job = value as Job;
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
                    if(value == null)
                    {
                        return true;
                    }
                    else if(value is Job)
                    {
                        return true;
                    }
                    error=string.Format("MiscSaleLine.{0} must be of type Job", JOB);
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
                    return mMiscSaleLine.TaxCode;
                },
                delegate(object value)
                {
                    if (value is TaxCode)
                    {
                        mMiscSaleLine.TaxCode = value as TaxCode;
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
                        error =DecorateError(TAXCODE, "cannot be empty");
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

            #region TAX_BASIS_AMOUNT_IS_INCLUSIVE
            AddProperty(TAX_BASIS_AMOUNT_IS_INCLUSIVE,
                TAX_BASIS_AMOUNT_IS_INCLUSIVE,
                delegate()
                {
                    return mMiscSaleLine.TaxBasisAmountIsInclusive.Equals("Y");
                },
                delegate(object value)
                {
                    mMiscSaleLine.TaxBasisAmountIsInclusive = (bool)value ? "Y" : "N";
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
        }




        public BOMiscSaleLine(Accountant accountant, Sale _sale, MiscSaleLine _line, BOContext context)
            : base(accountant, _sale, _line, context)
        {
            mObjectID = BOType.BOMiscSaleLine;
            mMiscSaleLine = _line.Clone() as MiscSaleLine;
            mMiscSaleLine.Sale = _sale;

            if (mMiscSaleLine.Sale.IsTaxInclusive == "Y")
            {
                mAmount = mMiscSaleLine.TaxInclusiveAmount;
            }
            else
            {
                mAmount = mMiscSaleLine.TaxExclusiveAmount;
            }
        }

        public override void  Update()
        {
            if (mMiscSaleLine.Sale.IsTaxInclusive == "Y")
            {
                mMiscSaleLine.TaxInclusiveAmount = mAmount;
                mMiscSaleLine.TaxExclusiveAmount = mMiscSaleLine.TaxInclusiveAmount / (1 + mMiscSaleLine.TaxCode.TaxPercentageRate / 100);
            }
            else
            {
                mMiscSaleLine.TaxExclusiveAmount = mAmount;
                mMiscSaleLine.TaxInclusiveAmount = mMiscSaleLine.TaxExclusiveAmount * (1 + mMiscSaleLine.TaxCode.TaxPercentageRate / 100);
            }

            mMiscSaleLine.TaxBasisAmountIsInclusive = mMiscSaleLine.Sale.IsTaxInclusive;
            if (mMiscSaleLine.TaxBasisAmountIsInclusive.Equals("Y"))
            {
                mMiscSaleLine.TaxBasisAmount = mMiscSaleLine.TaxInclusiveAmount;
            }
            else
            {
                mMiscSaleLine.TaxBasisAmount = mMiscSaleLine.TaxExclusiveAmount;
            }


            Update(mMiscSaleLine);
        }

        
    }
}
