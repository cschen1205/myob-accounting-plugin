using Accounting.Core.Definitions;
using Accounting.Core.Purchases;

namespace Accounting.Bll.Im.Purchases
{
    public class BOPurchaseFactory : Accounting.Bll.Purchases.BOPurchaseFactory
    {
        public BOPurchaseFactory(Accountant acc)
            : base(acc)
        {
        }

        public override Accounting.Bll.Purchases.BOPurchaseClosedBill CreatePurchaseClosedBill()
        {
            Purchase _data = mAccountant.PurchaseMgr.CreateEntity();
            return new BOPurchaseClosedBill(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public override Accounting.Bll.Purchases.BOPurchaseClosedBill OpenPurchaseClosedBill(Purchase _sale)
        {
            return new BOPurchaseClosedBill(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public override Accounting.Bll.Purchases.BOPurchaseOpenBill CreatePurchaseOpenBill()
        {
            Purchase _data = mAccountant.PurchaseMgr.CreateEntity();
            return new BOPurchaseOpenBill(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public override Accounting.Bll.Purchases.BOPurchaseOpenBill OpenPurchaseOpenBill(Purchase _sale)
        {
            return new BOPurchaseOpenBill(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public override Accounting.Bll.Purchases.BOPurchaseOrder CreatePurchaseOrder()
        {
            Purchase _data = mAccountant.PurchaseMgr.CreateEntity();
            return new BOPurchaseOrder(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public override Accounting.Bll.Purchases.BOPurchaseOrder OpenPurchaseOrder(Purchase _sale)
        {
            return new BOPurchaseOrder(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public override Accounting.Bll.Purchases.BOPurchaseQuote CreatePurchaseQuote()
        {
            Purchase _data = mAccountant.PurchaseMgr.CreateEntity();
            return new BOPurchaseQuote(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public override Accounting.Bll.Purchases.BOPurchaseQuote OpenPurchaseQuote(Purchase _sale)
        {
            return new BOPurchaseQuote(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public override Accounting.Bll.Purchases.BOPurchaseDebitReturn CreatePurchaseDebitReturn()
        {
            Purchase _data = mAccountant.PurchaseMgr.CreateEntity();
            return new BOPurchaseDebitReturn(mAccountant, _data, BusinessObject.BOContext.Record_Create);
        }

        public override Accounting.Bll.Purchases.BOPurchaseDebitReturn OpenPurchaseDebitReturn(Purchase _sale)
        {
            return new BOPurchaseDebitReturn(mAccountant, _sale, BusinessObject.BOContext.Record_Update);
        }

        public override Accounting.Bll.Purchases.BOPurchaseOrder CreatePurchaseOrderFromQuote(Purchase _quote)
        {
            Purchase _order = _quote.Clone() as Purchase;
            _order.PurchaseID = null;
            _order.PurchaseStatus = mAccountant.StatusMgr.FindByStatusType(Status.StatusType.Order);

            return new BOPurchaseOrder(mAccountant, _order, BusinessObject.BOContext.Record_Create);
        }

        public override Accounting.Bll.Purchases.BOPurchaseOpenBill CreatePurchaseOpenBillFromQuote(Purchase _quote)
        {
            Purchase _openBill = _quote.Clone() as Purchase;
            _openBill.PurchaseID = null;
            _openBill.PurchaseStatus = mAccountant.StatusMgr.FindByStatusType(Status.StatusType.Open);

            return new BOPurchaseOpenBill(mAccountant, _openBill, BusinessObject.BOContext.Record_Create);
        }

        public override Accounting.Bll.Purchases.BOPurchaseOpenBill CreatePurchaseOpenBillFromOrder(Purchase _order)
        {
            Purchase _openBill = _order.Clone() as Purchase;
            _openBill.PurchaseID = null;
            _openBill.PurchaseStatus = mAccountant.StatusMgr.FindByStatusType(Status.StatusType.Open);

            return new BOPurchaseOpenBill(mAccountant, _openBill, BusinessObject.BOContext.Record_Create);
        }
    }
}
