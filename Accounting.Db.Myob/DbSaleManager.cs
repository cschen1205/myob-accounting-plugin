using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.Odbc;

namespace Accounting.Db.Myob
{
    using Accounting.Core;
    using Accounting.Core.Sales;
    using Accounting.Core.Definitions;
    using Accounting.Core.Inventory;
    using Accounting.Core.Accounts;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public class DbSaleManager : SaleManager
    {
        public DbSaleManager(DbManager mgr)
            : base(mgr)
        {

        }

        protected override OpResult _Store(Sale _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Sale object cannot be deleted as it is null");
            }

            bool is_creating = !Exists(_obj);

            if (is_creating)
            {
                RepositoryMgr.MiscNumberMgr.SaveInvoiceNumber(_obj.InvoiceNumber);
            }

            string query = "";

            if (_obj.InvoiceType != null)
            {
                if (_obj.InvoiceType.IsProfessional)
                {
                    query = GetQuery_StoreProfessionalSaleLines(_obj);
                }
                else if (_obj.InvoiceType.IsTimeBilling)
                {
                    query = GetQuery_StoreTimeBillingSaleLines(_obj);
                }
                else if (_obj.InvoiceType.IsService)
                {
                    query = GetQuery_StoreServiceSaleLines(_obj);
                }
                else if (_obj.InvoiceType.IsItem)
                {
                    query = GetQuery_StoreItemSaleLines(_obj); 
                }
                else if (_obj.InvoiceType.IsMisc)
                {
                    query = GetQuery_StoreMiscellaneousSaleLines(_obj); 
                }
            }

            if (string.IsNullOrEmpty(query))
            {
                if (is_creating)
                {
                    return OpResult.NotifyStoreAction(OpResult.ResultStatus.CreateFailedOnCriteria, _obj, "Sale object does not have any SaleLines");
                }
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.UpdateFailedOnCriteria, _obj, "Sale object does not have any SaleLines");
            }

