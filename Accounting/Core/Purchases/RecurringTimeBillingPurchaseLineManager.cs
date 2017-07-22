using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Purchases
{
    using System.ComponentModel;
    using System.Linq;
    public abstract class RecurringTimeBillingPurchaseLineManager : RecurringEntityManager<RecurringTimeBillingPurchaseLine>
    {
        public RecurringTimeBillingPurchaseLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region+(Factory Methods)
        protected override RecurringTimeBillingPurchaseLine _CreateDbEntity()
        {
            return new RecurringTimeBillingPurchaseLine(true, this);
        }

        protected override RecurringTimeBillingPurchaseLine _CreateEntity()
        {
            return new RecurringTimeBillingPurchaseLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(RecurringTimeBillingPurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["RecurringTimeBillingPurchaseLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringTimeBillingPurchaseLineID);
            fields["RecurringPurchaseLineID"] = DbMgr.CreateIntFieldEntry(_obj.RecurringPurchaseLineID);
            fields["RecurringPurchaseID"] = DbMgr.CreateIntFieldEntry(_obj.RecurringPurchaseID);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["LineTypeID"] = DbMgr.CreateStringFieldEntry(_obj.LineTypeID);
            fields["AccountID"] = DbMgr.CreateIntFieldEntry(_obj.AccountID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            fields["TaxExclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveAmount);
            fields["TaxInclusiveAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveAmount);
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["TaxBasisAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxBasisAmount);
            fields["TaxBasisAmountIsInclusive"] = DbMgr.CreateStringFieldEntry(_obj.TaxBasisAmountIsInclusive);
            fields["TaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.TaxCodeID);

            return fields;
        }
        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("RecurringTimeBillingPurchaseLines");
        }

        private DbSelectStatement GetQuery_SelectByRecurringTimeBillingPurchaseLineID(int RecurringTimeBillingPurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringTimeBillingPurchaseLines")
                .Criteria
                    .IsEqual("RecurringTimeBillingPurchaseLines", "RecurringTimeBillingPurchaseLineID", RecurringTimeBillingPurchaseLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecurringTimeBillingPurchaseLineID(int RecurringTimeBillingPurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("RecurringTimeBillingPurchaseLines")
                .Criteria
                    .IsEqual("RecurringTimeBillingPurchaseLines", "RecurringTimeBillingPurchaseLineID", RecurringTimeBillingPurchaseLineID);

            return clause;
        }

        private bool Exists(int? RecurringTimeBillingPurchaseLineID)
        {
            if (RecurringTimeBillingPurchaseLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringTimeBillingPurchaseLineID(RecurringTimeBillingPurchaseLineID.Value)) != 0;
        }

        public override bool Exists(RecurringTimeBillingPurchaseLine _obj)
        {
            return Exists(_obj.RecurringTimeBillingPurchaseLineID);
        }

        public void DeleteCollectionByPurchaseID(int? PurchaseID)
        {
            IList<RecurringTimeBillingPurchaseLine> lines = FindCollectionByPurchaseID(PurchaseID);
            foreach (RecurringTimeBillingPurchaseLine line in lines)
            {
                Delete(line);
            }
        }

        public IList<RecurringTimeBillingPurchaseLine> FindCollectionByPurchaseID(int? PurchaseID)
        {
            if (UseMemoryStore)
            {
                IList<RecurringTimeBillingPurchaseLine> store = DataStore;
                var result = from ipl in store
                             where ipl.RecurringPurchaseID == PurchaseID
                             select ipl;
                return new BindingList<RecurringTimeBillingPurchaseLine>(result.ToList());
            }
            return _FindCollectionByPurchaseID(PurchaseID);
        }

        protected IList<RecurringTimeBillingPurchaseLine> _FindCollectionByPurchaseID(int? RecurringPurchaseID)
        {
            BindingList<RecurringTimeBillingPurchaseLine> _grp = new BindingList<RecurringTimeBillingPurchaseLine>();
            if (RecurringPurchaseID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringTimeBillingPurchaseLines")
                .Criteria
                    .IsEqual("RecurringTimeBillingPurchaseLines", "RecurringPurchaseID", RecurringPurchaseID.Value);
            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringTimeBillingPurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override RecurringTimeBillingPurchaseLine _FindByIntId(int? RecurringTimeBillingPurchaseLineID)
        {
            if (Exists(RecurringTimeBillingPurchaseLineID))
            {
                RecurringTimeBillingPurchaseLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByRecurringTimeBillingPurchaseLineID(RecurringTimeBillingPurchaseLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(RecurringTimeBillingPurchaseLine _obj, DbDataReader _reader)
        {
            _obj.RecurringTimeBillingPurchaseLineID =GetInt32(_reader, ("RecurringTimeBillingPurchaseLineID"));
            _obj.RecurringPurchaseLineID =GetInt32(_reader, ("RecurringPurchaseLineID"));
            _obj.RecurringPurchaseID =GetInt32(_reader, ("RecurringPurchaseID"));
            _obj.LineNumber =GetInt32(_reader, ("LineNumber"));
            _obj.LineTypeID =GetString(_reader, ("LineTypeID"));
            _obj.AccountID =GetInt32(_reader, ("AccountID"));
            _obj.Description =GetString(_reader, ("Description"));
            _obj.TaxExclusiveAmount = GetDouble(_reader, ("TaxExclusiveAmount"));
            _obj.TaxInclusiveAmount = GetDouble(_reader, ("TaxInclusiveAmount"));
            _obj.JobID =GetInt32(_reader, ("JobID"));
            _obj.TaxBasisAmount = GetDouble(_reader, ("TaxBasisAmount"));
            _obj.TaxBasisAmountIsInclusive =GetString(_reader, ("TaxBasisAmountIsInclusive"));
            _obj.TaxCodeID =GetInt32(_reader, ("TaxCodeID"));
        }

        protected override object GetDbProperty(RecurringTimeBillingPurchaseLine _obj, string property_name)
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
            else if (property_name.Equals("RecurringPurchase"))
            {
                return RepositoryMgr.PurchaseMgr.FindById(_obj.RecurringPurchaseID);
            }
            return null;
        }

        protected override IList<RecurringTimeBillingPurchaseLine>_FindAllCollection()
        {
            List<RecurringTimeBillingPurchaseLine> _grp = new List<RecurringTimeBillingPurchaseLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringTimeBillingPurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
