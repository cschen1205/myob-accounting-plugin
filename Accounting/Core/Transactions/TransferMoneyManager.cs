using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public abstract class TransferMoneyManager : EntityManager<TransferMoney>
    {
        public TransferMoneyManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override TransferMoney _CreateDbEntity()
        {
            return new TransferMoney(true, this);
        }

        protected override TransferMoney _CreateEntity()
        {
            return new TransferMoney(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(TransferMoney _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["TransferMoneyID"] = DbMgr.CreateAutoIntFieldEntry(_obj.TransferMoneyID);
            fields["FromAccountID"] = DbMgr.CreateIntFieldEntry(_obj.FromAccountID);
            fields["ToAccountID"] = DbMgr.CreateIntFieldEntry(_obj.ToAccountID);
            fields["TransferNumber"] = DbMgr.CreateStringFieldEntry(_obj.TransferNumber);
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate);
            fields["Amount"] = DbMgr.CreateDoubleFieldEntry(_obj.Amount);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
            //fields["IsTransferredElectronically"]=new StringFieldEntry(_obj.IsTransferredElectronically);
            //fields["StatementText"]=new StringFieldEntry(_obj.StatementText);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["IsAutoRecorded"] = DbMgr.CreateStringFieldEntry(_obj.IsAutoRecorded);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate);
            fields["CategoryID"] = DbMgr.CreateIntFieldEntry(_obj.CategoryID);
            //fields["CostCentreID"]=new IntFieldEntry(_obj.CostCentreID);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("TransferMoney");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByTransferMoneyID(int TransferMoneyID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("TransferMoney")
                .Criteria
                    .IsEqual("TransferMoney", "TransferMoneyID", TransferMoneyID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountbyTransferMoneyID(int TransferMoneyID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("TransferMoney")
                .Criteria
                    .IsEqual("TransferMoney", "TransferMoneyID", TransferMoneyID);

            return clause;
        }

        private bool Exists(int? TransferMoneyID)
        {
            if (TransferMoneyID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountbyTransferMoneyID(TransferMoneyID.Value)) != 0;
        }

        public override bool Exists(TransferMoney _obj)
        {
            if (_obj.TransferMoneyID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountbyTransferMoneyID(_obj.TransferMoneyID.Value)) != 0;
        }

        protected override void LoadFromReader(TransferMoney _obj, DbDataReader _reader)
        {
            _obj.TransferMoneyID =GetInt32(_reader, ("TransferMoneyID"));
            _obj.FromAccountID =GetInt32(_reader, ("FromAccountID"));
            _obj.ToAccountID =GetInt32(_reader, ("ToAccountID"));
            _obj.TransferNumber=GetString(_reader, ("TransferNumber"));
            _obj.TransactionDate=GetDateTime(_reader, ("TransactionDate"));
            _obj.Amount=GetDouble(_reader, ("Amount"));
            _obj.Memo=GetString(_reader, ("Memo"));
            //_obj.IsTransferredElectronically=GetString(_reader, ("IsTransferredElectronically"));
            //_obj.StatementText=GetString(_reader, ("StatementText"));
            _obj.IsTaxInclusive=GetString(_reader, ("IsTaxInclusive"));
            _obj.IsAutoRecorded=GetString(_reader, ("IsAutoRecorded"));
            _obj.CurrencyID=GetInt32(_reader, ("CurrencyID"));
            _obj.TransactionExchangeRate=GetDouble(_reader, ("TransactionExchangeRate"));
            _obj.CategoryID = GetInt32(_reader, "CategoryID");
            //_obj.CostCentreID=GetInt32(_reader, ("CostCentreID"));
        }

        protected override object GetDbProperty(TransferMoney _obj, string property_name)
        {
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

        protected override TransferMoney _FindByIntId(int? TransferMoneyID)
        {
            if (Exists(TransferMoneyID))
            {
                TransferMoney _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByTransferMoneyID(TransferMoneyID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

      

        protected override IList<TransferMoney> _FindAllCollection()
        {
            List<TransferMoney> objs = new List<TransferMoney>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                TransferMoney _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                objs.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return objs;
        }

    }
}
