using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.JournalRecords;

namespace Accounting.Bll.Journals
{
    public class BOListTransactionJournal : BOList<BOTransaction>
    {
        public BOListTransactionJournal(Accountant accountant)
            : base(accountant)
        {
            mObjectID = BOType.BOListTransactionJournal;
        }

        public List<JournalSet> ListJournalSet(DateTime start_date, DateTime end_date)
        {
            return mAccountant.JournalSetMgr.RetrieveByTransactionDates(start_date, end_date);
        }
    }
}
