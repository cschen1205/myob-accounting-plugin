using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Sales
{
    using Accounting.Core;
    using Accounting.Core.Sales;
    using Accounting.Core.Inventory;

    public class BOSaleOpenInvoice : BOSale
    {
        public BOSaleOpenInvoice(Accountant accountant, Sale _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
            mObjectID = BOType.BOSaleOpenInvoice;
            mDataProxy.InvoiceStatus = mAccountant.StatusMgr.Status_Open; 
        }
    }
}
