using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Jobs;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public class DbJobJournalRecordManager : JobJournalRecordManager
    {
        public DbJobJournalRecordManager(DbManager mgr)
            : base(mgr)
        {

        }

        protected override void CreateTableCommands()

        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["JobJournalRecordID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["TransactionNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["JournalRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SalePurchaseLineID"] = DbManager.FIELDTYPE.INTEGER;
            fields["JournalTypeID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["IsReimbursed"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["TransactionNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            /*
           foreignKeys["JobID"] = "Jobs(JobID)";
           foreignKeys["AccountID"] = "Accounts(AccountID)";
           foreignKeys["JournalRecordID"] = "JournalRecords(JournalRecordID)";
           foreignKeys["JournalTypeID"] = "JournalTypes(JournalTypeID)";
           //omit foreignKeys for SalePurchaseLineID
            * */

            TableCommands["JobJournalRecords"] = DbMgr.CreateTableCommand("JobJournalRecords", fields, "JobJournalRecordID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(JobJournalRecord _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("JobJournalRecords", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(JobJournalRecord _obj)
        {
            return DbMgr.CreateUpdateClause("JobJournalRecords", GetFields(_obj), "JobJournalRecordID", _obj.JobJournalRecordID);
        }

        protected override OpResult _Store(JobJournalRecord _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "JobJournalRecord object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj) ;
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.JobJournalRecordID == null)
            {
                _obj.JobJournalRecordID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
