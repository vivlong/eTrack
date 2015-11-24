<%@ Page Language="VB" AutoEventWireup="true" CodeFile="CELEdit.aspx.vb" Inherits="CELEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        @import url("<%=ConfigPath%>/LrErp.css");
        @import url("<%=ConfigPath%>/PageControl.css");
    </style>
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/CELEdit.css" rel="Stylesheet" type="text/css" />
    <link href="../UserControl/datepicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/PageControl.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="../JavaScript/DateOperate.js" -->
    <!-- #include file="JavaScript/CELEdit.js" -->

    <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

    <script language="javascript" type="text/javascript" src="../UserControl/datepicker/WdatePicker.js"></script>

    <script language="javascript" type="text/javascript">
    function on_page_loaded()
    {   
      blChanged=true;CloseWindow(0);return false;
    }
         function setConfig(strConfig)
     {
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
         case "Smalt":
                colorSecond="#e8e8ec";
                colorSelected="#d9cfdd";
                break ;
         default :
                colorSecond="#e6eff8";
                colorSelected="#9fbbe2";
                break ;
       }
     }
    </script>

</head>
<body onunload="on_page_loaded()" onload="setConfig('<%=ExportConfig%>');">
    <form id="frmCELEdit" runat="server">
    <div id="divForm">
        <div id="divTopNav">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="a1" CssClass="f12e navNml navOn" runat="server" Text="<%$ Resources:a1 %>" /></li>
            </ul>
        </div>
        <div class="divline" style="display: none;">
            <asp:TextBox ID="txtUserId" runat="server" CssClass="TextBox txt" MaxLength="50" />
        </div>
        <div id="SaveHint" runat="server" class="Hint">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>"> </asp:Label>
        </div>
        <div id="divMiddle1">
            <div class="divline">
                <asp:Label ID="lblContainerNo" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblContainerNo %>" />
                <asp:TextBox ID="txtContainerNo" runat="server" CssClass="TextBox txt" MaxLength="13" />
            </div>
            <div class="divline">
                <asp:Label ID="lblEquipmentType" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblEquipmentType %>" />
                <asp:TextBox ID="txtEquipmentType" runat="server" CssClass="TextBox txt" MaxLength="5" />
                <asp:Button ID="btnEquipmentType" runat="server" CssClass="Button btnDate" Text="..."
                    UseSubmitBehavior="False" />
            </div>
            <div class="divline">
                <asp:Label ID="lblSiteCode" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblSiteCode %>" />
                <asp:TextBox ID="txtSiteCode" runat="server" CssClass="TextBox txt" MaxLength="10" />
                <asp:Button ID="btnSiteCode" runat="server" CssClass="Button btnDate" Text="..."
                    UseSubmitBehavior="False" />
            </div>
            <div class="divline">
                <asp:Label ID="lblEventPortCode" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblEventPortCode %>" />
                <asp:TextBox ID="txtEventPortCode" runat="server" CssClass="TextBox txt" MaxLength="5" />
                <asp:Button ID="btnEventPortCode" runat="server" CssClass="Button btnDate" Text="..."
                    UseSubmitBehavior="False" />
            </div>
            <div class="divline">
                <asp:Label ID="lblEventCode" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblEventCode %>" />
                <asp:DropDownList ID="drEventCode" runat="server" CssClass="txt DropDown DropList" />
            </div>
            <div class="divline">
                <asp:Label ID="lblState" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblState %>" />
                <asp:TextBox ID="drState" runat="server" CssClass="TextBox txt" ReadOnly="true" />
            </div>
            <div class="divline">
                <asp:Label ID="lblEventDate" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblEventDate %>" />
                <asp:TextBox ID="txtEventDate" runat="server" CssClass="TextBox txt" MaxLength="15" />
                <asp:Button ID="btnEventDate" runat="server" CssClass="Button btnDate" Text="..."
                    UseSubmitBehavior="False" />
            </div>
            <div class="divline">
                <asp:Label ID="lblJobNo" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblJobNo %>" />
                <asp:TextBox ID="txtJobNo" runat="server" CssClass="TextBox txt" MaxLength="20" />
            </div>
            <div class="divline">
                <asp:Label ID="lblShipperCode" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblShipperCode %>" />
                <asp:TextBox ID="txtShipperCode" runat="server" CssClass="TextBox txt" MaxLength="10" />
                <asp:Button ID="btnShipperCode" runat="server" CssClass="Button btnDate" Text="..."
                    UseSubmitBehavior="False" />
            </div>
            <div class="divline">
                <asp:Label ID="lblShipperName" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblShipperName %>" />
                <asp:TextBox ID="txtShipperName" runat="server" CssClass="TextBox txt" MaxLength="50" />
            </div>
            <div class="divline">
                <asp:Label ID="lblPortOfLoading" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblPortOfLoading %>" />
                <asp:TextBox ID="txtPortOfLoading" runat="server" CssClass="TextBox txt" MaxLength="5" />
                <asp:Button ID="btnPortOfLoading" runat="server" CssClass="Button btnDate" Text="..."
                    UseSubmitBehavior="False" />
            </div>
            <div class="divline">
                <asp:Label ID="lblFinalDestination" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblFinalDestination %>" />
                <asp:TextBox ID="txtFinalDestination" runat="server" CssClass="TextBox txt" MaxLength="5" />
                <asp:Button ID="btnFinalDestination" runat="server" CssClass="Button btnDate" Text="..."
                    UseSubmitBehavior="False" />
            </div>
            <div class="divline">
                <asp:Label ID="lblVesselName" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblVesselName %>" />
                <asp:TextBox ID="txtVesselName" runat="server" CssClass="TextBox txt" MaxLength="50" />
            </div>
            <div class="divline">
                <asp:Label ID="lblVoyageNo" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblVoyageNo %>" />
                <asp:TextBox ID="txtVoyageNo" runat="server" CssClass="TextBox txt" MaxLength="12" />
            </div>
            <div class="divline">
                <asp:Label ID="lblConsigneeCode" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblConsigneeCode %>" />
                <asp:TextBox ID="txtConsigneeCode" runat="server" CssClass="TextBox txt" MaxLength="10" />
                <asp:Button ID="btnConsigneeCode" runat="server" CssClass="Button btnDate" Text="..."
                    UseSubmitBehavior="False" />
            </div>
            <div class="divline">
                <asp:Label ID="lblConsigneeName" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblConsigneeName %>" />
                <asp:TextBox ID="txtConsigneeName" runat="server" CssClass="TextBox txt" MaxLength="50" />
            </div>
            <div class="divline">
                <asp:Label ID="lblDepotCode" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblDepotCode %>" />
                <asp:TextBox ID="txtDepotCode" runat="server" CssClass="TextBox txt" MaxLength="10" />
                <asp:Button ID="btnDepotCode" runat="server" CssClass="Button btnDate" Text="..."
                    UseSubmitBehavior="False" />
            </div>
            <div class="divline">
                <asp:Label ID="lblTruckerName" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblTruckerName %>" />
                <asp:TextBox ID="txtTruckerName" runat="server" CssClass="TextBox txt" MaxLength="50" />
            </div>
            <div class="divline">
                <asp:Label ID="lblVehicleNo" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblVehicleNo %>" />
                <asp:TextBox ID="txtVehicleNo" runat="server" CssClass="TextBox txt" MaxLength="25" />
            </div>
            <div class="divline">
                <asp:Label ID="lblSealNo" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblSealNo %>" />
                <asp:TextBox ID="txtSealNo" runat="server" CssClass="TextBox txt" MaxLength="30" />
            </div>
            <div class="divline">
                <asp:Label ID="lblDGFlag" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblDGFlag %>" />
                <asp:DropDownList ID="drDGFlag" runat="server" CssClass="txt DropDown DropList" />
            </div>
            <div class="divline">
                <asp:Label ID="lblDriverPassNo" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblDriverPassNo %>" />
                <asp:TextBox ID="txtDriverPassNo" runat="server" CssClass="TextBox txt" MaxLength="20" />
            </div>
            <div class="divline">
                <asp:Label ID="lblDetentionCharge" runat="server" CssClass="Label lblShare" Text="<%$ Resources:lblDetentionCharge %>" />
                <asp:TextBox ID="txtDetentionCharge" runat="server" CssClass="TextBox txt" MaxLength="14" />
            </div>
            <div class="divline">
                <asp:Label ID="lblComputedDetentionCharge" runat="server" CssClass="Label lblShare"
                    Text="<%$ Resources:lblComputedDetentionCharge %>" />
                <asp:TextBox ID="txtComputedDetentionCharge" runat="server" CssClass="TextBox txt"
                    MaxLength="14" />
            </div>
            <div class="divline">
                <asp:Label ID="lblSurveyRemarks" runat="server" CssClass="Label lblRemark" Text="<%$ Resources:lblSurveyRemarks %>" />
                <asp:TextBox ID="txtSurveyRemarks" runat="server" CssClass="TextBox Remark" TextMode="multiLine" />
            </div>
            <div class="divline">
                <asp:Label ID="lblRemarks" runat="server" CssClass="Label lblRemark" Text="<%$ Resources:lblRemarks %>" />
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="TextBox Remark" TextMode="multiLine" />
            </div>
        </div>
        <div id="divBottomNav">
            <%--<asp:Button ID="btnBook" runat="server" Text="<%$ Resources:btnBook.Text %>" CssClass="Button"
                UseSubmitBehavior="False" />--%>
            <%--<asp:Button ID="btnNew" runat="server" Text="<%$ Resources:btnNew.Text %>" CssClass="Button"
                UseSubmitBehavior="False" />--%>
            <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:btnSave.Text %>" CssClass="Button"
                UseSubmitBehavior="False" />
            <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose.Text %>" CssClass="Button"
                UseSubmitBehavior="False" />&nbsp
        </div>
    </div>
    <asp:HiddenField ID="fldId" runat="server" />
    <asp:HiddenField ID="hidUserId" runat="server" />
    </form>
</body>
</html>
