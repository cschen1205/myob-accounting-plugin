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

    public abstract class RecurringProfessionalPurchaseLineManager : RecurringEntityManager<RecurringProfessionalPurchaseLine>
    {
        public RecurringProfessionalPurchaseLineManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override RecurringProfessionalPurchaseLine _CreateDbEntity()
        {
            return new RecurringProfessionalPurchaseLine(true, this);
        }

        protected override RecurringProfessionalPurchaseLine _CreateEntity()
        {
            return new RecurringProfessionalPurchaseLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(RecurringProfessionalPurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["RecurringProfessionalPurchaseLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringProfessionalPurchaseLineID);
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
            return clause.SelectAll().From("RecurringProfessionalPurchaseLines");
        }

        private DbSelectStatement GetQuery_SelectByRecurringProfessionalPurchaseLineID(int RecurringProfessionalPurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringProfessionalPurchaseLines")
                .Criteria
                    .IsEqual("RecurringProfessionalPurchaseLines", "RecurringProfessionalPurchaseLineID", RecurringProfessionalPurchaseLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecurringProfessionalPurchaseLineID(int RecurringProfessionalPurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("RecurringProfessionalPurchaseLines")
                .Criteria
                    .IsEqual("RecurringProfessionalPurchaseLines", "RecurringProfessionalPurchaseLineID", RecurringProfessionalPurchaseLineID);

            return clause;
        }

        private bool Exists(int? RecurringProfessionalPurchaseLineID)
        {
            if (RecurringProfessionalPurchaseLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringProfessionalPurchaseLineID(RecurringProfessionalPurchaseLineID.Value)) != 0;
        }

        public override  bool Exists(RecurringProfessionalPurchaseLine _obj)
        {
            return Exists(_obj.RecurringProfessionalPurchaseLineID);
        }

        protected override RecurringProfessionalPurchaseLine _FindByIntId(int? RecurringProfessionalPurchaseLineID)
        {
            if (Exists(RecurringProfessionalPurchaseLineID))
            {
                RecurringProfessionalPurchaseLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByRecurringProfessionalPurchaseLineID(RecurringProfessionalPurchaseLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

                public void DeleteCollectionByPurchaseID(int? PurchaseID)
        {
            IList<RecurringProfessionalPurchaseLine> lines = FindCollectionByPurchaseID(PurchaseID);
            foreach (RecurringProfessionalPurchaseLine line in lines)
            {
                Delete(line);
            }
        }

        public IList<RecurringProfessionalPurchaseLine> FindCollectionByPurchaseID(int? PurchaseID)
        {
            if (UseMemoryStore)
            {
                IList<RecurringProfessionalPurchaseLine> store = DataStore;
                var result = from ipl in store
                             where ipl.RecurringPurchaseID == PurchaseID
                             select ipl;
                return new BindingList<RecurringProfessionalPurchaseLine>(result.ToList());
            }
            return _FindCollectionByPurchaseID(PurchaseID);
        }

        protected IList<RecurringProfessionalPurchaseLine> _FindCollectionByPurchaseID(int? RecurringPurchaseID)
        {
            BindingList<RecurringProfessionalPurchaseLine> _grp = new BindingList<RecurringProfessionalPurchaseLine>();
            if (RecurringPurchaseID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringProfessionalPurchaseLines")
                .Criteria
                    .IsEqual("RecurringProfessionalPurchaseLines", "RecurringPurchaseID", RecurringPurchaseID.Value);
            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringProfessionalPurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override void LoadFromReader(RecurringProfessionalPurchaseLine _obj, DbDataReader _reader)
        {
            _obj.RecurringProfessionalPurchaseLineID =GetInt32(_reader, ("RecurringProfessionalPurchaseLineID"));
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

        protected override object GetDbProperty(RecurringProfessionalPurchaseLine _obj, string property_name)
        {
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

        protected override IList<RecurringProfessionalPurchaseLine>_FindAllCollection()
        {
            List<RecurringProfessionalPurchaseLine> _grp = new List<RecurringProfessionalPurchaseLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringProfessionalPurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
