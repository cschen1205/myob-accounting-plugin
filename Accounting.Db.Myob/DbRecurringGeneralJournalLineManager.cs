using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.JournalRecords;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbRecurringGeneralJournalLineManager : RecurringGeneralJournalLineManager
    {
        public DbRecurringGeneralJournalLineManager(DbManager mgr)
            : base(mgr)
        {
          
        }
    }
}
