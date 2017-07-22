using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Payroll
{
    public abstract class WageDollarHistoryManager : EntityManager<WageDollarHistory>
    {
        public WageDollarHistoryManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override WageDollarHistory _CreateDbEntity()
        {
            return new WageDollarHistory(true, this);
        }
        protected override WageDollarHistory _CreateEntity()
        {
            return new WageDollarHistory(false, this);
        }
        #endregion

        protected override void LoadFromReader(WageDollarHistory _obj, DbDataReader reader)
        {

            _obj.WageDollarHistoryID = GetInt32(reader, "WageDollarHistoryID");
            _obj.Dollars = GetDouble(reader, "Dollars");
            _obj.WageID = GetInt32(reader, "WageID");
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.PayrollYear = GetInt32(reader, "PayrollYear");
            _obj.Period = GetInt32(reader, "Period");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(WageDollarHistory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["WageDollarHistoryID"] = DbMgr.CreateAutoIntFieldEntry(_obj.WageDollarHistoryID); //GetInt32(reader, "WageDollarHistoryID");
            fields["Dollars"] = DbMgr.CreateDoubleFieldEntry(_obj.Dollars); //GetInt32(reader, "Dollars");
            fields["WageID"] = DbMgr.CreateIntFieldEntry(_obj.WageID); //GetInt32(reader, "WageID");
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID); //GetInt32(reader, "CardRecordID");
            fields["PayrollYear"] = DbMgr.CreateIntFieldEntry(_obj.PayrollYear); //GetInt32(reader, "PayrollYear");
            fields["Period"] = DbMgr.CreateIntFieldEntry(_obj.Period); //GetInt32(reader, "Period");

            return fields;
        }

        protected override object GetDbProperty(WageDollarHistory _obj, string property_name)
        {
            if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            else if (property_name.Equals("Wage"))
            {
                return RepositoryMgr.WageMgr.FindById(_obj.WageID);
            }
 
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause.SelectAll().From("WageDollarHistory");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByWageDollarHistoryID(int WageDollarHistoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("WageDollarHistory")
                .Criteria
                    .IsEqual("WageDollarHistory", "WageDollarHistoryID", WageDollarHistoryID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByWageDollarHistoryID(int WageDollarHistoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("WageDollarHistory")
                .Criteria
                    .IsEqual("WageDollarHistory", "WageDollarHistoryID", WageDollarHistoryID);

            return clause;
        }

        public bool Exists(int? WageDollarHistoryID)
        {
            if (WageDollarHistoryID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByWageDollarHistoryID(WageDollarHistoryID.Value)) != 0;
        }

        public override bool Exists(WageDollarHistory _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.WageDollarHistoryID);
        }

        protected override WageDollarHistory _FindByIntId(int? WageDollarHistoryID)
        {
            if (WageDollarHistoryID == null) return null;
            WageDollarHistory _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByWageDollarHistoryID(WageDollarHistoryID.Value));
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

        protected override IList<WageDollarHistory>_FindAllCollection()
        {
            List<WageDollarHistory> _grp = new List<WageDollarHistory>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                WageDollarHistory _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
