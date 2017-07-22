using System;
using System.Collections.Generic;
using System.Text;


namespace Accounting.Core.Accounts
{
    using System.ComponentModel;
    using System.Data;
    using System.Data.Common;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public abstract class SubAccountTypeManager : EntityManager<SubAccountType>
    {
        public SubAccountTypeManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override SubAccountType _CreateDbEntity()
        {
            return new SubAccountType(true, this);
        }

        protected override SubAccountType _CreateEntity()
        {
            return new SubAccountType(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(SubAccountType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["SubAccountTypeID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.SubAccountTypeID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("SubAccountTypes");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectBySubAccountTypeID(string SubAccountTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("SubAccountTypes")
                .Criteria.IsEqual("SubAccountTypes", "SubAccountTypeID", SubAccountTypeID);

            return clause;
        }

        protected DbSelectStatement GetQuery_SelectCountBySubAccountTypeID(string SubAccountTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectCount()
                .From("SubAccountTypes")
                .Criteria.IsEqual("SubAccountTypes", "SubAccountTypeID", SubAccountTypeID);

            return clause;
        }

        public override bool Exists(SubAccountType _obj)
        {
            return ExecuteScalarInt(GetQuery_SelectCountBySubAccountTypeID(_obj.SubAccountTypeID)) != 0;
        }

        protected override SubAccountType _FindByTextId(string SubAccountTypeID)
        {
            if (Exists(SubAccountTypeID))
            {
                SubAccountType _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectBySubAccountTypeID(SubAccountTypeID));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<SubAccountType>_FindAllCollection()
        {
            List<SubAccountType> _grp = new List<SubAccountType>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                SubAccountType _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override void LoadFromReader(SubAccountType _obj, DbDataReader _reader)
        {
            _obj.SubAccountTypeID =GetString(_reader, ("SubAccountTypeID"));
            _obj.Description =GetString(_reader, ("Description"));
        }

        public bool Exists(string SubAccountTypeID)
        {
            return ExecuteScalarInt(GetQuery_SelectCountBySubAccountTypeID(SubAccountTypeID)) != 0;
        }
    }
}
