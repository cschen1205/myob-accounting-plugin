using System;
using System.Drawing;
using System.Windows.Forms;


namespace DacII.WinForms.Analysis
{
    using DacII.Presenters;
    using DacII.DacHandlers;

    using AdvancedDataGridView;
    using Accounting.Bll;
    using Accounting.Bll.Analysis;
    using Accounting.Core.Jobs;
    using Accounting.Core.Accounts;
    using Accounting.Core.Data;

    public partial class FrmJobs : BaseView
    {
        private Font mBoldFont;
        private BOJobs mModel ;

        public FrmJobs(ApplicationPresenter ap, BOJobs model)
            : base(ap)
        {
            InitializeComponent();
            mModel=model;

            BindViews();
            RegisterEventHandlers();
        }

        private string Title
        {
            get 
            {
                if (mModel.SelectJob == null)
                {
                    return "Actuals vs. Budgets";
                }
                else
                {
                    return string.Format("Actuals vs. Budgets -- ({0}) {1}",
                        mModel.SelectJob.JobNumber,
                        mModel.SelectJob.JobName);
                }
            }
        }

        private void BindJobTree()
        {
            ddtvJob.Nodes.Clear();
            foreach (TreeNode<Job> node in mModel.JobTree[1])
            {
                BindJobTreeNode(ddtvJob, node);
            }
        }

        private void BindJobTreeNode(TreeView ddtv, TreeNode<Job> node)
        {
            TreeNode treenode=new TreeNode();
            treenode.Text=string.Format("({0})-{1}", node.DataSource.JobNumber, node.DataSource.JobName);
            treenode.Tag=node;
            if (node.DataSource.IsHeader)
            {
            }
            ddtv.Nodes.Add(treenode);
            BindJobTreeNode(treenode, node);

            ExpandTreeView(treenode);
        }

        private void ExpandTreeView(TreeNode tgnode)
        {
            tgnode.Expand();
            foreach (TreeNode tgchild_node in tgnode.Nodes)
            {
                ExpandTreeView(tgchild_node);
            }
        }

        private void BindJobTreeNode(TreeNode treenode, TreeNode<Job> node)
        {
            foreach (TreeNode<Job> child_node in node.Children)
            {
                TreeNode child_treenode=new TreeNode();
                child_treenode.Text = string.Format("({0}) {1}", child_node.DataSource.JobNumber, child_node.DataSource.JobName);
                child_treenode.Tag=child_node;

                treenode.Nodes.Add(child_treenode);
                BindJobTreeNode(child_treenode, child_node);
            }
        }

