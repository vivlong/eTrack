<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddStatus.aspx.vb" Inherits="Matra_AddStatus" %>

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
    <link href="App_Themes/AddStatus.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="AddStatus" runat="server">
    <div id="divForm">
        <div id="divTopNav">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="a1" runat="server" CssClass="f12e navNml navOn"
                        Text="<%$ Resources:a1.Text %>" Width="150px"></asp:Label></li>
            </ul>
         </div>
         <div id="divMiddle" class="divBorder">
            <div class="divline">
                <asp:Label ID="lblDateUpdated" runat="server" CssClass="Label" Text="<%$ Resources:lblDateUpdated %>">
                </asp:Label>
                <asp:TextBox ID="txtDateUpdated" runat="server" CssClass="TextBox"></asp:TextBox> 
            </div>
            <div class="divline">
                <asp:Label ID="lblCode" runat="server" CssClass="Label" Text="<%$ Resources:lblCode %>">
                </asp:Label>
                <asp:TextBox ID="txtCode" runat="server" CssClass="TextBox"></asp:TextBox> 
            </div>
            <div class="divline">
                <asp:Label ID="lblDescription" runat="server" CssClass="Label" Text="<%$ Resources:lblDescription %>">
                </asp:Label>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="TextBox"></asp:TextBox> 
            </div>
            <div class="divline">
                <asp:Label ID="lblActivityDate" runat="server" CssClass="Label" Text="<%$ Resources:lblActivityDate %>">
                </asp:Label>
                <asp:TextBox ID="txtActivityDate" runat="server" CssClass="TextBox"></asp:TextBox> 
            </div>
         </div>
         <div id="divBottomNav">
            <asp:Button ID="btnUpdate" Text="<%$ Resources:btnUpdate %>" runat="server" CssClass="Button btnUpdate" />
         </div>
    </div>
    </form>
</body>
</html>
