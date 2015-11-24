<%@ Page Language="VB" AutoEventWireup="true" CodeFile="BookingEdit.aspx.vb" Inherits="BookingEdit" %>

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
    <link href="../App_Themes/Calendar.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/BookingEdit.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="JavaScript/BookingEdit.js" -->
    <!-- #include file="JavaScript/TableOperate.js" -->
    <!--#include file="../JavaScript/Print.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"> </script>
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
        function showBtn(intflag) {
            document.getElementById('btnUpdate').style.display = 'none';
            if (intflag == 2) { document.getElementById('btnUpdate').style.display = ''; }
            var flagSave = false;
            var valId = document.getElementById("fldId").value;
            if (valId < 0) {
                if (intflag == 2) {
                    document.getElementById('btnSave').style.display = 'none';
                }
                else { document.getElementById('btnSave').style.display = ''; }
                if (TabNo == 1) {
                    if (intflag != 1) {
                        if (window.confirm("Do you want to save New Booking?")) {
                            var flagAuto = true;
                            flagAuto = AutoSave('Booking', 3, intflag);
                            if (flagAuto != false) {
                                TabNo = intflag;
                            }
                        }
                        else { return false; }
                    }
                }
                else { SelectedDiv(intflag, 3); }
            }
            else { SelectedDiv(intflag, 3); }
        }
        function showDiv(intflag) {
            document.getElementById('btnUpdate').style.display = 'none';
            // if (intflag == 2) { document.getElementById('btnUpdate').style.display = ''; }
            var flagSave = false;
            var valId = document.getElementById("fldId").value;
            if (valId < 0) {
                if (intflag == 2) {
                    document.getElementById('btnSave').style.display = 'none';
                }
                // else { document.getElementById('btnSave').style.display = ''; }
                if (TabNo == 1) {
                    if (intflag != 1) {
                        //if (window.confirm("Do you want to save New Booking?"))
                        // { AutoSave('Booking', 3, intflag); TabNo = intflag; }
                        //else { return false; }
                        return false;
                    }
                }
                else { SelectedDiv(intflag, 3); }
            }
            else { SelectedDiv(intflag, 3); }
        }
    </script>
