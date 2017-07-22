using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.CostCentres;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbCostCentreAccountActivityManager : CostCentreAccountActivityManager
    {
        public DbCostCentreAccountActivityManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            //create table: Cards
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CostCentreAccountActivityID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CostCentreID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["FinancialYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["Period"] = DbManager.FIELDTYPE.INTEGER;
            fields["Amount"] = DbManager.FIELDTYPE.DOUBLE;

            TableCommands["CostCentreAccountActivities"] = DbMgr.CreateTableCommand("CostCentreAccountActivities", fields, "CostCentreAccountActivityID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(CostCentreAccountActivity _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("CostCentreAccountActivities", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(CostCentreAccountActivity _obj)
        {
            return DbMgr.CreateUpdateClause("CostCentreAccountActivities", GetFields(_obj), "CostCentreAccountActivityID", _obj.CostCentreAccountActivityID);
        }

        protected override OpResult _Store(CostCentreAccountActivity _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "CostCentreAccountActivity object cannot be created as it is null");
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
