using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Transactions;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbElectronicPaymentManager : ElectronicPaymentManager
    {
        public DbElectronicPaymentManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //ElectronicPayments()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ElectronicPaymentID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["PaymentNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["StatementText"] = DbManager.FIELDTYPE.VARCHAR_18;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IssuingAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TotalPaymentAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;

            TableCommands["ElectronicPayments"] = DbMgr.CreateTableCommand("ElectronicPayments", fields, "ElectronicPaymentID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(ElectronicPayment _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("ElectronicPayments", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ElectronicPayment _obj)
        {
            return DbMgr.CreateUpdateClause("ElectronicPayments", GetFields(_obj), "ElectronicPaymentID", _obj.ElectronicPaymentID);
        }

        protected override OpResult _Store(ElectronicPayment _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ElectronicPayment object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
