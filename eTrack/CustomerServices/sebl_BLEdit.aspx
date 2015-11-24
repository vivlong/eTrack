<%@ Page Language="VB" AutoEventWireup="true" CodeFile="sebl_BLEdit.aspx.vb" Inherits="sebl_BLEdit" %>

<%@ Register Src="../UserControl/DateTimeSelect.ascx" TagName="DateTimeSelect" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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
    <link href="App_Themes/sebl_BLEdit.css" rel="Stylesheet" type="text/css" />
    <link href="../UserControl/datepicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../JavaScript/jquery-1.11.2.min.js"></script><script type="text/javascript" src="../App_Themes/layer/layer.js"></script>
    <script type="text/javascript" src="../JavaScript/jquery.maskedinput.js"></script>
    <script language="javascript" type="text/javascript" src="../UserControl/datepicker/WdatePicker.js"></script>
    <!-- #include file="../JavaScript/JsConst.js" -->
    <!-- #include file="../JavaScript/BaseEdit.js" -->
    <!-- #include file="JavaScript/sebl_BLEdit.js" -->
    <!-- #include file="JavaScript/TableOperate.js" -->
    <!--#include file="../JavaScript/Print.js" -->
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Format.js"> </script>
    <script type="text/javascript" language="javascript">
        function ChgUrgAttribute(aFlag) {
            if (aFlag == 1) {
                document.getElementById("txtUrgentRemark").value = "";
                document.getElementById("txtUrgentRemark").readOnly = true;
            }
            else if (aFlag == 2) {
                document.getElementById("txtUrgentRemark").readOnly = false;
            }
        }
        function on_page_loaded() {
            try {
                if (!window.onbeforeunload)
                    window.onbeforeunload = function() { };
            } catch (e) { }
        }
        function SelectCell(TrxNo,LineItemNo,ItemNo,DataStr1,DataStr2) {
            if (TrxNo!= "") {  
             document.getElementById("HidTrxNo").value = TrxNo;
             document.getElementById("HidLineItemNo").value = LineItemNo;
             document.getElementById("HidMarkNo").value = ItemNo;
             document.getElementById("txtDescription").value = DataStr1;
             document.getElementById("txtMark").value = DataStr2;
        }
         
      }
//             function SelectRow(TrxNo,LineItemNo) {
//            if (TrxNo!= "") {  
//             document.getElementById("HidTrxNo").value = TrxNo;
//             document.getElementById("HidLineItemNo").value = LineItemNo;
//            // document.getElementById("HidMarkNo").value = ItemNo;
//            context=0;
//             var arg = "LoadDiv2"+ParSeparator+GetDiv2Detail();
//        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveReturn", "context")%>;
//           
//            }
//         
//      }
function InputEnter(e,obj,NextObj)
{
 var key =window.event ? e.keyCode : e.which;
     if((key==13)||(key==0x28)) 
     {
       limit20Row(obj,NextObj);
      
                }
                }

function limit20Row(obj,NextObj)
{
if(obj!=null) 
        {
          if(!obj.disabled && obj.style.display!="none")
          {
          var s=obj.value;
          var reg = new RegExp("\r", "g");
          if(s.indexOf("\r")>=0)
          {
              var len =s.match(reg).length;
              if (len>=19)
              {
              var  s  = obj.value+"\r";
              var  a  = s.split("\r") ;//s.match(/[^\r]+(\r|$)/g);
              var  result  =  "";
              if(a)  
              {
              for(var  i=0;  i <20;  i++)
              {
              if(i>=19)
              {
              result  +=  a[i].toString().Trim("\r");
             FocusControl(event,null,NextObj);
              }
              else{
              result  +=  a[i];}
              } 
              }
              obj.value=result;
              }
              }
              }
             
                return false;
                }
               
}
 function SaveDetail(strTitle,intFlag)
{

 if ($("#divMiddle1").css("display")=="block")
 {
  if (!StrToBool(SavePrompt) || window.confirm(ConfirmSave.replace("{0}",strTitle))) 
    { 
        if (!CanSave()) 
        {
            return;
        }
        context=intFlag;
        BeforeSave();
        var arg = "SaveData"+ParSeparator+GetDetail();
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveReturn", "context")%>;
    }
    else {
            if(intFlag) {NewDetail(1);}
            else {window.close();}
         }
  }
  else if(document.getElementById("divMiddle2").style.display=="block")
  {
    if(  document.getElementById("divMiddle1").style.display=="none")
    {
           // BeforeSave();
            context = document.getElementById("divSource");
            var arg = "SaveDiv2Data"+ParSeparator+GetDiv2Detail();
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveReturnDiv2", "context")%>;
            return;
    }
  }
}

