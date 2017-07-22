using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Sales
{
    using System.ComponentModel;
    using System.Linq;

    public abstract class RecurringTimeBillingSaleLineManager : EntityManager<RecurringTimeBillingSaleLine>
    {
        public RecurringTimeBillingSaleLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override RecurringTimeBillingSaleLine _CreateDbEntity()
        {
            return new RecurringTimeBillingSaleLine(true, this);
        }

        protected override RecurringTimeBillingSaleLine _CreateEntity()
        {
            return new RecurringTimeBillingSaleLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(RecurringTimeBillingSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["RecurringTimeBillingSaleLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringTimeBillingSaleLineID);
            fields["RecurringSaleLineID"] = DbMgr.CreateIntFieldEntry(_obj.RecurringSaleLineID);
            fields["RecurringSaleID"] = DbMgr.CreateIntFieldEntry(_obj.RecurringSaleID);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["LineTypeID"] = DbMgr.CreateStringFieldEntry(_obj.LineTypeID);
            fields["Notes"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            fields["TaxExclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveAmount);
            fields["TaxInclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveAmount);
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
                .From("RecurringTimeBillingSaleLines");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByRecurringTimeBillingSaleLineID(int RecurringTimeBillingSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringTimeBillingSaleLines")
                .Criteria
                    .IsEqual("RecurringTimeBillingSaleLines", "RecurringTimeBillingSaleLineID", RecurringTimeBillingSaleLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecurringTimeBillingSaleLineID(int RecurringTimeBillingSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("RecurringTimeBillingSaleLines")
                .Criteria
                    .IsEqual("RecurringTimeBillingSaleLines", "RecurringTimeBillingSaleLineID", RecurringTimeBillingSaleLineID);

            return clause;
        }

        private bool Exists(int? RecurringTimeBillingSaleLineID)
        {
            if (RecurringTimeBillingSaleLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringTimeBillingSaleLineID(RecurringTimeBillingSaleLineID.Value)) != 0;
        }

        public override bool Exists(RecurringTimeBillingSaleLine _obj)
        {
            if (_obj.RecurringTimeBillingSaleLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringTimeBillingSaleLineID(_obj.RecurringTimeBillingSaleLineID.Value)) != 0;
        }

        public void DeleteCollectionBySaleID(int? SaleID)
        {
            IList<RecurringTimeBillingSaleLine> lines = FindCollectionBySaleID(SaleID);
            foreach (RecurringTimeBillingSaleLine line in lines)
            {
                Delete(line);
            }
        }

        public IList<RecurringTimeBillingSaleLine> FindCollectionBySaleID(int? SaleID)
        {
            if (UseMemoryStore)
            {
                IList<RecurringTimeBillingSaleLine> store = DataStore;
                var result = from ipl in store
                             where ipl.RecurringSaleID == SaleID
                             select ipl;
                return new BindingList<RecurringTimeBillingSaleLine>(result.ToList());
            }
            return _FindCollectionBySaleID(SaleID);
        }

        protected IList<RecurringTimeBillingSaleLine> _FindCollectionBySaleID(int? RecurringSaleID)
        {
            BindingList<RecurringTimeBillingSaleLine> _grp = new BindingList<RecurringTimeBillingSaleLine>();

            if (RecurringSaleID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringTimeBillingSaleLines")
                .Criteria
                    .IsEqual("RecurringTimeBillingSaleLines", "RecurringSaleID", RecurringSaleID.Value);

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringTimeBillingSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override RecurringTimeBillingSaleLine _FindByIntId(int? RecurringTimeBillingSaleLineID)
        {
            if (Exists(RecurringTimeBillingSaleLineID))
            {
                RecurringTimeBillingSaleLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByRecurringTimeBillingSaleLineID(RecurringTimeBillingSaleLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(RecurringTimeBillingSaleLine _obj, DbDataReader _reader)
        {
            _obj.RecurringTimeBillingSaleLineID =GetInt32(_reader, ("RecurringTimeBillingSaleLineID"));
            _obj.RecurringSaleLineID =GetInt32(_reader, ("RecurringSaleLineID"));
            _obj.RecurringSaleID =GetInt32(_reader, ("RecurringSaleID"));
            _obj.LineNumber =GetInt32(_reader, ("LineNumber"));
            _obj.LineTypeID =GetString(_reader, ("LineTypeID"));
            _obj.Description =GetString(_reader, ("Notes"));
            _obj.TaxExclusiveAmount = GetDouble(_reader, ("TaxExclusiveAmount"));
            _obj.TaxInclusiveAmount = GetDouble(_reader, ("TaxInclusiveAmount"));
            _obj.JobID =GetInt32(_reader, ("JobID"));
            _obj.TaxBasisAmount = GetDouble(_reader, ("TaxBasisAmount"));
            _obj.TaxBasisAmountIsInclusive =GetString(_reader, ("TaxBasisAmountIsInclusive"));
            _obj.TaxCodeID =GetInt32(_reader, ("TaxCodeID"));
            _obj.LineDate = _reader.GetDateTime(_reader.GetOrdinal("LineDate"));
            _obj.HoursUnits = GetDouble(_reader, ("HoursUnits"));
            _obj.ActivityID =GetInt32(_reader, ("ActivityID"));
        }

        protected override object GetDbProperty(RecurringTimeBillingSaleLine _obj, string property_name)
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
            else if (property_name.Equals("RecurringSale"))
            {
                return RepositoryMgr.RecurringSaleMgr.FindById(_obj.RecurringSaleID);
            }
            return null;
        }

        protected override IList<RecurringTimeBillingSaleLine>_FindAllCollection()
        {
            List<RecurringTimeBillingSaleLine> _grp = new List<RecurringTimeBillingSaleLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringTimeBillingSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
