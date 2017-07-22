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
    public sealed class DbSupplierFinanceChargeManager : SupplierFinanceChargeManager
    {
        public DbSupplierFinanceChargeManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //SupplierFinanceCharges()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SupplierFinanceChargeID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["SupplierFinanceChargeNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ExchangeGainLoss"] = DbManager.FIELDTYPE.DOUBLE;
            fields["LateChargesAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["FinanceCharge"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["LateChargesAccountID"] = "Accounts(LateChargesAccountID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
             * */

            TableCommands["SupplierFinanceCharges"] = DbMgr.CreateTableCommand("SupplierFinanceCharges", fields, "SupplierFinanceChargeID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(SupplierFinanceCharge _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("SupplierFinanceCharges", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(SupplierFinanceCharge _obj)
        {
            return DbMgr.CreateUpdateClause("SupplierFinanceCharges", GetFields(_obj), "SupplierFinanceChargeID", _obj.SupplierFinanceChargeID);
        }

       

        protected override OpResult _Store(SupplierFinanceCharge _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "SupplierFinanceCharge object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.SupplierFinanceChargeID == null)
            {
                _obj.SupplierFinanceChargeID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
