<%@ Page Language="VB" AutoEventWireup="true" CodeFile="CPC.aspx.vb" Inherits="CPC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/CPC.css" rel="Stylesheet" type="text/css" />
    <link href="../UserControl/datepicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <!--#include file="../JavaScript/JsConst.js"-->
    <!--#include file="../JavaScript/Query.js" -->
    <!--#include file="../JavaScript/Print.js" -->
    <!--#include file="JavaScript/CPC.js" -->
    <!-- #include file="../JavaScript/DateOperate.js" -->
    <!--#include file="../JavaScript/ResetSize.js" -->

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

    <script language="javascript" type="text/javascript" src="../UserControl/datepicker/WdatePicker.js"></script>

</head>
<body onload="ResetSize(12,0)">
    <form id="frmCPC" runat="server">
    <div id="MsgBox">
        <div class="bar">
            <asp:Label ID="lblLoadTitleHint" runat="server" Text="<%$ Resources:Message, LoadTitleHint %>"></asp:Label>
        </div>
        <div class="content">
            <img alt="" src="../images/load.gif" style="text-align: center; vertical-align: middle" />&nbsp;
            &nbsp;<asp:Label ID="lblMessage" runat="server" Text="<%$ Resources:Message, LoadDataHint %>"></asp:Label>
        </div>
    </div>
    <div id="divForm">
        <div id="divTopNav">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="lblQueryTitle" CssClass="f12e navNml navOn" runat="server" Text="<%$ Resources:lblQueryTitle %>"></asp:Label></li>
            </ul>
        </div>
        <div id="divMiddle" class="divBorder">
            <div class="divline">
                <asp:Label ID="lblAsOfDate" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblAsOfDate%>"></asp:Label>
                <asp:TextBox ID="txtAsOfDate" runat="server" CssClass="TextBox lblDate" />
                <asp:Button ID="btnAsOfDate" runat="server" CssClass="Button bntDate" Text="..."
                    UseSubmitBehavior="False" />
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
                <asp:Label ID="lblResultTitle" runat="server" CssClass="Title1" Text="<%$ Resources:lblResultTitle %>"></asp:Label>
            </div>
        </div>
        <div id="divSource">
            <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvwSource_RowDataBound"
                OnRowCreated="gvwSource_RowCreated" EnableViewState="False" ShowFooter="True">
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
                <asp:Button ID="btnPrint" runat="server" CssClass="Button" Text="<%$ Resources:PageList, Print %>"
                    UseSubmitBehavior="False" />
                <asp:Button ID="btnToExcel" runat="server" CssClass="Button" Text="Export Excel"
                    Width="77px" UseSubmitBehavior="False" />
                <asp:Button ID="btnReturn" runat="server" CssClass="Button" Text="Back" UseSubmitBehavior="False" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
