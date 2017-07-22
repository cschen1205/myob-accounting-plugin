using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Db.Elements
{
    public class DbIntFieldEntry : DbFieldEntry
    {
        public DbIntFieldEntry(int? _value)
        {
            if (_value == null)
            {
                mValidValue = false;
            }
            else
            {
                mValue = Convert.ToString(_value);
                mType = EntryType.Type_int;
            }
        }
    }
}
