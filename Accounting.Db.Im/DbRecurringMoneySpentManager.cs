using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Transactions;
    using Accounting.Db;
    using Accounting.Db.Elements;


    public class DbRecurringMoneySpentManager : RecurringMoneySpentManager
    {
        public DbRecurringMoneySpentManager(DbManager mgr)
            : base(mgr)
        {

        }


        protected override void CreateTableCommands() //RecurringMoneySpent()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringMoneySpentID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["IssuingAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TotalSpentAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Payee"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PayeeLine1"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PayeeLine2"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PayeeLine3"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PayeeLine4"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["PaymentDeliveryID"] = DbManager.FIELDTYPE.VARCHAR_1;
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
            fields["CostCentreID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["IssuingAccountID"] = "Accounts(IssuingAccountID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["PaymentDeliveryID"] = "InvoiceDelivery(PaymentDeliveryID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";                        
            foreignKeys["FrequencyID"] = "Frequencies(FrequencyID)";
            foreignKeys["ScheduleID"] = "Schedule(ScheduleID)";
            foreignKeys["AlertID"] = "Alerts(AlertID)";
            foreignKeys["AlertUserID"] = "Users(AlertUserID)";
            foreignKeys["AlertTypeID"] = "AlertTypes(AlertTypeID)";
            foreignKeys["NumberingTypeID"] = "NumberingTypes(NumberingTypeID)";            
             * */

            TableCommands["RecurringMoneySpent"] = DbMgr.CreateTableCommand("RecurringMoneySpent", fields, "RecurringMoneySpentID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(RecurringMoneySpent _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("RecurringMoneySpent", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringMoneySpent _obj)
        {
            return DbMgr.CreateUpdateClause("RecurringMoneySpent", GetFields(_obj), "RecurringMoneySpentID", _obj.RecurringMoneySpentID);
        }

        protected override OpResult _Store(RecurringMoneySpent _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringMoneySpent object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.RecurringMoneySpentID == null)
            {
                _obj.RecurringMoneySpentID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
