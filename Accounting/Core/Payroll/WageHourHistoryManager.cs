using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Payroll
{
    public abstract class WageHourHistoryManager : EntityManager<WageHourHistory>
    {
        public WageHourHistoryManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override WageHourHistory _CreateDbEntity()
        {
            return new WageHourHistory(true, this);
        }
        protected override WageHourHistory _CreateEntity()
        {
            return new WageHourHistory(false, this);
        }
        #endregion

        protected override void LoadFromReader(WageHourHistory _obj, DbDataReader reader)
        {

            _obj.WageHourHistoryID = GetInt32(reader, "WageHourHistoryID");
            _obj.Hours = GetDouble(reader, "Hours");
            _obj.WageID = GetInt32(reader, "WageID");
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
            _obj.PayrollYear = GetInt32(reader, "PayrollYear");
            _obj.Period = GetInt32(reader, "Period");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(WageHourHistory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["WageHourHistoryID"] = DbMgr.CreateAutoIntFieldEntry(_obj.WageHourHistoryID); //GetInt32(reader, "WageHourHistoryID");
            fields["Hours"] = DbMgr.CreateDoubleFieldEntry(_obj.Hours); //GetInt32(reader, "Hours");
            fields["WageID"] = DbMgr.CreateIntFieldEntry(_obj.WageID); //GetInt32(reader, "WageID");
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID); //GetInt32(reader, "CardRecordID");
            fields["PayrollYear"] = DbMgr.CreateIntFieldEntry(_obj.PayrollYear); //GetInt32(reader, "PayrollYear");
            fields["Period"] = DbMgr.CreateIntFieldEntry(_obj.Period); //GetInt32(reader, "Period");

            return fields;
        }

        protected override object GetDbProperty(WageHourHistory _obj, string property_name)
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

            clause.SelectAll().From("WageHourHistory");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByWageHourHistoryID(int WageHourHistoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("WageHourHistory")
                .Criteria
                    .IsEqual("WageHourHistory", "WageHourHistoryID", WageHourHistoryID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByWageHourHistoryID(int WageHourHistoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("WageHourHistory")
                .Criteria
                    .IsEqual("WageHourHistory", "WageHourHistoryID", WageHourHistoryID);

            return clause;
        }

        public bool Exists(int? WageHourHistoryID)
        {
            if (WageHourHistoryID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByWageHourHistoryID(WageHourHistoryID.Value)) != 0;
        }

        public override bool Exists(WageHourHistory _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.WageHourHistoryID);
        }

        protected override WageHourHistory _FindByIntId(int? WageHourHistoryID)
        {
            if (WageHourHistoryID == null) return null;
            WageHourHistory _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByWageHourHistoryID(WageHourHistoryID.Value));
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

        protected override IList<WageHourHistory>_FindAllCollection()
        {
            List<WageHourHistory> _grp = new List<WageHourHistory>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                WageHourHistory _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
