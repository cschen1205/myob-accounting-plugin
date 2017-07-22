using System;
using System.Collections.Generic;
using System.Text;


namespace Accounting.Bll
{
    using System.IO;
    using System.Data.Common;
    using Accounting.Db;
    using Accounting.Core.Cards;
    using Accounting.Core.TaxCodes;
    using Accounting.Core.Definitions;
    using Accounting.Core.Currencies;
    using Accounting.Core.Terms;
    using Accounting.Core.Inventory;
    using Accounting.Core.Accounts;
    using Accounting.Core.Purchases;
    using Accounting.Core.Misc;
    using Accounting.Core.ShippingMethods;
    using Accounting.Core.Sales;
    using Accounting.Core.Jobs;
    using Accounting.Core.JournalRecords;
    using Accounting.Core.Transactions;
    using Accounting.Core.Activities;
    using Accounting.Core.Payroll;
    using Accounting.Core.CostCentres;
    using Accounting.Core.Security;
    using Accounting.Core;
    using Accounting.Util;
    using Accounting.Bll.Security;

    public class Accountant : RepositoryManager
    {
        private static object mLocker=new object();

        public void ResetAllExceptSecurity()
        {
            WageDollarHistoryMgr.RecreateTable();
            WageHourHistoryMgr.RecreateTable();
            LinkedCategoryMgr.RecreateTable();
            LinkedEmployeeMgr.RecreateTable();
            CostCentreJournalRecordMgr.RecreateTable();
            CostCentreAccountActivityMgr.RecreateTable();
            CostCentreAccountMgr.RecreateTable();
            CostCentreMgr.RecreateTable();
            PayrollInformationMgr.RecreateTable();
            BASInformationMgr.RecreateTable();
            PaySuperannuationLineMgr.RecreateTable();
            PaySuperannuationMgr.RecreateTable();
            SuperannuationFundMgr.RecreateTable();
            PayLiabilityLineMgr.RecreateTable();
            PayLiabilityMgr.RecreateTable();
            WritePaychequeLineMgr.RecreateTable();
            PayBasisMgr.RecreateTable();
            CategoryTypeMgr.RecreateTable();
            WritePaychequeMgr.RecreateTable();
            BankingDetailMgr.RecreateTable();
            PaymentTypeMgr.RecreateTable();
            BankDepositLineMgr.RecreateTable();
            BankDepositMgr.RecreateTable();
            RecurringItemSaleLineMgr.RecreateTable();
            RecurringServiceSaleLineMgr.RecreateTable();
            RecurringMiscSaleLineMgr.RecreateTable();
            RecurringTimeBillingSaleLineMgr.RecreateTable();
            RecurringProfessionalSaleLineMgr.RecreateTable();
            RecurringSaleLineMgr.RecreateTable();
            RecurringSaleMgr.RecreateTable();
            RecurringItemPurchaseLineMgr.RecreateTable();
            RecurringServicePurchaseLineMgr.RecreateTable();
            RecurringMiscPurchaseLineMgr.RecreateTable();
            //RecurringTimeBillingPurchaseLineMgr.RecreateTable();
            RecurringProfessionalPurchaseLineMgr.RecreateTable();
            RecurringPurchaseLineMgr.RecreateTable();
            RecurringPurchaseMgr.RecreateTable();
            RecurringGeneralJournalLineMgr.RecreateTable();
            RecurringGeneralJournalMgr.RecreateTable();
            RecurringTransferMoneyMgr.RecreateTable();
            RecurringMoneyReceivedLineMgr.RecreateTable();
            RecurringMoneyReceivedMgr.RecreateTable();
            RecurringMoneySpentLineMgr.RecreateTable();
            RecurringMoneySpentMgr.RecreateTable();
            NumberingTypeMgr.RecreateTable();
            FrequencyMgr.RecreateTable();
            EmployerExpenseTypeMgr.RecreateTable();
            ContributionTypeMgr.RecreateTable();
            CalculationMethodMgr.RecreateTable();
            TerminationMethodMgr.RecreateTable();
            DayNameMgr.RecreateTable();
            EmploymentStatusMgr.RecreateTable();
            EmploymentClassificationMgr.RecreateTable();
            EmploymentBasisMgr.RecreateTable();
            AccountingBasisMgr.RecreateTable();
            ImportantDatesMgr.RecreateTable();
            AuditTrailMgr.RecreateTable();
            ElectronicPaymentLineMgr.RecreateTable();
            ElectronicPaymentMgr.RecreateTable();
            ActivitySlipInvoicedMgr.RecreateTable();
            ActivitySlipMgr.RecreateTable();
            WageMgr.RecreateTable();
            ActivitySalesHistoryMgr.RecreateTable();
            NegativeInventoryMgr.RecreateTable();
            BuildComponentMgr.RecreateTable();
            BuiltItemMgr.RecreateTable();
            ItemPurchasesHistoryMgr.RecreateTable();
            ItemSalesHistoryMgr.RecreateTable();
            ItemOpeningBalanceMgr.RecreateTable();
            ItemMovementMgr.RecreateTable();
            ItemPriceMgr.RecreateTable();
            MoveItemMgr.RecreateTable();
            RoundingMgr.RecreateTable();
            TaxInformationConsolidationMgr.RecreateTable();
            TaxInformationMgr.RecreateTable();
            TaxCodeConsolidationMgr.RecreateTable();
            EmploymentCategoryMgr.RecreateTable();
            ScheduleMgr.RecreateTable();
            PaymentValueTypeMgr.RecreateTable();
            TaxScaleMgr.RecreateTable();
            AlertTypeMgr.RecreateTable();
            AlertMgr.RecreateTable();
            LimitTypeMgr.RecreateTable();
            ReportingMethodMgr.RecreateTable();
            ReconciliationStatusMgr.RecreateTable();
            SalespersonHistoryMgr.RecreateTable();
            InventoryTransferLineMgr.RecreateTable();
            InventoryTransferMgr.RecreateTable();
            InventoryAdjustmentLineMgr.RecreateTable();
            InventoryAdjustmentMgr.RecreateTable();
            DebitRefundMgr.RecreateTable();
            SettledDebitLineMgr.RecreateTable();
            SettledDebitMgr.RecreateTable();
            CreditRefundMgr.RecreateTable();
            SettledCreditLineMgr.RecreateTable();
            SettledCreditMgr.RecreateTable();
            SupplierFinanceChargeMgr.RecreateTable();
            SupplierDepositMgr.RecreateTable();
            SupplierDiscountMgr.RecreateTable();
            SupplierDiscountLineMgr.RecreateTable();
            SupplierPaymentMgr.RecreateTable();
            SupplierPaymentLineMgr.RecreateTable();
            CustomerFinanceChargeMgr.RecreateTable();
            CustomerDepositMgr.RecreateTable();
            CustomerDiscountMgr.RecreateTable();
            CustomerDiscountLineMgr.RecreateTable();
            CustomerPaymentMgr.RecreateTable();
            CustomerPaymentLineMgr.RecreateTable();
            PurchasesHistoryMgr.RecreateTable();
            SalesHistoryMgr.RecreateTable();
            DepositStatusMgr.RecreateTable();
            MoneySpentMgr.RecreateTable();
            MoneySpentLineMgr.RecreateTable();
            MoneyReceivedMgr.RecreateTable();
            MoneyReceivedLineMgr.RecreateTable();
            JobJournalRecordMgr.RecreateTable();
            JobBudgetMgr.RecreateTable();
            JobAccountActivityMgr.RecreateTable();
            JobAccountMgr.RecreateTable();
            ItemLocationMgr.RecreateTable();
            LinkedAccountMgr.RecreateTable();
            DataFileInformationMgr.RecreateTable();
            AccountBudgetMgr.RecreateTable();
            AccountActivityMgr.RecreateTable();
            PaymentMethodMgr.RecreateTable();
            BillingRateUsedMgr.RecreateTable();
            ReferralSourceMgr.RecreateTable();
            ContactLogMgr.RecreateTable();
            AccountTypeMgr.RecreateTable();
            SubAccountTypeMgr.RecreateTable();
            AccountClassificationMgr.RecreateTable();
            CashFlowClassificationMgr.RecreateTable();
            ShippingMethodMgr.RecreateTable();
            CommentMgr.RecreateTable();
            AddressMgr.RecreateTable();
            ActivityMgr.RecreateTable();
            GeneralJournalMgr.RecreateTable();
            GeneralJournalLineMgr.RecreateTable();
            TaxCodeMgr.RecreateTable();
            InvoiceDeliveryMgr.RecreateTable();
            JournalTypeMgr.RecreateTable();
            JournalSetMgr.RecreateTable();
            JournalRecordMgr.RecreateTable();
            CardTypeMgr.RecreateTable();
            InvoiceTypeMgr.RecreateTable();
            CurrencyMgr.RecreateTable();
            TermsOfPaymentMgr.RecreateTable();
            PriceLevelMgr.RecreateTable();
            TermsMgr.RecreateTable();
            LocationMgr.RecreateTable();
            AccountMgr.RecreateTable();
            CardMgr.RecreateTable();
            CardActivityMgr.RecreateTable();
            PersonalCardMgr.RecreateTable();
            SupplierMgr.RecreateTable();
            EmployeeMgr.RecreateTable();
            CustomerMgr.RecreateTable();
            ItemMgr.RecreateTable();
            JobMgr.RecreateTable();
            StatusMgr.RecreateTable();
            ItemPurchaseLineMgr.RecreateTable();
            ServicePurchaseLineMgr.RecreateTable();
            MiscPurchaseLineMgr.RecreateTable();
            ProfessionalPurchaseLineMgr.RecreateTable();
            PurchaseLineMgr.RecreateTable();
            PurchaseMgr.RecreateTable();
            ItemSaleLineMgr.RecreateTable();
            ServiceSaleLineMgr.RecreateTable();
            MiscSaleLineMgr.RecreateTable();
            TimeBillingSaleLineMgr.RecreateTable();
            ProfessionalSaleLineMgr.RecreateTable();
            SaleLineMgr.RecreateTable();
            SaleMgr.RecreateTable();
            TransferMoneyMgr.RecreateTable();
            CustomListMgr.RecreateTable();

            //AddOn Tables
            ItemAddOnMgr.RecreateTable();
            GenderMgr.RecreateTable();
            ItemSizeMgr.RecreateTable();

            //Item Fields Table
            DataFieldMgr.RecreateTable();
            ItemDataFieldEntryMgr.RecreateTable();
        }

