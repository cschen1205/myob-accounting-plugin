using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Transactions
{
    public abstract class PaySuperannuationLineManager : EntityManager<PaySuperannuationLine>
    {
        public PaySuperannuationLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override PaySuperannuationLine _CreateDbEntity()
        {
            return new PaySuperannuationLine(true, this);
        }
        protected override PaySuperannuationLine _CreateEntity()
        {
            return new PaySuperannuationLine(false, this);
        }
        #endregion

        protected override void LoadFromReader(PaySuperannuationLine _obj, DbDataReader reader)
        {
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.LineNumber = GetInt32(reader, "LineNumber");
            _obj.PaySuperannuationID = GetInt32(reader, "PaySuperannuationID");
            _obj.PaySuperannuationLineID = GetInt32(reader, "PaySuperannuationLineID");
            _obj.SourceLineID = GetInt32(reader, "SourceLineID");
            _obj.SuperannuationFundID = GetInt32(reader, "SuperannuationFundID");
            _obj.AmountPaid = GetDouble(reader, "AmountPaid");
            _obj.PaymentStatusID = GetString(reader, "PaymentStatusID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(PaySuperannuationLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID); //GetInt32(reader, "");
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber); //GetInt32(reader, "");
            fields["PaySuperannuationID"] = DbMgr.CreateIntFieldEntry(_obj.PaySuperannuationID); //GetInt32(reader, "");
            fields["PaySuperannuationLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.PaySuperannuationLineID); //GetInt32(reader, "");
            fields["SourceLineID"] = DbMgr.CreateIntFieldEntry(_obj.SourceLineID); //GetInt32(reader, "");
            fields["SuperannuationFundID"] = DbMgr.CreateAutoIntFieldEntry(_obj.SuperannuationFundID); //GetInt32(reader, "");
            fields["AmountPaid"] = DbMgr.CreateDoubleFieldEntry(_obj.AmountPaid);
            fields["PaymentStatusID"] = DbMgr.CreateStringFieldEntry(_obj.PaymentStatusID);

            return fields;
        }

        protected override object GetDbProperty(PaySuperannuationLine _obj, string property_name)
        {
            if (property_name.Equals("PaySuperannuation"))
            {
                return RepositoryMgr.PaySuperannuationMgr.FindById(_obj.PaySuperannuationID);
            }
            else if (property_name.Equals("SourceLine"))
            {
                return RepositoryMgr.WritePaychequeLineMgr.FindById(_obj.SourceLineID);
            }
            else if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            else if (property_name.Equals("SuperannuationFund"))
            {
                return RepositoryMgr.SuperannuationFundMgr.FindById(_obj.SuperannuationFundID);
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
            return clause.SelectAll().From("PaySuperannuationLines");
        }

        private DbSelectStatement GetQuery_SelectByPaySuperannuationLineID(int PaySuperannuationLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("PaySuperannuationLines")
                .Criteria
                    .IsEqual("PaySuperannuationLines", "PaySuperannuationLineID", PaySuperannuationLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByPaySuperannuationLineID(int PaySuperannuationLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("PaySuperannuationLines")
                .Criteria
                    .IsEqual("PaySuperannuationLines", "PaySuperannuationLineID", PaySuperannuationLineID);

            return clause;
        }

        public bool Exists(int? PaySuperannuationLineID)
        {
            if (PaySuperannuationLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByPaySuperannuationLineID(PaySuperannuationLineID.Value)) != 0;
        }

        public override bool Exists(PaySuperannuationLine _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.PaySuperannuationLineID);
        }

        protected override PaySuperannuationLine _FindByIntId(int? PaySuperannuationLineID)
        {
            if (PaySuperannuationLineID == null) return null;
            PaySuperannuationLine _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByPaySuperannuationLineID(PaySuperannuationLineID.Value));
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

        protected override IList<PaySuperannuationLine>_FindAllCollection()
        {
            List<PaySuperannuationLine> _grp = new List<PaySuperannuationLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                PaySuperannuationLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

    }
}
