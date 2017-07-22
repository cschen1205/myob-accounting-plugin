using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Im.Sales
{
    using Accounting.Core;
    using Accounting.Core.Sales;

    public class BOSaleClosedInvoice : Accounting.Bll.Sales.BOSaleClosedInvoice
    {
        public BOSaleClosedInvoice(Accountant accountant, Sale _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
            
        }
    }
}
