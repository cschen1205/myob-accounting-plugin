using System;

namespace DacII.WinForms
{
    using DacII.Presenters;

    public partial class FrmCmd : BaseView
    {
        public FrmCmd(ApplicationPresenter ap)
            : base(ap)
        {
            InitializeComponent();

            tlpSales.Add(btnCreateSaleQuote, btnShowSales);
            tlpSales.Add(btnCreateSaleOrder, btnShowSales);
            tlpSales.Add(btnCreateSaleOpenInvoice, btnShowSales);
            tlpSales.Add(btnCreateSaleQuote, btnCreateSaleOrder);
            tlpSales.Add(btnCreateSaleOrder, btnCreateSaleOpenInvoice);

            tlpPurchases.Add(btnCreatePurchaseQuote, btnShowPurchases);
            tlpPurchases.Add(btnCreatePurchaseOrder, btnShowPurchases);
            tlpPurchases.Add(btnCreatePurchaseOpenBill, btnShowPurchases);
            tlpPurchases.Add(btnCreatePurchaseQuote, btnCreatePurchaseOrder);
            tlpPurchases.Add(btnCreatePurchaseOrder, btnCreatePurchaseOpenBill);

            tlpInventory.Add(btnCreateItem, btnShowItems);
            tlpInventory.Add(btnShowItems, btnShowItemsRegister);

            tlpCards.Add(btnCreateCustomer, btnShowCustomers);
            tlpCards.Add(btnCreateSupplier, btnShowSuppliers);
            tlpCards.Add(btnCreateEmployee, btnShowEmployees);
            tlpCards.Add(btnShowCustomers, btnShowAllCards);
            tlpCards.Add(btnShowSuppliers, btnShowAllCards);
            tlpCards.Add(btnShowEmployees, btnShowAllCards);

            tlpAccounts.Add(btnCreateAccount, btnShowAccounts);
            tlpAccounts.Add(btnShowAccounts, btnShowBalanceShretForAccountAnalysis);
            tlpAccounts.Add(btnShowAccounts, btnShowProfitAndLossForAccountAnalysis);
            tlpAccounts.Add(btnShowAccounts, btnShowCashFlowForAccountAnalysis);

            tlpJobs.Add(btnCreateJob, btnShowJobs);
            tlpJobs.Add(btnShowJobs, btnShowJobsAnalysis);

            BindViews();
            RegisterEventHandlers();
        }

        private void btnShowSales_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowSales();
        }

        private void btnCreateSaleQuote_Click(object sender, EventArgs e)
        {
            mApplicationController.CreateSaleQuote();
        }

        private void btnCreateSaleOrder_Click(object sender, EventArgs e)
        {
            mApplicationController.CreateSaleOrder();
        }

        private void btnCreateSaleOpenInvoice_Click(object sender, EventArgs e)
        {
            mApplicationController.CreateSaleOpenInvoice();
        }

        private void btnShowPurchases_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowPurchases();
        }

        private void btnCreatePurchaseQuote_Click(object sender, EventArgs e)
        {
            mApplicationController.CreatePurchaseQuote();
        }

        private void btnCreatePurchaseOrder_Click(object sender, EventArgs e)
        {
            mApplicationController.CreatePurchaseOrder();
        }

        private void btnCreatePurchaseOpenBill_Click(object sender, EventArgs e)
        {
            mApplicationController.CreatePurchaseOpenBill();
        }

        private void btnShowItems_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowItems();
        }

        private void btnShowItemsRegister_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowRegisterForItems();
        }

        private void btnCreateItem_Click(object sender, EventArgs e)
        {
            mApplicationController.CreateItem();
        }

        private void btnShowAllCards_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowAllCards();
        }

        private void btnShowCustomers_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowCustomers();
        }

        private void btnShowSuppliers_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowSuppliers();
        }

        private void btnCreateEmployee_Click(object sender, EventArgs e)
        {
            mApplicationController.CreateEmployee();
        }

        private void btnShowEmployees_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowEmployees();
        }

        private void btnCreateSupplier_Click(object sender, EventArgs e)
        {
            mApplicationController.CreateSupplier();
        }

        private void btnCreateCustomer_Click(object sender, EventArgs e)
        {
            mApplicationController.CreateCustomer();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            mApplicationController.CreateAccount();
        }

        private void btnShowAccounts_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowAccounts();
        }

        private void btnShowBalanceSheetForAccountAnalysis_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowBalanceSheetForAccountsAnalysis();
        }

        private void btnCreateJob_Click(object sender, EventArgs e)
        {
            mApplicationController.CreateJob();
        }

        private void btnShowJobs_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowJobs();
        }

        private void btnShowJobsAnalysis_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowJobsAnalysis();
        }

        private void btnShowCashFlowForAccountAnalysis_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowCashflowForAccountAnalysis();
        }

        private void btnShowProfitAndLossForAccountAnalysis_Click(object sender, EventArgs e)
        {
            mApplicationController.ShowProfitAndLossForAccountsAnalysis();
        }
        


    }
}
