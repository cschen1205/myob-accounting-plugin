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
    using Accounting.Core.Activities;

    public class BOTimeBillingSaleLine : BOSaleLine
    {
        private TimeBillingSaleLine mTimeBillingSaleLine=null;
        private double mRate = 0;

        public static string LOCATION = "Location";
        public static string LINE_DATE = "LineDate";
        public static string NOTES = "Description";
        public static string JOB = "Job";
        public static string ESTIMATED_COST = "EstimatedCost";
        public static string HOURS_UNITS = "HoursUnits";
        public static string ACTIVITY = "Activity";
        public static string RATE = "Rate";
        public static string TAXCODE = "TaxCode";
        public static string TAX_BASIS_AMOUNT_IS_INCLUSIVE = "TaxBasisAmountIsInclusive";

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            #region LOCATION
            AddProperty(LOCATION,
                LOCATION,
                delegate()
                {
                    return mTimeBillingSaleLine.Location;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mTimeBillingSaleLine.Location = null;
                    }
                    else if (value is Location)
                    {
                        mTimeBillingSaleLine.Location = value as Location;
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

            #region LINE_DATE
            AddProperty(LINE_DATE,
                LINE_DATE,
                delegate()
                {
                    return mTimeBillingSaleLine.LineDate;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mTimeBillingSaleLine.LineDate = null;
                    }
                    else if (value is DateTime?)
                    {
                        mTimeBillingSaleLine.LineDate = (DateTime?)value;
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

            #region NOTES
            AddProperty(NOTES,
                NOTES,
                delegate()
                {
                    return mTimeBillingSaleLine.Description;
                },
                delegate(object value)
                {
                    mTimeBillingSaleLine.Description = (string)value;
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
                        error = DecorateError(NOTES, error);
                    }
                    else
                    {
                        error =  DecorateTypeMismatchError(NOTES, "string");
                    }
                    return false;
                });
            #endregion

            #region JOB
            AddProperty(JOB,
                JOB,
                delegate()
                {
                    return mTimeBillingSaleLine.Job;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mTimeBillingSaleLine.Job = null;
                    }
                    else if (value is Job)
                    {
                        mTimeBillingSaleLine.Job = value as Job;
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

            #region ESTIMATED_COST
            AddProperty(ESTIMATED_COST,
                ESTIMATED_COST,
                delegate()
                {
                    return mTimeBillingSaleLine.EstimatedCost;
                },
                delegate(object value)
                {
                    mTimeBillingSaleLine.EstimatedCost = double.Parse(value as string);
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
                        error = DecorateError(ESTIMATED_COST, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(ESTIMATED_COST, "string");
                    }
                    return false;
                });
            #endregion

            #region HOURS_UNITS
            AddProperty(HOURS_UNITS,
                HOURS_UNITS,
                delegate()
                {
                    return mTimeBillingSaleLine.HoursUnits;
                },
                delegate(object value)
                {
                    mTimeBillingSaleLine.HoursUnits = double.Parse(value as string);
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
                            return true;
                        }
                        error = DecorateError(HOURS_UNITS, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(HOURS_UNITS, "string");
                    }
                    return false;
                });
            #endregion;

            #region ACTIVITY
            AddProperty(ACTIVITY,
                ACTIVITY,
                delegate()
                {
                    return mTimeBillingSaleLine.Activity;
                },
                delegate(object value)
                {
                    if (value is Activity)
                    {
                        mTimeBillingSaleLine.Activity = value as Activity;
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
                        error = DecorateError(ACTIVITY, "cannot be empty");
                        return false;
                    }
                    else if (value is Activity)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(ACTIVITY, "Activity");
                    return false;
                });
            #endregion

            #region RATE
            AddProperty(RATE,
                RATE,
                delegate()
                {
                    return mRate;
                },
                delegate(object value)
                {
                    mRate = double.Parse(value as string);
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
                        error = DecorateError(RATE, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(RATE, "string");
                    }
                    return false;
                });
            #endregion

            #region TAXCODE
            AddProperty(TAXCODE,
                TAXCODE,
                delegate()
                {
                    return mTimeBillingSaleLine.TaxCode;
                },
                delegate(object value)
                {
                    if (value is TaxCode)
                    {
                        mTimeBillingSaleLine.TaxCode = value as TaxCode;
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
            #endregion;

            #region TAX_BASIS_AMOUNT_IS_INCLUSIVE
            AddProperty(TAX_BASIS_AMOUNT_IS_INCLUSIVE,
                TAX_BASIS_AMOUNT_IS_INCLUSIVE,
                delegate()
                {
                    return mTimeBillingSaleLine.TaxBasisAmountIsInclusive.Equals("Y");
                },
                delegate(object value)
                {
                    mTimeBillingSaleLine.TaxBasisAmountIsInclusive=(bool)value ? "Y": "N";
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
                    error=string.Format("TimeBillingSaleLine.{0} must be of type bool", TAX_BASIS_AMOUNT_IS_INCLUSIVE);
                    return false;
                });
            #endregion
        }

        public BOTimeBillingSaleLine(Accountant accountant, Sale _sale, TimeBillingSaleLine _line, BOContext context)
            : base(accountant, _sale, _line, context)
        {
            mObjectID = BOType.BOTimeInvoiceingSaleLine;
            mTimeBillingSaleLine = _line.Clone() as TimeBillingSaleLine;
            mTimeBillingSaleLine.Sale = _sale;

            if (mTimeBillingSaleLine.Sale.IsTaxInclusive == "Y")
            {
                mRate = mTimeBillingSaleLine.TaxInclusiveRate;
            }
            else
            {
                mRate = mTimeBillingSaleLine.TaxExclusiveRate;
            }
        }

        public override void Update()
        {
            if (mTimeBillingSaleLine.Sale.IsTaxInclusive == "Y")
            {
                mTimeBillingSaleLine.TaxInclusiveRate = mRate;
                mTimeBillingSaleLine.TaxInclusiveAmount = mRate * mTimeBillingSaleLine.HoursUnits;
                mTimeBillingSaleLine.TaxExclusiveRate = mTimeBillingSaleLine.TaxInclusiveRate / (1 + mTimeBillingSaleLine.TaxCode.TaxPercentageRate / 100);
                mTimeBillingSaleLine.TaxExclusiveAmount = mTimeBillingSaleLine.TaxInclusiveAmount / (1 + mTimeBillingSaleLine.TaxCode.TaxPercentageRate / 100);
            }
            else
            {
                mTimeBillingSaleLine.TaxExclusiveRate = mRate;
                mTimeBillingSaleLine.TaxExclusiveAmount = mRate * mTimeBillingSaleLine.HoursUnits;
                mTimeBillingSaleLine.TaxInclusiveRate = mTimeBillingSaleLine.TaxExclusiveRate * (1 + mTimeBillingSaleLine.TaxCode.TaxPercentageRate / 100);
                mTimeBillingSaleLine.TaxInclusiveAmount = mTimeBillingSaleLine.TaxExclusiveAmount * (1 + mTimeBillingSaleLine.TaxCode.TaxPercentageRate / 100);
            }

            mTimeBillingSaleLine.TaxBasisAmountIsInclusive = mTimeBillingSaleLine.Sale.IsTaxInclusive;
            if (mTimeBillingSaleLine.TaxBasisAmountIsInclusive.Equals("Y"))
            {
                mTimeBillingSaleLine.TaxBasisAmount = mTimeBillingSaleLine.TaxInclusiveAmount;
            }
            else
            {
                mTimeBillingSaleLine.TaxBasisAmount = mTimeBillingSaleLine.TaxExclusiveAmount;
            }

            Update(mTimeBillingSaleLine);
        }

        
    }
}