        private Company.BOCompany mCompany=null;
        public Company.BOCompany CompanyInfo
        {
            get
            {
                if (mCompany == null)
                {
                    lock (mLocker)
                    {
                        mCompany = new Company.BOCompany(this, DataFileInformationMgr.Company, BusinessObject.BOContext.Record_Update);
                    }
                }
                return mCompany;
            }
        }

        public bool CanDeleteAuthRole(AuthRole role)
        {
            return AuthRoleMgr.CanDelete(role);
        }

        
        private Journals.BOListTransactionJournal mTransactionJournals = null;
        public Journals.BOListTransactionJournal TransactionJournals
        {
            get
            {
                if (mTransactionJournals == null)
                {
                    lock (mLocker)
                    {
                        mTransactionJournals = new Journals.BOListTransactionJournal(this);
                    }
                }
                return mTransactionJournals;
            }
        }

        #region Account
        private Accounts.BOListAccount mAccounts = null;
        public Accounts.BOListAccount Accounts
        {
            get
            {
                if (mAccounts == null)
                {
                    lock (mLocker)
                    {
                        mAccounts = new Accounts.BOListAccount(this);
                    }
                }
                return mAccounts;
            }
        }

        public Accounts.BOAccount OpenAccount(Account _obj)
        {
            return new Accounts.BOAccount(this, _obj, BusinessObject.BOContext.Record_Update);
        }

        public Accounts.BOAccount CreateAccount()
        {
            Account data = AccountMgr.CreateEntity();
            return new Accounts.BOAccount(this, data, BusinessObject.BOContext.Record_Create);
        }

        public void DeleteAccount(Account _obj)
        {
            Accounts.BOAccount model = OpenAccount(_obj);
            if (model == null) return;
            model.Delete();
        }
        #endregion

        #region Cards
       
        private Cards.BOListCard mAllCards = null;
        public Cards.BOListCard AllCards
        {
            get
            {
                if (mAllCards == null)
                {
                    lock (mLocker)
                    {
                        mAllCards = new Cards.BOListCard(this);
                        mAllCards.ActiveCardType = CardType.TypeID.None;
                    }
                }
                return mAllCards;
            }
        }

        public Cards.BOCard OpenCard(Card _obj)
        {
            if (_obj is Supplier)
            {
                return new Cards.BOSupplier(this, _obj as Supplier, BusinessObject.BOContext.Record_Update);
            }
            else if (_obj is Customer)
            {
                return new Cards.BOCustomer(this, _obj as Customer, BusinessObject.BOContext.Record_Update);
            }
            else if (_obj is Employee)
            {
                return new Cards.BOEmployee(this, _obj as Employee, BusinessObject.BOContext.Record_Update);
            }
            return null;
        }

        public Cards.BOSupplier CreateSupplier()
        {
            Supplier data = SupplierMgr.CreateEntity();
            return new Cards.BOSupplier(this, data, BusinessObject.BOContext.Record_Create); 
        }

        public Cards.BOEmployee CreateEmployee()
        {
            Employee data = EmployeeMgr.CreateEntity();
            return new Cards.BOEmployee(this, data, BusinessObject.BOContext.Record_Create);
        }

        public Cards.BOCustomer CreateCustomer()
        {
            Customer data = CustomerMgr.CreateEntity();
            return new Cards.BOCustomer(this, data, BusinessObject.BOContext.Record_Create);
        }

        public void DeleteCard(Card _obj)
        {
            Cards.BOCard card = OpenCard(_obj);
            if (card == null) return;
            card.Delete();
        }
        #endregion

        public Util.BOEmail CreateEmail(string subject, string body, params string[] filenames)
        {
            Util.BOEmail model= new Util.BOEmail(this);
            model.Subject = subject;
            model.Body = body;
            foreach (string filename in filenames)
            {
                model.Attachments.Add(filename);
            }
            return model;
        }
    

        #region Inventory
        #region Items
        private Inventory.BOItemsList mItems = null;
        public Inventory.BOItemsList Items
        {
            get
            {
                if (mItems == null)
                {
                    lock (mLocker)
                    {
                        mItems = new Inventory.BOItemsList(this);
                    }
                }
                return mItems;
            }
        }

        private Inventory.BOItemsRegister mItemsRegister=null;
        public Inventory.BOItemsRegister ItemsRegister
        {
            get
            {
                if (mItemsRegister == null)
                {
                    lock (mLocker)
                    {
                        mItemsRegister = new Inventory.BOItemsRegister(this);
                    }
                }
                return mItemsRegister;
            }
        }

        public Inventory.BOItem OpenItem(Item _obj)
        {
            return new Inventory.BOItem(this, _obj, BusinessObject.BOContext.Record_Update);
        }

        public Inventory.BOItem CreateItem()
        {
            Item new_item = ItemMgr.CreateEntity();
            return new Inventory.BOItem(this, new_item, BusinessObject.BOContext.Record_Create);
        }

        public void DeleteItem(Item _obj)
        {
            Inventory.BOItem item = OpenItem(_obj);
            if (item == null) return;
            item.Delete();
        }
        #endregion

        #region ItemDataFieldEntries

        public Inventory.BOItemDataFieldEntry OpenItemDataFieldEntry(ItemDataFieldEntry _obj, Item _item)
        {
            Inventory.BOItemDataFieldEntry model= new Inventory.BOItemDataFieldEntry(this, _obj, _item, BusinessObject.BOContext.Record_Update);
            return model;
        }

        public Inventory.BOItemDataFieldEntry CreateItemDataFieldEntry(Item _item)
        {
            ItemDataFieldEntry new_data_field_entry = ItemDataFieldEntryMgr.CreateEntity();
            return new Inventory.BOItemDataFieldEntry(this, new_data_field_entry, _item, BusinessObject.BOContext.Record_Create);
        }

        public void DeleteItemDataFieldEntry(ItemDataFieldEntry _obj, Item _item)
        {
            Inventory.BOItemDataFieldEntry model = OpenItemDataFieldEntry(_obj, _item);
            if (model == null) return;
            model.Delete();
        }
        #endregion
        #endregion

        #region Administrator
        #region DataFieldForItemAddOn
        private Definitions.BOListDataField mDataFieldsForItemAddOn=null;
        public Definitions.BOListDataField DataFieldsForItemAddOn
        {
            get
            {
                if (mDataFieldsForItemAddOn == null)
                {
                    lock (mLocker)
                    {
                        mDataFieldsForItemAddOn = new Definitions.BOListDataField(this);
                    }
                }
                return mDataFieldsForItemAddOn;
            }
        }

        public Definitions.BODataField OpenDataFieldForItemAddOn(DataField df)
        {
            return new Definitions.BODataField(this, df, BusinessObject.BOContext.Record_Update);
        }

        public void DeleteDataFieldForItemAddOn(DataField df)
        {
            Definitions.BODataField _obj = OpenDataFieldForItemAddOn(df);
            if (_obj == null) return;
            _obj.Delete();
        }

        public Definitions.BODataField CreateDataFieldForItemAddOn()
        {
            DataField data = DataFieldMgr.CreateEntity();
            return new Definitions.BODataField(this, data, BusinessObject.BOContext.Record_Create);
        }
        #endregion

        #region GenderForItemAddOn
        private Definitions.BOListGender mGendersForItemAddOn = null;
        public Definitions.BOListGender GendersForItemAddOn
        {
            get
            {
                if (mGendersForItemAddOn == null)
                {
                    lock (mLocker)
                    {
                        mGendersForItemAddOn = new Definitions.BOListGender(this);
                    }
                }
                return mGendersForItemAddOn;
            }
        }

        public Definitions.BOGender OpenGenderForItemAddOn(Gender df)
        {
            return new Definitions.BOGender(this, df, BusinessObject.BOContext.Record_Update);
        }

        public void DeleteGenderForItemAddOn(Gender df)
        {
            Definitions.BOGender _obj = OpenGenderForItemAddOn(df);
            if (_obj == null) return;
            _obj.Delete();
        }

        public Definitions.BOGender CreateGenderForItemAddOn()
        {
            Gender new_gender = GenderMgr.CreateEntity();
            return new Definitions.BOGender(this, new_gender, BusinessObject.BOContext.Record_Create);
        }
        #endregion

        #region ItemSizeForItemAddOn
        private Definitions.BOListItemSize mItemSizesForItemAddOn = null;
        public Definitions.BOListItemSize ItemSizesForItemAddOn
        {
            get
            {
                if (mItemSizesForItemAddOn == null)
                {
                    lock (mLocker)
                    {
                        mItemSizesForItemAddOn = new Definitions.BOListItemSize(this);
                    }
                }
                return mItemSizesForItemAddOn;
            }
        }

        public Definitions.BOItemSize OpenItemSizeForItemAddOn(ItemSize df)
        {
            return new Definitions.BOItemSize(this, df, BusinessObject.BOContext.Record_Update);
        }

        public void DeleteItemSizeForItemAddOn(ItemSize df)
        {
            Definitions.BOItemSize _obj = OpenItemSizeForItemAddOn(df);
            if (_obj == null) return;
            _obj.Delete();
        }

        public Definitions.BOItemSize CreateItemSizeForItemAddOn()
        {
            ItemSize new_item_size = ItemSizeMgr.CreateEntity();
            return new Definitions.BOItemSize(this, new_item_size, BusinessObject.BOContext.Record_Create);
        }
        #endregion

        #endregion

        #region Purchases
        public Purchases.BOListPurchase mPurchases = null;
        public Purchases.BOListPurchase Purchases
        {
            get
            {
                if (mPurchases == null)
                {
                    lock (mLocker)
                    {
                        mPurchases = new Purchases.BOListPurchase(this);
                    }
                }
                return mPurchases;
            }
        }

