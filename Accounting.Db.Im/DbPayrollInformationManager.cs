using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Misc;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbPayrollInformationManager : PayrollInformationManager
    {
        public DbPayrollInformationManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands() //PayrollInformation()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["PayrollInformationID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CurrentPayrollYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["HoursInWorkWeek"] = DbManager.FIELDTYPE.DOUBLE;
            fields["WithholderPayerNumber"] = DbManager.FIELDTYPE.VARCHAR_14;
            fields["RoundNetPayTo"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxTableRevisionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["DefaultSuperannuationFundID"] = DbManager.FIELDTYPE.INTEGER;
            fields["BaseSalaryWageID"] = DbManager.FIELDTYPE.INTEGER;
            fields["BaseHourlyWageID"] = DbManager.FIELDTYPE.INTEGER;
            fields["UseTimesheets"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IncludeTimeBillingInTimesheets"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["TimesheetWeekStartID"] = DbManager.FIELDTYPE.VARCHAR_3;



            TableCommands["PayrollInformation"] = DbMgr.CreateTableCommand("PayrollInformation", fields, "PayrollInformationID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(PayrollInformation _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("PayrollInformation", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(PayrollInformation _obj)
        {
            return DbMgr.CreateUpdateClause("PayrollInformation", GetFields(_obj), "PayrollInformationID", _obj.PayrollInformationID);
        }

        protected override OpResult _Store(PayrollInformation _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "PayrollInformation object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
