using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db.Elements;

namespace Accounting.Db.Oracle.Elements
{
    public class OracleDbDateTimeFieldEntry : DbDateTimeFieldEntry
    {
        public OracleDbDateTimeFieldEntry(Nullable<DateTime> dt)
            : base(dt)
        {
            if (dt.HasValue)
            {

                //TO_DATE('1998/05/31 12:00:00', 'YYYY/MM/DD HH24:MI:SS')
                //mValue =string.Format("'{0}'", dt.Value.ToString("MM/dd/yyyy"));
                mValue = string.Format("TO_DATE('{0}', 'YYYY/MM/DD')", dt.Value.ToString("yyyy/MM/dd"));
            }
        }
    }
}
