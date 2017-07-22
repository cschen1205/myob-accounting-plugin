using System;
using System.Collections.Generic;
using System.Text;

namespace DacII.Presenters
{
    using Accounting.Bll;
    using Accounting.Bll.Im;
    using Accounting.Bll.Cards;
    using Accounting.Bll.Inventory;
    using Accounting.Bll.Purchases;
    using Accounting.Bll.Sales;
    using Accounting.Bll.Security;
    using Accounting.Bll.Definitions;
    using Accounting.Bll.Jobs;
    using Accounting.Bll.Accounts;
    using Accounting.Bll.Purchases.PurchaseLines;
    using Accounting.Bll.Sales.SaleLines;

    using Accounting.Core.Definitions;
    using Accounting.Core.Inventory;
    using Accounting.Core.Security;
    using Accounting.Core.Cards;
    using Accounting.Core.Purchases;
    using Accounting.Core.Sales;
    using Accounting.Core.Jobs;
    using Accounting.Core.Accounts;
    using Accounting.Core.Misc;
    using Accounting.Core.Terms;
    using Accounting.Core.ShippingMethods;
    using Accounting.Core.TaxCodes;
    using Accounting.Core.Currencies;
    using Accounting.Core.Activities;
    using Accounting.Core.Payroll;

    using Accounting.Db;
    using Accounting.Db.MySQL;
    using Accounting.Db.SqlClient;
  
    using SwissArmyKnife.Net;

    using Barcode.Code128;
    using System.Drawing;
    using System.Windows.Forms;

    public class ApplicationPresenter : Notifier
    {
        List<string> mGenders;
        public IList<string> FindAllGenders()
        {
            if (mGenders == null)
            {
                mGenders = new List<string>();
                mGenders.Add("M");
                mGenders.Add("F");
            }
            return mGenders;
        }

        public bool SupportMultiCurrency
        {
            get
            {
                return mAccountant.CurrencyMgr.SupportMultiCurrency;
            }
        }

        public IList<SuperannuationFund> FindAllSuperannuationFunds()
        {
            return mAccountant.SuperannuationFundMgr.FindAllCollection();
        }

        public IList<TaxScale> FindAllTaxScales()
        {
            return mAccountant.TaxScaleMgr.FindAllCollection();
        }

        public IList<EmploymentCategory> FindAllEmploymentCategories()
        {
            return mAccountant.EmploymentCategoryMgr.FindAllCollection();
        }

        public IList<EmploymentStatus> FindAllEmploymentStatuses()
        {
            return mAccountant.EmploymentStatusMgr.FindAllCollection();
        }

        public IList<Supplier> FindAllSuppliers()
        {
            return mAccountant.SupplierMgr.FindAllCollection();
        }

        public IList<Status> FindAllPurchaseStatuses()
        {
            return mAccountant.StatusMgr.ListPurchaseStatus();
        }

        public IList<Status> FindAllExistingPurchaseStatuses()
        {
            return mAccountant.PurchaseMgr.ListPurchaseStatus();
        }

        public IList<InvoiceType> FindAllPurchaseLayouts()
        {
            return mAccountant.InvoiceTypeMgr.FindAllCollection();
        }

        List<string> mNumberOfAccounts =null;
        public IList<string> FindNumberOfBankAccounts()
        {
            if(mNumberOfAccounts==null)
            {
                mNumberOfAccounts= new List<string>();
                mNumberOfAccounts.Add("1");
                mNumberOfAccounts.Add("2");
                mNumberOfAccounts.Add("3");
            }
            return mNumberOfAccounts;
        }

        public IList<PaymentValueType> FindAllBank1ValueTypes()
        {
            return mAccountant.PaymentValueTypeMgr.FindAllCollection();
        }

         public IList<PaymentValueType> FindAllBank2ValueTypes()
        {
            return mAccountant.PaymentValueTypeMgr.FindAllCollection();
        }

         public IList<PaymentValueType> FindAllBank3ValueTypes()
        {
            return mAccountant.PaymentValueTypeMgr.FindAllCollection();
        }

        public IList<EmploymentClassification> FindAllEmploymentClassifications()
        {
            return mAccountant.EmploymentClassificationMgr.FindAllCollection();
        }

        public IList<EmploymentBasis> FindAllEmploymentBasis()
        {
            return mAccountant.EmploymentBasisMgr.FindAllCollection();
        }

        public IList<PayBasis> FindAllPayBasis()
        {
            return mAccountant.PayBasisMgr.FindAllCollection();
        }

        public IList<Frequency> FindAllPayFrequencies()
        {
             return mAccountant.FrequencyMgr.FindAllCollection();
        }

        public IList<Account> FindAllWagesExpenseAccounts()
        {
            return mAccountant.AccountMgr.FindExpenseCollection();
        }

        public IList<PaymentType> FindAllPaymentTypes()
        {
            return mAccountant.PaymentTypeMgr.FindAllCollection();
        }

        public IList<AuthRole> FindAllAuthRoles()
        {
            return mAccountant.AuthRoleMgr.FindAllCollection();
        }

        public IList<AuthUser> FindAllAuthUsers()
        {
            return mAccountant.AuthUserMgr.FindAllCollection();
        }

        public IList<Customer> FindAllCustomers()
        {
            return mAccountant.CustomerMgr.FindAllCollection();
        }

        public IList<Employee> FindAllEmployees()
        {
            return mAccountant.EmployeeMgr.FindAllCollection();
        }

        public IList<Comment> FindAllComments()
        {
            return mAccountant.CommentMgr.FindAllCollection();
        }

        public IList<Terms> FindAllTerms()
        {
            return mAccountant.TermsMgr.FindAllCollection();
        }

        public IList<InvoiceDelivery> FindInvoiceDeliveries()
        {
            return mAccountant.InvoiceDeliveryMgr.FindAllCollection();
        }

