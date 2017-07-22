
namespace Accounting.Bll.Im.Purchases
{
    using Accounting.Core.Purchases;

    public class BOPurchaseClosedBill : Accounting.Bll.Purchases.BOPurchaseClosedBill
    {
        public BOPurchaseClosedBill(Accountant accountant, Purchase _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
            
        }
    }
}
