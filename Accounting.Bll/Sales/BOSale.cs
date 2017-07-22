using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Sales
{
    using System.ComponentModel;
    using Accounting.Core;
    using Accounting.Core.Sales;
    using Accounting.Core.Cards;
    using Accounting.Core.Misc;
    using Accounting.Core.Definitions;
    using Accounting.Core.Terms;
    using Accounting.Core.ShippingMethods;
    using Accounting.Core.TaxCodes;
    using Accounting.Core.Currencies;
    using Accounting.Bll.Sales.SaleLines;

    public abstract class BOSale : BOTransaction
    {
        #region property_name
        public static string DESTINATION_COUNTRY = "DestinationCountry";
        public static string MEMO = "Memo";
        public static string COMMENT = "Comment";
        public static string INVOICE_NUMBER = "InvoiceNumber";
        public static string PROMISED_DATE = "PromisedDate";
        public static string INVOICE_DATE = "InvoiceDate";
        public static string INVOICE_DELIVERY = "InvoiceDelivery";
        public static string INVOICE_STATUS = "InvoiceStatus";
        public static string OUTSTANDING_BALANCE = "OutstandingBalance";
        public static string TERMS = "Terms";
        public static string SHIP_TO_ADDRESS = "ShipToAddress";
        public static string SHIP_TO_ADDRESS_LINE1 = "ShipToAddressLine1";
        public static string SHIP_TO_ADDRESS_LINE2 = "ShipToAddressLine2";
        public static string SHIP_TO_ADDRESS_LINE3 = "ShipToAddressLine3";
        public static string SHIP_TO_ADDRESS_LINE4 = "ShipToAddressLine4";
        public static string INVOICE_TYPE = "InvoiceType";
        public static string TOTAL_TAX = "TotalTax";
        public static string SHIPPING_METHOD = "ShippingMethod";
        public static string CUSTOMER = "Customer";
        public static string FREIGHT_TAXCODE = "FreightTaxCode";
        public static string CUSTOMER_PO_NUMBER = "CustomerPONumber";
        public static string FREIGHT = "Freight";
        public static string IS_TAX_INCLUSIVE = "IsTaxInclusive";
        public static string SALES_PERSON = "SalesPerson";
        public static string TOTAL = "Total";
        public static string CURRENCY = "Currency";
        public static string BALANCE_DUE = "BalanceDue";
        public static string TOTAL_LINES = "TotalLines";
        public static string CUSTOMER_PHONE1 = "CustomerPhone1";
        public static string CUSTOMER_PHONE2 = "CustomerPhone2";
        public static string CUSTOMER_EMAIL = "CustomerEmail";
        public static string CUSTOMER_ADDRESS = "CustomerAddress";
        #endregion

        protected Sale mDataProxy;
        protected Sale mDataSource;
        private string mCustomerAddress="Address 1";

        public Sale Data
        {
            get { return mDataProxy; }
        }

        public bool IsItem
        {
            get
            {
                return mDataProxy.InvoiceType.IsItem;
            }
        }

        public bool IsService
        {
            get
            {
                return mDataProxy.InvoiceType.IsService;
            }
        }

        public bool IsMisc
        {
            get
            {
                return mDataProxy.InvoiceType.IsMisc;
            }
        }

        public bool IsProfessional
        {
            get
            {
                return mDataProxy.InvoiceType.IsProfessional;
            }
        }

        public bool IsTimeBilling
        {
            get
            {
                return mDataProxy.InvoiceType.IsTimeBilling;
            }
        }

        public bool IsOrder
        {
            get
            {
                return mDataProxy.InvoiceStatus.Type == Status.StatusType.Order;
            }
        }

        public bool IsQuote
        {
            get
            {
                return mDataProxy.InvoiceStatus.Type == Status.StatusType.Quote;
            }
        }

        public bool IsOpenInvoice
        {
            get
            {
                return mDataProxy.InvoiceStatus.Type == Status.StatusType.Open;
            }
        }

        BindingList<ItemSaleLine> mItemSaleLines = null;
        public BindingList<ItemSaleLine> ItemSaleLines
        {
            get
            {
                mItemSaleLines = new BindingList<ItemSaleLine>();
                foreach (ItemSaleLine _line in mDataProxy.SaleLines)
                {
                    mItemSaleLines.Add(_line);
                }

                return mItemSaleLines;
            }
        }

        BindingList<ProfessionalSaleLine> mProfessionalSaleLines = null;
        public BindingList<ProfessionalSaleLine> ProfessionalSaleLines
        {
            get
            {
                if (mProfessionalSaleLines == null)
                {
                    mProfessionalSaleLines = new BindingList<ProfessionalSaleLine>();
                    foreach (ProfessionalSaleLine _line in mDataProxy.SaleLines)
                    {
                        mProfessionalSaleLines.Add(_line);
                    }
                }
                return mProfessionalSaleLines;
            }
        }

        BindingList<ServiceSaleLine> mServiceSaleLines = null;
        public BindingList<ServiceSaleLine> ServiceSaleLines
        {
            get
            {
                mServiceSaleLines = new BindingList<ServiceSaleLine>();
                foreach (ServiceSaleLine _line in mDataProxy.SaleLines)
                {
                    mServiceSaleLines.Add(_line);
                }

                return mServiceSaleLines;
            }
        }

        BindingList<TimeBillingSaleLine> mTimeBillingSaleLines = null;
        public BindingList<TimeBillingSaleLine> TimeBillingSaleLines
        {
            get
            {
                mTimeBillingSaleLines = new BindingList<TimeBillingSaleLine>();
                foreach (TimeBillingSaleLine _line in mDataProxy.SaleLines)
                {
                    mTimeBillingSaleLines.Add(_line);
                }

                return mTimeBillingSaleLines;
            }
        }

        BindingList<MiscSaleLine> mMiscSaleLines = null;
        public BindingList<MiscSaleLine> MiscSaleLines
        {
            get
            {
                mMiscSaleLines = new BindingList<MiscSaleLine>();
                foreach (MiscSaleLine _line in mDataProxy.SaleLines)
                {
                    mMiscSaleLines.Add(_line);
                }

                return mMiscSaleLines;
            }
        }
        
        public BOSale(Accountant accountant, Sale _obj, BOContext _state)
            : base(accountant, _state)
        {
            mObjectID = BOType.BOSale;
            mDataSource = _obj;
            mDataProxy = _obj.Clone() as Sale;
            mDataProxy.PropertyChanged += new PropertyChangedEventHandler(mDataProxy_PropertyChanged);
            mDataProxy.Evaluate();
        }

        void mDataProxy_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged(e.PropertyName);
        }

        protected override void UpdateContent()
        {
            Sale discovered = mDataSource.Discover() as Sale;
            if (discovered != null)
            {
                mDataSource = discovered;
                mDataProxy = mDataSource.Clone() as Sale;
                mDataProxy.Evaluate();
            }
        }

        protected override OpResult _Record()
        {
            mDataSource.AssignFrom(mDataProxy);
            return mAccountant.SaleMgr.Store(mDataSource);
        }

        public bool DestinationCountry_Validate(object value, ref string error)
        {
            if (value is string)
            {
                return true;
            }
            error = DecorateTypeMismatchError(DESTINATION_COUNTRY, "string");
            return false;
        }

        public bool Memo_Validate(object value, ref string error)
        {
            if (value is string)
            {
                string _obj = value as string;
                if (IsWithinRange(MEMO, 0, 255, out error))
                {
                    return true;
                }
                error = DecorateError(MEMO, error);
            }
            else
            {
                error = DecorateTypeMismatchError(MEMO, "string");
            }
            return true;
        }

        #region Comment
        public object Comment_Get()
        {
            return mDataProxy.Comment;
        }
        public void Comment_Set(object value)
        {
            if (value == null)
            {
                mDataProxy.Comment = "";
            }
            else if (value is string)
            {
                mDataProxy.Comment = (string)value;
            }
            else
            {
                mDataProxy.Comment = (value as Comment).ToString();
            }
        }
        public bool Comment_IsEnabled()
        {
            return CanEdit;
        }
        public bool Comment_IsVisible()
        {
            return true;
        }
        public bool Comment_Validate(object value, ref string error)
        {
            return true;
        }
        #endregion

        #region InvoiceNumber
        public object InvoiceNumber_Get()
        {
            if (this.RecordContext == BusinessObject.BOContext.Record_Create)
            {
                return mAccountant.GenerateInvoiceNumber();
            }
            return mDataProxy.InvoiceNumber;
        }
        public bool InvoiceNumber_Validate(object value, ref string error)
        {
            if (value is string)
            {
                if (IsAlphaNumeric(value as string, 1, 8, out error))
                {
                    if (this.RecordContext == BOContext.Record_Create)
                    {
                        if (mAccountant.SaleMgr.ExistsByInvoiceNumber(value as string))
                        {
                            error = DecorateEntityAlreadyExistError(INVOICE_NUMBER, value as string);
                            return false;
                        }
                    }
                    return true;
                }
                error = DecorateError(INVOICE_NUMBER, error);
                return false;
            }
            else
            {
                error = DecorateTypeMismatchError(INVOICE_NUMBER, "string");
                return false;
            }
        }
        public bool InvoiceNumber_IsVisible()
        {
            return true;
        }
        public void InvoiceNumber_Set(object value)
        {
            mDataProxy.InvoiceNumber = (string)value;
        }
        public bool InvoiceNumber_IsEnabled()
        {
            return CanEdit;
        }
        #endregion

        #region FreightTaxCode
        public void FreightTaxCode_Set(object value)
        {
            if (value == null)
            {
                mDataProxy.FreightTaxCode = null;
            }
            else if (value is TaxCode)
            {
                mDataProxy.FreightTaxCode = value as TaxCode;
            }

            double tax_rate = 0;
            if (mDataProxy.FreightTaxCode != null)
            {
                tax_rate = mDataProxy.FreightTaxCode.TaxPercentageRate / 100.0;
            }
            mDataProxy.TaxInclusiveFreight = mDataProxy.TaxExclusiveFreight * (1 + tax_rate);
            mDataProxy.Evaluate();
        }
        public object FreightTaxCode_Get()
        {
            return mDataProxy.FreightTaxCode;
        }
        public bool FreightTaxCode_Validate(object value, ref string error)
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
        }
        public bool FreightTaxCode_IsVisible()
        {
            return true;
        }
        public bool FreightTaxCode_IsEnabled()
        {
            return CanEdit;
        }
        #endregion

        #region Total
        public object Total_Get()
        {
            return mDataProxy.Currency.Format(mDataProxy.Total);
        }
        public void Total_Set(object value) { }
        public bool Total_IsEnabled()
        {
            return CanEdit;
        }
        public bool Total_IsVisible()
        {
            return true;
        }
        public bool Total_Validate(object value, ref string error)
        {
            return true;
        }
        #endregion

        #region Customer
        public object Customer_Get() {
            return mDataProxy.Customer;
        }
        public void Customer_Set(object value)
        {
            mDataProxy.Customer = value as Customer;
        }
        public bool Customer_Validate(object value, ref string error)
        {
            if (value == null)
            {
                error = DecorateError(CUSTOMER, "cannot be empty");
                return false;
            }
            else if (value is Customer)
            {
                return true;
            }
            error = DecorateTypeMismatchError(CUSTOMER, "Customer");
            return false;
        }
        public bool Customer_IsEnabled()
        {
            return CanEdit;
        }
        public bool Customer_IsVisible()
        {
            return true;
        }
        #endregion

        #region PromisedDate
        public void PromisedDate_Set(object value)
        {
            if (value == null)
            {
                mDataProxy.PromisedDate = null;
            }
            else
            {
                mDataProxy.PromisedDate = (DateTime?)value;
            }
        }
        public bool PromisedDate_IsEnabled()
        {
            return CanEdit;
        }
        public object PromisedDate_Get()
        {
            return mDataProxy.PromisedDate;
        }
        public bool PromisedDate_IsVisible()
        {
            return true;
        }
        public bool PromisedDate_Validate(object value, ref string error)
        {
            if (value == null)
            {
                return true;
            }
            else if (value is DateTime?)
            {
                return true;
            }

            error = DecorateTypeMismatchError(PROMISED_DATE, "DateTime?");
            return false;
        }
        #endregion

        #region InvoiceDate
        public bool InvoiceDate_Validate(object value, ref string error)
        {
            if (value == null)
            {
                return true;
            }
            else if (value is DateTime?)
            {
                return true;
            }

            error = DecorateTypeMismatchError(INVOICE_DATE, "DateTime?");
            return false;
        }
        public bool InvoiceDate_IsVisible()
        {
            return true;
        }
        public void InvoiceDate_Set(object value)
        {
            if (value == null)
            {
                mDataProxy.InvoiceDate = null;
            }
            else
            {
                mDataProxy.InvoiceDate = (DateTime?)value;
            }
        }
        public object InvoiceDate_Get()
        {
            return mDataProxy.InvoiceDate;
        }
        public bool InvoiceDate_IsEnabled()
        {
            return CanEdit;
        }
        #endregion

        #region InvoiceDelivery
        public object InvoiceDelivery_Get()
        {
            return mDataProxy.InvoiceDelivery;
        }
        public void InvoiceDelivery_Set(object value)
        {
            if (value == null)
            {
                mDataProxy.InvoiceDelivery = null;
            }
            else
            {
                mDataProxy.InvoiceDelivery = value as InvoiceDelivery;
            }
        }
        public bool InvoiceDelivery_IsEnabled()
        {
            return CanEdit;
        }
        public bool InvoiceDelivery_IsVisible()
        {
            return true;
        }
        public bool InvoiceDelivery_Validate(object value, ref string error)
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
        }
        #endregion

        #region InvoiceStatus
        public object InvoiceStatus_Get()
        {
            return mDataProxy.InvoiceStatus;
        }
        public void InvoiceStatus_Set(object value)
        {
            if (value == null)
            {
                mDataProxy.InvoiceStatus = null;
            }
            else if (value is Status)
            {
                mDataProxy.InvoiceStatus = value as Status;
            }
            else
            {
                throw new Exception(string.Format("[{0}] must be of type Status", INVOICE_STATUS));
            }
        }
        public bool InvoiceStatus_IsEnabled()
        {
            return CanEdit;
        }
        public bool InvoiceStatus_IsVisible()
        {
            return true;
        }
        public bool InvoiceStatus_Validate(object value, ref string error)
        {
            if (value == null)
            {
                return true;
            }
            else if (value is Status)
            {
                return true;
            }

            error = DecorateTypeMismatchError(INVOICE_STATUS, "Status");
            return false;
        }
        #endregion

        #region Terms
        public object Terms_Get()
        {
            return mDataProxy.Terms;
        }
        public void Terms_Set(object value)
        {
            if (value == null)
            {
                mDataProxy.Terms = null;
            }
            else
            {
                mDataProxy.Terms = value as Terms;
            }
        }
        public bool Terms_IsEnabled()
        {
            return CanEdit;
        }
        public bool Terms_IsVisible()
        {
            return true;
        }
        public bool Terms_Validate(object value, ref string error)
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
        }
        #endregion

        #region ShipToAddress
        public object ShipToAddress_Get()
        {
            return mDataProxy.ShipToAddress;
        }
        public void ShipToAddress_Set(object value)
        {

        }
        public bool ShipToAddress_IsEnabled()
        {
            return false;
        }
        public bool ShipToAddress_IsVisible()
        {
            return true;
        }
        public bool ShipToAddress_Validate(object value, ref string error)
        {
            return true;
        }
        #endregion

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            AddProperty(DESTINATION_COUNTRY,
                DESTINATION_COUNTRY,
                delegate() { return mDataProxy.DestinationCountry; },
                delegate(object value) { mDataProxy.DestinationCountry = (string)value; },
                delegate() { return CanEdit; },
                delegate() { return true; },
                DestinationCountry_Validate);

            AddProperty(MEMO,
                MEMO,
                delegate() { return mDataProxy.Memo; },
                delegate(object value) { mDataProxy.Memo = (string)value; },
                delegate() { return CanEdit; },
                delegate() { return true; },
                Memo_Validate);

            AddProperty(COMMENT,
                COMMENT,
                Comment_Get,
                Comment_Set,
                Comment_IsEnabled,
                Comment_IsVisible,
                Comment_Validate);

            AddProperty(INVOICE_NUMBER,
                INVOICE_NUMBER,
                InvoiceNumber_Get,
                InvoiceNumber_Set,
                InvoiceNumber_IsEnabled,
                InvoiceNumber_IsVisible,
                InvoiceNumber_Validate);

            AddProperty(PROMISED_DATE,
                PROMISED_DATE,
                PromisedDate_Get,
                PromisedDate_Set,
                PromisedDate_IsEnabled,
                PromisedDate_IsVisible,
                PromisedDate_Validate);

            AddProperty(INVOICE_DATE,
                INVOICE_DATE,
                InvoiceDate_Get,
                InvoiceDate_Set,
                InvoiceDate_IsEnabled,
                InvoiceDate_IsVisible,
                InvoiceDate_Validate);

            AddProperty(INVOICE_DELIVERY,
                INVOICE_DELIVERY,
                InvoiceDelivery_Get,
                InvoiceDelivery_Set,
                InvoiceDelivery_IsEnabled,
                InvoiceDelivery_IsVisible,
                InvoiceDelivery_Validate);

            AddProperty(INVOICE_STATUS,
                INVOICE_STATUS,
                InvoiceStatus_Get,
                InvoiceStatus_Set,
                InvoiceStatus_IsEnabled,
                InvoiceStatus_IsVisible,
                InvoiceStatus_Validate);

            AddProperty(TERMS,
                TERMS,
                Terms_Get,
                Terms_Set,
                Terms_IsEnabled,
                Terms_IsVisible,
                Terms_Validate);

            AddProperty(SHIP_TO_ADDRESS,
                SHIP_TO_ADDRESS,
                ShipToAddress_Get,
                ShipToAddress_Set,
                ShipToAddress_IsEnabled,
                ShipToAddress_IsVisible,
                ShipToAddress_Validate);

            AddProperty(SHIP_TO_ADDRESS_LINE1,
                SHIP_TO_ADDRESS_LINE1,
                delegate()
                {
                    return mDataProxy.ShipToAddressLine1;
                },
                delegate(object value)
                {
                    mDataProxy.ShipToAddressLine1 = (string)value;
                    mDataProxy.ShipToAddress = (string)value;
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
                        string _obj = value as string;
                        if (IsWithinRange(SHIP_TO_ADDRESS_LINE1, 0, 255, out error))
                        {
                            return true;
                        }
                        error = DecorateError(SHIP_TO_ADDRESS_LINE1, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(SHIP_TO_ADDRESS_LINE1, "string");
                    }
                    return false;
                });

            AddProperty(SHIP_TO_ADDRESS_LINE2,
                SHIP_TO_ADDRESS_LINE2,
                delegate()
                {
                    return mDataProxy.ShipToAddressLine2;
                },
                delegate(object value)
                {
                    mDataProxy.ShipToAddressLine2 = (string)value;
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
                        string _obj = value as string;
                        if (IsWithinRange(_obj, 0, 255, out error))
                        {
                            return true;
                        }
                        error = DecorateError(SHIP_TO_ADDRESS_LINE2, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(SHIP_TO_ADDRESS_LINE2, "string");
                    }
                    return false;
                });

            AddProperty(SHIP_TO_ADDRESS_LINE3,
                SHIP_TO_ADDRESS_LINE3,
                delegate()
                {
                    return mDataProxy.ShipToAddressLine3;
                },
                delegate(object value)
                {
                    mDataProxy.ShipToAddressLine3 = (string)value;  
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
                        string _obj = value as string;
                        if (IsWithinRange(SHIP_TO_ADDRESS_LINE3, 0, 255, out error))
                        {
                            return true;
                        }
                        error = DecorateError(SHIP_TO_ADDRESS_LINE3, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(SHIP_TO_ADDRESS_LINE3, "string");
                    }
                    return false;
                });

            AddProperty(SHIP_TO_ADDRESS_LINE4,
                SHIP_TO_ADDRESS_LINE4,
                delegate()
                {
                    return mDataProxy.ShipToAddressLine4;
                },
                delegate(object value)
                {
                    mDataProxy.ShipToAddressLine4 = (string)value; 
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
                        string _obj = value as string;
                        if (IsWithinRange(_obj, 0, 255, out error))
                        {
                            return true;
                        }
                        error = DecorateError(SHIP_TO_ADDRESS_LINE4, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(SHIP_TO_ADDRESS_LINE4, "string");
                    }
                    return false;
                });

            AddProperty(INVOICE_TYPE,
                INVOICE_TYPE,
                delegate()
                {
                    return mDataProxy.InvoiceType;
                },
                delegate(object value)
                {
                    mDataProxy.InvoiceType = value as InvoiceType;
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
                    else if(value is InvoiceType)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(INVOICE_TYPE, "InvoiceType");
                    return false;
                });

            AddProperty(TOTAL_TAX,
                TOTAL_TAX,
                TotalTax_Get,
                TotalTax_Set,
                TotalTax_IsEnabled,
                TotalTax_IsVisible,
                TotalTax_Validate);

            AddProperty(SHIPPING_METHOD,
                SHIPPING_METHOD,
                ShippingMethod_Get,
                ShippingMethod_Set,
                ShippingMethod_IsEnabled,
                ShippingMethod_IsVisible,
                ShippingMethod_Validate);

            AddProperty(CUSTOMER,
                CUSTOMER,
                Customer_Get,
                Customer_Set,
                Customer_IsEnabled,
                Customer_IsVisible,
                Customer_Validate);

            AddProperty(FREIGHT_TAXCODE,
                FREIGHT_TAXCODE,
                FreightTaxCode_Get,
                FreightTaxCode_Set,
                FreightTaxCode_IsEnabled,
                FreightTaxCode_IsVisible,
                FreightTaxCode_Validate);

            AddProperty(CUSTOMER_PO_NUMBER,
                CUSTOMER_PO_NUMBER,
                CustomerPONumber_Get,
                CustomerPONumber_Set,
                CustomerPONumber_IsEnabled,
                CustomerPONumber_IsVisible,
                CustomerPONumber_Validate);

            AddProperty(FREIGHT,
                FREIGHT,
                Freight_Get,
                Freight_Set,
                Freight_IsEnabled,
                Freight_IsVisible,
                Freight_Validate);

            AddProperty(IS_TAX_INCLUSIVE,
                IS_TAX_INCLUSIVE,
                IsTaxInclusive_Get,
                IsTaxInclusive_Set,
                IsTaxInclusive_IsEnabled,
                IsTaxInclusive_IsVisible,
                IsTaxInclusive_Validate);

            AddProperty(SALES_PERSON,
                SALES_PERSON,
                SalesPerson_Get,
                SalesPerson_Set,
                SalesPerson_IsEnabled,
                SalesPerson_IsVisible,
                SalesPerson_Validate);

            AddProperty(TOTAL,
                TOTAL,
                Total_Get,
                Total_Set,
                Total_IsEnabled,
                Total_IsVisible,
                Total_Validate);

            AddProperty(CURRENCY,
                CURRENCY,
                Currency_Get,
                Currency_Set,
                Currency_IsEnabled,
                Currency_IsVisible,
                Currency_Validate);

            AddProperty(BALANCE_DUE,
                BALANCE_DUE,
                BalanceDue_Get,
                BalanceDue_Set,
                BalanceDue_IsEnabled,
                BalanceDue_IsVisible,
                BalanceDue_Validate);

            AddProperty(TOTAL_LINES,
                TOTAL_LINES,
                TotalLines_Get,
                TotalLines_Set,
                TotalLines_IsEnabled,
                TotalLines_IsVisible,
                TotalLines_Validate);

            #region CUSTOMER_PHONE1
            AddProperty(CUSTOMER_PHONE1,
                CUSTOMER_PHONE1,
                delegate()
                {
                    if (mDataProxy.Customer != null)
                    {
                        return mDataProxy.Customer.Address1.Phone1;
                    }
                    else
                    {
                        return "";
                    }
                },
                delegate(object value)
                {

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
                    return true;
                });
            #endregion

            #region CUSTOMER_PHONE2
            AddProperty(CUSTOMER_PHONE2,
                CUSTOMER_PHONE1,
                delegate()
                {
                    if (mDataProxy.Customer != null)
                    {
                        return mDataProxy.Customer.Address1.Phone2;
                    }
                    else
                    {
                        return "";
                    }
                },
                delegate(object value)
                {

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
                    return true;
                });
            #endregion

            #region CUSTOMER_EMAIL
            AddProperty(CUSTOMER_EMAIL,
                CUSTOMER_EMAIL,
                delegate()
                {
                    if (mDataProxy.Customer != null)
                    {
                        return mDataProxy.Customer.Address1.Email;
                    }
                    else
                    {
                        return "";
                    }
                },
                delegate(object value)
                {

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
                    return true;
                });
            #endregion

            #region CUSTOMER_ADDRESS
            AddProperty(CUSTOMER_ADDRESS,
                CUSTOMER_ADDRESS,
                delegate()
                {
                    return mCustomerAddress;
                },
                delegate(object value)
                {
                    mCustomerAddress = value as string;
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
                        return true;
                    }
                    error = DecorateTypeMismatchError(CUSTOMER_ADDRESS, "string");
                    return false;
                });
            #endregion 
        }

        #region ShippingMethod
        public object ShippingMethod_Get()
        {
            return mDataProxy.ShippingMethod;
        }
        public void ShippingMethod_Set(object value)
        {
            if (value == null)
            {
                mDataProxy.ShippingMethod = null;
            }
            else
            {
                mDataProxy.ShippingMethod = value as ShippingMethod;
            }
        }
        public bool ShippingMethod_IsEnabled()
        {
            return CanEdit;
        }
        public bool ShippingMethod_Validate(object value, ref string error)
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
        }
        public bool ShippingMethod_IsVisible()
        {
            return true;
        }
        #endregion

        #region CustomerPONumber
        public bool CustomerPONumber_Validate(object value, ref string error)
        {
            if (value is string)
            {
                string _obj = value as string;
                if (IsWithinRange(_obj, 0, 20, out error))
                {
                    return true;
                }
                error = DecorateError(CUSTOMER_PO_NUMBER, error);
            }
            else
            {
                error = DecorateTypeMismatchError(CUSTOMER_PO_NUMBER, "string");
            }
            return false;
        }
        public object CustomerPONumber_Get()
        {
            return mDataProxy.CustomerPONumber;
        }
        public void CustomerPONumber_Set(object value)
        {
            mDataProxy.CustomerPONumber = value as string;
        }
        public bool CustomerPONumber_IsEnabled()
        {
            return CanEdit;
        }
        public bool CustomerPONumber_IsVisible()
        {
            return true;
        }
        #endregion

        #region SalesPerson
        public object SalesPerson_Get()
        {
            return mDataProxy.SalesPerson;
        }
        public void SalesPerson_Set(object value)
        {
            if (value == null)
            {
                mDataProxy.SalesPerson = null;
            }
            else if (value is Employee)
            {
                mDataProxy.SalesPerson = value as Employee;
            }
            else
            {
                throw new Exception("SalesPerson must be of type Employee");
            }
        }
        public bool SalesPerson_IsEnabled()
        {
            return CanEdit;
        }
        public bool SalesPerson_IsVisible() { return true; }
        public bool SalesPerson_Validate(object value, ref string error)
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
        }
        #endregion

        #region Freight
        public void Freight_Set(object value)
        {
            double tax_rate = 0;
            if (mDataProxy.FreightTaxCode != null)
            {
                tax_rate = mDataProxy.FreightTaxCode.TaxPercentageRate / 100.0;
            }
            if (mDataProxy.IsTaxInclusive == "Y")
            {
                mDataProxy.TaxInclusiveFreight = double.Parse(value as string);
                mDataProxy.TaxExclusiveFreight = mDataProxy.TaxInclusiveFreight / (1 + tax_rate);
            }
            else
            {
                mDataProxy.TaxExclusiveFreight = double.Parse(value as string);
                mDataProxy.TaxInclusiveFreight = mDataProxy.TaxExclusiveFreight * (1 + tax_rate);
            }
            mDataProxy.Evaluate();
        }
        public object Freight_Get()
        {
            return mDataProxy.Freight;
        }
        public bool Freight_IsEnabled()
        {
            return CanEdit;
        }
        public bool Freight_IsVisible()
        {
            return true;
        }
        public bool Freight_Validate(object value, ref string error)
        {
            if (value is string)
            {
                if (IsNumeric(value as string, 13, 2, out error))
                {
                    return true;
                }
                error = DecorateError(FREIGHT, error);
            }
            else
            {
                error = DecorateInputTypeMismatchError(FREIGHT, "string");
            }
            return false;
        }
        #endregion

        #region IsTaxInclusive
        public object IsTaxInclusive_Get()
        {
            return mDataProxy.IsTaxInclusive.Equals("Y");
        }
        public void IsTaxInclusive_Set(object value)
        {
            mDataProxy.IsTaxInclusive = (bool)value ? "Y" : "N";
            mDataProxy.Evaluate();
        }
        public bool IsTaxInclusive_IsEnabled()
        {
            return CanEdit;
        }
        public bool IsTaxInclusive_IsVisible()
        {
            return true;
        }
        public bool IsTaxInclusive_Validate(object value, ref string error)
        {
            if (value is bool)
            {
                return true;
            }
            error = DecorateTypeMismatchError(IS_TAX_INCLUSIVE, "bool");
            return false;
        }
        #endregion

        #region BalanceDue
        public bool BalanceDue_Validate(object value, ref string error) {  return true; }
        public bool BalanceDue_IsVisible()
        {
            return true;
        }
        public object BalanceDue_Get()
        {
            return mDataProxy.Currency.Format(mDataProxy.OutstandingBalance);
        }
        public void BalanceDue_Set(object value)
        {
        }
        public bool BalanceDue_IsEnabled() { return CanEdit;}
        #endregion

        #region Currency
        public void Currency_Set(object value)
        {
            if (value == null)
            {
                mDataProxy.Currency = null;
            }
            else
            {
                mDataProxy.Currency = value as Currency;
            }
        }
        public object Currency_Get()
        {
            return mDataProxy.Currency;
        }
        public bool Currency_IsEnabled()
        {
            return CanEdit;
        }
        public bool Currency_IsVisible()
        {
            return mAccountant.CurrencyMgr.SupportMultiCurrency;
        }
        public bool Currency_Validate(object value, ref string error)
        {
            if (value == null)
            {
                return true;
            }
            else if (value is Currency)
            {
                return true;
            }

            error = DecorateTypeMismatchError(CURRENCY, "Currency");
            return false;
        }
        #endregion

        #region TotalLines
        public object TotalLines_Get()
        {
            return mDataProxy.Currency.Format(mDataProxy.TotalLines);
        }
        public void TotalLines_Set(object value) { }
        public bool TotalLines_IsEnabled()
        {
            return CanEdit;
        }
        public bool TotalLines_IsVisible()
        {
            return true;
        }
        public bool TotalLines_Validate(object value, ref string error)
        {
            return true;
        }
        #endregion

        #region TotalTax
        public object TotalTax_Get()
        {
            return mDataProxy.Currency.Format(mDataProxy.TotalTax);
        }
        public void TotalTax_Set(object value)
        {
        }
        public bool TotalTax_IsEnabled()
        {
            return mDataProxy.IsTaxInclusive!="Y";
        }
        public bool TotalTax_IsVisible()
        {
            return true;
        }
        public bool TotalTax_Validate(object value, ref string error)
        {
            return true;
        }
        #endregion

        protected override OpResult _Delete()
        {
            return mAccountant.SaleMgr.Delete(mDataSource);
        }

        public string GenerateJournalMemo(Customer _obj)
        {
            if (_obj == null)
            {
                return "Sale";
            }
            return string.Format("Sale; {0}", _obj.Name);
        }

        public override bool CanEdit
        {
            get
            {
                if (this.RecordContext == BOContext.Record_Create)
                {
                    return mDataProxy.AllowCreate;
                }
                else if (this.RecordContext == BOContext.Record_Update)
                {
                    return mDataProxy.AllowUpdate;
                }
                return false;
            }
        }

        public override bool CanDelete
        {
            get
            {
                return mDataProxy.AllowDelete;
            }
        }
    }
}
