<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DateTimeSelect.ascx.vb"
    Inherits="DateTimeSelect" %>
<link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
<script type="text/javascript" src="../JavaScript/jquery.maskedinput.js"></script>
<asp:TextBox ID="txtDateTime" runat="server" Width="100px" CssClass="TextBox txtorigin" />
<asp:Button ID="btnOpen" runat="server" CssClass="Button bntDate" Text="..." UseSubmitBehavior="False" />
<script type="text/javascript">
    $(function () {
        var sIncludeTime = '<%= sIncludeTime %>';
        if (sIncludeTime != "False") {
            $('#' + '<%= txtDateTime.ClientID %>').mask('99/99/9999 99:99');
        }
        else {
            $('#' + '<%= txtDateTime.ClientID %>').mask('99/99/9999');
        }
    });
</script>
