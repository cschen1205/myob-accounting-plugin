using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core.Misc
{
    public class AuditTrail : Entity
    {
        internal AuditTrail(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        

        private int? mAuditTrailID;
        public int? AuditTrailID
        {
            get { return mAuditTrailID; }
            set
            {
                mAuditTrailID = value;
                NotifyPropertyChanged("AuditTrailID");
            }
        }


        public override RecordKeyInt IntId
        {
            get
            {
                return new RecordKeyInt("AuditTrailID", AuditTrailID);
            }
        }

        private string mAuditTypeID = "";
        public string AuditTypeID
        {
            get { return mAuditTypeID; }
            set
            {
                mAuditTypeID = value;
                NotifyPropertyChanged("AuditTypeID");
            }
        }

        private string mTransactionNumber = "";
        public string TransactionNumber
        {
            get { return mTransactionNumber; }
            set
            {
                mTransactionNumber = value;
                NotifyPropertyChanged("TransactionNumber");
            }
        }

        private DateTime? mChangeDate;
        public DateTime? ChangeDate
        {
            get { return mChangeDate; }
            set
            {
                mChangeDate = value;
                NotifyPropertyChanged("ChangeDate");
            }
        }

        private DateTime? mOriginalDate;
        public DateTime? OriginalDate
        {
            get { return mOriginalDate; }
            set
            {
                mOriginalDate = value;
                NotifyPropertyChanged("OriginalDate");
            }
        }

        private string mWasThirteenthPeriod = "N";
        public string WasThirteenthPeriod
        {
            get { return mWasThirteenthPeriod; }
            set
            {
                mWasThirteenthPeriod = value;
                NotifyPropertyChanged("WasThirteenthPeriod");
            }
        }

        private string mIsReconciled = "N";
        public string IsReconciled
        {
            get { return mIsReconciled; }
            set
            {
                mIsReconciled = value;
                NotifyPropertyChanged("IsReconciled");
            }
        }

        #region User
        private Security.AuthUser mUser = null;
        public Security.AuthUser User
        {
            get
            {
                if (mUser == null) mUser = (Security.AuthUser)BuildProperty(this, "User");
                return mUser;
            }
            set
            {
                mUser = value;
                NotifyPropertyChanged("User");
            }
        }
        public int? mUserID;
        public int? UserID
        {
            get
            {
                if (mUser != null) return mUser.UserID;
                return mUserID;
            }
            set
            {
                mUserID = value;
                NotifyPropertyChanged("UserID");
            }
        }

        #endregion

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
    }
}
