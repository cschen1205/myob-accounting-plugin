using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Activities
{
    public abstract class ActivitySlipManager : EntityManager<ActivitySlip>
    {
        public ActivitySlipManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override ActivitySlip _CreateDbEntity()
        {
            return new ActivitySlip(true, this);
        }
        protected override ActivitySlip _CreateEntity()
        {
            return new ActivitySlip(false, this);
        }
        #endregion

        protected override void LoadFromReader(ActivitySlip _obj, DbDataReader reader)
        {
            _obj.ActivityDate = GetDateTime(reader, "ActivityDate");
            _obj.ActivityID = GetInt32(reader, "ActivityID");
            _obj.ActivitySlipID = GetInt32(reader, "ActivitySlipID");
            _obj.ActivitySlipNumber = GetString(reader, "ActivitySlipNumber");
            _obj.AdjustmentAmount = GetDouble(reader, "AdjustmentAmount");
            _obj.AdjustmentUnits = GetDouble(reader, "AdjustmentUnits");
            _obj.AlreadyBilledAmount = GetDouble(reader, "AlreadyBilledAmount");
            _obj.AlreadyBilledUnits = GetDouble(reader, "AlreadyBilledUnits");
            _obj.CardTypeID = GetString(reader, "CardTypeID");
            _obj.CustomerID = GetInt32(reader, "CustomerID");
            _obj.Date = _obj.ActivityDate;
            _obj.ElapsedTime = GetInt32(reader, "ElapsedTime");
            _obj.EmployeeSupplierID = GetInt32(reader, "EmployeeSupplierID");
            _obj.IncludeInPayroll = GetString(reader, "IncludeInPayroll");
            _obj.JobID = GetInt32(reader, "JobID");
            _obj.JournalRecordID = GetInt32(reader, "JournalRecordID");
            _obj.Notes = GetString(reader, "Notes");
            _obj.PayrollStatusID = GetString(reader, "PayrollStatusID");
            _obj.Rate = GetDouble(reader, "Rate");
            _obj.SetID = GetInt32(reader, "SetID");
            _obj.SlipStatusID = GetString(reader, "SlipStatusID");
            _obj.StartTime = GetString(reader, "StartTime");
            _obj.StopTime = GetString(reader, "StopTime");
            _obj.Units = GetDouble(reader, "Units");
            _obj.WagesID = GetInt32(reader, "WagesID", "WageID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ActivitySlip _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ActivityDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.ActivityDate); //GetDateTime(reader, "");
            fields["ActivityID"] = DbMgr.CreateIntFieldEntry(_obj.ActivityID); //GetInt32(reader, "");
            fields["ActivitySlipID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ActivitySlipID); //GetInt32(reader, "");
            fields["ActivitySlipNumber"] = DbMgr.CreateStringFieldEntry(_obj.ActivitySlipNumber); //GetString(reader, "");
            fields["AdjustmentAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.AdjustmentAmount); //GetDouble(reader, "");
            fields["AdjustmentUnits"] = DbMgr.CreateDoubleFieldEntry(_obj.AdjustmentUnits); //GetDouble(reader, "");
            fields["AlreadyBilledAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.AlreadyBilledAmount); //GetDouble(reader, "");
            fields["AlreadyBilledUnits"] = DbMgr.CreateDoubleFieldEntry(_obj.AlreadyBilledUnits); //GetDouble(reader, "");
            fields["CardTypeID"] = DbMgr.CreateStringFieldEntry(_obj.CardTypeID); //GetString(reader, "");
            fields["CustomerID"] = DbMgr.CreateIntFieldEntry(_obj.CustomerID); //GetInt32(reader, "");
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date); //fields[""]=DbMgr.CreateIntFieldEntry(_obj.ActivityDate;
            fields["ElapsedTime"] = DbMgr.CreateIntFieldEntry(_obj.ElapsedTime); //GetInt32(reader, "");
            fields["EmployeeSupplierID"] = DbMgr.CreateIntFieldEntry(_obj.EmployeeSupplierID); //GetInt32(reader, "");
            fields["IncludeInPayroll"] = DbMgr.CreateStringFieldEntry(_obj.IncludeInPayroll); //GetString(reader, "");
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID); //GetInt32(reader, "");
            fields["JournalRecordID"] = DbMgr.CreateIntFieldEntry(_obj.JournalRecordID); //GetInt32(reader, "");
            fields["Notes"] = DbMgr.CreateStringFieldEntry(_obj.Notes); //GetString(reader, "");
            fields["PayrollStatusID"] = DbMgr.CreateStringFieldEntry(_obj.PayrollStatusID); //GetString(reader, "");
            fields["Rate"] = DbMgr.CreateDoubleFieldEntry(_obj.Rate); //GetDouble(reader, "");
            fields["SetID"] = DbMgr.CreateIntFieldEntry(_obj.SetID); //GetInt32(reader, "");
            fields["SlipStatusID"] = DbMgr.CreateStringFieldEntry(_obj.SlipStatusID); //GetString(reader, "");
            fields["StartTime"] = DbMgr.CreateStringFieldEntry(_obj.StartTime); //GetString(reader, "");
            fields["StopTime"] = DbMgr.CreateStringFieldEntry(_obj.StopTime); //GetString(reader, "");
            fields["Units"] = DbMgr.CreateDoubleFieldEntry(_obj.Units); //GetDouble(reader, "");
            fields["WagesID"] = DbMgr.CreateIntFieldEntry(_obj.WagesID); //GetInt32(reader, "");

            return fields;
        }

        protected override object GetDbProperty(ActivitySlip _obj, string property_name)
        {
            if (property_name.Equals("Activity"))
            {
                return RepositoryMgr.ActivityMgr.FindById(_obj.ActivityID);
            }
            else if (property_name.Equals("EmployeeSupplier"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.EmployeeSupplierID, true);
            }
            else if (property_name.Equals("CardType"))
            {
                return RepositoryMgr.CardTypeMgr.FindById(_obj.CardTypeID);
            }
            else if (property_name.Equals("Customer"))
            {
                return RepositoryMgr.CustomerMgr.FindById(_obj.CustomerID);
            }
            else if (property_name.Equals("Job"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            else if (property_name.Equals("SlipStatus"))
            {
                return RepositoryMgr.StatusMgr.FindById(_obj.SlipStatusID);
            }
            else if (property_name.Equals("Wage"))
            {
                return RepositoryMgr.WageMgr.FindById(_obj.WagesID);
            }
            else if (property_name.Equals("JournalRecord"))
            {
                return RepositoryMgr.JournalRecordMgr.FindById(_obj.JournalRecordID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("ActivitySlips");
        }

        private DbSelectStatement GetQuery_SelectByActivitySlipID(int ActivitySlipID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("ActivitySlips")
                .Criteria
                    .IsEqual("ActivitySlips", "ActivitySlipID", ActivitySlipID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByActivitySlipID(int ActivitySlipID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("ActivitySlips")
                .Criteria
                    .IsEqual("ActivitySlips", "ActivitySlipID", ActivitySlipID);

            return clause;
        }

        public bool Exists(int? ActivitySlipID)
        {
            if (ActivitySlipID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByActivitySlipID(ActivitySlipID.Value)) != 0;
        }

        public override bool Exists(ActivitySlip _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.ActivitySlipID);
        }

        protected override ActivitySlip _FindByIntId(int? ActivitySlipID)
        {
            if (ActivitySlipID == null) return null;

            ActivitySlip _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByActivitySlipID(ActivitySlipID.Value));
            DbDataReader _reader = _cmd.ExecuteReader();

            if (_reader.Read())
            {
                _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
            }

            _reader.Close();
            _cmd.Dispose();

            return _obj;
        }

        protected override IList<ActivitySlip>_FindAllCollection()
        {
            List<ActivitySlip> _grp = new List<ActivitySlip>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                ActivitySlip _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

    }
}
