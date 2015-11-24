<%@ Page Language="VB" AutoEventWireup="true" CodeFile="StoringOrderEdit.aspx.vb"
    Inherits="StoringOrderEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <base target="_self"></base>
    <style type="text/css">
        @import url("<%=ConfigPath%>/LrErp.css");
        @import url("<%=ConfigPath%>/LrErp_Grid.css");
        @import url("<%=ConfigPath%>/LrErp_List.css");
        @import url("<%=ConfigPath%>/PageControl.css");
    </style>
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/StoringOrderEdit.css" rel="Stylesheet" type="text/css" />
    <link href="../UserControl/datepicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="JavaScript/SOEdit.js" -->
    <!-- #include file="../JavaScript/DateOperate.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script language="javascript" type="text/javascript" src="../UserControl/datepicker/WdatePicker.js"></script>

    <script language="javascript" type="text/javascript">
     function on_page_loaded()   
     {   
       blChanged=true;CloseWindow(0);return false;
     }
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

    <style type="text/css">
        html, body
        {
            overflow: hidden;
        }
    </style>
</head>
<body onunload="on_page_loaded()">

    <script type="text/javascript">
function WebForm_CallbackComplete_SyncFixed() {
  // SyncFix: the original version uses "i" as global thereby resulting in javascript errors when "i" is used elsewhere in consuming pages
  for (var i = 0; i < __pendingCallbacks.length; i++) {
   callbackObject = __pendingCallbacks[ i ];
  if (callbackObject && callbackObject.xmlRequest && (callbackObject.xmlRequest.readyState == 4)) {
   if (!__pendingCallbacks[ i ].async) {
     __synchronousCallBackIndex = -1;
   }
   __pendingCallbacks[i] = null;

   var callbackFrameID = "__CALLBACKFRAME" + i;
   var xmlRequestFrame = document.getElementById(callbackFrameID);
   if (xmlRequestFrame) {
     xmlRequestFrame.parentNode.removeChild(xmlRequestFrame);
   }
   WebForm_ExecuteCallback(callbackObject);
  }
 }
}

