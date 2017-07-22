using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll
{
    public class BOType
    {
        //Accounts
        public static string BOAccounts = "Accounts";
        public static string BOAccount = "Account";
        public static string BOListAccount = "AccountManager";

        //Analysis
        public static string BOAnalysis = "Analysis";
        public static string BOAnalysisJobs = "Analysis.Jobs";
        public static string BOAnalysisCashFlow = "Analysis.CashFlow";
        public static string BOAnalysisProfitAndLoss = "Analysis.ProfitAndLoss";
        public static string BOAnalysisBalanceSheet = "Analysis.BalanceSheet";

        //Cards
        public static string BOCards = "Cards";
        public static string BOCard = "Card";
        public static string BOCustomer = "Customer";
        public static string BOSupplier = "Supplier";
        public static string BOEmployee = "Employee";
        public static string BOListCard = "CardManager";

        //Company
        public static string BOCompany = "Company";

        //Definition
        public static string BODataField = "DataField";
        public static string BOGender = "Gender";
        public static string BOItemSize = "ItemSize";
        public static string BOListDataField = "DataFieldManager";
        public static string BOListGender = "GenderManager";
        public static string BOListItemSize = "ItemSizeManager";

        //Inventory
        public static string BOInventory = "Inventory";
        public static string BOItem = "Item";
        public static string BOItemDataFieldEntry  = "ItemDataFieldEntry";
        public static string BOListItem = "ItemManager";
        public static string BOListItemDataFieldEntry = "ItemDataFieldEntryManager";
        public static string BOListLocation = "LocationManager";
        public static string BOLocation = "Location";
        public static string BOItemsRegister = "ItemsRegister";
        public static readonly string BOAdjustInventory = "InventoryAdjustment";
        public static readonly string BOInventoryAdjustmentLine = "InventoryAdjustmentLine";

        //Jobs
        public static string BOProject = "Project";
        public static string BOJob = "Job";
        public static string BOListJob = "JobManager";

        //Journals
        public static string BOListTransactionJournal  = "TransactionJournalManager";
        public static string BORecordJournalEntry  = "RecordJournalEntry";
        public static string BOTransferMoney  = "TransferMoney";

        //Purchase
        public static string BOPurchases = "Purchases";
        public static string BOListPurchase = "PurchaseManager";
        public static string BOPurchase = "Purchase";
        public static string BOPurchaseClosedBill  = "PurchaseClosedBill";
        public static string BOPurchaseDebitReturn  = "PurchaseDebitReturn";
        public static string BOPurchaseOpenBill  = "PurchaseOpenBill";
        public static string BOPurchaseOrder  = "PurchaseOrder";
        public static string BOPurchaseQuote  = "PurchaseQuote";
        public static string BOItemPurchaseLine  = "ItemPurchaseLine";
        public static string BOListPurchaseLine= "PurchaseLineManager";
        public static string BOMiscPurchaseLine  = "MiscPurchaseLine";
        public static string BOProfessionalPurchaseLine = "ProfessionalPurchaseLine";
        public static string BOPurchaseLine = "PurchaseLine";
        public static string BOServicePurchaseLine  = "ServicePurchaseLine";
        public static string BOTimeBillingPurchaseLine = "TimeBillingPurchaseLine";

        //Sale
        public static string BOSales = "Sales";
        public static string BOListSale = "SaleManager";
        public static string BOSale = "Sale";
        public static string BOSaleClosedInvoice = "SaleClosedInvoice";
        public static string BOSaleCreditReturn = "SaleCreditReturn";
        public static string BOSaleOpenInvoice = "SaleOpenInvoice";
        public static string BOSaleOrder = "SaleOrder";
        public static string BOSaleQuote = "SaleQuote";
        public static string BOItemSaleLine = "ItemSaleLine";
        public static string BOListSaleLine = "SaleLineManager";
        public static string BOMiscSaleLine = "MiscSaleLine";
        public static string BOProfessionalSaleLine = "ProfessionalSaleLine";
        public static string BOSaleLine = "SaleLine";
        public static string BOServiceSaleLine = "ServiceSaleLine";
        public static string BOTimeInvoiceingSaleLine = "TimeInvoiceingSaleLine";

        //User
        public static string BOUser = "User";
        public static string BORole = "Role";
    }
}
