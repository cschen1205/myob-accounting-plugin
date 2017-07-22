using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Cards;
using Accounting.Core.Jobs;
using Accounting.Core;
using Accounting.Core.Data;

namespace Accounting.Bll.Jobs
{
    public class BOListJob : BOList<BOJob>
    {
        public BOListJob(Accountant accountant)
            : base(accountant)
        {
            mObjectID = BOType.BOListJob;
        }

        public object DataGridView()
        {
            return mAccountant.JobMgr.Table();
        }

        public Hierarchy<Job> Hierarchy
        {
            get
            {
                return mAccountant.JobMgr.Hierarchy;
            }
        }
    }
}
