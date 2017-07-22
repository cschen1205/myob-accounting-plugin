using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class ContributionTypeManager : EntityManager<ContributionType>
    {
        public ContributionTypeManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override ContributionType _CreateDbEntity()
        {
            return new ContributionType(true, this);
        }
        protected override ContributionType _CreateEntity()
        {
            return new ContributionType(false, this);
        }
        #endregion

        protected override void LoadFromReader(ContributionType _obj, DbDataReader reader)
        {
            _obj.ContributionTypeID = GetString(reader, "ContributionTypeID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ContributionType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ContributionTypeID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.ContributionTypeID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("ContributionTypes");
        }

        private DbSelectStatement GetQuery_SelectByContributionTypeID(string ContributionTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("ContributionTypes")
                .Criteria
                    .IsEqual("ContributionTypes", "ContributionTypeID", ContributionTypeID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByContributionTypeID(string ContributionTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("ContributionTypes")
                .Criteria
                    .IsEqual("ContributionTypes", "ContributionTypeID", ContributionTypeID);

            return clause;
        }

        public bool Exists(string ContributionTypeID)
        {
            if (ContributionTypeID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByContributionTypeID(ContributionTypeID)) != 0;
        }

        public override bool Exists(ContributionType _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.ContributionTypeID);
        }

        protected override ContributionType _FindByTextId(string ContributionTypeID)
        {
            ContributionType _obj = null;
            if (ContributionTypeID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByContributionTypeID(ContributionTypeID));
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

        protected override IList<ContributionType>_FindAllCollection()
        {
            List<ContributionType> _grp = new List<ContributionType>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                ContributionType _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
