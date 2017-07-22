using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.JournalRecords;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbJournalRecordManager : JournalRecordManager
    {
        public DbJournalRecordManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //JournalRecords()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["JournalRecordID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["SetID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["IsMultipleJob"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["EntryIsPurged"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsForeignTransaction"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsExchangeConversion"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ReconciliationStatusID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["DateReconciled"] = DbManager.FIELDTYPE.DATETIME;
            fields["UserID"] = DbManager.FIELDTYPE.INTEGER;
            fields["RecordSessionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["RecordSessionTime"] = DbManager.FIELDTYPE.VARCHAR_10; //store hh:mm:ss

            /*
            foreignKeys["SetID"] = "JournalSets(SetID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["ReconciliationStatusID"] = "ReconciliationStatus(ReconciliationStatusID)";
            foreignKeys["UserID"] = "Users(UserID)";
             * */

            TableCommands["JournalRecords"] = DbMgr.CreateTableCommand("JournalRecords", fields, "JournalRecordID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(JournalRecord _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            
            return DbMgr.CreateInsertClause("JournalRecords", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(JournalRecord _obj)
        {
            return DbMgr.CreateUpdateClause("JournalRecords", GetFields(_obj), "JournalRecordID", _obj.JournalRecordID);
        }

        protected override OpResult _Store(JournalRecord _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "JournalRecord object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.JournalRecordID == null)
            {
                _obj.JournalRecordID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }

    
}
