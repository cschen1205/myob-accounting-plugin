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

    public class BOSupplier : BOCard
    {
        private Supplier mDataProxy;
        private Supplier mDataSource;

        public static string PAYMENT_BSB="BSBCode";
        public static string PAYMENT_BANK_ACCOUNT_NUMBER="BankAccountNumber";
        public static string PAYMENT_BANK_ACCOUNT_NAME="BankAccountName";
        public static string PAYMENT_MEMO="PaymentMemo";
        public static string PAYMENT_CARD_NUMBER="PaymentCardNumber";
        public static string PAYMENT_NAME_ON_CARD="PaymentNameOnCard";
        public static string PAYMENT_EXPIRATION_DATE="PaymentExpirationDate";
        public static string HIGHEST_PURCHASE_AMOUNT="HighestPurchaseAmount";
        public static string LAST_PURCHASE_DATE="LastPurchaseDate";
        public static string LAST_PAYMENT_DATE = "LastPaymentDate";
        public static string HIGHEST_PAYABLE_AMOUNT="HighestPayableAmount";
        public static string ESTIMATED_COST_PER_HOUR="EstimatedCostPerHour";
        public static string SUPPLIER_SINCE="SupplierSince";
        public static string TAXCODE = "TaxCode";
        public static string INVOICE_DELIVERY="InvoiceDelivery";
        public static string PURCHASE_LAYOUT="PurchaseLayout";
        public static string PAYMENT_METHOD="PaymentMethod";
        public static string NOTES="Notes";
        public static string PICTURE = "Picture";
        public static string VOLUME_DISCOUNT="VolumeDiscount";
        public static string CREDIT_LIMIT = "CreditLimit";
        public static string TERMS = "Terms";
        public static string CURRENT_BALANCE = "CurrentBalance";
        public static string USE_SUPPLIER_TAXCODE= "UseSupplierTaxCode";
        public static string FREIGHT_TAXCODE= "FreightTaxCode";
        public static string TAX_ID_NUMBER = "TaxIDNumber";
        public static string ABN = "ABN";
        public static string ABN_BRANCH = "ABNBranch";
        public static string HOURLY_BILLING_RATE = "HourlyBillingRate";
        public static string PURCHASE_COMMENT = "PurchaseComment";
        public static string SHIPPING_METHOD = "ShippingMethod";
        public static string EXPENSE_ACCOUNT = "ExpenseAccount";
        public static string PAYMENT_NOTES = "PaymentNotes";
        public static string LAST_NAME = "LastName";
        public static string FIRST_NAME = "FirstName";

        public BOSupplier(Accountant accountant, Supplier _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
            mObjectID = BOType.BOSupplier;
            mDataProxy = _obj.Clone() as Supplier;
            mDataSource = _obj;
        }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            #region BSB_CODE
            AddProperty(PAYMENT_BSB,
                PAYMENT_BSB,
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
                        if (IsAlphabet(value as string, 0, 9, out error))
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

            #region BANK_ACCOUNT_NUMBER
            AddProperty(PAYMENT_BANK_ACCOUNT_NUMBER,
                PAYMENT_BANK_ACCOUNT_NUMBER,
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
                        error = DecorateError(PAYMENT_BANK_ACCOUNT_NUMBER, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(PAYMENT_BANK_ACCOUNT_NUMBER, "string"); 
                    }
                    return false;
                });
            #endregion

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

            #region BANK_ACCOUNT_NAME
            AddProperty(PAYMENT_BANK_ACCOUNT_NAME,
                PAYMENT_BANK_ACCOUNT_NAME,
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
                        error = DecorateError(PAYMENT_BANK_ACCOUNT_NAME, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(PAYMENT_BANK_ACCOUNT_NAME, "string"); 
                    }
                    return false;
                });
            #endregion

            #region PAYMENT_MEMO
            AddProperty(PAYMENT_MEMO,
                PAYMENT_MEMO,
                delegate()
                {
                    return mDataProxy.PaymentMemo;
                },
                delegate(object value)
                {
                    mDataProxy.PaymentMemo = (string)value;
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
                        error = DecorateError(PAYMENT_MEMO, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(PAYMENT_MEMO, "string"); 
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
                            string _value = value as string;
                            if (_value.Length > 0)
                            {
                                string regexpression = @"\d{2}\/d{2}";
                                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(regexpression);
                                if (!regex.IsMatch(_value))
                                {
                                    error = DecorateError(PAYMENT_EXPIRATION_DATE, "must be of form yy/mm");
                                    return false;
                                }
                            }
                            return true;
                        }
                        error = DecorateError(PAYMENT_EXPIRATION_DATE, "must be of form yy/mm");
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(PAYMENT_EXPIRATION_DATE, "string"); 
                    }
                    return false;
                });
            #endregion

            #region HIGHEST_PURCHASE_AMOUNT
            AddProperty(HIGHEST_PURCHASE_AMOUNT,
                HIGHEST_PURCHASE_AMOUNT,
                delegate()
                {
                    return mDataProxy.HighestPurchaseAmount;
                },
                delegate(object value)
                {
                    mDataProxy.HighestPurchaseAmount = double.Parse(value as string);
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
                        error = DecorateError(HIGHEST_PURCHASE_AMOUNT, error);
                    }
                    else
                    {
                        error = DecorateInputTypeMismatchError(HIGHEST_PURCHASE_AMOUNT, "string"); 
                    }
                    return false;
                }
            );
            #endregion

            #region LAST_PURCHASE_DATE
            AddProperty(LAST_PURCHASE_DATE,
                LAST_PURCHASE_DATE,
                delegate()
                {
                    return mDataProxy.LastPurchaseDate;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.LastPurchaseDate = null;
                    }
                    else if (value is DateTime?)
                    {
                        mDataProxy.LastPurchaseDate = value as DateTime?;
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
                    error = DecorateTypeMismatchError(LAST_PURCHASE_DATE, "DateTime?");
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
                    else if (value is DateTime?)
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
                    error = DecorateTypeMismatchError(LAST_PAYMENT_DATE, "DateTime?");
                    return false;
                });
            #endregion

            #region HIGHEST_PAYABLE_AMOUNT
            AddProperty(HIGHEST_PAYABLE_AMOUNT,
                HIGHEST_PAYABLE_AMOUNT,
                delegate()
                {
                    return mDataProxy.HighestPayableAmount;
                },
                delegate(object value)
                {
                    mDataProxy.HighestPayableAmount = double.Parse(value as string);
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
                        error = DecorateError(HIGHEST_PAYABLE_AMOUNT, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(HIGHEST_PAYABLE_AMOUNT, "string"); 
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
                        error = DecorateTypeMismatchError(ESTIMATED_COST_PER_HOUR, "string"); 
                    }
                    return false;
                });
            #endregion

            #region SUPPLIER_SINCE
            AddProperty(SUPPLIER_SINCE,
                SUPPLIER_SINCE,
                delegate()
                {
                    return mDataProxy.SupplierSince;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.SupplierSince = null;
                    }
                    else if (value is DateTime?)
                    {
                        mDataProxy.SupplierSince = value as DateTime?;
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
                    error = DecorateTypeMismatchError(SUPPLIER_SINCE, "DateTime?");
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
                        mDataProxy.TaxCode = (TaxCode)value;
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
                        mDataProxy.InvoiceDelivery = (InvoiceDelivery)value;
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

            #region PURCHASE_LAYOUT
            AddProperty(PURCHASE_LAYOUT,
                PURCHASE_LAYOUT,
                delegate()
                {
                    return mDataProxy.PurchaseLayout;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.PurchaseLayout = null;
                    }
                    if (value is InvoiceType)
                    {
                        mDataProxy.PurchaseLayout = (InvoiceType)value;
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
                    error = DecorateTypeMismatchError(PURCHASE_LAYOUT, "InvoiceType"); 
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
                        mDataProxy.PaymentMethod = (PaymentMethod)value;
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
                    else if(value is PaymentMethod)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(PAYMENT_METHOD, "PaymentMethod"); 
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
                        if (IsWithinRange(value as string, 0, 255, out  error))
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

            #region VOLUME_DISCOUNT
            AddProperty(VOLUME_DISCOUNT,
                VOLUME_DISCOUNT,
                delegate()
                {
                    return mDataProxy.VolumeDiscount;
                },
                delegate(object value)
                {
                    if (value is string)
                    {
                        double result;
                        if (double.TryParse((string)value, out result))
                        {
                            mDataProxy.VolumeDiscount = result;
                        }
                    }
                    else
                    {
                        mDataProxy.VolumeDiscount = (double)value;
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
                        error = DecorateTypeMismatchError(VOLUME_DISCOUNT, "string"); 
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
                        error="Supplier.CreditLimit must be input as string";
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
                        mDataProxy.Terms = (Terms)value;
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
                        error = DecorateTypeMismatchError(CURRENT_BALANCE, "string"); 
                    }
                    return false;
                });
            #endregion

            #region USE_SUPPLIER_TAXCODE
            AddProperty(USE_SUPPLIER_TAXCODE,
                USE_SUPPLIER_TAXCODE,
                delegate()
                {
                    return mDataProxy.UseSupplierTaxCode.Equals("Y");
                },
                delegate(object value)
                {
                    mDataProxy.UseSupplierTaxCode = (bool)value ? "Y" : "N";
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
                    error = DecorateTypeMismatchError(USE_SUPPLIER_TAXCODE, "string"); 
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
                    if (value is TaxCode)
                    {
                        mDataProxy.FreightTaxCode = (TaxCode)value;
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
                        if(IsWithinRange(value as string, 0, 14, out error))
                        {
                            return true;
                        }
                        error=string.Format("Supplier.ABN {0}", error);
                    }
                    else
                    {
                        error="Supplier.ABN must be of type string";
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
                        if (IsNumeric(value as string, 13, 2, out error))
                        {
                            return true;
                        }
                        error = DecorateError(HOURLY_BILLING_RATE, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(HOURLY_BILLING_RATE, "string"); 
                    }
                    return false;
                });
            #endregion

            #region PURCHASE_COMMENT
            AddProperty(PURCHASE_COMMENT,
                PURCHASE_COMMENT,
                delegate()
                {
                    return mDataProxy.PurchaseComment;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.PurchaseComment = null;
                    }
                    else if (value is Comment)
                    {
                        mDataProxy.PurchaseComment = value as Comment;
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
                    error = DecorateTypeMismatchError(PURCHASE_COMMENT, "Comment"); 
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

            #region EXPENSE_ACCOUNT
            AddProperty(EXPENSE_ACCOUNT,
                EXPENSE_ACCOUNT,
                delegate()
                {
                    return mDataProxy.ExpenseAccount;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.ExpenseAccount = null;
                    }
                    else if (value is Account)
                    {
                        mDataProxy.ExpenseAccount = value as Account;
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
                    error = DecorateTypeMismatchError(EXPENSE_ACCOUNT, "Account");
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
                        if(IsWithinRange(value as string, 0, 255, out error))
                        {
                            return true;
                        }
                        error=string.Format("Supplier.PaymentNotes {0}", error);
                    }
                    else
                    {
                        error="Supplier.PaymentNotes must be of type string";
                    }
                    return false;
                });
            #endregion
        }

        public string GenerateCardIdentification()
        {
            return mAccountant.SupplierMgr.GenerateCardIdentification();
        }

        protected override OpResult _Delete()
        {
            return mAccountant.SupplierMgr.Delete(mDataSource);
        }

        protected override OpResult _Record()
        {
            mDataSource.AssignFrom(mDataProxy);
            return mAccountant.SupplierMgr.Store(mDataSource);
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
