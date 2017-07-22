using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Sales;

namespace Accounting.Bll.Sales
{
    using Accounting.Core;
    public class BOSaleCreditReturn : BOSale
    {
        public BOSaleCreditReturn(Accountant accountant, Sale _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
            mObjectID = BOType.BOSaleCreditReturn;
            mDataProxy.InvoiceStatus = mAccountant.StatusMgr.Status_CreditReturn;
        }
    }
}
