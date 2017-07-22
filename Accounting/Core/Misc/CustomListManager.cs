using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Misc
{
    public abstract class CustomListManager : EntityManager<CustomList>
    {
        public CustomListManager(DbManager mgr)
            : base(mgr)
        {
        }


        #region +(Factory Methods)
        protected override CustomList _CreateDbEntity()
        {
            return new CustomList(true, this);
        }

        protected override CustomList _CreateEntity()
        {
            return new CustomList(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(CustomList _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["CustomListID"] = DbMgr.CreateAutoIntFieldEntry(_obj.CustomListID);
            fields["CustomListText"] = DbMgr.CreateStringFieldEntry(_obj.CustomListText);
            fields["CustomListNumber"] = DbMgr.CreateIntFieldEntry(_obj.CustomListNumber);
            fields["CustomListName"] = DbMgr.CreateStringFieldEntry(_obj.CustomListName);
            fields["ChangeControl"] = DbMgr.CreateStringFieldEntry(_obj.ChangeControl);
            fields["CustomListType"] = DbMgr.CreateStringFieldEntry(_obj.CustomListType);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("CustomLists");
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByCustomListID(int CustomListID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("CustomLists")
                .Criteria.IsEqual("CustomLists", "CustomListID", CustomListID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCustomListID(int CustomListID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("CustomLists")
                .Criteria.IsEqual("CustomLists", "CustomListID", CustomListID);
            return clause;
        }

        private bool Exists(int? CustomListID)
        {
            if (CustomListID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByCustomListID(CustomListID.Value)) != 0;
        }

        public override bool Exists(CustomList _obj)
        {
            if (_obj.CustomListID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByCustomListID(_obj.CustomListID.Value)) != 0;
        }

        protected override void LoadFromReader(CustomList _obj, DbDataReader _reader)
        {
            _obj.CustomListID =GetInt32(_reader, ("CustomListID"));
            _obj.CustomListText = GetString(_reader, ("CustomListText"));
            _obj.CustomListNumber = GetInt32(_reader, "CustomListNumber");
            _obj.CustomListName = GetString(_reader, "CustomListName");
            _obj.ChangeControl = GetString(_reader, "ChangeControl");
            _obj.CustomListType = GetString(_reader, "CustomListType");
        }

        protected override IList<CustomList>_FindAllCollection()
        {
            List<CustomList> comments = new List<CustomList>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                CustomList _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                comments.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return comments;
        }

        protected override CustomList _FindByIntId(int? CustomListID)
        {
            if (Exists(CustomListID))
            {
                CustomList _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByCustomListID(CustomListID.Value));
                return _obj;
            }
            else
            {
                return CreateEntity();
            }
        }
    }
}
