using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Purchases
{
    using System.Linq;
    using System.ComponentModel;
    public abstract class RecurringServicePurchaseLineManager : RecurringEntityManager<RecurringServicePurchaseLine>
    {
        public RecurringServicePurchaseLineManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override RecurringServicePurchaseLine _CreateDbEntity()
        {
            return new RecurringServicePurchaseLine(true, this);
        }

        protected override RecurringServicePurchaseLine _CreateEntity()
        {
            return new RecurringServicePurchaseLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(RecurringServicePurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetRecurringEntityFields(_obj);
            fields["RecurringServicePurchaseLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringServicePurchaseLineID);
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
            clause
                .SelectAll()
                .From("RecurringServicePurchaseLines");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByRecurringServicePurchaseLineID(int RecurringServicePurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringServicePurchaseLines")
                .Criteria
                    .IsEqual("RecurringServicePurchaseLines", "RecurringServicePurchaseLineID", RecurringServicePurchaseLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecurringServicePurchaseLineID(int RecurringServicePurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("RecurringServicePurchaseLines")
                .Criteria
                    .IsEqual("RecurringServicePurchaseLines", "RecurringServicePurchaseLineID", RecurringServicePurchaseLineID);

            return clause;
        }

        private bool Exists(int? RecurringServicePurchaseLineID)
        {
            if (RecurringServicePurchaseLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringServicePurchaseLineID(RecurringServicePurchaseLineID.Value)) != 0;
        }

        public override  bool Exists(RecurringServicePurchaseLine _obj)
        {
            if (_obj.RecurringServicePurchaseLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringServicePurchaseLineID(_obj.RecurringServicePurchaseLineID.Value)) != 0;
        }

        protected override RecurringServicePurchaseLine _FindByIntId(int? RecurringServicePurchaseLineID)
        {
            if (Exists(RecurringServicePurchaseLineID))
            {
                RecurringServicePurchaseLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByRecurringServicePurchaseLineID(RecurringServicePurchaseLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        public void DeleteCollectionByPurchaseID(int? PurchaseID)
        {
            IList<RecurringServicePurchaseLine> lines = FindCollectionByPurchaseID(PurchaseID);
            foreach (RecurringServicePurchaseLine line in lines)
            {
                Delete(line);
            }
        }

        public IList<RecurringServicePurchaseLine> FindCollectionByPurchaseID(int? PurchaseID)
        {
            if (UseMemoryStore)
            {
                IList<RecurringServicePurchaseLine> store = DataStore;
                var result = from ipl in store
                             where ipl.RecurringPurchaseID == PurchaseID
                             select ipl;
                return new BindingList<RecurringServicePurchaseLine>(result.ToList());
            }
            return _FindCollectionByPurchaseID(PurchaseID);
        }

        protected IList<RecurringServicePurchaseLine> _FindCollectionByPurchaseID(int? RecurringPurchaseID)
        {
            BindingList<RecurringServicePurchaseLine> _grp = new BindingList<RecurringServicePurchaseLine>();
            if (RecurringPurchaseID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringServicePurchaseLines")
                .Criteria
                    .IsEqual("RecurringServicePurchaseLines", "RecurringPurchaseID", RecurringPurchaseID.Value);
            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringServicePurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override void LoadFromReader(RecurringServicePurchaseLine _obj, DbDataReader _reader)
        {
            LoadRecurringEntityFromReader(_obj, _reader);

            _obj.RecurringServicePurchaseLineID =GetInt32(_reader, ("RecurringServicePurchaseLineID"));
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

        protected override object GetDbProperty(RecurringServicePurchaseLine _obj, string property_name)
        {
            object returned_obj = GetRecurringEntityDbProperty(_obj, property_name);
            if (returned_obj != null) return returned_obj;

            if (property_name.Equals("Account"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.AccountID);
            }
            else if (property_name.Equals("Job"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            else if (property_name.Equals("TaxCode"))
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.TaxCodeID);
            }
            else if (property_name.Equals("RecurringPurchase"))
            {
                return RepositoryMgr.PurchaseMgr.FindById(_obj.RecurringPurchaseID);
            }
            return null;
        }

        protected override IList<RecurringServicePurchaseLine>_FindAllCollection()
        {
            List<RecurringServicePurchaseLine> _grp = new List<RecurringServicePurchaseLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringServicePurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
