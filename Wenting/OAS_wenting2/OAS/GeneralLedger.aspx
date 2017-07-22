<%@ Page Language="C#" MasterPageFile="~/OAS.Master" AutoEventWireup="true" CodeBehind="GeneralLedger.aspx.cs" Inherits="OAS.GeneralLedger" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/themes/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />
    <link href="css/codezone/block.css" rel="stylesheet" type="text/css" />    
    <script src="js/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
     <script src="js/codezone/block.js" type="text/javascript"></script>
    
    <script type="text/javascript">
    $(document).ready(function(){
        $('#GeneralLedger').css({'color': '#ff0000', 'fontWeight': 'bold'});		    
        $('#AccountsView').load('AccountsList.aspx');
        $('#RecordJournalEntryView').load('RecordJournalEntry.aspx');
    });
    </script>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table class="blockgroup">
<tr>
<td align="center"></td>
<td>
<div id="AccountsList" class="block">
<div class="blocktitle" id="AccountsListTitle">Accounts List</div>
<div class="blockcontents" id="AccountsView">
</div>

</div>
</td align="center">
</tr>
<tr>
<td align="center">
<div id="TransferMoney" class="block">
<div class="blocktitle">Transfer Money</div>
</div>
</td>
<td align="center">
<div id="RecordJournalEntry" class="block">
<div class="blocktitle">Record Journal Entry</div>
<div class="blockcontents" id="RecordJournalEntryView"></div>
</div>
</td>
<td align="center">
<div id="CompanyDataAuditor" class="block">
<div class="blocktitle">Company Data Auditor</div>
</div>
</td align="center">
</tr>
<td align="center"></td>
<td align="center">
<div id="TransactionJournal" class="block">
<div class="blocktitle">Transaction Journal</div>
</div>
</td>
<td align="center"></td>
<tr>
</tr>
</table>
</asp:Content>
