using System;
using System.Drawing;
using System.Windows.Forms;


namespace DacII.WinForms.Accounts
{
    using DacII.Presenters;
    using DacII.DacHandlers;

    using AdvancedDataGridView;
    using Accounting.Bll;
    using Accounting.Bll.Accounts;
    using Accounting.Core.Accounts;
    using Accounting.Core.Data;

    public partial class FrmAccountsRegister : BaseView
    {
        private Font mBoldFont;
        private BOListAccount mModel;
        

        public FrmAccountsRegister(ApplicationPresenter ap, BOListAccount model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;

            BindViews();
            RegisterEventHandlers();
        }

        protected override void RegisterEventHandlers()
        {
            RegisterEventHandler(tgvAllAccounts, DacEventHandler.EventTypes.DoubleClick, new EventHandler(tgvAllAccounts_DoubleClick));
            RegisterEventHandler(tgvAsset, DacEventHandler.EventTypes.DoubleClick, new EventHandler(tgvAsset_DoubleClick));
            RegisterEventHandler(tgvCoS, DacEventHandler.EventTypes.DoubleClick, new EventHandler(tgvCoS_DoubleClick));
            RegisterEventHandler(tgvEquity, DacEventHandler.EventTypes.DoubleClick, new EventHandler(tgvEquity_DoubleClick));
            RegisterEventHandler(tgvExpense, DacEventHandler.EventTypes.DoubleClick, new EventHandler(tgvExpense_DoubleClick));
            RegisterEventHandler(tgvIncome, DacEventHandler.EventTypes.DoubleClick, new EventHandler(tgvIncome_DoubleClick));
            RegisterEventHandler(tgvLiability, DacEventHandler.EventTypes.DoubleClick, new EventHandler(tgvLiability_DoubleClick));
            RegisterEventHandler(tgvOtherExpense, DacEventHandler.EventTypes.DoubleClick, new EventHandler(tgvOtherExpense_DoubleClick));
            RegisterEventHandler(tgvOtherIncome, DacEventHandler.EventTypes.DoubleClick, new EventHandler(tgvOtherIncome_DoubleClick));
        }

        void tgvOtherIncome_DoubleClick(object sender, EventArgs e)
        {
            TreeNode<Account> node = GetNode(tgvOtherIncome);
            if (node != null) mApplicationController.OpenAccount(node.DataSource);
        }

        void tgvOtherExpense_DoubleClick(object sender, EventArgs e)
        {
            TreeNode<Account> node = GetNode(tgvOtherExpense);
            if (node != null) mApplicationController.OpenAccount(node.DataSource);
        }

        void tgvLiability_DoubleClick(object sender, EventArgs e)
        {
            TreeNode<Account> node = GetNode(tgvLiability);
            if (node != null) mApplicationController.OpenAccount(node.DataSource);
        }

        void tgvIncome_DoubleClick(object sender, EventArgs e)
        {
            TreeNode<Account> node = GetNode(tgvIncome);
            if (node != null) mApplicationController.OpenAccount(node.DataSource);
        }

        void tgvExpense_DoubleClick(object sender, EventArgs e)
        {
            TreeNode<Account> node = GetNode(tgvExpense);
            if (node != null) mApplicationController.OpenAccount(node.DataSource);
        }

        void tgvEquity_DoubleClick(object sender, EventArgs e)
        {
            TreeNode<Account> node = GetNode(tgvEquity);
            if (node != null) mApplicationController.OpenAccount(node.DataSource);
        }

        void tgvCoS_DoubleClick(object sender, EventArgs e)
        {
            TreeNode<Account> node = GetNode(tgvCoS);
            if (node != null) mApplicationController.OpenAccount(node.DataSource);
        }

        void tgvAsset_DoubleClick(object sender, EventArgs e)
        {
            TreeNode<Account> node = GetNode(tgvAsset);
            if (node != null)
            {
                mApplicationController.OpenAccount(node.DataSource);
            }
        }

        void tgvAllAccounts_DoubleClick(object sender, EventArgs e)
        {
            TreeNode<Account> node=GetNode(tgvAllAccounts);
            if (node != null)
            {
                mApplicationController.OpenAccount(node.DataSource);
            }
        }

