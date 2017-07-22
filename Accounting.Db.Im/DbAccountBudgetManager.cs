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

    public class DbAccountBudgetManager : AccountBudgetManager
    {
        public DbAccountBudgetManager(DbManager mgr)
            : base(mgr)
        {

        }



        protected override void CreateTableCommands() //AccountBudgets()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["AccountBudgetID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["AccountID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Period"] = DbManager.FIELDTYPE.INTEGER;
            fields["Amount"] = DbManager.FIELDTYPE.DOUBLE;
            fields["FinancialYear"] = DbManager.FIELDTYPE.INTEGER;

            //foreignKeys["AccountID"] = "Accounts(AccountID)";

            TableCommands["AccountBudgets"] = DbMgr.CreateTableCommand("AccountBudgets", fields, "AccountBudgetID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(AccountBudget _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("AccountBudgets", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(AccountBudget _obj)
        {
            return DbMgr.CreateUpdateClause("AccountBudgets", GetFields(_obj), "AccountBudgetID", _obj.AccountBudgetID);
        }

        protected override OpResult _Store(AccountBudget _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "AccountBudget object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.AccountBudgetID == null)
            {
                _obj.AccountBudgetID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
