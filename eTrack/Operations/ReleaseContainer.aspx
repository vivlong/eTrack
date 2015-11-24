<%@ Page Language="VB" AutoEventWireup="true" CodeFile="ReleaseContainer.aspx.vb"
    Inherits="ReceiveContainer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Release Container</title>
    <base target="_self"></base>
    <style type="text/css">
        @import url("<%=ConfigPath%>/LrErp.css");
        @import url("<%=ConfigPath%>/LrErp_Grid.css");
        @import url("<%=ConfigPath%>/LrErp_List.css");
        @import url("<%=ConfigPath%>/PageControl.css");
    </style>
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/ReleaseContainer.css" rel="Stylesheet" type="text/css" />
    <link href="../UserControl/datepicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/BaseList.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="JavaScript/ReleaseContainer.js" -->
    <!--#include file="../JavaScript/DateOperate.js"-->

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>

    <script language="javascript" type="text/javascript" src="../UserControl/datepicker/WdatePicker.js"></script>

    <script language="javascript" type="text/javascript">
function on_page_loaded(){blChanged=true;CloseWindow(0);return false;}   
onerror=handleErr
var txt=""

function handleErr(msg,url,l)
{
txt="There was an error on this page.\n\n";
txt+="Error: " + msg + "\n";
txt+="URL: " + url + "\n";
txt+="Line: " + l + "\n\n";
txt+="Click OK to continue.\n\n";
alert(txt);
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
    <form id="frmReleaseContainer" runat="server">
    <div id="divForm">
        <div id="divTopNav" style="width: 100%">
            <ul id="ulTopNav">
            </ul>
        </div>
        <div id="SaveHint" runat="server" class="Hint" style="left: 0px; top: 10px">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>" />
        </div>
        <br />
        <div id="divMiddle1" style="height: 410px; padding-top: 10px">
            <div class="divline">
                <asp:Label ID="lblReleaseDate" runat="server" CssClass="Label" Width="100px" Text="<%$ Resources:lblReleaseDate %>" />
                <asp:TextBox ID="txtReleaseDate" runat="server" CssClass="TextBox txt" MaxLength="16" />
                <asp:Button ID="btnReleaseDate" runat="server" CssClass="Button bntDate" Text="..."
                    UseSubmitBehavior="False" />
            </div>
            <br />
            <div id="divSource" style="height: 320px; width: 99%; padding-left: 2px;" runat="server">
                <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                    CssClass="GvwView2" OnRowDataBound="gvwSource_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="hid_TrxNo" runat="server" Value='<%# Eval("TrxNo") %>' />
                                <asp:HiddenField ID="hid_LineItemNo" runat="server" Value='<%# Eval("LineItemNo") %>' />
                                <asp:HiddenField ID="hid_Qty" runat="server" Value='<%# Eval("Qty") %>' />
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
                                    MaxLength="13" CssClass="txtField" Width="100px" BorderStyle="Solid" BorderColor="White"
                                    BorderWidth="0px" BackColor="AntiqueWhite" />
                                <asp:HiddenField ID="HidContainerNo" runat="server" Value='<%# Eval("ContainerNo") %>' />
                                <asp:HiddenField ID="HidReleaseFlag" runat="server" Value='<%# Eval("ReleaseFlag") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="colModifyBy taLeft" />
                            <HeaderStyle CssClass="colModifyBy taCenter" />
                            <FooterStyle CssClass="taRight" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Release Date" ItemStyle-BackColor="AntiqueWhite">
                            <ItemTemplate>
                                <asp:TextBox ID="txtReleaseDate" runat="server" Text='<%# Eval("ReleaseDate") %>'
                                    MaxLength="13" CssClass="txtField" Width="100px" BorderStyle="Solid" BorderColor="White"
                                    ReadOnly="true" BorderWidth="0px" BackColor="AntiqueWhite" />
                            </ItemTemplate>
                            <ItemStyle CssClass="colModifyBy taLeft" />
                            <HeaderStyle CssClass="colModifyBy taCenter" />
                            <FooterStyle CssClass="taRight" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trucker Name" ItemStyle-BackColor="AntiqueWhite">
                            <ItemTemplate>
                                <asp:TextBox ID="txtTruckerName" runat="server" Text='<%# Eval("TruckerName") %>'
                                    CssClass="txtField" MaxLength="50" BorderStyle="Solid" BorderColor="White" BorderWidth="0px"
                                    BackColor="AntiqueWhite" />
                            </ItemTemplate>
                            <ItemStyle CssClass="colTable taLeft" />
                            <HeaderStyle CssClass="colTable taCenter" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vehicle No" ItemStyle-BackColor="AntiqueWhite">
                            <ItemTemplate>
                                <asp:TextBox ID="txtVehicleNo" runat="server" Text='<%# Eval("VehicleNo") %>' CssClass="txtField"
                                    MaxLength="25" BorderStyle="Solid" BorderColor="White" BorderWidth="0px" BackColor="AntiqueWhite" />
                            </ItemTemplate>
                            <ItemStyle CssClass="colFieldName taLeft" />
                            <HeaderStyle CssClass="colFieldName taCenter" />
                            <FooterStyle CssClass="taRight" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Seal No" ItemStyle-BackColor="AntiqueWhite">
                            <ItemTemplate>
                                <asp:TextBox ID="txtSealNo" runat="server" Text='<%# Eval("SealNo") %>' CssClass="txtField"
                                    MaxLength="30" BorderStyle="Solid" BorderColor="White" BorderWidth="0px" BackColor="AntiqueWhite" />
                            </ItemTemplate>
                            <FooterStyle CssClass="taRight" />
                            <HeaderStyle CssClass="colType taCenter" />
                            <ItemStyle CssClass="colType taLeft" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DG Flag" ItemStyle-BackColor="AntiqueWhite">
                            <ItemTemplate>
                                <asp:TextBox ID="txtDGFlag" runat="server" Text='<%# Eval("DGFlag") %>' CssClass="txtField"
                                    Width="40px" MaxLength="1" BorderStyle="Solid" BorderColor="White" BorderWidth="0px"
                                    BackColor="AntiqueWhite" />
                            </ItemTemplate>
                            <ItemStyle CssClass="colLen taLeft" />
                            <HeaderStyle CssClass="colLen taCenter" />
                            <FooterStyle CssClass="taRight" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Driver Pass No" ItemStyle-BackColor="AntiqueWhite">
                            <ItemTemplate>
                                <asp:TextBox ID="txtDriverPassNo" runat="server" Text='<%# Eval("DriverPassNo") %>'
                                    CssClass="txtField" MaxLength="20" BorderStyle="Solid" BorderColor="White" BorderWidth="0px"
                                    BackColor="AntiqueWhite" />
                            </ItemTemplate>
                            <FooterStyle CssClass="taRight" />
                            <HeaderStyle CssClass="colView taCenter" />
                            <ItemStyle CssClass="colView taLeft" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Container Type" ItemStyle-BackColor="AntiqueWhite">
                            <ItemTemplate>
                                <asp:TextBox ID="txtContainerType" runat="server" Width="100px" Text='<%# Eval("EquipmentType") %>'
                                    CssClass="txtField" MaxLength="20" BorderStyle="Solid" BorderColor="White" BorderWidth="0px"
                                    ReadOnly="true" BackColor="AntiqueWhite" />
                            </ItemTemplate>
                            <FooterStyle CssClass="taRight" />
                            <HeaderStyle CssClass="colView taCenter" />
                            <ItemStyle CssClass="colView taLeft" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Release Remark" ItemStyle-BackColor="AntiqueWhite">
                            <ItemTemplate>
                                <asp:TextBox ID="txtReleaseRemarks" runat="server" Text='<%# Eval("ReleaseRemarks") %>'
                                    CssClass="txtField" Width="300px" MaxLength="255" BorderStyle="Solid" BorderColor="White"
                                    BorderWidth="0px" BackColor="AntiqueWhite" />
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
            <asp:Button ID="btnReleaseContainer" runat="server" Text="<%$ Resources:btnReleaseContainer %>"
                CssClass="Button" UseSubmitBehavior="False" Width="150px" />
            <asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:btnCancel %>" CssClass="Button"
                UseSubmitBehavior="False" Width="100px" />&nbsp&nbsp
        </div>
        <asp:HiddenField ID="fldId" runat="server" />
        <asp:HiddenField ID="hidLineItemNo" runat="server" />
        <asp:HiddenField ID="hidTruckerName" runat="server" />
        <asp:HiddenField ID="hidEquipmentType" runat="server" />
    </div>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
         currentValue=""
         currentValue="-1";
</script>

