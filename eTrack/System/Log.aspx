<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Log.aspx.vb" Inherits="Log"
    Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/Calendar.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/Log.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <!--#include file="../JavaScript/JsConst.js"-->
    <!--#include file="../JavaScript/Common.js"-->
    <!--#include file="../JavaScript/Calendar.js"-->
    <!--#include file="../JavaScript/Query.js" -->
    <!--#include file="../JavaScript/Print.js" -->
    <!--#include file="JavaScript/LogQuery.js" -->

    <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>

</head>
<body>
    <form id="frmLogQuery" runat="server">
    <div id="divForm">
        <div id="divTopNav">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="lblQueryTitle" CssClass="f12e navNml navOn" runat="server" Text="<%$ Resources:lblQueryTitle.Text %>"></asp:Label></li>
            </ul>
        </div>
        <div id="MsgBox">
            <div class="bar">
                <asp:Label ID="lblLoadTitleHint" runat="server" Text="<%$ Resources:Message, LoadTitleHint %>"></asp:Label>
            </div>
            <div class="content">
                <img alt="" src="../images/load.gif" style="text-align: center; vertical-align: middle" />&nbsp;
                &nbsp;<asp:Label ID="lblMessage" runat="server" Text="<%$ Resources:Message, LoadDataHint %>"></asp:Label>
            </div>
        </div>
        <div id="divMiddle" class="divBorder">
            <div class="divline">
                <asp:CheckBox ID="chkDate" runat="server" Text="<%$ Resources:chkDate.Text %>" CssClass="CheckBox" />
                <asp:TextBox ID="txtQDate" runat="server" CssClass="TextBox"></asp:TextBox>
                <asp:Button ID="btnQDate" runat="server" CssClass="Button" Text="..." UseSubmitBehavior="False" />
                <asp:Label ID="lblTo" runat="server" CssClass="Label" Text="<%$ Resources:lblTo.Text %>"></asp:Label>
                <asp:TextBox ID="txtZDate" runat="server" CssClass="TextBox"></asp:TextBox>
                <asp:Button ID="btnZDate" runat="server" CssClass="Button" Text="..." UseSubmitBehavior="False" />
            </div>
            <div class="divline">
                <asp:CheckBox ID="chkUser" runat="server" Text="<%$ Resources:chkUser.Text %>" CssClass="CheckBox" />
                <asp:TextBox ID="txtUser" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
            <div class="divline">
                <asp:CheckBox ID="chkRemark" runat="server" Text="<%$ Resources:chkRemark.Text %>"
                    CssClass="CheckBox" />
                <asp:TextBox ID="txtRemark" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
        </div>
        <div id="divBottomNav">
            <asp:Button ID="btnOk" runat="server" CssClass="Button" Text="<%$ Resources:btnOk.Text %>"
                UseSubmitBehavior="false" />
        </div>
    </div>
    <div id="divResult" runat="server">
        <div id="ResultTitle">
            <div class="secondleft">
                <asp:Label ID="lblResultTitle" runat="server" CssClass="Title1" Text="<%$ Resources:lblResultTitle.Text %>"></asp:Label>
            </div>
        </div>
        <div id="divSource" style="height: 550px;">
            <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvwSource_RowDataBound"
                EnableViewState="False" ShowFooter="True">
                <HeaderStyle CssClass="Header" />
                <FooterStyle CssClass="Footer" />
                <RowStyle CssClass="Row" />
                <SelectedRowStyle CssClass="SelectRow" />
                <PagerStyle CssClass="Pager" />
                <AlternatingRowStyle CssClass="Alternating" />
            </asp:GridView>
        </div>
        <div id="divPage">
            <div class="fLeft">
                <asp:Label ID="lblPage" runat="server" Text="Page"></asp:Label>
                <asp:LinkButton ID="lbtnFirst" runat="server" Text="First"></asp:LinkButton>
                <asp:LinkButton ID="lbtnPrior" runat="server" Text="Prior"></asp:LinkButton>
                <asp:LinkButton ID="lbtnNext" runat="server" Text="Next"></asp:LinkButton>
                <asp:LinkButton ID="lbtnLast" runat="server" Text="Last"></asp:LinkButton>
                <asp:LinkButton ID="lbtnGoTo" runat="server" Text="Go to"></asp:LinkButton>
                <asp:TextBox ID="txtPage" runat="server" CssClass="txInput"></asp:TextBox>
            </div>
            <div class="fRight">
                <asp:Button ID="btnPrint" runat="server" CssClass="Button" Text="Print" UseSubmitBehavior="False" />
                <asp:Button ID="btnToExcel" runat="server" CssClass="Button" Text="Export Excel"
                    Width="77px" UseSubmitBehavior="False" />
                <asp:Button ID="btnReturn" runat="server" CssClass="Button" Text="Back" UseSubmitBehavior="False" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
<script type="text/javascript" language="javascript">
    function nocontextmenu(){ 
     event.cancelBubble = true 
     event.returnValue = false; 
     return false; 
    } 
    function nodblClick(){ 
     event.cancelBubble = true 
     event.returnValue = false; 
     return false; 
    } 
    function norightclick(e){ 
     if (window.Event){ 
      //if (e.which == 2 || e.which == 3) 
      return false; 
     } 
     else 
      if (event.button == 2 || event.button == 3){ 
       event.cancelBubble = true 
       event.returnValue = false; 
       return false; 
      } 
    } 
    document.oncontextmenu = nocontextmenu; // for IE5+ 
    //document.onmousedown = norightclick; 
    document.onclick = HideMenu;
    document.ondblclick = nodblClick;
</script>

