<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountsList.aspx.cs" Inherits="OAS.AccountsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <script src="js/jquery-1.3.2.min.js" type="text/javascript"></script>
    <link href="css/themes/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
   <style type="text/css">
     #tabAccountsList
    {
    	margin:0px;
    	padding:0px;
    }
     .button
    {
	    position:relative;
	    border-top: 2px solid #888;
        border-left: 2px solid #888;
        border-bottom: 2px solid #444;
        border-right: 2px solid #444;
        padding-left: 10px;
        padding-right: 10px;
        padding-bottom: 5px;
        padding-top: 5px;
    }

    .buttonhover
    {
	    cursor:pointer;
	    background: #afa;
    }
   </style>
</head>
<body>
        <div id="dlgBudget" class="dialog" title="Budget">Budget Details</div>
        <div id="dlgNewAccount" class="dialog" title="New Account">Create a new account</div>
        
        
        <div id="tabAccountsList">
        <ul>
        <li><a href="#divAllAccounts"><span>All Accounts</span></a></li>
        <li><a href="#divAssets"><span>Assets</span></a></li>
        </ul>
        <div id="divAllAccounts">test</div>
        <div id="divAssets">test2</div>
        </div>       
        <table>
        <tr>
        <td id="btnBudget" class="button">Budgets</td>
        <td id="btnNewAccount" class="button">New</td>
        </tr>
        </table>
        
        
        <script type="text/javascript">
        $('#tabAccountsList').tabs();
                
            $('.dialog').dialog({
                autoOpen: false,
                width: 600,
                buttons: {
                    "Ok": function() { 
	                    $(this).dialog("close"); 
                    }, 
                    "Cancel": function() { 
	                    $(this).dialog("close"); 
                    } 
                }
            });
            
            $('.button').hover(function(){
                $(this).addClass('buttonhover');
                }, function(){
                $(this).removeClass('buttonhover');
                }
            );
            
            $('#btnBudget').bind("click", function(){
                $('#dlgBudget').dialog('open');
            });
            
            $('#btnNewAccount').bind("click", function(){
                $('#dlgNewAccount').dialog('open');
            });
        </script>
        
        
</body>
</html>
