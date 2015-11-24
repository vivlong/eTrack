<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Company.aspx.vb" Inherits="Company" Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head >
    <title></title>
    <link href="../App_Themes/LrErp.css"  rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css"  rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css"  rel="Stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/BaseList.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->
    <!--#include file="../JavaScript/ResetSize.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
</head>
<body onload="ResetSize(11,0)">
    <form id="frmCompany" runat="server">
        <div>
            <div id="popupMenu" class="skin" runat="server" onclick="ClickItem()" onmousemove="HighlighItem()" onmouseout="LowlightItem()">            
            </div>
            <div id="divSearch" style="width:99%">
                <div class="searchICO fLeft" ></div>
                  <asp:DropDownList ID="drpSearch" runat="server" CssClass="fLeft" />
                <asp:TextBox id="txtSearch" runat="server"  CssClass="fLeft txInput txtSearch"   />
                <asp:Button id="btnSearch" runat="server" CssClass="btnFnt" Text="Search" UseSubmitBehavior="False" />
            </div>  
            <div id="divSource" style="width:99.5%">
                <asp:GridView ID="gvwSource" runat="server"  AutoGenerateColumns="False" OnRowDataBound="gvwSource_RowDataBound" enableviewstate="False" style="width:100%" >
                <HeaderStyle CssClass="Header"/>
                <FooterStyle CssClass="Footer"/>
                <RowStyle CssClass="Row" />
                <SelectedRowStyle CssClass="SelectRow" />
                <PagerStyle CssClass="Pager" />
                <AlternatingRowStyle CssClass="Alternating" />                    
                </asp:GridView>
            </div>       
            <div id="divPage">
                <div class="fLeft">
                    <asp:Label ID="lblPage" runat="server"  Text="Page" ></asp:Label>
                    <asp:LinkButton ID="lbtnFirst" runat="server" Text="First" ></asp:LinkButton>
                    <asp:LinkButton ID="lbtnPrior" runat="server" Text="Prior" ></asp:LinkButton>
                    <asp:LinkButton ID="lbtnNext" runat="server" Text="Next" ></asp:LinkButton>
                    <asp:LinkButton ID="lbtnLast" runat="server" Text="Last" ></asp:LinkButton>
                    <asp:LinkButton ID="lbtnGoTo" runat="server"  Text="Go to" ></asp:LinkButton>
                    <asp:TextBox ID="txtPage" runat="server" CssClass="txInput" ></asp:TextBox>                
                </div>
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

