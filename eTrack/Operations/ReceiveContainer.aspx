<%@ Page Language="VB" AutoEventWireup="true" CodeFile="ReceiveContainer.aspx.vb"
    Inherits="ReceiveContainer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Receive Container</title>
    <base target="_self"></base>
    <style type="text/css">
        @import url("<%=ConfigPath%>/LrErp.css");
        @import url("<%=ConfigPath%>/LrErp_Grid.css");
        @import url("<%=ConfigPath%>/LrErp_List.css");
        @import url("<%=ConfigPath%>/PageControl.css");
    </style>
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/ReceiveContainer.css" rel="Stylesheet" type="text/css" />
    <link href="../UserControl/datepicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/BaseList.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="JavaScript/ReceiveContainer.js" -->
    <!--#include file="../JavaScript/DateOperate.js"-->

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>

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
    <form id="frmReceiveContainer" runat="server">
    <div id="divForm">
        <div id="divTopNav" style="width: 100%;">
            <ul id="ulTopNav">
            </ul>
        </div>
        <div id="SaveHint" runat="server" class="Hint" style="left: 0px; top: 10px">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>" />
        </div>
        <div id="divMiddle1" style="width: 100%; height: 420px; padding-top: 10px">
            <br />
            <div class="divline">
                <asp:Label ID="lblReceivedDate" runat="server" CssClass="Label" Width="100px" Text="<%$ Resources:lblReceivedDate %>" />
                <asp:TextBox ID="txtReceivedDate" runat="server" CssClass="TextBox txt" MaxLength="16" />
                <asp:Button ID="btnReceivedDate" runat="server" CssClass="Button bntDate" Text="..."
                    UseSubmitBehavior="False" />
            </div>
            <br />
            <div id="divSource" class="divSource1" style="height: 340px; width: 99%" runat="server">
                <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                    CssClass="GvwView2" OnRowDataBound="gvwSource_RowDataBound">
                    <%-- --%>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a id="Img2" runat="server" alt="del">
                                    <img id="Img3" runat="server" src="../Images/Edit/ed_Delete.gif" alt="del" />
                                </a>
                            </ItemTemplate>
                            <ItemStyle CssClass="colNo taLeft" />
                            <HeaderStyle CssClass="colNo taCenter" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Container No" ItemStyle-BackColor="AntiqueWhite">
                            <ItemTemplate>
                                <asp:TextBox ID="txtContainerNo" runat="server" Text='<%# Eval("ContainerNo") %>'
                                    MaxLength="13" CssClass="TextBox txtField" BorderStyle="Solid" BorderColor="White"
                                    BorderWidth="0px" BackColor="AntiqueWhite" />
                                <asp:HiddenField ID="HidContainerNo" runat="server" Value='<%# Eval("ContainerNo") %>' />
                                <asp:HiddenField ID="hid_TrxNo" runat="server" Value='<%# Eval("TrxNo") %>' />
                                <asp:HiddenField ID="hid_LineItemNo" runat="server" Value='<%# Eval("LineItemNo") %>' />
                                <asp:HiddenField ID="HidReceiveFlag" runat="server" Value='<%# Eval("ReceiveFlag") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="colModifyBy taLeft" />
                            <HeaderStyle CssClass="colModifyBy taCenter" />
                            <FooterStyle CssClass="taRight" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="POL" ItemStyle-BackColor="AntiqueWhite">
                            <ItemTemplate>
                                <asp:TextBox ID="lblPOD" runat="server" Text='<%# Eval("PortOfLoadingCode") %>' CssClass=" label txtField"
                                    Width="70px" BorderStyle="Solid" BorderColor="White" BorderWidth="0px" BackColor="AntiqueWhite"
                                    ReadOnly="true" />
                            </ItemTemplate>
                            <ItemStyle CssClass="colTable taLeft" />
                            <HeaderStyle CssClass="colTable taCenter" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trucker Name" ItemStyle-BackColor="AntiqueWhite">
                            <ItemTemplate>
                                <asp:TextBox ID="txtTruckerName" runat="server" Text='<%# Eval("TruckerName") %>'
                                    CssClass="TextBox txtField" MaxLength="50" BorderStyle="Solid" BorderColor="White"
                                    BorderWidth="0px" BackColor="AntiqueWhite" />
                            </ItemTemplate>
                            <ItemStyle CssClass="colTable taLeft" />
                            <HeaderStyle CssClass="colTable taCenter" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vehicle No" ItemStyle-BackColor="AntiqueWhite">
                            <ItemTemplate>
                                <asp:TextBox ID="txtVehicleNo" runat="server" Text='<%# Eval("VehicleNo") %>' CssClass="TextBox txtField"
                                    MaxLength="20" Width="70px" BorderStyle="Solid" BorderColor="White" BorderWidth="0px"
                                    BackColor="AntiqueWhite" />
                            </ItemTemplate>
                            <ItemStyle CssClass="colFieldName taLeft" />
                            <HeaderStyle CssClass="colFieldName taCenter" />
                            <FooterStyle CssClass="taRight" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Collection Remarks" ItemStyle-BackColor="AntiqueWhite">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCollectionRemarks" runat="server" Text='<%# Eval("CollectionRemarks") %>'
                                    CssClass="TextBox txtField" MaxLength="255" BorderStyle="Solid" BorderColor="White"
                                    BorderWidth="0px" BackColor="AntiqueWhite" />
                            </ItemTemplate>
                            <FooterStyle CssClass="taRight" />
                            <HeaderStyle CssClass="colType taCenter" />
                            <ItemStyle CssClass="colType taLeft" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Survey Remarks" ItemStyle-BackColor="AntiqueWhite">
                            <ItemTemplate>
                                <asp:TextBox ID="txtSurveyRemarks" runat="server" Text='<%# Eval("SurveyRemarks") %>'
                                    CssClass="TextBox txtField" MaxLength="255" BorderStyle="Solid" BorderColor="White"
                                    BorderWidth="0px" BackColor="AntiqueWhite" />
                            </ItemTemplate>
                            <ItemStyle CssClass="colLen taLeft" />
                            <HeaderStyle CssClass="colLen taCenter" />
                            <FooterStyle CssClass="taRight" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Detention Chg" ItemStyle-BackColor="AntiqueWhite">
                            <ItemTemplate>
                                <asp:TextBox ID="txtDetentionChg" runat="server" Text='<%# Eval("ActualDetentionCharge") %>'
                                    CssClass="TextBox txtField" MaxLength="14" BorderStyle="Solid" BorderColor="White"
                                    BorderWidth="0px" BackColor="AntiqueWhite" />
                            </ItemTemplate>
                            <FooterStyle CssClass="taRight" />
                            <HeaderStyle CssClass="colView taCenter" />
                            <ItemStyle CssClass="colView taLeft" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Computed Detention Chg" ItemStyle-BackColor="AntiqueWhite">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCDC" runat="server" Width="100px" Text='<%# Eval("ComputedDetentionCharge") %>'
                                    CssClass="TextBox txtField" MaxLength="14" BorderStyle="Solid" BorderColor="White"
                                    ReadOnly="true" BorderWidth="0px" BackColor="AntiqueWhite" />
                            </ItemTemplate>
                            <FooterStyle CssClass="taRight" />
                            <HeaderStyle CssClass="colView taCenter" />
                            <ItemStyle CssClass="colView taLeft" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="State" ItemStyle-BackColor="AntiqueWhite">
                            <ItemTemplate>
                                <asp:Label ID="txtState" runat="server" Text='<%# Eval("State") %>' CssClass="label txtField"
                                    Width="120px" MaxLength="2" BorderStyle="Solid" BorderColor="White" BorderWidth="0px"
                                    BackColor="AntiqueWhite" />
                                <asp:DropDownList ID="drState" runat="server" BackColor="AntiqueWhite">
                                    <asp:ListItem Value="SD">Pending Survery</asp:ListItem>
                                    <asp:ListItem Value="DM">Damage</asp:ListItem>
                                    <asp:ListItem Value="AV" Selected="True">Available</asp:ListItem>
                                    <asp:ListItem Value="WR">Washing Required</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                            <FooterStyle CssClass="taRight" />
                            <HeaderStyle CssClass="colView taCenter" />
                            <ItemStyle CssClass="colView taLeft" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Container Type" ItemStyle-BackColor="AntiqueWhite">
                            <ItemTemplate>
                                <asp:TextBox ID="txtContainerType" runat="server" Text='<%# Eval("ContainerType") %>'
                                    CssClass="TextBox txtField" Width="90px" MaxLength="5" BorderStyle="Solid" BorderColor="White"
                                    BorderWidth="0px" BackColor="AntiqueWhite" />
                                <asp:DropDownList ID="drContainerType" runat="server" BackColor="AntiqueWhite">
                                    <asp:ListItem Value="Empty" Selected="True">Empty</asp:ListItem>
                                    <asp:ListItem Value="Laden">Laden</asp:ListItem>
                                </asp:DropDownList>
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
            <br />
        </div>
        <div id="divBottomNav">
            <asp:Button ID="btnSave" runat="server" Text="Receive Container" CssClass="Button"
                UseSubmitBehavior="False" Width="130px" />
            <%-- <asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:btnCancel %>" CssClass="Button"
                UseSubmitBehavior="False" Width="100px" />--%>
            <asp:Button ID="btnPrintReceipt" runat="server" Text="<%$ Resources:btnPrintReceipt %>"
                CssClass="Button" UseSubmitBehavior="False" Width="120px" />&nbsp&nbsp
        </div>
        <input name='txtTRLastIndex' type='hidden' id='txtTRLastIndex' value="1" />
        <asp:HiddenField ID="fldId" runat="server" />
        <asp:HiddenField ID="hidBatchNo" runat="server" />
    </div>
    </form>
</body>
</html>
