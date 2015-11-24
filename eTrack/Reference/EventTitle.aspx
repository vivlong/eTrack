<%@ Page Language="VB" AutoEventWireup="true" CodeFile="EventTitle.aspx.vb" Inherits="EventTitle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <script src="../JavaScript/jquery.min.js" type="text/javascript"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/js_lzw.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->
    <!--#include file="../JavaScript/Print.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script language="javascript" type="text/javascript">
        function PrintDetail(intId) {
            if (intId) {
                var strUrl = "../loading.aspx?tourl=" + PrintPath + "/crEventTitle.aspx?Id=" + intId.toString() + "";
                window.open(strUrl);
            }
        }
        function GetQuery() {
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
        function AdvGetQuery() { }
        function AddTitle(obj) { 
        if($.trim(obj.value)==""){alert("please enter the Title");return false;}
         context=$("#gvwSource");
         var arg="AddTitle"+ParSeparator+obj.value;
         <%=ClientScript.GetCallbackEventReference(Me,"arg","SetAddTitle","context")%>
        }
        function SetAddTitle(result,context)
        {
            var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk) {
                context.html(strResult[1]);
            }
            else if (strResult[1]!=""){
                alert(strResult[1]);
            }
         }
         //delete
        function DeleteTitle(trxNo) {
         context=$("#gvwSource");
         var arg="DeleteTitle"+ParSeparator+trxNo;
         <%=ClientScript.GetCallbackEventReference(Me,"arg","SetAddTitle","context")%>
        }
    </script>
</head>
<body onload="DivAutoSize(115);" onresize="DivAutoSize(115);">
    <form id="frmEventTitle" runat="server">
    <div id="divTitle">
        &nbsp
        <asp:Label ID="Label1" CssClass="Title" runat="server" Text="Event Title"></asp:Label>
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
        &nbsp
        <asp:TextBox ID="txtSearch" runat="server" CssClass="txInput txtSearch" />
        <asp:Button ID="btnAdd" runat="server" CssClass="btnFnt" Width="60px" Text="Add"
            UseSubmitBehavior="false" />
    </div>
    <div id="divSource">
        <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvwSource_RowDataBound"
            EnableViewState="False">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a style="cursor: pointer" onclick="DeleteTitle(<%# Eval("TrxNo") %>);">
                            <img id="Img3" runat="server" src="../Images/Edit/ed_Delete.gif" alt="del" /></a>
                    </ItemTemplate>
                    <ItemStyle CssClass="colNo taCenter" />
                    <HeaderStyle CssClass="colNo taCenter" />
                </asp:TemplateField>
                <asp:BoundField HeaderText="Event Title" DataField="Title" HtmlEncode="False">
                    <ItemStyle CssClass="colFileDate taCenter" />
                    <HeaderStyle CssClass="colFileDate taCenter" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Create By" DataField="CreateBy" HtmlEncode="False">
                    <ItemStyle CssClass="colFileSize taCenter" />
                    <HeaderStyle CssClass="colFileSize taCenter" />
                </asp:BoundField>
                <asp:BoundField HeaderText="CreateDateTime" DataField="CreateDateTime" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                    HtmlEncode="False">
                    <ItemStyle CssClass="colFileDate taCenter" />
                    <HeaderStyle CssClass="colFileDate taCenter" />
                </asp:BoundField>
            </Columns>
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
document.onmousedown = norightclick;
document.onclick = HideMenu;
document.ondblclick = nodblClick;
</script>
