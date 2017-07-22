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

    public abstract class ProfessionalSaleLineManager : EntityManager<ProfessionalSaleLine>
    {
        public ProfessionalSaleLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override ProfessionalSaleLine _CreateDbEntity()
        {
            return new ProfessionalSaleLine(true, this);
        }

        protected override ProfessionalSaleLine _CreateEntity()
        {
            return new ProfessionalSaleLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(ProfessionalSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["ProfessionalSaleLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ProfessionalSaleLineID);
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
            fields["LineDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.LineDate);
            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("ProfessionalSaleLines");
        }

        private DbSelectStatement GetQuery_SelectByProfessionalSaleLineID(int ProfessionalSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ProfessionalSaleLines")
                .Criteria
                    .IsEqual("ProfessionalSaleLines", "ProfessionalSaleLineID", ProfessionalSaleLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByProfessionalSaleLineID(int ProfessionalSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("ProfessionalSaleLines")
                .Criteria
                    .IsEqual("ProfessionalSaleLines", "ProfessionalSaleLineID", ProfessionalSaleLineID);
            return clause;
        }

        private bool Exists(int? ProfessionalSaleLineID)
        {
            if (ProfessionalSaleLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByProfessionalSaleLineID(ProfessionalSaleLineID.Value)) != 0;
        }

        public override bool Exists(ProfessionalSaleLine _obj)
        {
            return Exists(_obj.ProfessionalSaleLineID);
        }

        public void DeleteCollectionBySaleID(int? SaleID)
        {
            IList<ProfessionalSaleLine> lines = FindCollectionBySaleID(SaleID);
            foreach (ProfessionalSaleLine line in lines)
            {
                Delete(line);
            }
        }

        public IList<ProfessionalSaleLine> FindCollectionBySaleID(int? SaleID)
        {
            if (UseMemoryStore)
            {
                IList<ProfessionalSaleLine> store = DataStore;
                var result = from ipl in store
                             where ipl.SaleID == SaleID
                             select ipl;
                return new BindingList<ProfessionalSaleLine>(result.ToList());
            }
            return _FindCollectionBySaleID(SaleID);
        }

        protected IList<ProfessionalSaleLine> _FindCollectionBySaleID(int? SaleID)
        {
            BindingList<ProfessionalSaleLine> _grp = new BindingList<ProfessionalSaleLine>();

            if (SaleID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ProfessionalSaleLines")
                .Criteria
                    .IsEqual("ProfessionalSaleLines", "SaleID", SaleID.Value);

            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ProfessionalSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override ProfessionalSaleLine _FindByIntId(int? ProfessionalSaleLineID)
        {
            if (Exists(ProfessionalSaleLineID))
            {
                ProfessionalSaleLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByProfessionalSaleLineID(ProfessionalSaleLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(ProfessionalSaleLine _obj, DbDataReader _reader)
        {
            _obj.ProfessionalSaleLineID =GetInt32(_reader, ("ProfessionalSaleLineID"));
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
            _obj.LineDate = GetDateTime(_reader, ("LineDate"));

          
        }

        

        protected override object GetDbProperty(ProfessionalSaleLine _obj, string property_name)
        {
            if (property_name.Equals("TaxCode"))
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.TaxCodeID);
            }
            else if (property_name.Equals("Account"))
            {
                return RepositoryMgr.AccountMgr.FindById(_obj.AccountID);
            }
            else if (property_name.Equals("Job"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            else if (property_name.Equals("Sale"))
            {
                return RepositoryMgr.SaleMgr.FindById(_obj.SaleID);
            }
            return null;
        }

        protected override IList<ProfessionalSaleLine>_FindAllCollection()
        {
            List<ProfessionalSaleLine> _grp = new List<ProfessionalSaleLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ProfessionalSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
