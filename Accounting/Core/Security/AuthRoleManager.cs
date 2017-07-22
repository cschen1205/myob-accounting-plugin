using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db;
using Accounting.Db.Elements;
using System.Data;
using System.Data.Common;
using System.Xml;

namespace Accounting.Core.Security
{
    public class AuthRoleManager : EntityManager<AuthRole>
    {
        public AuthRoleManager(DbManager mgr)
            : base(mgr)
        {

        }

        protected override AuthRole _CreateDbEntity()
        {
            return new AuthRole(true, this);
        }

        protected override AuthRole _CreateEntity()
        {
            return new AuthRole(false, this);
        }


        public override Dictionary<string, DbFieldEntry> GetFields(AuthRole _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["RoleID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RoleID);
            fields["RoleName"] = DbMgr.CreateStringFieldEntry(_obj.RoleName);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            fields["FullControl"] = DbMgr.CreateStringFieldEntry(_obj.FullControl);
            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AuthRole");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByRoleID(int RoleID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AuthRole")
                .Criteria
                    .IsEqual("AuthRole", "RoleID", RoleID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByRoleName(string RoleName)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AuthRole")
                .Criteria
                    .IsEqual("AuthRole", "RoleName", RoleName);

            return clause;
        }

        public bool CanDelete(AuthRole _obj)
        {
            return CanDeleteByRoleID(_obj.RoleID);
        }

        public bool CanDeleteByRoleID(int? RoleID)
        {
            if (RoleID == null) return false;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("AuthRoleRole")
                .Criteria
                    .IsEqual("AuthRoleRole", "ChildRoleID", RoleID.Value);


            if (ExecuteScalarInt(clause) != 0)
            {
                return false;
            }

            clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("AuthUser")
                .Criteria
                    .IsEqual("AuthUser", "RoleID", RoleID.Value);


            if (ExecuteScalarInt(clause) != 0)
            {
                return false;
            }
            return true;
            
        }

        private DbSelectStatement GetQuery_SelectCountByRoleID(int RoleID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("AuthRole")
                .Criteria
                    .IsEqual("AuthRole", "RoleID", RoleID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRoleName(string RoleName)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("AuthRole")
                .Criteria
                    .IsEqual("AuthRole", "RoleName", RoleName);

            return clause;
        }

        public bool ExistsByRoleID(int? RoleID)
        {
            if (RoleID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRoleID(RoleID.Value)) != 0;
        }

        public bool ExistsByRoleName(string RoleName)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByRoleName(RoleName)) != 0;
        }

