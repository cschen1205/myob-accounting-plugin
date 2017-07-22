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

    public class DbMoneyReceivedManager : MoneyReceivedManager
    {
        public DbMoneyReceivedManager(DbManager mgr)
            : base(mgr)
        {

        }



        protected override void CreateTableCommands() //MoneyReceived()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["MoneyReceivedID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["DepositNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["RecipientAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TotalAmountReceived"] = DbManager.FIELDTYPE.DOUBLE;
            fields["MethodOfPaymentID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PaymentCardNumber"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["PaymentNameOnCard"] = DbManager.FIELDTYPE.VARCHAR_50;
            fields["PaymentExpirationDate"] = DbManager.FIELDTYPE.VARCHAR_10; //format: dd/mm
            fields["PaymentAuthorisationNumber"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PaymentBankAccountNumber"] = DbManager.FIELDTYPE.VARCHAR_11;
            fields["PaymentBankAccountName"] = DbManager.FIELDTYPE.VARCHAR_32;
            fields["PaymentChequeNumber"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["PaymentNotes"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PaymentBankBranch"] = DbManager.FIELDTYPE.VARCHAR_7;
            fields["PaymentBSB"] = DbManager.FIELDTYPE.VARCHAR_7;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsAutoRecorded"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["DepositStatusID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CategoryID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CostCentreID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["RecipientAccountID"] = "Accounts(RecipientAccountID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["CardRecordID"] = "Customers(CardRecordID)";
            foreignKeys["CardRecordID"] = "Suppliers(CardRecordID)";
            foreignKeys["CardRecordID"] = "Employees(CardRecordID)";
            foreignKeys["CardRecordID"] = "PersonalCards(CardRecordID)";
            foreignKeys["PaymentMethodID"] = "PaymentMethods(PaymentMethodID)";
            foreignKeys["DepositStatusID"] = "DepositStatus(DepositStatusID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";
             * */

            TableCommands["MoneyReceived"] = DbMgr.CreateTableCommand("MoneyReceived", fields, "MoneyReceivedID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(MoneyReceived _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("MoneyReceived", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(MoneyReceived _obj)
        {
            return DbMgr.CreateUpdateClause("MoneyReceived", GetFields(_obj), "MoneyReceivedID", _obj.MoneyReceivedID);
        }

        protected override OpResult _Store(MoneyReceived _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "MoneyReceived object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.MoneyReceivedID == null)
            {
                _obj.MoneyReceivedID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
