using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.CostCentres;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbCostCentreJournalRecordManager : CostCentreJournalRecordManager
    {
        public DbCostCentreJournalRecordManager(DbManager mgr)
            : base(mgr)
        {
            
        }

            
        protected override void CreateTableCommands()
        {
            //create table: Cards
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CostCentreJournalRecordID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["TransactionNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CostCentreID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["JournalRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["JournalTypeID"] = DbManager.FIELDTYPE.VARCHAR_3;
           
            TableCommands["CostCentreJournalRecords"] = DbMgr.CreateTableCommand("CostCentreJournalRecords", fields, "CostCentreJournalRecordID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(CostCentreJournalRecord _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("CostCentreJournalRecords", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(CostCentreJournalRecord _obj)
        {
            return DbMgr.CreateUpdateClause("CostCentreJournalRecords", GetFields(_obj), "CostCentreJournalRecordID", _obj.CostCentreJournalRecordID);
        }

        protected override OpResult _Store(CostCentreJournalRecord _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "CostCentreJournalRecord object cannot be created as it is null");
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
