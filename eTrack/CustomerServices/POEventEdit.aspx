<%@ Page Language="VB" AutoEventWireup="true" CodeFile="POEventEdit.aspx.vb" Inherits="EventEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <base target="_self"></base>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/Calendar.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/POEventEdit.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="JavaScript/POEventEdit.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"> </script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>

</head>
<body>
    <form id="frmBookingFormEdit" runat="server">
    <div id="divForm">
        <div id="MsgBox">
            <div class="bar">
                <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:Message, LoadTitleHint %>"></asp:Label>
            </div>
        </div>
        <div id="SaveHint" runat="server" class="Hint" style="left: 0px; top: 10px">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>" />
        </div>
        <div id="divMiddle1" runat="server" class="divBorder divTab" style="height: 300px;
            width: 100%; padding-left: 20px; padding-top: 10px;">
            <div class="divLeft">
                <div class="divline">
                    <asp:Label ID="lblEventDate" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblEventDate %>" />
                    <asp:TextBox ID="txtEventDate" runat="server" CssClass="TextBox txtDate" MaxLength="13" />
                    <asp:Button ID="btnEventDate" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />dd/mm/yyyy
                </div>
                <div class="divline">
                    <asp:Label ID="lblEventTitle" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblEventTitle %>" />
                    <asp:TextBox ID="txtEventTitle" runat="server" CssClass="TextBox txt" 
                        MaxLength="50" Width="269px" />                    <asp:Button ID="btnEventTitle" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblComments" runat="server" Text="<%$ Resources:lblComments %>" CssClass="Label lbl" />
                    <asp:TextBox ID="txtComments" runat="server" CssClass="TextBox txt" MaxLength="80"
                        TextMode="MultiLine" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblNotifyUsers" runat="server" Text="<%$ Resources:lblNotifyUsers %>"
                        CssClass="Label lbl" />
                    <asp:CheckBox ID="chkNotifyUsers" runat="server" />
                </div>
            </div>
        </div>
        <div id="divBottomNav" runat="server">
            <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:btnSave %>" CssClass="Button"
                UseSubmitBehavior="False" />
            <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose %>" CssClass="Button"
                UseSubmitBehavior="False" />&nbsp &nbsp &nbsp
        </div>
    </div>
    <asp:HiddenField ID="fldId" runat="server" />
    <asp:HiddenField ID="fldLineItemNo" runat="server" Value ="-1" />
    </form>
</body>
</html>
