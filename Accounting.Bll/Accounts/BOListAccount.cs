using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core;
using Accounting.Core.Accounts;
using Accounting.Core.Data;

namespace Accounting.Bll.Accounts
{
    public class BOListAccount : BOList<BOAccount>
    {
        public BOListAccount(Accountant accountant)
            : base(accountant)
        {
            mObjectID = BOType.BOListAccount;
        }

        public int CurrentFinancialYear
        {
            get
            {
                return mAccountant.DataFileInformationMgr.Company.CurrentFinancialYear.Value;
            }
        }

        private PLCriteria mPLCriteria = PLCriteria.ThisYearActualsOnly;
        public PLCriteria PLCriteria
        {
            get { return mPLCriteria; }
            set { mPLCriteria = value; }
        }

        public int mPLPeriod = 12;
        public int PLPeriod
        {
            get
            {
                return mPLPeriod;
            }
            set
            {
                mPLPeriod = value;
            }
        }
  
        
        public Hierarchy<Account> Hierarchy
        {
            get
            {
                return mAccountant.AccountMgr.Hierarchy;
            }
        }

        public TreeNode<Account> BalanceSheet
        {
            get
            {
                return mAccountant.AccountMgr.BalanceSheet;
            }
        }

        public TreeNode<Account> PLStatement
        {
            get
            {
                return mAccountant.AccountMgr.PLStatement;
            }
        }
    }
}
