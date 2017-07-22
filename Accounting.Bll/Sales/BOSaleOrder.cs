using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Bll.Sales
{
    using Accounting.Core;
    using Accounting.Core.Sales;
    using Accounting.Core.Inventory;
    public class BOSaleOrder : BOSale
    {
        public BOSaleOrder(Accountant accountant, Sale _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
            mObjectID = BOType.BOSaleOrder;
            mDataProxy.InvoiceStatus = mAccountant.StatusMgr.Status_Order;
        }

        public double TotalPaid
        {
            get
            {
                return mDataProxy.TotalPaid;
            }
            set
            {
                mDataProxy.TotalPaid = value;
            }
        }
    }
}
