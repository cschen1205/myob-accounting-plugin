using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Elements
{
    public class DbAutoIntFieldEntry : DbIntFieldEntry
    {
        public DbAutoIntFieldEntry(int? value)
            : base(value)
        {
            mType = EntryType.Type_auto_int;
            SkipOnUpdate = true;
        }
    }
}
