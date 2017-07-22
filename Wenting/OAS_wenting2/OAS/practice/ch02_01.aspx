<%@ Page Language="C#" MasterPageFile="~/OAS.Master" AutoEventWireup="true" CodeBehind="ch02_01.aspx.cs" Inherits="OAS.practice.ch02_01" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.horizontal
{
	float: left;
	list-style: none;
	margin: 10px;
}
.sublevel
{
	background: #ccc;
}
a.mailto
{
	background: url(../images/email.png) no-repeat right top;
	padding-right: 18px;
}
a.pdflink
{
	background: url(../images/pdf.png) no-repeat right top;
	padding-right: 18px;
}
a.henrylink
{
	background: #fff;
	border: 1px #000;
	padding: 2px;
}
a.external {
  background: #fff url(../images/external.png) no-repeat 100% 2px;
  padding-right: 16px;
}
</style>

    <script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
    <script type="text/javascript">
    $(document).ready(function() {
        $('#selected-plays > li').addClass('horizontal');
        $('#selected-plays li:not(.horizontal)').addClass('sublevel');
        $('a[href^=mailto:]').addClass('mailto');
        $('a[href$=.pdf]').addClass('pdflink');
        $('a[href^=http:][href*=henry]').addClass('henrylink');
        $('a').filter(function() {
            return this.hostname && this.hostname != location.hostname;
            }).addClass('external');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<ul id="selected-plays" class="clear-after">
  <li>Comedies
    <ul>
    	<li><a href="/asyoulikeit/">As You Like It</a></li>
    	<li>All's Well That Ends Well</li>
    	<li>A Midsummer Night's Dream</li>
    	<li>Twelfth Night</li>
    </ul>
  </li>
  <li>Tragedies
    <ul>
    	<li><a href="hamlet.pdf">Hamlet</a></li>
    	<li>Macbeth</li>
    	<li>Romeo and Juliet</li>
    </ul>
  </li>
  <li>Histories
    <ul>
    	<li>Henry IV (<a href="mailto:henryiv@king.co.uk">email</a>)
        <ul>
          <li>Part I</li>
          <li>Part II</li>
			  </ul>
			</li>  
			<li><a href="http://www.shakespeare.co.uk/henryv.htm">Henry V</a></li>
			<li>Richard II</li>
    </ul>
  </li>
</ul>
</asp:Content>
