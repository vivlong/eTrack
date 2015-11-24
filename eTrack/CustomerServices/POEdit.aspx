<%@ Page Language="VB" AutoEventWireup="true" CodeFile="POEdit.aspx.vb" Inherits="POEdit" %>

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
    <link href="App_Themes/POEdit.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>

    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="JavaScript/POEdit.js" -->
    <!-- #include file="JavaScript/POEditFun.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"> </script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

</head>
<body>

    <script type="text/javascript">
        function WebForm_CallbackComplete_SyncFixed() {
            // SyncFix: the original version uses "i" as global thereby resulting in javascript errors when "i" is used elsewhere in consuming pages
            for (var i = 0; i < __pendingCallbacks.length; i++) {
                callbackObject = __pendingCallbacks[i];
                if (callbackObject && callbackObject.xmlRequest && (callbackObject.xmlRequest.readyState == 4)) {
                    if (!__pendingCallbacks[i].async) {
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

        window.onload = function() {
            if (typeof (WebForm_CallbackComplete) == "function") {
                // set the original version with fixed version
                WebForm_CallbackComplete = WebForm_CallbackComplete_SyncFixed;
            }
        }
    </script>

    <form id="frmBookingFormEdit" runat="server">
    <div id="divForm">
        <div id="divTopNav" runat="server" style="width: 100%">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="a1" runat="server" CssClass="f12e navNml navOn" Width="165px" onclick="SelectedDiv(1,4);SetTab(1);"
                        Text="<%$ Resources:a1 %>"></asp:Label></li>
                <li>
                    <asp:Label ID="a2" CssClass="f12c navNml noSep" runat="server" Width="120px" onclick="SelectedDiv(2,4);SetTab(2);"
                        Text="<%$ Resources:a2 %>" /></li>
                <li>
                    <asp:Label ID="a3" CssClass="f12c navNml noSep" runat="server" Width="120px" onclick="SelectedDiv(3,4);SetTab(3);"
                        Text="<%$ Resources:a3 %>" /></li>
                <li>
                    <asp:Label ID="a4" CssClass="f12c navNml noSep" runat="server" Width="165px" onclick="SelectedDiv(4,4);"
                        Text="<%$ Resources:a4 %>" /></li>
            </ul>
        </div>
        <div id="SaveHint" runat="server" class="Hint" style="left: 0px; top: 10px">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>" />
        </div>
        <div id="divTop" runat="server" class="divBorder" style="height: 610px; width: 100%;
            padding-left: 10px; padding-top: 10px;">
            <div class="divline" style="padding-top: 10px; padding-left: 20px;">
                <asp:Label ID="lblPartial" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblPartial %>" />
                <asp:RadioButtonList ID="rbPartial" runat="server" RepeatColumns="2" RepeatLayout="Flow">
                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                    <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="divline divPanding" style="text-align: center">
                <span class="Label">Ship To Information (default
                    <asp:CheckBox ID="chkShipTo" runat="server" />
                    )</span>
            </div>
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td style="border: 0">
                        <div id="divMiddle11" class="divLeft" style="padding-left: 10px;">
                            <div class="divline">
                                <asp:Label ID="lblCompanyName" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblCompanyName %>" />
                                <asp:TextBox ID="txtCompanyName" runat="server" CssClass="TextBox txt" MaxLength="50" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblFirstName" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblFirstName %>" />
                                <div id="div_drop" style="display: inline">
                                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="TextBox txt" MaxLength="50" />
                                </div>
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblAddress" runat="server" Text="<%$ Resources:lblAddress %>" CssClass="Label lbl" />
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="TextBox txt" MaxLength="100" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblCountry" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblCountry %>" />
                                <asp:DropDownList ID="drCountry" runat="server" CssClass="DropList" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblPostalCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblPostalCode %>" />
                                <asp:TextBox ID="txtPostalCode" runat="server" CssClass="TextBox txt" MaxLength="50" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblPhone" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblPhone %>" />
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="TextBox txt" MaxLength="50" />
                            </div>
                        </div>
                        <div id="divMiddle12" class="divLeft" style="padding-left: 10px;">
                            <div class="divline">
                                <asp:Label ID="lblEmailAddress" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblEmailAddress %>" />
                                <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="TextBox txt" MaxLength="50" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblLastName" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblLastName %>" />
                                <div id="div1" style="display: inline">
                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="TextBox txt" MaxLength="50" />
                                </div>
                            </div>
                            <div id="div2" runat="server" class="divline">
                                <asp:Label ID="lblAddress2" runat="server" Text="<%$ Resources:lblAddress2 %>" CssClass="Label lbl" />
                                <asp:TextBox ID="txtAddress2" runat="server" CssClass="TextBox txt" MaxLength="100" />
                            </div>
                            <div id="div3" runat="server" class="divline">
                                <asp:Label ID="lblState" runat="server" Text="<%$ Resources:lblState %>" CssClass="Label lbl" />
                                <asp:TextBox ID="txtState" runat="server" CssClass="TextBox txt" MaxLength="20" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblCity" runat="server" Text="<%$ Resources:lblCity %>" CssClass="Label lbl" />
                                <asp:DropDownList ID="drCity" runat="server" CssClass="DropList txt" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblFax" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblFax %>" />
                                <asp:TextBox ID="txtFax" runat="server" CssClass="TextBox txt" MaxLength="50" />
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="border: 0;">
                        <div style="text-align: center;">
                        </div>
                        <div id="divMinContentLeft" class="divLeft" style="padding-left: 10px;">
                            <div class="divline">
                                <asp:Label ID="lblPurchaseOrderNumber" runat="server" Text="<%$ Resources:lblPurchaseOrderNumber %>"
                                    CssClass="Label lbl" />
                                <asp:TextBox ID="txtPurchaseOrderNumber" runat="server" CssClass="TextBox txt" MaxLength="50" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblCurrency" runat="server" Text="<%$ Resources:lblCurrency %>" CssClass="Label lbl" />
                                <asp:DropDownList ID="drCurrency" runat="server" CssClass="DropList" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblIncoTerms" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblIncoTerms %>" />
                                <asp:DropDownList ID="drIncoTerms" runat="server" CssClass="DropList" Width="120px" />
                                <asp:DropDownList ID="drTermCity" runat="server" CssClass="DropList" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblSupplier" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblSupplier %>" />
                                <asp:DropDownList ID="drSupplier" runat="server" CssClass="DropList" Width="100px" />
                                <input id="btnShowNewSupplier" onclick="BtnShowSupplier()" type="button" class="Button"
                                    style="width: 80px" value="New Supplier" />
                            </div>
                        </div>
                        <div id="divMinContentRight" class="divLeft" style="padding-left: 10px;">
                            <div id="div6" runat="server" class="divline">
                                <asp:Label ID="lblPurchaseOrderAmount" runat="server" Text="<%$ Resources:lblPurchaseOrderAmount %>"
                                    CssClass="Label lbl" />
                                <asp:TextBox ID="txtPurchaseOrderAmount" runat="server" CssClass="TextBox txt" MaxLength="13" />
                            </div>
                            <div id="div7" runat="server" class="divline">
                                <asp:Label ID="lblIssueDate" runat="server" Text="<%$ Resources:lblIssueDate %>"
                                    CssClass="Label lbl" />
                                <asp:TextBox ID="txtIssueDate" runat="server" CssClass="TextBox txtDate" MaxLength="10" />
                                <asp:Button ID="btnIssueDate" runat="server" CssClass="Button bntDate" Text="..."
                                    UseSubmitBehavior="False" />dd/mm/yyyy
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblModeofTransport" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblModeofTransport %>" />
                                <asp:DropDownList ID="drModeofTransport" runat="server" CssClass="DropList" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblInvoiceNumber" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblInvoiceNumber %>" />
                                <div id="divInvoiceNumber" style="display: inline">
                                    <asp:TextBox ID="txtInvoiceNumber" runat="server" CssClass="TextBox txt" MaxLength="50" />
                                </div>
                            </div>
                        </div>
                        <div id="divNewSupplier" style="display: none;" runat="server">
                            <fieldset class="divLeft" style="width: 92%">
                                <legend align="center">New Supplier</legend>
                                <div id="divShipToLeft" class="divLeft" style="padding-left: 0px;">
                                    <div class="divline">
                                        <asp:Label ID="lblCompanyName1" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblCompanyName %>" />
                                        <asp:TextBox ID="txtCompanyName1" runat="server" CssClass="TextBox txt" MaxLength="50" />
                                    </div>
                                    <div class="divline">
                                        <asp:Label ID="lblLastName1" runat="server" Text="<%$ Resources:lblLastName %>" CssClass="Label lbl" />
                                        <asp:TextBox ID="txtLastName1" runat="server" CssClass="TextBox txt" MaxLength="50" />
                                    </div>
                                    <div class="divline">
                                        <asp:Label ID="lblAddress21" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblAddress2 %>" />
                                        <asp:TextBox ID="txtAddress21" runat="server" CssClass="TextBox txt" MaxLength="45" />
                                    </div>
                                    <div class="divline">
                                        <asp:Label ID="lblState1" runat="server" Text="<%$ Resources:lblState %>" CssClass="Label lbl" />
                                        <asp:TextBox ID="txtState1" runat="server" CssClass="TextBox txt" MaxLength="20" />
                                    </div>
                                    <div class="divline">
                                        <asp:Label ID="lblCountry1" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblCountry %>" />
                                        <asp:DropDownList ID="drCountry1" runat="server" CssClass="DropList" />
                                    </div>
                                    <div class="divline">
                                        <asp:Label ID="lblFax1" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblFax %>" />
                                        <asp:TextBox ID="txtFax1" runat="server" CssClass="TextBox txt" MaxLength="50" />
                                    </div>
                                </div>
                                <div id="divShipToRight" class="divLeft" style="padding-left: 10px;">
                                    <div class="divline">
                                        <asp:Label ID="lblFirstName1" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblFirstName %>" />
                                        <div id="div4" style="display: inline">
                                            <asp:TextBox ID="txtFirstName1" runat="server" CssClass="TextBox txt" MaxLength="50" />
                                        </div>
                                    </div>
                                    <div class="divline">
                                        <asp:Label ID="lblAddress1" runat="server" Text="<%$ Resources:lblAddress %>" CssClass="Label lbl" />
                                        <asp:TextBox ID="txtAddress1" runat="server" CssClass="TextBox txt" MaxLength="45" />
                                    </div>
                                    <div class="divline">
                                        <asp:Label ID="lblCity1" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblCity %>" />
                                        <asp:DropDownList ID="drCity1" runat="server" CssClass="DropList txt" />
                                    </div>
                                    <div class="divline">
                                        <asp:Label ID="lblPostalCode1" runat="server" Text="<%$ Resources:lblPostalCode %>"
                                            CssClass="Label lbl" />
                                        <asp:TextBox ID="txtPostalCode1" runat="server" CssClass="TextBox txt" MaxLength="50" />
                                    </div>
                                    <div class="divline">
                                        <asp:Label ID="lblPhone1" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblPhone %>" />
                                        <asp:TextBox ID="txtPhone1" runat="server" CssClass="TextBox txt" MaxLength="50" />
                                    </div>
                                    <div class="divline">
                                        <asp:Label ID="lblEmailAddress1" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblEmailAddress %>" />
                                        <asp:TextBox ID="txtEmailAddress1" runat="server" CssClass="TextBox txt" MaxLength="50" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="border: 0">
                        <div id="div8" class="divLeft" style="padding-left: 10px;">
                            <div class="divline">
                                <asp:Label ID="lblETD" runat="server" Text="<%$ Resources:lblETD %>" CssClass="Label lbl" />
                                <asp:TextBox ID="txtETD" runat="server" CssClass="TextBox txtDate" MaxLength="10" />
                                <asp:Button ID="btnETD" runat="server" CssClass="Button bntDate" Text="..." UseSubmitBehavior="False" />
                                &nbsp;<asp:Label ID="lblPortOfLoading" runat="server" CssClass="Label lbl" Width="90px"
                                    Text="<%$ Resources:lblPortOfLoading %>" />
                                <asp:TextBox ID="txtPortOfLoading" runat="server" CssClass="TextBox txtProt" MaxLength="5"
                                    TabIndex="20" Width="55px" />
                                <asp:Button ID="btnPortOfLoading" runat="server" CssClass="Button bntDate" Text="..."
                                    UseSubmitBehavior="False" TabIndex="21" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblRequiredDate" runat="server" Text="<%$ Resources:lblRequiredDate %>"
                                    CssClass="Label lbl" />
                                <asp:TextBox ID="txtRequiredDate" runat="server" CssClass="TextBox txtDate" MaxLength="10" />
                                <asp:Button ID="btnRequiredDate" runat="server" CssClass="Button bntDate" Text="..."
                                    UseSubmitBehavior="False" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblShipToName" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblShipToName %>" />
                                <asp:TextBox ID="txtShipToName" runat="server" CssClass="TextBox txt" MaxLength="50" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblShipToAddress2" runat="server" Text="<%$ Resources:lblShipToAddress2 %>"
                                    CssClass="Label lbl" />
                                <asp:TextBox ID="txtShipToAddress2" runat="server" CssClass="TextBox txt" MaxLength="100" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblShipToAddress4" runat="server" Text="<%$ Resources:lblShipToAddress4 %>"
                                    CssClass="Label lbl" />
                                <asp:TextBox ID="txtShipToAddress4" runat="server" CssClass="TextBox txt" MaxLength="100" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblShipToPhone" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblShipToPhone %>" />
                                <asp:TextBox ID="txtShipToPhone2" runat="server" CssClass="TextBox txt" MaxLength="50" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblContactPerson" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblContactPerson %>" />
                                <asp:TextBox ID="txtContactPerson" runat="server" CssClass="TextBox txt" MaxLength="50" />
                            </div>
                        </div>
                        <div id="div5" class="divLeft" style="padding-left: 10px;">
                            <div class="divline">
                                <asp:Label ID="lblETA" runat="server" Text="<%$ Resources:lblETA %>" CssClass="Label lbl" />
                                <asp:TextBox ID="txtETA" runat="server" CssClass="TextBox txtDate" MaxLength="10"
                                    Width="90px" />
                                <asp:Button ID="btnETA" runat="server" CssClass="Button bntDate" Text="..." UseSubmitBehavior="False" />
                                &nbsp;
                                <asp:Label ID="lblPortOfDischarge" runat="server" CssClass="Label lbl" Width="100px"
                                    Text="<%$ Resources:lblProtOfDischarge %>" />
                                <asp:TextBox ID="txtPortOfDischarge" runat="server" CssClass="TextBox txtProt" MaxLength="5"
                                    Width="55px" />
                                <asp:Button ID="btnPortOfDischarge" runat="server" CssClass="Button bntDate" Text="..."
                                    UseSubmitBehavior="False" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblShipToAddress1" runat="server" Text="<%$ Resources:lblShipToAddress1 %>"
                                    CssClass="Label lbl" />
                                <asp:TextBox ID="txtShipToAddress1" runat="server" CssClass="TextBox txt" MaxLength="100" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblShipToAddress3" runat="server" Text="<%$ Resources:lblShipToAddress3 %>"
                                    CssClass="Label lbl" />
                                <asp:TextBox ID="txtShipToAddress3" runat="server" CssClass="TextBox txt" MaxLength="100" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblShipToEmail" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblShipToEmail %>" />
                                <asp:TextBox ID="txtShipToEmail" runat="server" CssClass="TextBox txt" MaxLength="50" />
                            </div>
                            <div class="divline">
                                <asp:Label ID="lblShipToFax" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblShipToFax %>" />
                                <asp:TextBox ID="txtShipToFax2" runat="server" CssClass="TextBox txt" MaxLength="50" />
                            </div>
                            <div class="divline">
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="border: 0">
                        <div class="divLeft" style="padding-left: 10px;">
                            <asp:Label ID="lblDescription" CssClass="Label lbl" Height="80px" runat="server"
                                Text="<%$ Resources:lblDescription %>" />
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="TextBox txt" Height="80px"
                                Width="763px" MaxLength="80" TextMode="MultiLine" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divMiddle1" runat="server" class="divBorder divTab" style="height: 260px;
            width: 100%; padding-left: 20px; padding-top: 10px; display: none;">
            <div class="divLeft" style="width: 50%">
                <div class="divline">
                    <asp:Label ID="lblValue" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblValue %>" />
                    <asp:TextBox ID="txtValue" runat="server" CssClass="TextBox txtValue" MaxLength="9" />
                    <asp:DropDownList ID="drPOCurrCode" runat="server" CssClass="DropList" Width="120px" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblIncoterms2" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblIncoterms %>" />
                    <asp:DropDownList ID="drIncoterms2" runat="server" CssClass="DropList" />
                    <asp:DropDownList ID="drTermCity2" runat="server" CssClass="DropList" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblStatus" runat="server" Text="<%$ Resources:lblStatus %>" CssClass="Label lbl" />
                    <asp:DropDownList ID="drStatus" runat="server" CssClass="DropList" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblPortOfLoading2" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblPortOfLoading %>" />
                    <asp:TextBox ID="txtPortOfLoading2" runat="server" CssClass="TextBox txtProt" MaxLength="5"
                        TabIndex="20" Width="270px" />
                    <asp:Button ID="btnPortOfLoading2" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" TabIndex="21" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblPortOfDischarge2" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblProtOfDischarge %>" />
                    <asp:TextBox ID="txtPortOfDischarge2" runat="server" CssClass="TextBox txtProt" MaxLength="5"
                        Width="270px" />
                    <asp:Button ID="btnPortOfDischarge2" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblDescription1" runat="server" Text="<%$ Resources:lblDescription %>"
                        CssClass="Label lbl" />
                    <asp:TextBox ID="txtDescription1" runat="server" CssClass="TextBox lbl2" TextMode="MultiLine" />
                </div>
            </div>
            <div class="divRight">
                <div class="divline">
                    <asp:Label ID="lblIssueDate2" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblIssueDate %>" />
                    <asp:TextBox ID="txtIssueDate2" runat="server" CssClass="TextBox txtDate" MaxLength="10" />
                    <asp:Button ID="btnIssueDateInfo" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />dd/mm/yyyy
                </div>
                <div class="divline">
                    <asp:Label ID="lblShipDate" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblShipDate %>" />
                    <div id="div10" style="display: inline">
                        <asp:TextBox ID="txtShipDate" runat="server" CssClass="TextBox txtDate" />
                        <asp:Button ID="btnShipDateInfo" runat="server" CssClass="Button bntDate" Text="..."
                            UseSubmitBehavior="False" />dd/mm/yyyy
                    </div>
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblRequiredDate2" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblRequiredDate %>" />
                        <div id="div11" style="display: inline">
                            <asp:TextBox ID="txtRequiredDate2" runat="server" CssClass="TextBox txtDate" />
                            <asp:Button ID="btnRequiredDate2" runat="server" CssClass="Button bntDate" Text="..."
                                UseSubmitBehavior="False" />dd/mm/yyyy
                        </div>
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblETD2" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblETD %>" />
                        <div id="div12" style="display: inline">
                            <asp:TextBox ID="txtETD2" runat="server" CssClass="TextBox txtDate" />
                            <asp:Button ID="btnETD2" runat="server" CssClass="Button bntDate" Text="..." UseSubmitBehavior="False" />dd/mm/yyyy
                        </div>
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblETA2" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblETA %>" />
                        <div id="div13" style="display: inline">
                            <asp:TextBox ID="txtETA2" runat="server" CssClass="TextBox txtDate" />
                            <asp:Button ID="btnETA2" runat="server" CssClass="Button bntDate" Text="..." UseSubmitBehavior="False" />dd/mm/yyyy
                        </div>
                    </div>
                    <div id="divDate" runat="server">
                        <div class="divline">
                            <asp:Label ID="lblRequisitionDate" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblReqisitionDate %>" />
                            <asp:TextBox ID="txtRequestionDate" runat="server" CssClass="TextBox txtDate" MaxLength="10" />
                            <asp:Button ID="btnRequestionDate" runat="server" CssClass="Button bntDate" Text="..."
                                UseSubmitBehavior="False" />dd/mm/yyyy
                        </div>
                        <div class="divline">
                            <asp:Label ID="lblReceivedDate" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblReceivedDate %>" />
                            <asp:TextBox ID="txtReceivedDate" runat="server" CssClass="TextBox txtDate" MaxLength="10" />
                            <asp:Button ID="btnReceivedDate" runat="server" CssClass="Button bntDate" Text="..."
                                UseSubmitBehavior="False" />dd/mm/yyyy
                        </div>
                        <div class="divline">
                            <asp:Label ID="lblVendorReceivedDate" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblVendorReceivedDate %>" />
                            <div id="div9" style="display: inline">
                                <asp:TextBox ID="txtVendorReceivedDate" runat="server" CssClass="TextBox lbl2" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    <div id="divMiddle2" class="divBorder divTab" style="height: 260px; width: 100%;
    padding-left: 20px; padding-top: 10px; display: none;"> <%-- --%> <div class="divLeft">
    <div class="divline"> <asp:Label ID="Label1" CssClass="Label lbl" runat="server"
    Text="<%$ Resources:lblCompanyName %>" /> <asp:TextBox ID="txtSupplierCompanyName"
    runat="server" CssClass="TextBox txt2" MaxLength="50" /> </div> <div class="divline">
    <asp:Label ID="lblSupplierEmail" runat="server" Text="<%$ Resources:lblEmail %>"
    CssClass="Label lbl" /> <asp:TextBox ID="txtSupplierEmail" runat="server" CssClass="TextBox
    txt3" MaxLength="50" /> </div> <div class="divline"> <asp:Label ID="lblSAdderss"
    runat="server" Text="<%$ Resources:lblAddress %>" CssClass="Label lbl" /> <asp:TextBox
    ID="txtSupplierAdderss" Height="80px" runat="server" CssClass="TextBox txt1" TextMode="MultiLine"
    /> </div> <div class="divline"> <asp:Label ID="Label8" runat="server" CssClass="Label
    lbl" Text="<%$ Resources:lblPhone %>" /> <asp:TextBox ID="txtSupplierPhone" runat="server"
    CssClass="TextBox txt1" MaxLength="50" /> </div> <div class="divline"> <asp:Label
    ID="Label2" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblFax %>" />
    <asp:TextBox ID="txtSupplierFax" runat="server" CssClass="TextBox txt1" MaxLength="50"
    /> </div> </div> <div class="divRight"> </div> </div> <div id="divMiddle3" class="divBorder
    divTab" style="height: 260px; width: 100%; padding-left: 20px; padding-top: 10px;
    display: none;"> <div class="divLeft"> <div class="divline"> <asp:Label ID="Label3"
    CssClass="Label lbl" runat="server" Text="<%$ Resources:lblCompanyName %>" /> <asp:TextBox
    ID="txtShipToCompany" runat="server" CssClass="TextBox txt2" MaxLength="50" /> </div>
    <div class="divline"> <asp:Label ID="lblEmail" runat="server" CssClass="Label lbl"
    Text="<%$ Resources:lblEmail %>" /> <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox
    txt3" MaxLength="50" /> </div> <div class="divline"> <asp:Label ID="lblShipToAddress"
    runat="server" Text="<%$ Resources:lblAddress %>" CssClass="Label lbl" /> <asp:TextBox
    ID="txtShipToAddress" Height="80px" runat="server" CssClass="TextBox txt1" TextMode="MultiLine"
    MaxLength="405" /> </div> <div class="divline"> <asp:Label ID="Label5" runat="server"
    CssClass="Label lbl" Text="<%$ Resources:lblPhone %>" /> <asp:TextBox ID="txtShipToPhone"
    runat="server" CssClass="TextBox txt1" MaxLength="30" /> </div> <div class="divline">
    <asp:Label ID="Label6" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblFax
    %>" /> <asp:TextBox ID="txtShipToFax" runat="server" CssClass="TextBox txt1" MaxLength="30"
    /> </div> </div> <div class="divRight"> </div> </div> <div id="divMiddle4" class="divBorder
    divTab" style="height: 260px; width: 100%; padding-left: 20px; padding-top: 10px;
    display: none;"> <div id="divAttach" class="divsource "> <asp:GridView ID="gvwAttach"
    runat="server" AutoGenerateColumns="False" EnableViewState="False" OnRowDataBound="gvwAttach_RowDataBound"
    CssClass="GvwView"> <Columns> <asp:TemplateField> <ItemTemplate> <asp:Image ID="imgDelete"
    runat="server" ImageUrl="~/Images/Edit/ed_delete.gif" CssClass="delImg" /> <asp:Image
    ID="imgInsert" runat="server" ImageUrl="~/Images/Edit/ed_Insert.gif" CssClass="delImg"
    /><%--AlternateText="<%$ Resources:imgInsert.AlternateText %>"--%> </ItemTemplate>
    <ItemStyle CssClass="colEdit taCenter" /> <HeaderStyle CssClass="colEdit taCenter
    " /> </asp:TemplateField> <asp:BoundField HeaderText="<%$ Resources:BoundField1.HeaderText
    %>" DataField="No"> <ItemStyle CssClass="colNo taLeft" Width="30px" /> <HeaderStyle
    CssClass="colNo taCenter " Width="30px" /> </asp:BoundField> <asp:BoundField HeaderText="<%$
    Resources:BoundField2.HeaderText %>" DataField="ReferenceFileName" HtmlEncode="False">
    <ItemStyle CssClass="colFileName taLeft" /> <HeaderStyle CssClass="colFileName taCenter"
    /> </asp:BoundField> <asp:BoundField HeaderText="<%$ Resources:BoundField3.HeaderText
    %>" DataField="FileSize" DataFormatString="{0:#,##0}" HtmlEncode="False"> <ItemStyle
    CssClass="colFileSize taRight" /> <HeaderStyle CssClass="colFileSize taCenter" />
    </asp:BoundField> <asp:BoundField HeaderText="<%$ Resources:BoundField4.HeaderText
    %>" DataField="FileDate" DataFormatString="{0:yyyy-MM-dd HH:mm}" HtmlEncode="False">
    <ItemStyle CssClass="colFileDate taLeft" /> <HeaderStyle CssClass="colFileDate taCenter"
    /> </asp:BoundField> </Columns> <HeaderStyle CssClass="Header" /> <FooterStyle CssClass="Footer"
    /> <RowStyle CssClass="Row" /> <SelectedRowStyle CssClass="SelectRow" /> <PagerStyle
    CssClass="Pager" /> <AlternatingRowStyle CssClass="Alternating" /> </asp:GridView>
    </div> <div class="divline"> </div> </div> <div id="divPartialPO" runat="server"
    style="display: none;"> <div id="divSource" style="height: 350px;"> <asp:GridView
    ID="gvwSource" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvwSource_RowDataBound"
    EnableViewState="False"> <HeaderStyle CssClass="Header" /> <FooterStyle CssClass="Footer"
    /> <RowStyle CssClass="Row" /> <SelectedRowStyle CssClass="SelectRow" /> <PagerStyle
    CssClass="Pager" /> <AlternatingRowStyle CssClass="Alternating" /> </asp:GridView>
    </div> <div cssclass="divRight" style="position: absolute; right: 7px;"> <asp:Label
    ID="lblGrandTotal" runat="server" Text="Grand Total"></asp:Label> <asp:TextBox ID="txtGrandTotal"
    runat="server" CssClass="txInput" ReadOnly="true" Width="80px"></asp:TextBox> </div>
    <div id="divPage"> <div class="fLeft"> <asp:Label ID="lblPage" runat="server" Text="Page"></asp:Label>
    <asp:LinkButton ID="lbtnFirst" runat="server" Text="First"></asp:LinkButton> <asp:LinkButton
    ID="lbtnPrior" runat="server" Text="Prior"></asp:LinkButton> <asp:Label ID="lblPabe"
    runat="server" Text="Page" /> <asp:TextBox ID="txtPage" runat="server" CssClass="txInput"></asp:TextBox>
    <asp:LinkButton ID="lbtnGoTo" runat="server" Text="Go"></asp:LinkButton> <asp:LinkButton
    ID="lbtnNext" runat="server" Text="Next"></asp:LinkButton> <asp:LinkButton ID="lbtnLast"
    runat="server" Text="Last"></asp:LinkButton> </div> </div> <asp:HiddenField ID="hid_val"
    runat="server" Value="1" /> </div> <div id="divBottomNav"> <asp:Button ID="btnSave"
    runat="server" Text="<%$ Resources:btnSave %>" CssClass="Button" UseSubmitBehavior="False"
    /> <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose %>" CssClass="Button"
    UseSubmitBehavior="False" />&nbsp &nbsp &nbsp </div> </div> <asp:HiddenField ID="fldId"
    runat="server" /> <div id="divSupplier"> <asp:HiddenField ID="hidSupplier" runat="server"
    /> <asp:HiddenField ID="hidTab" runat="server" Value="1" /> </div>
    </form>
</body>
</html>
