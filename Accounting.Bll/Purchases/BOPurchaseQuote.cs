
namespace Accounting.Bll.Purchases
{
    using Accounting.Core.Purchases;
    public class BOPurchaseQuote : BOPurchase
    {
        public BOPurchaseQuote(Accountant accountant, Purchase _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
            mObjectID = BOType.BOPurchaseQuote;
            mDataProxy.PurchaseStatus = mAccountant.StatusMgr.Status_Quote;
        }
    }
}
