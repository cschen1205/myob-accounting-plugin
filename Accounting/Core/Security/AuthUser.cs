using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Security
{
    public class AuthUser : Entity
    {
        internal AuthUser(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        public override string ToString()
        {
            return Username;
        }

        public override bool Equals(object obj)
        {
            if (obj is AuthUser)
            {
                AuthUser _obj = obj as AuthUser;
                if (_obj.Username.Equals(Username))
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

     

        private int? mAuthUserID;
        public int? UserID
        {
            get { return mAuthUserID; }
            set
            {
                mAuthUserID = value;
                NotifyPropertyChanged("UserID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("UserID", UserID);
            }
        }

        private string mAuthUsername="";
        public string Username
        {
            get { return mAuthUsername; }
            set 
            {
                mAuthUsername = value;
                NotifyPropertyChanged("Username");
            }
        }

        private string mAuthPassword="";
        public string Password
        {
            get 
            {
                return mAuthPassword;
            }
            set 
            {
                mAuthPassword = value;
                NotifyPropertyChanged("Password");
            }
        }

        private string mDescription = "";
        public string Description
        {
            get { return mDescription; }
            set 
            {
                mDescription = value;
                NotifyPropertyChanged("Description");
            }
        }

        private int? mRoleID;
        public int? RoleID
        {
            get
            {
                if (mRole != null)
                {
                    return mRole.RoleID;
                }
                return mRoleID;
            }
            set
            {
                mRoleID = value;
                NotifyPropertyChanged("RoleID");
            }
        }

        private AuthRole mRole=null;
        public AuthRole Role
        {
            get
            {
                if (mRole == null)
                {
                    mRole = (AuthRole)BuildProperty(this, "Role");
                }
                return mRole;
            }
            set
            {
                mRole = value;
                NotifyPropertyChanged("Role");
            }
        }

        private string mUseTimeslipsLink = "N";
        public string UseTimeslipsLink
        {
            get { return mUseTimeslipsLink; }
            set
            {
                mUseTimeslipsLink = value;
                NotifyPropertyChanged("UseTimeslipsLink");
            }
        }

        private string mUseBillingUnits = "N";
        public string UseBillingUnits
        {
            get { return mUseBillingUnits; }
            set
            {
                mUseBillingUnits = value;
                NotifyPropertyChanged("UseBillingUnits");
            }
        }

        public int? mBillingUnit= 30;
        public int? BillingUnit
        {
            get { return mBillingUnit; }
            set
            {
                mBillingUnit = value;
                NotifyPropertyChanged("BillingUnit");
            }
        }

        private string mRoundCalculatedTime = "N";
        public string RoundCalculatedTime
        {
            get { return mRoundCalculatedTime; }
            set
            {
                mRoundCalculatedTime = value;
                NotifyPropertyChanged("RoundCalculatedTime");
            }
        }

        private string mRoundToID = "";
        public string RoundToID
        {
            get { return mRoundToID; }
            set
            {
                mRoundToID = value;
                NotifyPropertyChanged("RoundToID");
            }
        }

        private int? mMinuteIncrement;
        public int? MinuteIncrement
        {
            get { return mMinuteIncrement; }
            set
            {
                mMinuteIncrement = value;
                NotifyPropertyChanged("MinuteIncrement");
            }
        }

        private string mIncludeItemsInTimeBilling = "N";
        public string IncludeItemsInTimeBilling
        {
            get { return mIncludeItemsInTimeBilling; }
            set
            {
                mIncludeItemsInTimeBilling = value;
                NotifyPropertyChanged("IncludeItemsInTimeBilling");
            }
        }
    }

}
