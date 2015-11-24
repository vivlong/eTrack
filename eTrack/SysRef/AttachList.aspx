<%@ Page Language="VB" AutoEventWireup="true" CodeFile="AttachList.aspx.vb" Inherits="AttachList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <base target="_self"></base>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="JavaScript/AttachList.js" -->

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

</head>
<body onunload="CloseWindow();return false" onload="ChangeHeight('divAttach',632,380);" >
    <form id="frmAttachList" runat="server">
    <div id="divForm">
        <div id="divTopNav" style="width: 640px">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="a3" CssClass="f12e navNml navOn" runat="server" Text="<%$ Resources:a1 %>" /></li>
            </ul>
        </div>
        <div id="SaveHint" runat="server" class="Hint" style="left: 0px; top: 10px">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>" />
        </div>
        <div id="divAttach" class="divBorder divAttach" style="padding-left: 3px; padding-top: 3px">
            <asp:GridView ID="gvwAttach" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                OnRowDataBound="gvwAttach_RowDataBound" Width="610">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="imgDelete" runat="server" ImageUrl="~/Images/Edit/ed_delete.gif" CssClass="delImg" />
                            <asp:Image ID="imgInsert" runat="server" ImageUrl="~/Images/Edit/ed_Insert.gif" CssClass="delImg" /><%--AlternateText="<%$ Resources:imgInsert.AlternateText %>"--%>
                        </ItemTemplate>
                        <ItemStyle CssClass="colEdit taCenter" />
                        <HeaderStyle CssClass="colEdit taCenter " />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="<%$ Resources:BoundField1.HeaderText %>" DataField="No">
                        <ItemStyle CssClass="colNo taLeft" Width="30px" />
                        <HeaderStyle CssClass="colNo taCenter " Width="30px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="<%$ Resources:BoundField2.HeaderText %>" DataField="ReferenceFileName"
                        HtmlEncode="False">
                        <ItemStyle CssClass="colFileName taLeft" />
                        <HeaderStyle CssClass="colFileName taCenter" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="<%$ Resources:BoundField3.HeaderText %>" DataField="FileSize"
                        DataFormatString="{0:#,##0}" HtmlEncode="False">
                        <ItemStyle CssClass="colFileSize taRight" />
                        <HeaderStyle CssClass="colFileSize taCenter" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="<%$ Resources:BoundField4.HeaderText %>" DataField="FileDate"
                        DataFormatString="{0:yyyy-MM-dd HH:mm}" HtmlEncode="False">
                        <ItemStyle CssClass="colFileDate taLeft" />
                        <HeaderStyle CssClass="colFileDate taCenter" />
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
        <div id="divBottomNav" style="padding-right: 5px; padding-top: 5px; text-align:right;">
            <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose.Text %>" CssClass="Button"
                UseSubmitBehavior="False" />
        </div>
        <asp:HiddenField ID="hidId" runat="server" />
        <asp:HiddenField ID="hidFolder" runat="server" />
    </div>
    </form>
</body>
</html>
