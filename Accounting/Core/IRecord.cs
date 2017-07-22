using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core
{
    using Db.Elements;
    public interface IRecord
    {
        bool Match(int? id);
        bool Match(string id);
        RecordKeyString TextId
        {
            get;
        }
        RecordKeyInt IntId
        {
            get;
        }
    }
}
