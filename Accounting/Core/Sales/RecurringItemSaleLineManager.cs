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
    public abstract class RecurringItemSaleLineManager : RecurringEntityManager<RecurringItemSaleLine>
    {
        public RecurringItemSaleLineManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override RecurringItemSaleLine _CreateDbEntity()
        {
            return new RecurringItemSaleLine(true, this);
        }

        protected override RecurringItemSaleLine _CreateEntity()
        {
            return new RecurringItemSaleLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(RecurringItemSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["RecurringItemSaleLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringItemSaleLineID);
            fields["RecurringSaleLineID"] = DbMgr.CreateIntFieldEntry(_obj.RecurringSaleLineID);
            fields["RecurringSaleID"] = DbMgr.CreateIntFieldEntry(_obj.RecurringSaleID);
            fields["LineNumber"] = DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["LineTypeID"] = DbMgr.CreateStringFieldEntry(_obj.LineTypeID);
            fields["ItemID"] = DbMgr.CreateIntFieldEntry(_obj.ItemID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            fields["Quantity"] = DbMgr.CreateDoubleFieldEntry(_obj.Quantity);
            fields["TaxExclusiveUnitPrice"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveUnitPrice);
            fields["TaxInclusiveUnitPrice"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveUnitPrice);
            fields["TaxExclusiveTotal"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveTotal);
            fields["TaxInclusiveTotal"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveTotal);
            fields["Discount"] = DbMgr.CreateDoubleFieldEntry(_obj.Discount);
            fields["JobID"] = DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["TaxBasisAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxBasisAmount);
            fields["TaxBasisAmountIsInclusive"] = DbMgr.CreateStringFieldEntry(_obj.TaxBasisAmountIsInclusive);
            fields["TaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.TaxCodeID);
            fields["CostOfGoodsSoldAmount"] = DbMgr.CreateDoubleFieldEntry(_obj.CostOfGoodsSoldAmount);
            fields["LocationID"] = DbMgr.CreateIntFieldEntry(_obj.LocationID);
            fields["SalesTaxCalBasisID"] = DbMgr.CreateStringFieldEntry(_obj.SalesTaxCalBasisID);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("RecurringItemSaleLines");
        }

        private DbSelectStatement GetQuery_SelectByRecurringItemSaleLineID(int RecurringItemSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringItemSaleLines")
                .Criteria
                    .IsEqual("RecurringItemSaleLines", "RecurringItemSaleLineID", RecurringItemSaleLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByRecurringItemSaleLineID(int RecurringItemSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("RecurringItemSaleLines")
                .Criteria
                    .IsEqual("RecurringItemSaleLines", "RecurringItemSaleLineID", RecurringItemSaleLineID);

            return clause;
        }

        private bool Exists(int? RecurringItemSaleLineID)
        {
            if (RecurringItemSaleLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByRecurringItemSaleLineID(RecurringItemSaleLineID.Value)) != 0;
        }

        public override bool Exists(RecurringItemSaleLine _obj)
        {
            return Exists(_obj.RecurringItemSaleLineID);
        }

        public void DeleteCollectionBySaleID(int? SaleID)
        {
            IList<RecurringItemSaleLine> lines = FindCollectionBySaleID(SaleID);
            foreach (RecurringItemSaleLine line in lines)
            {
                Delete(line);
            }
        }

        public IList<RecurringItemSaleLine> FindCollectionBySaleID(int? SaleID)
        {
            if (UseMemoryStore)
            {
                IList<RecurringItemSaleLine> store = DataStore;
                var result = from ipl in store
                             where ipl.RecurringSaleID == SaleID
                             select ipl;
                return new BindingList<RecurringItemSaleLine>(result.ToList());
            }
            return _FindCollectionBySaleID(SaleID);
        }

        protected IList<RecurringItemSaleLine> _FindCollectionBySaleID(int? RecurringSaleID)
        {
            BindingList<RecurringItemSaleLine> _grp = new BindingList<RecurringItemSaleLine>();
            if (RecurringSaleID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringItemSaleLines")
                .Criteria
                    .IsEqual("RecurringItemSaleLines", "RecurringSaleID", RecurringSaleID.Value);

            

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringItemSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override RecurringItemSaleLine _FindByIntId(int? RecurringItemSaleLineID)
        {
            if (Exists(RecurringItemSaleLineID))
            {
                RecurringItemSaleLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByRecurringItemSaleLineID(RecurringItemSaleLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(RecurringItemSaleLine _obj, DbDataReader _reader)
        {
            _obj.RecurringItemSaleLineID =GetInt32(_reader, ("RecurringItemSaleLineID"));
            _obj.RecurringSaleLineID =GetInt32(_reader, ("RecurringSaleLineID"));
            _obj.RecurringSaleID =GetInt32(_reader, ("RecurringSaleID"));
            _obj.LineNumber =GetInt32(_reader, ("LineNumber"));
            _obj.LineTypeID =GetString(_reader, ("LineTypeID"));
            _obj.ItemID =GetInt32(_reader, ("ItemID"));
            _obj.Description =GetString(_reader, ("Description"));
            _obj.Quantity = GetDouble(_reader, ("Quantity"));
            _obj.TaxExclusiveUnitPrice = GetDouble(_reader, ("TaxExclusiveUnitPrice"));
            _obj.TaxInclusiveUnitPrice = GetDouble(_reader, ("TaxInclusiveUnitPrice"));
            _obj.TaxExclusiveTotal = GetDouble(_reader, ("TaxExclusiveTotal"));
            _obj.TaxInclusiveTotal = GetDouble(_reader, ("TaxInclusiveTotal"));
            _obj.Discount = GetDouble(_reader, ("Discount"));
            _obj.JobID =GetInt32(_reader, ("JobID"));
            _obj.TaxBasisAmount = GetDouble(_reader, ("TaxBasisAmount"));
            _obj.TaxBasisAmountIsInclusive =GetString(_reader, ("TaxBasisAmountIsInclusive"));
            _obj.TaxCodeID =GetInt32(_reader, ("TaxCodeID"));
            _obj.CostOfGoodsSoldAmount = GetDouble(_reader, ("CostOfGoodsSoldAmount"));
            _obj.LocationID =GetInt32(_reader, ("LocationID"));
            _obj.SalesTaxCalBasisID =GetString(_reader, ("SalesTaxCalBasisID"));
            _obj.TaxInclusiveAmount = _obj.TaxInclusiveTotal;
            _obj.TaxExclusiveAmount = _obj.TaxExclusiveTotal;
        }

        protected override object GetDbProperty(RecurringItemSaleLine _obj, string property_name)
        {
            if (property_name.Equals("Job"))
            {
                return RepositoryMgr.JobMgr.FindById(_obj.JobID);
            }
            else if(property_name.Equals("Location"))
            {
                return RepositoryMgr.LocationMgr.FindByLocationID(_obj.LocationID);
            }
            else if (property_name.Equals("TaxCode"))
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.TaxCodeID);
            }
            else if (property_name.Equals("Item"))
            {
                return RepositoryMgr.ItemMgr.FindById(_obj.ItemID);
            }
            else if (property_name.Equals("SalesTaxCalcBasis"))
            {
                return RepositoryMgr.PriceLevelMgr.FindById(_obj.SalesTaxCalBasisID);
            }
            else if (property_name.Equals("RecurringSale"))
            {
                return RepositoryMgr.RecurringSaleMgr.FindById(_obj.RecurringSaleID);
            }

            return null;
        }

        protected override IList<RecurringItemSaleLine>_FindAllCollection()
        {
            List<RecurringItemSaleLine> _grp = new List<RecurringItemSaleLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringItemSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
