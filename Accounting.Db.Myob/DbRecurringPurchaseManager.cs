using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.Odbc;

namespace Accounting.Db.Myob
{
    using Accounting.Core;
    using Accounting.Core.Purchases;
    using Accounting.Core.Inventory;
    using Accounting.Core.Cards;
    using Accounting.Db;

    public class DbRecurringPurchaseManager : RecurringPurchaseManager
    {
        /*
        private string GetQuery_SaveRecurringPurchaseByItem(RecurringPurchase _RecurringPurchase, Item _item, string _description, int _quantity)
        {
            Customer _customer = DbMgr.CustomerMgr.Retrieve(_RecurringPurchase.CardRecordID);

            //Step 0: Obtain the tax rate of the item 
            double tax_rate = _item.BuyTaxCode.TaxPercentageRate / 100.0;
            //Step 0: Use the given Tax Excl Price (up to 4 decimal places) for the exclusive amount
            double exclusive_amount = _item.TaxExclusiveLastPurchasePrice;
            //Step 1: Provide the Exclusive Totals for each line of the invoice.  If an item layout is used, then Exclusive Total = Exclusive Amount x Quantity 
            double ExTaxTotal = exclusive_amount * _quantity;
            //Step 2: Calculate the Inclusive Total to four decimal places for each line where Inclusive Total = Exclusive Total x (1 + tax rate) Eg. If tax rate = 10% and Exclusive Total = 100, then Inclusive Total = 100 X (1 + 0.10)															
            double IncTaxTotal = ExTaxTotal * (1 + tax_rate);
            //Step 4: Calculate the GST to 4 decimal places for each line found in Step 1, where GST = Inclusive Total (step 1) x [(tax rate)/(1+tax rate)]  Eg. If tax rate = 10% and Inclusive Total = 100, then GST = 100 x [(0.10)/(1+0.10)] = 9.0909															
            double GSTAmount = ExTaxTotal * tax_rate;

            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Import_Item_RecurringPurchases (");
            sb.Append("InvoiceNumber");
            sb.Append(", RecordID");
            sb.Append(", CoLastName");
            sb.Append(", FirstName");
            sb.Append(", Inclusive");

            sb.Append(", AddressLine1");
            sb.Append(", AddressLine2");
            sb.Append(", AddressLine3");
            sb.Append(", AddressLine4");

            sb.Append(", RecurringPurchaseDate");

            sb.Append(", CustomersNumber");

            sb.Append(", ShipVia");
            sb.Append(", ItemNumber");
            sb.Append(", DeliveryStatus");
            sb.Append(", Quantity");
            sb.Append(", Description");
            sb.Append(", ExTaxPrice");
            sb.Append(", IncTaxPrice");
            sb.Append(", Discount");

            sb.Append(", ExTaxTotal");
            sb.Append(", IncTaxTotal");

            sb.Append(", Job");

            sb.Append(", Comment");
            sb.Append(", Memo");

            sb.Append(", RecurringPurchasespersonLastName");
            sb.Append(", RecurringPurchasespersonFirstName");

            sb.Append(", ShippingDate");

            sb.Append(", TaxCode");

            //Xianshun: LCT is Luxury Car Tax. I have never seen it being used.
            //sb.Append(", NonGSTLCTAmount");
            //sb.Append(", LCTAmount");
            sb.Append(", GSTAmount");

            //sb.Append(", FreightExTaxAmount");
            //sb.Append(", FreightIncTaxAmount");
            //sb.Append(", FreightTaxCode");
            //sb.Append(", FreightNonGSTLCTAmount");
            //sb.Append(", FreightGSTAmount");
            //sb.append(", FreightLCTAmount");

            sb.Append(", RecurringPurchaseStatus");

            sb.Append(", PaymentIsDue");
            sb.Append(", DiscountDays");
            sb.Append(", BalanceDueDays");
            sb.Append(", PercentDiscount");

            sb.Append(", AmountPaid");

            sb.Append(", Category");
            sb.Append(") VALUES (");

            sb.AppendFormat("'{0}'", _RecurringPurchase.InvoiceNumber);
            sb.AppendFormat(", '{0}'", _customer.CardRecordID); //RecordID
            sb.AppendFormat(", '{0}'", _customer.Name); //CoLastName
            sb.Append(", ''"); //FirstName
            sb.AppendFormat(", '{0}'", _item.PriceIsInclusive == "Y" ? "X" : "");

            sb.AppendFormat(", '{0}'", _RecurringPurchase.ShipToAddressLine1);
            sb.AppendFormat(", '{0}'", _RecurringPurchase.ShipToAddressLine2);
            sb.AppendFormat(", '{0}'", _RecurringPurchase.ShipToAddressLine3);
            sb.AppendFormat(", '{0}'", _RecurringPurchase.ShipToAddressLine4);

            sb.AppendFormat(", '{0}'", _RecurringPurchase.InvoiceDate.Value.ToString("dd/MM/yyyy")); //RecurringPurchaseDate

            sb.AppendFormat(", '{0}'", ""); //CustomersNumber

            sb.AppendFormat(", '{0}'", _RecurringPurchase.ShippingMethod.Method);
            sb.AppendFormat(", '{0}'", _item.ItemNumber);
            sb.AppendFormat(", '{0}'", _RecurringPurchase.InvoiceDelivery.InvoiceDeliveryID);
            sb.AppendFormat(", {0}", _quantity);
            sb.AppendFormat(", '{0}'", _description);
            sb.AppendFormat(", {0}", _item.TaxExclusiveLastPurchasePrice);
            sb.AppendFormat(", {0}", _item.TaxInclusiveLastPurchasePrice);
            sb.AppendFormat(", {0}", 0); //Discount

            sb.AppendFormat(", {0}", ExTaxTotal);
            sb.AppendFormat(", {0}", IncTaxTotal);

            sb.Append(", ''"); //Job

            sb.AppendFormat(", '{0}'", _RecurringPurchase.Comment);
            sb.AppendFormat(", '{0}'", _RecurringPurchase.Memo);

            sb.AppendFormat(", '{0}'", _RecurringPurchase.RecurringPurchasesPerson.FirstName);
            sb.AppendFormat(", '{0}'", _RecurringPurchase.RecurringPurchasesPerson.LastName);

            sb.AppendFormat(", '{0}'", _RecurringPurchase.PromisedDate); //ShippingDate

            sb.AppendFormat(", '{0}'", _item.SellTaxCode.Code); //TaxCode

            //sb.AppendFormat(", {0}", 0); //NonGSTLCTAmount
            //sb.AppendFormat(", {0}", 0); //LCTAmount
            sb.AppendFormat(", {0}", GSTAmount);

            //sb.AppendFormat(", {0}", 0); //FreightExTaxAmount
            //sb.AppendFormat(", {0}", 0); //FreightIncTaxAmount
            //sb.AppendFormat(", '{0}'", ""); //FreightTaxCode
            //sb.AppendFormat(", {0}", 0); //FreightNonGSTLCTAmount
            //sb.AppendFormat(", {0}", 0); //FreightGSTAmount
            //sb.AppendFormat(", {0}", 0); //FreightLCTAmount

            sb.AppendFormat(", '{0}'", _RecurringPurchase.InvoiceDelivery.InvoiceDeliveryID); //RecurringPurchaseStatus

            sb.AppendFormat(", '{0}'", _RecurringPurchase.Terms.PaymentIsDue); //PaymentIsDue
            sb.AppendFormat(", {0}", _RecurringPurchase.Terms.DiscountDays); //DiscountDays
            sb.AppendFormat(", {0}", _RecurringPurchase.Terms.BalanceDueDays); //BalanceDueDays
            sb.AppendFormat(", {0}", _RecurringPurchase.Terms.EarlyPaymentDiscountPercent); //PercentDiscount

            sb.AppendFormat(", {0}", 0); //AmountPaid: need to check out

            sb.AppendFormat(", '{0}'", ""); //Category: need to check out
            sb.Append(");");

            return sb.ToString();
        }*/

