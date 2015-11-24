<%@ Page Language="VB" AutoEventWireup="true" CodeFile="RoleInfo.aspx.vb" Inherits="RoleInfo"
    Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/BaseList.js" -->
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->
    <!-- #include file="JavaScript/RoleInfo.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script type="text/javascript" language="javascript">
//        function GetQuery() {
//            //by lzw
//            var strQuery = document.getElementById("txtSearch").value;

//            if (strQuery != "") { strWhere = " and (sRoleNo='" + strQuery + "' or sRoleName='" + strQuery + "') "; }
//            else { strWhere = ""; }
//        }
    </script>
</head>
<body onload="DivAutoSize(90);" onresize="DivAutoSize(90);">
    <form id="frmRoleInfo" runat="server">
    <div>
        <div id="popupMenu" class="skin" runat="server" onclick="ClickItem(event)" onmousemove="HighlighItem(event)"
            onmouseout="LowlightItem(event)">
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
        <div id="divSearch" class="divSearch">
            <div class="searchICO fLeft">
            </div>
            <asp:DropDownList ID="drpSearch" runat="server" CssClass="fLeft" />            
            <asp:TextBox ID="txtSearch" runat="server" CssClass="fLeft txInput txtSearch" />
            <asp:Button ID="btnSearch" runat="server" CssClass="btnFnt" Text="Search" UseSubmitBehavior="False" />
        </div>
        <div id="divSource" style="height: 590px;">
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
                <asp:LinkButton ID="lbtnNext" runat="server" Text="Next"></asp:LinkButton>
                <asp:LinkButton ID="lbtnLast" runat="server" Text="Last"></asp:LinkButton>
                <asp:LinkButton ID="lbtnGoTo" runat="server" Text="Go to"></asp:LinkButton>
                <asp:TextBox ID="txtPage" runat="server" CssClass="txInput"></asp:TextBox>
            </div>
        </div>
    </div>
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
