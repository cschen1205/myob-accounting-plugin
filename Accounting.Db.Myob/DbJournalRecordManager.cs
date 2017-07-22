using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.JournalRecords;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbJournalRecordManager : JournalRecordManager
    {
        public DbJournalRecordManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
