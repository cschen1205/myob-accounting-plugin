<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmPrintEmployees.aspx.cs" Inherits="Contacts_frmPrintEmployees" Title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadRegion" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommandRegion" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyRegion" Runat="Server">
    <rsweb:reportviewer ID="rpvEmployees" runat="server" Height="338px" Width="100%">
        <LocalReport ReportPath="Contacts\rptEmployees.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="Accounting_Core_Employee_Employee" />
            </DataSources>
        </LocalReport>
    </rsweb:reportviewer>
    
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="EmployeeGroup" SelectMethod="GetEmployees">
    </asp:ObjectDataSource>
    
</asp:Content>

