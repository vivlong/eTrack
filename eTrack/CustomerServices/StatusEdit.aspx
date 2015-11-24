<%@ Page Language="VB" AutoEventWireup="true" CodeFile="StatusEdit.aspx.vb" Inherits="StatusEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/StatusEdit.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/Calendar.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="JavaScript/StatusEdit.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"> </script>  
        <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>  
</head>
<body onunload="CloseWindow();">
    <form id="frmStatusEdit" runat="server">
        <div id="divForm">
            <div id="divTopNav">
                <ul id="ulTopNav">
                    <li><asp:Label ID="lblPage" CssClass ="f12e navNml navOn" runat="server" Text ="<%$ Resources:lblPage.Text %>"></asp:Label></li>
                </ul>
            </div>
            <div id="SaveHint" runat="server" class="Hint" >            
                <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>"> </asp:Label>
            </div>
            <div id="divMiddle1" class="divBorder">
                <div class="divline">
                    <asp:Label ID="lblJobNo" runat="server" CssClass="Label" Text="<%$ Resources:lblJobNo.Text %>" ></asp:Label>
                    <asp:TextBox ID="txtJobNo" runat="server" CssClass="TextBox" ></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblDateTime" runat="server" CssClass="Label" Text="<%$ Resources:lblDateTime.Text %>" ></asp:Label>
                    <asp:TextBox ID="txtDateTime" runat="server" CssClass="TextBox" ></asp:TextBox>
                    <asp:Button ID="btnDateTime" runat="server" CssClass="Button" Text="..." UseSubmitBehavior="False"/>
                </div>
                <div class="divline">
                    <asp:Label ID="lblDescription" runat="server" CssClass="Label" Text="<%$ Resources:lblDescription.Text %>" ></asp:Label>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="TextBox" ></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblRefNo" runat="server" CssClass="Label" Text="<%$ Resources:lblRefNo.Text %>" ></asp:Label>
                    <asp:TextBox ID="txtRefNo" runat="server" CssClass="TextBox"  ></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblStatusCode" runat="server" CssClass="Label" Text="<%$ Resources:lblStatusCode.Text %>" ></asp:Label>
                    <asp:DropDownList ID="drpStatusCode" runat="server"> 
                    </asp:DropDownList>   
                </div>
            </div>
            <div id="divBottomNav">
                <asp:Button ID="btnNew" runat="server" Text ="<%$ Resources:btnNew.Text %>" CssClass="Button" UseSubmitBehavior="False"/>
                <asp:Button ID="btnSave" runat="server" Text ="<%$ Resources:btnSave.Text %>" CssClass="Button" UseSubmitBehavior="False" />
                <asp:Button ID="btnClose" runat="server" Text ="<%$ Resources:btnClose.Text %>" CssClass="Button" UseSubmitBehavior="False"/>
            </div>
        </div>
        <asp:HiddenField ID="fldId" runat="server" />
        <asp:HiddenField ID="fldUpdateBy" runat="server" />
        <asp:HiddenField ID="fldUpdateDateTime" runat="server" />
    </form>
</body>
</html>
