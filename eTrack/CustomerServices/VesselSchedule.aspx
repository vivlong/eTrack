<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VesselSchedule.aspx.vb"
    Inherits="VesselSchedule_VesselSchedule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/VesselSchedule.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/Calendar.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/Print.js" -->
    <!-- #include file="../JavaScript/Query.js" -->
    <!--#include file="JavaScript/VesselSchedule.js" -->
    <!-- #include file="../JavaScript/CheckForm.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"> </script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>

</head>
<body onload="DivAutoSize(155);" onresize="DivAutoSize(155);">
    <form id="frmAirSeaQuery" runat="server">
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
        <div id="divVesselSearch" style="height: 60px; width: 760px; padding-left: 10px;">
            <div class="divline">
                <asp:Label ID="lbPortOfDischarge" runat="server" Text="<%$ Resources:lbPortOfDischarge %>">
                </asp:Label>
                <asp:DropDownList ID="drPortOfDischarge" runat="server" CssClass="" />
                <asp:Button ID="btnAddField" runat="server" CssClass="btnFnt" Width="60px" Text="Add"
                    UseSubmitBehavior="false" />
                <asp:HiddenField ID="hid_AddField" runat="server" />
                <asp:DropDownList ID="drPortOfDischargeField" runat="server" Width="120px" />
                <asp:Button ID="btnRemove" runat="server" CssClass="btnFnt" Text="Remove" UseSubmitBehavior="false"
                    Width="60px" />
                <asp:Button ID="btnClearField" runat="server" CssClass="btnFnt" Text="Clear" UseSubmitBehavior="false"
                    Width="60px" />
                <asp:HiddenField ID="fldCustomerCode" runat="server" />
                <asp:HiddenField ID="fldLoginType" runat="server" />
            </div>
            <div class="divline">
                <div class="fLeft">
                    <asp:Label ID="lbDepartureDate" runat="server" Text="<%$ Resources:lbDepartureDate %>" />
                    <asp:TextBox ID="txtDepartureDate" runat="server" CssClass="TextBox" />
                    <asp:Button ID="btnDepartureDate" runat="server" CssClass="Button" Text="..." Width="20px"
                        UseSubmitBehavior="False" />
                    <asp:Label ID="lbDuring" runat="server" Text="<%$ Resources:lbDuring %>" />
                    <asp:DropDownList ID="drDuring" runat="server" CssClass="" />
                    <asp:Label ID="lblweek" runat="server" Text="<%$ Resources:lblweek %>" />
                    <asp:Button ID="btnSearch" runat="server" CssClass="Button" Text="Search" UseSubmitBehavior="false" />
                </div>
            </div>
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
                <asp:Button ID="btnPrint" runat="server" CssClass="Button" Text="Print" UseSubmitBehavior="False" />
                <asp:Button ID="btnToExcel" runat="server" CssClass="Button" Text="Export Excel"
                    Width="77px" UseSubmitBehavior="False" />
            </div>
        </div>
        <asp:HiddenField ID="hid_voyageID" runat="server" />
        <div id="div_voyageidpass">
            <asp:HiddenField ID="hid_voyageIDPass" runat="server" />
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

