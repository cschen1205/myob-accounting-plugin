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
    public class DbBankDepositLineManager : BankDepositLineManager
    {
        public DbBankDepositLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //BankDepositLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["BankDepositLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["BankDepositID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["SourceID"] = DbManager.FIELDTYPE.INTEGER;
            fields["JournalTypeID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["AmountDeposited"] = DbManager.FIELDTYPE.DOUBLE;
            fields["DepositStatusID"] = DbManager.FIELDTYPE.VARCHAR_1;

            /*
            foreignKeys["BankDepositID"] = "BankDeposits(BankDepositID)";
            foreignKeys["SourceID"] = "MoneyReceived(SourceID)";
            foreignKeys["JournalTypeID"] = "JournalTypes(JournalTypeID)";
            foreignKeys["DepositStatusID"] = "DepositStatus(DepositStatusID)";
             * */

            TableCommands["BankDepositLines"] = DbMgr.CreateTableCommand("BankDepositLines", fields, "BankDepositLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(BankDepositLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("BankDepositLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(BankDepositLine _obj)
        {
            return DbMgr.CreateUpdateClause("BankDepositLines", GetFields(_obj), "BankDepositLineID", _obj.BankDepositLineID);
        }

        protected override OpResult _Store(BankDepositLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "BankDepositLine object cannot be created as it is null");
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
