<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Inventory2.aspx.vb" Inherits="Inventory2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/Inventory.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/Calendar.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/Print.js" -->
    <!-- #include file="../JavaScript/Query.js" -->
    <!-- #include file="../JavaScript/CheckForm.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->
    <!--#include file="JavaScript/Inventory2.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"> </script>    
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>

</head>
<body onload="(11,-20)">
    <form id="frmAirSeaQuery" runat="server">
    <div id="divTitle">
        <asp:Label ID="lblTitle" CssClass="Title" runat="server" Text="<%$ Resources:lblTitle.Text %>"></asp:Label>
    </div>
    <div id="MsgBox" style="left: 26%; top: 171px">
        <div class="bar">
            <asp:Label ID="lblLoadTitleHint" runat="server" Text="<%$ Resources:Message, LoadTitleHint %>"></asp:Label>
        </div>
        <div class="content">
            <img alt="" src="../images/load.gif" style="text-align: center; vertical-align: middle" />&nbsp;
            &nbsp;<asp:Label ID="lblMessage" runat="server" Text="<%$ Resources:Message, LoadDataHint %>"></asp:Label>
        </div>
    </div>
    <div id="divMiddle1">
        <div id="divSource" style="height: 450px">
            <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvwSource_RowDataBound"
                EnableViewState="False">
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
                <asp:Label ID="lblPabe" runat="server" Text="Page" />
                <asp:TextBox ID="txtPage" runat="server" CssClass="txInput"></asp:TextBox>
                <asp:LinkButton ID="lbtnGoTo" runat="server" Text="Go"></asp:LinkButton>
                <asp:LinkButton ID="lbtnNext" runat="server" Text="Next"></asp:LinkButton>
                <asp:LinkButton ID="lbtnLast" runat="server" Text="Last"></asp:LinkButton>
            </div>
        </div>
        <div id="hid_div">
            <asp:HiddenField ID="hid_val" runat="server" Value="1" />
        </div>
    </form>
</body>
</html>
