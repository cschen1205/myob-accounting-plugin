using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.JournalRecords
{
    public interface JournalSource
    {
        Nullable<DateTime> GetTransactionDate();
        int? GetSourceID();
    }
}
