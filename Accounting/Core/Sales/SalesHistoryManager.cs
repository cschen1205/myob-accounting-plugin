using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Sales
{
    public abstract class SalesHistoryManager : EntityManager<SalesHistory>
    {
        public SalesHistoryManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override SalesHistory _CreateDbEntity()
        {
            return new SalesHistory(true, this);
        }
        protected override SalesHistory _CreateEntity()
        {
            return new SalesHistory(false, this);
        }
        #endregion

        protected override void LoadFromReader(SalesHistory _obj, DbDataReader reader)
        {
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.FinancialYear = GetInt32(reader, "FinancialYear");
            _obj.Period = GetInt32(reader, "Period");
            _obj.SaleAmount = GetDouble(reader, "SaleAmount");
            _obj.SalesHistoryID = GetInt32(reader, "SalesHistoryID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(SalesHistory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["FinancialYear"] = DbMgr.CreateIntFieldEntry(_obj.FinancialYear);
            fields["Period"] = DbMgr.CreateIntFieldEntry(_obj.Period);
            fields["SaleAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.SaleAmount);
            fields["SalesHistoryID"] = DbMgr.CreateAutoIntFieldEntry(_obj.SalesHistoryID);

            return fields;
        }

        protected override object GetDbProperty(SalesHistory _obj, string property_name)
        {
            if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectCountBySalesHistoryID(int SalesHistoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("SalesHistory")
                .Criteria
                    .IsEqual("SalesHistory", "SalesHistoryID", SalesHistoryID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectBySalesHistoryID(int SalesHistoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("SalesHistory")
                .Criteria
                    .IsEqual("SalesHistory", "SalesHistoryID", SalesHistoryID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("SalesHistory");

            return clause;
        }

        public bool Exists(int? SalesHistoryID)
        {
            if (SalesHistoryID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountBySalesHistoryID(SalesHistoryID.Value)) != 0;
        }

        public override bool Exists(SalesHistory _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.SalesHistoryID);
        }

        protected override IList<SalesHistory>_FindAllCollection()
        {
            List<SalesHistory> _grp = new List<SalesHistory>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                SalesHistory _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override SalesHistory _FindByIntId(int? SalesHistoryID)
        {
            SalesHistory _obj = null;
            if (SalesHistoryID == null) return null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectBySalesHistoryID(SalesHistoryID.Value));
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
