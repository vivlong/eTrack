<%@ Page Language="VB" AutoEventWireup="true" CodeFile="RoleFunction.aspx.vb" Inherits="RoleFunction"
    Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../System/App_Themes/RoleFunction.css" rel="Stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="JavaScript/RoleFunction.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script type="text/javascript" language="javascript">
        var drobj;
        var strTab = 1;
        function SelectedDivl(selectId) {
            strTab = selectId;
            if (selectId == 1) {

                document.getElementById("lblTitle").className = "f12e navNml navOn";
                document.getElementById("lblCustomerLogin").className = "f12c navNml noSep";
                if (document.getElementById("hidType").value == "1") {
                document.getElementById("lblTitle2").className = "f12c navNml noSep";
                }
                document.getElementById("divSearch").style.display = "";
                document.getElementById("divCustomer").style.display = "none";
                drobj = document.getElementById("drpRoleInfo");
                document.getElementById("hidDiv").value = "1";
                if (document.getElementById("hidType").value == "1") {
                    SelectRoleFunction(document.getElementById("drpRoleInfo"));
                    document.getElementById("divSearch").style.display = "none";
                }
                else {
                    SelectRoleForAdmin(selectId);
                }
            }
            else if (selectId == 3) {
            document.getElementById("lblTitle2").className = "f12e navNml navOn";
            document.getElementById("lblTitle").className = "f12c navNml noSep";
            document.getElementById("lblCustomerLogin").className = "f12c navNml noSep";
            document.getElementById("divSearch").style.display = "";
            document.getElementById("divCustomer").style.display = "none";
            drobj = document.getElementById("drpRoleInfo");
            document.getElementById("hidDiv").value = "3";
            SelectRoleFunction(document.getElementById("drpRoleInfo"));
            }
            else {
                document.getElementById("lblCustomerLogin").className = "f12e navNml navOn";
                document.getElementById("lblTitle").className = "f12c navNml noSep";
                if (document.getElementById("hidType").value == "1") {
              document.getElementById("lblTitle2").className = "f12c navNml noSep";
                }
                document.getElementById("divSearch").style.display = "none";
                document.getElementById("divCustomer").style.display = "";
                document.getElementById("hidDiv").value = "2";
                drobj = document.getElementById("drpRoleCustomer");
                SelectRoleForAdmin(selectId);
            }
        }
    </script>
