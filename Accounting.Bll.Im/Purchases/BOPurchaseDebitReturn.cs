
namespace Accounting.Bll.Im.Purchases
{
    using Accounting.Core.Purchases;

    public class BOPurchaseDebitReturn : Accounting.Bll.Purchases.BOPurchaseDebitReturn
    {
        public BOPurchaseDebitReturn(Accountant accountant, Purchase _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
            
        }
    }
}