function SaveReturnDiv2(result,context) 
{ 
    AfterSave();
    var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk) {
                context.innerHTML = strResult[1];
          
             document.getElementById("HidLineItemNo").value = "";
                       document.getElementById("txtDescription").value = "";
             document.getElementById("txtMark").value = "";
               document.getElementById("txtContainerNo").value=""
     document.getElementById("txtSealNo").value=""
document.getElementById("drpContainerType").selectedIndex=0;
  document.getElementById("txtVolume").value=""
  document.getElementById("txtUomCode").value=""
  document.getElementById("txtPcs").value=""
  document.getElementById("txtGrossWeight").value=""
            }
            else if (strResult[1]!=""){
            }
}
function getValue(strTrxNo,strLineItemNo,strDescription,strMarkNo,strContainerNo,strSealNo,strContainerType,strVolume,strUomCode,strPcs,strGrossWeight)
{
  document.getElementById("HidTrxNo").value = strTrxNo;
             document.getElementById("HidLineItemNo").value = strLineItemNo;
               document.getElementById("txtDescription").value = strDescription.replace(new RegExp(ColSeparator,"g"),"\r\n");
             document.getElementById("txtMark").value = strMarkNo.replace(new RegExp(ColSeparator,"g"),"\r\n");
  document.getElementById("txtContainerNo").value=strContainerNo
  document.getElementById("txtSealNo").value=strSealNo
    document.getElementById("drpContainerType").value=strContainerType
 // document.getElementById("drpContainerType").value=strContainerType
  document.getElementById("txtVolume").value=strVolume
  document.getElementById("txtUomCode").value=strUomCode
  document.getElementById("txtPcs").value=strPcs
  document.getElementById("txtGrossWeight").value=strGrossWeight

              // document.getElementById("btnNew2").disabled=false ;
}
function SelectedDiv(selectId,LiCount)
{
    var DivName;
    var LiName;
    var Id;
    Id= document.getElementById("HidTrxNo").value;
    if (Id=="")
    {
   
    if(selectId!=1)
    {
  if(!showBtn(0) )
  {
   return;
  }
    } }
    
    for(var i=1;i<=LiCount;i++){
        if (selectId==i){
                DivName="divMiddle"+selectId.toString();
                document.getElementById(DivName).style.display="block";
                LiName="a"+selectId.toString();
                document.getElementById(LiName).className="f12e navNml navOn";
        }
        else{
                DivName="divMiddle"+i.toString();
                document.getElementById(DivName).style.display="none";
                LiName="a"+i.toString();
                document.getElementById(LiName).className="f12c navNml noSep";
        }
    }
    if (selectId==1)
    {
       document.getElementById("btnNew").status=false; 
           document.getElementById("btnSave").status=true; 
            document.getElementById("btnNew").style.display="none";
    }
    else if (selectId==2)
    {
       document.getElementById("btnNew").status=true; 
           document.getElementById("btnSave").status=true; 
                 document.getElementById("btnNew").style.display="";
    }
}
 function showBtn(intflag) {
          
                        if (window.confirm("Do you want to save New Booking?")) {
                            var flagAuto = true;
                            flagAuto =  SaveDetail("B/L Entry",intflag);
                            if (flagAuto == true) {
                             TabNo = intflag; 
                             return true;
                            }
                   
                        }
                       return false; 
               
        }
