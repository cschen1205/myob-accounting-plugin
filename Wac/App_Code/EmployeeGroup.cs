using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Accounting;
using Accounting.Core.Employees;

/// <summary>
/// Summary description for EmployeeGroup
/// </summary>
public class EmployeeGroup
{
    private List<Employee> mEmployees = null;
    public EmployeeGroup()
    {
        //
        // TODO: Add constructor logic here
        mEmployees = Accountant.EmployeeMgr.RetrieveAll();
        //
    }

    public List<Employee> GetEmployees()
    {
        return mEmployees;
    }
}
