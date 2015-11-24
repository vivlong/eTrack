<%@ Page Language="VB" AutoEventWireup="true" CodeFile="MatraEdit.aspx.vb" Inherits="MatraEdit" %>

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
    <link href="App_Themes/MatraEdit.css" rel="Stylesheet" type="text/css" />
    <link href="../UserControl/datepicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!--#include file="JavaScript/Matra.js" -->
    <script language="javascript" type="text/javascript" src="../UserControl/datepicker/WdatePicker.js"></script>
    <%--<script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"> </script>--%>
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>
</head>
<body>
    <form id="frmMatraEntry" runat="server">
    <div id="divForm">
        <div id="divTopNav">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="a1" runat="server" CssClass="f12e navNml navOn" Text="<%$ Resources:a1.Text %>"></asp:Label></li>
            </ul>
        </div>
        <div id="divMiddle1" class="divBorder">
            <div id="divMiddle11">
                <div class="divline">
                    <asp:Label ID="lblRFQNo" runat="server" CssClass="Label" Text="<%$ Resources:lblRFQNo %>">
                    </asp:Label>
                    <asp:TextBox ID="txtRFQNo" runat="server" CssClass="TextBox LongTextBox" MaxLength="50"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblPartNo" runat="server" CssClass="Label" Text="<%$ Resources:lblPartNo %>">
                    </asp:Label>
                    <asp:TextBox ID="txtPartNo" runat="server" CssClass="TextBox LongTextBox" MaxLength="50"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblSerialNo" runat="server" CssClass="Label" Text="<%$ Resources:lblSerialNo %>">
                    </asp:Label>
                    <asp:TextBox ID="txtSerialNo" runat="server" CssClass="TextBox LongTextBox" MaxLength="50"></asp:TextBox>
                </div>
                <div class="divline">
                    <asp:Label ID="lblMroCode" runat="server" CssClass="Label" Text="<%$ Resources:lblMroCode %>">
                    </asp:Label>
                    <asp:TextBox ID="txtMro" runat="server" CssClass="TextBox dteTextBox" MaxLength="10"></asp:TextBox>
                    <asp:TextBox ID="txtMroName" runat="server" CssClass="TextBox ShortTextBox"></asp:TextBox>
                    <asp:Button ID="btnMro" runat="server" CssClass="Button dteButton" Text="..." UseSubmitBehavior="False" />
                </div>
                <div id="divMatra">
                    <div class="divline" style="font-weight: bolder; padding-top: 8px;">
                        <asp:Label ID="lblMatra" runat="server" CssClass="Label" Text="<%$ Resources:lblMatra %>">
                        </asp:Label>
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblMtoNotification" runat="server" CssClass="Label" Text="<%$ Resources:lblMtoNotification %>">
                        </asp:Label>
                        <asp:TextBox ID="txtMtoNotification" runat="server" CssClass="TextBox dteTextBox"
                            ReadOnly="true" MaxLength="10"></asp:TextBox>
                        <asp:Button ID="btnMtoNotification" runat="server" CssClass="Button dteButton" Enabled="false"
                            Text="..." UseSubmitBehavior="False" />
                        <asp:Label ID="lblDateFormat1" runat="server" Text="dd/mm/yyyy">
                        </asp:Label>
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblLocalMto" runat="server" CssClass="Label" Text="<%$ Resources:lblLocalMto %>">
                        </asp:Label>
                        <asp:TextBox ID="txtLocalMto" runat="server" CssClass="TextBox dteTextBox" ReadOnly="true"
                            MaxLength="10"></asp:TextBox>
                        <asp:TextBox ID="txtLocalMtoName" runat="server" CssClass="TextBox ShortTextBox"
                            ReadOnly="true"></asp:TextBox>
                        <asp:Button ID="btnLocalMto" runat="server" CssClass="Button dteButton" Enabled="false"
                            Text="..." UseSubmitBehavior="False" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblConsignmentDate" runat="server" CssClass="Label" Text="<%$ Resources:lblConsignmentDate %>">
                        </asp:Label>
                        <asp:TextBox ID="txtConsignmentDate" runat="server" CssClass="TextBox dteTextBox"
                            ReadOnly="true" MaxLength="10"></asp:TextBox>
                        <asp:Button ID="btnConsignmentDate" runat="server" CssClass="Button dteButton" Enabled="false"
                            Text="..." UseSubmitBehavior="False" />
                        <asp:Label ID="Label1" runat="server" Text="dd/mm/yyyy">
                        </asp:Label>
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblPickupFrom" runat="server" CssClass="Label" Text="<%$ Resources:lblPickupFrom %>">
                        </asp:Label>
                        <asp:TextBox ID="txtPickupFrom" runat="server" CssClass="TextBox" ReadOnly="true"
                            MaxLength="50"></asp:TextBox>
                        <asp:TextBox ID="txtPickupDate" runat="server" CssClass="TextBox dteTextBox" ReadOnly="true"
                            MaxLength="10"></asp:TextBox>
                        <asp:Button ID="btnPickupDate" runat="server" CssClass="Button dteButton" Enabled="false"
                            Text="..." UseSubmitBehavior="False" />
                        <asp:Label ID="Label2" runat="server" Text="dd/mm/yyyy">
                        </asp:Label>
                    </div>
                    <div class="divline" style="display: none;">
                        <asp:Label ID="lblShipTo" runat="server" CssClass="Label" Text="<%$ Resources:lblShipTo %>">
                        </asp:Label>
                        <asp:TextBox ID="txtShipTo" runat="server" CssClass="TextBox" ReadOnly="true"></asp:TextBox>
                        <asp:TextBox ID="txtShipDate" runat="server" CssClass="TextBox dteTextBox" ReadOnly="true"></asp:TextBox>
                        <asp:Button ID="btnShipDate" runat="server" CssClass="Button dteButton" Enabled="false"
                            Text="..." UseSubmitBehavior="False" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblConsignmentNote" runat="server" CssClass="Label" Text="<%$ Resources:lblConsignmentNote %>">
                        </asp:Label>
                        <asp:TextBox ID="txtConsignmentNote" runat="server" CssClass="TextBox LongTextBox"
                            ReadOnly="true" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="divline" style="padding-top: 80px; font-weight: bold;">
                        <asp:Label ID="lblMtoRep" runat="server" CssClass="Label" Text="<%$ Resources:lblMtoRep %>">
                        </asp:Label>
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblDateReceivedFromMto" runat="server" CssClass="Label" Text="<%$ Resources:lblDateReceivedFromMto %>">
                        </asp:Label>
                        <asp:TextBox ID="txtDateReceivedFromMto" runat="server" CssClass="TextBox dteTextBox"
                            MaxLength="10"></asp:TextBox>
                        <asp:Button ID="btnDateReceivedFromMto" runat="server" CssClass="Button dteButton"
                            Text="..." UseSubmitBehavior="False" />
                        <asp:Label ID="Label3" runat="server" Text="dd/mm/yyyy">
                        </asp:Label>
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblDateDeliveredToMro" runat="server" CssClass="Label" Text="<%$ Resources:lblDateDeliveredToMro %>">
                        </asp:Label>
                        <asp:TextBox ID="txtDateDeliveredToMro" runat="server" CssClass="TextBox dteTextBox"
                            MaxLength="10"></asp:TextBox>
                        <asp:Button ID="btnDateDeliveredToMro" runat="server" CssClass="Button dteButton"
                            Text="..." UseSubmitBehavior="False" />
                        <asp:Label ID="Label4" runat="server" Text="dd/mm/yyyy">
                        </asp:Label>
                    </div>
                    <div class="divline" style="padding-top: 5px; font-weight: bold;">
                        <asp:Label ID="lblMro" runat="server" CssClass="Label" Text="<%$ Resources:lblMro %>">
                        </asp:Label>
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblDateReceivedFromMtoRep" runat="server" CssClass="Label" Text="<%$ Resources:lblDateReceivedFromMtoRep %>">
                        </asp:Label>
                        <asp:TextBox ID="txtDateReceivedFromMtoRep" runat="server" CssClass="TextBox dteTextBox"
                            MaxLength="10"></asp:TextBox>
                        <asp:Button ID="btnDateReceivedFromMtoRep" runat="server" CssClass="Button dteButton"
                            Text="..." UseSubmitBehavior="False" />
                        <asp:Label ID="Label5" runat="server" Text="dd/mm/yyyy">
                        </asp:Label>
                    </div>
                </div>
            </div>
            <div id="divMiddle12">
                <div class="divline">
                    <asp:Label ID="lblCreateBy" runat="server" CssClass="Label" Text="<%$ Resources:lblCreateBy %>">
                    </asp:Label>
                    <asp:TextBox ID="txtCreateBy" runat="server" CssClass="TextBox dteTextBox" ReadOnly="true"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCloseJob" Text="<%$ Resources:btnCloseJob %>" runat="server" CssClass="Button btnCloseJob" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblCreateAt" runat="server" CssClass="Label" Text="<%$ Resources:lblCreateAt %>">
                    </asp:Label>
                    <asp:TextBox ID="txtCreateAt" runat="server" CssClass="TextBox dteTextBox" ReadOnly="true"></asp:TextBox>
                    <%--<asp:Button ID="btnCreateAt" runat="server" CssClass="Button dteButton" Text="..."
                            UseSubmitBehavior="False" />--%>
                </div>
                <div class="divline">
                    <asp:Label ID="lblStatus" runat="server" CssClass="Label" Text="<%$ Resources:lblStatus %>">
                    </asp:Label>
                    <%--<asp:DropDownList ID="drpStatus" runat="server" >
                        <asp:ListItem Text="Open" Value="0"></asp:ListItem>
                        <asp:ListItem Text="In-Process" Value="1" Selected="True"  ></asp:ListItem>
                        <asp:ListItem Text="Close" Value="2"></asp:ListItem>
                    </asp:DropDownList> --%>
                    <asp:TextBox ID="txtStatus" runat="server" CssClass="TextBox dteTextBox" ReadOnly="true"></asp:TextBox>
                </div>
                <div id="divMto">
                    <div class="divline" style="font-weight: bolder; padding-top: 30px;">
                        <asp:Label ID="lblMto" runat="server" CssClass="Label" Text="<%$ Resources:lblMto %>">
                        </asp:Label>
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblMtoTransporterName" runat="server" CssClass="Label" Text="<%$ Resources:lblMtoTransporterName %>">
                        </asp:Label>
                        <asp:TextBox ID="txtDriverName1" runat="server" CssClass="TextBox SpecialTextBox"
                            ReadOnly="true" MaxLength="50"></asp:TextBox>
                        <asp:TextBox ID="txtDriverName2" runat="server" CssClass="TextBox SpecialTextBox"
                            ReadOnly="true" MaxLength="50"></asp:TextBox>
                        <asp:TextBox ID="txtDriverName3" runat="server" CssClass="TextBox SpecialTextBox"
                            ReadOnly="true" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblMtoTransporterIC" runat="server" CssClass="Label" Text="<%$ Resources:lblMtoTransporterIC %>">
                        </asp:Label>
                        <asp:TextBox ID="txtDriveric1" runat="server" CssClass="TextBox SpecialTextBox" ReadOnly="true"
                            MaxLength="50"></asp:TextBox>
                        <asp:TextBox ID="txtDriveric2" runat="server" CssClass="TextBox SpecialTextBox" ReadOnly="true"
                            MaxLength="50"></asp:TextBox>
                        <asp:TextBox ID="txtDriveric3" runat="server" CssClass="TextBox SpecialTextBox" ReadOnly="true"
                            MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblCommodity" runat="server" CssClass="Label" Text="<%$ Resources:lblCommodity %>">
                        </asp:Label>
                        <asp:TextBox ID="txtCommodity" runat="server" CssClass="TextBox" ReadOnly="true"
                            MaxLength="100"></asp:TextBox>
                        <asp:Label ID="lblQty" runat="server" Text="<%$ Resources:lblQty %>">
                        </asp:Label>
                        <asp:TextBox ID="txtQty" runat="server" CssClass="TextBox" ReadOnly="true" MaxLength="9"></asp:TextBox>
                        <asp:TextBox ID="txtUom" runat="server" CssClass="TextBox dteTextBox" ReadOnly="true"
                            MaxLength="3"></asp:TextBox>
                        <asp:Button ID="btnUom" runat="server" CssClass="Button dteButton" Enabled="false"
                            Text="..." UseSubmitBehavior="False" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblGrossWeight" runat="server" CssClass="Label" Text="<%$ Resources:lblGrossWeight %>">
                        </asp:Label>
                        <asp:TextBox ID="txtGrossWeight" runat="server" CssClass="TextBox" ReadOnly="true"></asp:TextBox>
                        <asp:Label ID="lblChargeWeight" runat="server" Text="<%$ Resources:lblChargeWeight %>">
                        </asp:Label>
                        <asp:TextBox ID="txtChargeWeight" runat="server" CssClass="TextBox" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblMAwbOrOBlNo" runat="server" CssClass="Label" Text="<%$ Resources:lblMAwbOrOBlNo %>">
                        </asp:Label>
                        <asp:TextBox ID="txtMAwbOrOBlNo" runat="server" CssClass="TextBox" ReadOnly="true"
                            MaxLength="20"></asp:TextBox>
                        <asp:Label ID="lblHAwbOrHBlNo" runat="server" Text="<%$ Resources:lblHAwbOrHBlNo %>">
                        </asp:Label>
                        <asp:TextBox ID="txtHAwbOrHBlNo" runat="server" CssClass="TextBox" ReadOnly="true"
                            MaxLength="20"></asp:TextBox>
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblFltOrVoyNo" runat="server" CssClass="Label" Text="<%$ Resources:lblFltOrVoyNo %>">
                        </asp:Label>
                        <asp:TextBox ID="txtFltOrVoyNo" runat="server" CssClass="TextBox" Width="325px" ReadOnly="true"
                            MaxLength="20"></asp:TextBox>
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblAirportDeptOrPol" runat="server" CssClass="Label" Text="<%$ Resources:lblAirportDeptOrPol %>">
                        </asp:Label>
                        <asp:TextBox ID="txtAirportDeptOrPol" runat="server" CssClass="TextBox" ReadOnly="true"
                            MaxLength="50"></asp:TextBox>
                        <asp:Label ID="lblEtd" runat="server" CssClass="Label" Text="<%$ Resources:lblEtd %>">
                        </asp:Label>
                        <asp:TextBox ID="txtEtd" runat="server" CssClass="TextBox" ReadOnly="true" MaxLength="10"></asp:TextBox>
                        <asp:Button ID="btnEtd" runat="server" CssClass="Button dteButton" Enabled="false"
                            Text="..." UseSubmitBehavior="False" />
                        <asp:Label ID="Label6" runat="server" Text="dd/mm/yyyy">
                        </asp:Label>
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblAirportDestOrPod" runat="server" CssClass="Label" Text="<%$ Resources:lblAirportDestOrPod %>">
                        </asp:Label>
                        <asp:TextBox ID="txtAirportDestOrPod" runat="server" CssClass="TextBox" ReadOnly="true"
                            MaxLength="50"></asp:TextBox>
                        <asp:Label ID="lblEta" runat="server" CssClass="Label" Text="<%$ Resources:lblEta %>">
                        </asp:Label>
                        <asp:TextBox ID="txtEta" runat="server" CssClass="TextBox" ReadOnly="true" MaxLength="10"></asp:TextBox>
                        <asp:Button ID="btnEta" runat="server" CssClass="Button dteButton" Enabled="false"
                            Text="..." UseSubmitBehavior="False" />
                        <asp:Label ID="Label7" runat="server" Text="dd/mm/yyyy">
                        </asp:Label>
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblFinalPlaceOfDelivery" runat="server" CssClass="Label" Text="<%$ Resources:lblFinalPlaceOfDelivery %>">
                        </asp:Label>
                        <asp:TextBox ID="txtFinalPlaceOfDelivery" runat="server" CssClass="TextBox" ReadOnly="true"
                            MaxLength="50"></asp:TextBox>
                        <asp:Label ID="lblDestEta" runat="server" CssClass="Label" Text="<%$ Resources:lblDestEta %>">
                        </asp:Label>
                        <asp:TextBox ID="txtDestEta" runat="server" CssClass="TextBox" ReadOnly="true" MaxLength="10"></asp:TextBox>
                        <asp:Button ID="btnDestEta" runat="server" CssClass="Button dteButton" Enabled="false"
                            Text="..." UseSubmitBehavior="False" />
                        <asp:Label ID="Label8" runat="server" Text="dd/mm/yyyy">
                        </asp:Label>
                    </div>
                    <div class="divline" style="padding-top: 10px;">
                        <asp:Label ID="lblMtoRepCode" runat="server" CssClass="Label" Text="<%$ Resources:lblMtoRepCode %>">
                        </asp:Label>
                        <asp:TextBox ID="txtMtoRep" runat="server" CssClass="TextBox dteTextBox" MaxLength="10"></asp:TextBox>
                        <asp:TextBox ID="txtMtoRepName" runat="server" CssClass="TextBox ShortTextBox" Width="215px"></asp:TextBox>
                        <asp:Button ID="btnMtoRep" runat="server" CssClass="Button dteButton" Text="..."
                            UseSubmitBehavior="False" />
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblDateDeliveredToMtoRep" runat="server" CssClass="Label" Text="<%$ Resources:lblDateDeliveredToMtoRep %>">
                        </asp:Label>
                        <asp:TextBox ID="txtDateDeliveredToMtoRep" runat="server" CssClass="TextBox dteTextBox"
                            MaxLength="10"></asp:TextBox>
                        <asp:Button ID="btnDateDeliveredToMtoRep" runat="server" CssClass="Button dteButton"
                            Text="..." UseSubmitBehavior="False" />
                        <asp:Label ID="Label9" runat="server" Text="dd/mm/yyyy">
                        </asp:Label>
                    </div>
                    <div class="divline" style="padding-top: 25px;">
                        <asp:Label ID="lblTearDownInspectionDate" runat="server" CssClass="Label" Text="<%$ Resources:lblTearDownInspectionDate %>">
                        </asp:Label>
                        <asp:TextBox ID="txtTearDownInspectionDate" runat="server" CssClass="TextBox dteTextBox"
                            ReadOnly="true" MaxLength="10"></asp:TextBox>
                        <asp:Button ID="btnTearDownInspectionDate" runat="server" CssClass="Button dteButton"
                            Enabled="false" Text="..." UseSubmitBehavior="False" />
                        <asp:Label ID="Label10" runat="server" Text="dd/mm/yyyy">
                        </asp:Label>
                    </div>
                    <div class="divline">
                        <asp:Label ID="lblQuotationRefNo" runat="server" CssClass="Label" Text="<%$ Resources:lblQuotationRefNo %>">
                        </asp:Label>
                        <asp:TextBox ID="txtQuotationRefNo" runat="server" CssClass="TextBox" Width="325px"
                            ReadOnly="true" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div id="divMiddle13" class="gvwSource">
                <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvwSource_RowDataBound"
                    EnableViewState="False" Width="965px">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="imgEdit" runat="server" AlternateText="Edit" ImageUrl="~/Images/Edit/ed_edit.gif"
                                    CssClass="delImg" />
                                <asp:Image ID="imgDelete" runat="server" AlternateText="Delete" ImageUrl="~/Images/Edit/ed_delete.gif"
                                    CssClass="delImg" />
                                <asp:Image ID="imgInsert" runat="server" AlternateText="Insert" ImageUrl="~/Images/Edit/ed_Insert.gif"
                                    CssClass="delImg" />
                            </ItemTemplate>
                            <ItemStyle CssClass="colEdit taCenter" />
                            <HeaderStyle CssClass="colEdit taCenter " />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="STATUS DATE" DataField="StatusDate">
                            <ItemStyle Width="107px" />
                            <HeaderStyle Width="107px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="CODE" DataField="StatusCode" HtmlEncode="False">
                            <ItemStyle Width="127px" />
                            <HeaderStyle Width="127px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="DESCRIPTION" DataField="StatusDesc" HtmlEncode="False">
                            <ItemStyle Width="537px" />
                            <HeaderStyle Width="537px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="ACTIVITY DATE" DataField="ActivityDate" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                            HtmlEncode="False">
                            <ItemStyle Width="107px" />
                            <HeaderStyle Width="107px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="UPDATE BY" DataField="UpdateBy" HtmlEncode="False">
                            <ItemStyle Width="87px" />
                            <HeaderStyle Width="87px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="LineItemNo" DataField="LineItemNo" HtmlEncode="False">
                            <ItemStyle />
                            <HeaderStyle />
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
        </div>
        <div id="divBottomNav">
            <div style="float: left;">
                <asp:Button ID="btnAddStatus" Text="<%$ Resources:btnAddStatus %>" runat="server"
                    CssClass="Button btnAddStatus" />
            </div>
            <div style="float: right;">
                <asp:Button ID="btnNew" Text="<%$ Resources:btnNew %>" runat="server" CssClass="Button" />
                <asp:Button ID="btnSave" Text="<%$ Resources:btnSave %>" runat="server" CssClass="Button" />
                <asp:Button ID="btnExit" Text="<%$ Resources:btnExit %>" runat="server" CssClass="Button" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="fldId" runat="server" />
    </form>
</body>
</html>
