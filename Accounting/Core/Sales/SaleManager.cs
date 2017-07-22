using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Sales
{
    using System.Linq;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Common;
    using Accounting.Core.Inventory;
    using Accounting.Db;
    using Accounting.Db.Elements;
    using Accounting.Core.Cards;
    using Accounting.Core.Definitions;

    public abstract class SaleManager : EntityManager<Sale>
    {
        public SaleManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        #region Sale factory methods
        protected override Sale _CreateDbEntity()
        {
            return new Sale(true, this);
        }

        protected override Sale _CreateEntity()
        {
            Sale _obj = new Sale(false, this);
            _obj.InvoiceType = RepositoryMgr.InvoiceTypeMgr.DefaultInvoiceType;
            return _obj;
        }
        #endregion 

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Sales");

            return clause;
        }

        public override Dictionary<string, DbFieldEntry> GetFields(Sale _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["SaleID"] = DbMgr.CreateAutoIntFieldEntry(_obj.SaleID);
            fields["InvoiceNumber"] = DbMgr.CreateStringFieldEntry(_obj.InvoiceNumber);
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["CustomerPONumber"] = DbMgr.CreateStringFieldEntry(_obj.CustomerPONumber);
            fields["IsHistorical"] = DbMgr.CreateStringFieldEntry(_obj.IsHistorical);
            fields["BackorderSaleID"] = DbMgr.CreateIntFieldEntry(_obj.BackorderSaleID);
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.Date);
            fields["InvoiceDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.InvoiceDate);
            fields["IsThirteenthPeriod"] = DbMgr.CreateStringFieldEntry(_obj.IsThirteenthPeriod);
            fields["ShipToAddress"] = DbMgr.CreateStringFieldEntry(_obj.ShipToAddress);
            fields["ShipToAddressLine1"] = DbMgr.CreateStringFieldEntry(_obj.ShipToAddressLine1);
            fields["ShipToAddressLine2"] = DbMgr.CreateStringFieldEntry(_obj.ShipToAddressLine2);
            fields["ShipToAddressLine3"] = DbMgr.CreateStringFieldEntry(_obj.ShipToAddressLine3);
            fields["ShipToAddressLine4"] = DbMgr.CreateStringFieldEntry(_obj.ShipToAddressLine4);
            fields["InvoiceTypeID"] = DbMgr.CreateStringFieldEntry(_obj.InvoiceTypeID);
            fields["InvoiceStatusID"] = DbMgr.CreateStringFieldEntry(_obj.InvoiceStatusID);
            fields["TermsID"] = DbMgr.CreateIntFieldEntry(_obj.TermsID);
            fields["TotalLines"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalLines);
            fields["TaxExclusiveFreight"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveFreight);
            fields["TaxInclusiveFreight"] = DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveFreight);
            fields["FreightTaxCodeID"] = DbMgr.CreateIntFieldEntry(_obj.FreightTaxCodeID);
            fields["TotalTax"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalTax);
            fields["TotalPaid"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalPaid);
            fields["TotalCredits"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalCredits);
            fields["TotalDeposits"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalDeposits);
            fields["TotalDiscounts"] = DbMgr.CreateDoubleFieldEntry(_obj.TotalDiscounts);
            fields["OutstandingBalance"] = DbMgr.CreateDoubleFieldEntry(_obj.OutstandingBalance);
            fields["SalesPersonID"] = DbMgr.CreateIntFieldEntry(_obj.SalesPersonID);
            fields["Memo"] = DbMgr.CreateStringFieldEntry(_obj.Memo);
            fields["Comment"] = DbMgr.CreateStringFieldEntry(_obj.Comment);
            fields["ShippingMethodID"] = DbMgr.CreateIntFieldEntry(_obj.ShippingMethodID);
            fields["Date"] = DbMgr.CreateDateTimeFieldEntry(_obj.InvoiceDate);
            fields["PromisedDate"] = DbMgr.CreateDateTimeFieldEntry(_obj.PromisedDate);
            fields["ReferralSourceID"] = DbMgr.CreateIntFieldEntry(_obj.ReferralSourceID);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["IsAutoRecorded"] = DbMgr.CreateStringFieldEntry(_obj.IsAutoRecorded);
            fields["IsPrinted"] = DbMgr.CreateStringFieldEntry(_obj.IsPrinted);
            fields["InvoiceDeliveryID"] = DbMgr.CreateStringFieldEntry(_obj.InvoiceDeliveryID);
            fields["DaysTillPaid"] = DbMgr.CreateIntFieldEntry(_obj.DaysTillPaid);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["TransactionExchangeRate"] = DbMgr.CreateDoubleFieldEntry(_obj.TransactionExchangeRate);
            //fields["CostCentreID"]=   Convert.ToString(_obj.CostCentreID);
            fields["LinesPurged"] = DbMgr.CreateStringFieldEntry(_obj.LinesPurged);
            fields["PreAuditTrail"] = DbMgr.CreateStringFieldEntry(_obj.PreAuditTrail);
            fields["DestinationCountry"] = DbMgr.CreateStringFieldEntry(_obj.DestinationCountry);

            return fields;
        }

        public List<Definitions.Status> RetrieveInvoiceStatuses()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectDistinct()
                .SelectColumn("Sales", "InvoiceStatusID")
                .From("Sales");
            

            DbCriteria criteria = DbMgr.CreateCriteria();

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                criteria.IsEqual("Status", "StatusID", GetString(_reader, ("InvoiceStatusID")), DbCriteria.ConcatMode.OR);
            }
            _reader.Close();
            _cmd.Dispose();

            return RepositoryMgr.StatusMgr.List(criteria);
        }

        private DbSelectStatement GetQuery_SelectByInvoiceNumber(string InvoiceNumber)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Sales")
                .Criteria.IsEqual("Sales", "InvoiceNumber", InvoiceNumber);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByInvoiceNumber(string InvoiceNumber)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Sales")
                .Criteria.IsEqual("Sales", "InvoiceNumber", InvoiceNumber);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectBySaleID(int SaleID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Sales")
                .Criteria.IsEqual("Sales", "SaleID", SaleID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountBySaleID(int SaleID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Sales")
                .Criteria.IsEqual("Sales", "SaleID", SaleID);

            return clause;
        }

        public bool ExistsByInvoiceNumber(string InvoiceNumber)
        {
            return ExecuteScalarInt(GetQuery_SelectByInvoiceNumber(InvoiceNumber)) != 0;
        }

        public bool ExistsBySaleID(int? SaleID)
        {
            if (SaleID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountBySaleID(SaleID.Value)) != 0;
        }

        public override bool Exists(Sale _obj)
        {
            return ExistsBySaleID(_obj.SaleID);
        }

        public Sale FindByInvoiceNumber(string InvoiceNumber)
        {
            if (ExistsByInvoiceNumber(InvoiceNumber))
            {
                Sale _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByInvoiceNumber(InvoiceNumber));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override Sale _FindByIntId(int? SaleID)
        {
            if (ExistsBySaleID(SaleID))
            {
                Sale _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectBySaleID(SaleID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(Sale _obj, DbDataReader _reader)
        {
            _obj.InvoiceNumber =GetString(_reader, ("InvoiceNumber"));
            _obj.SaleID =GetInt32(_reader, ("SaleID"));
            _obj.CardRecordID =GetInt32(_reader, ("CardRecordID"));
            _obj.CustomerPONumber =GetString(_reader, ("CustomerPONumber"));
            _obj.IsHistorical =GetString(_reader, ("IsHistorical"));
            _obj.BackorderSaleID =GetInt32(_reader, ("BackorderSaleID"));
            _obj.DestinationCountry = GetString(_reader, "DestinationCountry");
            _obj.Date = GetDateTime(_reader, "Date");
            _obj.InvoiceDate = GetDateTime(_reader, "InvoiceDate");

            _obj.IsThirteenthPeriod =GetString(_reader, ("IsThirteenthPeriod"));
            _obj.ShipToAddress =GetString(_reader, ("ShipToAddress"));
            _obj.ShipToAddressLine1 =GetString(_reader, ("ShipToAddressLine1"));
            _obj.ShipToAddressLine2 =GetString(_reader, ("ShipToAddressLine2"));
            _obj.ShipToAddressLine3 =GetString(_reader, ("ShipToAddressLine3"));
            _obj.ShipToAddressLine4 =GetString(_reader, ("ShipToAddressLine4"));
            _obj.InvoiceTypeID =GetString(_reader, ("InvoiceTypeID"));
            _obj.InvoiceStatusID =GetString(_reader, ("InvoiceStatusID"));
            _obj.TermsID =GetInt32(_reader, ("TermsID"));
            _obj.TotalLines = GetDouble(_reader, ("TotalLines"));
            _obj.TaxExclusiveFreight = GetDouble(_reader, ("TaxExclusiveFreight"));
            _obj.TaxInclusiveFreight = GetDouble(_reader, ("TaxInclusiveFreight"));
            _obj.FreightTaxCodeID =GetInt32(_reader, ("FreightTaxCodeID"));
            _obj.TotalTax = GetDouble(_reader, ("TotalTax"));
            _obj.TotalPaid = GetDouble(_reader, ("TotalPaid"));
            _obj.TotalCredits = GetDouble(_reader, ("TotalCredits"));
            _obj.TotalDeposits = GetDouble(_reader, ("TotalDeposits"));
            _obj.TotalDiscounts = GetDouble(_reader, ("TotalDiscounts"));
            _obj.OutstandingBalance = GetDouble(_reader, ("OutstandingBalance"));
            _obj.SalesPersonID =GetInt32(_reader, ("SalesPersonID"));
            _obj.Memo =GetString(_reader, ("Memo"));
            _obj.Comment =GetString(_reader, ("Comment"));
            _obj.ShippingMethodID =GetInt32(_reader, ("ShippingMethodID"));
            _obj.PromisedDate = GetDateTime(_reader, ("PromisedDate"));
            _obj.ReferralSourceID =GetInt32(_reader, ("ReferralSourceID"));
            _obj.IsTaxInclusive =GetString(_reader, ("IsTaxInclusive"));
            _obj.IsAutoRecorded =GetString(_reader, ("IsAutoRecorded"));
            _obj.IsPrinted =GetString(_reader, ("IsPrinted"));
            _obj.InvoiceDeliveryID =GetString(_reader, ("InvoiceDeliveryID"));

            try
            {
                _obj.DaysTillPaid = GetInt16(_reader, ("DaysTillPaid"));
            }
            catch
            {
                _obj.DaysTillPaid =GetInt32(_reader, ("DaysTillPaid"));
            }
            _obj.CurrencyID =GetInt32(_reader, ("CurrencyID"));
            _obj.TransactionExchangeRate = GetDouble(_reader, ("TransactionExchangeRate"));
            _obj.CostCentreID =GetInt32(_reader, ("CostCentreID"));
            _obj.LinesPurged =GetString(_reader, ("LinesPurged"));
            _obj.PreAuditTrail =GetString(_reader, ("PreAuditTrail"));
        }

        protected override object GetDbProperty(Sale _obj, string property_name)
        {
            if (property_name.Equals("Terms"))
            {
                return RepositoryMgr.TermsMgr.FindById(_obj.TermsID);
            }
            else if (property_name.Equals("InvoiceDelivery"))
            {
                return RepositoryMgr.InvoiceDeliveryMgr.FindById(_obj.InvoiceDeliveryID);
            }
            else if (property_name.Equals("ShippingMethod"))
            {
                return RepositoryMgr.ShippingMethodMgr.FindById(_obj.ShippingMethodID);
            }
            else if (property_name.Equals("Currency"))
            {
                return RepositoryMgr.CurrencyMgr.FindById(_obj.CurrencyID);
            }
            else if (property_name.Equals("FreightTaxCode"))
            {
                return RepositoryMgr.TaxCodeMgr.FindById(_obj.FreightTaxCodeID);
            }
            else if (property_name.Equals("InvoiceStatus"))
            {
                return RepositoryMgr.StatusMgr.FindById(_obj.InvoiceStatusID);
            }
            else if (property_name.Equals("InvoiceType"))
            {
                return RepositoryMgr.InvoiceTypeMgr.FindById(_obj.InvoiceTypeID);
            }
            else if(property_name.Equals("SalesPerson"))
            {
                return RepositoryMgr.EmployeeMgr.FindById(_obj.SalesPersonID);
            }
            else if (property_name.Equals("Customer"))
            {
                return RepositoryMgr.CustomerMgr.FindById(_obj.CardRecordID);
            }
            else if(property_name.Equals("ReferralSource"))
            {
                return RepositoryMgr.ReferralSourceMgr.FindById(_obj.ReferralSourceID);
            }

            return null;
        }

        protected override IList<Sale>_FindAllCollection()
        {
            List<Sale> _purchases = new List<Sale>();

            DbSelectStatement clause = GetQuery_SelectAll();
            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Sale _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _purchases.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _purchases;
        }

        public IList<Sale> FindFilteredCollection(DateTime? start, DateTime? end, Customer customer, Status invoiceStatus)
        {
            if (UseMemoryStore)
            {
                IList<Sale> store= DataStore;
                var result = from s in store
                             where s.Match(start, end, customer, invoiceStatus)
                             select s;
                return new BindingList<Sale>(result.ToList());
            }

            return _FindFilteredCollection(start, end, customer, invoiceStatus);
        }

        public IList<Sale> FindFilteredItemSaleCollection(DateTime? start, DateTime? end, Item _item)
        {
            if (UseMemoryStore)
            {
                IList<Sale> store = DataStore;
                var result = from s in store
                             where s.Match(start, end, null, null) && s.IsSellingItem(_item)
                             select s;
                return new BindingList<Sale>(result.ToList());
            }

            return _FindFilteredItemSaleCollection(start, end, _item);
        }

        private IList<Sale> _FindFilteredItemSaleCollection(DateTime? start, DateTime? end, Item _item)
        {
            DbCriteria criteria = CreateCriteria();
            criteria
                .IsGreaterEqual("Sales", "InvoiceDate", start)
                .IsLessEqual("Sales", "InvoiceDate", end)
                .IsEqual("Sales", "InvoiceType", "I");


            Currencies.CurrencyManager cm = RepositoryMgr.CurrencyMgr;
            bool support_multi_currency = cm.SupportMultiCurrency;
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                    .SelectAll()
                    .From("Sales")
                    .OrderBy("Sales", "InvoiceDate", "ASC")
                    .Criteria.And(criteria);



            BindingList<Sale> sales = new BindingList<Sale>();

            Dictionary<int, int> currencyIds = new Dictionary<int, int>();

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Sale _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                if (_obj.IsSellingItem(_item))
                {
                    sales.Add(_obj);
                }
            }
            _reader.Close();
            _cmd.Dispose();

            return sales;
        }

        private IList<Sale> _FindFilteredCollection(DateTime? start, DateTime? end, Customer customer, Status invoiceStatus)
        {
            DbCriteria criteria = CreateCriteria();
            criteria
                .IsGreaterEqual("Sales", "InvoiceDate", start)
                .IsLessEqual("Sales", "InvoiceDate", end);

            if (customer != null)
            {
                criteria.IsEqual("Customers", "CardIdentification", customer.CardIdentification);
            }

            if (invoiceStatus != null)
            {
                criteria.IsEqual("Sales", "InvoiceStatusID", invoiceStatus.StatusID);
            }
            

            Currencies.CurrencyManager cm = RepositoryMgr.CurrencyMgr;
            bool support_multi_currency = cm.SupportMultiCurrency;
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                    .SelectAll()
                    .From("Sales")
                    .OrderBy("Sales", "InvoiceDate", "ASC")
                    .Criteria.And(criteria);



            BindingList<Sale> sales = new BindingList<Sale>();

            Dictionary<int, int> currencyIds = new Dictionary<int, int>();

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Sale _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                sales.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return sales;
        }

        public int GetPageCount(DbCriteria criteria)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                    .SelectCount()
                    .From("Sales")
                    .From("Customers")
                    .Join("Customers", "CustomerID", "Sales", "CardRecordID")
                    .Criteria.And(criteria);

            return ExecuteScalarInt(clause);
        }

        public List<SaleRow> ListTableRow(DbCriteria criteria, int? startIndex, int? pageSize)
        {
            Currencies.CurrencyManager cm = RepositoryMgr.CurrencyMgr;
            bool support_multi_currency = cm.SupportMultiCurrency;
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            
            clause
                    .SelectDistinct()
                    .SelectColumn("Sales", "SaleID", "ID")
                    .SelectColumn("Sales", "CurrencyID", "CurrencyID")
                    .SelectColumn("Sales", "InvoiceNumber", "InvoiceNo")
                    .SelectColumn("Customers", "Name", "Customer")
                    .SelectColumn("Sales", "InvoiceDate", "InvoiceDate")
                    .SelectColumn("Sales", "TotalLines", "Amount")
                    .SelectColumn("Sales", "InvoiceStatusID", "InvoiceStatusID")
                    .SelectColumn("Sales", "OutstandingBalance", "AmtDue")
                    .From("Sales")
                    .From("Customers")
                    .Join("Customers", "CustomerID", "Sales", "CardRecordID")
                    .OrderBy("Sales", "InvoiceDate", "ASC")
                    .Criteria.And(criteria);


            int indexer = 0;
            List<SaleRow> _grp = new List<SaleRow>();

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                if (startIndex != null)
                {
                    indexer++;
                    if (indexer < startIndex)
                    {

                        continue;
                    }
                    else if (indexer > startIndex + pageSize)
                    {
                        break;
                    }
                }

                SaleRow _obj = new SaleRow();
                _obj.SaleID = GetInt32(_reader, "ID");
                _obj.InvoiceNumber = GetString(_reader, "InvoiceNo");
                _obj.Customer = GetString(_reader, "Customer");
                _obj.InvoiceDate = GetDateTime(_reader, "InvoiceDate");
                _obj.Amount = GetDouble(_reader, "Amount");
                _obj.AmountDue = GetDouble(_reader, "AmtDue");
                _obj.CurrencyID = GetInt32(_reader, "CurrencyID");
                _obj.InvoiceStatusID = GetString(_reader, "InvoiceStatusID");
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            Definitions.StatusManager sm = RepositoryMgr.StatusMgr;

            foreach (SaleRow _obj in _grp)
            {
                _obj.Currency=cm.FindById(_obj.CurrencyID);
                _obj.InvoiceStatus = sm.FindById(_obj.InvoiceStatusID);
            }

            return _grp;
        }
    }
}
