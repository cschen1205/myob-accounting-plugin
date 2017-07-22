using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Sales;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbCustomerPaymentManager : CustomerPaymentManager
    {
        public DbCustomerPaymentManager(DbManager mgr)
            : base(mgr)
        {
            
        }


        protected override void CreateTableCommands() //CustomerPayments()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["CustomerPaymentID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CustomerPaymentNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["MethodOfPaymentID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PaymentCardNumber"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["PaymentNameOnCard"] = DbManager.FIELDTYPE.VARCHAR_50;
            fields["PaymentExpirationDate"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["PaymentAuthorisationNumber"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PaymentBankAccountNumber"] = DbManager.FIELDTYPE.VARCHAR_11;
            fields["PaymentBankAccountName"] = DbManager.FIELDTYPE.VARCHAR_32;
            fields["PaymentBankBranch"] = DbManager.FIELDTYPE.VARCHAR_7;
            fields["PaymentChequeNumber"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["PaymentBSB"] = DbManager.FIELDTYPE.VARCHAR_7;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["PaymentNotes"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["FinanceCharge"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["RecipientAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TotalCustomerPayment"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ExchangeGainLoss"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["DepositStatusID"] = DbManager.FIELDTYPE.VARCHAR_1;

            /*
            foreignKeys["PaymentMethodID"] = "PaymentMethods(PaymentMethodID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["RecipientAccountID"] = "Accounts(RecipientAccountID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["DepositStatusID"] = "DepositStatus(DepositStatusID)";
            * */

            TableCommands["CustomerPayments"] = DbMgr.CreateTableCommand("CustomerPayments", fields, "CustomerPaymentID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(CustomerPayment _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("CustomerPayments", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(CustomerPayment _obj)
        {
            return DbMgr.CreateUpdateClause("CustomerPayments", GetFields(_obj), "CustomerPaymentID", _obj.CustomerPaymentID);
        }

       

        protected override OpResult _Store(CustomerPayment _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "CustomerPayment object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));

            if (_obj.CustomerPaymentID == null)
            {
                _obj.CustomerPaymentID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