        public IList<ShippingMethod> FindAllShippingMethods()
        {
            return mAccountant.ShippingMethodMgr.FindAllCollection();
        }

        public IList<TaxCode> FindAllTaxCodes()
        {
            return mAccountant.TaxCodeMgr.FindAllCollection();
        }

        public IList<Item> FindAllSoldItems()
        {
            return mAccountant.ItemMgr.FindSoldItemCollection();
        }

        public IList<ReferralSource> FindAllReferralSources()
        {
            return mAccountant.ReferralSourceMgr.FindAllCollection();
        }

        public IList<InvoiceType> FindAllSaleLayouts()
        {
            return mAccountant.InvoiceTypeMgr.FindAllCollection();
        }

        public IList<Currency> FindAllCurrencies()
        {
            return mAccountant.CurrencyMgr.FindAllCollection(); 
        }

        public IList<Account> FindAllFromAccounts()
        {
            return mAccountant.AccountMgr.List("1-2100");
        }

        public IList<Account> FindAllToAccounts()
        {
            return mAccountant.AccountMgr.List("1-2100");
        }

        List<string> mAddresses = null;
        public IList<string> FindAllAddresses()
        {
            if (mAddresses == null)
            {
                mAddresses = new List<string>();
                mAddresses.Add("Address 1");
                mAddresses.Add("Address 2");
                mAddresses.Add("Address 3");
                mAddresses.Add("Address 4");
                mAddresses.Add("Address 5");
            }

            return mAddresses;
        }

        public IList<Status> FindAllSaleStatuses()
        {
            return mAccountant.StatusMgr.FindSaleStatusCollection();
        }

        public IList<Status> FindAllExistingSaleStatuses()
        {
            return mAccountant.SaleMgr.RetrieveInvoiceStatuses();
        }

        public IList<Account> FindAllAccounts()
        {
            return mAccountant.AccountMgr.FindAllCollection();
        }

        public IList<Job> FindAllJobs()
        {
            return mAccountant.JobMgr.FindAllCollection();
        }

        public IList<Location> FindAllLocations()
        {
            return mAccountant.LocationMgr.FindAllCollection();
        }

        public IList<Item> FindAllBoughtItems()
        {
            return mAccountant.ItemMgr.FindBoughtItemCollection();
        }

        public IList<Activity> FindAllActivities()
        {
            return mAccountant.ActivityMgr.FindAllCollection();
        }

        public ApplicationPresenter(Accountant acc)
        {
            mAccountant = acc;
        }

        

        public IList<PriceLevel> FindAllPriceLevels()
        {
            return mAccountant.PriceLevelMgr.FindAllCollection();
        }

        public IList<DataField> FindAllDataFieldsForItemAddOn()
        {
             return mAccountant.DataFieldMgr.FindAllCollection();
        }

        public IList<Account> FindAllIncomeAccounts()
        {
            return mAccountant.AccountMgr.FindIncomeCollection();
        }

        public IList<Account> FindAllExpenseAccounts()
        {
            return mAccountant.AccountMgr.FindExpenseCollection();
        }

        public IList<Account> FindAllInventoryAccounts()
        {
            return mAccountant.AccountMgr.FindAssetCollection();
        }

        public IList<Gender> FindAllGendersForItemAddOn()
        {
            return mAccountant.GenderMgr.FindAllCollection();
        }

        public IList<ItemSize> FindAllItemSizesForItemAddOn()
        {
            return mAccountant.ItemSizeMgr.FindAllCollection();
        }

        public IList<InvoiceDelivery> FindallInvoiceDeliveries()
        {
            return mAccountant.InvoiceDeliveryMgr.FindAllCollection();
        }

        public IList<InvoiceType> FindAllInvoiceTypes()
        {
            return mAccountant.InvoiceTypeMgr.FindAllCollection();
        }

        SecurityPresenter mSecurityPresenter;
        public SecurityPresenter SecurityPresenter
        {
            set
            {
                mSecurityPresenter = value;
            }
        }

        MiscPresenter mMiscPresenter;
        public MiscPresenter MiscPresenter
        {
            set
            {
                mMiscPresenter = value;
            }
        }

        SetupPresenter mSetupPresenter;
        public SetupPresenter SetupPresenter
        {
            set
            {
                mSetupPresenter = value;
            }
        }

        public IList<AccountType> FindAllAccountTypes()
        {
            return mAccountant.AccountTypeMgr.FindAllCollection();
        }

        public IList<AccountClassification> FindAllAccountClassifications()
        {
            return mAccountant.AccountClassificationMgr.FindAllCollection();
        }

        public IList<CashFlowClassification> FindAllCashFlowClassification()
        {
            return mAccountant.CashFlowClassificationMgr.FindAllCollection();
        }

        public IList<SubAccountType> FindAllSubAccountTypes()
        {
            return mAccountant.SubAccountTypeMgr.FindAllCollection();
        }

        public IList<PaymentMethod> FindAllPaymentMethods()
        {
            return mAccountant.PaymentMethodMgr.FindAllCollection();
        }

        InventoryPresenter mInventoryPresenter;
        public InventoryPresenter InventoryPresenter
        {
            set
            {
                mInventoryPresenter = value;
            }
        }

        DefinitionPresenter mDefinitionPresenter;
        public DefinitionPresenter DefinitionPresenter
        {
            set
            {
                mDefinitionPresenter = value;
            }
        }

        SalePresenter mSalePresenter;
        public SalePresenter SalePresenter
        {
            set
            {
                mSalePresenter = value;
            }
        }

        PurchasePresenter mPurchasePresenter;
        public PurchasePresenter PurchasePresenter
        {
            set
            {
                mPurchasePresenter = value;
            }
        }

        JobPresenter mJobPresenter;
        public JobPresenter JobPresenter
        {
            set
            {
                mJobPresenter = value;
            }
        }

