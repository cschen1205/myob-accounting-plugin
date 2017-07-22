<%@ Control Language="C#" ClassName="menuAccountant" %>
<%@ Implements Interface="System.Web.UI.WebControls.WebParts.IWebPart" %>

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
        _title = "  Accountant";
        _description = "";
        _titleiconimageurl = "~/images/menuicon.jpg";
    }
    

</script>

<ul class="menutextindent">
    <li><a href="../Admin/Default.aspx">Administration</a></li>
    <li><a href="../Sales/Default.aspx">Sales</a></li>
    <li><a href="../Purchases/Default.aspx">Purchases</a></li>
    <li><a href="../Inventory/Default.aspx">Inventory</a></li>
    <li><a href="../Report/Default.aspx">Report</a></li>
    <li><a href="../Contacts/Default.aspx">Contacts</a></li>
</ul>



