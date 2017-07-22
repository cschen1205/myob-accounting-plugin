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

    public abstract class RecurringServiceSaleLineManager : EntityManager<RecurringServiceSaleLine>
    {
        public RecurringServiceSaleLineManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override RecurringServiceSaleLine _CreateDbEntity()
        {
            return new RecurringServiceSaleLine(true, this);
        }

        protected override RecurringServiceSaleLine _CreateEntity()
        {
            return new RecurringServiceSaleLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(RecurringServiceSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["RecurringServiceSaleLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringServiceSaleLineID);
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

            return fields;
        }


        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("RecurringServiceSaleLines");
        }

        private DbSelectStatement GetQuery_SelectByRecurringServiceSaleLineID(int RecurringServiceSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringServiceSaleLines")
                .Criteria
                    .IsEqual("RecurringServiceSaleLines", "RecurringServiceSaleLineID", RecurringServiceSaleLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecurringServiceSaleLineID(int RecurringServiceSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("RecurringServiceSaleLines")
                .Criteria
                    .IsEqual("RecurringServiceSaleLines", "RecurringServiceSaleLineID", RecurringServiceSaleLineID);

            return clause;
        }

        private bool Exists(int? RecurringServiceSaleLineID)
        {
            if (RecurringServiceSaleLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringServiceSaleLineID(RecurringServiceSaleLineID.Value)) != 0;
        }

        public override bool Exists(RecurringServiceSaleLine _obj)
        {
            if (_obj.RecurringServiceSaleLineID == null)
            {
                return false;
            }
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringServiceSaleLineID(_obj.RecurringServiceSaleLineID.Value)) != 0;
        }

        public void DeleteCollectionBySaleID(int? SaleID)
        {
            IList<RecurringServiceSaleLine> lines = FindCollectionBySaleID(SaleID);
            foreach (RecurringServiceSaleLine line in lines)
            {
                Delete(line);
            }
        }

        public IList<RecurringServiceSaleLine> FindCollectionBySaleID(int? SaleID)
        {
            if (UseMemoryStore)
            {
                IList<RecurringServiceSaleLine> store = DataStore;
                var result = from ipl in store
                             where ipl.RecurringSaleID == SaleID
                             select ipl;
                return new BindingList<RecurringServiceSaleLine>(result.ToList());
            }
            return _FindCollectionBySaleID(SaleID);
        }

        protected List<RecurringServiceSaleLine> _FindCollectionBySaleID(int? RecurringSaleID)
        {
            List<RecurringServiceSaleLine> _grp = new List<RecurringServiceSaleLine>();

            if (RecurringSaleID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringServiceSaleLines")
                .Criteria
                    .IsEqual("RecurringServiceSaleLines", "RecurringSaleID", RecurringSaleID.Value);

            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringServiceSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override RecurringServiceSaleLine _FindByIntId(int? RecurringServiceSaleLineID)
        {
            if (Exists(RecurringServiceSaleLineID))
            {
                RecurringServiceSaleLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByRecurringServiceSaleLineID(RecurringServiceSaleLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(RecurringServiceSaleLine _obj, DbDataReader _reader)
        {
            _obj.RecurringServiceSaleLineID =GetInt32(_reader, ("RecurringServiceSaleLineID"));
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
        }

        protected override object GetDbProperty(RecurringServiceSaleLine _obj, string property_name)
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
            else if (property_name.Equals("RecurringSale"))
            {
                return RepositoryMgr.RecurringSaleMgr.FindById(_obj.RecurringSaleID);
            }
            return null;
        }

        protected override IList<RecurringServiceSaleLine>_FindAllCollection()
        {
            List<RecurringServiceSaleLine> _grp = new List<RecurringServiceSaleLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringServiceSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
