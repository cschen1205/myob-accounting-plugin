<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmSales.aspx.cs" Inherits="frmSales" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadRegion" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyRegion" Runat="Server">
   
    
<asp:GridView ID="dgvSales"  runat="server" AutoGenerateColumns="false" SkinID="GridView">
    <Columns>
            <asp:BoundField DataField="InvoiceNumber" HeaderText="Invoice Number" ReadOnly="True" SortExpression="InvoiceNumber" />
            <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date" ReadOnly="True" SortExpression="InvoiceDate" />
            <asp:BoundField DataField="IName" HeaderText="Customer" ReadOnly="True" SortExpression="IName" />
            
            <asp:HyperlinkField 
                    Text="Edit" 
                    ShowHeader="false" 
                    DataNavigateUrlFields="SaleID"
                    DataNavigateUrlFormatString="frmSale.aspx?saleid={0}&action=edit" /> 
            <asp:HyperlinkField 
                    Text="Delete" 
                    ShowHeader="false" 
                    DataNavigateUrlFields="SaleID"
                    DataNavigateUrlFormatString="frmSale.aspx?saleid={0}&action=del" /> 
          
     </Columns>
</asp:GridView>    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CommandRegion" Runat="Server">
 <a href="frmPrintSales.aspx">Print</a>
        
        <asp:Button ID="Button2" runat="server" Text="Button" />
 
</asp:Content>

