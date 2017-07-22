
namespace Accounting.Bll.Im.Purchases
{
    using Accounting.Core.Purchases;

    public class BOPurchaseOpenBill : Accounting.Bll.Purchases.BOPurchaseOpenBill
    {
        public BOPurchaseOpenBill(Accountant accountant, Purchase _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
            
        }
    }
}
