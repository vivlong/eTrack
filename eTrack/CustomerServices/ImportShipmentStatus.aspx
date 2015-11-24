<%@ Page Language="VB" AutoEventWireup="true" CodeFile="ImportShipmentStatus.aspx.vb"
    Inherits="ImportShipmentStatus" %>

<%@ Register Src="../UserControl/DateTimeSelect.ascx" TagName="DateTimeSelect" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Import Shipment Status</title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/ImportShipmentStatus.css" rel="stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!--#include file="../JavaScript/ResetSize.js" -->
    <!--#include file="JavaScript/SelectReportEdit.js" -->
</head>
<body>
    <form id="frmVessel" runat="server">
    <div id="MsgBox">
        <div class="bar">
            <asp:Label CssClass="Label" ID="lblLoadTitleHint" runat="server" Text="<%$ Resources:Message, LoadTitleHint %>"></asp:Label>
        </div>
        <div class="content">
            <img alt="" src="../images/load.gif" style="text-align: center; vertical-align: middle" />&nbsp;
            &nbsp;<asp:Label CssClass="Label" ID="lblMessage" runat="server" Text="<%$ Resources:Message, LoadDataHint %>"></asp:Label>
        </div>
    </div>
    <div id="divVesselSearch" style="height: 430px; width: 760px; padding-left: 10px;">
        <div id="divCargo">
            <div id="divSource4">
                <div class="divLine">
                    &nbsp;</div>
                <table style="border: 0px; vertical-align: middle; border-color: White;">
                    <tr class="tr25">
                        <td class="lbl">
                            <asp:Label ID="Label1" runat="server" Text="House BL Number" CssClass="Label lbl3" />
                        </td>
                        <td class="tdborder0">
                            <asp:Label CssClass="Label" ID="lblHouseBLNumber" runat="server" />
                        </td>
                        <td class="lbl">
                            <asp:Label ID="Label3" runat="server" Text="Vsl Details" CssClass="Label lbl3" />
                        </td>
                        <td class="tdborder0">
                            <asp:Label CssClass="Label" ID="lblVslDetails" runat="server" />
                        </td>
                    </tr>
                    <tr class="tr25">
                        <td class="lbl">
                            <asp:Label ID="Label5" runat="server" Text="Port of Loading" CssClass="Label lbl3" />
                        </td>
                        <td class="tdborder0">
                            <asp:Label CssClass="Label" ID="lblPortOfLoading" runat="server" />
                        </td>
                        <td class="lbl">
                            <asp:Label ID="Label7" runat="server" Text="ETD POL" CssClass="Label lbl3" />
                        </td>
                        <td class="tdborder0">
                            <asp:Label CssClass="Label" ID="lblETDPOL" runat="server" />
                        </td>
                    </tr>
                    <tr class="tr25">
                        <td class="lbl">
                            <asp:Label ID="Label9" runat="server" Text="Port of Discharge" CssClass="Label lbl3"></asp:Label>
                        </td>
                        <td class="tdborder0">
                            <asp:Label CssClass="Label" ID="lblPortofDischarge" runat="server" />
                        </td>
                        <td class="lbl">
                            <asp:Label ID="Label11" runat="server" Text="ETA POD" CssClass="Label lbl3" />
                        </td>
                        <td class="tdborder0">
                            <asp:Label CssClass="Label" ID="lblETAPOD" runat="server" />
                        </td>
                    </tr>
                </table>
                <table width="98%" style="border: 0px; vertical-align: middle; border-color: White;">
                    <tr class="tr25" id="trCR" runat="server">
                        <td class="lbl">
                            <asp:Label CssClass="Label" ID="Label13" runat="server" Text="Cargo arrived at Warehouse" />
                        </td>
                        <td class="tdborder0">
                            <asp:Label CssClass="Label" ID="txtCR" runat="server" Width="400px" />
                        </td>
                    </tr>
                    <tr class="tr25" id="trCS" runat="server">
                        <td class="lbl">
                            <asp:Label CssClass="Label" ID="Label14" runat="server" Text="Cargo unstuffed from Container at CFS" />
                        </td>
                        <td class="tdborder0">
                            <asp:Label CssClass="Label" ID="txtCS" runat="server" Width="400px" />
                        </td>
                    </tr>
                    <tr class="tr25" id="trBL" runat="server">
                        <td class="lbl">
                            <asp:Label CssClass="Label" ID="Label4" runat="server" Text="B/L ready for Collection"></asp:Label>
                        </td>
                        <td class="tdborder0">
                            <asp:Label CssClass="Label" ID="txtBL" runat="server" Width="400px" />
                        </td>
                    </tr>
                    <tr class="tr25" id="trCA" runat="server" >
                        <td class="lbl">
                            <asp:Label CssClass="Label" ID="Label15" runat="server" Text="Cargo arrived at Port of Discharge"></asp:Label>
                        </td>
                        <td class="tdborder0">
                            <asp:Label CssClass="Label" ID="txtCA" runat="server" Width="400px" />
                        </td>
                    </tr>
                    <tr class="tr25" id="trDO" runat="server">
                        <td class="lbl">
                            <asp:Label CssClass="Label" ID="Label8" runat="server" Text="Delivery Order ready for collection by Consignee"></asp:Label>
                        </td>
                        <td class="tdborder0">
                            <asp:Label CssClass="Label" ID="txtDO" runat="server" Width="400px" />
                        </td>
                    </tr>
                    <tr class="tr25" id="trDC" runat="server">
                        <td class="lbl">
                            <asp:Label CssClass="Label" ID="Label6" runat="server" Text="Delivery Order collected by Consignee"></asp:Label>
                        </td>
                        <td class="tdborder0">
                            <asp:Label CssClass="Label" ID="txtDC" runat="server" Width="400px" />
                        </td>
                    </tr>
                    <tr class="tr25" id="trCC" runat="server">
                        <td class="lbl">
                            <asp:Label CssClass="Label" ID="Label16" runat="server" Text="Cargo collect by Consignee"></asp:Label>
                        </td>
                        <td class="tdborder0">
                            <asp:Label CssClass="Label" ID="txtCC" runat="server" Width="400px" />
                        </td>
                    </tr>
                    <tr class="tr25" id="trContainerNo" runat="server">
                        <td class="lbl">
                            <asp:Label CssClass="Label" ID="Label17" runat="server" Text="Container No" />
                        </td>
                        <td class="tdborder0">
                            <asp:Label CssClass="Label" ID="lblContainerNo" runat="server" Width="400px" />
                        </td>
                    </tr>
                    <tr class="tr25" id="trSealNo" runat="server">
                        <td class="lbl">
                            <asp:Label CssClass="Label" ID="Label19" runat="server" Text="Seal No"></asp:Label>
                        </td>
                        <td class="tdborder0">
                            <asp:Label CssClass="Label" ID="lblSEALNo" runat="server" Width="400px" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div id="divBottomNav">
        <asp:Button ID="btnClose" runat="server" Text="Close"
            CssClass="Button" UseSubmitBehavior="False" />
    </div>
    <asp:HiddenField ID="hid_val" runat="server" Value="1" />
    </form>
</body>
</html>
