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


    public class DbRecurringMoneyReceivedManager : RecurringMoneyReceivedManager
    {
        public DbRecurringMoneyReceivedManager(DbManager mgr)
            : base(mgr)
        {

        }

       

        protected override void CreateTableCommands() //RecurringMoneyReceived()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RecurringMoneyReceivedID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["RecipientAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TotalAmountReceived"] = DbManager.FIELDTYPE.DOUBLE;
            fields["MethodOfPaymentID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PaymentCardNumber"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["PaymentNameOnCard"] = DbManager.FIELDTYPE.VARCHAR_50;
            fields["PaymentExpirationDate"] = DbManager.FIELDTYPE.VARCHAR_5;
            fields["PaymentNotes"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
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
            fields["CostCentreID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TotalAmountReceived"] = DbManager.FIELDTYPE.DOUBLE;

            /*
                        foreignKeys["RecipientAccountID"] = "Accounts(RecipientAccountID)";
                        foreignKeys["PaymentMethodID"] = "PaymentMethods(PaymentMethodID)";
                        foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
                        foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
                        foreignKeys["CategoryID"] = "Categories(CategoryID)";                        
                        foreignKeys["FrequencyID"] = "Frequencies(FrequencyID)";
                        foreignKeys["ScheduleID"] = "Schedule(ScheduleID)";
                        foreignKeys["AlertID"] = "Alerts(AlertID)";
                        foreignKeys["AlertUserID"] = "Users(AlertUserID)";
                        foreignKeys["AlertTypeID"] = "AlertTypes(AlertTypeID)";
                        foreignKeys["NumberingTypeID"] = "NumberingTypes(NumberingTypeID)";               
                         * */

            TableCommands["RecurringMoneyReceived"] = DbMgr.CreateTableCommand("RecurringMoneyReceived", fields, "RecurringMoneyReceivedID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(RecurringMoneyReceived _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("RecurringMoneyReceived", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(RecurringMoneyReceived _obj)
        {
            return DbMgr.CreateUpdateClause("RecurringMoneyReceived", GetFields(_obj), "RecurringMoneyReceivedID", _obj.RecurringMoneyReceivedID);
        }

        protected override OpResult _Store(RecurringMoneyReceived _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringMoneyReceived object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.RecurringMoneyReceivedID == null)
            {
                _obj.RecurringMoneyReceivedID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
