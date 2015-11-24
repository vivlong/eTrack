<%@ Page Language="VB" AutoEventWireup="true" CodeFile="ContainerEnquiryDetail.aspx.vb"  Inherits="ContainerEnquiryDetail" %>

<%@ Register Src="../UserControl/DateTimeSelect.ascx" TagName="DateTimeSelect" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/ContainerEnquiryDetail.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/Print.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <script language="javascript" type="text/javascript" src="../UserControl/datepicker/WdatePicker.js"></script>
    <link href="../UserControl/datepicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
     <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="JavaScript/ContainerEnquiryEdit.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>

</head>
<body onunload="CloseWindow();">
    <form id="frmContainerEnquiryEdit" runat="server">
    <div id="divForm">
        <div id="divTopNav">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="a1" CssClass="f12e navNml navOn" runat="server" Text="<%$ Resources:a1.Text %>"></asp:Label></li><%--Text="<%$ Resources:a1.Text %>"--%>
            </ul>
        </div>
        <div id="SaveHint" runat="server" class="Hint">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>"> </asp:Label>
        </div>
        <div id="divMiddle1" class="divBorder">
            <div class="divline">
                <asp:Label ID="lblContainerNo" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblContainerNo %>"></asp:Label>
                <asp:TextBox ID="txtContainerNo" ReadOnly=true runat="server" CssClass="TextBox txt"></asp:TextBox>
            </div>
            <div class="divline">
                <asp:Label ID="lblETA" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblETA %>"></asp:Label>
                <asp:TextBox ID="txtETA" ReadOnly ="true" runat="server" CssClass="TextBox txt"></asp:TextBox>
                <asp:HiddenField ID="txtETD" runat="server" />
            </div>
             <div class="divline">
                <asp:Label ID="lblDischargeDate" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblDischargeDate %>"></asp:Label>
                <uc1:DateTimeSelect ID="dtsDischargeDate" runat="server" />
                dd/mm/yyyy 
            </div>
            <div class="divline">
                <asp:Label ID="lblFinalDestDate" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblFinalDestDate %>"></asp:Label>
                <uc1:DateTimeSelect ID="txtFinalDestDate" runat="server" />
                dd/mm/yyyy 
            </div>
            <div class="divline">
                <asp:Label ID="lblDOReleaseDate" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblDOReleaseDate %>"></asp:Label>
                 <uc1:DateTimeSelect ID="txtDOReleaseDate" runat="server" />
                dd/mm/yyyy 
            </div>
            <div class="divline">
                <asp:Label ID="lblCntrReturnDate" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblCntrReturnDate %>"></asp:Label>
                 <uc1:DateTimeSelect ID="txtCntrReturnDate" runat="server" />
                dd/mm/yyyy 
            </div>
            <div class="divline">
                <asp:Label ID="lblCntrReturnType" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblCntrReturnType %>"></asp:Label>
                <asp:DropDownList ID="drCntrReturnType" runat="server" CssClass="txtDate">
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="E">Empty</asp:ListItem>
                    <asp:ListItem Value="L">Laden</asp:ListItem>                  
                </asp:DropDownList>
            </div>
            <div class="divline">
                <asp:Label ID="lblHODate" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblHODate %>"></asp:Label>
                     <uc1:DateTimeSelect ID="txtHODate" runat="server" />
            </div>
             <div class="divline">
                <asp:Label ID="lblOwner" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblOwner %>"></asp:Label>
                <asp:TextBox ID="txtOwner" runat="server" CssClass="TextBox txt" MaxLength="80"></asp:TextBox>
            </div>  
            <div class="divline">
                <asp:Label ID="lblCntrRemark" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblCntrRemark %>"></asp:Label>
                <asp:TextBox ID="txtCntrRemark" runat="server" CssClass="TextBox txt" MaxLength="500"></asp:TextBox>
            </div>  
            <div class="divline">
                <asp:Label ID="lblPickupDate" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblPickupDate %>" Visible="false"></asp:Label>
                <uc1:DateTimeSelect ID="txtPickupDate" runat="server" Visible ="false"/>
            </div>  
          <div class="divline">
                <asp:Label ID="lblCargoStatusCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblCargoStatusCode %>"></asp:Label>
                <asp:DropDownList ID="drCargoStatusCode" runat="server" CssClass="txtDate">
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                    <asp:ListItem Value="N">No</asp:ListItem>                  
                </asp:DropDownList> 
                <asp:HiddenField ID="fldRccfContainer" runat="server" />
                <asp:HiddenField ID="fldCntrTransferDate" runat="server" />
           </div>           
        </div>
         <div id="divBottomNav" style="width: 100%;">
        <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:btnSave %>" CssClass="Button"
            UseSubmitBehavior="False" />
        <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose %>" CssClass="Button"
            UseSubmitBehavior="False" />&nbsp
    </div>
    </div>
    <asp:HiddenField ID="fldId" runat="server" />
    </form>
</body>
</html>
