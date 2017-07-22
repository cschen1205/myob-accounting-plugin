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
    using Accounting.Core.Cards;
    using Accounting.Core.Definitions;
    using Accounting.Core.Inventory;

    public abstract class PurchaseManager : EntityManager<Purchase>
    {
        public PurchaseManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        #region +(Factory Methods)
        protected override Purchase _CreateDbEntity()
        {
            return new Purchase(true, this);
        }

        protected override Purchase _CreateEntity()
        {
            Purchase _obj = new Purchase(false, this);
            _obj.PurchaseType = RepositoryMgr.InvoiceTypeMgr.DefaultInvoiceType;
            return _obj;
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(Purchase _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["PurchaseID"] = DbMgr.CreateAutoIntFieldEntry(_obj.PurchaseID);
            fields["PurchaseNumber"] = DbMgr.CreateStringFieldEntry(_obj.PurchaseNumber);
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
            fields["Comment"] = DbMgr.CreateStringFieldEntry(_obj.Comment);
            fields["ShipToAddress"] = DbMgr.CreateStringFieldEntry(_obj.ShipToAddress);
            fields["ShipToAddressLine1"] = DbMgr.CreateStringFieldEntry(_obj.ShipToAddressLine1);
            fields["ShipToAddressLine2"] = DbMgr.CreateStringFieldEntry(_obj.ShipToAddressLine2);
            fields["ShipToAddressLine3"] = DbMgr.CreateStringFieldEntry(_obj.ShipToAddressLine3);
            fields["ShipToAddressLine4"] = DbMgr.CreateStringFieldEntry(_obj.ShipToAddressLine4);
            fields["PurchaseStatusID"] = DbMgr.CreateStringFieldEntry(_obj.PurchaseStatusID);
            fields["TermsID"] = DbMgr.CreateIntFieldEntry(_obj.TermsID);
            fields["TotalLines"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalLines);
            fields["TotalTax"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalTax);
            fields["TotalPaid"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalPaid);
            fields["OutstandingBalance"] = DbMgr.CreateDoubleFieldEntry(_obj.OutstandingBalance);
            fields["InvoiceDeliveryID"] = DbMgr.CreateStringFieldEntry(_obj.InvoiceDeliveryID);
            fields["ShippingMethodID"] = DbMgr.CreateIntFieldEntry(_obj.ShippingMethodID);
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod);
            fields["ReversalLinkID"] = DbMgr.CreateIntFieldEntry(_obj.ReversalLinkID);
            fields["OrderStatusID"] = DbMgr.CreateStringFieldEntry(_obj.OrderStatusID);
            fields["TaxExclusiveFreight"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveFreight);
            fields["TaxInclusiveFreight"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveFreight);
            fields["FreightTaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.FreightTaxCodeID);
            fields["TotalDeposits"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalDeposits);
            fields["TotalDebits"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalDebits);
            fields["TotalDiscounts"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalDiscounts);
            fields["IsPrinted"] = DbMgr.CreateStringFieldEntry(_obj.IsPrinted);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate);
            //fields["CostCentreID"] = new IntFieldEntry(_obj.CostCentreID);
            fields["LinesPurged"] = DbMgr.CreateStringFieldEntry(_obj.LinesPurged);
            fields["PreAuditTrail"] = DbMgr.CreateStringFieldEntry(_obj.PreAuditTrail);
            //fields["DaysTillPaid"] = new IntFieldEntry(_obj.DaysTillPaid);
            fields["IsAutoRecorded"] = DbMgr.CreateStringFieldEntry(_obj.IsAutoRecorded);
            fields["PurchaseDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.PurchaseDate);
            fields["PromisedDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.PromisedDate);
            fields["SupplierInvoiceNumber"] = DbMgr.CreateStringFieldEntry(_obj.SupplierInvoiceNumber);
            fields["IsHistorical"] = DbMgr.CreateStringFieldEntry(_obj.IsHistorical);
            fields["BackorderPurchaseID"] = DbMgr.CreateIntFieldEntry(_obj.BackorderPurchaseID);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["PurchaseTypeID"] = DbMgr.CreateStringFieldEntry(_obj.PurchaseTypeID);

            return fields;
        }
   
        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Purchases");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByPurchaseNumber(string PurchaseNumber)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Purchases")
                .Criteria
                    .IsEqual("Purchases", "PurchaseNumber", PurchaseNumber);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByPurchaseNumber(string PurchaseNumber)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Purchases")
                .Criteria
                    .IsEqual("Purchases", "PurchaseNumber", PurchaseNumber);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByPurchaseID(int PurchaseID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Purchases")
                .Criteria
                    .IsEqual("Purchases", "PurchaseID", PurchaseID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByPurchaseID(int PurchaseID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Purchases")
                .Criteria
                    .IsEqual("Purchases", "PurchaseID", PurchaseID);

            return clause;
        }

        public bool ExistsByPurchaseNumber(string PurchaseNumber)
        {
            return ExecuteScalarInt(GetQuery_SelectByPurchaseNumber(PurchaseNumber)) != 0;
        }

        public bool ExistsByPurchaseID(int? PurchaseID)
        {
            if (PurchaseID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByPurchaseID(PurchaseID.Value)) != 0;
        }

        public override bool Exists(Purchase _obj)
        {
            return ExistsByPurchaseID(_obj.PurchaseID);
        }

        public Purchase FindByPurchaseNumber(string PurchaseNumber)
        {
            if (ExistsByPurchaseNumber(PurchaseNumber))
            {
                Purchase _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByPurchaseNumber(PurchaseNumber));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override Purchase _FindByIntId(int? PurchaseID)
        {
            if (ExistsByPurchaseID(PurchaseID))
            {
                Purchase _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByPurchaseID(PurchaseID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(Purchase _obj, DbDataReader _reader)
        {
            _obj.PurchaseNumber=GetString(_reader, ("PurchaseNumber"));
            _obj.PurchaseID =GetInt32(_reader, ("PurchaseID"));
            _obj.CardRecordID =GetInt32(_reader, ("CardRecordID"));
            _obj.Memo =GetString(_reader, ("Memo"));
            _obj.Comment =GetString(_reader, ("Comment"));
            _obj.PurchaseDate = GetDateTime(_reader, ("PurchaseDate"));
            _obj.PromisedDate = GetDateTime(_reader, ("PromisedDate"));
            _obj.ShipToAddress =GetString(_reader, ("ShipToAddress"));
            _obj.ShipToAddressLine1 =GetString(_reader, ("ShipToAddressLine1"));
            _obj.ShipToAddressLine2 =GetString(_reader, ("ShipToAddressLine2"));
            _obj.ShipToAddressLine3 =GetString(_reader, ("ShipToAddressLine3"));
            _obj.ShipToAddressLine4 =GetString(_reader, ("ShipToAddressLine4"));
            _obj.PurchaseStatusID =GetString(_reader, ("PurchaseStatusID"));
            _obj.TermsID =GetInt32(_reader, ("TermsID"));
            _obj.TotalLines = GetDouble(_reader, ("TotalLines"));
            _obj.TotalTax = GetDouble(_reader, ("TotalTax"));
            _obj.TotalPaid = GetDouble(_reader, ("TotalPaid"));
            _obj.OutstandingBalance = GetDouble(_reader, ("OutstandingBalance"));
            _obj.InvoiceDeliveryID =GetString(_reader, ("InvoiceDeliveryID"));
            _obj.ShippingMethodID =GetInt32(_reader, ("ShippingMethodID"));
            _obj.SupplierInvoiceNumber =GetString(_reader, ("SupplierInvoiceNumber"));
            _obj.IsHistorical =GetString(_reader, ("IsHistorical"));
            _obj.BackorderPurchaseID =GetInt32(_reader, ("BackorderPurchaseID"));
            _obj.IsThirteenthPeriod =GetString(_reader, ("IsThirteenthPeriod"));
            _obj.ReversalLinkID =GetInt32(_reader, ("ReversalLinkID"));
            _obj.OrderStatusID =GetString(_reader, ("OrderStatusID"));
            _obj.TaxExclusiveFreight = GetDouble(_reader, ("TaxExclusiveFreight"));
            _obj.TaxInclusiveFreight = GetDouble(_reader, ("TaxInclusiveFreight"));
            _obj.FreightTaxCodeID =GetInt32(_reader, ("FreightTaxCodeID"));
            _obj.TotalDeposits = GetDouble(_reader, ("TotalDeposits"));
            _obj.TotalDebits = GetDouble(_reader, ("TotalDebits"));
            _obj.TotalDiscounts = GetDouble(_reader, ("TotalDiscounts"));
            _obj.IsPrinted =GetString(_reader, ("IsPrinted"));
            _obj.CurrencyID =GetInt32(_reader, ("CurrencyID"));
            _obj.IsTaxInclusive =GetString(_reader, ("IsTaxInclusive"));
            _obj.TransactionExchangeRate = GetDouble(_reader, ("TransactionExchangeRate"));
            _obj.CostCentreID =GetInt32(_reader, ("CostCentreID"));
            _obj.LinesPurged =GetString(_reader, ("LinesPurged"));
            _obj.PreAuditTrail =GetString(_reader, ("PreAuditTrail"));
            _obj.DaysTillPaid =GetInt32(_reader, ("DaysTillPaid"));
            _obj.IsAutoRecorded =GetString(_reader, ("IsAutoRecorded"));
            _obj.PurchaseTypeID =GetString(_reader, ("PurchaseTypeID"));
        }

        protected override object GetDbProperty(Purchase _obj, string property_name)
        {
            if (property_name == "PurchaseType")
            {
                return RepositoryMgr.InvoiceTypeMgr.FindById(_obj.PurchaseTypeID);
            }
            else if (property_name == "PurchaseStatus")
            {
                return RepositoryMgr.StatusMgr.FindById(_obj.PurchaseStatusID);
            }
            else if (property_name == "Terms")
            {
                return RepositoryMgr.TermsMgr.FindById(_obj.TermsID);
            }
            else if (property_name == "Supplier")
            {
                return RepositoryMgr.SupplierMgr.FindById(_obj.CardRecordID);
            }
            else if (property_name == "InvoiceDelivery")
            {
                return RepositoryMgr.InvoiceDeliveryMgr.FindById(_obj.InvoiceDeliveryID);
            }
            else if (property_name == "ShippingMethod")
            {
                return RepositoryMgr.ShippingMethodMgr.FindById(_obj.ShippingMethodID);
            }
            else if (property_name == "Currency")
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name == "FreightTaxCode")
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.FreightTaxCodeID);
            }
            return null;
        }

        public List<Definitions.Status> ListPurchaseStatus()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                    .SelectDistinct()
                    .SelectColumn("Purchases", "PurchaseStatusID")
                    .From("Purchases");

            

            DbCriteria criteria = DbMgr.CreateCriteria();

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                criteria.IsEqual("Status", "StatusID",  GetString(_reader, ("PurchaseStatusID")), DbCriteria.ConcatMode.OR); 
            }
            _reader.Close();
            _cmd.Dispose();

            return RepositoryMgr.StatusMgr.List(criteria);
        }

        protected override IList<Purchase>_FindAllCollection()
        {
            List<Purchase> _purchases = new List<Purchase>();

            DbSelectStatement clause = GetQuery_SelectAll();
            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Purchase _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _purchases.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _purchases;
        }

        public IList<Purchase> FindFilteredItemPurchaseCollection(DateTime? start, DateTime? end, Item _item)
        {
            if (UseMemoryStore)
            {
                IList<Purchase> store = DataStore;
                var result = from s in store
                             where s.Match(start, end, null, null) && s.IsPurchasingItem(_item)
                             select s;
                return new BindingList<Purchase>(result.ToList());
            }

            return _FindFilteredItemPurchaseCollection(start, end, _item);
        }

        private IList<Purchase> _FindFilteredItemPurchaseCollection(DateTime? start, DateTime? end, Item _item)
        {
            DbCriteria criteria = CreateCriteria();
            criteria
                .IsGreaterEqual("Purchases", "PurchaseDate", start)
                .IsLessEqual("Purchases", "PurchaseDate", end)
                .IsEqual("Purchases", "PurchaseType", "I");


            Currencies.CurrencyManager cm = RepositoryMgr.CurrencyMgr;
            bool support_multi_currency = cm.SupportMultiCurrency;
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                    .SelectAll()
                    .From("Purchases")
                    .OrderBy("Purchases", "PurchaseDate", "ASC")
                    .Criteria.And(criteria);



            BindingList<Purchase> purchases = new BindingList<Purchase>();

            Dictionary<int, int> currencyIds = new Dictionary<int, int>();

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Purchase _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                if (_obj.IsPurchasingItem(_item))
                {
                    purchases.Add(_obj);
                }
            }
            _reader.Close();
            _cmd.Dispose();

            return purchases;
        }

        public IList<Purchase> FindFilteredCollection(DateTime? start, DateTime? end, Supplier supplier, Status purchaseStatus)
        {
            if (UseMemoryStore)
            {
                IList<Purchase> store = DataStore;
                var result = from s in store
                             where s.Match(start, end, supplier, purchaseStatus)
                             select s;
                return new BindingList<Purchase>(result.ToList());
            }

            return _FindFilteredCollection(start, end, supplier, purchaseStatus);
        }

        private IList<Purchase> _FindFilteredCollection(DateTime? start, DateTime? end, Supplier supplier, Status purchaseStatus)
        {
            DbCriteria criteria =CreateCriteria();
            criteria
                .IsGreaterEqual("Purchases", "PurchaseDate", start)
                .IsLessEqual("Purchases", "PurchaseDate", end);

            if (supplier != null)
            {
                criteria.IsEqual("Suppliers", "CardIdentification", supplier.CardIdentification);
            }

            if (purchaseStatus != null)
            {
                criteria.IsEqual("Purchases", "PurchaseStatusID", purchaseStatus.StatusID);
            }

            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Purchases")
                 .OrderBy("Purchases", "PurchaseDate", "ASC")
                .Criteria.And(criteria);


            BindingList<Purchase> purchases = new BindingList<Purchase>();

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                Purchase _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                purchases.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return purchases;
        }

        
    }
}
