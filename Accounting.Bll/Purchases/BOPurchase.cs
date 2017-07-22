using System;
using System.Collections.Generic;

namespace Accounting.Bll.Purchases
{
    using Accounting.Core;
    using Accounting.Core.Cards;
    using Accounting.Core.Currencies;
    using Accounting.Core.Definitions;
    using Accounting.Core.Misc;
    using Accounting.Core.Purchases;
    using Accounting.Core.ShippingMethods;
    using Accounting.Core.TaxCodes;
    using Accounting.Core.Terms;
    using System.ComponentModel;

    public abstract class BOPurchase : BOTransaction
    {
        #region property_name
        public static string MEMO = "Memo";
        public static string COMMENT = "Comment";
        public static string PURCHASE_NUMBER = "PurchaseNumber";
        public static string PROMISED_DATE = "PromisedDate";
        public static string PURCHASE_DATE = "PurchaseDate";
        public static string INVOICE_DELIVERY = "InvoiceDelivery";
        public static string PURCHASE_STATUS = "PurchaseStatus";
        public static string OUTSTANDING_BALANCE= "OutstandingBalance";
        public static string TERMS = "Terms";
        public static string SHIP_TO_ADDRESS_LINE1 = "ShipToAddressLine1";
        public static string SHIP_TO_ADDRESS_LINE2 = "ShipToAddressLine2";
        public static string SHIP_TO_ADDRESS_LINE3 = "ShipToAddressLine3";
        public static string SHIP_TO_ADDRESS_LINE4 = "ShipToAddressLine4";
        public static string SHIP_TO_ADDRESS = "ShipToAddress";
        public static string SHIPPING_METHOD = "ShippingMethod";
        public static string SUPPLIER = "Supplier";
        public static string FREIGHT_TAXCODE = "FreightTaxCode";
        public static string SUPPLIER_INVOICE_NUMBER = "SupplierInvoiceNumber";
        public static string FREIGHT = "Freight";
        public static string TOTAL_TAX = "TotalTax";
        public static string IS_TAX_INCLUSIVE = "IsTaxInclusive";
        public static string PURCHASE_TYPE = "PurchaseType";
        public static string CURRENCY = "Currency";
        public static readonly string BALANCE_DUE = "BalanceDue";
        public static readonly string TOTAL_LINES = "TotalLines";
        public static readonly string TOTAL = "Total";
        public static readonly string SUPPLIER_ADDRESS = "SupplierAddress";
        public static readonly string PURCHASE_LINES = "PurchaseLines";
        #endregion

        protected Purchase mDataProxy;
        private Purchase mDataSource;
      
        private string mSupplierAddress = "Address 1";

        public bool IsItem
        {
            get
            {
                return mDataProxy.PurchaseType.IsItem;
            }
        }

        public bool IsService
        {
            get
            {
                return mDataProxy.PurchaseType.IsService;
            }
        }

        public bool IsMisc
        {
            get
            {
                return mDataProxy.PurchaseType.IsMisc;
            }
        }

        public bool IsProfessional
        {
            get
            {
                return mDataProxy.PurchaseType.IsProfessional;
            }
        }

        public bool IsTimeBilling
        {
            get
            {
                return mDataProxy.PurchaseType.IsTimeBilling;
            }
        }

        public bool IsOrder
        {
            get
            {
                return mDataProxy.PurchaseStatus.Type == Status.StatusType.Order;
            }
        }

        public bool IsQuote
        {
            get
            {
                return mDataProxy.PurchaseStatus.Type == Status.StatusType.Quote;
            }
        }

        public bool IsOpenBill
        {
            get
            {
                return mDataProxy.PurchaseStatus.Type == Status.StatusType.Open;
            }
        }

        BindingList<ItemPurchaseLine> mItemPurchaseLines = null;
        public BindingList<ItemPurchaseLine> ItemPurchaseLines 
        {
            get 
            {
                mItemPurchaseLines = new BindingList<ItemPurchaseLine>();
                foreach (ItemPurchaseLine _line in mDataProxy.PurchaseLines)
                {
                    mItemPurchaseLines.Add(_line);
                }
         
                return mItemPurchaseLines;
            }
        }

