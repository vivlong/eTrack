<%@ Page Language="VB" AutoEventWireup="true" CodeFile="Tracking.aspx.vb" Inherits="Tracking" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title></title>
  <link href="../App_Themes/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <link href="../App_Themes/bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet">
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/Tracking.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/Calendar.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/GridList.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->
    <!--#include file="../JavaScript/Print.js" -->
    <!--#include file="JavaScript/Tracking.js" -->
  <script type="text/javascript" src="../JavaScript/Common.js"> </script>
  <script type="text/javascript" src="../JavaScript/Calendar.js"> </script>
  <script type="text/javascript" src="../JavaScript/Format.js"> </script>
  <script src="../App_Themes/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
  <script src="../App_Themes/bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
  <script type="text/javascript">
      var txtTableName = "";
     function SelectedDivl(selectId,LiCount)
   {
    var DivName;
    var LiName;
    for(var i=1;i<=LiCount;i++)
    {
        if (selectId==i)
        {
                LiName="a"+selectId.toString();
                document.getElementById(LiName).className="f12e navNml navOn";
        }
        else{
                LiName="a"+i.toString();
                document.getElementById(LiName).className="f12c navNml noSep";
             }
    }
    if(selectId==1)
    { 
     document.getElementById("btnControl").style.display="";
     document.getElementById("divTrackSearch").style.display="";
     TableName="jmjm1";
     document.getElementById("divTrackSearch").style.display="block";
     document.getElementById("divTrackSearch1").style.display="none";
     document.getElementById("divSource2").style.display="none";
     document.getElementById("divPage").style.display="block";
     document.getElementById("divSource").style.display="block";
     document.getElementById("divSource3").style.display="none";
     document.getElementById("divCargo").style.display="none";
    }
    else if(selectId==2)
    {
     document.getElementById("btnControl").style.display="none";
     document.getElementById("divTrackSearch").style.display="none";
     document.getElementById("divTrackSearch1").style.display="block";
     //divSource2.style.display="block";
     TableName="Transhipment_Mf";
     document.getElementById("divSource").style.display="none";
     document.getElementById("divSource2").style.display="block";
     document.getElementById("divSource3").style.display="block";
     document.getElementById("divPage").style.display="none";
     document.getElementById("divCargo").style.display="none";
    }
    else if(selectId==3)
    {
     document.getElementById("btnControl").style.display="none";
     document.getElementById("divTrackSearch").style.display="none";
     document.getElementById("divTrackSearch1").style.display="block";
     document.getElementById("divSource2").style.display="none";
     //TableName="";
     document.getElementById("divSource").style.display="none";
     document.getElementById("divSource3").style.display="none";
     document.getElementById("divPage").style.display="none";
     document.getElementById("divCargo").style.display="block";
     document.getElementById("divTrackSearch1").style.display="none";
    }
     document.getElementById('hidVal_Tracking').value=selectId;
     context=document.getElementById("hid_div");
     var arg="SetTabVal"+ParSeparator+selectId;
     <%= ClientScript.GetCallbackEventReference(Me,"arg","SetResult", "context")%>; 
    }
       function SetResult(result,context)
   {
    var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk) {
            context.innerHTML=strResult[1];
            }
            else if (strResult[1]!=""){
                window.alert(strResult[1]);
            }
   }
  function ShowGvwData(objFlag)
  {
  if(objFlag=="sea"){var txtValue =document.getElementById("txtBLNo").value;}
  if(objFlag=="air"){var txtValue =document.getElementById("txtAWBNo").value;}
     context=divSource3;
     var arg="BindGvwData"+ParSeparator+objFlag+ParSeparator+txtValue;
     <%= ClientScript.GetCallbackEventReference(Me,"arg","ShowGvw", "context")%>; 
  }
   function ShowGvw(result,context)
   {
          var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk) {
            context.innerHTML=strResult[1];
            divSource2.innerHTML=strResult[2];
            }
            else if (strResult[1]!=""){
                window.alert(strResult[1]);
            }
   }
  function ShowCargoData(objFlag)
  {
  if(objFlag=="sea"){
  var txtValue =document.getElementById("txtCargoBLNo").value;
     context=document.getElementById("divHouseBLNumber");
     var arg="ShowCargoDatabac"+ParSeparator+objFlag+ParSeparator+txtValue;
     <%= ClientScript.GetCallbackEventReference(Me,"arg","ShowCargo", "context")%>; 
   }
   else{return false;}
  }
  
 function ShowCargo(result,context)
{
      var strResult=result.split(ParSeparator);
      if(strResult.length>0)
      {
        if (strResult[0]==RtnOk) {
            document.getElementById("divHouseBLNumber").innerHTML=strResult[1];
            document.getElementById("divVslDetails").innerHTML=strResult[2];
            document.getElementById("divPortOfLoading").innerHTML=strResult[3];
            document.getElementById("divETDPOL").innerHTML=strResult[4];
            document.getElementById("divPortofDischarge").innerHTML=strResult[5];
            document.getElementById("divETAPOD").innerHTML=strResult[6];
            document.getElementById("divCargoArrive").innerHTML=strResult[7];
            document.getElementById("divDeliveryOrderready").innerHTML=strResult[8];
            document.getElementById("divDeliveryOrdercollected").innerHTML=strResult[9];
            document.getElementById("divCargocollectby").innerHTML=strResult[10];
            document.getElementById("divContainerNo").innerHTML=strResult[11];
            document.getElementById("divSEALNo").innerHTML=strResult[12];
         }
      }
}
    </script>
  <style type="text/css">
  .container-fluid 
  {
    padding-left: 0px;
    padding-right: 0px;
  }
  .form-horizontal .control-label 
  {
    text-align:left;
  }
  </style>
