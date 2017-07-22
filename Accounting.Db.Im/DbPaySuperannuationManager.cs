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
    public class DbPaySuperannuationManager : PaySuperannuationManager
    {
        public DbPaySuperannuationManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands() //PaySuperannuation()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["PaySuperannuationID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["PaymentNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IssuingAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TotalPaymentAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;

            TableCommands["PaySuperannuation"] = DbMgr.CreateTableCommand("PaySuperannuation", fields, "PaySuperannuationID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(PaySuperannuation _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("PaySuperannuation", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(PaySuperannuation _obj)
        {
            return DbMgr.CreateUpdateClause("PaySuperannuation", GetFields(_obj), "PaySuperannuationID", _obj.PaySuperannuationID);
        }

        protected override OpResult _Store(PaySuperannuation _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "PaySuperannuation object cannot be created as it is null");
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