function  ClearDiv2Detail()
      {
        document.getElementById("HidLineItemNo").value = "";
               document.getElementById("txtDescription").value = "";
             document.getElementById("txtMark").value = "";
               document.getElementById("txtContainerNo").value=""
  document.getElementById("txtSealNo").value=""
  //document.getElementById("txtContainerType").value=""
  document.getElementById("drpContainerType").selectedIndex=0;
  document.getElementById("txtVolume").value=""
  document.getElementById("txtUomCode").value=""
  document.getElementById("txtPcs").value=""
  document.getElementById("txtGrossWeight").value=""
if(m_oddFlag==1) {
            m_PreRow.style.backgroundColor=colorFirst;
        }
        else if(m_oddFlag==0) {
            m_PreRow.style.backgroundColor=colorSecond;
        }
          m_oddFlag=null;
          m_PreRow=null;
                   // document.getElementById("btnNew2").status=false; 
      }
      function DeleteDiv2Detail(TrxNo,lineItemNo)
{
            if (window.confirm("Are you sure to delete this record?")) 
            {
                context = document.getElementById("divSource");
                var arg = "DeleteDiv2Detail"+ParSeparator+TrxNo.toString()+ParSeparator+lineItemNo.toString();
                <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveReturnDiv2", "context")%>;
            }
}
var m_PreRow;
var m_oddFlag;
function Sebl2RowSelected(tr,oddFlag)
{
    tr.style.backgroundColor="#AACCFF";
    if(m_PreRow!=null&&m_PreRow!=tr)
    {
        if(m_oddFlag==1) {
            m_PreRow.style.backgroundColor=colorFirst;
        }
        else {
            m_PreRow.style.backgroundColor=colorSecond;
        }
    }
    m_PreRow=tr;
    m_oddFlag=oddFlag;
}
function Sebl2RowMouseOut(tr,oddFlag,LineItemNo)
{
    var SelectedItem;
    SelectedItem=document.getElementById("hidLineItemNo").value;
    if (SelectedItem==LineItemNo) 
    {
        tr.style.backgroundColor="#AACCFF";
    }
    else 
    {
        if(oddFlag==1) {
            tr.style.backgroundColor=colorFirst;
        }
        else {
            tr.style.backgroundColor=colorSecond;
        }
    }
}
    </script>