</head>

<body onload="DivAutoSize(155);" onresize="DivAutoSize(155);" class="container-fluid">
  <form id="frmTracking" runat="server" role="form" class="form-horizontal">
    <div id="divTopNav" runat="server">
        <ul id="ulTopNav">
            <li>
          <asp:Label ID="a1" CssClass="f12e navNml navOn" runat="server" Width="120px" onclick="javascript:SelectedDivl(1,3);" Text="<%$ Resources:a1 %>"></asp:Label></li>
            <li>
          <asp:Label ID="a2" CssClass="f12c navNml noSep" runat="server" Width="120px" onclick="javascript:SelectedDivl(2,3);" Text="<%$ Resources:a2 %>"></asp:Label></li>
            <li>
          <asp:Label ID="a3" CssClass="f12c navNml noSep" runat="server" Width="120px" onclick="javascript:SelectedDivl(3,3);" Text="<%$ Resources:a3 %>"></asp:Label></li>
        </ul>
    </div>
    <div id="popupMenu" class="skin" runat="server" onclick="ClickItem(event)" onmousemove="HighlighItem(event)" onmouseout="LowlightItem(event)"></div>
    <div id="MsgBox">
        <div class="bar">
            <asp:Label ID="lblLoadTitleHint" runat="server" Text="<%$ Resources:Message, LoadTitleHint %>"></asp:Label>
        </div>
        <div class="content">
            <img alt="" src="../images/load.gif" style="text-align: center; vertical-align: middle" />
            <asp:Label ID="lblMessage" runat="server" Text="<%$ Resources:Message, LoadDataHint %>"></asp:Label>
        </div>
    </div>
    <div id="divTrackSearch" style="height: 54px; padding-bottom: 2px; padding-left: 5px;" class="divSearch">
        <div class="divline">
            <asp:DropDownList ID="drpSearch" runat="server" CssClass="" />
            <asp:TextBox ID="txtSearch" runat="server" CssClass="TextBox" />
            <asp:HiddenField ID="fldCustomerCode" runat="server" />
            <asp:HiddenField ID="fldLoginType" runat="server" />
        </div>
        <div class="divline">
            <div class="fLeft">
                <asp:DropDownList ID="drpFrom" runat="server" CssClass="" />
                <asp:Label ID="lblFrom" runat="server" Text="From"></asp:Label>
                <asp:TextBox ID="txtFrom" runat="server" CssClass="TextBox" />
          <asp:Button ID="btnFrom" runat="server" CssClass="Button" Text="..." Width="20px" UseSubmitBehavior="False" />
                <asp:Label ID="lblTo" runat="server" Text="To"></asp:Label>
                <%--<asp:DropDownList ID="drpTo" runat="server" CssClass="" /> --%>
                <asp:TextBox ID="txtTo" runat="server" CssClass="TextBox" />
                <asp:Button ID="btnTo" runat="server" CssClass="Button" Text="..." Width="20px" UseSubmitBehavior="False" />
                &nbsp<asp:Button ID="btnSearch" runat="server" CssClass="Button" Text="Search" UseSubmitBehavior="false" />
          <asp:Button ID="btnMultiGridColumnSet" runat="server" CssClass="btnFnt" Text="Custom" UseSubmitBehavior="false" />
            </div>
        </div>
    </div>
    <div id="divTrackSearch1" style="height: 60px; display: none;" class="divSearch">
        <%--display: none--%>
        <div class="divTrans">
            <asp:Label ID="lblBLNo" CssClass="Label lbl2" runat="server" Text="<%$ Resources:lblBLNo %>" />
            <asp:TextBox ID="txtBLNo" runat="server" CssClass="txt2" />
            <asp:Button ID="btnSearchSebl" runat="server" CssClass="Button" Text="Search" UseSubmitBehavior="false" />
        </div>
        <div class="divTrans">
            <asp:Label ID="lblAWBNo" CssClass="Label lbl2" runat="server" Text="<%$ Resources:lblAWBNo %>" />
            <asp:TextBox ID="txtAWBNo" runat="server" CssClass="txt2" />
            <asp:Button ID="btnSearchAiaw" runat="server" CssClass="Button" Text="Search" UseSubmitBehavior="false" />
        </div>
    </div>
    <div id="divSource">
      <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvwSource_RowDataBound" EnableViewState="False">
            <HeaderStyle CssClass="Header" />
            <FooterStyle CssClass="Footer" />
            <RowStyle CssClass="Row" />
            <SelectedRowStyle CssClass="SelectRow" />
            <PagerStyle CssClass="Pager" />
            <AlternatingRowStyle CssClass="Alternating" />
        </asp:GridView>
    </div>
    <div id="divSource3" style="display: none;" class="divSource">
      <asp:GridView ID="gvwSourceTS" runat="server" AutoGenerateColumns="False" EnableViewState="False" OnRowDataBound="gvwSourceTS_RowDataBound">
            <HeaderStyle CssClass="Header" />
            <FooterStyle CssClass="Footer" />
            <RowStyle CssClass="Row" />
            <SelectedRowStyle CssClass="SelectRow" />
            <PagerStyle CssClass="Pager" />
            <AlternatingRowStyle CssClass="Alternating" />
        </asp:GridView>
    </div>
    <div id="divSource2" runat="server" style="display: none;" class="divSource">
      <asp:GridView ID="gvwSourceDown" runat="server" AutoGenerateColumns="False" EnableViewState="False" OnRowDataBound="gvwSourceDown_RowDataBound" CssClass="gvwSource">
            <HeaderStyle CssClass="Header" />
            <FooterStyle CssClass="Footer" />
            <RowStyle CssClass="Row" />
            <SelectedRowStyle CssClass="SelectRow" />
            <PagerStyle CssClass="Pager" />
            <AlternatingRowStyle CssClass="Alternating" />
        </asp:GridView>
    </div>
    <div id="divCargo" style="display: none;">
        <div id="div1" style="height: 50px;">
            <%--display: none--%>
            <div class="divTrans">
                <asp:Label ID="lblCargoBLNo" CssClass="Label lbl2" runat="server" Text="<%$ Resources:lblBLNo %>" />
                <asp:TextBox ID="txtCargoBLNo" runat="server" CssClass="txt2" />
                <asp:Button ID="btnCargoSebl" runat="server" CssClass="Button" Text="Search" UseSubmitBehavior="false" />
            </div>
            <div class="divTrans">
                <asp:Label ID="lblCargoAiaw" CssClass="Label lbl2" runat="server" Text="<%$ Resources:lblAWBNo %>" />
                <asp:TextBox ID="txtCargoAiaw" runat="server" CssClass="txt2" />
                <asp:Button ID="btnCargoAiaw" runat="server" CssClass="Button" Text="Search" UseSubmitBehavior="false" />
            </div>
        </div>
        <p></p>
        <div id="divSource4" class="divSource row" style="height: 470px;">
            <p></p>
            <div class="col-xs-11">
                <div class="row">
                    <div class="col-xs-6">
                        <div class="form-group form-group-sm">
                            <label for="txtHouseBLNumber" id="lblHouseBLNumber" class="col-xs-5 control-label">House BL Number</label>
                            <div class="col-xs-7" id="divHouseBLNumber">
                                <asp:TextBox ID="txtHouseBLNumber" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-6">
                        <div class="form-group form-group-sm">
                            <label for="txtVslDetails" id="lblVslDetails" class="col-xs-5 control-label">Vsl Details</label>
                            <div class="col-xs-7" id="divVslDetails">
                                <asp:TextBox ID="txtVslDetails" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <div class="form-group form-group-sm">
                            <label for="txtPortOfLoading" id="lblPortOfLoading" class="col-xs-5 control-label">Port Of Loading</label>
                            <div class="col-xs-7" id="divPortOfLoading">
                                <asp:TextBox ID="txtPortOfLoading" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-6">
                        <div class="form-group form-group-sm">
                            <label for="txtETDPOL" id="lblETDPOL" class="col-xs-5 control-label">ETD POL</label>
                            <div class="col-xs-7" id="divETDPOL">
                                <asp:TextBox ID="txtETDPOL" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <div class="form-group form-group-sm">
                            <label for="txtPortofDischarge" id="lblPortofDischarge" class="col-xs-5 control-label">Port of Discharge</label>
                            <div class="col-xs-7" id="divPortofDischarge">
                                <asp:TextBox ID="txtPortofDischarge" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-6">
                        <div class="form-group form-group-sm">
                            <label for="txtETAPOD" id="lblETAPOD" class="col-xs-5 control-label">ETA POD</label>
                            <div class="col-xs-7" id="divETAPOD">
                                <asp:TextBox ID="txtETAPOD" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group form-group-sm">
                    <label for="txtDeliveryOrderready" id="lblCargoArrive" class="col-xs-4 control-label">Cargo arrived at Port of Discharge</label>
                    <div class="col-xs-8" id="divCargoArrive">
                        <asp:TextBox ID="txtCargoArrive" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group form-group-sm">
                    <label for="txtDeliveryOrderready" id="lblDeliveryOrderready" class="col-xs-4 control-label">Delivery Order ready for collection by Consignee</label>
                    <div class="col-xs-8" id="divDeliveryOrderready">
                        <asp:TextBox ID="txtDeliveryOrderready" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group form-group-sm">
                    <label for="txtDeliveryOrdercollected" id="lblDeliveryOrdercollected" class="col-xs-4 control-label">Delivery Order collected by Consignee</label>
                    <div class="col-xs-8" id="divDeliveryOrdercollected">
                        <asp:TextBox ID="txtDeliveryOrdercollected" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group form-group-sm">
                    <label for="txtCargocollectby" id="lblCargocollectby" class="col-xs-4 control-label">Cargo collect by Consignee</label>
                    <div class="col-xs-8" id="divCargocollectby">
                        <asp:TextBox ID="txtCargocollectby" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group form-group-sm">
                    <label for="txtContainerNo" id="lblContainerNo" class="col-xs-4 control-label">Container No</label>
                    <div class="col-xs-8" id="divContainerNo">
                        <asp:TextBox ID="txtContainerNo" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group form-group-sm">
                    <label for="txtSealNo" id="lblSealNo" class="col-xs-4 control-label">Seal No</label>
                    <div class="col-xs-8" id="divSealNo">
                        <asp:TextBox ID="txtSealNo" runat="server" CssClass="form-control" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="divPage">
        <div class="fLeft">
            <asp:Label ID="lblPage" runat="server" Text="Page"></asp:Label>
            <asp:LinkButton ID="lbtnFirst" runat="server" Text="First"></asp:LinkButton>
            <asp:LinkButton ID="lbtnPrior" runat="server" Text="Prior"></asp:LinkButton>
            <asp:Label ID="lblPabe" runat="server" Text="Page" />
            <asp:TextBox ID="txtPage" runat="server" CssClass="txInput"></asp:TextBox>
            <asp:LinkButton ID="lbtnGoTo" runat="server" Text="Go"></asp:LinkButton>
            <asp:LinkButton ID="lbtnNext" runat="server" Text="Next"></asp:LinkButton>
            <asp:LinkButton ID="lbtnLast" runat="server" Text="Last"></asp:LinkButton>
        </div>
        <div id="btnControl" class="fRight">
            <asp:Button ID="btnPrint" runat="server" CssClass="Button" Text="Print" UseSubmitBehavior="False" />
            <asp:Button ID="btnToExcel" runat="server" CssClass="Button" Text="Export Excel"
                Width="77px" UseSubmitBehavior="False" />
        </div>
    </div>
    <div id="hid_div">
        <asp:HiddenField ID="hidVal_Tracking" runat="server" Value="1" />
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
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
</script>
