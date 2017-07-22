using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.JournalRecords;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbRecurringGeneralJournalManager : RecurringGeneralJournalManager
    {
        public DbRecurringGeneralJournalManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
