using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Security;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public sealed class DbAuthUserManager : AuthUserManager
    {
        public DbAuthUserManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //AuthUser()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["AuthUserID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["AuthUsername"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["AuthPassword"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["RoleID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields["UseTimeslipsLink"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UseBillingUnits"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["BillingUnit"] = DbManager.FIELDTYPE.INTEGER;
            fields["RoundCalculatedTime"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["RoundToID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["MinuteIncrement"] = DbManager.FIELDTYPE.INTEGER;
            fields["IncludeItemsInTimeBilling"] = DbManager.FIELDTYPE.VARCHAR_1;
            /*
            fields["CreateTime"] = DbManager.FIELDTYPE.DATETIME;
            fields["CreateUserID"] = DbManager.FIELDTYPE.INTEGER;
            fields["UpdateTime"] = DbManager.FIELDTYPE.DATETIME;
            fields["UpdateUserID"] = DbManager.FIELDTYPE.INTEGER;
             */

            TableCommands["AuthUser"] = DbMgr.CreateTableCommand("AuthUser", fields, "AuthUserID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(AuthUser _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("AuthUser", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(AuthUser _obj)
        {
            return DbMgr.CreateUpdateClause("AuthUser", GetFields(_obj), "AuthUserID", _obj.UserID);
        }

        protected override OpResult _Store(AuthUser _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "AuthUser object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.UserID == null)
            {
                _obj.UserID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
