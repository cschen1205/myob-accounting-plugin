using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db.Elements;

namespace Accounting.Db.Myob.Elements
{
    public class MyobDbDateTimeFieldEntry : DbDateTimeFieldEntry
    {
        private string mSelectExpression = "";
        public MyobDbDateTimeFieldEntry(Nullable<DateTime> dt)
            : base(dt)
        {
            if (dt.HasValue)
            {
                mValue =string.Format("'{0}'", dt.Value.ToString("dd/MM/yyyy"));
                mSelectExpression = string.Format("'{0}'", dt.Value.ToString("yyyy-MM-dd"));
            }
        }

        public override string SelectExpression
        {
            get
            {
                return mSelectExpression;
            }
        }
    }
}
