<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WMS.aspx.vb" Inherits="WMS_WMS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_Grid.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/LrErp_List.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/TitleList.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/WMS.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/Calendar.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/Print.js" -->
    <!-- #include file="../JavaScript/Query.js" -->
    <!--#include file="JavaScript/WMS.js" -->
    <!-- #include file="../JavaScript/CheckForm.js" -->
    <!-- #include file="../JavaScript/PopupMenu.js" -->

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"> </script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>

    <script language="javascript" type="text/javascript">
    var TableName="impm1_Balance";
    function SelectedDivl(selectId,LiCount)
   {
        strHidCon1=1;
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
        document.getElementById('hid_val').value=selectId;
        if(selectId==1)
        {
         TableName="impm1_Balance";
         document.getElementById("divSearchBal").style.display="block"
         document.getElementById("divSearchMov").style.display="none"
         document.getElementById("divSearchInv").style.display="none"
         document.getElementById("divMiddle1").style.display="block"
        }
        else if(selectId==2)
        {
         TableName="Impm1_Movement";
         document.getElementById("divSearchBal").style.display="none"
         document.getElementById("divSearchMov").style.display="block"
         document.getElementById("divSearchInv").style.display="none"
         document.getElementById("divMiddle1").style.display="block"
        }
        else if(selectId==3)
        { 
         TableName="Impm1_Inventory1";
         document.getElementById("divSearchBal").style.display="none"
         document.getElementById("divSearchMov").style.display="none"
         document.getElementById("divSearchInv").style.display="block"
         document.getElementById("divMiddle1").style.display="block"
        }
        context=document.getElementById("hid_div");
        document.getElementById("divSource").innerHTML="";
        var arg="SetTabVal"+ParSeparator+document.getElementById('hid_val').value;
         <%= ClientScript.GetCallbackEventReference(Me,"arg","SetResult", "context")%>; 
   }
   
   function DetailClick()
   {
    context=document.getElementById("hid_div");
    document.getElementById('hid_val').value=4;
    var arg="SetTabVal"+ParSeparator+document.getElementById('hid_val').value;
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
function ExportExcelMul()//For mutile Tab to export excel 
{
    Loading();
    var obj =document.getElementById("drDimensionFlag");
     var intflag=obj.selectedIndex;
    var arg = "ServerExportEM"+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+GetQueryValue()+ParSeparator+MutiTab+ParSeparator+intflag;
    context=null;
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "ShowExcelFile", "context")%>;
}

  
function ListExportMul()
{
    Loading();
        var obj =document.getElementById("drDimensionFlag");
     var intflag=obj.selectedIndex+1;
    var arg = "ServerExportEM"+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+MutiTab+ParSeparator+intflag;
    context=null;
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "ShowExcelFile", "context")%>;
}
    </script>
