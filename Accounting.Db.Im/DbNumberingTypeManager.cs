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
    public class DbNumberingTypeManager : NumberingTypeManager
    {
        public DbNumberingTypeManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["NumberingTypeID"] = DbManager.FIELDTYPE.VARCHAR_3;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_56;

            TableCommands["NumberingTypes"] = DbMgr.CreateTableCommand("NumberingTypes", fields, "NumberingTypeID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(NumberingType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("NumberingTypes", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(NumberingType _obj)
        {
            return DbMgr.CreateUpdateClause("NumberingTypes", GetFields(_obj), "NumberingTypeID", _obj.NumberingTypeID);
        }

        protected override OpResult _Store(NumberingType _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "NumberingType object cannot be created as it is null");
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
