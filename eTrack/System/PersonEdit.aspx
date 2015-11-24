<%@ Page Language="VB" AutoEventWireup="true" CodeFile="PersonEdit.aspx.vb" Inherits="PersonEdit"
    Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="../System/App_Themes/PersonEdit.css" rel="Stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="../System/JavaScript/PersonEdit.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>
</head>
<body onunload="CloseWindow();">
    <form id="frmPersonsEdit" runat="server">
    <div id="divForm">
        <div id="divTopNav">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="a1" onclick="SelectedDiv(1,2)" CssClass="f12e navNml navOn" runat="server"
                        Text="<%$ Resources:a1.Text %>"></asp:Label></li>
                <li>
                    <asp:Label ID="a2" onclick="SelectedDiv(2,2)" CssClass="f12c navNml noSep" runat="server"
                        Text="<%$ Resources:a3.Text %>"></asp:Label></li>
            </ul>
        </div>
        <div id="SaveHint" runat="server" class="Hint">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>"> </asp:Label>
        </div>
        <div id="divMiddle1">
            <div  class="divline">
                <asp:HiddenField ID="hid_No" runat="server" />
            </div>
            <div class="divline">
            </div>
            <div class="divline">
                <asp:Label ID="lblsUserNo" runat="server" CssClass="Label" Text="<%$ Resources:lblsUserNo.Text %>"></asp:Label>
                <asp:TextBox ID="txtsUserNo" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
            <div class="divline">
                <asp:Label ID="lblsUserName" runat="server" CssClass="Label" Text="<%$ Resources:lblsUserName.Text %>"></asp:Label>
                <asp:TextBox ID="txtsUserName" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
            <div class="divline">
                <asp:Label ID="lblsPassword" runat="server" CssClass="Label" Text="<%$ Resources:lblsPassword.Text %>"></asp:Label>
                <asp:TextBox ID="txtsPassword" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
            </div>
            <div class="divline">
                <asp:Label ID="lblPassword" runat="server" CssClass="Label" Text="<%$ Resources:lblPassword.Text %>"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <div id="divMiddle2" class="divBorder">
            <div id="divRole">
                <asp:GridView ID="gvwRoleInfo" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                    OnRowDataBound="gvwRoleInfo_RowDataBound" CssClass="GvwView">
                    <Columns>
                        <asp:BoundField HeaderText="<%$ Resources:BoundField11.HeaderText %>" DataField="No">
                            <ItemStyle CssClass="colNo taLeft" Width="30px" />
                            <HeaderStyle CssClass="colNo taCenter " Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="<%$ Resources:BoundField12.HeaderText %>" DataField="RoleNo">
                            <ItemStyle CssClass="colCode taLeft" />
                            <HeaderStyle CssClass="colCode taCenter" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="<%$ Resources:BoundField13.HeaderText %>" DataField="RoleName">
                            <ItemStyle CssClass="colName taLeft" />
                            <HeaderStyle CssClass="colName taCenter" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="imgDelete" runat="server" AlternateText="Delete" ImageUrl="~/Images/Edit/ed_delete.gif"
                                    CssClass="delImg" />
                                <asp:Image ID="imgInsert" runat="server" AlternateText="Add" ImageUrl="~/Images/Edit/ed_Insert.gif"
                                    CssClass="delImg" />
                            </ItemTemplate>
                            <ItemStyle CssClass="colEdit taCenter" />
                            <HeaderStyle CssClass="colEdit taCenter " />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="Header" />
                    <FooterStyle CssClass="Footer" />
                    <RowStyle CssClass="Row" />
                    <SelectedRowStyle CssClass="SelectRow" />
                    <PagerStyle CssClass="Pager" />
                    <AlternatingRowStyle CssClass="Alternating" />
                </asp:GridView>
            </div>
        </div>
        <div id="divBottomNav">
            <asp:Button ID="btnNew" runat="server" Text="<%$ Resources:btnNew.Text %>" CssClass="Button"
                UseSubmitBehavior="False" Visible=false />
            <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:btnSave.Text %>" CssClass="Button"
                UseSubmitBehavior="False" />
            <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose.Text %>" CssClass="Button"
                UseSubmitBehavior="False" />&nbsp
        </div>
    </div>
    <asp:HiddenField ID="fldId" runat="server" />
    </form>
</body>
</html>
