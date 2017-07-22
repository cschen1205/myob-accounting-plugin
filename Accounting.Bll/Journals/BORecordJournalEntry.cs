using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Journals
{
    using Accounting.Core.JournalRecords;
    public class BORecordJournalEntry : BusinessObject
    {
        JournalRecord mDataProxy;
        JournalRecord mDataSource;

        public BORecordJournalEntry(Accountant accountant, JournalRecord data, BOContext context)
            : base(accountant, context)
        {
            mObjectID = BOType.BORecordJournalEntry;
            mDataProxy = data.Clone() as JournalRecord;
            mDataSource = data;
        }

        protected override Accounting.Core.OpResult _Delete()
        {
            return mAccountant.JournalRecordMgr.Delete(mDataSource);
        }

        protected override Accounting.Core.OpResult _Record()
        {
            mDataSource.AssignFrom(mDataProxy);
            return mAccountant.JournalRecordMgr.Store(mDataSource);
        }
    }
}
