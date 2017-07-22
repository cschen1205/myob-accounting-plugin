using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Sales;
using Accounting.Core.Definitions;

namespace Accounting.Bll.Sales
{
    public class BOSaleFactory
    {
        protected Accountant mAccountant;
        public BOSaleFactory(Accountant acc)
        {
            mAccountant = acc;
        }

        public virtual BOSaleClosedInvoice CreateSaleClosedInvoice()
        {
            Sale _data = mAccountant.SaleMgr.CreateEntity();
            return new BOSaleClosedInvoice(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public virtual BOSaleClosedInvoice OpenSaleClosedInvoice(Sale _sale)
        {
            return new BOSaleClosedInvoice(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public virtual BOSaleOpenInvoice CreateSaleOpenInvoice()
        {
            Sale _data = mAccountant.SaleMgr.CreateEntity();
            return new BOSaleOpenInvoice(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public virtual BOSaleOpenInvoice OpenSaleOpenInvoice(Sale _sale)
        {
            return new BOSaleOpenInvoice(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public virtual BOSaleOrder CreateSaleOrder()
        {
            Sale _data = mAccountant.SaleMgr.CreateEntity();
            return new BOSaleOrder(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public virtual BOSaleOrder OpenSaleOrder(Sale _sale)
        {
            return new BOSaleOrder(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public virtual BOSaleQuote CreateSaleQuote()
        {
            Sale _data = mAccountant.SaleMgr.CreateEntity();
            return new BOSaleQuote(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public virtual BOSaleQuote OpenSaleQuote(Sale _sale)
        {
            return new BOSaleQuote(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public virtual BOSaleCreditReturn CreateSaleCreditReturn()
        {
            Sale _data = mAccountant.SaleMgr.CreateEntity();
            return new BOSaleCreditReturn(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public virtual BOSaleCreditReturn OpenSaleCreditReturn(Sale _sale)
        {
            return new BOSaleCreditReturn(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public virtual BOSaleOrder CreateSaleOrderFromQuote(Sale _quote)
        {
            Sale _order = _quote.Clone() as Sale;
            _order.SaleID = null;
            _order.InvoiceStatus = mAccountant.StatusMgr.FindByStatusType(Status.StatusType.Order);

            return new BOSaleOrder(mAccountant, _order, BusinessObject.BOContext.Record_Update);
        }

        public virtual BOSaleOpenInvoice CreateSaleOpenInvoiceFromQuote(Sale _quote)
        {
            Sale _openInvoice = _quote.Clone() as Sale;
            _openInvoice.SaleID = null;
            _openInvoice.InvoiceStatus = mAccountant.StatusMgr.FindByStatusType(Status.StatusType.Open);

            return new BOSaleOpenInvoice(mAccountant, _openInvoice, BusinessObject.BOContext.Record_Update);
        }

        public virtual BOSaleOpenInvoice CreateSaleOpenInvoiceFromOrder(Sale _order)
        {
            Sale _openInvoice = _order.Clone() as Sale;
            _openInvoice.SaleID = null;
            _openInvoice.InvoiceStatus = mAccountant.StatusMgr.FindByStatusType(Status.StatusType.Open);

            return new BOSaleOpenInvoice(mAccountant, _openInvoice, BusinessObject.BOContext.Record_Update);
        }
    }
}
