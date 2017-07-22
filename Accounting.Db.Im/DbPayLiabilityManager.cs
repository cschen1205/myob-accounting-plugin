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
    public class DbPayLiabilityManager : PayLiabilityManager
    {
        public DbPayLiabilityManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //PayLiabilities()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["PayLiabilitiesID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ChequeNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["PaymentDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IssuingAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TotalPayment"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Payee"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PayeeLine1"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PayeeLine2"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PayeeLine3"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PayeeLine4"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["StatementText"] = DbManager.FIELDTYPE.VARCHAR_18;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["FromDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["ToDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsPrinted"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["PaymentStatusID"] = DbManager.FIELDTYPE.VARCHAR_1;


            TableCommands["PayLiabilities"] = DbMgr.CreateTableCommand("PayLiabilities", fields, "PayLiabilitiesID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(PayLiability _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("PayLiabilities", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(PayLiability _obj)
        {
            return DbMgr.CreateUpdateClause("PayLiabilities", GetFields(_obj), "PayLiabilitiesID", _obj.PayLiabilityID);
        }

        protected override OpResult _Store(PayLiability _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "PayLiability object cannot be created as it is null");
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
