<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FieldSingleSelect.ascx.vb"
    Inherits="FieldSingleSelect" %>
<link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
<%--<script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>--%>
<asp:TextBox ID="txtName" ReadOnly="true" runat="server" CssClass="TextBox txtorigin"
    MaxLength="50" />
<asp:Button ID="btnOpen" runat="server" CssClass="Button bntDate" Text="..." UseSubmitBehavior="False"  />
