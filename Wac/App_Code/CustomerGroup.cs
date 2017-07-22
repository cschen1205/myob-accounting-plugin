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
using Accounting.Core.Customers;

/// <summary>
/// Summary description for CustomerGroup
/// </summary>
public class CustomerGroup
{
    private List<Customer> mCustomers = null;
    public CustomerGroup()
    {
        //
        // TODO: Add constructor logic here
        mCustomers = Accountant.CustomerMgr.RetrieveAll();
        //
    }

    public List<Customer> GetCustomers()
    {
        return mCustomers;
    }
}
