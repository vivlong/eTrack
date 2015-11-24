<%@ Page Language="VB" AutoEventWireup="true" CodeFile="ExportBookingEdit.aspx.vb"
    Inherits="ExportBookingEdit" %>

<%@ Register Src="../UserControl/FieldDoubleSelect.ascx" TagName="FieldDoubleSelect"
    TagPrefix="uc1" %>
<%@ Register Src="../UserControl/DateTimeSelect.ascx" TagName="DateTimeSelect" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/CurrRateSelect.ascx" TagName="CurrRateSelect" TagPrefix="uc3" %>
<%@ Register Src="../UserControl/FieldSingleSelect.ascx" TagName="FieldSingleSelect"
    TagPrefix="uc4" %>
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
    <link href="App_Themes/ExportBookingEdit.css" rel="Stylesheet" type="text/css" />
    <link href="../UserControl/datepicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <script type="text/javascript" src="../JavaScript/jquery.maskedinput.js"></script>
    <script language="javascript" type="text/javascript" src="../UserControl/datepicker/WdatePicker.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="JavaScript/ExportBookingEdit.js" -->
    <!--#include file="../JavaScript/Print.js" -->
    <!--#include file="../UserControl/JavaScript/FiledSelect.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>
    <script type="text/javascript" language="javascript">

        function ChgUrgAttribute(aFlag) {
            if (aFlag == 1) {
                document.getElementById("txtUrgentRemark").value = "";
                document.getElementById("txtUrgentRemark").readOnly = true;
            }
            else if (aFlag == 2) {
                document.getElementById("txtUrgentRemark").readOnly = false;
            }
        }
        function on_page_loaded() {
            try {
                if (!window.onbeforeunload)
                    window.onbeforeunload = function () { };
            } catch (e) { }
        }
    </script>
