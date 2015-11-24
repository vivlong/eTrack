<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VesselScheduleDetail.aspx.vb"
    Inherits="VesselSchedule_VesselScheduleDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/VesselScheduleDetail.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/Print.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="JavaScript/SeaFreightEdit.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>

</head>
<body onunload="CloseWindow();">
    <form id="frmSeaFreightEdit" runat="server">
    <div id="divForm">
        <div id="divTopNav">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="a1" CssClass="f12e navNml navOn" runat="server" Text="<%$ Resources:a1.Text %>"></asp:Label></li><%--Text="<%$ Resources:a1.Text %>"--%>
            </ul>
        </div>
        <div id="SaveHint" runat="server" class="Hint">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>"> </asp:Label>
        </div>
        <div id="divMiddle1" class="divBorder">
            <div class="divline">
                <asp:Label ID="lblVesselVoyage" runat="server" CssClass="Label" Text="<%$ Resources:lblVesselVoyage %>"></asp:Label>
                <asp:TextBox ID="txtVesselVoyage" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
            <div class="divline">
                <asp:Label ID="lbPortOfDischarge" runat="server" CssClass="Label" Text="<%$ Resources:lbPortOfDischarge %>"></asp:Label>
                <asp:TextBox ID="txtPortOfDischarge" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
            <div class="divline">
                <asp:Label ID="lblDepartureDate" runat="server" CssClass="Label" Text="<%$ Resources:lblDepartureDate %>"></asp:Label>
                <asp:TextBox ID="txtDepartureDate" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
            <div class="divline">
                <asp:Label ID="lblArrivalDate" runat="server" CssClass="Label" Text="<%$ Resources:lblArrivalDate %>"></asp:Label>
                <asp:TextBox ID="txtArrivalDate" runat="server" CssClass="TextBox"></asp:TextBox>
            </div>
            
        </div>
        <div id="divBottomNav">
            <div id="div_con" style="display: none">
                <asp:Button ID="btnAdd" runat="server" Text="<%$ Resources:btnAdd.Text %>" CssClass="Button"
                    UseSubmitBehavior="False" Visible="False" />
                <asp:Button ID="btnNew" runat="server" Text="<%$ Resources:btnNew.Text %>" CssClass="Button"
                    UseSubmitBehavior="False" />
                <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:btnSave.Text %>" CssClass="Button"
                    UseSubmitBehavior="False" />
                <asp:Button ID="btnPrint" runat="server" Text="<%$ Resources:btnPrint.Text %>" CssClass="Button"
                    UseSubmitBehavior="False" />
                <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose.Text %>" CssClass="Button"
                    UseSubmitBehavior="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="fldId" runat="server" />
    </form>
</body>
</html>
