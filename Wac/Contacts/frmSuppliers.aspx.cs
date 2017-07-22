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

public partial class frmSuppliers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Suppliers";
        string query = "SELECT SupplierID, IName, IsInactive, CardIdentification FROM Suppliers";
        dgvSuppliers.DataSource = Accountant.SupplierMgr.GetView(query);
        dgvSuppliers.DataBind();
    }
}
