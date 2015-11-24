<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Booking.aspx.vb" Inherits="Booking" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Select Report</title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
	<script type="text/javascript" src="../JavaScript/jquery.nyroModal-1.6.2.js"></script>
    
    

    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/js_lzw.js" -->
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
                var strUrl = "../loading.aspx?tourl=Print/crBooking.aspx?Id=" + intId + "&Report=" + arrReport[0];
                window.open(strUrl);
            }
        }
        function SelectedDivl(selectId, LiCount) {
            var DivName;
            var LiName;
            for (var i = 1; i <= LiCount; i++) {
                if (selectId == i) {
                    LiName = "a" + selectId.toString();
                    document.getElementById(LiName).className = "f12e navNml navOn";
                }
                else {
                    LiName = "a" + i.toString();
                    document.getElementById(LiName).className = "f12c navNml noSep";
                }
            }
            document.getElementById('hid_val').value = selectId;
            GetTabQueryData();
        }
        function GetTabQuery() {
            //by lzw
            var strw = document.getElementById("hid_val").value;
            if (strw == "1") {
                strw = " and modulecode in ('SE','SI','SF') ";
            }
            else if (strw == "2") {
                strw = " and modulecode in ('AE','AI','AF') ";
            }
            else if (strw == "3") {
                strw = " and modulecode in ('TP')  ";
            }
            else if (strw == "4") {
                strw = " and OrderType ='M' and isnull(BalancePcs,0)!=0 and StatusCode<>'DEL' and ModuleCode='SE' ";
            }
            else if (strw == "5") {
                strw = " and OrderType ='S' and isnull(BalancePcs,0)!=0 and StatusCode<>'DEL' and ModuleCode='SE' ";
            }
            else if (strw == "6") {
                strw = " and OrderType ='F' and isnull(BalancePcs,0)!=0 and StatusCode<>'DEL' and ModuleCode='SE' ";
            }
            else if (strw == "7") {
                strw = " and OrderType ='P' and isnull(BalancePcs,0)!=0 and StatusCode<>'DEL' and ModuleCode='SE' ";
            }
            else if (strw == "8") {
                strw = " and OrderType not in ('M','S','F','P') and isnull(BalancePcs,0)!=0 and StatusCode<>'DEL' and ModuleCode='SE' ";
            }
            else if (strw == "9") {
                strw = " and ModuleCode='AE'  and isnull(BalancePcs,0)!=0 and StatusCode<>'DEL' ";      
            }  else if (strw == "10") {
                strw = " and (OrderType not in ('M','S','F','P') or ModuleCode='AE') and isnull(BalancePcs,0)!=0 and StatusCode<>'DEL' ";
                }
            strWhere = strw
        }
        function AdvGetQuery() {
            var strw = document.getElementById("hid_val").value;
            if (strw == "1") {
                strw = " and modulecode in ('SE','SI','SF') ";
            }
            else if (strw == "2") {
                strw = " and modulecode in ('AE','AI','AF') ";
            }
            else if (strw == "3") {
                strw = " and modulecode in ('TP')  ";
            }
            else { strw = ""; }
            strWhere = strWhere + strw;
        }
        function GetQuery() {
            //by lzw
            var strWhereBook = "";
            var strw = document.getElementById("hid_val").value;
            var strQuery = document.getElementById("txtSearch").value;
            var objSearchField = document.getElementById("drpSearch");
           // 
            if(strQuery=="")
            {
            GetTabQuery();
            return;
            }
            if (objSearchField) {
                var arrFieldName = objSearchField.options[objSearchField.selectedIndex].value.split(",");
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
                    else { strWhere = "  and (Convert(NVarChar(50)," + arrFieldName[0] + ",103)" + " like '%" + strQuery + "%' or Convert(NVarChar(50)," + arrFieldName[0] + ",105)" + " like '%" + strQuery + "%' or cast(" + arrFieldName[0] + " as NVarChar(50))" + " like '%" + strQuery + "%' )"; }
                }
                //if (strQuery == "") { strWhere = "1=2"; }
            }
            if (strw == "1") {
                strw = " and modulecode in ('SE','SI','SF') ";
            }
            else if (strw == "2") {
                strw = " and modulecode in ('AE','AI','AF') ";
            }
            else if (strw == "3") {
                strw = " and modulecode in ('TP')  ";
            }
             else if (strw == "4") {
                strw = " and OrderType ='M' ";
            }
            else if (strw == "5") {
                strw = " and OrderType ='S'";
            }
            else if (strw == "6") {
                strw = " and OrderType ='F'";
            }
            else if (strw == "7") {
                strw = " and OrderType ='P'";
            }
            else if (strw == "8") {
                strw = " and OrderType not in ('M','S','F','P')";
            }
            else if (strw == "9") {
                strw = " and ModuleCode='AE'";
            }
            
            strWhere = strWhere + strw + strWhereBook;
        }

    </script>

