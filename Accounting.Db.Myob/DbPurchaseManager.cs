using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Db.Myob
{
    using Accounting.Core;
    using System.Data.Common;
    using System.Data.Odbc;
    using Accounting.Core.Purchases;
    using Accounting.Core.Inventory;
    using Accounting.Core.Cards;
    using Accounting.Core.Accounts;
    using Accounting.Core.Definitions;
    using Accounting.Db;
    using Accounting.Db.Elements;

    public class DbPurchaseManager : PurchaseManager
    {
        public DbPurchaseManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override OpResult _Store(Purchase _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "Purchase object cannot be created as it is null");
            }

            //bool is_creating = !Exists(_obj);

            //if (is_creating)
            //{
            //    RepositoryMgr.MiscNumberMgr.SavePurchaseNumber(_obj.PurchaseNumber);
            //}
            RepositoryMgr.MiscNumberMgr.SavePurchaseNumber(_obj.PurchaseNumber);

            string query = "";

            if (_obj.PurchaseType != null)
            {
                if (_obj.PurchaseType.IsProfessional)
                {
                    query = GetQuery_StoreProfessionalPurchaseLines(_obj);
                }
                else if (_obj.PurchaseType.IsTimeBilling)
                {
                    query = GetQuery_StoreTimeBillingPurchaseLines(_obj);
                }
                else if (_obj.PurchaseType.IsService)
                {
                    query = GetQuery_StoreServicePurchaseLines(_obj);
                }
                else if (_obj.PurchaseType.IsItem)
                {
                    query = GetQuery_StoreItemPurchaseLines(_obj);
                }
                else if (_obj.PurchaseType.IsMisc)
                {
                    query = GetQuery_StoreMiscellaneousPurchaseLines(_obj);
                }
            }

            if (string.IsNullOrEmpty(query))
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.CreateFailedOnCriteria, _obj, "Purchase object does not have any PurchaseLine");
                //if (is_creating)
                //{
                //    return OpResult.NotifyStoreAction(OpResult.ResultStatus.CreateFailedOnCriteria, _obj, "Sale object does not have any SaleLines");
                //}
                //return OpResult.NotifyStoreAction(OpResult.ResultStatus.UpdateFailedOnCriteria, _obj, "Sale object does not have any SaleLines");
            }

            Console.WriteLine(query);

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
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.CreatedWithException, _obj, ex.ToString());
                //if (is_creating)
                //{
                //    return OpResult.NotifyStoreAction(OpResult.ResultStatus.CreatedWithException, _obj, ex.ToString());
                //}
                //return OpResult.NotifyStoreAction(OpResult.ResultStatus.UpdatedWithException, _obj, ex.ToString());
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                Console.WriteLine(ex.ToString());
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.CreatedWithException, _obj, ex.ToString());
                //if (is_creating)
                //{
                //    return OpResult.NotifyStoreAction(OpResult.ResultStatus.CreatedWithException, _obj, ex.ToString());
                //}
                //return OpResult.NotifyStoreAction(OpResult.ResultStatus.UpdatedWithException, _obj, ex.ToString());
            }

            _obj.FromDb = true;

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
            //if (is_creating)
            //{
            //    return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
            //}
            //return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
        }

        #region ItemPurchaseLines
        private Dictionary<string, DbFieldEntry> GetQueryMap_StoreItemPurchaseLines(Purchase _purchase, ItemPurchaseLine _line)
        {
            bool is_header = (_line == null);
            Dictionary<string, DbFieldEntry> query_map = new Dictionary<string, DbFieldEntry>();

            bool multi_currency_support = _purchase.RepositoryMgr.CurrencyMgr.SupportMultiCurrency;

            #region Populate Purchase Information
            query_map.Add("FirstName", DbMgr.CreateStringFieldEntry(is_header && _purchase.Supplier != null ? _purchase.Supplier.FirstName : ""));
            query_map.Add("CoLastName", DbMgr.CreateStringFieldEntry(is_header && _purchase.Supplier != null ? _purchase.Supplier.LastName : ""));
            query_map.Add("CardID", DbMgr.CreateStringFieldEntry(is_header && _purchase.Supplier != null ? _purchase.Supplier.CardIdentification : ""));
            query_map.Add("AddressLine1", DbMgr.CreateStringFieldEntry(is_header ? _purchase.ShipToAddressLine1 : ""));
            query_map.Add("AddressLine2", DbMgr.CreateStringFieldEntry(is_header ? _purchase.ShipToAddressLine2 : ""));
            query_map.Add("AddressLine3", DbMgr.CreateStringFieldEntry(is_header ? _purchase.ShipToAddressLine3 : ""));
            query_map.Add("AddressLine4", DbMgr.CreateStringFieldEntry(is_header ? _purchase.ShipToAddressLine4 : ""));
            query_map.Add("PurchaseNumber", DbMgr.CreateStringFieldEntry(is_header ? _purchase.PurchaseNumber : ""));
            query_map.Add("Memo", DbMgr.CreateStringFieldEntry(is_header ? _purchase.Memo : ""));
            query_map.Add("Inclusive", DbMgr.CreateStringFieldEntry(is_header && _purchase.IsTaxInclusive == "Y" ? "1" : ""));
            query_map.Add("PurchaseDate", _purchase.PurchaseDate != null && is_header ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_purchase.PurchaseDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("ShipVia", DbMgr.CreateStringFieldEntry(is_header && _purchase.ShippingMethod != null ? _purchase.ShippingMethod.Method : ""));
            query_map.Add("DeliveryStatus", DbMgr.CreateStringFieldEntry(is_header & _purchase.InvoiceDelivery != null ? _purchase.InvoiceDelivery.InvoiceDeliveryID : ""));
            query_map.Add("Comment", DbMgr.CreateStringFieldEntry(is_header && _purchase.Comment != null ? _purchase.Comment : ""));
            query_map.Add("ShippingDate", is_header && _purchase.PromisedDate != null ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_purchase.PromisedDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("FreightExTaxAmount", DbMgr.CreateDoubleFieldEntry(is_header ? _purchase.TaxExclusiveFreight : 0));
            query_map.Add("FreightIncTaxAmount", DbMgr.CreateDoubleFieldEntry(is_header ? _purchase.TaxInclusiveFreight : 0));
            query_map.Add("FreightTaxCode", DbMgr.CreateStringFieldEntry(is_header && _purchase.FreightTaxCode != null ? _purchase.FreightTaxCode.Code : ""));

           
            string purchase_status_text="";
            Status purchase_status = _purchase.PurchaseStatus;
            if(is_header && purchase_status != null)
            {
                if(purchase_status.Type==Status.StatusType.Quote)
                {
                    purchase_status_text="Q";
                }
                else if (purchase_status.Type == Status.StatusType.Order)
                {
                    purchase_status_text = "O";
                }
                else if (purchase_status.Type == Status.StatusType.Open)
                {
                    purchase_status_text = "B";
                }
            }
            query_map.Add("PurchaseStatus", DbMgr.CreateStringFieldEntry(purchase_status_text));

            if (_purchase.PurchaseStatus.Type == Accounting.Core.Definitions.Status.StatusType.Order
                   || _purchase.PurchaseStatus.Type == Accounting.Core.Definitions.Status.StatusType.Open
                   )
            {
                //sqlArray.Add("AmountPaid", DbMgr.CreateDoubleFieldEntry(_obj.AmountPaid));
            }

            if (multi_currency_support)
            {
                query_map.Add("CurrencyCode", DbMgr.CreateStringFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion && _purchase.Currency != null ? _purchase.Currency.CurrencyCode : ""));
                query_map.Add("ExchangeRate", DbMgr.CreateDoubleFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion ? _purchase.TransactionExchangeRate : 0));
            }
            query_map.Add("PaymentIsDue", DbMgr.CreateIntFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.PaymentIsDue : 0));
            query_map.Add("DiscountDays", DbMgr.CreateIntFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.DiscountDays : 0));
            query_map.Add("BalanceDueDays", DbMgr.CreateIntFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.BalanceDueDays : 0));
            query_map.Add("PercentDiscount", DbMgr.CreateDoubleFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.EarlyPaymentDiscountPercent : 0));
            //query_map.Add("PercentMonthlyCharge", DbMgr.CreateDoubleFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.LatePaymentChargePercent : 0));
            #endregion

            #region Populate Line Information
            query_map.Add("ItemNumber", DbMgr.CreateStringFieldEntry(!is_header && _line.Item != null ? _line.Item.ItemNumber : ""));
            query_map.Add("Quantity", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.Quantity : 0));
            if (purchase_status != null)
            {
                if (purchase_status.Type == Status.StatusType.Quote)
                {
                }
                else if (purchase_status.Type == Status.StatusType.Order)
                {
                    query_map.Add("Ordered", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.Quantity : 0));
                }
                else if (purchase_status.Type == Status.StatusType.Open)
                {
                    query_map.Add("Billed", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.Quantity : 0));
                }
            }
            query_map.Add("Description", DbMgr.CreateStringFieldEntry(!is_header ? _line.Description : ""));
            query_map.Add("ExTaxPrice", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.TaxExclusiveUnitPrice : 0));
            query_map.Add("IncTaxPrice", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.TaxInclusiveUnitPrice : 0));
            query_map.Add("Discount", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.Discount : 0));
            query_map.Add("ExTaxTotal", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.TaxExclusiveTotal : 0));
            query_map.Add("IncTaxTotal", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.TaxInclusiveTotal : 0));
            query_map.Add("Job", DbMgr.CreateStringFieldEntry(!is_header && _line.Job != null ? _line.Job.JobName : ""));
            query_map.Add("TaxCode", DbMgr.CreateStringFieldEntry(!is_header && _line.TaxCode != null ? _line.TaxCode.Code : ""));
            query_map.Add("Received", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.Received : 0));
            #endregion

            return query_map;
        }

        private string GetQuery_StoreItemPurchaseLines(Purchase _purchase)
        {
            List<Dictionary<string, DbFieldEntry>> query_matrix = new List<Dictionary<string, DbFieldEntry>>();
            Dictionary<string, DbFieldEntry> query_header = GetQueryMap_StoreItemPurchaseLines(_purchase, null);

            foreach (ItemPurchaseLine _line in _purchase.PurchaseLines)
            {
                    Dictionary<string, DbFieldEntry> query_map = GetQueryMap_StoreItemPurchaseLines(_purchase, _line);
                    query_matrix.Add(query_map);
            }

            string query = "";
            if (query_matrix.Count != 0)
            {
                query = GetQuery(query_header, query_matrix, "Import_Item_Purchases");
            }
            return query;
        }
        #endregion

        #region MiscPurchaseLines
        private Dictionary<string, DbFieldEntry> GetQueryMap_StoreMiscellaneousPurchaseLines(Purchase _purchase, MiscPurchaseLine _line)
        {
            bool is_header = (_line == null);
            Dictionary<string, DbFieldEntry> query_map = new Dictionary<string, DbFieldEntry>();

            bool multi_currency_support = _purchase.RepositoryMgr.CurrencyMgr.SupportMultiCurrency;

            #region Populate Purchase Information
            query_map.Add("FirstName", DbMgr.CreateStringFieldEntry(is_header && _purchase.Supplier != null ? _purchase.Supplier.FirstName : ""));
            query_map.Add("CoLastName", DbMgr.CreateStringFieldEntry(is_header && _purchase.Supplier != null ? _purchase.Supplier.LastName : ""));
            query_map.Add("CardID", DbMgr.CreateStringFieldEntry(is_header && _purchase.Supplier != null ? _purchase.Supplier.CardIdentification : ""));
            query_map.Add("PurchaseNumber", DbMgr.CreateStringFieldEntry(is_header ? _purchase.PurchaseNumber : ""));
            query_map.Add("Memo", DbMgr.CreateStringFieldEntry(is_header ? _purchase.Memo : ""));
            query_map.Add("Inclusive", DbMgr.CreateStringFieldEntry(is_header && _purchase.IsTaxInclusive == "Y" ? "1" : ""));
            query_map.Add("PurchaseDate", _purchase.PurchaseDate != null && is_header ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_purchase.PurchaseDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            //query_map.Add("DeliveryStatus", DbMgr.CreateStringFieldEntry(is_header & _purchase.InvoiceDelivery != null ? _purchase.InvoiceDelivery.InvoiceDeliveryID : ""));
            //query_map.Add("Comment", DbMgr.CreateStringFieldEntry(is_header && _purchase.Comment != null ? _purchase.Comment : ""));

            string purchase_status_text = "";
            Status purchase_status = _purchase.PurchaseStatus;
            if (is_header && purchase_status != null)
            {
                if (purchase_status.Type == Status.StatusType.Quote)
                {
                    purchase_status_text = "Q";
                }
                else if (purchase_status.Type == Status.StatusType.Order)
                {
                    purchase_status_text = "O";
                }
                else if (purchase_status.Type == Status.StatusType.Open)
                {
                    purchase_status_text = "B";
                }
            }
            query_map.Add("PurchaseStatus", DbMgr.CreateStringFieldEntry(purchase_status_text));

            if (_purchase.PurchaseStatus.Type == Accounting.Core.Definitions.Status.StatusType.Order
                   || _purchase.PurchaseStatus.Type == Accounting.Core.Definitions.Status.StatusType.Open
                   )
            {
                //sqlArray.Add("AmountPaid", DbMgr.CreateDoubleFieldEntry(_obj.AmountPaid));
            }
            if (multi_currency_support)
            {
                query_map.Add("CurrencyCode", DbMgr.CreateStringFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion && _purchase.Currency != null ? _purchase.Currency.CurrencyCode : ""));
                query_map.Add("ExchangeRate", DbMgr.CreateDoubleFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion ? _purchase.TransactionExchangeRate : 0));
            }
            query_map.Add("PaymentIsDue", DbMgr.CreateIntFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.PaymentIsDue : 0));
            query_map.Add("DiscountDays", DbMgr.CreateIntFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.DiscountDays : 0));
            query_map.Add("BalanceDueDays", DbMgr.CreateIntFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.BalanceDueDays : 0));
            query_map.Add("PercentDiscount", DbMgr.CreateDoubleFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.EarlyPaymentDiscountPercent : 0));
            //query_map.Add("PercentMonthlyCharge", DbMgr.CreateDoubleFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.LatePaymentChargePercent : 0));
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

        private string GetQuery_StoreMiscellaneousPurchaseLines(Purchase _purchase)
        {
            List<Dictionary<string, DbFieldEntry>> query_matrix = new List<Dictionary<string, DbFieldEntry>>();
            Dictionary<string, DbFieldEntry> query_header = GetQueryMap_StoreMiscellaneousPurchaseLines(_purchase, null);

            foreach (MiscPurchaseLine _line in _purchase.PurchaseLines)
            {
                    Dictionary<string, DbFieldEntry> query_map = GetQueryMap_StoreMiscellaneousPurchaseLines(_purchase, _line);
                    query_matrix.Add(query_map);
             
            }

            string query = "";
            if (query_matrix.Count != 0)
            {
                query = GetQuery(query_header, query_matrix, "Import_Miscellaneous_Purchases");
            }
            return query;
        }
        #endregion

        #region TimeBillingPurchaseLines
        private Dictionary<string, DbFieldEntry> GetQueryMap_StoreTimeBillingPurchaseLines(Purchase _purchase, TimeBillingPurchaseLine _line)
        {
            bool is_header = (_line == null);
            Dictionary<string, DbFieldEntry> query_map = new Dictionary<string, DbFieldEntry>();

            bool multi_currency_support = _purchase.RepositoryMgr.CurrencyMgr.SupportMultiCurrency;

            #region Populate Purchase Information
            query_map.Add("FirstName", DbMgr.CreateStringFieldEntry(is_header && _purchase.Supplier != null ? _purchase.Supplier.FirstName : ""));
            query_map.Add("CoLastName", DbMgr.CreateStringFieldEntry(is_header && _purchase.Supplier != null ? _purchase.Supplier.LastName : ""));
            query_map.Add("CardID", DbMgr.CreateStringFieldEntry(is_header && _purchase.Supplier != null ? _purchase.Supplier.CardIdentification : ""));
            query_map.Add("PurchaseNumber", DbMgr.CreateStringFieldEntry(is_header ? _purchase.PurchaseNumber : ""));
            query_map.Add("Memo", DbMgr.CreateStringFieldEntry(is_header ? _purchase.Memo : ""));
            query_map.Add("AddressLine1", DbMgr.CreateStringFieldEntry(is_header ? _purchase.ShipToAddressLine1 : ""));
            query_map.Add("AddressLine2", DbMgr.CreateStringFieldEntry(is_header ? _purchase.ShipToAddressLine2 : ""));
            query_map.Add("AddressLine3", DbMgr.CreateStringFieldEntry(is_header ? _purchase.ShipToAddressLine3 : ""));
            query_map.Add("AddressLine4", DbMgr.CreateStringFieldEntry(is_header ? _purchase.ShipToAddressLine4 : ""));
            query_map.Add("ShipVia", DbMgr.CreateStringFieldEntry(is_header && _purchase.ShippingMethod != null ? _purchase.ShippingMethod.Method : ""));
            query_map.Add("FreightAmount", DbMgr.CreateDoubleFieldEntry(is_header ? _purchase.TaxExclusiveFreight : 0));
            query_map.Add("FreightTaxCode", DbMgr.CreateStringFieldEntry(is_header && _purchase.FreightTaxCode != null ? _purchase.FreightTaxCode.Code : ""));
            query_map.Add("Inclusive", DbMgr.CreateStringFieldEntry(is_header && _purchase.IsTaxInclusive == "Y" ? "1" : ""));
            query_map.Add("PurchaseDate", _purchase.PurchaseDate != null && is_header ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_purchase.PurchaseDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("DeliveryStatus", DbMgr.CreateStringFieldEntry(is_header & _purchase.InvoiceDelivery != null ? _purchase.InvoiceDelivery.InvoiceDeliveryID : ""));
            query_map.Add("PromisedDate", is_header && _purchase.PromisedDate != null ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_purchase.PromisedDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("Comment", DbMgr.CreateStringFieldEntry(is_header && _purchase.Comment != null ? _purchase.Comment : ""));

            string purchase_status_text = "";
            Status purchase_status = _purchase.PurchaseStatus;
            if (is_header && purchase_status != null)
            {
                if (purchase_status.Type == Status.StatusType.Quote)
                {
                    purchase_status_text = "Q";
                }
                else if (purchase_status.Type == Status.StatusType.Order)
                {
                    purchase_status_text = "O";
                }
                else if (purchase_status.Type == Status.StatusType.Open)
                {
                    purchase_status_text = "B";
                }
            }
            query_map.Add("PurchaseStatus", DbMgr.CreateStringFieldEntry(purchase_status_text));

            if (_purchase.PurchaseStatus.Type == Accounting.Core.Definitions.Status.StatusType.Order
                   || _purchase.PurchaseStatus.Type == Accounting.Core.Definitions.Status.StatusType.Open
                   )
            {
                //sqlArray.Add("AmountPaid", DbMgr.CreateDoubleFieldEntry(_obj.AmountPaid));
            }

            if (multi_currency_support)
            {
                query_map.Add("CurrencyCode", DbMgr.CreateStringFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion && _purchase.Currency != null ? _purchase.Currency.CurrencyCode : ""));
                query_map.Add("ExchangeRate", DbMgr.CreateDoubleFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion ? _purchase.TransactionExchangeRate : 0));
            }
            query_map.Add("PaymentIsDue", DbMgr.CreateIntFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.PaymentIsDue : 0));
            query_map.Add("DiscountDays", DbMgr.CreateIntFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.DiscountDays : 0));
            query_map.Add("BalanceDueDays", DbMgr.CreateIntFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.BalanceDueDays : 0));
            query_map.Add("PercentDiscount", DbMgr.CreateDoubleFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.EarlyPaymentDiscountPercent : 0));
            //query_map.Add("PercentMonthlyCharge", DbMgr.CreateDoubleFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.LatePaymentChargePercent : 0));
            #endregion

            #region Populate Line Information
            query_map.Add("ActivityID", !is_header && _line.Activity != null ? (DbFieldEntry)DbMgr.CreateStringFieldEntry(_line.Activity.ActivityName) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("Description", DbMgr.CreateStringFieldEntry(!is_header ? _line.Description : ""));
            query_map.Add("ExTaxAmount", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.TaxExclusiveAmount : 0));
            query_map.Add("IncTaxAmount", DbMgr.CreateDoubleFieldEntry(!is_header ? _line.TaxInclusiveAmount : 0));
            query_map.Add("Job", DbMgr.CreateStringFieldEntry(!is_header && _line.Job != null ? _line.Job.JobName : ""));
            query_map.Add("TaxCode", DbMgr.CreateStringFieldEntry(!is_header && _line.TaxCode != null ? _line.TaxCode.Code : ""));
            query_map.Add("HoursUnits", !is_header ? (DbFieldEntry)DbMgr.CreateDoubleFieldEntry(_line.HoursUnits) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("Notes", (DbFieldEntry)DbMgr.CreateStringFieldEntry(!is_header ? _line.Description : ""));
            query_map.Add("DetailDate", !is_header && _line.LineDate != null ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_line.LineDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("Rate", !is_header ? (DbFieldEntry)DbMgr.CreateDoubleFieldEntry(_line.TaxInclusiveRate) : DbMgr.CreateStringFieldEntry(""));
            #endregion
            return query_map;
        }

        private string GetQuery_StoreTimeBillingPurchaseLines(Purchase _purchase)
        {
            List<Dictionary<string, DbFieldEntry>> query_matrix = new List<Dictionary<string, DbFieldEntry>>();
            Dictionary<string, DbFieldEntry> query_header = GetQueryMap_StoreTimeBillingPurchaseLines(_purchase, null);

            foreach (TimeBillingPurchaseLine _line in _purchase.PurchaseLines)
            {
                 Dictionary<string, DbFieldEntry> query_map = GetQueryMap_StoreTimeBillingPurchaseLines(_purchase, _line);
                 query_matrix.Add(query_map);
            }

            string query = "";
            if (query_matrix.Count != 0)
            {
                query = GetQuery(query_header, query_matrix, "Import_TimeBilling_Purchases");
            }
            return query;
        }
        #endregion

        #region ProfessionalPurchaseLines
        private Dictionary<string, DbFieldEntry> GetQueryMap_StoreProfessionalPurchaseLines(Purchase _purchase, ProfessionalPurchaseLine _line)
        {
            bool is_header = (_line == null);
            Dictionary<string, DbFieldEntry> query_map = new Dictionary<string, DbFieldEntry>();

            bool multi_currency_support = _purchase.RepositoryMgr.CurrencyMgr.SupportMultiCurrency;

            #region Populate Purchase Information
            query_map.Add("FirstName", DbMgr.CreateStringFieldEntry(is_header && _purchase.Supplier != null ? _purchase.Supplier.FirstName : ""));
            query_map.Add("CoLastName", DbMgr.CreateStringFieldEntry(is_header && _purchase.Supplier != null ? _purchase.Supplier.LastName : ""));
            query_map.Add("CardID", DbMgr.CreateStringFieldEntry(is_header && _purchase.Supplier != null ? _purchase.Supplier.CardIdentification : ""));
            query_map.Add("PurchaseNumber", DbMgr.CreateStringFieldEntry(is_header ? _purchase.PurchaseNumber : ""));
            query_map.Add("Memo", DbMgr.CreateStringFieldEntry(is_header ? _purchase.Memo : ""));
            query_map.Add("Inclusive", DbMgr.CreateStringFieldEntry(is_header && _purchase.IsTaxInclusive == "Y" ? "1" : ""));
            query_map.Add("PurchaseDate", _purchase.PurchaseDate != null && is_header ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_purchase.PurchaseDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("DeliveryStatus", DbMgr.CreateStringFieldEntry(is_header & _purchase.InvoiceDelivery != null ? _purchase.InvoiceDelivery.InvoiceDeliveryID : ""));
            query_map.Add("PromisedDate", is_header && _purchase.PromisedDate != null ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_purchase.PromisedDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("Comment", DbMgr.CreateStringFieldEntry(is_header && _purchase.Comment != null ? _purchase.Comment : ""));

            string purchase_status_text = "";
            Status purchase_status = _purchase.PurchaseStatus;
            if (is_header && purchase_status != null)
            {
                if (purchase_status.Type == Status.StatusType.Quote)
                {
                    purchase_status_text = "Q";
                }
                else if (purchase_status.Type == Status.StatusType.Order)
                {
                    purchase_status_text = "O";
                }
                else if (purchase_status.Type == Status.StatusType.Open)
                {
                    purchase_status_text = "B";
                }
            }
            query_map.Add("PurchaseStatus", DbMgr.CreateStringFieldEntry(purchase_status_text));

            if (_purchase.PurchaseStatus.Type == Accounting.Core.Definitions.Status.StatusType.Order
                   || _purchase.PurchaseStatus.Type == Accounting.Core.Definitions.Status.StatusType.Open
                   )
            {
                //sqlArray.Add("AmountPaid", DbMgr.CreateDoubleFieldEntry(_obj.AmountPaid));
            }

            if(multi_currency_support)
            {
                query_map.Add("CurrencyCode", DbMgr.CreateStringFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion && _purchase.Currency != null ? _purchase.Currency.CurrencyCode : ""));
                query_map.Add("ExchangeRate", DbMgr.CreateDoubleFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion ? _purchase.TransactionExchangeRate : 0));
            }
            query_map.Add("PaymentIsDue", DbMgr.CreateIntFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.PaymentIsDue : 0));
            query_map.Add("DiscountDays", DbMgr.CreateIntFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.DiscountDays : 0));
            query_map.Add("BalanceDueDays", DbMgr.CreateIntFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.BalanceDueDays : 0));
            query_map.Add("PercentDiscount", DbMgr.CreateDoubleFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.EarlyPaymentDiscountPercent : 0));
            //query_map.Add("PercentMonthlyCharge", DbMgr.CreateDoubleFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.LatePaymentChargePercent : 0));
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

        private string GetQuery_StoreProfessionalPurchaseLines(Purchase _purchase)
        {
            List<Dictionary<string, DbFieldEntry>> query_matrix = new List<Dictionary<string, DbFieldEntry>>();
            Dictionary<string, DbFieldEntry> query_header = GetQueryMap_StoreProfessionalPurchaseLines(_purchase, null);

            foreach (ProfessionalPurchaseLine _line in _purchase.PurchaseLines)
            {
                    Dictionary<string, DbFieldEntry> query_map = GetQueryMap_StoreProfessionalPurchaseLines(_purchase, _line);
                    query_matrix.Add(query_map);
            }

            string query = "";
            if (query_matrix.Count != 0)
            {
                query = GetQuery(query_header, query_matrix, "Import_Professional_Purchases");
            }
            return query;
        }
        #endregion

        #region ServicePurchaseLines
        private Dictionary<string, DbFieldEntry> GetQueryMap_StoreServicePurchaseLines(Purchase _purchase, ServicePurchaseLine _line)
        {
            bool is_header = (_line == null);
            Dictionary<string, DbFieldEntry> query_map = new Dictionary<string, DbFieldEntry>();

            bool multi_currency_support = _purchase.RepositoryMgr.CurrencyMgr.SupportMultiCurrency;

            #region Populate Purchase Information
            query_map.Add("FirstName", DbMgr.CreateStringFieldEntry(is_header && _purchase.Supplier != null ? _purchase.Supplier.FirstName : ""));
            query_map.Add("CoLastName", DbMgr.CreateStringFieldEntry(is_header && _purchase.Supplier != null ? _purchase.Supplier.LastName : ""));
            query_map.Add("CardID", DbMgr.CreateStringFieldEntry(is_header && _purchase.Supplier != null ? _purchase.Supplier.CardIdentification : ""));
            query_map.Add("PurchaseNumber", DbMgr.CreateStringFieldEntry(is_header ? _purchase.PurchaseNumber : ""));
            query_map.Add("Memo", DbMgr.CreateStringFieldEntry(is_header ? _purchase.Memo : ""));
            query_map.Add("Inclusive", DbMgr.CreateStringFieldEntry(is_header && _purchase.IsTaxInclusive == "Y" ? "1" : ""));
            query_map.Add("PurchaseDate", _purchase.PurchaseDate != null && is_header ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_purchase.PurchaseDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("DeliveryStatus", DbMgr.CreateStringFieldEntry(is_header & _purchase.InvoiceDelivery != null ? _purchase.InvoiceDelivery.InvoiceDeliveryID : ""));
            query_map.Add("ShippingDate", is_header && _purchase.PromisedDate != null ? (DbFieldEntry)DbMgr.CreateDateTimeFieldEntry(_purchase.PromisedDate) : (DbFieldEntry)DbMgr.CreateStringFieldEntry(""));
            query_map.Add("Comment", DbMgr.CreateStringFieldEntry(is_header && _purchase.Comment != null ? _purchase.Comment : ""));

            string purchase_status_text = "";
            Status purchase_status = _purchase.PurchaseStatus;
            if (is_header && purchase_status != null)
            {
                if (purchase_status.Type == Status.StatusType.Quote)
                {
                    purchase_status_text = "Q";
                }
                else if (purchase_status.Type == Status.StatusType.Order)
                {
                    purchase_status_text = "O";
                }
                else if (purchase_status.Type == Status.StatusType.Open)
                {
                    purchase_status_text = "B";
                }
            }
            query_map.Add("PurchaseStatus", DbMgr.CreateStringFieldEntry(purchase_status_text));

            if (_purchase.PurchaseStatus.Type == Accounting.Core.Definitions.Status.StatusType.Order
                   || _purchase.PurchaseStatus.Type == Accounting.Core.Definitions.Status.StatusType.Open
                   )
            {
                //sqlArray.Add("AmountPaid", DbMgr.CreateDoubleFieldEntry(_obj.AmountPaid));
            }

            if (multi_currency_support)
            {
                query_map.Add("CurrencyCode", DbMgr.CreateStringFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion && _purchase.Currency != null ? _purchase.Currency.CurrencyCode : ""));
                query_map.Add("ExchangeRate", DbMgr.CreateDoubleFieldEntry(is_header && RepositoryMgr.IsMultiUserVersion ? _purchase.TransactionExchangeRate : 0));
            }
            query_map.Add("PaymentIsDue", DbMgr.CreateIntFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.PaymentIsDue : 0));
            query_map.Add("DiscountDays", DbMgr.CreateIntFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.DiscountDays : 0));
            query_map.Add("BalanceDueDays", DbMgr.CreateIntFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.BalanceDueDays : 0));
            query_map.Add("PercentDiscount", DbMgr.CreateDoubleFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.EarlyPaymentDiscountPercent : 0));
            //query_map.Add("PercentMonthlyCharge", DbMgr.CreateDoubleFieldEntry(is_header && _purchase.Terms != null ? _purchase.Terms.LatePaymentChargePercent : 0));
            query_map.Add("AddressLine1", DbMgr.CreateStringFieldEntry(is_header ? _purchase.ShipToAddressLine1 : ""));
            query_map.Add("AddressLine2", DbMgr.CreateStringFieldEntry(is_header ? _purchase.ShipToAddressLine2 : ""));
            query_map.Add("AddressLine3", DbMgr.CreateStringFieldEntry(is_header ? _purchase.ShipToAddressLine3 : ""));
            query_map.Add("AddressLine4", DbMgr.CreateStringFieldEntry(is_header ? _purchase.ShipToAddressLine4 : ""));
            query_map.Add("ShipVia", DbMgr.CreateStringFieldEntry(is_header && _purchase.ShippingMethod != null ? _purchase.ShippingMethod.Method : ""));
            query_map.Add("FreightExTaxAmount", DbMgr.CreateDoubleFieldEntry(is_header ? _purchase.TaxExclusiveFreight : 0));
            query_map.Add("FreightIncTaxAmount", DbMgr.CreateDoubleFieldEntry(is_header ? _purchase.TaxInclusiveFreight : 0));
            query_map.Add("FreightTaxCode", DbMgr.CreateStringFieldEntry(is_header && _purchase.FreightTaxCode != null ? _purchase.FreightTaxCode.Code : ""));
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

        private string GetQuery_StoreServicePurchaseLines(Purchase _purchase)
        {
            List<Dictionary<string, DbFieldEntry>> query_matrix = new List<Dictionary<string, DbFieldEntry>>();
            Dictionary<string, DbFieldEntry> query_header = GetQueryMap_StoreServicePurchaseLines(_purchase, null);

            foreach (ServicePurchaseLine _line in _purchase.PurchaseLines)
            {
                    Dictionary<string, DbFieldEntry> query_map = GetQueryMap_StoreServicePurchaseLines(_purchase, _line);
                    query_matrix.Add(query_map);
            }

            string query = "";
            if (query_matrix.Count != 0)
            {
                query = GetQuery(query_header, query_matrix, "Import_Service_Purchases");
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
            if (acc != null)
            {
                int account_number=0;
                if (AccountNumber2Int(acc.AccountNumber, out account_number))
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
