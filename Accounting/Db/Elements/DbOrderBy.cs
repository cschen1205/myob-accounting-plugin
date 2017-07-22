using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Db.Elements
{
    public class DbOrderBy : DbElement
    {
        public enum OrderMode
        {
            ASC,
            DESC
        };

        public OrderMode Order
        {
            get;
            set;
        }

        public DbColumn Column
        {
            get;
            set;
        }

        public override string ToString()
        {
            if (Order == OrderMode.ASC)
            {
                return string.Format("{0} ASC", Column);
            }
            else
            {
                return string.Format("{0} DESC", Column);
            }
        }
    }
}
