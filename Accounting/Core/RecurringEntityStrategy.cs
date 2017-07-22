using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core
{
    public class RecurringEntityStrategy
    {
        private DbManager mDbMgr = null;
        protected DbManager DbMgr
        {
            get
            {
                return mDbMgr;
            }
        }

        protected RepositoryManager RepositoryMgr
        {
            get { return mDbMgr.RepositoryMgr; }
        }

        public RecurringEntityStrategy(DbManager mgr)
        {
            mDbMgr = mgr;
        }

        public virtual void LoadFromReader(RecurringEntity _obj, DbDataReader _reader)
        {
            _obj.AlertID = DbMgr.GetString(_reader, "AlertID");
            _obj.AlertTypeID = DbMgr.GetString(_reader, "AlertTypeID");
            _obj.AlertUserID = DbMgr.GetInt32(_reader, "AlertUserID");
            _obj.AppliedNumber = DbMgr.GetString(_reader, "AppliedNumber");
            _obj.ContinueUntil = DbMgr.GetDateTime(_reader, "ContinueUntil");
            _obj.DaysInAdvance = DbMgr.GetInt32(_reader, "DaysInAdvance");
            _obj.FrequencyID = DbMgr.GetString(_reader, "FrequencyID");
            _obj.LastPosted = DbMgr.GetDateTime(_reader, "LastPosted");
            _obj.NextDue = DbMgr.GetDateTime(_reader, "NextDue");
            _obj.PerformTimes = DbMgr.GetInt32(_reader, "PerformTimes");
            _obj.RecurringName = DbMgr.GetString(_reader, "RecurringName");
            _obj.RemainingTime = DbMgr.GetInt32(_reader, "RemainingTime");
            _obj.RepeatedOn = DbMgr.GetDateTime(_reader, "RepeatedOn");
            _obj.RetainChanges = DbMgr.GetString(_reader, "RetainChanges");
            _obj.ScheduleID = DbMgr.GetString(_reader, "ScheduleID");
            _obj.StartingOn = DbMgr.GetDateTime(_reader, "StartingOn");
        }

        public virtual Dictionary<string, DbFieldEntry> GetFields(RecurringEntity _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AlertID"] = DbMgr.CreateStringFieldEntry(_obj.AlertID); //DbMgr.GetString(_reader, "AlertID");
            fields["AlertTypeID"] = DbMgr.CreateStringFieldEntry(_obj.AlertTypeID); //DbMgr.GetString(_reader, "AlertTypeID");
            fields["AlertUserID"] = DbMgr.CreateIntFieldEntry(_obj.AlertUserID); //DbMgr.GetInt32(_reader, "AlertUserID");
            fields["AppliedNumber"] = DbMgr.CreateStringFieldEntry(_obj.AppliedNumber); //DbMgr.GetString(_reader, "AppliedNumber");
            fields["ContinueUntil"] = DbMgr.CreateDateTimeFieldEntry(_obj.ContinueUntil); //DbMgr.GetDateTime(_reader, "ContinueUntil");
            fields["DaysInAdvance"] = DbMgr.CreateIntFieldEntry(_obj.DaysInAdvance); //DbMgr.GetInt32(_reader, "DaysInAdvance");
            fields["FrequencyID"] = DbMgr.CreateStringFieldEntry(_obj.FrequencyID); //DbMgr.GetString(_reader, "FrequencyID");
            fields["LastPosted"] = DbMgr.CreateDateTimeFieldEntry(_obj.LastPosted); //DbMgr.GetDateTime(_reader, "LastPosted");
            fields["NextDue"] = DbMgr.CreateDateTimeFieldEntry(_obj.NextDue); //DbMgr.GetDateTime(_reader, "NextDue");
            fields["PerformTimes"] = DbMgr.CreateIntFieldEntry(_obj.PerformTimes); //DbMgr.GetInt32(_reader, "PerformTimes");
            fields["RecurringName"] = DbMgr.CreateStringFieldEntry(_obj.RecurringName); //DbMgr.GetString(_reader, "RecurringName");
            fields["RemainingTime"] = DbMgr.CreateIntFieldEntry(_obj.RemainingTime); //DbMgr.GetInt32(_reader, "RemainingTime");
            fields["RepeatedOn"] = DbMgr.CreateDateTimeFieldEntry(_obj.RepeatedOn); //DbMgr.GetDateTime(_reader, "RepeatedOn");
            fields["RetainChanges"] = DbMgr.CreateStringFieldEntry(_obj.RetainChanges); //DbMgr.GetString(_reader, "RetainChanges");
            fields["ScheduleID"] = DbMgr.CreateStringFieldEntry(_obj.ScheduleID); //DbMgr.GetString(_reader, "ScheduleID");
            fields["StartingOn"] = DbMgr.CreateDateTimeFieldEntry(_obj.StartingOn); //DbMgr.GetDateTime(_reader, "StartingOn");

            return fields;
        }

        public virtual object GetDbProperty(RecurringEntity _obj, string property_name)
        {
            if (property_name.Equals("Frequency"))
            {
                return RepositoryMgr.FrequencyMgr.FindById(_obj.FrequencyID);
            }
            else if (property_name.Equals("Schedule"))
            {
                return RepositoryMgr.ScheduleMgr.FindById(_obj.ScheduleID);
            }
            else if (property_name.Equals("Alert"))
            {
                return RepositoryMgr.AlertMgr.FindById(_obj.AlertID);
            }
            else if (property_name.Equals("AlertUser"))
            {
                return RepositoryMgr.AuthUserMgr.FindByUserID(_obj.AlertUserID);
            }
            else if (property_name.Equals("AlertType"))
            {
                return RepositoryMgr.AlertTypeMgr.FindById(_obj.AlertTypeID);
            }

            return null;
        }
    }
}
