<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmCompanyInfo.aspx.cs" Inherits="Admin_frmCompanyInfo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadRegion" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftRegion" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CommandRegion" Runat="Server">
 <a href="frmPrintCompanyInfo.aspx">Print</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyRegion" Runat="Server">
    <table><tr><td valign="top">
    <asp:Label ID="lblCompanyName" runat="server" Text="Name:"></asp:Label>
    </td><td valign="top">
    <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
    </td></tr>
     <tr><td valign="top">
        <asp:Label ID="lblRegistrationNumber" runat="server" Text="Registration No.:"></asp:Label>
    </td><td valign="top">
        <asp:TextBox ID="txtRegistrationNumber" runat="server"></asp:TextBox>
    </td></tr>
    <tr><td valign="top">
    <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
    </td><td valign="top">
    <asp:TextBox ID="txtAddress" runat="server" Height="51px" Width="283px" TextMode="MultiLine"></asp:TextBox>
    </td></tr>
    <tr><td valign="top">
        <asp:Label ID="lblCity" runat="server" Text="City:"></asp:Label>
    </td><td valign="top">
        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
    </td></tr>
     <tr><td valign="top">
        <asp:Label ID="lblProvince" runat="server" Text="Province:"></asp:Label>
    </td><td valign="top">
        <asp:TextBox ID="txtProvince" runat="server"></asp:TextBox>
    </td></tr>
     <tr><td valign="top">
        <asp:Label ID="lblCountry" runat="server" Text="Country:"></asp:Label>
    </td><td valign="top">
        <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
    </td></tr>
      <tr><td valign="top">
        <asp:Label ID="lblPostalCode" runat="server" Text="Postal Code:"></asp:Label>
    </td><td valign="top">
        <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
    </td></tr>
     <tr><td valign="top">
        <asp:Label ID="lblPhone1" runat="server" Text="Phone1:"></asp:Label>
    </td><td valign="top">
        <asp:TextBox ID="txtPhone1" runat="server"></asp:TextBox>
    </td></tr>
     <tr><td valign="top">
        <asp:Label ID="lblPhone2" runat="server" Text="Phone2:"></asp:Label>
    </td><td valign="top">
        <asp:TextBox ID="txtPhone2" runat="server"></asp:TextBox>
    </td></tr>
     <tr><td valign="top">
        <asp:Label ID="lblFax" runat="server" Text="Fax:"></asp:Label>
    </td><td valign="top">
        <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
    </td></tr>
     <tr><td valign="top">
        <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
    </td><td valign="top">
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    </td></tr>
     <tr><td valign="top">
        <asp:Label ID="lblWebSite" runat="server" Text="Web Site:"></asp:Label>
    </td><td valign="top">
        <asp:TextBox ID="txtWebSite" runat="server"></asp:TextBox>
    </td></tr>
    <tr><td valign="top" colspan="2">
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"/>
    </td></tr>
        
    </table>    
    <asp:HiddenField ID="CompanyId" runat="server" />
</asp:Content>

