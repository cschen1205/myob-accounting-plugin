using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Sales
{
    public abstract class RecurringSaleManager : RecurringEntityManager<RecurringSale>
    {
        public RecurringSaleManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        #region RecurringSale factory methods
        protected override RecurringSale _CreateDbEntity()
        {
            return new RecurringSale(true, this);
        }

        protected override RecurringSale _CreateEntity()
        {
            RecurringSale _obj = new RecurringSale(false, this);
            _obj.InvoiceType = RepositoryMgr.InvoiceTypeMgr.DefaultInvoiceType;
            return _obj;
        }
        #endregion 

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringSales");

            return clause;
        }

        public override Dictionary<string, DbFieldEntry> GetFields(RecurringSale _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetRecurringEntityFields(_obj);

            fields["RecurringSaleID"] = DbMgr.CreateAutoIntFieldEntry(_obj.RecurringSaleID);
            fields["InvoiceNumber"] = DbMgr.CreateStringFieldEntry(_obj.InvoiceNumber);
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID);
            fields["CustomerPONumber"] = DbMgr.CreateStringFieldEntry(_obj.CustomerPONumber);
            fields["IsHistorical"] = DbMgr.CreateStringFieldEntry(_obj.IsHistorical);
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
            fields["ReferralSourceID"] = DbMgr.CreateIntFieldEntry(_obj.ReferralSourceID);
            fields["IsTaxInclusive"] = DbMgr.CreateStringFieldEntry(_obj.IsTaxInclusive);
            fields["InvoiceDeliveryID"] = DbMgr.CreateStringFieldEntry(_obj.InvoiceDeliveryID);
            fields["CurrencyID"] = DbMgr.CreateIntFieldEntry(_obj.CurrencyID);
            fields["CostCentreID"]=DbMgr.CreateIntFieldEntry(_obj.CostCentreID);

            return fields;
        }

        public List<Definitions.Status> RetrieveInvoiceStatuses()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectDistinct()
                .SelectColumn("RecurringSales", "InvoiceStatusID")
                .From("RecurringSales");
            

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
                .From("RecurringSales")
                .Criteria.IsEqual("RecurringSales", "InvoiceNumber", InvoiceNumber);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByInvoiceNumber(string InvoiceNumber)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("RecurringSales")
                .Criteria.IsEqual("RecurringSales", "InvoiceNumber", InvoiceNumber);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectBySaleID(int RecurringSaleID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("RecurringSales")
                .Criteria.IsEqual("RecurringSales", "RecurringSaleID", RecurringSaleID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountBySaleID(int RecurringSaleID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("RecurringSales")
                .Criteria.IsEqual("RecurringSales", "RecurringSaleID", RecurringSaleID);

            return clause;
        }

        private bool Exists(string InvoiceNumber)
        {
            return ExecuteScalarInt(GetQuery_SelectByInvoiceNumber(InvoiceNumber)) != 0;
        }

        private bool Exists(int? RecurringSaleID)
        {
            if (RecurringSaleID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountBySaleID(RecurringSaleID.Value)) != 0;
        }

        public override bool Exists(RecurringSale _obj)
        {
            return Exists(_obj.RecurringSaleID);
        }

        protected override RecurringSale _FindByTextId(string InvoiceNumber)
        {
            if (Exists(InvoiceNumber))
            {
                RecurringSale _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByInvoiceNumber(InvoiceNumber));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override RecurringSale _FindByIntId(int? RecurringSaleID)
        {
            if (Exists(RecurringSaleID))
            {
                RecurringSale _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectBySaleID(RecurringSaleID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadFromReader(RecurringSale _obj, DbDataReader _reader)
        {
            LoadRecurringEntityFromReader(_obj, _reader);

            _obj.InvoiceNumber =GetString(_reader, ("InvoiceNumber"));
            _obj.RecurringSaleID =GetInt32(_reader, ("RecurringSaleID"));
            _obj.CardRecordID =GetInt32(_reader, ("CardRecordID"));
            _obj.CustomerPONumber =GetString(_reader, ("CustomerPONumber"));
            _obj.IsHistorical =GetString(_reader, ("IsHistorical"));
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
            _obj.ReferralSourceID =GetInt32(_reader, ("ReferralSourceID"));
            _obj.IsTaxInclusive =GetString(_reader, ("IsTaxInclusive"));
            _obj.InvoiceDeliveryID =GetString(_reader, ("InvoiceDeliveryID"));
            _obj.CurrencyID =GetInt32(_reader, ("CurrencyID"));
            _obj.CostCentreID =GetInt32(_reader, ("CostCentreID"));
        }

        protected override object GetDbProperty(RecurringSale _obj, string property_name)
        {
            object returned_obj = GetRecurringEntityDbProperty(_obj, property_name);
            if (returned_obj != null) return returned_obj;

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

        protected override IList<RecurringSale>_FindAllCollection()
        {
            List<RecurringSale> _purchases = new List<RecurringSale>();

            DbSelectStatement clause = GetQuery_SelectAll();
            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                RecurringSale _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _purchases.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _purchases;
        }

        public DataTable Table(DbCriteria criteria)
        {
            Currencies.CurrencyManager cm = RepositoryMgr.CurrencyMgr;
            bool support_multi_currency=cm.SupportMultiCurrency;
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            
            clause
                    .SelectDistinct()
                    .SelectColumn("RecurringSales", "RecurringSaleID", "ID")
                    .SelectColumn("RecurringSales", "CurrencyID", "CurrencyID")
                    .SelectColumn("RecurringSales", "InvoiceNumber", "InvoiceNo")
                    .SelectColumn("Customers", "Name", "Customer")
                    .SelectColumn("RecurringSales", "InvoiceDate", "InvoiceDate")
                    .SelectColumn("RecurringSales", "TotalLines", "Amount")
                    .SelectColumn("RecurringSales", "OutstandingBalance", "AmtDue")
                    .From("RecurringSales")
                    .From("Customers")
                    .Join("Customers", "CustomerID", "RecurringSales", "CardRecordID")
                    .OrderBy("RecurringSales", "InvoiceDate", "ASC")
                    .Criteria.And(criteria);

            

            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Invoice #");
            table.Columns.Add("Customer");
            table.Columns.Add("Invoice Date");
            table.Columns.Add("Amount");
            table.Columns.Add("Amt Due");

            Dictionary<int, int> currencyIds = new Dictionary<int, int>();

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                DataRow row = table.NewRow();
                int? id=GetInt32(_reader, "ID");
                row["ID"] = id.Value;
                row["Invoice #"] = GetString(_reader, "InvoiceNo");
                row["Customer"] = GetString(_reader, "Customer");
                DateTime? invoice_date=GetDateTime(_reader, "InvoiceDate");
                if (invoice_date.HasValue)
                {
                    row["Invoice Date"] = invoice_date.Value.ToString("yyyy-MM-dd");
                }
                
                row["Amount"] =GetDouble(_reader, "Amount");
                row["Amt Due"] =GetDouble(_reader, "AmtDue");

                int? currency_id=GetInt32(_reader, "CurrencyID");
                if (currency_id != null)
                {
                    currencyIds[id.Value] = currency_id.Value;
                }
               
                table.Rows.Add(row);
            }
            _reader.Close();
            _cmd.Dispose();

            foreach (DataRow row in table.Rows)
            {
                double Amount = Convert.ToDouble(row["Amount"]);
                double AmtDue = Convert.ToDouble(row["Amt Due"]);

                int id = Convert.ToInt32(row["ID"]);
                if (support_multi_currency && currencyIds.ContainsKey(id))
                {
                   
                    Currencies.Currency currency = cm.FindById(currencyIds[id]);
                    row["Amount"] = currency.Format(Amount);
                    row["Amt Due"] = currency.Format(AmtDue);
                }
                else
                {
                    row["Amount"] = cm.Format(Amount);
                    row["Amt Due"] = cm.Format(AmtDue);
                }
            }

            return table;
        }
    }
}
