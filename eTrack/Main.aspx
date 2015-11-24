<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Main.aspx.vb" Inherits="Main"
    EnableEventValidation="false" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>SysFreight Online System</title>
    <link href="App_Themes/system.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/LrErp.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/Header.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="JavaScript/jquery.min.js"></script>
    <script type="text/javascript" src="JavaScript/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="JavaScript/main.js"></script>
    <script type="text/javascript">
		function Closing(strFlag)
        {     
            var arg = "HandleLogout"; 
            context=null;
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "strFlag", "context")%>;
        }
      
        $(function() {
            $(".toggle dl dd").hide();
            $(".toggle dl dt").click(function() {
                $(".toggle dl dd").not($(this).next()).hide();
             //   $(".toggle dl dt").not($(this).next()).removeClass("current");
                $(this).next().slideToggle(150);
              //  $(this).toggleClass("current");
            });
        });
				
 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div region="north" border="false" class="headbackground" style="height: 60px;">
        <div id="divLogo" style="vertical-align: middle">
            <asp:Image ID="imgSysmagic" runat="server" ImageUrl="Images/logo.png" Height="60px"
                Width="180px"></asp:Image>
        </div>
        <div id="divUsrMsg" runat="server" style="left: 192px; top: -52px">
            <asp:Label ID="lblWelcome" runat="server" Text="Welcome"></asp:Label>
            <asp:Label ID="lblUserName" runat="server"></asp:Label>
            <%--<asp:Image ID="imgsms" runat="server" ImageUrl="Images/smsHint.gif"></asp:Image>--%>
            <asp:HyperLink ID="lnksms" runat="server"></asp:HyperLink>
        </div>
        <div id="divDate" style="top: -52px">
            <asp:Label ID="lblDateTime" runat="server"></asp:Label></div>
        <div id="divImage">
            <asp:Button ID="btnHelp" runat="server" CssClass="Button" Text="Help" UseSubmitBehavior="false"
                Visible="False" />
            <a id="btnRelogin" runat="server" href="#" class="easyui-linkbutton">Relogin</a>
            <a id="btnExit" runat="server" href="#" class="easyui-linkbutton">Exit</a>
        </div>
    </div>
    <div id="divTrk" runat="server" style="display: none">
        <div id="divTracking" class="disHid" runat="server" style="padding-left: 10px; height: 80px;
            padding-bottom: 0px;">
            <div class="divline">
                &nbsp</div>
            <div class="divline1">
                <asp:DropDownList ID="drJobNo" runat="server">
                    <asp:ListItem Value="JobNo">Job No</asp:ListItem>
                    <asp:ListItem Value="MawbOBLNo">BL No</asp:ListItem>
                    <asp:ListItem Value="AwbBlNo">AWB No</asp:ListItem>
                    <asp:ListItem Value="ContainerNo">Container No</asp:ListItem>
                    <asp:ListItem Value="CustomerRefNo">Reference No</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="divline">
                &nbsp</div>
            <div class="divline1">
                <asp:TextBox ID="txt_serach" CssClass="textbox" runat="server" Width="100px"></asp:TextBox>
            </div>
            <div class="divline">
                &nbsp</div>
            <div class="divline1">
                <input id="btn" type="button" class="Button" value="Submit" onclick="GoToPage('CustomerServices/LeftSerach.aspx','SeaFreight',800,700)"
                    style="cursor: hand; height: 22px; width: 60px" />
            </div>
        </div>
    </div>
    <div region="west" split="false" title="Main Menu" style="width: 180px; padding1: 1px;
        overflow: hidden;">
        <div id="divForm" class="easyui-accordion" fit="true" runat="server" border="false" style="width:100%:" >
        </div>
    </div>
    <div region="center" height="0px">
        <div id="tabs" class="easyui-tabs" fit="true" border="false">
            <div id="tab1" title="Home" class="easyui-tabs" fit="true" border="false" href="FirstPage.aspx">
            </div>
        </div>
    </div>
    </form>
</body>
</html>
