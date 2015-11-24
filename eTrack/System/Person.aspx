<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Person.aspx.vb" Inherits="Person"
    Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/BaseList.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script type="text/javascript" language="javascript">
//        function GetQuery() {
//            //by lzw
//            //add Drop Condition
//            var statusCode = $("#drpStatus").val();
//            if (statusCode != "ALL")
//            { strWhere = " and StatusCode='" + statusCode + "'"; }
//            else { strWhere = ""; }
//            var strQuery = document.getElementById("txtSearch").value;
//            if (strQuery != "") { strWhere += " and (UserID='" + strQuery + "' or UserName='" + strQuery + "') "; }
//        }
        function GetQueryData() {
            var obj = document.getElementById("txtSearch");
            context = document.getElementById("divSource");
            intPage = 1;
            ShowLoadingData();
            GetQuery(obj); 
             var statusCode = $("#drpStatus").val();
            if (statusCode != "ALL")
            { strWhere = strWhere+" and StatusCode='" + statusCode + "'"; }
            var arg = "GetPageData" + ParSeparator + intPage.toString() + ParSeparator + strQuery + ParSeparator + strWhere + ParSeparator + SortField + ParSeparator + SortDesc.toString() + ParSeparator + "";
            WebForm_DoCallback('__Page', arg, SetSourceValue, context, null, false);
        } 
    </script>
</head>
<body onload="DivAutoSize(90);" onresize="DivAutoSize(90);">
    <form id="frmPerson" runat="server">
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
            <asp:DropDownList ID="drpStatus" runat="server" CssClass="drpStatus">
                <asp:ListItem Value="USE">USE</asp:ListItem>
                <asp:ListItem Value="DEL">DEL</asp:ListItem>
                <asp:ListItem Value="ALL">ALL</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnSearch" runat="server" CssClass="btnFnt" Text="<%$ Resources:PageList, Search %>"
                UseSubmitBehavior="False" />
        </div>
        <div id="divSource" style="height: 580px;">
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
                <asp:Label ID="lblPage" runat="server" Text="<%$ Resources:PageList, Page %>"></asp:Label>
                <asp:LinkButton ID="lbtnFirst" runat="server" Text="<%$ Resources:PageList, First %>"></asp:LinkButton>
                <asp:LinkButton ID="lbtnPrior" runat="server" Text="<%$ Resources:PageList, Prior %>"></asp:LinkButton>
                <asp:LinkButton ID="lbtnNext" runat="server" Text="<%$ Resources:PageList, Next %>"></asp:LinkButton>
                <asp:LinkButton ID="lbtnLast" runat="server" Text="<%$ Resources:PageList, Last %>"></asp:LinkButton>
                <asp:LinkButton ID="lbtnGoTo" runat="server" Text="<%$ Resources:PageList, Goto %>"></asp:LinkButton>
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
