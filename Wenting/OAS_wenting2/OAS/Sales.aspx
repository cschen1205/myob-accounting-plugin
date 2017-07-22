<%@ Page Language="C#" MasterPageFile="~/OAS.Master" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="OAS.Sales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/themes/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="js/ui/ui.core.js" type="text/javascript"></script>
    <script src="js/ui/ui.dialog.js" type="text/javascript"></script>
    <script src="js/ui/ui.resizable.js" type="text/javascript"></script>
    <script src="js/ui/ui.draggable.js" type="text/javascript"></script>

    <link href="css/codezone/block.css" rel="stylesheet" type="text/css" />
    <script src="js/codezone/block.js" type="text/javascript"></script>
    <script src="js/codezone/dialog.js" type="text/javascript"></script>
    
    <script type="text/javascript">
    $(document).ready(function(){	
	    $('#btnAccounts').click(function(){
	        $('#dlgAccounts').dialog('open');
	    });
    	
	    $('#btnBudgets').click(function(){
	        $('#dlgBudgets').dialog('open');
	    });
    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<body>
<div id="dlgAccounts" title="Sales register" class="dialog">I'm in a dialog</div>
<div id="dlgBudgets" title="Budgets" class="dialog">I'm in a dialog</div>

<table class="blockgroup">
<tr>
    <td align="center"></td>
    <td align="center">
        <div id="SalesRegister" class="block">
            <div class="blocktitle">Sales Register</div>
            <div class="blockbutton" id="btnQuotes">Quotes</div>
            <div class="blockbutton" id="btnOrders">Orders</div>
            <div class="blockbutton">New sale</div>   
        </div>
    </td>
</tr>
<tr>
    <td align="center"></td>
    <td align="center">
        <div id="EnterSales" class="block">
            <div class="blocktitle">Enter Sales</div>    
        </div>
    </td>
    <td align="center">
        <div id="ReceivePayments" class="block">
            <div class="blocktitle">Receive Payments</div>    
        </div>
    </td>
</tr>
<tr>
    <td align="center">
        <div id="Statements" class="block">
            <div class="blocktitle">Print/Email Statements</div>
        </div>
    </td>
    <td align="center">
        <div id="Invoices" class="block">
            <div class="blocktitle">Print/Email Invoices</div>    
        </div>
    </td>
</tr>
<tr>
    <td align="center"></td>
    <td align="center">
        <div id="TransactionJournal" class="block">
            <div class="blocktitle">Transaction Journal</div>
        </div>
    </td>
    <td align="center">
        <div id="PrintReceipts" class="block">
            <div class="blocktitle">PrintReceipts</div>
        </div>
    </td>
</tr>
</table>
</body>
</asp:Content>