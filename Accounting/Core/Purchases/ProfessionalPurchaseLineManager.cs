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

    public abstract class ProfessionalPurchaseLineManager : EntityManager<ProfessionalPurchaseLine>
    {
        public ProfessionalPurchaseLineManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override ProfessionalPurchaseLine _CreateDbEntity()
        {
            return new ProfessionalPurchaseLine(true, this);
        }

        protected override ProfessionalPurchaseLine _CreateEntity()
        {
            return new ProfessionalPurchaseLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(ProfessionalPurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["ProfessionalPurchaseLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ProfessionalPurchaseLineID);
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
            IList<ProfessionalPurchaseLine> lines = FindCollectionByPurchaseID(PurchaseID);
            foreach (ProfessionalPurchaseLine line in lines)
            {
                Delete(line);
            }
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("ProfessionalPurchaseLines");
        }

        private DbSelectStatement GetQuery_SelectByProfessionalPurchaseLineID(int ProfessionalPurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ProfessionalPurchaseLines")
                .Criteria
                    .IsEqual("ProfessionalPurchaseLines", "ProfessionalPurchaseLineID", ProfessionalPurchaseLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByProfessionalPurchaseLineID(int ProfessionalPurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("ProfessionalPurchaseLines")
                .Criteria
                    .IsEqual("ProfessionalPurchaseLines", "ProfessionalPurchaseLineID", ProfessionalPurchaseLineID);

            return clause;
        }

        private bool Exists(int? ProfessionalPurchaseLineID)
        {
            if (ProfessionalPurchaseLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByProfessionalPurchaseLineID(ProfessionalPurchaseLineID.Value)) != 0;
        }

        public override  bool Exists(ProfessionalPurchaseLine _obj)
        {
            return Exists(_obj.ProfessionalPurchaseLineID);
        }

        protected override ProfessionalPurchaseLine _FindByIntId(int? ProfessionalPurchaseLineID)
        {
            if (Exists(ProfessionalPurchaseLineID))
            {
                ProfessionalPurchaseLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByProfessionalPurchaseLineID(ProfessionalPurchaseLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        public IList<ProfessionalPurchaseLine> FindCollectionByPurchaseID(int? PurchaseID)
        {
              if (UseMemoryStore)
            {
                IList<ProfessionalPurchaseLine> store = DataStore;
                var result = from ipl in store
                             where ipl.PurchaseID == PurchaseID
                             select ipl;
                return new BindingList<ProfessionalPurchaseLine>(result.ToList());
            }
            return _FindCollectionByPurchaseID(PurchaseID);
        }

        protected IList<ProfessionalPurchaseLine> _FindCollectionByPurchaseID(int? PurchaseID)
        {
            BindingList<ProfessionalPurchaseLine> _grp = new BindingList<ProfessionalPurchaseLine>();
            if (PurchaseID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ProfessionalPurchaseLines")
                .Criteria
                    .IsEqual("ProfessionalPurchaseLines", "PurchaseID", PurchaseID.Value);
            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ProfessionalPurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override void LoadFromReader(ProfessionalPurchaseLine _obj, DbDataReader _reader)
        {
            _obj.ProfessionalPurchaseLineID =GetInt32(_reader, ("ProfessionalPurchaseLineID"));
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

        protected override object GetDbProperty(ProfessionalPurchaseLine _obj, string property_name)
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
            else if (property_name.Equals("Purchase"))
            {
                return RepositoryMgr.PurchaseMgr.FindById(_obj.PurchaseID);
            }
            return null;
        }

        protected override IList<ProfessionalPurchaseLine>_FindAllCollection()
        {
            List<ProfessionalPurchaseLine> _grp = new List<ProfessionalPurchaseLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ProfessionalPurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
