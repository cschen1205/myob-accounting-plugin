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
    public sealed class DbSupplierPaymentManager : SupplierPaymentManager
    {
        public DbSupplierPaymentManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //SupplierPayments()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SupplierPaymentID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["SupplierPaymentNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Payee"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PayeeLine1"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PayeeLine2"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PayeeLine3"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PayeeLine4"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IssuingAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TotalSupplierPayment"] = DbManager.FIELDTYPE.DOUBLE;
            fields["FinanceCharge"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ExchangeGainLoss"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IsPrinted"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["PaymentDeliveryID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["PaymentStatusID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["StatementText"] = DbManager.FIELDTYPE.VARCHAR_18;
            fields["StatementParticulars"] = DbManager.FIELDTYPE.VARCHAR_12;
            fields["StatementCode"] = DbManager.FIELDTYPE.VARCHAR_12;
            fields["StatementReference"] = DbManager.FIELDTYPE.VARCHAR_12;
            /*
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["IssuingAccountID"] = "Accounts(IssuingAccountID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["PaymentDeliveryID"] = "InvoiceDelivery(PaymentDeliveryID)";
             * */

            TableCommands["SupplierPayments"] = DbMgr.CreateTableCommand("SupplierPayments", fields, "SupplierPaymentID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(SupplierPayment _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("SupplierPayments", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(SupplierPayment _obj)
        {
            return DbMgr.CreateUpdateClause("SupplierPayments", GetFields(_obj), "SupplierPaymentID", _obj.SupplierPaymentID);
        }

       

        protected override OpResult _Store(SupplierPayment _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "SupplierPayment object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.SupplierPaymentID == null)
            {
                _obj.SupplierPaymentID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
