<%@ Page Language="VB" AutoEventWireup="true" CodeFile="EquipmentTypeEdit.aspx.vb"
    Inherits="EquipmentTypeEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/EquipmentTypeEdit.css" rel="Stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/PageControl.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="JavaScript/EquipmentTypeEdit.js" -->

    <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

    <script language="javascript" type="text/javascript">
    function on_page_loaded()
    {   
      blChanged=true;CloseWindow(0);return false;
    }
    </script>

</head>
<body onunload="on_page_loaded()">
    <form id="frmTankTypeEdit" runat="server">
    <div id="divForm">
        <div id="divTopNav">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="a1" CssClass="f12e navNml navOn" runat="server" Text="<%$ Resources:a1 %>"></asp:Label></li>
            </ul>
        </div>
        <div id="SaveHint" runat="server" class="Hint">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>"> </asp:Label>
        </div>
        <div id="divMiddle1" class="divBorder">
            <div class="divline">
                <asp:Label ID="lblContainerType" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblContainerType %>" />
                <asp:TextBox ID="txtContainerType" runat="server" CssClass="TextBox txt" MaxLength="5" />
            </div>
            <div class="divline">
                <asp:Label ID="lblExternalLength" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblExternalLength %>" />
                <asp:TextBox ID="txtExternalLength" runat="server" CssClass="TextBox txt alignRight"
                    MaxLength="14" />
                <asp:Label ID="lblLengthTip" runat="server" CssClass="Label" Text="mm" />
            </div>
            <div class="divline">
                <asp:Label ID="lblExternalWidth" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblExternalWidth %>" />
                <asp:TextBox ID="txtExternalWidth" runat="server" CssClass="TextBox txt alignRight"
                    MaxLength="14" />
                <asp:Label ID="lblBreadthTip" runat="server" CssClass="Label" Text="mm" />
            </div>
            <div class="divline">
                <asp:Label ID="lblExternalHeight" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblExternalHeight %>" />
                <asp:TextBox ID="txtExternalHeight" runat="server" CssClass="TextBox txt  alignRight"
                    MaxLength="14" />
                <asp:Label ID="lblHeightTip" runat="server" CssClass="Label" Text="mm" />
            </div>
            <div class="divline">
                <asp:Label ID="lblInternalLength" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblInternalLength %>" />
                <asp:TextBox ID="txtInternalLength" runat="server" CssClass="TextBox txt alignRight"
                    MaxLength="14" />
                <asp:Label ID="lblInternalLengthTip" runat="server" CssClass="Label" Text="mm" />
            </div>
            <div class="divline">
                <asp:Label ID="lblInternalWidth" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblInternalWidth %>" />
                <asp:TextBox ID="txtInternalWidth" runat="server" CssClass="TextBox txt alignRight"
                    MaxLength="14" />
                <asp:Label ID="lblInternalLengthTip0" runat="server" CssClass="Label" Text="mm" />
            </div>
            <div class="divline">
                <asp:Label ID="lblInternalHeight" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblInternalHeight %>" />
                <asp:TextBox ID="txtInternalHeight" runat="server" CssClass="TextBox txt alignRight"
                    MaxLength="14" />
                <asp:Label ID="lblInternalLengthTip1" runat="server" CssClass="Label" Text="mm" />
            </div>
            <div class="divline">
                <asp:Label ID="lblMaterial" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblMaterial %>" />
                <asp:TextBox ID="txtMaterial" runat="server" CssClass="TextBox txt" MaxLength="70" />
            </div>
            <div class="divline">
                <asp:Label ID="lblExternalcoat" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblExternalcoat %>" />
                <asp:TextBox ID="txtCoat" runat="server" CssClass="TextBox txt" MaxLength="50" />
            </div>
            <div class="divline">
                <asp:Label ID="lblCapacity" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblCapacity %>" />
                <asp:TextBox ID="txtCapacity" runat="server" CssClass="TextBox txt alignRight" MaxLength="14" />
                <asp:Label ID="lblGrossWeightTip" runat="server" CssClass="Label" Text="cum" />
            </div>
            <div class="divline">
                <asp:Label ID="lblMaximumgrossweight" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblMaximumgrossweight %>" />
                <asp:TextBox ID="txtMaximumgrossweight" runat="server" CssClass="TextBox txt alignRight"
                    MaxLength="14" />
                <asp:Label ID="lblMaximumgrossweightTip" runat="server" CssClass="Label" Text="kg" />
            </div>
            <div class="divline">
                <asp:Label ID="lblMaxPayLoad" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblMaxPayLoad %>" />
                <asp:TextBox ID="txtMaxPayLoad" runat="server" CssClass="TextBox txt alignRight"
                    MaxLength="14" />
                <asp:Label ID="Label2" runat="server" CssClass="Label" Text="kg" />
            </div>
            <div class="divline">
                <asp:Label ID="lblStacking" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblStacking %>" />
                <asp:TextBox ID="txtStacking" runat="server" CssClass="TextBox txt" MaxLength="70" />
            </div>
            <div class="divline">
                <asp:Label ID="lblTareWeight" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblTareWeight %>" />
                <asp:TextBox ID="txtTareWeight" runat="server" CssClass="TextBox txt alignRight"
                    MaxLength="14" />
                <asp:Label ID="lblTareWeightTip" runat="server" CssClass="Label" Text="kg" />
            </div>
            <div class="divline">
                <asp:Label ID="lblWorkingPressure" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblWorkingPressure %>" />
                <asp:TextBox ID="txtWorkingPressure" runat="server" CssClass="TextBox txt alignRight"
                    MaxLength="6" />
                <asp:Label ID="lblWorkingPressureTip" runat="server" CssClass="Label" Text="Bars" />
            </div>
            <div class="divline">
                <asp:Label ID="lblApprovals" runat="server" CssClass="Label lblShare" Width="200px"
                    Text="<%$ Resources:lblApprovals.Text %>" />
                <asp:TextBox ID="txtApprovals" runat="server" CssClass="TextBox txt" TextMode="multiLine"
                    Columns="0" Rows="0" />
            </div>
        </div>
        <div id="divBottomNav">
            <asp:Button ID="btnNew" runat="server" Text="<%$ Resources:btnNew.Text %>" CssClass="Button"
                UseSubmitBehavior="False" />
            <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:btnSave.Text %>" CssClass="Button"
                UseSubmitBehavior="False" />
            <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose.Text %>" CssClass="Button"
                UseSubmitBehavior="False" />
        </div>
    </div>
    <asp:HiddenField ID="fldId" runat="server" />
    <asp:HiddenField ID="hidUserId" runat="server" />
    </form>
</body>
</html>