        public DbRecurringPurchaseManager(DbManager mgr)
            : base(mgr)
        {
            
        }

        protected override OpResult _Store(RecurringPurchase _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "RecurringPurchase object cannot be created as it is null");
            }

            return OpResult.NotifyStoreAction(OpResult.ResultStatus.NoActionTaken, _obj, "No implementation available for storing persistent RecurringPurchase object");
        }

        /*
        //INSERT INTO Import_Item_RecurringPurchases (InvoiceNumber, RecordID, CoLastName, ItemNumber, Quantity, RecurringPurchaseStatus, ExTaxPrice, ExTaxTotal, RecurringPurchaseDate, PaymentIsDue, AmountPaid, RecurringPurchasespersonLastName, RecurringPurchasespersonFirstName, PaymentMethod, Comment, Job, PaymentNotes, TaxCode, GSTAmount, NonGSTLCTAmount) VALUES ('12G', '26', '', 'JKN LF', 0.6, 'I', 10, 6, '18/3/2008', 0, 3, '', '', 'American Express', '', '', '', 'GST', 0.6, 0)
        private bool SaveItemRecurringPurchase(RecurringPurchase _RecurringPurchase, Item _item, string _description, int _quantity)
        {
            string query=GetQuery_SaveRecurringPurchaseByItem(_RecurringPurchase, _item, _description, _quantity);
            DbCommand cmdSQLInsert = CreateDbCommand(query);
            DbTransaction myTrans = DbMgr.DbConnection.BeginTransaction();
            try
            {
                cmdSQLInsert.CommandText = query;
                cmdSQLInsert.Transaction = myTrans;
                cmdSQLInsert.ExecuteNonQuery();
                myTrans.Commit();
                return true;
            }
            catch (OdbcException ex)
            {
                myTrans.Rollback();
                Log(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                return false;
            }
        }*/
    }
}