            DbCommand cmdSQLInsert = new OdbcCommand(query, (OdbcConnection)DbMgr.DbConnection);
            DbTransaction myTrans = DbMgr.DbConnection.BeginTransaction();
            try
            {
                cmdSQLInsert.CommandText = query;
                cmdSQLInsert.Transaction = myTrans;
                cmdSQLInsert.ExecuteNonQuery();
                myTrans.Commit();
            }
            catch (OdbcException ex)
            {
                myTrans.Rollback();
                Log(ex.Message);
                Console.WriteLine(ex.ToString());
                if (is_creating)
                {
                    return OpResult.NotifyStoreAction(OpResult.ResultStatus.CreatedWithException, _obj, ex.ToString());
                }
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.UpdatedWithException, _obj, ex.ToString());
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                Console.WriteLine(ex.ToString());
                if (is_creating)
                {
                    return OpResult.NotifyStoreAction(OpResult.ResultStatus.CreatedWithException, _obj, ex.ToString());
                }
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.UpdatedWithException, _obj, ex.ToString());
            }

            _obj.FromDb = true;

            if (is_creating)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
            }
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
        }

        #region ItemSaleLines
        private Dictionary<string, DbFieldEntry> GetQueryMap_StoreItemSaleLines(Sale _sale, ItemSaleLine _line)
        {
            bool is_header = (_line == null);
            Dictionary<string, DbFieldEntry> query_map = new Dictionary<string, DbFieldEntry>();

            bool multi_currency_support = _sale.RepositoryMgr.CurrencyMgr.SupportMultiCurrency;

            #region Populate Sale Information
            query_map.Add("FirstName", DbMgr.CreateStringFieldEntry(is_header && _sale.Customer != null ? _sale.Customer.FirstName : ""));
            query_map.Add("CoLastName", DbMgr.CreateStringFieldEntry(is_header && _sale.Customer != null ? _sale.Customer.LastName : ""));
            query_map.Add("CardID", DbMgr.CreateStringFieldEntry(is_header && _sale.Customer != null ? _sale.Customer.CardIdentification : ""));
            query_map.Add("AddressLine1", DbMgr.CreateStringFieldEntry(is_header ? _sale.ShipToAddressLine1 : ""));
            query_map.Add("AddressLine2", DbMgr.CreateStringFieldEntry(is_header ? _sale.ShipToAddressLine2 : ""));
            query_map.Add("AddressLine3", DbMgr.CreateStringFieldEntry(is_header ? _sale.ShipToAddressLine3 : ""));
            query_map.Add("AddressLine4", DbMgr.CreateStringFieldEntry(is_header ? _sale.ShipToAddressLine4 : ""));
            query_map.Add("InvoiceNumber", DbMgr.CreateStringFieldEntry(is_header ? _sale.InvoiceNumber : ""));
            query_map.Add("Memo", DbMgr.CreateStringFieldEntry(is_header ? _sale.Memo : ""));
            query_map.Add("Inclusive", DbMgr.CreateStringFieldEntry(is_header && _sale.IsTaxInclusive == "Y" ? "1" : ""));
            query_map.Add("SaleDate", _sale.InvoiceDate != null && is_header ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_sale.InvoiceDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("ShipVia", DbMgr.CreateStringFieldEntry(is_header && _sale.ShippingMethod != null ? _sale.ShippingMethod.Method : ""));
            query_map.Add("DeliveryStatus", DbMgr.CreateStringFieldEntry(is_header & _sale.InvoiceDelivery != null ? _sale.InvoiceDelivery.InvoiceDeliveryID : ""));
            query_map.Add("Comment", DbMgr.CreateStringFieldEntry(is_header && _sale.Comment != null ? _sale.Comment : ""));
            query_map.Add("SalespersonLastName", DbMgr.CreateStringFieldEntry(is_header && _sale.SalesPerson != null ? _sale.SalesPerson.LastName : ""));
            query_map.Add("SalespersonFirstName", DbMgr.CreateStringFieldEntry(is_header && _sale.SalesPerson != null ? _sale.SalesPerson.FirstName : ""));
            query_map.Add("ShippingDate", is_header && _sale.PromisedDate != null ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_sale.PromisedDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("FreightExTaxAmount", DbMgr.CreateDoubleFieldEntry(is_header ? _sale.TaxExclusiveFreight : 0));
            query_map.Add("FreightIncTaxAmount", DbMgr.CreateDoubleFieldEntry(is_header ? _sale.TaxInclusiveFreight : 0));
            query_map.Add("FreightTaxCode", DbMgr.CreateStringFieldEntry(is_header  && _sale.FreightTaxCode != null ? _sale.FreightTaxCode.Code : ""));

            string sale_status_text = "";
            Status sale_status = _sale.InvoiceStatus;
            if (is_header && sale_status != null)
            {
                if (sale_status.Type == Status.StatusType.Quote)
                {
                    sale_status_text = "Q";
                }
                else if (sale_status.Type == Status.StatusType.Order)
                {
                    sale_status_text = "O";
                }
                else if (sale_status.Type == Status.StatusType.Open)
                {
                    sale_status_text = "I";
                }
            }
            query_map.Add("SaleStatus", DbMgr.CreateStringFieldEntry(sale_status_text));
          
            if (_sale.InvoiceStatus.Type == Accounting.Core.Definitions.Status.StatusType.Order
                   || _sale.InvoiceStatus.Type == Accounting.Core.Definitions.Status.StatusType.Open
                   )
            {
                //sqlArray.Add("AmountPaid", DbMgr.CreateDoubleFieldEntry(_obj.AmountPaid));
            }
            if (multi_currency_support)
            {
                query_map.Add("CurrencyCode", DbMgr.CreateStringFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion && _sale.Currency != null ? _sale.Currency.CurrencyCode : ""));
                query_map.Add("ExchangeRate", DbMgr.CreateDoubleFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion ? _sale.TransactionExchangeRate : 0));
            }
            query_map.Add("PaymentIsDue", DbMgr.CreateIntFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.PaymentIsDue : 0));
            query_map.Add("DiscountDays", DbMgr.CreateIntFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.DiscountDays : 0));
            query_map.Add("BalanceDueDays", DbMgr.CreateIntFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.BalanceDueDays : 0));
            query_map.Add("PercentDiscount", DbMgr.CreateDoubleFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.EarlyPaymentDiscountPercent : 0));
            query_map.Add("PercentMonthlyCharge", DbMgr.CreateDoubleFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.LatePaymentChargePercent : 0));
            query_map.Add("ReferralSource", DbMgr.CreateStringFieldEntry(is_header && _sale.ReferralSource != null ? _sale.ReferralSource.Description : ""));
            #endregion

            #region Populate Line Information
            query_map.Add("ItemNumber", DbMgr.CreateStringFieldEntry(!is_header && _line.Item != null ? _line.Item.ItemNumber : ""));
            query_map.Add("Quantity", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.Quantity : 0));
            query_map.Add("Description", DbMgr.CreateStringFieldEntry(!is_header ? _line.Description : ""));
            query_map.Add("ExTaxPrice", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.TaxExclusiveUnitPrice : 0));
            query_map.Add("IncTaxPrice", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.TaxInclusiveUnitPrice : 0));
            query_map.Add("Discount", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.Discount : 0));
            query_map.Add("ExTaxTotal", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.TaxExclusiveTotal : 0));
            query_map.Add("IncTaxTotal", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.TaxInclusiveTotal : 0));
            query_map.Add("Job", DbMgr.CreateStringFieldEntry(!is_header && _line.Job != null ? _line.Job.JobName : ""));
            query_map.Add("TaxCode", DbMgr.CreateStringFieldEntry(!is_header && _line.TaxCode != null ? _line.TaxCode.Code : ""));
            #endregion 

            return query_map;
        }

        private string GetQuery_StoreItemSaleLines(Sale _sale)
        {
            List<Dictionary<string, DbFieldEntry>> query_matrix = new List<Dictionary<string, DbFieldEntry>>();
            Dictionary<string, DbFieldEntry> query_header = GetQueryMap_StoreItemSaleLines(_sale, null);

            foreach (ItemSaleLine _line in _sale.SaleLines)
            {
                    Dictionary<string, DbFieldEntry> query_map = GetQueryMap_StoreItemSaleLines(_sale, _line);
                    query_matrix.Add(query_map);
            }

            string query = "";
            if (query_matrix.Count != 0)
            {
                query = GetQuery(query_header, query_matrix, "Import_Item_Sales");
            }
            return query;
        }
        #endregion

        #region MiscSaleLines
        private Dictionary<string, DbFieldEntry> GetQueryMap_StoreMiscellaneousSaleLines(Sale _sale, MiscSaleLine _line)
        {
            bool is_header = (_line == null);
            Dictionary<string, DbFieldEntry> query_map = new Dictionary<string, DbFieldEntry>();

            bool multi_currency_support = _sale.RepositoryMgr.CurrencyMgr.SupportMultiCurrency;

            #region Populate Sale Information
            query_map.Add("FirstName", DbMgr.CreateStringFieldEntry(is_header && _sale.Customer != null ? _sale.Customer.FirstName : ""));
            query_map.Add("CoLastName", DbMgr.CreateStringFieldEntry(is_header && _sale.Customer != null ? _sale.Customer.LastName : ""));
            query_map.Add("CardID", DbMgr.CreateStringFieldEntry(is_header && _sale.Customer != null ? _sale.Customer.CardIdentification : ""));
            query_map.Add("InvoiceNumber", DbMgr.CreateStringFieldEntry(is_header ? _sale.InvoiceNumber : ""));
            query_map.Add("Memo", DbMgr.CreateStringFieldEntry(is_header ? _sale.Memo : ""));
            query_map.Add("Inclusive", DbMgr.CreateStringFieldEntry(is_header && _sale.IsTaxInclusive == "Y" ? "1" : ""));
            query_map.Add("SaleDate", _sale.InvoiceDate != null && is_header ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_sale.InvoiceDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("DeliveryStatus", DbMgr.CreateStringFieldEntry(is_header & _sale.InvoiceDelivery != null ? _sale.InvoiceDelivery.InvoiceDeliveryID : ""));
            query_map.Add("Comment", DbMgr.CreateStringFieldEntry(is_header && _sale.Comment != null ? _sale.Comment : ""));
            query_map.Add("SalespersonLastName", DbMgr.CreateStringFieldEntry(is_header && _sale.SalesPerson != null ? _sale.SalesPerson.LastName : ""));
            query_map.Add("SalespersonFirstName", DbMgr.CreateStringFieldEntry(is_header && _sale.SalesPerson != null ? _sale.SalesPerson.FirstName : ""));

            string sale_status_text = "";
            Status sale_status = _sale.InvoiceStatus;
            if (is_header && sale_status != null)
            {
                if (sale_status.Type == Status.StatusType.Quote)
                {
                    sale_status_text = "Q";
                }
                else if (sale_status.Type == Status.StatusType.Order)
                {
                    sale_status_text = "O";
                }
                else if (sale_status.Type == Status.StatusType.Open)
                {
                    sale_status_text = "I";
                }
            }
            query_map.Add("SaleStatus", DbMgr.CreateStringFieldEntry(sale_status_text));

            if (_sale.InvoiceStatus.Type == Accounting.Core.Definitions.Status.StatusType.Order
                   || _sale.InvoiceStatus.Type == Accounting.Core.Definitions.Status.StatusType.Open
                   )
            {
                //sqlArray.Add("AmountPaid", DbMgr.CreateDoubleFieldEntry(_obj.AmountPaid));
            }
            if (multi_currency_support)
            {
                query_map.Add("CurrencyCode", DbMgr.CreateStringFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion && _sale.Currency != null ? _sale.Currency.CurrencyCode : ""));
                query_map.Add("ExchangeRate", DbMgr.CreateDoubleFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion ? _sale.TransactionExchangeRate : 0));
            }
            query_map.Add("PaymentIsDue", DbMgr.CreateIntFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.PaymentIsDue : 0));
            query_map.Add("DiscountDays", DbMgr.CreateIntFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.DiscountDays : 0));
            query_map.Add("BalanceDueDays", DbMgr.CreateIntFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.BalanceDueDays : 0));
            query_map.Add("PercentDiscount", DbMgr.CreateDoubleFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.EarlyPaymentDiscountPercent : 0));
            query_map.Add("PercentMonthlyCharge", DbMgr.CreateDoubleFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.LatePaymentChargePercent : 0));
            query_map.Add("ReferralSource", DbMgr.CreateStringFieldEntry(is_header && _sale.ReferralSource != null ? _sale.ReferralSource.Description : ""));
            #endregion

            #region Populate Line Information
            query_map.Add("AccountNumber", DbMgr.CreateStringFieldEntry(!is_header && _line.Account != null ? _line.Account.AccountNumber : ""));
            query_map.Add("Description", DbMgr.CreateStringFieldEntry(!is_header ? _line.Description : ""));
            query_map.Add("ExTaxAmount", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.TaxExclusiveAmount : 0));
            query_map.Add("IncTaxAmount", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.TaxInclusiveAmount : 0));
            query_map.Add("Job", DbMgr.CreateStringFieldEntry(!is_header && _line.Job != null ? _line.Job.JobName : ""));
            query_map.Add("TaxCode", DbMgr.CreateStringFieldEntry(!is_header && _line.TaxCode != null ? _line.TaxCode.Code : ""));
            #endregion

            return query_map;
        }

        private string GetQuery_StoreMiscellaneousSaleLines(Sale _sale)
        {
            List<Dictionary<string, DbFieldEntry>> query_matrix = new List<Dictionary<string, DbFieldEntry>>();
            Dictionary<string, DbFieldEntry> query_header = GetQueryMap_StoreMiscellaneousSaleLines(_sale, null);

            foreach (MiscSaleLine _line in _sale.SaleLines)
            {
                
                    Dictionary<string, DbFieldEntry> query_map = GetQueryMap_StoreMiscellaneousSaleLines(_sale, _line);
                    query_matrix.Add(query_map);
                
            }

            string query = "";
            if (query_matrix.Count != 0)
            {
                query = GetQuery(query_header, query_matrix, "Import_Miscellaneous_Sales");
            }
            return query;
        }
        #endregion

        #region TimeBillingSaleLines
        private Dictionary<string, DbFieldEntry> GetQueryMap_StoreTimeBillingSaleLines(Sale _sale, TimeBillingSaleLine _line)
        {
            bool is_header = (_line == null);
            Dictionary<string, DbFieldEntry> query_map = new Dictionary<string, DbFieldEntry>();

            bool multi_currency_support = _sale.RepositoryMgr.CurrencyMgr.SupportMultiCurrency;

            #region Populate Sale Information
            query_map.Add("FirstName", DbMgr.CreateStringFieldEntry(is_header && _sale.Customer != null ? _sale.Customer.FirstName : ""));
            query_map.Add("CoLastName", DbMgr.CreateStringFieldEntry(is_header && _sale.Customer != null ? _sale.Customer.LastName : ""));
            query_map.Add("CardID", DbMgr.CreateStringFieldEntry(is_header && _sale.Customer != null ? _sale.Customer.CardIdentification : ""));
            query_map.Add("InvoiceNumber", DbMgr.CreateStringFieldEntry(is_header ? _sale.InvoiceNumber : ""));
            query_map.Add("Memo", DbMgr.CreateStringFieldEntry(is_header ? _sale.Memo : ""));
            query_map.Add("AddressLine1", DbMgr.CreateStringFieldEntry(is_header ? _sale.ShipToAddressLine1 : ""));
            query_map.Add("AddressLine2", DbMgr.CreateStringFieldEntry(is_header ? _sale.ShipToAddressLine2 : ""));
            query_map.Add("AddressLine3", DbMgr.CreateStringFieldEntry(is_header ? _sale.ShipToAddressLine3 : ""));
            query_map.Add("AddressLine4", DbMgr.CreateStringFieldEntry(is_header ? _sale.ShipToAddressLine4 : ""));
            query_map.Add("ShipVia", DbMgr.CreateStringFieldEntry(is_header && _sale.ShippingMethod != null ? _sale.ShippingMethod.Method : ""));
            query_map.Add("FreightAmount", DbMgr.CreateDoubleFieldEntry(is_header ? _sale.TaxExclusiveFreight : 0));
            query_map.Add("FreightTaxCode", DbMgr.CreateStringFieldEntry(is_header && _sale.FreightTaxCode != null ? _sale.FreightTaxCode.Code : ""));
            query_map.Add("Inclusive", DbMgr.CreateStringFieldEntry(is_header && _sale.IsTaxInclusive == "Y" ? "1" : ""));
            query_map.Add("SaleDate", _sale.InvoiceDate != null && is_header ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_sale.InvoiceDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("DeliveryStatus", DbMgr.CreateStringFieldEntry(is_header & _sale.InvoiceDelivery != null ? _sale.InvoiceDelivery.InvoiceDeliveryID : ""));
            query_map.Add("PromisedDate", is_header && _sale.PromisedDate != null ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_sale.PromisedDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("Comment", DbMgr.CreateStringFieldEntry(is_header && _sale.Comment != null ? _sale.Comment : ""));
            query_map.Add("SalespersonLastName", DbMgr.CreateStringFieldEntry(is_header && _sale.SalesPerson != null ? _sale.SalesPerson.LastName : ""));
            query_map.Add("SalespersonFirstName", DbMgr.CreateStringFieldEntry(is_header && _sale.SalesPerson != null ? _sale.SalesPerson.FirstName : ""));

            string sale_status_text = "";
            Status sale_status = _sale.InvoiceStatus;
            if (is_header && sale_status != null)
            {
                if (sale_status.Type == Status.StatusType.Quote)
                {
                    sale_status_text = "Q";
                }
                else if (sale_status.Type == Status.StatusType.Order)
                {
                    sale_status_text = "O";
                }
                else if (sale_status.Type == Status.StatusType.Open)
                {
                    sale_status_text = "I";
                }
            }
            query_map.Add("SaleStatus", DbMgr.CreateStringFieldEntry(sale_status_text));

            if (_sale.InvoiceStatus.Type == Accounting.Core.Definitions.Status.StatusType.Order
                   || _sale.InvoiceStatus.Type == Accounting.Core.Definitions.Status.StatusType.Open
                   )
            {
                //sqlArray.Add("AmountPaid", DbMgr.CreateDoubleFieldEntry(_obj.AmountPaid));
            }
            if (multi_currency_support)
            {
                query_map.Add("CurrencyCode", DbMgr.CreateStringFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion && _sale.Currency != null ? _sale.Currency.CurrencyCode : ""));
                query_map.Add("ExchangeRate", DbMgr.CreateDoubleFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion ? _sale.TransactionExchangeRate : 0));
            }
            query_map.Add("PaymentIsDue", DbMgr.CreateIntFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.PaymentIsDue : 0));
            query_map.Add("DiscountDays", DbMgr.CreateIntFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.DiscountDays : 0));
            query_map.Add("BalanceDueDays", DbMgr.CreateIntFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.BalanceDueDays : 0));
            query_map.Add("PercentDiscount", DbMgr.CreateDoubleFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.EarlyPaymentDiscountPercent : 0));
            query_map.Add("PercentMonthlyCharge", DbMgr.CreateDoubleFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.LatePaymentChargePercent : 0));
            query_map.Add("ReferralSource", DbMgr.CreateStringFieldEntry(is_header && _sale.ReferralSource != null ? _sale.ReferralSource.Description : ""));
            #endregion

            #region Populate Line Information
            query_map.Add("ActivityID", !is_header && _line.Activity != null ? (DbFieldEntry)DbMgr.CreateStringFieldEntry(_line.Activity.ActivityName) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("Description", DbMgr.CreateStringFieldEntry(!is_header ? _line.Description : ""));
            query_map.Add("ExTaxAmount", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.TaxExclusiveAmount : 0));
            query_map.Add("IncTaxAmount", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.TaxInclusiveAmount : 0));
            query_map.Add("Job", DbMgr.CreateStringFieldEntry(!is_header && _line.Job != null ? _line.Job.JobName : ""));
            query_map.Add("TaxCode", DbMgr.CreateStringFieldEntry(!is_header && _line.TaxCode != null ? _line.TaxCode.Code : ""));
            query_map.Add("HoursUnits", !is_header ? (DbFieldEntry)DbMgr.CreateDoubleFieldEntry(_line.HoursUnits) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("Notes", (DbFieldEntry)DbMgr.CreateStringFieldEntry(!is_header ?  _line.Description : "") );
            query_map.Add("DetailDate", !is_header && _line.LineDate != null ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_line.LineDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("Rate", !is_header ? (DbFieldEntry)DbMgr.CreateDoubleFieldEntry(_line.TaxInclusiveRate) : DbMgr.CreateStringFieldEntry(""));
            #endregion
            return query_map;
        }

        private string GetQuery_StoreTimeBillingSaleLines(Sale _sale)
        {
            List<Dictionary<string, DbFieldEntry>> query_matrix = new List<Dictionary<string, DbFieldEntry>>();
            Dictionary<string, DbFieldEntry> query_header = GetQueryMap_StoreTimeBillingSaleLines(_sale, null);

            foreach (TimeBillingSaleLine _line in _sale.SaleLines)
            {
                    Dictionary<string, DbFieldEntry> query_map = GetQueryMap_StoreTimeBillingSaleLines(_sale, _line);
                    query_matrix.Add(query_map);
             
            }

            string query = "";
            if (query_matrix.Count != 0)
            {
                query = GetQuery(query_header, query_matrix, "Import_TimeBilling_Sales");
            }
            return query;
        }
        #endregion

        #region ProfessionalSaleLines
        private Dictionary<string, DbFieldEntry> GetQueryMap_StoreProfessionalSaleLines(Sale _sale, ProfessionalSaleLine _line)
        {
            bool is_header = (_line == null);
            Dictionary<string, DbFieldEntry> query_map = new Dictionary<string, DbFieldEntry>();

            bool multi_currency_support = _sale.RepositoryMgr.CurrencyMgr.SupportMultiCurrency;

            #region Populate Sale Information
            query_map.Add("FirstName", DbMgr.CreateStringFieldEntry(is_header && _sale.Customer != null ? _sale.Customer.FirstName : ""));
            query_map.Add("CoLastName", DbMgr.CreateStringFieldEntry(is_header && _sale.Customer != null ? _sale.Customer.LastName : ""));
            query_map.Add("CardID", DbMgr.CreateStringFieldEntry(is_header && _sale.Customer != null ? _sale.Customer.CardIdentification : ""));
            query_map.Add("InvoiceNumber", DbMgr.CreateStringFieldEntry(is_header ? _sale.InvoiceNumber : ""));
            query_map.Add("Memo", DbMgr.CreateStringFieldEntry(is_header ? _sale.Memo : ""));
            query_map.Add("Inclusive", DbMgr.CreateStringFieldEntry(is_header && _sale.IsTaxInclusive == "Y" ? "1" : ""));
            query_map.Add("SaleDate", _sale.InvoiceDate != null && is_header ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_sale.InvoiceDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("DeliveryStatus", DbMgr.CreateStringFieldEntry(is_header & _sale.InvoiceDelivery != null ? _sale.InvoiceDelivery.InvoiceDeliveryID : ""));
            query_map.Add("PromisedDate", is_header && _sale.PromisedDate != null ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_sale.PromisedDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("Comment", DbMgr.CreateStringFieldEntry(is_header && _sale.Comment != null ? _sale.Comment : ""));
            query_map.Add("SalespersonLastName", DbMgr.CreateStringFieldEntry(is_header && _sale.SalesPerson != null ? _sale.SalesPerson.LastName : ""));
            query_map.Add("SalespersonFirstName", DbMgr.CreateStringFieldEntry(is_header && _sale.SalesPerson != null ? _sale.SalesPerson.FirstName : ""));

            string sale_status_text = "";
            Status sale_status = _sale.InvoiceStatus;
            if (is_header && sale_status != null)
            {
                if (sale_status.Type == Status.StatusType.Quote)
                {
                    sale_status_text = "Q";
                }
                else if (sale_status.Type == Status.StatusType.Order)
                {
                    sale_status_text = "O";
                }
                else if (sale_status.Type == Status.StatusType.Open)
                {
                    sale_status_text = "I";
                }
            }
            query_map.Add("SaleStatus", DbMgr.CreateStringFieldEntry(sale_status_text));

            if (_sale.InvoiceStatus.Type == Accounting.Core.Definitions.Status.StatusType.Order
                   || _sale.InvoiceStatus.Type == Accounting.Core.Definitions.Status.StatusType.Open
                   )
            {
                //sqlArray.Add("AmountPaid", DbMgr.CreateDoubleFieldEntry(_obj.AmountPaid));
            }
            if (multi_currency_support)
            {
                query_map.Add("CurrencyCode", DbMgr.CreateStringFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion && _sale.Currency != null ? _sale.Currency.CurrencyCode : ""));
                query_map.Add("ExchangeRate", DbMgr.CreateDoubleFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion ? _sale.TransactionExchangeRate : 0));
            }
            query_map.Add("PaymentIsDue", DbMgr.CreateIntFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.PaymentIsDue : 0));
            query_map.Add("DiscountDays", DbMgr.CreateIntFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.DiscountDays : 0));
            query_map.Add("BalanceDueDays", DbMgr.CreateIntFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.BalanceDueDays : 0));
            query_map.Add("PercentDiscount", DbMgr.CreateDoubleFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.EarlyPaymentDiscountPercent : 0));
            query_map.Add("PercentMonthlyCharge", DbMgr.CreateDoubleFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.LatePaymentChargePercent : 0));
            query_map.Add("ReferralSource", DbMgr.CreateStringFieldEntry(is_header && _sale.ReferralSource != null ? _sale.ReferralSource.Description : ""));
            #endregion

            #region Populate Line Information
            query_map.Add("AccountNumber", !is_header ? GetAccountNumber(_line.Account) : DbMgr.CreateStringFieldEntry(""));
            query_map.Add("Description", DbMgr.CreateStringFieldEntry(!is_header ? _line.Description : ""));
            query_map.Add("ExTaxAmount", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.TaxExclusiveAmount : 0));
            query_map.Add("IncTaxAmount", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.TaxInclusiveAmount : 0));
            query_map.Add("Job", DbMgr.CreateStringFieldEntry(!is_header && _line.Job != null ? _line.Job.JobName : ""));
            query_map.Add("TaxCode", DbMgr.CreateStringFieldEntry(!is_header && _line.TaxCode != null ? _line.TaxCode.Code : ""));
            query_map.Add("DetailDate", !is_header && _line.LineDate != null ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_line.LineDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            #endregion

            return query_map;
        }

        private string GetQuery_StoreProfessionalSaleLines(Sale _sale)
        {
            List<Dictionary<string, DbFieldEntry>> query_matrix = new List<Dictionary<string, DbFieldEntry>>();
            Dictionary<string, DbFieldEntry> query_header = GetQueryMap_StoreProfessionalSaleLines(_sale, null);

            foreach (ProfessionalSaleLine _line in _sale.SaleLines)
            {
                    Dictionary<string, DbFieldEntry> query_map = GetQueryMap_StoreProfessionalSaleLines(_sale, _line);
                    query_matrix.Add(query_map);
            }

            string query = "";
            if (query_matrix.Count != 0)
            {
                query = GetQuery(query_header, query_matrix, "Import_Professional_Sales");
            }
            return query;
        }
        #endregion

        #region ServiceSaleLines
        private Dictionary<string, DbFieldEntry> GetQueryMap_StoreServiceSaleLines(Sale _sale, ServiceSaleLine _line)
        {
            bool is_header = (_line == null);
            Dictionary<string, DbFieldEntry> query_map = new Dictionary<string, DbFieldEntry>();

            bool multi_currency_support = _sale.RepositoryMgr.CurrencyMgr.SupportMultiCurrency;

            #region Populate Sale Information
            query_map.Add("FirstName", DbMgr.CreateStringFieldEntry(is_header && _sale.Customer != null ? _sale.Customer.FirstName : ""));
            query_map.Add("CoLastName", DbMgr.CreateStringFieldEntry(is_header && _sale.Customer != null ? _sale.Customer.LastName : ""));
            query_map.Add("CardID", DbMgr.CreateStringFieldEntry(is_header && _sale.Customer != null ? _sale.Customer.CardIdentification : ""));
            query_map.Add("InvoiceNumber", DbMgr.CreateStringFieldEntry(is_header ? _sale.InvoiceNumber : ""));
            query_map.Add("Memo", DbMgr.CreateStringFieldEntry(is_header ? _sale.Memo : ""));
            query_map.Add("Inclusive", DbMgr.CreateStringFieldEntry(is_header && _sale.IsTaxInclusive == "Y" ? "1" : ""));
            query_map.Add("SaleDate", _sale.InvoiceDate != null && is_header ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_sale.InvoiceDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("DeliveryStatus", DbMgr.CreateStringFieldEntry(is_header & _sale.InvoiceDelivery != null ? _sale.InvoiceDelivery.InvoiceDeliveryID : ""));
            query_map.Add("ShippingDate", is_header && _sale.PromisedDate != null ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_sale.PromisedDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("Comment", DbMgr.CreateStringFieldEntry(is_header && _sale.Comment != null ? _sale.Comment : ""));
            query_map.Add("SalespersonLastName", DbMgr.CreateStringFieldEntry(is_header && _sale.SalesPerson != null ? _sale.SalesPerson.LastName : ""));
            query_map.Add("SalespersonFirstName", DbMgr.CreateStringFieldEntry(is_header && _sale.SalesPerson != null ? _sale.SalesPerson.FirstName : ""));

            string sale_status_text = "";
            Status sale_status = _sale.InvoiceStatus;
            if (is_header && sale_status != null)
            {
                if (sale_status.Type == Status.StatusType.Quote)
                {
                    sale_status_text = "Q";
                }
                else if (sale_status.Type == Status.StatusType.Order)
                {
                    sale_status_text = "O";
                }
                else if (sale_status.Type == Status.StatusType.Open)
                {
                    sale_status_text = "I";
                }
            }
            query_map.Add("SaleStatus", DbMgr.CreateStringFieldEntry(sale_status_text));

            if (_sale.InvoiceStatus.Type == Accounting.Core.Definitions.Status.StatusType.Order
                   || _sale.InvoiceStatus.Type == Accounting.Core.Definitions.Status.StatusType.Open
                   )
            {
                //sqlArray.Add("AmountPaid", DbMgr.CreateDoubleFieldEntry(_obj.AmountPaid));
            }
            if (multi_currency_support)
            {
                query_map.Add("CurrencyCode", DbMgr.CreateStringFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion && _sale.Currency != null ? _sale.Currency.CurrencyCode : ""));
                query_map.Add("ExchangeRate", DbMgr.CreateDoubleFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion ? _sale.TransactionExchangeRate : 0));
            }
            query_map.Add("PaymentIsDue", DbMgr.CreateIntFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.PaymentIsDue : 0));
            query_map.Add("DiscountDays", DbMgr.CreateIntFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.DiscountDays : 0));
            query_map.Add("BalanceDueDays", DbMgr.CreateIntFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.BalanceDueDays : 0));
            query_map.Add("PercentDiscount", DbMgr.CreateDoubleFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.EarlyPaymentDiscountPercent : 0));
            query_map.Add("PercentMonthlyCharge", DbMgr.CreateDoubleFieldEntry(is_header && _sale.Terms != null ? _sale.Terms.LatePaymentChargePercent : 0));
            query_map.Add("ReferralSource", DbMgr.CreateStringFieldEntry(is_header && _sale.ReferralSource != null ? _sale.ReferralSource.Description : ""));
            query_map.Add("AddressLine1", DbMgr.CreateStringFieldEntry(is_header ? _sale.ShipToAddressLine1 : ""));
            query_map.Add("AddressLine2", DbMgr.CreateStringFieldEntry(is_header ? _sale.ShipToAddressLine2 : ""));
            query_map.Add("AddressLine3", DbMgr.CreateStringFieldEntry(is_header ? _sale.ShipToAddressLine3 : ""));
            query_map.Add("AddressLine4", DbMgr.CreateStringFieldEntry(is_header ? _sale.ShipToAddressLine4 : ""));
            query_map.Add("ShipVia", DbMgr.CreateStringFieldEntry(is_header && _sale.ShippingMethod != null ? _sale.ShippingMethod.Method : ""));
            query_map.Add("FreightExTaxAmount", DbMgr.CreateDoubleFieldEntry(is_header ? _sale.TaxExclusiveFreight : 0));
            query_map.Add("FreightIncTaxAmount", DbMgr.CreateDoubleFieldEntry(is_header ? _sale.TaxInclusiveFreight : 0));
            query_map.Add("FreightTaxCode", DbMgr.CreateStringFieldEntry(is_header && _sale.FreightTaxCode != null ? _sale.FreightTaxCode.Code : ""));
            #endregion

            #region Populate Line Information
            query_map.Add("AccountNumber", !is_header ? GetAccountNumber(_line.Account) : DbMgr.CreateStringFieldEntry(""));
            query_map.Add("Description", DbMgr.CreateStringFieldEntry(!is_header ? _line.Description : ""));
            query_map.Add("ExTaxAmount", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.TaxExclusiveAmount : 0));
            query_map.Add("IncTaxAmount", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.TaxInclusiveAmount : 0));
            query_map.Add("Job", DbMgr.CreateStringFieldEntry(!is_header && _line.Job != null ? _line.Job.JobName : ""));
            query_map.Add("TaxCode", DbMgr.CreateStringFieldEntry(!is_header && _line.TaxCode != null ? _line.TaxCode.Code : ""));
            #endregion

            return query_map;
        }

        private string GetQuery_StoreServiceSaleLines(Sale _sale)
        {
            List<Dictionary<string, DbFieldEntry>> query_matrix = new List<Dictionary<string, DbFieldEntry>>();
            Dictionary<string, DbFieldEntry> query_header = GetQueryMap_StoreServiceSaleLines(_sale, null);

            foreach (ServiceSaleLine _line in _sale.SaleLines)
            {
                    Dictionary<string, DbFieldEntry> query_map = GetQueryMap_StoreServiceSaleLines(_sale, _line);
                    query_matrix.Add(query_map);
            }

            string query = "";
            if (query_matrix.Count != 0)
            {
                query = GetQuery(query_header, query_matrix, "Import_Service_Sales");
            }
            return query;
        }
        #endregion

        #region Convert the string-version of AccountNumber to integer-version of AccountNumber
        public bool AccountNumber2Int(string account_number_text, out int account_number_numeric)
        {
            account_number_text = account_number_text.Replace("-", "");
            return int.TryParse(account_number_text, out account_number_numeric);
        }

        public DbFieldEntry GetAccountNumber(Account acc)
        {
             if(acc != null)
             {
                 int account_number=0;
                 if(AccountNumber2Int(acc.AccountNumber, out account_number))
                 {
                     return DbMgr.CreateIntFieldEntry(account_number);
                 }
                 else
                 {
                     return DbMgr.CreateStringFieldEntry("");
                 }
             }
             return DbMgr.CreateStringFieldEntry("");
        }
        #endregion

        private string GetQuery(Dictionary<string, DbFieldEntry> query_header, List<Dictionary<string, DbFieldEntry>> query_matrix, string table_name)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("INSERT INTO {0} (", DbMgr.FieldAlias(table_name));

            bool first_column = true;
            foreach (string columnname in query_header.Keys)
            {
                if (first_column)
                {
                    sb.AppendFormat("{0}", DbMgr.FieldAlias(columnname));
                    first_column = false;
                }
                else
                {
                    sb.AppendFormat(", {0}", DbMgr.FieldAlias(columnname));
                }
            }

            sb.Append(") VALUES (");

            first_column = true;
            foreach (string columnname in query_header.Keys)
            {
                if (first_column)
                {
                    sb.AppendFormat("({0}", query_header[columnname]);
                    first_column = false;
                }
                else
                {
                    sb.AppendFormat(", {0}", query_header[columnname]);
                }
            }
            sb.Append(")");


            foreach (Dictionary<string, DbFieldEntry> query_map in query_matrix)
            {
                first_column = true;
                foreach (string columnname in query_map.Keys)
                {
                    if (first_column)
                    {
                        sb.AppendFormat(", ({0}", query_map[columnname]);
                        first_column = false;
                    }
                    else
                    {
                        sb.AppendFormat(", {0}", query_map[columnname]);
                    }
                }
                sb.Append(")");
            }

            sb.Append(")");

            return sb.ToString();
        }
    }
}
