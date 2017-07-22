using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Misc;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbAuditTrailManager : AuditTrailManager
    {
        public DbAuditTrailManager(DbManager mgr)
            : base(mgr)
        {
            
        }




        protected override void CreateTableCommands() //AuditTrail()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["AuditTrailID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["AuditTypeID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["TransactionNumber"] = DbManager.FIELDTYPE.VARCHAR_10;
            fields["ChangeDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["OriginalDate"] = DbManager.FIELDTYPE.DATETIME;
            fields["WasThirteenthPeriod"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["IsReconciled"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UserID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;

            //foreignKeys["UserID"] = "Users(UserID)";

            TableCommands["AuditTrail"] = DbMgr.CreateTableCommand("AuditTrail", fields, "AuditTrailID", foreignKeys);
        }
        

        private DbInsertStatement GetQuery_InsertQuery(AuditTrail _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("AuditTrail", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(AuditTrail _obj)
        {
            return DbMgr.CreateUpdateClause("AuditTrail", GetFields(_obj), "AuditTrailID", _obj.AuditTrailID);
        }

        protected override OpResult _Store(AuditTrail _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "AuditTrail object cannot be created as it is null");
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
