using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Accounts;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public class DbLinkedAccountManager : LinkedAccountManager
    {
        public DbLinkedAccountManager(DbManager mgr)
            : base(mgr)
        {

        }



        protected override void CreateTableCommands() //LinkedAccounts()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["LinkedAccountID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CurrentEarningsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["RetainedEarningsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["HistoricalBalancingID"] = DbManager.FIELDTYPE.INTEGER;
            fields["UndepositedFundsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ElectronicPaymentsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["EmployerExpenseID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CurrencyGainLossID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ReceivablesAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ReceivablesChequeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ReceivablesFreightID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ReceivablesDepositsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ReceivablesDiscountsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ReceivablesLateFeesID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PayablesAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PayablesChequeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PayablesFreightID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PayablesDepositsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PayablesDiscountsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PayablesLateFeesID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ChangeControl"] = DbManager.FIELDTYPE.VARCHAR_6;
            fields["PayablesInventoryID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PayrollCashID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PayrollChequeID"] = DbManager.FIELDTYPE.INTEGER;
            fields["WagesExpenseID"] = DbManager.FIELDTYPE.INTEGER;
            fields["WithholdingPayableID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["CurrentEarningsID"] = "Accounts(CurrentEarningsID)";
            foreignKeys["RetainedEarningsID"] = "Accounts(RetainedEarningsID)";
            foreignKeys["HistoricalBalancingID"] = "Accounts(HistoricalBalancingID)";
            foreignKeys["UndepositedFundsID"] = "Accounts(UndepositedFundsID)";
            foreignKeys["CurrencyGainLossID"] = "Accounts(CurrencyGainLossID)";
            foreignKeys["ReceivablesAccountID"] = "Accounts(ReceivablesAccountID)";
            foreignKeys["ReceivablesChequeID"] = "Accounts(ReceivablesChequeID)";
            foreignKeys["ReceivablesFreightID"] = "Accounts(ReceivablesFreightID)";
            foreignKeys["ReceivablesDepositsID"] = "Accounts(ReceivablesDepositsID)";
            foreignKeys["ReceivablesDiscountsID"] = "Accounts(ReceivablesDiscountsID)";
            foreignKeys["ReceivablesLateFeesID"] = "Accounts(ReceivablesLateFeesID)";
            foreignKeys["PayablesAccountID"] = "Accounts(PayablesAccountID)";
            foreignKeys["PayablesChequeID"] = "Accounts(PayablesChequeID)";
            foreignKeys["PayablesFreightID"] = "Accounts(PayablesFreightID)";
            foreignKeys["PayablesDepositsID"] = "Accounts(PayablesDepositsID)";
            foreignKeys["PayablesDiscountsID"] = "Accounts(PayablesDiscountsID)";
            foreignKeys["PayablesLateFeesID"] = "Accounts(PayablesLateFeesID)";
            foreignKeys["PayablesInventoryID"] = "Accounts(PayablesInventoryID)";
             * */

            TableCommands["LinkedAccounts"] = DbMgr.CreateTableCommand("LinkedAccounts", fields, "LinkedAccountID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(LinkedAccount _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("LinkedAccounts", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(LinkedAccount _obj)
        {
            return DbMgr.CreateUpdateClause("LinkedAccounts", GetFields(_obj), "LinkedAccountID", _obj.LinkedAccountID);
        }

        protected override OpResult _Store(LinkedAccount _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "LinkedAccount object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.LinkedAccountID == null)
            {
                _obj.LinkedAccountID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
