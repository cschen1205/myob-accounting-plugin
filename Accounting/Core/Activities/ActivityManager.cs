using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Activities
{
    public abstract class ActivityManager : EntityManager<Activity>
    {
        public ActivityManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override Activity _CreateDbEntity()
        {
            return new Activity(true, this);
        }

        protected override Activity _CreateEntity()
        {
            return new Activity(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(Activity _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["ActivityID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ActivityID);
            fields["IsInactive"] = DbMgr.CreateStringFieldEntry(_obj.IsInactive);
            fields["ActivityName"] = DbMgr.CreateStringFieldEntry(_obj.ActivityName);
            fields["ActivityNumber"] = DbMgr.CreateStringFieldEntry(_obj.ActivityNumber);
            fields["IncomeAccountID"] = DbMgr.CreateIntFieldEntry(_obj.IncomeAccountID);
            fields["IsHourly"] = DbMgr.CreateStringFieldEntry(_obj.IsHourly);
            fields["IsChargeable"] = DbMgr.CreateStringFieldEntry(_obj.IsChargeable);
            fields["BillingRateUsedID"] = DbMgr.CreateStringFieldEntry(_obj.BillingRateUsedID);
            fields["ActivityDescription"] = DbMgr.CreateStringFieldEntry(_obj.ActivityDescription);
            fields["UseDescription"] = DbMgr.CreateStringFieldEntry(_obj.UseDescription);
            fields["ActivityRate"] = DbMgr.CreateDoubleFieldEntry(_obj.ActivityRate);
            fields["TaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.TaxCodeID);
            fields["SellUnitMeasure"] = DbMgr.CreateStringFieldEntry(_obj.SellUnitMeasure);
            fields["ChangeControl"] = DbMgr.CreateIntFieldEntry(_obj.ChangeControl);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Activities");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByActivityID(int ActivityID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Activities")
                .Criteria.IsEqual("Activities", "ActivityID", ActivityID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByActivityID(int ActivityID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Activities")
                .Criteria.IsEqual("Activities", "ActivityID", ActivityID);

            return clause;
        }

        private bool Exists(int? ActivityID)
        {
            if (ActivityID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByActivityID(ActivityID.Value)) != 0;
        }

        public override bool Exists(Activity _obj)
        {
            if (_obj.ActivityID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByActivityID(_obj.ActivityID.Value)) != 0;
        }

        protected override void LoadFromReader(Activity _obj, DbDataReader reader)
        {
            _obj.ActivityID =GetInt32(reader, ("ActivityID"));
            _obj.IsInactive =GetString(reader, ("IsInactive"));
            _obj.ActivityName =GetString(reader, ("ActivityName"));
            _obj.ActivityNumber =GetString(reader, ("ActivityNumber"));
            _obj.IncomeAccountID =GetInt32(reader, ("IncomeAccountID"));
            _obj.IsHourly =GetString(reader, ("IsHourly"));
            _obj.IsChargeable =GetString(reader, ("IsChargeable"));
            _obj.BillingRateUsedID =GetString(reader, ("BillingRateUsedID"));
            _obj.ActivityDescription =GetString(reader, ("ActivityDescription"));
            _obj.UseDescription =GetString(reader, ("UseDescription"));
            _obj.ActivityRate = GetDouble(reader, ("ActivityRate"));
            _obj.TaxCodeID =GetInt32(reader, ("TaxCodeID"));
            _obj.SellUnitMeasure =GetString(reader, ("SellUnitMeasure"));
            _obj.ChangeControl =GetInt32(reader, ("ChangeControl"));
        }

        protected override object GetDbProperty(Activity _obj, string property_name)
        {
            if (property_name == "IncomeAccount") //IncomeAccount
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.IncomeAccountID);
            }
            else if (property_name == "TaxCode")
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.TaxCodeID);
            }
            else if (property_name == "BillingRateUsed")
            {
                return RepositoryMgr.BillingRateUsedMgr.FindById(_obj.BillingRateUsedID);
            }
            return null;
        }

        protected override Activity _FindByIntId(int? ActivityID)
        {
            if (Exists(ActivityID))
            {
                Activity _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByActivityID(ActivityID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<Activity>_FindAllCollection()
        {
            List<Activity> objs = new List<Activity>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Activity _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                objs.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return objs;
        }

    }
}