</head>
<body onload="DivAutoSize(177);" onresize="DivAutoSize(177);">
    <form id="frmAirSeaQuery" runat="server">
    <div id="divTopNav" runat="server">
        <ul id="ulTopNav">
            <li>
                <asp:Label ID="a1" CssClass="f12e navNml navOn" runat="server" Width="120px" onclick="javascript:SelectedDivl(1,3);iniControl();"
                    Text="<%$ Resources:a1 %>"></asp:Label></li>
            <li>
                <asp:Label ID="a2" CssClass="f12c navNml noSep" runat="server" Width="120px" onclick="javascript:SelectedDivl(2,3);iniControl();"
                    Text="<%$ Resources:a2 %>"></asp:Label></li>
            <li>
                <asp:Label ID="a3" CssClass="f12c navNml noSep" runat="server" Width="120px" onclick="javascript:SelectedDivl(3,3);iniControl();"
                    Text="<%$ Resources:a3 %>"></asp:Label></li>
        </ul>
    </div>
    <div id="popupMenu" class="skin" runat="server" onclick="ClickItem(event)" onmousemove="HighlighItem(event)"
        onmouseout="LowlightItem(event)">
    </div>
    <div id="MsgBox" style="left: 26%; top: 171px">
        <div class="bar">
            <asp:Label ID="lblLoadTitleHint" runat="server" Text="<%$ Resources:Message, LoadTitleHint %>"></asp:Label>
        </div>
        <div class="content">
            <img alt="" src="../images/load.gif" style="text-align: center; vertical-align: middle" />&nbsp;
            &nbsp;<asp:Label ID="lblMessage" runat="server" Text="<%$ Resources:Message, LoadDataHint %>"></asp:Label>
        </div>
    </div>
    <div id="divMiddle1">
        <div id="divSearchBal" class="divSearch">
            <div class="divline">
                <asp:Label ID="lblCustomerCode" runat="server" Text="<%$ Resources:lblCustomerCode %>"
                    CssClass="Drlist" />
                <asp:DropDownList ID="drCustomerCode" runat="server" CssClass="Drlist" />
                &nbsp
                <div id="divCustomerName" style="display: inline">
                    <asp:TextBox ID="lblCustomerName" CssClass="txt" runat="server" ReadOnly="true" /></div>
            </div>
            <div class="divline">
                <asp:Label ID="lbProductCode" runat="server" Text="<%$ Resources:lbProductCode %>" />
                <div id="div_ProductCode" style="display: inline">
                    <asp:DropDownList ID="drProductCode" runat="server" CssClass="Drlist" />
                </div>
                <asp:Button ID="btnAddField" runat="server" CssClass="btnFnt" Width="60px" Text="Add"
                    UseSubmitBehavior="false" />
                <asp:HiddenField ID="hid_AddField" runat="server" />
                <asp:DropDownList ID="drProductCodeField" runat="server" Width="120px" />
                <asp:Button ID="btnRemove" runat="server" CssClass="btnFnt" Text="Remove" UseSubmitBehavior="false"
                    Width="60px" />
                <asp:Button ID="btnClearField" runat="server" CssClass="btnFnt" Text="Clear" UseSubmitBehavior="false"
                    Width="60px" />
                <asp:HiddenField ID="fldCustomerCode" runat="server" />
                <asp:HiddenField ID="fldLoginType" runat="server" />
            </div>
            <div class="divline">
                <asp:Label ID="lblRefNo" runat="server" Text="<%$ Resources:lblRefNo %>" />
                <div id="divRefNo" style="display: inline">
                </div>
                
                   <asp:TextBox ID="txtRefNo" CssClass="txt" runat="server" />
                
            </div>
            <div class="divline">
                <div class="fLeft">
                    <asp:Label ID="lbAsonDate" runat="server" Text="<%$ Resources:lbAsonDate %>" />
                    <asp:TextBox ID="txtAsonDate" runat="server" CssClass="TextBox" />
                    <asp:Button ID="btnAsonDate" runat="server" CssClass="Button" Text="..." Width="20px"
                        UseSubmitBehavior="False" />
                    <span class="spanspace"></span>
                    <asp:Button ID="btnSearchBal" runat="server" CssClass="Button" Text="Search" UseSubmitBehavior="false" />
                    &nbsp
                    <div id="divDetail" style="display: inline;">
                        <asp:Button ID="btnDetail" runat="server" CssClass="Button" Text="Details" UseSubmitBehavior="false" />
                    </div>
                    <div id="divSummary" style="display: none;">
                        <asp:Button ID="btnSummary" runat="server" CssClass="btnFnt" Width="60px" Text="Summary"
                            UseSubmitBehavior="false" />
                    </div>
                    <div id="divColumn" style="display: none">
                        <asp:Button ID="btnMultiGridColumnSet" runat="server" CssClass="btnFnt" Text="Custom"
                            UseSubmitBehavior="false" /></div>
                </div>
            </div>
        </div>
        <div id="divSearchMov" style="display: none;" class="divSearch">
            <div class="divline">
                <asp:Label ID="lblCustomerCode1" runat="server" Text="<%$ Resources:lblCustomerCode %>" />
                <asp:DropDownList ID="drCustomerCode1" runat="server" CssClass="Drlist" />
                &nbsp
                <div id="divCustomerName1" style="display: inline">
                    <asp:TextBox ID="txtCustomerName1" CssClass="txt" runat="server" ReadOnly="true" /></div>
            </div>
            <div class="divline">
                <asp:Label ID="lbProductCode1" runat="server" Text="<%$ Resources:lbProductCode %>" />
                <div id="div_ProductCode1" style="display: inline">
                    <asp:DropDownList ID="drProductCode1" runat="server" CssClass="Drlist" />
                </div>
                <asp:Button ID="btnAddField1" runat="server" CssClass="btnFnt" Width="60px" Text="Add"
                    UseSubmitBehavior="false" />
                <asp:HiddenField ID="hid_AddField1" runat="server" />
                <asp:DropDownList ID="drProductCodeField1" runat="server" Width="120px" />
                <asp:Button ID="btnRemove1" runat="server" CssClass="btnFnt" Text="Remove" UseSubmitBehavior="false"
                    Width="60px" />
                <asp:Button ID="btnClearField1" runat="server" CssClass="btnFnt" Text="Clear" UseSubmitBehavior="false"
                    Width="60px" />
            </div>
            <div class="divline">
                <asp:Label ID="lblRefNo1" runat="server" Text="<%$ Resources:lblRefNo %>" />
                <div id="divRefNo1" style="display: inline">
                   <asp:TextBox ID="txtRefNo1" CssClass="txt" runat="server" />
                </div>
                
            </div>
            <div class="divline">
                <div class="fLeft">
                    <asp:Label ID="lbMovenMentDate" runat="server" Text="<%$ Resources:lbMovenMentDate %>" />
                    <asp:TextBox ID="txtMovenMentDateFrom" runat="server" CssClass="TextBox txtDate2" />
                    <asp:Button ID="btnMovenMentDateFrom" runat="server" CssClass="Button" Text="..."
                        Width="20px" UseSubmitBehavior="False" />&nbsp&nbsp&nbsp To&nbsp&nbsp
                    <asp:TextBox ID="txtMovenMentDateTo" runat="server" CssClass="TextBox txtDate2"></asp:TextBox>
                    <asp:Button ID="btnMovenMentDateTo" runat="server" CssClass="Button" Text="..." UseSubmitBehavior="False"
                        Width="20px" />
                    <asp:Button ID="btnSearchMov" runat="server" CssClass="btnFnt" Text="Search" UseSubmitBehavior="false" />
                    <asp:Button ID="btnMultiGridColumnSet1" runat="server" CssClass="btnFnt" Text="Custom"
                        UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
        <div id="divSearchInv" style="display: none;" class="divSearch">
            <div class="divWMS">
                <asp:Label ID="lblCustomerCode2" CssClass="Label lbl2" runat="server" Text="<%$ Resources:lblCustomerCode %>" />
                <asp:DropDownList ID="drCustomerCode2" runat="server" CssClass="Drlist" />
                &nbsp
                <div id="divCustomerName2" style="display: inline">
                    <asp:TextBox ID="txtCustomerName2" CssClass="txt2" runat="server" ReadOnly="true" /></div>
                &nbsp 
                <asp:Label ID="lblBrandName" CssClass="Label lbl3" runat="server" Text="<%$ Resources:lblBrandName %>" />
                <asp:TextBox ID="txtBrandName" runat="server" CssClass="txt2" />
            </div>
            <div class="divWMS">
                <asp:Label ID="lblProductCode2" CssClass="Label lbl2" runat="server" Text="<%$ Resources:lblProductCode %>" />
                <div id="div_ProductCode2" style="display: inline">
                    <asp:DropDownList ID="drProductCode2" runat="server" CssClass="Drlist" />
                </div>
                &nbsp 
                <div id="div_ProductName2" style="display: inline">
                    <asp:TextBox ID="txtProductCode2" runat="server" CssClass="txt2" ReadOnly="true" />
                </div>
                
                &nbsp 
                <asp:Label ID="lblDateFrom" CssClass="Label lbl3" runat="server" Text="<%$ Resources:lblDateFrom %>" />
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="TextBox txtDate0"></asp:TextBox>
                <asp:Button ID="btnDateFrom" runat="server" CssClass="Button" Text="..." UseSubmitBehavior="False"
                    Width="15px" /> To 
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="TextBox txtDate0"></asp:TextBox>
                <asp:Button ID="btnDateTo" runat="server" CssClass="Button" Text="..." UseSubmitBehavior="False"
                    Width="15px" />
            </div>
            <!--
            <div class="divline">
                <asp:Label ID="lblRefNo2" runat="server" Text="<%$ Resources:lblRefNo %>" />
                <div id="divRefNo2" style="display: inline">
                   <asp:TextBox ID="txtRefNo2" CssClass="txt" runat="server" />
                </div>
                !-->
            </div>
            <div class="divWMS">
                <asp:Label ID="lblWarehouseCode" CssClass="Label lbl2" runat="server" Text="<%$ Resources:lblWarehouseCode %>" />
                <asp:DropDownList ID="drWarehouseCode2" runat="server" CssClass="Drlist" />
                &nbsp
                <div id="divWarehouseCode2" style="display: inline">
                    <asp:TextBox ID="txtWarehouseName2" runat="server" CssClass="txt2" ReadOnly="true" />
                </div>
                &nbsp
                <asp:Label ID="lblDimensionFlag" CssClass="Label lbl1" runat="server" Text="<%$ Resources:lblDimensionFlag %>" />
                &nbsp
                <asp:DropDownList ID="drDimensionFlag" runat="server" CssClass="DropList" />
                &nbsp
                <asp:Button ID="btnSearchInv" runat="server" CssClass="Button" Text="Search" UseSubmitBehavior="false" />
                <%--<asp:Button ID="btnMultiGridColumnSet2" runat="server" CssClass="btnFnt" Text="Custom"
                    UseSubmitBehavior="false" />--%>
            </div>
        </div>
        
        <div id="divSource" style="height: 500px;float:left;" >
            <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvwSource_RowDataBound"
                EnableViewState="False">
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
                <asp:Label ID="lblPabe" runat="server" Text="Page" />
                <asp:TextBox ID="txtPage" runat="server" CssClass="txInput"></asp:TextBox>
                <asp:LinkButton ID="lbtnGoTo" runat="server" Text="Go"></asp:LinkButton>
                <asp:LinkButton ID="lbtnNext" runat="server" Text="Next"></asp:LinkButton>
                <asp:LinkButton ID="lbtnLast" runat="server" Text="Last"></asp:LinkButton>
            </div>
            <div class="fRight">
                <%--<asp:Button ID="btnToExcel" runat="server" CssClass="Button" Text="Export Excel"
                    Width="77px" UseSubmitBehavior="False" />--%>
            </div>
        </div>
    </div>
    <div id="hid_div">
        <asp:HiddenField ID="hid_val" runat="server" Value="1" />
    </div>
    <asp:HiddenField ID="hid_ProductCode" runat="server" />
    <div id="div_ProductCodepass">
        <asp:HiddenField ID="hid_ProductCodePass" runat="server" />
    </div>
    <asp:HiddenField ID="hidDateFrom" runat="server" />
    <asp:HiddenField ID="hidDateTo" runat="server" />
    <div id="divDimensionFlag">
        <asp:HiddenField ID="hidDimensionFlag" runat="server" Value="Packing" />
    </div>
    </form>
</body>
</html>

 <script type="text/javascript" language="javascript">
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
 
