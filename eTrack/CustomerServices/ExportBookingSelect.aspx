<%@ Page Language="VB" AutoEventWireup="true" CodeFile="ExportBookingSelect.aspx.vb" Inherits="ExportBookingSelect" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Select Vessel Schedule</title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/BaseList.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->
    <!--#include file="../JavaScript/Print.js" -->
    <!--#include file="../JavaScript/ResetSize.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script language="javascript" type="text/javascript">
        function GetQuery() {
            //by lzw
            var strWhereBook = "";
            var strw = document.getElementById("hid_val").value;
            var strQuery = document.getElementById("txtSearch").value;
            var objSearchField = document.getElementById("drpSearch");
            // 
            if (strQuery == "") {
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
            }
        }
        //lzw081110 
        function setValue_EB(arrPara) {
            var ret = WindowDialog("ExportBookingEdit.aspx?seblTrxNo=" + arrPara, 800, 600);
            this.close();
            if (ret != null) { }
        }
        function SelectByPod() { 
          if($("#drpSearch").val()!="")
          {
            context=null;
            var arg="SelectByPod"+ParSeparator+$("#drpSearch").val();
            <%=ClientScript.GetCallbackEventReference(Me,"arg","SetReturnValue","context")%>
          }
        }
       function SetReturnValue(result,context)
       {
        var strResult=result.split(ParSeparator);
        if (strResult[0]==RtnOk) {
            $("#divSource").html(strResult[1]).
            context.value="";
           }
           else{alert(strResult[1]);}
        }
    </script>
</head>
<body onload="DivAutoSize(210);" onresize="DivAutoSize(210);">
    <form id="frmBooking" runat="server">
    <div id="divTopNav" runat="server">
        <ul id="ulTopNav">
            <li>
                <%--Malaysia--%>
                <asp:Label ID="a1" Style="display: none;" CssClass="f12e navNml navOn" runat="server"
                    Width="100px" Text="<%$ Resources:a1 %>" />
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
        <asp:Label ID="Label1" runat="server" Text="Port"></asp:Label>
        <asp:DropDownList ID="drpSearch" runat="server" CssClass=" DropList" AutoPostBack="True" />
    </div>
    <div id="divSource" style="width: 765px;">
    </div>
    <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvwSource_RowDataBound"
        EnableViewState="False">
        <HeaderStyle CssClass="Header" />
        <FooterStyle CssClass="Footer" />
        <RowStyle CssClass="Row" />
        <SelectedRowStyle CssClass="SelectRow" />
        <PagerStyle CssClass="Pager" />
        <AlternatingRowStyle CssClass="Alternating" />
    </asp:GridView>
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
            <asp:Button ID="btnClose" runat="server" CssClass="Button" Text="<%$ Resources:btnClose %>"
                Width="77px" UseSubmitBehavior="False" />
        </div>
    </div>
    <asp:HiddenField ID="hid_val" runat="server" Value="4" />
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
//    function window.onunload() {
//        CloseWindow(); return false;
//    }
</script>
