using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Misc;
    using Accounting.Db.Elements;

    public class DbMiscNumberManager : MiscNumberManager
    {
        public DbMiscNumberManager(DbManager mgr)
            : base(mgr)
        {
        }

        protected override void CreateTableCommands() //MiscPurchaseLines()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();


            fields["ID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["type"] = DbManager.FIELDTYPE.INTEGER;
            fields["signature"] = DbManager.FIELDTYPE.VARCHAR_255;


            TableCommands["NumberGenerator"] = DbMgr.CreateTableCommand("NumberGenerator", fields, "ID", foreignKeys);
        }

        protected override OpResult _Delete(MiscNumber _obj)
        {
            if (Exists(_obj))
            {
                DbDeleteStatement clause = DbMgr.CreateDeleteClause();
                clause.DeleteFrom("NumberGenerator").Criteria
                    .IsEqual("NumberGenerator", "signature", _obj.signature)
                    .IsEqual("NumberGenerator", "type", (int)_obj.type);
                DbMgr.ExecuteNonQuery(clause);
                return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
            }
            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.NotExists, _obj, "MiscNumber object does not exists");
            
        }

        private DbInsertStatement GetQuery_InsertQuery(MiscNumber _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("NumberGenerator", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(MiscNumber _obj)
        {
            return DbMgr.CreateUpdateClause("NumberGenerator", GetFields(_obj), "ID", _obj.ID);
        }

        protected override OpResult _Store(MiscNumber _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "MiscNumber object cannot be created as it is null");
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