</head>
<body onload="on_page_loaded()">
    <form id="frmBookingFormEdit" runat="server">
    <div id="divForm">
        <div id="divTopNav" style="width: 1023px">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="a1" runat="server" CssClass="f12e navNml navOn" onclick="showBtn(1);"
                        Text="<%$ Resources:a1.Text %>"></asp:Label></li>
                <li>
                    <asp:Label ID="a2" CssClass="f12c navNml noSep" runat="server" onclick="showBtn(2);"
                        Text="<%$ Resources:a2.Text %>" /></li>
                <li>
                    <asp:Label ID="a3" CssClass="f12c navNml noSep" runat="server" onclick="showBtn(3);"
                        Text="<%$ Resources:a3.Text %>" /></li>
            </ul>
        </div>
        <div id="SaveHint" runat="server" class="Hint" style="left: 0px; top: 10px">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>" />
        </div>
        <div id="divMiddle1" class="divMiddle">
            <div id="divMiddle11" runat="server">
                <div class="divline">
                    <asp:Label ID="lblOrderDate" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblOrderDate %>" />
                    <asp:TextBox ID="txtOrderDate" CssClass="TextBox txtDate" runat="server" MaxLength="10" />
                    <asp:Button ID="btnOrderDate" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                    dd/mm/yyyy
                    <div id="divline_Module" runat="server" class="divline" style="display: inline;">
                        <asp:Label ID="lblModule" CssClass="Label lblModule" runat="server" Text="<%$ Resources:lblModule %>" />
                        <asp:DropDownList ID="drModule" runat="server">
                            <asp:ListItem Value="SE">SE</asp:ListItem>
                            <asp:ListItem Value="AE">AE</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="divline">
                    <asp:Label ID="lblCustomerName" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblCustomerName %>" />
                    <asp:TextBox ID="drpCustomerName" runat="server" CssClass="TextBox txt" MaxLength="50" />
                    <asp:Button ID="btnCustomerName" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblContactName" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblContactName %>" />
                    <div id="div_drop" style="display: inline">
                        <asp:TextBox ID="drpContactName" runat="server" CssClass="TextBox txt" MaxLength="50" />
                        <asp:Button ID="btnContactName" runat="server" CssClass="Button bntDate" Text="..."
                            UseSubmitBehavior="False" />
                        <asp:HiddenField ID="hid_CustomerCode" runat="server" />
                    </div>
                </div>
                <div id="divline_Telephone" class="divline" runat="server">
                    <asp:Label ID="lblTelephone" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblTelephone %>" />
                    <asp:TextBox ID="txtTelephone" runat="server" CssClass="TextBox txt" MaxLength="30" />
                </div>
                <div id="divline_ShipperName" runat="server" class="divline">
                    <asp:Label ID="lblShipperName" runat="server" Text="<%$ Resources:lblShipperName %>"
                        CssClass="Label lbl" />
                    <asp:TextBox ID="txtShipperName" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div id="divline_CollectFrom" runat="server" class="divline">
                    <asp:Label ID="lblCollectFrom" runat="server" Text="<%$ Resources:lblCollectFrom %>"
                        CssClass="Label lbl" />
                    <asp:TextBox ID="txtCollectFrom" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div id="divline_ShipperAddress" runat="server">
                    <div class="divline">
                        <asp:Label ID="lblShipperAddress" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblShipperAddress %>" />
                        <asp:TextBox ID="txtShipperAddress1" runat="server" CssClass="TextBox txt" MaxLength="45" />
                    </div>
                    <div class="divline">
                        <a class="Label span">&nbsp</a>
                        <asp:TextBox ID="txtShipperAddress2" runat="server" CssClass="TextBox txt" MaxLength="45" />
                    </div>
                    <div class="divline">
                        <a class="Label span">&nbsp</a>
                        <asp:TextBox ID="txtShipperAddress3" runat="server" CssClass="TextBox txt" MaxLength="45" />
                    </div>
                    <div class="divline">
                        <a class="Label span">&nbsp</a>
                        <asp:TextBox ID="txtShipperAddress4" runat="server" CssClass="TextBox txt" MaxLength="45" />
                    </div>
                </div>
                <div id="divline_ConsignessName" runat="server" class="divline">
                    <asp:Label ID="lblConsignessName" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblConsignessName %>" />
                    <asp:TextBox ID="txtConsignessName" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div id="divline_DeliverTo" runat="server" class="divline">
                    <asp:Label ID="lblDeliverTo" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblDeliverTo %>" />
                    <asp:TextBox ID="txtDeliverTo" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div id="divline_ConsigneeAddress" runat="server">
                    <div class="divline">
                        <asp:Label ID="lblConsigneeAddress" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblConsigneeAddress %>" />
                        <asp:TextBox ID="txtConsigneeAddress1" runat="server" CssClass="TextBox txt" MaxLength="45" />
                    </div>
                    <div class="divline">
                        <a class="Label span">&nbsp</a>
                        <asp:TextBox ID="txtConsigneeAddress2" runat="server" CssClass="TextBox txt" MaxLength="45" />
                    </div>
                    <div class="divline">
                        <a class="Label span">&nbsp</a>
                        <asp:TextBox ID="txtConsigneeAddress3" runat="server" CssClass="TextBox txt" MaxLength="45" />
                    </div>
                    <div class="divline">
                        <a class="Label span">&nbsp</a>
                        <asp:TextBox ID="txtConsigneeAddress4" runat="server" CssClass="TextBox txt" MaxLength="45" />
                    </div>
                </div>
                <div id="divline_DeliverToAddress" runat="server">
                    <div class="divline">
                        <asp:Label ID="lblDeliverToAddress" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblConsigneeAddress %>" />
                        <asp:TextBox ID="txtDeliverToAddress1" runat="server" CssClass="TextBox txt" MaxLength="45" />
                    </div>
                    <div class="divline">
                        <a class="Label span">&nbsp</a>
                        <asp:TextBox ID="txtDeliverToAddress2" runat="server" CssClass="TextBox txt" MaxLength="45" />
                    </div>
                    <div class="divline">
                        <a class="Label span">&nbsp</a>
                        <asp:TextBox ID="txtDeliverToAddress3" runat="server" CssClass="TextBox txt" MaxLength="45" />
                    </div>
                    <div class="divline">
                        <a class="Label span">&nbsp</a>
                        <asp:TextBox ID="txtDeliverToAddress4" runat="server" CssClass="TextBox txt" MaxLength="45" />
                    </div>
                </div>
                <div id="divline_PickupDateTimeTP" runat="server" class="divline">
                    <asp:Label ID="lblPickupDateTimeTP" runat="server" CssClass="Label CarogTime" Text="<%$ Resources:lblCargoTime %>" />
                    <asp:TextBox ID="txtPickupDateTimeTP" runat="server" CssClass="TextBox txtJobNo"
                        MaxLength="16">
                    </asp:TextBox>
                    <asp:Button ID="btnPickupDateTimeTP" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                    dd/MM/yyyy HH:mm</div>
                <div id="divline_CargoDeliverDateTime" runat="server" class="divline">
                    <asp:Label ID="lblCargoDeliverDateTime" runat="server" CssClass="Label CarogTime"
                        Text="<%$ Resources:lblCargoDeliverDateTime %>" />
                    <asp:TextBox ID="txtCargoDeliverDateTime" runat="server" CssClass="TextBox txtJobNo"
                        MaxLength="16">
                    </asp:TextBox>
                    <asp:Button ID="btnCargoDeliverDateTime" runat="server" CssClass="Button bntDate"
                        Text="..." UseSubmitBehavior="False" />
                    dd/MM/yyyy HH:mm</div>
                <div id="divline_OriginCode" runat="server" class="divline">
                    <asp:Label ID="lblOriginCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblOriginCode %>" />
                    <asp:TextBox ID="txtOriginCode" runat="server" CssClass="TextBox origin" MaxLength="3" />
                    <div id="divOrigin" style="display: inline">
                        <asp:TextBox ID="txtOriginName" ReadOnly="true" runat="server" CssClass="TextBox txtorigin" />
                    </div>
                    <asp:Button ID="btnOrigin" runat="server" CssClass="Button bntDate" Text="..." UseSubmitBehavior="False" />
                </div>
                <div id="divOrigin1" style="display: none">
                </div>
                <div id="divline_DestCode" runat="server" class="divline">
                    <asp:Label ID="lblDestCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblDestCode %>" />
                    <asp:TextBox ID="txtDestCode" runat="server" CssClass="TextBox origin" MaxLength="3" />
                    <div id="divDestCode" style="display: inline">
                        <asp:TextBox ID="txtDestName" runat="server" ReadOnly="true" CssClass="TextBox txtorigin" />
                    </div>
                    <asp:Button ID="btnDestCode" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                </div>
                <div id="divDestCode1" style="display: none">
                </div>
                <div id="div_lblPortOfLoadingCode" runat="server" class="divline">
                    <asp:Label ID="lblPortOfLoadingCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblPortOfLoadingCode %>" />
                    <asp:TextBox ID="txtPortOfLoadingCode" runat="server" CssClass="TextBox origin" MaxLength="5" />
                    <div id="divLoading" style="display: inline">
                        <asp:TextBox ID="txtPortOfLoadingName" runat="server" ReadOnly="true" CssClass="TextBox txtorigin" />
                    </div>
                    <asp:Button ID="btnPortOfLoading" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                </div>
                <div id="divLoading1" style="display: none">
                </div>
                <div id="div_lblAirPortofDeparture" runat="server" class="divline">
                    <asp:Label ID="lblAirPortofDeparture" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblAirPortofDeparture %>" />
                    <asp:TextBox ID="txtAirPortofDepartureCode" runat="server" CssClass="TextBox origin"
                        MaxLength="5" />
                    <div id="divtxtAirPortofDeparture" style="display: inline">
                        <asp:TextBox ID="txtAirPortofDepartureName" runat="server" ReadOnly="true" CssClass="TextBox txtorigin" />
                    </div>
                    <asp:Button ID="btnAirPortofDeparture" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                </div>
                <div id="div_txtAirPortofDeparture1" style="display: none">
                </div>
                <div id="divline_EtdDate" runat="server" class="divline">
                    <asp:Label ID="lblEtdDate" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblEtdDate %>" />
                    <asp:TextBox ID="txtlblEtdDate" runat="server" CssClass="TextBox txtDate" MaxLength="10" />
                    <asp:Button ID="btnlblEtdDate" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                    dd/mm/yyyy</div>
                <div id="div_lblPortOfDischargeCode" runat="server" class="divline">
                    <asp:Label ID="lblPortOfDischargeCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblPortOfDischargeCode %>" />
                    <asp:TextBox ID="txtPortOfDischargeCode" runat="server" CssClass="TextBox origin"
                        MaxLength="5" />
                    <div id="divDischarge" style="display: inline">
                        <asp:TextBox ID="txtPortOfDischargeName" runat="server" ReadOnly="true" CssClass="TextBox txtorigin" />
                    </div>
                    <asp:Button ID="btnPortOfDischargeName" runat="server" CssClass="Button bntDate"
                        Text="..." UseSubmitBehavior="False" />
                </div>
                <div id="divDischarge1" runat="server" style="display: none">
                </div>
                <div id="div_lblAirPortofDestination" runat="server" class="divline">
                    <asp:Label ID="lblAirPortofDestination" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblAirPortofDestination %>" />
                    <asp:TextBox ID="txtAirPortDestinationCode" runat="server" CssClass="TextBox origin"
                        MaxLength="5" />
                    <div id="divAirPortDestinationName" style="display: inline">
                        <asp:TextBox ID="txtAirPortDestinationName" ReadOnly="true" runat="server" CssClass="TextBox txtorigin" />
                    </div>
                    <asp:Button ID="btnAirDestinationDestination" runat="server" CssClass="Button bntDate"
                        Text="..." UseSubmitBehavior="False" />
                </div>
                <div id="div1AirPortDestination1" style="display: none">
                </div>
                <div id="divline_EtaDate" runat="server" class="divline">
                    <asp:Label ID="lblEtaDate" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblEtaDate %>" />
                    <asp:TextBox ID="txtlblEtaDate" runat="server" CssClass="TextBox txtDate" MaxLength="10" />
                    <asp:Button ID="btnlblEtaDate" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                    dd/mm/yyyy
                </div>
                <div id="divlblVoyageNo" runat="server" class="divline">
                    <asp:Label ID="lblVoyageNo" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblVoyageNo %>" />
                    <asp:TextBox ID="txtVoyageName" runat="server" CssClass="TextBox txtVoyageName" MaxLength="50" />
                    <div id="divVoyage" style="display: none">
                    </div>
                    <asp:Button ID="btnVoyageName" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtVoyageNo" runat="server" CssClass="TextBox txtVoyageName" MaxLength="12" />
                </div>
                <div id="divlblAlirline" runat="server" class="divline">
                    <asp:Label ID="lblAlirlineID" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblAlirlineID %>" />
                    <asp:TextBox ID="txtAlirlineID" runat="server" CssClass="TextBox txtVoyageName" MaxLength="2" />
                    <asp:Button ID="btnAlirlineID" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtFlightNo" runat="server" CssClass="TextBox txtVoyageName" MaxLength="10" />
                </div>
            </div>
            <div id="divMiddle12" runat="server">
                <div id="divhid_DgFlag" runat="server" class="divline">
                    <div id="divline_CargoType" runat="server" style="display: inline">
                        <asp:Label ID="lblDgFlag" runat="server" CssClass="Label ShotTitle" Text="<%$ Resources:lblDgFlag %>" />
                        <asp:DropDownList ID="txtDgFlag" runat="server" CssClass="txtDgFlag">
                            <asp:ListItem Value="0">N</asp:ListItem>
                            <asp:ListItem Value="1">Y</asp:ListItem>
                        </asp:DropDownList>
                        <span class="Dgblank"></span>
                    </div>
                    <asp:Label ID="lblCargoType" runat="server" CssClass="Label ShotTitle" Text="<%$ Resources:lblCargoType %>" />
                    <asp:DropDownList ID="txtCargoType" runat="server" CssClass="txtDate">
                        <asp:ListItem Value="LCL">LCL</asp:ListItem>
                        <asp:ListItem Value="FCL">FCL</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="divline_DeliveryType" runat="server" class="divline">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td style="border: 0px; padding-left: 0px">
                                <asp:Label ID="lblDeliveryType" runat="server" CssClass="Label ShotTitle" Text="<%$ Resources:lblDeliveryType %>" />
                            </td>
                            <td style="width: 5px">
                            </td>
                            <td style="border: 0px; padding-left: 0px">
                                <asp:TextBox ID="txtDeliveryType" runat="server" CssClass="TextBox txtDate" MaxLength="5" />
                            </td>
                            <td style="border: 0px; padding-left: 0px">
                                <div id="divDelivery">
                                    <asp:TextBox ID="txtDelivery" runat="server" ReadOnly="true" CssClass="TextBox txtDelivery"
                                        MaxLength="50" /></div>
                            </td>
                            <td style="border: 0px; padding-left: 0px">
                                <asp:Button ID="btnDelivery" runat="server" CssClass="Button bntDate" Text="..."
                                    UseSubmitBehavior="False" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divDelivery1" style="display: none">
                </div>
                <div id="divline_CommodityCode" runat="server" class="divline">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td style="border: 0px; padding-left: 0px">
                                <asp:Label ID="lblCommodityCode" runat="server" CssClass="Label ShotTitle" Text="<%$ Resources:lblCommodityCode %>" />
                            </td>
                            <td style="width: 5px">
                            </td>
                            <td style="border: 0px; padding-left: 0px">
                                <asp:TextBox ID="txtCommodityCode" runat="server" CssClass="TextBox txtDate" MaxLength="10" />
                            </td>
                            <td style="border: 0px; padding-left: 0px">
                                <div id="divCommodity">
                                    <asp:TextBox ID="txtCommodityName" runat="server" CssClass="TextBox txtDelivery"
                                        MaxLength="50" /></div>
                            </td>
                            <td style="border: 0px; padding-left: 3px">
                                <asp:Button ID="btnCommodity" runat="server" CssClass="Button bntDate" Text="..."
                                    UseSubmitBehavior="False" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divCommodity1" style="display: none">
                </div>
                <div class="divline">
                    <asp:Label ID="lblPcs" runat="server" CssClass="Label lblPcs1" Text="<%$ Resources:lblPcs %>" />
                    <asp:Label ID="lbPacking" runat="server" CssClass="Label lbPacking" Text="<%$ Resources:lbPacking %>" />
                    <asp:Label ID="lblGrossWeight" runat="server" CssClass="Label lblKG" Text="<%$ Resources:lblGrossWeight %>" />
                    <asp:Label ID="lblVolume" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblVolume %>" />
                </div>
                <div class="divline">
                    <asp:TextBox ID="txtPcs" runat="server" CssClass="TextBox txtPcs marginPcs" MaxLength="4" />
                    <asp:TextBox ID="txtUomCode" runat="server" CssClass="TextBox ShotTitle" MaxLength="3" />
                    <div id="divUom" style="display: none">
                    </div>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:Button ID="btnUom" runat="server" CssClass="Button bntDate" Text="..." UseSubmitBehavior="False" />
                    &nbsp&nbsp&nbsp
                    <asp:TextBox ID="txtGrossWeight" runat="server" CssClass="TextBox txtKG" MaxLength="14" />
                    &nbsp&nbsp&nbsp
                    <asp:TextBox ID="txtVolume" runat="server" CssClass="TextBox txtKG" MaxLength="14" />
                </div>
                <div id="divlblNoOfContainer1" runat="server" class="divline">
                    <div class="divline">
                        <asp:Label ID="lblNoOfContainer1" runat="server" CssClass="Label NoOfContainer" Text="<%$ Resources:lblNoOfContainer1 %>" />
                        <asp:Label ID="lblNoOfContainer2" runat="server" CssClass="Label NoOfContainer2"
                            Text="<%$ Resources:lblNoOfContainer2 %>" />
                        <asp:Label ID="lblNoOfContainer3" runat="server" CssClass="Label NoOfContainer" Text="<%$ Resources:lblNoOfContainer3 %>" />
                    </div>
                    <div id="divline_NoOfContainer1" runat="server" class="divline">
                        <asp:TextBox ID="txtNoOfContainer1" runat="server" CssClass="TextBox txtCon" MaxLength="4" />
                        ×
                        <asp:DropDownList ID="txtContainerType1" runat="server" CssClass="txtConl" Height="20px" />
                        <%--<asp:TextBox ID="txtContainerType1" runat="server" CssClass="TextBox txtConl" />--%>
                        &nbsp&nbsp&nbsp&nbsp
                        <asp:TextBox ID="txtNoOfContainer2" runat="server" CssClass="TextBox txtCon" MaxLength="4" />
                        ×
                        <asp:DropDownList ID="txtContainerType2" runat="server" CssClass="txtConl" Height="20px" />
                        <%--<asp:TextBox ID="txtContainerType2" runat="server" CssClass="TextBox txtConl" />--%>
                        &nbsp&nbsp&nbsp&nbsp
                        <asp:TextBox ID="txtNoOfContainer3" runat="server" CssClass="TextBox txtCon" MaxLength="4" />
                        ×
                        <asp:DropDownList ID="txtContainerType3" runat="server" CssClass="txtConl" Height="20px" />
                        <%--<asp:TextBox ID="txtContainerType3" runat="server" CssClass="TextBox txtConl" />--%>
                    </div>
                </div>
                <div id="divline_PickupDateTime" runat="server" class="divline">
                    <asp:Label ID="lblPickupDateTime" runat="server" CssClass="Label CarogTime" Text="<%$ Resources:lblCargoTime %>" />
                    <asp:TextBox ID="txtPickupDateTime" runat="server" CssClass="TextBox txtJobNo" MaxLength="16">
                    </asp:TextBox>
                    <asp:Button ID="btnPickupDateTime" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                    dd/MM/yyyy HH:mm</div>
                <div id="divline_PickupAddress" runat="server" class="divline">
                    <asp:Label ID="lblPickupAddress" runat="server" CssClass="Label CarogTime" Text="<%$ Resources:lblCargoForm %>" />
                    <asp:TextBox ID="txtCollectFromName" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div id="divline_CargoAddress" runat="server">
                    <div class="divline">
                        <asp:Label ID="lblCargoAddress" runat="server" CssClass="Label CarogTime" Text="<%$ Resources:lblCargoAddress %>" />
                        <asp:TextBox ID="txtCargoAddress1" runat="server" CssClass="TextBox txt" MaxLength="45" />
                    </div>
                    <div class="divline">
                        <a class="Label CarogTime">&nbsp</a>
                        <asp:TextBox ID="txtCargoAddress2" runat="server" CssClass="TextBox txt" MaxLength="45" />
                    </div>
                    <div class="divline">
                        <a class="Label CarogTime">&nbsp</a>
                        <asp:TextBox ID="txtCargoAddress3" runat="server" CssClass="TextBox txt" MaxLength="45" />
                    </div>
                    <div class="divline">
                        <a class="Label CarogTime">&nbsp</a>
                        <asp:TextBox ID="txtCargoAddress4" runat="server" CssClass="TextBox txt" MaxLength="45" />
                    </div>
                </div>
                <div id="divline_CargoDescriptionAddress" runat="server">
                    <div class="divline">
                        <asp:Label ID="lblDescriptionOfGoods1" runat="server" CssClass="Label CarogTime"
                            Text="<%$ Resources:lblDescriptionOfGoods1 %>" />
                        <asp:TextBox ID="txtDescriptionOfGoods1" runat="server" CssClass="TextBox txt" MaxLength="50" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblG2" runat="server" CssClass="Label CarogTime" Text=" " />
                        <asp:TextBox ID="txtDescriptionOfGoods2" runat="server" CssClass="TextBox txt" MaxLength="50" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblG3" runat="server" CssClass="Label CarogTime" Text=" " />
                        <asp:TextBox ID="txtDescriptionOfGoods3" runat="server" CssClass="TextBox txt" MaxLength="50" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblG4" runat="server" CssClass="Label CarogTime" Text=" " />
                        <asp:TextBox ID="txtDescriptionOfGoods4" runat="server" CssClass="TextBox txt" MaxLength="50" />
                    </div>
                </div>
                <div class="divline">
                    <asp:Label ID="lblMarkNo" runat="server" CssClass="Label CarogTime" Text="<%$ Resources:lblMarkNo %>" />
                    <asp:TextBox ID="txtMarkNo" runat="server" CssClass="TextBox txt" MaxLength="25" />
                </div>
                <div class="divline" style="vertical-align: top; margin-top: 0px">
                    <asp:Label ID="lblSpecialInstruction" runat="server" CssClass="Label CarogTime hight90"
                        Text="<%$ Resources:lblSpecialInstruction %>" />
                    <asp:TextBox ID="txtSpecialInstruction" runat="server" CssClass="TextBox hight90 txt"
                        TextMode="MultiLine" MaxLength="3000" />
                </div>
                <div class="divline">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="border: 0px; padding-left: 0px">
                                <asp:Label ID="lblOrderNo" runat="server" CssClass="Label CarogTime" Text="<%$ Resources:lblOrderNo %>" />
                            </td>
                            <td style="border: 0px; padding-left: 0px">
                                <asp:TextBox ID="txtOrderType" runat="server" CssClass="TextBox txtOrderType" MaxLength="10" />
                                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="TextBox txtOrder" ReadOnly="true"
                                    MaxLength="50" />
                            </td>
                            <td style="border: 0px; padding-left: 0px">
                                <div id="divbtnConfirmOrder" style="display: inline">
                                    <asp:Button ID="btnConfirmOrder" runat="server" CssClass="Button" Text="<%$ Resources:btnConfirm.Text %>"
                                        UseSubmitBehavior="False" />
                                </div>
                                <div id="divIssue" style="display: inline">
                                    <asp:Button ID="btnPrompt" runat="server" Text="<%$ Resources:lblIssue %>" CssClass="Button"
                                        UseSubmitBehavior="False" /></div>
                                <div id="divScan" style="display: inline">
                                    <asp:Button ID="btnScan" runat="server" Text="<%$ Resources:btnScan %>" CssClass="Button"
                                        UseSubmitBehavior="False" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divline_Packing" runat="server" class="divline">
                    <div class="divLine">
                        <asp:Label ID="lblPacking1" runat="server" CssClass="Label lblPacking" Text="<%$ Resources:lblPacking1 %>" />
                        <asp:Label ID="lblPacking2" runat="server" CssClass="Label lblPacking1" Text="<%$ Resources:lblPacking2 %>" />
                        <asp:Label ID="lblPacking3" runat="server" CssClass="Label lblPacking2" Text="<%$ Resources:lblPacking3 %>" />
                        <asp:Label ID="lblPacking4" runat="server" CssClass="Label lblPacking1" Text="<%$ Resources:lblPacking4 %>" />
                        <asp:Label ID="lblPacking5" runat="server" CssClass="Label lblPacking1" Text="<%$ Resources:lblPacking5 %>" />
                    </div>
                    <div class="divLine">
                        <asp:TextBox ID="txtPackingQty1" runat="server" CssClass="TextBox PackingQty" MaxLength="10" />
                        <asp:TextBox ID="txtPackingQty2" runat="server" CssClass="TextBox PackingQty" MaxLength="10" />
                        <asp:TextBox ID="txtPackingQty3" runat="server" CssClass="TextBox PackingQty" MaxLength="10" />
                        <asp:TextBox ID="txtPackingQty4" runat="server" CssClass="TextBox PackingQty" MaxLength="10" />
                        <asp:TextBox ID="txtPackingQty5" runat="server" CssClass="TextBox PackingQty" MaxLength="10" /></div>
                    <%--style="display: none"--%>
                </div>
                <div id="divline_Booking" runat="server" class="divline">
                    <asp:Label ID="lblBooking" runat="server" CssClass="Label CarogTime" Text="<%$ Resources:lblBooking %>" />
                    <asp:TextBox ID="txtBooking" runat="server" ReadOnly="true" CssClass="TextBox txtDate"
                        MaxLength="20" />
                    <asp:Label ID="lblJobNo" runat="server" CssClass="Label" Text="<%$ Resources:lblJobNo %>" />
                    &nbsp
                    <asp:TextBox ID="txtJobNo" runat="server" ReadOnly="true" CssClass="TextBox txtJobNo"
                        MaxLength="20" />
                </div>
            </div>
        </div>
        <div id="divMiddle2" class="divMiddle">
            <div>
                <asp:DropDownList ID="drDimension" runat="server">
                    <asp:ListItem Value="0">CM</asp:ListItem>
                    <asp:ListItem Value="1">IN</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div id="divSource" style="width: 99%; height: 400px;">
                <asp:GridView ID="gvwDimension" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                    CssClass="GvwView2" OnRowDataBound="gvwDimension_RowDataBound">
                    <%-- --%>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="hid_LineItemNo" runat="server" Value='<%# Eval("LineItemNo") %>' />
                                <a id="Img2" runat="server" alt="del">
                                    <img id="Img3" runat="server" src="../Images/Edit/ed_Delete.gif" alt="del" />
                                </a>
                            </ItemTemplate>
                            <ItemStyle CssClass="colNo taLeft" />
                            <HeaderStyle CssClass="colNo taCenter" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="S/No">
                            <ItemTemplate>
                                <asp:Label ID="lblNo" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="colNo taLeft" Width="30px" />
                            <HeaderStyle CssClass="colNo taCenter" Width="30px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pcs">
                            <ItemTemplate>
                                <asp:TextBox ID="txtPcs" runat="server" Text='<%# Eval("Pcs") %>' MaxLength="9" CssClass="TextBox txtField" />
                            </ItemTemplate>
                            <ItemStyle CssClass="colModifyBy taLeft" />
                            <HeaderStyle CssClass="colModifyBy taCenter" />
                            <FooterStyle CssClass="taRight" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Weight">
                            <ItemTemplate>
                                <asp:TextBox ID="txtWeight" runat="server" Text='<%# Eval("Weight") %>' CssClass="TextBox txtField" />
                            </ItemTemplate>
                            <ItemStyle CssClass="colTable taLeft" />
                            <HeaderStyle CssClass="colTable taCenter" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Length">
                            <ItemTemplate>
                                <asp:TextBox ID="txtLength" runat="server" Text='<%# Eval("Length") %>' CssClass="TextBox txtField" />
                            </ItemTemplate>
                            <ItemStyle CssClass="colFieldName taLeft" />
                            <HeaderStyle CssClass="colFieldName taCenter" />
                            <FooterStyle CssClass="taRight" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Width">
                            <ItemTemplate>
                                <asp:TextBox ID="txtWidth" runat="server" Text='<%# Eval("Width") %>' CssClass="TextBox txtField" />
                            </ItemTemplate>
                            <FooterStyle CssClass="taRight" />
                            <HeaderStyle CssClass="colType taCenter" />
                            <ItemStyle CssClass="colType taLeft" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Height">
                            <ItemTemplate>
                                <asp:TextBox ID="txtHeight" runat="server" Text='<%# Eval("Height") %>' CssClass="TextBox txtField" />
                            </ItemTemplate>
                            <ItemStyle CssClass="colLen taLeft" />
                            <HeaderStyle CssClass="colLen taCenter" />
                            <FooterStyle CssClass="taRight" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Volume">
                            <ItemTemplate>
                                <asp:Label ID="txtVolume" runat="server" Text='<%# Eval("Volume") %>' CssClass="txtField" />
                            </ItemTemplate>
                            <FooterStyle CssClass="taRight" />
                            <HeaderStyle CssClass="colView taCenter" />
                            <ItemStyle CssClass="colView taLeft" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="Header" />
                    <FooterStyle CssClass="Footer" />
                    <RowStyle CssClass="Row" />
                    <SelectedRowStyle CssClass="SelectRow" />
                    <PagerStyle CssClass="Pager" />
                    <AlternatingRowStyle CssClass="Alternating" />
                    <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />
                </asp:GridView>
            </div>
            <div>
                <asp:Label ID="lbTotalPcs" CssClass="Label " runat="server" Text="Total Pcs:" />
                <div id="divTotalPcs" style="display: inline">
                    <asp:Label ID="txtTotalPcs" CssClass="Label lbl" runat="server" Text="0" /></div>
                &nbsp
                <asp:Label ID="lblTotalWeight" CssClass="Label " runat="server" Text="Weight:" />
                <div id="divTotalWeight" style="display: inline">
                    <asp:Label ID="txtTotalWeight" CssClass="Label lbl" runat="server" Text="0" /></div>
                &nbsp
                <asp:Label ID="lbTotalVolumn" CssClass="Label " runat="server" Text="Volume:" />
                <div id="divTotalVolumn" style="display: inline">
                    <asp:Label ID="txtTotalVolumn" CssClass="Label" runat="server" Text="0" />
                    &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp M3</div>
            </div>
        </div>
        <div id="divMiddle3" class="divMiddle">
            <div id="divAttach" style="height: 542px;">
                <asp:GridView ID="gvwAttach" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                    OnRowDataBound="gvwAttach_RowDataBound" Width="540px" CssClass="GvwView">
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
            <div class="divline">
            </div>
        </div>
        <div id="divBottomNav" style="width: 100%;">
            <asp:Button ID="btnUpdate" runat="server" Text="<%$ Resources:btnUpdate %>" CssClass="Button"
                UseSubmitBehavior="False" />
            <asp:Button ID="btnPrint" runat="server" Text="<%$ Resources:btnPrint %>" CssClass="Button"
                UseSubmitBehavior="False" />
            <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:btnSave.Text %>" CssClass="Button"
                UseSubmitBehavior="False" />
            <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose.Text %>" CssClass="Button"
                UseSubmitBehavior="False" />
            <asp:Button ID="btnSend0" runat="server" Text="Send" CssClass="Button" UseSubmitBehavior="False"
                Width="120px" Visible="false" />
        </div>
        <input name='txtTRLastIndex' type='hidden' id='txtTRLastIndex' value="1" />
        <div id="div_fldId">
            <asp:HiddenField ID="fldId" runat="server" />
        </div>
        <asp:HiddenField ID="hid_OrderNo" runat="server" />
        <asp:HiddenField ID="hid_UomCode" runat="server" />
        <asp:HiddenField ID="hid_AlirlineID" runat="server" />
        <asp:HiddenField ID="hid_moduleCode" runat="server" />
        <div id="div_CheckVal" style="display: none">
        </div>
        <asp:HiddenField ID="hid_CheckVal" runat="server" />
        <div id="divNull">
        </div>
        <asp:HiddenField ID="hidUserNo" runat="server" />
        <asp:HiddenField ID="hidReports" runat="server" />
        <asp:HiddenField ID="hidOrderNoBarCode" runat="server" />
    </div>
    </form>
</body>
</html>
