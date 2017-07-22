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

    public class DbMoneySpentManager : MoneySpentManager
    {
        public DbMoneySpentManager(DbManager mgr)
            : base(mgr)
        {

        }



        protected override void CreateTableCommands() //MoneySpent()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["PaymentStatusID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CostCentreID"] = DbManager.FIELDTYPE.INTEGER;
            fields["MoneySpentID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ChequeNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
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
            fields["IsAutoRecorded"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IsPrinted"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["PaymentDeliveryID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CategoryID"] = DbManager.FIELDTYPE.INTEGER;
            fields["StatementText"] = DbManager.FIELDTYPE.VARCHAR_18;
            fields["StatementParticulars"] = DbManager.FIELDTYPE.VARCHAR_12;
            fields["StatementCode"] = DbManager.FIELDTYPE.VARCHAR_12;
            fields["StatementReference"] = DbManager.FIELDTYPE.VARCHAR_12;
            fields["CostCentreID"] = DbManager.FIELDTYPE.INTEGER;
            /*
            foreignKeys["IssuingAccountID"] = "Accounts(IssuingAccountID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["CardRecordID"]="Customers(CardRecordID)";
            foreignKeys["CardRecordID"] = "Suppliers(CardRecordID)";
            foreignKeys["CardRecordID"] = "Employees(CardRecordID)";
            foreignKeys["CardRecordID"] = "PersonalCards(CardRecordID)";
            foreignKeys["PaymentDeliveryID"] = "InvoiceDelivery(PaymentDeliveryID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";
             * */

            TableCommands["MoneySpent"] = DbMgr.CreateTableCommand("MoneySpent", fields, "MoneySpentID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(MoneySpent _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("MoneySpent", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(MoneySpent _obj)
        {
            return DbMgr.CreateUpdateClause("MoneySpent", GetFields(_obj), "MoneySpentID", _obj.MoneySpentID);
        }

        protected override OpResult _Store(MoneySpent _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "MoneySpent object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.MoneySpentID == null)
            {
                _obj.MoneySpentID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
