﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Inventory;

namespace Accounting.Db.Myob
{
    public class DbItemDataFieldEntryManager : ItemDataFieldEntryManager 
    {
        public DbItemDataFieldEntryManager(DbManager mgr)
            : base(mgr)
        {
        }
    }
}
