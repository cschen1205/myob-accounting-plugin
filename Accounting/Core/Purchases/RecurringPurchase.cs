using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Purchases
{
    using System.ComponentModel;
    using Accounting.Core.Definitions;

    public class RecurringPurchase : RecurringEntity
    {
        #region -(Constructor)
        internal RecurringPurchase(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        

        #region RecurringPurchaseID
        private int? mRecurringPurchaseID;
        public int? RecurringPurchaseID
        {
            set { mRecurringPurchaseID = value;
            NotifyPropertyChanged("RecurringPurchaseID");
            }
            get { return mRecurringPurchaseID; }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("RecurringPurchaseID", RecurringPurchaseID);
            }
        }

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
            set { mTaxExclusiveFreight = value;
            NotifyPropertyChanged("TaxExclusiveFreight");
            }
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

        #region Memo
        private string mMemo = "";
        public string Memo
        {
            get { return mMemo;  }
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

        #region IsTaxInclusive
        private string mIsTaxInclusive="N";
        public string IsTaxInclusive
        {
            get { return mIsTaxInclusive; }
            set { mIsTaxInclusive = value;
            NotifyPropertyChanged("IsTaxInclusive");
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
        

        #region -(Object Override Methods)
        public override bool Equals(object obj)
        {
            if (obj is RecurringPurchase)
            {
                RecurringPurchase _obj = (RecurringPurchase)obj;
                return _obj.RecurringPurchaseID == mRecurringPurchaseID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "";
        }
        #endregion

        private BindingList<RecurringPurchaseLine> mRecurringPurchaseLines = null;
        public BindingList<RecurringPurchaseLine> RecurringPurchaseLines
        {
            get
            {
                if (mRecurringPurchaseLines == null)
                {
                    mRecurringPurchaseLines = new BindingList<RecurringPurchaseLine>();
                    if (FromDb)
                    {
                        InvoiceType sale_type = PurchaseType;
                        if (sale_type != null)
                        {
                            if (sale_type.IsItem)
                            {
                                IList<RecurringItemPurchaseLine> lines = RepositoryMgr.RecurringItemPurchaseLineMgr.FindCollectionByPurchaseID(RecurringPurchaseID);
                                foreach (RecurringItemPurchaseLine line in lines)
                                {
                                    mRecurringPurchaseLines.Add(line);
                                }
                            }
                            else if (sale_type.IsProfessional)
                            {
                                IList<RecurringProfessionalPurchaseLine> lines = RepositoryMgr.RecurringProfessionalPurchaseLineMgr.FindCollectionByPurchaseID(RecurringPurchaseID);
                                foreach (RecurringProfessionalPurchaseLine line in lines)
                                {
                                    mRecurringPurchaseLines.Add(line);
                                }
                            }
                            else if (sale_type.IsMisc)
                            {
                                IList<RecurringMiscPurchaseLine> lines = RepositoryMgr.RecurringMiscPurchaseLineMgr.FindCollectionByPurchaseID(RecurringPurchaseID);
                                foreach (RecurringMiscPurchaseLine line in lines)
                                {
                                    mRecurringPurchaseLines.Add(line);
                                }
                            }
                            else if (sale_type.IsService)
                            {
                                IList<RecurringServicePurchaseLine> lines = RepositoryMgr.RecurringServicePurchaseLineMgr.FindCollectionByPurchaseID(RecurringPurchaseID);
                                foreach (RecurringServicePurchaseLine line in lines)
                                {
                                    mRecurringPurchaseLines.Add(line);
                                }
                            }
                            else if (sale_type.IsTimeBilling)
                            {
                                IList<RecurringTimeBillingPurchaseLine> lines = RepositoryMgr.RecurringTimeBillingPurchaseLineMgr.FindCollectionByPurchaseID(RecurringPurchaseID);
                                foreach (RecurringTimeBillingPurchaseLine line in lines)
                                {
                                    mRecurringPurchaseLines.Add(line);
                                }
                            }
                        }
                    }
                    else
                    {

                    }
                }
                return mRecurringPurchaseLines;
            }
        }

        #region -(Entity Override Methods)
        public override void AssignFrom(Entity rhs)
        {
            base.AssignFrom(rhs);

            //Copy2(rhs);
            RecurringPurchase _obj = rhs as RecurringPurchase;
            //this.RecurringPurchaseID = _obj.RecurringPurchaseID;

            //RecurringPurchaseLines.Clear();
            mRecurringPurchaseLines = new BindingList<RecurringPurchaseLine>();

            foreach (RecurringPurchaseLine line in _obj.RecurringPurchaseLines)
            {
                RecurringPurchaseLine new_line = line.Clone() as RecurringPurchaseLine;
                new_line.RecurringPurchase = this;
                mRecurringPurchaseLines.Add(new_line);
            }
        }
        //public override void Copy2(Entity rhs)
        //{
        //    base.Copy2(rhs);

        //    RecurringPurchase _obj = rhs as RecurringPurchase;

        //    this.CardRecordID = _obj.CardRecordID;
        //    this.Comment = _obj.Comment;
        //    this.CostCentreID = _obj.CostCentreID;
        //    this.Currency = _obj.Currency;
        //    this.CurrencyID = _obj.CurrencyID;
        //    this.FreightTaxCode = _obj.FreightTaxCode;
        //    this.FreightTaxCodeID = _obj.FreightTaxCodeID;
        //    this.InvoiceDelivery = _obj.InvoiceDelivery;
        //    this.InvoiceDeliveryID = _obj.InvoiceDeliveryID;
           
        //    this.IsTaxInclusive = _obj.IsTaxInclusive;
            
        //    this.Memo = _obj.Memo;
           
        //    this.PurchaseStatus = _obj.PurchaseStatus;
        //    this.PurchaseStatusID = _obj.PurchaseStatusID;
        //    this.PurchaseType = _obj.PurchaseType;
        //    this.PurchaseTypeID = _obj.PurchaseTypeID;
           
        //    this.ShippingMethod = _obj.ShippingMethod;
        //    this.ShippingMethodID = _obj.ShippingMethodID;
        //    this.ShipToAddress = _obj.ShipToAddress;
        //    this.ShipToAddressLine1 = _obj.ShipToAddressLine1;
        //    this.ShipToAddressLine2 = _obj.ShipToAddressLine2;
        //    this.ShipToAddressLine3 = _obj.ShipToAddressLine3;
        //    this.ShipToAddressLine4 = _obj.ShipToAddressLine4;
        //    this.Supplier = _obj.Supplier;
           
        //    this.TaxExclusiveFreight = _obj.TaxExclusiveFreight;
        //    this.TaxInclusiveFreight = _obj.TaxInclusiveFreight;
        //    this.Terms = _obj.Terms;
        //    this.TermsID = _obj.TermsID;


        //    RecurringPurchaseLines.Clear();

        //    foreach (RecurringPurchaseLine line in _obj.RecurringPurchaseLines)
        //    {
        //        RecurringPurchaseLine new_line = line.CloneLine(false);
        //        new_line.RecurringPurchase = this;
        //        this.RecurringPurchaseLines.Add(new_line);
        //    }
        //}
        #endregion
    }
}
