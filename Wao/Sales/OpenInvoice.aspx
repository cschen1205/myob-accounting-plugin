<%@ Page Title="" Language="C#" MasterPageFile="~/WaoDefault.Master" AutoEventWireup="true" CodeBehind="OpenInvoice.aspx.cs" Inherits="Wao.Sales.OpenInvoice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="apptitle" runat="server">
    <asp:Label ID="lblAppTitle" runat="server" Text="Sales - OpenInvoice"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</asp:ToolkitScriptManager>

    <asp:TabContainer ID="TabContainer1" runat="server">
    <asp:TabPanel HeaderText="Sale Invoice" runat="server">

    <ContentTemplate>
        <asp:UpdatePanel ID="updatePanel1" runat="server">
            <ContentTemplate>
                <table>
                <tr><td>
                 <asp:Panel ID="PanelMainDetails" runat="server" GroupingText="Main Details">
                <table>
                    <tr>
                        <td>
                            Sale By:
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="cboSalesperson" runat="server" Width="100%">
                            </asp:DropDownList>
                        </td>  
                    </tr>
                    <tr>
                        <td>
                            Date:</td>
                        <td>
                            <asp:TextBox ID="txtDate" runat="server" />
                            <asp:CalendarExtender ID="CalendarExtenderDate"
                                TargetControlID="txtDate" 
                                Format="dd/MM/yyyy" 
                                runat="server">
                            </asp:CalendarExtender>
                        </td>
                        <td>
                            Promised Date:</td>
                        <td>
                            <asp:TextBox ID="txtPromisedDate" runat="server" />
                            <asp:CalendarExtender ID="CalendarExtenderPromisedDate"
                                TargetControlID="txtPromisedDate" 
                                Format="dd/MM/yyyy" 
                                runat="server">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Memo:</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtMemo" runat="server" Width="100%" />
                            
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                </td>
                <td>
                   <asp:Panel ID="PanelOtherDetails" runat="server" GroupingText="Other Details">
                        <table>
                        
                        <tr>
                            <td>
                                Comment:
                            </td>
                            <td>
                                <asp:DropDownList ID="cboComment" runat="server" Width="100%">
                                </asp:DropDownList>
                            </td>  
                        </tr>
                        <tr>
                            <td>
                                Terms:
                            </td>
                            <td>
                                <asp:DropDownList ID="cboTerms" runat="server" Width="100%">
                                </asp:DropDownList>
                            </td>  
                        </tr>
                        <tr>
                            <td>
                                Referral Source:
                            </td>
                            <td>
                                <asp:DropDownList ID="cboReferralSource" runat="server" Width="100%">
                                </asp:DropDownList>
                            </td>  
                        </tr>
                        </table>
                    </asp:Panel>
                </td>
                </tr>
                <tr>
                <td>
                    <asp:Panel ID="PanelCustomer" runat="server" GroupingText="Customer">
                    
                        <table width="100%">
                        <tr>
                             <td>Customer:
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList ID="cboCustomer" runat="server" Width="100%" OnSelectedIndexChanged="cboCustomer_OnSelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>  
                        </tr>
                        <tr>
 
                            <td>Phone1:</td>
                            <td>
                                
                                         <asp:TextBox ID="txtPhone1" runat="server" Width="100%" />
                                   
                            
                            </td>
                            <td>City:</td>
                            <td><asp:TextBox ID="txtCity" runat="server" Width="100%" /></td>
                        </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td>
                </td>
                </tr>
                </table>
                <asp:Button ID="Button3" runat="Server" Text="Save"  />
                <br /><br />
                Hit Save to cause a postback from an update panel inside the tab panel.<br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </ContentTemplate>
    
    </asp:TabPanel>
    
    <asp:TabPanel ID="TabPanelLines" HeaderText="Sale Lines" runat="server">

    <ContentTemplate>
        <asp:UpdatePanel ID="updatePanel2" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            Signature:</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>
                            Bio:</td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" /></td>
                    </tr>
                </table>
                <asp:Button ID="Button1" runat="Server" Text="Save"  />
                <br /><br />
                Hit Save to cause a postback from an update panel inside the tab panel.<br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </ContentTemplate>
    
    </asp:TabPanel>
    </asp:TabContainer>

</asp:Content>
