<%@ Page Language="VB" AutoEventWireup="true" CodeFile="PersonList.aspx.vb" Inherits="PersonList" Culture="auto" meta:resourcekey="Page" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <base target="_self" ></base>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="JavaScript/PersonList.js" -->
    <!-- #include file="JavaScript/NoPaginationMultiSelect.js" -->
    <!-- #include file="../JavaScript/ResetSize.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
</head>
<body onload="ResetSize(1,0)">
    <form id="frmSelectPerson" runat="server">
        <div>
            <div id="divSearch">
                <div class="searchICO fLeft"></div>
                <asp:TextBox ID="txtSearch" runat="server" CssClass="fLeft txInput txtSearch" />
                <asp:Button ID="btnSearch" runat="server" CssClass="btnFnt" Text="<%$ Resources:btnSearch.Text %>" UseSubmitBehavior="False" />
            </div>
            <div id="divSource">
                <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                    CellPadding="0" OnRowDataBound="gvwSource_RowDataBound" >
                    <Columns>
                        <asp:TemplateField HeaderText="&lt;input type='checkbox' id='cbSelect' onclick='selectAll(this);'&gt;">
                            <ItemTemplate>
                                <input type="checkbox" id="chkUnSelect" runat="server" class="checkbox" value='<%# Bind("UserId") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="colCheck taCenter" />
                            <HeaderStyle CssClass="colCheck taCenter" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="<%$ Resources:BoundField1.HeaderText %>" DataField="No" >
                            <ItemStyle CssClass="colNo taLeft" />
                            <HeaderStyle CssClass="colNo taCenter " />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="<%$ Resources:BoundField2.HeaderText %>" DataField="UserNo" >
                            <ItemStyle CssClass="colCode taLeft" />
                            <HeaderStyle CssClass="colCode taCenter" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="<%$ Resources:BoundField3.HeaderText %>" DataField="UserName" HtmlEncode="False" >
                            <ItemStyle CssClass="colName taLeft" />
                            <HeaderStyle CssClass="colName taCenter" />
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
                <asp:Button ID="btnOk" runat="server" CssClass="btnFnt" Text="<%$ Resources:btnOk.Text %>" UseSubmitBehavior="False"  />
                <asp:Button ID="btnCancel" runat="server" CssClass="btnFnt" Text="<%$ Resources:btnCancel.Text %>" UseSubmitBehavior="False" />
            </div>
        </div>
    </form>
</body>
</html>
