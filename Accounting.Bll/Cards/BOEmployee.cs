using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Cards
{
    using Accounting.Core;
    using Accounting.Core.Cards;
    using Accounting.Core.TaxCodes;
    using Accounting.Core.Definitions;
    using Accounting.Core.Accounts;
    using Accounting.Core.Payroll;

    public class BOEmployee : BOCard
    {
        public static string FIRST_NAME = "FirstName";
        public static string LAST_NAME = "LastName";
        public static string GENDER = "Gender";
        public static string NOTES = "Notes";
        public static string PICTURE = "Picture";
        public static string HOURLY_BILLING_RATE = "HourlyBillingRate";
        public static string ESTIMATED_COST_PER_HOUR = "EstimatedCostPerHour";
        public static string NUMBER_OF_BANK_ACCOUNTS = "NumberOfBankAccounts";
        public static string BANK1_BSB = "Bank1BSB";
        public static string BANK1_ACCOUNT_NAME = "Bank1AccountName";
        public static string BANK1_ACCOUNT_NUMBER = "Bank1AccountNumber";
        public static string BANK1_VALUE = "Bank1Value";
        public static string BANK1_VALUE_TYPE = "Bank1ValueType";
        public static string BANK2_BSB = "Bank2BSB";
        public static string BANK2_ACCOUNT_NAME = "Bank2AccountName";
        public static string BANK2_ACCOUNT_NUMBER = "Bank2AccountNumber";
        public static string BANK2_VALUE = "Bank2Value";
        public static string BANK2_VALUE_TYPE = "Bank2ValueType";
        public static string BANK3_BSB = "Bank3BSB";
        public static string BANK3_ACCOUNT_NAME = "Bank3AccountName";
        public static string BANK3_ACCOUNT_NUMBER = "Bank3AccountNumber";
        public static string BANK3_VALUE = "Bank3Value";
        public static string BANK3_VALUE_TYPE = "Bank3ValueType";
        public static string EMPLOYMENT_BASIS = "EmploymentBasis";
        public static string PAYMENT_TYPE = "PaymentType";
        public static string EMPLOYMENT_CLASSIFICATION = "EmploymentClassification";
        public static string DATE_OF_BIRTH = "DateOfBirth";
        public static string START_DATE = "StartDate";
        public static string TERMINATION_DATE = "TerminationDate";
        public static string PAY_BASIS = "PayBasis";
        public static string BASE_PAY = "BasePay";
        public static string PAY_FREQUENCY = "PayFrequency";
        public static string HOURS_IN_PAY_PERIOD = "HoursInPayPeriod";
        public static string WAGES_EXPENSE_ACCOUNT = "WagesExpenseAccount";
        public static string SUPERANNUATION_FUND = "SuperannuationFund";
        public static string SUPERANNUATION_MEMBERSHIP_NUMBER = "SuperannuationMembershipNumber";
        public static string TAX_FILE_NUMBER = "TaxFileNumber";
        public static string TAX_SCALE = "TaxScale";
        public static string WITHHOLDING_VARIATION_RATE = "WithholdingVariationRate";
        public static string TOTAL_REBATES = "TotalRebates";
        public static string EXTRA_TAX = "ExtraTax";
        public static string EMPLOYMENT_STATUS = "EmploymentStatus";
        public static string EMPLOYMENT_CATEGORY = "EmploymentCategory";

        Employee mDataProxy;
        Employee mDataSource;

        public BOEmployee(Accountant accountant, Employee _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
            mObjectID = BOType.BOEmployee;
            mDataProxy = _obj.Clone() as Employee;
            mDataSource = _obj;
        }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            #region FIRST_NAME
            AddProperty(FIRST_NAME,
                FIRST_NAME,
                delegate()
                {
                    return mDataProxy.FirstName;
                },
                delegate(object value)
                {
                    mDataProxy.FirstName = (string)value;
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    if (mDataProxy.IsIndividual == "Y")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                },
                delegate(object value, ref string error)
                {
                    if (value is string)
                    {
                        if (IsWithinRange(value as string, 0, 20, out error))
                        {
                            return true;
                        }
                        error = DecorateError(FIRST_NAME, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(FIRST_NAME, "string");
                    }
                    return false;
                });
            #endregion

            #region LAST_NAME
            AddProperty(LAST_NAME,
                LAST_NAME,
                delegate()
                {
                    return mDataProxy.LastName;
                },
                delegate(object value)
                {
                    mDataProxy.LastName = (string)value;
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
                        if (IsWithinRange(value as string, 1, 52, out error))
                        {
                            return true;
                        }
                        error = DecorateError(LAST_NAME, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(LAST_NAME, "string");
                    }
                    return false;
                });
            #endregion

            #region GENDER
            AddProperty(GENDER,
                GENDER,
                delegate()
                {
                    return mDataProxy.Gender;
                },
                delegate(object value)
                {
                    mDataProxy.Gender = (string)value;
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
                        error = DecorateError(GENDER, "cannot be empty");
                        return false;
                    }
                    else if (value is string)
                    {
                        if (IsWithinRange(value as string, 1, 1, out error))
                        {
                            return true;
                        }
                        error = DecorateError(GENDER, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(GENDER, "string");
                    }
                    return false;
                });
            #endregion 

            #region NOTES
            AddProperty(NOTES,
                NOTES,
                delegate()
                {
                    return mDataProxy.Notes;
                },
                delegate(object value)
                {
                    mDataProxy.Notes = (string)value;
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
                        error = DecorateError(NOTES, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(NOTES, "string");
                    }
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

            #region HOURLY_BILLING_RATE
            AddProperty(HOURLY_BILLING_RATE,
                HOURLY_BILLING_RATE,
                delegate()
                {
                    return mDataProxy.HourlyBillingRate;
                },
                delegate(object value)
                {
                    mDataProxy.HourlyBillingRate = double.Parse(value as string);
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
                        error = DecorateError(HOURLY_BILLING_RATE, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(HOURLY_BILLING_RATE, "string");
                    }
                    return false;
                });
            #endregion

            #region ESTIMATED_COST_PER_HOUR
            AddProperty(ESTIMATED_COST_PER_HOUR,
                ESTIMATED_COST_PER_HOUR,
                delegate()
                {
                    return mDataProxy.EstimatedCostPerHour;
                },
                delegate(object value)
                {
                    mDataProxy.EstimatedCostPerHour = double.Parse(value as string);
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
                        error = DecorateError(ESTIMATED_COST_PER_HOUR, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(ESTIMATED_COST_PER_HOUR, "string");
                    }
                    return false;
                });
            #endregion

            #region NUMBER_OF_BANK_ACCOUNTS
            AddProperty(NUMBER_OF_BANK_ACCOUNTS,
                NUMBER_OF_BANK_ACCOUNTS,
                delegate()
                {
                    return mDataProxy.NumberOfBankAccounts.ToString();
                },
                delegate(object value)
                {
                    mDataProxy.NumberOfBankAccounts = int.Parse(value as string);
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
                    return true;
                });
            #endregion

            #region BANK1_BSB
            AddProperty(BANK1_BSB,
                BANK1_BSB,
                delegate()
                {
                    return mDataProxy.BSBCode;
                },
                delegate(object value)
                {
                    mDataProxy.BSBCode = (string)value;
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
                        if (IsWithinRange(value as string, 0, 9, out error))
                        {
                            return true;
                        }
                        error = DecorateError(BANK1_BSB, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(BANK1_BSB, "string"); 
                    }
                    return false;
                });
            #endregion

            #region BANK1_ACCOUNT_NUMBER
            AddProperty(BANK1_ACCOUNT_NUMBER,
                BANK1_ACCOUNT_NUMBER,
                delegate()
                {
                    return mDataProxy.BankAccountNumber;
                },
                delegate(object value)
                {
                    mDataProxy.BankAccountNumber = (string)value;
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
                        if (IsWithinRange(value as string, 0, 19, out error))
                        {
                            return true;
                        }
                        error = DecorateError(BANK1_ACCOUNT_NUMBER, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(BANK1_ACCOUNT_NUMBER, "string");
                    }
                    return false;
                });
            #endregion

            #region BANK1_ACCOUNT_NAME
            AddProperty(BANK1_ACCOUNT_NAME,
                BANK1_ACCOUNT_NAME,
                delegate()
                {
                    return mDataProxy.BankAccountName;
                },
                delegate(object value)
                {
                    mDataProxy.BankAccountName = (string)value;
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
                        if (IsWithinRange(value as string, 0, 26, out error))
                        {
                            return true;
                        }
                        error = DecorateError(BANK1_ACCOUNT_NAME, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(BANK1_ACCOUNT_NAME, "string");
                    }
                    return false;
                });
            #endregion

            #region BANK1_VALUE
            AddProperty(BANK1_VALUE,
                BANK1_VALUE,
                delegate()
                {
                    return mDataProxy.Bank1Value;
                },
                delegate(object value)
                {
                    double val = 0;
                    if (double.TryParse(value as string, out val))
                    {
                        mDataProxy.Bank1Value = val;
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
                    if (value is string)
                    {
                        if (string.IsNullOrEmpty(value as string))
                        {
                            return true;
                        }
                        if (IsNumeric(value as string, 13, 2, out error))
                        {
                            return true;
                        }
                        error = DecorateError(BANK1_VALUE, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(BANK1_VALUE, "string");
                    }
                    return false;
                });
            #endregion

            #region BANK1_VALUE_TYPE
            AddProperty(BANK1_VALUE_TYPE,
                BANK1_VALUE_TYPE,
                delegate()
                {
                    return mDataProxy.Bank1ValueType;
                },
                delegate(object value)
                {
                    mDataProxy.Bank1ValueType = value as PaymentValueType;
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
                    else if (value is PaymentValueType)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(BANK1_VALUE_TYPE, "PaymentValueType");
                    }
                    return false;
                });
            #endregion 

            #region BANK2_BSB
            AddProperty(BANK2_BSB,
                BANK2_BSB,
                delegate()
                {
                    return mDataProxy.BSBCode2;
                },
                delegate(object value)
                {
                    mDataProxy.BSBCode2 = (string)value;
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
                        if (IsWithinRange(value as string, 0, 9, out error))
                        {
                            return true;
                        }
                        error = DecorateError(BANK2_BSB, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(BANK2_BSB, "string");
                    }
                    return false;
                });
            #endregion

            #region BANK2_ACCOUNT_NUMBER
            AddProperty(BANK2_ACCOUNT_NUMBER,
                BANK2_ACCOUNT_NUMBER,
                delegate()
                {
                    return mDataProxy.BankAccountNumber2;
                },
                delegate(object value)
                {
                    mDataProxy.BankAccountNumber2 = (string)value;
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
                        if (IsWithinRange(value as string, 0, 19, out error))
                        {
                            return true;
                        }
                        error = DecorateError(BANK2_ACCOUNT_NUMBER, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(BANK2_ACCOUNT_NUMBER, "string");
                    }
                    return false;
                });
            #endregion

            #region BANK2_ACCOUNT_NAME
            AddProperty(BANK2_ACCOUNT_NAME,
                BANK2_ACCOUNT_NAME,
                delegate()
                {
                    return mDataProxy.BankAccountName2;
                },
                delegate(object value)
                {
                    mDataProxy.BankAccountName2 = (string)value;
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
                        if (IsWithinRange(value as string, 0, 26, out error))
                        {
                            return true;
                        }
                        error = DecorateError(BANK2_ACCOUNT_NAME, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(BANK2_ACCOUNT_NAME, "string");
                    }
                    return false;
                });
            #endregion

            #region BANK2_VALUE
            AddProperty(BANK2_VALUE,
                BANK2_VALUE,
                delegate()
                {
                    return mDataProxy.Bank2Value;
                },
                delegate(object value)
                {
                    double val=0;
                    if(double.TryParse(value as string, out val))
                    {
                        mDataProxy.Bank2Value = val;
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
                    if (value is string)
                    {
                        if (string.IsNullOrEmpty(value as string))
                        {
                            return true;
                        }
                        if (IsNumeric(value as string, 13, 2, out error))
                        {
                            return true;
                        }
                        error = DecorateError(BANK2_VALUE, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(BANK2_VALUE, "string");
                    }
                    return false;
                });
            #endregion

            #region BANK2_VALUE_TYPE
            AddProperty(BANK2_VALUE_TYPE,
                BANK2_VALUE_TYPE,
                delegate()
                {
                    return mDataProxy.Bank2ValueType;
                },
                delegate(object value)
                {
                    mDataProxy.Bank2ValueType = value as PaymentValueType;
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
                    else if (value is PaymentValueType)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(BANK2_VALUE_TYPE, "PaymentValueType");
                    }
                    return false;
                });
            #endregion 

            #region BANK3_BSB
            AddProperty(BANK3_BSB,
                BANK3_BSB,
                delegate()
                {
                    return mDataProxy.BSBCode3;
                },
                delegate(object value)
                {
                    mDataProxy.BSBCode3 = (string)value;
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
                        if (IsWithinRange(value as string, 0, 9, out error))
                        {
                            return true;
                        }
                        error = DecorateError(BANK3_BSB, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(BANK3_BSB, "string");
                    }
                    return false;
                });
            #endregion

            #region BANK3_ACCOUNT_NUMBER
            AddProperty(BANK3_ACCOUNT_NUMBER,
                BANK3_ACCOUNT_NUMBER,
                delegate()
                {
                    return mDataProxy.BankAccountNumber3;
                },
                delegate(object value)
                {
                    mDataProxy.BankAccountNumber3 = (string)value;
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
                        if (IsWithinRange(value as string, 0, 19, out error))
                        {
                            return true;
                        }
                        error = DecorateError(BANK3_ACCOUNT_NUMBER, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(BANK3_ACCOUNT_NUMBER, "string");
                    }
                    return false;
                });
            #endregion

            #region BANK3_ACCOUNT_NAME
            AddProperty(BANK3_ACCOUNT_NAME,
                BANK3_ACCOUNT_NAME,
                delegate()
                {
                    return mDataProxy.BankAccountName3;
                },
                delegate(object value)
                {
                    mDataProxy.BankAccountName3 = (string)value;
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
                        if (IsWithinRange(value as string, 0, 26, out error))
                        {
                            return true;
                        }
                        error = DecorateError(BANK3_ACCOUNT_NAME, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(BANK3_ACCOUNT_NAME, "string");
                    }
                    return false;
                });
            #endregion

            #region BANK3_VALUE
            AddProperty(BANK3_VALUE,
                BANK3_VALUE,
                delegate()
                {
                    return mDataProxy.Bank3Value;
                },
                delegate(object value)
                {
                    double val = 0;
                    if (double.TryParse(value as string, out val))
                    {
                        mDataProxy.Bank3Value = val;
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
                    if (value is string)
                    {
                        if (string.IsNullOrEmpty(value as string))
                        {
                            return true;
                        }
                        if (IsNumeric(value as string, 13, 2, out error))
                        {
                            return true;
                        }
                        error = DecorateError(BANK3_VALUE, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(BANK3_VALUE, "string");
                    }
                    return false;
                });
            #endregion

            #region BANK3_VALUE_TYPE
            AddProperty(BANK3_VALUE_TYPE,
                BANK3_VALUE_TYPE,
                delegate()
                {
                    return mDataProxy.Bank3ValueType;
                },
                delegate(object value)
                {
                    mDataProxy.Bank3ValueType = value as PaymentValueType;
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
                    else if (value is PaymentValueType)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(BANK3_VALUE_TYPE, "PaymentValueType");
                    }
                    return false;
                });
            #endregion 

            #region EMPLOYMENT_BASIS
            AddProperty(EMPLOYMENT_BASIS,
                EMPLOYMENT_BASIS,
                delegate()
                {
                    return mDataProxy.EmploymentBasis;
                },
                delegate(object value)
                {
                    mDataProxy.EmploymentBasis = value as EmploymentBasis;
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
                        error = DecorateError(EMPLOYMENT_BASIS, "cannot be empty");
                        return false;
                    }
                    else if (value is EmploymentBasis)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(EMPLOYMENT_BASIS, "EmploymentBasis");
                    }
                    return false;
                });
            #endregion 

            #region PAYMENT_TYPE
            AddProperty(PAYMENT_TYPE,
                PAYMENT_TYPE,
                delegate()
                {
                    return mDataProxy.PaymentType;
                },
                delegate(object value)
                {
                    mDataProxy.PaymentType = value as PaymentType;
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
                        error = DecorateError(PAYMENT_TYPE, "cannot be empty");
                        return false;
                    }
                    else if (value is PaymentType)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(PAYMENT_TYPE, "PaymentType");
                    }
                    return false;
                });
            #endregion 

            #region EMPLOYMENT_CLASSIFICATION
            AddProperty(EMPLOYMENT_CLASSIFICATION,
                EMPLOYMENT_CLASSIFICATION,
                delegate()
                {
                    return mDataProxy.EmploymentClassification;
                },
                delegate(object value)
                {
                    mDataProxy.EmploymentClassification = value as EmploymentClassification;
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
                        error = DecorateError(EMPLOYMENT_CLASSIFICATION, "cannot be empty");
                        return false;
                    }
                    else if (value is EmploymentClassification)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(EMPLOYMENT_CLASSIFICATION, "EmploymentClassification");
                    }
                    return false;
                });
            #endregion 

            #region DATE_OF_BIRTH
            AddProperty(DATE_OF_BIRTH,
                DATE_OF_BIRTH,
                delegate()
                {
                    return mDataProxy.DateOfBirth;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.DateOfBirth = null;
                    }
                    else
                    {
                        mDataProxy.DateOfBirth = value as DateTime?;
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
                    error =DecorateTypeMismatchError(DATE_OF_BIRTH, "DateTime?");
                    return false;
                });
            #endregion

            #region START_DATE
            AddProperty(START_DATE,
                START_DATE,
                delegate()
                {
                    return mDataProxy.StartDate;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.StartDate = null;
                    }
                    else
                    {
                        mDataProxy.StartDate = value as DateTime?;
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
                    error = DecorateTypeMismatchError(START_DATE, "DateTime?");
                    return false;
                });
            #endregion

            #region TERMINATION_DATE
            AddProperty(TERMINATION_DATE,
                TERMINATION_DATE,
                delegate()
                {
                    return mDataProxy.TerminationDate;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.TerminationDate = null;
                    }
                    else
                    {
                        mDataProxy.TerminationDate = value as DateTime?;
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
                    error = DecorateTypeMismatchError(TERMINATION_DATE, "DateTime?");
                    return false;
                });
            #endregion

            #region PAY_BASIS
            AddProperty(PAY_BASIS,
                PAY_BASIS,
                delegate()
                {
                    return mDataProxy.PayBasis;
                },
                delegate(object value)
                {
                    mDataProxy.PayBasis = value as PayBasis;
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
                        error = DecorateError(PAY_BASIS, "cannot be empty");
                        return false;
                    }
                    else if (value is PayBasis)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(PAY_BASIS, "PayBasis");
                    }
                    return false;
                });
            #endregion 

            #region BASE_PAY
            AddProperty(BASE_PAY,
                BASE_PAY,
                delegate()
                {
                    return mDataProxy.BasePay;
                },
                delegate(object value)
                {
                    double val=0;
                    if(double.TryParse(value as string, out val))
                    {
                        mDataProxy.BasePay = val;
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
                    if (value is string)
                    {
                        if (string.IsNullOrEmpty(value as string))
                        {
                            return true;
                        }
                        if (IsNumeric(value as string, 13, 2, out error))
                        {
                            return true;
                        }
                        error = DecorateError(BASE_PAY, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(BASE_PAY, "string");
                    }
                    return false;
                });
            #endregion

            #region PAY_FREQUENCY
            AddProperty(PAY_FREQUENCY,
                PAY_FREQUENCY,
                delegate()
                {
                    return mDataProxy.PayFrequency;
                },
                delegate(object value)
                {
                    mDataProxy.PayFrequency = value as Frequency;
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
                        error = DecorateError(PAY_FREQUENCY, "cannot be empty");
                        return false;
                    }
                    else if (value is Frequency)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(PAY_FREQUENCY, "PayFrequency");
                    }
                    return false;
                });
            #endregion 

            #region HOURS_IN_PAY_PERIOD
            AddProperty(HOURS_IN_PAY_PERIOD,
                HOURS_IN_PAY_PERIOD,
                delegate()
                {
                    return mDataProxy.HoursInPayPeriod;
                },
                delegate(object value)
                {
                    double val = 0;
                    if (double.TryParse(value as string, out val))
                    {
                        mDataProxy.HoursInPayPeriod = val;
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
                    if (value is string)
                    {
                        if (string.IsNullOrEmpty(value as string))
                        {
                            return true;
                        }
                        if (IsNumeric(value as string, 3, 3, out error))
                        {
                            return true;
                        }
                        error = DecorateError(HOURS_IN_PAY_PERIOD, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(HOURS_IN_PAY_PERIOD, "string");
                    }
                    return false;
                });
            #endregion

            #region WAGES_EXPENSE_ACCOUNT
            AddProperty(WAGES_EXPENSE_ACCOUNT,
                WAGES_EXPENSE_ACCOUNT,
                delegate()
                {
                    return mDataProxy.WagesExpenseAccount;
                },
                delegate(object value)
                {
                    mDataProxy.WagesExpenseAccount = value as Account;
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
                        error = DecorateError(WAGES_EXPENSE_ACCOUNT, "cannot be empty");
                        return false;
                    }
                    else if (value is Account)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(WAGES_EXPENSE_ACCOUNT, "Account");
                    }
                    return false;
                });
            #endregion 

            #region SUPERANNUATION_FUND
            AddProperty(SUPERANNUATION_FUND,
                SUPERANNUATION_FUND,
                delegate()
                {
                    return mDataProxy.SuperannuationFund;
                },
                delegate(object value)
                {
                    mDataProxy.SuperannuationFund = value as SuperannuationFund;
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
                        error = DecorateError(SUPERANNUATION_FUND, "cannot be empty");
                        return false;
                    }
                    else if (value is SuperannuationFund)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(SUPERANNUATION_FUND, "SuperannuationFund");
                    }
                    return false;
                });
            #endregion 

            #region SUPERANNUATION_MEMBERSHIP_NUMBER
            AddProperty(SUPERANNUATION_MEMBERSHIP_NUMBER,
                SUPERANNUATION_MEMBERSHIP_NUMBER,
                delegate()
                {
                    return mDataProxy.SuperannuationMembershipNumber;
                },
                delegate(object value)
                {
                    mDataProxy.SuperannuationMembershipNumber = (string)value;
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
                        if (IsWithinRange(value as string, 0, 16, out error))
                        {
                            return true;
                        }
                        error = DecorateError(SUPERANNUATION_MEMBERSHIP_NUMBER, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(SUPERANNUATION_MEMBERSHIP_NUMBER, "string");
                    }
                    return false;
                });
            #endregion

            #region TAX_FILE_NUMBER
            AddProperty(TAX_FILE_NUMBER,
                TAX_FILE_NUMBER,
                delegate()
                {
                    return mDataProxy.TaxFileNumber;
                },
                delegate(object value)
                {
                    mDataProxy.TaxFileNumber = (string)value;
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
                        
                        if (IsWithinRange(value as string, 0, 11, out error))
                        {
                            if (string.IsNullOrEmpty(value as string))
                            {
                                return true;
                            }
                            if (!IsInteger(value as string, 11, false, out error))
                            {
                                error = DecorateError(TAX_FILE_NUMBER, error);
                                return false;
                            }
                            return true;
                        }
                        error = DecorateError(TAX_FILE_NUMBER, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(TAX_FILE_NUMBER, "string");
                    }
                    return false;
                });
            #endregion

            #region TAX_SCALE
            AddProperty(TAX_SCALE,
                TAX_SCALE,
                delegate()
                {
                    return mDataProxy.TaxScale;
                },
                delegate(object value)
                {
                    mDataProxy.TaxScale = value as TaxScale;
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
                        error = DecorateError(TAX_SCALE, "cannot be empty");
                        return false;
                    }
                    else if (value is TaxScale)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(TAX_SCALE, "TaxScale");
                    }
                    return false;
                });
            #endregion 

            #region WITHHOLDING_VARIATION_RATE
            AddProperty(WITHHOLDING_VARIATION_RATE,
                WITHHOLDING_VARIATION_RATE,
                delegate()
                {
                    return mDataProxy.WithholdingVariationRate;
                },
                delegate(object value)
                {
                    double val = 0;
                    if (double.TryParse(value as string, out val))
                    {
                        mDataProxy.WithholdingVariationRate = val;
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
                    if (value is string)
                    {
                        if (string.IsNullOrEmpty(value as string))
                        {
                            return true;
                        }
                        if (IsNumeric(value as string, 3, 4, out error))
                        {
                            return true;
                        }
                        error = DecorateError(WITHHOLDING_VARIATION_RATE, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(WITHHOLDING_VARIATION_RATE, "string");
                    }
                    return false;
                });
            #endregion

            #region TOTAL_REBATES
            AddProperty(TOTAL_REBATES,
                TOTAL_REBATES,
                delegate()
                {
                    return mDataProxy.TotalRebates;
                },
                delegate(object value)
                {
                    double val = 0;
                    if (double.TryParse(value as string, out val))
                    {
                        mDataProxy.TotalRebates = val;
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
                    if (value is string)
                    {
                        if (string.IsNullOrEmpty(value as string))
                        {
                            return true;
                        }
                        if (IsNumeric(value as string, 13, 2, out error))
                        {
                            return true;
                        }
                        error = DecorateError(TOTAL_REBATES, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(TOTAL_REBATES, "string");
                    }
                    return false;
                });
            #endregion

            #region EXTRA_TAX
            AddProperty(EXTRA_TAX,
                EXTRA_TAX,
                delegate()
                {
                    return mDataProxy.ExtraTax;
                },
                delegate(object value)
                {
                    double val = 0;
                    if (double.TryParse(value as string, out val))
                    {
                        mDataProxy.ExtraTax = val;
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
                    if (value is string)
                    {
                        if (string.IsNullOrEmpty(value as string))
                        {
                            return true;
                        }
                        if (IsNumeric(value as string, 13, 2, out error))
                        {
                            return true;
                        }
                        error = DecorateError(EXTRA_TAX, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(EXTRA_TAX, "string");
                    }
                    return false;
                });
            #endregion

            #region EMPLOYMENT_STATUS
            AddProperty(EMPLOYMENT_STATUS,
                EMPLOYMENT_STATUS,
                delegate()
                {
                    return mDataProxy.EmploymentStatus;
                },
                delegate(object value)
                {
                    mDataProxy.EmploymentStatus = value as EmploymentStatus;
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
                        error = DecorateError(EMPLOYMENT_STATUS, "cannot be empty");
                        return false;
                    }
                    else if (value is EmploymentStatus)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(EMPLOYMENT_STATUS, "EmploymentStatus");
                    }
                    return false;
                });
            #endregion 

            #region EMPLOYMENT_CATEGORY
            AddProperty(EMPLOYMENT_CATEGORY,
                EMPLOYMENT_CATEGORY,
                delegate()
                {
                    return mDataProxy.EmploymentCategory;
                },
                delegate(object value)
                {
                    mDataProxy.EmploymentCategory = value as EmploymentCategory;
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
                        error = DecorateError(EMPLOYMENT_CATEGORY, "cannot be empty");
                        return false;
                    }
                    else if (value is EmploymentCategory)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(EMPLOYMENT_CATEGORY, "EmploymentCategory");
                    }
                    return false;
                });
            #endregion 
        }

        protected override OpResult _Delete()
        {
            return mAccountant.EmployeeMgr.Delete(mDataSource);
        }

        public string GenerateCardIdentification()
        {
            return mAccountant.EmployeeMgr.GenerateCardIdentification();
        }

        protected override OpResult _Record()
        {
            mDataSource.AssignFrom(mDataProxy);
            return mAccountant.EmployeeMgr.Store(mDataSource);
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
