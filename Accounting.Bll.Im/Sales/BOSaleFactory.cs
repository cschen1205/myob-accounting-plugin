using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Sales;
using Accounting.Core.Definitions;

namespace Accounting.Bll.Im.Sales
{
    public class BOSaleFactory : Accounting.Bll.Sales.BOSaleFactory
    {
        public BOSaleFactory(Accountant acc)
            : base(acc)
        {
        }

        public override Accounting.Bll.Sales.BOSaleClosedInvoice CreateSaleClosedInvoice()
        {
            Sale _data = mAccountant.SaleMgr.CreateEntity();
            return new BOSaleClosedInvoice(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public override Accounting.Bll.Sales.BOSaleClosedInvoice OpenSaleClosedInvoice(Sale _sale)
        {
            return new BOSaleClosedInvoice(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public override Accounting.Bll.Sales.BOSaleOpenInvoice CreateSaleOpenInvoice()
        {
            Sale _data = mAccountant.SaleMgr.CreateEntity();
            return new BOSaleOpenInvoice(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public override Accounting.Bll.Sales.BOSaleOpenInvoice OpenSaleOpenInvoice(Sale _sale)
        {
            return new BOSaleOpenInvoice(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public override Accounting.Bll.Sales.BOSaleOrder CreateSaleOrder()
        {
            Sale _data = mAccountant.SaleMgr.CreateEntity();
            return new BOSaleOrder(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public override Accounting.Bll.Sales.BOSaleOrder OpenSaleOrder(Sale _sale)
        {
            return new BOSaleOrder(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public override Accounting.Bll.Sales.BOSaleQuote CreateSaleQuote()
        {
            Sale _data = mAccountant.SaleMgr.CreateEntity();
            return new BOSaleQuote(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public override Accounting.Bll.Sales.BOSaleQuote OpenSaleQuote(Sale _sale)
        {
            return new BOSaleQuote(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public override Accounting.Bll.Sales.BOSaleCreditReturn CreateSaleCreditReturn()
        {
            Sale _data = mAccountant.SaleMgr.CreateEntity();
            return new BOSaleCreditReturn(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public override Accounting.Bll.Sales.BOSaleCreditReturn OpenSaleCreditReturn(Sale _sale)
        {
            return new BOSaleCreditReturn(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public override Accounting.Bll.Sales.BOSaleOrder CreateSaleOrderFromQuote(Sale _quote)
        {
            Sale _order = _quote.Clone() as Sale;
            _order.SaleID = null;
            _order.InvoiceStatus = mAccountant.StatusMgr.FindByStatusType(Status.StatusType.Order);

            return new BOSaleOrder(mAccountant, _order, BusinessObject.BOContext.Record_Create);
        }

        public override Accounting.Bll.Sales.BOSaleOpenInvoice CreateSaleOpenInvoiceFromQuote(Sale _quote)
        {
            Sale _openInvoice = _quote.Clone() as Sale;
            _openInvoice.SaleID = null;
            _openInvoice.InvoiceStatus = mAccountant.StatusMgr.FindByStatusType(Status.StatusType.Open);

            return new BOSaleOpenInvoice(mAccountant, _openInvoice, BusinessObject.BOContext.Record_Create);
        }

        public override Accounting.Bll.Sales.BOSaleOpenInvoice CreateSaleOpenInvoiceFromOrder(Sale _order)
        {
            Sale _openInvoice = _order.Clone() as Sale;
            _openInvoice.SaleID = null;
            _openInvoice.InvoiceStatus = mAccountant.StatusMgr.FindByStatusType(Status.StatusType.Open);

            return new BOSaleOpenInvoice(mAccountant, _openInvoice, BusinessObject.BOContext.Record_Create);
        }

        
    }
}
