using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db;
using Accounting.Db.Elements;
using System.Data;
using System.Data.Common;
using System.Xml;
using Accounting.Core.Cryptography;

namespace Accounting.Core.Security
{
    public class AuthUserManager : EntityManager<AuthUser>
    {
        public AuthUserManager(DbManager mgr)
            : base(mgr)
        {

        }

        protected override AuthUser _CreateDbEntity()
        {
            return new AuthUser(true, this);
        }

        protected override AuthUser _CreateEntity()
        {
            return new AuthUser(false, this);
        }

        public override Dictionary<string, DbFieldEntry> GetFields(AuthUser _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["AuthUserID"] = DbMgr.CreateAutoIntFieldEntry(_obj.UserID);
            fields["AuthUsername"] = DbMgr.CreateStringFieldEntry(_obj.Username.ToLower());
            fields["AuthPassword"] = DbMgr.CreateStringFieldEntry(Encrypt(_obj.Password));
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            fields["RoleID"] = DbMgr.CreateIntFieldEntry(_obj.RoleID);
            fields["UseTimeslipsLink"] = DbMgr.CreateStringFieldEntry(_obj.UseTimeslipsLink);
            fields["UseBillingUnits"] = DbMgr.CreateStringFieldEntry(_obj.UseBillingUnits);
            fields["BillingUnit"] = DbMgr.CreateIntFieldEntry(_obj.BillingUnit);
            fields["RoundCalculatedTime"] = DbMgr.CreateStringFieldEntry(_obj.RoundCalculatedTime);
            fields["RoundToID"] = DbMgr.CreateStringFieldEntry(_obj.RoundToID);
            fields["MinuteIncrement"] = DbMgr.CreateIntFieldEntry(_obj.MinuteIncrement);
            fields["IncludeItemsInTimeBilling"] = DbMgr.CreateStringFieldEntry(_obj.IncludeItemsInTimeBilling);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AuthUser");

            return clause;
        }

        protected string Encrypt(string value)
        {
            CryptorManager cm = CryptorManager.Instance;
            return cm.encrypt(value);
        }

        protected string Decrypt(string encrypted_value)
        {
            CryptorManager cm = CryptorManager.Instance;
            return cm.decrypt(encrypted_value);
        }

        public bool HasAuthUsers()
        {
            if (!DbMgr.TableExists("AuthUser"))
            {
                return false;
            }
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectCount().From("AuthUser");
            return ExecuteScalarInt(clause) != 0;
        }

        public bool HasUser(string username)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectCount().From("AuthUser").Criteria.IsEqual("AuthUser", "AuthUsername", username);
            return ExecuteScalarInt(clause) != 0;
        }

        public AuthUser Authenticate(string username, string password, out string error, out bool valid_login)
        {
            error = "No Error";
            valid_login = false;
            if (!HasAuthUsers())
            {
                error = "No Auth Users in the current database!";
                valid_login = true;
                return null;
            }
            if (!HasUser(username))
            {
                error = string.Format("Username [{0}] is not defined!", username);
                return null;
            }
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("AuthUser")
                .Criteria
                    .IsEqual("AuthUser", "AuthUsername", username.ToLower())
                    .IsEqual("AuthUser", "AuthPassword", Encrypt(password));

            if (ExecuteScalarInt(clause) != 0)
            {
                AuthUser user = _FindByTextId(username);
                if (user != null || user.Role != null)
                {
                    valid_login = true;
                    return user;
                }
                else
                {
                    error = "Invalid Secury role associated with this account!";
                }
            }
            else
            {
                error = "Invalid password!";
            }
            return null;
        }

        protected override AuthUser _FindByTextId(string username)
        {
            if (!HasUser(username)) return null;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectColumn("AuthUser", "AuthUserID")
                .From("AuthUser")
                .Criteria
                    .IsEqual("AuthUser", "AuthUsername", username);

            int UserID = ExecuteScalarInt(clause);
            return FindByUserID(UserID);
        }

