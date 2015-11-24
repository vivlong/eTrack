﻿<%@ Page Language="VB" AutoEventWireup="true" CodeFile="BillofLading.aspx.vb" Inherits="BillofLading" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/js_lzw.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->
    <!--#include file="JavaScript/BillofLading.js" -->
    <!--#include file="../JavaScript/Print.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Reference.js"></script>
    <script language="javascript" type="text/javascript">
        function GetQuery() {
            //by lzw
            var strWhereBook = "";
            var strQuery = document.getElementById("txtSearch").value;
            var objSearchField="";
            if (divdrpSearch1.style.display == "" || divdrpSearch1.style.display == "block")
            {
                objSearchField = document.getElementById("drpSearch1");
                document.getElementById('hidVal_BillofLading').value = "1";
            }
            else {
                objSearchField = document.getElementById("drpSearch2");
                document.getElementById('hidVal_BillofLading').value = "2";
            }
            if (objSearchField) {
                var arrFieldName = objSearchField.options[objSearchField.selectedIndex].value.split(",");
                if (arrFieldName[0] == "") {
                    strWhere = strWhere + strWhereBook;
                    return;
                }
              
                if (arrFieldName[1] == "0") {
                    if (strQuery == " ") {
                        strWhere = " and (" + arrFieldName[0] + " is null or " + arrFieldName[0] + "='') ";

                    }
                    else { strWhere = "  and " + arrFieldName[0] + " like '%" + strQuery + "%' "; }
                }
                else {
                    if (strQuery == " ") {
                        strWhere = "  and (" + arrFieldName[0] + " is null or " + arrFieldName[0] + "='') ";
                    }
                    else { strWhere = "  and Cast(" + arrFieldName[0] + " as NVarChar(50))" + " like '%" + strQuery + "%' "; }
                }
            }
            strWhere = strWhere + strWhereBook;
        }
        function PrintDetail(intId, Reports) {
            var strUrl = "";
            var strReport = document.getElementById("hidReports").value;
            var arrReport = strReport.split(",");
            if (Reports == "") { alert("There are Not Reports in the Server."); return false; }
            if (arrReport.length != 0) {
                var strUrl = "../loading.aspx?tourl=CustomerServices/SelectReportEdit.aspx?type=2&id=" + intId;
                var ret = WindowDialog(strUrl, 400, 300);
                if (ret != null) { }
            }
        }
        function PrintDetail2(intId, Reports) {
            var strUrl = "";
            var strReport = document.getElementById("hidReports2").value;
            var arrReport = strReport.split(",");
            if (Reports == "") { alert("There are Not Reports in the Server."); return false; }
            if (arrReport.length != 0) {
                var strUrl = "../loading.aspx?tourl=CustomerServices/SelectReportEdit.aspx?type=3&id=" + intId;
                var ret = WindowDialog(strUrl, 400, 300);
                if (ret != null) { }
            }
        }
        function AdvGetQuery() { }
    </script>
</head>
<body onload="DivAutoSize(120);" onresize="DivAutoSize(120);">
    <form id="frmBillofLading" runat="server">
    <div id="divTopNav" runat="server">
        <ul id="ulTopNav">
            <li>
                <asp:Label ID="a1" CssClass="f12e navNml navOn" runat="server" Width="115px" onclick="javascript:SelectedDivl(1,2);GetQueryData(1);"
                    Text="Export"></asp:Label></li>
            <li>
                <asp:Label ID="a2" CssClass="f12c navNml noSep" runat="server" Width="115px" onclick="javascript:SelectedDivl(2,2);GetQueryData(2);"
                    Text="Import"></asp:Label></li>
        </ul>
    </div>
    <div id="popupMenu" class="skin" runat="server" onclick="ClickItem(event)" onmousemove="HighlighItem(event)"
        onmouseout="LowlightItem(event)">
    </div>
    <div id="MsgBox">
        <div class="bar">
            <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:Message, LoadTitleHint %>"></asp:Label>
        </div>
        <div class="content">
            <img alt="" src="../images/load.gif" style="text-align: center; vertical-align: middle" />&nbsp;
            &nbsp;<asp:Label ID="lblMessage" runat="server" Text="<%$ Resources:Message, LoadDataHint %>"></asp:Label>
        </div>
    </div>
    <div id="divSearch" class="divSearch">
        <div class="searchICO fLeft">
        </div>
        <div id="divdrpSearch1" style="display: block;" runat="server">
            <asp:DropDownList ID="drpSearch1" runat="server" CssClass="fLeft" />
        </div>
        <div id="divdrpSearch2" style="display: none;" runat="server">
            <asp:DropDownList ID="drpSearch2" runat="server" CssClass="fLeft" />
        </div>
        <asp:TextBox ID="txtSearch" runat="server" CssClass="txInput txtSearch" />
        <asp:Button ID="btnSearch" runat="server" CssClass="btnFnt" Width="60px" Text="Search"
            UseSubmitBehavior="false" />
        <asp:Button ID="btnAdvSearch" runat="server" CssClass="btnFnt" Width="60px" Text="Advance"
            UseSubmitBehavior="false" />
        <input id="btn" type="button" class="Button btnFnt" value="Custom" onclick="GridColumnSet()"
            style="cursor: hand; width: 60px" />
    </div>
    <div id="divSource">
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
            <asp:Button ID="btnToExcel" runat="server" CssClass="Button" Text="<%$ Resources:lblExcel.Text %>"
                Width="77px" UseSubmitBehavior="False" />
        </div>
    </div>
    <asp:HiddenField ID="hidVal_BillofLading" runat="server" Value="1" />
      <asp:HiddenField ID="hidReports" runat="server" />
        <asp:HiddenField ID="hidReports2" runat="server" />
    </form>
</body>
</html>
<script type="text/javascript" language="javascript">
    function nocontextmenu() {
        event.cancelBubble = true
        event.returnValue = false;
        return false;
    }
    function nodblClick() {
        event.cancelBubble = true
        event.returnValue = false;
        return false;
    }
    function norightclick(e) {
        if (window.Event) {
            //if (e.which == 2 || e.which == 3) 
            return false;
        }
        else
            if (event.button == 2 || event.button == 3) {
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
