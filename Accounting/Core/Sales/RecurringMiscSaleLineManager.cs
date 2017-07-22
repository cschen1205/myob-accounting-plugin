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

    public abstract class RecurringMiscSaleLineManager : RecurringEntityManager<RecurringMiscSaleLine>
    {
        public RecurringMiscSaleLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override RecurringMiscSaleLine _CreateDbEntity()
        {
            return new RecurringMiscSaleLine(true, this);
        }

        protected override RecurringMiscSaleLine _CreateEntity()
        {
            return new RecurringMiscSaleLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(RecurringMiscSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["RecurringMiscSaleLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringMiscSaleLineID);
            fields["RecurringSaleLineID"] = DbMgr.CreateIntFieldEntry(_obj.RecurringSaleLineID);
            fields["RecurringSaleID"] = DbMgr.CreateIntFieldEntry(_obj.RecurringSaleID);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["LineTypeID"] = DbMgr.CreateStringFieldEntry(Convert.ToString(_obj.LineTypeID));
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
            return clause.SelectAll().From("RecurringMiscSaleLines");
        }

        private DbSelectStatement GetQuery_SelectByRecurringMiscSaleLineID(int RecurringMiscSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringMiscSaleLines")
                .Criteria
                    .IsEqual("RecurringMiscSaleLines", "RecurringMiscSaleLineID", RecurringMiscSaleLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecurringMiscSaleLineID(int RecurringMiscSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("RecurringMiscSaleLines")
                .Criteria
                    .IsEqual("RecurringMiscSaleLines", "RecurringMiscSaleLineID", RecurringMiscSaleLineID);

            return clause;
        }

        private bool Exists(int? RecurringMiscSaleLineID)
        {
            if (RecurringMiscSaleLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringMiscSaleLineID(RecurringMiscSaleLineID.Value)) != 0;
        }

        public override  bool Exists(RecurringMiscSaleLine _obj)
        {
            return Exists(_obj.RecurringMiscSaleLineID);
        }

        public void DeleteCollectionBySaleID(int? SaleID)
        {
            IList<RecurringMiscSaleLine> lines = FindCollectionBySaleID(SaleID);
            foreach (RecurringMiscSaleLine line in lines)
            {
                Delete(line);
            }
        }

        public IList<RecurringMiscSaleLine> FindCollectionBySaleID(int? SaleID)
        {
            if (UseMemoryStore)
            {
                IList<RecurringMiscSaleLine> store = DataStore;
                var result = from ipl in store
                             where ipl.RecurringSaleID == SaleID
                             select ipl;
                return new BindingList<RecurringMiscSaleLine>(result.ToList());
            }
            return _FindCollectionBySaleID(SaleID);
        }

        protected IList<RecurringMiscSaleLine> _FindCollectionBySaleID(int? RecurringSaleID)
        {
            BindingList<RecurringMiscSaleLine> _grp = new BindingList<RecurringMiscSaleLine>();
            if (RecurringSaleID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringMiscSaleLines")
                .Criteria
                    .IsEqual("RecurringMiscSaleLines", "RecurringSaleID", RecurringSaleID.Value);

            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringMiscSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override RecurringMiscSaleLine _FindByIntId(int? RecurringMiscSaleLineID)
        {
            if (Exists(RecurringMiscSaleLineID))
            {
                RecurringMiscSaleLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByRecurringMiscSaleLineID(RecurringMiscSaleLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(RecurringMiscSaleLine _obj, DbDataReader _reader)
        {
            _obj.RecurringMiscSaleLineID =GetInt32(_reader, ("RecurringMiscSaleLineID"));
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

        protected override object GetDbProperty(RecurringMiscSaleLine _obj, string property_name)
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

        protected override IList<RecurringMiscSaleLine>_FindAllCollection()
        {
            List<RecurringMiscSaleLine> _grp = new List<RecurringMiscSaleLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringMiscSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
