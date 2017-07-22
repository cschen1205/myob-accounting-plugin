using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;
using Accounting.Core.Data;

namespace Accounting.Core.Accounts
{
    public abstract class AccountManager : EntityManager<Account>
    {
        public AccountManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region factory methods
        protected override Account _CreateDbEntity()
        {
            return new Account(true, this);
        }

        protected override Account _CreateEntity()
        {
            return new Account(false, this);
        }
        #endregion


        public virtual Account GetLinkedAccount(string linkAccount)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectColumn("LinkedAccounts", string.Format("{0}ID", linkAccount))
                .From("LinkedAccounts");
            
            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            int? AccountID = null;
            if (_reader.Read())
            {
                AccountID = GetInt32(_reader, string.Format("{0}ID", linkAccount));
            }
            return _FindByIntId(AccountID);
        }




        public override Dictionary<string, DbFieldEntry> GetFields(Account _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["AccountID"] = DbMgr.CreateAutoIntFieldEntry(_obj.AccountID);
            fields["AccountName"] = DbMgr.CreateStringFieldEntry(_obj.AccountName);
            fields["AccountNumber"] = DbMgr.CreateStringFieldEntry(_obj.AccountNumber);
            fields["IsInactive"] = DbMgr.CreateStringFieldEntry(_obj.IsInactive);
            fields["ParentAccountID"] = DbMgr.CreateIntFieldEntry(_obj.ParentAccountID);
            fields["AccountClassificationID"] = DbMgr.CreateStringFieldEntry(_obj.AccountClassificationID);
            fields["AccountLevel"] = DbMgr.CreateIntFieldEntry(_obj.AccountLevel);
            fields["SubAccountClassificationID"] = DbMgr.CreateStringFieldEntry(_obj.SubAccountClassificationID);
            fields["TaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.TaxCodeID);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["AccountTypeID"] = DbMgr.CreateStringFieldEntry(_obj.AccountTypeID);
            fields["CurrentAccountBalance"] = DbMgr.CreateDoubleFieldEntry(_obj.CurrentAccountBalance);
            fields["CashFlowClassificationID"] = DbMgr.CreateStringFieldEntry(_obj.CashFlowClassificationID);
            fields["AccountDescription"] = DbMgr.CreateStringFieldEntry(_obj.AccountDescription);
            fields["LastChequeNumber"] = DbMgr.CreateStringFieldEntry(_obj.LastChequeNumber);
            fields["CurrencyExchangeAccountID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyExchangeAccountID);
            fields["IsReconciled"] = DbMgr.CreateStringFieldEntry(_obj.IsReconciled);
            fields["LastReconciledDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.LastReconciledDate);
            fields["StatementBalance"] = DbMgr.CreateDoubleFieldEntry(_obj.StatementBalance);
            fields["IsCreditBalance"] = DbMgr.CreateStringFieldEntry(_obj.IsCreditBalance);
            fields["OpeningAccountBalance"] = DbMgr.CreateDoubleFieldEntry(_obj.OpeningAccountBalance);
            fields["PreLastYearActivity"] = DbMgr.CreateDoubleFieldEntry(_obj.PreLastYearActivity);
            fields["LastYearOpeningBalance"] = DbMgr.CreateDoubleFieldEntry(_obj.LastYearOpeningBalance);
            fields["ThisYearOpeningBalance"] = DbMgr.CreateDoubleFieldEntry(_obj.ThisYearOpeningBalance);
            fields["PostThisYearActivity"] = DbMgr.CreateDoubleFieldEntry(_obj.PostThisYearActivity);
            fields["IsTotal"] = DbMgr.CreateStringFieldEntry(_obj.IsTotal);
            fields["BSBCode"] = DbMgr.CreateStringFieldEntry(_obj.BSBCode);
            fields["BankAccountNumber"] = DbMgr.CreateStringFieldEntry(_obj.BankAccountNumber);
            fields["BankAccountName"] = DbMgr.CreateStringFieldEntry(_obj.BankAccountName);
            fields["CompanyTradingName"] = DbMgr.CreateStringFieldEntry(_obj.CompanyTradingName);
            fields["CreateBankFiles"] = DbMgr.CreateStringFieldEntry(_obj.CreateBankFiles);
            fields["BankCode"] = DbMgr.CreateStringFieldEntry(_obj.BankCode);
            fields["DirectEntryUserID"] = DbMgr.CreateStringFieldEntry(_obj.DirectEntryUserID);
            fields["IsSelfBalancing"] = DbMgr.CreateStringFieldEntry(_obj.IsSelfBalancing);
            //fields["StatementParticulars"] = new StringFieldEntry(_obj.StatementParticulars);
            //fields["StatementCode"] = new StringFieldEntry(_obj.StatementCode);
            //fields["StatementReference"] = new StringFieldEntry(_obj.StatementReference);
            //fields["AccountantLinkCode"] = DbMgr.CreateStringFieldEntry(_obj.AccountantLinkCode);
            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Accounts");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByAccountID(int AccountID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Accounts")
                .Criteria.IsEqual("Accounts", "AccountID", AccountID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByAccountNumber(string AccountNumber)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Accounts")
                .Criteria.IsEqual("Accounts", "AccountNumber", AccountNumber);

            return clause;
        }

        protected DbSelectStatement GetQuery_SelectCountByAccountID(int AccountID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Accounts")
                .Criteria.IsEqual("Accounts", "AccountID", AccountID);

            return clause;
        }

        protected DbSelectStatement GetQuery_SelectCountByAccountNumber(string AccountNumber)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Accounts")
                .Criteria.IsEqual("Accounts", "AccountNumber", AccountNumber);

            return clause;
        }

        public override bool Exists(Account _obj)
        {
            return Exists(_obj.AccountID);
        }

        protected override Account _FindByTextId(string AccountNumber)
        {
            if (Exists(AccountNumber))
            {
                Account _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByAccountNumber(AccountNumber));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override Account _FindByIntId(int? AccountID)
        {
            if (Exists(AccountID))
            {
                Account _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByAccountID(AccountID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<Account>_FindAllCollection()
        {
            List<Account> _grp = new List<Account>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Account _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        public IList<Account> FindAssetCollection()
        {
            List<Account> _grp = new List<Account>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("Accounts")
                .Criteria
                    .IsEqual("Accounts", "AccountClassificationID", "A")
                    .IsEqual("Accounts", "AccountTypeID", "D");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Account _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        public IList<Account> FindExpenseCollection()
        {
            List<Account> _grp = new List<Account>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("Accounts")
                .Criteria
                    .IsEqual("Accounts", "AccountClassificationID", "EXP")
                    .IsEqual("Accounts", "AccountTypeID", "D");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Account _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        public IList<Account> FindCostOfSalesCollection()
        {
            List<Account> _grp = new List<Account>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("Accounts")
                .Criteria
                    .IsEqual("Accounts", "AccountClassificationID", "COS")
                    .IsEqual("Accounts", "AccountTypeID", "D");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Account _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        public IList<Account> FindIncomeCollection()
        {
            List<Account> _grp = new List<Account>();

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause.SelectAll()
                .From("Accounts")
                .Criteria
                    .IsEqual("Accounts", "AccountClassificationID", "I")
                    .IsEqual("Accounts", "AccountTypeID", "D");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Account _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
       

        public List<Account> CashAccounts
        {
            get
            {
                DbSelectStatement clause = DbMgr.CreateSelectClause();
                clause
                    .SelectAll()
                    .From("Accounts")
                    .Criteria.IsEqual("Accounts", "CashFlowClassificationID", "C");

                

                List<Account> result = new List<Account>();

                DbCommand cmd = CreateDbCommand(clause);
                DbDataReader _reader = cmd.ExecuteReader();
                while (_reader.Read())
                {
                    Account _obj = CreateDbEntity();
                    LoadFromReader(_obj, _reader);
                    result.Add(_obj);
                }

                _reader.Close();
                cmd.Dispose();

                return result;
            }
        }

        public List<Account> List(string AccountNumber)
        {
            DbSelectStatement clause_select_account_id=DbMgr.CreateSelectClause();
            clause_select_account_id
                .SelectColumn("Accounts", "AccountID")
                .From("Accounts")
                .Criteria.IsEqual("Accounts", "AccountNumber", AccountNumber);

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Accounts")
                .OrderBy("Accounts", "AccountNumber")
                .Criteria.IsEqual("Accounts", "ParentAccountID", clause_select_account_id);

            

            List<Account> result = new List<Account>();

            DbCommand cmd = CreateDbCommand(clause);
            DbDataReader _reader = cmd.ExecuteReader();
            while (_reader.Read())
            {
                Account _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                result.Add(_obj);
            }

            _reader.Close();
            cmd.Dispose();

            return result;
        }

        public double GetCurrentYearAccountBalance(Account acc)
        {
            return acc.CurrentYearAccountBalance;
        }

        public Hierarchy<Account> Hierarchy
        {
            get
            {
                return new Hierarchy<Account>(
                    this.FindAllCollection(),  
                    1, 
                    new Hierarchy<Account>.GetLevelDelegate(GetAccountLevel), 
                    new Hierarchy<Account>.IsParentDelegate(IsParentAccount),
                    new TreeNode<Account>.GetTreeNodeValue(GetCurrentYearAccountBalance)
                    );
            }
        }

        public int GetAccountLevel(Account acc)
        {
            return acc.AccountLevel.Value;
        }

        public bool IsParentAccount(Account parent, Account child)
        {
            return parent.AccountID == child.ParentAccountID;
        }

        public TreeNode<Account> BalanceSheet
        {
            get
            {
                Hierarchy<Account> tree = Hierarchy;
                foreach (TreeNode<Account> node in tree[0])
                {
                    string accountName = node.DataSource.AccountName;
                    if (accountName.Equals("Balance Sheet"))
                    {
                        return node;
                     }
                }
                return null;
           }
        }

        public TreeNode<Account> PLStatement
        {
            get
            {
                Hierarchy<Account> tree = Hierarchy;
                foreach (TreeNode<Account> node in tree[0])
                {
                    string accountName = node.DataSource.AccountName;
                    if (accountName.Equals("Net Profit/(Loss)"))
                    {
                        return node;
                    }
                }
                return null;
            }
        }

        protected override object GetDbProperty(Account _obj, string property_name)
        {
            if (property_name == "Currency")
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name == "TaxCode")
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.TaxCodeID);
            }
            else if (property_name == "AccountType")
            {
                return RepositoryMgr.AccountTypeMgr.FindById(_obj.AccountTypeID);
            }
            else if (property_name == "SubAccountClassification")
            {
                return RepositoryMgr.SubAccountTypeMgr.FindById(_obj.SubAccountClassificationID);
            }
            else if (property_name == "AccountClassification")
            {
                return RepositoryMgr.AccountClassificationMgr.FindById(_obj.AccountClassificationID);
            }
            else if (property_name == "CashFlowClassification")
            {
                return RepositoryMgr.CashFlowClassificationMgr.FindById(_obj.CashFlowClassificationID);
            }
            return null;
        }

        protected override void LoadFromReader(Account _obj, DbDataReader _reader)
        {
            _obj.AccountID =GetInt32(_reader, ("AccountID"));
            _obj.AccountName =GetString(_reader, ("AccountName"));
            _obj.AccountNumber =GetString(_reader, ("AccountNumber"));
            _obj.IsInactive =GetString(_reader, ("IsInactive"));
            _obj.ParentAccountID =GetInt32(_reader, ("ParentAccountID"));
            _obj.AccountClassificationID =GetString(_reader, ("AccountClassificationID"));
            _obj.AccountLevel =GetInt32(_reader, ("AccountLevel"));
            _obj.SubAccountClassificationID =GetString(_reader, ("SubAccountClassificationID"));
            _obj.TaxCodeID =GetInt32(_reader, ("TaxCodeID"));
            _obj.CurrencyID =GetInt32(_reader, ("CurrencyID"));
            _obj.AccountTypeID =GetString(_reader, ("AccountTypeID"));
            _obj.CurrentAccountBalance = GetDouble(_reader, ("CurrentAccountBalance"));
            _obj.CashFlowClassificationID =GetString(_reader, ("CashFlowClassificationID"));
            _obj.AccountDescription =GetString(_reader, ("AccountDescription"));
            _obj.CurrencyExchangeAccountID =GetInt32(_reader, ("CurrencyExchangeAccountID"));
            try
            {
                _obj.LastChequeNumber =GetString(_reader, ("LastChequeNumber"));
            }
            catch
            {
                _obj.LastChequeNumber = Convert.ToString(GetInt32(_reader, ("LastChequeNumber")));
            }
            _obj.IsReconciled =GetString(_reader, ("IsReconciled"));
            _obj.LastReconciledDate=GetDateTime(_reader, ("LastReconciledDate"));
            _obj.StatementBalance = GetDouble(_reader, ("StatementBalance"));
            _obj.IsCreditBalance =GetString(_reader, ("IsCreditBalance"));
            _obj.OpeningAccountBalance = GetDouble(_reader, ("OpeningAccountBalance"));
            _obj.PreLastYearActivity=GetDouble(_reader, ("PreLastYearActivity"));
            _obj.LastYearOpeningBalance = GetDouble(_reader, ("LastYearOpeningBalance"));
            _obj.ThisYearOpeningBalance = GetDouble(_reader, ("ThisYearOpeningBalance"));
            _obj.PostThisYearActivity = GetDouble(_reader, ("PostThisYearActivity"));
            _obj.IsTotal =GetString(_reader, ("IsTotal"));
            _obj.BSBCode =GetString(_reader, ("BSBCode"));
            _obj.BankAccountNumber =GetString(_reader, ("BankAccountNumber"));
            _obj.BankAccountName =GetString(_reader, ("BankAccountName"));
            _obj.CompanyTradingName =GetString(_reader, ("CompanyTradingName"));
            _obj.CreateBankFiles =GetString(_reader, ("CreateBankFiles"));
            _obj.BankCode =GetString(_reader, ("BankCode"));
            _obj.DirectEntryUserID =GetString(_reader, ("DirectEntryUserID"));
            _obj.IsSelfBalancing =GetString(_reader, ("IsSelfBalancing"));
            //_obj.StatementParticulars =GetString(_reader, ("StatementParticulars"));
            //_obj.StatementCode =GetString(_reader, ("StatementCode"));
            //_obj.StatementReference =GetString(_reader, ("StatementReference"));
            //_obj.AccountantLinkCode =GetString(_reader, ("AccountantLinkCode"));
        }

        public bool Exists(string AccountNumber)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByAccountNumber(AccountNumber)) != 0;
        }

        public bool Exists(int? AccountID)
        {
            if (AccountID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByAccountID(AccountID.Value)) != 0;
        }
    }
}
