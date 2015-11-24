<%@ Page Language="VB" AutoEventWireup="true" CodeFile="MatraEdit.aspx.vb" Inherits="MatraEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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
    <link href="App_Themes/Matra.css" rel="Stylesheet" type="text/css" />
</head>
<body> 
    <form id="frmMatraEntry" runat="server">
    <div id="divForm">
        <div id="divTopNav">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="a1" runat="server" CssClass="f12e navNml navOn"
                        Text="<%$ Resources:a1.Text %>"></asp:Label></li>
            </ul>
         </div>
        <div id="divMiddle1" class="divBorder">
        
            <div id="divMiddle11">
                <div class="divline">
                    <asp:Label ID="lblRFQNo" runat="server" CssClass="Label" Text="<%$ Resources:lblRFQNo %>">
                    </asp:Label>
                    <asp:TextBox ID="txtRFQNo" runat="server" CssClass="TextBox LongTextBox"></asp:TextBox> 
                </div>
                <div class="divline">
                    <asp:Label ID="lblPartNo" runat="server" CssClass="Label" Text="<%$ Resources:lblPartNo %>">
                    </asp:Label>
                    <asp:TextBox ID="txtPartNo" runat="server" CssClass="TextBox LongTextBox"></asp:TextBox> 
                </div>
                <div class="divline">
                    <asp:Label ID="lblSerialNo" runat="server" CssClass="Label" Text="<%$ Resources:lblSerialNo %>">
                    </asp:Label>
                    <asp:TextBox ID="txtSerialNo" runat="server" CssClass="TextBox LongTextBox" ></asp:TextBox> 
                </div>
                <div class="divline" style="padding-top:25px;">
                    <asp:Label ID="lblMatra" runat="server" CssClass="Label" Text="<%$ Resources:lblMatra %>">
                    </asp:Label>
                </div>
                <div class="divline">
                    <asp:Label ID="lblMtoNotification" runat="server" CssClass="Label" Text="<%$ Resources:lblMtoNotification %>">
                    </asp:Label>
                    <asp:TextBox ID="txtMtoNotification" runat="server" CssClass="TextBox LongTextBox" ></asp:TextBox> 
                </div>
                <div class="divline">
                    <asp:Label ID="lblLocalMto" runat="server" CssClass="Label" Text="<%$ Resources:lblLocalMto %>">
                    </asp:Label>
                    <asp:TextBox ID="txtLocalMto" runat="server" CssClass="TextBox" ></asp:TextBox> 
                    <asp:TextBox ID="txtLocalMtoName" runat="server" CssClass="TextBox" ></asp:TextBox> 
                </div>
                <div class="divline">
                    <asp:Label ID="lblPickupFrom" runat="server" CssClass="Label" Text="<%$ Resources:lblPickupFrom %>">
                    </asp:Label>
                    <asp:TextBox ID="txtPickupFrom" runat="server" CssClass="TextBox" ></asp:TextBox> 
                    <asp:TextBox ID="txtPickupDate" runat="server" CssClass="TextBox" ></asp:TextBox> 
                </div>
                <div class="divline">
                    <asp:Label ID="lblShipTo" runat="server" CssClass="Label" Text="<%$ Resources:lblShipTo %>">
                    </asp:Label>
                    <asp:TextBox ID="txtShipTo" runat="server" CssClass="TextBox" ></asp:TextBox> 
                    <asp:TextBox ID="txtShipDate" runat="server" CssClass="TextBox" ></asp:TextBox> 
                </div>
                <div class="divline">
                    <asp:Label ID="lblConsignmentNote" runat="server" CssClass="Label" Text="<%$ Resources:lblConsignmentNote %>">
                    </asp:Label>
                    <asp:TextBox ID="txtConsignmentNote" runat="server" CssClass="TextBox LongTextBox" ></asp:TextBox> 
                </div>
                <div class="divline" style="padding-top:25px;">
                    <asp:Label ID="lblMtoRep" runat="server" CssClass="Label" Text="<%$ Resources:lblMtoRep %>">
                    </asp:Label>
                    <asp:TextBox ID="txtMtoRep" runat="server" CssClass="TextBox" ></asp:TextBox> 
                    <asp:TextBox ID="txtMtoRepName" runat="server" CssClass="TextBox" ></asp:TextBox> 
                </div>
                <div class="divline">
                    <asp:Label ID="lblMro" runat="server" CssClass="Label" Text="<%$ Resources:lblMro %>">
                    </asp:Label>
                    <asp:TextBox ID="txtMro" runat="server" CssClass="TextBox" ></asp:TextBox> 
                    <asp:TextBox ID="txtMroName" runat="server" CssClass="TextBox" ></asp:TextBox> 
                </div>
            </div>
            
            <div id="divMiddle12">
                <div class="divline">
                    <asp:Label ID="lblCreateBy" runat="server" CssClass="Label" Text="<%$ Resources:lblCreateBy %>">
                    </asp:Label>
                    <asp:TextBox ID="txtCreateBy" runat="server" CssClass="TextBox" ></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCloseJob" Text="<%$ Resources:btnCloseJob %>" runat="server" CssClass="Button btnCloseJob" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblCreateAt" runat="server" CssClass="Label" Text="<%$ Resources:lblCreateAt %>">
                    </asp:Label>
                    <asp:TextBox ID="txtCreateAt" runat="server" CssClass="TextBox LongTextBox" ></asp:TextBox> 
                </div>
                <div class="divline"  style="padding-top:25px;">
                    <asp:Label ID="lblStatus" runat="server" CssClass="Label" Text="<%$ Resources:lblStatus %>">
                    </asp:Label>
                    <asp:DropDownList ID="drpStatus" runat="server" >
                        <asp:ListItem Text="Open" Value="0"></asp:ListItem>
                        <asp:ListItem Text="In-Process" Value="1" Selected="True"  ></asp:ListItem>
                        <asp:ListItem Text="Close" Value="2"></asp:ListItem>
                    </asp:DropDownList> 
                </div>
                <div class="divline">
                    <asp:Label ID="lblMto" runat="server" CssClass="Label" Text="<%$ Resources:lblMto %>">
                    </asp:Label>
                </div>
                <div class="divline">
                    <asp:Label ID="lblCommodity" runat="server" CssClass="Label" Text="<%$ Resources:lblCommodity %>">
                    </asp:Label>
                    <asp:TextBox ID="txtCommodity" runat="server" CssClass="TextBox LongTextBox" ></asp:TextBox> 
                </div>
                <div class="divline">
                    <asp:Label ID="lblQty" runat="server" CssClass="Label" Text="<%$ Resources:lblQty %>">
                    </asp:Label>
                    <asp:TextBox ID="txtQty" runat="server" CssClass="TextBox" ></asp:TextBox> 
                    <asp:TextBox ID="txtUom" runat="server" CssClass="TextBox" ></asp:TextBox> 
                </div>
                <div class="divline">
                    <asp:Label ID="lblGrossWeight" runat="server" CssClass="Label" Text="<%$ Resources:lblGrossWeight %>">
                    </asp:Label>
                    <asp:TextBox ID="txtGrossWeight" runat="server" CssClass="TextBox" ></asp:TextBox> 
                    <asp:Label ID="lblChargeWeight" runat="server" CssClass="Label" Text="<%$ Resources:lblChargeWeight %>">
                    </asp:Label>
                    <asp:TextBox ID="txtChargeWeight" runat="server" CssClass="TextBox" ></asp:TextBox> 
                </div>
                <div class="divline">
                    <asp:Label ID="lblMAwbOrOBlNo" runat="server" CssClass="Label" Text="<%$ Resources:lblMAwbOrOBlNo %>">
                    </asp:Label>
                    <asp:TextBox ID="txtMAwbOrOBlNo" runat="server" CssClass="TextBox" ></asp:TextBox> 
                    <asp:Label ID="lblHAwbOrHBlNo" runat="server" CssClass="Label" Text="<%$ Resources:lblHAwbOrHBlNo %>">
                    </asp:Label>
                    <asp:TextBox ID="txtHAwbOrHBlNo" runat="server" CssClass="TextBox" ></asp:TextBox> 
                </div>
                <div class="divline">
                    <asp:Label ID="lblFltOrVoyNo" runat="server" CssClass="Label" Text="<%$ Resources:lblFltOrVoyNo %>">
                    </asp:Label>
                    <asp:TextBox ID="txtFltOrVoyNo" runat="server" CssClass="TextBox LongTextBox" ></asp:TextBox> 
                </div>
                <div class="divline">
                    <asp:Label ID="lblAirportDeptOrPol" runat="server" CssClass="Label" Text="<%$ Resources:lblAirportDeptOrPol %>">
                    </asp:Label>
                    <asp:TextBox ID="txtAirportDeptOrPol" runat="server" CssClass="TextBox" ></asp:TextBox> 
                    <asp:Label ID="lblEtd" runat="server" CssClass="Label" Text="<%$ Resources:lblEtd %>">
                    </asp:Label>
                    <asp:TextBox ID="txtEtd" runat="server" CssClass="TextBox" ></asp:TextBox> 
                </div>
                <div class="divline">
                    <asp:Label ID="lblAirportDestOrPod" runat="server" CssClass="Label" Text="<%$ Resources:lblAirportDestOrPod %>">
                    </asp:Label>
                    <asp:TextBox ID="txtAirportDestOrPod" runat="server" CssClass="TextBox" ></asp:TextBox> 
                    <asp:Label ID="lblEta" runat="server" CssClass="Label" Text="<%$ Resources:lblEta %>">
                    </asp:Label>
                    <asp:TextBox ID="txtEta" runat="server" CssClass="TextBox" ></asp:TextBox> 
                </div>
                <div class="divline">
                    <asp:Label ID="lblFinalPlaceOfDelivery" runat="server" CssClass="Label" Text="<%$ Resources:lblFinalPlaceOfDelivery %>">
                    </asp:Label>
                    <asp:TextBox ID="txtFinalPlaceOfDelivery" runat="server" CssClass="TextBox" ></asp:TextBox> 
                    <asp:Label ID="lblDestEta" runat="server" CssClass="Label" Text="<%$ Resources:lblDestEta %>">
                    </asp:Label>
                    <asp:TextBox ID="txtDestEta" runat="server" CssClass="TextBox" ></asp:TextBox> 
                </div>
            </div>
            <div id="divMiddle13" class="gvwSource">
                <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                         OnRowDataBound="gvwSource_RowDataBound" CssClass="GvwView">
                    <Columns>
                        <asp:BoundField HeaderText="STATUS DATE" >
                            <ItemStyle CssClass="taLeft" Width="150px" />
                            <HeaderStyle CssClass="taCenter" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="CODE" >
                            <ItemStyle CssClass="taLeft" Width="160px" />
                            <HeaderStyle CssClass="taCenter" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="DESCRIPTION" >
                            <ItemStyle CssClass="taLeft" Width="250px" />
                            <HeaderStyle CssClass="taCenter" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="ACTIVITY DATE" >
                            <ItemStyle CssClass="taLeft" Width="150px" />
                            <HeaderStyle CssClass="taCenter" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="UPDATE BY">
                            <ItemStyle Width="120px" CssClass="taLeft" />
                            <HeaderStyle CssClass="taCenter" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
         <div id="divBottomNav">
            <asp:Button ID="btnAddStatus" Text="<%$ Resources:btnAddStatus %>" runat="server" CssClass="Button btnAddStatus" />
         </div>
    </div>
    </form>
</body>
</html>
