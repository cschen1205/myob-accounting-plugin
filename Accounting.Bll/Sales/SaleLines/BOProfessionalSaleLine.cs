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

    public class BOProfessionalSaleLine : BOSaleLine
    {
        private ProfessionalSaleLine mProfessionalSaleLine=null;
        private double mAmount = 0;
       
        public static string ACCOUNT = "Account";
        public static string LINE_DATE = "LineDate";
        public static string DESCRIPTION = "Description";
        public static string JOB = "Job";
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
                    return mProfessionalSaleLine.Account;
                },
                delegate(object value)
                {
                    if (value is Account)
                    {
                        mProfessionalSaleLine.Account = value as Account;
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
                    return mProfessionalSaleLine.LineDate;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mProfessionalSaleLine.LineDate = null;
                    }
                    else if (value is DateTime?)
                    {
                        mProfessionalSaleLine.LineDate = (DateTime?)value;
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
                    return mProfessionalSaleLine.Description;
                },
                delegate(object value)
                {
                    mProfessionalSaleLine.Description = (string)value;
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
                    return mProfessionalSaleLine.Job;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mProfessionalSaleLine.Job = null;
                    }
                    else if (value is Job)
                    {
                        mProfessionalSaleLine.Job = value as Job;
                    }
                    else
                    {
                        throw new Exception("Job must be of type Job");
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
                    return mProfessionalSaleLine.TaxCode;
                },
                delegate(object value)
                {
                    if (value is TaxCode)
                    {
                        mProfessionalSaleLine.TaxCode = value as TaxCode;
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

            #region TAX_BASIS_AMOUNT_IS_INCLUSIVE
            AddProperty(TAX_BASIS_AMOUNT_IS_INCLUSIVE,
                TAX_BASIS_AMOUNT_IS_INCLUSIVE,
                delegate()
                {
                    return mProfessionalSaleLine.TaxBasisAmountIsInclusive.Equals("Y");
                },
                delegate(object value)
                {
                    mProfessionalSaleLine.TaxBasisAmountIsInclusive = (bool)value ? "Y" : "N";
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



        public BOProfessionalSaleLine(Accountant accountant, Sale _sale, ProfessionalSaleLine _line, BOContext context)
            : base(accountant, _sale, _line, context)
        {
            mObjectID = BOType.BOProfessionalSaleLine;
            mProfessionalSaleLine = _line.Clone() as ProfessionalSaleLine;
            mProfessionalSaleLine.Sale = _sale;

            if (mProfessionalSaleLine.Sale.IsTaxInclusive == "Y")
            {
                mAmount = mProfessionalSaleLine.TaxInclusiveAmount;
            }
            else
            {
                mAmount = mProfessionalSaleLine.TaxExclusiveAmount;
            }
        }

        public override void  Update()
        {
            if (mProfessionalSaleLine.Sale.IsTaxInclusive == "Y")
            {
                mProfessionalSaleLine.TaxInclusiveAmount = mAmount;
                mProfessionalSaleLine.TaxExclusiveAmount = mProfessionalSaleLine.TaxInclusiveAmount / (1 + mProfessionalSaleLine.TaxCode.TaxPercentageRate / 100);
            }
            else
            {
                mProfessionalSaleLine.TaxExclusiveAmount = mAmount;
                mProfessionalSaleLine.TaxInclusiveAmount = mProfessionalSaleLine.TaxExclusiveAmount * (1 + mProfessionalSaleLine.TaxCode.TaxPercentageRate / 100);
            }

            mProfessionalSaleLine.TaxBasisAmountIsInclusive = mProfessionalSaleLine.Sale.IsTaxInclusive;
            if (mProfessionalSaleLine.TaxBasisAmountIsInclusive.Equals("Y"))
            {
                mProfessionalSaleLine.TaxBasisAmount = mProfessionalSaleLine.TaxInclusiveAmount;
            }
            else
            {
                mProfessionalSaleLine.TaxBasisAmount = mProfessionalSaleLine.TaxExclusiveAmount;
            }

            Update(mProfessionalSaleLine);
        }

      
        
    }
}
