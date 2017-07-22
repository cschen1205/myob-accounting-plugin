<%@ Page Language="C#" MasterPageFile="~/OAS.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="OAS.Setup" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function(){
            $('#Setup').css({'color': '#ff0000', 'fontWeight': 'bold'});
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<table>
    <tr><td colspan="2" align="left"><asp:Label ID="lblInstruction" runat="server" Text="This will setup the OAS database"></asp:Label></td></tr>
    <tr>
    <td align="left">Username:</td>
    <td align="left"><asp:TextBox ID="txtUsername" runat="server" Text="admin"></asp:TextBox></td>
    </tr>
    <tr>
    <td align="left">Password:</td>
    <td align="left"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
    </tr>
    <tr>
    <td align="left">Host:</td>
    <td align="left"><asp:TextBox ID="txtHost" runat="server" Text="NANYANG-DB77830\SQLEXPRESS"></asp:TextBox></td>
    </tr>
    <tr>
    <td align="left">Database:</td>
    <td align="left"><asp:TextBox ID="txtDatabase" runat="server" Text="CZOASDB"></asp:TextBox></td>
    </tr>
    <tr>
    <td align="left"><asp:CheckBox ID="chkLocalHost" runat="server" Text="Is localhost" Checked="true" /></td>
    </tr>
    <tr>
    <td colspan="2" align="left"><asp:Button ID="btnSetup" runat="server" Text="Setup" 
            onclick="btnSetup_Click" />
    <cc1:ConfirmButtonExtender ID="cbeSetup" runat="server" TargetControlID="btnSetup" ConfirmText="This will erase any existing data in the database, do you want to proceed">
    </cc1:ConfirmButtonExtender>
    </td>
    </tr>
    <tr><td colspan="2" align="left"><asp:Label ID="lblInfo" runat="server" Text="Please enter the admin password to initialize the setup"></asp:Label></td></tr>
</table>
</asp:Content>
