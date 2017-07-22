using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Purchases
{
    public abstract class PurchasesHistoryManager : EntityManager<PurchasesHistory>
    {
        public PurchasesHistoryManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override PurchasesHistory _CreateDbEntity()
        {
            return new PurchasesHistory(true, this);
        }
        protected override PurchasesHistory _CreateEntity()
        {
            return new PurchasesHistory(false, this);
        }
        #endregion

        protected override void LoadFromReader(PurchasesHistory _obj, DbDataReader reader)
        {
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.FinancialYear = GetInt32(reader, "FinancialYear");
            _obj.Period = GetInt32(reader, "Period");
            _obj.PurchaseAmount = GetDouble(reader, "PurchaseAmount");
            _obj.PurchasesHistoryID = GetInt32(reader, "PurchasesHistoryID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(PurchasesHistory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["FinancialYear"] = DbMgr.CreateIntFieldEntry(_obj.FinancialYear);
            fields["Period"] = DbMgr.CreateIntFieldEntry(_obj.Period);
            fields["PurchaseAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.PurchaseAmount);
            fields["PurchasesHistoryID"] = DbMgr.CreateAutoIntFieldEntry(_obj.PurchasesHistoryID);

            return fields;
        }

        protected override object GetDbProperty(PurchasesHistory _obj, string property_name)
        {
            if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectCountByPurchasesHistoryID(int PurchasesHistoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("PurchasesHistory")
                .Criteria
                    .IsEqual("PurchasesHistory", "PurchasesHistoryID", PurchasesHistoryID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectByPurchasesHistoryID(int PurchasesHistoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("PurchasesHistory")
                .Criteria
                    .IsEqual("PurchasesHistory", "PurchasesHistoryID", PurchasesHistoryID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("PurchasesHistory");

            return clause;
        }

        public bool Exists(int? PurchasesHistoryID)
        {
            if (PurchasesHistoryID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByPurchasesHistoryID(PurchasesHistoryID.Value)) != 0;
        }

        public override bool Exists(PurchasesHistory _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.PurchasesHistoryID);
        }

        protected override IList<PurchasesHistory>_FindAllCollection()
        {
            List<PurchasesHistory> _grp = new List<PurchasesHistory>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                PurchasesHistory _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override PurchasesHistory _FindByIntId(int? PurchasesHistoryID)
        {
            PurchasesHistory _obj = null;
            if (PurchasesHistoryID == null) return null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByPurchasesHistoryID(PurchasesHistoryID.Value));
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