window.onload = function(){
if (typeof (WebForm_CallbackComplete) == "function") {
  // set the original version with fixed version
  WebForm_CallbackComplete = WebForm_CallbackComplete_SyncFixed;
}
}
    </script>

    <form id="frmStoringOrderEdit" runat="server" style="overflow-x: hidden;">
    <div id="popupMenu" class="skin" runat="server" onclick="ClickItem()" onmousemove="HighlighItem()"
        onmouseout="LowlightItem()">
    </div>
    <div id="divForm">
        <div id="Div2" class="skin" runat="server" onclick="ClickItem()" onmousemove="HighlighItem()"
            onmouseout="LowlightItem()">
        </div>
        <div id="divTopNav" style="width: 1024px;">
            <ul id="ulTopNav">
                <%--                    <li>
                        <asp:Label ID="Label1" CssClass="f12e navNml navOn" runat="server" Text="<%$ Resources:a1.Text %>"
                            Width="150px"></asp:Label></li>--%>
            </ul>
        </div>
        <div id="SaveHint" runat="server" class="Hint" style="left: 0px; top: 10px">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>" />
        </div>
        <div id="divMiddle1" style="padding-top: 10px" style="width: 1024px;">
            <div id="divMiddle11">
                <div class="divline" style="display: none;">
                    <asp:TextBox ID="txtSON" CssClass="Label lbl" runat="server" />
                    <asp:TextBox ID="txtSiteCode" runat="server" CssClass="TextBox txt" MaxLength="5" />
                    <asp:TextBox ID="txtUserNo" runat="server" CssClass="TextBox txt" MaxLength="5" />
                </div>
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td class="tdF">
                            <asp:Label ID="lblOrganizationCode" CssClass="Label lbl1" runat="server" Text="<%$ Resources:lblOrganizationCode %>" />
                        </td>
                        <td class="tdtxt" style="width: 360px;">
                            <asp:TextBox ID="txtOrganization" runat="server" CssClass="TextBox txt" MaxLength="10"
                                Width="320px" />
                        </td>
                        <td class="td">
                            <asp:Label ID="lblDepotCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblDepotCode %>" />
                        </td>
                        <td class="tdtxt">
                            <asp:TextBox ID="txtDepotCode" runat="server" CssClass="TextBox txt" MaxLength="10"
                                TabIndex="18" />
                            <asp:Button ID="btnDepotCode" runat="server" CssClass="Button bntDate" Text="..."
                                UseSubmitBehavior="False" TabIndex="19" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdF">
                            <asp:Label ID="lblJobNo" runat="server" CssClass="Label lbl1" Text="<%$ Resources:lblJobNo %>" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtJobNo" runat="server" CssClass="TextBox txt" MaxLength="20" TabIndex="1" />
                            <asp:Button ID="btnJobNo" runat="server" CssClass="Button bntDate" Text="..." UseSubmitBehavior="False"
                                Visible="false" TabIndex="3" />
                        </td>
                        <td class="td">
                            <asp:Label ID="lblPortOfDischarge" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblPortOfDischarge %>" />
                        </td>
                        <td class="tdtxt">
                            <asp:TextBox ID="txtPortOfLoading" runat="server" CssClass="TextBox txt" MaxLength="5"
                                TabIndex="20" />
                            <asp:Button ID="btnPortOfLoading" runat="server" CssClass="Button bntDate" Text="..."
                                UseSubmitBehavior="False" TabIndex="21" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdF">
                            <asp:Label ID="lblVesselName" runat="server" CssClass="Label lbl1" Text="<%$ Resources:lblVesselName %>" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtVesselName" runat="server" CssClass="TextBox txt" MaxLength="50"
                                Width="320px" TabIndex="4" />
                        </td>
                        <td class="td">
                            <asp:Label ID="lblDemurrageCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblDemurrageCode %>" />
                        </td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="tdtxt">
                                        <asp:DropDownList ID="drDemurrageCode" runat="server" CssClass="DropList DropDown" TabIndex="22" />
                                    </td>
                                    <td class="td">
                                        <asp:Label ID="Label3" runat="server" CssClass="Label Prot" Text="<%$ Resources:lblFreePeriod %>" />
                                    </td>
                                    <td class="tdtxt">
                                        <asp:TextBox ID="txtDemurrageFreeDay" runat="server" CssClass="TextBox txt" MaxLength="4"
                                            Width="64px" TabIndex="23" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdF">
                            <asp:Label ID="lblVoyageNo" runat="server" CssClass="Label lbl1" Text="<%$ Resources:lblVoyageNo %>" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtVoyageNo" runat="server" CssClass="TextBox txt" MaxLength="12"
                                TabIndex="5" />
                        </td>
                        <td class="td">
                            <asp:Label ID="lblDemurrageSD" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblDetentionStart %>" />
                        </td>
                        <td class="tdtxt">
                            <asp:TextBox ID="txtDemurrageSD" runat="server" CssClass="TextBox txt" MaxLength="15"
                                TabIndex="24"/>
                            <asp:Button ID="btnDemurrageSD" runat="server" CssClass="Button bntDate" Text="..."
                                UseSubmitBehavior="False" TabIndex="25" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdF">
                            <asp:Label ID="lblETA" runat="server" CssClass="Label lbl1" Text="<%$ Resources:lblETA %>" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtETA" runat="server" CssClass="TextBox txt" MaxLength="15" TabIndex="6" />
                            <asp:Button ID="btnETA" runat="server" CssClass="Button bntDate" Text="..." UseSubmitBehavior="False"
                                TabIndex="7" />
                        </td>
                        <td class="td">
                            <asp:Label ID="lblDetentionCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblDetentionCode %>" />
                        </td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="tdtxt">
                                        <asp:DropDownList ID="drDetentionCode" runat="server" CssClass="DropList DropDown" TabIndex="26" />
                                    </td>
                                    <td class="td">
                                        <asp:Label ID="lblFreePeriod" runat="server" CssClass="Label Prot" Text="<%$ Resources:lblFreePeriod %>" />
                                    </td>
                                    <td class="tdtxt">
                                        <asp:TextBox ID="txtDetentionFreeDay" runat="server" CssClass="TextBox txt" MaxLength="4"
                                            Width="64px" TabIndex="27" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdF">
                            <asp:Label ID="lblReturnType" runat="server" CssClass="Label lbl1" Text="<%$ Resources:lblReturnType %>" />
                        </td>
                        <td>
                            <asp:DropDownList ID="drReturnType" runat="server" TabIndex="8" CssClass="DropList" />
                        </td>
                        <td class="td">
                            <asp:Label ID="lblDetentionStart" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblDetentionStart %>" />
                        </td>
                        <td class="tdtxt">
                            <asp:TextBox ID="txtDetentionStart" runat="server" CssClass="TextBox txt" MaxLength="15"
                                TabIndex="27" />
                            <asp:Button ID="btnDetentionStart" runat="server" CssClass="Button bntDate" Text="..."
                                UseSubmitBehavior="False" TabIndex="28" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdF">
                            <asp:Label ID="lblConsigneeCode" runat="server" CssClass="Label lbl1" Text="<%$ Resources:lblConsigneeCode %>" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtConsigneeCode" runat="server" CssClass="TextBox txt" MaxLength="10"
                                TabIndex="9" />
                            <asp:Button ID="btnConsigneeCode" runat="server" CssClass="Button bntDate" Text="..."
                                UseSubmitBehavior="False" TabIndex="10" />
                        </td>
                        <td class="tdF">
                            <asp:Label ID="lblRefNo" runat="server" CssClass="Label lbl1" Text="<%$ Resources:lblRefNo %>" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtRefNo" runat="server" CssClass="TextBox txt" MaxLength="50" Width="310px"
                                TabIndex="29" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdF">
                            <asp:Label ID="lblConsigneeName" runat="server" CssClass="Label lbl1" Text="<%$ Resources:lblConsigneeName %>" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtConsigneeName" runat="server" CssClass="TextBox 2Ltxt" MaxLength="50"
                                Width="320px" TabIndex="11" />
                        </td>
                        <td class="td" rowspan="3">
                            <asp:Label ID="lblInstructionTD" runat="server" CssClass="Label lbl lblTop" Text="<%$ Resources:lblInstructionTD %>"
                                Height="50px" />
                        </td>
                        <td class="tdtxt" rowspan="3">
                            <asp:TextBox ID="txtInstructionTD" runat="server" CssClass="TextBox 2Ltxt" MaxLength="50"
                                TextMode="MultiLine" Height="50px" Width="309px" TabIndex="30" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdF">
                            <asp:Label ID="lblConsigneeAddress" runat="server" CssClass="Label lbl1" Text="<%$ Resources:lblConsigneeAddress %>" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtConsigneeAddress1" runat="server" CssClass="TextBox 2Ltxt" MaxLength="45"
                                Width="320px" TabIndex="12" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdF">
                        </td>
                        <td>
                            <asp:TextBox ID="txtConsigneeAddress2" runat="server" CssClass="TextBox 2Ltxt" MaxLength="45"
                                Width="320px" TabIndex="13" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdF">
                        </td>
                        <td>
                            <asp:TextBox ID="txtConsigneeAddress3" runat="server" CssClass="TextBox 2Ltxt" MaxLength="45"
                                Width="320px" TabIndex="14" />
                        </td>
                        <td class="td">
                            <asp:Label ID="lblTruckerCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblTruckerCode %>" />
                        </td>
                        <td class="tdtxt">
                            <asp:TextBox ID="txtTruckerCode" runat="server" CssClass="TextBox txt" MaxLength="10"
                                TabIndex="31" />
                            <asp:Button ID="btnTruckerCode" runat="server" CssClass="Button bntDate" Text="..."
                                UseSubmitBehavior="False" TabIndex="32" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdF">
                        </td>
                        <td>
                            <asp:TextBox ID="txtConsigneeAddress4" runat="server" CssClass="TextBox 2Ltxt" MaxLength="45"
                                Width="320px" TabIndex="15" />
                        </td>
                        <td class="td">
                            <asp:Label ID="lblTruckerName" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblTruckerName %>" />
                        </td>
                        <td class="tdtxt">
                            <asp:TextBox ID="txtTruckerName" runat="server" CssClass="TextBox txt" MaxLength="50"
                                Width="310px" TabIndex="33" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdF">
                            <asp:Label ID="lblContactPerson" runat="server" CssClass="Label lbl1" Text="<%$ Resources:lblContactPerson %>" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtContactPerson" runat="server" CssClass="TextBox txt" MaxLength="50"
                                Width="320px" TabIndex="16" />
                        </td>
                        <td class="td">
                            <asp:Label ID="lblTruckingCD" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblTruckingCD %>" />
                        </td>
                        <td class="tdtxt">
                            <asp:TextBox ID="txtTruckingCD" runat="server" CssClass="TextBox txt" MaxLength="15"
                                TabIndex="34" />
                            <asp:Button ID="btnTruckingCD" runat="server" CssClass="Button bntDate" Text="..."
                                UseSubmitBehavior="False" TabIndex="35" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdF">
                            <asp:Label ID="lblContactNo" runat="server" CssClass="Label lbl1" Text="<%$ Resources:lblContactNo %>" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtContactNo" runat="server" CssClass="TextBox txt" MaxLength="50"
                                Width="320px" TabIndex="17" />
                        </td>
                        <td class="td">
                            <asp:Label ID="lblTruckerRefNo" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblTruckerRefNo %>" />
                        </td>
                        <td class="tdtxt">
                            <asp:TextBox ID="txtTruckerRefNo" runat="server" CssClass="TextBox txt" MaxLength="50"
                                Width="310px" TabIndex="36" />
                        </td>
                    </tr>
                </table>
                <br />
                <div id="divSource" class="divSource1" style="height: 260px; width: 1010px" runat="server">
                    <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                        OnRowDataBound="gvwSource_RowDataBound">
                        <HeaderStyle CssClass="Header" />
                        <FooterStyle CssClass="Footer" />
                        <RowStyle CssClass="Row" />
                        <SelectedRowStyle CssClass="SelectRow" />
                        <PagerStyle CssClass="Pager" />
                        <AlternatingRowStyle CssClass="Alternating" />
                    </asp:GridView>
                </div>
                <div id="divPage">
                    <div class="fLeft">
                        <asp:Label ID="lblPage" runat="server" Text="Page"></asp:Label>
                        <asp:LinkButton ID="lbtnFirst" runat="server" Text="First"></asp:LinkButton>
                        <asp:LinkButton ID="lbtnPrior" runat="server" Text="Prior"></asp:LinkButton>
                        <asp:LinkButton ID="lbtnNext" runat="server" Text="Next"></asp:LinkButton>
                        <asp:LinkButton ID="lbtnLast" runat="server" Text="Last"></asp:LinkButton>
                        <asp:LinkButton ID="lbtnGoTo" runat="server" Text="Go to"></asp:LinkButton>
                        <asp:TextBox ID="txtPage" runat="server" CssClass="txInput"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div id="divBottomNav">
            <asp:Button ID="btnContainer" runat="server" Text="Container No" CssClass="Button"
                UseSubmitBehavior="False" TabIndex="100" Width="80px" />
            <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:btnSave %>" CssClass="Button"
                UseSubmitBehavior="False" TabIndex="100" />
            <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose %>" CssClass="Button"
                UseSubmitBehavior="False" TabIndex="100" />
            <asp:Button ID="btnComputerDC" runat="server" Text="<%$ Resources:btnComputerDC %>"
                CssClass="Button" UseSubmitBehavior="False" Width="170px" Visible="false" />
            <asp:Button ID="btnReceiveContainer" runat="server" Text="<%$ Resources:btnReceiveContainer %>"
                CssClass="Button" UseSubmitBehavior="False" Width="120px" Visible="false" />&nbsp
        </div>
        <div id="divTrxNo">
            <asp:HiddenField ID="fldId" runat="server" />
        </div>
        <asp:HiddenField ID="hidSiteCode" runat="server" />
        <asp:HiddenField ID="HidTitle" runat="server" Value="<%$ Resources:a1 %>" />
        <asp:HiddenField ID="hidConfig" runat="server" />
    </div>
    </form>
</body>
</html>

<script type="text/javascript" language="javascript">
    setConfig();
</script>

