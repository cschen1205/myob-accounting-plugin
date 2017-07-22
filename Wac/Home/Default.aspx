<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Home_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadRegion" Runat="Server">
      
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftRegion" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyRegion" Runat="Server">
<table width="100%" height="380px" style="background-image:url(../Images/home_bg.jpg);background-repeat:no-repeat;">
<tr>
<td valign="top">
<asp:Login ID="Login1" runat="server" SkinID="LoginView">
    </asp:Login>
</td>
<td>

</td>
</tr>

</table>

    
</asp:Content>



