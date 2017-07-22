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
    public sealed class DbCreditRefundManager : CreditRefundManager
    {
        public DbCreditRefundManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //CreditRefunds()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["CreditRefundID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ChequeNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IssuingAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AmountRefunded"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CreditNoteID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ExchangeGainLoss"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Payee"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsPrinted"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["PaymentDeliveryID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["IssuingAccountID"] = "Accounts(IssuingAccountID)";
            foreignKeys["CreditNoteID"] = "Sales(CreditNoteID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["PaymentDeliveryID"] = "InvoiceDelivery(PaymentDeliveryID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
             * */

            TableCommands["CreditRefunds"] = DbMgr.CreateTableCommand("CreditRefunds", fields, "CreditRefundID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(CreditRefund _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("CreditRefunds", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(CreditRefund _obj)
        {
            return DbMgr.CreateUpdateClause("CreditRefunds", GetFields(_obj), "CreditRefundID", _obj.CreditRefundID);
        }

       

        protected override OpResult _Store(CreditRefund _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "CreditRefund object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.CreditRefundID == null)
            {
                _obj.CreditRefundID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
