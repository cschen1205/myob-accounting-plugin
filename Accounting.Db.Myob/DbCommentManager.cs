using System;
using System.Collections.Generic;
using System.Text;
using Accounting.Core.Misc;
using Accounting.Db;

namespace Accounting.Db.Myob
{
    public class DbCommentManager : CommentManager
    {
        public DbCommentManager(DbManager mgr)
            : base(mgr)
        {
           
        }
    }
}
