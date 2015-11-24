<%@ Page Language="VB" AutoEventWireup="true" CodeFile="RoleInfoEdit.aspx.vb" Inherits="RoleInfoEdit"
    Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="../System/App_Themes/RoleInfoEdit.css" rel="Stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="../System/JavaScript/RoleInfoEdit.js" -->

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

</head>
<body onunload="CloseWindow();">
    <form id="frmRoleInfo" runat="server">
    <div id="divForm">
        <div id="divTopNav">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="a1" onclick="SelectedDiv(1,2)" CssClass="f12e navNml navOn" runat="server"
                        Text="<%$ Resources:a1.Text %>" /></li>
                <li>
                    <asp:Label ID="a2" onclick="SelectedDiv(2,2)" CssClass="f12c navNml noSep" runat="server"
                        Text="<%$ Resources:a2.Text %>" /></li>
            </ul>
        </div>
        <div id="SaveHint" runat="server" class="Hint">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>" />
        </div>
        <div id="divMiddle1">
            <div class="divline">
                <asp:Label ID="lblsRoleNo" runat="server" CssClass="Label" Text="<%$ Resources:lblsRoleNo.Text %>" />
                <asp:TextBox ID="txtsRoleNo" runat="server" CssClass="TextBox" MaxLength="4" />
            </div>
            <div class="divline">
                <asp:Label ID="lblsRoleName" runat="server" CssClass="Label" Text="<%$ Resources:lblsRoleName.Text %>" />
                <asp:TextBox ID="txtsRoleName" runat="server" CssClass="TextBox" MaxLength="20" />
            </div>
        </div>
        <div id="divMiddle2">
            <div id="divPerson">
                <asp:GridView ID="gvwPerson" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                    OnRowDataBound="gvwPerson_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="No" HeaderText="<%$ Resources:BoundField1.HeaderText %>">
                            <ItemStyle CssClass="colNo taLeft" />
                            <HeaderStyle CssClass="colNo taCenter " />
                        </asp:BoundField>
                        <asp:BoundField DataField="UserNo" HeaderText="<%$ Resources:BoundField2.HeaderText %>">
                            <ItemStyle CssClass="colName taLeft" />
                            <HeaderStyle CssClass="colName taCenter" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UserName" HeaderText="<%$ Resources:BoundField3.HeaderText %>">
                            <ItemStyle CssClass="colName taLeft" />
                            <HeaderStyle CssClass="colName taCenter" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemStyle CssClass="colEdit taCenter" />
                            <HeaderStyle CssClass="colEdit taCenter " />
                            <ItemTemplate>
                                <asp:Image ID="imgDelete" runat="server" AlternateText="<%$ Resources:imgDelete.AlternateText %>"
                                    CssClass="delImg" ImageUrl="~/Images/Edit/ed_delete.gif" />
                                <asp:Image ID="imgInsert" runat="server" AlternateText="<%$ Resources:imgInsert.AlternateText %>"
                                    CssClass="delImg" ImageUrl="~/Images/Edit/ed_Insert.gif" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="Row" />
                    <SelectedRowStyle CssClass="SelectRow" />
                    <PagerStyle CssClass="Pager" />
                    <HeaderStyle CssClass="Header" />
                    <FooterStyle CssClass="Footer" />
                    <AlternatingRowStyle CssClass="Alternating" />
                </asp:GridView>
            </div>
        </div>
        <div id="divBottomNav">
            <asp:Button ID="btnNew" runat="server" Text="<%$ Resources:btnNew.Text %>" CssClass="Button"
                UseSubmitBehavior="False" />
            <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:btnSave.Text %>" CssClass="Button"
                UseSubmitBehavior="False" />
            <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose.Text %>" CssClass="Button"
                UseSubmitBehavior="False" />&nbsp
        </div>
    </div>
    <asp:HiddenField ID="hidUser" runat="server" />
    <asp:HiddenField ID="fldId" runat="server" />
    </form>
</body>
</html>
