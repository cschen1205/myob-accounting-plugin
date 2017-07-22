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
    public sealed class DbSupplierDiscountManager : SupplierDiscountManager
    {
        public DbSupplierDiscountManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //SupplierDiscounts()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SupplierDiscountID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["SupplierDiscountNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["Date"] = DbManager.FIELDTYPE.DATETIME;
            fields["TransactionDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["IsThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Memo"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IsTaxInclusive"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["CurrencyID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TransactionExchangeRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ExchangeGainLoss"] = DbManager.FIELDTYPE.DOUBLE;
            fields["DiscountAccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CardRecordID"] = DbManager.FIELDTYPE.INTEGER;
            fields["TotalDiscount"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["CurrencyID"] = "Currency(CurrencyID)";
            foreignKeys["DiscountAccountID"] = "Accounts(DiscountAccountID)";
            foreignKeys["CardRecordID"] = "Cards(CardRecordID)";
             * */

            TableCommands["SupplierDiscounts"] = DbMgr.CreateTableCommand("SupplierDiscounts", fields, "SupplierDiscountID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(SupplierDiscount _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("SupplierDiscounts", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(SupplierDiscount _obj)
        {
            return DbMgr.CreateUpdateClause("SupplierDiscounts", GetFields(_obj), "SupplierDiscountID", _obj.SupplierDiscountID);
        }

       

        protected override OpResult _Store(SupplierDiscount _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "SupplierDiscount object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));

            if (_obj.SupplierDiscountID == null)
            {
                _obj.SupplierDiscountID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
