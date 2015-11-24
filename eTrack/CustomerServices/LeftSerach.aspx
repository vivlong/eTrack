<%@ Page Language="VB" AutoEventWireup="true" CodeFile="LeftSerach.aspx.vb" Inherits="LeftSerach"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/Tracking.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/Calendar.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/Print.js" -->
    <!-- #include file="../JavaScript/Query.js" -->
    <!--#include file="JavaScript/LeftSearch.js" -->

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"> </script>    
        <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
        <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>    
    <style type="text/css">
    .AspNetPagerCss {height:22px; width:22px; vertical-align:bottom; border:0px}
    </style>
</head>
<body>
    <form id="frmAirSeaQuery" runat="server">
        <div id="divForm">
            <div id="divTitle">
                <asp:Label ID="lblTitle" CssClass="Title" runat="server" Text="<%$ Resources:lblTitle.Text %>"></asp:Label>
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
            <div id="divSearch" style="display: none">
                <div class="divline">
                    <asp:DropDownList ID="drpSearch" runat="server" CssClass="" />
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="TextBox" />
                    <asp:HiddenField ID="fldCustomerCode" runat="server" />
                    <asp:HiddenField ID="fldLoginType" runat="server" />
                </div>
                <div class="divline">
                    <div class="fLeft">
                        <asp:DropDownList ID="drpFrom" runat="server" CssClass="" />
                        <asp:Label ID="lblFrom" runat="server" Text="From"></asp:Label>
                        <asp:TextBox ID="txtFrom" runat="server" CssClass="TextBox" />
                        <asp:Button ID="btnFrom" runat="server" CssClass="Button" Text="..." Width="20px"
                            UseSubmitBehavior="False" />
                        <asp:Label ID="lblTo" runat="server" Text="To"></asp:Label>
                        <asp:TextBox ID="txtTo" runat="server" CssClass="TextBox" />
                        <asp:Button ID="btnTo" runat="server" CssClass="Button" Text="..." Width="20px" UseSubmitBehavior="False" />
                    </div>
                    <div class="fRight">
                        <asp:Button ID="btnSearch" runat="server" CssClass="Button" Text="Search" UseSubmitBehavior="false" />
                    </div>
                </div>
            </div>
            <div id="divSource" style="height: 620px;">
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
                <div class="fRight">
                    <asp:Button ID="btnPrint" runat="server" CssClass="Button" Text="Print" UseSubmitBehavior="False" />
                    <asp:Button ID="btnToExcel" runat="server" CssClass="Button" Text="Export Excel"
                        Width="77px" UseSubmitBehavior="False" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
