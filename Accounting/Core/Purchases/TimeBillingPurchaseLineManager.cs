using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Purchases
{
    using System.Linq;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Common;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public abstract class TimeBillingPurchaseLineManager : EntityManager<TimeBillingPurchaseLine>
    {
        public TimeBillingPurchaseLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region+(Factory Methods)
        protected override TimeBillingPurchaseLine _CreateDbEntity()
        {
            return new TimeBillingPurchaseLine(true, this);
        }

        protected override TimeBillingPurchaseLine _CreateEntity()
        {
            return new TimeBillingPurchaseLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(TimeBillingPurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["TimeBillingPurchaseLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.TimeBillingPurchaseLineID);
            fields["PurchaseLineID"] = DbMgr.CreateIntFieldEntry(_obj.PurchaseLineID);
            fields["PurchaseID"] = DbMgr.CreateIntFieldEntry(_obj.PurchaseID);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["LineTypeID"] = DbMgr.CreateStringFieldEntry(_obj.LineTypeID);
            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            fields["TaxExclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveAmount);
            fields["TaxInclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveAmount);
            fields["IsMultipleJob"] = DbMgr.CreateStringFieldEntry(_obj.IsMultipleJob);
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["TaxBasisAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxBasisAmount);
            fields["TaxBasisAmountIsInclusive"] = DbMgr.CreateStringFieldEntry(_obj.TaxBasisAmountIsInclusive);
            fields["TaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.TaxCodeID);

            return fields;
        }

        public void DeleteCollectionByPurchaseID(int? PurchaseID)
        {
            IList<TimeBillingPurchaseLine> lines = FindCollectionByPurchaseID(PurchaseID);
            foreach (TimeBillingPurchaseLine line in lines)
            {
                Delete(line);
            }
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("TimeBillingPurchaseLines");
        }

        private DbSelectStatement GetQuery_SelectByTimeBillingPurchaseLineID(int TimeBillingPurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("TimeBillingPurchaseLines")
                .Criteria
                    .IsEqual("TimeBillingPurchaseLines", "TimeBillingPurchaseLineID", TimeBillingPurchaseLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByTimeBillingPurchaseLineID(int TimeBillingPurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("TimeBillingPurchaseLines")
                .Criteria
                    .IsEqual("TimeBillingPurchaseLines", "TimeBillingPurchaseLineID", TimeBillingPurchaseLineID);

            return clause;
        }

        private bool Exists(int? TimeBillingPurchaseLineID)
        {
            if (TimeBillingPurchaseLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByTimeBillingPurchaseLineID(TimeBillingPurchaseLineID.Value)) != 0;
        }

        public override bool Exists(TimeBillingPurchaseLine _obj)
        {
            return Exists(_obj.TimeBillingPurchaseLineID);
        }

        public IList<TimeBillingPurchaseLine> FindCollectionByPurchaseID(int? PurchaseID)
        {
            if (UseMemoryStore)
            {
                IList<TimeBillingPurchaseLine> store = DataStore;
                var result = from ipl in store
                             where ipl.PurchaseID == PurchaseID
                             select ipl;
                return new BindingList<TimeBillingPurchaseLine>(result.ToList());
            }
            return _FindCollectionByPurchaseID(PurchaseID);
        }

        protected IList<TimeBillingPurchaseLine> _FindCollectionByPurchaseID(int? PurchaseID)
        {
            List<TimeBillingPurchaseLine> _grp = new List<TimeBillingPurchaseLine>();
            if (PurchaseID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("TimeBillingPurchaseLines")
                .Criteria
                    .IsEqual("TimeBillingPurchaseLines", "PurchaseID", PurchaseID.Value);
            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                TimeBillingPurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override TimeBillingPurchaseLine _FindByIntId(int? TimeBillingPurchaseLineID)
        {
            if (Exists(TimeBillingPurchaseLineID))
            {
                TimeBillingPurchaseLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByTimeBillingPurchaseLineID(TimeBillingPurchaseLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(TimeBillingPurchaseLine _obj, DbDataReader _reader)
        {
            _obj.TimeBillingPurchaseLineID =GetInt32(_reader, ("TimeBillingPurchaseLineID"));
            _obj.PurchaseLineID =GetInt32(_reader, ("PurchaseLineID"));
            _obj.PurchaseID =GetInt32(_reader, ("PurchaseID"));
            _obj.LineNumber =GetInt32(_reader, ("LineNumber"));
            _obj.LineTypeID =GetString(_reader, ("LineTypeID"));
            _obj.AccountID =GetInt32(_reader, ("AccountID"));
            _obj.Description =GetString(_reader, ("Description"));
            _obj.TaxExclusiveAmount = GetDouble(_reader, ("TaxExclusiveAmount"));
            _obj.TaxInclusiveAmount = GetDouble(_reader, ("TaxInclusiveAmount"));
            _obj.IsMultipleJob =GetString(_reader, ("IsMultipleJob"));
            _obj.JobID =GetInt32(_reader, ("JobID"));
            _obj.TaxBasisAmount = GetDouble(_reader, ("TaxBasisAmount"));
            _obj.TaxBasisAmountIsInclusive =GetString(_reader, ("TaxBasisAmountIsInclusive"));
            _obj.TaxCodeID =GetInt32(_reader, ("TaxCodeID"));
        }

        protected override object GetDbProperty(TimeBillingPurchaseLine _obj, string property_name)
        {
            if (property_name.Equals("Job"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            else if (property_name.Equals("Account"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.AccountID);
            }
            else if (property_name.Equals("TaxCode"))
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.TaxCodeID);
            }
            else if (property_name.Equals("Activity"))
            {
                return RepositoryMgr.ActivityMgr.FindById(_obj.AccountID);
            }
            else if (property_name.Equals("Purchase"))
            {
                return RepositoryMgr.PurchaseMgr.FindById(_obj.PurchaseID);
            }
            return null;
        }

        protected override IList<TimeBillingPurchaseLine>_FindAllCollection()
        {
            List<TimeBillingPurchaseLine> _grp = new List<TimeBillingPurchaseLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                TimeBillingPurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
