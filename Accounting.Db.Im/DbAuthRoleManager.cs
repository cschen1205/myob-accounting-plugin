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
    public sealed class DbAuthRoleManager : AuthRoleManager
    {
        public DbAuthRoleManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //AuthRoleItems()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["RoleItemID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["RoleID"] = DbManager.FIELDTYPE.INTEGER;
            fields["ItemID"] = DbManager.FIELDTYPE.INTEGER;
            fields["Description"] = DbManager.FIELDTYPE.VARCHAR_255;

            /*
            fields["CreateTime"] = DbManager.FIELDTYPE.DATETIME;
            fields["CreateUserID"] = DbManager.FIELDTYPE.INTEGER;
            fields["UpdateTime"] = DbManager.FIELDTYPE.DATETIME;
            fields["UpdateUserID"] = DbManager.FIELDTYPE.INTEGER;*/

            TableCommands["AuthRoleItem"] = DbMgr.CreateTableCommand("AuthRoleItem", fields, "RoleItemID", foreignKeys);

            Dictionary<string, DbManager.FIELDTYPE> fields1 = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys1 = new Dictionary<string, string>();

            fields1["RoleID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields1["RoleName"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields1["Description"] = DbManager.FIELDTYPE.VARCHAR_255;
            fields1["FullControl"] = DbManager.FIELDTYPE.VARCHAR_1;
            /*
            fields1["CreateTime"] = DbManager.FIELDTYPE.DATETIME;
            fields1["CreateUserID"] = DbManager.FIELDTYPE.INTEGER;
            fields1["UpdateTime"] = DbManager.FIELDTYPE.DATETIME;
            fields1["UpdateUserID"] = DbManager.FIELDTYPE.INTEGER;*/

            TableCommands["AuthRole"] = DbMgr.CreateTableCommand("AuthRole", fields1, "RoleID", foreignKeys1);

            Dictionary<string, DbManager.FIELDTYPE> fields2 = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys2 = new Dictionary<string, string>();

            fields2["RoleRoleID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields2["ParentRoleID"] = DbManager.FIELDTYPE.INTEGER;
            fields2["ChildRoleID"] = DbManager.FIELDTYPE.INTEGER;
            fields2["Description"] = DbManager.FIELDTYPE.VARCHAR_255;
            /*
            fields2["CreateTime"] = DbManager.FIELDTYPE.DATETIME;
            fields2["CreateUserID"] = DbManager.FIELDTYPE.INTEGER;
            fields2["UpdateTime"] = DbManager.FIELDTYPE.DATETIME;
            fields2["UpdateUserID"] = DbManager.FIELDTYPE.INTEGER;*/

            TableCommands["AuthRoleRole"] = DbMgr.CreateTableCommand("AuthRoleRole", fields2, "RoleRoleID", foreignKeys2);
        }



        private DbInsertStatement GetQuery_InsertQuery(AuthRole _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("AuthRole", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(AuthRole _obj)
        {
            return DbMgr.CreateUpdateClause("AuthRole", GetFields(_obj), "RoleID", _obj.RoleID);
        }

        private void RemoveRoleRole(AuthRole _obj)
        {
            DbDeleteStatement statement = DbMgr.CreateDeleteClause();
            statement.DeleteFrom("AuthRoleRole").Criteria.IsEqual("AuthRoleRole", "ParentRoleID", _obj.RoleID);
            ExecuteNonQuery(statement);
        }

        private void RemoveRoleItem(AuthRole _obj)
        {
            DbDeleteStatement statement = DbMgr.CreateDeleteClause();
            statement.DeleteFrom("AuthRoleItem").Criteria.IsEqual("AuthRoleItem", "RoleID", _obj.RoleID);
            ExecuteNonQuery(statement);
        }

        private void InsertRoleRole(AuthRole _obj)
        {
            foreach (AuthRole child_role in _obj.Children)
            {
                Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
                fields["ParentRoleID"] =DbMgr.CreateIntFieldEntry( _obj.RoleID);
                fields["ChildRoleID"] = DbMgr.CreateIntFieldEntry(child_role.RoleID);
                fields["Description"] = DbMgr.CreateStringFieldEntry(string.Format("{0} is superset of {1}", _obj.RoleName, child_role.RoleName));

                DbInsertStatement statement = DbMgr.CreateInsertClause();
                statement
                    .InsertColumns(fields)
                    .Into("AuthRoleRole");
                ExecuteNonQuery(statement);
            }
        }

        private void InsertRoleItem(AuthRole _obj)
        {
            foreach (AuthItem item in _obj.ForbiddenItems)
            {
  
                    Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
                    fields["RoleID"] = DbMgr.CreateIntFieldEntry(_obj.RoleID);
                    fields["ItemID"] = DbMgr.CreateIntFieldEntry(item.ItemID);
                    fields["Description"] = DbMgr.CreateStringFieldEntry(string.Format("{0} can act on {1}", _obj.RoleName, item.ItemName));

                    DbInsertStatement statement = DbMgr.CreateInsertClause();
                    statement
                        .InsertColumns(fields)
                        .Into("AuthRoleItem");
                    ExecuteNonQuery(statement);
            }
        }

      

        protected override OpResult _Delete(AuthRole _obj)
        {
            RemoveRoleItem(_obj);
            RemoveRoleRole(_obj);
            
            DbDeleteStatement statement = DbMgr.CreateDeleteClause();
            statement.DeleteFrom("AuthRole").Criteria.IsEqual("AuthRole", "RoleID", _obj.RoleID);
            ExecuteNonQuery(statement);

            statement = DbMgr.CreateDeleteClause();
            statement.DeleteFrom("AuthRoleRole").Criteria.IsEqual("AuthRoleRole", "ChildRoleID", _obj.RoleID);
            ExecuteNonQuery(statement);

            statement = DbMgr.CreateDeleteClause();
            statement.DeleteFrom("AuthUser").Criteria.IsEqual("AuthUser", "RoleID", _obj.RoleID);
            ExecuteNonQuery(statement);

            return OpResult.NotifyDeleteAction(OpResult.ResultStatus.ExistsAndDeleted, _obj);
        }

        protected override OpResult _Store(AuthRole _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "AuditTrail object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                RemoveRoleItem(_obj);
                RemoveRoleRole(_obj);
                InsertRoleItem(_obj);
                InsertRoleRole(_obj);
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            DbInsertStatement clause = null;
            clause = DbMgr.CreateInsertClause();
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            clause
                .InsertColumns(fields)
                .Into("AuthRole");
            ExecuteNonQuery(clause);
            if (_obj.RoleID == null)
            {
                _obj.RoleID = DbMgr.GetLastInsertID();
            }

            foreach (AuthRole child_role in _obj.Children)
            {
                Store(child_role);

                DbSelectStatement select_statement = DbMgr.CreateSelectClause();
                select_statement
                    .SelectCount()
                    .From("AuthRoleRole")
                    .Criteria
                        .IsEqual("AuthRoleRole", "ParentRoleID", _obj.RoleID)
                        .IsEqual("AuthRoleRole", "ChildRoleID", child_role.RoleID);
                bool relationship_not_found = ExecuteScalarInt(select_statement) == 0;
                if (relationship_not_found)
                {
                    clause = DbMgr.CreateInsertClause();
                    clause
                        .InsertColumn("ParentRoleID", DbMgr.CreateIntFieldEntry(_obj.RoleID))
                        .InsertColumn("ChildRoleID", DbMgr.CreateIntFieldEntry(child_role.RoleID))
                        .InsertColumn("Description", DbMgr.CreateStringFieldEntry(string.Format("{0} is superset of {1}", _obj.RoleName, child_role.RoleName)))
                        .Into("AuthRoleRole");

                    ExecuteNonQuery(clause);
                }
            }

            foreach (AuthItem item in _obj.ForbiddenItems)
            {
                DbSelectStatement select_statement = DbMgr.CreateSelectClause();
                select_statement
                    .SelectCount()
                    .From("AuthRoleItem")
                    .Criteria
                        .IsEqual("AuthRoleItem", "RoleID", _obj.RoleID)
                        .IsEqual("AuthRoleItem", "ItemID", item.ItemID);
                bool relationship_not_found = ExecuteScalarInt(select_statement) == 0;
                if (relationship_not_found)
                {
                    clause = DbMgr.CreateInsertClause();
                    clause
                        .InsertColumn("RoleID", DbMgr.CreateIntFieldEntry(_obj.RoleID))
                        .InsertColumn("ItemID", DbMgr.CreateIntFieldEntry(item.ItemID))
                        .InsertColumn("Description", DbMgr.CreateStringFieldEntry(string.Format("{0} can act on {1}", _obj.RoleName, item.ItemName)))
                        .Into("AuthRoleItem");

                    ExecuteNonQuery(clause);
                }
            }

            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }

    }
}
