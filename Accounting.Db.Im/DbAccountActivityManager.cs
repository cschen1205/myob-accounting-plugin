using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Im
{
    using Accounting.Core;
    using Accounting.Core.Accounts;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public class DbAccountActivityManager : AccountActivityManager
    {
        public DbAccountActivityManager(DbManager mgr)
            : base(mgr)
        {

        }


        protected override void CreateTableCommands() //AccountActivities()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["AccountActivityID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["FinancialYear"] = DbManager.FIELDTYPE.INTEGER;
            fields["Period"] = DbManager.FIELDTYPE.INTEGER;
            fields["Amount"] = DbManager.FIELDTYPE.DOUBLE;

            //foreignKeys["AccountID"] = "Accounts(AccountID)";

            TableCommands["AccountActivities"] = DbMgr.CreateTableCommand("AccountActivities", fields, "AccountActivityID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(AccountActivity _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("AccountActivities", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(AccountActivity _obj)
        {
            return DbMgr.CreateUpdateClause("AccountActivities", GetFields(_obj), "AccountActivityID", _obj.AccountActivityID);
        }

        protected override OpResult _Store(AccountActivity _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "AccountActivity object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.AccountActivityID == null)
            {
                _obj.AccountActivityID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
