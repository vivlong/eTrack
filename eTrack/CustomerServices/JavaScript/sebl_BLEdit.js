<script language ="javascript" type="text/javascript">
 function PrintDetail(intId, Reports) {
            var strUrl = "";
            intId=document.getElementById("fldId").value;
            var strReport = document.getElementById("hidReports").value;
            var arrReport = strReport.split(",");
            if (intId == "-1") { return false; }
            if (Reports == "") { alert("There are Not Reports in the Server."); return false; }
            if (arrReport.length!=1) {
                var strUrl = "../loading.aspx?tourl=CustomerServices/SelectReportSebl_BL.aspx?id=" + intId;
               var ret=WindowDialog(strUrl,400,300);
               if(ret!=null){}
            }
            else {
                strUrl = "../loading.aspx?tourl=CustomerServices/SelectReportSebl_BL.aspx?id=" + intId;
                var strUrl = "../loading.aspx?tourl=Print/crSebl_BL.aspx?Id=" + intId + "&Report=" + arrReport[0];
                window.open(strUrl);
            }
        }
var conName;
function CheckFieldVal(objCon,strFieldCode,strFieldName,strType,strTable)
{
        var strFieldVal=objCon.value;
        if(strFieldVal.Trim()==""){return false;}
        objCon.value=objCon.value.toUpperCase();
        switch(strType)
        {
            case "Commodity Code":
                context=document.getElementById("txtCommodityCode");
                conName=document.getElementById("txtCommodityDescription");
                 break;
            case "Origin Code":
                context=document.getElementById("txtOriginCode");
                conName=document.getElementById("txtOriginName");
                 break;
            case "Dest Code":
                context=document.getElementById("txtDestCode");
                conName=document.getElementById("txtDestName");
                 break;
            case "Port Of Discharge Code":
                context=document.getElementById("txtPortOfDischargeCode");
                conName=document.getElementById("txtPortOfDischargeName");
                 break;
            case "Shipping Line Code":
                context=document.getElementById("txtShippingLineCode");
                conName=document.getElementById("txtPortOfDischargeName");
                 break;
           default:
                context=objCon;
                 break;
         }
        var arg = "CheckFieldVal"+ParSeparator+strFieldCode+ParSeparator+strFieldName+ParSeparator+strFieldVal+ParSeparator+strType+ParSeparator+strTable;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetCheckValue", "context")%>;
}
    function SetCheckValue(result,context)
    {
        var strResult=result.split(ParSeparator);
        if (strResult[0]!=RtnOk) {
            alert(strResult[1]+strResult[2]);
            context.value="";
           }
        else{conName.value=strResult[1];}
    }
function CheckFieldValSp(objCon,strFieldCode,strFieldName,strType,strTable)
{
        var strFieldVal=objCon.value;
        if(strFieldVal.Trim()==""){return false;}
        objCon.value=objCon.value.toUpperCase();
        context=objCon;
        conName=objCon;
        var arg = "CheckFieldValSp"+ParSeparator+strFieldCode+ParSeparator+strFieldName+ParSeparator+strFieldVal+ParSeparator+strType+ParSeparator+strTable;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetCheckValueSp", "context")%>;
}
    function SetCheckValueSp(result,context)
    {
        var strResult=result.split(ParSeparator);
        if (strResult[0]!=RtnOk) {
            alert(strResult[1]+strResult[2]);
            context.value="";
           }
   
    }
//lzw100428
function selCN(txtCode,txtName,table,fields,where,showCode,showName)
{
    var ret=WindowDialog("../SysRef/TypeSort.aspx?table="+table+"&fields="+fields+"&where="+where+"&showCode="+showCode+"&showName="+showName,<%= SysMagic.SystemClass.InfoListSize.Width%>,<%=  SysMagic.SystemClass.InfoListSize.Height%>);
    if(ret!=null) 
    {
         var strRel=ret.split(ColSeparator);
         if (strRel.length==2) 
         { 
            var txt=strRel[1]=="&nbsp;"?" ":strRel[1];
            txt=txt.replace('amp;','');
            txtCode.value=strRel[0];
            txtName.value=txt;
         }
    }
}
//lzw100428
function selFix(txtCode,txtName,table,fields,where,showCode,showName)
{
    var ret=ModalDialog("../SysRef/TypeSort.aspx?table="+table+"&fields="+fields+"&where="+where+"&showCode="+showCode+"&showName="+showName,956.2 ,537.6);
    if(ret!=null) 
    {
         var strRel=ret.split(ColSeparator);
         if (strRel.length==2) 
         { 
            var txt=strRel[1]=="&nbsp;"?" ":strRel[1];
            txt=txt.replace('amp;','');
            txtCode.value=strRel[0];
            txtName.value=txt;
         }
    }
}



 
function ReturntheValue(result,context)
{
        AfterSave(); // after reply need enable the button.
        window.alert(result);
        window.close(); 
} 

