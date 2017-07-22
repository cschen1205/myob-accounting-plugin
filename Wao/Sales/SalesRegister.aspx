<%@ Page Title="" Language="C#" MasterPageFile="~/WaoDefault.Master" AutoEventWireup="true" CodeBehind="SalesRegister.aspx.cs" Inherits="Wao.Sales.SalesRegister" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content3" ContentPlaceHolderID="apptitle" runat="server">
Sales - Sales Register
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</asp:ToolkitScriptManager>

<asp:Label ID="lblStartDate" runat="server" Text="From Date: "></asp:Label>
<asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>

<asp:CalendarExtender 
    ID="CalendarExtenderStartDate" 
    TargetControlID="txtStartDate" 
    
    runat="server" Format="dd/MM/yyyy" />

<asp:Label ID="lblEndDate" runat="server" Text="To Date: "></asp:Label>
<asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>

<asp:CalendarExtender 
    ID="CalendarExtenderEndDate" 
    TargetControlID="txtEndDate" 
    runat="server" />
    
<asp:DropDownList ID="cboPageSize" runat="server">
<asp:ListItem Value="10" Text="Show  10 Records" Selected="False" />
<asp:ListItem Value="20" Text="Show  20 Records" Selected="True" />
<asp:ListItem Value="50" Text="Show  50 Records" Selected="False" />
<asp:ListItem Value="100" Text="Show 100 Records" Selected="False" />
</asp:DropDownList>

<br />
<asp:CheckBox ID="chkCard" runat="server" Text="Find Only Customer:" />
<asp:DropDownList ID="cboCard" runat="server"></asp:DropDownList>


<asp:CheckBox ID="chkStatus" runat="server" Text="Find Only Status:" />
<asp:DropDownList ID="cboStatus" runat="server"></asp:DropDownList>

<br />

<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_OnClicked" />
    
<asp:UpdatePanel ID="udpGridView" runat="server">
<ContentTemplate>
<asp:GridView 
DataKeyNames="ID"
 PageSize="20"
 AllowPaging="true"
 AllowSorting="true"
 HeaderStyle-BackColor="ActiveCaption"
 AlternatingRowStyle-BackColor="AliceBlue"
    OnPageIndexChanging="gridView_PageIndexChanging" 
    OnSorting="gridView_Sorting"
    AutoGenerateColumns="False" 
       OnRowCommand="GridView1_RowCommand" 
       OnRowDataBound="GridView1_RowDataBound" 
       OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting"
    ID="gridView"  
    runat="server" 
    Width="100%">
   
   
    <Columns>
   <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
   <asp:BoundField DataField="Invoice #" HeaderText="Invoice #" SortExpression="Invoice #" />
   <asp:BoundField DataField="Customer" HeaderText="Customer" SortExpression="Customer" />
   <asp:BoundField DataField="Invoice Date" HeaderText="Invoice Date" SortExpression="Invoice Date" />
   <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
   <asp:BoundField DataField="Amt Due" HeaderText="Amt Due" SortExpression="Amt Due" />
   <asp:TemplateField HeaderText="Select">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" 
         CommandArgument='<%# Eval("ID") %>' 
         CommandName="Delete" runat="server">
         Delete</asp:LinkButton>
         
         <asp:LinkButton ID="LinkButton2" 
         CommandArgument='<%# Eval("ID") %>' 
         CommandName="Details" runat="server">
         View</asp:LinkButton>
     </ItemTemplate>
   </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Sale Status">
     <ItemTemplate>
         <asp:Label ID="lblSaleStatus" runat="server" Text=""></asp:Label>
     </ItemTemplate>
   </asp:TemplateField>
  </Columns>
  
</asp:GridView>  

</ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
</Triggers>
</asp:UpdatePanel>  
             
 <asp:UpdatePanelAnimationExtender ID="UpdatePanelAnimationExtender1" runat="server" TargetControlID="udpGridView">
    <Animations>
        <OnUpdating>
            <Parallel Duration="0">
                <EnableAction AnimationTarget="btnSearch" Enabled="false" />
                <FadeOut MinimumOpacity=".5" />
            </Parallel>
        </OnUpdating>
        <OnUpdated>
            <Parallel Duration="0">
                <FadeIn MinimumOpacity=".5" />
                <EnableAction AnimationTarget="btnSearch" Enabled="true" />
            </Parallel>                    
        </OnUpdated>
    </Animations>                
</asp:UpdatePanelAnimationExtender>

</asp:Content>