        private void RefreshData()
        {
            lblJobNumber.Text = (mModel.SelectJob == null ? "Job Number: XXX" : string.Format("Job Number: {0}", mModel.SelectJob.JobNumber));
            lblPercentCompleted.Text=(mModel.SelectJob==null ? "Percent Completed: XXX" : string.Format("Percent Completed: {0}", mModel.SelectJob.PercentCompleted));
            lblJobName.Text = (mModel.SelectJob == null ? "Job Name: XXX" : string.Format("Job Name: {0}", mModel.SelectJob.JobName));

            tgvPLStatement.Nodes.Clear();
            tgvPLStatement.Columns.Clear();

            tgvPLStatement.Columns.Add(new TreeGridColumn());
            tgvPLStatement.Columns.Add(new DataGridViewTextBoxColumn());
            tgvPLStatement.Columns.Add(new DataGridViewTextBoxColumn());
            tgvPLStatement.Columns.Add(new DataGridViewTextBoxColumn());

            tgvPLStatement.Columns[0].Width = 300;
            tgvPLStatement.Columns[0].HeaderText = Title;

            tgvPLStatement.Columns[1].Width = 80;
            tgvPLStatement.Columns[1].HeaderText ="Actuals";

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

            PopulateTreeGridView2(tgvPLStatement, node_income);
            PopulateTreeGridView2(tgvPLStatement, node_cos);

            double gross_profit = 0, gross_profit2 = 0;
            if (node_income != null && node_cos != null)
            {
                double income = mModel.GetActuals(node_income);
                double cos = mModel.GetActuals(node_cos);
                gross_profit = income - cos;
                string gross_profit_formatted = PLStatement.DataSource.Currency.Format(gross_profit);

                income = mModel.GetBudget(node_income);
                cos = mModel.GetBudget(node_cos);
                gross_profit2 = income - cos;
                string gross_profit_formatted2 = PLStatement.DataSource.Currency.Format(gross_profit2);

                string difference = PLStatement.DataSource.Currency.Format(gross_profit - gross_profit2);

                PopulateTreeGridView(tgvPLStatement, "Gross Profit", gross_profit_formatted, gross_profit_formatted2, difference);
            }

            PopulateTreeGridView2(tgvPLStatement, node_expenses);

            double operating_profit = 0, operating_profit2 = 0;
            if (node_expenses != null)
            {
                double expenses = mModel.GetActuals(node_expenses);
                operating_profit = gross_profit - expenses;
                string operating_profit_formatted = PLStatement.DataSource.Currency.Format(operating_profit);

                expenses = mModel.GetBudget(node_expenses);
                operating_profit2 = gross_profit2 - expenses;
                string operating_profit_formatted2 = PLStatement.DataSource.Currency.Format(operating_profit2);

                string difference = PLStatement.DataSource.Currency.Format(operating_profit - operating_profit2);

                PopulateTreeGridView(tgvPLStatement, "Operating Profit", operating_profit_formatted, operating_profit_formatted2, difference);
            }

            PopulateTreeGridView2(tgvPLStatement, node_other_income);
            PopulateTreeGridView2(tgvPLStatement, node_other_expenses);

    

            TreeGridNode tgnode_total = tgvPLStatement.Nodes.Add(string.Format("{0}", PLStatement.DataSource.AccountName),
               mModel.GetActualsT(PLStatement),
               mModel.GetBudgetT(PLStatement),
               mModel.GetDifferenceT(PLStatement)
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

        private void PopulateTreeGridView2(TreeGridView tgv, TreeNode<Account> node)
        {
            if (node == null) return;
            TreeGridNode tgnode = tgv.Nodes.Add(node.DataSource.AccountName, "", "");

            PopulateTreeGridView2(tgnode, node);
            ExpandTreeGridView(tgnode);

            TreeGridNode tgnode_total = tgv.Nodes.Add(string.Format("{0}", node.DataSource.AccountName),
                mModel.GetActualsT(node),
                mModel.GetBudgetT(node),
                mModel.GetDifferenceT(node)
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

        private void PopulateTreeGridView2(TreeGridNode tgnode, TreeNode<Account> node)
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
                        mModel.GetActualsT(child_node),
                        mModel.GetBudgetT(child_node),
                        mModel.GetDifferenceT(child_node)
                        );
                }
                PopulateTreeGridView2(tgchild_node, child_node);
            }
        }



        protected override void LoadView()
        {
            BindJobTree();
            RefreshData();
        }

        protected override void RegisterEventHandlers()
        {
            RegisterEventHandler(ddtvJob, DacEventHandler.EventTypes.AfterSelect, new TreeViewEventHandler(ddtvJob_AfterSelect));
        }

        void ddtvJob_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selected_node=ddtvJob.SelectedNode;
            if(selected_node==null) return;
            mModel.SelectJob = ((TreeNode<Job>)selected_node.Tag).DataSource;
            RefreshData();
        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        //[System.Runtime.InteropServices.DllImport("gdi32.dll")]
        //public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        //private Bitmap memoryImage;
        //private void CaptureScreen()
        //{
        //    Graphics mygraphics = this.CreateGraphics();
        //    Size s = this.Size;
        //    memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
        //    Graphics memoryGraphics = Graphics.FromImage(memoryImage);
        //    IntPtr dc1 = mygraphics.GetHdc();
        //    IntPtr dc2 = memoryGraphics.GetHdc();
        //    BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
        //    mygraphics.ReleaseHdc(dc1);
        //    memoryGraphics.ReleaseHdc(dc2);
        //}
        //private void PrintDoc_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    e.Graphics.DrawImage(memoryImage, 0, 0);
        //}

        //private void btnPrint_Click(object sender, EventArgs e)
        //{
        //    CaptureScreen();
        //    PrintDoc.Print();
        //}
    }
}
