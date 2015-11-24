<%@ Page Language="VB" AutoEventWireup="true" CodeFile="OverseasRIEdit.aspx.vb" Inherits="OverseasRIEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/OverseasRIEidt.css" rel="stylesheet" type="text/css" />
    <link href="../UserControl/datepicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/ReBaseList.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->
    <!--#include file="JavaScript/OverseasRIEidt.js" -->
    <!-- #include file="../JavaScript/DateOperate.js" -->
    <!--#include file="../JavaScript/ResetSize.js" -->
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
<body onload="ResetSize(11,300)">
    <form id="form1" runat="server">
    <div id="divTopNav">
        <ul id="ulTopNav">
            <li>
                <div id="divTitle">
                </div>
                <asp:Label ID="a1" CssClass="f12e navNml navOn" runat="server" Width="250px" />
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
                <asp:Label ID="lblOrganization" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblOrganization %>" />
                <asp:TextBox ID="txtOrganization" runat="server" CssClass="TextBox txt" ReadOnly="true"
                    MaxLength="10" TabIndex="1" />
            </div>
            <div class="divleft">
                <asp:Label ID="lblJobNo" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblJobNo %>" />
                <asp:TextBox ID="txtJobNo" runat="server" CssClass="TextBox txt" MaxLength="20" 
                    TabIndex="1" />
                <asp:Button ID="btnJobNo" runat="server" CssClass="Button bntDate" Text="..." UseSubmitBehavior="False" />
            </div>
            <div class="divleft">
                <asp:Label ID="lblVesselName" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblVesselName %>" />
                <asp:TextBox ID="txtVesselName" runat="server" CssClass="TextBox txt" Width="250px"
                    MaxLength="50" TabIndex="2" />
            </div>
            <div class="divleft">
                <asp:Label ID="lblVoyageNo" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblVoyageNo %>" />
                <asp:TextBox ID="txtVoyageNo" runat="server" CssClass="TextBox txt" 
                    MaxLength="20" TabIndex="3" />
            </div>
            <div class="divleft">
                <asp:Label ID="lblETA" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblETA %>" />
                <asp:TextBox ID="txtETA" runat="server" CssClass="TextBox txt" MaxLength="16" 
                    TabIndex="4" />
                <asp:Button ID="btnETA" runat="server" CssClass="Button bntDate" Text="..." 
                    UseSubmitBehavior="False" TabIndex="5" />
            </div>
            <div class="divleft">
                <asp:Label ID="lblPortOfDischarge" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblPortOfDischarge %>" />
                <asp:TextBox ID="txtPortOfDischarge" runat="server" CssClass="TextBox txt" 
                    MaxLength="5" TabIndex="5" />
                <asp:Button ID="btnPortOfDischarge" runat="server" CssClass="Button bntDate" Text="..."
                    UseSubmitBehavior="False" TabIndex="7" />
            </div>
            <div class="divleft">
                <asp:Label ID="lblReleaseDate" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblReleaseDate %>" />
                <asp:TextBox ID="txtReleaseDate" runat="server" CssClass="TextBox txt" 
                    MaxLength="16" TabIndex="8" />
                <asp:Button ID="btnReleaseDate" runat="server" CssClass="Button bntDate" Text="..."
                    UseSubmitBehavior="False" TabIndex="9" />
            </div>
        </div>
    </div>
    <div id="divSource" style="height: 500px">
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
        <asp:Button ID="btnRelease" runat="server" CssClass="btnFnt" Width="120px" Text="Release Container"
            UseSubmitBehavior="false" TabIndex="100" />
        <asp:Button ID="btnCancel" runat="server" CssClass="btnFnt" Text="Cancel" 
            UseSubmitBehavior="false" TabIndex="100" />&nbsp&nbsp
    </div>
    <br />
    <asp:HiddenField ID="hidFunNo" runat="server" />
    <asp:HiddenField ID="hidTrxNo" runat="server" />
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
    var UpdateFlag="N";
    var strRIN='';
    var strRON='';
</script>

