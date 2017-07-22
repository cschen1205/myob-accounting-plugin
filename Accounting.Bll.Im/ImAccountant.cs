using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Db;
using Accounting.Db.Im;
using Accounting.Core.Sales;

namespace Accounting.Bll.Im
{
    public class ImAccountant : Accountant
    {
        public ImAccountant(string _name)
            : base(_name)
        {
        }

        protected override Accounting.Bll.Purchases.BOPurchaseFactory CreatePurchaseFactory()
        {
            return new Accounting.Bll.Im.Purchases.BOPurchaseFactory(this);
        }

        protected override Accounting.Bll.Sales.BOSaleFactory CreateSaleFactory()
        {
            return new Accounting.Bll.Im.Sales.BOSaleFactory(this);
        }
    }
}