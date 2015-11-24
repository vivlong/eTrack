<%@ Page Language="VB" AutoEventWireup="true" CodeFile="IssueEdit.aspx.vb" Inherits="IssueEdit" %>

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
    <link href="App_Themes/IssueEdit.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="JavaScript/IssueEdit.js" -->
    
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"> </script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

</head>
<body>
    <form id="frmIssueFormEdit" runat="server">
    <div id="divForm">
        <div id="divTopNav" runat="server" style="width: 100%">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="a1" runat="server" CssClass="f12e navNml navOn" Width="165px" onclick="SelectedDiv(1,4);SetTab(1);"
                        Text="<%$ Resources:a1 %>"></asp:Label></li>
                <li>
            </ul>
        </div>
        <div id="SaveHint" runat="server" class="Hint" style="left: 0px; top: 10px">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>" />
        </div>
        <div id="divMiddle4" runat="server">
            <div id="divSource" style="height: 320px;">
                <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvwSource_RowDataBound"
                    EnableViewState="False" Width="500px">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a id="Img2" runat="server" alt="del">
                                    <img id="Img3" runat="server" src="../Images/Edit/ed_Delete.gif" alt="del" />
                                </a>
                                <asp:HiddenField ID="hid_TrxNo" runat="server" Value='<%# Eval("TrxNo") %>' />
                                <asp:HiddenField ID="hid_LineItemNo" runat="server" Value='<%# Eval("LineItemNo") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="colNo taLeft" />
                            <HeaderStyle CssClass="colNo taCenter" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date (dd/MM/yyyy)" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtDate" runat="server" Text='<%# Eval("Date") %>' CssClass=" TextBox" MaxLength="10"
                                    Width="100px" />
                            </ItemTemplate>
                            <ItemStyle CssClass="colTable taLeft" />
                            <HeaderStyle CssClass="colTable taCenter" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty" >
                            <ItemTemplate>
                                <asp:TextBox ID="txtPackingQty" runat="server" Text='<%# Eval("PackingQty") %>'
                                    CssClass="TextBox" MaxLength="4"   Width="100px"/>
                            </ItemTemplate>
                            <ItemStyle CssClass="colTable taLeft" />
                            <HeaderStyle CssClass="colTable taCenter" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remark">
                            <ItemTemplate>
                                <asp:TextBox ID="txtRemark" runat="server" Text='<%# Eval("Remark") %>' CssClass="TextBox"
                                    MaxLength="1000" Width="260px"/>
                            </ItemTemplate>
                            <ItemStyle CssClass="colFieldName taLeft" />
                            <HeaderStyle CssClass="colFieldName taCenter" />
                            <FooterStyle CssClass="taRight" />
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
            <asp:HiddenField ID="hid_val" runat="server" Value="1" />
        </div>
        <div id="divBottomNav">
            <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:btnSave %>" CssClass="Button"
                UseSubmitBehavior="False" /> 
            <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose %>" CssClass="Button"
                UseSubmitBehavior="False" />&nbsp &nbsp &nbsp
        </div>
    </div>
    <asp:HiddenField ID="fldId" runat="server" />
    <div id="divSupplier">
        <asp:HiddenField ID="hidSupplier" runat="server" />
    </div>
    </form>
</body>
</html>
