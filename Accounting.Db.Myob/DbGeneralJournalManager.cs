using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.JournalRecords;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbGeneralJournalManager : GeneralJournalManager
    {
        public DbGeneralJournalManager(DbManager mgr)
            : base(mgr)
        {
            
        }
    }
}
