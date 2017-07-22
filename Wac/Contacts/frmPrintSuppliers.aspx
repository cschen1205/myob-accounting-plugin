<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmPrintSuppliers.aspx.cs" Inherits="Contacts_frmPrintSuppliers" Title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadRegion" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommandRegion" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyRegion" Runat="Server">
    <rsweb:reportviewer ID="rpvSuppliers" runat="server" Height="338px" Width="100%" Font-Names="Verdana" Font-Size="8pt">
        <LocalReport ReportPath="Contacts\rptSuppliers.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="Accounting_Core_Supplier_Supplier" />
            </DataSources>
        </LocalReport>
    </rsweb:reportviewer>
    
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="SupplierGroup" SelectMethod="GetSuppliers">
    </asp:ObjectDataSource>
    
</asp:Content>

