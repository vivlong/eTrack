<%@ Page Language="VB" AutoEventWireup="true" CodeFile="POLineItemEdit.aspx.vb" Inherits="LineItemPOEdit" %>

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
    <link href="App_Themes/POLineItemEdit.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="JavaScript/POLineItemEdit.js" -->
    <!-- #include file="JavaScript/POLineItemEditFun.js" -->

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"> </script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>

</head>
<body>
    <%--onload="FirstAddSignRow(0)"--%>
    <form id="frmBookingFormEdit" runat="server">
    <div id="divForm">
        <div id="divTopNav" runat="server" style="width: 100%">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="a1" runat="server" CssClass="f12e navNml navOn" Width="100px" onclick="SelectedDiv(1,5);SetTab(1);"
                        Text="<%$ Resources:a1 %>"></asp:Label></li>
                <li>
                    <asp:Label ID="a2" CssClass="f12c navNml noSep" runat="server" Width="150px" onclick="SelectedDiv(2,5);SetTab(2);"
                        Text="<%$ Resources:a2 %>" /></li>
                <li>
                    <asp:Label ID="a3" CssClass="f12c navNml noSep" runat="server" Width="150px" onclick="SelectedDiv(3,5);SetTab(3);"
                        Text="<%$ Resources:a3 %>" /></li>
                <li>
                    <asp:Label ID="a4" CssClass="f12c navNml noSep" runat="server" Width="130px" onclick="SelectedDiv(4,5);SetTab(4);"
                        Text="<%$ Resources:a4 %>" /></li>
                <li>
                    <asp:Label ID="a5" CssClass="f12c navNml noSep" runat="server" Width="100px" onclick="SelectedDiv(5,5);SetTab(5);"
                        Text="<%$ Resources:a5 %>" /></li>
            </ul>
        </div>
        <div id="SaveHint" runat="server" class="Hint" style="left: 0px; top: 10px">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>" />
        </div>
        <div id="divTop" runat="server" class="divBorder" style="height: 610px; width: 100%;
            padding-left: 10px; padding-top: 10px;">
            <div class="divline" style="padding-top: 10px; padding-left: 10px;">
                <asp:Label ID="lblHazardous" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblHazardous %>" />
                <asp:RadioButtonList ID="rblHazardous" runat="server" RepeatColumns="2" RepeatLayout="Flow">
                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                    <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <fieldset style="width: 93%">
                <legend align="center">Item Information</legend>
                <br />
                <div id="divMiddle11" class="divLeft" style="padding-left: 10px;">
                    <div class="divline">
                        <asp:Label ID="lblLineItemNumber" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblLineItemNumber %>" />
                        <asp:TextBox ID="txtLineItemNumber" runat="server" CssClass="TextBox txt" MaxLength="50" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblPartNumber" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblPartNumber %>" />
                        <asp:DropDownList ID="drPartNumber" runat="server" CssClass="DropList" />
                        <asp:TextBox ID="txtPartNumber" runat="server" CssClass="TextBox" MaxLength="50" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblHarmonizeCode" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblHarmonizeCode %>" />
                        <asp:TextBox ID="txtHarmonizeCode" runat="server" CssClass="TextBox txt" MaxLength="50" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblUnitPrice" runat="server" Text="<%$ Resources:lblUnitPrice %>"
                            CssClass="Label lbl" />
                        <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="TextBox txtDate" MaxLength="50" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblSupplierPartNumber" runat="server" Text="<%$ Resources:lblSupplierPartNumber %>"
                            CssClass="Label lbl" />
                        <asp:TextBox ID="txtSupplierPartNumber" runat="server" CssClass="DropList txt" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblNetWeight" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblNetWeight %>" />
                        <asp:TextBox ID="txtNetWeight" runat="server" CssClass="TextBox txtDate" MaxLength="50" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblTagNumber" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblTagNumber %>" />
                        <asp:TextBox ID="txtTagNumber" runat="server" CssClass="TextBox txt" MaxLength="50" />
                    </div>
                </div>
                <div id="divMiddle12" class="divLeft" style="padding-left: 10px;">
                    <div class="divline">
                        &nbsp
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblPartDescription" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblPartDescription %>" />
                        <div id="div1" style="display: inline">
                            <asp:TextBox ID="txtPartDescription" runat="server" CssClass="TextBox txt" MaxLength="80" />
                        </div>
                    </div>
                    <div id="div2" runat="server" class="divline">
                        <asp:Label ID="lblHarmonizeDescription" runat="server" Text="<%$ Resources:lblHarmonizeDescription %>"
                            CssClass="Label lbl" />
                        <asp:TextBox ID="txtHarmonizeDescription" runat="server" CssClass="TextBox txt" MaxLength="80" />
                    </div>
                    <div id="div3" runat="server" class="divline">
                        <asp:Label ID="lblCurrnecy" runat="server" Text="<%$ Resources:lblCurrnecy %>" CssClass="Label lbl" />
                        <asp:DropDownList ID="drCurrency" runat="server" CssClass="DropList" MaxLength="50" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblQuantity" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblQuantity %>" />
                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="TextBox" MaxLength="13" />
                        <asp:DropDownList ID="drQuantity" runat="server" CssClass="DropList" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblGrossWeight" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblGrossWeight %>" />
                        <asp:TextBox ID="txtGrossWeight" runat="server" CssClass="TextBox txtDate" MaxLength="13" />
                    </div>
                    <div class="divline">
                    </div>
                </div>
            </fieldset>
            <fieldset style="width: 93%">
                <legend align="center">Shipping Information</legend>
                <br />
                <div id="divMinContentLeft" class="divLeft" style="padding-left: 10px;">
                    <div class="divline">
                        <asp:Label ID="lblInsuranceValue" runat="server" Text="<%$ Resources:lblInsuranceValue %>"
                            CssClass="Label lbl" />
                        <asp:TextBox ID="txtInsuranceValue" runat="server" CssClass="TextBox txt" MaxLength="50" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblDateRequested" runat="server" Text="<%$ Resources:lblDateRequested %>"
                            CssClass="Label lbl" />
                        <asp:TextBox ID="txtDateRequested" runat="server" CssClass="TextBox txtDate" MaxLength="10" />
                        <asp:Button ID="btnDateRequested" runat="server" CssClass="Button bntDate" Text="..."
                            UseSubmitBehavior="False" />dd/mm/yyyy
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblModeofTransport" runat="server" Text="<%$ Resources:lblModeofTransport %>"
                            CssClass="Label lbl" />
                        <asp:DropDownList ID="drModeofTransport" runat="server" CssClass="DropList" />
                    </div>
                </div>
                <div id="divMinContentRight" class="divLeft" style="padding-left: 10px;">
                    <div runat="server" class="divline">
                        &nbsp
                    </div>
                    <div runat="server" class="divline">
                        <asp:Label ID="lblLastestDeliveryDate" runat="server" Text="<%$ Resources:lblLastestDeliveryDate %>"
                            CssClass="Label lbl" />
                        <asp:TextBox ID="txtLastestDeliveryDate" runat="server" CssClass="TextBox txtDate"
                            MaxLength="10" />
                        <asp:Button ID="btnIssueDate" runat="server" CssClass="Button bntDate" Text="..."
                            UseSubmitBehavior="False" />dd/mm/yyyy
                    </div>
                    <div runat="server" class="divline">
                        <asp:Label ID="lblStatus" runat="server" Text="<%$ Resources:lblStatus %>" CssClass="Label lbl" />
                        <asp:DropDownList ID="drStatus" runat="server" CssClass="DropList" />
                    </div>
                </div>
            </fieldset>
            <fieldset style="width: 93%">
                <legend align="center">Package Information</legend>
                <br />
                <div class="divLeft" style="padding-left: 10px; width: 455px;">
                    <div class="divline">
                        <asp:Label ID="lblUnitofMeasurement" runat="server" Text="<%$ Resources:lblUnitofMeasurement %>"
                            CssClass="Label lbl" />
                        <asp:DropDownList ID="drUnitofMeasurement" runat="server" CssClass="DropList" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblLength" runat="server" Text="<%$ Resources:lblLength %>" CssClass="Label lbl" />
                        <asp:TextBox ID="txtLength" runat="server" CssClass="TextBox" MaxLength="13" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblHeight" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblHeight %>" />
                        <asp:TextBox ID="txtHeight" runat="server" CssClass="TextBox" MaxLength="13" />
                    </div>
                </div>
                <div id="div11" class="divLeft">
                    <div id="div12" runat="server" class="divline">
                        &nbsp
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblWidth" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblWidth %>" />
                        <asp:TextBox ID="txtWidth" runat="server" CssClass="TextBox txtDate" MaxLength="13" />
                    </div>
                    <div id="div13" runat="server" class="divline">
                        <asp:Label ID="lblWeight" runat="server" Text="<%$ Resources:lblWeight %>" CssClass="Label lbl" />
                        <asp:TextBox ID="txtWeight" runat="server" CssClass="TextBox txtDate" MaxLength="13" />
                        <asp:DropDownList ID="drWeight" runat="server" CssClass="DropList" />
                    </div>
                </div>
            </fieldset>
            <div class="divLeft" style="padding-left: 10px;">
                <asp:Label ID="lblDescription" CssClass="Label lbl" Height="80px" runat="server"
                    Text="<%$ Resources:lblDescription %>" />
                <asp:TextBox ID="txtDescription" runat="server" CssClass="TextBox txt" TextMode="MultiLine"
                    Height="80px" Width="763px" MaxLength="80" />
            </div>
        </div>
        <div id="divMiddle1" runat="server" class="divBorder divTab" style="height: 260px;
            width: 100%; padding-left: 20px; padding-top: 10px; display: none;">
            <div class="divLeft">
                <div class="divline">
                    <asp:Label ID="lblPartNumber1" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblPartNumber %>" />
                    <asp:TextBox ID="txtPartNumber2" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblDesc" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblDescription %>" />
                    <asp:TextBox ID="txtItemDescription1" runat="server" CssClass="TextBox txt" MaxLength="80" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblSupplierPartNumber1" runat="server" Text="<%$ Resources:lblSupplierPartNumber %>"
                        CssClass="Label lbl" />
                    <asp:TextBox ID="txtSupplierPartNumber2" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblUP" runat="server" Text="<%$ Resources:lblUnitPrice %>" CssClass="Label lbl" />
                    <asp:TextBox ID="txtUnitPrice2" runat="server" CssClass="TextBox txt1" MaxLength="13" />
                    <asp:DropDownList ID="drCurrency1" runat="server" CssClass="DropList" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblHarmonizedCode" runat="server" Text="<%$ Resources:lblHarmonizedCode %>"
                        CssClass="Label lbl" />
                    <asp:TextBox ID="txtHarmonizedCode2" runat="server" CssClass="TextBox txt" MaxLength="15" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblDescr1" runat="server" Text="<%$ Resources:lblDescription %>" CssClass="Label lbl" />
                    <asp:TextBox ID="txtDescription2" runat="server" CssClass="TextBox txt" MaxLength="80" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblHazardous2" runat="server" Text="<%$ Resources:lblHazardous %>"
                        CssClass="Label lbl" />
                    <%--<asp:TextBox ID="txtHazardous2" runat="server" CssClass="TextBox txt" MaxLength="50" />--%>
                    <asp:RadioButtonList ID="rbHazardous1" runat="server" RepeatColumns="2" RepeatLayout="Flow">
                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                        <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="divLeft">
                <div class="divline">
                    <asp:Label ID="lblTN2" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblTagNumber %>" />
                    <asp:TextBox ID="txtTagNumber2" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblQO" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblQuatityOrdered %>" />
                    <div id="div10" style="display: inline">
                        <asp:TextBox ID="txtQuatityOrdered2" runat="server" CssClass="TextBox txt" MaxLength="50" />
                    </div>
                </div>
            </div>
        </div>
        <div id="divMiddle2" class="divBorder divTab" style="height: 260px; width: 100%;
            padding-left: 20px; padding-top: 10px; display: none;">
            <%-- --%>
            <div class="divLeft">
                <div class="divline">
                    <asp:Label ID="lblIV" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblInsuranceValue %>" />
                    <asp:TextBox ID="txtInsuranceValue2" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblDR" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblDateRequested %>" />
                    <asp:TextBox ID="txtDateRequested2" runat="server" CssClass="TextBox txtDate" />
                    <asp:Button ID="btnDateRequested2" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />dd/mm/yyyy
                </div>
                <div class="divline">
                    <asp:Label ID="lblDD" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblLatestDeliveryDate %>" />
                    <asp:TextBox ID="txtLatestDeliveryDate2" runat="server" CssClass="TextBox txtDate"
                        MaxLength="50" />
                    <asp:Button ID="btnLatestDeliveryDate2" runat="server" CssClass="Button bntDate"
                        Text="..." UseSubmitBehavior="False" />dd/mm/yyyy
                </div>
                <div class="divline">
                    <asp:Label ID="lblDRS" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblDateRequiredatSite %>" />
                    <asp:TextBox ID="txtDateRequiredatSite2" runat="server" CssClass="TextBox txtDate"
                        MaxLength="50" />
                    <asp:Button ID="btnDateRequiredatSite2" runat="server" CssClass="Button bntDate"
                        Text="..." UseSubmitBehavior="False" />dd/mm/yyyy
                </div>
                <div class="divline">
                    <asp:Label ID="lblETA" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblEstimatedTimeofArrival %>" />
                    <asp:TextBox ID="txtEstimatedTimeofArrival2" runat="server" CssClass="TextBox txtDate"
                        MaxLength="50" />
                    <asp:Button ID="btnEstimatedTimeofArrival2" runat="server" CssClass="Button bntDate"
                        Text="..." UseSubmitBehavior="False" />dd/mm/yyyy
                </div>
                <div class="divline">
                    <asp:Label ID="lblSta" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblStatus %>" />
                    <%--<asp:TextBox ID="txtStatus2" runat="server" CssClass="TextBox txt" MaxLength="50" />--%>
                    <asp:DropDownList ID="drStatus2" runat="server" CssClass="DropList" />
                </div>
            </div>
            <div class="divLeft">
            </div>
        </div>
        <div id="divMiddle3" class="divBorder divTab" style="height: 260px; width: 100%;
            padding-left: 20px; padding-top: 10px; display: none;">
            <div class="divLeft">
                <div class="divline">
                    <asp:Label ID="lblUoM" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblUnitofMeasurement %>" />
                    <asp:TextBox ID="txtUnitofMeasurement2" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblLeng" runat="server" Text="<%$ Resources:lblLength %>" CssClass="Label lbl" />
                    <asp:TextBox ID="txtLength2" runat="server" CssClass="TextBox txt1" MaxLength="13" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblWid" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblWidth %>" />
                    <asp:TextBox ID="txtWidth2" runat="server" CssClass="TextBox txt1" MaxLength="13" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblHei" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblHeight %>" />
                    <asp:TextBox ID="txtHeight2" runat="server" CssClass="TextBox txt1" MaxLength="13" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblWei" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblWeight %>" />
                    <asp:TextBox ID="txtWeight2" runat="server" CssClass="TextBox txt1" MaxLength="13" />
                </div>
            </div>
            <div class="divLeft">
            </div>
        </div>
        <div id="divMiddle4" class="divBorder divTab" style="height: 260px; width: 100%;
            padding-left: 20px; padding-top: 10px; display: none;">
            <div class="divLeft">
                <div class="divline">
                    <asp:Label ID="lblCN" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblCompanyName %>" />
                    <asp:TextBox ID="txtCompanyName2" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblName" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblName %>" />
                    <asp:TextBox ID="txtName2" runat="server" CssClass="TextBox txt" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblAddress21" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblAddress %>" />
                    <asp:TextBox ID="txtAddress1" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblAddress22" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblAddress2 %>" />
                    <asp:TextBox ID="txtAddress2" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblCity" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblCity %>" />
                    <asp:DropDownList ID="drCity2" runat="server" CssClass="DropList" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblState" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblState %>" />
                    <asp:TextBox ID="txtState2" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblPostal" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblPostal %>" />
                    <asp:TextBox ID="txtPostal2" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblCountry" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblCountry %>" />
                    <asp:DropDownList ID="drCountry2" runat="server" CssClass="DropList" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblPhone" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblPhone %>" />
                    <asp:TextBox ID="txtPhone2" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblFax" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblFax %>" />
                    <asp:TextBox ID="txtFax2" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblEmail" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblEmail %>" />
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
            </div>
            <div class="divLeft">
            </div>
        </div>
        <div id="divMiddle5" class="divBorder divTab" style="height: 260px; width: 100%;
            padding-left: 20px; padding-top: 10px; display: none;">
            <div id="divAttach" class="divsource ">
                <asp:GridView ID="gvwAttach" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                    OnRowDataBound="gvwAttach_RowDataBound" CssClass="GvwView">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="imgDelete" runat="server" ImageUrl="~/Images/Edit/ed_delete.gif" CssClass="delImg" />
                                <asp:Image ID="imgInsert" runat="server" ImageUrl="~/Images/Edit/ed_Insert.gif" CssClass="delImg" />
                            </ItemTemplate>
                            <ItemStyle CssClass="colEdit taCenter" />
                            <HeaderStyle CssClass="colEdit taCenter " />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="<%$ Resources:BoundField1.HeaderText %>" DataField="No">
                            <ItemStyle CssClass="colNo taLeft" />
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
        <div id="divPartialPO" runat="server" style="display: none;">
            <div id="divSource" style="height: 370px;">
                <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvwSource_RowDataBound"
                    EnableViewState="False">
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
                    <asp:Label ID="lblPabe" runat="server" Text="Page" />
                    <asp:TextBox ID="txtPage" runat="server" CssClass="txInput"></asp:TextBox>
                    <asp:LinkButton ID="lbtnGoTo" runat="server" Text="Go"></asp:LinkButton>
                    <asp:LinkButton ID="lbtnNext" runat="server" Text="Next"></asp:LinkButton>
                    <asp:LinkButton ID="lbtnLast" runat="server" Text="Last"></asp:LinkButton>
                </div>
            </div>
            <asp:HiddenField ID="hid_val" runat="server" Value="1" />
        </div>
        <div id="divBottomNav" runat="server">
            <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:btnSave %>" CssClass="Button"
                UseSubmitBehavior="False" />
            <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose %>" CssClass="Button"
                UseSubmitBehavior="False" />&nbsp &nbsp &nbsp
        </div>
    </div>
    <asp:HiddenField ID="fldId" runat="server" />
    <asp:HiddenField ID="fldPoTrxNo" runat="server" />
    <asp:HiddenField ID="fldLineItemNo" runat="server" />
    <div id="divSupplier">
        <asp:HiddenField ID="hidSupplier" runat="server" />
    </div>
    </form>
</body>
</html>
