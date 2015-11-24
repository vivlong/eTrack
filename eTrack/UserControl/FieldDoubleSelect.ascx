<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FieldDoubleSelect.ascx.vb"
    Inherits="FieldDoubleSelect" %>
<link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
<%--<script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>--%>
<asp:TextBox ID="txtCode" runat="server" CssClass="TextBox origin" MaxLength="3" />
<asp:TextBox ID="txtName" ReadOnly="true" runat="server" MaxLength="50" CssClass="TextBox txtorigin" />
<asp:Button ID="btnOpen" runat="server" CssClass="Button bntDate" Text="..." UseSubmitBehavior="False"/>