</head>
<body onload="DivAutoSize(120);" onresize="DivAutoSize(120);">
    <form id="frmBooking" runat="server">
    <div id="divTopNav" runat="server">
        <ul id="ulTopNav">
            <li>
                <%--Malaysia--%>
                <asp:Label ID="a4" Style="display: none;" CssClass="f12e navNml navOn" runat="server"
                    onclick="javascript:SelectedDivl(4,10);" Width="100px" Text="<%$ Resources:a4 %>" />
            </li>
            <li>
                <%--Singapore--%>
                <asp:Label ID="a5" Style="display: none;" CssClass="f12e navNml navOn" runat="server"
                    onclick="javascript:SelectedDivl(5,10);" Width="100px" Text="<%$ Resources:a5 %>" />
            </li>
            <li>
                <%--Indonesia--%>
                <asp:Label ID="a6" Style="display: none;" CssClass="f12e navNml navOn" runat="server"
                    onclick="javascript:SelectedDivl(6,10);" Width="100px" Text="<%$ Resources:a6 %>" />
            </li>
            <li>
                <%--Philippine--%>
                <asp:Label ID="a7" Style="display: none;" CssClass="f12e navNml navOn" runat="server"
                    onclick="javascript:SelectedDivl(7,10);" Width="100px" Text="<%$ Resources:a7 %>" />
            </li>
            <li>
                <%--Other--%>
                <asp:Label ID="a8" Style="display: none;" CssClass="f12e navNml navOn" runat="server"
                    onclick="javascript:SelectedDivl(8,10);" Width="100px" Text="<%$ Resources:a8 %>" />
            </li>
            <li>
                <%--Air_Warehouse--%>
                <asp:Label ID="a9" Style="display: none;" CssClass="f12e navNml navOn" runat="server"
                    onclick="javascript:SelectedDivl(9,10);" Width="100px" Text="<%$ Resources:a9 %>" />
            </li>
            <li>
                <%--Sea--%>
                <asp:Label ID="a1" Style="display: none;" CssClass="f12c navNml noSep" runat="server"
                    onclick="javascript:SelectedDivl(1,10);" Width="100px"  Text="<%$ Resources:a1.Text %>" /></li>
            <li>
                <%--Air--%>
                <asp:Label ID="a2" Style="display: none;" CssClass="f12c navNml noSep" runat="server"
                    onclick="javascript:SelectedDivl(2,10);"  Width="100px" Text="<%$ Resources:a2.Text %>" />
            </li>
            <li>
                <%--Sea--%>
                <asp:Label ID="a3" Style="display: none;" CssClass="f12c navNml noSep" runat="server"
                    onclick="javascript:SelectedDivl(3,10);" Width="100px" Text="<%$ Resources:a3.Text %>" />
            </li>
              <li>
                <%--Sea--%>
                <asp:Label ID="a10" Style="display: none;" CssClass="f12c navNml noSep" runat="server"
                    onclick="javascript:SelectedDivl(10,10);" Width="100px" Text="<%$ Resources:a10.Text %>" />
            </li>
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
        <asp:DropDownList ID="drpSearch" runat="server" CssClass="fLeft" />
        <div id="div_txtSearch" style="display: inline;">
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
    <asp:HiddenField ID="hid_val" runat="server" Value="4" />
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

