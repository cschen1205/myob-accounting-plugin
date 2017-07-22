using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Cards
{
    using Accounting.Core.Misc;
    public class Card : Entity
    {
        #region Name
        private string mName="";
        public string Name
        {
            get { return mName; }
            set 
            {
                mName = value;
                NotifyPropertyChanged("Name");
            }
        }
        #endregion


        

        #region +(Constructor)
        internal Card(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {

        }
        #endregion

        

        #region CardType
        private string mCardTypeID;
        public string CardTypeID
        {
            get
            {
                if (mCardType != null)
                {
                    return mCardType.CardTypeID;
                }
                return mCardTypeID;
            }
            set
            {
                mCardTypeID = value;
                NotifyPropertyChanged("CardTypeID");
            }
        }

        private CardType mCardType;
        public CardType CardType
        {
            get 
            { 
                if(mCardType==null)
                {
                    mCardType = (CardType)BuildProperty(this, "CardType");
                }
                return mCardType;
            }
            set
            {
                mCardType=value;
                NotifyPropertyChanged("CardType");
            }
        }
        #endregion

        #region CardRecordID
        private int? mCardRecordID;
        public int? CardRecordID
        {
            get 
            {
                return mCardRecordID; 
            }
            set 
            { 
                mCardRecordID = value;
                NotifyPropertyChanged("CardRecordID");
            }
        }
        #endregion

        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("CardRecordID", CardRecordID);
            }
        }

        #region IsInactive
        private string mIsInactive="N";
        public string IsInactive
        {
            get { return mIsInactive; }
            set 
            {
                mIsInactive = value;
                NotifyPropertyChanged("IsInactive");
            }
        }
        public bool Inactive
        {
            get { return mIsInactive == "Y"; }
        }
        #endregion

        #region CardIdentification
        private string mCardIdentification;
        public string CardIdentification
        {
            get { return mCardIdentification; }
            set 
            {
                mCardIdentification = value;
                NotifyPropertyChanged("CardIdentification");
            }
        }
        #endregion

        #region IsIndividual
        private string mIsIndividual="Y";
        public string IsIndividual
        {
            get
            {
                return mIsIndividual;
            }
            set
            {
                mIsIndividual = value;
                NotifyPropertyChanged("IsIndividual");
            }
        }
        #endregion

        #region PaymentDelivery
        private string mPaymentDeliveryID;
        public string PaymentDeliveryID
        {
            get
            {
                if (mPaymentDelivery != null)
                {
                    return mPaymentDelivery.InvoiceDeliveryID;
                }
                return mPaymentDeliveryID;
            }
            set 
            {
                mPaymentDeliveryID = value;
                NotifyPropertyChanged("PaymentDeliveryID");
            }
        }
        private Definitions.InvoiceDelivery mPaymentDelivery;
        public Definitions.InvoiceDelivery PaymentDelivery
        {
            get 
            {
                if (mPaymentDelivery == null)
                {
                    mPaymentDelivery = (Definitions.InvoiceDelivery)BuildProperty(this, "PaymentDelivery");
                }
                return mPaymentDelivery; 
            }
            set
            {
                mPaymentDelivery = value;
                NotifyPropertyChanged("PaymentDelivery");
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override bool Equals(object obj)
        {
            if (obj is Card)
            {
                Card _obj = (Card)obj;
                return _obj.CardRecordID == mCardRecordID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion

        #region Address1
        private Cards.Address mAddress1;
        public Cards.Address Address1
        {
            get
            {
                if (mAddress1 == null)
                {
                    mAddress1 = (Cards.Address)BuildProperty(this, "Address1");
                    if (mAddress1 == null)
                    {
                        mAddress1 = RepositoryMgr.AddressMgr.CreateEntity();
                        mAddress1.Location = 1;
                    }
                    mAddress1.Card = this;
                }
                return mAddress1;
            }
            set
            {
                mAddress1 = value;
                mAddress1.Card = this;
                NotifyPropertyChanged("Address1");
            }
        }
        #endregion

        #region Address2
        private Cards.Address mAddress2;
        public Cards.Address Address2
        {
            get
            {
                if (mAddress2 == null)
                {
                    mAddress2 = (Cards.Address)BuildProperty(this, "Address2");
                    if (mAddress2 == null)
                    {
                        mAddress2 = RepositoryMgr.AddressMgr.CreateEntity();
                        mAddress2.Location = 2;
                    }
                    mAddress2.Card = this;
                }
                return mAddress2;
            }
            set
            {
                mAddress2 = value;
                mAddress2.Card = this;
                NotifyPropertyChanged("Address2");
            }
        }
        #endregion

        #region Address3
        private Cards.Address mAddress3;
        public Cards.Address Address3
        {
            get
            {
                if (mAddress3 == null)
                {
                    mAddress3 = (Cards.Address)BuildProperty(this, "Address3");
                    if (mAddress3 == null)
                    {
                        mAddress3 = RepositoryMgr.AddressMgr.CreateEntity();
                        mAddress3.Location = 3;
                    }
                    mAddress3.Card = this;
                }
                return mAddress3;
            }
            set
            {
                mAddress3 = value;
                mAddress3.Card = this;
                NotifyPropertyChanged("Address3");
            }
        }
        #endregion

        #region Address4
        private Cards.Address mAddress4;
        public Cards.Address Address4
        {
            get
            {
                if (mAddress4 == null)
                {
                    mAddress4 = (Cards.Address)BuildProperty(this, "Address4");
                    if (mAddress4 == null)
                    {
                        mAddress4 = RepositoryMgr.AddressMgr.CreateEntity();
                        mAddress4.Location = 4;
                    }
                    mAddress4.Card = this;
                }
                return mAddress4;
            }
            set
            {
                mAddress4 = value;
                mAddress4.Card = this;
                NotifyPropertyChanged("Address4");
            }
        }
        #endregion

        #region Address5
        private Cards.Address mAddress5;
        public Cards.Address Address5
        {
            get
            {
                if (mAddress5 == null)
                {
                    mAddress5 = (Cards.Address)BuildProperty(this, "Address5");
                    if (mAddress5 == null)
                    {
                        mAddress5 = RepositoryMgr.AddressMgr.CreateEntity();
                        mAddress5.Location = 5;
                    }
                    mAddress5.Card = this;
                }
                return mAddress5;
            }
            set
            {
                mAddress5 = value;
                mAddress5.Card = this;
                NotifyPropertyChanged("Address5");
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
            set 
            {
                mCurrencyID = value;
                NotifyPropertyChanged("CurrencyID");
            }
        }
        Currencies.Currency mCurrency = null;
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

        #region CustomField1
        private string mCustomField1 = "";
        public string CustomField1
        {
            get { return mCustomField1; }
            set 
            { 
                mCustomField1 = value;
                NotifyPropertyChanged("CustomField1");
            }
        }
        #endregion

        #region CustomList1ID
        private CustomList mCustomList1 = null;
        public CustomList CustomList1
        {
            get
            {
                if (mCustomList1 == null)
                {
                    mCustomList1 = (CustomList)BuildProperty(this, "CustomList1");
                }
                return mCustomList1;
            }
            set
            {
                mCustomList1 = value;
                NotifyPropertyChanged("CustomList1");
            }
        }
        private int? mCustomList1ID=null;
        public int? CustomList1ID
        {
            get 
            {
                if (mCustomList1 != null)
                {
                    return mCustomList1.CustomListID;
                }
                return mCustomList1ID; 
            }
            set 
            { 
                mCustomList1ID = value;
                NotifyPropertyChanged("CustomList1ID");
            }
        }
        #endregion

        #region CustomField2
        private string mCustomField2 = "";
        public string CustomField2
        {
            get { return mCustomField2; }
            set 
            { 
                mCustomField2 = value;
                NotifyPropertyChanged("CustomField2");
            }
        }
        #endregion

        #region CustomList2ID
        private CustomList mCustomList2 = null;
        public CustomList CustomList2
        {
            get
            {
                if (mCustomList2 == null)
                {
                    mCustomList2 = (CustomList)BuildProperty(this, "CustomList2");
                }
                return mCustomList2;
            }
            set
            {
                mCustomList2 = value;
                NotifyPropertyChanged("CustomList2");
            }
        }
        private int? mCustomList2ID=null;
        public int? CustomList2ID
        {
            get 
            {
                if (mCustomList2 != null)
                {
                    return mCustomList2.CustomListID;
                }
                return mCustomList2ID; 
            }
            set 
            { 
                mCustomList2ID = value;
                NotifyPropertyChanged("CustomList2ID");
            }
        }
        #endregion

        #region CustomField3
        private string mCustomField3 = "";
        public string CustomField3
        {
            get { return mCustomField3; }
            set 
            { 
                mCustomField3 = value;
                NotifyPropertyChanged("CustomField3");
            }
        }
        #endregion

        #region CustomList3ID
        private CustomList mCustomList3 = null;
        public CustomList CustomList3
        {
            get
            {
                if (mCustomList3 == null)
                {
                    mCustomList3 = (CustomList)BuildProperty(this, "CustomList3");
                }
                return mCustomList3;
            }
            set
            {
                mCustomList3 = value;
                NotifyPropertyChanged("CustomList3");
            }
        }
        private int? mCustomList3ID;
        public int? CustomList3ID
        {
            get
            {
                if (mCustomList3 != null)
                {
                    return mCustomList3.CustomListID;
                }
                return mCustomList3ID; 
            }
            set 
            { 
                mCustomList3ID = value;
                NotifyPropertyChanged("CustomList3ID");
            }
        }
        #endregion
    }
}
