<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta charset="UTF-8">
    <title>eTrack Login</title>
    <base target="_self" />
    <link rel="stylesheet" href="App_Themes/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="App_Themes/LrErp.css">
    <link rel="stylesheet" href="App_Themes/Default.css">
    <link rel="stylesheet" href="App_Themes/icon.css">
    <link rel="stylesheet" href="App_Themes/default/easyui.css">
    <script src="JavaScript/jquery-1.11.2.min.js"></script>
    <script src="JavaScript/jquery.easyui.min.js"></script>
    <script src="App_Themes/bootstrap/js/bootstrap.min.js"></script>
    <script src="App_Themes/layer/layer.js"></script>
    <script src="JavaScript/Common.js"></script>
    <!--#include file="JavaScript/JsConst.js"-->
    <!--#include file="JavaScript/Default.js"-->
    <script type="text/javascript">
        function WebForm_CallbackComplete_SyncFixed() {
            for (var i = 0; i < __pendingCallbacks.length; i++) {
                callbackObject = __pendingCallbacks[i];
                if (callbackObject && callbackObject.xmlRequest && (callbackObject.xmlRequest.readyState == 4)) {
                    if (!__pendingCallbacks[i].async) {
                        __synchronousCallBackIndex = -1;
                    }
                    __pendingCallbacks[i] = null;

                    var callbackFrameID = "__CALLBACKFRAME" + i;
                    var xmlRequestFrame = document.getElementById(callbackFrameID);
                    if (xmlRequestFrame) {
                        xmlRequestFrame.parentNode.removeChild(xmlRequestFrame);
                    }
                    // SyncFix: the following statement has been moved down from above;
                    WebForm_ExecuteCallback(callbackObject);
                }
            }
        }
        window.onload = function() {
            if (typeof (WebForm_CallbackComplete) == "function") {
                // set the original version with fixed version
                WebForm_CallbackComplete = WebForm_CallbackComplete_SyncFixed;
            }
        }
    </script>
