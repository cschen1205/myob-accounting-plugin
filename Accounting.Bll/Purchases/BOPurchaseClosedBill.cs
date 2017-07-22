
namespace Accounting.Bll.Purchases
{
    using Accounting.Core.Purchases;
    public class BOPurchaseClosedBill : BOPurchase
    {
        public BOPurchaseClosedBill(Accountant accountant, Purchase _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
            mObjectID = BOType.BOPurchaseClosedBill;
            mDataProxy.PurchaseStatus = mAccountant.StatusMgr.Status_Closed;
        }
    }
}
