using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Im.Sales
{
    using Accounting.Core;
    using Accounting.Core.Sales;

    public class BOSaleQuote : Accounting.Bll.Sales.BOSaleQuote
    {
        public BOSaleQuote(Accountant accountant, Sale _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
            
        }
    }
}
