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

    public abstract class MiscSaleLineManager : EntityManager<MiscSaleLine>
    {
        public MiscSaleLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override MiscSaleLine _CreateDbEntity()
        {
            return new MiscSaleLine(true, this);
        }

        protected override MiscSaleLine _CreateEntity()
        {
            return new MiscSaleLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(MiscSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["MiscSaleLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.MiscSaleLineID);
            fields["SaleLineID"] = DbMgr.CreateIntFieldEntry(_obj.SaleLineID);
            fields["SaleID"] = DbMgr.CreateIntFieldEntry(_obj.SaleID);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["LineTypeID"] = DbMgr.CreateStringFieldEntry(Convert.ToString(_obj.LineTypeID));
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
            return clause.SelectAll().From("MiscSaleLines");
        }

        private DbSelectStatement GetQuery_SelectByMiscSaleLineID(int MiscSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("MiscSaleLines")
                .Criteria
                    .IsEqual("MiscSaleLines", "MiscSaleLineID", MiscSaleLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByMiscSaleLineID(int MiscSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("MiscSaleLines")
                .Criteria
                    .IsEqual("MiscSaleLines", "MiscSaleLineID", MiscSaleLineID);

            return clause;
        }

        private bool Exists(int? MiscSaleLineID)
        {
            if (MiscSaleLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByMiscSaleLineID(MiscSaleLineID.Value)) != 0;
        }

        public override  bool Exists(MiscSaleLine _obj)
        {
            return Exists(_obj.MiscSaleLineID);
        }

        public void DeleteCollectionBySaleID(int? SaleID)
        {
            IList<MiscSaleLine> lines = FindCollectionBySaleID(SaleID);
            foreach (MiscSaleLine line in lines)
            {
                Delete(line);
            }
        }

        public IList<MiscSaleLine> FindCollectionBySaleID(int? SaleID)
        {
            if (UseMemoryStore)
            {
                IList<MiscSaleLine> store = DataStore;
                var result = from ipl in store
                             where ipl.SaleID == SaleID
                             select ipl;
                return new BindingList<MiscSaleLine>(result.ToList());
            }
            return _FindCollectionBySaleID(SaleID);
        }

        protected IList<MiscSaleLine> _FindCollectionBySaleID(int? SaleID)
        {
            BindingList<MiscSaleLine> _grp = new BindingList<MiscSaleLine>();
            if (SaleID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("MiscSaleLines")
                .Criteria
                    .IsEqual("MiscSaleLines", "SaleID", SaleID.Value);

            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                MiscSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override MiscSaleLine _FindByIntId(int? MiscSaleLineID)
        {
            if (Exists(MiscSaleLineID))
            {
                MiscSaleLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByMiscSaleLineID(MiscSaleLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(MiscSaleLine _obj, DbDataReader _reader)
        {
            _obj.MiscSaleLineID =GetInt32(_reader, ("MiscSaleLineID"));
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

        protected override object GetDbProperty(MiscSaleLine _obj, string property_name)
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

        protected override IList<MiscSaleLine>_FindAllCollection()
        {
            List<MiscSaleLine> _grp = new List<MiscSaleLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                MiscSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
