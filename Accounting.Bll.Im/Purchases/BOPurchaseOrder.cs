
namespace Accounting.Bll.Im.Purchases
{
    using Accounting.Core.Purchases;

    public class BOPurchaseOrder : Accounting.Bll.Purchases.BOPurchaseOrder
    {
        public BOPurchaseOrder(Accountant accountant, Purchase _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
            
        }
    }
}
