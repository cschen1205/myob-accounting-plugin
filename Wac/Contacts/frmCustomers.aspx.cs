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

public partial class frmCustomers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Customers";
        string query = "SELECT CustomerID, IName, IsInactive, CardIdentification FROM Customers";
        dgvCustomers.DataSource = Accountant.CustomerMgr.GetView(query);
        dgvCustomers.DataBind();
    }
}