        BindingList<ProfessionalPurchaseLine> mProfessionalPurchaseLines = null;
        public BindingList<ProfessionalPurchaseLine> ProfessionalPurchaseLines
        {
            get
            {
                if (mProfessionalPurchaseLines == null)
                {
                    mProfessionalPurchaseLines = new BindingList<ProfessionalPurchaseLine>();
                    foreach (ProfessionalPurchaseLine _line in mDataProxy.PurchaseLines)
                    {
                        mProfessionalPurchaseLines.Add(_line);
                    }
                }
                return mProfessionalPurchaseLines;
            }
        }

        BindingList<ServicePurchaseLine> mServicePurchaseLines = null;
        public BindingList<ServicePurchaseLine> ServicePurchaseLines
        {
            get
            {
                mServicePurchaseLines = new BindingList<ServicePurchaseLine>();
                foreach (ServicePurchaseLine _line in mDataProxy.PurchaseLines)
                {
                    mServicePurchaseLines.Add(_line);
                }
         
                return mServicePurchaseLines;
            }
        }

        BindingList<TimeBillingPurchaseLine> mTimeBillingPurchaseLines = null;
        public BindingList<TimeBillingPurchaseLine> TimeBillingPurchaseLines
        {
            get
            {
                mTimeBillingPurchaseLines = new BindingList<TimeBillingPurchaseLine>();
                foreach (TimeBillingPurchaseLine _line in mDataProxy.PurchaseLines)
                {
                    mTimeBillingPurchaseLines.Add(_line);
                }
         
                return mTimeBillingPurchaseLines;
            }
        }

        BindingList<MiscPurchaseLine> mMiscPurchaseLines = null;
        public BindingList<MiscPurchaseLine> MiscPurchaseLines
        {
            get
            {
                mMiscPurchaseLines = new BindingList<MiscPurchaseLine>();
                foreach (MiscPurchaseLine _line in mDataProxy.PurchaseLines)
                {
                    mMiscPurchaseLines.Add(_line);
                }
         
                return mMiscPurchaseLines;
            }
        }

        public BOPurchase(Accountant accountant, Purchase _obj, BOContext _state)
            : base(accountant, _state)
        {
            mObjectID = BOType.BOPurchase;
            mDataSource = _obj;            
            mDataProxy = _obj.Clone() as Purchase;
            mDataProxy.PropertyChanged += new PropertyChangedEventHandler(mDataProxy_PropertyChanged);
            mDataProxy.Evaluate();
        }

        void mDataProxy_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged(e.PropertyName);
        }

        protected override void UpdateContent()
        {
            Purchase discovered = mDataSource.Discover() as Purchase;
            if (discovered != null)
            {
                mDataSource = discovered;
                mDataProxy = mDataSource.Clone() as Purchase;
                mDataProxy.Evaluate();
            }
        }

        public bool Memo_Validate(object value, ref string error)
        {
            if (value is string)
            {
                string _obj = value as string;
                if (IsWithinRange(_obj, 0, 255, out error))
                {
                    return true;
                }
                error = DecorateError(MEMO, error);
            }
            else
            {
                error = DecorateTypeMismatchError(MEMO, "string");
            }
            return false;
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
            else if (value is Comment)
            {
                mDataProxy.Comment = (value as Comment).ToString();
            }
        }

        public bool Comment_Validate(object value, ref string error)
        {
            if (value == null)
            {
                return true;
            }
            else if (value is string)
            {
                return true;
            }
            else if (value is Comment)
            {
                return true;
            }
            else
            {
                error = DecorateTypeMismatchError(COMMENT, "Comment or string");
            }
            return false;
        }

        public object PurchaseNumber_Get()
        {
            if (RecordContext == BusinessObject.BOContext.Record_Create)
            {
                return mAccountant.GeneratePurchaseNumber();
            }
            return mDataProxy.PurchaseNumber;
        }

