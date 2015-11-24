<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SendEmail.aspx.vb" Inherits="Reference_SendeEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email</title>
        <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/Calendar.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/SendEmail.css" rel="Stylesheet" type="text/css" />
       <!-- #include file="../JavaScript/JsConst.js" -->
       <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="JavaScript/SendEmail.js" -->
</head>
<body>
    <form id="form1" runat="server">
    <div id="divMiddle1" runat="server" class="divBorder divTab" style="height: 300px;
            width: 100%; padding-left: 20px; padding-top: 10px;">
    
     <div class="divline">
                    <asp:Label ID="lblTo" CssClass="Label lbl" runat="server" Text="To" />
                    <asp:TextBox ID="txtTo" runat="server" CssClass="TextBox txt" />
                </div>
                    <div class="divline">
                    <asp:Label ID="lblCC" CssClass="Label lbl" runat="server" Text="Cc" />
                    <asp:TextBox ID="txtCC" runat="server" CssClass="TextBox txt"  />
                </div>
                    <div class="divline">
                    <asp:Label ID="lblSubject" CssClass="Label lbl" runat="server" Text="Subject" />
                    <asp:TextBox ID="txtSubject" runat="server" CssClass="TextBox txt"  />
                </div>
                    <div class="divline">
                   
                    <asp:TextBox ID="txtContent" runat="server" CssClass="TextBox content" 
                            TextMode="MultiLine"  />
                </div>
               <%-- <div class="divButton">      
                      <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="Button" UseSubmitBehavior="False"
                Width="120px"  />
        </div>--%>
          <div id="divBottomNav" runat="server">
            <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="Button"
                UseSubmitBehavior="False" />
            <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="Button"
                UseSubmitBehavior="False" />&nbsp &nbsp &nbsp
        </div>
    </div>
    <script language="javascript" type="text/javascript">
    setValue();
    </script>
    </form>
</body>
</html>
