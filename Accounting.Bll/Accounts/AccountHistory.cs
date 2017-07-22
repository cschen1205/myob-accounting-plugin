using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Accounts
{
    public class AccountHistory
    {
        public string Month
        {
            get;
            set;
        }

        public string LastFYBalance
        {
            set;
            get;
        }

        public string CurrentFYBalance
        {
            set;
            get;
        }
    }
}
