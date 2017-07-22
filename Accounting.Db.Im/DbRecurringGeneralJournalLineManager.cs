using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using System.Data;
using Accounting.Core;
using Accounting.Core.JournalRecords;
using Accounting.Core.Cards;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbRecurringGeneralJournalLineManager : RecurringGeneralJournalLineManager
    {
        public DbRecurringGeneralJournalLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //RecurringGeneralJournalLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringGeneralJournalLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["RecurringGeneralJournalID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineMemo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;
            /*
            foreignKeys["RecurringGeneralJournalID"] = "RecurringGeneralJournals(RecurringGeneralJournalID)";
            foreignKeys["AccountID"] = "Accounts(AccountID)";
            foreignKeys["JobID"] = "Jobs(JobID)";
            foreignKeys["TaxCodeID"] = "TaxCodes(TaxCodeID)";                 
             * */

            TableCommands["RecurringGeneralJournalLines"] = DbMgr.CreateTableCommand("RecurringGeneralJournalLines", fields, "RecurringGeneralJournalLineID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(RecurringGeneralJournalLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("RecurringGeneralJournalLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringGeneralJournalLine _obj)
        {
            return DbMgr.CreateUpdateClause("RecurringGeneralJournalLines", GetFields(_obj), "RecurringGeneralJournalLineID", _obj.RecurringGeneralJournalLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(RecurringGeneralJournalLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("RecurringGeneralJournalLines").Criteria.IsEqual("RecurringGeneralJournalLines", "RecurringGeneralJournalLineID", _obj.RecurringGeneralJournalLineID);
            
            return clause;
        }

        protected override OpResult _Store(RecurringGeneralJournalLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringGeneralJournalLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.RecurringGeneralJournalLineID == null)
            {
                _obj.RecurringGeneralJournalLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(RecurringGeneralJournalLine _obj)
        {
            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "RecurringGeneralJournalLine object cannot be deleted as it does not exist");
        }
    }
}
