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
    public class DbActivitySalesHistoryManager : ActivitySalesHistoryManager
    {
        public DbActivitySalesHistoryManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["ActivitySalesHistoryID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["ActivityID"] = DbManager.FIELDTYPE.INTEGER;
            fields["FinancialYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["Period"] = DbManager.FIELDTYPE.INTEGER;
            fields["UnitsSold"] = DbManager.FIELDTYPE.DOUBLE;
            fields["SaleAmount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["EstimatedCostOfSalesAmount"] = DbManager.FIELDTYPE.DOUBLE;

            /*
            foreignKeys["ActivityID"] = "Activities(ActivityID)";
           
             * */

            TableCommands["ActivitySalesHistory"] = DbMgr.CreateTableCommand("ActivitySalesHistory", fields, "ActivitySalesHistoryID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(ActivitySalesHistory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("ActivitySalesHistory", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(ActivitySalesHistory _obj)
        {
            return DbMgr.CreateUpdateClause("ActivitySalesHistory", GetFields(_obj), "ActivitySalesHistoryID", _obj.ActivitySalesHistoryID);
        }

        protected override OpResult _Store(ActivitySalesHistory _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ActivitySalesHistory object cannot be created as it is null");
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
