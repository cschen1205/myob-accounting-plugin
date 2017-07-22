using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Accounts
{
    public abstract class AccountTypeManager : EntityManager<AccountType>
    {
        public AccountTypeManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override AccountType _CreateDbEntity()
        {
            return new AccountType(true, this);
        }

        protected override AccountType _CreateEntity()
        {
            return new AccountType(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(AccountType _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["AccountTypeID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.AccountTypeID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AccountType");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByAccountTypeID(string AccountTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AccountType")
                .Criteria.IsEqual("AccountType", "AccountTypeID", AccountTypeID);

            return clause;
        }

        protected DbSelectStatement GetQuery_SelectCountByAccountTypeID(string AccountTypeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("AccountType")
                .Criteria.IsEqual("AccountType", "AccountTypeID", AccountTypeID);

            return clause;
        }

        public override bool Exists(AccountType _obj)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByAccountTypeID(_obj.AccountTypeID)) != 0;
        }

        protected override AccountType _FindByTextId(string AccountTypeID)
        {
            if (Exists(AccountTypeID))
            {
                AccountType _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByAccountTypeID(AccountTypeID));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<AccountType>_FindAllCollection()
        {
            List<AccountType> _grp = new List<AccountType>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                AccountType _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override void LoadFromReader(AccountType _obj, DbDataReader _reader)
        {
            _obj.AccountTypeID =GetString(_reader, ("AccountTypeID"));
            _obj.Description =GetString(_reader, ("Description"));
        }

        public bool Exists(string AccountTypeID)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByAccountTypeID(AccountTypeID)) != 0;
        }
    }
}
