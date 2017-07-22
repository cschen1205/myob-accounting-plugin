using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Accounts
{
    public abstract class AccountClassificationManager : EntityManager<AccountClassification>
    {
        public AccountClassificationManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override AccountClassification _CreateDbEntity()
        {
            return new AccountClassification(true, this);
        }

        protected override AccountClassification _CreateEntity()
        {
            return new AccountClassification(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(AccountClassification _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["AccountClassificationID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.AccountClassificationID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AccountClassification");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByAccountClassificationID(string AccountClassificationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AccountClassification")
                .Criteria.IsEqual("AccountClassification", "AccountClassificationID", AccountClassificationID);

            return clause;
        }

        protected DbSelectStatement GetQuery_SelectCountByAccountClassificationID(string AccountClassificationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("AccountClassification")
                .Criteria.IsEqual("AccountClassification", "AccountClassificationID", AccountClassificationID);

            return clause;
        }

        public override bool Exists(AccountClassification _obj)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByAccountClassificationID(_obj.AccountClassificationID)) != 0;
        }

        protected override AccountClassification _FindByTextId(string AccountClassificationID)
        {
            if (Exists(AccountClassificationID))
            {
                AccountClassification _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByAccountClassificationID(AccountClassificationID));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<AccountClassification>_FindAllCollection()
        {
            List<AccountClassification> _grp = new List<AccountClassification>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                AccountClassification _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override void LoadFromReader(AccountClassification _obj, DbDataReader _reader)
        {
            _obj.AccountClassificationID =GetString(_reader, ("AccountClassificationID"));
            _obj.Description =GetString(_reader, ("Description"));
        }

        public bool Exists(string AccountClassificationID)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByAccountClassificationID(AccountClassificationID)) != 0;
        }
    }
}