        public void PurchaseNumber_Set(object value)
        {
            if (value is string)
            {
                mDataProxy.PurchaseNumber = value as string;
            }
            else
            {
                throw new Exception("PurchaseNumber must be of type string");
            }
        }

        public bool PurchaseNumber_Validate(object value, ref string error)
        {
            if (value is string)
            {
                if (IsAlphaNumeric(value as string, 1, 8, out error))
                {
                    if (this.RecordContext == BOContext.Record_Create)
                    {
                        if (mAccountant.PurchaseMgr.ExistsByPurchaseNumber(value as string))
                        {
                            error = DecorateEntityAlreadyExistError(PURCHASE_NUMBER, value as string);
                            return false;
                        }
                    }
                    return true;
                }
                error = DecorateError(PURCHASE_NUMBER, error);
            }
            else
            {
                error = DecorateTypeMismatchError(PURCHASE_NUMBER, "string");
            }
            return false;
        }

        public void PromisedDate_Set(object value)
        {
            if (value == null)
            {
                mDataProxy.PromisedDate = null;
            }
            else if (value is DateTime?)
            {
                mDataProxy.PromisedDate = (DateTime?)value;
            }
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
            else
            {
                error = DecorateTypeMismatchError(PROMISED_DATE, "DateTime?");
            }
            return false;
        }

        public void PurchaseDate_Set(object value)
        {
            if (value == null)
            {
                mDataProxy.PurchaseDate = null;
            }
            else if (value is DateTime?)
            {
                mDataProxy.PurchaseDate = (DateTime?)value;
            }
        }

        public bool PurchaseDate_Validate(object value, ref string error)
        {
            if (value == null)
            {
                return true;
            }
            else if (value is DateTime?)
            {
                return true;
            }
            error = DecorateTypeMismatchError(PURCHASE_DATE, "DateTime?");
            return false;
        }

