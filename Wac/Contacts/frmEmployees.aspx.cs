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

public partial class frmEmployees : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Employees";
        string query = "SELECT EmployeeID, IName, IsInactive, CardIdentification FROM Employees";
        dgvEmployees.DataSource = Accountant.EmployeeMgr.GetView(query);
        dgvEmployees.DataBind();
    }
}
