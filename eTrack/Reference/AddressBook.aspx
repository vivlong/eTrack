<%@ Page Language="VB" AutoEventWireup="true" CodeFile="AddressBook.aspx.vb" Inherits="AddressBook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/js_lzw.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->
    <!--#include file="../JavaScript/Print.js" -->


    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

    <script language="javascript" type="text/javascript">
        function PrintDetail(intId)
    {
        if(intId){
            var strUrl="../loading.aspx?tourl="+PrintPath+"/crAddressBook.aspx?Id="+intId.toString()+"";
            window.open(strUrl);
        }
    }
    function GetQuery() 
    {
        //by lzw
        var strWhereBook = "";
        var strQuery = document.getElementById("txtSearch").value;
        var objSearchField = document.getElementById("drpSearch");
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
                else { strWhere = "  and Cast(" + arrFieldName[0] + " as NVarChar(50))" + " like '%" + strQuery + "%' "; }
            }
        }
        strWhere = strWhere + strWhereBook;
    }
   function AdvGetQuery() {}
    </script>

</head>
<body onload="DivAutoSize(115);" onresize="DivAutoSize(115);">
    <form id="frmAddressBook" runat="server">
    <div id="divTitle">
        &nbsp
        <asp:Label ID="Label1" CssClass="Title" runat="server" Text="<%$ Resources:lblTitle.Text %>"></asp:Label>
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
    <div id="divSearch">
        <div class="searchICO fLeft">
        </div>
        <asp:DropDownList ID="drpSearch" runat="server" CssClass="fLeft drpSearch" Width="160px" />
        <asp:TextBox ID="txtSearch" runat="server" CssClass="txInput txtSearch" />
        <asp:Button ID="btnSearch" runat="server" CssClass="btnFnt" Width="60px" Text="Search"
            UseSubmitBehavior="false" />
        <asp:Button ID="btnAdvSearch" runat="server" CssClass="btnFnt" Width="60px" Text="Advance"
            UseSubmitBehavior="false" />
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
    <asp:HiddenField ID="hid_val" runat="server" Value="1" />
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
