using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Definitions;
    using Accounting.Db.Elements;

    public class DbGenderManager : GenderManager
    {
        public DbGenderManager(DbManager mgr)
            : base(mgr)
        {
        }

        protected override void CreateTableCommands() 
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["GenderID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;

            TableCommands["Gender"] = DbMgr.CreateTableCommand("Gender", fields, "GenderID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(Gender _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);

            return DbMgr.CreateInsertClause("Gender", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(Gender _obj)
        {
            return DbMgr.CreateUpdateClause("Gender", GetFields(_obj), "GenderID", _obj.GenderID);
        }

        protected override OpResult _Delete(Gender _obj)
        {
            if (Exists(_obj))
            {
                DbDeleteStatement clause = DbMgr.CreateDeleteClause();
                clause.DeleteFrom("Gender").Criteria.IsEqual("Gender", "GenderID", _obj.GenderID);

                DbMgr.ExecuteNonQuery(clause);

                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "Gender object does not exist");
        }

        protected override OpResult _Store(Gender _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Gender object cannot be created as it is null");
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
