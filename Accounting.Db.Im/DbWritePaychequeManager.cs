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
    public class DbWritePaychequeManager : WritePaychequeManager
    {
        public DbWritePaychequeManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //WritePaycheque()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["WritePaychequeID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ChequeNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["IssuingAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["NetPay"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Payee"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PaymentTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["BankingDetailsID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PayPeriodStartDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["PayPeriodEndingDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["NumberOfPayPeriods"] = DbManager.FIELDTYPE.DOUBLE;
            fields["PayeeLine1"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PayeeLine2"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PayeeLine3"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["PayeeLine4"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["StatementText"] = DbManager.FIELDTYPE.VARCHAR_18;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsPrinted"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CostCentreID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PaymentStatusID"] = DbManager.FIELDTYPE.VARCHAR_1;


            TableCommands["WritePaycheque"] = DbMgr.CreateTableCommand("WritePaycheque", fields, "WritePaychequeID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(WritePaycheque _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("WritePaycheque", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(WritePaycheque _obj)
        {
            return DbMgr.CreateUpdateClause("WritePaycheque", GetFields(_obj), "WritePaychequeID", _obj.WritePaychequeID);
        }

        protected override OpResult _Store(WritePaycheque _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "WritePaycheque object cannot be created as it is null");
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
