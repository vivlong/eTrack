<%@ Page Language="VB" AutoEventWireup="true" CodeFile="ContainerEU.aspx.vb" Inherits="Operations_ContainerEU" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        @import url("<%=ConfigPath%>/LrErp.css");
        @import url("<%=ConfigPath%>/LrErp_Grid.css");
        @import url("<%=ConfigPath%>/LrErp_List.css");
        @import url("<%=ConfigPath%>/PageControl.css");
    </style>
    <link href="App_Themes/ContainerEU.css" rel="stylesheet" type="text/css" />
    <link href="../UserControl/datepicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/ReBaseList.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->
    <!--#include file="JavaScript/ContainerEU.js" -->
    <!-- #include file="../JavaScript/DateOperate.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script language="javascript" type="text/javascript" src="../UserControl/datepicker/WdatePicker.js"></script>

    <script type="text/javascript" language="javascript">
    function InsertDetail()
    {
       var strFun=document .getElementById("hidFunNo").value;
       var ret=WindowDialog(EditPage+"?FunNo="+strFun,EditWidth,EditHeight);
       if (ret==RtnOk) {GetPageData(null,-1)}
    }
    </script>

</head>
<body onload="ResetSize(11,300);setConfig('<%=ExportConfig%>');">

    <script type="text/javascript">
function WebForm_CallbackComplete_SyncFixed() {
  // SyncFix: the original version uses "i" as global thereby resulting in javascript errors when "i" is used elsewhere in consuming pages
  for (var i = 0; i < __pendingCallbacks.length; i++) {
   callbackObject = __pendingCallbacks[ i ];
  if (callbackObject && callbackObject.xmlRequest && (callbackObject.xmlRequest.readyState == 4)) {
   // the callback should be executed after releasing all resources
   // associated with this request.
   // Originally if the callback gets executed here and the callback
   // routine makes another ASP.NET ajax request then the pending slots and
   // pending callbacks array gets messed up since the slot is not released
   // before the next ASP.NET request comes.
   // FIX: This statement has been moved below
   // WebForm_ExecuteCallback(callbackObject);
   if (!__pendingCallbacks[ i ].async) {
     __synchronousCallBackIndex = -1;
   }
   __pendingCallbacks[i] = null;

   var callbackFrameID = "__CALLBACKFRAME" + i;
   var xmlRequestFrame = document.getElementById(callbackFrameID);
   if (xmlRequestFrame) {
     xmlRequestFrame.parentNode.removeChild(xmlRequestFrame);
   }

   // SyncFix: the following statement has been moved down from above;
   WebForm_ExecuteCallback(callbackObject);
  }
 }
}
window.onload = function(){
if (typeof (WebForm_CallbackComplete) == "function") {
  // set the original version with fixed version
  WebForm_CallbackComplete = WebForm_CallbackComplete_SyncFixed;
}
}
    </script>

    <form id="form1" runat="server">
    <div id="divTopNav">
        <ul id="ulTopNav">
            <li>
                <asp:Label ID="a1" CssClass="f12e navNml navOn" runat="server" Text="<%$ Resources:a1.Text %>"
                    Width="200px" />
            </li>
        </ul>
    </div>
    <div id="popupMenu" class="skin" runat="server" onclick="ClickItem()" onmousemove="HighlighItem()"
        onmouseout="LowlightItem()">
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
    <div id="divSearch">
        <div class="divleft">
            <div class="divleft">
                <asp:Label ID="lblEvent" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblEvent %>" />
                <asp:DropDownList ID="drEvent" runat="server" CssClass="DropList txt" />
            </div>
            <div class="divleft">
                <%-- <div id="divDrNO" class="lbl">--%>
                <asp:DropDownList ID="DrNO" runat="server" CssClass="DropList" />
                <asp:TextBox ID="txtNo" runat="server" CssClass="TextBox txt" />
                &nbsp;</div>
            <div class="divleft">
                <asp:Label ID="lblVesselName" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblVesselName %>" />
                <asp:TextBox ID="txtVesselName" runat="server" CssClass="TextBox txt" />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblVoyageNo" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblVoyageNo %>" />
                <asp:TextBox ID="txtVoyageNo" runat="server" CssClass="TextBox htxt" />
                &nbsp;
                <asp:Button ID="btnQUERY" runat="server" CssClass="btnFnt" Text="QUERY" UseSubmitBehavior="false"
                    Width="80px" />
            </div>
        </div>
    </div>
    <div id="divSource" style="height: 290px; width: 99%;">
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
    <div class="divleft">
        <asp:Label ID="lblEventDate" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblEventDate %>" />
        <asp:TextBox ID="txtEventDate" runat="server" CssClass="TextBox lblDate" />
        <asp:Button ID="btnEventDate" runat="server" CssClass="Button bntDate" Text="..."
            UseSubmitBehavior="False" />
        <span class="blank">&nbsp</span>
        <div id="divNewVoyageNo" runat="server" style="display: inline;">
            <asp:Label ID="lblNewVoyageNo" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblNewVoyageNo %>" />
            <asp:TextBox ID="txtNewVoyageNo" runat="server" CssClass="TextBox txt" MaxLength="12" />
        </div>
    </div>
    <div class="divleft">
        <asp:Button ID="btnCreateEvent" runat="server" CssClass="btnFnt" Width="100px" Text="Create Event"
            UseSubmitBehavior="false" />
        <asp:Button ID="btnCancel" runat="server" CssClass="btnFnt" Text="Cancel" UseSubmitBehavior="false" />&nbsp&nbsp
    </div>
    <asp:HiddenField ID="hidFunNo" runat="server" />
    <br />
    </form>
</body>
</html>

<script type="text/javascript" language="javascript">
// if (window.Event){
//    document.captureEvents(Event.MOUSEUP); 
// }
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

