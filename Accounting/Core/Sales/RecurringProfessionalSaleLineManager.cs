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

    public abstract class RecurringProfessionalSaleLineManager : EntityManager<RecurringProfessionalSaleLine>
    {
        public RecurringProfessionalSaleLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override RecurringProfessionalSaleLine _CreateDbEntity()
        {
            return new RecurringProfessionalSaleLine(true, this);
        }

        protected override RecurringProfessionalSaleLine _CreateEntity()
        {
            return new RecurringProfessionalSaleLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(RecurringProfessionalSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["RecurringProfessionalSaleLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringProfessionalSaleLineID);
            fields["RecurringSaleLineID"] = DbMgr.CreateIntFieldEntry(_obj.RecurringSaleLineID);
            fields["RecurringSaleID"] = DbMgr.CreateIntFieldEntry(_obj.RecurringSaleID);
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
            fields["LineDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.LineDate);
            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("RecurringProfessionalSaleLines");
        }

        private DbSelectStatement GetQuery_SelectByRecurringProfessionalSaleLineID(int RecurringProfessionalSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringProfessionalSaleLines")
                .Criteria
                    .IsEqual("RecurringProfessionalSaleLines", "RecurringProfessionalSaleLineID", RecurringProfessionalSaleLineID);
            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecurringProfessionalSaleLineID(int RecurringProfessionalSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("RecurringProfessionalSaleLines")
                .Criteria
                    .IsEqual("RecurringProfessionalSaleLines", "RecurringProfessionalSaleLineID", RecurringProfessionalSaleLineID);
            return clause;
        }

        private bool Exists(int? RecurringProfessionalSaleLineID)
        {
            if (RecurringProfessionalSaleLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringProfessionalSaleLineID(RecurringProfessionalSaleLineID.Value)) != 0;
        }

        public override bool Exists(RecurringProfessionalSaleLine _obj)
        {
            return Exists(_obj.RecurringProfessionalSaleLineID);
        }

        public void DeleteCollectionBySaleID(int? SaleID)
        {
            IList<RecurringProfessionalSaleLine> lines = FindCollectionBySaleID(SaleID);
            foreach (RecurringProfessionalSaleLine line in lines)
            {
                Delete(line);
            }
        }

        public IList<RecurringProfessionalSaleLine> FindCollectionBySaleID(int? SaleID)
        {
            if (UseMemoryStore)
            {
                IList<RecurringProfessionalSaleLine> store = DataStore;
                var result = from ipl in store
                             where ipl.RecurringSaleID == SaleID
                             select ipl;
                return new BindingList<RecurringProfessionalSaleLine>(result.ToList());
            }
            return _FindCollectionBySaleID(SaleID);
        }

        protected IList<RecurringProfessionalSaleLine> _FindCollectionBySaleID(int? RecurringSaleID)
        {
            BindingList<RecurringProfessionalSaleLine> _grp = new BindingList<RecurringProfessionalSaleLine>();

            if (RecurringSaleID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringProfessionalSaleLines")
                .Criteria
                    .IsEqual("RecurringProfessionalSaleLines", "RecurringSaleID", RecurringSaleID.Value);

            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringProfessionalSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override RecurringProfessionalSaleLine _FindByIntId(int? RecurringProfessionalSaleLineID)
        {
            if (Exists(RecurringProfessionalSaleLineID))
            {
                RecurringProfessionalSaleLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByRecurringProfessionalSaleLineID(RecurringProfessionalSaleLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(RecurringProfessionalSaleLine _obj, DbDataReader _reader)
        {
            _obj.RecurringProfessionalSaleLineID =GetInt32(_reader, ("RecurringProfessionalSaleLineID"));
            _obj.RecurringSaleLineID =GetInt32(_reader, ("RecurringSaleLineID"));
            _obj.RecurringSaleID =GetInt32(_reader, ("RecurringSaleID"));
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
            _obj.LineDate = GetDateTime(_reader, ("LineDate"));

          
        }

        

        protected override object GetDbProperty(RecurringProfessionalSaleLine _obj, string property_name)
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
            else if (property_name.Equals("RecurringSale"))
            {
                return RepositoryMgr.RecurringSaleMgr.FindById(_obj.RecurringSaleID);
            }
            return null;
        }

        protected override IList<RecurringProfessionalSaleLine>_FindAllCollection()
        {
            List<RecurringProfessionalSaleLine> _grp = new List<RecurringProfessionalSaleLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringProfessionalSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
