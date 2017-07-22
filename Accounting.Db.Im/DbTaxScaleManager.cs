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
    public class DbTaxScaleManager : TaxScaleManager
    {
        public DbTaxScaleManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["TaxScaleID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_56;

            TableCommands["TaxScales"] = DbMgr.CreateTableCommand("TaxScales", fields, "TaxScaleID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(TaxScale _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("TaxScales", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(TaxScale _obj)
        {
            return DbMgr.CreateUpdateClause("TaxScales", GetFields(_obj), "TaxScaleID", _obj.TaxScaleID);
        }

        protected override OpResult _Store(TaxScale _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "TaxScale object cannot be created as it is null");
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
