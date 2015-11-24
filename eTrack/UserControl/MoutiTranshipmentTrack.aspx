<%@ Page Language="VB" AutoEventWireup="true" CodeFile="MoutiTranshipmentTrack.aspx.vb"
    Inherits="MoutiTranshipmentTrack" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>More Container No</title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/js_lzw.js" -->
    <!-- #include file="JavaScript/NoPaginationSingleSelect.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script language="javascript" type="text/javascript">
        function GetQuery() {
            //by lzw
            strQuery = document.getElementById("txtSearch").value;
            var objSearchField = document.getElementById("drpSearch");
            if (objSearchField) {
                var arrFieldName = objSearchField.options[objSearchField.selectedIndex].value.split(",");
                if (arrFieldName[1] == "0") {
                    if (strQuery == " ") {
                        strQuery = " and (" + arrFieldName[0] + " is null or " + arrFieldName[0] + "='') ";

                    }
                    else { strQuery = "  and " + arrFieldName[0] + " like '%" + strQuery + "%' "; }
                }
                else {
                    if (strQuery == " ") {
                        strQuery = "  and (" + arrFieldName[0] + " is null or " + arrFieldName[0] + "='') ";
                    }
                    else { strQuery = "  and Cast(" + arrFieldName[0] + " as NVarChar(50))" + " like '%" + strQuery + "%' "; }
                }
            }
            strQuery = strWhere + strQuery;
        }
        function killerrors() {
            return true;
        }
        window.onerror = killerrors; 
    </script>
</head>
<body>
    <form id="frmAirline" runat="server">
    <div id="divTopNav">
        <ul id="ulTopNav">
            <li>
                <asp:Label ID="a1" CssClass="f12e navNml navOn" runat="server" Text="Container No List"
                    Width="116px"></asp:Label></li>
        </ul>
    </div>
    <div id="MsgBox">
        <div class="bar">
            <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:Message, LoadTitleHint %>"></asp:Label>
        </div>
        <div class="content">
            <img alt="" src="../images/load.gif" style="text-align: center; vertical-align: middle" />&nbsp;
            &nbsp;<asp:Label ID="lblMessage" runat="server" Text="<%$ Resources:Message, LoadDataHint %>"></asp:Label>
        </div>
    </div>
    <div id="divSource" style="height: 480px;">
        <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvwSource_RowDataBound"
            EnableViewState="False" Width="600px">
            <Columns>
                <asp:BoundField HeaderText="Trx No" DataField="TrxNo">
                    <ItemStyle CssClass="colNo taLeft" Width="20px" />
                    <HeaderStyle CssClass="colNo taCenter " Width="20px" />
                </asp:BoundField>
            </Columns>
            <Columns>
                <asp:BoundField HeaderText="ContainerNo" DataField="ContainerNo">
                    <ItemStyle CssClass="colNo taLeft" Width="200px" />
                    <HeaderStyle CssClass="colNo taCenter " Width="200px" />
                </asp:BoundField>
            </Columns>
            <Columns>
                <asp:BoundField HeaderText="House B/L No" DataField="BlNo">
                    <ItemStyle CssClass="colNo taLeft" Width="200px" />
                    <HeaderStyle CssClass="colNo taCenter " Width="200px" />
                </asp:BoundField>
            </Columns>
            <Columns>
                <asp:BoundField HeaderText="ETA Singapore" DataField="EtaDate">
                    <ItemStyle CssClass="colNo taLeft" Width="200px" />
                    <HeaderStyle CssClass="colNo taCenter " Width="200px" />
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
        <input type="button" id="btnAll" runat="server" style="width: 100px" class="Button"
                         value="<%$ Resources:btnAll.Text %>" />
        <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose.Text %>" CssClass="Button"
            UseSubmitBehavior="False" />
            
    </div>
    <asp:HiddenField ID="hid_val" runat="server" Value="1" />
    </form>
</body>
</html>