        AccountPresenter mAccountPresenter;
        public AccountPresenter AccountPresenter
        {
            set
            {
                mAccountPresenter = value;
            }
        }

        CardPresenter mCardPresenter;
        public CardPresenter CardPresenter
        {
            set
            {
                mCardPresenter = value;
            }
        }

        private bool mAquaStyleEnabled = false;
        public bool AquaStyleEnabled
        {
            get
            {
                return mAquaStyleEnabled;
            }
            set
            {
                mAquaStyleEnabled = value;
                System.Windows.Forms.CZRoundedGroupBox.GroupBoxCaptionStyle = System.Windows.Forms.CZRoundedGroupBox.CaptionStyle.Office2007;
                OnPropertyChanged("AquaStyleEnabled");
            }
        }

        public void Email(string subject, string body, params string[] attachments)
        {
            mMiscPresenter.ShowEmail(mAccountant.CreateEmail(subject, body, attachments));
        }

        public string GetFullPath(string filename)
        {
            return mAccountant.GetFullPath(filename);
        }

        public void Login()
        {
            bool validated = false;
            DacII.WinForms.Security.FrmMyobLogin frm = new DacII.WinForms.Security.FrmMyobLogin(mAccountant);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                validated = true;
            }

            if (!validated)
            {
                Exit();
            }
            else
            {
                BOUser curr_user = mAccountant.CurrentAuthUser;
                if (curr_user != null)
                {
                    AuthRole curr_role = curr_user.Role;
                    IsFullControl = curr_role == null || curr_role.IsFullControl;
                    Username = curr_user.Username;
                }

                ShowCmd();

                mMiscPresenter.BackupEnabled = true;
            }
        }

        private string mStatus;
        public string Status
        {
            get
            {
                return mStatus;
            }
            set
            {
                mStatus = value;
                OnPropertyChanged("Status");
            }
        }

        private bool mIsFullControl;
        public bool IsFullControl
        {
            get { return mIsFullControl; }
            set
            {
                mIsFullControl = value;
                OnPropertyChanged("IsFullControl");
            }
        }

        private bool mRibbonVisible = true;
        public bool RibbonVisible
        {
            get { return mRibbonVisible; }
            set { mRibbonVisible = value;
            OnPropertyChanged("RibbonVisible");
            }
        }

        
        private string mUsername = "";
        public string Username
        {
            get { return mUsername; }
            set
            {
                mUsername = value;
                OnPropertyChanged("Username");
            }
        }

        
       

        #region Cards

        public void ShowAllCards()
        {
            BOListCard cards=mAccountant.AllCards;
            cards.ActiveCardType = CardType.TypeID.None;
            mCardPresenter.ShowCards(cards);
        }

        public void ShowCustomers()
        {
            BOListCard cards = mAccountant.AllCards;
            cards.ActiveCardType = CardType.TypeID.Customer;
            mCardPresenter.ShowCards(cards);
        }

        public void ShowEmployees()
        {
            BOListCard cards = mAccountant.AllCards;
            cards.ActiveCardType = CardType.TypeID.Employee;
            mCardPresenter.ShowCards(cards);
        }

        public void ShowSuppliers()
        {
            BOListCard cards = mAccountant.AllCards;
            cards.ActiveCardType = CardType.TypeID.Supplier;
            mCardPresenter.ShowCards(cards);
        }
        #endregion

        

        #region Purchase

        public void ShowPurchases()
        {
            mPurchasePresenter.ShowPurchases(mAccountant.Purchases);
        }

        public void CreatePurchaseQuote()
        {
            mPurchasePresenter.ShowPurchase(mAccountant.CreatePurchaseQuote());
        }

        public void CreatePurchaseOrder()
        {
            mPurchasePresenter.ShowPurchase(mAccountant.CreatePurchaseOrder());
        }
       
        public void CreatePurchaseOpenBill()
        {
            mPurchasePresenter.ShowPurchase(mAccountant.CreatePurchaseOpenBill());
        }

        public void DeletePurchase(Purchase _obj)
        {
            mAccountant.DeletePurchase(_obj);
        }

        public void CreatePurchaseOrderFromQuote(Purchase _obj)
        {
            mPurchasePresenter.ShowPurchase(mAccountant.CreatePurchaseOrderFromQuote(_obj));
        }

        public void CreatePurchaseOpenBillFromQuote(Purchase _obj)
        {
            mPurchasePresenter.ShowPurchase(mAccountant.CreatePurchaseOpenBillFromQuote(_obj));
        }

        public void CreatePurchaseOpenBillFromOrder(Purchase _obj)
        {
            mPurchasePresenter.ShowPurchase(mAccountant.CreatePurchaseOpenBillFromOrder(_obj));
        }

        public void OpenPurchase(Purchase purchase)
        {
            mPurchasePresenter.ShowPurchase(mAccountant.OpenPurchase(purchase));
        }

        
        #endregion


        public void ShowTransactionJournals()
        {
            mAccountPresenter.ShowTransactionJournals(mAccountant.TransactionJournals);
        }


        #region Account

        public void ShowAccounts()
        {
            mAccountPresenter.ShowAccounts(mAccountant.Accounts);
        }

        public void CreateAccount()
        {
            mAccountPresenter.ShowAccount(mAccountant.CreateAccount());
        }

        public void OpenAccount(Account _obj)
        {
            mAccountPresenter.ShowAccount(mAccountant.OpenAccount(_obj));
        }

      
        #endregion

        #region Cards
        public void OpenCard(Card card)
        {
            mCardPresenter.ShowCard(mAccountant.OpenCard(card));
        }

        public void CreateSupplier()
        {
            mCardPresenter.ShowCard(mAccountant.CreateSupplier());
        }

        public void CreateEmployee()
        {
            mCardPresenter.ShowCard(mAccountant.CreateEmployee());
        }

