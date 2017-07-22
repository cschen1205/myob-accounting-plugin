using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Core.Purchases;
using Accounting.Core.Definitions;

namespace Accounting.Bll.Purchases
{
    public class BOPurchaseFactory
    {
        protected Accountant mAccountant = null;
        public BOPurchaseFactory(Accountant acc)
        {
            mAccountant = acc;
        }

        public virtual BOPurchaseClosedBill CreatePurchaseClosedBill()
        {
            Purchase _data = mAccountant.PurchaseMgr.CreateEntity();
            return new BOPurchaseClosedBill(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public virtual BOPurchaseClosedBill OpenPurchaseClosedBill(Purchase _sale)
        {
            return new BOPurchaseClosedBill(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public virtual BOPurchaseOpenBill CreatePurchaseOpenBill()
        {
            Purchase _data = mAccountant.PurchaseMgr.CreateEntity();
            return new BOPurchaseOpenBill(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public virtual BOPurchaseOpenBill OpenPurchaseOpenBill(Purchase _sale)
        {
            return new BOPurchaseOpenBill(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public virtual BOPurchaseOrder CreatePurchaseOrder()
        {
            Purchase _data = mAccountant.PurchaseMgr.CreateEntity();
            return new BOPurchaseOrder(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public virtual BOPurchaseOrder OpenPurchaseOrder(Purchase _sale)
        {
            return new BOPurchaseOrder(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public virtual BOPurchaseQuote CreatePurchaseQuote()
        {
            Purchase _data = mAccountant.PurchaseMgr.CreateEntity();
            return new BOPurchaseQuote(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public virtual BOPurchaseQuote OpenPurchaseQuote(Purchase _sale)
        {
            return new BOPurchaseQuote(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public virtual BOPurchaseDebitReturn CreatePurchaseDebitReturn()
        {
            Purchase _data = mAccountant.PurchaseMgr.CreateEntity();
            return new BOPurchaseDebitReturn(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public virtual BOPurchaseDebitReturn OpenPurchaseDebitReturn(Purchase _sale)
        {
            return new BOPurchaseDebitReturn(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public virtual BOPurchaseOrder CreatePurchaseOrderFromQuote(Purchase _quote)
        {
            Purchase _order = _quote.Clone() as Purchase;
            _order.PurchaseID = null;
            _order.PurchaseStatus = mAccountant.StatusMgr.FindByStatusType(Status.StatusType.Order);

            return new BOPurchaseOrder(mAccountant, _order, BusinessObject.BOContext.Record_Update);
        }

        public virtual BOPurchaseOpenBill CreatePurchaseOpenBillFromQuote(Purchase _quote)
        {
            Purchase _openBill = _quote.Clone() as Purchase;
            _openBill.PurchaseID = null;
            _openBill.PurchaseStatus = mAccountant.StatusMgr.FindByStatusType(Status.StatusType.Open);

            return new BOPurchaseOpenBill(mAccountant, _openBill, BusinessObject.BOContext.Record_Update);
        }

        public virtual BOPurchaseOpenBill CreatePurchaseOpenBillFromOrder(Purchase _order)
        {
            Purchase _openBill = _order.Clone() as Purchase;
            _openBill.PurchaseID = null;
            _openBill.PurchaseStatus = mAccountant.StatusMgr.FindByStatusType(Status.StatusType.Open);

            return new BOPurchaseOpenBill(mAccountant, _openBill, BusinessObject.BOContext.Record_Update);
        }
    }
}

