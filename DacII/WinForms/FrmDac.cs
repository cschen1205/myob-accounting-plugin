using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DacII.WinForms
{
    using DacII.Presenters;

    public partial class FrmDac : Form
    {
        ApplicationPresenter mApplicationController = null;

        public FrmDac(ApplicationPresenter ap)
        {
            InitializeComponent();

            mApplicationController = ap;
            mApplicationController.MiscPresenter = new MiscPresenter(mApplicationController, this);
            mApplicationController.InventoryPresenter = new InventoryPresenter(mApplicationController, this);
            mApplicationController.SalePresenter = new SalePresenter(mApplicationController, this);
            mApplicationController.PurchasePresenter = new PurchasePresenter(mApplicationController, this);
            mApplicationController.JobPresenter = new JobPresenter(mApplicationController, this);
            mApplicationController.DefinitionPresenter = new DefinitionPresenter(mApplicationController, this);
            mApplicationController.AccountPresenter = new AccountPresenter(mApplicationController, this);
            mApplicationController.CardPresenter = new CardPresenter(mApplicationController, this);
            mApplicationController.SetupPresenter = new SetupPresenter(mApplicationController, this);
            mApplicationController.SecurityPresenter = new SecurityPresenter(mApplicationController, this);

            mApplicationController.PropertyChanged += new PropertyChangedEventHandler(mController_PropertyChanged);

            mApplicationController.RibbonVisible = true;
            mApplicationController.AquaStyleEnabled = true;
        }

        public FrmDac()
        {
            InitializeComponent();
        }

        private void TriggerCmd_Terms(object sender, EventArgs e)
        {
            mApplicationController.ShowTerms();
        }

        private void TriggerCmd_Currencies(object sender, EventArgs e)
        {
            mApplicationController.ShowCurrencies();
        }

        private void TriggerCmd_TaxCodes(object sender, EventArgs e)
        {
            mApplicationController.ShowTaxCodes();
        }

        void mController_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsFullControl")
            {
                if (mApplicationController.IsFullControl)
                {
                    if (!RibDacII.Tabs.Contains(TabAdmin))
                    {
                        RibDacII.Tabs.Add(TabAdmin);
                    }
                }
                else
                {
                    if (RibDacII.Tabs.Contains(TabAdmin))
                    {
                        RibDacII.Tabs.Remove(TabAdmin);
                    }
                }
                administratorToolStripMenuItem.Visible = mApplicationController.IsFullControl;
            }
            else if (e.PropertyName == "Username")
            {
                this.miUsername.Text=string.Format("Current user: {0}", mApplicationController.Username);
            }
            else if (e.PropertyName == "RibbonVisible")
            {
                
                this.RibDacII.Visible = mApplicationController.RibbonVisible;
                this.menustrip.Visible = !mApplicationController.RibbonVisible;
                if (mApplicationController.RibbonVisible)
                {
                    miShowRibbon.Text = "Hide Ribbon";
                    tmiShowRibbon.Text = "Hide Ribbon";
                    RibBtnSwitch.ToolTip = "Hide Ribbon";
                }
                else
                {
                    miShowRibbon.Text = "Show Ribbon";
                    tmiShowRibbon.Text = "Show Ribbon";
                    RibBtnSwitch.ToolTip = "Show Ribbon";
                }
                miShowRibbon.Checked = mApplicationController.RibbonVisible;
                tmiShowRibbon.Checked = mApplicationController.RibbonVisible;
            }
            else if (e.PropertyName == "Status")
            {
                miStatus.Text = mApplicationController.Status;
            }
        }


        private void FrmDacII_Load(object sender, EventArgs e)
        {
            mApplicationController.Login();
        }


        public bool BackupEnabled
        {
            get { return timerBackup.Enabled; }
            set { timerBackup.Enabled = value; }
        }

        public void TriggerCmd_Myob(object sender, EventArgs args)
        {
            mApplicationController.ShowMyob();
        }

        public void TriggerCmd_Cmd(object sender, EventArgs args)
        {
            mApplicationController.ShowCmd();
        }

        public void TriggerCmd_ItemsList(object sender, EventArgs e)
        {
            mApplicationController.ShowItems();
        }

        public void TriggerCmd_PurchasesRegister()
        {
           mApplicationController.ShowPurchases();
        }
        
        public void TriggerCmd_SalesRegister(object sender, EventArgs e)
        {
            mApplicationController.ShowSales();
        }

      
        public void TriggerCmd_CardsRegister(object sender, EventArgs e)
        {
            mApplicationController.ShowAllCards();
        }

        public void TriggerCmd_CustomersRegister(object sender, EventArgs e)
        {
            mApplicationController.ShowCustomers();
        }

        public void TriggerCmd_EmployeesRegister(object sender, EventArgs e)
        {
            mApplicationController.ShowEmployees();
        }

        public void TriggerCmd_SuppliersRegister(object sender, EventArgs e)
        {
            mApplicationController.ShowSuppliers();
        }

        public void TriggerCmd_CreateSaleQuote(object sender, EventArgs e)
        {
            mApplicationController.CreateSaleQuote();
        }

        public void TriggerCmd_CreateSaleOrder(object sender, EventArgs e)
        {
            mApplicationController.CreateSaleOrder();
        }

        public void TriggerCmd_CreateSaleOpenInvoice(object sender, EventArgs e)
        {
            mApplicationController.CreateSaleOpenInvoice();
        }

        public void TriggerCmd_CreatePurchaseQuote(object sender, EventArgs e)
        {
            mApplicationController.CreatePurchaseQuote();
        }
        
        public void TriggerCmd_CreatePurchaseOrder(object sender, EventArgs e)
        {
            mApplicationController.CreatePurchaseOrder();
        }
        
        public void TriggerCmd_CreatePurchaseOpenBill(object sender, EventArgs e)
        {
            mApplicationController.CreatePurchaseOpenBill();
        }

        public void TriggerCmd_PurchasesRegister(object sender, EventArgs e)
        {
            mApplicationController.ShowPurchases();
        }
        
        public void TriggerCmd_ItemsRegister(object sender, EventArgs e)
        {
            mApplicationController.ShowRegisterForItems();
        }
        
        public void TriggerCmd_TransactionJournals(object sender, EventArgs args)
        {
            mApplicationController.ShowTransactionJournals();
        }
        
        public void TriggerCmd_AccountsList(object sender, EventArgs args)
        {
            mApplicationController.ShowAccounts();
        }
        
        public void TriggerCmd_CreateCustomer(object sender, EventArgs args)
        {
            mApplicationController.CreateCustomer();
        }
        
        public void TriggerCmd_CreateSupplier(object sender, EventArgs args)
        {
            mApplicationController.CreateSupplier();
        }
        
        public void TriggerCmd_CreateEmployee(object sender, EventArgs args)
        {
            mApplicationController.CreateEmployee();
        }
        
        public void TriggerCmd_CreateItem(object sender, EventArgs args)
        {
            mApplicationController.CreateItem();
        }
        
        public void TriggerCmd_JobsRegister(object sender, EventArgs args)
        {
            mApplicationController.ShowJobs();
        }
        
        public void TriggerCmd_Security(object sender, EventArgs args)
        {
            mApplicationController.ShowSecurity();
        }
        
        public void TriggerCmd_AddAuthRole(object sender, EventArgs args)
        {
            mApplicationController.CreateAuthRole();
        }
        
        public void TriggerCmd_AddAuthUser(object sender, EventArgs args)
        {
            mApplicationController.CreateAuthUser();
        }
        
        public void TriggerCmd_GendersRegister(object sender, EventArgs args)
        {
            mApplicationController.ShowGendersForItemAddOn();
        }
        
        public void TriggerCmd_ItemSizesRegister(object sender, EventArgs args)
        {
            mApplicationController.ShowItemSizesForItemAddOn();
        }
        
        public void TriggerCmd_AccountsAnalysisBalanceSheet(object sender, EventArgs args)
        {
            mApplicationController.ShowBalanceSheetForAccountsAnalysis();
        }
        
        public void TriggerCmd_AccountsAnalysisProfitAndLoss(object sender, EventArgs args)
        {
            mApplicationController.ShowProfitAndLossForAccountsAnalysis();
        }
        
        public void TriggerCmd_JobsAnalysis(object sender, EventArgs args)
        {
            mApplicationController.ShowJobsAnalysis();
        }

        public void TriggerCmd_RptSalesItem(object sender, EventArgs args)
        {
            mApplicationController.ShowSalesItemRpt();
        }
       
        public void TriggerCmd_UserGuide(object sender, EventArgs args)
        {
            mApplicationController.ShowUserGuide();
        }
        
        public void TriggerCmd_About(object sender, EventArgs args)
        {
            mApplicationController.ShowAbout();
        }
        
        public void TriggerCmd_Backup(object sender, EventArgs args)
        {
            mApplicationController.ShowBackupOptions();
        }

        public void TriggerCmd_Exit(object sender, EventArgs args)
        {
            mApplicationController.Exit();
        }

        public void TriggerCmd_Erase(object sender, EventArgs args)
        {
            mApplicationController.ShowEraseOptions();
        }
        
        private void TriggerTimer_Backup(object sender, EventArgs args)
        {
            
        }

        private void FrmDacII_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerBackup.Enabled = false;
        }

        
        public void TriggerCmd_DataFields(object sender, EventArgs args)
        {
            mApplicationController.ShowDataFieldsForItemAddOn();
        }
        

        public void TriggerCmd_RptPurchasesItem(object sender, EventArgs e)
        {
            mApplicationController.ShowPurchasesItemsRpt();
        }

        public void TriggerCmd_RptAccountsBalanceSheet(object sender, EventArgs e)
        {
            mApplicationController.ShowBalanceSheetForAccountRpt();
        }

        private void RibBtnRptAccountsPL_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowProfitAndLossForAccountRpt();
        }
        
        private void TriggerAccess_CreateJob(object sender, EventArgs e)
        {
            mApplicationController.CreateJob();
        }

        private void TriggerCmd_InvalidateDataStore(object sender, EventArgs e)
        {
            mApplicationController.InvalidateDataStore();
        }

        private void TriggerCmd_ChangeWindowState(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild.WindowState == FormWindowState.Maximized)
            {
                this.ActiveMdiChild.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.ActiveMdiChild.WindowState = FormWindowState.Maximized;
            }
        }

        private void miShowRibbon_Click(object sender, EventArgs e)
        {
            mApplicationController.RibbonVisible = !mApplicationController.RibbonVisible;
        }

        private void RibBtnSwitch_Click(object sender, EventArgs e)
        {
            mApplicationController.RibbonVisible = !mApplicationController.RibbonVisible;
        }

        private void RibObBtnCompany_Click(object sender, EventArgs e)
        {
            mApplicationController.OpenDataInformationFile();
        }

        private void TriggerCmd_ItemsListSummaryRpt(object sender, EventArgs e)
        {
            mApplicationController.ShowItemsListSummaryRpt();
        }

        private void TriggerCmd_ItemsRegisterSummaryRpt(object sender, EventArgs e)
        {
            mApplicationController.ShowItemsRegisterSummaryRpt();
        }

        private void TriggerCmd_AdjustInventory(object sender, EventArgs e)
        {
            mApplicationController.AdjustInventory();
        }

        private void TriggerCmd_CardsListSummaryRpt(object sender, EventArgs e)
        {
            mApplicationController.ShowCardListSummaryRpt();
        }
    }
}
