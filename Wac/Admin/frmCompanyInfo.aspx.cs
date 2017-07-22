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
using Accounting.Core.Company;

public partial class Admin_frmCompanyInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Title = "Company Info";
            CompanyInfo company = Accountant.CompanyInfoMgr.Retrieve();
            this.txtCompanyName.Text = company.CompanyName;
            this.txtAddress.Text = company.Address;
            txtRegistrationNumber.Text = company.RegistrationNumber;
            txtCity.Text = company.City;
            txtProvince.Text = company.Province;
            txtCountry.Text = company.Country;
            txtPhone1.Text = company.Phone1;
            txtPhone2.Text = company.Phone2;
            txtFax.Text = company.Fax;
            txtEmail.Text = company.Email;
            txtWebSite.Text = company.WebSite;
            txtPostalCode.Text = company.PostCode;
            CompanyId.Value = Convert.ToString(company.ID);
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int id = int.Parse(CompanyId.Value);
        CompanyInfo company = new CompanyInfo();
        company.ID = id;
        company.CompanyName= this.txtCompanyName.Text;
        company.Address= this.txtAddress.Text;
        company.RegistrationNumber= txtRegistrationNumber.Text;
        company.City= txtCity.Text;
        company.Province= txtProvince.Text;
        company.Country= txtCountry.Text;
        company.Phone1= txtPhone1.Text;
        company.Phone2= txtPhone2.Text;
        company.Fax= txtFax.Text;
        company.Email= txtEmail.Text;
        company.WebSite= txtWebSite.Text;
        company.PostCode= txtPostalCode.Text;
        Accountant.CompanyInfoMgr.Store(company);
        Response.Redirect("frmPrintCompanyInfo.aspx");
    }
}
