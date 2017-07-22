using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Inventory
{
    public class Location : Entity
    {
        #region -(Constructor)
        internal Location(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }
        #endregion

        

        #region LocationID
        private int? mLocationID;
        public int? LocationID
        {
            get { return mLocationID; }
            set 
            {
                mLocationID = value;
                NotifyPropertyChanged("LocationID");
            }
        }
        #endregion


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("LocationID", LocationID);
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
        #endregion

        #region CanBeSold
        private string mCanBeSold;
        public string CanBeSold
        {
            get { return mCanBeSold; }
            set 
            {
                mCanBeSold = value;
                NotifyPropertyChanged("CanBeSold");
            }
        }
        #endregion

        #region LocationIdentification
        private string mLocationIdentification;
        public string LocationIdentification
        {
            get { return mLocationIdentification; }
            set 
            {
                mLocationIdentification = value;
                NotifyPropertyChanged("LocationIdentification");
            }
        }
        #endregion

        #region LocationName
        private string mLocationName;
        public string LocationName
        {
            get { return mLocationName; }
            set 
            {
                mLocationName = value;
                NotifyPropertyChanged("LocationName");
            }
        }
        #endregion

        #region Street
        private string mStreet;
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

        #region City
        private string mCity;
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
        private string mState;
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

        #region Postcode
        private string mPostcode;
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

        #region Country
        private string mCountry;
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

        #region Contact
        private string mContact;
        public string Contact
        {
            get { return mContact; }
            set 
            {
                mContact = value;
                NotifyPropertyChanged("Contact");
            }
        }
        #endregion

        #region ContactPhone
        private string mContactPhone;
        public string ContactPhone
        {
            get { return mContactPhone; }
            set 
            {
                mContactPhone = value;
                NotifyPropertyChanged("ContactPhone");
            }
        }
        #endregion

        #region Notes
        private string mNotes;
        public string Notes
        {
            get { return mNotes; }
            set 
            {
                mNotes = value;
                NotifyPropertyChanged("Notes");
            }
        }
        #endregion

        #region -(Object Override Methods)
        public override bool Equals(object obj)
        {
            if (obj is Location)
            {
                Location _obj = (Location)obj;
                return _obj.LocationID == mLocationID;
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
