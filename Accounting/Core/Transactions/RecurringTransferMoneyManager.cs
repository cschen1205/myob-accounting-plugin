using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public abstract class RecurringTransferMoneyManager : RecurringEntityManager<RecurringTransferMoney>
    {
        public RecurringTransferMoneyManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override RecurringTransferMoney _CreateDbEntity()
        {
            return new RecurringTransferMoney(true, this);
        }

        protected override RecurringTransferMoney _CreateEntity()
        {
            return new RecurringTransferMoney(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(RecurringTransferMoney _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetRecurringEntityFields(_obj);

            fields["RecurringTransferMoneyID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringTransferMoneyID);
            fields["FromAccountID"] = DbMgr.CreateIntFieldEntry(_obj.FromAccountID);
            fields["ToAccountID"] = DbMgr.CreateIntFieldEntry(_obj.ToAccountID);
            fields["Amount"] = DbMgr.CreateDoubleFieldEntry(_obj.Amount);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
            fields["IsTransferredElectronically"]=DbMgr.CreateStringFieldEntry(_obj.IsTransferredElectronically);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["CostCentreID"]=DbMgr.CreateIntFieldEntry(_obj.CostCentreID);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringTransferMoney");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByRecurringTransferMoneyID(int RecurringTransferMoneyID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringTransferMoney")
                .Criteria
                    .IsEqual("RecurringTransferMoney", "RecurringTransferMoneyID", RecurringTransferMoneyID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountbyRecurringTransferMoneyID(int RecurringTransferMoneyID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("RecurringTransferMoney")
                .Criteria
                    .IsEqual("RecurringTransferMoney", "RecurringTransferMoneyID", RecurringTransferMoneyID);

            return clause;
        }

        private bool Exists(int? RecurringTransferMoneyID)
        {
            if (RecurringTransferMoneyID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountbyRecurringTransferMoneyID(RecurringTransferMoneyID.Value)) != 0;
        }

        public override bool Exists(RecurringTransferMoney _obj)
        {
            if (_obj.RecurringTransferMoneyID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountbyRecurringTransferMoneyID(_obj.RecurringTransferMoneyID.Value)) != 0;
        }

        protected override void LoadFromReader(RecurringTransferMoney _obj, DbDataReader _reader)
        {
            LoadRecurringEntityFromReader(_obj, _reader);

            _obj.RecurringTransferMoneyID =GetInt32(_reader, ("RecurringTransferMoneyID"));
            _obj.FromAccountID =GetInt32(_reader, ("FromAccountID"));
            _obj.ToAccountID =GetInt32(_reader, ("ToAccountID"));
            _obj.Amount=GetDouble(_reader, ("Amount"));
            _obj.Memo=GetString(_reader, ("Memo"));
            _obj.IsTransferredElectronically=GetString(_reader, "IsTransferredElectronically");
            _obj.IsTaxInclusive=GetString(_reader, ("IsTaxInclusive"));
            _obj.CurrencyID=GetInt32(_reader, ("CurrencyID"));
            _obj.CostCentreID=GetInt32(_reader, "CostCentreID");
        }

        protected override object GetDbProperty(RecurringTransferMoney _obj, string property_name)
        {
            object returned_obj = GetRecurringEntityDbProperty(_obj, property_name);
            if (returned_obj != null) return returned_obj;

            if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name.Equals("FromAccount"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.FromAccountID);
            }
            else if (property_name.Equals("ToAccount"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.ToAccountID);
            }
            return null;
        }

        protected override RecurringTransferMoney _FindByIntId(int? RecurringTransferMoneyID)
        {
            if (Exists(RecurringTransferMoneyID))
            {
                RecurringTransferMoney _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByRecurringTransferMoneyID(RecurringTransferMoneyID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

      

        protected override IList<RecurringTransferMoney> _FindAllCollection()
        {
            List<RecurringTransferMoney> objs = new List<RecurringTransferMoney>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringTransferMoney _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                objs.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return objs;
        }

    }
}
