using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Sales
{
    using System.Linq;
    using System.ComponentModel;

    public abstract class TimeBillingSaleLineManager : EntityManager<TimeBillingSaleLine>
    {
        public TimeBillingSaleLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override TimeBillingSaleLine _CreateDbEntity()
        {
            return new TimeBillingSaleLine(true, this);
        }

        protected override TimeBillingSaleLine _CreateEntity()
        {
            return new TimeBillingSaleLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(TimeBillingSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["TimeBillingSaleLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.TimeBillingSaleLineID);
            fields["SaleLineID"] = DbMgr.CreateIntFieldEntry(_obj.SaleLineID);
            fields["SaleID"] = DbMgr.CreateIntFieldEntry(_obj.SaleID);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["LineTypeID"] = DbMgr.CreateStringFieldEntry(_obj.LineTypeID);
            fields["Notes"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            fields["TaxExclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveAmount);
            fields["TaxInclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveAmount);
            fields["IsMultipleJob"] = DbMgr.CreateStringFieldEntry(_obj.IsMultipleJob);
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["TaxBasisAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxBasisAmount);
            fields["TaxBasisAmountIsInclusive"] = DbMgr.CreateStringFieldEntry(_obj.TaxBasisAmountIsInclusive);
            fields["TaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.TaxCodeID);
            fields["LineDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.LineDate);
            fields["HoursUnits"] = DbMgr.CreateDoubleFieldEntry(_obj.HoursUnits);
            fields["ActivityID"] = DbMgr.CreateIntFieldEntry(_obj.ActivityID);
            fields["LocationID"] = DbMgr.CreateIntFieldEntry(_obj.LocationID);
            fields["EstimatedCost"] = DbMgr.CreateDoubleFieldEntry(_obj.EstimatedCost);
            fields["TaxExclusiveRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveRate);
            fields["TaxInclusiveRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveRate);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("TimeBillingSaleLines");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByTimeBillingSaleLineID(int TimeBillingSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("TimeBillingSaleLines")
                .Criteria
                    .IsEqual("TimeBillingSaleLines", "TimeBillingSaleLineID", TimeBillingSaleLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByTimeBillingSaleLineID(int TimeBillingSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("TimeBillingSaleLines")
                .Criteria
                    .IsEqual("TimeBillingSaleLines", "TimeBillingSaleLineID", TimeBillingSaleLineID);

            return clause;
        }

        private bool Exists(int? TimeBillingSaleLineID)
        {
            if (TimeBillingSaleLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByTimeBillingSaleLineID(TimeBillingSaleLineID.Value)) != 0;
        }

        public override bool Exists(TimeBillingSaleLine _obj)
        {
            if (_obj.TimeBillingSaleLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByTimeBillingSaleLineID(_obj.TimeBillingSaleLineID.Value)) != 0;
        }

        public void DeleteCollectionBySaleID(int? SaleID)
        {
            IList<TimeBillingSaleLine> lines = FindCollectionBySaleID(SaleID);
            foreach (TimeBillingSaleLine line in lines)
            {
                Delete(line);
            }
        }

        public IList<TimeBillingSaleLine> FindCollectionBySaleID(int? SaleID)
        {
            if (UseMemoryStore)
            {
                IList<TimeBillingSaleLine> store = DataStore;
                var result = from ipl in store
                             where ipl.SaleID == SaleID
                             select ipl;
                return new BindingList<TimeBillingSaleLine>(result.ToList());
            }
            return _FindCollectionBySaleID(SaleID);
        }

        protected IList<TimeBillingSaleLine> _FindCollectionBySaleID(int? SaleID)
        {
            BindingList<TimeBillingSaleLine> _grp = new BindingList<TimeBillingSaleLine>();

            if (SaleID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("TimeBillingSaleLines")
                .Criteria
                    .IsEqual("TimeBillingSaleLines", "SaleID", SaleID.Value);

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                TimeBillingSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override TimeBillingSaleLine _FindByIntId(int? TimeBillingSaleLineID)
        {
            if (Exists(TimeBillingSaleLineID))
            {
                TimeBillingSaleLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByTimeBillingSaleLineID(TimeBillingSaleLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(TimeBillingSaleLine _obj, DbDataReader _reader)
        {
            _obj.TimeBillingSaleLineID =GetInt32(_reader, ("TimeBillingSaleLineID"));
            _obj.SaleLineID =GetInt32(_reader, ("SaleLineID"));
            _obj.SaleID =GetInt32(_reader, ("SaleID"));
            _obj.LineNumber =GetInt32(_reader, ("LineNumber"));
            _obj.LineTypeID =GetString(_reader, ("LineTypeID"));
            _obj.Description =GetString(_reader, ("Notes"));
            _obj.TaxExclusiveAmount = GetDouble(_reader, ("TaxExclusiveAmount"));
            _obj.TaxInclusiveAmount = GetDouble(_reader, ("TaxInclusiveAmount"));
            _obj.IsMultipleJob =GetString(_reader, ("IsMultipleJob"));
            _obj.JobID =GetInt32(_reader, ("JobID"));
            _obj.TaxBasisAmount = GetDouble(_reader, ("TaxBasisAmount"));
            _obj.TaxBasisAmountIsInclusive =GetString(_reader, ("TaxBasisAmountIsInclusive"));
            _obj.TaxCodeID =GetInt32(_reader, ("TaxCodeID"));
            _obj.LineDate = _reader.GetDateTime(_reader.GetOrdinal("LineDate"));
            _obj.HoursUnits = GetDouble(_reader, ("HoursUnits"));
            _obj.ActivityID =GetInt32(_reader, ("ActivityID"));
        }

        protected override object GetDbProperty(TimeBillingSaleLine _obj, string property_name)
        {
            if (property_name.Equals("TaxCode"))
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.TaxCodeID);
            }
            else if (property_name.Equals("Location"))
            {
                return RepositoryMgr.LocationMgr.FindByLocationID(_obj.LocationID);
            }
            else if (property_name.Equals("Job"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            else if (property_name.Equals("Activity"))
            {
                return RepositoryMgr.ActivityMgr.FindById(_obj.ActivityID); 
            }
            else if (property_name.Equals("Sale"))
            {
                return RepositoryMgr.SaleMgr.FindById(_obj.SaleID);
            }
            return null;
        }

        protected override IList<TimeBillingSaleLine>_FindAllCollection()
        {
            List<TimeBillingSaleLine> _grp = new List<TimeBillingSaleLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                TimeBillingSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
