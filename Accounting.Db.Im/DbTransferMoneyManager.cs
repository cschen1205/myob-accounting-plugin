using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Transactions;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbTransferMoneyManager : TransferMoneyManager
    {
        public DbTransferMoneyManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //TransferMoney()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["TransferMoneyID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["TransferNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["FromAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ToAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Amount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsAutoRecorded"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CategoryID"] = DbManager.FIELDTYPE.INTEGER;
            //fields["IsTransferredElectronically"] = DbManager.FIELDTYPE.VARCHAR_1;
            //fields["StatementText"] = DbManager.FIELDTYPE.VARCHAR_18;
            //fields["CostCentreID"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["FromAccountID"] = "Accounts(FromAccountID)";
            foreignKeys["ToAccountID"] = "Accounts(ToAccountID)";
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CategoryID"] = "Categories(CategoryID)";
             * */

            TableCommands["TransferMoney"] = DbMgr.CreateTableCommand("TransferMoney", fields, "TransferMoneyID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(TransferMoney _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("TransferMoney", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(TransferMoney _obj)
        {
            return DbMgr.CreateUpdateClause("TransferMoney", GetFields(_obj), "TransferMoneyID", _obj.TransferMoneyID);
        }

        protected override OpResult _Store(TransferMoney _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "TransferMoney object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.TransferMoneyID == null)
            {
                _obj.TransferMoneyID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);

        }
    }

    
}