        public Purchases.BOPurchase OpenPurchase(Purchase _obj)
        {
            if (_obj == null) return null;
            Purchases.BOPurchase model = null;

            Status.StatusType status=_obj.PurchaseStatus.Type;

            if (status == Status.StatusType.Quote)
            {
                model = PurchaseFactory.OpenPurchaseQuote(_obj);
            }
            else if (status == Status.StatusType.Order)
            {
                model = PurchaseFactory.OpenPurchaseOrder(_obj);
            }
            else if (status == Status.StatusType.Open)
            {
                model = PurchaseFactory.OpenPurchaseOpenBill(_obj);
            }
            else if (status == Status.StatusType.Closed)
            {
                model = PurchaseFactory.OpenPurchaseClosedBill(_obj);
            }
            else if (status == Status.StatusType.Debit)
            {
                model = PurchaseFactory.OpenPurchaseDebitReturn(_obj);
            }

            return model;
        }

        public Purchases.BOPurchaseQuote CreatePurchaseQuote()
        {
            return PurchaseFactory.CreatePurchaseQuote();
        }

        public Purchases.BOPurchaseOrder CreatePurchaseOrder()
        {
            return PurchaseFactory.CreatePurchaseOrder();
        }

        public Purchases.BOPurchaseOpenBill CreatePurchaseOpenBill()
        {
            return PurchaseFactory.CreatePurchaseOpenBill();
        }

        public Purchases.BOPurchaseClosedBill CreatePurchaseClosedBill()
        {
            return PurchaseFactory.CreatePurchaseClosedBill();
        }

        public Purchases.BOPurchaseDebitReturn CreatePurchaseDebitReturn()
        {
            return PurchaseFactory.CreatePurchaseDebitReturn();
        }

        public void DeletePurchase(Purchase _obj)
        {
            Purchases.BOPurchase model = OpenPurchase(_obj);
            model.Delete();
        }

        public Purchases.BOPurchaseOrder CreatePurchaseOrderFromQuote(Purchase _quote)
        {
            return PurchaseFactory.CreatePurchaseOrderFromQuote(_quote);
        }

        public Purchases.BOPurchaseOpenBill CreatePurchaseOpenBillFromQuote(Purchase _quote)
        {
            return PurchaseFactory.CreatePurchaseOpenBillFromQuote(_quote);
        }

        public Purchases.BOPurchaseOpenBill CreatePurchaseOpenBillFromOrder(Purchase _order)
        {
            return PurchaseFactory.CreatePurchaseOpenBillFromOrder(_order);
        }
        #endregion

        #region Sales

        private Sales.BOListSale mSales = null;
        public Sales.BOListSale Sales
        {
            get
            {
                if (mSales == null)
                {
                    lock (mLocker)
                    {
                        mSales = new Accounting.Bll.Sales.BOListSale(this);
                    }
                }
                return mSales;
            }
        }
        public Sales.BOSale OpenSale(Sale _obj)
        {
            if (_obj == null) return null;
            Sales.BOSale model = null;

            Status.StatusType status = _obj.InvoiceStatus.Type;

            if (status == Status.StatusType.Quote)
            {
                model = SaleFactory.OpenSaleQuote(_obj);
            }
            else if (status == Status.StatusType.Order)
            {
                model = SaleFactory.OpenSaleOrder(_obj);
            }
            else if (status == Status.StatusType.Open)
            {
                model = SaleFactory.OpenSaleOpenInvoice(_obj);
            }
            else if (status == Status.StatusType.Closed)
            {
                model = SaleFactory.OpenSaleClosedInvoice(_obj);
            }
            else if (status == Status.StatusType.Credit)
            {
                model = SaleFactory.OpenSaleCreditReturn(_obj);
            }

            return model;
        }

        public Sales.SaleLines.BOSaleLine CreateSaleLine(Sale sale)
        {
            InvoiceType purchase_type = sale.InvoiceType;
            if (purchase_type == null)
            {
                return null;
            }


            if (purchase_type.IsItem)
            {
                return new Sales.SaleLines.BOItemSaleLine(
                    this,
                    sale,
                    ItemSaleLineMgr.CreateEntity(),
                    BusinessObject.BOContext.Record_Create);
            }
            else if (purchase_type.IsService)
            {
                return new Sales.SaleLines.BOServiceSaleLine(
                   this,
                   sale,
                   ServiceSaleLineMgr.CreateEntity(),
                   BusinessObject.BOContext.Record_Create);
            }
            else if (purchase_type.IsMisc)
            {
                return new Sales.SaleLines.BOMiscSaleLine(
                   this,
                   sale,
                   MiscSaleLineMgr.CreateEntity(),
                   BusinessObject.BOContext.Record_Create);
            }
            else if (purchase_type.IsProfessional)
            {
                return new Sales.SaleLines.BOProfessionalSaleLine(
                   this,
                   sale,
                   ProfessionalSaleLineMgr.CreateEntity(),
                   BusinessObject.BOContext.Record_Create);
            }
            else if (purchase_type.IsTimeBilling)
            {
                return new Sales.SaleLines.BOTimeBillingSaleLine(
                   this,
                   sale,
                   TimeBillingSaleLineMgr.CreateEntity(),
                   BusinessObject.BOContext.Record_Create);
            }

            return null;
        }

        public Sales.BOSaleQuote CreateSaleQuote()
        {
            return SaleFactory.CreateSaleQuote();
        }

        public Sales.BOSaleOrder CreateSaleOrder()
        {
            return SaleFactory.CreateSaleOrder();
        }

        public Sales.BOSaleOpenInvoice CreateSaleOpenInvoice()
        {
            return SaleFactory.CreateSaleOpenInvoice();
        }

        public Sales.BOSaleClosedInvoice CreateSaleClosedInvoice()
        {
            return SaleFactory.CreateSaleClosedInvoice();
        }

        public Sales.BOSaleCreditReturn CreateSaleCreditReturn()
        {
            return SaleFactory.CreateSaleCreditReturn();
        }

        public void DeleteSale(Sale _obj)
        {
            Sales.BOSale model = OpenSale(_obj);
            model.Delete();
        }

        public Sales.BOSaleOrder CreateSaleOrderFromQuote(Sale _quote)
        {
            return SaleFactory.CreateSaleOrderFromQuote(_quote);
        }

        public Sales.BOSaleOpenInvoice CreateSaleOpenInvoiceFromQuote(Sale _quote)
        {
            return SaleFactory.CreateSaleOpenInvoiceFromQuote(_quote);
        }

        public Sales.BOSaleOpenInvoice CreateSaleOpenInvoiceFromOrder(Sale _order)
        {
            return SaleFactory.CreateSaleOpenInvoiceFromOrder(_order);
        }
        #endregion

        public string DefaultMgrFactory_DbUsername
        {
            get
            {
                return ConfigMgr.GetParamValue(DefaultMgrFactory.Name+"dbusername");
            }
            set
            {
                ConfigMgr.SetParam(DefaultMgrFactory.Name + "dbusername", value);
            }
        }

        public void LoadAuthItems()
        {
          
             CurrentAuthUser.GetAuthItemHierarchy();
          
        }

        public string DefaultMgrFactory_DbPassword
        {
            get
            {
                return ConfigMgr.GetParamValue(DefaultMgrFactory.Name + "dbpassword");
            }
            set
            {
                ConfigMgr.SetParam(DefaultMgrFactory.Name + "dbpassword", value);
            }
        }

        public string DefaultMgrFactory_Database
        {
            get
            {
                return ConfigMgr.GetParamValue(DefaultMgrFactory.Name + "database");
            }
            set
            {
                ConfigMgr.SetParam(DefaultMgrFactory.Name + "database", value);
            }
        }

        public string DefaultMgrFactory_Directory
        {
            get
            {
                string db_path = DefaultMgrFactory_Database;
                if (string.IsNullOrEmpty(db_path)) return "";
                return (new FileInfo(db_path)).DirectoryName;
            }
        }

        public string DefaultMgrFactory_HostExePath
        {
            get
            {
                return ConfigMgr.GetParamValue(DefaultMgrFactory.Name + "host_exe_path");
            }
            set
            {
                ConfigMgr.SetParam(DefaultMgrFactory.Name + "host_exe_path", value);
            }
        }

        public string DefaultMgrFactory_Port
        {
            get
            {
                return ConfigMgr.GetParamValue(DefaultMgrFactory.Name + "port");
            }
            set
            {
                ConfigMgr.SetParam(DefaultMgrFactory.Name + "port", value);
            }
        }

        public string DefaultMgrFactory_Key
        {
            get
            {
                return ConfigMgr.GetParamValue(DefaultMgrFactory.Name+"key");
            }
            set
            {
                ConfigMgr.SetParam(DefaultMgrFactory.Name+"key", value);
            }
        }

        public string DefaultMgrFactory_Driver
        {
            set
            {
                ConfigMgr.SetParam(DefaultMgrFactory.Name+"driver", value);
            }
            get
            {
                return ConfigMgr.GetParamValue(DefaultMgrFactory.Name+"driver");
            }
        }

        #region Jobs

        private Analysis.BOJobs mJobAnalysis = null;
        public Analysis.BOJobs JobAnalysis
        {
            get
            {
                if (mJobAnalysis == null)
                {
                    lock (mLocker)
                    {
                        mJobAnalysis = new Analysis.BOJobs(this, BusinessObject.BOContext.Record_Update);
                    }
                }
                return mJobAnalysis;
            }
        }
        private Jobs.BOListJob mJobs = null;
        public Jobs.BOListJob Jobs
        {
            get
            {
                if (mJobs == null)
                {
                    lock (mLocker)
                    {
                        mJobs = new Jobs.BOListJob(this);
                    }
                }
                return mJobs;
            }
        }

        public Jobs.BOJob CreateJob()
        {
            Job new_job = JobMgr.CreateEntity();
            return new Jobs.BOJob(this, new_job, BusinessObject.BOContext.Record_Create);
        }

        public Jobs.BOJob OpenJob(Job _obj)
        {
            return new Jobs.BOJob(this, _obj, BusinessObject.BOContext.Record_Update);
        }

        public void DeleteJob(Job _obj)
        {
            Jobs.BOJob model = OpenJob(_obj);
            if (model == null) return;
            model.Delete();
        }
        #endregion


        public void ResetSecurity()
        {
            foreach (IRepository repository in this.Repositories)
            {
                if (repository is AuthItemManager 
                    || repository is AuthRoleManager
                    || repository is AuthUserManager)
                {
                    repository.RecreateTable();
                }
            }
        }

