<%@ Page Language="VB" AutoEventWireup="true" CodeFile="ScanEdit.aspx.vb" Inherits="ScanEdit" %>

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
    <link href="App_Themes/ScanEdit.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="JavaScript/ScanEdit.js" -->

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
                    <asp:Label ID="a1" runat="server" CssClass="f12e navNml navOn" Width="80px" onclick="SelectedScan(1,2);"
                        Text="<%$ Resources:a1 %>"></asp:Label></li>
                <li>
                    <li>
                        <asp:Label ID="a2" runat="server" CssClass="f12c navNml noSep" Width="80px" onclick="SelectedScan(2,2);"
                            Text="<%$ Resources:a2 %>"></asp:Label></li>
                    <li>
            </ul>
        </div>
        <div id="SaveHint" runat="server" class="Hint" style="left: 0px; top: 10px">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>" />
        </div>
        <div id="divMiddle4" runat="server">
            <div id="divSource" style="height: 320px;">
                <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvwSource_RowDataBound"
                    EnableViewState="False" Width="550px">
                    <Columns>
                        <asp:BoundField HeaderText="<%$ Resources:lblSortNo %>" DataField="SortNo">
                            <ItemStyle CssClass="colTable" Width="90px" />
                            <HeaderStyle CssClass="colTable" Width="90px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="<%$ Resources:lblType %>" DataField="Type">
                            <ItemStyle CssClass="colTable" Width="30px" />
                            <HeaderStyle CssClass="colTable" Width="90px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="<%$ Resources:lblQty %>" DataField="Qty">
                            <ItemStyle CssClass="colTable" Width="90px" />
                            <HeaderStyle CssClass="colTable" Width="90px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="<%$ Resources:lblContainerNo %>" DataField="ContainerNo">
                            <ItemStyle CssClass="colTable" Width="30px" />
                            <HeaderStyle CssClass="colTable" Width="90px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="<%$ Resources:lblCreateBy %>" DataField="CreateBy">
                            <ItemStyle CssClass="colTable" Width="90px" />
                            <HeaderStyle CssClass="colTable" Width="90px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="<%$ Resources:lblCreateDateTime %>" DataField="CreateDateTime">
                            <ItemStyle CssClass="colTable" Width="90px" />
                            <HeaderStyle CssClass="colTable" Width="90px" />
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
            <asp:HiddenField ID="hid_val" runat="server" Value="1" />
        </div>
        <div id="divBottomNav">
            <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose %>" CssClass="Button"
                UseSubmitBehavior="False" />&nbsp &nbsp &nbsp
        </div>
    </div>
    <asp:HiddenField ID="fldId" runat="server" />
    </form>
</body>
</html>
