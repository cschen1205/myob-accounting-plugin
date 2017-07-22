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
    public sealed class DbSupplierDiscountLineManager : SupplierDiscountLineManager
    {
        public DbSupplierDiscountLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //SupplierDiscountLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["SupplierDiscountLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["SupplierDiscountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["PurchaseID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AmountApplied"] = DbManager.FIELDTYPE.INTEGER;

            /*
            foreignKeys["SupplierDiscountID"] = "SupplierDiscounts(SupplierDiscountID)";
            foreignKeys["PurchaseID"] = "Purchases(PurchaseID)";
             * */

            TableCommands["SupplierDiscountLines"] = DbMgr.CreateTableCommand("SupplierDiscountLines", fields, "SupplierDiscountLineID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(SupplierDiscountLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("SupplierDiscountLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(SupplierDiscountLine _obj)
        {
            return DbMgr.CreateUpdateClause("SupplierDiscountLines", GetFields(_obj), "SupplierDiscountLineID", _obj.SupplierDiscountLineID);
        }

       

        protected override OpResult _Store(SupplierDiscountLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "SupplierDiscountLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.SupplierDiscountLineID == null)
            {
                _obj.SupplierDiscountLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
