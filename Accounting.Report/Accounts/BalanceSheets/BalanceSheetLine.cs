using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Accounts;

namespace Accounting.Report.Accounts.BalanceSheets
{
    public class BalanceSheetLine
    {
        public enum LineType
        {
            Header,
            Footer,
            Data
        }

        public string Cell1
        {
            get
            {
                if (Account == null) return "";
                string name = Account.AccountName;
                if (Type == LineType.Footer)
                {
                    name = string.Format("Total {0}", name);
                }
                for (int i = 0; i < Account.AccountLevel.Value; ++i)
                {
                    name = "  " + name;
                }
                return name;
            }
        }

        public LineType Type = LineType.Data;

        public string Cell2
        {
            get
            {
                if (Account == null) return "";
                if (Type == LineType.Header) return "";
                if (Type == LineType.Footer) return "";
                return Account.CurrentAccountBalanceDescription;
            }
        }

        public string Cell3
        {
            get
            {
                if (Account == null) return "";
                if (Type == LineType.Header) return "";
                if (Type == LineType.Data) return "";
                return Account.CurrentAccountBalanceDescription;
            }
        }

        public Account Account
        {
            get;
            set;
        }


    }
}
