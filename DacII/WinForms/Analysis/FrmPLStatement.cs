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

    public partial class FrmPLStatement : BaseView
    {
        private Font mBoldFont;
        private BOListAccount mModel;

        public FrmPLStatement(ApplicationPresenter ap, BOListAccount model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;

            BindViews();
            RegisterEventHandlers();
        }

        private string Title
        {
            get
            {
                switch (mModel.PLCriteria)
                {
                    case PLCriteria.ThisYearActualsOnly:
                        return "This Year Actuals";
                    case PLCriteria.LastYearActualsOnly:
                        return "Last Year Actuals";
                    case PLCriteria.BudgetsOnly:
                        return "Budgets";
                    case PLCriteria.ActualsVsBudgets:
                        return "Actuals vs. Budgets";
                    case PLCriteria.ThisYearVsLastYear:
                        return "This Year vs. Last Year";
                    default:
                        return "";
                }
            }
        }

        protected override void LoadView()
        {
            switch (mModel.PLCriteria)
            {
                case PLCriteria.ThisYearActualsOnly:
                    RefreshData(mModel.CurrentFinancialYear, mModel.PLPeriod, false);
                    break;
                case PLCriteria.LastYearActualsOnly:
                    RefreshData(mModel.CurrentFinancialYear - 1, mModel.PLPeriod, false);
                    break;
                case PLCriteria.BudgetsOnly:
                    RefreshData(mModel.CurrentFinancialYear, mModel.PLPeriod, true);
                    break;
                case PLCriteria.ActualsVsBudgets:
                    RefreshData2(mModel.CurrentFinancialYear, mModel.PLPeriod);
                    break;
                case PLCriteria.ThisYearVsLastYear:
                    RefreshData3(mModel.CurrentFinancialYear, mModel.PLPeriod);
                    break;
                default:
                    break;
            }
        }

        private void RefreshData3(int year, int period)
        {
            int display_year = year;
            int display_month;
            PLUtil.Period2MonthYear(mModel.Accountant, period, ref display_year, out display_month);

            tgvPLStatement.Nodes.Clear();
            tgvPLStatement.Columns.Clear();

            tgvPLStatement.Columns.Add(new TreeGridColumn());
            tgvPLStatement.Columns.Add(new DataGridViewTextBoxColumn());
            tgvPLStatement.Columns.Add(new DataGridViewTextBoxColumn());
            tgvPLStatement.Columns.Add(new DataGridViewTextBoxColumn());

            tgvPLStatement.Columns[0].Width = 300;
            tgvPLStatement.Columns[0].HeaderText =
                string.Format("{0} ({1}-{2})", Title, display_year, PLUtil.Month2String(display_month));

            tgvPLStatement.Columns[1].Width = 80;
            tgvPLStatement.Columns[1].HeaderText = "This Year";

            tgvPLStatement.Columns[2].Width = 80;
            tgvPLStatement.Columns[2].HeaderText = "Last Year";

            tgvPLStatement.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tgvPLStatement.Columns[3].HeaderText = "Difference";

            mBoldFont = new Font(tgvPLStatement.DefaultCellStyle.Font, FontStyle.Bold);

            TreeNode<Account> PLStatement = mModel.PLStatement;
            TreeNode<Account> node_income = null;
            TreeNode<Account> node_cos = null;
            TreeNode<Account> node_expenses = null;
            TreeNode<Account> node_other_income = null;
            TreeNode<Account> node_other_expenses = null;
            foreach (TreeNode<Account> child_node in PLStatement.Children)
            {
                string accountName = child_node.DataSource.AccountName;
                if (accountName.Equals("Income"))
                {
                    node_income = child_node;
                }
                else if (accountName.Equals("Cost Of Sales"))
                {
                    node_cos = child_node;
                }
                else if (accountName.Equals("Expenses"))
                {
                    node_expenses = child_node;
                }
                else if (accountName.Equals("Other Income"))
                {
                    node_other_income = child_node;
                }
                else if (accountName.Equals("Other Expenses"))
                {
                    node_other_expenses = child_node;
                }
            }

            PopulateTreeGridView3(tgvPLStatement, node_income, year, period);
            PopulateTreeGridView3(tgvPLStatement, node_cos, year, period);

            double gross_profit = 0, gross_profit2 = 0;
            if (node_income != null && node_cos != null)
            {
                double income = node_income.DataSource.GetAmountByPeriod(year, period, false);
                double cos = node_cos.DataSource.GetAmountByPeriod(year, period, false);
                gross_profit = income - cos;
                string gross_profit_formatted = PLStatement.DataSource.Currency.Format(gross_profit);

                income = node_income.DataSource.GetAmountByPeriod(year-1, period, false);
                cos = node_cos.DataSource.GetAmountByPeriod(year-1, period, false);
                gross_profit2 = income - cos;
                string gross_profit_formatted2 = PLStatement.DataSource.Currency.Format(gross_profit2);

                string difference = PLStatement.DataSource.Currency.Format(
                    gross_profit - gross_profit2);

                PopulateTreeGridView(tgvPLStatement, "Gross Profit", gross_profit_formatted, gross_profit_formatted2, difference);
            }

            PopulateTreeGridView3(tgvPLStatement, node_expenses, year, period);

            double operating_profit = 0, operating_profit2 = 0;
            if (node_expenses != null)
            {
                double expenses = node_expenses.DataSource.GetAmountByPeriod(year, period, false);
                operating_profit = gross_profit - expenses;
                string operating_profit_formatted = PLStatement.DataSource.Currency.Format(operating_profit);

                expenses = node_expenses.DataSource.GetAmountByPeriod(year-1, period, false);
                operating_profit2 = gross_profit2 - expenses;
                string operating_profit_formatted2 = PLStatement.DataSource.Currency.Format(operating_profit2);

                string difference = PLStatement.DataSource.Currency.Format(
                    operating_profit - operating_profit2);

                PopulateTreeGridView(tgvPLStatement, "Operating Profit", operating_profit_formatted, operating_profit_formatted2, difference);
            }

            PopulateTreeGridView2(tgvPLStatement, node_other_income, year, period);
            PopulateTreeGridView2(tgvPLStatement, node_other_expenses, year, period);

            TreeGridNode tgnode_total = tgvPLStatement.Nodes.Add(string.Format("{0}", PLStatement.DataSource.AccountName),
               PLStatement.DataSource.GetAmountDescriptionByPeriod(year, period, false),
               PLStatement.DataSource.GetAmountDescriptionByPeriod(year-1, period, false),
               PLStatement.DataSource.Currency.Format(
                   PLStatement.DataSource.GetAmountByPeriod(year, period, false)
                   - PLStatement.DataSource.GetAmountByPeriod(year-1, period, false)
                   )
               );
            tgnode_total.Cells[0].Style.Font = mBoldFont;
        }

        private void RefreshData2(int year, int period)
        {
            int display_year = year;
            int display_month;
            PLUtil.Period2MonthYear(mModel.Accountant, period, ref display_year, out display_month);

            tgvPLStatement.Nodes.Clear();
            tgvPLStatement.Columns.Clear();

            tgvPLStatement.Columns.Add(new TreeGridColumn());
            tgvPLStatement.Columns.Add(new DataGridViewTextBoxColumn());
            tgvPLStatement.Columns.Add(new DataGridViewTextBoxColumn());
            tgvPLStatement.Columns.Add(new DataGridViewTextBoxColumn());

            tgvPLStatement.Columns[0].Width = 300;
            tgvPLStatement.Columns[0].HeaderText =
                string.Format("{0} ({1}-{2})", Title, display_year, PLUtil.Month2String(display_month));

            tgvPLStatement.Columns[1].Width = 80;
            tgvPLStatement.Columns[1].HeaderText ="Actual";

            tgvPLStatement.Columns[2].Width = 80;
            tgvPLStatement.Columns[2].HeaderText ="Budget";

            tgvPLStatement.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tgvPLStatement.Columns[3].HeaderText ="Difference";

            mBoldFont = new Font(tgvPLStatement.DefaultCellStyle.Font, FontStyle.Bold);

            TreeNode<Account> PLStatement = mModel.PLStatement;
            TreeNode<Account> node_income = null;
            TreeNode<Account> node_cos = null;
            TreeNode<Account> node_expenses = null;
            TreeNode<Account> node_other_income = null;
            TreeNode<Account> node_other_expenses = null;
            foreach (TreeNode<Account> child_node in PLStatement.Children)
            {
                string accountName = child_node.DataSource.AccountName;
                if (accountName.Equals("Income"))
                {
                    node_income = child_node;
                }
                else if (accountName.Equals("Cost Of Sales"))
                {
                    node_cos = child_node;
                }
                else if (accountName.Equals("Expenses"))
                {
                    node_expenses = child_node;
                }
                else if (accountName.Equals("Other Income"))
                {
                    node_other_income = child_node;
                }
                else if (accountName.Equals("Other Expenses"))
                {
                    node_other_expenses = child_node;
                }
            }

            PopulateTreeGridView2(tgvPLStatement, node_income, year, period);
            PopulateTreeGridView2(tgvPLStatement, node_cos, year, period);

            double gross_profit = 0, gross_profit2 = 0;
            if (node_income != null && node_cos != null)
            {
                double income = node_income.DataSource.GetAmountByPeriod(year, period, false);
                double cos = node_cos.DataSource.GetAmountByPeriod(year, period, false);
                gross_profit = income - cos;
                string gross_profit_formatted = PLStatement.DataSource.Currency.Format(gross_profit);

                income = node_income.DataSource.GetAmountByPeriod(year, period, true);
                cos = node_cos.DataSource.GetAmountByPeriod(year, period, true);
                gross_profit2 = income - cos;
                string gross_profit_formatted2 = PLStatement.DataSource.Currency.Format(gross_profit2);

                string difference = PLStatement.DataSource.Currency.Format(gross_profit - gross_profit2);

                PopulateTreeGridView(tgvPLStatement, "Gross Profit", gross_profit_formatted, gross_profit_formatted2, difference);
            }

            PopulateTreeGridView2(tgvPLStatement, node_expenses, year, period);

            double operating_profit = 0, operating_profit2 = 0;
            if (node_expenses != null)
            {
                double expenses = node_expenses.DataSource.GetAmountByPeriod(year, period, false);
                operating_profit = gross_profit - expenses;
                string operating_profit_formatted = PLStatement.DataSource.Currency.Format(operating_profit);

                expenses = node_expenses.DataSource.GetAmountByPeriod(year, period, true);
                operating_profit2 = gross_profit2 - expenses;
                string operating_profit_formatted2 = PLStatement.DataSource.Currency.Format(operating_profit2);

                string difference = PLStatement.DataSource.Currency.Format(operating_profit - operating_profit2);

                PopulateTreeGridView(tgvPLStatement, "Operating Profit", operating_profit_formatted, operating_profit_formatted2, difference);
            }

            PopulateTreeGridView2(tgvPLStatement, node_other_income, year, period);
            PopulateTreeGridView2(tgvPLStatement, node_other_expenses, year, period);

    

            TreeGridNode tgnode_total = tgvPLStatement.Nodes.Add(string.Format("{0}", PLStatement.DataSource.AccountName),
               PLStatement.DataSource.GetAmountDescriptionByPeriod(year, period, true),
               PLStatement.DataSource.GetAmountDescriptionByPeriod(year, period, false),
               PLStatement.DataSource.Currency.Format(
                PLStatement.DataSource.GetAmountByPeriod(year, period, false)
                - PLStatement.DataSource.GetAmountByPeriod(year, period, true)
                )
               );
            tgnode_total.Cells[0].Style.Font = mBoldFont;
        }

        private void RefreshData(int year, int period, bool budgets)
        {
            int display_year = year;
            int display_month;
            PLUtil.Period2MonthYear(mModel.Accountant, period, ref display_year, out display_month);

            tgvPLStatement.Nodes.Clear();
            tgvPLStatement.Columns.Clear();

            tgvPLStatement.Columns.Add(new TreeGridColumn());
            tgvPLStatement.Columns.Add(new DataGridViewTextBoxColumn());
            tgvPLStatement.Columns.Add(new DataGridViewTextBoxColumn());

            tgvPLStatement.Columns[0].Width = 300;
            tgvPLStatement.Columns[0].HeaderText =
                string.Format("{0} ({1}-{2})", Title, display_year, PLUtil.Month2String(display_month));

            tgvPLStatement.Columns[1].Width = 150;
            tgvPLStatement.Columns[1].HeaderText =
                string.Format("Selected Period ({0})", PLUtil.Month2String(display_month));

            tgvPLStatement.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tgvPLStatement.Columns[2].HeaderText =
                string.Format("Year To Date ({0})", display_year);

            mBoldFont = new Font(tgvPLStatement.DefaultCellStyle.Font, FontStyle.Bold);

            TreeNode<Account> PLStatement = mModel.PLStatement;
            TreeNode<Account> node_income = null;
            TreeNode<Account> node_cos = null;
            TreeNode<Account> node_expenses = null;
            TreeNode<Account> node_other_income = null;
            TreeNode<Account> node_other_expenses = null;
            foreach (TreeNode<Account> child_node in PLStatement.Children)
            {
                string accountName = child_node.DataSource.AccountName;
                if (accountName.Equals("Income"))
                {
                    node_income = child_node;
                }
                else if (accountName.Equals("Cost Of Sales"))
                {
                    node_cos = child_node;
                }
                else if (accountName.Equals("Expenses"))
                {
                    node_expenses = child_node;
                }
                else if (accountName.Equals("Other Income"))
                {
                    node_other_income = child_node;
                }
                else if (accountName.Equals("Other Expenses"))
                {
                    node_other_expenses = child_node;
                }
            }

            PopulateTreeGridView(tgvPLStatement, node_income, year, period, budgets);
            PopulateTreeGridView(tgvPLStatement, node_cos, year, period, budgets);

            double gross_profit = 0, gross_profit2 = 0;
            if (node_income != null && node_cos != null)
            {
                double income = node_income.DataSource.GetAccountBalance(year, period, budgets);
                double cos = node_cos.DataSource.GetAccountBalance(year, period, budgets);
                gross_profit = income - cos;
                string gross_profit_formatted = PLStatement.DataSource.Currency.Format(gross_profit);

                income = node_income.DataSource.GetAmountByPeriod(year, period, budgets);
                cos = node_cos.DataSource.GetAmountByPeriod(year, period, budgets);
                gross_profit2 = income - cos;
                string gross_profit_formatted2 = PLStatement.DataSource.Currency.Format(gross_profit2);

                PopulateTreeGridView(tgvPLStatement, "Gross Profit", gross_profit_formatted, gross_profit_formatted2);
            }

            PopulateTreeGridView(tgvPLStatement, node_expenses, year, period, budgets);

            double operating_profit = 0, operating_profit2 = 0;
            if (node_expenses != null)
            {
                double expenses = node_expenses.DataSource.GetAccountBalance(year, period, budgets);
                operating_profit = gross_profit - expenses;
                string operating_profit_formatted = PLStatement.DataSource.Currency.Format(operating_profit);

                expenses = node_expenses.DataSource.GetAmountByPeriod(year, period, budgets);
                operating_profit2 = gross_profit2 - expenses;
                string operating_profit_formatted2 = PLStatement.DataSource.Currency.Format(operating_profit2);

                PopulateTreeGridView(tgvPLStatement, "Operating Profit", operating_profit_formatted, operating_profit_formatted2);
            }

            PopulateTreeGridView(tgvPLStatement, node_other_income, year, period, budgets);
            PopulateTreeGridView(tgvPLStatement, node_other_expenses, year, period, budgets);

            TreeGridNode tgnode_total = tgvPLStatement.Nodes.Add(string.Format("{0}", PLStatement.DataSource.AccountName),
               PLStatement.DataSource.GetAmountDescriptionByPeriod(year, period, budgets),
               PLStatement.DataSource.GetAccountBalanceDescription(year, period, budgets)
               );
            tgnode_total.Cells[0].Style.Font = mBoldFont;
        }

        private void PopulateTreeGridView(TreeGridView tgv, params string[] fieldvalues)
        {
            TreeGridNode tgnode = null;
            if (fieldvalues.Length <= 3)
            {
                tgnode = tgv.Nodes.Add(fieldvalues[0], 
                (fieldvalues.Length > 1 ? fieldvalues[1] : ""), 
                (fieldvalues.Length > 2 ? fieldvalues[2] : ""));
            }
            else
            {
                tgnode = tgv.Nodes.Add(fieldvalues[0], 
                fieldvalues[1],fieldvalues[2], fieldvalues[3]);
            }
            tgnode.Cells[0].Style.Font = mBoldFont;

            tgv.Nodes.Add("", "", "");
        }

        private void PopulateTreeGridView2(TreeGridView tgv, TreeNode<Account> node, int year, int period)
        {
            if (node == null) return;
            TreeGridNode tgnode = tgv.Nodes.Add(node.DataSource.AccountName, "", "");

            PopulateTreeGridView2(tgnode, node, year, period);
            ExpandTreeGridView(tgnode);

            TreeGridNode tgnode_total = tgv.Nodes.Add(string.Format("{0}", node.DataSource.AccountName),
                node.DataSource.GetAmountDescriptionByPeriod(year, period, false),
                node.DataSource.GetAmountDescriptionByPeriod(year, period, true),
                node.DataSource.Currency.Format(
                    node.DataSource.GetAmountByPeriod(year, period, false)
                    - node.DataSource.GetAmountByPeriod(year, period, true)
                    )
                );
            tgnode_total.Cells[0].Style.Font = mBoldFont;

            tgv.Nodes.Add("", "", "");


        }

        private void PopulateTreeGridView3(TreeGridView tgv, TreeNode<Account> node, int year, int period)
        {
            if (node == null) return;
            TreeGridNode tgnode = tgv.Nodes.Add(node.DataSource.AccountName, "", "");

            PopulateTreeGridView3(tgnode, node, year, period);
            ExpandTreeGridView(tgnode);

            TreeGridNode tgnode_total = tgv.Nodes.Add(string.Format("{0}", node.DataSource.AccountName),
                node.DataSource.GetAmountDescriptionByPeriod(year, period, false),
                node.DataSource.GetAmountDescriptionByPeriod(year-1, period, false),
                node.DataSource.Currency.Format(
                    node.DataSource.GetAmountByPeriod(year, period, false)
                    -node.DataSource.GetAmountByPeriod(year-1, period, false))
                );
            tgnode_total.Cells[0].Style.Font = mBoldFont;

            tgv.Nodes.Add("", "", "");


        }

        private void PopulateTreeGridView(TreeGridView tgv, TreeNode<Account> node, int year, int period, bool budgets)
        {
            if (node == null) return;
            TreeGridNode tgnode = tgv.Nodes.Add(node.DataSource.AccountName, "", "");

            PopulateTreeGridView(tgnode, node, year, period, budgets);
            ExpandTreeGridView(tgnode);

            TreeGridNode tgnode_total = tgv.Nodes.Add(string.Format("{0}", node.DataSource.AccountName),
                node.DataSource.GetAmountDescriptionByPeriod(year, period, budgets),
                node.DataSource.GetAccountBalanceDescription(year, period, budgets)
                );
            tgnode_total.Cells[0].Style.Font = mBoldFont;

            tgv.Nodes.Add("", "", "");

            
        }

        private void ExpandTreeGridView(TreeGridNode tgnode)
        {
            tgnode.Expand();
            foreach (TreeGridNode tgchild_node in tgnode.Nodes)
            {
                ExpandTreeGridView(tgchild_node);
            }
        }

        private void PopulateTreeGridView3(TreeGridNode tgnode, TreeNode<Account> node, int year, int period)
        {
            if (node.DataSource.IsHeader)
            {
                tgnode.Cells[0].Style.Font = mBoldFont;
            }

            TreeGridNode tgchild_node;
            foreach (TreeNode<Account> child_node in node.Children)
            {
                if (child_node.DataSource.IsHeader)
                {
                    tgchild_node = tgnode.Nodes.Add(child_node.DataSource.AccountName, "", "");
                }
                else
                {
                    tgchild_node = tgnode.Nodes.Add(child_node.DataSource.AccountName,
                        child_node.DataSource.GetAmountDescriptionByPeriod(year, period, false),
                        child_node.DataSource.GetAmountDescriptionByPeriod(year-1, period, false),
                        child_node.DataSource.Currency.Format(
                            child_node.DataSource.GetAmountByPeriod(year, period, false)
                            -child_node.DataSource.GetAmountByPeriod(year-1, period, false))
                        );
                }
                PopulateTreeGridView3(tgchild_node, child_node, year, period);
            }
        }

        private void PopulateTreeGridView2(TreeGridNode tgnode, TreeNode<Account> node, int year, int period)
        {
            if (node.DataSource.IsHeader)
            {
                tgnode.Cells[0].Style.Font = mBoldFont;
            }

            TreeGridNode tgchild_node;
            foreach (TreeNode<Account> child_node in node.Children)
            {
                if (child_node.DataSource.IsHeader)
                {
                    tgchild_node = tgnode.Nodes.Add(child_node.DataSource.AccountName, "", "");
                }
                else
                {
                    tgchild_node = tgnode.Nodes.Add(child_node.DataSource.AccountName,
                        child_node.DataSource.GetAmountDescriptionByPeriod(year, period, false),
                        child_node.DataSource.GetAmountDescriptionByPeriod(year, period, true),
                        child_node.DataSource.Currency.Format(
                            child_node.DataSource.GetAmountByPeriod(year, period, false)
                            - child_node.DataSource.GetAmountByPeriod(year, period, true)
                            )
                        );
                }
                PopulateTreeGridView2(tgchild_node, child_node, year, period);
            }
        }

        private void PopulateTreeGridView(TreeGridNode tgnode, TreeNode<Account> node, int year, int period, bool budgets)
        {
            if (node.DataSource.IsHeader)
            {
                tgnode.Cells[0].Style.Font = mBoldFont;
            }

            TreeGridNode tgchild_node;
            foreach (TreeNode<Account> child_node in node.Children)
            {
                if (child_node.DataSource.IsHeader)
                {
                    tgchild_node = tgnode.Nodes.Add(child_node.DataSource.AccountName, "", "");
                }
                else
                {
                    tgchild_node = tgnode.Nodes.Add(child_node.DataSource.AccountName,
                        child_node.DataSource.GetAmountDescriptionByPeriod(year, period, budgets),
                        child_node.DataSource.GetAccountBalanceDescription(year, period, budgets)
                        );
                }
                PopulateTreeGridView(tgchild_node, child_node, year, period, budgets);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FrmPLFilter frm = new FrmPLFilter(mApplicationController);
            frm.Period = mModel.PLPeriod;
            frm.PLCriteria = mModel.PLCriteria;
            if (frm.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (mModel.PLPeriod == frm.Period &&
                mModel.PLCriteria == frm.PLCriteria
                )
            {
                return;
            }
            mModel.PLPeriod = frm.Period;
            mModel.PLCriteria = frm.PLCriteria;
            SafeLoadView();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}