        private TreeNode<Account> GetNode(TreeGridView tgv)
        {
            TreeNode<Account> node = null;
            if (tgv.SelectedRows.Count == 0) return null;
            if (tgv.SelectedRows[0].Cells.Count == 0) return null;
            node=(TreeNode<Account>)tgv.SelectedRows[0].Cells[0].Tag;
            return node;
        }

        protected override void LoadView()
        {
            if (mBoldFont == null)
            {
                mBoldFont = new Font(tgvAllAccounts.DefaultCellStyle.Font, FontStyle.Bold);
            }

            tgvAllAccounts.Nodes.Clear();
            tgvAsset.Nodes.Clear();
            tgvCoS.Nodes.Clear();
            tgvEquity.Nodes.Clear();
            tgvExpense.Nodes.Clear();
            tgvIncome.Nodes.Clear();
            tgvLiability.Nodes.Clear();
            tgvOtherExpense.Nodes.Clear();
            tgvOtherIncome.Nodes.Clear();

            Hierarchy<Account> hierarchy = mModel.Hierarchy;
            int level = 1;
            foreach (TreeNode<Account> node in hierarchy[level])
            {
                PopulateTreeGridView(tgvAllAccounts, node);
                string accountName=node.DataSource.AccountName;
                if (accountName == "Assets")
                {
                    PopulateTreeGridView(tgvAsset, node);
                }
                else if(accountName=="Liabilities")
                {
                    PopulateTreeGridView(tgvLiability, node);
                }
                else if(accountName=="Equity")
                {
                    PopulateTreeGridView(tgvEquity, node);
                }
                else if(accountName=="Income")
                {
                    PopulateTreeGridView(tgvIncome, node);
                }
                else if(accountName=="Cost Of Sales")
                {
                    PopulateTreeGridView(tgvCoS, node);
                }
                else if(accountName=="Expenses")
                {
                    PopulateTreeGridView(tgvExpense, node);
                }
                else if(accountName=="Other Income")
                {
                    PopulateTreeGridView(tgvOtherIncome, node);
                }
                else if (accountName == "Other Expenses")
                {
                    PopulateTreeGridView(tgvOtherExpense, node);
                }
            }
        }

        private void PopulateTreeGridView(TreeGridView tgv, TreeNode<Account> node)
        {
            TreeGridNode tgnode = tgv.Nodes.Add(node.DataSource, node.DataSource.AccountClassification, node.DataSource.TaxCode, node.DataSource.IsLinked, node.DataSource.CurrentAccountBalanceDescription);
            tgnode.Cells[0].Tag = node;

            PopulateTreeGridView(tgnode, node);
            ExpandTreeGridView(tgnode);
        }

        private void ExpandTreeGridView(TreeGridNode tgnode)
        {
            tgnode.Expand();
            foreach (TreeGridNode tgchild_node in tgnode.Nodes)
            {
                ExpandTreeGridView(tgchild_node);
            }
        }

        private void PopulateTreeGridView(TreeGridNode tgnode, TreeNode<Account> node)
        {
            if (node.DataSource.IsHeader)
            {
                tgnode.Cells[0].Style.Font= mBoldFont;
                //tgnode.DefaultCellStyle.Font = mBoldFont;
            }

            TreeGridNode tgchild_node;
            foreach (TreeNode<Account> child_node in node.Children)
            {
                if (child_node.DataSource.IsHeader)
                {
                    tgchild_node = tgnode.Nodes.Add(child_node.DataSource, child_node.DataSource.AccountClassification, child_node.DataSource.TaxCode, child_node.DataSource.IsLinked, child_node.DataSource.CurrentAccountBalanceDescription);
                    tgchild_node.Cells[0].Tag = child_node;
                }
                else
                {
                    tgchild_node = tgnode.Nodes.Add(child_node.DataSource, child_node.DataSource.SubAccountClassification, child_node.DataSource.TaxCode, child_node.DataSource.IsLinked, child_node.DataSource.CurrentAccountBalanceDescription);
                    tgchild_node.Cells[0].Tag =child_node;
                }
                PopulateTreeGridView(tgchild_node, child_node);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        
    }
}
