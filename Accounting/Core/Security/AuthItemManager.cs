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
    public class AuthItemManager : EntityManager<AuthItem>
    {
        public AuthItemManager(DbManager mgr)
            : base(mgr)
        {
        }

        protected override AuthItem _CreateDbEntity()
        {
            return new AuthItem(true, this);
        }

        protected override AuthItem _CreateEntity()
        {
            return new AuthItem(false, this);
        }

        public override Dictionary<string, DbFieldEntry> GetFields(AuthItem _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["ItemID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ItemID);
            fields["ItemName"] = DbMgr.CreateStringFieldEntry(_obj.ItemName);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            fields["ParentItemID"] = DbMgr.CreateIntFieldEntry(_obj.ParentItemID);
            fields["DisplayName"] = DbMgr.CreateStringFieldEntry(_obj.DisplayName);
            return fields;
        }


        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AuthItem");

            return clause;
        }

        private void BuildAuthItemTree(XmlElement current_element, AuthItem current_item)
        {
            current_item.ItemName = current_element.Attributes["ItemName"].Value.ToString();
            current_item.Description = current_element.Attributes["Description"].Value.ToString();
            current_item.DisplayName = current_element.Attributes["DisplayName"].Value.ToString();
            foreach (XmlElement child_element in current_element.ChildNodes)
            {
                AuthItem child_item = CreateDbEntity();
                BuildAuthItemTree(child_element, child_item);
                child_item.ParentItem = current_item;
                current_item.Children.Add(child_item);
            }
        }

        public virtual void BuildAuthItemSchema(string schema_file)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(schema_file);
            XmlElement root = doc.DocumentElement;
            List<AuthItem> items = new List<AuthItem>();

            foreach (XmlElement child_element in root.ChildNodes)
            {
                if (child_element.Name.Equals("AuthItem"))
                {
                    AuthItem item = CreateDbEntity();
                    BuildAuthItemTree(child_element, item);
                    items.Add(item);
                }
            }

            foreach (AuthItem item in items)
            {
                Store(item);
            }
        }

        public virtual void RebuildAuthItemSchema(string schema_file)
        {
            CleanAuthItemSchema();
            BuildAuthItemSchema(schema_file);
        }

        public virtual void CleanAuthItemSchema()
        {
            DbDeleteStatement clause = DbMgr.CreateDeleteClause();
            ExecuteNonQuery(clause.DeleteFrom("AuthItem"));
        }

        private DbSelectStatement GetQuery_SelectByItemID(int ItemID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AuthItem")
                .Criteria
                    .IsEqual("AuthItem", "ItemID", ItemID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByItemName(string ItemName)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AuthItem")
                .Criteria
                    .IsEqual("AuthItem", "ItemName", ItemName);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByItemID(int ItemID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("AuthItem")
                .Criteria
                    .IsEqual("AuthItem", "ItemID", ItemID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByItemName(string ItemName)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("AuthItem")
                .Criteria
                    .IsEqual("AuthItem", "ItemName", ItemName);

            return clause;
        }

        public bool Exists(int? ItemID)
        {
            if (ItemID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByItemID(ItemID.Value)) != 0;
        }

        public bool Exists(string ItemName)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByItemName(ItemName)) != 0;
        }

        public override bool Exists(AuthItem _obj)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByItemName(_obj.ItemName)) != 0;
        }

        public bool CanDelete(AuthItem _obj)
        {
            return CanDelete(_obj.ItemID);
        }

        public bool CanDelete(int? ItemID)
        {
            if (ItemID == null) return false;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("AuthRoleItem")
                .Criteria
                    .IsEqual("AuthRoleItem", "ItemID", ItemID.Value);


            if (ExecuteScalarInt(clause) != 0)
            {
                return false;
            }

            clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("AuthItem")
                .Criteria
                    .IsEqual("AuthItem", "ParentItemID", ItemID.Value);

            if (ExecuteScalarInt(clause) != 0)
            {
                return false;
            }

            return true;
        }

        protected override void LoadFromReader(AuthItem _obj, System.Data.Common.DbDataReader reader)
        {
            _obj.ParentItemID = GetInt32(reader, "ParentItemID");
            _obj.ItemID = GetInt32(reader, "ItemID");
            _obj.ItemName = GetString(reader, "ItemName");
            _obj.Description = GetString(reader, "Description");
            _obj.DisplayName = GetString(reader, "DisplayName");
        }

        protected override object GetDbProperty(AuthItem _obj, string property_name)
        {
            if (property_name.Equals("ParentItem"))
            {
                return RepositoryMgr.AuthItemMgr.FindById(_obj.ParentItemID);
            }
            else if (property_name.Equals("Children"))
            {
                return RepositoryMgr.AuthItemMgr.List(_obj.ItemID);
            }
           
            return null;
        }

        public List<AuthItem> List(int? ParentItemID)
        {
            List<AuthItem> items = new List<AuthItem>();
            if (ParentItemID == null) return items;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AuthItem")
                .Criteria
                    .IsEqual("AuthItem", "ParentItemID", ParentItemID);
            
            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                AuthItem _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);

                items.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return items;
        }

        public virtual IList<AuthItem> FindRootCollection()
        {
            IList<AuthItem> tmparray=FindAllCollection();

            List<AuthItem> roots = new List<AuthItem>();
            foreach (AuthItem _obj in tmparray)
            {
                if (_obj.ParentItem == null)
                {
                    roots.Add(_obj);
                }
            }

            return roots;
        }

        protected override IList<AuthItem>_FindAllCollection()
        {
            List<AuthItem> tmparray = new List<AuthItem>();
            

            DbSelectStatement clause = GetQuery_SelectAll();
            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                AuthItem _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                tmparray.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();


            return tmparray;
        }

        protected override AuthItem _FindByIntId(int? ItemID)
        {
            if (Exists(ItemID))
            {
                AuthItem _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByItemID(ItemID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override AuthItem _FindByTextId(string ItemName)
        {
            if (Exists(ItemName))
            {
                AuthItem _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByItemName(ItemName));
                return _obj;
            }
            else
            {
                return null;
            }
        }


        public DataTable Table()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectColumn("AuthItem", "ItemID", "ID")
                .SelectColumn("AuthItem", "Description", "Description")
                .From("AuthItem");
            

            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Description");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                DataRow row = table.NewRow();
                row["ID"] = GetInt32(_reader, "ID");
                row["Description"] = GetString(_reader, "Description");
                table.Rows.Add(row);
            }

            _reader.Close();
            _cmd.Dispose();

            return table;
        }
    }
}
