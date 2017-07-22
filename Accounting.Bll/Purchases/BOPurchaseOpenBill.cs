
namespace Accounting.Bll.Purchases
{
    using Accounting.Core.Purchases;

    public class BOPurchaseOpenBill : BOPurchase
    {
        public BOPurchaseOpenBill(Accountant accountant, Purchase _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
            mObjectID = BOType.BOPurchaseOpenBill;
            mDataProxy.PurchaseStatus = mAccountant.StatusMgr.Status_Open;
        }
    }
}
