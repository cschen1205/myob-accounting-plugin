using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Db.Myob
{
    using Accounting.Core;
    using Accounting.Core.Sales;
    using Accounting.Core.Inventory;
    using Accounting.Core.Cards;
    using Accounting.Db;
    using Accounting.Db.Elements;
    using System.Data.Odbc;
    using System.Data.Common;

    public class DbItemSaleLineManager : ItemSaleLineManager
    {
        public DbItemSaleLineManager(DbManager mgr)
            : base(mgr)
        {
           
        }

        private DbInsertStatement GetInsertStatement(ItemSaleLine _obj)
        {
            Sale _sale = _obj.Sale;

            DbInsertStatement clause = DbMgr.CreateInsertClause();

            if (_sale.Customer != null)
            {
                clause.InsertColumn("FirstName", DbMgr.CreateStringFieldEntry(_sale.Customer.FirstName));
                clause.InsertColumn("CoLastName", DbMgr.CreateStringFieldEntry(_sale.Customer.LastName));
                clause.InsertColumn("CardID", DbMgr.CreateStringFieldEntry(_sale.Customer.CardIdentification));
            }
            clause.InsertColumn("AddressLine1", DbMgr.CreateStringFieldEntry(_sale.ShipToAddressLine1));
            clause.InsertColumn("AddressLine2", DbMgr.CreateStringFieldEntry(_sale.ShipToAddressLine2));
            clause.InsertColumn("AddressLine3", DbMgr.CreateStringFieldEntry(_sale.ShipToAddressLine3));
            clause.InsertColumn("AddressLine4", DbMgr.CreateStringFieldEntry(_sale.ShipToAddressLine4));

            if (_sale.IsTaxInclusive == "Y")
            {
                clause.InsertColumn("Inclusive", DbMgr.CreateIntFieldEntry(1));
            }

            clause.InsertColumn("InvoiceNumber", DbMgr.CreateStringFieldEntry(_sale.InvoiceNumber));

            if (_sale.InvoiceDate != null)
            {
                clause.InsertColumn("SaleDate", DbMgr.CreateDateTimeFieldEntry(_sale.InvoiceDate));
            }

            if (_sale.ShippingMethod != null)
            {
                clause.InsertColumn("ShipVia", DbMgr.CreateStringFieldEntry(_sale.ShippingMethod.Method));
            }

            if (_obj.Item != null)
            {
                clause.InsertColumn("ItemNumber", DbMgr.CreateStringFieldEntry(_obj.Item.ItemNumber));
            }

            if (_sale.InvoiceDelivery != null)
            {
                clause.InsertColumn("DeliveryStatus", DbMgr.CreateStringFieldEntry(_sale.InvoiceDelivery.InvoiceDeliveryID));
            }

            clause.InsertColumn("Quantity", DbMgr.CreateDoubleFieldEntry(_obj.Quantity));

            clause.InsertColumn("Description", DbMgr.CreateStringFieldEntry(_obj.Description));

            clause.InsertColumn("ExTaxPrice", DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveUnitPrice));
            clause.InsertColumn("IncTaxPrice", DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveUnitPrice));

            clause.InsertColumn("Discount", DbMgr.CreateDoubleFieldEntry(_obj.Discount));

            clause.InsertColumn("ExTaxTotal", DbMgr.CreateDoubleFieldEntry(_obj.TaxExclusiveTotal));
            clause.InsertColumn("IncTaxTotal", DbMgr.CreateDoubleFieldEntry(_obj.TaxInclusiveTotal));

            if (_obj.Job != null)
            {
                clause.InsertColumn("Job", DbMgr.CreateStringFieldEntry(_obj.Job.JobName));
            }

            if (_sale.Comment != null)
            {
                clause.InsertColumn("Comment", DbMgr.CreateStringFieldEntry(_sale.Comment));
            }

            clause.InsertColumn("Memo", DbMgr.CreateStringFieldEntry(_sale.Memo));

            if (_sale.SalesPerson != null)
            {
                clause.InsertColumn("SalespersonLastName", DbMgr.CreateStringFieldEntry(_sale.SalesPerson.LastName));
                clause.InsertColumn("SalespersonFirstName", DbMgr.CreateStringFieldEntry(_sale.SalesPerson.FirstName));
            }

            if (_sale.PromisedDate != null)
            {
                clause.InsertColumn("ShippingDate", DbMgr.CreateDateTimeFieldEntry(_sale.PromisedDate));
            }

            if (_obj.TaxCode != null)
            {
                clause.InsertColumn("TaxCode", DbMgr.CreateStringFieldEntry(_obj.TaxCode.Code));
            }

            clause.InsertColumn("FreightExTaxAmount", DbMgr.CreateDoubleFieldEntry(_sale.TaxExclusiveFreight));
            clause.InsertColumn("FreightIncTaxAmount", DbMgr.CreateDoubleFieldEntry(_sale.TaxInclusiveFreight));

            if (_sale.FreightTaxCode != null)
            {
                clause.InsertColumn("FreightTaxCode", DbMgr.CreateStringFieldEntry(_sale.FreightTaxCode.Code));
            }

            if (_sale.InvoiceStatus != null)
            {
                clause.InsertColumn("SaleStatus", DbMgr.CreateStringFieldEntry(_sale.InvoiceStatus.StatusID));

                if (_sale.InvoiceStatus.Type == Accounting.Core.Definitions.Status.StatusType.Order
                    || _sale.InvoiceStatus.Type == Accounting.Core.Definitions.Status.StatusType.Open
                    )
                {
                    //clause.InsertColumn("AmountPaid", DbMgr.CreateDoubleFieldEntry(_obj.AmountPaid));
                }
            }

            if (RepositoryMgr.IsMultiUserVersion)
            {
                if (_sale.Currency != null)
                {
                    clause.InsertColumn("CurrencyCode", DbMgr.CreateStringFieldEntry(_sale.Currency.CurrencyCode));
                }
                clause.InsertColumn("ExchangeRate", DbMgr.CreateDoubleFieldEntry(_sale.TransactionExchangeRate));
            }

            if (_sale.Terms != null)
            {
                clause.InsertColumn("PaymentIsDue", DbMgr.CreateIntFieldEntry(_sale.Terms.PaymentIsDue));
                clause.InsertColumn("DiscountDays", DbMgr.CreateIntFieldEntry(_sale.Terms.DiscountDays));
                clause.InsertColumn("BalanceDueDays", DbMgr.CreateIntFieldEntry(_sale.Terms.BalanceDueDays));
                clause.InsertColumn("PercentDiscount", DbMgr.CreateDoubleFieldEntry(_sale.Terms.EarlyPaymentDiscountPercent));
                clause.InsertColumn("PercentMonthlyCharge", DbMgr.CreateDoubleFieldEntry(_sale.Terms.LatePaymentChargePercent));
            }

            if (_sale.ReferralSource != null)
            {
                clause.InsertColumn("ReferralSource", DbMgr.CreateStringFieldEntry(_sale.ReferralSource.Description));
            }

            clause.Into("Import_Item_Sales");

            return clause;
        }
        protected override OpResult _Store(ItemSaleLine _obj)
        {
            if (_obj == null) return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "ItemSaleLine object cannot be created as it is null");

            bool is_creating = !Exists(_obj);

            DbInsertStatement clause=GetInsertStatement(_obj);

            DbCommand cmdSQLInsert = CreateDbCommand(clause);
            DbTransaction myTrans = DbMgr.DbConnection.BeginTransaction();
            try
            {
                cmdSQLInsert.CommandText = clause.ToString();
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
    }
}