</head>
<body onload="on_page_loaded()">
    <form id="frmBookingFormEdit" runat="server">
    <div id="divForm">
        <div id="divTopNav">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="a1" runat="server" CssClass="f12e navNml navOn" Text="Online Booking"
                        Width="99px"></asp:Label></li>
            </ul>
        </div>
        <div id="SaveHint" runat="server" class="Hint" style="left: 0px; top: 10px">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>" />
        </div>
        <div id="divMiddle1" style="padding-left: 20px; padding-top: 10px">
            <div class="divline">
                <asp:Label ID="lblTrxNo" CssClass="lab lbl" runat="server" Text="<%$ Resources:lblTrxNo %>" />
                <asp:TextBox ID="txtTrxNo" CssClass="TextBox txtDate ReadOnly" ReadOnly="true" runat="server"
                    MaxLength="10" />
            </div>
            <div>
                <asp:Label ID="lblBookingDateTime" CssClass="lab lbl" runat="server" Text="<%$ Resources:lblBookingDateTime %>" />
                <uc2:DateTimeSelect ID="BookingDateTimeSelect" runat="server" />
                dd/MM/yyyy HH:mm</div>
            <div>
                <asp:Label ID="lblBookingNo" CssClass="lab lbl" runat="server" Text="<%$ Resources:lblBookingNo %>" />
                <asp:TextBox ID="txtBookingNo" CssClass="TextBox txtDate" runat="server" MaxLength="10" />
            </div>
            <div>
                <asp:Label ID="lblCustomerName" CssClass="lab lbl" runat="server" Text="<%$ Resources:lblCustomerName %>" />
                <asp:TextBox ID="txtCustomerName" CssClass="TextBox txt " runat="server" MaxLength="50" />
            </div>
            <div>
                <asp:Label ID="lblContactName" CssClass="lab lbl" runat="server" Text="<%$ Resources:lblContactName %>" />
                <uc4:FieldSingleSelect ID="ContactNameSelect" runat="server" />
            </div>
            <div>
                <asp:Label ID="lblTelephone" CssClass="lab lbl" runat="server" Text="<%$ Resources:lblTelephone %>" />
                <uc4:FieldSingleSelect ID="TelephoneSelect" runat="server" />
            </div>
            <div>
                <asp:Label ID="lblVessel" runat="server" CssClass="lab lbl" Text="<%$ Resources:lblVessel %>" />
                <uc1:FieldDoubleSelect ID="VesselSelect" runat="server" />
            </div>
            <div>
                <asp:Label ID="lblVoyage" CssClass="lab lbl" runat="server" Text="<%$ Resources:lblVoyage %>" />
                <asp:TextBox ID="txtVoyage" CssClass="TextBox txtDate" runat="server" MaxLength="12" />
            </div>
            <div>
                <asp:Label ID="lblETD" CssClass="lab lbl" runat="server" Text="<%$ Resources:lblETD %>" />
                <uc2:DateTimeSelect ID="ETDSelect" runat="server" />
                dd/mm/yyyy
            </div>
            <div>
                <asp:Label ID="lblETA" CssClass="lab lbl" runat="server" Text="<%$ Resources:lblETA %>" />
                <uc2:DateTimeSelect ID="ETASelect" runat="server" />
                dd/mm/yyyy
            </div>
            <div>
                <asp:Label ID="lblPortofDischarge" runat="server" CssClass="lab lbl" Text="<%$ Resources:lblPortofDischarge %>" />
                <uc1:FieldDoubleSelect ID="PortofDischargeSelect" runat="server" />
            </div>
            <div>
                <asp:Label ID="lblDestination" runat="server" CssClass="lab lbl" Text="<%$ Resources:lblDestination %>" />
                <uc1:FieldDoubleSelect ID="DestSelect" runat="server" />
            </div>
            <div style="display: none">
                <asp:Label ID="lblCargoType" runat="server" CssClass="lab lbl" Text="<%$ Resources:lblCargoType %>" />
                <asp:DropDownList ID="drpCargoType" runat="server" CssClass="txtDate">
                    <asp:ListItem Value="LCL">LCL</asp:ListItem>
                    <asp:ListItem Value="FCL">FCL</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="drpDgFlag" runat="server" CssClass="txtDate">
                    <asp:ListItem Value="LCL">LCL</asp:ListItem>
                    <asp:ListItem Value="FCL">FCL</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <asp:Label ID="lblCommodity" runat="server" CssClass="lab lbl" Text="<%$ Resources:lblCommodity %>" />
                <uc1:FieldDoubleSelect ID="CommoditySelect" runat="server" />
            </div>
            <table cellpadding="0" cellspacing="0" style="padding-left: 3px;">
                <tr>
                    <td class="lbl">
                        &nbsp
                    </td>
                    <td>
                        <asp:Label ID="lblPcs" runat="server" CssClass="lab lblKG" Text="<%$ Resources:lblPcs %>" />
                    </td>
                    <td class="pandLeft">
                        <asp:Label ID="lblGrossWeight" runat="server" CssClass="lab lblKG" Text="<%$ Resources:lblGrossWeight %>" />
                    </td>
                    <td class="pandLeft">
                        <asp:Label ID="lblVolume" runat="server" CssClass="lab lblKG" Text="<%$ Resources:lblVolume %>" />
                    </td>
                </tr>
                <tr>
                    <td class="lbl">
                    </td>
                    <td>
                        <asp:TextBox ID="txtPcs" runat="server" CssClass="TextBox txtKG" MaxLength="10" />
                    </td>
                    <td class="pandLeft">
                        <asp:TextBox ID="txtGrossWeight" runat="server" CssClass="TextBox txtKG" MaxLength="8" />
                    </td>
                    <td class="pandLeft">
                        <asp:TextBox ID="txtVolume" runat="server" CssClass="TextBox txtKG" MaxLength="8" />
                    </td>
                </tr>
            </table>
            <div>
                <asp:Label ID="lblRemark" CssClass="lab lbl lblRemark" runat="server" Text="<%$ Resources:lblRemark %>" />
                <asp:TextBox ID="txtFooter1" CssClass="TextBox txtDate" runat="server" MaxLength="80" Height="58px" Width="404px" TextMode="MultiLine" />
            </div>
        </div>
        <div id="divBottomNav" style="width: 100%;">
            <asp:Button ID="btnPrint" runat="server" Text="<%$ Resources:btnPrint %>" CssClass="Button"
                UseSubmitBehavior="False" />
            <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:btnSave %>" CssClass="Button"
                UseSubmitBehavior="False" />
            <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose %>" CssClass="Button"
                UseSubmitBehavior="False" />&nbsp
        </div>
        <asp:HiddenField ID="fldId" Value="-1" runat="server" />
        <asp:HiddenField ID="hidUserNo" runat="server" />
        <asp:HiddenField ID="hidReports" runat="server" />
        <asp:HiddenField ID="hidSeblTrxNo" runat="server" />
        <asp:HiddenField ID="hidOriginCode" runat="server" Value="" />
    </div>
    </form>
</body>
</html>
