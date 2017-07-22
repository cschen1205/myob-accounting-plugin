using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core
{
    public abstract class RecurringEntity : Entity
    {
        public RecurringEntity(bool fromDb, EntityBuilder eb)
            : base(fromDb, eb)
        {
        }

        public string RecurringName;

        #region Frequency
        private Definitions.Frequency mFrequency = null;
        public Definitions.Frequency Frequency
        {
            get
            {
                if (mFrequency == null) mFrequency = (Definitions.Frequency)BuildProperty(this, "Frequency");
                return mFrequency;
            }
            set
            {
                mFrequency = value;
            }
        }
        private string mFrequencyID;
        public string FrequencyID
        {
            get
            {
                if (mFrequency != null) return mFrequency.FrequencyID;
                return mFrequencyID;
            }
            set
            {
                mFrequencyID = value;
            }
        }
        #endregion

        public DateTime? StartingOn;

        public DateTime? NextDue;

        public DateTime? RepeatedOn;

        #region Schedule
        private Definitions.Schedule mSchedule = null;
        public Definitions.Schedule Schedule
        {
            get
            {
                if (mSchedule == null) mSchedule = (Definitions.Schedule)BuildProperty(this, "Schedule");
                return mSchedule;
            }
            set
            {
                mSchedule = value;
            }
        }
        private string mScheduleID;
        public string ScheduleID
        {
            get
            {
                if (mSchedule != null) return mSchedule.ScheduleID;
                return mScheduleID;
            }
            set
            {
                mScheduleID = value;
            }
        }
        #endregion

        public DateTime? ContinueUntil;

        public int? PerformTimes;

        public int? RemainingTime;

        #region Alert
        private Definitions.Alert mAlert = null;
        public Definitions.Alert Alert
        {
            get
            {
                if (mAlert == null) mAlert = (Definitions.Alert)BuildProperty(this, "Alert");
                return mAlert;
            }
            set
            {
                mAlert = value;
            }
        }
        private string mAlertID;
        public string AlertID
        {
            get
            {
                if (mAlert != null) return mAlert.AlertID;
                return mAlertID;
            }
            set
            {
                mAlertID = value;
            }
        }
        #endregion

        #region AlertUser
        private Security.AuthUser mAlertUser = null;
        public Security.AuthUser AlertUser
        {
            get
            {
                if (mAlertUser == null) mAlertUser = (Security.AuthUser)BuildProperty(this, "AlertUser");
                return mAlertUser;
            }
            set
            {
                mAlertUser = value;
            }
        }
        private int? mAlertUserID;
        public int? AlertUserID
        {
            get
            {
                if (mAlertUser != null) return mAlertUser.UserID;
                return mAlertUserID;
            }
            set
            {
                mAlertUserID = value;
            }
        }
        #endregion

        #region AlertType
        private Definitions.AlertType mAlertType = null;
        public Definitions.AlertType AlertType
        {
            get
            {
                if (mAlertType == null) mAlertType = (Definitions.AlertType)BuildProperty(this, "AlertType");
                return mAlertType;
            }
            set
            {
                mAlertType = value;
            }
        }
        private string mAlertTypeID;
        public string AlertTypeID
        {
            get
            {
                if (mAlertType != null) return mAlertType.AlertTypeID;
                return mAlertTypeID;
            }
            set
            {
                mAlertTypeID = value;
            }
        }
        #endregion

        public int? DaysInAdvance;

        public string AppliedNumber;

        public string RetainChanges="N";

        public DateTime? LastPosted;
    }
}
