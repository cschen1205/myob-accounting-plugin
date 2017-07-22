using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public abstract class PayLiabilityLineManager : EntityManager<PayLiabilityLine>
    {
        public PayLiabilityLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override PayLiabilityLine _CreateDbEntity()
        {
            return new PayLiabilityLine(true, this);
        }
        protected override PayLiabilityLine _CreateEntity()
        {
            return new PayLiabilityLine(false, this);
        }
        #endregion

        protected override void LoadFromReader(PayLiabilityLine _obj, DbDataReader reader)
        {
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.CategoryID = GetInt32(reader, "CategoryID");
            _obj.CategoryTypeID = GetString(reader, "CategoryTypeID");
            _obj.LineNumber = GetInt32(reader, "LineNumber");
            _obj.PayLiabilitiesID = GetInt32(reader, "PayLiabilitiesID");
            _obj.PayLiabilityLineID = GetInt32(reader, "PayLiabilityLineID");
            _obj.SourceLineID = GetInt32(reader, "SourceLineID");
            _obj.SuperannuationFundID = GetInt32(reader, "SuperannuationFundID");
            _obj.AmountPaid = GetDouble(reader, "AmountPaid");
            _obj.PaymentStatusID = GetString(reader, "PaymentStatusID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(PayLiabilityLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID); //GetInt32(reader, "");
            fields["CategoryID"] = DbMgr.CreateIntFieldEntry(_obj.CategoryID); //GetInt32(reader, "");
            fields["CategoryTypeID"] = DbMgr.CreateStringFieldEntry(_obj.CategoryTypeID); //GetString(reader, "");
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber); //GetInt32(reader, "");
            fields["PayLiabilitiesID"] = DbMgr.CreateIntFieldEntry(_obj.PayLiabilitiesID); //GetInt32(reader, "");
            fields["PayLiabilityLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.PayLiabilityLineID); //GetInt32(reader, "");
            fields["SourceLineID"] = DbMgr.CreateIntFieldEntry(_obj.SourceLineID); //GetInt32(reader, "");
            fields["SuperannuationFundID"] = DbMgr.CreateAutoIntFieldEntry(_obj.SuperannuationFundID); //GetInt32(reader, "");
            fields["AmountPaid"] = DbMgr.CreateDoubleFieldEntry(_obj.AmountPaid);
            fields["PaymentStatusID"] = DbMgr.CreateStringFieldEntry(_obj.PaymentStatusID);

            return fields;
        }

        protected override object GetDbProperty(PayLiabilityLine _obj, string property_name)
        {
            if (property_name.Equals("PayLiability"))
            {
                return RepositoryMgr.PayLiabilityMgr.FindById(_obj.PayLiabilitiesID);
            }
            else if (property_name.Equals("SourceLine"))
            {
                return RepositoryMgr.WritePaychequeLineMgr.FindById(_obj.SourceLineID);
            }
            else if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            else if (property_name.Equals("CategoryType"))
            {
                return RepositoryMgr.CategoryTypeMgr.FindById(_obj.CategoryTypeID);
            }
            else if (property_name.Equals("SuperannuationFund"))
            {
                return RepositoryMgr.SuperannuationFundMgr.FindById(_obj.SuperannuationFundID);
            }
            else if (property_name.Equals("Account"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.AccountID);
            }
            else if (property_name.Equals("PaymentStatus"))
            {
                return RepositoryMgr.DepositStatusMgr.FindById(_obj.PaymentStatusID);
            }

            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("PayLiabilityLines");
        }

        private DbSelectStatement GetQuery_SelectByPayLiabilityLineID(int PayLiabilityLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("PayLiabilityLines")
                .Criteria
                    .IsEqual("PayLiabilityLines", "PayLiabilityLineID", PayLiabilityLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByPayLiabilityLineID(int PayLiabilityLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("PayLiabilityLines")
                .Criteria
                    .IsEqual("PayLiabilityLines", "PayLiabilityLineID", PayLiabilityLineID);

            return clause;
        }

        public bool Exists(int? PayLiabilityLineID)
        {
            if (PayLiabilityLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByPayLiabilityLineID(PayLiabilityLineID.Value)) != 0;
        }

        public override bool Exists(PayLiabilityLine _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.PayLiabilityLineID);
        }

        protected override PayLiabilityLine _FindByIntId(int? PayLiabilityLineID)
        {
            if (PayLiabilityLineID == null) return null;
            PayLiabilityLine _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByPayLiabilityLineID(PayLiabilityLineID.Value));
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

        protected override IList<PayLiabilityLine>_FindAllCollection()
        {
            List<PayLiabilityLine> _grp = new List<PayLiabilityLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                PayLiabilityLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

    }
}