        private BOUser mUser=null;
        public BOUser CurrentAuthUser
        {
            get
            {
                if (mUser == null)
                {
                    mUser = CreateAuthUser();
                }
                return mUser;
            }
            set
            {
                mUser = value;
            }
        }

        public string Name
        {
            get;
            set;
        }


        public override string ToString()
        {
            if (mUser.Data != null)
                return string.Format("{0} ({1})", mUser.Data.Username, Name);
            else
                return Name;
        }

        private string mApplicationDirPath;
        public string ApplicationDirPath
        {
            get { return mApplicationDirPath; }
            set 
            {
                mApplicationDirPath = value;
                AppEnv.ApplicationPath = value;
            }
        }

        public string GetFullPath(string filename)
        {
            return string.Format("{0}{1}{2}", ApplicationDirPath, System.IO.Path.DirectorySeparatorChar, filename);
        }

        public Accountant(string _name)
        {
            Name = _name;
        }

        public string Username
        {
            get
            {
                return ConfigMgr.GetParamValue("username");
            }
            set
            {
                ConfigMgr.SetParam("username", value);
            }
        }

        public string Password
        {
            get
            {
                return ConfigMgr.GetParamValue("password");
            }
            set
            {
                ConfigMgr.SetParam("password", value);
            }
        }

        public string GenerateInvoiceNumber()
        {
            return MiscNumberMgr.GenerateInvoiceNumber();
        }

        public string GeneratePurchaseNumber()
        {
            return MiscNumberMgr.GeneratePurchaseNumber();
        }

        public string Culture
        {
            get 
            { 
                string culture=ConfigMgr.GetParamValue("culture");
                if (culture.Equals("")) return "en";
                return culture;
            }
            set { ConfigMgr.SetParam("culture", value); }
        }
        
