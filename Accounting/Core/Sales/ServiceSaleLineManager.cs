using System;
using System.Collections.Generic;
using System.Text;


namespace Accounting.Core.Sales
{
    using System.Linq;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Common;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public abstract class ServiceSaleLineManager : EntityManager<ServiceSaleLine>
    {
        public ServiceSaleLineManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override ServiceSaleLine _CreateDbEntity()
        {
            return new ServiceSaleLine(true, this);
        }

        protected override ServiceSaleLine _CreateEntity()
        {
            return new ServiceSaleLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(ServiceSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["ServiceSaleLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ServiceSaleLineID);
            fields["SaleLineID"] = DbMgr.CreateIntFieldEntry(_obj.SaleLineID);
            fields["SaleID"] = DbMgr.CreateIntFieldEntry(_obj.SaleID);
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


        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("ServiceSaleLines");
        }

        private DbSelectStatement GetQuery_SelectByServiceSaleLineID(int ServiceSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ServiceSaleLines")
                .Criteria
                    .IsEqual("ServiceSaleLines", "ServiceSaleLineID", ServiceSaleLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByServiceSaleLineID(int ServiceSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("ServiceSaleLines")
                .Criteria
                    .IsEqual("ServiceSaleLines", "ServiceSaleLineID", ServiceSaleLineID);

            return clause;
        }

        private bool Exists(int? ServiceSaleLineID)
        {
            if (ServiceSaleLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByServiceSaleLineID(ServiceSaleLineID.Value)) != 0;
        }

        public override bool Exists(ServiceSaleLine _obj)
        {
            if (_obj.ServiceSaleLineID == null)
            {
                return false;
            }
            return ExecuteScalarInt(GetQuery_SelectCountByServiceSaleLineID(_obj.ServiceSaleLineID.Value)) != 0;
        }

        public void DeleteCollectionBySaleID(int? SaleID)
        {
            IList<ServiceSaleLine> lines = FindCollectionBySaleID(SaleID);
            foreach (ServiceSaleLine line in lines)
            {
                Delete(line);
            }
        }

        public IList<ServiceSaleLine> FindCollectionBySaleID(int? SaleID)
        {
            if (UseMemoryStore)
            {
                IList<ServiceSaleLine> store = DataStore;
                var result = from ipl in store
                             where ipl.SaleID == SaleID
                             select ipl;
                return new BindingList<ServiceSaleLine>(result.ToList());
            }
            return _FindCollectionBySaleID(SaleID);
        }

        protected IList<ServiceSaleLine> _FindCollectionBySaleID(int? SaleID)
        {
            BindingList<ServiceSaleLine> _grp = new BindingList<ServiceSaleLine>();

            if (SaleID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ServiceSaleLines")
                .Criteria
                    .IsEqual("ServiceSaleLines", "SaleID", SaleID.Value);

            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ServiceSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override ServiceSaleLine _FindByIntId(int? ServiceSaleLineID)
        {
            if (Exists(ServiceSaleLineID))
            {
                ServiceSaleLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByServiceSaleLineID(ServiceSaleLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(ServiceSaleLine _obj, DbDataReader _reader)
        {
            _obj.ServiceSaleLineID =GetInt32(_reader, ("ServiceSaleLineID"));
            _obj.SaleLineID =GetInt32(_reader, ("SaleLineID"));
            _obj.SaleID =GetInt32(_reader, ("SaleID"));
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

        protected override object GetDbProperty(ServiceSaleLine _obj, string property_name)
        {
            if(property_name.Equals("TaxCode"))
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.TaxCodeID);
            }
            else if(property_name.Equals("Account"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.AccountID);
            }
            else if(property_name.Equals("Job"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            else if (property_name.Equals("Sale"))
            {
                return RepositoryMgr.SaleMgr.FindById(_obj.SaleID);
            }
            return null;
        }

        protected override IList<ServiceSaleLine>_FindAllCollection()
        {
            List<ServiceSaleLine> _grp = new List<ServiceSaleLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ServiceSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
