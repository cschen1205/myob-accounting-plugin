using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Accounting;
using Accounting.Bll;
using Accounting.Bll.Purchases;

namespace Wao.Purchases
{
    public partial class PurchasesRegister : System.Web.UI.Page
    {
        private BOListPurchase mModel = new BOListPurchase(AccountantPool.Instance.CurrentAccountant);

        

        protected void Page_Load(object sender, EventArgs e)
        {
            
            //string query = "SELECT Purchases.PurchaseNumber, Purchases.PurchaseID, Purchases.PurchaseDate, Suppliers.IName FROM Purchases, Suppliers WHERE Purchases.CardRecordID=Suppliers.SupplierID";
            dgvPurchases.DataSource = mModel.DataGridView(DateTime.Now.AddYears(-6), DateTime.Now, null, null);
            dgvPurchases.DataBind();
        }
    }
}
