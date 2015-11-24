<%@ Page Language="VB" AutoEventWireup="true" CodeFile="PasswordEdit.aspx.vb" Inherits="PasswordEdit"
    Culture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/PasswordEdit.css" rel="Stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="JavaScript/PasswordEdit.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

</head>
<body>
    <form id="frmPasswordEdit" runat="server">
    <div id="divForm" style="text-align: center;">
        <div id="divMiddle" style="width: 99.5%">
            <div class="divline">
                <asp:Label ID="lblsPasswordOld" runat="server" CssClass="Label" Text="<%$ Resources:lblsPasswordOld.Text %>"></asp:Label>
                <asp:TextBox ID="txtsPasswordOld" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
            </div>
            <div class="divline">
                <asp:Label ID="lblsPassword1" runat="server" CssClass="Label" Text="<%$ Resources:lblsPassword1.Text %>"></asp:Label>
                <asp:TextBox ID="txtsPassword1" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
            </div>
            <div class="divline">
                <asp:Label ID="lblsPassword2" runat="server" CssClass="Label" Text="<%$ Resources:lblsPassword2.Text %>"></asp:Label>
                <asp:TextBox ID="txtsPassword2" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
            </div>
        </div>
    </div>
    <div id="divBottomNav" style="width: 100%">
        <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:btnSave.Text %>" CssClass="Button fleft"
            UseSubmitBehavior="False" />
        <asp:Button ID="btnClear" runat="server" Text="<%$ Resources:btnClear.Text %>" CssClass="Button fright"
            UseSubmitBehavior="False" />&nbsp
    </div>
    <asp:HiddenField ID="fldUserNo" runat="server" />
    <asp:HiddenField ID="fldPassword" runat="server" />
    <asp:HiddenField ID="fldTable" runat="server" />
    </form>
</body>
</html>
