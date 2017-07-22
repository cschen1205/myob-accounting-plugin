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

    public abstract class AccountBudgetManager : EntityManager<AccountBudget>
    {
        public AccountBudgetManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override AccountBudget _CreateEntity()
        {
            return new AccountBudget(false, this);
        }

        protected override AccountBudget _CreateDbEntity()
        {
            return new AccountBudget(true, this);
        }
        #endregion

        protected override object GetDbProperty(AccountBudget _obj, string property_name)
        {
            if (property_name.Equals("Account"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.AccountID);
            }
            return null;
        }

        protected override void LoadFromReader(AccountBudget _obj, DbDataReader reader)
        {
            _obj.AccountBudgetID = GetInt32(reader, "AccountBudgetID");
            _obj.AccountID = GetInt32(reader, "AccountID");
            _obj.Amount = GetDouble(reader, "Amount");
            _obj.FinancialYear = GetInt32(reader, "FinancialYear");
            _obj.Period = GetInt32(reader, "Period");
        }

        public bool Exists(int? AccountBudgetID)
        {
            if (AccountBudgetID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByAccountBudgetID(AccountBudgetID.Value)) != 0;
        }

        public bool Exists(int AccountID, int year, int period)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByYearMonth(AccountID, year, period)) != 0;
        }

        public override bool Exists(AccountBudget _obj)
        {
            return Exists(_obj.AccountBudgetID);
        }

        protected override AccountBudget _FindByIntId(int? AccountBudgetID)
        {
            if (Exists(AccountBudgetID))
            {
                AccountBudget _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByAccountBudgetID(AccountBudgetID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<AccountBudget> _FindAllCollection()
        {
            List<AccountBudget> _grp = new List<AccountBudget>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                AccountBudget _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        private DbSelectStatement GetQuery_SelectCountByYearMonth(int AccountID, int year, int period)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("AccountBudgets")
                .Criteria
                    .IsEqual("AccountBudgets", "FinancialYear", year)
                    .IsEqual("AccountBudgets", "Period", period)
                    .IsEqual("AccountBudgets", "AccountID", AccountID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByYearMonth(int AccountID, int year, int period)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AccountBudgets")
                .Criteria
                    .IsEqual("AccountBudgets", "FinancialYear", year)
                    .IsEqual("AccountBudgets", "Period", period)
                    .IsEqual("AccountBudgets", "AccountID", AccountID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AccountBudgets");

            return clause;
        }

        protected DbSelectStatement GetQuery_SelectCountByAccountBudgetID(int AccountBudgetID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("AccountBudgets")
                .Criteria.IsEqual("AccountBudgets", "AccountBudgetID", AccountBudgetID);

            return clause;
        }

        protected DbSelectStatement GetQuery_SelectByAccountBudgetID(int AccountBudgetID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AccountBudgets")
                .Criteria.IsEqual("AccountBudgets", "AccountBudgetID", AccountBudgetID);

            return clause;
        }

        public override Dictionary<string, DbFieldEntry> GetFields(AccountBudget _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["AccountBudgetID"] = DbMgr.CreateAutoIntFieldEntry(_obj.AccountBudgetID);
            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID);
            fields["FinancialYear"] = DbMgr.CreateIntFieldEntry(_obj.FinancialYear);
            fields["Period"] = DbMgr.CreateIntFieldEntry(_obj.Period);
            fields["Amount"] = DbMgr.CreateDoubleFieldEntry(_obj.Amount);

            return fields;
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
        //            .SelectColumn("AccountBudgets", "FinancialYear")
        //            .From("AccountBudgets");
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

        public IList<AccountBudget> FindCollectionByAccountYear(int? account_id, int? FinancialYear)
        {
            if (UseMemoryStore)
            {
                IList<AccountBudget> store = DataStore;
                var result = from s in store
                             where s.Match(account_id, FinancialYear, null)
                             orderby s.Period ascending
                             select s;
                IList<AccountBudget> _list = result.ToList();
                BindingList<AccountBudget> _blist = new BindingList<AccountBudget>();
                foreach (AccountBudget ab in _list)
                {
                    _blist.Add(ab);
                }
                return _blist;
            }
            return _FindCollectionByAccountYear(account_id, FinancialYear);
        }

        public AccountBudget FindByAccountYearPeriod(int? account_id, int? year, int? period)
        {
            if (UseMemoryStore)
            {
                IList<AccountBudget> store = DataStore;
                var result = from s in store
                             where s.Match(account_id, year, period)
                             orderby s.Period ascending
                             select s;
                if (result.Count() == 0) return null;
                return result.First();
            }
            return _FindByAccountYearPeriod(account_id, year, period);
        }

        protected IList<AccountBudget> _FindCollectionByAccountYear(int? AccountID, int? FinancialYear)
        {
            BindingList<AccountBudget> _grp = new BindingList<AccountBudget>();

            if (AccountID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AccountBudgets")
                .OrderBy("AccountBudgets", "Period", "DESC") 
                .Criteria
                    .IsEqual("AccountBudgets", "AccountID", AccountID)
                    .IsEqual("AccountBudgets", "FinancialYear", FinancialYear);

            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                AccountBudget _obj = CreateDbEntity(); 
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected AccountBudget _FindByAccountYearPeriod(int? account_id, int? year, int? period)
        {
            AccountBudget _obj = null;

            if (account_id == null) return _obj;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("AccountBudgets")
                .OrderBy("AccountBudgets", "Period", "DESC")
                .Criteria
                    .IsEqual("AccountBudgets", "AccountID", account_id)
                    .IsEqual("AccountBudgets", "FinancialYear", year)
                    .IsEqual("AccountBudgets", "Period", period);


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