function CanConfirmSave()
{
    return true;
}

function GetDetail()
{
    var strDetail="";
    strDetail=document.getElementById("fldId").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtBookingNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtBlNo").value;
    var obj =document.getElementById("drShipmentType");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtOBlNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("hidCustomerCode").value;    
    strDetail=strDetail+ColSeparator+document.getElementById("txtCustomerName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipperName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipperAddress1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipperAddress2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipperAddress3").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtShipperAddress4").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsignessName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeAddress1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeAddress2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeAddress3").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtConsigneeAddress4").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtNotifyName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtNotifyAddress1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtNotifyAddress2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtNotifyAddress3").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtNotifyAddress4").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDeliveryAgentName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDeliveryAgentAddress1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDeliveryAgentAddress2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDeliveryAgentAddress3").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDeliveryAgentAddress4").value;
    obj =document.getElementById("drCargoType");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;
    obj =document.getElementById("drDestCargoType");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCargoClass").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCommodityCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCommodityDescription").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtOriginCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDestCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDestName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtPlaceOfReceipt").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtPortOfLoadingName").value;
    strDetail=strDetail+ColSeparator+$("#ETDSelect_txtDateTime").val();
    strDetail=strDetail+ColSeparator+document.getElementById("txtPortOfDischargeCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtPortOfDischargeName").value;
    strDetail=strDetail+ColSeparator+$("#ETASelect_txtDateTime").val();


    strDetail=strDetail+ColSeparator+document.getElementById("txtPlaceOfDelivery").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtVesselName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtVoyageNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtShippingLineCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtShippingDescription").value;
    obj =document.getElementById("drFreight");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;
    obj =document.getElementById("drBlSurrenderFlag");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtNoOfOriginBl").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtBlIssuePlace").value;

    strDetail=strDetail+ColSeparator+$("#BlIssueSelect_txtDateTime").val(); 

    strDetail=strDetail+ColSeparator+$("#LadenSelect_txtDateTime").val();

    strDetail=strDetail+ColSeparator+document.getElementById("txtIssueBy").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtTotalPcsInWord").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtPrepaidAt").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtPayableAt").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtJobNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCreateBy").value;
    strDetail=strDetail+ColSeparator+$("#CeateDateSelect_txtDateTime").val();


    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+"";
    strDetail=strDetail+ColSeparator+"";
    return strDetail+ParSeparator;
    //return strDetail;
}
function GetDiv2Detail()
{
    var strDetail="";
    strDetail=document.getElementById("HidTrxNo").value;
    strDetail=strDetail+ParSeparator+document.getElementById("HidLineItemNo").value;
    strDetail= strDetail+ParSeparator;
    strDetail= strDetail+document.getElementById("txtDescription").value.replace(/\r\n/g,ColSeparator);
        strDetail= strDetail+ParSeparator;
        strDetail= strDetail+document.getElementById("txtMark").value.replace(/\r\n/g,ColSeparator);
        strDetail=strDetail+ParSeparator;
  strDetail=strDetail+document.getElementById("txtContainerNo").value;
strDetail=strDetail+ParSeparator;
  strDetail=strDetail+document.getElementById("txtSealNo").value;
strDetail=strDetail+ParSeparator;
select=document.getElementById("drpContainerType");
    strDetail=strDetail+select.options[select.selectedIndex].text;
  //strDetail=strDetail+document.getElementById("txtContainerType").value;
strDetail=strDetail+ParSeparator;
  strDetail=strDetail+document.getElementById("txtVolume").value;
strDetail=strDetail+ParSeparator;
  strDetail=strDetail+document.getElementById("txtUomCode").value;
strDetail=strDetail+ParSeparator;
  strDetail=strDetail+document.getElementById("txtPcs").value;
strDetail=strDetail+ParSeparator;
  strDetail=strDetail+document.getElementById("txtGrossWeight").value;
strDetail=strDetail;
    return strDetail
    //return strDetail;
}  
function NewDetail(intFlag)
{
 if(intFlag!=2){}
}

