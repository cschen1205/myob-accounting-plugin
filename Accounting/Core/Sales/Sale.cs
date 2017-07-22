using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Sales
{
    using System.ComponentModel;
    using Accounting.Core.Cards;
    using Accounting.Core.Definitions;
    using Accounting.Core.Inventory;
    public class Sale : Entity, JournalRecords.JournalSource
    {
        #region Sale constructor
        internal Sale(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        #region SaleID
        private int? mSaleID;
        public int? SaleID
        {
            set
            {
                mSaleID = value;
                NotifyPropertyChanged("SaleID");
            }
            get { return mSaleID; }
        }
        #endregion

        public string AmountText
        {
            get
            {
                return this.Currency.Format(TotalLines);
            }
        }

        public string AmountDueText
        {
            get
            {
                return this.Currency.Format(OutstandingBalance);
            }
        }

        internal bool Match(DateTime? start, DateTime? end, Customer customer, Status invoiceStatus)
        {
            if (invoiceStatus != null)
            {
                if (!invoiceStatus.Equals(InvoiceStatus))
                {
                    return false;
                }
            }
            if (InvoiceDate != null)
            {
                if (start != null)
                {
                    if (InvoiceDate.Value < start.Value)
                    {
                        return false;
                    }
                }
                if (end != null)
                {
                    if (InvoiceDate.Value > end.Value)
                    {
                        return false;
                    }
                }
            }

            if (customer != null)
            {
                if (!customer.Equals(Customer))
                {
                    return false;
                }
            }

            return true;

        }

    

        public override Accounting.Core.RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("SaleID", SaleID);
            }
        }

        #region -(GetTransactionDate)
        public Nullable<DateTime> GetTransactionDate()
        {
            return InvoiceDate;
        }
        #endregion

        #region -(GetSourceID)
        public int? GetSourceID()
        {
            return mSaleID;
        }
        #endregion

        #region Customer
        //The CardRecordID (Cards) or CustomerID (Customers) of the record containing customer information for this sale invoice entry.
        private int? mCardRecordID;
        public int? CardRecordID
        {
            set { mCardRecordID = value;
            NotifyPropertyChanged("CardRecordID");
            }
            get {
                if (mCustomer != null)
                {
                    return mCustomer.CardRecordID;
                }
                return mCardRecordID; }
        }
        private Cards.Customer mCustomer;
        public Cards.Customer Customer
        {
            get 
            {
                if(mCustomer==null && FromDb)
                {
                    mCustomer=(Cards.Customer) BuildProperty(this, "Customer");
                }
                return mCustomer; 
            }
            set
            {
                mCustomer = value;
                NotifyPropertyChanged("Customer");
            }
        }
        #endregion

        #region InvoiceNumber
        //The sale invoice number.
        private string mInvoiceNumber;
        public string InvoiceNumber
        {
            set { mInvoiceNumber = value;
            NotifyPropertyChanged("InvoiceNumber");
            }
            get { return mInvoiceNumber; }
        }
        #endregion

        #region CustomerPONumber
        //The customer PO number.
        private string mCustomerPONumber;
        public string CustomerPONumber
        {
            set { mCustomerPONumber = value;
            NotifyPropertyChanged("CustomerPONumber");
            }
            get { return mCustomerPONumber; }
        }
        #endregion

        #region IsHistorical
        //If the sale invoice was generated through the historical sale window.
        private string mIsHistorical="N";
        public string IsHistorical
        {
            set { mIsHistorical = value;
            NotifyPropertyChanged("IsHistorical");
            }
            get { return mIsHistorical; }
        }
        #endregion

        #region BackorderSaleID
        //The set number to which this sale invoice belongs. Used to link sale invoices together.
        private int? mBackorderSaleID;
        public int? BackorderSaleID
        {
            set { mBackorderSaleID = value;
            NotifyPropertyChanged("BackorderSaleID");
            }
            get {
                if (mBackorderSaleID == -1)
                {
                    return mSaleID;
                }
                return mBackorderSaleID; 
            }
        }
        #endregion

        #region Date
        //Date of the sale invoice entry. To avoid SQL reserved word conflicts, use the InvoiceDate field below.
        private Nullable<DateTime> mDate;
        public Nullable<DateTime> Date
        {
            set { mDate = value;
            NotifyPropertyChanged("Date");
            }
            get { return mDate; }
        }
        #endregion

        #region InvoiceDate
        //Transaction date of this entry. This field contains the same data as the Date field above.
        private Nullable<DateTime> mInvoiceDate;
        public Nullable<DateTime> InvoiceDate
        {
            get { return mInvoiceDate; }
            set { mInvoiceDate = value;
            NotifyPropertyChanged("InvoiceDate");
            }
        }
        #endregion

        #region IsThirteenthPeriod
        //If the transaction was recorded as a thirteenth period transaction.
        private string mIsThirteenthPeriod="N";
        public string IsThirteenthPeriod
        {
            get { return mIsThirteenthPeriod; }
            set { mIsThirteenthPeriod = value;
            NotifyPropertyChanged("IsThirteenthPeriod");
            }
        }
        #endregion 

        #region ShipToAddress
        //ShipTo address of the sale invoice.
        private string mShipToAddressLine1;
        private string mShipToAddressLine2;
        private string mShipToAddressLine3;
        private string mShipToAddressLine4;
        private string mShipToAddress;
        public string ShipToAddressLine1
        {
            get { return mShipToAddressLine1; }
            set { mShipToAddressLine1 = value;
            NotifyPropertyChanged("ShipToAddressLine1");
            }
        }
        public string ShipToAddressLine2
        {
            get { return mShipToAddressLine2; }
            set { mShipToAddressLine2 = value;
            NotifyPropertyChanged("ShipToAddressLine2");
            }
        }
        public string ShipToAddressLine3
        {
            get { return mShipToAddressLine3; }
            set { mShipToAddressLine3 = value;
            NotifyPropertyChanged("ShipToAddressLine3");
            }
        }
        public string ShipToAddressLine4
        {
            get { return mShipToAddressLine4; }
            set { mShipToAddressLine4 = value;
            NotifyPropertyChanged("ShipToAddressLine4");
            }
        }
        public string ShipToAddress
        {
            get { return mShipToAddress; }
            set { mShipToAddress = value;
            NotifyPropertyChanged("ShipToAddress");
            }
        }
        #endregion

        #region InvoiceType
        //InvoiceTypeID (InvoiceType) of the record containing the full sale type definition.
        private string mInvoiceTypeID;
        public string InvoiceTypeID
        {
            get {
                if (mInvoiceType != null)
                {
                    return mInvoiceType.InvoiceTypeID;
                }
                return mInvoiceTypeID; }
            set { mInvoiceTypeID = value;
            NotifyPropertyChanged("InvoiceTypeID");
            }
        }
        private Definitions.InvoiceType mInvoiceType=null;
        public Definitions.InvoiceType InvoiceType
        {
            get {
                if(mInvoiceType==null && FromDb)
                {
                    mInvoiceType=(Definitions.InvoiceType)BuildProperty(this, "InvoiceType");
                }
                return mInvoiceType; 
            }
            set
            {
                mInvoiceType = value;
                NotifyPropertyChanged("InvoiceType");
            }
        }
        #endregion

        #region InvoiceStatus
        //StatusID (Status) of the record containing the full sale invoice status definition.
        private string mInvoiceStatusID;
        public string InvoiceStatusID
        {
            set { mInvoiceStatusID = value;
            NotifyPropertyChanged("InvoiceStatusID");
            }
            get {
                if (mInvoiceStatus != null)
                {
                    return mInvoiceStatus.StatusID;
                }
                return mInvoiceStatusID; }
        }
        private Definitions.Status mInvoiceStatus = null;
        public Definitions.Status InvoiceStatus
        {
            get 
            {
                if (mInvoiceStatus == null)
                {
                    mInvoiceStatus = (Definitions.Status)BuildProperty(this, "InvoiceStatus");
                }
                return mInvoiceStatus; 
            }
            set
            {
                mInvoiceStatus = value;
                NotifyPropertyChanged("InvoiceStatus");
            }
        }
        
        #endregion

        #region Terms
        //The TermsID (Terms) of the record containing terms information for this sale entry.
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
        private Terms.Terms mTerms;
        public Terms.Terms Terms
        {
            get {
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

        #region TotalLines
        //The sum of all tax exclusive line amounts applicable to this sale invoice.
        private double mTotalLines;
        public double TotalLines
        {
            get { return mTotalLines; }
            set { mTotalLines = value;
            NotifyPropertyChanged("TotalLines");
            }
        }
        #endregion

        #region TaxExclusiveFreight
        //The Tax exclusive freight amount applicable to this sale invoice.
        private double mTaxExclusiveFreight;
        public double TaxExclusiveFreight
        {
            get { return mTaxExclusiveFreight; }
            set { mTaxExclusiveFreight = value;
            NotifyPropertyChanged("TaxExclusiveFreight");
            }
        }
        #endregion

        #region TaxInclusiveFreight
        //The Tax inclusive freight amount applicable to this sale invoice.
        private double mTaxInclusiveFreight;
        public double TaxInclusiveFreight
        {
            get { return mTaxInclusiveFreight; }
            set { mTaxInclusiveFreight = value;
            NotifyPropertyChanged("TaxInclusiveFreight");
            }
        }
        #endregion

        #region FreightTaxCode
        //TaxCodeID (TaxCodes) of the record containing the tax code applied against the Freight amount on this sale invoice.
        private int? mFreightTaxCodeID;
        public int? FreightTaxCodeID
        {
            set { mFreightTaxCodeID = value;
            NotifyPropertyChanged("FreightTaxCodeID");
            }
            get {
                if (mFreightTaxCode != null)
                {
                    return mFreightTaxCode.TaxCodeID;
                }
                return mFreightTaxCodeID; }
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

        #region TotalTax
        //The total of all tax amounts applicable to this sale invoice.
        private double mTotalTax;
        public double TotalTax
        {
            get { return mTotalTax; }
            set { mTotalTax = value;
            NotifyPropertyChanged("TotalTax");
            }
        }
        #endregion

        #region TotalPaid
        //The total of all payments made against this sale invoice.
        private double mTotalPaid;
        public double TotalPaid
        {
            get { return mTotalPaid; }
            set { mTotalPaid = value;
            NotifyPropertyChanged("TotalPaid");
            }
        }
        #endregion

        #region TotalDeposits
        //The total of all deposit payments made against a sale invoice. This field can only have a non-zero balance when the status is pending.
        private double mTotalDeposits;
        public double TotalDeposits
        {
            get { return mTotalDeposits; }
            set { mTotalDeposits = value;
            NotifyPropertyChanged("TotalDeposits");
            }
        }
        #endregion

        #region TotalCredits
        //The total credits applied against this sale invoice from another sale invoice, OR The total credits applied from this sale invoice to another sale invoice.
        private double mTotalCredits;
        public double TotalCredits
        {
            get { return mTotalCredits; }
            set { mTotalCredits = value;
            NotifyPropertyChanged("TotalCredits");
            }
        }
        #endregion

        #region TotalDiscounts
        //The total amount of discounts applied against this sale invoice.
        private double mTotalDiscounts;
        public double TotalDiscounts
        {
            set { mTotalDiscounts = value;
            NotifyPropertyChanged("TotalDiscounts");
            }
            get { return mTotalDiscounts; }
        }
        #endregion

        #region OutstandingBalance
        //The amount still payable on the sale invoice.
        private double mOutstandingBalance;
        public double OutstandingBalance
        {
            get { return mOutstandingBalance; }
            set { mOutstandingBalance = value;
            NotifyPropertyChanged("OutstandingBalance");
            }
        }
        #endregion

        #region SalesPerson
        //The CardRecordID (Cards) or EmployeeID (Employees) of the record containing salesperson information for this sale invoiceentry.
        private int? mSalesPersonID;
        public int? SalesPersonID
        {
            set { mSalesPersonID = value;
            NotifyPropertyChanged("SalesPersonID");
            }
            get {
                if (mSalesPerson != null)
                {
                    return mSalesPerson.CardRecordID;
                }
                return mSalesPersonID; }
        }
        private Cards.Employee mSalesPerson;
        public Cards.Employee SalesPerson
        {
            get 
            {
                if (mSalesPerson == null)
                {
                    mSalesPerson = (Cards.Employee)BuildProperty(this, "SalesPerson");
                }
                return mSalesPerson; 
            }
            set
            {
                mSalesPerson = value;
                NotifyPropertyChanged("SalesPerson");
            }
        }
        #endregion 

        #region Memo
        //Journal memo of the sale invoice. 
        private string mMemo = null;
        public string Memo
        {
            get
            {
                if (mMemo == null)
                {
                    if (Customer == null) return "Sale";
                    return string.Format("Sale; {0}", Customer.Name);
                }
                return mMemo;
            }
            set
            {
                mMemo = value;
                NotifyPropertyChanged("Memo");
            }
        }
        #endregion

        #region Comment
        private string mComment = null;
        public string Comment
        {
            get { return mComment; }
            set { mComment = value;
            NotifyPropertyChanged("Comment");
            }
        }
        #endregion

        #region ShippingMethod
        //The Shipping MethodID (ShippingMethods) of the record containing Shipping information for this sale invoice entry.
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
            get {
                if (mShippingMethod == null)
                {
                    mShippingMethod = (ShippingMethods.ShippingMethod)BuildProperty(this, "ShippingMethod");
                }
                return mShippingMethod; 
            }
            set
            {
                //Accounting.Util.AppEnv.Instance.Log(string.Format("shipping method id: {0}", mShippingMethodID));
                mShippingMethod = value;
                NotifyPropertyChanged("ShippingMethod");
                //Accounting.Util.AppEnv.Instance.Log(string.Format("shipping method id: {0}", mShippingMethod.ShippingMethodID));
            }
        }
        #endregion

        #region PromisedDate
        //Promised date of the sale invoice.
        private Nullable<DateTime> mPromisedDate;
        public Nullable<DateTime> PromisedDate
        {
            set { mPromisedDate = value;
            NotifyPropertyChanged("PromisedDate");
            }
            get { return mPromisedDate;
            
            }
        }
        #endregion

        #region ReferralSource
        //The ReferralSourceID (ReferralSources) of the record containing referral source for this sale invoice entry.
        private int? mReferralSourceID;
        public int? ReferralSourceID
        {
            get {
                if (mReferralSource != null)
                {
                    return mReferralSource.ReferralSourceID;
                }
                return mReferralSourceID; 
            }
            set { mReferralSourceID = value;
            NotifyPropertyChanged("ReferralSourceID");
            }
        }

        private ReferralSource mReferralSource;
        public ReferralSource ReferralSource
        {
            get
            {
                if(mReferralSource==null && FromDb)
                {
                    mReferralSource=(ReferralSource) BuildProperty(this, "ReferralSource");
                }
                return mReferralSource;
            }
            set
            {
                mReferralSource=value;
                NotifyPropertyChanged("ReferralSource");
            }
        }
        #endregion

        #region IsTaxInclusive
        //Yes/No flag indicating if the transaction is Tax inclusive. Note: Historical Sales can only be recorded as Tax inclusive. All historical sales should therefore report as Y.
        private string mIsTaxInclusive="N";
        public string IsTaxInclusive
        {
            get { return mIsTaxInclusive; }
            set { mIsTaxInclusive = value;
            NotifyPropertyChanged("IsTaxInclusive");
            }
        }
        #endregion

        #region IsAutoRecorded
        //Y/N flag to indicate if the sale invoice was automatically recorded.
        private string mIsAutoRecorded="N";
        public string IsAutoRecorded
        {
            get { return mIsAutoRecorded; }
            set { mIsAutoRecorded = value;
            NotifyPropertyChanged("IsAutoRecorded");
            }
        }
        #endregion

        #region IsPrinted
        //Sale Invoice is marked as Already Printed or Sent
        private string mIsPrinted="N";
        public string IsPrinted
        {
            get { return mIsPrinted; }
            set { mIsPrinted = value;
            NotifyPropertyChanged("IsPrinted");
            }
        }
        #endregion

        #region InvoiceDelivery
        //InvoiceDeliveryID (InvoiceDelivery) of the record containing the full Invoice Delivery Status assigned to the sale.
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
        private Definitions.InvoiceDelivery mInvoiceDelivery;
        public Definitions.InvoiceDelivery InvoiceDelivery
        {
            get 
            {
                if(mInvoiceDelivery==null && FromDb)
                {
                    mInvoiceDelivery=(Definitions.InvoiceDelivery)BuildProperty(this, "InvoiceDelivery");
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

        #region DaysTillPaid
        //Number of days taken until the sale invoice was paid in full.
        private int? mDaysTillPaid;
        public int? DaysTillPaid
        {
            get { return mDaysTillPaid; }
            set { mDaysTillPaid = value;
            NotifyPropertyChanged("DaysTillPaid");
            }
        }
        #endregion

        #region TransactionExchangeRate
        //The exchange rate of this transaction at the time of recording.
        private double mTransactionExchangeRate=1;
        public double TransactionExchangeRate
        {
            get {
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

        #region CostCentreID
        //The CostCentreID assigned to the Sale Invoice.
        private int? mCostCentreID;
        public int? CostCentreID
        {
            set { mCostCentreID = value;
            NotifyPropertyChanged("CostCentreID");
            }
            get { return mCostCentreID; }
        }
        #endregion

        #region LinesPurged
        //Y/N flag indicates if the sale lines have been purged.
        private string mLinesPurged="N";
        public string LinesPurged
        {
            get { return mLinesPurged; }
            set { mLinesPurged = value;
            NotifyPropertyChanged("LinesPurged");
            }
        }
        #endregion

        #region PreAuditTrail
        //Y/N flag indicates if the invoice involves inventoried stock items and was recorded using a version of AccountRight that did not have an inventory audit trail.
        private string mPreAuditTrail="N";
        public string PreAuditTrail
        {
            get { return mPreAuditTrail; }
            set { mPreAuditTrail = value;
            NotifyPropertyChanged("PreAuditTrail");
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
            get { 
                if(mCurrency == null)
                {
                    mCurrency=(Currencies.Currency)BuildProperty(this, "Currency");
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

        #region DestinationCountry
        private string mDestinationCountry = "";
        public string DestinationCountry
        {
            get { return mDestinationCountry; }
            set
            {
                mDestinationCountry = value;
                NotifyPropertyChanged("DestinationCountry");
            }
        }
        #endregion

        public bool IsItemSale
        {
            get {
                if (InvoiceType != null)
                {
                    return InvoiceType.IsItem;
                }
                return false;
            }
        }

        public bool IsMiscSale
        {
            get
            {
                if (InvoiceType != null)
                {
                    return InvoiceType.IsMisc;
                }
                return false;
            }
        }

        public bool IsProfessionalSale
        {
            get
            {
                if (InvoiceType != null)
                {
                    return InvoiceType.IsProfessional;
                }
                return false;
            }
        }

        public bool IsServiceSale
        {
            get
            {
                if (InvoiceType != null)
                {
                    return InvoiceType.IsService;
                }
                return false;
            }
        }

        public bool IsTimeBillingSale
        {
            get
            {
                if (InvoiceType != null)
                {
                    return InvoiceType.IsTimeBilling;
                }
                return false;
            }
        }

        #region -(Object Override Methods)
        public override string ToString()
        {
            return InvoiceNumber;
        }

        public override bool Equals(object obj)
        {
            if(obj is Sale)
            {
                Sale rhs = (Sale)obj;
                if (rhs.FromDb && FromDb)
                {
                    return rhs.SaleID == SaleID;
                }
                if (rhs.InvoiceNumber == rhs.InvoiceNumber)
                {
                    return rhs.InvoiceType.Equals(InvoiceType);
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        private List<SaleLine> mSaleLines = null;
        public IList<SaleLine> SaleLines
        {
            get
            {
                if (mSaleLines == null)
                {
                    mSaleLines = new List<SaleLine>();
                    if (FromDb)
                    {
                        InvoiceType invoice_type = InvoiceType;
                        if (invoice_type != null)
                        {
                            if (invoice_type.IsItem)
                            {
                                IList<ItemSaleLine> lines = RepositoryMgr.ItemSaleLineMgr.FindCollectionBySaleID(SaleID);
                                foreach (ItemSaleLine line in lines)
                                {
                                    mSaleLines.Add(line);
                                }
                            }
                            else if (invoice_type.IsProfessional)
                            {
                                IList<ProfessionalSaleLine> lines = RepositoryMgr.ProfessionalSaleLineMgr.FindCollectionBySaleID(SaleID);
                                foreach (ProfessionalSaleLine line in lines)
                                {
                                    mSaleLines.Add(line);
                                }
                            }
                            else if (invoice_type.IsMisc)
                            {
                                IList<MiscSaleLine> lines = RepositoryMgr.MiscSaleLineMgr.FindCollectionBySaleID(SaleID);
                                foreach (MiscSaleLine line in lines)
                                {
                                    mSaleLines.Add(line);
                                }
                            }
                            else if (invoice_type.IsService)
                            {
                                IList<ServiceSaleLine> lines = RepositoryMgr.ServiceSaleLineMgr.FindCollectionBySaleID(SaleID);
                                foreach (ServiceSaleLine line in lines)
                                {
                                    mSaleLines.Add(line);
                                }
                            }
                            else if (invoice_type.IsTimeBilling)
                            {
                                IList<TimeBillingSaleLine> lines = RepositoryMgr.TimeBillingSaleLineMgr.FindCollectionBySaleID(SaleID);
                                foreach (TimeBillingSaleLine line in lines)
                                {
                                    mSaleLines.Add(line);
                                }
                            }
                        }
                    }
                }
                return mSaleLines;
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

            Sale _obj = rhs as Sale;

            mSaleLines = new List<SaleLine>();

            foreach (SaleLine line in _obj.SaleLines)
            {
                SaleLine new_line = line.Clone() as SaleLine;
                new_line.Sale = this;
                mSaleLines.Add(new_line);
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
            foreach (SaleLine _line in SaleLines)
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

        internal bool IsSellingItem(Item _item)
        {
            if (IsItemSale)
            {
                if (_item == null) return true;
                foreach (ItemSaleLine _line in SaleLines)
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
    }
}
