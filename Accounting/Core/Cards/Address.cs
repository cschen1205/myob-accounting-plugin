using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Cards
{
    public class Address : Entity
    {
        #region +(Constructor)
        internal Address(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {

        }
        #endregion

        

        #region Solutation
        private string mSolutation = "";
        public string Solutation
        {
            get { return mSolutation; }
            set 
            { 
                mSolutation = value;
                NotifyPropertyChanged("Solutation");
            }
        }
        #endregion

        #region Card
        private int? mCardRecordID;
        public int? CardRecordID
        {
            set 
            { 
                mCardRecordID = value;
                NotifyPropertyChanged("CardRecordID");
            }
            get {
                if (Card != null)
                {
                    return Card.CardRecordID;
                }
                return mCardRecordID; }
        }
        private Cards.Card mCard = null;
        public Cards.Card Card
        {
            get
            {
                return mCard;
            }
            set
            {
                mCard = value;
                NotifyPropertyChanged("Card");
            }
        }
        #endregion

        #region Postcode
        private string mPostcode = "";
        public string Postcode
        {
            get { return mPostcode; }
            set 
            {
                mPostcode = value;
                NotifyPropertyChanged("Postcode");
            }
        }
        #endregion

        #region ID
        private int? mAddressID;
        public int? AddressID
        {
            get { return mAddressID; }
            set 
            { 
                mAddressID = value;
                NotifyPropertyChanged("AddressID");
            }
        }
        #endregion

        #region Phone3
        private string mPhone3 = "";
        public string Phone3
        {
            get { return mPhone3; }
            set 
            { 
                mPhone3 = value;
                NotifyPropertyChanged("Phone3");
            }
        }
        #endregion

        #region Fax
        private string mFax = "";
        public string Fax
        {
            get { return mFax; }
            set 
            { 
                mFax = value;
                NotifyPropertyChanged("Fax");
            }
        }
        #endregion

        #region IsValid
        public bool IsValid
        {
            get { return mAddressID != null && mLocation != null; }
        }
        #endregion

        #region IsEmpty
        public bool IsEmpty
        {
            get
            {
                if (mStreetLine1 == "" &&
                    mStreetLine2 == "" &&
                    mStreetLine3 == "" &&
                    mStreetLine4 == "")
                    return true;
                else
                    return false;
            }
        }
        #endregion

        #region Country
        private string mCountry = "";
        public string Country
        {
            get { return mCountry; }
            set 
            { 
                mCountry = value;
                NotifyPropertyChanged("Country");
            }
        }
        #endregion

        #region Addrss.ContactName
        private string mContactPerson = "";
        public string ContactName
        {
            get { return mContactPerson; }
            set 
            { 
                mContactPerson = value;
                NotifyPropertyChanged("ContactName");
            }
        }
        #endregion

        #region City
        private string mCity = "";
        public string City
        {
            get { return mCity; }
            set 
            {
                mCity = value;
                NotifyPropertyChanged("City");
            }
        }
        #endregion

        #region State
        private string mState = "";
        public string State
        {
            get { return mState; }
            set 
            {
                mState = value;
                NotifyPropertyChanged("State");
            }
        }
        #endregion

        #region Phone1
        public string mPhone1 = "";
        public string Phone1
        {
            get { return mPhone1; }
            set 
            {
                mPhone1 = value;
                NotifyPropertyChanged("Phone1");
            }
        }
        #endregion

        #region Phone2
        public string mPhone2 = "";
        public string Phone2
        {
            get { return mPhone2; }
            set 
            { 
                mPhone2 = value;
                NotifyPropertyChanged("Phone2");
            }
        }
        #endregion

        #region Email
        public string mEmail = "";
        public string Email
        {
            get { return mEmail; }
            set 
            { 
                mEmail = value;
                NotifyPropertyChanged("Email");
            }
        }
        #endregion

        #region Website
        private string mWeb = "";
        public string Website
        {
            get { return mWeb; }
            set 
            {
                mWeb = value;
                NotifyPropertyChanged("Website");
            }
        }
        #endregion

        #region Street
        private string mStreet = "";
        public string Street
        {
            get { return mStreet; }
            set 
            { 
                mStreet = value;
                NotifyPropertyChanged("Street");
            }
        }
        #endregion

        #region Location
        private int? mLocation;
        public int? Location
        {
            get { return mLocation; }
            set 
            { 
                mLocation = value;
                NotifyPropertyChanged("Location");
            }
        }
        #endregion

        #region StreetLine
        private string mStreetLine1 = "";
        public string StreetLine1
        {
            get
            {
                return mStreetLine1;
            }
            set
            {
                mStreetLine1 = value;
                NotifyPropertyChanged("StreetLine1");
            }
        }
        #endregion

        #region StreetLine2
        private string mStreetLine2 = "";
        public string StreetLine2
        {
            get
            {
                return mStreetLine2;
            }
            set
            {
                mStreetLine2 = value;
                NotifyPropertyChanged("StreetLine2");
            }
        }
        #endregion

        #region StreetLine3
        private string mStreetLine3 = "";
        public string StreetLine3
        {
            get
            {
                return mStreetLine3;
            }
            set
            {
                mStreetLine3 = value;
                NotifyPropertyChanged("StreetLine3");
            }
        }
        #endregion

        #region StreetLine4
        private string mStreetLine4 = "";
        public string StreetLine4
        {
            get
            {
                return mStreetLine4;
            }
            set
            {
                mStreetLine4 = value;
                NotifyPropertyChanged("StreetLine4");
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override string ToString()
        {
            return string.Format("Address {0}", Location);
        }

        public override bool Equals(object obj)
        {
            if (obj is Address)
            {
                Address _obj = (Address)obj;
                return _obj.AddressID == mAddressID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
