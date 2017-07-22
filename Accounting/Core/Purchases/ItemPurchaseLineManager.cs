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

    public abstract class ItemPurchaseLineManager : EntityManager<ItemPurchaseLine>
    {
        public ItemPurchaseLineManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override ItemPurchaseLine _CreateDbEntity()
        {
            return new ItemPurchaseLine(true, this);
        }

        protected override ItemPurchaseLine _CreateEntity()
        {
            return new ItemPurchaseLine(false, this);
        }
        #endregion
        
        public override Dictionary<string, DbFieldEntry> GetFields(ItemPurchaseLine _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["ItemPurchaseLineID"] = DbMgr.CreateAutoIntFieldEntry(_obj.ItemPurchaseLineID);
            fields["PurchaseLineID"]= DbMgr.CreateIntFieldEntry(_obj.PurchaseLineID);
            fields["PurchaseID"]= DbMgr.CreateIntFieldEntry(_obj.PurchaseID);
            fields["LineNumber"]= DbMgr.CreateIntFieldEntry(_obj.LineNumber);
            fields["LineTypeID"]= DbMgr.CreateStringFieldEntry(_obj.LineTypeID);
            fields["ItemID"]= DbMgr.CreateIntFieldEntry(_obj.ItemID);
            fields["Description"]= DbMgr.CreateStringFieldEntry(_obj.Description);
            fields["Quantity"]= DbMgr.CreateDoubleFieldEntry(_obj.Quantity);
            fields["TaxExclusiveUnitPrice"]= DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveUnitPrice);
            fields["TaxInclusiveUnitPrice"]= DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveUnitPrice);
            fields["TaxExclusiveTotal"]= DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveTotal);
            fields["TaxInclusiveTotal"]= DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveTotal);
            fields["Discount"]= DbMgr.CreateDoubleFieldEntry(_obj.Discount);
            fields["IsMultipleJob"]= DbMgr.CreateStringFieldEntry(_obj.IsMultipleJob);
            fields["JobID"]= DbMgr.CreateIntFieldEntry(_obj.JobID);
            fields["TaxBasisAmount"]= DbMgr.CreateDoubleFieldEntry(_obj.TaxBasisAmount);
            fields["TaxBasisAmountIsInclusive"]= DbMgr.CreateStringFieldEntry(_obj.TaxBasisAmountIsInclusive);
            fields["TaxCodeID"]= DbMgr.CreateIntFieldEntry(_obj.TaxCodeID);
            fields["Received"]= DbMgr.CreateDoubleFieldEntry(_obj.Received);
            fields["LocationID"]=  DbMgr.CreateIntFieldEntry(_obj.LocationID);

            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("ItemPurchaseLines");
        }

        private DbSelectStatement GetQuery_SelectByItemPurchaseLineID(int ItemPurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ItemPurchaseLines")
                .Criteria
                    .IsEqual("ItemPurchaseLines", "ItemPurchaseLineID", ItemPurchaseLineID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByItemPurchaseLineID(int ItemPurchaseLineID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("ItemPurchaseLines")
                .Criteria
                    .IsEqual("ItemPurchaseLines", "ItemPurchaseLineID", ItemPurchaseLineID);

            return clause;
        }

        private bool Exists(int? ItemPurchaseLineID)
        {
            if (ItemPurchaseLineID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByItemPurchaseLineID(ItemPurchaseLineID.Value)) != 0;
        }

        public override bool Exists(ItemPurchaseLine _obj)
        {
            return Exists(_obj.ItemPurchaseLineID);
        }

        protected override ItemPurchaseLine _FindByIntId(int? ItemPurchaseLineID)
        {
            if (Exists(ItemPurchaseLineID))
            {
                ItemPurchaseLine _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByItemPurchaseLineID(ItemPurchaseLineID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(ItemPurchaseLine _obj, DbDataReader _reader)
        {
            _obj.ItemPurchaseLineID =GetInt32(_reader, ("ItemPurchaseLineID"));
            _obj.PurchaseLineID =GetInt32(_reader, ("PurchaseLineID"));
            _obj.PurchaseID =GetInt32(_reader, ("PurchaseID"));
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
            _obj.Received = GetDouble(_reader, ("Received"));
            _obj.LocationID =GetInt32(_reader, ("LocationID"));
        }

        protected override object GetDbProperty(ItemPurchaseLine _obj, string property_name)
        {
            if (property_name.Equals("Item"))
            {
                return RepositoryMgr.ItemMgr.FindById(_obj.ItemID);
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

        public void DeleteCollectionByPurchaseID(int? PurchaseID)
        {
            IList<ItemPurchaseLine> lines = FindCollectionByPurchaseID(PurchaseID);
            foreach (ItemPurchaseLine line in lines)
            {
                Delete(line);
            }
        }

        public IList<ItemPurchaseLine> FindCollectionByPurchaseID(int? PurchaseID)
        {
            if (UseMemoryStore)
            {
                IList<ItemPurchaseLine> store = DataStore;
                var result = from ipl in store
                             where ipl.PurchaseID == PurchaseID
                             select ipl;
                return new BindingList<ItemPurchaseLine>(result.ToList());
            }
            return _FindCollectionByPurchaseID(PurchaseID);
        }

        private IList<ItemPurchaseLine> _FindCollectionByPurchaseID(int? PurchaseID)
        {
            BindingList<ItemPurchaseLine> _grp = new BindingList<ItemPurchaseLine>();
            if (PurchaseID == null) return _grp;

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("ItemPurchaseLines")
                .Criteria
                    .IsEqual("ItemPurchaseLines", "PurchaseID", PurchaseID.Value);

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ItemPurchaseLine _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        protected override IList<ItemPurchaseLine>_FindAllCollection()
        {
            List<ItemPurchaseLine> _grp = new List<ItemPurchaseLine>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                ItemPurchaseLine _obj =CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

       
    }
}
