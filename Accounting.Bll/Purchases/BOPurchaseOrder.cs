
namespace Accounting.Bll.Purchases
{
    using Accounting.Core.Purchases;
    public class BOPurchaseOrder : BOPurchase
    {

        public BOPurchaseOrder(Accountant accountant, Purchase _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
            mObjectID = BOType.BOPurchaseOrder;
            mDataProxy.PurchaseStatus = mAccountant.StatusMgr.Status_Order;
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