        public void ImportDataFrom(Accountant rhs)
        {
            BeginImporting();
            rhs.BeginExporting();

            IList<WageDollarHistory> WageDollarHistorys = rhs.WageDollarHistoryMgr.FindAllCollection();
            foreach (WageDollarHistory s in WageDollarHistorys)
            {
                WageDollarHistoryMgr.Store(s);
            }

            IList<WageHourHistory> WageHourHistorys = rhs.WageHourHistoryMgr.FindAllCollection();
            foreach (WageHourHistory s in WageHourHistorys)
            {
                WageHourHistoryMgr.Store(s);
            }

            IList<LinkedCategory> LinkedCategorys = rhs.LinkedCategoryMgr.FindAllCollection();
            foreach (LinkedCategory s in LinkedCategorys)
            {
                LinkedCategoryMgr.Store(s);
            }

            IList<LinkedEmployee> LinkedEmployees = rhs.LinkedEmployeeMgr.FindAllCollection();
            foreach (LinkedEmployee s in LinkedEmployees)
            {
                LinkedEmployeeMgr.Store(s);
            }

            IList<CostCentreJournalRecord> CostCentreJournalRecords = rhs.CostCentreJournalRecordMgr.FindAllCollection();
            foreach (CostCentreJournalRecord s in CostCentreJournalRecords)
            {
                CostCentreJournalRecordMgr.Store(s);
            }

            IList<CostCentreAccountActivity> CostCentreAccountActivitys = rhs.CostCentreAccountActivityMgr.FindAllCollection();
            foreach (CostCentreAccountActivity s in CostCentreAccountActivitys)
            {
                CostCentreAccountActivityMgr.Store(s);
            }

            IList<CostCentreAccount> CostCentreAccounts = rhs.CostCentreAccountMgr.FindAllCollection();
            foreach (CostCentreAccount s in CostCentreAccounts)
            {
                CostCentreAccountMgr.Store(s);
            }

            IList<CostCentre> CostCentres = rhs.CostCentreMgr.FindAllCollection();
            foreach (CostCentre s in CostCentres)
            {
                CostCentreMgr.Store(s);
            }

            IList<PayrollInformation> PayrollInformations = rhs.PayrollInformationMgr.FindAllCollection();
            foreach (PayrollInformation s in PayrollInformations)
            {
                PayrollInformationMgr.Store(s);
            }

            IList<BASInformation> BASInformations = rhs.BASInformationMgr.FindAllCollection();
            foreach (BASInformation s in BASInformations)
            {
                BASInformationMgr.Store(s);
            }

            IList<PaySuperannuationLine> PaySuperannuationLines = rhs.PaySuperannuationLineMgr.FindAllCollection();
            foreach (PaySuperannuationLine s in PaySuperannuationLines)
            {
                PaySuperannuationLineMgr.Store(s);
            }

            IList<PaySuperannuation> PaySuperannuations = rhs.PaySuperannuationMgr.FindAllCollection();
            foreach (PaySuperannuation s in PaySuperannuations)
            {
                PaySuperannuationMgr.Store(s);
            }

            IList<SuperannuationFund> SuperannuationFunds = rhs.SuperannuationFundMgr.FindAllCollection();
            foreach (SuperannuationFund s in SuperannuationFunds)
            {
                SuperannuationFundMgr.Store(s);
            }

            IList<PayLiabilityLine> PayLiabilityLines = rhs.PayLiabilityLineMgr.FindAllCollection();
            foreach (PayLiabilityLine s in PayLiabilityLines)
            {
                PayLiabilityLineMgr.Store(s);
            }

            IList<PayLiability> PayLiabilitys = rhs.PayLiabilityMgr.FindAllCollection();
            foreach (PayLiability s in PayLiabilitys)
            {
                PayLiabilityMgr.Store(s);
            }


            IList<WritePaychequeLine> WritePaychequeLines = rhs.WritePaychequeLineMgr.FindAllCollection();
            foreach (WritePaychequeLine s in WritePaychequeLines)
            {
                WritePaychequeLineMgr.Store(s);
            }

            IList<PayBasis> PayBasiss = rhs.PayBasisMgr.FindAllCollection();
            foreach (PayBasis s in PayBasiss)
            {
                PayBasisMgr.Store(s);
            }

            IList<CategoryType> CategoryTypes = rhs.CategoryTypeMgr.FindAllCollection();
            foreach (CategoryType s in CategoryTypes)
            {
                CategoryTypeMgr.Store(s);
            }

            IList<WritePaycheque> WritePaycheques = rhs.WritePaychequeMgr.FindAllCollection();
            foreach (WritePaycheque s in WritePaycheques)
            {
                WritePaychequeMgr.Store(s);
            }

            IList<BankingDetail> BankingDetails = rhs.BankingDetailMgr.FindAllCollection();
            foreach (BankingDetail s in BankingDetails)
            {
                BankingDetailMgr.Store(s);
            }

            IList<PaymentType> PaymentTypes = rhs.PaymentTypeMgr.FindAllCollection();
            foreach (PaymentType s in PaymentTypes)
            {
                PaymentTypeMgr.Store(s);
            }

            IList<BankDepositLine> BankDepositLines = rhs.BankDepositLineMgr.FindAllCollection();
            foreach (BankDepositLine s in BankDepositLines)
            {
                BankDepositLineMgr.Store(s);
            }

            IList<BankDeposit> BankDeposits = rhs.BankDepositMgr.FindAllCollection();
            foreach (BankDeposit s in BankDeposits)
            {
                BankDepositMgr.Store(s);
            }

            IList<RecurringItemSaleLine> RecurringItemSaleLines = rhs.RecurringItemSaleLineMgr.FindAllCollection();
            foreach (RecurringItemSaleLine s in RecurringItemSaleLines)
            {
                RecurringItemSaleLineMgr.Store(s);
            }

            IList<RecurringServiceSaleLine> RecurringServiceSaleLines = rhs.RecurringServiceSaleLineMgr.FindAllCollection();
            foreach (RecurringServiceSaleLine s in RecurringServiceSaleLines)
            {
                RecurringServiceSaleLineMgr.Store(s);
            }

            IList<RecurringMiscSaleLine> RecurringMiscSaleLines = rhs.RecurringMiscSaleLineMgr.FindAllCollection();
            foreach (RecurringMiscSaleLine s in RecurringMiscSaleLines)
            {
                RecurringMiscSaleLineMgr.Store(s);
            }

            IList<RecurringTimeBillingSaleLine> RecurringTimeBillingSaleLines = rhs.RecurringTimeBillingSaleLineMgr.FindAllCollection();
            foreach (RecurringTimeBillingSaleLine s in RecurringTimeBillingSaleLines)
            {
                RecurringTimeBillingSaleLineMgr.Store(s);
            }

            IList<RecurringProfessionalSaleLine> RecurringProfessionalSaleLines = rhs.RecurringProfessionalSaleLineMgr.FindAllCollection();
            foreach (RecurringProfessionalSaleLine s in RecurringProfessionalSaleLines)
            {
                RecurringProfessionalSaleLineMgr.Store(s);
            }

            IList<RecurringSaleLine> RecurringSaleLines = rhs.RecurringSaleLineMgr.FindAllCollection();
            foreach (RecurringSaleLine s in RecurringSaleLines)
            {
                RecurringSaleLineMgr.Store(s);
            }

            IList<RecurringSale> RecurringSales = rhs.RecurringSaleMgr.FindAllCollection();
            foreach (RecurringSale s in RecurringSales)
            {
                RecurringSaleMgr.Store(s);
            }

            IList<RecurringItemPurchaseLine> RecurringItemPurchaseLines = rhs.RecurringItemPurchaseLineMgr.FindAllCollection();
            foreach (RecurringItemPurchaseLine s in RecurringItemPurchaseLines)
            {
                RecurringItemPurchaseLineMgr.Store(s);
            }

            IList<RecurringServicePurchaseLine> RecurringServicePurchaseLines = rhs.RecurringServicePurchaseLineMgr.FindAllCollection();
            foreach (RecurringServicePurchaseLine s in RecurringServicePurchaseLines)
            {
                RecurringServicePurchaseLineMgr.Store(s);
            }

            IList<RecurringMiscPurchaseLine> RecurringMiscPurchaseLines = rhs.RecurringMiscPurchaseLineMgr.FindAllCollection();
            foreach (RecurringMiscPurchaseLine s in RecurringMiscPurchaseLines)
            {
                RecurringMiscPurchaseLineMgr.Store(s);
            }

            /*
            IList<RecurringTimeBillingPurchaseLine> RecurringTimeBillingPurchaseLines = rhs.RecurringTimeBillingPurchaseLineMgr.List();
            foreach (RecurringTimeBillingPurchaseLine s in RecurringTimeBillingPurchaseLines)
            {
                RecurringTimeBillingPurchaseLineMgr.Store(s);
            }
            */

            IList<RecurringProfessionalPurchaseLine> RecurringProfessionalPurchaseLines = rhs.RecurringProfessionalPurchaseLineMgr.FindAllCollection();
            foreach (RecurringProfessionalPurchaseLine s in RecurringProfessionalPurchaseLines)
            {
                RecurringProfessionalPurchaseLineMgr.Store(s);
            }

            IList<RecurringPurchaseLine> RecurringPurchaseLines = rhs.RecurringPurchaseLineMgr.FindAllCollection();
            foreach (RecurringPurchaseLine s in RecurringPurchaseLines)
            {
                RecurringPurchaseLineMgr.Store(s);
            }

            IList<RecurringPurchase> RecurringPurchases = rhs.RecurringPurchaseMgr.FindAllCollection();
            foreach (RecurringPurchase s in RecurringPurchases)
            {
                RecurringPurchaseMgr.Store(s);
            }

            IList<RecurringGeneralJournalLine> RecurringGeneralJournalLines = rhs.RecurringGeneralJournalLineMgr.FindAllCollection();
            foreach (RecurringGeneralJournalLine s in RecurringGeneralJournalLines)
            {
                RecurringGeneralJournalLineMgr.Store(s);
            }

            IList<RecurringGeneralJournal> RecurringGeneralJournals = rhs.RecurringGeneralJournalMgr.FindAllCollection();
            foreach (RecurringGeneralJournal s in RecurringGeneralJournals)
            {
                RecurringGeneralJournalMgr.Store(s);
            }

            IList<RecurringTransferMoney> RecurringTransferMoneys = rhs.RecurringTransferMoneyMgr.FindAllCollection();
            foreach (RecurringTransferMoney s in RecurringTransferMoneys)
            {
                RecurringTransferMoneyMgr.Store(s);
            }

            IList<RecurringMoneyReceivedLine> RecurringMoneyReceivedLines = rhs.RecurringMoneyReceivedLineMgr.FindAllCollection();
            foreach (RecurringMoneyReceivedLine s in RecurringMoneyReceivedLines)
            {
                RecurringMoneyReceivedLineMgr.Store(s);
            }

            IList<RecurringMoneyReceived> RecurringMoneyReceiveds = rhs.RecurringMoneyReceivedMgr.FindAllCollection();
            foreach (RecurringMoneyReceived s in RecurringMoneyReceiveds)
            {
                RecurringMoneyReceivedMgr.Store(s);
            }

            IList<RecurringMoneySpentLine> RecurringMoneySpentLines = rhs.RecurringMoneySpentLineMgr.FindAllCollection();
            foreach (RecurringMoneySpentLine s in RecurringMoneySpentLines)
            {
                RecurringMoneySpentLineMgr.Store(s);
            }

            IList<RecurringMoneySpent> RecurringMoneySpents = rhs.RecurringMoneySpentMgr.FindAllCollection();
            foreach (RecurringMoneySpent s in RecurringMoneySpents)
            {
                RecurringMoneySpentMgr.Store(s);
            }

            IList<NumberingType> NumberingTypes = rhs.NumberingTypeMgr.FindAllCollection();
            foreach (NumberingType s in NumberingTypes)
            {
                NumberingTypeMgr.Store(s);
            }

            IList<Frequency> Frequencys = rhs.FrequencyMgr.FindAllCollection();
            foreach (Frequency s in Frequencys)
            {
                FrequencyMgr.Store(s);
            }

            IList<EmployerExpenseType> EmployerExpenseTypes = rhs.EmployerExpenseTypeMgr.FindAllCollection();
            foreach (EmployerExpenseType s in EmployerExpenseTypes)
            {
                EmployerExpenseTypeMgr.Store(s);
            }

            IList<ContributionType> ContributionTypes = rhs.ContributionTypeMgr.FindAllCollection();
            foreach (ContributionType s in ContributionTypes)
            {
                ContributionTypeMgr.Store(s);
            }

            IList<CalculationMethod> CalculationMethods = rhs.CalculationMethodMgr.FindAllCollection();
            foreach (CalculationMethod s in CalculationMethods)
            {
                CalculationMethodMgr.Store(s);
            }

            IList<TerminationMethod> TerminationMethods = rhs.TerminationMethodMgr.FindAllCollection();
            foreach (TerminationMethod s in TerminationMethods)
            {
                TerminationMethodMgr.Store(s);
            }

            IList<DayName> DayNames = rhs.DayNameMgr.FindAllCollection();
            foreach (DayName s in DayNames)
            {
                DayNameMgr.Store(s);
            }

            IList<EmploymentStatus> EmploymentStatuss = rhs.EmploymentStatusMgr.FindAllCollection();
            foreach (EmploymentStatus s in EmploymentStatuss)
            {
                EmploymentStatusMgr.Store(s);
            }

            IList<EmploymentClassification> EmploymentClassifications = rhs.EmploymentClassificationMgr.FindAllCollection();
            foreach (EmploymentClassification s in EmploymentClassifications)
            {
                EmploymentClassificationMgr.Store(s);
            }

            IList<EmploymentBasis> EmploymentBasiss = rhs.EmploymentBasisMgr.FindAllCollection();
            foreach (EmploymentBasis s in EmploymentBasiss)
            {
                EmploymentBasisMgr.Store(s);
            }

            IList<AccountingBasis> AccountingBasiss = rhs.AccountingBasisMgr.FindAllCollection();
            foreach (AccountingBasis s in AccountingBasiss)
            {
                AccountingBasisMgr.Store(s);
            }

            IList<ImportantDates> ImportantDatess = rhs.ImportantDatesMgr.FindAllCollection();
            foreach (ImportantDates s in ImportantDatess)
            {
                ImportantDatesMgr.Store(s);
            }

            IList<AuditTrail> AuditTrails = rhs.AuditTrailMgr.FindAllCollection();
            foreach (AuditTrail s in AuditTrails)
            {
                AuditTrailMgr.Store(s);
            }

            IList<ElectronicPaymentLine> ElectronicPaymentLines = rhs.ElectronicPaymentLineMgr.FindAllCollection();
            foreach (ElectronicPaymentLine s in ElectronicPaymentLines)
            {
                ElectronicPaymentLineMgr.Store(s);
            }

            IList<ElectronicPayment> ElectronicPayments = rhs.ElectronicPaymentMgr.FindAllCollection();
            foreach (ElectronicPayment s in ElectronicPayments)
            {
                ElectronicPaymentMgr.Store(s);
            }

            IList<ActivitySlipInvoiced> ActivitySlipInvoiceds = rhs.ActivitySlipInvoicedMgr.FindAllCollection();
            foreach (ActivitySlipInvoiced s in ActivitySlipInvoiceds)
            {
                ActivitySlipInvoicedMgr.Store(s);
            }

            IList<ActivitySlip> ActivitySlips = rhs.ActivitySlipMgr.FindAllCollection();
            foreach (ActivitySlip s in ActivitySlips)
            {
                ActivitySlipMgr.Store(s);
            }

            IList<Wage> Wages = rhs.WageMgr.FindAllCollection();
            foreach (Wage s in Wages)
            {
                WageMgr.Store(s);
            }

            IList<ActivitySalesHistory> ActivitySalesHistorys = rhs.ActivitySalesHistoryMgr.FindAllCollection();
            foreach (ActivitySalesHistory s in ActivitySalesHistorys)
            {
                ActivitySalesHistoryMgr.Store(s);
            }

            IList<NegativeInventory> NegativeInventorys = rhs.NegativeInventoryMgr.FindAllCollection();
            foreach (NegativeInventory s in NegativeInventorys)
            {
                NegativeInventoryMgr.Store(s);
            }

            IList<BuildComponent> BuildComponents = rhs.BuildComponentMgr.FindAllCollection();
            foreach (BuildComponent s in BuildComponents)
            {
                BuildComponentMgr.Store(s);
            }

            IList<BuiltItem> BuiltItems = rhs.BuiltItemMgr.FindAllCollection();
            foreach (BuiltItem s in BuiltItems)
            {
                BuiltItemMgr.Store(s);
            }

            IList<ItemPurchasesHistory> ItemPurchasesHistorys = rhs.ItemPurchasesHistoryMgr.FindAllCollection();
            foreach (ItemPurchasesHistory s in ItemPurchasesHistorys)
            {
                ItemPurchasesHistoryMgr.Store(s);
            }

            IList<ItemSalesHistory> ItemSalesHistorys = rhs.ItemSalesHistoryMgr.FindAllCollection();
            foreach (ItemSalesHistory s in ItemSalesHistorys)
            {
                ItemSalesHistoryMgr.Store(s);
            }

            IList<ItemOpeningBalance> ItemOpeningBalances = rhs.ItemOpeningBalanceMgr.FindAllCollection();
            foreach (ItemOpeningBalance s in ItemOpeningBalances)
            {
                ItemOpeningBalanceMgr.Store(s);
            }

            IList<ItemMovement> ItemMovements = rhs.ItemMovementMgr.FindAllCollection();
            foreach (ItemMovement s in ItemMovements)
            {
                ItemMovementMgr.Store(s);
            }

            IList<ItemPrice> ItemPrices = rhs.ItemPriceMgr.FindAllCollection();
            foreach (ItemPrice s in ItemPrices)
            {
                ItemPriceMgr.Store(s);
            }


            IList<MoveItem> MoveItems = rhs.MoveItemMgr.FindAllCollection();
            foreach (MoveItem s in MoveItems)
            {
                MoveItemMgr.Store(s);
            }

            IList<Rounding> Roundings = rhs.RoundingMgr.FindAllCollection();
            foreach (Rounding s in Roundings)
            {
                RoundingMgr.Store(s);
            }

            IList<TaxInformationConsolidation> TaxInformationConsolidations = rhs.TaxInformationConsolidationMgr.FindAllCollection();
            foreach (TaxInformationConsolidation s in TaxInformationConsolidations)
            {
                TaxInformationConsolidationMgr.Store(s);
            }

            IList<TaxInformation> TaxInformations = rhs.TaxInformationMgr.FindAllCollection();
            foreach (TaxInformation s in TaxInformations)
            {
                TaxInformationMgr.Store(s);
            }

            IList<TaxCodeConsolidation> TaxCodeConsolidations = rhs.TaxCodeConsolidationMgr.FindAllCollection();
            foreach (TaxCodeConsolidation s in TaxCodeConsolidations)
            {
                TaxCodeConsolidationMgr.Store(s);
            }

            IList<EmploymentCategory> EmploymentCategorys = rhs.EmploymentCategoryMgr.FindAllCollection();
            foreach (EmploymentCategory s in EmploymentCategorys)
            {
                EmploymentCategoryMgr.Store(s);
            }

            IList<Schedule> Schedules = rhs.ScheduleMgr.FindAllCollection();
            foreach (Schedule s in Schedules)
            {
                ScheduleMgr.Store(s);
            }

            IList<PaymentValueType> ValueTypes = rhs.PaymentValueTypeMgr.FindAllCollection();
            foreach (PaymentValueType s in ValueTypes)
            {
                PaymentValueTypeMgr.Store(s);
            }

            IList<TaxScale> TaxScales = rhs.TaxScaleMgr.FindAllCollection();
            foreach (TaxScale s in TaxScales)
            {
                TaxScaleMgr.Store(s);
            }

            IList<AlertType> AlertTypes = rhs.AlertTypeMgr.FindAllCollection();
            foreach (AlertType s in AlertTypes)
            {
                AlertTypeMgr.Store(s);
            }

            IList<Alert> Alerts = rhs.AlertMgr.FindAllCollection();
            foreach (Alert s in Alerts)
            {
                AlertMgr.Store(s);
            }

            IList<LimitType> LimitTypes = rhs.LimitTypeMgr.FindAllCollection();
            foreach (LimitType s in LimitTypes)
            {
                LimitTypeMgr.Store(s);
            }

            IList<ReportingMethod> ReportingMethods = rhs.ReportingMethodMgr.FindAllCollection();
            foreach (ReportingMethod s in ReportingMethods)
            {
                ReportingMethodMgr.Store(s);
            }

            IList<ReconciliationStatus> ReconciliationStatuss = rhs.ReconciliationStatusMgr.FindAllCollection();
            foreach (ReconciliationStatus s in ReconciliationStatuss)
            {
                ReconciliationStatusMgr.Store(s);
            }

            IList<SalespersonHistory> SalespersonHistorys = rhs.SalespersonHistoryMgr.FindAllCollection();
            foreach (SalespersonHistory s in SalespersonHistorys)
            {
                SalespersonHistoryMgr.Store(s);
            }

            IList<InventoryTransferLine> InventoryTransferLines = rhs.InventoryTransferLineMgr.FindAllCollection();
            foreach (InventoryTransferLine s in InventoryTransferLines)
            {
                InventoryTransferLineMgr.Store(s);
            }

            IList<InventoryTransfer> InventoryTransfers = rhs.InventoryTransferMgr.FindAllCollection();
            foreach (InventoryTransfer s in InventoryTransfers)
            {
                InventoryTransferMgr.Store(s);
            }

            IList<InventoryAdjustmentLine> InventoryAdjustmentLines = rhs.InventoryAdjustmentLineMgr.FindAllCollection();
            foreach (InventoryAdjustmentLine s in InventoryAdjustmentLines)
            {
                InventoryAdjustmentLineMgr.Store(s);
            }

            IList<InventoryAdjustment> InventoryAdjustments = rhs.InventoryAdjustmentMgr.FindAllCollection();
            foreach (InventoryAdjustment s in InventoryAdjustments)
            {
                InventoryAdjustmentMgr.Store(s);
            }

            IList<DebitRefund> DebitRefunds = rhs.DebitRefundMgr.FindAllCollection();
            foreach (DebitRefund s in DebitRefunds)
            {
                DebitRefundMgr.Store(s);
            }

            IList<SettledDebitLine> SettledDebitLines = rhs.SettledDebitLineMgr.FindAllCollection();
            foreach (SettledDebitLine s in SettledDebitLines)
            {
                SettledDebitLineMgr.Store(s);
            }

            IList<SettledDebit> SettledDebits = rhs.SettledDebitMgr.FindAllCollection();
            foreach (SettledDebit s in SettledDebits)
            {
                SettledDebitMgr.Store(s);
            }

            IList<CreditRefund> CreditRefunds = rhs.CreditRefundMgr.FindAllCollection();
            foreach (CreditRefund s in CreditRefunds)
            {
                CreditRefundMgr.Store(s);
            }

            IList<SettledCreditLine> SettledCreditLines = rhs.SettledCreditLineMgr.FindAllCollection();
            foreach (SettledCreditLine s in SettledCreditLines)
            {
                SettledCreditLineMgr.Store(s);
            }

            IList<SettledCredit> SettledCredits = rhs.SettledCreditMgr.FindAllCollection();
            foreach (SettledCredit s in SettledCredits)
            {
                SettledCreditMgr.Store(s);
            }

            IList<SupplierFinanceCharge> SupplierFinanceCharges = rhs.SupplierFinanceChargeMgr.FindAllCollection();
            foreach (SupplierFinanceCharge s in SupplierFinanceCharges)
            {
                SupplierFinanceChargeMgr.Store(s);
            }

            IList<SupplierDeposit> SupplierDeposits = rhs.SupplierDepositMgr.FindAllCollection();
            foreach (SupplierDeposit s in SupplierDeposits)
            {
                SupplierDepositMgr.Store(s);
            }

            IList<SupplierDiscount> SupplierDiscounts = rhs.SupplierDiscountMgr.FindAllCollection();
            foreach (SupplierDiscount s in SupplierDiscounts)
            {
                SupplierDiscountMgr.Store(s);
            }

            IList<SupplierDiscountLine> SupplierDiscountLines = rhs.SupplierDiscountLineMgr.FindAllCollection();
            foreach (SupplierDiscountLine s in SupplierDiscountLines)
            {
                SupplierDiscountLineMgr.Store(s);
            }

            IList<SupplierPayment> SupplierPayments = rhs.SupplierPaymentMgr.FindAllCollection();
            foreach (SupplierPayment s in SupplierPayments)
            {
                SupplierPaymentMgr.Store(s);
            }

            IList<SupplierPaymentLine> SupplierPaymentLines = rhs.SupplierPaymentLineMgr.FindAllCollection();
            foreach (SupplierPaymentLine s in SupplierPaymentLines)
            {
                SupplierPaymentLineMgr.Store(s);
            }

            IList<CustomerFinanceCharge> CustomerFinanceCharges = rhs.CustomerFinanceChargeMgr.FindAllCollection();
            foreach (CustomerFinanceCharge s in CustomerFinanceCharges)
            {
                CustomerFinanceChargeMgr.Store(s);
            }

            IList<CustomerDeposit> CustomerDeposits = rhs.CustomerDepositMgr.FindAllCollection();
            foreach (CustomerDeposit s in CustomerDeposits)
            {
                CustomerDepositMgr.Store(s);
            }

            IList<CustomerDiscount> CustomerDiscounts = rhs.CustomerDiscountMgr.FindAllCollection();
            foreach (CustomerDiscount s in CustomerDiscounts)
            {
                CustomerDiscountMgr.Store(s);
            }

            IList<CustomerDiscountLine> CustomerDiscountLines = rhs.CustomerDiscountLineMgr.FindAllCollection();
            foreach (CustomerDiscountLine s in CustomerDiscountLines)
            {
                CustomerDiscountLineMgr.Store(s);
            }

            IList<CustomerPayment> CustomerPayments = rhs.CustomerPaymentMgr.FindAllCollection();
            foreach (CustomerPayment s in CustomerPayments)
            {
                CustomerPaymentMgr.Store(s);
            }

            IList<CustomerPaymentLine> CustomerPaymentLines = rhs.CustomerPaymentLineMgr.FindAllCollection();
            foreach (CustomerPaymentLine s in CustomerPaymentLines)
            {
                CustomerPaymentLineMgr.Store(s);
            }

            IList<PurchasesHistory> PurchasesHistories = rhs.PurchasesHistoryMgr.FindAllCollection();
            foreach (PurchasesHistory s in PurchasesHistories)
            {
                PurchasesHistoryMgr.Store(s);
            }

            IList<SalesHistory> SalesHistories = rhs.SalesHistoryMgr.FindAllCollection();
            foreach (SalesHistory s in SalesHistories)
            {
                SalesHistoryMgr.Store(s);
            }

            IList<DepositStatus> DepositStatuses = rhs.DepositStatusMgr.FindAllCollection();
            foreach (DepositStatus s in DepositStatuses)
            {
                DepositStatusMgr.Store(s);
            }

            IList<MoneySpent> MoneySpents = rhs.MoneySpentMgr.FindAllCollection();
            foreach (MoneySpent s in MoneySpents)
            {
                MoneySpentMgr.Store(s);
            }

            IList<MoneySpentLine> MoneySpentLines = rhs.MoneySpentLineMgr.FindAllCollection();
            foreach (MoneySpentLine s in MoneySpentLines)
            {
                MoneySpentLineMgr.Store(s);
            }

            IList<MoneyReceived> MoneyReceiveds = rhs.MoneyReceivedMgr.FindAllCollection();
            foreach (MoneyReceived s in MoneyReceiveds)
            {
                MoneyReceivedMgr.Store(s);
            }

            IList<MoneyReceivedLine> MoneyReceivedLines = rhs.MoneyReceivedLineMgr.FindAllCollection();
            foreach (MoneyReceivedLine s in MoneyReceivedLines)
            {
                MoneyReceivedLineMgr.Store(s);
            }


            IList<JobJournalRecord> JobJournalRecords = rhs.JobJournalRecordMgr.FindAllCollection();
            foreach (JobJournalRecord s in JobJournalRecords)
            {
                JobJournalRecordMgr.Store(s);
            }

            IList<JobBudget> JobBudgets = rhs.JobBudgetMgr.FindAllCollection();
            foreach (JobBudget s in JobBudgets)
            {
                JobBudgetMgr.Store(s);
            }

            IList<JobAccountActivity> JobAccountActivities = rhs.JobAccountActivityMgr.FindAllCollection();
            foreach (JobAccountActivity s in JobAccountActivities)
            {
                JobAccountActivityMgr.Store(s);
            }

            IList<JobAccount> JobAccounts = rhs.JobAccountMgr.FindAllCollection();
            foreach (JobAccount s in JobAccounts)
            {
                JobAccountMgr.Store(s);
            }

            IList<ItemLocation> ItemLocations = rhs.ItemLocationMgr.FindAllCollection();
            foreach (ItemLocation s in ItemLocations)
            {
                ItemLocationMgr.Store(s);
            }

            IList<LinkedAccount> LinkedAccounts = rhs.LinkedAccountMgr.FindAllCollection();
            foreach (LinkedAccount s in LinkedAccounts)
            {
                LinkedAccountMgr.Store(s);
            }

            IList<DataFileInformation> DataFileInformations = rhs.DataFileInformationMgr.FindAllCollection();
            foreach (DataFileInformation s in DataFileInformations)
            {
                DataFileInformationMgr.Store(s);
            }

            IList<AccountBudget> AccountBudgets = rhs.AccountBudgetMgr.FindAllCollection();
            foreach (AccountBudget s in AccountBudgets)
            {
                AccountBudgetMgr.Store(s);
            }

            IList<AccountActivity> AccountActivities = rhs.AccountActivityMgr.FindAllCollection();
            foreach (AccountActivity s in AccountActivities)
            {
                AccountActivityMgr.Store(s);
            }

            IList<PaymentMethod> PaymentMethods = rhs.PaymentMethodMgr.FindAllCollection();
            foreach (PaymentMethod s in PaymentMethods)
            {
                PaymentMethodMgr.Store(s);
            }

            IList<BillingRateUsed> BillingRateUseds = rhs.BillingRateUsedMgr.FindAllCollection();
            foreach (BillingRateUsed s in BillingRateUseds)
            {
                BillingRateUsedMgr.Store(s);
            }

            IList<ReferralSource> ReferralSources = rhs.ReferralSourceMgr.FindAllCollection();
            foreach (ReferralSource s in ReferralSources)
            {
                ReferralSourceMgr.Store(s);
            }

            IList<ContactLog> ContactLogs = rhs.ContactLogMgr.FindAllCollection();
            foreach (ContactLog s in ContactLogs)
            {
                ContactLogMgr.Store(s);
            }

            IList<AccountType> AccountTypes = rhs.AccountTypeMgr.FindAllCollection();
            foreach (AccountType s in AccountTypes)
            {
                AccountTypeMgr.Store(s);
            }

            IList<SubAccountType> SubAccountTypes = rhs.SubAccountTypeMgr.FindAllCollection();
            foreach (SubAccountType s in SubAccountTypes)
            {
                SubAccountTypeMgr.Store(s);
            }

            IList<AccountClassification> AccountClassifications = rhs.AccountClassificationMgr.FindAllCollection();
            foreach (AccountClassification s in AccountClassifications)
            {
                AccountClassificationMgr.Store(s);
            }

            IList<CashFlowClassification> CashFlowClassifications = rhs.CashFlowClassificationMgr.FindAllCollection();
            foreach (CashFlowClassification s in CashFlowClassifications)
            {
                CashFlowClassificationMgr.Store(s);
            }

            IList<ShippingMethod> ShippingMethods = rhs.ShippingMethodMgr.FindAllCollection();
            foreach (ShippingMethod s in ShippingMethods)
            {
                ShippingMethodMgr.Store(s);
            }

            IList<CustomList> CustomLists = rhs.CustomListMgr.FindAllCollection();
            foreach (CustomList s in CustomLists)
            {
                CustomListMgr.Store(s);
            }

            IList<Comment> Comments = rhs.CommentMgr.FindAllCollection();
            foreach (Comment s in Comments)
            {
                CommentMgr.Store(s);
            }

            IList<Address> Addresss = rhs.AddressMgr.FindAllCollection();
            foreach (Address s in Addresss)
            {
                AddressMgr.Store(s);
            }

            IList<Activity> Activitys = rhs.ActivityMgr.FindAllCollection();
            foreach (Activity s in Activitys)
            {
                ActivityMgr.Store(s);
            }

            IList<GeneralJournal> GeneralJournals = rhs.GeneralJournalMgr.FindAllCollection();
            foreach (GeneralJournal s in GeneralJournals)
            {
                GeneralJournalMgr.Store(s);
            }

            IList<GeneralJournalLine> GeneralJournalLines = rhs.GeneralJournalLineMgr.FindAllCollection();
            foreach (GeneralJournalLine s in GeneralJournalLines)
            {
                GeneralJournalLineMgr.Store(s);
            }

            IList<TaxCode> TaxCodes = rhs.TaxCodeMgr.FindAllCollection();
            foreach (TaxCode s in TaxCodes)
            {
                TaxCodeMgr.Store(s);
            }

            IList<InvoiceDelivery> InvoiceDeliverys = rhs.InvoiceDeliveryMgr.FindAllCollection();
            foreach (InvoiceDelivery s in InvoiceDeliverys)
            {
                InvoiceDeliveryMgr.Store(s);
            }

            IList<JournalType> JournalTypes = rhs.JournalTypeMgr.FindAllCollection();
            foreach (JournalType s in JournalTypes)
            {
                JournalTypeMgr.Store(s);
            }

            IList<JournalSet> JournalSets = rhs.JournalSetMgr.FindAllCollection();
            foreach (JournalSet s in JournalSets)
            {
                JournalSetMgr.Store(s);
            }

            IList<JournalRecord> JournalRecords = rhs.JournalRecordMgr.FindAllCollection();
            foreach (JournalRecord s in JournalRecords)
            {
                JournalRecordMgr.Store(s);
            }

            IList<CardType> CardTypes = rhs.CardTypeMgr.FindAllCollection();
            foreach (CardType s in CardTypes)
            {
                CardTypeMgr.Store(s);
            }

            IList<InvoiceType> InvoiceTypes = rhs.InvoiceTypeMgr.FindAllCollection();
            foreach (InvoiceType s in InvoiceTypes)
            {
                InvoiceTypeMgr.Store(s);
            }

            IList<Currency> Currencys = rhs.CurrencyMgr.FindAllCollection();
            foreach (Currency s in Currencys)
            {
                CurrencyMgr.Store(s);
            }

            IList<TermsOfPayment> TermsOfPayments = rhs.TermsOfPaymentMgr.FindAllCollection();
            foreach (TermsOfPayment s in TermsOfPayments)
            {
                TermsOfPaymentMgr.Store(s);
            }

            IList<PriceLevel> PriceLevels = rhs.PriceLevelMgr.FindAllCollection();
            foreach (PriceLevel s in PriceLevels)
            {
                PriceLevelMgr.Store(s);
            }

            IList<Terms> Termss = rhs.TermsMgr.FindAllCollection();
            foreach (Terms s in Termss)
            {
                TermsMgr.Store(s);
            }

            IList<Location> Locations = rhs.LocationMgr.FindAllCollection();
            foreach (Location s in Locations)
            {
                LocationMgr.Store(s);
            }

            IList<Account> Accounts = rhs.AccountMgr.FindAllCollection();
            foreach (Account s in Accounts)
            {
                AccountMgr.Store(s);
            }

            IList<Card> Cards = rhs.CardMgr.FindAllCollection();
            foreach (Card s in Cards)
            {
                CardMgr.Store(s);
            }

            IList<CardActivity> CardActivities = rhs.CardActivityMgr.FindAllCollection();
            foreach (CardActivity s in CardActivities)
            {
                CardActivityMgr.Store(s);
            }

            IList<PersonalCard> PersonalCards = rhs.PersonalCardMgr.FindAllCollection();
            foreach (PersonalCard s in PersonalCards)
            {
                PersonalCardMgr.Store(s);
            }


            IList<Supplier> Suppliers = rhs.SupplierMgr.FindAllCollection();
            foreach (Supplier s in Suppliers)
            {
                SupplierMgr.Store(s);
            }

            IList<Employee> Employees = rhs.EmployeeMgr.FindAllCollection();
            foreach (Employee s in Employees)
            {
                EmployeeMgr.Store(s);
            }

            IList<Customer> Customers = rhs.CustomerMgr.FindAllCollection();
            foreach (Customer s in Customers)
            {
                CustomerMgr.Store(s);
            }

            IList<Item> Items = rhs.ItemMgr.FindAllCollection();
            foreach (Item s in Items)
            {
                ItemMgr.Store(s);
            }

            IList<Job> Jobs = rhs.JobMgr.FindAllCollection();
            foreach (Job s in Jobs)
            {
                JobMgr.Store(s);
            }

            IList<Status> Statuss = rhs.StatusMgr.FindAllCollection();
            foreach (Status s in Statuss)
            {
                StatusMgr.Store(s);
            }

            IList<ItemPurchaseLine> ItemPurchaseLines = rhs.ItemPurchaseLineMgr.FindAllCollection();
            foreach (ItemPurchaseLine s in ItemPurchaseLines)
            {
                ItemPurchaseLineMgr.Store(s);
            }
            
            IList<ServicePurchaseLine> ServicePurchaseLines = rhs.ServicePurchaseLineMgr.FindAllCollection();
            foreach (ServicePurchaseLine s in ServicePurchaseLines)
            {
                ServicePurchaseLineMgr.Store(s);
            }
            
            IList<MiscPurchaseLine> MiscPurchaseLines = rhs.MiscPurchaseLineMgr.FindAllCollection();
            foreach (MiscPurchaseLine s in MiscPurchaseLines)
            {
                MiscPurchaseLineMgr.Store(s);
            }
            
            IList<ProfessionalPurchaseLine> ProfessionalPurchaseLines = rhs.ProfessionalPurchaseLineMgr.FindAllCollection();
            foreach (ProfessionalPurchaseLine s in ProfessionalPurchaseLines)
            {
                ProfessionalPurchaseLineMgr.Store(s);
            }
            
            IList<PurchaseLine> PurchaseLines = rhs.PurchaseLineMgr.FindAllCollection();
            foreach (PurchaseLine s in PurchaseLines)
            {
                PurchaseLineMgr.Store(s);
            }

            IList<Purchase> Purchases = rhs.PurchaseMgr.FindAllCollection();
            foreach (Purchase s in Purchases)
            {
                PurchaseMgr.Store(s);
            }

            IList<ItemSaleLine> ItemSaleLines = rhs.ItemSaleLineMgr.FindAllCollection();
            foreach (ItemSaleLine s in ItemSaleLines)
            {
                ItemSaleLineMgr.Store(s);
            }
            
            IList<ServiceSaleLine> ServiceSaleLines = rhs.ServiceSaleLineMgr.FindAllCollection();
            foreach (ServiceSaleLine s in ServiceSaleLines)
            {
                ServiceSaleLineMgr.Store(s);
            }
            
            IList<MiscSaleLine> MiscSaleLines = rhs.MiscSaleLineMgr.FindAllCollection();
            foreach (MiscSaleLine s in MiscSaleLines)
            {
                MiscSaleLineMgr.Store(s);
            }
            
            IList<TimeBillingSaleLine> TimeBillingSaleLines = rhs.TimeBillingSaleLineMgr.FindAllCollection();
            foreach (TimeBillingSaleLine s in TimeBillingSaleLines)
            {
                TimeBillingSaleLineMgr.Store(s);
            }
            
            IList<ProfessionalSaleLine> ProfessionalSaleLines = rhs.ProfessionalSaleLineMgr.FindAllCollection();
            foreach (ProfessionalSaleLine s in ProfessionalSaleLines)
            {
                ProfessionalSaleLineMgr.Store(s);
            }
            
            IList<SaleLine> SaleLines = rhs.SaleLineMgr.FindAllCollection();
            foreach (SaleLine s in SaleLines)
            {
                SaleLineMgr.Store(s);
            }

            IList<Sale> Sales = rhs.SaleMgr.FindAllCollection();
            foreach (Sale s in Sales)
            {
                SaleMgr.Store(s);
            }

            IList<TransferMoney> TransferMoneys = rhs.TransferMoneyMgr.FindAllCollection();
            foreach (TransferMoney s in TransferMoneys)
            {
                TransferMoneyMgr.Store(s);
            }

            EndImporting();
            rhs.EndExporting();
        }

