using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Elements
{
    public class DbJoin : DbElement
    {
        public DbColumn Column1
        {
            get;
            set;
        }

        public DbColumn Column2
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Format("{0} = {1}", Column1, Column2);
        }
    }
}
