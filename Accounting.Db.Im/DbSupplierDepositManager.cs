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
    public sealed class DbSupplierDepositManager : SupplierDepositManager
    {
        public DbSupplierDepositManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //SupplierDeposits()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SupplierDepositID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["SupplierDepositNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["ExchangeGainLoss"] = DbManager.FIELDTYPE.INTEGER;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.INTEGER;
            fields["SupplierDepositAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["PurchaseID"] = DbManager.FIELDTYPE.INTEGER;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["DepositApplied"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["SupplierDepositAccountID"] = "Accounts(SupplierDepositAccountID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
            foreignKeys["PurchaseID"] = "Purchases(PurchaseID)";
             * */

            TableCommands["SupplierDeposits"] = DbMgr.CreateTableCommand("SupplierDeposits", fields, "SupplierDepositID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(SupplierDeposit _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("SupplierDeposits", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(SupplierDeposit _obj)
        {
            return DbMgr.CreateUpdateClause("SupplierDeposits", GetFields(_obj), "SupplierDepositID", _obj.SupplierDepositID);
        }

       

        protected override OpResult _Store(SupplierDeposit _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "SupplierDeposit object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.SupplierDepositID == null)
            {
                _obj.SupplierDepositID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
