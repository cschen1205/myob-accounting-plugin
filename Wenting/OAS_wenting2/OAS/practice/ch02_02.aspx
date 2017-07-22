<%@ Page Language="C#" MasterPageFile="~/OAS.Master" AutoEventWireup="true" CodeBehind="ch02_02.aspx.cs" Inherits="OAS.practice.ch02_02" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
tr
{
	background: #fff;
}
.alt
{
	background: #ccc;
}
.highlight
{
	font-style: italic;
	font-weight: bold;
}
.greenhighlight
{
	font-style: italic;
	font-weight: bold;
	color: Green;
}
</style>

    <script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            $('tr:nth-child(even)').addClass('alt');
            $('tr:contains(Henry)').addClass('highlight');
            $('td:contains(Henry)').next().addClass('greenhighlight');
            });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
  <tr>
  	<td>As You Like It</td>
  	<td>Comedy</td>
  	<td></td>
  </tr>
  <tr>
  	<td>All's Well that Ends Well</td>
  	<td>Comedy</td>
  	<td>1601</td>
  </tr>
  <tr>
  	<td>Hamlet</td>
  	<td>Tragedy</td>
  	<td>1604</td>
  </tr>
  <tr>
  	<td>Macbeth</td>
  	<td>Tragedy</td>
  	<td>1606</td>
  </tr>
  <tr>
  	<td>Romeo and Juliet</td>
  	<td>Tragedy</td>
  	<td>1595</td>
  </tr>
  <tr>
  	<td>Henry IV, Part I</td>
  	<td>History</td>
  	<td>1596</td>
  </tr>
  <tr>
  	<td>Henry V</td>
  	<td>History</td>
  	<td>1599</td>
  </tr>
</table>
</asp:Content>
