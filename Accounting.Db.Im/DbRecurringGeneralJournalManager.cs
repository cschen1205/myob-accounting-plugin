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
    public sealed class DbRecurringGeneralJournalManager : RecurringGeneralJournalManager
    {
        public DbRecurringGeneralJournalManager(DbManager mgr)
            : base(mgr)
        {
            
        }


        protected override void CreateTableCommands() //RecurringGeneralJournals()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringGeneralJournalID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CategoryID"] = DbManager.FIELDTYPE.INTEGER;
            fields["RecurringName"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["FrequencyID"] = DbManager.FIELDTYPE.VARCHAR_2;
            fields["StartingOn"] = DbManager.FIELDTYPE.DATETIME;
            fields["NextDue"] = DbManager.FIELDTYPE.DATETIME;
            fields["RepeatedOn"] = DbManager.FIELDTYPE.DATETIME;
            fields["ScheduleID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ContinueUntil"] = DbManager.FIELDTYPE.DATETIME;
            fields["PerformTimes"] = DbManager.FIELDTYPE.INTEGER;
            fields["RemainingTime"] = DbManager.FIELDTYPE.INTEGER;
            fields["AlertID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["AlertUserID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AlertTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["DaysInAdvance"] = DbManager.FIELDTYPE.INTEGER;
            fields["NumberingTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CostCentreID"] = DbManager.FIELDTYPE.INTEGER;
            fields["GSTReportingMethodID"] = DbManager.FIELDTYPE.VARCHAR_1;
            /*
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";                        
            foreignKeys["FrequencyID"] = "Frequencies(FrequencyID)";
            foreignKeys["ScheduleID"] = "Schedule(ScheduleID)";
            foreignKeys["AlertID"] = "Alerts(AlertID)";
            foreignKeys["AlertUserID"] = "Users(AlertUserID)";
            foreignKeys["AlertTypeID"] = "AlertTypes(AlertTypeID)";
            foreignKeys["NumberingTypeID"] = "NumberingTypes(NumberingTypeID)";               
             * */

            TableCommands["RecurringGeneralJournals"] = DbMgr.CreateTableCommand("RecurringGeneralJournals", fields, "RecurringGeneralJournalID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(RecurringGeneralJournal _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
           
            return DbMgr.CreateInsertClause("RecurringGeneralJournals", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringGeneralJournal _obj)
        {
            return DbMgr.CreateUpdateClause("RecurringGeneralJournals", GetFields(_obj), "RecurringGeneralJournalID", _obj.RecurringGeneralJournalID);
        }

        private DbDeleteStatement GetQuery_DeleteQuery(RecurringGeneralJournal _obj)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("RecurringGeneralJournals").Criteria.IsEqual("RecurringGeneralJournals", "RecurringGeneralJournalID", _obj.RecurringGeneralJournalID);
            
            return clause;
        }

        protected override OpResult _Store(RecurringGeneralJournal _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringGeneralJournal object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                foreach (RecurringGeneralJournalLine line in _obj.RecurringGeneralJournalLines)
                {
                    RepositoryMgr.RecurringGeneralJournalLineMgr.Store(line);
                }
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.RecurringGeneralJournalID == null)
            {
                _obj.RecurringGeneralJournalID = DbMgr.GetLastInsertID();
            }
            foreach (RecurringGeneralJournalLine line in _obj.RecurringGeneralJournalLines)
            {
                RepositoryMgr.RecurringGeneralJournalLineMgr.Store(line);
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

        protected override OpResult _Delete(RecurringGeneralJournal _obj)
        {
            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_DeleteQuery(_obj));
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "RecurringGeneralJournal object cannot be deleted as it does not exist");
        }
    }
}