</head>
<body onload="on_page_loaded()">
    <form id="frmsebl_BLEdit" runat="server">
    <div id="divTopNav">
        <ul id="ulTopNav">
            <li>
                <asp:Label ID="a1" runat="server" CssClass="f12e navNml navOn" onclick="SelectedDiv(1, 2);"
                    Text="B/L Info"></asp:Label></li>
            <li>
                <asp:Label ID="a2" CssClass="f12c navNml noSep" runat="server" onclick="SelectedDiv(2, 2);"
                    Text="Cargo Info" /></li>
        </ul>
    </div>
    <div id="SaveHint" runat="server" class="Hint" style="left: 0px; top: 10px">
        <asp:Label ID="HintMessage" runat="server" Text="<%$ Resources:Message, SaveDataHint %>" />
    </div>
    <div id="divMiddle1" class="divBorder">
        <div id="divMiddle11">
            <div class="divline">
                <asp:Label ID="lblBookingNo" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblBookingNo %>" />
                <asp:TextBox ID="txtBookingNo" runat="server" CssClass="TextBox txtNo" MaxLength="20" />
                <asp:Label ID="lblBlNo" CssClass="Label lblRight1" runat="server" Text="<%$ Resources:lblBlNo %>" />
                <asp:TextBox ID="txtBlNo" CssClass="TextBox txtNo2" runat="server" MaxLength="20" />
            </div>
            <div class="divline">
                <asp:Label ID="lblShipmentType" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblShipmentType %>" />
                <asp:DropDownList ID="drShipmentType" runat="server" CssClass=" DropList txtNo" Width="121px">
                    <asp:ListItem Value="H">House</asp:ListItem>
                    <asp:ListItem Value="D">Direct</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lblOBlNo" CssClass="Label lblRight1" runat="server" Text="<%$ Resources:lblOBlNo %>" />
                <asp:TextBox ID="txtOBlNo" CssClass="TextBox txtNo2" runat="server" MaxLength="20" />
            </div>
            <div class="divline">
                <asp:Label ID="lblCustomerCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblCustomerName %>" />
                <asp:TextBox ID="txtCustomerName" runat="server" CssClass="TextBox txt" MaxLength="45" />
                <asp:Button ID="btnCustomerCode" runat="server" CssClass="Button bntDate" Text="..."
                    UseSubmitBehavior="False" />
                <asp:HiddenField ID="hidCustomerCode" runat="server" />
            </div>
            <div id="divline" runat="server" class="divline">
                <asp:Label ID="lblShipperCode" runat="server" Text="<%$ Resources:lblShipperName %>"
                    CssClass="Label lbl" />
                <asp:TextBox ID="txtShipperName" runat="server" CssClass="TextBox txt" MaxLength="50" />
            </div>
            <div class="divline">
                <asp:Label ID="lblShipperAddress" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblShipperAddress %>" />
                <asp:TextBox ID="txtShipperAddress1" runat="server" CssClass="TextBox txt" MaxLength="45" />
            </div>
            <div class="divline">
                <span class="Label span1">&nbsp</span>
                <asp:TextBox ID="txtShipperAddress2" runat="server" CssClass="TextBox txt" MaxLength="45" />
            </div>
            <div class="divline">
                <span class="Label span1">&nbsp</span>
                <asp:TextBox ID="txtShipperAddress3" runat="server" CssClass="TextBox txt" MaxLength="45" />
            </div>
            <div class="divline">
                <span class="Label span1">&nbsp</span>
                <asp:TextBox ID="txtShipperAddress4" runat="server" CssClass="TextBox txt" MaxLength="45" />
            </div>
            <div id="divline" class="divline">
                <asp:Label ID="lblConsignessCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblConsignessName %>" />
                <asp:TextBox ID="txtConsignessName" runat="server" CssClass="TextBox txt" MaxLength="50" />
            </div>
            <div class="divline">
                <div class="divline">
                    <asp:Label ID="lblConsigneeAddress" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblConsigneeAddress %>" />
                    <asp:TextBox ID="txtConsigneeAddress1" runat="server" CssClass="TextBox txt" MaxLength="45" />
                </div>
                <div class="divline">
                    <span class="Label span1">&nbsp</span>
                    <asp:TextBox ID="txtConsigneeAddress2" runat="server" CssClass="TextBox txt" MaxLength="45" />
                </div>
                <div class="divline">
                    <span class="Label span1">&nbsp</span>
                    <asp:TextBox ID="txtConsigneeAddress3" runat="server" CssClass="TextBox txt" MaxLength="45" />
                </div>
                <div class="divline">
                    <span class="Label span1">&nbsp</span>
                    <asp:TextBox ID="txtConsigneeAddress4" runat="server" CssClass="TextBox txt" MaxLength="45" />
                </div>
            </div>
            <div class="divline">
                <asp:Label ID="lblNotifyCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblNotifyName %>" />
                <asp:TextBox ID="txtNotifyName" runat="server" CssClass="TextBox txt" MaxLength="50" />
            </div>
            <div id="divline">
                <div class="divline">
                    <asp:Label ID="lblNotifyAddress" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblConsigneeAddress %>" />
                    <asp:TextBox ID="txtNotifyAddress1" runat="server" CssClass="TextBox txt" MaxLength="45" />
                </div>
                <div class="divline">
                    <span class="Label span1">&nbsp</span>
                    <asp:TextBox ID="txtNotifyAddress2" runat="server" CssClass="TextBox txt" MaxLength="45" />
                </div>
                <div class="divline">
                    <span class="Label span1">&nbsp</span>
                    <asp:TextBox ID="txtNotifyAddress3" runat="server" CssClass="TextBox txt" MaxLength="45" />
                </div>
                <div class="divline">
                    <span class="Label span1">&nbsp</span>
                    <asp:TextBox ID="txtNotifyAddress4" runat="server" CssClass="TextBox txt" MaxLength="45" />
                </div>
            </div>
            <div class="divline">
                <asp:Label ID="lblDeliveryAgentCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblDeliveryAgentName %>" />
                <asp:TextBox ID="txtDeliveryAgentName" runat="server" CssClass="TextBox txt" MaxLength="50" />
            </div>
            <div class="divline">
                <asp:Label ID="lblDeliveryAgentAddress" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblDeliveryAgentAddress %>" />
                <asp:TextBox ID="txtDeliveryAgentAddress1" runat="server" CssClass="TextBox txt"
                    MaxLength="45" />
            </div>
            <div class="divline">
                <span class="Label span1">&nbsp</span>
                <asp:TextBox ID="txtDeliveryAgentAddress2" runat="server" CssClass="TextBox txt"
                    MaxLength="45" />
            </div>
            <div class="divline">
                <span class="Label span1">&nbsp</span>
                <asp:TextBox ID="txtDeliveryAgentAddress3" runat="server" CssClass="TextBox txt"
                    MaxLength="45" />
            </div>
            <div class="divline">
                <span class="Label span1">&nbsp</span>
                <asp:TextBox ID="txtDeliveryAgentAddress4" runat="server" CssClass="TextBox txt"
                    MaxLength="45" />
            </div>
        </div>
        <div id="divMiddle12">
            <div class="divline">
                <asp:Label ID="lblCargoType" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblCargoType %>" />
                <asp:DropDownList ID="drCargoType" runat="server" CssClass="txtDate">
                    <asp:ListItem Value="CFS">CFS</asp:ListItem>
                    <asp:ListItem Value="CY">CY</asp:ListItem>
                    <asp:ListItem Value="FCL">FCL</asp:ListItem>
                    <asp:ListItem Value="SOC">SOC</asp:ListItem>
                    <asp:ListItem Value="COC">COC</asp:ListItem>
                    <asp:ListItem Value="CV">RORO</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
                <asp:DropDownList ID="drDestCargoType" runat="server" CssClass="txtDate">
                    <asp:ListItem Value="CFS">CFS</asp:ListItem>
                    <asp:ListItem Value="CY">CY</asp:ListItem>
                    <asp:ListItem Value="FCL">FCL</asp:ListItem>
                    <asp:ListItem Value="SOC">SOC</asp:ListItem>
                    <asp:ListItem Value="COC">COC</asp:ListItem>
                    <asp:ListItem Value="CV">RORO</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="divline">
                <asp:Label ID="lblCargoClass" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblCargoClass %>" />
                <asp:TextBox ID="txtCargoClass" runat="server" CssClass="TextBox txtDate" MaxLength="50" />
            </div>
            <div class="divline">
                <asp:Label ID="lblCommodity" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblCommodity %>" />
                <asp:TextBox ID="txtCommodityCode" runat="server" CssClass="TextBox txtCode" MaxLength="10" />
                <asp:TextBox ID="txtCommodityDescription" runat="server" CssClass="TextBox txtName"
                    MaxLength="50" />
                <asp:Button ID="btnCommodity" runat="server" CssClass="Button bntDate" Text="..."
                    UseSubmitBehavior="False" />
            </div>
            <div class="divline">
                <asp:Label ID="lblOrigin" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblOrigin%>" />
                <asp:TextBox ID="txtOriginCode" runat="server" CssClass="TextBox txtCode" MaxLength="3" />
                <asp:TextBox ID="txtOriginName" runat="server" CssClass="TextBox txtName" MaxLength="50" />
                <asp:Button ID="btnOrigin" runat="server" CssClass="Button bntDate" Text="..." UseSubmitBehavior="False" />
            </div>
            <div class="divline">
                <asp:Label ID="lblDest" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblDest %>" />
                <asp:TextBox ID="txtDestCode" runat="server" CssClass="TextBox txtCode" MaxLength="3" />
                <asp:TextBox ID="txtDestName" runat="server" CssClass="TextBox txtName" MaxLength="50" />
                <asp:Button ID="btnDest" runat="server" CssClass="Button bntDate" Text="..." UseSubmitBehavior="False" />
            </div>
            <div class="divline">
                <asp:Label ID="lblPlaceOfReceipt" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblPlaceOfReceipt %>" />
                <asp:TextBox ID="txtPlaceOfReceipt" runat="server" CssClass="TextBox txt1" MaxLength="5" />
            </div>
            <div class="divline">
                <asp:Label ID="lblPortOfLoading" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblPortOfLoading %>" />
                <asp:TextBox ID="txtPortOfLoadingName" runat="server" CssClass="TextBox txt1" MaxLength="45" />
            </div>
            <div class="divline">
                <asp:Label ID="lblEtdDate" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblEtdDate %>" />
                <%--<asp:TextBox ID="txtEtdDate" CssClass="TextBox txtDate" runat="server" MaxLength="10" />
                <asp:Button ID="btnEtdDate" runat="server" CssClass="Button bntDate" Text="..." UseSubmitBehavior="False" />--%>
                <uc1:DateTimeSelect ID="ETDSelect" runat="server" />
                dd/mm/yyyy
            </div>
            <div class="divline">
                <asp:Label ID="lblPortOfDischarge" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblPortOfDischarge %>" />
                <asp:TextBox ID="txtPortOfDischargeCode" runat="server" CssClass="TextBox txtCode"
                    MaxLength="5" />
                <asp:TextBox ID="txtPortOfDischargeName" runat="server" CssClass="TextBox txtName"
                    MaxLength="45" />
                <asp:Button ID="btnPortOfDischarge" runat="server" CssClass="Button bntDate" Text="..."
                    UseSubmitBehavior="False" />
            </div>
            <div class="divline">
                <asp:Label ID="lblEtaDate" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblEtaDate %>" />
                <%--<asp:TextBox ID="txtEtaDate" runat="server" CssClass="TextBox txtDate" MaxLength="10" />
                <asp:Button ID="btnEtaDate" runat="server" CssClass="Button bntDate" Text="..." UseSubmitBehavior="False" />--%>
                <uc1:DateTimeSelect ID="ETASelect" runat="server" />
                dd/mm/yyyy
            </div>
            <div class="divline">
                <asp:Label ID="lblPlaceOfDelivery" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblPlaceOfDelivery %>" />
                <asp:TextBox ID="txtPlaceOfDelivery" runat="server" CssClass="TextBox txt1" MaxLength="45" />
            </div>
            <div class="divline">
                <asp:Label ID="lblVessel" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblVessel %>" />
                <asp:TextBox ID="txtVesselName" runat="server" CssClass="TextBox txtVessel" MaxLength="50" />
                <asp:Button ID="btnVessel" runat="server" CssClass="Button bntDate" Text="..." UseSubmitBehavior="False" />
                <asp:TextBox ID="txtVoyageNo" runat="server" CssClass="TextBox txtDate" MaxLength="12" />
            </div>
            <div class="divline">
                <asp:Label ID="lblShippingLine" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblShippingLine %>" />
                <asp:TextBox ID="txtShippingLineCode" runat="server" CssClass="TextBox txtCode" MaxLength="12" />
                <asp:TextBox ID="txtShippingDescription" runat="server" CssClass="TextBox txtName"
                    MaxLength="50" />
                <asp:Button ID="btnShippingDescription" runat="server" CssClass="Button bntDate"
                    Text="..." UseSubmitBehavior="False" />
            </div>
            <div class="divline">
                <asp:Label ID="lblFreight" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblFreight %>" />
                <asp:DropDownList ID="drFreight" runat="server" CssClass="txtDate">
                    <asp:ListItem Value="P">Prepaid</asp:ListItem>
                    <asp:ListItem Value="C">Collect</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="divline">
                <asp:Label ID="lblBlSurrenderFlag" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblBlSurrenderFlag %>" />
                <asp:DropDownList ID="drBlSurrenderFlag" runat="server">
                    <asp:ListItem Value="N">N</asp:ListItem>
                    <asp:ListItem Value="Y">Y</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lblNoOfOriginBl" runat="server" CssClass="Label lblRight2" Text="<%$ Resources:lblNoOfOriginBl %>" />
                <asp:TextBox ID="txtNoOfOriginBl" runat="server" CssClass="TextBox txtDate" MaxLength="1" />
            </div>
            <div class="divline">
                <asp:Label ID="lblBlIssuePlace" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblBlIssuePlace %>" />
                <asp:TextBox ID="txtBlIssuePlace" CssClass="TextBox txt1" runat="server" MaxLength="20" />
            </div>
            <div class="divline">
                <asp:Label ID="lblBlIssueDate" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblBlIssueDate %>" />
                <%--<asp:TextBox ID="txtBlIssueDate" CssClass="TextBox txtDate" runat="server" MaxLength="20" />
                <asp:Button ID="btnBlIssueDate" runat="server" CssClass="Button bntDate" Text="..."
                    UseSubmitBehavior="False" />--%>
                <uc1:DateTimeSelect ID="BlIssueSelect" runat="server" />
                dd/mm/yyyy</div>
            <div class="divline">
                <asp:Label ID="lblLadenDate" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblLadenDate %>" />
                <%--<asp:TextBox ID="txtLadenDate" CssClass="TextBox txtDate" runat="server" MaxLength="20" />
                <asp:Button ID="btnLadenDate" runat="server" CssClass="Button bntDate" Text="..."
                    UseSubmitBehavior="False" />--%>
                <uc1:DateTimeSelect ID="LadenSelect" runat="server" />
                dd/mm/yyyy</div>
            <div class="divline">
                <asp:Label ID="lblIssueBy" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblIssueBy %>" />
                <asp:TextBox ID="txtIssueBy" CssClass="TextBox txt1" runat="server" MaxLength="20" />
            </div>
            <div class="divline">
                <asp:Label ID="lblTotalPcsInWord" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblTotalPcsInWord %>" />
                <asp:TextBox ID="txtTotalPcsInWord" CssClass="TextBox txt1" runat="server" MaxLength="20" />
            </div>
            <div class="divline">
                <asp:Label ID="lblPrepaidAt" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblPrepaidAt %>" />
                <asp:TextBox ID="txtPrepaidAt" CssClass="TextBox txtDate" runat="server" MaxLength="20" />
                <asp:Label ID="lblPayableAt" CssClass="Label lblRight3" runat="server" Text="<%$ Resources:lblPayableAt %>" />
                <asp:TextBox ID="txtPayableAt" CssClass="TextBox txtNo1" runat="server" MaxLength="20" />
            </div>
            <div class="divline">
                <asp:Label ID="lblJobNo" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblJobNo %>" />
                <asp:TextBox ID="txtJobNo" CssClass="TextBox txtDate" runat="server" MaxLength="20" />
                <asp:Label ID="lblCreateBy" CssClass="Label lblRight3" runat="server" Text="<%$ Resources:lblCreateBy %>" />
                <asp:TextBox ID="txtCreateBy" CssClass="TextBox txtNo1" runat="server" MaxLength="20" />
            </div>
            <div class="divline">
                <asp:Label ID="lblCeateDate" CssClass="Label lbl" runat="server" Text="<%$ Resources:lblCeateDate %>" />
                <%--<asp:TextBox ID="txtCeateDate" CssClass="TextBox txtDate" runat="server" MaxLength="10" />
                <asp:Button ID="btnCeateDate" runat="server" CssClass="Button bntDate" Text="..."
                    UseSubmitBehavior="False" />--%>
                    <uc1:DateTimeSelect ID="CeateDateSelect" runat="server" />
                dd/mm/yyyy
            </div>
        </div>
    </div>
    <div id="divMiddle2" style="display: none;">
        <div id="divSource" style="height: 350px; display: block;" runat="server">
            <asp:GridView ID="gvwSource" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                OnRowDataBound="gvwSource_RowDataBound" CssClass="GvwView" Width="900px">
                <HeaderStyle CssClass="Header" />
                <FooterStyle CssClass="Footer" />
                <RowStyle CssClass="Row" />
                <SelectedRowStyle CssClass="SelectRow" />
                <PagerStyle CssClass="Pager" />
                <AlternatingRowStyle CssClass="Alternating" />
            </asp:GridView>
        </div>
        <div id="divMiddle22">
            <div id="divMiddleLeft" style="float: left;">
                <div class="divline divlineLeft">
                    <asp:Label ID="lblContainerNo" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblContainerNo %>" />
                    <asp:TextBox ID="txtContainerNo" runat="server" CssClass="TextBox txt" MaxLength="13"></asp:TextBox>
                </div>
                <div class="divline divlineLeft">
                    <asp:Label ID="lblContainerType" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblContainerType %>" />
                    <%-- <asp:TextBox ID="txtContainerType" runat="server" CssClass="TextBox txt" MaxLength="5"></asp:TextBox>--%>
                    <asp:DropDownList ID="drpContainerType" runat="server" CssClass="txt ">
                    </asp:DropDownList>
                </div>
                <div class="divline divlineLeft">
                    <asp:Label ID="lblUomCode" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblUomCode %>" />
                    <asp:TextBox ID="txtUomCode" runat="server" CssClass="TextBox txt" MaxLength="3"></asp:TextBox>
                </div>
                <div class="divline divlineLeftMu">
                    <div style="float: left">
                        <asp:Label ID="lblMark" runat="server" CssClass="label lbl" Text="<%$ Resources:lblMark %>" /></div>
                    <div style="float: left">
                        <asp:TextBox ID="txtMark" runat="server" CssClass="MarkWidth MarkHigth" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div id="divMiddleRight" style="float: left;">
                <div class="divline divlineRight">
                    <asp:Label ID="lblSealNo" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblSealNo %>" />
                    <asp:TextBox ID="txtSealNo" runat="server" CssClass="TextBox txt" MaxLength="30"></asp:TextBox>
                </div>
                <div class="divline divlineRight">
                    <asp:Label ID="lblVolume" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblVolume %>" />
                    <asp:TextBox ID="txtVolume" runat="server" CssClass="TextBox txt"></asp:TextBox>
                </div>
                <div class="divline divlineRight" style="float: left;">
                    <asp:Label ID="lblPcs" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblPcs %>" />
                    <asp:TextBox ID="txtPcs" runat="server" CssClass="TextBox txt1"></asp:TextBox>
                </div>
                <div class="divline divlineRight">
                    <asp:Label ID="lblGrossWeight" runat="server" CssClass="Label lbl" Text="<%$ Resources:lblGrossWeight %>" />
                    <asp:TextBox ID="txtGrossWeight" runat="server" CssClass="TextBox txt1"></asp:TextBox>
                </div>
                <div class="divline divlineRightMu">
                    <div style="float: left">
                        <asp:Label ID="lblGoodsDescription" runat="server" CssClass="label lbl" Text="<%$ Resources:lblGoodsDescription %>" /></div>
                    <div style="float: left">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="MarkWidth MarkHigth" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="HideModule" style="display: none">
        <asp:HiddenField ID="HidTrxNo" runat="server" />
        <asp:HiddenField ID="HidLineItemNo" runat="server" />
        <asp:HiddenField ID="HidMarkNo" runat="server" />
        <asp:HiddenField ID="hidReports" runat="server" />
        <asp:HiddenField ID="fldId" runat="server" />
    </div>
    <div id="divBottomNav" style="width: 100%;">
        <asp:Button ID="btnNew" runat="server" Text="<%$ Resources:btnNew %>" CssClass="Button"
            UseSubmitBehavior="False" />
        <asp:Button ID="btnPrint" runat="server" Text="<%$ Resources:btnPrint %>" CssClass="Button"
            UseSubmitBehavior="False" />
        <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:btnSave %>" CssClass="Button"
            UseSubmitBehavior="False" />
        <asp:Button ID="btnClose" runat="server" Text="<%$ Resources:btnClose %>" CssClass="Button"
            UseSubmitBehavior="False" />&nbsp
    </div>
    </form>
</body>
</html>