</head>
<body>
    <div id="divForm" class="container">
        <form id="DefaultPage" class="form-horizontal" runat="server">
            <div class="pull-left divLogo"><img src="Images/logo.png" alt=""></div>
            <div class="divTitle">
                <h3><span style="color:Red; margin-left: -15%; font-family:@Verdana; font-size:1.3em;">Sys<span style="font-weight:bold;">Freight</span></span><strong>&nbsp;&nbsp;<em style="font-family:@Verdana;">eTrack</em></strong></h3>
            </div>
            <br />
            <div id="divLoginInfo" runat="server">
                <div class="col-xs-12 divLogin" onblur="javascript:showDatabase()" runat="server">
                    <div class="form-group form-group-sm" id="divLoginType" runat="server">
                        <label for="rdbtnType" ID="lblType" class="col-xs-4 control-label bold em09">Login as</label>
                        <div class="col-xs-8" style="text-align: left;">
                            <asp:RadioButtonList ID="rdbtnType" runat="server" RepeatColumns="1" RepeatLayout="flow" RepeatDirection="Vertical" onclick="javascript:showDatabase()" CssClass="radio" Font-Size="0.9em">
                                <asp:ListItem Value="0" Text="Customer / Agent"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Internal User"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Oversea Agent / Warehouse"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Consignee"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="form-group form-group-sm" id="divUid" runat="server">
                        <label for="txtUserId" ID="lblUserId" class="col-xs-3 control-label bold em09">User ID</label>
                        <div class="col-xs-5">
                            <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control" Height="28px"/>
                        </div>
                        <div class="col-xs-4">
                            <asp:CheckBox ID="chkUserName" Text="Save User ID" runat="server" CssClass="checkbox" Font-Size="0.85em"/>
                        </div>
                    </div>
                    <div class="form-group form-group-sm" id="divPwd" runat="server">
                        <label for="txtPassword" ID="lblPassword" class="col-xs-3 control-label bold em09">Password</label>
                        <div class="col-xs-5">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" Height="28px"/>
                        </div>
                        <div class="col-xs-4">                        
                            <p>                            
                                <input type="button" id="btnLogin" runat="server" class="btn btn-default btn-sm btn-blue" style="margin-left: -1em;" value="Login" />
                                <input type="reset" id="Reset1" runat="server" class="btn btn-default btn-sm btn-blue" style="margin-left: 1em;" value="Reset" />
                                <input type="button" id="btnAdv" runat="server" class="btn btn-default btn-sm btn-blue" value="Advance" onclick="Advance(this); return false;" visible=false />
                            </p>
                        </div>
                    </div>
                    <div class="form-group form-group-sm displayNone" id="divLanguage">
                        <label for="drpLanguage" ID="lblLanguage" class="col-xs-4 control-label bold em09">Language</label>
                        <div class="col-xs-8">
                            <asp:DropDownList ID="drpLanguage" runat="server" CssClass="form-control" Height="28px">
                                <asp:ListItem>English</asp:ListItem>
                                <asp:ListItem>Chinese</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group form-group-sm displayNone" id="divDataBase">
                        <label for="drpDatabase" ID="lblDatabase" class="col-xs-4 control-label bold em09">Database</label>
                        <div class="col-xs-8">
                            <div id="divSetDataBase" style="width: 223px; display: inline;">
                                <asp:DropDownList ID="drpDatabase" runat="server" CssClass="form-control" Height="28px"/>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm displayNone" id="divSiteCode">
                        <label for="drSiteCode" ID="lblSite" class="col-xs-4 control-label bold em09">Site</label>
                        <div class="col-xs-8">
                            <div id="divSite" style="display: inline;">
                                <asp:DropDownList ID="drSiteCode" CssClass="form-control" runat="server" Height="28px"/>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <%--Shipment Tracking--%>
                    <div class="form-group form-group-sm" id="divShipment" runat="server">
                        <label ID="lblShipmentTracking" class="col-xs-12 control-label bold em09">Shipment Tracking</label>
                        <div class="col-xs-12">
                            <div class="col-xs-4">
                                <asp:DropDownList ID="drpSearch" runat="server" CssClass="form-control" Height="28px"/>
                            </div>
                            <div class="col-xs-6">
                                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Height="28px"/>
                            </div>
                            <div class="col-xs-2">
                                <input id="btnSubmit" type="button" runat="server" class="btn btn-default btn-sm btn-blue" value="GO" onclick="checkSearch(); return false;" />
                            </div>
                        </div>
                    </div>
                    <%--Transhipment Track & Trace--%>
                    <div class="form-group form-group-sm" id="divTranshipmentTrack" runat="server">
                        <label ID="lblTranshipment" class="col-xs-12 control-label bold em09">Transhipment Track & Trace</label>
                        <div class="col-xs-12">
                            <div class="col-xs-4">
                                <asp:DropDownList ID="drpTranshipmentTrack" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-xs-6">
                                <asp:TextBox ID="txtBLNo" runat="server" CssClass="form-control" Height="28px"/>
                            </div>
                            <div class="col-xs-2">
                                <input type="button" id="Button2" runat="server" class="btn btn-default btn-sm btn-blue" Height="28px" value="GO" onclick="ShowTranshipmentTrack(); return false;" />
                            </div>
                        </div>
                    </div>
                    <%--Import Shipment Status--%>
                    <div class="form-group form-group-sm" id="divImportShipment" runat="server">
                        <label ID="Label3" class="col-xs-12 control-label bold em09">Import Shipment Status</label>
                        <div class="col-xs-12">
                            <div class="col-xs-4">
                                <asp:DropDownList ID="drpImportShipment" runat="server" CssClass="form-control" Height="28px"/>
                            </div>
                            <div class="col-xs-6">
                                <asp:TextBox ID="txtImportShipmentBL" runat="server" CssClass="form-control" Height="28px"/>
                            </div>
                            <div class="col-xs-2">
                                <input type="button" id="Button3" runat="server" class="btn btn-default btn-sm btn-blue" value="GO" onclick="ShowImportShipmentStatus(); return false;" />
                            </div>
                        </div>
                    </div>
                    <%--Export Shipment Status--%>
                    <div class="form-group form-group-sm" id="divExportShipment" runat="server">
                    <label ID="Label1" class="col-xs-12 control-label bold em09">Export Shipment Status</label>
                        <div class="col-xs-12">
                            <div class="col-xs-4">
                                <asp:DropDownList ID="drpExportShipment" runat="server" CssClass="form-control" Height="28px"/>
                            </div>
                            <div class="col-xs-6">
                                <asp:TextBox ID="txtExportShipmentBL" runat="server" CssClass="form-control" Height="28px"/>
                            </div>
                            <div class="col-xs-2">
                                <input type="button" id="Button1" runat="server" class="btn btn-default btn-sm btn-blue" Height="28px" value="GO" onclick="ShowExportShipmentStatus(); return false;" />
                            </div>
                        </div>
                    </div>
                    <%--Sailing Schedule--%>
                    <div class="form-group form-group-sm" id="divSailingSchedule" runat="server">
                    <label ID="lblSailingSchedule" class="col-xs-12 control-label bold em09">Sailing Schedule</label>
                        <div class="col-xs-12">
                            <div class="col-xs-4">
                                <label for="drVSPort" ID="lblPort" class="col-xs-12 control-label">Port</label>
                            </div>
                            <div class="col-xs-6">
                                <asp:DropDownList ID="drPort" runat="server" CssClass="form-control" Height="28px"/>
                            </div>
                            <div class="col-xs-2">
                                <input type="button" id="Button4" runat="server" class="btn btn-default btn-sm btn-blue" Height="28px" value="GO" onclick="ShowVesselList(); return false;" />
                            </div>
                        </div>
                    </div>
                    <%--Vessel Schedule--%>
                    <div class="form-group form-group-sm" id="divVesselSchedule" runat="server">
                    <label ID="lblVesselSchedule" class="col-xs-12 control-label bold em09">Vessel Schedule</label>
                        <div class="col-xs-12">
                            <div class="col-xs-4">
                                <label for="drVSPort" ID="lblVesselPort" class="col-xs-3 control-label">Port</label>
                            </div>
                            <div class="col-xs-6">
                                <asp:DropDownList ID="drVSPort" runat="server" CssClass="form-control" Height="28px"/>
                            </div>
                            <div class="col-xs-2">
                                <input type="button" id="Button5" runat="server" class="btn btn-default btn-sm btn-blue" Height="28px" value="GO" onclick="ShowVSList(); return false;" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="form-group" runat="server">
                        <p style="font-size:0.85em;">Copyright &copy; SysMagic Software Solution Pte Ltd. All rights reserved.</p>
                        <p><a href='javascript:void(0);' onclick="window.open('FirstPage.aspx?Redirect=first')">Disclaimer</a></p>
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
