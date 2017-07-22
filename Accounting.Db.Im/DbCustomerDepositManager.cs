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
    public sealed class DbCustomerDepositManager : CustomerDepositManager
    {
        public DbCustomerDepositManager(DbManager mgr)
            : base(mgr)
        {
        }
        

            
        protected override void CreateTableCommands() //CustomerDeposits()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["CustomerDepositID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CustomerDepositNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["CustomerDepositsAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SaleID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["DepositApplied"] = DbManager.FIELDTYPE.DOUBLE;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ExchangeGainLoss"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["CustomerDepositsAccountID"] = "Accounts(CustomerDepositsAccountID)";
            foreignKeys["SaleID"] = "Sales(SaleID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
             * */

            TableCommands["CustomerDeposits"] = DbMgr.CreateTableCommand("CustomerDeposits", fields, "CustomerDepositID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(CustomerDeposit _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("CustomerDeposits", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(CustomerDeposit _obj)
        {
            return DbMgr.CreateUpdateClause("CustomerDeposits", GetFields(_obj), "CustomerDepositID", _obj.CustomerDepositID);
        }

       

        protected override OpResult _Store(CustomerDeposit _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "CustomerDeposit object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.CustomerDepositID == null)
            {
                _obj.CustomerDepositID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
