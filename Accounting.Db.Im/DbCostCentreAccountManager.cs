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
    public class DbCostCentreAccountManager : CostCentreAccountManager
    {
        public DbCostCentreAccountManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        

        protected override void CreateTableCommands()
        {
            //create table: Cards
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CostCentreAccountID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CostCentreID"] = DbManager.FIELDTYPE.INTEGER;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["CurrentBalance"] = DbManager.FIELDTYPE.DOUBLE;
            fields["PreLastYearActivity"] = DbManager.FIELDTYPE.DOUBLE;
            fields["LastYearOpeningBalance"] = DbManager.FIELDTYPE.DOUBLE;
            fields["ThisYearOpeningBalance"] = DbManager.FIELDTYPE.DOUBLE;
            fields["PostThisYearActivity"] = DbManager.FIELDTYPE.DOUBLE;

            TableCommands["CostCentreAccounts"] = DbMgr.CreateTableCommand("CostCentreAccounts", fields, "CostCentreAccountID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(CostCentreAccount _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("CostCentreAccounts", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(CostCentreAccount _obj)
        {
            return DbMgr.CreateUpdateClause("CostCentreAccounts", GetFields(_obj), "CostCentreAccountID", _obj.CostCentreAccountID);
        }

        protected override OpResult _Store(CostCentreAccount _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "CostCentreAccount object cannot be created as it is null");
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
