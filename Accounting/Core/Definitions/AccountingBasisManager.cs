using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class AccountingBasisManager : EntityManager<AccountingBasis>
    {
        public AccountingBasisManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override AccountingBasis _CreateDbEntity()
        {
            return new AccountingBasis(true, this);
        }
        protected override AccountingBasis _CreateEntity()
        {
            return new AccountingBasis(false, this);
        }
        #endregion

        protected override void LoadFromReader(AccountingBasis _obj, DbDataReader reader)
        {
            _obj.AccountingBasisID = GetString(reader, "AccountingBasisID");
            _obj.Description = GetString(reader, "Description");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(AccountingBasis _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["AccountingBasisID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.AccountingBasisID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("AccountingBasis");
        }

        private DbSelectStatement GetQuery_SelectByAccountingBasisID(string AccountingBasisID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("AccountingBasis")
                .Criteria
                    .IsEqual("AccountingBasis", "AccountingBasisID", AccountingBasisID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByAccountingBasisID(string AccountingBasisID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("AccountingBasis")
                .Criteria
                    .IsEqual("AccountingBasis", "AccountingBasisID", AccountingBasisID);

            return clause;
        }

        public bool Exists(string AccountingBasisID)
        {
            if (AccountingBasisID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByAccountingBasisID(AccountingBasisID)) != 0;
        }

        public override bool Exists(AccountingBasis _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.AccountingBasisID);
        }

        protected override AccountingBasis _FindByTextId(string AccountingBasisID)
        {
            AccountingBasis _obj = null;
            if (AccountingBasisID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByAccountingBasisID(AccountingBasisID));
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

        protected override IList<AccountingBasis>_FindAllCollection()
        {
            List<AccountingBasis> _grp = new List<AccountingBasis>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                AccountingBasis _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
