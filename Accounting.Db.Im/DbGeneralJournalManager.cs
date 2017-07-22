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
    public sealed class DbGeneralJournalManager : GeneralJournalManager
    {
        public DbGeneralJournalManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands() //GeneralJournals()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["GeneralJournalID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["GeneralJournalNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsAutoRecorded"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CategoryID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["CurrencyID"]="Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";
             * */

            TableCommands["GeneralJournals"] = DbMgr.CreateTableCommand("GeneralJournals", fields, "GeneralJournalID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(GeneralJournal _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
           
            return DbMgr.CreateInsertClause("GeneralJournals", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(GeneralJournal _obj)
        {
            return DbMgr.CreateUpdateClause("GeneralJournals", GetFields(_obj), "GeneralJournalID", _obj.GeneralJournalID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(GeneralJournal _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("GeneralJournals").Criteria.IsEqual("GeneralJournals", "GeneralJournalID", _obj.GeneralJournalID);
            
            return clause;
        }

        protected override OpResult _Store(GeneralJournal _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "GeneralJournal object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                foreach(GeneralJournalLine line in _obj.GeneralJournalLines)
                {
                    RepositoryMgr.GeneralJournalLineMgr.Store(line);
                }
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
             if (_obj.GeneralJournalID == null)
            {
                _obj.GeneralJournalID = DbMgr.GetLastInsertID();
            }
            foreach (GeneralJournalLine line in _obj.GeneralJournalLines)
            {
                RepositoryMgr.GeneralJournalLineMgr.Store(line);
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(GeneralJournal _obj)
        {
            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "GeneralJournal object cannot be deleted as it does not exist");
        }
    }
}
