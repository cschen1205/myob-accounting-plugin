using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Activities;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbBillingRateUsedManager : BillingRateUsedManager
    {
        public DbBillingRateUsedManager(DbManager mgr)
            : base(mgr)
        {
         
        }

        protected override void CreateTableCommands()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["BillingRateUsedID"] = DbManager.FIELDTYPE.VARCHAR_2;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_20;

            TableCommands["BillingRateUsed"] = DbMgr.CreateTableCommand("BillingRateUsed", fields, "BillingRateUsedID", foreignKeys);
        }


        private DbInsertStatement GetQuery_InsertQuery(BillingRateUsed _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("BillingRateUsed", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(BillingRateUsed _obj)
        {
            return DbMgr.CreateUpdateClause("BillingRateUsed", GetFields(_obj), "BillingRateUsedID", _obj.BillingRateUsedID);
        }

     

        protected override OpResult _Store(BillingRateUsed _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "BillingRateUsed object cannot be created as it is null");
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
