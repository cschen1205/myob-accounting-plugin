using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db.Elements;

namespace Accounting.Db.SqlCe.Elements
{
    public class SqlCeDbDateTimeFieldEntry : DbDateTimeFieldEntry
    {
        public SqlCeDbDateTimeFieldEntry(Nullable<DateTime> dt)
            : base(dt)
        {
            if (dt.HasValue)
            {
                //mValue =string.Format("'{0}'", dt.Value.ToString("MM/dd/yyyy"));
                mValue = string.Format("'{0}'", dt.Value.ToString("yyyy-MM-dd"));
            }
        }
    }
}
