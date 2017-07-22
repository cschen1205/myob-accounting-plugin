
namespace Accounting.Bll.Im.Purchases
{
    using Accounting.Core.Purchases;

    public class BOPurchaseQuote : Accounting.Bll.Purchases.BOPurchaseQuote
    {
        public BOPurchaseQuote(Accountant accountant, Purchase _obj, BOContext _state)
            : base(accountant, _obj, _state)
        {
            
        }
    }
}
