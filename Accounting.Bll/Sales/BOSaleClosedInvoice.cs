using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Sales
{
    using Accounting.Core;
    using Accounting.Core.Sales;
    public class BOSaleClosedInvoice : BOSale
    {
        public BOSaleClosedInvoice(Accountant accountant, Sale _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
            mObjectID = BOType.BOSaleClosedInvoice;
            mDataProxy.InvoiceStatus = mAccountant.StatusMgr.Status_Closed;
        }   
    }
}
