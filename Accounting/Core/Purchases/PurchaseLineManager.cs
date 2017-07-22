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

    public abstract class PurchaseLineManager : EntityManager<PurchaseLine>
    {
        public PurchaseLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override PurchaseLine _CreateDbEntity()
        {
            return new PurchaseLine(true, this);
        }

        protected override PurchaseLine _CreateEntity()
        {
            return new PurchaseLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(PurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["PurchaseLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.PurchaseLineID);
            fields["PurchaseID"] = DbMgr.CreateIntFieldEntry(_obj.PurchaseID);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["LineTypeID"] = DbMgr.CreateStringFieldEntry(_obj.LineTypeID);
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

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("PurchaseLines");
        }

        private DbSelectStatement GetQuery_SelectByPurchaseLineID(int PurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("PurchaseLines")
                .Criteria
                    .IsEqual("PurchaseLines", "PurchaseLineID", PurchaseLineID);
            return clause;
        }

        public void DeleteCollectionByPurchaseID(int? PurchaseID)
        {
            IList<PurchaseLine> lines = FindCollectionByPurchaseID(PurchaseID);
            foreach (PurchaseLine line in lines)
            {
                Delete(line);
            }
        }

        public IList<PurchaseLine> FindCollectionByPurchaseID(int? PurchaseID)
        {
            if (UseMemoryStore)
            {
                IList<PurchaseLine> store = DataStore;
                var result = from ipl in store
                             where ipl.PurchaseID == PurchaseID
                             select ipl;
                return new BindingList<PurchaseLine>(result.ToList());
            }
            return _FindCollectionByPurchaseID(PurchaseID);
        }

        private IList<PurchaseLine> _FindCollectionByPurchaseID(int? PurchaseID)
        {
            BindingList<PurchaseLine> _grp = new BindingList<PurchaseLine>();
            if (PurchaseID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("PurchaseLines")
                .Criteria
                    .IsEqual("PurchaseLines", "PurchaseID", PurchaseID.Value);

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                PurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        private DbSelectStatement GetQuery_SelectCountByPurchaseLineID(int PurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("PurchaseLines")
                .Criteria
                    .IsEqual("PurchaseLines", "PurchaseLineID", PurchaseLineID);
            return clause;
        }

        private bool Exists(int? PurchaseLineID)
        {
            if (PurchaseLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByPurchaseLineID(PurchaseLineID.Value)) != 0;
        }

        public override bool Exists(PurchaseLine _obj)
        {
            return Exists(_obj.PurchaseLineID);
        }

        protected override PurchaseLine _FindByIntId(int? PurchaseLineID)
        {
            if (Exists(PurchaseLineID))
            {
                PurchaseLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByPurchaseLineID(PurchaseLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(PurchaseLine _obj, DbDataReader _reader)
        {
            _obj.PurchaseLineID =GetInt32(_reader, ("PurchaseLineID"));
            _obj.PurchaseID =GetInt32(_reader, ("PurchaseID"));
            _obj.LineNumber =GetInt32(_reader, ("LineNumber"));
            _obj.LineTypeID =GetString(_reader, ("LineTypeID"));
            _obj.Description =GetString(_reader, ("Description"));
            _obj.TaxExclusiveAmount = GetDouble(_reader, ("TaxExclusiveAmount"));
            _obj.TaxInclusiveAmount = GetDouble(_reader, ("TaxInclusiveAmount"));
            _obj.IsMultipleJob =GetString(_reader, ("IsMultipleJob"));
            _obj.JobID =GetInt32(_reader, ("JobID"));
            _obj.TaxBasisAmount = GetDouble(_reader, ("TaxBasisAmount"));
            _obj.TaxBasisAmountIsInclusive =GetString(_reader, ("TaxBasisAmountIsInclusive"));
            _obj.TaxCodeID =GetInt32(_reader, ("TaxCodeID"));
        }

        protected override object GetDbProperty(PurchaseLine _obj, string property_name)
        {
            if (property_name.Equals("TaxCode"))
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.TaxCodeID);
            }
            else if (property_name.Equals("Job"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            else if(property_name.Equals("Purchase"))
            {
                return RepositoryMgr.PurchaseMgr.FindById(_obj.PurchaseID);
            }
            return null;
        }

        protected override IList<PurchaseLine>_FindAllCollection()
        {
            List<PurchaseLine> _grp = new List<PurchaseLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                PurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
