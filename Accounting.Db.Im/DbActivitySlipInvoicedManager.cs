using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Activities;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbActivitySlipInvoicedManager : ActivitySlipInvoicedManager
    {
        public DbActivitySlipInvoicedManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ActivitySlipInvoicedID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ActivitySlipID"] = DbManager.FIELDTYPE.INTEGER;
            fields["SaleID"] = DbManager.FIELDTYPE.INTEGER;
            fields["InvoicedUnits"] = DbManager.FIELDTYPE.DOUBLE;
            fields["InvoicedDollars"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["ActivitySlipID"] = "ActivitySlips(ActivitySlipID)";
            foreignKeys["SaleID"] = "Sales(SaleID)";
         
             * */

            TableCommands["ActivitySlipInvoiced"] = DbMgr.CreateTableCommand("ActivitySlipInvoiced", fields, "ActivitySlipInvoicedID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(ActivitySlipInvoiced _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("ActivitySlipInvoiced", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ActivitySlipInvoiced _obj)
        {
            return DbMgr.CreateUpdateClause("ActivitySlipInvoiced", GetFields(_obj), "ActivitySlipInvoicedID", _obj.ActivitySlipInvoicedID);
        }

        protected override OpResult _Store(ActivitySlipInvoiced _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ActivitySlipInvoiced object cannot be created as it is null");
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