        private DbSelectStatement GetQuery_SelectByUserID(int UserID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AuthUser")
                .Criteria
                    .IsEqual("AuthUser", "AuthUserID", UserID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByUsername(string Username)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AuthUser")
                .Criteria
                    .IsEqual("AuthUser", "AuthUsername", Username);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByUserID(int UserID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("AuthUser")
                .Criteria
                    .IsEqual("AuthUser", "AuthUserID", UserID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByUsername(string Username)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("AuthUser")
                .Criteria
                    .IsEqual("AuthUser", "AuthUsername", Username);

            return clause;
        }

        public bool ExistsByUserID(int? UserID)
        {
            if (UserID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByUserID(UserID.Value)) != 0;
        }

        public bool ExistsByUsername(string Username)
        {
            if (string.IsNullOrEmpty(Username)) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByUsername(Username)) != 0;
        }

        public override bool Exists(AuthUser _obj)
        {
            return ExistsByUsername(_obj.Username);
        }

        protected override void LoadFromReader(AuthUser _obj, System.Data.Common.DbDataReader reader)
        {
            _obj.UserID = GetInt32(reader, "AuthUserID");
            _obj.Username = GetString(reader, "AuthUsername");
            _obj.Password = Decrypt(GetString(reader, "AuthPassword"));
            _obj.RoleID = GetInt32(reader, "RoleID");
            _obj.Description = GetString(reader, "Description");
            _obj.UseTimeslipsLink = GetString(reader, "UseTimeslipsLink");
            _obj.UseBillingUnits = GetString(reader, "UseBillingUnits");
            _obj.BillingUnit = GetInt32(reader, "BillingUnit");
            _obj.RoundCalculatedTime = GetString(reader, "RoundCalculatedTime");
            _obj.RoundToID = GetString(reader, "RoundToID");
            _obj.MinuteIncrement = GetInt32(reader, "MinuteIncrement");
            _obj.IncludeItemsInTimeBilling = GetString(reader, "IncludeItemsInTimeBilling");
        }

        protected override object GetDbProperty(AuthUser _obj, string property_name)
        {
            if (property_name.Equals("Role"))
            {
                return RepositoryMgr.AuthRoleMgr.FindByRoleID(_obj.RoleID);
            }
            else if (property_name.Equals("RoundTo"))
            {
                return RepositoryMgr.RoundingMgr.FindById(_obj.RoundToID);
            }
            return null;
        }

        protected override IList<AuthUser>_FindAllCollection()
        {
            List<AuthUser> users = new List<AuthUser>();

            DbSelectStatement clause = GetQuery_SelectAll();
            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                AuthUser _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);

                users.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return users;
        }

        public AuthUser FindByUserID(int? UserID)
        {
            if (ExistsByUserID(UserID))
            {
                AuthUser _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByUserID(UserID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        public AuthUser FindByUsername(string Username)
        {
            if (ExistsByUsername(Username))
            {
                AuthUser _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByUsername(Username));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        public void Delete(int UserID)
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            clause.DeleteFrom("AuthUser").Criteria.IsEqual("AuthUser", "AuthUserID", UserID);
            ExecuteNonQuery(clause);
        }

        public virtual void BuildAuthUserSchema(string schema_file)
        {
           
            XmlDocument doc = new XmlDocument();
            doc.Load(schema_file);
            XmlElement root = doc.DocumentElement;
            List<AuthUser> users = new List<AuthUser>();

            foreach (XmlElement child_element in root.ChildNodes)
            {
                if (child_element.Name.Equals("AuthUser"))
                {
                    AuthUser user = CreateDbEntity();
                    string rolename = child_element.Attributes["RoleName"].Value.ToString();
                    string username = child_element.Attributes["Username"].Value.ToString();
                    string password = child_element.Attributes["Password"].Value.ToString();
                    string description = child_element.Attributes["Description"].Value.ToString();
                    user.Role = RepositoryMgr.AuthRoleMgr.FindById(rolename);
                    user.Username = username;
                    user.Password = password;
                    user.Description = description;
                    users.Add(user);
                }
            }

            foreach (AuthUser user in users)
            {
                Store(user);
            }
        }

        public virtual void RebuildAuthUserSchema(string schema_file)
        {
            CleanAuthUserSchema();
            BuildAuthUserSchema(schema_file);
        }

        public virtual void CleanAuthUserSchema()
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            ExecuteNonQuery(clause.DeleteFrom("AuthUser"));
        }
    }
}
