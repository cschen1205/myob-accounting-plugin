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

    public abstract class ItemSaleLineManager : EntityManager<ItemSaleLine>
    {
        public ItemSaleLineManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override ItemSaleLine _CreateDbEntity()
        {
            return new ItemSaleLine(true, this);
        }

        protected override ItemSaleLine _CreateEntity()
        {
            return new ItemSaleLine(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(ItemSaleLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["ItemSaleLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ItemSaleLineID);
            fields["SaleLineID"] = DbMgr.CreateIntFieldEntry(_obj.SaleLineID);
            fields["SaleID"] = DbMgr.CreateIntFieldEntry(_obj.SaleID);
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
            fields["IsMultipleJob"] = DbMgr.CreateStringFieldEntry(_obj.IsMultipleJob);
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
            return clause.SelectAll().From("ItemSaleLines");
        }

        private DbSelectStatement GetQuery_SelectByItemSaleLineID(int ItemSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ItemSaleLines")
                .Criteria
                    .IsEqual("ItemSaleLines", "ItemSaleLineID", ItemSaleLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByItemSaleLineID(int ItemSaleLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("ItemSaleLines")
                .Criteria
                    .IsEqual("ItemSaleLines", "ItemSaleLineID", ItemSaleLineID);

            return clause;
        }

        private bool Exists(int? ItemSaleLineID)
        {
            if (ItemSaleLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByItemSaleLineID(ItemSaleLineID.Value)) != 0;
        }

        public override bool Exists(ItemSaleLine _obj)
        {
            return Exists(_obj.ItemSaleLineID);
        }

        public void DeleteCollectionBySaleID(int? SaleID)
        {
            IList<ItemSaleLine> lines = FindCollectionBySaleID(SaleID);
            foreach (ItemSaleLine line in lines)
            {
                Delete(line);
            }
        }

        public IList<ItemSaleLine> FindCollectionBySaleID(int? SaleID)
        {
            if (UseMemoryStore)
            {
                IList<ItemSaleLine> store = DataStore;
                var result = from ipl in store
                             where ipl.SaleID == SaleID
                             select ipl;
                return new BindingList<ItemSaleLine>(result.ToList());
            }
            return _FindCollectionBySaleID(SaleID);
        }

        protected IList<ItemSaleLine> _FindCollectionBySaleID(int? SaleID)
        {
            BindingList<ItemSaleLine> _grp = new BindingList<ItemSaleLine>();
            if (SaleID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ItemSaleLines")
                .Criteria
                    .IsEqual("ItemSaleLines", "SaleID", SaleID.Value);

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ItemSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override ItemSaleLine _FindByIntId(int? ItemSaleLineID)
        {
            if (Exists(ItemSaleLineID))
            {
                ItemSaleLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByItemSaleLineID(ItemSaleLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(ItemSaleLine _obj, DbDataReader _reader)
        {
            _obj.ItemSaleLineID =GetInt32(_reader, ("ItemSaleLineID"));
            _obj.SaleLineID =GetInt32(_reader, ("SaleLineID"));
            _obj.SaleID =GetInt32(_reader, ("SaleID"));
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
            _obj.IsMultipleJob =GetString(_reader, ("IsMultipleJob"));
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

        protected override object GetDbProperty(ItemSaleLine _obj, string property_name)
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
            else if (property_name.Equals("Sale"))
            {
                return RepositoryMgr.SaleMgr.FindById(_obj.SaleID);
            }

            return null;
        }

        protected override IList<ItemSaleLine>_FindAllCollection()
        {
            List<ItemSaleLine> _grp = new List<ItemSaleLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ItemSaleLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