        private Sales.BOSaleFactory mSaleFactory = null;
        public Sales.BOSaleFactory SaleFactory
        {
            get
            {
                if (mSaleFactory == null)
                {
                    mSaleFactory = CreateSaleFactory();
                }
                return mSaleFactory;
            }
        }
        protected virtual Sales.BOSaleFactory CreateSaleFactory()
        {
            return new Sales.BOSaleFactory(this);
        }

        private Purchases.BOPurchaseFactory mPurchaseFactory = null;
        public Purchases.BOPurchaseFactory PurchaseFactory
        {
            get
            {
                if (mPurchaseFactory == null)
                {
                    mPurchaseFactory = CreatePurchaseFactory();
                }
                return mPurchaseFactory;
            }
        }
        protected virtual Purchases.BOPurchaseFactory CreatePurchaseFactory()
        {
            return new Purchases.BOPurchaseFactory(this);
        }

        public Purchases.PurchaseLines.BOPurchaseLine CreatePurchaseLine(Purchase purchase)
        {
            InvoiceType purchase_type = purchase.PurchaseType;
            if (purchase_type == null)
            {
                return null;
            }

            
            if (purchase_type.IsItem)
            {
                return new Purchases.PurchaseLines.BOItemPurchaseLine(
                    this, 
                    purchase,
                    ItemPurchaseLineMgr.CreateEntity(), 
                    BusinessObject.BOContext.Record_Create);
            }
            else if (purchase_type.IsService)
            {
                return new Purchases.PurchaseLines.BOServicePurchaseLine(
                   this,
                   purchase,
                   ServicePurchaseLineMgr.CreateEntity(),
                   BusinessObject.BOContext.Record_Create);
            }
            else if (purchase_type.IsMisc)
            {
                return new Purchases.PurchaseLines.BOMiscPurchaseLine(
                   this,
                   purchase,
                   MiscPurchaseLineMgr.CreateEntity(),
                   BusinessObject.BOContext.Record_Create);
            }
            else if (purchase_type.IsProfessional)
            {
                return new Purchases.PurchaseLines.BOProfessionalPurchaseLine(
                   this,
                   purchase,
                   ProfessionalPurchaseLineMgr.CreateEntity(),
                   BusinessObject.BOContext.Record_Create);
            }
            else if (purchase_type.IsTimeBilling)
            {
                return new Purchases.PurchaseLines.BOTimeBillingPurchaseLine(
                   this,
                   purchase,
                   TimeBillingPurchaseLineMgr.CreateEntity(),
                   BusinessObject.BOContext.Record_Create);
            }

            return null;
        }

