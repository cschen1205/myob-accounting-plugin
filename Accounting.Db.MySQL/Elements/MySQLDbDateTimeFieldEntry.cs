using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db.Elements;

namespace Accounting.Db.MySQL.Elements
{
    public class MySQLDbDateTimeFieldEntry : DbDateTimeFieldEntry
    {
        public MySQLDbDateTimeFieldEntry(Nullable<DateTime> dt)
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