function BeforeSave()
{
    document.getElementById("btnSave").disabled=true;
    document.getElementById("btnClose").disabled=true;
}
function AfterSave()
{
    document.getElementById("btnSave").disabled=false;
    document.getElementById("btnClose").disabled=false;
}

function SetOtherSaveReturn(strResult)
{
    if(strResult.length==4){
        document.getElementById("divAttach").innerHTML=strResult[2];
        document.getElementById("fldId").value=strResult[3];
    }
}

function MultiSelectPerson(txtSelect)
{
    var ret=WindowDialog("../SysRef/MultiPersonList.aspx?Id=",<%= SysMagic.SystemClass.InfoListSize.Width%>,<%= SysMagic.SystemClass.InfoListSize.Height%>);

    if(ret!=null) {
        txtSelect.value=ret[1];
    }
}
//lzw081110
function selBindCode(txtCode,txtName,table,fields,where,showCode,showName)
{
    var ret=WindowDialog("../SysRef/TypeSort.aspx?table="+table+"&fields="+fields+"&where="+where+"&showCode="+showCode+"&showName="+showName,<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);
    if(ret!=null) 
    {
     var strRel=ret.split(ColSeparator);
     if (strRel.length==2) 
     {
       context= document.getElementById("div_drop");
        var txt=strRel[1]=="&nbsp;"?" ":strRel[1];
            txt=txt.replace('amp;','');
          txtName.value=txt;
          txtCode.value=strRel[0];
          if(showCode=="Customer Code")
          {
            var arg = "BindDropDown"+ParSeparator+strRel[0]+ParSeparator+strRel[1];
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetContactReturnValue", "context")%>;
          }
     }
    }
}
function SetContactReturnValue(result,context) 
{ 
    AfterSave();
    var strResult=result.split(ParSeparator);
    if (strResult[0]==RtnOk) {
        context.innerHTML = strResult[1]+strResult[2]+strResult[3];
    }
    else if (strResult[1]!=""){
        window.alert(strResult[1]);
    }
}

function selBindContactName(txtName,table,fields,where,showCode,showName)
{
    var ret=WindowDialog("../SysRef/TypeSort.aspx?table="+table+"&fields="+fields+"&where="+where+"&showCode="+showCode+"&showName="+showName,<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);
    if(ret!=null) 
    {
     var strRel=ret.split(ColSeparator);
     if (strRel.length==2) 
     { 
         context=document.getElementById("div_drop");
        var txt=strRel[1].Trim()=="&nbsp;"?" ":strRel[1];
        txtName.value=txt;
     }
    }
}    

function SetReturnValue(result,context) 
{ 

    AfterSave();
    var strResult=result.split(ParSeparator);
    switch(strResult.length) {
        case 2:
            if (strResult[0]==RtnOk) {
                context.innerHTML = strResult[1];
            }
            else if (strResult[1]!=""){
            }
            break;
        case 3:
            if (strResult[0]==RtnOk) {
                context.innerHTML = strResult[1];
                if (strResult[2].length <= 6){
                  document.getElementById("fldId").value=strResult[2];
                }
            }
            else if (strResult[1]!=""){
                window.alert(strResult[1]);
            }
            break;
        case 4:
            if (strResult[0]==RtnOk) {
                context.innerHTML = strResult[1];
            }
            break 
        case 5:
            if (strResult[0]!=RtnOk) {
                //window.alert(strResult[1]);
            }
            else if (strResult[1]!=""){
                window.alert(strResult[1]);
            }
            break;
        default:
            break;
    }
}

function CheckValue(objCon,strFieldName,strTable)
{
    var strFieldVal=document.getElementById(objCon).value;
    if (strFieldVal!="")
    {
        context=objCon;
        BeforeSave();
        var arg = "CheckVal"+ParSeparator+strFieldName+ParSeparator+strFieldVal+ParSeparator+strTable;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}
 
function CanSave()
{
 //drOrganization
  var txt =document.getElementById('txtBlNo')
  if (txt.value=="")
  {
    window.alert("Bl No is mandatory.");
    txt.focus();
    return false;
  }
  return true;
}
function setToUpperCase(Tobj)
{Tobj.value=Tobj.value.toUpperCase();}

</script>