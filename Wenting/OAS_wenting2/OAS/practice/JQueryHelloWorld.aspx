<%@ Page Language="C#" MasterPageFile="~/OAS.Master" AutoEventWireup="true" CodeBehind="JQueryHelloWorld.aspx.cs" Inherits="OAS.practice.JQueryHelloWorld" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
    <style type="text/css">
        div { 
        background-color:#D5EDEF; 
        color:#4f6b72;
        width:50px; 
        border: 1px solid #C1DAD7; 
 
      }
 </style>
 <script type="text/javascript">
     $(document).ready(function() {
         $("#btnAnimate").click(function() {
             $("#<%=Panel1.ClientID %>").animate(
            {
                width: "350px",
                opacity: 0.5,
                fontSize: "16px"
            }, 1800);
         });
     });
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
        <input id="btnAnimate" type="button" value="Animate" />
        <asp:Panel ID="Panel1" runat="server">
        Some sample text in this panel        
        </asp:Panel>
</asp:Content>
