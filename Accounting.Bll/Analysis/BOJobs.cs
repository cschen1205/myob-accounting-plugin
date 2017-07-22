using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Accounts;
using Accounting.Core.Data;
using Accounting.Bll.Accounts;
using Accounting.Core.Jobs;

namespace Accounting.Bll.Analysis
{
    public class BOJobs : BusinessObject
    {
        BOListAccount mListAccountModel;
        Job mSelectedJob = null;

        public Job SelectJob
        {
            get { return mSelectedJob; }
            set { mSelectedJob = value; }
        }

        public BOJobs(Accountant acc, BOContext context)
            : base(acc, context)
        {
            mObjectID = BOType.BOAnalysisJobs;
            mListAccountModel = new BOListAccount(acc);
        }

        private TreeNode<Account> mPLStatement=null;
        public TreeNode<Account> PLStatement
        {
            get
            {
                if (mPLStatement == null)
                {
                   mPLStatement= mListAccountModel.PLStatement;
                }
                return mPLStatement;
            }
        }

        private Hierarchy<Job> mJobTree = null;
        public Hierarchy<Job> JobTree
        {
            get
            {
                if(mJobTree==null)
                {
                    mJobTree = mAccountant.JobMgr.Hierarchy;
                }
                return mJobTree;
            }
        }

        public string GetBudgetT(TreeNode<Account> node)
        {
            return node.DataSource.Currency.Format(GetBudget(node));
        }

        public string GetActualsT(TreeNode<Account> node)
        {
            return node.DataSource.Currency.Format(GetActuals(node));
        }

        public double GetBudget(TreeNode<Account> node)
        {
            TreeNode<Job> job_treenode = JobTree.Find(mSelectedJob);
            return GetBudget(node, job_treenode);
        }

        public double GetBudget(TreeNode<Account> node, TreeNode<Job> job_treenode)
        {
            if (job_treenode == null) return 0;
            JobBudget jb = mAccountant.JobBudgetMgr.FindByJobAccount(job_treenode.DataSource, node.DataSource);
            if (jb != null)
                return jb.Amount;

            double sum = 0;
           
            if (job_treenode.Children.Count > 0)
            {
                foreach (TreeNode<Job> job_childnode in job_treenode.Children)
                {
                    sum += GetBudget(node, job_childnode);
                }
            }
            else
            {
                foreach (TreeNode<Account> child_node in node.Children)
                {
                    sum += GetBudget(child_node, job_treenode);
                }
            }
            return sum;
        }

        public double GetActuals(TreeNode<Account> node)
        {
            TreeNode<Job> job_treenode = JobTree.Find(mSelectedJob);
            return GetActuals(node, job_treenode);
        }

        public double GetActuals(TreeNode<Account> node, TreeNode<Job> job_treenode)
        {
            if (job_treenode == null) return 0;
            JobAccount jacc = mAccountant.JobAccountMgr.FindByJobAccount(job_treenode.DataSource, node.DataSource);
            if (jacc != null)
                return jacc.CurrentBalance;

            double sum = 0;


            if (job_treenode.Children.Count > 0)
            {
                foreach (TreeNode<Job> job_childnode in job_treenode.Children)
                {
                    sum += GetActuals(node, job_childnode);
                }
            }
            else
            {
                foreach (TreeNode<Account> child_node in node.Children)
                {
                    sum += GetActuals(child_node, job_treenode);
                }
            }

            
            return sum;
        }

        public string GetDifferenceT(TreeNode<Account> node)
        {
            double actuals = GetActuals(node);
            double budget = GetBudget(node);
            return node.DataSource.Currency.Format(actuals - budget);
        }
    }
}
