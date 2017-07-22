using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Activities
{
    public abstract class ActivitySlipInvoicedManager : EntityManager<ActivitySlipInvoiced>
    {
        public ActivitySlipInvoicedManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override ActivitySlipInvoiced _CreateDbEntity()
        {
            return new ActivitySlipInvoiced(true, this);
        }
        protected override ActivitySlipInvoiced _CreateEntity()
        {
            return new ActivitySlipInvoiced(false, this);
        }
        #endregion

        protected override void LoadFromReader(ActivitySlipInvoiced _obj, DbDataReader reader)
        {
            _obj.ActivitySlipID = GetInt32(reader, "ActivitySlipID");
            _obj.ActivitySlipInvoicedID = GetInt32(reader, "ActivitySlipInvoicedID");
            _obj.SaleID = GetInt32(reader, "SaleID");
            _obj.InvoicedDollars = GetDouble(reader, "InvoicedDollars");
            _obj.InvoicedUnits = GetDouble(reader, "InvoicedDollars");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(ActivitySlipInvoiced _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["ActivitySlipID"] = DbMgr.CreateIntFieldEntry(_obj.ActivitySlipID); //GetInt32(reader, "");
            fields["ActivitySlipInvoicedID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ActivitySlipInvoicedID); //GetInt32(reader, "");
            fields["SaleID"] = DbMgr.CreateIntFieldEntry(_obj.SaleID); //GetInt32(reader, "");
            fields["InvoicedDollars"] = DbMgr.CreateDoubleFieldEntry(_obj.InvoicedDollars); //GetDouble(reader, "");
            fields["InvoicedDollars"] = DbMgr.CreateDoubleFieldEntry(_obj.InvoicedUnits); //GetDouble(reader, "");
           
            return fields;
        }

        protected override object GetDbProperty(ActivitySlipInvoiced _obj, string property_name)
        {
            if (property_name.Equals("ActivitySlip"))
            {
                return RepositoryMgr.ActivitySlipMgr.FindById(_obj.ActivitySlipID);
            }
            else if (property_name.Equals("Sale"))
            {
                return RepositoryMgr.SaleMgr.FindById(_obj.SaleID);
            }
           
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            return clause.SelectAll().From("ActivitySlipInvoiced");
        }

        private DbSelectStatement GetQuery_SelectByActivitySlipInvoicedID(int ActivitySlipInvoicedID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("ActivitySlipInvoiced")
                .Criteria
                    .IsEqual("ActivitySlipInvoiced", "ActivitySlipInvoicedID", ActivitySlipInvoicedID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByActivitySlipInvoicedID(int ActivitySlipInvoicedID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("ActivitySlipInvoiced")
                .Criteria
                    .IsEqual("ActivitySlipInvoiced", "ActivitySlipInvoicedID", ActivitySlipInvoicedID);

            return clause;
        }

        public bool Exists(int? ActivitySlipInvoicedID)
        {
            if (ActivitySlipInvoicedID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByActivitySlipInvoicedID(ActivitySlipInvoicedID.Value)) != 0;
        }

        public override bool Exists(ActivitySlipInvoiced _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.ActivitySlipInvoicedID);
        }

        protected override ActivitySlipInvoiced _FindByIntId(int? ActivitySlipInvoicedID)
        {
            if (ActivitySlipInvoicedID == null) return null;

            ActivitySlipInvoiced _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByActivitySlipInvoicedID(ActivitySlipInvoicedID.Value));
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

        protected override IList<ActivitySlipInvoiced>_FindAllCollection()
        {
            List<ActivitySlipInvoiced> _grp = new List<ActivitySlipInvoiced>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                ActivitySlipInvoiced _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

    }
}
