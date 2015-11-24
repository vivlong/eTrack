<%@ Page Language="VB" AutoEventWireup="true" CodeFile="ContainerList.aspx.vb" Inherits="TypeSort" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        @import url("<%=ConfigPath%>/LrErp.css");
        @import url("<%=ConfigPath%>/LrErp_Grid.css");
        @import url("<%=ConfigPath%>/LrErp_List.css");
        @import url("<%=ConfigPath%>/PageControl.css");
    </style>
    <link href="App_Themes/ContainerList.css" rel="Stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="JavaScript/ContainerList.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script language="javascript" type="text/javascript">
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
<body onload="setConfig('<%=ExportConfig%>');">
    <form id="frmAirline" runat="server">
    <div id="divTopNav">
        <ul id="ulTopNav">
        </ul>
    </div>
    <div id="MsgBox">
        <div class="bar">
            <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:Message, LoadTitleHint %>"></asp:Label>
        </div>
        <div class="content">
            <img alt="" src="../images/load.gif" style="text-align: center; vertical-align: middle" />&nbsp;
            &nbsp;<asp:Label ID="lblMessage" runat="server" Text="<%$ Resources:Message, LoadDataHint %>"></asp:Label>
        </div>
    </div>
    <div id="divSource" style="height: 400px;">
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
    <div id="divBottomNav">
        <asp:Button ID="btnSelectAll" runat="server" Text="Select All" CssClass="Button"
            UseSubmitBehavior="False" Width="80px" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="Button" UseSubmitBehavior="False" />
        <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose.Text %>" CssClass="Button"
            UseSubmitBehavior="False" />
        &nbsp
    </div>
    <asp:HiddenField ID="hidTrxNo" runat="server" />
    </form>
</body>
</html>
