<%@ Page Language="VB" AutoEventWireup="true" CodeFile="RIEdit.aspx.vb" Inherits="RIEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title id="strTitle"></title>
    <style type="text/css">
        @import url("<%=ConfigPath%>/LrErp.css");
        @import url("<%=ConfigPath%>/LrErp_Grid.css");
        @import url("<%=ConfigPath%>/LrErp_List.css");
        @import url("<%=ConfigPath%>/PageControl.css");
    </style>
    <link href="../App_Themes/HintMessage.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/RIEdit.css" rel="Stylesheet" type="text/css" />
    <link href="../UserControl/datepicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="JavaScript/RIEdit.js" -->
    <!-- #include file="../JavaScript/DateOperate.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script language="javascript" type="text/javascript" src="../UserControl/datepicker/WdatePicker.js"></script>

    <script language="javascript" type="text/javascript">
    function on_page_loaded()
    {blChanged=true;CloseWindow(0);return false;}
    
     function setConfig()
     {
       var strConfig=document.getElementById("hidConfig").value;
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
<body onunload="on_page_loaded();">

    <script type="text/javascript">
function WebForm_CallbackComplete_SyncFixed() {
  for (var i = 0; i < __pendingCallbacks.length; i++) {
   callbackObject = __pendingCallbacks[ i ];
  if (callbackObject && callbackObject.xmlRequest && (callbackObject.xmlRequest.readyState == 4)) {
   if (!__pendingCallbacks[ i ].async) {
     __synchronousCallBackIndex = -1;
   }
   __pendingCallbacks[i] = null;

   var callbackFrameID = "__CALLBACKFRAME" + i;
   var xmlRequestFrame = document.getElementById(callbackFrameID);
   if (xmlRequestFrame) {
     xmlRequestFrame.parentNode.removeChild(xmlRequestFrame);
   }
   WebForm_ExecuteCallback(callbackObject);
  }
 }
}

window.onload = function(){
if (typeof (WebForm_CallbackComplete) == "function") {
  WebForm_CallbackComplete = WebForm_CallbackComplete_SyncFixed;
}
}
    </script>

    <form id="frmRI" runat="server">
    <div id="divForm">
        <div id="popupMenu" class="skin" runat="server" onclick="ClickItem()" onmousemove="HighlighItem()"
            onmouseout="LowlightItem()">
        </div>
        <div id="divTopNav">
            <ul id="ulTopNav">
                <li>
                    <asp:Label ID="a1" CssClass="f12e navNml navOn" runat="server" Text="<%$ Resources:a1 %>"
                        Width="250px" />
                </li>
            </ul>
        </div>
        <div id="SaveHint" runat="server" class="Hint" style="left: 0px; top: 10px">
            <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>" />
        </div>
        <div id="divMiddle1" class="divMiddle1" style="height: 560px; padding-top: 10px;
            width: 99%">
            <div id="divMiddle11">
                <div class="divline" style="display: none;">
                    <asp:TextBox ID="txtRIN" runat="server" CssClass="TextBox txt" MaxLength="20" />
                    <asp:TextBox ID="txtSiteCode" runat="server" CssClass="TextBox txt" MaxLength="10" />
                    <asp:TextBox ID="txtUserId" runat="server" CssClass="TextBox txt" MaxLength="50" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblOrganization" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblOrganization %>" />
                    <asp:TextBox ID="txtOrganization" runat="server" CssClass="TextBox txt" MaxLength="10"
                        Width="198px" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblMasterJobNo" runat="server" Text="<%$ Resources:lblMasterJobNo %>"
                        CssClass="Label lbl" />
                    <asp:TextBox ID="txtMasterJobNo" runat="server" CssClass="TextBox txt" MaxLength="20"
                        Width="198px" />
                    <asp:Button ID="btnMasterJobNo" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblVesselName" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblVesselName %>" />
                    <asp:TextBox ID="txtVesselName" runat="server" CssClass="TextBox txt" MaxLength="50"
                        Width="282px" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblVoyageNo" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblVoyageNo %>" />
                    <asp:TextBox ID="txtVoyageNo" runat="server" CssClass="TextBox txt" MaxLength="12" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblETA" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblETA %>" />
                    <asp:TextBox ID="txtETA" runat="server" CssClass="TextBox txt" MaxLength="16" />
                    <asp:Button ID="btnETA" runat="server" CssClass="Button bntDate" Text="..." UseSubmitBehavior="False" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblReleaseType" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblReleaseType %>" />
                    <asp:TextBox ID="txtReleaseType" runat="server" CssClass="TextBox txt" MaxLength="50"
                        ReadOnly="true" Width="180px" />
                    <asp:DropDownList ID="drReleaseType" runat="server" CssClass="DropList" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblReleasingDC" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblReleasingDC %>" />
                    <asp:TextBox ID="txtReleasingDC" runat="server" CssClass="TextBox txt" MaxLength="5" />
                    <asp:Button ID="btnReleasingDC" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                </div>
            </div>
            <div id="divMiddle12">
                <div class="divline">
                    <asp:Label ID="lblPortOfLoading" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblPortOfLoading %>" />
                    <asp:TextBox ID="txtPortOfLoading" runat="server" CssClass="TextBox txt" MaxLength="5" />
                    <asp:Button ID="btnPortOfLoading" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblProtOfDischarge1" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblProtOfDischarge1 %>" />
                    <asp:TextBox ID="txtProtOfDischarge1" runat="server" CssClass="TextBox txtProt" MaxLength="5" />
                    <asp:Button ID="btnProtOfDischarge1" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblProtOfDischarge2" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblProtOfDischarge2 %>" />
                    <asp:TextBox ID="txtProtOfDischarge2" runat="server" CssClass="TextBox txtProt" MaxLength="5" />
                    <asp:Button ID="btnProtOfDischarge2" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblProtOfDischarge3" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblProtOfDischarge3 %>" />
                    <asp:TextBox ID="txtProtOfDischarge3" runat="server" CssClass="TextBox txtProt" MaxLength="5" />
                    <asp:Button ID="btnProtOfDischarge3" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblFinalDestination" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblFinalDestination %>" />
                    <asp:TextBox ID="txtFinalDestination" runat="server" CssClass="TextBox txt" MaxLength="5" />
                    <asp:Button ID="btnFinalDestination" runat="server" CssClass="Button bntDate" Text="..."
                        UseSubmitBehavior="False" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblDetentionCode" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblDetentionCode %>" />
                    <asp:TextBox ID="txtDetentionCode" runat="server" CssClass="TextBox txt" MaxLength="50"
                        ReadOnly="true" />
                    <asp:DropDownList ID="drDetentionCode" runat="server" CssClass="DropList" MaxLength="10" />
                </div>
                <div class="divline">
                    <asp:Label ID="lblFreePeriod" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblFreePeriod %>" />
                    <asp:TextBox ID="txtFreePeriod" runat="server" CssClass="TextBox txt" MaxLength="4" />
                </div>
            </div>
            <div id="divSource" style="height: 350px; display: block;" runat="server">
                <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                    OnRowDataBound="gvwSource_RowDataBound">
                    <HeaderStyle CssClass="Header" />
                    <FooterStyle CssClass="Footer" />
                    <RowStyle CssClass="Row" />
                    <SelectedRowStyle CssClass="SelectRow" />
                    <PagerStyle CssClass="Pager" />
                    <AlternatingRowStyle CssClass="Alternating" />
                </asp:GridView>
            </div>
            <div id="divPage">
                <div class="fLeft">
                    <asp:Label ID="lblPage" runat="server" Text="Page"></asp:Label>
                    <asp:LinkButton ID="lbtnFirst" runat="server" Text="First"></asp:LinkButton>
                    <asp:LinkButton ID="lbtnPrior" runat="server" Text="Prior"></asp:LinkButton>
                    <asp:LinkButton ID="lbtnNext" runat="server" Text="Next"></asp:LinkButton>
                    <asp:LinkButton ID="lbtnLast" runat="server" Text="Last"></asp:LinkButton>
                    <asp:LinkButton ID="lbtnGoTo" runat="server" Text="Go to"></asp:LinkButton>
                    <asp:TextBox ID="txtPage" runat="server" CssClass="txInput"></asp:TextBox>
                </div>
            </div>
        </div>
        <div id="divBottomNav" class="divBottom">
            <asp:Button ID="btnNew" runat="server" Text="<%$ Resources:btnNew %>" CssClass="Button"
                UseSubmitBehavior="False" Visible="false" />
            <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:btnSave %>" CssClass="Button"
                UseSubmitBehavior="False" />
            <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose %>" CssClass="Button"
                UseSubmitBehavior="False" />&nbsp&nbsp
        </div>
        <div id="divTrxNo">
            <asp:HiddenField ID="hidTrxNo" runat="server" />
        </div>
        <asp:HiddenField ID="hidNewTrxNo" runat="server" />
        <asp:HiddenField ID="HidTitle" runat="server" Value="<%$ Resources:a1 %>" />
        <asp:HiddenField ID="hidConfig" runat="server"  />        
    </div>
    </form>
</body>
</html>

<script type="text/javascript" language="javascript">
// if (window.Event){
//    document.captureEvents(Event.MOUSEUP); 
// }
    function nocontextmenu(){ 
     event.cancelBubble = true 
     event.returnValue = false; 
     return false; 
    } 
    function nodblClick(){ 
     event.cancelBubble = true 
     event.returnValue = false; 
     return false; 
    } 
    function norightclick(e){ 
     if (window.Event){ 
      //if (e.which == 2 || e.which == 3) 
      return false; 
     } 
     else 
      if (event.button == 2 || event.button == 3){ 
       event.cancelBubble = true 
       event.returnValue = false; 
       return false; 
      } 
    } 
    document.oncontextmenu = nocontextmenu; // for IE5+ 
    //document.onmousedown = norightclick; 
    document.onclick = HideMenu;
    document.ondblclick = nodblClick;
    setConfig();
</script>

