using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Elements
{
    public abstract class DbElement
    {
        protected DbManager mDbMgr;

        public DbManager DbMgr
        {
            get { return mDbMgr; }
            set { mDbMgr = value; }
        }

        protected bool mValidValue = true;
        public bool IsValidValue
        {
            get { return mValidValue; }
        }

        public virtual string SelectExpression
        {
            get { return ToString(); }
        }
    }
}
