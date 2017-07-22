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

    public abstract class ServicePurchaseLineManager : EntityManager<ServicePurchaseLine>
    {
        public ServicePurchaseLineManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override ServicePurchaseLine _CreateDbEntity()
        {
            return new ServicePurchaseLine(true, this);
        }

        protected override ServicePurchaseLine _CreateEntity()
        {
            return new ServicePurchaseLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(ServicePurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["ServicePurchaseLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ServicePurchaseLineID);
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
            IList<ServicePurchaseLine> lines = FindCollectionByPurchaseID(PurchaseID);
            foreach (ServicePurchaseLine line in lines)
            {
                Delete(line);
            }
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ServicePurchaseLines");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByServicePurchaseLineID(int ServicePurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ServicePurchaseLines")
                .Criteria
                    .IsEqual("ServicePurchaseLines", "ServicePurchaseLineID", ServicePurchaseLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByServicePurchaseLineID(int ServicePurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("ServicePurchaseLines")
                .Criteria
                    .IsEqual("ServicePurchaseLines", "ServicePurchaseLineID", ServicePurchaseLineID);

            return clause;
        }

        private bool Exists(int? ServicePurchaseLineID)
        {
            if (ServicePurchaseLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByServicePurchaseLineID(ServicePurchaseLineID.Value)) != 0;
        }

        public override  bool Exists(ServicePurchaseLine _obj)
        {
            if (_obj.ServicePurchaseLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByServicePurchaseLineID(_obj.ServicePurchaseLineID.Value)) != 0;
        }

        protected override ServicePurchaseLine _FindByIntId(int? ServicePurchaseLineID)
        {
            if (Exists(ServicePurchaseLineID))
            {
                ServicePurchaseLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByServicePurchaseLineID(ServicePurchaseLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        public IList<ServicePurchaseLine> FindCollectionByPurchaseID(int? PurchaseID)
        {
            if (UseMemoryStore)
            {
                IList<ServicePurchaseLine> store = DataStore;
                var result = from ipl in store
                             where ipl.PurchaseID == PurchaseID
                             select ipl;
                return new BindingList<ServicePurchaseLine>(result.ToList());
            }
            return _FindCollectionByPurchaseID(PurchaseID);
        }

        public IList<ServicePurchaseLine> _FindCollectionByPurchaseID(int? PurchaseID)
        {
            BindingList<ServicePurchaseLine> _grp = new BindingList<ServicePurchaseLine>();
            if (PurchaseID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ServicePurchaseLines")
                .Criteria
                    .IsEqual("ServicePurchaseLines", "PurchaseID", PurchaseID.Value);
            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ServicePurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override void LoadFromReader(ServicePurchaseLine _obj, DbDataReader _reader)
        {
            _obj.ServicePurchaseLineID =GetInt32(_reader, ("ServicePurchaseLineID"));
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

        protected override object GetDbProperty(ServicePurchaseLine _obj, string property_name)
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

        protected override IList<ServicePurchaseLine>_FindAllCollection()
        {
            List<ServicePurchaseLine> _grp = new List<ServicePurchaseLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ServicePurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
