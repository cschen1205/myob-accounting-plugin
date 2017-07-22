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

    public class BOServiceSaleLine : BOSaleLine
    {
        private ServiceSaleLine mServiceSaleLine=null;
        private double mAmount = 0;

        public static string ACCOUNT = "Account";
        public static string DESCRIPTION = "Description";
        public static string JOB="Job";
        public static string AMOUNT = "Amount";
        public static string TAXCODE = "TaxCode";
        public static string TAX_BASIS_AMOUNT_IS_INCLUSIVE = "TaxBasisAmountIsInclusive";

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            #region ACCOUNT
            AddProperty(ACCOUNT,
                ACCOUNT,
                delegate()
                {
                    return mServiceSaleLine.Account;
                },
                delegate(object value)
                {
                    if (value is Account)
                    {
                        mServiceSaleLine.Account = value as Account;
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
                        error = DecorateError(ACCOUNT, "cannot be empty");
                        return false;
                    }
                    else if(value is Account)
                    {
                        return true;
                    }
                    error= DecorateTypeMismatchError(ACCOUNT, "Account");
                    return false;
                });
            #endregion

            #region DESCRIPTION
            AddProperty(DESCRIPTION,
                DESCRIPTION,
                delegate()
                {
                    return mServiceSaleLine.Description;
                },
                delegate(object value)
                {
                    mServiceSaleLine.Description = (string)value;
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
                    return mServiceSaleLine.Job;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mServiceSaleLine.Job = null;
                    }
                    else if (value is Job)
                    {
                        mServiceSaleLine.Job = value as Job;
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
                    return mServiceSaleLine.TaxCode;
                },
                delegate(object value)
                {
                    if (value is TaxCode)
                    {
                        mServiceSaleLine.TaxCode = value as TaxCode;
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
                    else if(value is TaxCode)
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
                    return mServiceSaleLine.TaxBasisAmountIsInclusive.Equals("Y");
                },
                delegate(object value)
                {
                    mServiceSaleLine.TaxBasisAmountIsInclusive = (bool)value ? "Y" : "N";
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

        public BOServiceSaleLine(Accountant accountant, Sale _sale, ServiceSaleLine _line, BOContext context)
            : base(accountant, _sale, _line, context)
        {
            mObjectID = BOType.BOServiceSaleLine;
            mServiceSaleLine = _line.Clone() as ServiceSaleLine;
            mServiceSaleLine.Sale = _sale;

            if (mServiceSaleLine.Sale.IsTaxInclusive == "Y")
            {
                mAmount = mServiceSaleLine.TaxInclusiveAmount;
            }
            else
            {
                mAmount = mServiceSaleLine.TaxExclusiveAmount;
            }
        }

        public override void  Update()
        {
            if (mServiceSaleLine.Sale.IsTaxInclusive == "Y")
            {
                mServiceSaleLine.TaxInclusiveAmount = mAmount;
                mServiceSaleLine.TaxExclusiveAmount = mServiceSaleLine.TaxInclusiveAmount / (1 + mServiceSaleLine.TaxCode.TaxPercentageRate / 100);
            }
            else
            {
                mServiceSaleLine.TaxExclusiveAmount = mAmount;
                mServiceSaleLine.TaxInclusiveAmount = mServiceSaleLine.TaxExclusiveAmount * (1 + mServiceSaleLine.TaxCode.TaxPercentageRate / 100);
            }

            mServiceSaleLine.TaxBasisAmountIsInclusive = mServiceSaleLine.Sale.IsTaxInclusive;
            if (mServiceSaleLine.TaxBasisAmountIsInclusive.Equals("Y"))
            {
                mServiceSaleLine.TaxBasisAmount = mServiceSaleLine.TaxInclusiveAmount;
            }
            else
            {
                mServiceSaleLine.TaxBasisAmount = mServiceSaleLine.TaxExclusiveAmount;
            }

            Update(mServiceSaleLine);
        }

       
        
    }
}
