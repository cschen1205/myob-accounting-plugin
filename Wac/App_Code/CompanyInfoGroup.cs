using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Accounting;
using Accounting.Core.Company;
using System.Collections.Generic;

/// <summary>
/// Summary description for CompanyInfoGroup
/// </summary>
public class CompanyInfoGroup
{
    private List<CompanyInfo> mCompanyInfos=new List<CompanyInfo>();
    public CompanyInfoGroup()
    {
        //
        // TODO: Add constructor logic here
        mCompanyInfos.Add(Accountant.CompanyInfoMgr.Retrieve());
        //
    }

    public List<CompanyInfo> GetCompanyInfos()
    {
        return mCompanyInfos;
    }


}
