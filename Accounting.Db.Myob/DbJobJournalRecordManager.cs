using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Jobs;

namespace Accounting.Db.Myob
{
    public class DbJobJournalRecordManager : JobJournalRecordManager
    {
        public DbJobJournalRecordManager(DbManager mgr)
            : base(mgr)
        {

        }
    }
}
