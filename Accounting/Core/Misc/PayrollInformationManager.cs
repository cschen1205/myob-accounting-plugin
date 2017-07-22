using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Misc
{
    public abstract class PayrollInformationManager : EntityManager<PayrollInformation>
    {
        public PayrollInformationManager(DbManager mgr)
            : base(mgr)
        {
        }

        protected override PayrollInformation _CreateDbEntity()
        {
            return new PayrollInformation(true, this);
        }
        protected override PayrollInformation _CreateEntity()
        {
            return new PayrollInformation(false, this);
        }

        protected override void LoadFromReader(PayrollInformation _obj, DbDataReader reader)
        {
            _obj.BaseHourlyWageID = GetInt32(reader, "BaseHourlyWageID");
            _obj.BaseSalaryWageID = GetInt32(reader, "BaseSalaryWageID");
            _obj.CurrentPayrollYear = GetInt32(reader, "CurrentPayrollYear");
            _obj.DefaultSuperannuationFundID = GetInt32(reader, "DefaultSuperannuationFundID");
            _obj.HoursInWorkWeek = GetDouble(reader, "HoursInWorkWeek");
            _obj.IncludeTimeBillingInTimesheets = GetString(reader, "IncludeTimeBillingInTimesheets");
            _obj.PayrollInformationID = GetInt32(reader, "PayrollInformationID");
            _obj.RoundNetPayTo = GetInt32(reader, "RoundNetPayTo");
            _obj.TaxTableRevisionDate = GetDateTime(reader, "TaxTableRevisionDate");
            _obj.TimesheetWeekStartID = GetString(reader, "TimesheetWeekStartID");
            _obj.UseTimesheets = GetString(reader, "UseTimesheets");
            _obj.WithholderPayerNumber = GetString(reader, "WithholderPayerNumber");
        }

        protected override object GetDbProperty(PayrollInformation _obj, string property_name)
        {
            if (property_name.Equals("BaseSalaryWage"))
            {
                return RepositoryMgr.WageMgr.FindById(_obj.BaseSalaryWageID);
            }
            else if (property_name.Equals("BaseHourlyWage"))
            {
                return RepositoryMgr.WageMgr.FindById(_obj.BaseHourlyWageID);
            }
            else if (property_name.Equals("TimesheetWeekStart"))
            {
                return RepositoryMgr.DayNameMgr.FindById(_obj.TimesheetWeekStartID);
            }
            else if (property_name.Equals("DefaultSuperannuationFund"))
            {
                return RepositoryMgr.SuperannuationFundMgr.FindById(_obj.DefaultSuperannuationFundID);
            }

            return null;
        }

        public override Dictionary<string, DbFieldEntry> GetFields(PayrollInformation _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["BaseHourlyWageID"] = DbMgr.CreateIntFieldEntry(_obj.BaseHourlyWageID); //GetInt32(reader, "BaseHourlyWageID");
            fields["BaseSalaryWageID"] = DbMgr.CreateIntFieldEntry(_obj.BaseSalaryWageID); //GetInt32(reader, "BaseSalaryWageID");
            fields["CurrentPayrollYear"] = DbMgr.CreateIntFieldEntry(_obj.CurrentPayrollYear); //GetInt32(reader, "CurrentPayrollYear");
            fields["DefaultSuperannuationFundID"] = DbMgr.CreateIntFieldEntry(_obj.DefaultSuperannuationFundID); //GetInt32(reader, "DefaultSuperannuationFundID");
            fields["HoursInWorkWeek"] = DbMgr.CreateDoubleFieldEntry(_obj.HoursInWorkWeek); //GetDouble(reader, "HoursInWorkWeek");
            fields["IncludeTimeBillingInTimesheets"] = DbMgr.CreateStringFieldEntry(_obj.IncludeTimeBillingInTimesheets); //GetString(reader, "IncludeTimeBillingInTimesheets");
            fields["PayrollInformationID"] = DbMgr.CreateAutoIntFieldEntry(_obj.PayrollInformationID); //GetInt32(reader, "PayrollInformationID");
            fields["RoundNetPayTo"] = DbMgr.CreateIntFieldEntry(_obj.RoundNetPayTo); //GetInt32(reader, "RoundNetPayTo");
            fields["TaxTableRevisionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TaxTableRevisionDate); //GetDateTime(reader, "TaxTableRevisionDate");
            fields["TimesheetWeekStartID"] = DbMgr.CreateStringFieldEntry(_obj.TimesheetWeekStartID); //GetString(reader, "TimesheetWeekStartID");
            fields["UseTimesheets"] = DbMgr.CreateStringFieldEntry(_obj.UseTimesheets); //GetString(reader, "UseTimesheets");
            fields["WithholderPayerNumber"] = DbMgr.CreateStringFieldEntry(_obj.WithholderPayerNumber); //GetString(reader, "WithholderPayerNumber");

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("PayrollInformation");
        }

        private DbSelectStatement GetQuery_SelectByPayrollInformationID(int PayrollInformationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("PayrollInformation")
                .Criteria
                    .IsEqual("PayrollInformation", "PayrollInformationID", PayrollInformationID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByPayrollInformationID(int PayrollInformationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("PayrollInformation")
                .Criteria
                    .IsEqual("PayrollInformation", "PayrollInformationID", PayrollInformationID);

            return clause;
        }

        public bool Exists(int? PayrollInformationID)
        {
            if (PayrollInformationID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByPayrollInformationID(PayrollInformationID.Value)) != 0;
        }

        public override bool Exists(PayrollInformation _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.PayrollInformationID);
        }

        protected override PayrollInformation _FindByIntId(int? PayrollInformationID)
        {
            if (PayrollInformationID == null) return null;
            PayrollInformation _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByPayrollInformationID(PayrollInformationID.Value));
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

        protected override IList<PayrollInformation>_FindAllCollection()
        {
            List<PayrollInformation> _grp = new List<PayrollInformation>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                PayrollInformation _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