        public override bool Exists(AuthRole _obj)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByRoleName(_obj.RoleName)) != 0;
        }

        protected override void LoadFromReader(AuthRole _obj, System.Data.Common.DbDataReader reader)
        {
            _obj.RoleID = GetInt32(reader, "RoleID");
            _obj.RoleName = GetString(reader, "RoleName");
            _obj.Description = GetString(reader, "Description");
            _obj.FullControl = GetString(reader, "FullControl");
        }

        protected override object GetDbProperty(AuthRole _obj, string property_name)
        {
            if (property_name.Equals("Children"))
            {
                List<int> child_role_ids = new List<int>();
                DbSelectStatement clause = DbMgr.CreateSelectClause();
                clause
                    .SelectColumn("AuthRoleRole", "ChildRoleID")
                    .From("AuthRoleRole")
                    .Criteria
                        .IsEqual("AuthRoleRole", "ParentRoleID", _obj.RoleID);

                DbCommand cmd = DbMgr.CreateDbCommand(clause);
                DbDataReader _reader = cmd.ExecuteReader();
                while (_reader.Read())
                {
                    int? child_role_id = GetInt32(_reader, "ChildRoleID");
                    if (child_role_id != null)
                    {
                        child_role_ids.Add(child_role_id.Value);
                    }
                }
                _reader.Close();
                cmd.Dispose();

                List<AuthRole> child_roles = new List<AuthRole>();
                foreach (int child_role_id in child_role_ids)
                {
                    AuthRole child_role = RepositoryMgr.AuthRoleMgr.FindByRoleID(child_role_id);
                    if (child_role != null)
                    {
                        child_roles.Add(child_role);
                    }
                }
                return child_roles;
            }
            else if(property_name.Equals("Items"))
            {
                List<int> item_ids = new List<int>();
                DbSelectStatement clause = DbMgr.CreateSelectClause();
                clause
                    .SelectColumn("AuthRoleItem", "ItemID")
                    .From("AuthRoleItem")
                    .Criteria
                        .IsEqual("AuthRoleItem", "RoleID", _obj.RoleID);

                DbCommand cmd = DbMgr.CreateDbCommand(clause);
                DbDataReader _reader = cmd.ExecuteReader();
                while (_reader.Read())
                {
                    int? item_id = GetInt32(_reader, "ItemID");
                    if (item_id != null)
                    {
                        item_ids.Add(item_id.Value);
                    }
                }
                _reader.Close();
                cmd.Dispose();

                List<AuthItem> items = new List<AuthItem>();
                foreach (int item_id in item_ids)
                {
                    AuthItem item = RepositoryMgr.AuthItemMgr.FindById(item_id);
                    if (item != null)
                    {
                        items.Add(item);
                    }
                }
                return items;
            }
            return null;
        }

        public List<AuthRole> FindCollectionByParentRoleID(int ParentRoleID)
        {
            List<AuthRole> roless = new List<AuthRole>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AuthRole")
                .Criteria
                    .IsEqual("AuthRole", "ParentRoleID", ParentRoleID);
            
            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                AuthRole _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);

                roless.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return roless;
        }

        protected override IList<AuthRole>_FindAllCollection()
        {
            List<AuthRole> terms = new List<AuthRole>();

            DbSelectStatement clause = GetQuery_SelectAll();
            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                AuthRole _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);

                terms.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return terms;
        }

        public AuthRole FindByRoleID(int? RoleID)
        {
            if (ExistsByRoleID(RoleID))
            {
                AuthRole _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByRoleID(RoleID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        public AuthRole FindByRoleName(string RoleName)
        {
            if (ExistsByRoleName(RoleName))
            {
                AuthRole _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByRoleName(RoleName));
                return _obj;
            }
            else
            {
                return null;
            }
        }

      

        private void BuildAuthRoleTree(XmlElement current_element, Dictionary<string, AuthRole> roles, string current_name)
        {
            AuthRole current_role = roles[current_name];
            foreach (XmlElement child_element in current_element.ChildNodes)
            {
                if (child_element.Name.Equals("AuthItems"))
                {
                    
                    foreach(XmlElement child_element2 in child_element.ChildNodes)
                    {
                        if(child_element2.Name.Equals("AuthItem"))
                        {                
                            string authitem_name = child_element2.Attributes["ItemName"].Value.ToString();
                            AuthItem item = RepositoryMgr.AuthItemMgr.FindById(authitem_name);
                            if (item != null)
                            {
                    
                                current_role.ForbiddenItems.Add(item);
                            }
                        }
                    }
                }
                else if (child_element.Name.Equals("Children"))
                {
                    foreach (XmlElement child_element2 in child_element.ChildNodes)
                    {
                        if (child_element2.Name.Equals("AuthRole"))
                        {
                            string child_role_name = child_element2.Attributes["RoleName"].Value.ToString();
                            current_role.Children.Add(roles[child_role_name]);
                        }
                    }
                }
            }
        }

        public virtual void BuildAuthRoleSchema(string schema_file)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(schema_file);
            XmlElement root = doc.DocumentElement;
            Dictionary<string, AuthRole> roles = new Dictionary<string, AuthRole>();

            foreach (XmlElement child_element in root.ChildNodes)
            {
                if (child_element.Name.Equals("AuthRole"))
                {
                    string name = child_element.Attributes["RoleName"].Value.ToString();
                    string description = child_element.Attributes["Description"].Value.ToString();
                    string full_control = child_element.Attributes["FullControl"].Value.ToString();
                    AuthRole role = CreateDbEntity();
                    role.RoleName = name;
                    role.FullControl = full_control;
                    role.Description = description;
                    roles[name] = role;
                }
            }

            foreach (XmlElement child_element in root.ChildNodes)
            {
                if (child_element.Name.Equals("AuthRole"))
                {
                    string name = child_element.Attributes["RoleName"].Value.ToString();
                    BuildAuthRoleTree(child_element, roles, name);
                }
            }

            foreach (AuthRole role in roles.Values)
            {
                Store(role);
            }
        }

        protected override AuthRole _FindByTextId(string RoleName)
        {
            if (ExistsByRoleName(RoleName))
            {
                AuthRole _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByRoleName(RoleName));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        public virtual void RebuildAuthRoleSchema(string schema_file)
        {
            RecreateTable();
            //CleanAuthRoleSchema();
            BuildAuthRoleSchema(schema_file);
        }

        /*
        public virtual void CleanAuthRoleSchema()
        {
            DbDeleteStatement clause = null;
            clause=DbMgr.CreateDeleteClause();
            ExecuteNonQuery(clause.DeleteFrom("AuthRole"));

            clause = DbMgr.CreateDeleteClause();
            ExecuteNonQuery(clause.DeleteFrom("AuthRoleItem"));

            clause = DbMgr.CreateDeleteClause();
            ExecuteNonQuery(clause.DeleteFrom("AuthRoleRole"));
        }
        */
    }
}