        public void CreateCustomer()
        {
            mCardPresenter.ShowCard(mAccountant.CreateCustomer());
        }

        public void DeleteCard(Card card)
        {
            mAccountant.DeleteCard(card);
        }

        
       
        #endregion


        #region Inventory

        #region Item

        public void ShowRegisterForItems()
        {
            mInventoryPresenter.ShowRegisterForItems(mAccountant.ItemsRegister);
        }

        public void ShowItems()
        {
            mInventoryPresenter.ShowItems(mAccountant.Items);
        }

        public void OpenItem(Item _obj)
        {
            mInventoryPresenter.ShowItem(mAccountant.OpenItem(_obj));
        }
        
        public void CreateItem()
        {
            mInventoryPresenter.ShowItem(mAccountant.CreateItem());
        }

        public void DeleteItem(Item _obj)
        {
            mAccountant.DeleteItem(_obj);
        }

       
        #endregion

        #region ItemDataFieldEntry
        public void OpenItemDataFieldEntry(ItemDataFieldEntry dfe, Item _item)
        {
            mInventoryPresenter.ShowItemDataFieldEntry(mAccountant.OpenItemDataFieldEntry(dfe, _item));
        }

        public void CreateItemDataFieldEntry(Item _item)
        {
            mInventoryPresenter.ShowItemDataFieldEntry(mAccountant.CreateItemDataFieldEntry(_item));
        }

        public void DeleteItemDataFieldEntry(ItemDataFieldEntry dfe, Item _item)
        {
            mAccountant.DeleteItemDataFieldEntry(dfe, _item);
        }

        
        #endregion

        #endregion


        #region Security
        public void ShowSecurity()
        {
            mSecurityPresenter.ShowSecurity();
        }

        public void OpenAuthUser(AuthUser data)
        {
            mSecurityPresenter.ShowAuthUser(mAccountant.OpenAuthUser(data));
        }

        public void CreateAuthUser()
        {
            mSecurityPresenter.ShowAuthUser(mAccountant.CreateAuthUser());
        }

        public void DeleteAuthUser(AuthUser data)
        {
            BOUser model = mAccountant.OpenAuthUser(data);
            model.Delete();
        }

        public void CreateAuthRole()
        {
            mSecurityPresenter.ShowAuthRole(mAccountant.CreateAuthRole());
        }

        public void OpenAuthRole(AuthRole role)
        {
            mSecurityPresenter.ShowAuthRole(mAccountant.OpenAuthRole(role));
        }

