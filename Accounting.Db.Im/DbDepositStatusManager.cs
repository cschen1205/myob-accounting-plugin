using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Definitions;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public class DbDepositStatusManager : DepositStatusManager
    {
        public DbDepositStatusManager(DbManager mgr)
            : base(mgr)
        {

        }



        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["DepositStatusID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_11;

            TableCommands["DepositStatus"] = DbMgr.CreateTableCommand("DepositStatus", fields, "DepositStatusID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(DepositStatus _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("DepositStatus", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(DepositStatus _obj)
        {
            return DbMgr.CreateUpdateClause("DepositStatus", GetFields(_obj), "DepositStatusID", _obj.DepositStatusID);
        }

        protected override OpResult _Store(DepositStatus _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "DepositStatus object is not created as it is null");
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
