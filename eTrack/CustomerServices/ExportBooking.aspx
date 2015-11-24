<%@ Page Language="VB" AutoEventWireup="true" CodeFile="ExportBooking.aspx.vb" Inherits="ExportBooking" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Select Report</title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/BaseList.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->
    <!--#include file="../JavaScript/Print.js" -->
    <!--#include file="../JavaScript/ResetSize.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script language="javascript" type="text/javascript">
    function GetQueryDataBook() 
{   
    var obj= document.getElementById("txtSearch");
   
    context = document.getElementById("divSource");
    intPage=1;
    ShowLoadingData();
    GetQuery();
    var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+""; 
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSourceValue", "context")%>; 
}
        function PrintDetail(intId, Reports) {
            var strUrl = "";
            var strReport = document.getElementById("hidReports").value;
            var arrReport = strReport.split(",");
            if (Reports == "") { alert("There are Not Reports in the Server."); return false; }
            if (arrReport.length != 1) {
                var strUrl = "../loading.aspx?tourl=CustomerServices/SelectReportEdit.aspx?id=" + intId;
                var ret = WindowDialog(strUrl, 400, 300);
                if (ret != null) { }
            }
            else {
                strUrl = "../loading.aspx?tourl=CustomerServices/SelectReportEdit.aspx?id=" + intId;
                var strUrl = "../loading.aspx?tourl=Print/crExportBooking.aspx?Id=" + intId + "&Report=" + arrReport[0];
                window.open(strUrl);
            }
        }
        //lzw081110
        var CurrDate = "";
        function openSelect() {
        var ret = WindowDialog("ExportBookingSelect.aspx", 765, 480);
        if (ret != null) { GetPageData(null,-1) }
        }
    </script>
</head>
<body onload="DivAutoSize(110);" onresize="DivAutoSize(110);">
    <form id="frmExportBooking" runat="server">
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
        <asp:DropDownList ID="drpSearch" runat="server" CssClass="fLeft" />
        <div id="div_txtSearch" style="display: inline">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="txInput txtSearch" />
        </div>
        <asp:Button ID="btnSearch" runat="server" CssClass="btnFnt" Width="60px" Text="Search"
            UseSubmitBehavior="false" />
        <asp:Button ID="btnAdvSearch" runat="server" CssClass="btnFnt" Width="60px" Text="Advance"
            UseSubmitBehavior="false" />
        <asp:Button ID="btnGridColumnSet" runat="server" CssClass="btnFnt" Width="60px" UseSubmitBehavior="false"
            Text="<%$ Resources:btnGridColumnSet %>" />
    </div>
    <div id="HeaderDiv">
    </div>
    <div id="divSource" style="height: 540px;">
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
    <asp:HiddenField ID="hidReports" runat="server" />
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