</head>
<body onload="DivAutoSize(140);" onresize="DivAutoSize(140);">
    <form id="frmRoleFunction" runat="server">
    <div id="divForm">
        <div id="divTopNav">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="lblTitle" CssClass="f12e navNml navOn" runat="server" Text="<%$ Resources:lblTitle.Text %>"
                        onclick="SelectedDivl(1);" /></li>
                 <li>
                 <asp:Label ID="lblTitle2" CssClass="f12c navNml noSep" runat="server" Text="<%$ Resources:lblTitle2.Text %>"
                        onclick="SelectedDivl(3);" /></li>
                <li>
                    <asp:Label ID="lblCustomerLogin" CssClass="f12c navNml noSep" runat="server" Text="<%$ Resources:lblCustomerLogin %>"
                        onclick="SelectedDivl(2);" /></li>
            </ul>
        </div>
        <div id="popupMenu" class="skin" runat="server" onclick="ClickItem(event)" onmousemove="HighlighItem(event)"
            onmouseout="LowlightItem(event)">
        </div>
        <div class="divline" id="divSearch" runat="server">
            <asp:Label ID="lblRoleInfo" runat="server" Text="<%$ Resources:lblRoleInfo.Text %>" />
            <asp:DropDownList ID="drpRoleInfo" runat="server" Width="160px" />
            <asp:Label ID="lblRoleName" runat="server" Visible="False" />
            <asp:HiddenField ID="hidRoleId" runat="server" />
        </div>
        <div class="divline" id="divCustomer" style="display: none;">
            <asp:Label ID="lblRoleCustomer" runat="server" Text="<%$ Resources:lblRoleInfo.Text %>" />
            <asp:Label ID="lblCustomer" runat="server" />
        </div>
        <div id="divSource" style="height: 300px;">
            <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvwSource_RowDataBound"
                EnableViewState="False">
                <Columns>
                    <asp:TemplateField HeaderText="&lt;input type='checkbox' id='cbSelect' onclick='selectAll(this);'&gt;">
                        <ItemTemplate>
                            <input type="checkbox" id="chkSelect" runat="server" class="checkbox" value='<%# Bind("FunNo") %>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="colCheck taCenter" />
                        <HeaderStyle CssClass="colCheck taCenter " />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="<%$ Resources:BoundField1.HeaderText %>"
                        DataField="FunName">
                        <ItemStyle CssClass="colCode taLeft" />
                        <HeaderStyle CssClass="colCode taCenter " />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="<%$ Resources:TemplateField2.HeaderText %>">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkFun0" runat="server" />
                            <asp:CheckBox ID="chkFun1" runat="server" />
                            <asp:CheckBox ID="chkFun2" runat="server" />
                            <asp:CheckBox ID="chkFun3" runat="server" />
                            <asp:CheckBox ID="chkFun4" runat="server" />
                            <asp:CheckBox ID="chkFun5" runat="server" />
                            <asp:CheckBox ID="chkFun6" runat="server" />
                            <asp:CheckBox ID="chkFun7" runat="server" />
                            <asp:CheckBox ID="chkFun8" runat="server" />
                            <asp:CheckBox ID="chkFun9" runat="server" />
                            <asp:CheckBox ID="chkFun10" runat="server" />
                            <asp:CheckBox ID="chkFun11" runat="server" />
                            <asp:CheckBox ID="chkFun12" runat="server" />
                            <asp:CheckBox ID="chkFun13" runat="server" />
                            <asp:CheckBox ID="chkFun14" runat="server" />
                            <asp:CheckBox ID="chkFun15" runat="server" />
                        </ItemTemplate>
                        <ItemStyle CssClass="colFun taLeft" />
                        <HeaderStyle CssClass="colFun taCenter" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:TemplateField3.HeaderText %>">
                        <ItemTemplate>
                          <asp:TextBox ID="txtCondition0" runat="server" Width="97%" CssClass="txInput txtSearch" />
                          <asp:TextBox ID="txtCondition1" runat="server" Width="97%"  CssClass="txInput txtSearch" />
                          <asp:TextBox ID="txtCondition2" runat="server" Width="97%"  CssClass="txInput txtSearch" />
                          <asp:TextBox ID="txtCondition3" runat="server" Width="97%"  CssClass="txInput txtSearch" />
                          <asp:TextBox ID="txtCondition4" runat="server" Width="97%"  CssClass="txInput txtSearch" />
                          <asp:TextBox ID="txtCondition5" runat="server" Width="97%"  CssClass="txInput txtSearch" />
                        </ItemTemplate>
                        <ItemStyle CssClass="colFun taLeftBo" />
                        <HeaderStyle CssClass="colFun taCenter" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="Header" />
                <FooterStyle CssClass="Footer" />
                <RowStyle CssClass="Row" />
                <SelectedRowStyle CssClass="SelectRow" />
                <PagerStyle CssClass="Pager" />
                <AlternatingRowStyle CssClass="Alternating" />
            </asp:GridView>
            <asp:GridView ID="gvwSourceAdmin" runat="server" AutoGenerateColumns="False" EnableViewState="False">
                <Columns>
                    <asp:TemplateField HeaderText="&lt;input type='checkbox' id='cbSelect' onclick='selectAllAdmin(this);'&gt;">
                        <ItemTemplate>
                            <input type="checkbox" id="chkSelect" runat="server" class="checkbox" value='<%# Bind("FunNo") %>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="colCheck taCenter" />
                        <HeaderStyle CssClass="colCheck taCenter " />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="<%$ Resources:BoundField1.HeaderText %>" DataField="FunName">
                        <ItemStyle CssClass="colCode taLeft" />
                        <HeaderStyle CssClass="colCode taCenter " />
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
        <div id="divBottomNav">
            <asp:Button ID="btnOk" runat="server" CssClass="Button" Text="<%$ Resources:btnOk.Text %>"
                UseSubmitBehavior="False" />
            <asp:Button ID="btnBack" runat="server" CssClass="Button" Text="<%$ Resources:btnBack.Text %>"
                UseSubmitBehavior="False" Visible="False" />
            &nbsp
        </div>
    </div>
    <asp:HiddenField ID="hidType" runat="server" />
    <asp:HiddenField ID="hidDiv" runat="server" />
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
