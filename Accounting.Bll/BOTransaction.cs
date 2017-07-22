using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll
{
    public class BOTransaction : BusinessObject
    {
        public BOTransaction(Accountant acc, BOContext state)
            : base(acc, state)
        {
        }
    }
}
