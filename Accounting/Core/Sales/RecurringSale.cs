using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Sales
{
    using System.ComponentModel;
    using Accounting.Core.Definitions;
    public class RecurringSale : RecurringEntity
    {
        #region RecurringSale constructor
        internal RecurringSale(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region RecurringSaleID
        private int? mRecurringSaleID;
        public int? RecurringSaleID
        {
            set 
            {
                mRecurringSaleID = value;
                NotifyPropertyChanged("RecurringSaleID");
            }
            get { return mRecurringSaleID; }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("RecurringSaleID", RecurringSaleID);
            }
        }

        #region Customer
        //The CardRecordID (Cards) or CustomerID (Customers) of the record containing customer information for this RecurringSale invoice entry.
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

        #region ShipToAddress
        //ShipTo address of the RecurringSale invoice.
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
        //InvoiceTypeID (InvoiceType) of the record containing the full RecurringSale type definition.
        private string mInvoiceTypeID;
        public string InvoiceTypeID
        {
            get
            {
                if (mInvoiceType != null)
                {
                    return mInvoiceType.InvoiceTypeID;
                }
                return mInvoiceTypeID;
            }
            set { mInvoiceTypeID = value;
            NotifyPropertyChanged("InvoiceTypeID");
            }
        }
        private Definitions.InvoiceType mInvoiceType = null;
        public Definitions.InvoiceType InvoiceType
        {
            get
            {
                if (mInvoiceType == null && FromDb)
                {
                    mInvoiceType = (Definitions.InvoiceType)BuildProperty(this, "InvoiceType");
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
        //StatusID (Status) of the record containing the full RecurringSale invoice status definition.
        private string mInvoiceStatusID;
        public string InvoiceStatusID
        {
            set { mInvoiceStatusID = value;
            NotifyPropertyChanged("InvoiceStatusID");
            }
            get
            {
                if (mInvoiceStatus != null)
                {
                    return mInvoiceStatus.StatusID;
                }
                return mInvoiceStatusID;
            }
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
        //The TermsID (Terms) of the record containing terms information for this RecurringSale entry.
        private int? mTermsID;
        public int? TermsID
        {
            set { mTermsID = value;
            NotifyPropertyChanged("TermsID");
            }
            get
            {
                if (mTerms != null)
                {
                    return mTerms.TermsID;
                }
                return mTermsID;
            }
        }
        private Terms.Terms mTerms;
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

        #region TaxExclusiveFreight
        //The Tax exclusive freight amount applicable to this RecurringSale invoice.
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
        //The Tax inclusive freight amount applicable to this RecurringSale invoice.
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
        //TaxCodeID (TaxCodes) of the record containing the tax code applied against the Freight amount on this RecurringSale invoice.
        private int? mFreightTaxCodeID;
        public int? FreightTaxCodeID
        {
            set { mFreightTaxCodeID = value;
            NotifyPropertyChanged("FreightTaxCodeID");
            }
            get
            {
                if (mFreightTaxCode != null)
                {
                    return mFreightTaxCode.TaxCodeID;
                }
                return mFreightTaxCodeID;
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

        #region InvoiceNumber
        //The RecurringSale invoice number.
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
        //If the RecurringSale invoice was generated through the historical RecurringSale window.
        private string mIsHistorical="N";
        public string IsHistorical
        {
            set { mIsHistorical = value;
            NotifyPropertyChanged("IsHistorical");
            }
            get { return mIsHistorical; }
        }
        #endregion

        #region BackorderRecurringSaleID
        //The set number to which this RecurringSale invoice belongs. Used to link RecurringSale invoices together.
        private int? mBackorderRecurringSaleID;
        public int? BackorderRecurringSaleID
        {
            set { mBackorderRecurringSaleID = value;
            NotifyPropertyChanged("BackorderRecurringSaleID");
            }
            get {
                if (mBackorderRecurringSaleID == -1)
                {
                    return mRecurringSaleID;
                }
                return mBackorderRecurringSaleID; 
            }
        }
        #endregion

        #region Date
        //Date of the RecurringSale invoice entry. To avoid SQL reserved word conflicts, use the InvoiceDate field below.
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
            get { return mInvoiceDate;
            }
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

        

        

       

        #region TotalLines
        //The sum of all tax exclusive line amounts applicable to this RecurringSale invoice.
        private double mTotalLines;
        public double TotalLines
        {
            get { return mTotalLines; }
            set { mTotalLines = value;
            NotifyPropertyChanged("TotalLines");
            }
        }
        #endregion

        

        

        #region TotalTax
        //The total of all tax amounts applicable to this RecurringSale invoice.
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
        //The total of all payments made against this RecurringSale invoice.
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
        //The total of all deposit payments made against a RecurringSale invoice. This field can only have a non-zero balance when the status is pending.
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
        //The total credits applied against this RecurringSale invoice from another RecurringSale invoice, OR The total credits applied from this RecurringSale invoice to another RecurringSale invoice.
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
        //The total amount of discounts applied against this RecurringSale invoice.
        private double mTotalDiscounts;
        public double TotalDiscounts
        {
            set { mTotalDiscounts = value;
            NotifyPropertyChanged("TotalDiscounts");
            }
            get { return mTotalDiscounts;
            
            }
        }
        #endregion

        #region OutstandingBalance
        //The amount still payable on the RecurringSale invoice.
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
        //The CardRecordID (Cards) or EmployeeID (Employees) of the record containing SalesPerson information for this RecurringSale invoiceentry.
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
        //Journal memo of the RecurringSale invoice. 
        private string mMemo = null;
        public string Memo
        {
            get
            {
                if (mMemo == null)
                {
                    return string.Format("purchase; {0}", Customer.Name);
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
        //The Shipping MethodID (ShippingMethods) of the record containing Shipping information for this RecurringSale invoice entry.
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

        #region ReferralSource
        //The ReferralSourceID (ReferralSources) of the record containing referral source for this RecurringSale invoice entry.
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
                NotifyPropertyChanged("ReferralSourceID");
            }
        }
        #endregion

        #region IsTaxInclusive
        //Yes/No flag indicating if the transaction is Tax inclusive. Note: Historical RecurringSales can only be recorded as Tax inclusive. All historical RecurringSales should therefore report as Y.
        private string mIsTaxInclusive = "N";
        public string IsTaxInclusive
        {
            get { return mIsTaxInclusive; }
            set { mIsTaxInclusive = value;
            NotifyPropertyChanged("IsTaxInclusive");
            }
        }
        #endregion

        #region InvoiceDelivery
        //InvoiceDeliveryID (InvoiceDelivery) of the record containing the full Invoice Delivery Status assigned to the RecurringSale.
        private string mInvoiceDeliveryID;
        public string InvoiceDeliveryID
        {
            set { mInvoiceDeliveryID = value;
            NotifyPropertyChanged("InvoiceDeliveryID");
            }
            get
            {
                if (mInvoiceDelivery != null)
                {
                    return mInvoiceDelivery.InvoiceDeliveryID;
                }
                return mInvoiceDeliveryID;
            }
        }
        private Definitions.InvoiceDelivery mInvoiceDelivery;
        public Definitions.InvoiceDelivery InvoiceDelivery
        {
            get
            {
                if (mInvoiceDelivery == null && FromDb)
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

        #region Currency
        private int? mCurrencyID;
        public int? CurrencyID
        {
            get
            {
                if (mCurrency != null)
                {
                    return mCurrency.CurrencyID;
                }
                return mCurrencyID;
            }
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

        #region CostCentreID
        //The CostCentreID assigned to the RecurringSale Invoice.
        private int? mCostCentreID;
        public int? CostCentreID
        {
            set { mCostCentreID = value;
            NotifyPropertyChanged("CostCentreID");
            }
            get { return mCostCentreID; }
        }
        #endregion

        #region -(Object Override Methods)
        public override string ToString()
        {
            return InvoiceNumber;
        }

        public override bool Equals(object obj)
        {
            if(obj is RecurringSale)
            {
                RecurringSale rhs = (RecurringSale)obj;
                if (rhs.FromDb && FromDb)
                {
                    return rhs.RecurringSaleID == RecurringSaleID;
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

        private BindingList<RecurringSaleLine> mRecurringSaleLines = null;
        public BindingList<RecurringSaleLine> RecurringSaleLines
        {
            get
            {
                if (mRecurringSaleLines == null)
                {
                    mRecurringSaleLines = new BindingList<RecurringSaleLine>();
                    if (FromDb)
                    {
                        InvoiceType sale_type = InvoiceType;
                        if (sale_type != null)
                        {
                            if (sale_type.IsItem)
                            {
                                IList<RecurringItemSaleLine> lines = RepositoryMgr.RecurringItemSaleLineMgr.FindCollectionBySaleID(RecurringSaleID);
                                foreach (RecurringItemSaleLine line in lines)
                                {
                                    mRecurringSaleLines.Add(line);
                                }
                            }
                            else if (sale_type.IsProfessional)
                            {
                                IList<RecurringProfessionalSaleLine> lines = RepositoryMgr.RecurringProfessionalSaleLineMgr.FindCollectionBySaleID(RecurringSaleID);
                                foreach (RecurringProfessionalSaleLine line in lines)
                                {
                                    mRecurringSaleLines.Add(line);
                                }
                            }
                            else if (sale_type.IsMisc)
                            {
                                IList<RecurringMiscSaleLine> lines = RepositoryMgr.RecurringMiscSaleLineMgr.FindCollectionBySaleID(RecurringSaleID);
                                foreach (RecurringMiscSaleLine line in lines)
                                {
                                    mRecurringSaleLines.Add(line);
                                }
                            }
                            else if (sale_type.IsService)
                            {
                                IList<RecurringServiceSaleLine> lines = RepositoryMgr.RecurringServiceSaleLineMgr.FindCollectionBySaleID(RecurringSaleID);
                                foreach (RecurringServiceSaleLine line in lines)
                                {
                                    mRecurringSaleLines.Add(line);
                                }
                            }
                            else if (sale_type.IsTimeBilling)
                            {
                                IList<RecurringTimeBillingSaleLine> lines = RepositoryMgr.RecurringTimeBillingSaleLineMgr.FindCollectionBySaleID(RecurringSaleID);
                                foreach (RecurringTimeBillingSaleLine line in lines)
                                {
                                    mRecurringSaleLines.Add(line);
                                }
                            }
                        }
                    }
                    else
                    {

                    }
                }
                return mRecurringSaleLines;
            }
        }

        #region -(Entity Override Methods)
        public override void AssignFrom(Entity rhs)
        {
            base.AssignFrom(rhs);
            //Copy2(rhs);

            RecurringSale _obj = rhs as RecurringSale;
            //this.RecurringSaleID = _obj.RecurringSaleID;

            //RecurringSaleLines.Clear();
            mRecurringSaleLines = new BindingList<RecurringSaleLine>();

            foreach (RecurringSaleLine line in _obj.RecurringSaleLines)
            {
                RecurringSaleLine new_line = line.Clone() as RecurringSaleLine;
                new_line.RecurringSale = this;
                mRecurringSaleLines.Add(new_line);
            }
        }

        //public override void Copy2(Entity rhs)
        //{
        //    base.Copy2(rhs);

        //    RecurringSale _obj = rhs as RecurringSale;

        //    this.BackorderRecurringSaleID=_obj.BackorderRecurringSaleID;
        //    this.CardRecordID = _obj.CardRecordID;
        //    this.Comment = _obj.Comment;
        //    this.CostCentreID = _obj.CostCentreID;
        //    this.Currency = _obj.Currency;
        //    this.CurrencyID = _obj.CurrencyID;
        //    this.Customer = _obj.Customer;
        //    this.CustomerPONumber = _obj.CustomerPONumber;
        //    this.Date = _obj.Date;
        //    this.FreightTaxCode = _obj.FreightTaxCode;
        //    this.FreightTaxCodeID = _obj.FreightTaxCodeID;
        //    this.InvoiceDate = _obj.InvoiceDate;
        //    this.InvoiceDelivery = _obj.InvoiceDelivery;
        //    this.InvoiceDeliveryID = _obj.InvoiceDeliveryID;
        //    this.InvoiceNumber = _obj.InvoiceNumber;
        //    this.InvoiceStatus = _obj.InvoiceStatus;
        //    this.InvoiceStatusID = _obj.InvoiceStatusID;
        //    this.InvoiceType = _obj.InvoiceType;
        //    this.InvoiceTypeID = _obj.InvoiceTypeID;
        //    this.IsHistorical = _obj.IsHistorical;
        //    this.IsTaxInclusive = _obj.IsTaxInclusive;
        //    this.IsThirteenthPeriod = _obj.IsThirteenthPeriod;
        //    this.Memo = _obj.Memo;
        //    this.OutstandingBalance = _obj.OutstandingBalance;
        //    this.ReferralSource = _obj.ReferralSource;
        //    this.ReferralSourceID = _obj.ReferralSourceID;
        //    this.SalesPerson = _obj.SalesPerson;
        //    this.SalesPersonID = _obj.SalesPersonID;
        //    this.ShippingMethod = _obj.ShippingMethod;
        //    this.ShippingMethodID = _obj.ShippingMethodID;
        //    this.ShipToAddress = _obj.ShipToAddress;
        //    this.ShipToAddressLine1 = _obj.ShipToAddressLine1;
        //    this.ShipToAddressLine2 = _obj.ShipToAddressLine2;
        //    this.ShipToAddressLine3 = _obj.ShipToAddressLine3;
        //    this.ShipToAddressLine4 = _obj.ShipToAddressLine4;
        //    this.TaxExclusiveFreight = _obj.TaxExclusiveFreight;
        //    this.TaxInclusiveFreight = _obj.TaxInclusiveFreight;
        //    this.Terms = _obj.Terms;
        //    this.TermsID = _obj.TermsID;
        //    this.TotalDeposits = _obj.TotalDeposits;
        //    this.TotalDiscounts = _obj.TotalDiscounts;
        //    this.TotalLines = _obj.TotalLines;
        //    this.TotalPaid = _obj.TotalPaid;
        //    this.TotalTax = _obj.TotalTax;

        //    foreach (RecurringSaleLine line in _obj.RecurringSaleLines)
        //    {
        //        RecurringSaleLine new_line = line.CloneLine(false);
        //        new_line.RecurringSale = this;
        //        this.RecurringSaleLines.Add(new_line);
        //    }

           
        //}
        #endregion

    }
}
