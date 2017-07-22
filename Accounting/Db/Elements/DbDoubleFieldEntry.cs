using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Db.Elements
{
    public class DbDoubleFieldEntry : DbFieldEntry
    {
        public DbDoubleFieldEntry(double _value)
        {
            mValue =Convert.ToString(_value);
            mType = EntryType.Type_double;
        }
    }
}
