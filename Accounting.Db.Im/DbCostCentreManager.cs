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
    public class DbCostCentreManager : CostCentreManager
    {
        public DbCostCentreManager(DbManager mgr)
            : base(mgr)
        {
            
        }

         protected override void CreateTableCommands()
     
        {
            //create table: Cards
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["CostCentreID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["CostCentreName"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["CostCentreIdentification"] = DbManager.FIELDTYPE.VARCHAR_15;
            fields["CostCentreDescription"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["IsInactive"] = DbManager.FIELDTYPE.VARCHAR_1;

            TableCommands["CostCentres"] = DbMgr.CreateTableCommand("CostCentres", fields, "CostCentreID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(CostCentre _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("CostCentres", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(CostCentre _obj)
        {
            return DbMgr.CreateUpdateClause("CostCentres", GetFields(_obj), "CostCentreID", _obj.CostCentreID);
        }

        protected override OpResult _Store(CostCentre _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "CostCentre object cannot be created as it is null");
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
