using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db;
using Accounting.Db.Elements;
using System.Data.Common;

namespace Accounting.Core.Accounts
{
    using System.ComponentModel;

    public abstract class AccountActivityManager : EntityManager<AccountActivity>
    {
        public AccountActivityManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override AccountActivity _CreateEntity()
        {
            return new AccountActivity(false, this);
        }

        protected override AccountActivity _CreateDbEntity()
        {
            return new AccountActivity(true, this);
        }
        #endregion

        protected override object GetDbProperty(AccountActivity _obj, string property_name)
        {
            if (property_name.Equals("Account"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.AccountID);
            }
            return null;
        }

        protected override void LoadFromReader(AccountActivity _obj, DbDataReader reader)
        {
            _obj.AccountActivityID = GetInt32(reader, "AccountActivityID");
            _obj.AccountID = GetInt32(reader, "AccountID");
            _obj.Amount = GetDouble(reader, "Amount");
            _obj.FinancialYear = GetInt32(reader, "FinancialYear");
            _obj.Period = GetInt32(reader, "Period");
        }

        public bool Exists(int? AccountActivityID)
        {
            if (AccountActivityID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByAccountActivityID(AccountActivityID.Value)) != 0;
        }

        public bool Exists(int? account_id, int? year, int? period)
        {
            if (account_id == null && year==null && period == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByYearMonth(account_id, year, period)) != 0;
        }

        public override bool Exists(AccountActivity _obj)
        {
            return Exists(_obj.AccountActivityID);
        }

        protected override AccountActivity _FindByIntId(int? AccountActivityID)
        {
            if (Exists(AccountActivityID))
            {
                AccountActivity _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByAccountActivityID(AccountActivityID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        public AccountActivity FindByAccountYearPeriod(int? AccountID, int? year, int? period)
        {
            if (UseMemoryStore)
            {
                IList<AccountActivity> store = DataStore;
                var result = from s in store
                             where s.Match(AccountID, year, period)
                             select s;
                if (result.Count() != 0) return result.First();
                return null;
            }
            return _FindByIdYearPeriod(AccountID, year, period);
        }

        protected AccountActivity _FindByIdYearPeriod(int? account_id, int? year, int? period)
        {
            if (Exists(account_id, year, period))
            {
                AccountActivity _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByAccountYearPeriod(account_id, year, period));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<AccountActivity>_FindAllCollection()
        {
            List<AccountActivity> _grp = new List<AccountActivity>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                AccountActivity _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        private DbSelectStatement GetQuery_SelectCountByYearMonth(int? account_id, int? year, int? period)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("AccountActivities")
                .Criteria
                    .IsEqual("AccountActivities", "FinancialYear", year)
                    .IsEqual("AccountActivities", "Period", period)
                    .IsEqual("AccountActivities", "AccountID", account_id);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByAccountYearPeriod(int? account_id, int? year, int? period)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AccountActivities")
                .Criteria
                    .IsEqual("AccountActivities", "FinancialYear", year)
                    .IsEqual("AccountActivities", "Period", period)
                    .IsEqual("AccountActivities", "AccountID", account_id);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AccountActivities");

            return clause;
        }

        protected DbSelectStatement GetQuery_SelectCountByAccountActivityID(int AccountActivityID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("AccountActivities")
                .Criteria.IsEqual("AccountActivities", "AccountActivityID", AccountActivityID);

            return clause;
        }

        protected DbSelectStatement GetQuery_SelectByAccountActivityID(int AccountActivityID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AccountActivities")
                .Criteria.IsEqual("AccountActivities", "AccountActivityID", AccountActivityID);

            return clause;
        }

        public override Dictionary<string, DbFieldEntry> GetFields(AccountActivity _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["AccountActivityID"] = DbMgr.CreateAutoIntFieldEntry(_obj.AccountActivityID);
            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID);
            fields["FinancialYear"] = DbMgr.CreateIntFieldEntry(_obj.FinancialYear);
            fields["Period"] = DbMgr.CreateIntFieldEntry(_obj.Period);
            fields["Amount"] = DbMgr.CreateDoubleFieldEntry(_obj.Amount);

            return fields;
        }

        private List<AccountActivity> _FindCollectionByAccount(int? AccountID)
        {
            List<AccountActivity> _grp = new List<AccountActivity>();

            if (AccountID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AccountActivities")
                .Criteria.IsEqual("AccountActivities", "AccountID", AccountID.Value);

            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                AccountActivity _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        public IList<AccountActivity> FindCollectionByAccountYear(Account account, int year)
        {
            if (UseMemoryStore)
            {
                IList<AccountActivity> store = DataStore;
                var result = from s in store
                             where s.Match(account.AccountID, year, null)
                             orderby s.Period.Value ascending
                             select s;
                BindingList<AccountActivity> _blist = new BindingList<AccountActivity>();
                IList<AccountActivity> _list = result.ToList();
                foreach (AccountActivity aa in _list)
                {
                    _blist.Add(aa);
                }
                return _blist;
            }
            return _FindCollectionByAccount(account.AccountID);
        }

        //public int? LastFinancialYear
        //{
        //    get 
        //    {
        //        int? year = CurrentFinancialYear;
        //        if (year == null)
        //        {
        //            return null;
        //        }
        //        return year.Value-1; 
        //    }
        //}

        //public int? CurrentFinancialYear
        //{
        //    get
        //    {
        //        DbSelectStatement clause = DbMgr.CreateSelectClause();
        //        clause
        //            .SelectDistinct()
        //            .SelectColumn("AccountActivities", "FinancialYear")
        //            .From("AccountActivities");
        //        string query=clause.ToString();

        //        int? year=null;
        //        DbCommand _cmd = CreateDbCommand(clause);
        //        DbDataReader _reader = _cmd.ExecuteReader();
        //        if (_reader.Read())
        //        {
        //            year=GetInt32(_reader, "FinancialYear");
        //        }
        //        _reader.Close();
        //        _cmd.Dispose();

        //        return year;
        //    }
        //}

        //public List<AccountActivity> List(Account account, int? FinancialYear)
        //{
        //    if (account == null) return new List<AccountActivity>();
        //    return List(account.AccountID, FinancialYear);
        //}

        //public List<AccountActivity> List(int? AccountID, int? FinancialYear)
        //{
        //    List<AccountActivity> _grp = new List<AccountActivity>();

        //    if (AccountID == null) return _grp;

        //    DbSelectStatement clause = DbMgr.CreateSelectClause();
        //    clause
        //        .SelectAll()
        //        .From("AccountActivities")
        //        .OrderBy("AccountActivities", "Period", "DESC") 
        //        .Criteria
        //            .IsEqual("AccountActivities", "AccountID", AccountID)
        //            .IsEqual("AccountActivities", "FinancialYear", FinancialYear);

            

        //    DbCommand _cmd = CreateDbCommand(clause);
        //    DbDataReader _reader = _cmd.ExecuteReader();
        //    while (_reader.Read())
        //    {
        //        AccountActivity _obj = CreateDbEntity(); 
        //        LoadFromReader(_obj, _reader);
        //        _grp.Add(_obj);
        //    }
        //    _reader.Close();
        //    _cmd.Dispose();

        //    return _grp;
        //}

        


    }
}
