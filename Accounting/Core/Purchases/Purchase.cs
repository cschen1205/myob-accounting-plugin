using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Purchases
{
    using Accounting.Core.Cards;
    using Accounting.Core.Definitions;
    using Accounting.Core.Inventory;
    using System.ComponentModel;

    public class Purchase : Entity, JournalRecords.JournalSource
    {
        #region -(Constructor)
        internal Purchase(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        #region -(GetSourceID)
        public int? GetSourceID()
        {
            return mPurchaseID;
        }
        #endregion

        #region -(GetTransactionDate)
        public Nullable<DateTime> GetTransactionDate()
        {
            return PurchaseDate;
        }
        #endregion

        internal bool Match(DateTime? start, DateTime? end, Supplier supplier, Status purchaseStatus)
        {
            if (purchaseStatus != null)
            {
                if (!purchaseStatus.Equals(PurchaseStatus))
                {
                    return false;
                }
            }
            if (PurchaseDate != null)
            {
                if (start != null)
                {
                    if (PurchaseDate.Value < start.Value)
                    {
                        return false;
                    }
                }
                if (end != null)
                {
                    if (PurchaseDate.Value > end.Value)
                    {
                        return false;
                    }
                }
            }

            if (supplier != null)
            {
                if (!supplier.Equals(Supplier))
                {
                    return false;
                }
            }

            return true;

        }

        internal bool IsPurchasingItem(Item _item)
        {
            if (IsItemPurchase)
            {
                if (_item == null) return true;
                foreach (ItemPurchaseLine _line in PurchaseLines)
                {
                    if (_line.Item == _item)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

        


        public bool IsItemPurchase
        {
            get
            {
                if (PurchaseType != null)
                {
                    return PurchaseType.IsItem;
                }
                return false;
            }
        }

        public bool IsMiscPurchase
        {
            get
            {
                if (PurchaseType != null)
                {
                    return PurchaseType.IsMisc;
                }
                return false;
            }
        }

        public bool IsProfessionalPurchase
        {
            get
            {
                if (PurchaseType != null)
                {
                    return PurchaseType.IsProfessional;
                }
                return false;
            }
        }

        public bool IsServicePurchase
        {
            get
            {
                if (PurchaseType != null)
                {
                    return PurchaseType.IsService;
                }
                return false;
            }
        }

        public bool IsTimeBillingPurchase
        {
            get
            {
                if (PurchaseType != null)
                {
                    return PurchaseType.IsTimeBilling;
                }
                return false;
            }
        }

        #region PreAuditTrail
        private string mPreAuditTrail;
        public string PreAuditTrail
        {
            get { return mPreAuditTrail; }
            set { mPreAuditTrail = value;
            NotifyPropertyChanged("PreAuditTrail");
            }
        }
        #endregion

        #region LinesPurged
        private string mLinesPurged;
        public string LinesPurged
        {
            get { return mLinesPurged; }
            set { mLinesPurged = value;
            NotifyPropertyChanged("LinesPurged");
            }
        }
        #endregion

        #region CostCentreID
        private int? mCostCentreID;
        public int? CostCentreID
        {
            get { return mCostCentreID; }
            set { mCostCentreID = value;
            NotifyPropertyChanged("CostCentreID");
            }
        }
        #endregion

        #region TransactionExchangeRate
        private double mTransactionExchangeRate=1;
        public double TransactionExchangeRate
        {
            get 
            {
                if (Currency != null)
                {
                    return Currency.ExchangeRate;
                }
                return mTransactionExchangeRate; 
            }
            set { mTransactionExchangeRate = value;
            NotifyPropertyChanged("TransactionExchangeRate");
            }
        }
        #endregion

        #region IsTaxInclusive
        private string mIsTaxInclusive="N";
        public string IsTaxInclusive
        {
            get { return mIsTaxInclusive; }
            set 
            {
                if (mIsTaxInclusive != value)
                {
                    mIsTaxInclusive = value;
                    NotifyPropertyChanged("IsTaxInclusive");
                }
            }
        }
        #endregion

        #region DaysTillPaid
        private int? mDaysTillPaid;
        public int? DaysTillPaid
        {
            get { return mDaysTillPaid; }
            set { mDaysTillPaid = value;
            NotifyPropertyChanged("DaysTillPaid");
            }
        }
        #endregion

        #region Currency
        private int? mCurrencyID;
        public int? CurrencyID
        {
            get {
                if (mCurrency != null)
                {
                    return mCurrency.CurrencyID;
                }
                return mCurrencyID; }
            set { mCurrencyID = value;
            NotifyPropertyChanged("CurrencyID");
            }
        }
        private Currencies.Currency mCurrency;
        public Currencies.Currency Currency
        {
            get 
            {
                if (mCurrency == null)
                {
                    mCurrency = (Currencies.Currency)BuildProperty(this, "Currency");
                }
                return mCurrency; 
            }
            set
            {
                mCurrency = value;
                NotifyPropertyChanged("Currency");
            }
        }
        #endregion

        #region IsAutoRecorded
        private string mIsAutoRecorded;
        public string IsAutoRecorded
        {
            get { return mIsAutoRecorded; }
            set { mIsAutoRecorded = value;
            NotifyPropertyChanged("IsAutoRecorded");
            }
        }
        #endregion

        #region IsPrinted
        private string mIsPrinted;
        public string IsPrinted
        {
            get { return mIsPrinted; }
            set { mIsPrinted = value;
            NotifyPropertyChanged("IsPrinted");
            }
        }
        #endregion

        #region TotalDiscounts
        private double mTotalDiscounts;
        public double TotalDiscounts
        {
            get { return mTotalDiscounts; }
            set { mTotalDiscounts = value;
            NotifyPropertyChanged("TotalDiscounts");
            }
        }
        #endregion

        #region TotalDebits
        private double mTotalDebits;
        public double TotalDebits
        {
            get { return mTotalDebits; }
            set { mTotalDebits = value;
            NotifyPropertyChanged("TotalDebits");
            }
        }
        #endregion

        #region TotalDeposits
        private double mTotalDeposits;
        public double TotalDeposits
        {
            get { return mTotalDeposits; }
            set { mTotalDeposits = value; NotifyPropertyChanged("TotalDeposits");  }
        }
        #endregion

        #region FreightTaxCode
        private int? mFreightTaxCodeID;
        public int? FreightTaxCodeID
        {
            get {
                if (mFreightTaxCode != null)
                {
                    return mFreightTaxCode.TaxCodeID;
                }
                return mFreightTaxCodeID; }
            set { mFreightTaxCodeID = value;
            NotifyPropertyChanged("FreightTaxCodeID");
            }
        }
        private TaxCodes.TaxCode mFreightTaxCode;
        public TaxCodes.TaxCode FreightTaxCode
        {
            get
            {
                if (mFreightTaxCode == null)
                {
                    mFreightTaxCode = (TaxCodes.TaxCode)BuildProperty(this, "FreightTaxCode");
                }
                return mFreightTaxCode;
            }
            set
            {
                mFreightTaxCode = value;
                NotifyPropertyChanged("FreightTaxCode");
            }
        }
        #endregion

        #region TaxInclusiveFreight
        private double mTaxInclusiveFreight;
        public double TaxInclusiveFreight
        {
            get { return mTaxInclusiveFreight; }
            set { mTaxInclusiveFreight = value;
            NotifyPropertyChanged("TaxInclusiveFreight");
            }
        }
        #endregion

        #region TaxExclusiveFreight
        private double mTaxExclusiveFreight;
        public double TaxExclusiveFreight
        {
            get { return mTaxExclusiveFreight; }
            set 
            { 
                mTaxExclusiveFreight = value;
                NotifyPropertyChanged("TaxExclusiveFreight");
            }
        }
        #endregion

        #region OrderStatus
        private string mOrderStatusID;
        public string OrderStatusID
        {
            get {
                if (mOrderStatus != null)
                {
                    return mOrderStatus.OrderStatusID;
                }
                return mOrderStatusID; }
            set { mOrderStatusID = value;
            NotifyPropertyChanged("OrderStatusID");
            }
        }
        private Definitions.OrderStatus mOrderStatus;
        public Definitions.OrderStatus OrderStatus
        {
            get { return mOrderStatus; }
            set
            {
                mOrderStatus = value;
                NotifyPropertyChanged("OrderStatusID");
            }
        }
        #endregion

        #region ReversalLinkID
        private int? mReversalLinkID;
        public int? ReversalLinkID
        {
            get { return mReversalLinkID; }
            set { mReversalLinkID = value;
            NotifyPropertyChanged("ReversalLinkID");
            }
        }
        #endregion

        #region IsThirteenthPeriod
        private string mIsThirteenthPeriod="N";
        public string IsThirteenthPeriod
        {
            get { return mIsThirteenthPeriod; }
            set { mIsThirteenthPeriod = value;
            NotifyPropertyChanged("IsThirteenthPeriod");
            }
        }
        #endregion

        #region BackorderPurchase
        private int? mBackorderPurchaseID;
        public int? BackorderPurchaseID
        {
            get { return mBackorderPurchaseID; }
            set { mBackorderPurchaseID = value;
            NotifyPropertyChanged("BackorderPurchaseID");
            }
        }
        #endregion

        #region IsHistorical
        private string mIsHistorical="N";
        public string IsHistorical
        {
            get { return mIsHistorical; }
            set { mIsHistorical = value;
            NotifyPropertyChanged("IsHistorical");
            }
        }
        #endregion

        #region SupplierInvoiceNumber
        private string mSupplierInvoiceNumber;
        public string SupplierInvoiceNumber
        {
            get { return mSupplierInvoiceNumber; }
            set { mSupplierInvoiceNumber = value;
            NotifyPropertyChanged("SupplierInvoiceNumber");
            }
        }
        #endregion

        #region ShippingMethod
        private int? mShippingMethodID;
        public int? ShippingMethodID
        {
            get {
                if (mShippingMethod != null)
                {
                    return mShippingMethod.ShippingMethodID;
                }
                return mShippingMethodID; }
            set { mShippingMethodID = value;
            NotifyPropertyChanged("ShippingMethodID");
            }
        }
        private ShippingMethods.ShippingMethod mShippingMethod;
        public ShippingMethods.ShippingMethod ShippingMethod
        {
            get 
            {
                if (mShippingMethod == null)
                {
                    mShippingMethod = (ShippingMethods.ShippingMethod)BuildProperty(this, "ShippingMethod");
                }
                return mShippingMethod; 
            }
            set
            {
                mShippingMethod = value;
                NotifyPropertyChanged("ShippingMethod");
            }
        }
        #endregion

        #region InvoiceDelivery
        private string mInvoiceDeliveryID;
        public string InvoiceDeliveryID
        {
            set { mInvoiceDeliveryID = value;
            NotifyPropertyChanged("InvoiceDeliveryID");
            }
            get {
                if (mInvoiceDelivery != null)
                {
                    return mInvoiceDelivery.InvoiceDeliveryID;
                }
                return mInvoiceDeliveryID; }
        }
        private Definitions.InvoiceDelivery mInvoiceDelivery = null;
        public Definitions.InvoiceDelivery InvoiceDelivery
        {
            get 
            {
                if (mInvoiceDelivery == null)
                {
                    mInvoiceDelivery = (Definitions.InvoiceDelivery)BuildProperty(this, "InvoiceDelivery");
                }
                return mInvoiceDelivery; 
            }
            set
            {
                mInvoiceDelivery = value;
                NotifyPropertyChanged("InvoiceDelivery");
            }
        }
        #endregion

        #region OutstandingBalance
        private double mOutstandingBalance;
        public double OutstandingBalance
        {
            get { return mOutstandingBalance; }
            set { mOutstandingBalance = value;
            NotifyPropertyChanged("OutstandingBalance");
            }
        }
        #endregion

        #region TotalPaid
        private double mTotalPaid;
        public double TotalPaid
        {
            get { return mTotalPaid; }
            set { mTotalPaid = value;
            NotifyPropertyChanged("TotalPaid");
            }
        }
        #endregion

        #region TotalTax
        private double mTotalTax;
        public double TotalTax
        {
            get { return mTotalTax; }
            set 
            { 
                mTotalTax = value;
                NotifyPropertyChanged("TotalTax");
                NotifyPropertyChanged("_TotalTax");
            }
        }
        #endregion

        #region TotalLines
        private double mTotalLines;
        public double TotalLines
        {
            get { return mTotalLines; }
            set 
            {
                if (mTotalLines != value)
                {
                    mTotalLines = value;
                    NotifyPropertyChanged("TotalLines");
                    NotifyPropertyChanged("_TotalLines");
                }
            }
        }
        #endregion

        #region Terms
        private int? mTermsID;
        public int? TermsID
        {
            set { mTermsID = value;
            NotifyPropertyChanged("TermsID");
            }
            get {
                if (mTerms != null)
                {
                   return mTerms.TermsID;
                }
                return mTermsID; }
        }
        private Terms.Terms mTerms = null;
        public Terms.Terms Terms
        {
            get 
            {
                if (mTerms == null)
                {
                    mTerms = (Terms.Terms)BuildProperty(this, "Terms");
                }
                return mTerms; 
            }
            set
            {
                mTerms = value;
                NotifyPropertyChanged("Terms");
            }
        }
        #endregion

        #region PaymentIsDue
        private string mPaymentIsDue;
        public string PaymentIsDue
        {
            get { return mPaymentIsDue; }
            set { mPaymentIsDue = value;
            NotifyPropertyChanged("PaymentIsDue");
            }
        }
        #endregion

        #region PurchaseStatus
        private string mPurchaseStatusID;
        public string PurchaseStatusID
        {
            set { mPurchaseStatusID = value;
            NotifyPropertyChanged("PurchaseStatusID");
            }
            get {
                if (mPurchaseStatus != null)
                {
                    return mPurchaseStatus.StatusID;
                }
                return mPurchaseStatusID; }
        }
        private Definitions.Status mPurchaseStatus = null;
        public Definitions.Status PurchaseStatus
        {
            get 
            {
                if (mPurchaseStatus == null)
                {
                    mPurchaseStatus = (Definitions.Status)BuildProperty(this, "PurchaseStatus");
                }
                return mPurchaseStatus; 
            }
            set
            {
                mPurchaseStatus = value;
                NotifyPropertyChanged("PurchaseStatus");
            }
        }
        #endregion

        #region ShipToAddress
        private string mAddressLine1;
        private string mAddressLine2;
        private string mAddressLine3;
        private string mAddressLine4;
        private string mAddress;
        public string ShipToAddress
        {
            get { return mAddress; }
            set { mAddress = value;
            NotifyPropertyChanged("ShipToAddress");
            }
        }

        public string ShipToAddressLine1
        {
            get { return mAddressLine1; }
            set { mAddressLine1 = value;
            NotifyPropertyChanged("ShipToAddressLine1");
            }
        }
        public string ShipToAddressLine2
        {
            get { return mAddressLine2; }
            set { mAddressLine2 = value;
            NotifyPropertyChanged("ShipToAddressLine2");
            }
        }
        public string ShipToAddressLine3
        {
            get { return mAddressLine3; }
            set { mAddressLine3 = value;
            NotifyPropertyChanged("ShipToAddressLine3");
            }
        }
        public string ShipToAddressLine4
        {
            get { return mAddressLine4; }
            set { mAddressLine4 = value;
            NotifyPropertyChanged("ShipToAddressLine4");
            }
        }
        #endregion

        #region PromisedDate
        private Nullable<DateTime> mPromisedDate;
        public Nullable<DateTime> PromisedDate
        {
            set { mPromisedDate = value;
            NotifyPropertyChanged("PromisedDate");
            }
            get { return mPromisedDate; }
        }
        #endregion

        #region Memo
        private string mMemo = null;
        public string Memo
        {
            get
            {
                if (mMemo == null)
                {
                    if (Supplier == null) return "Purchase";
                    return string.Format("Purchase; {0}", Supplier.Name);
                }
                return mMemo;
            }
            set { mMemo = value;
            NotifyPropertyChanged("Memo");
            }
        }
        #endregion

        #region Comment
        private string mComment;
        public string Comment
        {
            get { return mComment; }
            set { mComment = value;
            NotifyPropertyChanged("Comment");
            }
        }
        #endregion

        #region PurchaseDate
        private Nullable<DateTime> mPurchaseDate;
        public Nullable<DateTime> PurchaseDate
        {
            get { return mPurchaseDate; }
            set { mPurchaseDate = value;
            NotifyPropertyChanged("PurchaseDate");
            }
        }
        #endregion

        #region PurchaseNumber
        private string mPurchaseNumber = "";
        public string PurchaseNumber
        {
            set { mPurchaseNumber = value;
            NotifyPropertyChanged("PurchaseNumber");
            }
            get { return mPurchaseNumber; }
        }
        #endregion 

        #region Supplier
        private int? mCardRecordID;
        public int? CardRecordID
        {
            set { mCardRecordID = value;
            NotifyPropertyChanged("CardRecordID");
            }
            get {
                if (mSupplier != null)
                {
                    return mSupplier.CardRecordID;
                }
                return mCardRecordID; }
        }
        private Cards.Supplier mSupplier = null;
        public Cards.Supplier Supplier
        {
            get 
            {
                if (mSupplier == null)
                {
                    mSupplier = (Cards.Supplier)BuildProperty(this, "Supplier");
                }
                return mSupplier; 
            }
            set
            {
                mSupplier = value;
                NotifyPropertyChanged("Supplier");
            }
        }
        #endregion

        #region PurchaseID
        private int? mPurchaseID;
        public int? PurchaseID
        {
            set { mPurchaseID = value;
            NotifyPropertyChanged("PurchaseID");
            }
            get { return mPurchaseID; }
        }
        #endregion

        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("PurchaseID", PurchaseID);
            }
        }

        #region PurchaseType
        private string mPurchaseTypeID;
        public string PurchaseTypeID
        {
            get
            {
                if(mPurchaseType != null)
                {
                    return mPurchaseType.InvoiceTypeID;
                }
                return mPurchaseTypeID;
            }
            set
            {
                mPurchaseTypeID=value;
                NotifyPropertyChanged("PurchaseTypeID");
            }
        }
        private Definitions.InvoiceType mPurchaseType;
        public Definitions.InvoiceType PurchaseType
        {
            get
            {
                if (mPurchaseType == null)
                {
                    mPurchaseType = (Definitions.InvoiceType)BuildProperty(this, "PurchaseType");
                }
                return mPurchaseType;
            }
            set
            {
                mPurchaseType = value;
                NotifyPropertyChanged("PurchaseType");
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override bool Equals(object obj)
        {
            if (obj is Purchase)
            {
                Purchase _obj = (Purchase)obj;
                return _obj.PurchaseID == mPurchaseID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return PurchaseNumber;
        }
        #endregion

        private List<PurchaseLine> mPurchaseLines = null;
        public IList<PurchaseLine> PurchaseLines
        {
            get
            {
                if (mPurchaseLines == null)
                {
                    mPurchaseLines = new List<PurchaseLine>();
                    if (FromDb)
                    {
                        InvoiceType purchase_type = PurchaseType;
                        if (purchase_type != null)
                        {
                            if (purchase_type.IsItem)
                            {
                                IList<ItemPurchaseLine> lines = RepositoryMgr.ItemPurchaseLineMgr.FindCollectionByPurchaseID(PurchaseID);
                                foreach (ItemPurchaseLine line in lines)
                                {
                                    mPurchaseLines.Add(line);
                                }
                            }
                            else if (purchase_type.IsProfessional)
                            {
                                IList<ProfessionalPurchaseLine> lines = RepositoryMgr.ProfessionalPurchaseLineMgr.FindCollectionByPurchaseID(PurchaseID);
                                foreach (ProfessionalPurchaseLine line in lines)
                                {
                                    mPurchaseLines.Add(line);
                                }
                            }
                            else if (purchase_type.IsMisc)
                            {
                                IList<MiscPurchaseLine> lines = RepositoryMgr.MiscPurchaseLineMgr.FindCollectionByPurchaseID(PurchaseID);
                                foreach (MiscPurchaseLine line in lines)
                                {
                                    mPurchaseLines.Add(line);
                                }
                            }
                            else if (purchase_type.IsService)
                            {
                                IList<ServicePurchaseLine> lines = RepositoryMgr.ServicePurchaseLineMgr.FindCollectionByPurchaseID(PurchaseID);
                                foreach (ServicePurchaseLine line in lines)
                                {
                                    mPurchaseLines.Add(line);
                                }
                            }
                            else if (purchase_type.IsTimeBilling)
                            {
                                IList<TimeBillingPurchaseLine> lines = RepositoryMgr.TimeBillingPurchaseLineMgr.FindCollectionByPurchaseID(PurchaseID);
                                foreach (TimeBillingPurchaseLine line in lines)
                                {
                                    mPurchaseLines.Add(line);
                                }
                            }
                        }
                    }
                }
                return mPurchaseLines;
            }
        }

        public double Total
        {
            get
            {
                if (IsTaxInclusive == "Y")
                {
                    return TotalLines + Freight;
                }
                else
                {
                    return TotalLines + TotalTax + Freight;
                }
            }
        }

        #region -(Entity Override Methods)
        public override void AssignFrom(Entity rhs)
        {
            base.AssignFrom(rhs);

            Purchase _obj = rhs as Purchase;

            mPurchaseLines = new List<PurchaseLine>();

            foreach (PurchaseLine line in _obj.PurchaseLines)
            {
                PurchaseLine new_line = line.Clone() as PurchaseLine;
                new_line.Purchase = this;
                mPurchaseLines.Add(new_line);
            }
        }
        #endregion

        public double Freight
        {
            get
            {
                if (IsTaxInclusive == "Y")
                {
                    return TaxInclusiveFreight;
                }
                else
                {
                    return TaxExclusiveFreight;
                }
            }
        }

        public void Evaluate()
        {
            bool is_tax_inclusive = IsTaxInclusive == "Y";
            double total_lines = 0;
            double total_tax = 0;
            foreach (PurchaseLine _line in PurchaseLines)
            {
                _line.TaxBasisAmountIsInclusive = IsTaxInclusive;
                _line.Evaluate();
                total_lines += _line.TaxBasisAmount;
                total_tax += (_line.TaxInclusiveAmount - _line.TaxExclusiveAmount);
            }

            total_tax += (TaxInclusiveFreight - TaxExclusiveFreight);

            TotalLines = total_lines;
            TotalTax = total_tax;
            NotifyPropertyChanged("Total");
            NotifyPropertyChanged("Freight");
        }
    }
}
