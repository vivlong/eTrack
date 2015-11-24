<%@ Page Language="VB" AutoEventWireup="true" CodeFile="ReleasingOrderEdit.aspx.vb"
    Inherits="ReleasingOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title id="objTitle"></title>
    <style type="text/css">
        @import url("<%=ConfigPath%>/LrErp.css");
        @import url("<%=ConfigPath%>/LrErp_List.css");
        @import url("<%=ConfigPath%>/PageControl.css");
    </style>
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/ReleasingOrder.css" rel="Stylesheet" type="text/css" />
    <link href="../UserControl/datepicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="JavaScript/ROEdit.js" -->
    <!-- #include file="../JavaScript/DateOperate.js" -->

    <script language="javascript" type="text/javascript" src="../UserControl/datepicker/WdatePicker.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

    <script language="javascript" type="text/javascript">
     function setConfig()
     {
       var strConfig=document.getElementById("hidConfig").value;
       switch(strConfig)
       {
         case "Blue":
                colorSecond="#e6eff8";
                colorSelected="#9fbbe2";
                break ;
         case "Orange":
                colorSecond="#feecdb";
                colorSelected="#fecb99";
                break ;
         case "Blue":
                colorSecond="#e6eff8";
                colorSelected="#9fbbe2";
                break ;
         default :
                colorSecond="#e6eff8";
                colorSelected="#9fbbe2";
                break ;
       }
     }
    </script>

</head>
<body>
    <form id="frmReleasingOrder" runat="server">
    <div id="divForm">
        <div id="divTopNav">
            <ul id="ulTopNav">
                <li>
                    <%--<asp:Label ID="a1" CssClass="f12e navNml navOn" runat="server" Text="<%$ Resources:a1 %>"
                        Width="200px" />--%>
                </li>
            </ul>
        </div>
        <div id="SaveHint" runat="server" class="Hint" style="left: 0px; top: 10px">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>" />
        </div>
        <div id="divMiddle1" style="height: 520px; padding-top: 10px;">
            <div id="divMiddle21">
                <div class="divline" style="display: none;">
                    <asp:TextBox ID="txtRON" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblReleasingIN" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblReleasingIN %>" />
                    <asp:TextBox ID="txtReleasingIN" runat="server" CssClass="TextBox txt" MaxLength="20" />
                    &nbsp&nbsp&nbsp
                    <asp:Button ID="btnUpdateRON" runat="server" Text="Update Releasing Order No" CssClass="Button"
                        UseSubmitBehavior="False" Width="160px" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblShipperCode" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblShipperCode %>" />
                    <asp:TextBox ID="txtShipperCode" runat="server" CssClass="TextBox txt" MaxLength="10" />
                    <asp:Button ID="btnShipperCode" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblShipperName" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblShipperName %>" />
                    <asp:TextBox ID="txtShipperName" runat="server" CssClass="TextBox longTxt" MaxLength="50" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblEquipmentType" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblEquipmentType %>" />
                    <asp:TextBox ID="txtEquipmentType" runat="server" CssClass="TextBox txt" MaxLength="5" />
                    <asp:Button ID="btnEquipmentType" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblROReleaseDate" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblROReleaseDate %>" />
                    <asp:TextBox ID="txtROReleaseDate" runat="server" CssClass="TextBox txt" MaxLength="15" />
                    <asp:Button ID="btnROReleaseDate" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblQty" runat="server" Text="<%$ Resources:lblQty %>" CssClass="Label lbl" />
                    <asp:TextBox ID="txtQty" runat="server" CssClass="TextBox txtProt" MaxLength="4" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblReleaseQty" runat="server" Text="<%$ Resources:lblReleaseQty %>"
                        CssClass="Label lbl" />
                    <asp:TextBox ID="txtReleaseQty" runat="server" CssClass="TextBox txt" ReadOnly="true" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblDepotCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblDepotCode %>" />
                    <asp:TextBox ID="txtDepotCode" runat="server" CssClass="TextBox txt" MaxLength="10" />
                    <asp:Button ID="btnDepotCode" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                </div>
                <div class="divline">
                    <table class="divline" border="0px" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="td">
                                <asp:Label ID="lblInstructionTD" runat="server" CssClass="Label lblInstructionTD"
                                    Text="<%$ Resources:lblInstructionTD %>" />
                            </td>
                            <td rowspan="2" style="border: 0px">
                                <asp:TextBox ID="txtInstructionTD" runat="server" CssClass="TextBox txtlongTxt" MaxLength="1000"
                                    TextMode="MultiLine" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td" style="height: 30px; vertical-align: top;">
                                <asp:Button ID="btnITD" runat="server" Text="Instruction To Depot" CssClass=" Button btnITD"
                                    Width="140px" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="divline">
                    <asp:Label ID="lblTruckerCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblTruckerCode %>" />
                    <asp:TextBox ID="txtTruckerCode" runat="server" CssClass="TextBox txt" MaxLength="10" />
                    <asp:Button ID="btnTruckerCode" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblTruckerName" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblTruckerName %>" />
                    <asp:TextBox ID="txtTruckerName" runat="server" CssClass="TextBox longTxt" MaxLength="50" />
                </div>
                <div class="divline" style="display: none;">
                    <asp:Label ID="lblDateCollection" runat="server" CssClass="Label lbl lblTop" Text="<%$ Resources:lblDateCollection %>" />
                    <asp:TextBox ID="txtDateCollection" runat="server" CssClass="TextBox txt" MaxLength="16" />
                    <asp:Button ID="btnDateCollection" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                </div>
                <br />
                <fieldset id="fsPreCool" runat="server" style="width: 800px;">
                    <legend>
                        <asp:Label ID="lblPreCool" runat="server" CssClass="Label" Text="<%$ Resources:lblPreCool %>" /></legend>
                    <br />
                    <div class="divline">
                        <asp:Label ID="lblPreCoolFlag" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblPreCoolFlag %>" />
                        <asp:DropDownList ID="drPreCoolFlag" runat="server" CssClass="DropDown" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblPreSetTemp" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblPreSetTemp %>" />
                        <asp:DropDownList ID="drPreSetSign" runat="server" />
                        &nbsp
                        <asp:TextBox ID="txtPreSetTemp" runat="server" CssClass="TextBox txt" MaxLength="8" />&nbsp
                        <asp:DropDownList ID="drPreSetType" runat="server" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblCommodity" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblCommodity %>" />
                        <asp:TextBox ID="txtCommodity" runat="server" CssClass="TextBox longTxt" MaxLength="50" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblVoltage" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblVoltage %>" />
                        <asp:DropDownList ID="drVoltage" runat="server" CssClass="DropDown" />
                    </div>
                    <br />
                </fieldset>
            </div>
            <br />
        </div>
        <div id="divBottomNav">
            <asp:Button ID="btnNew" runat="server" Text="<%$ Resources:btnNew %>" CssClass="Button"
                UseSubmitBehavior="False" Visible="false" />
            <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:btnSave %>" CssClass="Button"
                UseSubmitBehavior="False" />
            <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose %>" CssClass="Button"
                UseSubmitBehavior="False" />
            &nbsp
        </div>
        <asp:HiddenField ID="HidLineItemNo" runat="server" />
        <asp:HiddenField ID="HidTrxNo" runat="server" />
        <asp:HiddenField ID="HidEditState" runat="server" />
        <asp:HiddenField ID="hidConfig" runat="server" />
    </div>
    </form>
</body>
</html>

<script type="text/javascript" language="javascript">
    setConfig();
</script>

