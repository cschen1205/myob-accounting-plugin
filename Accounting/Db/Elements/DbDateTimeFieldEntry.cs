using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Db.Elements
{
    public class DbDateTimeFieldEntry : DbFieldEntry
    {
        private Nullable<DateTime> mDate=null;
        public DbDateTimeFieldEntry(Nullable<DateTime> dt)
        {
            if (dt.HasValue)
            {
                mDate = dt;
                mValue =string.Format("#{0}#", dt.Value.ToString("MM/dd/yyyy"));
                mValidValue = true;
            }
            else
            {
                mValidValue = false;
            }
            mType = EntryType.Type_DateTime;
        }

        public override object DataSource
        {
            get
            {
                return mDate;
            }
        }

        public override string ToString()
        {
            if (mDate != null)
            {
                return mValue;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
