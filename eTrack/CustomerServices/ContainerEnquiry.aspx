<%@ Page Language="VB" AutoEventWireup="true" CodeFile="ContainerEnquiry.aspx.vb" Inherits="ContainerEnquiry" %>

<%@ Register Src="../UserControl/DateTimeSelect.ascx" TagName="DateTimeSelect" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Schedule</title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/ContainerEnquiry.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/Calendar.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/Print.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/js_lzw.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->
    <!--#include file="JavaScript/ContainerEnquiry.js" -->
    <!--#include file="../JavaScript/ResetSize.js" -->
    <!--#include file="../JavaScript/Print.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"> </script>
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
    function ShowVesselDetail(arrPara) {
        var ret = WindowDialog("VesselDetail.aspx?arrPara=" + arrPara+"", 400, 430);
        if (ret != null) {}
    }
    </script>
</head>
<body onload="DivAutoSize(150);" onresize="DivAutoSize(150);">
    <form id="frmContainerEnquiry" runat="server">
    <div id="divForm">
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
        <div id="divVesselSearch" runat="server" style="height: 90px; width: 760px; padding-left: 10px;">
            <div class="divline">
                <asp:Label ID="lbOBlNo" runat="server" 
                    Text="<%$ Resources:lbOBlNo %>"></asp:Label>
                <asp:DropDownList ID="drOBLNo" runat="server" CssClass="" />
                <asp:Label ID="lbVesselName" runat="server" 
                    Text="<%$ Resources:lbVesselName %>"></asp:Label>
                <asp:DropDownList ID="drVesselName" runat="server" CssClass="" />
                <asp:HiddenField ID="fldCustomerCode" runat="server" />
                <asp:HiddenField ID="fldPortofDischargeCode" runat="server" />
              <asp:HiddenField ID="fldLoginType" runat="server" />
            </div>
            <div class="divline">
                <asp:Label ID="lbMasterJobNo" runat="server" 
                    Text="<%$ Resources:lbMasterJobNo %>"></asp:Label>
                <asp:DropDownList ID="drMasterJobNo" runat="server" CssClass="" />
                <asp:Label ID="lbContainerNo" runat="server" 
                    Text="<%$ Resources:lbContainerNo %>"></asp:Label>
                <asp:DropDownList ID="drContainerNo" runat="server" CssClass="" />
            </div>
         <%--  <div class="divline">
                <asp:Label ID="lbPickupRefNo" runat="server" 
                    Text="<%$ Resources:lbPickupRefNo %>"></asp:Label>
                <asp:DropDownList ID="drPickupRefNo" runat="server" CssClass="" />
                <asp:Label ID="lbBillFlag" runat="server" 
                    Text="<%$ Resources:lbBillFlag %>"></asp:Label>
                <asp:DropDownList ID="drBillFlag" runat="server" CssClass="" />
            </div>--%>
             <div class="divline">
                <asp:Label ID="lbCargoStatus" runat="server" 
                    Text="<%$ Resources:lbCargoStatus %>"></asp:Label>
                <asp:DropDownList ID="drCargoStatusCode" runat="server" CssClass="" />
                <asp:Button ID="btnSearch" runat="server" CssClass="Button" Text="Search" UseSubmitBehavior="false" />               
            </div>
        </div>
        <div id="divSource" runat="server" style="padding-left: 10px">
            <asp:Repeater ID="rpSource" runat="server">
                <ItemTemplate>
                      <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvwSource_RowDataBound"
                        EnableViewState="False">
                        <HeaderStyle CssClass="Header" />
                        <FooterStyle CssClass="Footer" />
                        <RowStyle CssClass="Row" />
                        <SelectedRowStyle CssClass="SelectRow" />
                        <PagerStyle CssClass="Pager" />
                        <AlternatingRowStyle CssClass="Alternating" />
                    </asp:GridView>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div id="divPage" class="NoPrint">
            <div class="fRight">
                <asp:Button ID="btnToExcel" runat="server" CssClass="Button" Text="Export Excel"
                    Width="77px" UseSubmitBehavior="False" />
            </div>
        </div>
        <asp:HiddenField ID="hid_voyageID" runat="server" />
        <div id="div_voyageidpass">
            <asp:HiddenField ID="hid_voyageIDPass" runat="server" />
        </div>
    </div>
    <asp:HiddenField ID="hid_val" runat="server" Value="1" />
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
