<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmCustomers.aspx.cs" Inherits="frmCustomers" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadRegion" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyRegion" Runat="Server">
   
    
<asp:GridView ID="dgvCustomers" AutoGenerateColumns="False" SkinID="GridView" runat="server">
    <Columns>
            <asp:BoundField DataField="CardIdentification" HeaderText="Customer ID" ReadOnly="True" SortExpression="CardIdentification" />
            <asp:BoundField DataField="IName" HeaderText="Name" ReadOnly="True" SortExpression="IName" />
            <asp:BoundField DataField="IsInactive" HeaderText="Inactive" ReadOnly="True" SortExpression="IsInactive" />
            
            <asp:HyperlinkField 
                    Text="Edit" 
                    ShowHeader="false" 
                    DataNavigateUrlFields="CustomerID"
                    DataNavigateUrlFormatString="frmCustomer.aspx?supplierid={0}&action=edit" /> 
            <asp:HyperlinkField 
                    Text="Delete" 
                    ShowHeader="false" 
                    DataNavigateUrlFields="CustomerID"
                    DataNavigateUrlFormatString="frmCustomer.aspx?supplierid={0}&action=del" /> 
          
     </Columns>
</asp:GridView>    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CommandRegion" Runat="Server">
 <a href="frmPrintCustomers.aspx">Print</a>
        
        <asp:Button ID="Button2" runat="server" Text="Button" />
 
</asp:Content>

