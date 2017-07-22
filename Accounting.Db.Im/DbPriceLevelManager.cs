using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Definitions;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbPriceLevelManager : PriceLevelManager
    {
        public DbPriceLevelManager(DbManager mgr)
            : base(mgr)
        {
            
        }


        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["PriceLevelID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_30;
            fields["ImportPriceLevel"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ImportSalesTaxCalcMethod"] = DbManager.FIELDTYPE.VARCHAR_1;

            TableCommands["PriceLevels"] = DbMgr.CreateTableCommand("PriceLevels", fields, "PriceLevelID", foreignKeys);
        }
        private DbInsertStatement GetQuery_InsertQuery(PriceLevel _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("PriceLevels", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(PriceLevel _obj)
        {
            return DbMgr.CreateUpdateClause("PriceLevels", GetFields(_obj), "PriceLevelID", _obj.PriceLevelID);
        }

        protected override OpResult _Store(PriceLevel _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "PriceLevel object cannot be created as it is null");
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
