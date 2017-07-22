
namespace Accounting.Bll.Purchases
{
    using Accounting.Core.Purchases;
    public class BOPurchaseDebitReturn : BOPurchase
    {
        public BOPurchaseDebitReturn(Accountant accountant, Purchase _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
            mObjectID = BOType.BOPurchaseDebitReturn;
            mDataProxy.PurchaseStatus = mAccountant.StatusMgr.Status_DebitReturn;
        }
    }
}
