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
    using Accounting.Core.ShippingMethods;
    using Accounting.Core.Misc;
    using Accounting.Core.Terms;

    public class BOCustomer : BOCard
    {
        public static string FIRST_NAME = "FirstName";
        public static string LAST_NAME = "LastName";
        public static string PAYMENT_NOTES = "PaymentNotes";
        public static string PAYMENT_CARD_NUMBER = "PaymentCardNumber";
        public static string PAYMENT_NAME_ON_CARD = "PaymentNameOnCard";
        public static string PAYMENT_EXPIRATION_DATE = "PaymentExpirationDate";
        public static string LAST_SALE_DATE = "LastSaleDate";
        public static string LAST_PAYMENT_DATE = "LastPaymentDate";
        public static string HIGHEST_INVOICE_AMOUNT = "HighestInvoiceAmount";
        public static string HIGHEST_RECEIVABLE_AMOUNT = "HighestReceivableAmount";
        public static string CUSTOMER_SINCE = "CustomerSince";
        public static string PAYMENT_METHOD = "PaymentMethod";
        public static string NOTES = "Notes";
        public static string PICTURE = "Picture";
        public static string VOLUME_DISCOUNT = "VolumeDiscount";
        public static string CREDIT_LIMIT = "CreditLimit";
        public static string TERMS = "Terms";
        public static string CURRENT_BALANCE = "CurrentBalance";
        public static string USE_CUSTOMER_TAXCODE = "UseCustomerTaxCode";
        public static string FREIGHT_TAXCODE = "FreightTaxCode";
        public static string TAX_ID_NUMBER = "TaxIDNumber";
        public static string ABN = "ABN";
        public static string ABN_BRANCH = "ABNBranch";
        public static string HOURLY_BILLING_RATE = "HourlyBillingRate";
        public static string SALE_COMMENT = "SaleComment";
        public static string SHIPPING_METHOD = "ShippingMethod";
        public static string SALES_PERSON = "Salesperson";
        public static string INCOME_ACCOUNT = "IncomeAccount";
        public static string RECEIPT_MEMO = "ReceiptMemo";
        public static string PRICE_LEVEL = "PriceLevel";
        public static string TAXCODE = "TaxCode";
        public static string INVOICE_DELIVERY = "InvoiceDelivery";
        public static string SALE_LAYOUT = "SaleLayout";
        public static string ON_HOLD = "OnHold";

        public static string PAYMENT_BANK_ACCOUNT_NAME = "PaymentBankAccountName";
        public static string PAYMENT_BANK_ACCOUNT_NUMBER = "PaymentBankAccountNumber";
        public static string PAYMENT_BSB = "PaymentBSB";

        private Customer mDataProxy;
        private Customer mDataSource;

        public BOCustomer(Accountant accountant, Customer _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
            mObjectID = BOType.BOCustomer;
            mDataSource = _obj;
            mDataProxy = _obj.Clone() as Customer;
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
                        if (IsWithinRange(value as string, 0, 52, out error))
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

            #region PAYMENT_NOTES
            AddProperty(PAYMENT_NOTES,
                PAYMENT_NOTES,
                delegate()
                {
                    return mDataProxy.PaymentNotes;
                },
                delegate(object value)
                {
                    mDataProxy.PaymentNotes = (string)value;
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
                        error = DecorateError(PAYMENT_NOTES, error); 
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(PAYMENT_NOTES, "string"); 
                    }
                    return false;
                });
            #endregion

            #region PAYMENT_CARD_NUMBER
            AddProperty(PAYMENT_CARD_NUMBER,
                PAYMENT_CARD_NUMBER,
                delegate()
                {
                    return mDataProxy.PaymentCardNumber;
                },
                delegate(object value)
                {
                    mDataProxy.PaymentCardNumber = (string)value;
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
                        if (IsWithinRange(value as string, 0, 25, out error))
                        {
                            return true;
                        }
                        error = DecorateError(PAYMENT_CARD_NUMBER, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(PAYMENT_CARD_NUMBER, "string"); 
                    }
                    return false;
                });
            #endregion

            #region PAYMENT_NAME_ON_CARD
            AddProperty(PAYMENT_NAME_ON_CARD,
                PAYMENT_NAME_ON_CARD,
                delegate()
                {
                    return mDataProxy.PaymentNameOnCard;
                },
                delegate(object value)
                {
                    mDataProxy.PaymentNameOnCard = (string)value;
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
                        if (IsWithinRange(value as string, 0, 50, out error))
                        {
                            return true;
                        }
                        error = DecorateError(PAYMENT_NAME_ON_CARD, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(PAYMENT_NAME_ON_CARD, "string"); 
                    }
                    return false;
                });
            #endregion

            #region PAYMENT_EXPIRATION_DATE
            AddProperty(PAYMENT_EXPIRATION_DATE,
                PAYMENT_EXPIRATION_DATE,
                delegate()
                {
                    return mDataProxy.PaymentExpirationDate;
                },
                delegate(object value)
                {
                    mDataProxy.PaymentExpirationDate = (string)value;
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
                        if (IsWithinRange(value as string, 0, 5, out error))
                        {
                            //string _value=value as string;
                            //if(_value.Length > 0)
                            //{
                            //    string regexpression=@"\d{2}\/d{2}";
                            //    System.Text.RegularExpressions.Regex regex=new System.Text.RegularExpressions.Regex(regexpression);
                            //    if(!regex.IsMatch(_value))
                            //    {
                            //        error = DecorateError(PAYMENT_EXPIRATION_DATE, "must be of form yy/mm");
                            //        return false;
                            //    }
                            //}
                            return true;
                        }
                        error = DecorateError(PAYMENT_EXPIRATION_DATE, "must be of form yy/mm");
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(PAYMENT_EXPIRATION_DATE, "string"); 
                    }
                    return false;
                });
            #endregion

            #region LAST_SALE_DATE
            AddProperty(LAST_SALE_DATE,
                LAST_SALE_DATE,
                delegate()
                {
                    return mDataProxy.LastSaleDate;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.LastSaleDate = null;
                    }
                    if (value is DateTime?)
                    {
                        mDataProxy.LastSaleDate = value as DateTime?;
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
                    else
                    {
                        error= "Customer.LastSaleDate must be of type DateTime?";
                    }
                    return false;
                });
            #endregion

            #region LAST_PAYMENT_DATE
            AddProperty(LAST_PAYMENT_DATE,
                LAST_PAYMENT_DATE,
                delegate()
                {
                    return mDataProxy.LastPaymentDate;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.LastPaymentDate = null;
                    }
                    if (value is DateTime?)
                    {
                        mDataProxy.LastPaymentDate = value as DateTime?;
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
                    else
                    {
                        error = DecorateTypeMismatchError(LAST_PAYMENT_DATE, "DateTime?"); 
                    }
                    return false;
                });
            #endregion

            #region HIGHEST_INVOICE_AMOUNT
            AddProperty(HIGHEST_INVOICE_AMOUNT,
                HIGHEST_INVOICE_AMOUNT,
                delegate()
                {
                    return mDataProxy.HighestInvoiceAmount;
                },
                delegate(object value)
                {
                    mDataProxy.HighestInvoiceAmount = double.Parse(value as string);
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
                        error = DecorateError(HIGHEST_INVOICE_AMOUNT, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(HIGHEST_INVOICE_AMOUNT, "string");
                    }
                    return false;
                });
            #endregion

            #region HIGHEST_RECEIVABLE_AMOUNT
            AddProperty(HIGHEST_RECEIVABLE_AMOUNT,
                HIGHEST_RECEIVABLE_AMOUNT,
                delegate()
                {
                    return mDataProxy.HighestReceivableAmount;
                },
                delegate(object value)
                {
                    mDataProxy.HighestReceivableAmount = double.Parse(value as string);
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
                        if(IsNumeric(value as string, 13, 2, out error))
                        {
                            return true;
                        }
                        error=string.Format("Customer.HighestReceivableAmount {0}", error);
                    }
                    else
                    {
                        error="Customer.HighestReceivableAmount must be input as string";
                    }
                    return false;
                });
            #endregion

            #region CUSTOMER_SINCE
            AddProperty(CUSTOMER_SINCE,
                CUSTOMER_SINCE,
                delegate()
                {
                    return mDataProxy.CustomerSince;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.CustomerSince = null;
                    }
                    else if (value is DateTime?)
                    {
                        mDataProxy.CustomerSince = value as DateTime?;
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
                    else
                    {
                        error = DecorateTypeMismatchError(CUSTOMER_SINCE, "DateTime?");
                    }
                    return false;
                });
            #endregion

            #region PAYMENT_METHOD
            AddProperty(PAYMENT_METHOD,
                PAYMENT_METHOD,
                delegate()
                {
                    return mDataProxy.PaymentMethod;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.PaymentMethod = null;
                    }
                    else if (value is PaymentMethod)
                    {
                        mDataProxy.PaymentMethod = value as PaymentMethod;
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
                    else if (value is PaymentMethod)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(PAYMENT_METHOD, "PaymentMethod");
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
                    if(value is string)
                    {
                        if(IsWithinRange(value as string, 0, 255, out error))
                        {
                            return true;
                        }
                        error = DecorateError(NOTES, error);
                    }
                    else{
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

            #region VOLUME_DISCOUNT
            AddProperty(VOLUME_DISCOUNT,
                VOLUME_DISCOUNT,
                delegate()
                {
                    return mDataProxy.VolumeDiscount;
                },
                delegate(object value)
                {
                    mDataProxy.VolumeDiscount = double.Parse(value as string);
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
                        if (IsNumeric(value as string, 2, 2, out error))
                        {
                            double result = double.Parse(value as string);
                            if (result > 100)
                            {
                                error = DecorateError(VOLUME_DISCOUNT, "must be not larger than 100%");
                                return false;
                            }
                            return true;
                        }
                        error = DecorateError(VOLUME_DISCOUNT, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(VOLUME_DISCOUNT, "string"); 
                    }
                    return false;
                });
            #endregion

            #region CREDIT_LIMIT
            AddProperty(CREDIT_LIMIT,
                CREDIT_LIMIT,
                delegate()
                {
                    return mDataProxy.CreditLimit;
                },
                delegate(object value)
                {
                    mDataProxy.CreditLimit = double.Parse(value as string);
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
                        if (IsNumeric(value as string, 7, 2, out error))
                        {
                            return true;
                        }
                        error = DecorateError(CREDIT_LIMIT, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(CREDIT_LIMIT, "string"); 
                    }
                    return false;
                });
            #endregion

            #region TERMS
            AddProperty(TERMS,
                TERMS,
                delegate()
                {
                    return mDataProxy.Terms;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.Terms = null;
                    }
                    else if (value is Terms)
                    {
                        mDataProxy.Terms = value as Terms;
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
                    else if (value is Terms)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(TERMS, "Terms"); 
                    return false;
                });
            #endregion 

            #region CURRENT_BALANCE
            AddProperty(CURRENT_BALANCE,
                CURRENT_BALANCE,
                delegate()
                {
                    return mDataProxy.CurrentBalance;
                },
                delegate(object value)
                {
                    mDataProxy.CurrentBalance = double.Parse(value as string);
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
                        error = DecorateError(CURRENT_BALANCE, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(CURRENT_BALANCE, "string"); 
                    }
                    return false;
                });
            #endregion

            #region USE_CUSTOMER_TAXCODE
            AddProperty(USE_CUSTOMER_TAXCODE,
                USE_CUSTOMER_TAXCODE,
                delegate()
                {
                    return mDataProxy.UseCustomerTaxCode.Equals("Y");
                },
                delegate(object value)
                {
                    mDataProxy.UseCustomerTaxCode = (bool)value ? "Y" : "N";
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
                    error = DecorateTypeMismatchError(USE_CUSTOMER_TAXCODE, "bool"); 
                    return false;
                });
            #endregion

            #region FREIGHT_TAXCODE
            AddProperty(FREIGHT_TAXCODE,
                FREIGHT_TAXCODE,
                delegate()
                {
                    return mDataProxy.FreightTaxCode;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.FreightTaxCode = null;
                    }
                    else if (value is TaxCode)
                    {
                        mDataProxy.FreightTaxCode = value as TaxCode;
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
                    error = DecorateTypeMismatchError(FREIGHT_TAXCODE, "TaxCode"); 
                    return false;
                });
            #endregion

            #region TAX_ID_NUMBER
            AddProperty(TAX_ID_NUMBER,
                TAX_ID_NUMBER,
                delegate()
                {
                    return mDataProxy.TaxIDNumber;
                },
                delegate(object value)
                {
                    mDataProxy.TaxIDNumber = (string)value;
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
                        error = DecorateError(TAX_ID_NUMBER, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(TAX_ID_NUMBER, "string");
                    }
                    return false;
                });
            #endregion

            #region ABN
            AddProperty(ABN,
                ABN,
                delegate()
                {
                    return mDataProxy.ABN;
                },
                delegate(object value)
                {
                    mDataProxy.ABN = (string)value;
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
                        if (IsWithinRange(value as string, 0, 14, out error))
                        {
                            return true;
                        }
                        error = DecorateError(ABN, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ABN, "string");
                    }
                    return false;
                });
            #endregion

            #region ABN_BRANCH
            AddProperty(ABN_BRANCH,
                ABN_BRANCH,
                delegate()
                {
                    return mDataProxy.ABNBranch;
                },
                delegate(object value)
                {
                    mDataProxy.ABNBranch = (string)value;
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
                            return true;
                        }
                        error = DecorateError(ABN_BRANCH, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ABN_BRANCH, "string"); 
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
                        if (IsNumeric(value as string, 11, 4, out error))
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

            #region SALE_COMMENT
            AddProperty(SALE_COMMENT,
                SALE_COMMENT,
                delegate()
                {
                    return mDataProxy.SaleComment;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.SaleComment = null;
                    }
                    else if (value is Comment)
                    {
                        mDataProxy.SaleComment = value as Comment;
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
                    else if (value is Comment)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(SALE_COMMENT, "Comment"); 
                    return false;
                });
            #endregion

            #region SHIPPING_METHOD
            AddProperty(SHIPPING_METHOD,
                SHIPPING_METHOD,
                delegate()
                {
                    return mDataProxy.ShippingMethod;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.ShippingMethod = null;
                    }
                    else if (value is ShippingMethod)
                    {
                        mDataProxy.ShippingMethod = value as ShippingMethod;
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
                    else if (value is ShippingMethod)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(SHIPPING_METHOD, "ShippingMethod"); 
                    return false;
                });
            #endregion

            #region SALES_PERSON
            AddProperty(SALES_PERSON,
                SALES_PERSON,
                delegate()
                {
                    return mDataProxy.SalesPerson;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.SalesPerson = null;
                    }
                    else if (value is Employee)
                    {
                        mDataProxy.SalesPerson = value as Employee;
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
                    else if (value is Employee)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(SALES_PERSON, "Employee");
                    return false;
                });
            #endregion 

            #region INCOME_ACCOUNT
            AddProperty(INCOME_ACCOUNT,
                INCOME_ACCOUNT,
                delegate()
                {
                    return mDataProxy.IncomeAccount;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.IncomeAccount = null;
                    }
                    else if (value is Account)
                    {
                        mDataProxy.IncomeAccount = value as Account;
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
                    else if (value is Account)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(INCOME_ACCOUNT, "Account");
                    }
                    return false;
                });
            #endregion

            #region RECEIPT_MEMO
            AddProperty(RECEIPT_MEMO,
                RECEIPT_MEMO,
                delegate()
                {
                    return mDataProxy.ReceiptMemo;
                },
                delegate(object value)
                {
                    mDataProxy.ReceiptMemo = (string)value;
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
                        error = DecorateError(RECEIPT_MEMO, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(RECEIPT_MEMO, "string"); 
                    }
                    return false;
                });
            #endregion

            #region PRICE_LEVEL
            AddProperty(PRICE_LEVEL,
                PRICE_LEVEL,
                delegate()
                {
                    return mDataProxy.PriceLevel;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.PriceLevel = null;
                    }
                    else if (value is PriceLevel)
                    {
                        mDataProxy.PriceLevel = value as PriceLevel;
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
                    else if (value is PriceLevel)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(PRICE_LEVEL, "PriceLevel"); 
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
                    else if (value is TaxCode)
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

            #region INVOICE_DELIVERY
            AddProperty(INVOICE_DELIVERY,
                INVOICE_DELIVERY,
                delegate()
                {
                    return mDataProxy.InvoiceDelivery;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.InvoiceDelivery = null;
                    }
                    else if (value is InvoiceDelivery)
                    {
                        mDataProxy.InvoiceDelivery = value as InvoiceDelivery;
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
                    else if (value is InvoiceDelivery)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(INVOICE_DELIVERY, "InvoiceDelivery"); 
                    return false;
                });
            #endregion 

            #region SALE_LAYOUT
            AddProperty(SALE_LAYOUT,
                SALE_LAYOUT,
                delegate()
                {
                    return mDataProxy.SaleLayout;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.SaleLayout = null;
                    }
                    else if (value is InvoiceType)
                    {
                        mDataProxy.SaleLayout = value as InvoiceType;
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
                    else if (value is InvoiceType)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(SALE_LAYOUT, "InvoiceType"); 
                    return false;
                });
            #endregion

            #region ON_HOLD
            AddProperty(ON_HOLD,
                ON_HOLD,
                delegate()
                {
                    return mDataProxy.OnHold.Equals("Y");
                },
                delegate(object value)
                {
                    mDataProxy.OnHold = (bool)value ? "Y" : "N";
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
                    if (value is bool)
                    {
                        return true;
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(ON_HOLD, "bool"); 
                    }
                    return false;
                });
            #endregion

            #region PAYMENT_BSB
            AddProperty(PAYMENT_BSB,
                PAYMENT_BSB,
                delegate()
                {
                    return mDataProxy.PaymentBSB;
                },
                delegate(object value)
                {
                    mDataProxy.PaymentBSB = (string)value;
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
                        if (IsWithinRange(value as string, 0, 7, out error))
                        {
                            return true;
                        }
                        error = DecorateError(PAYMENT_BSB, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(PAYMENT_BSB, "string");
                    }
                    return false;
                });
            #endregion

            #region PAYMENT_BANK_ACCOUNT_NAME
            AddProperty(PAYMENT_BANK_ACCOUNT_NAME,
                PAYMENT_BANK_ACCOUNT_NAME,
                delegate()
                {
                    return mDataProxy.PaymentBankAccountName;
                },
                delegate(object value)
                {
                    mDataProxy.PaymentBankAccountName = (string)value;
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
                        if (IsWithinRange(value as string, 0, 32, out error))
                        {
                            return true;
                        }
                        error = DecorateError(PAYMENT_BANK_ACCOUNT_NAME, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(PAYMENT_BANK_ACCOUNT_NAME, "string");
                    }
                    return false;
                });
            #endregion

            #region PAYMENT_BANK_ACCOUNT_NUMBER
            AddProperty(PAYMENT_BANK_ACCOUNT_NUMBER,
                PAYMENT_BANK_ACCOUNT_NUMBER,
                delegate()
                {
                    return mDataProxy.PaymentBankAccountNumber;
                },
                delegate(object value)
                {
                    mDataProxy.PaymentBankAccountNumber = (string)value;
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
                        if (IsWithinRange(value as string, 0, 9, out error))
                        {
                            //int result;
                            if (!IsNumeric(value as string, 9, 0, out error))
                            {
                                error = DecorateError(PAYMENT_BANK_ACCOUNT_NUMBER, error);
                                return false;
                            }
                            return true;
                        }
                        error = DecorateError(PAYMENT_BANK_ACCOUNT_NUMBER, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(PAYMENT_BANK_ACCOUNT_NUMBER, "string");
                    }
                    return false;
                });
            #endregion
        }

        protected override OpResult _Delete()
        {
            return mAccountant.CustomerMgr.Delete(mDataSource);
        }

        protected override OpResult _Record()
        {
            mDataSource.AssignFrom(mDataProxy);
            return mAccountant.CustomerMgr.Store(mDataSource);
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
