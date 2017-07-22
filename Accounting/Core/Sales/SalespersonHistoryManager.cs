using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Sales
{
    public abstract class SalespersonHistoryManager : EntityManager<SalespersonHistory>
    {
        public SalespersonHistoryManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override SalespersonHistory _CreateDbEntity()
        {
            return new SalespersonHistory(true, this);
        }
        protected override SalespersonHistory _CreateEntity()
        {
            return new SalespersonHistory(false, this);
        }
        #endregion

        protected override void LoadFromReader(SalespersonHistory _obj, DbDataReader reader)
        {
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.FinancialYear = GetInt32(reader, "FinancialYear");
            _obj.Period = GetInt32(reader, "Period");
            _obj.SalespersonHistoryID = GetInt32(reader, "SalespersonHistoryID");
            _obj.SoldAmount = GetDouble(reader, "SoldAmount");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(SalespersonHistory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["CardRecordID"]=DbMgr.CreateIntFieldEntry(_obj.CardRecordID); //GetInt32(reader, "CardRecordID");
            fields["FinancialYear"] = DbMgr.CreateIntFieldEntry(_obj.FinancialYear); //GetInt32(reader, "FinancialYear");
            fields["Period"] = DbMgr.CreateIntFieldEntry(_obj.Period); //GetInt32(reader, "Period");
            fields["SalespersonHistoryID"] = DbMgr.CreateAutoIntFieldEntry(_obj.SalespersonHistoryID); //GetInt32(reader, "SalespersonHistoryID");
            fields["SoldAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.SoldAmount); //GetDouble(reader, "SoldAmount");

            return fields;
        }

        protected override object GetDbProperty(SalespersonHistory _obj, string property_name)
        {
            if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("SalespersonHistory");
        }

        private DbSelectStatement GetQuery_SelectBySalespersonHistoryID(int SalespersonHistoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("SalespersonHistory")
                .Criteria
                    .IsEqual("SalespersonHistory", "SalespersonHistoryID", SalespersonHistoryID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountBySalespersonHistoryID(int SalespersonHistoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("SalespersonHistory")
                .Criteria
                    .IsEqual("SalespersonHistory", "SalespersonHistoryID", SalespersonHistoryID);

            return clause;
        }

        public bool Exists(int? SalespersonHistoryID)
        {
            if (SalespersonHistoryID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountBySalespersonHistoryID(SalespersonHistoryID.Value)) != 0;
        }

        public override bool Exists(SalespersonHistory _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.SalespersonHistoryID);
        }

        protected override SalespersonHistory _FindByIntId(int? SalespersonHistoryID)
        {
            SalespersonHistory _obj = null;
            if (SalespersonHistoryID == null) return _obj;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectBySalespersonHistoryID(SalespersonHistoryID.Value));

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

        protected override IList<SalespersonHistory>_FindAllCollection()
        {
            List<SalespersonHistory> _grp = new List<SalespersonHistory>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                SalespersonHistory _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}

