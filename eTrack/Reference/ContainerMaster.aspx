<%@ Page Language="VB" AutoEventWireup="true" CodeFile="ContainerMaster.aspx.vb" Inherits="ContainerMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/ReBaseList.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->
    <!--#include file="../JavaScript/Print.js" -->
    <!--#include file="../JavaScript/ResetSize.js" -->
    
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script type="text/javascript" language="javascript">
    function InsertDetail()
     {
       var strFun=document .getElementById("hidFunNo").value;
       var ret=WindowDialog(EditPage+"?FunNo="+strFun,EditWidth,EditHeight);
       if (ret==RtnOk) {GetPageData(null,-1)}
     }
    </script>

</head>
<body onload="ResetSize(11,0)">
    <form id="frmContainerMaster" runat="server">
    <div>
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
            <div class="searchICO fLeft">
            </div>
            <asp:DropDownList ID="drpSearch" runat="server" CssClass="fLeft" />
            <asp:TextBox ID="txtSearch" runat="server" CssClass="fLeft txInput txtSearch" />
            <asp:Button ID="btnSearch" runat="server" CssClass="btnFnt" Text="Search" UseSubmitBehavior="false" />
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
                <asp:LinkButton ID="lbtnNext" runat="server" Text="Next"></asp:LinkButton>
                <asp:LinkButton ID="lbtnLast" runat="server" Text="Last"></asp:LinkButton>
                <asp:LinkButton ID="lbtnGoTo" runat="server" Text="Go to"></asp:LinkButton>
                <asp:TextBox ID="txtPage" runat="server" CssClass="txInput"></asp:TextBox>
            </div>
            <div class="fRight">
                    <%--<asp:Button ID="btnPrint" runat="server" CssClass="Button" Text="<%$ Resources:PageList, Print %>"
                        UseSubmitBehavior="False" />--%>
                    <asp:Button ID="btnToExcel" runat="server" CssClass="Button" Text="<%$ Resources:PageList, ExportExcel %>"
                        UseSubmitBehavior="False" />
            </div> 
        </div>
        <asp:HiddenField ID="hidFunNo" runat="server" />
    </div>
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