        public void DeleteAuthRole(AuthRole role)
        {
            if (!mAccountant.CanDeleteAuthRole(role))
            {
                if(MessageBox.Show(
                         "Other roles and users have inherited this role, delete this role will also delete them,\r\n do you still want to delete?", 
                         "Delete Warning",
                         MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                
            }else  if (MessageBox.Show(
                             "Do you want to delete?", 
                             "Delete Warning",
                             MessageBoxButtons.YesNo) == DialogResult.No)
             {
                 return;
             }
           
            BORole model = mAccountant.OpenAuthRole(role);
            model.Delete();
        }
       
        #endregion

        

        
       
        

        public void ShowBalanceSheetForAccountsAnalysis()
        {
            mAccountPresenter.ShowBalanceSheetForAccountsAnalysis(mAccountant.Accounts);
        }

        public void ShowProfitAndLossForAccountsAnalysis()
        {
           mAccountPresenter.ShowProfitAndLossForAccountsAnalysis(mAccountant.Accounts);
        }
        

        public void ShowCashflowForAccountAnalysis()
        {

        }

        public void ShowSalesItemRpt()
        {
            mSalePresenter.ShowSalesItemRpt();
        }

        public void ShowUserGuide()
        {
            mMiscPresenter.ShowUserGuide();
        }

        public void ShowAbout()
        {
            mMiscPresenter.ShowAbout();
        }

        public void ShowBackupOptions()
        {
            mMiscPresenter.ShowBackupOptions();
        }

        public void Exit()
        {
            System.Windows.Forms.Application.Exit();
        }

        public void ShowEraseOptions()
        {
            mMiscPresenter.ShowEraseOptions();
        }

        #region TimerTask
        private void TriggerTimer_Backup()
        {
            bool AutoDbBackup = mAccountant.ConfigMgr.GetParamValue("AutoDbBackup").Equals("1");
            if (!AutoDbBackup) return;

            string AutoDbBackupInterval = mAccountant.ConfigMgr.GetParamValue("AutoDbBackupInterval");

            DateTime curr_time = DateTime.Now;
            DayOfWeek dow = curr_time.DayOfWeek;
            if (AutoDbBackupInterval.Equals("Every Monday"))
            {
                if (dow != DayOfWeek.Monday) return;
            }
            else if (AutoDbBackupInterval.Equals("Every Tuesday"))
            {
                if (dow != DayOfWeek.Tuesday) return;
            }
            else if (AutoDbBackupInterval.Equals("Every Wednesday"))
            {
                if (dow != DayOfWeek.Wednesday) return;
            }
            else if (AutoDbBackupInterval.Equals("Every Thursday"))
            {
                if (dow != DayOfWeek.Thursday) return;
            }
            else if (AutoDbBackupInterval.Equals("Every Friday"))
            {
                if (dow != DayOfWeek.Friday) return;
            }
            else if (AutoDbBackupInterval.Equals("Every Saturday"))
            {
                if (dow != DayOfWeek.Saturday) return;
            }
            else if (AutoDbBackupInterval.Equals("Every Sunday"))
            {
                if (dow != DayOfWeek.Sunday) return;
            }

            int hour = 0, temp_hour, minute = 0, temp_minute;
            if (int.TryParse(mAccountant.ConfigMgr.GetParamValue("AutoDbBackupHour"), out temp_hour)) hour = temp_hour;
            if (int.TryParse(mAccountant.ConfigMgr.GetParamValue("AutoDbBackupMinute"), out temp_minute)) minute = temp_minute;

            int curr_hour = curr_time.Hour;
            int curr_minute = curr_time.Minute;

            if (curr_hour == hour && curr_minute == minute)
            {
                BackupToMSSQL();
                BackupToMySQL();
                BackupToCloud();
            }
        }

        public void BackupToCloud()
        {
            bool BackupByCloud = mAccountant.ConfigMgr.GetParamValue("BACKUP_CLOUDUSE").Equals("1");

            if (!BackupByCloud) return;

            bool BackupItemAddOn = mAccountant.ConfigMgr.GetParamValue("BACKUP_ITEMADDON").Equals("1");
            bool BackupAuthentication = mAccountant.ConfigMgr.GetParamValue("BACKUP_AUTHENTICATION").Equals("1");
            bool BackupAuthorization = mAccountant.ConfigMgr.GetParamValue("BACKUP_AUTHORIZATION").Equals("1");

            string cloudUID = mAccountant.ConfigMgr.GetParamValue("BACKUP_CLOUDUID");
            string cloudPWD = mAccountant.ConfigMgr.GetParamValue("BACKUP_CLOUDPWD");
            string cloudUrl = mAccountant.ConfigMgr.GetParamValue("BACKUP_CLOUDURL");
            if (BackupItemAddOn)
            {
                RestoreItemAddOnFromCloud(mAccountant, cloudUrl, cloudUID, cloudPWD);
                RestoreDataFieldsFromCloud(mAccountant, cloudUrl, cloudUID, cloudPWD);
                RestoreItemDataFieldEntriesFromCloud(mAccountant, cloudUrl, cloudUID, cloudPWD);
            }
        }

        public void RestoreItemAddOnFromCloud(Accountant curr_acc, string cloudUrl, string cloudUID, string cloudPWD)
        {
            IList<ItemAddOn> CurrItemAddOns = curr_acc.ItemAddOnMgr.FindAllCollection();
            int itemCount = CurrItemAddOns.Count;
            StringBuilder sb = new StringBuilder();
            sb.Append("backup=ItemAddOn");
            sb.AppendFormat("&count={0}", itemCount);

            cloudUID = cloudUID.Trim();
            if (string.IsNullOrEmpty(cloudUID))
            {
                sb.AppendFormat("&uid={0}", NetUtil.UrlEncode(cloudUID));
            }
            cloudPWD = cloudPWD.Trim();
            if (string.IsNullOrEmpty(cloudPWD))
            {
                sb.AppendFormat("&pwd={0}", NetUtil.UrlEncode(cloudPWD));
            }

            for (int i = 0; i < itemCount; ++i)
            {
                ItemAddOn _addon = CurrItemAddOns[i];
                sb.AppendFormat("&itemaddonid={0}", NetUtil.UrlEncode(_addon.ItemAddOnID));
                sb.AppendFormat("&brand[]={0}", NetUtil.UrlEncode(_addon.Brand));
                sb.AppendFormat("&serial[]={0}", NetUtil.UrlEncode(_addon.SerialNumber));
                sb.AppendFormat("&batch[]={0}", NetUtil.UrlEncode(_addon.BatchNumber));
                sb.AppendFormat("&color[]={0}", NetUtil.UrlEncode(_addon.Color));
                sb.AppendFormat("&expiry[]={0}", NetUtil.UrlEncode(_addon.ExpiryDate));
                sb.AppendFormat("&gender[]={0}", NetUtil.UrlEncode(_addon.GenderID));
                sb.AppendFormat("&itemsizeid[]={0}", NetUtil.UrlEncode(_addon.ItemSizeID));
            }

            cloudUrl = cloudUrl.Trim();
            NetUtil.Instance.HttpPost(cloudUrl, sb.ToString());
        }


        public void RestoreDataFieldsFromCloud(Accountant curr_acc, string cloudUrl, string cloudUID, string cloudPWD)
        {
            IList<DataField> CurrDataFields = curr_acc.DataFieldMgr.FindAllCollection();
            int itemCount = CurrDataFields.Count;
            StringBuilder sb = new StringBuilder();
            sb.Append("backup=DataFields");
            sb.AppendFormat("&count={0}", itemCount);

            cloudUID = cloudUID.Trim();
            if (string.IsNullOrEmpty(cloudUID))
            {
                sb.AppendFormat("&uid={0}", NetUtil.UrlEncode(cloudUID));
            }
            cloudPWD = cloudPWD.Trim();
            if (string.IsNullOrEmpty(cloudPWD))
            {
                sb.AppendFormat("&pwd={0}", NetUtil.UrlEncode(cloudPWD));
            }

            for (int i = 0; i < itemCount; ++i)
            {
                DataField _datafield = CurrDataFields[i];

                sb.AppendFormat("&fieldname[]={0}", NetUtil.UrlEncode(_datafield.DataFieldName));
                sb.AppendFormat("&fieldtype[]={0}", NetUtil.UrlEncode(_datafield.DataFieldType));
                sb.AppendFormat("&datafieldid[]={0}", NetUtil.UrlEncode(_datafield.DataFieldID));
                sb.AppendFormat("&nullable[]={0}", NetUtil.UrlEncode(_datafield.IsNullable));
            }

            cloudUrl = cloudUrl.Trim();
            NetUtil.Instance.HttpPost(cloudUrl, sb.ToString());
        }

        public void RestoreItemDataFieldEntriesFromCloud(Accountant curr_acc, string cloudUrl, string cloudUID, string cloudPWD)
        {
            IList<ItemDataFieldEntry> ItemDataFieldEntries = curr_acc.ItemDataFieldEntryMgr.FindAllCollection();
            int itemCount = ItemDataFieldEntries.Count;
            StringBuilder sb = new StringBuilder();
            sb.Append("backup=ItemDataFieldEntries");
            sb.AppendFormat("&count={0}", itemCount);

            cloudUID = cloudUID.Trim();
            if (string.IsNullOrEmpty(cloudUID))
            {
                sb.AppendFormat("&uid={0}", NetUtil.UrlEncode(cloudUID));
            }
            cloudPWD = cloudPWD.Trim();
            if (string.IsNullOrEmpty(cloudPWD))
            {
                sb.AppendFormat("&pwd={0}", NetUtil.UrlEncode(cloudPWD));
            }

            for (int i = 0; i < itemCount; ++i)
            {
                ItemDataFieldEntry _itemdatafieldentry = ItemDataFieldEntries[i];
                sb.AppendFormat("&itemdatafieldentryid[]={0}", NetUtil.UrlEncode(_itemdatafieldentry.ItemDataFieldEntryID));
                sb.AppendFormat("&content[]={0}", NetUtil.UrlEncode(_itemdatafieldentry.Content));
                sb.AppendFormat("&datafieldid[]={0}", NetUtil.UrlEncode(_itemdatafieldentry.DataFieldID));
                sb.AppendFormat("&itemnumber[]={0}", NetUtil.UrlEncode(_itemdatafieldentry.ItemNumber));
            }

            cloudUrl = cloudUrl.Trim();
            NetUtil.Instance.HttpPost(cloudUrl, sb.ToString());
        }

        public void BackupToMSSQL()
        {
            bool BackupByMSSQL = mAccountant.ConfigMgr.GetParamValue("BACKUP_MSSQLUSE").Equals("1");

            if (!BackupByMSSQL) return;

            Accountant backup_acc = new ImAccountant("BackupAccount(MSSQL)");

            string MSSQLUID = mAccountant.ConfigMgr.GetParamValue("BACKUP_MSSQLUID");
            string MSSQLPWD = mAccountant.ConfigMgr.GetParamValue("BACKUP_MSSQLPWD");
            string MSSQLDb = mAccountant.ConfigMgr.GetParamValue("BACKUP_MSSQLDB");
            string MSSQLHost = mAccountant.ConfigMgr.GetParamValue("BACKUP_MSSQLHOST");
            string MSSQLPort = mAccountant.ConfigMgr.GetParamValue("BACKUP_MSSQLPORT");

            bool BackupItemAddOn = mAccountant.ConfigMgr.GetParamValue("BACKUP_ITEMADDON").Equals("1");
            bool BackupAuthentication = mAccountant.ConfigMgr.GetParamValue("BACKUP_AUTHENTICATION").Equals("1");
            bool BackupAuthorization = mAccountant.ConfigMgr.GetParamValue("BACKUP_AUTHORIZATION").Equals("1");

            DbManager default_factory = new SqlClientDbManager(backup_acc, "PrimaryFactory");
            default_factory.Database = MSSQLDb;
            default_factory.HostExePath = MSSQLHost;
            default_factory.Port = MSSQLPort;
            default_factory.DbPassword = MSSQLPWD;
            default_factory.DbUsername = MSSQLUID;
            backup_acc.DefaultMgrFactory = default_factory;

            string error;
            if (backup_acc.ConnectMgrFactories(out error))
            {
                if (BackupItemAddOn)
                {
                    backup_acc.ItemAddOnMgr.RecreateTable();
                    IList<ItemAddOn> CurrItemAddOns = mAccountant.ItemAddOnMgr.FindAllCollection();
                    foreach (ItemAddOn s in CurrItemAddOns)
                    {
                        backup_acc.ItemAddOnMgr.Store(s);
                    }
                    backup_acc.DataFieldMgr.RecreateTable();
                    IList<DataField> DataFields = mAccountant.DataFieldMgr.FindAllCollection();
                    foreach (DataField s in DataFields)
                    {
                        backup_acc.DataFieldMgr.Store(s);
                    }
                    backup_acc.ItemDataFieldEntryMgr.RecreateTable();
                    IList<ItemDataFieldEntry> ItemDataFieldEntries = mAccountant.ItemDataFieldEntryMgr.FindAllCollection();
                    foreach (ItemDataFieldEntry s in ItemDataFieldEntries)
                    {
                        backup_acc.ItemDataFieldEntryMgr.Store(s);
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(error);
            }

            backup_acc.Release();
        }

        public void BackupToMySQL()
        {
            bool BackupByMySQL = mAccountant.ConfigMgr.GetParamValue("BACKUP_MySQLUSE").Equals("1");

            if (!BackupByMySQL) return;

            Accountant backup_acc = new ImAccountant("BackupAccount(MySQL)");

            DbManager default_factory = new MySQLDbManager(backup_acc, "PrimaryFactory");

            string MySQLUID = mAccountant.ConfigMgr.GetParamValue("BACKUP_MySQLUID");
            string MySQLPWD = mAccountant.ConfigMgr.GetParamValue("BACKUP_MySQLPWD");
            string MySQLDb = mAccountant.ConfigMgr.GetParamValue("BACKUP_MySQLDB");
            string MySQLHost = mAccountant.ConfigMgr.GetParamValue("BACKUP_MySQLHOST");
            string MySQLPort = mAccountant.ConfigMgr.GetParamValue("BACKUP_MySQLPORT");

            bool BackupItemAddOn = mAccountant.ConfigMgr.GetParamValue("BACKUP_ITEMADDON").Equals("1");
            bool BackupAuthentication = mAccountant.ConfigMgr.GetParamValue("BACKUP_AUTHENTICATION").Equals("1");
            bool BackupAuthorization = mAccountant.ConfigMgr.GetParamValue("BACKUP_AUTHORIZATION").Equals("1");

            default_factory.Database = MySQLDb;
            default_factory.HostExePath = MySQLHost;
            default_factory.Port = MySQLPort;
            default_factory.DbPassword = MySQLPWD;
            default_factory.DbUsername = MySQLUID;

            backup_acc.DefaultMgrFactory = default_factory;

            string error;
            if (backup_acc.ConnectMgrFactories(out error))
            {
                if (BackupItemAddOn)
                {
                    backup_acc.ItemAddOnMgr.RecreateTable();
                    IList<ItemAddOn> CurrItemAddOns = mAccountant.ItemAddOnMgr.FindAllCollection();
                    foreach (ItemAddOn s in CurrItemAddOns)
                    {
                        backup_acc.ItemAddOnMgr.Store(s);
                    }
                    backup_acc.DataFieldMgr.RecreateTable();
                    IList<DataField> DataFields = mAccountant.DataFieldMgr.FindAllCollection();
                    foreach (DataField s in DataFields)
                    {
                        backup_acc.DataFieldMgr.Store(s);
                    }
                    backup_acc.ItemDataFieldEntryMgr.RecreateTable();
                    IList<ItemDataFieldEntry> ItemDataFieldEntries = mAccountant.ItemDataFieldEntryMgr.FindAllCollection();
                    foreach (ItemDataFieldEntry s in ItemDataFieldEntries)
                    {
                        backup_acc.ItemDataFieldEntryMgr.Store(s);
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(error);
            }

            backup_acc.Release();
        }
        #endregion

        #region Administrator

        #region DataFieldForItemAddOn
        public void CreateDataFieldForItemAddOn()
        {
            mDefinitionPresenter.ShowDataFieldForItemAddOn(mAccountant.CreateDataFieldForItemAddOn());
        }

        public void OpenDataFieldForItemAddOn(DataField df)
        {
            mDefinitionPresenter.ShowDataFieldForItemAddOn(mAccountant.OpenDataFieldForItemAddOn(df));
        }

        public void DeleteDataFieldForItemAddOn(DataField df)
        {
            mAccountant.DeleteDataFieldForItemAddOn(df);
        }

        public void ShowDataFieldsForItemAddOn()
        {
            mDefinitionPresenter.ShowDataFieldsForItemAddOn(mAccountant.DataFieldsForItemAddOn);
        }
        #endregion

        #region GenderForItemAddOn
        public void CreateGenderForItemAddOn()
        {
            mDefinitionPresenter.ShowGenderForItemAddOn(mAccountant.CreateGenderForItemAddOn());
        }

        public void OpenGenderForItemAddOn(Gender df)
        {
            mDefinitionPresenter.ShowGenderForItemAddOn(mAccountant.OpenGenderForItemAddOn(df));
        }

        public void DeleteGenderForItemAddOn(Gender df)
        {
            mAccountant.DeleteGenderForItemAddOn(df);
        }

      
        public void ShowGendersForItemAddOn()
        {
            mDefinitionPresenter.ShowGendersForItemAddOn(mAccountant.GendersForItemAddOn);
        }
        #endregion

        #region ItemSizeForItemAddOn
        public void CreateItemSizeForItemAddOn()
        {
            mDefinitionPresenter.ShowItemSizeForItemAddOn(mAccountant.CreateItemSizeForItemAddOn());
        }

        public void OpenItemSizeForItemAddOn(ItemSize df)
        {
            mDefinitionPresenter.ShowItemSizeForItemAddOn(mAccountant.OpenItemSizeForItemAddOn(df));
        }

        public void DeleteItemSizeForItemAddOn(ItemSize df)
        {
            mAccountant.DeleteItemSizeForItemAddOn(df);
        }

        

        
        public void ShowItemSizesForItemAddOn()
        {
            mDefinitionPresenter.ShowItemSizesForItemAddOn(mAccountant.ItemSizesForItemAddOn);
        }
        #endregion

        #endregion

        public void ShowPurchasesItemsRpt()
        {
            mPurchasePresenter.ShowPurchasesItemsRpt();
        }

        public void ShowBalanceSheetForAccountRpt()
        {
            mAccountPresenter.ShowBalanceSheetForAccountRpt();
        }

        public void ShowProfitAndLossForAccountRpt()
        {
            mAccountPresenter.ShowProfitAndLossForAccountRpt();
        }

        public void ShowBarcodeReader(DacII.WinForms.Util.FrmReadBarcode.BarcodeReadHandler handler)
        {
            mMiscPresenter.ShowBarcodeReader(handler);
        }

        
        #region Sale

        public void ShowSales()
        {
            mSalePresenter.ShowSales(mAccountant.Sales);
        }

        public void OpenSale(Sale _obj)
        {
            mSalePresenter.ShowSale(mAccountant.OpenSale(_obj));
        }

        public void CreateSaleQuote()
        {
             mSalePresenter.ShowSale(mAccountant.CreateSaleQuote());
        }

        public void CreateSaleOrder()
        {
            mSalePresenter.ShowSale(mAccountant.CreateSaleOrder());
        }

        public void DeleteSale(Sale _obj)
        {
            mAccountant.DeleteSale(_obj);
        }

        public void CreateSaleOpenInvoice()
        {
            mSalePresenter.ShowSale(mAccountant.CreateSaleOpenInvoice());
        }

        public void CreateSaleOrderFromQuote(Sale _obj)
        {
            mSalePresenter.ShowSale(mAccountant.CreateSaleOrderFromQuote(_obj));
        }

        public void CreateSaleOpenInvoiceFromQuote(Sale _obj)
        {
            mSalePresenter.ShowSale(mAccountant.CreateSaleOpenInvoiceFromQuote(_obj));
        }

        public void CreateSaleOpenInvoiceFromOrder(Sale _obj)
        {
            mSalePresenter.ShowSale(mAccountant.CreateSaleOpenInvoiceFromOrder(_obj));
        }

        

        #endregion

        public void ShowJobsAnalysis()
        {
            mJobPresenter.ShowJobsAnalysis(mAccountant.JobAnalysis);
        }

        public void OpenJob(Job _obj)
        {
            mJobPresenter.ShowJob(mAccountant.OpenJob(_obj));
        }

        public void CreateJob()
        {
            mJobPresenter.ShowJob(mAccountant.CreateJob());
        }
        
        

        public void ShowJobs()
        {
            mJobPresenter.ShowJobs(mAccountant.Jobs);
        }

        public Accountant mAccountant;

        public bool CreatePurchaseLine(Purchase purchase)
        {
            BOPurchaseLine model=mAccountant.CreatePurchaseLine(purchase);
            return mPurchasePresenter.ShowPurchaseLine(model);
        }

        public bool CreateSaleLine(Sale sale)
        {
            BOSaleLine model = mAccountant.CreateSaleLine(sale);
            return mSalePresenter.ShowSaleLine(model);
        }

        

        public void PrintSale(Sale sale, string invoice_number)
        {
            try
            {
                Image myimg = Code128Rendering.MakeBarcodeImage(invoice_number, 2, true);
                myimg.Save(mAccountant.GetFullPath("Images/barcode_sale.png"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Accounting.Report.Sales.SalePrintPresenter report_presenter = new Accounting.Report.Sales.SalePrintPresenter(mAccountant, sale);
            mSalePresenter.PrintSale(report_presenter);
        }

        internal void PrintPurchase(Purchase purchase, string purchase_number)
        {
            try
            {
                Image myimg = Code128Rendering.MakeBarcodeImage(purchase_number, 2, true);
                myimg.Save(mAccountant.GetFullPath("Images/barcode_purchase.png"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Accounting.Report.Purchases.PurchasePrintPresenter report_presenter = new Accounting.Report.Purchases.PurchasePrintPresenter(mAccountant, purchase);
            mPurchasePresenter.PrintPurchase(report_presenter);
        }

        public void OpenPurchaseLine(PurchaseLine purchaseLine)
        {
            mPurchasePresenter.ShowPurchaseLine(mAccountant.OpenPurchaseLine(purchaseLine));
        }

        public void OpenSaleLine(SaleLine saleLine)
        {
            mSalePresenter.ShowSaleLine(mAccountant.OpenSaleLine(saleLine));
        }

        public void DeletePurchaseLine(PurchaseLine purchaseLine)
        {
            mAccountant.DeletePurchaseLine(purchaseLine);
        }

        public void DeleteSaleLine(SaleLine saleLine)
        {
            mAccountant.DeleteSaleLine(saleLine);
        }

        internal void ShowMyob()
        {
            mMiscPresenter.ShowMyob();
        }

        internal void ShowCmd()
        {
            mMiscPresenter.ShowCmd();
        }

        public bool CheckAccessSilent(string objectid, string propertyname, string attribute)
        {
            BOUser current_user = mAccountant.CurrentAuthUser;
            if (current_user.CheckAccess(objectid, propertyname, attribute))
            {
                return true;
            }
            return false;
        }

        public bool CheckAccessSilent(string objectid, string attribute)
        {
            BOUser current_user = mAccountant.CurrentAuthUser;
            if (current_user.CheckAccess(objectid, attribute))
            {
                return true;
            }
            return false;
        }

        public bool CheckAccess(string objectid, string propertyname, string attribute)
        {
            BOUser current_user = mAccountant.CurrentAuthUser;
            if (current_user.CheckAccess(objectid, propertyname, attribute))
            {
                return true;
            }
            else
            {
                MessageBox.Show(string.Format("Your current role as {0} does not allow you to access this feature", current_user.Role));
                return false;
            }
        }

        public bool CheckAccess(string objectid, string attribute)
        {
            BOUser current_user = mAccountant.CurrentAuthUser;
            if (current_user.CheckAccess(objectid, attribute))
            {
                return true;
            }
            else
            {
                MessageBox.Show(string.Format("Your current role as {0} does not allow you to access this feature", current_user.Role));
                return false;
            }
        }

        public void PrintCompany()
        {
            mSetupPresenter.PrintCompany(mAccountant.CompanyInfo);
        }

        public void OpenDataInformationFile()
        {
            mSetupPresenter.ShowCompany(mAccountant.CompanyInfo);
        }

        public void InvalidateDataStore()
        {
            mAccountant.InvalidateDataStore();
        }

        internal void ShowTerms()
        {
            mMiscPresenter.ShowTerms();
        }

        public void ShowCurrencies()
        {
            mMiscPresenter.ShowCurrencies();
        }

        public void ShowTaxCodes()
        {
            mMiscPresenter.ShowTaxCodes();
        }

        internal IList<Item> FindAllItems()
        {
            return mAccountant.ItemMgr.FindAllCollection();
        }

        internal void ShowItemsListSummaryRpt()
        {
            mInventoryPresenter.ShowItemsListSummaryRpt();
        }

        internal void ShowItemsRegisterSummaryRpt()
        {
            mInventoryPresenter.ShowItemsRegisterSummaryRpt();
        }

        internal void AdjustInventory()
        {
            mInventoryPresenter.ShowInventoryAdjustment(mAccountant.CreateInventoryAdjustment());
        }

        internal void ShowCardListSummaryRpt()
        {
            mCardPresenter.ShowCardListSummaryRpt();
        }

        internal void OpenInventoryAdjustmentLine(InventoryAdjustmentLine line)
        {
            mInventoryPresenter.ShowInventoryAdjustmentLine(mAccountant.OpenInventoryAdjustmentLine(line));
        }

        internal bool CreateInventoryAdjustmentLine(InventoryAdjustment ia)
        {
            return mInventoryPresenter.ShowInventoryAdjustmentLine(mAccountant.CreateInventoryAdjustmentLine(ia));
        }

        internal void DeleteInventoryAdjustmentLine(InventoryAdjustmentLine line)
        {
            BOInventoryAdjustmentLine model = mAccountant.OpenInventoryAdjustmentLine(line);
            model.Delete();
        }
    }
}
