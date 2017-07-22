using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Inventory
{
    public class ItemDataFieldEntryManager : EntityManager<ItemDataFieldEntry>
    {
        public ItemDataFieldEntryManager(DbManager mgr)
            : base(mgr)
        {
        }

        protected override ItemDataFieldEntry _CreateEntity()
        {
            return new ItemDataFieldEntry(false, this);
        }

        protected override ItemDataFieldEntry _CreateDbEntity()
        {
            return new ItemDataFieldEntry(true, this);
        }

        public override bool Exists(ItemDataFieldEntry _obj)
        {
            if (_obj == null) return false;
            return ExistsByItemDataFieldEntryID(_obj.ItemDataFieldEntryID);
        }

        public virtual bool ExistsByItemDataFieldEntryID(int? ItemDataFieldEntryID)
        {
            if (ItemDataFieldEntryID == null) return false;
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("ItemDataFieldEntries")
                .Criteria
                    .IsEqual("ItemDataFieldEntries", "ItemDataFieldEntryID", ItemDataFieldEntryID);

            return DbMgr.ExecuteScalarInt(clause) != 0;
        }

        public virtual bool ExistsByItemNumberAndDataFieldID(string ItemNumber, int? DataFieldID)
        {
            if (DataFieldID == null) return false;
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("ItemDataFieldEntries")
                .Criteria
                    .IsEqual("ItemDataFieldEntries", "ItemNumber", ItemNumber)
                    .IsEqual("ItemDataFieldEntries", "DataFieldID", DataFieldID);

            return DbMgr.ExecuteScalarInt(clause) != 0;
        }

        //public object Table(string ItemNumber)
        //{
        //    IList<ItemDataFieldEntry> _grp = List(ItemNumber);

        //    DataTable table = new DataTable();
        //    table.Columns.Add("ID");
        //    table.Columns.Add("FieldName");
        //    table.Columns.Add("FieldValue");

        //    foreach(ItemDataFieldEntry _obj in _grp)
        //    {
        //        DataRow row = table.NewRow();
        //        row["ID"] = _obj.ItemDataFieldEntryID;
        //        row["FieldName"] = _obj.DataField.DataFieldName;
        //        row["FieldValue"] = _obj.Content;
        //        table.Rows.Add(row);
        //    }
            

        //    return table;
        //}

        protected override void LoadFromReader(ItemDataFieldEntry _obj, DbDataReader reader)
        {
            _obj.ItemDataFieldEntryID = GetInt32(reader, "ItemDataFieldEntryID");
            _obj.DataFieldID = GetInt32(reader, "DataFieldID");
            _obj.ItemNumber = GetString(reader, "ItemNumber");
            _obj.Content = GetString(reader, "Content");
        }

        public virtual IList<ItemDataFieldEntry> FindCollectionByItemNumber(string ItemNumber)
        {
            List<ItemDataFieldEntry> _grp = new List<ItemDataFieldEntry>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ItemDataFieldEntries")
                .Criteria
                    .IsEqual("ItemDataFieldEntries", "ItemNumber", ItemNumber);

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ItemDataFieldEntry _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        public virtual ItemDataFieldEntry FindByItemNumberAndDataFieldID(string ItemNumber, int? DataFieldID)
        {
            if (string.IsNullOrEmpty(ItemNumber)) return null;
            ItemDataFieldEntry _obj = null;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ItemDataFieldEntries")
                .Criteria
                    .IsEqual("ItemDataFieldEntries", "ItemNumber", ItemNumber)
                    .IsEqual("ItemDataFieldEntries", "DataFieldID", DataFieldID);

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            if (_reader.Read())
            {
                _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
            }

            _reader.Close();
            _cmd.Dispose();

            return _obj;
        }

        protected override object GetDbProperty(ItemDataFieldEntry _obj, string property_name)
        {
            if (property_name.Equals("Item"))
            {
                return RepositoryMgr.ItemMgr.FindById(_obj.ItemNumber);
            }
            else if (property_name.Equals("DataField"))
            {
                return RepositoryMgr.DataFieldMgr.FindById(_obj.DataFieldID);
            }
            return null;
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ItemDataFieldEntry _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ItemDataFieldEntryID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ItemDataFieldEntryID);
            fields["DataFieldID"] = DbMgr.CreateIntFieldEntry(_obj.DataFieldID);
            fields["ItemNumber"] = DbMgr.CreateStringFieldEntry(_obj.ItemNumber);
            fields["Content"] = DbMgr.CreateStringFieldEntry(_obj.Content);

            return fields;
        }

        protected override IList<ItemDataFieldEntry>_FindAllCollection()
        {
            List<ItemDataFieldEntry> _grp = new List<ItemDataFieldEntry>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ItemDataFieldEntries");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ItemDataFieldEntry _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        public virtual IList<ItemDataFieldEntry> List(string ItemNumber)
        {
            List<ItemDataFieldEntry> _grp = new List<ItemDataFieldEntry>();
            if (string.IsNullOrEmpty(ItemNumber)) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ItemDataFieldEntries")
                .Criteria
                    .IsEqual("ItemDataFieldEntries", "ItemNumber", ItemNumber);

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ItemDataFieldEntry _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        public virtual ItemDataFieldEntry FindByItemDataFieldEntryID(int? ItemDataFieldEntryID)
        {
            ItemDataFieldEntry _obj=null;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ItemDataFieldEntries")
                .Criteria
                    .IsEqual("ItemDataFieldEntries", "ItemDataFieldEntryID", ItemDataFieldEntryID);

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            if (_reader.Read())
            {
                _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
            }

            _reader.Close();
            _cmd.Dispose();

            return _obj;
        }
    }
}
