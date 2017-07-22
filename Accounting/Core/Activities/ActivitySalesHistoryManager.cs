using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Activities
{
    public abstract class ActivitySalesHistoryManager : EntityManager<ActivitySalesHistory>
    {
        public ActivitySalesHistoryManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override ActivitySalesHistory _CreateDbEntity()
        {
            return new ActivitySalesHistory(true, this);
        }
        protected override ActivitySalesHistory _CreateEntity()
        {
            return new ActivitySalesHistory(false, this);
        }
        #endregion

        protected override void LoadFromReader(ActivitySalesHistory _obj, DbDataReader reader)
        {
            _obj.ActivityID = GetInt32(reader, "ActivityID");
            _obj.ActivitySalesHistoryID = GetInt32(reader, "ActivitySalesHistoryID");
            _obj.EstimatedCostOfSalesAmount = GetDouble(reader, "EstimatedCostOfSalesAmount");
            _obj.FinancialYear = GetInt32(reader, "FinancialYear");
            _obj.Period = GetInt32(reader, "Period");
            _obj.SaleAmount = GetDouble(reader, "SaleAmount");
            _obj.UnitsSold = GetDouble(reader, "UnitsSold");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ActivitySalesHistory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ActivityID"] = DbMgr.CreateIntFieldEntry(_obj.ActivityID); //GetInt32(reader, "");
            fields["ActivitySalesHistoryID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ActivitySalesHistoryID); //GetInt32(reader, "");
            fields["EstimatedCostOfSalesAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.EstimatedCostOfSalesAmount); //GetDouble(reader, "");
            fields["FinancialYear"] = DbMgr.CreateIntFieldEntry(_obj.FinancialYear); //GetInt32(reader, "");
            fields["Period"] = DbMgr.CreateIntFieldEntry(_obj.Period); //GetInt32(reader, "");
            fields["SaleAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.SaleAmount); //GetDouble(reader, "");
            fields["UnitsSold"] = DbMgr.CreateDoubleFieldEntry(_obj.UnitsSold); //GetDouble(reader, "");

            return fields;
        }

        protected override object GetDbProperty(ActivitySalesHistory _obj, string property_name)
        {
            if (property_name.Equals("Activity"))
            {
                return RepositoryMgr.ActivityMgr.FindById(_obj.ActivityID);
            }
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("ActivitySalesHistory");
        }

        private DbSelectStatement GetQuery_SelectByActivitySalesHistoryID(int ActivitySalesHistoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("ActivitySalesHistory")
                .Criteria
                    .IsEqual("ActivitySalesHistory", "ActivitySalesHistoryID", ActivitySalesHistoryID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByActivitySalesHistoryID(int ActivitySalesHistoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("ActivitySalesHistory")
                .Criteria
                    .IsEqual("ActivitySalesHistory", "ActivitySalesHistoryID", ActivitySalesHistoryID);

            return clause;
        }

        public bool Exists(int? ActivitySalesHistoryID)
        {
            if (ActivitySalesHistoryID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByActivitySalesHistoryID(ActivitySalesHistoryID.Value)) != 0;
        }

        public override bool Exists(ActivitySalesHistory _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.ActivitySalesHistoryID);
        }

        protected override ActivitySalesHistory _FindByIntId(int? ActivitySalesHistoryID)
        {
            if (ActivitySalesHistoryID == null) return null;
            ActivitySalesHistory _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByActivitySalesHistoryID(ActivitySalesHistoryID.Value));
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

        protected override IList<ActivitySalesHistory>_FindAllCollection()
        {
            List<ActivitySalesHistory> _grp = new List<ActivitySalesHistory>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                ActivitySalesHistory _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        
    }
}