        public void InvoiceDelivery_Set(object value)
        {
            if (value == null)
            {
                mDataProxy.InvoiceDelivery = null;
            }
            else if (value is InvoiceDelivery)
            {
                mDataProxy.InvoiceDelivery = value as InvoiceDelivery;
            }
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

        public bool PurchaseStatus_Validate(object value, ref string error)
        {
            if (value == null)
            {
                return true;
            }
            else if (value is Status)
            {
                return true;
            }
            error = DecorateTypeMismatchError(PURCHASE_STATUS, "Status");
            return false;
        }

        public void Terms_Set(object value)
        {
            if (value == null)
            {
                mDataProxy.Terms = null;
            }
            else if (value is Terms)
            {
                mDataProxy.Terms = value as Terms;
            }
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

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            AddProperty(MEMO,
                MEMO,
                delegate() { return mDataProxy.Memo; },
                delegate(object value) { mDataProxy.Memo = (string)value; },
                delegate() { return CanEdit; },
                delegate() { return true; },
                Memo_Validate);

            AddProperty(COMMENT,
                COMMENT,
                delegate() { return mDataProxy.Comment; },
                Comment_Set,
                delegate() { return CanEdit; },
                delegate() { return true; },
                Comment_Validate);

            AddProperty(PURCHASE_NUMBER,
                PURCHASE_NUMBER,
                PurchaseNumber_Get,
                PurchaseNumber_Set,
                delegate() { return CanEdit; },
                delegate() { return true; },
                PurchaseNumber_Validate);

            AddProperty(PROMISED_DATE,
                PROMISED_DATE,
                delegate() { return mDataProxy.PromisedDate; },
                PromisedDate_Set,
                delegate() { return CanEdit;},
                delegate() { return true; },
                PromisedDate_Validate);

            AddProperty(PURCHASE_DATE,
                PURCHASE_DATE,
                delegate() { return mDataProxy.PurchaseDate; },
                PurchaseDate_Set,
                delegate() { return CanEdit; },
                delegate() { return true; },
                PurchaseDate_Validate);

            AddProperty(INVOICE_DELIVERY,
                INVOICE_DELIVERY,
                delegate() { return mDataProxy.InvoiceDelivery; },
                InvoiceDelivery_Set,
                delegate() { return CanEdit; },
                delegate() { return true; },
                InvoiceDelivery_Validate);

            AddProperty(PURCHASE_STATUS,
                PURCHASE_STATUS,
                delegate() { return mDataProxy.PurchaseStatus; },
                delegate(object value) { },
                delegate() { return CanEdit; },
                delegate() { return true; },
                PurchaseStatus_Validate);

            AddProperty(OUTSTANDING_BALANCE,
                OUTSTANDING_BALANCE,
                delegate() { return mDataProxy.Currency.Format(mDataProxy.OutstandingBalance); },
                delegate(object value) { },
                delegate() { return true; },
                delegate() { return true; },
                delegate(object value, ref string error) { return true; });

            AddProperty(TERMS,
                TERMS,
                delegate() { return mDataProxy.Terms; },
                Terms_Set,
                delegate() { return CanEdit; },
                delegate() { return true; },
                Terms_Validate);

            AddProperty(SHIP_TO_ADDRESS_LINE1,
                SHIP_TO_ADDRESS_LINE1,
                delegate() {
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
                        string address = value as string;
                        if (IsWithinRange(address, 0, 255, out error))
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

            AddProperty(SHIP_TO_ADDRESS,
                SHIP_TO_ADDRESS,
                delegate()
                {
                    return mDataProxy.ShipToAddress;
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
                        string address = value as string;
                        if (IsWithinRange(address, 0, 255, out error))
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
                        string address = value as string;
                        if (IsWithinRange(address, 0, 255, out error))
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
                        string address = value as string;
                        if (IsWithinRange(address, 0, 255, out error))
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

            AddProperty(SUPPLIER,
                SUPPLIER,
                delegate()
                {
                    return mDataProxy.Supplier;
                },
                delegate(object value)
                {
                    if (value == null)
                    {
                        mDataProxy.Supplier = null;
                    }
                    else if (value is Supplier)
                    {
                        mDataProxy.Supplier = value as Supplier;
                    }
                },
                delegate()
                {
                    if (IsCreating)
                    {
                        return CanEdit;
                    }
                    else
                    {
                        return false;
                    }
                },
                delegate()
                {
                    return true;
                },
                delegate(object value, ref string error)
                {
                    if (value == null)
                    {
                        error = DecorateError(SUPPLIER, "cannot be empty");
                        return false;
                    }
                    else if (value is Supplier)
                    {
                        return true;
                    }
                    error = DecorateTypeMismatchError(SUPPLIER, "Supplier"); 
                    return false;
                });

            AddProperty(FREIGHT_TAXCODE,
                FREIGHT_TAXCODE,
                delegate()
                {
                    return mDataProxy.FreightTaxCode;
                },
                FreightTaxCode_Set,
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

            AddProperty(SUPPLIER_INVOICE_NUMBER,
                SUPPLIER_INVOICE_NUMBER,
                delegate()
                {
                    return mDataProxy.SupplierInvoiceNumber;
                },
                delegate(object value)
                {
                    mDataProxy.SupplierInvoiceNumber = (string)value;
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
                        if (IsAlphaNumeric(value as string, 0, 20, out error))
                        {
                            return true;
                        }
                        error = DecorateError(SUPPLIER_INVOICE_NUMBER, error);
                    }
                    else
                    {
                        error = DecorateTypeMismatchError(SUPPLIER_INVOICE_NUMBER, "string");
                    }
                    return false;
                });

            AddProperty(FREIGHT,
                FREIGHT,
                delegate() { return mDataProxy.Freight;},
                Freight_Set,
                delegate() { return CanEdit; },
                delegate() { return true; },
                Freight_Validate);

            AddProperty(TOTAL_TAX,
                TOTAL_TAX,
                delegate() { return mDataProxy.Currency.Format(mDataProxy.TotalTax); },
                delegate(object value) { },
                TotalTax_IsEnabled,
                delegate() { return true; },
                delegate(object value, ref string error) { return true; });

            AddProperty(IS_TAX_INCLUSIVE,
                IS_TAX_INCLUSIVE,
                delegate() { return mDataProxy.IsTaxInclusive.Equals("Y"); },
                IsTaxInclusive_Set,
                delegate() { return CanEdit; },
                delegate() { return true; },
                IsTaxInclusive_Validate);

            AddProperty(PURCHASE_TYPE,
                PURCHASE_TYPE,
                delegate()
                {
                    return mDataProxy.PurchaseType;
                },
                delegate(object value)
                {
                    mDataProxy.PurchaseType = value as InvoiceType;
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
                if (value == null)
                {
                    return true;
                }
                else if (value is InvoiceType)
                {
                    return true;
                }
                error = DecorateTypeMismatchError(PURCHASE_TYPE, "InvoiceType"); 
                return false;
            });

            AddProperty(CURRENCY,
                CURRENCY,
                delegate() { return mDataProxy.Currency; },
                delegate(object value) {
                    if (value == null)
                    {
                        mDataProxy.Currency = null;
                    }
                    else if (value is Currency)
                    {
                        mDataProxy.Currency = value as Currency;
                    }
                },
                delegate()
                {
                    return CanEdit;
                },
                delegate()
                {
                    return mAccountant.CurrencyMgr.SupportMultiCurrency;
                },
                delegate(object value, ref string error)
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
                });

            AddProperty(BALANCE_DUE,
                BALANCE_DUE,
                delegate()
                {
                    return mDataProxy.OutstandingBalance;
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

            AddProperty(TOTAL_LINES,
                TOTAL_LINES,
                delegate() { return mDataProxy.Currency.Format(mDataProxy.TotalLines); },
                delegate(object value) { },
                TotalLines_IsEnabled,
                delegate() { return true; },
                delegate(object value, ref string error) { return true; });

            AddProperty(TOTAL,
                TOTAL,
                delegate() { return mDataProxy.Currency.Format(mDataProxy.Total); },
                delegate(object value) { },
               Total_IsEnabled,
                delegate() { return true; },
                delegate(object value, ref string error) { return true; });

            AddProperty(SUPPLIER_ADDRESS,
                SUPPLIER_ADDRESS,
                delegate()
                {
                    return mSupplierAddress;
                },
                delegate(object value)
                {
                    mSupplierAddress = value as string;
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
                    error = DecorateTypeMismatchError(SUPPLIER_ADDRESS, "string"); 
                    return false;
                });
        }

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

        public bool Total_IsEnabled()
        { 
            return true; 
        }

        public bool TotalLines_IsEnabled() 
        { 
            return true; 
        }

        public bool TotalTax_IsEnabled() 
        {
            return mDataProxy.IsTaxInclusive != "Y";
        }

        public void Freight_Set(object value) 
        {
            double tax_rate=0;
            if(mDataProxy.FreightTaxCode != null)
            {
                tax_rate=mDataProxy.FreightTaxCode.TaxPercentageRate / 100.0;
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

        private bool Freight_Validate(object value, ref string error)
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
                error = DecorateTypeMismatchError(FREIGHT, "string");
            }
            return false;
        }

        public bool PurchaseFromDb
        {
            get { return mDataProxy.FromDb; }
        }

        protected override OpResult _Delete()
        {
            return mAccountant.PurchaseMgr.Delete(mDataSource);
        }

        public string GenerateJournalMemo(Supplier _obj)
        {
            if (_obj == null)
            {
                return "Purchase";
            }
            return string.Format("Purchase; {0}", _obj.Name);
        }

        public Purchase Data
        {
            get { return mDataProxy; }
        }

        protected override OpResult _Record()
        {
            mDataSource.AssignFrom(mDataProxy);
            return mAccountant.PurchaseMgr.Store(mDataSource);
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

        public bool IsTaxInclusive_Validate(object value, ref string error)
        {
            if (value is bool)
            {
                return true;
            }
            error = DecorateTypeMismatchError(IS_TAX_INCLUSIVE, "bool");
            return false;
        }

        public void IsTaxInclusive_Set(object value) 
        { 
            mDataProxy.IsTaxInclusive = (bool)value ? "Y" : "N";
            mDataProxy.Evaluate();
        }
    }
}
