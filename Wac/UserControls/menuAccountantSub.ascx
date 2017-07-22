<%@ Control Language="C#" ClassName="menuAccountantSub" %>
<%@ Implements Interface="System.Web.UI.WebControls.WebParts.IWebPart" %>
<%@ Import Namespace="System.Collections.Generic" %>


<script runat="server">
    private string _catalogiconimageurl;
    private string _description;
    private string _subtitle;
    private string _title;
    private string _titleiconimageurl;
    private string _titleurl;

    string IWebPart.CatalogIconImageUrl
    {
        get { return _catalogiconimageurl; }
        set { _catalogiconimageurl = value; }
    }
    string IWebPart.Description
    {
        get { return _description; }
        set { _description = value; }
    }
    string IWebPart.Subtitle
    {
        get { return _subtitle; }
    }
    string IWebPart.Title
    {
        get { return _title; }
        set { _title = value; }
    }
    string IWebPart.TitleIconImageUrl
    {
        get { return _titleiconimageurl; }
        set { _titleiconimageurl = value; }
    }

    string IWebPart.TitleUrl
    {
        get { return _titleurl; }
        set { _titleurl = value; }
    }

    private void Page_Load(object sender, System.EventArgs e)
    {
        _title = "  " + this.Page.Title;
        _description = "";
        _titleiconimageurl = "~/images/menuicon.jpg";

        StringBuilder sb=new StringBuilder(); 
        Dictionary<string, string> links=new Dictionary<string,string>();
        if (this.Page.Title == "Contacts")
        {
            links["frmSuppliers.aspx"] = "Suppliers";
            links["frmCustomers.aspx"] = "Customers";
            links["frmEmployees.aspx"] = "Employees"; 
        }
        else if (this.Page.Title == "Administration")
        {
            links["frmCompanyInfo.aspx"] = "Company Info";
            links["frmCalendar.aspx"] = "Calendar";
            links["frmGadgets.aspx"] = "Gadgets";  
        }
        else if (this.Page.Title == "Sales")
        {
            links["frmSales.aspx"] = "Invoice";
        }
        else if (this.Page.Title == "Purchases")
        {
            links["frmPurchases.aspx"] = "Purchase Order";
        }
        else if (this.Page.Title == "Suppliers")
        {
            links["frmPrintSuppliers.aspx"] = "Print Suppliers";
        }
        else if (this.Page.Title == "Customers")
        {
            links["frmPrintCustomers.aspx"] = "Print Customers";
        }
        else if (this.Page.Title == "Employees")
        {
            links["frmPrintEmployees.aspx"] = "Print Employees";
        }   

        if (links.Count == 0)
        {
            if(this.Page.Title=="Home")
            {
            }
            else if (this.Page.Title == "Calendar")
            {
                sb.Append("<iframe frameborder=0 marginwidth=0 marginheight=0 border=0 style=\"border:0;margin:0;width:300px;height:300px;\" src=\"http://www.google.com/calendar/embed?mode=AGENDA&showTitle=0&showTabs=0&showPrint=0&showCalendars=0&wkst=1&element=true&src=usa__en%40holiday.calendar.google.com\" scrolling=\"no\" allowtransparency=\"true\"></iframe>");
            }
            else if (this.Page.Title == "Company Info")
            {
                sb.Append("<img src=\"../Images/company_logo.png\" border=\"0\" />");
            }
            else
            {
                Random rad = new Random();
                double r = rad.NextDouble();
                if (r < 0.3)
                {
                    string city_code = "SG";
                    string city_name = "Singapore Time";
                    sb.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
                    sb.Append("<tr><td align=\"center\">");
                    sb.AppendFormat("<embed src=\"http://www.worldtimeserver.com/clocks/wtsclock001.swf?color=FF9900&wtsid={0}\" width=\"200\" height=\"200\" wmode=\"transparent\" type=\"application/x-shockwave-flash\" />", city_code);
                    sb.AppendFormat("</td></tr><tr><td align=\"center\"><h2>{0}</h2>", city_name);
                    sb.Append("</td></tr></table>");
                }
                else if (r < 0.6)
                {
                    sb.Append("<iframe frameborder=0 marginwidth=0 marginheight=0 border=0 style=\"border:0;margin:0;width:300px;height:300px;\" src=\"http://www.google.com/calendar/embed?mode=AGENDA&showTitle=0&showTabs=0&showPrint=0&showCalendars=0&wkst=1&element=true&src=usa__en%40holiday.calendar.google.com\" scrolling=\"no\" allowtransparency=\"true\"></iframe>");
                }
                else
                {
                    //<!-- Google News Element Code -->
                    sb.Append("<iframe frameborder=0 marginwidth=0 marginheight=0 border=0 style=\"border:0;margin:0;width:300px;height:250px;\" src=\"http://www.google.com/uds/modules/elements/newsshow/iframe.html?rsz=large&format=300x250&ned=en_sg&topic=b&q=Accounting&element=true\" scrolling=\"no\" allowtransparency=\"true\"></iframe>");
                    //sb.Append("<iframe frameborder=0 marginwidth=0 marginheight=0 border=0 style=\"border:0;margin:0;width:200px;height:250px;\" src=\"http://www.google.com/uds/modules/elements/newsshow/iframe.html?rsz=large&format=300x250&topic=b&q=Accounting&element=true\" scrolling=\"no\" allowtransparency=\"true\"></iframe>");
                }
            } 
             
        }
        else
        {   
            sb.Append("<ul class=\"menutextindent\" runat=\"server\">");

            foreach (string link in links.Keys)
            {
                sb.AppendFormat("<li><a href=\"{0}\">{1}</a></li>", link, links[link]);
            }
            sb.Append("</ul>");
        }
             

        _ucAccountantSubList.InnerHtml = sb.ToString();
       
        
    }
    

</script>

<div id="_ucAccountantSubList" runat="server">    
</div>