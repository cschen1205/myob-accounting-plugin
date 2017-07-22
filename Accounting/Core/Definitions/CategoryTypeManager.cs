using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class CategoryTypeManager : EntityManager<CategoryType>
    {
        public CategoryTypeManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override CategoryType _CreateDbEntity()
        {
            return new CategoryType(true, this);
        }
        protected override CategoryType _CreateEntity()
        {
            return new CategoryType(false, this);
        }
        #endregion

        protected override void LoadFromReader(CategoryType _obj, DbDataReader reader)
        {
            _obj.CategoryTypeID = GetString(reader, "CategoryTypeID", "CategoryTypesID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(CategoryType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CategoryTypeID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.CategoryTypeID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("CategoryTypes");
        }

        private DbSelectStatement GetQuery_SelectByCategoryTypeID(string CategoryTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("CategoryTypes")
                .Criteria
                    .IsEqual("CategoryTypes", "CategoryTypeID", CategoryTypeID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByCategoryTypeID(string CategoryTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("CategoryTypes")
                .Criteria
                    .IsEqual("CategoryTypes", "CategoryTypeID", CategoryTypeID);

            return clause;
        }

        public bool Exists(string CategoryTypeID)
        {
            if (CategoryTypeID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByCategoryTypeID(CategoryTypeID)) != 0;
        }

        public override bool Exists(CategoryType _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.CategoryTypeID);
        }

        protected override CategoryType _FindByTextId(string CategoryTypeID)
        {
            CategoryType _obj = null;
            if (CategoryTypeID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByCategoryTypeID(CategoryTypeID));
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

        protected override IList<CategoryType>_FindAllCollection()
        {
            List<CategoryType> _grp = new List<CategoryType>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                CategoryType _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
