using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Im.Sales
{
    using Accounting.Core;
    using Accounting.Core.Sales;
    using Accounting.Core.Inventory;

    public class BOSaleOrder : Accounting.Bll.Sales.BOSaleOrder
    {
        public BOSaleOrder(Accountant accountant, Sale _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
           
        }        
    }
}
