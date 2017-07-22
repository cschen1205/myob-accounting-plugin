using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public abstract class PaySuperannuationManager : EntityManager<PaySuperannuation>
    {
        public PaySuperannuationManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override PaySuperannuation _CreateDbEntity()
        {
            return new PaySuperannuation(true, this);
        }
        protected override PaySuperannuation _CreateEntity()
        {
            return new PaySuperannuation(false, this);
        }
        #endregion

        protected override void LoadFromReader(PaySuperannuation _obj, DbDataReader reader)
        {
            _obj.CurrencyID = GetInt32(reader, "CurrencyID");
            _obj.TransactionDate = GetDateTime(reader, "TransactionDate");
            _obj.Date = _obj.TransactionDate;
            _obj.IssuingAccountID = GetInt32(reader, "IssuingAccountID");
            _obj.IsTaxInclusive = GetString(reader, "IsTaxInclusive");
            _obj.IsThirteenthPeriod = GetString(reader, "IsThirteenthPeriod");
            _obj.Memo = GetString(reader, "Memo");
            _obj.PaymentNumber = GetString(reader, "PaymentNumber");
            _obj.PaySuperannuationID = GetInt32(reader, "PaySuperannuationID");
            _obj.TotalPaymentAmount = GetDouble(reader, "TotalPaymentAmount");
            _obj.TransactionExchangeRate = GetDouble(reader, "TransactionExchangeRate");
            
        }

        public override Dictionary<string, DbFieldEntry> GetFields(PaySuperannuation _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID); //GetInt32(reader, "CurrencyID");
            fields["TransactionDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.TransactionDate); //GetDateTime(reader, "TransactionDate");
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date); //fields[""]=DbMgr.CreateStringFieldEntry(_obj.TransactionDate;
            fields["IssuingAccountID"] = DbMgr.CreateIntFieldEntry(_obj.IssuingAccountID); //GetInt32(reader, "IssuingAccountID");
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive); //GetString(reader, "IsTaxInclusive");
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod); //GetString(reader, "IsThirteenthPeriod");
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo); //GetString(reader, "Memo");
            fields["PaymentNumber"] = DbMgr.CreateStringFieldEntry(_obj.PaymentNumber); //GetString(reader, "PaymentNumber");
            fields["PaySuperannuationID"] = DbMgr.CreateAutoIntFieldEntry(_obj.PaySuperannuationID); //GetInt32(reader, "PaySuperannuationID");
            fields["TotalPaymentAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalPaymentAmount); //GetDouble(reader, "TotalPaymentAmount");
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate); //GetDouble(reader, "TransactionExchangeRate");
            

            return fields;
        }

        protected override object GetDbProperty(PaySuperannuation _obj, string property_name)
        {
            if (property_name.Equals("IssuingAccount"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.IssuingAccountID);
            }
            else if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }

            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("PaySuperannuation");
        }

        private DbSelectStatement GetQuery_SelectByPaySuperannuationID(int PaySuperannuationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("PaySuperannuation")
                .Criteria
                    .IsEqual("PaySuperannuation", "PaySuperannuationID", PaySuperannuationID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByPaySuperannuationID(int PaySuperannuationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("PaySuperannuation")
                .Criteria
                    .IsEqual("PaySuperannuation", "PaySuperannuationID", PaySuperannuationID);

            return clause;
        }

        public bool Exists(int? PaySuperannuationID)
        {
            if (PaySuperannuationID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByPaySuperannuationID(PaySuperannuationID.Value)) != 0;
        }

        public override bool Exists(PaySuperannuation _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.PaySuperannuationID);
        }

        protected override PaySuperannuation _FindByIntId(int? PaySuperannuationID)
        {
            if (PaySuperannuationID == null) return null;

            PaySuperannuation _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByPaySuperannuationID(PaySuperannuationID.Value));
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

        protected override IList<PaySuperannuation>_FindAllCollection()
        {
            List<PaySuperannuation> _grp = new List<PaySuperannuation>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                PaySuperannuation _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