        public BORole CreateAuthRole()
        {
            AuthRole data = AuthRoleMgr.CreateEntity();
            return new BORole(this, data, BusinessObject.BOContext.Record_Create);
        }

        public BOUser CreateAuthUser()
        {
            AuthUser data = AuthUserMgr.CreateEntity();
            return new BOUser(this, data, BusinessObject.BOContext.Record_Create);
        }

        public BOUser OpenAuthUser(AuthUser data)
        {
            return new BOUser(this, data, BusinessObject.BOContext.Record_Update);
        }

        public BORole OpenAuthRole(AuthRole data)
        {
            return new BORole(this, data, BusinessObject.BOContext.Record_Update);
        }


        public Purchases.PurchaseLines.BOPurchaseLine OpenPurchaseLine(PurchaseLine _line)
        {
            if(_line==null) return null;
            Purchase purchase=_line.Purchase;

            if (_line is ItemPurchaseLine)
            {
                return new Purchases.PurchaseLines.BOItemPurchaseLine(this, purchase, _line as ItemPurchaseLine, BusinessObject.BOContext.Record_Update);
            }
            else if (_line is ServicePurchaseLine)
            {
                return new Purchases.PurchaseLines.BOServicePurchaseLine(this, purchase, _line as ServicePurchaseLine, BusinessObject.BOContext.Record_Update);
            }
            else if (_line is MiscPurchaseLine)
            {
                return new Purchases.PurchaseLines.BOMiscPurchaseLine(this, purchase, _line as MiscPurchaseLine, BusinessObject.BOContext.Record_Update);
            }
            else if (_line is ProfessionalPurchaseLine)
            {
                return new Purchases.PurchaseLines.BOProfessionalPurchaseLine(this, purchase, _line as ProfessionalPurchaseLine, BusinessObject.BOContext.Record_Update);
            }
            else if (_line is TimeBillingPurchaseLine)
            {
                return new Purchases.PurchaseLines.BOTimeBillingPurchaseLine(this, purchase, _line as TimeBillingPurchaseLine, BusinessObject.BOContext.Record_Update);
            }
            return null;
        }

