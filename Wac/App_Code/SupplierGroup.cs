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
using Accounting.Core.Suppliers;

/// <summary>
/// Summary description for Suppliers
/// </summary>
public class SupplierGroup
{
    List<Supplier> mSuppliers;
    public SupplierGroup()
    {
        //
        // TODO: Add constructor logic here
        mSuppliers = Accountant.SupplierMgr.RetrieveAll();
        //
    }

    public List<Supplier> GetSuppliers()
    {
        return mSuppliers;
    }
}
