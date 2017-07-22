using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Accounting.Bll;
using Accounting.Bll.Inventory;

namespace Wao.Inventory
{
    public partial class ItemsList : System.Web.UI.Page
    {
        private BOListItem mModel = new BOListItem(AccountantPool.Instance.CurrentAccountant);


        protected void Page_Load(object sender, EventArgs e)
        {
            //string query = "SELECT Purchases.PurchaseNumber, Purchases.PurchaseID, Purchases.PurchaseDate, Suppliers.IName FROM Purchases, Suppliers WHERE Purchases.CardRecordID=Suppliers.SupplierID";
            dgvItems.DataSource = mModel.ItemDataGridView(true, true, true, null, null);
            dgvItems.DataBind();
        }
    }
}