        public Sales.SaleLines.BOSaleLine OpenSaleLine(SaleLine _line)
        {
            if (_line == null) return null;
            Sale sale = _line.Sale;

            if (_line is ItemSaleLine)
            {
                return new Sales.SaleLines.BOItemSaleLine(this, sale, _line as ItemSaleLine, BusinessObject.BOContext.Record_Update);
            }
            else if (_line is ServiceSaleLine)
            {
                return new Sales.SaleLines.BOServiceSaleLine(this, sale, _line as ServiceSaleLine, BusinessObject.BOContext.Record_Update);
            }
            else if (_line is MiscSaleLine)
            {
                return new Sales.SaleLines.BOMiscSaleLine(this, sale, _line as MiscSaleLine, BusinessObject.BOContext.Record_Update);
            }
            else if (_line is ProfessionalSaleLine)
            {
                return new Sales.SaleLines.BOProfessionalSaleLine(this, sale, _line as ProfessionalSaleLine, BusinessObject.BOContext.Record_Update);
            }
            else if (_line is TimeBillingSaleLine)
            {
                return new Sales.SaleLines.BOTimeBillingSaleLine(this, sale, _line as TimeBillingSaleLine, BusinessObject.BOContext.Record_Update);
            }
            return null;
        }

        public void DeleteSaleLine(SaleLine _line)
        {
            Sale _sale=_line.Sale;
            _sale.SaleLines.Remove(_line);

            //Sales.SaleLines.BOSaleLine model = OpenSaleLine(_line);
            //model.Delete();
        }

        public void DeletePurchaseLine(PurchaseLine _line)
        {
            Purchase _purchase = _line.Purchase;

            //Console.WriteLine("Count: {0}", _purchase.PurchaseLines.Count);

            _purchase.PurchaseLines.Remove(_line);
            _purchase.Evaluate();

            //Console.WriteLine("Count: {0}", _purchase.PurchaseLines.Count);

            //Purchases.PurchaseLines.BOPurchaseLine model = OpenPurchaseLine(_line);
            //model.Delete();
        }

        public Inventory.BOInventoryAdjustment CreateInventoryAdjustment()
        {
            InventoryAdjustment data = InventoryAdjustmentMgr.CreateEntity();
            Inventory.BOInventoryAdjustment model = new Accounting.Bll.Inventory.BOInventoryAdjustment(this, data, BusinessObject.BOContext.Record_Create);
            return model;
        }

        public Inventory.BOInventoryAdjustmentLine CreateInventoryAdjustmentLine(InventoryAdjustment ia)
        {
            InventoryAdjustmentLine data = InventoryAdjustmentLineMgr.CreateEntity();
            data.InventoryAdjustment = ia;
            Inventory.BOInventoryAdjustmentLine model = new Accounting.Bll.Inventory.BOInventoryAdjustmentLine(this, ia, data, BusinessObject.BOContext.Record_Create);
            return model;
        }

        public Inventory.BOInventoryAdjustmentLine OpenInventoryAdjustmentLine(InventoryAdjustmentLine line)
        {
            Inventory.BOInventoryAdjustmentLine model = new Accounting.Bll.Inventory.BOInventoryAdjustmentLine(this, line.InventoryAdjustment, line, BusinessObject.BOContext.Record_Update);
            return model;
        }

        internal object GenerateInventoryJournalNumber()
        {
            return MiscNumberMgr.GenerateInventoryJournalNumber();
        }
    }

    
}
