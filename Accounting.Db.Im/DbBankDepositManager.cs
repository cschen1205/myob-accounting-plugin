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
    public class DbBankDepositManager : BankDepositManager
    {
        public DbBankDepositManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //BankDeposits()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["BankDepositID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["BankDepositNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["RecipientAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AmountDeposited"] = DbManager.FIELDTYPE.DOUBLE;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["RecipientAccountID"] = "(RecipientAccountID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
             * */

            TableCommands["BankDeposits"] = DbMgr.CreateTableCommand("BankDeposits", fields, "BankDepositID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(BankDeposit _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("BankDeposits", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(BankDeposit _obj)
        {
            return DbMgr.CreateUpdateClause("BankDeposits", GetFields(_obj), "BankDepositID", _obj.BankDepositID);
        }

        protected override OpResult _Store(BankDeposit _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "BankDeposit object cannot be created as it is null");
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
