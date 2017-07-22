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
    using Accounting.Core.Activities;

    public class BOTimeBillingPurchaseLine : BOPurchaseLine
    {
        public static string LINE_DATE = "LineDate";
        public static string DESCRIPTION = "Description";
        public static string TAXCODE = "TaxCode";
        public static string TAX_BASIS_AMOUNT_IS_INCLUSIVE = "TaxBasisAmountIsInclusive";
        public static string JOB = "Job";
        public static string RATE = "Rate";
        public static string LOCATION = "Location";
        public static string ESTIMATED_COST = "EstimatedCost";
        public static string ACTIVITY = "Activity";
        public static string HOURS_UNITS = "HoursUnits";

        private TimeBillingPurchaseLine mTimeBillingPurchaseLine=null;
        private double mRate = 0;

        public BOTimeBillingPurchaseLine(Accountant accountant, Purchase _purchase, TimeBillingPurchaseLine _line, BOContext context)
            : base(accountant, _purchase, _line, context)
        {
            mObjectID = BOType.BOTimeBillingPurchaseLine;
            mTimeBillingPurchaseLine = _line.Clone() as TimeBillingPurchaseLine;
            mTimeBillingPurchaseLine.Purchase = _purchase;

            if (mTimeBillingPurchaseLine.Purchase.IsTaxInclusive == "Y")
            {
                mRate = mTimeBillingPurchaseLine.TaxInclusiveRate;
            }
            else
            {
                mRate = mTimeBillingPurchaseLine.TaxExclusiveRate;
            }
        }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            #region LINE_DATE
            AddProperty(LINE_DATE,
                LINE_DATE,
                delegate()
                {
                    return mTimeBillingPurchaseLine.LineDate;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mTimeBillingPurchaseLine.LineDate = null;
                    }
                    else if (value is DateTime?)
                    {
                        mTimeBillingPurchaseLine.LineDate = (DateTime?)value;
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
                    return mTimeBillingPurchaseLine.Description;
                },
                delegate(object value)
                {
                    mTimeBillingPurchaseLine.Description = (string)value;
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

            #region TAXCODE
            AddProperty(TAXCODE,
                TAXCODE,
                delegate()
                {
                    return mTimeBillingPurchaseLine.TaxCode;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mTimeBillingPurchaseLine.TaxCode = null;
                    }
                    else if (value is TaxCode)
                    {
                        mTimeBillingPurchaseLine.TaxCode = value as TaxCode;
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
                    return mTimeBillingPurchaseLine.TaxBasisAmountIsInclusive.Equals("Y");
                },
                delegate(object value)
                {
                    mTimeBillingPurchaseLine.TaxBasisAmountIsInclusive = (bool)value ? "Y" : "N";
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

            #region JOB
            AddProperty(JOB,
                JOB,
                delegate()
                {
                    return mTimeBillingPurchaseLine.Job;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mTimeBillingPurchaseLine.Job = null;
                    }
                    else if (value is Job)
                    {
                        mTimeBillingPurchaseLine.Job = value as Job;
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

            #region LOCATION
            AddProperty(LOCATION,
                LOCATION,
                delegate()
                {
                    return mTimeBillingPurchaseLine.Location;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mTimeBillingPurchaseLine.Location = null;
                    }
                    else if (value is Location)
                    {
                        mTimeBillingPurchaseLine.Location = value as Location;
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

            #region ESTIMATED_COST
            AddProperty(ESTIMATED_COST,
                ESTIMATED_COST,
                delegate()
                {
                    return mTimeBillingPurchaseLine.EstimatedCost;
                },
                delegate(object value)
                {
                    mTimeBillingPurchaseLine.EstimatedCost = double.Parse(value as string);
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

            #region ACTIVITY
            AddProperty(ACTIVITY,
                ACTIVITY,
                delegate()
                {
                    return mTimeBillingPurchaseLine.Activity;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mTimeBillingPurchaseLine.Activity = null;
                    }
                    else if (value is Activity)
                    {
                        mTimeBillingPurchaseLine.Activity = value as Activity;
                    }
                    else
                    {
                        throw new Exception("Activity must be of type Activity");
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
                        error = DecorateError(ACTIVITY, "cannot be empty");
                        return false;
                    }
                    else if (value is Activity)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ACTIVITY, "Activity");
                    }
                    return false;
                });
            #endregion

            #region HOURS_UNITS
            AddProperty(HOURS_UNITS,
                HOURS_UNITS,
                delegate()
                {
                    return mTimeBillingPurchaseLine.HoursUnits;
                },
                delegate(object value)
                {
                    mTimeBillingPurchaseLine.HoursUnits = double.Parse(value as string);
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
            #endregion
        }

        public override void Update()
        {
            if (mTimeBillingPurchaseLine.Purchase.IsTaxInclusive == "Y")
            {
                mTimeBillingPurchaseLine.TaxInclusiveRate = mRate;
                mTimeBillingPurchaseLine.TaxInclusiveAmount = mRate * mTimeBillingPurchaseLine.HoursUnits;
                mTimeBillingPurchaseLine.TaxExclusiveRate = mTimeBillingPurchaseLine.TaxInclusiveRate / (1 + mTimeBillingPurchaseLine.TaxCode.TaxPercentageRate / 100);
                mTimeBillingPurchaseLine.TaxExclusiveAmount = mTimeBillingPurchaseLine.TaxInclusiveAmount / (1 + mTimeBillingPurchaseLine.TaxCode.TaxPercentageRate / 100);
            }
            else
            {
                mTimeBillingPurchaseLine.TaxExclusiveRate = mRate;
                mTimeBillingPurchaseLine.TaxExclusiveAmount = mRate * mTimeBillingPurchaseLine.HoursUnits;
                mTimeBillingPurchaseLine.TaxInclusiveRate = mTimeBillingPurchaseLine.TaxExclusiveRate * (1 + mTimeBillingPurchaseLine.TaxCode.TaxPercentageRate / 100);
                mTimeBillingPurchaseLine.TaxInclusiveAmount = mTimeBillingPurchaseLine.TaxExclusiveAmount * (1 + mTimeBillingPurchaseLine.TaxCode.TaxPercentageRate / 100);
            }

            mTimeBillingPurchaseLine.TaxBasisAmountIsInclusive = mTimeBillingPurchaseLine.Purchase.IsTaxInclusive;
            if (mTimeBillingPurchaseLine.TaxBasisAmountIsInclusive == "Y")
            {
                mTimeBillingPurchaseLine.TaxBasisAmount = mTimeBillingPurchaseLine.TaxInclusiveAmount;
            }
            else
            {
                mTimeBillingPurchaseLine.TaxBasisAmount = mTimeBillingPurchaseLine.TaxExclusiveAmount;
            }

            Update(mTimeBillingPurchaseLine);
        }

        
    }
}
