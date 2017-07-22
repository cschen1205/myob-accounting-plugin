<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmPurchases.aspx.cs" Inherits="frmPurchases" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadRegion" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyRegion" Runat="Server">
   
    
<asp:GridView ID="dgvPurchases"  runat="server" AutoGenerateColumns="false" SkinID="GridView">
    <Columns>
            <asp:BoundField DataField="PurchaseNumber" HeaderText="Purchase Number" ReadOnly="True" SortExpression="PurchaseNumber" />
            <asp:BoundField DataField="PurchaseDate" HeaderText="Purchase Date" ReadOnly="True" SortExpression="PurchaseDate" />
            <asp:BoundField DataField="IName" HeaderText="Supplier" ReadOnly="True" SortExpression="IName" />
            
            <asp:HyperlinkField 
                    Text="Edit" 
                    ShowHeader="false" 
                    DataNavigateUrlFields="PurchaseID"
                    DataNavigateUrlFormatString="frmPurchase.aspx?saleid={0}&action=edit" /> 
            <asp:HyperlinkField 
                    Text="Delete" 
                    ShowHeader="false" 
                    DataNavigateUrlFields="PurchaseID"
                    DataNavigateUrlFormatString="frmPurchase.aspx?saleid={0}&action=del" /> 
          
     </Columns>
</asp:GridView>    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CommandRegion" Runat="Server">
 <a href="frmPrintPurchases.aspx">Print</a>
        
        <asp:Button ID="Button2" runat="server" Text="Button" />
 
</asp:Content>

