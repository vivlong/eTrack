<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Charts.aspx.vb" Inherits="Statistics_Charts" %>

<%@ Register Assembly="Chartlet" Namespace="FanG" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chart</title>
    <link href="../App_Themes/samples.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" method="post" runat="server" style="text-align: center">
<%--    <div id="div1" style="height: 100%; text-align: left;">
        <asp:Label ID="labStyle" runat="server" Text="Appearance Style" CssClass="label" />
        &nbsp
        <asp:DropDownList ID="drStyle" runat="server">
        </asp:DropDownList>
    </div>--%>
    <div id="divChar" style="height: 100%; padding-top: 30px;">
        <cc1:Chartlet ID="clStatis" runat="server" AppearanceStyle="Bar_3D_Breeze_FlatCrystal_NoGlow_NoBorder"
            ChartTitle="" XUnit="" YUnit="" Alpha3D="255" FillColor1="Blue" 
            FillColorStyle="None" FillShiftStep="0" GroupSize="3" StrokeColorStyle="None" />
    </div>
    <p class="dscr">
        <!-- SECOND DESCRIPTION HERE-->
    </p>
    </form>
</body>
</html>
