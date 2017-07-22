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
    public sealed class DbCustomerDiscountLineManager : CustomerDiscountLineManager
    {
        public DbCustomerDiscountLineManager(DbManager mgr)
            : base(mgr)
        {
            
        }


        protected override void CreateTableCommands() //CustomerDiscountLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["CustomerDiscountLineID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CustomerDiscountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["LineNumber"] = DbManager.FIELDTYPE.INTEGER;
            fields["SaleID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AmountApplied"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["CustomerDiscountID"] = "CustomerDiscounts(CustomerDiscountID)";
            foreignKeys["SaleID"] = "Sales(SaleID)";
             * */

            TableCommands["CustomerDiscountLines"] = DbMgr.CreateTableCommand("CustomerDiscountLines", fields, "CustomerDiscountLineID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(CustomerDiscountLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("CustomerDiscountLines", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(CustomerDiscountLine _obj)
        {
            return DbMgr.CreateUpdateClause("CustomerDiscountLines", GetFields(_obj), "CustomerDiscountLineID", _obj.CustomerDiscountLineID);
        }

       

        protected override OpResult _Store(CustomerDiscountLine _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "CustomerDiscountLine object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.CustomerDiscountLineID == null)
            {
                _obj.CustomerDiscountLineID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);

        }

    }
}
