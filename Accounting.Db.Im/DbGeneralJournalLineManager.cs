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
    public class DbGeneralJournalLineManager : GeneralJournalLineManager
    {
        public DbGeneralJournalLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }


        protected override void CreateTableCommands() //GeneralJournalLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["GeneralJournalLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["GeneralJournalID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["JobID"] = DbManager.FIELDTYPE.INTEGER;
            fields["IsMultipleJob"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["TaxExclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["TaxInclusiveAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["LineMemo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["TaxCodeID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["GeneralJournalID"]="GeneralJournals(GeneralJournalID)";
            foreignKeys["AccountID"]="Accounts(AccountID)";
            foreignKeys["JobID"]="Jobs(JobID)";
            foreignKeys["TaxCodeID"]="TaxCodes(TaxCodeID)";
             * */

            TableCommands["GeneralJournalLines"] = DbMgr.CreateTableCommand("GeneralJournalLines", fields, "GeneralJournalLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(GeneralJournalLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("GeneralJournalLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(GeneralJournalLine _obj)
        {
            return DbMgr.CreateUpdateClause("GeneralJournalLines", GetFields(_obj), "GeneralJournalLineID", _obj.GeneralJournalLineID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(GeneralJournalLine _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("GeneralJournalLines").Criteria.IsEqual("GeneralJournalLines", "GeneralJournalLineID", _obj.GeneralJournalLineID);
            
            return clause;
        }

        protected override OpResult _Store(GeneralJournalLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "GeneralJournalLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.GeneralJournalLineID == null)
            {
                _obj.GeneralJournalLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(GeneralJournalLine _obj)
        {
            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "GeneralJournalLine object cannot be deleted as it does not exist");
        }
    }
}
