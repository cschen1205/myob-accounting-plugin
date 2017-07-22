using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class EmploymentCategoryManager : EntityManager<EmploymentCategory>
    {
        public EmploymentCategoryManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override EmploymentCategory _CreateDbEntity()
        {
            return new EmploymentCategory(true, this);
        }
        protected override EmploymentCategory _CreateEntity()
        {
            return new EmploymentCategory(false, this);
        }
        #endregion

        protected override void LoadFromReader(EmploymentCategory _obj, DbDataReader reader)
        {
            _obj.EmploymentCategoryID = GetString(reader, "EmploymentCategoryID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(EmploymentCategory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["EmploymentCategoryID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.EmploymentCategoryID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("EmploymentCategory");
        }

        private DbSelectStatement GetQuery_SelectByEmploymentCategoryID(string EmploymentCategoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("EmploymentCategory")
                .Criteria
                    .IsEqual("EmploymentCategory", "EmploymentCategoryID", EmploymentCategoryID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByEmploymentCategoryID(string EmploymentCategoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("EmploymentCategory")
                .Criteria
                    .IsEqual("EmploymentCategory", "EmploymentCategoryID", EmploymentCategoryID);

            return clause;
        }

        public bool Exists(string EmploymentCategoryID)
        {
            if (EmploymentCategoryID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByEmploymentCategoryID(EmploymentCategoryID)) != 0;
        }

        public override bool Exists(EmploymentCategory _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.EmploymentCategoryID);
        }

        protected override EmploymentCategory _FindByTextId(string EmploymentCategoryID)
        {
            EmploymentCategory _obj = null;
            if (EmploymentCategoryID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByEmploymentCategoryID(EmploymentCategoryID));
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

        protected override IList<EmploymentCategory>_FindAllCollection()
        {
            List<EmploymentCategory> _grp = new List<EmploymentCategory>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                EmploymentCategory _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
