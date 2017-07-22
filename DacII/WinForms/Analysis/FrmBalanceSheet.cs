using System;
using System.Drawing;
using System.Windows.Forms;


namespace DacII.WinForms.Analysis
{
    using DacII.Presenters;
    using AdvancedDataGridView;
    using Accounting.Bll;
    using Accounting.Bll.Accounts;
    using Accounting.Core.Accounts;
    using Accounting.Core.Data;

    public partial class FrmBalanceSheet : BaseView
    {
        private Font mBoldFont;
        private BOListAccount mModel;

        public FrmBalanceSheet(ApplicationPresenter ap, BOListAccount model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;

            BindViews();
            RegisterEventHandlers();
        }

        protected override void LoadView()
        {
            if (mBoldFont == null)
            {
                mBoldFont = new Font(tgvBalanceSheet.DefaultCellStyle.Font, FontStyle.Bold);
            }

            tgvBalanceSheet.Nodes.Clear();

            TreeNode<Account> balanceSheet = mModel.BalanceSheet;
            foreach (TreeNode<Account> child_node in balanceSheet.Children)
            {
                PopulateTreeGridView(tgvBalanceSheet, child_node);
            }
        }

        private void PopulateTreeGridView(TreeGridView tgv, TreeNode<Account> node)
        {
            TreeGridNode tgnode = tgv.Nodes.Add(node.DataSource.AccountName, "", "");

            PopulateTreeGridView(tgnode, node);
            ExpandTreeGridView(tgnode);

            TreeGridNode tgnode_total = tgv.Nodes.Add(string.Format("Total {0}", node.DataSource.AccountName), 
                node.DataSource.CurrentYearAccountBalanceDescription,
                node.DataSource.Currency.FormatPercent(node.Percent)
                );
            tgnode_total.Cells[0].Style.Font = mBoldFont;
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
                tgnode.Cells[0].Style.Font = mBoldFont;
            }

            TreeGridNode tgchild_node;
            TreeGridNode tgchild_total;
            foreach (TreeNode<Account> child_node in node.Children)
            {
                if (child_node.DataSource.IsHeader)
                {
                    tgchild_node = tgnode.Nodes.Add(child_node.DataSource.AccountName, "", "");
                    tgchild_total=tgnode.Nodes.Add(string.Format("Total {0}", child_node.DataSource.AccountName), 
                        child_node.DataSource.CurrentYearAccountBalanceDescription, 
                        child_node.DataSource.Currency.FormatPercent(child_node.Percent)
                        );
                    tgchild_total.Cells[0].Style.Font = mBoldFont;
                }
                else
                {
                    tgchild_node = tgnode.Nodes.Add(child_node.DataSource.AccountName, 
                        child_node.DataSource.CurrentYearAccountBalanceDescription, 
                        child_node.DataSource.Currency.FormatPercent(child_node.Percent)
                        );
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
