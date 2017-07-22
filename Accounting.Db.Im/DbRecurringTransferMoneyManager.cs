using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Transactions;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbRecurringTransferMoneyManager : RecurringTransferMoneyManager
    {
        public DbRecurringTransferMoneyManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //RecurringTransferMoney()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringTransferMoneyID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["FromAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ToAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Amount"] = DbManager.FIELDTYPE.DOUBLE;
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
            fields["AppliedNumber"] = DbManager.FIELDTYPE.VARCHAR_8;
            fields["RetainChanges"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["LastPosted"] = DbManager.FIELDTYPE.DATETIME;

            /*
            foreignKeys["FromAccountID"] = "Accounts(FromAccountID)";
            foreignKeys["ToAccountID"] = "Accounts(ToAccountID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";                        
            foreignKeys["FrequencyID"] = "Frequencies(FrequencyID)";
            foreignKeys["ScheduleID"] = "Schedule(ScheduleID)";
            foreignKeys["AlertID"] = "Alerts(AlertID)";
            foreignKeys["AlertUserID"] = "Users(AlertUserID)";
            foreignKeys["AlertTypeID"] = "AlertTypes(AlertTypeID)";
            foreignKeys["NumberingTypeID"] = "NumberingTypes(NumberingTypeID)";              
             * */

            TableCommands["RecurringTransferMoney"] = DbMgr.CreateTableCommand("RecurringTransferMoney", fields, "RecurringTransferMoneyID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(RecurringTransferMoney _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("RecurringTransferMoney", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringTransferMoney _obj)
        {
            return DbMgr.CreateUpdateClause("RecurringTransferMoney", GetFields(_obj), "RecurringTransferMoneyID", _obj.RecurringTransferMoneyID);
        }

        protected override OpResult _Store(RecurringTransferMoney _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringTransferMoney object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.RecurringTransferMoneyID == null)
            {
                _obj.RecurringTransferMoneyID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }

    
}
