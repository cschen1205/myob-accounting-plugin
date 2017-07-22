using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Purchases;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbDebitRefundManager : DebitRefundManager
    {
        public DbDebitRefundManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //DebitRefunds()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["DebitRefundID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["DebitRefundNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["RecipientAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AmountRefunded"] = DbManager.FIELDTYPE.DOUBLE;
            fields["MethodOfPaymentID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PaymentCardNumber"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["PaymentNameOnCard"] = DbManager.FIELDTYPE.VARCHAR_50;
            fields["PaymentExpirationDate"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["PaymentAuthorisationNumber"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PaymentBankAccountNumber"] = DbManager.FIELDTYPE.VARCHAR_11;
            fields["PaymentBankAccountName"] = DbManager.FIELDTYPE.VARCHAR_32;
            fields["PaymentChequeNumber"] = DbManager.FIELDTYPE.VARCHAR_25;
            fields["PaymentNotes"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["DepositStatusID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["DebitNoteID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ExchangeGainLoss"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["RecipientAccountID"] = "Accounts(RecipientAccountID)";
            foreignKeys["PaymentMethodID"] = "PaymentMethods(PaymentMethodID)";
            foreignKeys["DepositStatusID"] = "DepositStatus(DepositStatusID)";
            foreignKeys["DebitNoteID"] = "Purchases(DebitNoteID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";            
             * */

            TableCommands["DebitRefunds"] = DbMgr.CreateTableCommand("DebitRefunds", fields, "DebitRefundID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(DebitRefund _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("DebitRefunds", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(DebitRefund _obj)
        {
            return DbMgr.CreateUpdateClause("DebitRefunds", GetFields(_obj), "DebitRefundID", _obj.DebitRefundID);
        }

       

        protected override OpResult _Store(DebitRefund _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "DebitRefund object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.DebitRefundID == null)
            {
                _obj.DebitRefundID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
