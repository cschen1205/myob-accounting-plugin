using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Accounting;

public partial class frmSales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Sales";
        string query = "SELECT Sales.InvoiceNumber, Sales.SaleID, Sales.InvoiceDate, Customers.IName FROM Sales, Customers WHERE Sales.CardRecordID=Customers.CustomerID"; 
        dgvSales.DataSource = Accountant.SaleMgr.GetView(query);
        dgvSales.DataBind();
    }
}
