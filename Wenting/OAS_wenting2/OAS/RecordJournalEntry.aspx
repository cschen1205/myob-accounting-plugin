<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecordJournalEntry.aspx.cs" Inherits="OAS.RecordJournalEntry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <script src="js/jquery-1.3.2.min.js" type="text/javascript"></script>
    <link href="css/themes/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
   <style type="text/css">
     #tabRecordJournalEntry
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
        <div id="dlgBudget" class="dialog" title="Dialog1">Dialog1 Details</div>
        <div id="dlgNewAccount" class="dialog" title="Dialog2">Dialog2 Details</div>
        
        
        <div id="tabRecordJournalEntry">
        <ul>
        <li><a href="#divRJE1"><span>Tab 1</span></a></li>
        <li><a href="#divRJE2"><span>Tab 2</span></a></li>
        </ul>
        <div id="divRJE1">Tab 1 Contents</div>
        <div id="divRJE2">Tab 2 Contents</div>
        </div>       
        <table>
        <tr>
        <td id="button1" class="button">Button 1</td>
        <td id="button2" class="button">Button 2</td>
        </tr>
        </table>
        
        
        <script type="text/javascript">
        $('#tabRecordJournalEntry').tabs();
                
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
            
            $('#button1').bind("click", function(){
                $('#dlgBudget').dialog('open');
            });
            
            $('#button2').bind("click", function(){
                $('#dlgNewAccount').dialog('open');
            });
        </script>
        
        
</body>
</html>
