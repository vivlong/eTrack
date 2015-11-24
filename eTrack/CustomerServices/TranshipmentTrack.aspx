<%@ Page Language="VB" AutoEventWireup="true" CodeFile="TranshipmentTrack.aspx.vb"
    Inherits="TranshipmentTrack" %>

<%@ Register Src="../UserControl/DateTimeSelect.ascx" TagName="DateTimeSelect" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Transhipment Track & Trace </title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/TranshipmentTrack.css" rel="stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!--#include file="../JavaScript/ResetSize.js" -->
    <!--#include file="JavaScript/SelectReportEdit.js" -->
    <style type="text/css">
        .style1
        {
            display: inline-block;
            background-color: #D8EBFF;
            padding-left: 5px;
            width: 120px;
        }
        .style2
        {
            display: inline-block;
            background-color: #D8EBFF;
            padding-left: 5px;
            width: 164px;
        }
    </style>
</head>
<body>
    <form id="frmVessel" runat="server">
    <div id="divForm">
        <div id="MsgBox">
            <div class="bar">
                <asp:Label ID="lblLoadTitleHint" runat="server" Text="<%$ Resources:Message, LoadTitleHint %>"></asp:Label>
            </div>
            <div class="content">
                <img alt="" src="../images/load.gif" style="text-align: center; vertical-align: middle" />&nbsp;
                &nbsp;<asp:Label ID="lblMessage" runat="server" Text="<%$ Resources:Message, LoadDataHint %>"></asp:Label>
            </div>
        </div>
        <div id="divVesselSearch" style="width: 900px; padding-left: 10px; margin-top: 10px">
            <table class="table1">
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblOrigin" CssClass="label" runat="server" Text="ORIGIN MOTHER VSL/VOY">
                        </asp:Label>
                    </td>
                    <td class="TextBox" style="width: 130px">
                        <asp:Label ID="txtOrigin" CssClass="Label" runat="server">
                        </asp:Label>
                    </td>
                    <td>
                    </td><!--
                    <td class="style1"   >
                        TRACK AT 
                    </td>!-->
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblETA" CssClass="label" runat="server" Text="ETA SINGAPORE">
                        </asp:Label>
                    </td>
                    <td class="TextBox">
                        <asp:Label ID="txtETA" CssClass="Label" runat="server">
                        </asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <div class="divLine">
                &nbsp;
            </div>
            <div id="divSource" style="height: 390px; width: 980px">
                <asp:Repeater runat="server" ID="rptSource">
                    <HeaderTemplate>
                        <table class="table1" style="width: 900px;" cellpadding="1px" cellspacing="1px">
                            <tr>
                                <td class="alignCenter style1" style="width: 150px">
                                    HOUSE B/L<br />
                                    NUMBER
                                </td>
                                <td class="alignCenter style1" style="width: 190px">
                                    FINAL<br />
                                    DESTINATION
                                </td>
                                
                                <td class="alignCenter style1" style="width: 180px">
                                    CONNECTING<br />
                                    VESSEL
                                </td>
                                <td class="alignCenter style1" style="width: 110px">
                                    ETD<br />
                                    SIN
                                </td>
                                <td class="alignCenter style1" style="width: 110px">
                                    ETA<br />
                                    P.O.D
                                </td>
                                
                                <td class="alignCenter style1" style="width: 160px">
                                    CONTAINER /<br />
                                    SEAL NO.
                                </td>
                                <td class="alignCenter" style="background-color: #D8EBFF; width: 480px">
                                    DELIVERY
                                    <br />
                                    AGENT
                                </td>
                                <!--
                                <td class="alignCenter style1">
                                    BOOKING<br />
                                    NUMBER
                                </td> !-->
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="TextBox txt">
                                <asp:Label ID="txtHouse" Text='<% #Eval("BlNo")%>' CssClass="Label" runat="server">
                                </asp:Label>
                            </td>
                            <td class="TextBox txt">
                                <asp:Label ID="txtFinal" Text='<% #Eval("CityName")%>' CssClass="Label" runat="server">
                                </asp:Label>
                            </td>
                            <td class="TextBox txt">
                                <asp:Label ID="txtConnecting" Text='<% #Eval("VesselName")%>' CssClass="Label" runat="server">
                                </asp:Label>
                            </td>
                            <td class="TextBox txt">
                                <asp:Label ID="txtETD" Text='<% #Eval("EtdDate")%>' CssClass="Label" runat="server">
                                </asp:Label>
                            </td>
                            <td class="TextBox txt">
                                <asp:Label ID="txtETAPOD" Text='<% #Eval("EtaDate")%>' CssClass="Label" runat="server">
                                </asp:Label>
                            </td>
                            
                             <td class="TextBox txt">
                                <asp:Label ID="txtContainerSealNoType" Text='<% #Eval("ContainerSealNoType")%>' CssClass="Label" runat="server">
                                </asp:Label>
                            </td>
                            <td class="TextBox txtT">
                                <asp:Label ID="txtDelivery" Text='<% #Eval("DeliveryAgentName")%>' CssClass="Label"
                                    runat="server">
                                </asp:Label>
                            </td>
                            <!--
                            <td class="TextBox txt">
                                <asp:Label ID="txtBooking" Text='<% #Eval("ExportBookingNo")%>' CssClass="Label"
                                    runat="server">
                                </asp:Label>
                            </td> !-->
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div id="divBottomNav">
            <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:PageList, Close %>"
                CssClass="Button" UseSubmitBehavior="False" />
        </div>
    </div>
    </form>
</body>
</html>
