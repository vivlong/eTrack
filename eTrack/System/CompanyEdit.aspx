<%@ Page Language="VB" AutoEventWireup="true" CodeFile="CompanyEdit.aspx.vb" Inherits="CompanyEdit" Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="../System/App_Themes/CompanyEdit.css" rel="Stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="../System/JavaScript/CompanyEdit.js" -->
        <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
</head>
<body onunload="CloseWindow();">
    <form id="frmCompany" runat="server">
        <div id="divForm">
            <div id="divTopNav">
    	        <ul id="ulTopNav">
                    <li><asp:Label ID="a1" CssClass ="f12e navNml navOn" runat="server" onclick="SelectedDiv(1,2)" Text ="<%$ Resources:lblPage1.Text %>" ></asp:Label></li>
                    <li><asp:Label ID="a2" CssClass ="f12c navNml noSep" runat="server" onclick="SelectedDiv(2,2)" Text ="<%$ Resources:lblPage2.Text %>" ></asp:Label></li>
                </ul>
            </div>
            <div id="SaveHint" runat="server" class="Hint" >            
                <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>"> </asp:Label>
            </div>   
            <div id="divMiddle1" class="divBorder">
                <div class="divline">
                    <asp:Label ID="lblsCompNo" runat="server" CssClass="Label" Text ="<%$ Resources:lblsCompNo.Text %>" ></asp:Label>
                    <asp:TextBox ID="txtsCompNo" runat="server" CssClass="TextBox" ></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblsCnCompPartName" runat="server" CssClass="Label " Text="<%$ Resources:lblsCnCompPartName.Text %>"></asp:Label>
                    <asp:TextBox ID="txtsCnCompPartName" runat="server" CssClass="TextBox"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblsCnCompName" runat="server" CssClass="Label" Text="<%$ Resources:lblsCnCompName.Text %>"></asp:Label>
                    <asp:TextBox ID="txtsCnCompName" runat="server" CssClass="TextBox" ></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblsCnCompAddr" runat="server" CssClass="Label" Text="<%$ Resources:lblsCnCompAddr.Text %>"></asp:Label>
                    <asp:TextBox ID="txtsCnCompAddr" runat="server" CssClass="TextBox" ></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblsCompTel" runat="server" CssClass="Label" Text="<%$ Resources:lblsCompTel.Text %>"></asp:Label>
                    <asp:TextBox ID="txtsCompTel" runat="server" CssClass="TextBox" ></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblsCompFax" runat="server" CssClass="Label" Text="<%$ Resources:lblsCompFax.Text %>"></asp:Label>
                    <asp:TextBox ID="txtsCompFax" runat="server" CssClass="TextBox" ></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblsCompZip" runat="server" CssClass="Label" Text="<%$ Resources:lblsCompZip.Text %>"></asp:Label>
                    <asp:TextBox ID="txtsCompZip" runat="server" CssClass="TextBox"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblsCompWeb" runat="server" CssClass="Label" Text="<%$ Resources:lblsCompWeb.Text %>"></asp:Label>
                    <asp:TextBox ID="txtsCompWeb" runat="server" CssClass="TextBox" ></asp:TextBox>
                </div>
                
            </div>
            <div id="divMiddle2" class="divBorder">
                <div class="divline">
                    <asp:Label ID="lblsCompEmail" runat="server" CssClass="Label" Text="<%$ Resources:lblsCompEmail.Text %>"></asp:Label>
                    <asp:TextBox ID="txtsCompEmail" runat="server" CssClass="TextBox" ></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblsSmtpServer" runat="server" CssClass="Label" Text="<%$ Resources:lblsSmtpServer.Text %>"></asp:Label>
                    <asp:TextBox ID="txtsSmtpServer" runat="server" CssClass="TextBox" ></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblsSmtpPort" runat="server" CssClass="Label" Text="<%$ Resources:lblsSmtpPort.Text %>"></asp:Label>
                    <asp:TextBox ID="txtsSmtpPort" runat="server" CssClass="TextBox"  ></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblsSmtpUser" runat="server" CssClass="Label" Text="<%$ Resources:lblsSmtpUser.Text %>"></asp:Label>
                    <asp:TextBox ID="txtsSmtpUser" runat="server" CssClass="TextBox" ></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblsSmtpPassword" runat="server" CssClass="Label" Text="<%$ Resources:lblsSmtpPassword.Text %>"></asp:Label>
                    <asp:TextBox ID="txtsSmtpPassword" runat="server" CssClass="TextBox"  TextMode="Password"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblsConfirmPassword" runat="server" CssClass="Label" Text="<%$ Resources:lblsConfirmPassword.Text %>"></asp:Label>
                    <asp:TextBox ID="txtsConfirmPassword" runat="server" CssClass="TextBox" TextMode="Password" ></asp:TextBox>
                </div>
            </div>
            <div id="divBottomNav">
                <asp:Button ID="btnNew" runat="server" Text="<%$ Resources:btnNew.Text %>" CssClass="Button" UseSubmitBehavior="False" />
                <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:btnSave.Text %>" CssClass="Button" UseSubmitBehavior="False" />
                <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose.Text %>" CssClass="Button" UseSubmitBehavior="False" />
            </div>
        </div>        
        <asp:HiddenField ID="fldId" runat="server" />
    </form>
</body>
</html>
