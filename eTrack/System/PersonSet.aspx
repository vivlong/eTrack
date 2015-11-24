<%@ Page Language="VB" AutoEventWireup="true" CodeFile="PersonSet.aspx.vb" Inherits="PersonSet"
    Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/PersonSet.css" rel="stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="JavaScript/PersonSet.js" -->

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

</head>
<body>
    <form id="frmPersonsSet" runat="server">
    <div id="divForm">
        <div id="divTopNav" style="width: 100%">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="lblTitle" CssClass="f12e navNml navOn" runat="server" Text="<%$ Resources:Page.Title %>"></asp:Label></li>
            </ul>
        </div>
        <div id="divMiddle" class="divBorder" style="width: 99.5%">
            <div class="divline">
                <asp:Label ID="lblFirstPage" runat="server" CssClass="Label" Text="<%$ Resources:lblFirstPage.Text %>"></asp:Label>
                <asp:DropDownList ID="drpFirstPage" runat="server">
                </asp:DropDownList>
            </div>
            <div class="divline" style="display: none">
                <asp:CheckBox ID="chkDisplaySmsHint" runat="server" Text="<%$ Resources:chkDisplaySmsHint.Text %>"
                    CssClass="CheckBox" />
            </div>
            <div class="divline">
                <asp:Label ID="lblInfoSize" runat="server" CssClass="Label" Text="<%$ Resources:lblInfoSize.Text %>"></asp:Label>
                <asp:TextBox ID="txtInfoSize" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
            <div class="divline">
                <asp:Label ID="lblSearchSize" runat="server" CssClass="Label" Text="<%$ Resources:lblSearchSize.Text %>"></asp:Label>
                <asp:TextBox ID="txtSearchSize" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
            <div class="divline">
                <asp:Label ID="lblOpenSize" runat="server" CssClass="Label" Text="<%$ Resources:lblOpenSize.Text %>"></asp:Label>
                <asp:TextBox ID="txtOpenSize" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
            <div class="divline">
                <asp:Label ID="lblDetailSize" runat="server" CssClass="Label" Text="<%$ Resources:lblDetailSize.Text %>"></asp:Label>
                <asp:TextBox ID="txtDetailSize" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
            <div class="divline">
                <asp:Label ID="lblStatSize" runat="server" CssClass="Label" Text="<%$ Resources:lblStatSize.Text %>"></asp:Label>
                <asp:TextBox ID="txtStatSize" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
        </div>
        <div id="divBottomNav" style="width: 100%">
            <asp:Button ID="btnOk" runat="server" Text="<%$ Resources:btnOk.Text %>" CssClass="Button fleft"
                UseSubmitBehavior="False" />&nbsp
        </div>
    </div>
    <asp:HiddenField ID="txtUserId" runat="server" />
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
    //    document.onclick = HideMenu;
    document.ondblclick = nodblClick;
</script>

