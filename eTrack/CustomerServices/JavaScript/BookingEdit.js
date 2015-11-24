<script language ="javascript" type="text/javascript">

function UpdateTotal(objPcs,objWeight,objVolume)
{
  var strSql='';
  var signFrame = document.getElementById("gvwDimension");
  var strId=document.getElementById("fldId").value;
  if(strId == -1){return false;}
  if(signFrame.rows.length == 1){return false;}
  if(!objPcs || !objWeight || !objVolume){return false;}
  if(isNaN(parseFloat(objPcs.innerHTML)) || isNaN(parseFloat(objWeight.innerHTML)) || isNaN(parseFloat(objVolume.innerHTML))){return false;}
   context=null;
   var arg = "UpdateTotal"+ParSeparator+ objPcs.innerHTML+ParSeparator+objWeight.innerHTML+ParSeparator+objVolume.innerHTML+ParSeparator+strId;
   <%= ClientScript.GetCallbackEventReference(Me, "arg", "setUpdateTotal", "context")%>;

  function setUpdateTotal(result,context)
  {
    var strResult=result.split(ParSeparator);
    if (strResult[0]==RtnOk) {
        document.getElementById("txtPcs").value=strResult[1];
        document.getElementById("txtGrossWeight").value=strResult[2];
        document.getElementById("txtVolume").value=strResult[3];
        alert("Update Successfully");
    }
   }
}
//--------------------------------------------------------------------------------------------
blChanged=true;
var OrderNoBarCode=""; 
function getOrderNoBarCode(obj)
{
  var strOrderNo=obj.value;
  if(strOrderNo!=""){
     context=document .getElementById("btnPrompt");
     var arg = "getOrderNoBarCode"+ParSeparator+strOrderNo;
     <%= ClientScript.GetCallbackEventReference(Me, "arg", "setOrderNoBarCode", "context")%>;
  }
  function setOrderNoBarCode(result,context)
  {
    var strResult=result.split(ParSeparator);
    OrderNoBarCode=strResult[0];
    if(strResult[1]=='y')
    {context.disabled=false;}
    else{context.disabled=true;}
  }
}

        function PrintDetail(intId, Reports) {
            var strUrl = "";
            intId=document.getElementById("fldId").value;
            var strReport = document.getElementById("hidReports").value;
            var arrReport = strReport.split(",");
            if (intId == "-1") { return false; }
            if (Reports == "") { alert("There are Not Reports in the Server."); return false; }
            if (arrReport.length!=1) {
                var strUrl = "../loading.aspx?tourl=CustomerServices/SelectReportEdit.aspx?id=" + intId;
               var ret=WindowDialog(strUrl,400,300);
               if(ret!=null){}
            }
            else {
                strUrl = "../loading.aspx?tourl=CustomerServices/SelectReportEdit.aspx?id=" + intId;
                var strUrl = "../loading.aspx?tourl=Print/crBooking.aspx?Id=" + intId + "&Report=" + arrReport[0];
                window.open(strUrl);
            }
        }
//100517
function OpenRemark(){
    var id= document .getElementById("fldId").value;
    var ret=WindowDialog("IssueEdit.aspx?id="+id,<%= SysMagic.SystemClass.InfoListSize.Width%>,<%= SysMagic.SystemClass.InfoListSize.Height%>);
    if(ret!=null) 
    {
     var strRel=ret.split(ColSeparator);
     if (strRel.length==2) 
     {}
   }
}
//100517
function OpenScan(){
    var id= document .getElementById("txtOrderNo").value;
    var ret=WindowDialog("ScanEdit.aspx?id="+id,<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);
    if(ret!=null) 
    {
     var strRel=ret.split(ColSeparator);
     if (strRel.length==2) 
     {}
   }
}
function CheckOrderType(objOrderNo,objOrderType)
{
  if(objOrderNo.value==""){
     var arg="CheckOrderType"+ParSeparator+objOrderType.value;
     context=document .getElementById("btnConfirmOrder");
     <%= ClientScript.GetCallbackEventReference(Me,"arg","ReturnOrderType","context") %>;
    }
//______________________________________________
 function ReturnOrderType(result,context) 
 { 
     var strResult=result.split(ParSeparator);
     if (strResult[0]==RtnOk) {context.disabled=false;}
     else{alert(strResult[1]);}
  }
}
//>>>>>>>>>>>>>>
function SelectPersonFunction(obj)
{
    var strRoleId = obj.value;
    var strName = obj.name; 
    var strRoleName = obj.innerHTML;
    if (strRoleId) {
        var arg="SelectPersonFunction"+ParSeparator+strRoleId+ParSeparator+strName;
        context="";
        <%= ClientScript.GetCallbackEventReference(Me,"arg","ReturnMessage","context") %>;
    }
}
function DeleteClickOmtx3(intId,lineitem)
{
            if (window.confirm("Are you sure to delete this record?")) 
            {
                context = document.getElementById("divSource");
                var arg = "DeleteOmtx3Data"+ParSeparator+intId.toString()+ParSeparator+lineitem.toString();
                <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetDeleteOmtx3", "context")%>;
            }
}
function SetDeleteOmtx3(result,context) 
{ 
    AfterSave();
    var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk) {
                context.innerHTML = strResult[1];
               // GetTotalValue();
            }
            else if (strResult[1]!=""){
            }
}
function ReturntheValue(result,context)
{
        AfterSave(); // after reply need enable the button.
        window.alert(result);
        window.close(); 
} 
function ExportToDocument(intId,intType)
{
    var strId=document.getElementById("fldId").value;
    var strTrackNo=document.getElementById("txtTrackNo").value;
    var strName=document.getElementById("txtCompleteByName").value; 
    var strMessage;
    if (intType==0){
       strMessage="Are you sure to Export Document?"
      }
    else if (intType==1){
       strMessage="Are you sure to Export Excel about Table changes?"
      }
    else if (intType==2){
       strMessage="Are you sure to Export Excel?"
    }  
    if (strTrackNo.Rtrim()=="")  {
        window.alert("TrackNo is blank,can't export!");
        return false;
        }  
    if (window.confirm(strMessage)) {
        context = document.getElementById("divAttach");
        BeforeSave(); //before export to document need distable the button 
        var arg = "ExportToDocument"+ParSeparator+GetDetail()+ParSeparator+strTrackNo+ParSeparator+strId+ParSeparator+strName+ParSeparator+intType;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }  
}
function CanConfirmSave()
{
    return true;
}
function GetDetail2()
{
    var strDetail="";
    strDetail="New"; 
    strDetail=strDetail+ColSeparator+document.getElementById("txtPcs1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtWeight1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtLength1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtWidth1").value;  
    strDetail=strDetail+ColSeparator+document.getElementById("txtHeight1").value;  
    return strDetail; 
}

function GetDetail()
{
    var strDetail="";

    strDetail=document.getElementById("fldId").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtOrderDate").value;
    strDetail=strDetail+ColSeparator+document.getElementById("drpCustomerName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("drpContactName").value;  
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
    strDetail=strDetail+ColSeparator+document.getElementById("txtOriginCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDestCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtPortOfLoadingCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtlblEtdDate").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtPortOfDischargeCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtlblEtaDate").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtVoyageName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCargoType").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDgFlag").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtDeliveryType").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCommodityCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtUomCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtGrossWeight").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtVolume").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtNoOfContainer1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtContainerType1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtNoOfContainer2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtContainerType2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtNoOfContainer3").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtContainerType3").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtPickupDateTime").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCollectFromName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCargoAddress1").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCargoAddress2").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCargoAddress3").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCargoAddress4").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtSpecialInstruction").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtOrderNo").value;
    //add
    strDetail=strDetail+ColSeparator+document.getElementById("hid_CustomerCode").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtVoyageNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtCommodityName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtPcs").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtMarkNo").value;   
    //090312 byzhiwei
    strDetail=strDetail+ColSeparator+document.getElementById("txtAirPortofDepartureCode").value;   
    strDetail=strDetail+ColSeparator+document.getElementById("txtAirPortDestinationCode").value;   
    strDetail=strDetail+ColSeparator+document.getElementById("txtAlirlineID").value;   
    strDetail=strDetail+ColSeparator+document.getElementById("txtFlightNo").value; 
    strDetail=strDetail+ColSeparator+document.getElementById("hid_moduleCode").value; 
     //090325 byzhiwei for Local Transport
         strDetail=strDetail+ColSeparator+document.getElementById("txtCollectFrom").value; 
         strDetail=strDetail+ColSeparator+document.getElementById("txtDeliverTo").value;          
         strDetail=strDetail+ColSeparator+document.getElementById("txtPickupDateTimeTP").value;
         strDetail=strDetail+ColSeparator+document.getElementById("txtCargoDeliverDateTime").value;
         //adress
         strDetail=strDetail+ColSeparator+document.getElementById("txtDeliverToAddress1").value;        
         strDetail=strDetail+ColSeparator+document.getElementById("txtDeliverToAddress2").value;        
         strDetail=strDetail+ColSeparator+document.getElementById("txtDeliverToAddress3").value;        
         strDetail=strDetail+ColSeparator+document.getElementById("txtDeliverToAddress4").value;        
         strDetail=strDetail+ColSeparator+document.getElementById("txtDescriptionOfGoods1").value;        
         strDetail=strDetail+ColSeparator+document.getElementById("txtDescriptionOfGoods2").value;        
         strDetail=strDetail+ColSeparator+document.getElementById("txtDescriptionOfGoods3").value;        
         strDetail=strDetail+ColSeparator+document.getElementById("txtDescriptionOfGoods4").value;        
//100518 .net1783
         strDetail=strDetail+ColSeparator+document.getElementById("txtOrderType").value;
//100519 .net1786
         strDetail=strDetail+ColSeparator+document.getElementById("txtTelephone").value;
         strDetail=strDetail+ColSeparator+document.getElementById("txtPackingQty1").value;
         strDetail=strDetail+ColSeparator+document.getElementById("txtPackingQty2").value;
         strDetail=strDetail+ColSeparator+document.getElementById("txtPackingQty3").value;
         strDetail=strDetail+ColSeparator+document.getElementById("txtPackingQty4").value;
         strDetail=strDetail+ColSeparator+document.getElementById("txtPackingQty5").value;
         strDetail=strDetail+ColSeparator+document.getElementById("drModule").value;
         if(OrderNoBarCode==""){strDetail=strDetail+ColSeparator+document.getElementById("hidOrderNoBarCode").value;}
         else{strDetail=strDetail+ColSeparator+OrderNoBarCode; }
         strDetail=strDetail+ColSeparator+"";      
         strDetail=strDetail+ColSeparator+"";      
         strDetail=strDetail+ColSeparator+"";      
    return strDetail+ParSeparator+"";
    //return strDetail;
}
  
function NewDetail(intFlag)
{
if(intFlag!=2){
document.getElementById("fldId").value="-1";
document.getElementById("txtOrderDate").value="";
document.getElementById("drpCustomerName").value="";
document.getElementById("drpContactName").value="";
document.getElementById("txtShipperName").value="";  
document.getElementById("txtShipperAddress1").value="";  
document.getElementById("txtShipperAddress2").value="";  
document.getElementById("txtShipperAddress3").value="";    
document.getElementById("txtShipperAddress4").value="";    
document.getElementById("txtConsignessName").value="";        
document.getElementById("txtConsigneeAddress1").value="";    
document.getElementById("txtConsigneeAddress2").value="";    
document.getElementById("txtConsigneeAddress3").value="";    
document.getElementById("txtConsigneeAddress4").value="";     
document.getElementById("txtOriginCode").value="";
document.getElementById("txtOriginName").value="";
document.getElementById("txtDestCode").value="";
document.getElementById("txtDestName").value="";
document.getElementById("txtPortOfLoadingCode").value="";
document.getElementById("txtPortOfLoadingName").value="";
document.getElementById("txtlblEtdDate").value="";
document.getElementById("txtPortOfDischargeCode").value="";
document.getElementById("txtPortOfDischargeName").value="";
document.getElementById("txtlblEtaDate").value="";
document.getElementById("txtVoyageName").value="";
document.getElementById("txtCargoType").value="";
document.getElementById("txtDgFlag").value="";
document.getElementById("txtDeliveryType").value="";
document.getElementById("txtDelivery").value="";
document.getElementById("txtCommodityCode").value="";
document.getElementById("txtUomCode").value="";
document.getElementById("txtGrossWeight").value="";
document.getElementById("txtVolume").value="";
document.getElementById("txtNoOfContainer1").value="";
document.getElementById("txtContainerType1").value="";
document.getElementById("txtNoOfContainer2").value="";
document.getElementById("txtContainerType2").value="";
document.getElementById("txtNoOfContainer3").value="";
document.getElementById("txtContainerType3").value="";
document.getElementById("txtPickupDateTime").value="";
document.getElementById("txtCollectFromName").value="";
document.getElementById("txtCargoAddress1").value="";
document.getElementById("txtCargoAddress2").value="";
document.getElementById("txtCargoAddress3").value="";
document.getElementById("txtCargoAddress4").value="";
document.getElementById("txtSpecialInstruction").value="";
document.getElementById("txtOrderNo").value="";
document.getElementById("hid_CustomerCode").value="";
document.getElementById("txtVoyageNo").value="";
document.getElementById("txtCommodityName").value="";
document.getElementById("txtPcs").value="";
document.getElementById("txtMarkNo").value="";
document.getElementById("txtOrderType").value="";

document.getElementById("txtTelephone").value="";
document.getElementById("txtPackingQty1").value="";
document.getElementById("txtPackingQty2").value="";
document.getElementById("txtPackingQty3").value="";
document.getElementById("txtPackingQty4").value="";
document.getElementById("txtPackingQty5").value="";
document.getElementById("drModule").value="";
document.getElementById("hidOrderNoBarCode").value="";

}
//    if(intFlag==1){
//        context = document.getElementById("divAttach");
//        var arg = "GetNewBookingAttach";
//        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
//    }
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

function AddSelectedAttach()
{
    var strId=document.getElementById("fldId").value;
    var ret=WindowDialog("../SysRef/AttachEdit.aspx?Id="+strId+"&Folder=omtx1",640,450);
    if(ret!=null && ret!=""){
        context = document.getElementById("divAttach");
        var arg = "AddSelectedAttach"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function DeleteOneAttach(strFileName)
{
    var strId=document.getElementById("fldId").value;
    if (window.confirm("Are you sure to delete current select attachment?")) {
        context = document.getElementById("divAttach");
        var arg = "DeleteOneAttach"+ParSeparator+strId+ParSeparator+strFileName;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
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

    var ret=WindowDialog("../SysRef/MultiPersonList.aspx?Id=",<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);

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
//lzw090218
function UpdateDimension(strTrxNo,intLineitemno,strField,Context)
{
     var  strValue=document.getElementById(Context).value;
      strValue=strValue==""?"0":strValue
     if(strTrxNo!="" && intLineitemno!="")
     {
      var strslq=" update omtx3 set "+strField+"="+strValue+" where TrxNo="+strTrxNo+" and LineItemNo="+intLineitemno;
      context = document.getElementById("divSource");
      var arg = "DimensionUpdate"+ParSeparator+strslq;
      <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;    
     }
 }
//lzw090330
function AddToDimension()
{
    var blankFlag=0 ;
    var signFrame = document.getElementById("gvwDimension");
    var tr;
       if(signFrame.rows.length == 1){blankFlag+=1}
       else if (signFrame.rows.length > 1)
       { 
            tr = signFrame.rows[signFrame.rows.length-1];
              if (tr.cells[1].hasChildNodes() && (tr.cells[1].childNodes[0].nodeType==1)) 
              {
                 var strRowS="";
                 for (var j = 2; j< tr.cells.length-2; j++) 
                     {
                        var strFile=tr.cells[j].childNodes[0].value.replace(/,/g,"")
                        if(strFile.Trim()!=""){blankFlag+=1;}
                     }
             }
       }
       if(blankFlag>0)
       {
            var signFrame = document.getElementById("gvwDimension");
            context = document.getElementById("divSource");
            var strTrxNo =document.getElementById("fldId");
            var arg = "DimensionSaveOne"+ParSeparator+strTrxNo.value;
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;  
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
//lzw081110
function selCN(txtCode,txtName,table,fields,where,showCode,showName)
{
    var ret=WindowDialog("../SysRef/TypeSort.aspx?table="+table+"&fields="+fields+"&where="+where+"&showCode="+showCode+"&showName="+showName,<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);
    if(ret!=null) 
    {
         var strRel=ret.split(ColSeparator);
         if (strRel.length==2) 
         { 
            var txt=strRel[1]=="&nbsp;"?" ":strRel[1];
            txt=txt.replace('amp;','');
            txtCode.value=strRel[0];
            txtName.value=txt;
                switch(showCode)
                {
                    case "Origin Code":
                          document.getElementById("divOrigin1").innerHTML="";
                      break;
                    case "Destination Code":
                         document.getElementById("divDestCode1").innerHTML="";
                      break;
                    case "PortOfLoading Code":
                         document.getElementById("divLoading1").innerHTML="";
                      break;
                    case "PortOfDischarge Code":
                         document.getElementById("divDischarge1").innerHTML="";
                      break;
                    case "Delivery Type":
                         document.getElementById("divDelivery1").innerHTML="";
                      break;
                    case "Commodity Code":
                         document.getElementById("divCommodity1").innerHTML="";
                      break;
                    case "AirDeparture Code":
                         document.getElementById("div_txtAirPortofDeparture1").innerHTML="";
                      break;
                    case "AirDestination Code":
                         document.getElementById("div1AirPortDestination1").innerHTML="";
                    break;
                }
         }
    }
}

function CheckValue(objCon,strFieldName,strTable)
{
    var strFieldVal=document.getElementById(objCon).value;
    if (strFieldVal!="")
    {
        context=objCon;
        BeforeSave();
        var arg = "CheckValue"+ParSeparator+strFieldName+ParSeparator+strFieldVal+ParSeparator+strTable;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetCheckValue", "context")%>;
    }
    function SetCheckValue(result,context)
    {
      AfterSave();
      var strResult=result.split(ParSeparator);
      if (strResult[0]==RtnOk) 
      {
 
      }
      else {
           window.alert(strResult[1]);
           if (strResult[0]==RtnTimeOut) {CloseWindow();}
           }
     }
}
function CheckDoubleValue(objCon,strFieldCode,strFieldName,strType,strTable)
{

    var strFieldVal=objCon.value;
    objCon.value=objCon.value.toUpperCase();
        switch(strType)
        {
            case "Origin":
                context=document.getElementById("divOrigin");
                 break;
            case "DestCode":
                context=document.getElementById("divDestCode");
                 break;
            case "Loading":
                context=document.getElementById("divLoading");
                 break;
            case "Discharge":
                context=document.getElementById("divDischarge");
                 break;
            case "Delivery": 
                context=document.getElementById("divDelivery");
                 break;
            case "Commodity":
                context=document.getElementById("divCommodity");
                 break;
            case "AirPortofDeparture":
                context=document.getElementById("divtxtAirPortofDeparture");
                 break;
            case "AirPortDestination":
                context=document.getElementById("div_lblAirPortofDestination");
                 break;
            case "Voyage"://090610
                context=null;
                 break;
            case "Uom":
                context=null;
                 break;
           default:
        context=objCon;
                    break;
         }
        var arg = "CheckDoubleVal"+ParSeparator+strFieldCode+ParSeparator+strFieldName+ParSeparator+strFieldVal+ParSeparator+strType+ParSeparator+strTable;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetCheckValue", "context")%>;
}
 function SetCheckValue(result,context) 
{ 
    var strResult=result.split(ParSeparator);
    switch(strResult.length) {
            case 5:
            if (strResult[0]==RtnOk) {
                if(strResult[1]!="")
                        {
                         document.getElementById(strResult[1]).innerHTML=strResult[2]
                         var divFlag=strResult[2].split(" ");
                         if (divFlag[1]=="Origin"){document.getElementById("divOrigin").innerHTML=strResult[3]}
                          if (divFlag[1]=="Dest"){document.getElementById("divDestCode").innerHTML=strResult[3]}
                          if (divFlag[1]=="Loading"){document.getElementById("divLoading").innerHTML=strResult[3]}
                          if (divFlag[1]=="Discharge"){document.getElementById("divDischarge").innerHTML=strResult[3]}
                          if (divFlag[1]=="Delivery"){document.getElementById("divDelivery").innerHTML=strResult[3]}
                          if (divFlag[1]=="Commodity"){document.getElementById("divCommodity").innerHTML=strResult[3]}
                            if(strResult[2].split(" ").length==5)
                            {
                              if (divFlag[3]=="Departure"){document.getElementById("divtxtAirPortofDeparture").innerHTML=strResult[3]}
                              if (divFlag[3]=="Destination"){document.getElementById("divAirPortDestinationName").innerHTML=strResult[3]}
                            }
                        }
                 else{
                          if (strResult[3]=="Voyage"){document.getElementById("divVoyage").innerHTML=strResult[2]}
                          if (strResult[3]=="Uom"){document.getElementById("divUom").innerHTML=strResult[2]}
                     }
            }
            else if (strResult[1]!=""){
                window.alert(strResult[1]);
            }
            break;
        case 4:
            if (strResult[0]==RtnOk) {
                    if (strResult[1]!="divCommodity"){
                    document.getElementById(strResult[1]).innerHTML=strResult[2];}
                      document.getElementById(strResult[3]).innerHTML=" ";
                        if (strResult[1]=="divCommodity")
                           {document.getElementById(strResult[1]).value=strResult[2];} //document.getElementById("txtCommodityName").value=strResult[2];
                        
            }
            else if (strResult[1]!=""){
                window.alert(strResult[1]);
            }
          break;
        default:
            break;
    }
}
function CanSave()
{
var str ="";
if(document.getElementById("divOrigin1").innerHTML.length!=0)
{
  str+=document.getElementById("divOrigin1").innerHTML+"\r";
}

if(document.getElementById("divDestCode1").innerHTML.length!=0)
{
  str+=document.getElementById("divDestCode1").innerHTML+"\r";
}

if(document.getElementById("divLoading1").innerHTML.length!=0)
{
  str+=document.getElementById("divLoading1").innerHTML+"\r";
}

if(document.getElementById("divDischarge1").innerHTML.length!=0)
{
  str+=document.getElementById("divDischarge1").innerHTML+"\r";
}

if(document.getElementById("divDelivery1").innerHTML.length!=0)
{
  str+=document.getElementById("divDelivery1").innerHTML+"\r";
}

if(document.getElementById("divCommodity1").innerHTML.length!=0)
{
  str+=document.getElementById("divCommodity1").innerHTML+"\r";
}


if(document.getElementById("div_txtAirPortofDeparture1").innerHTML.length!=0)
{
  str+=document.getElementById("div_txtAirPortofDeparture1").innerHTML+"\r";
}

if(document.getElementById("div1AirPortDestination1").innerHTML.length!=0)
{
  str+=document.getElementById("div1AirPortDestination1").innerHTML+"\r";
}
if(document.getElementById("divVoyage").innerHTML.length!=0)
{
  str+=document.getElementById("divVoyage").innerHTML+"\r";
}
if(document.getElementById("divUom").innerHTML.length!=0)
{
  str+=document.getElementById("divUom").innerHTML+"\r";
}
if (str.Trim().length!="0")
{
alert(str);
return false;
}
else 
{return true;}
}
//090306 bylzw
function SendDetail(intId,intType)
{
   var strId=document.getElementById("fldId").value;
   var strMessage;
   var returmMessage;
   if (intType==0){
      strMessage="Are you sure to send this Booking?"
      returnMessage="Send the request Successful!"
     }
   if (window.confirm(strMessage)) {
        context = document.getElementById("divAttach");
        BeforeSave(); //before send need disable the button 
        var arg = "SendData"+ParSeparator+GetDetail()+ParSeparator+strId+ParSeparator+intType; // for this need first save when send .
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
//        window.alert(returnMessage);  
//        AfterSave(); // after send need enable the button.    
    }
}
function setToUpperCase(Tobj)
{
Tobj.value=Tobj.value.toUpperCase();
}



function FocusControlDimension(event,Prev,Next)
{
                   if((event.keyCode==13)||(event.keyCode==0x28)) 
                   {
                        if(Next!=null) {
                            if(!Next.disabled && Next.style.display!="none"){
                                event.returnValue=false;
                                Next.focus();
                                if (Next.type=="text") {
//                                    var r =Next.createTextRange();
//                                    r.moveStart("character",Next.value.length);
//                                    r.collapse(true);
//                                    r.select();
                                }
                            }
                            else{
                                      event.keyCode=9;
                            }
                            return ;
                        }
                        else {
                            event.returnValue=false;
                        }
                    }
}

function NumberBlurBooking(event,dotlen,intFlag)
{
    var e=event.srcElement ? event.srcElement : event.target;
    if (e.readOnly) {
        return;
    }
    if (e.value=="") {
        if (intFlag) {
//            e.value="0";  
        }
        else {
            e.value=(parseFloat("0")).toFixed(dotlen);  
        } 
    }
    else if (e.value=="-") {
        if (intFlag) {
            e.value="0";  
        }
        else {
            e.value=(parseFloat("0")).toFixed(dotlen);  
        } 
    }
    else {
        if(intFlag) {
            e.value=DeleteTailZero((parseFloat(e.value).toFixed(dotlen)));   
        }
        else {
            e.value=splitNumber((parseFloat(e.value)).toFixed(dotlen));   
        }
    }
    e.style.textAlign="left";
}
function AutoSave(strTitle,intFlag,IntTab)
{
     if (!StrToBool(SavePrompt) || window.confirm(ConfirmSave.replace("{0}",strTitle)))
        { 
         if (!CanSave()){return false;}
         context=intFlag;
         BeforeSave();
         var arg = "SaveData"+ParSeparator+GetDetail();
         <%= ClientScript.GetCallbackEventReference(Me,"arg", "SaveBooking", "context")%>;
        }
    else{
         if(intFlag) {NewDetail(1);}
         else {window.close();}
        }
    SelectedDiv(IntTab,3);
}
function SaveBookingDetail(strTitle,intFlag)
{
       if (!StrToBool(SavePrompt) || window.confirm(ConfirmSave.replace("{0}",strTitle))) 
          { 
           if (!CanSave()) 
           {return;}
           context=intFlag;
           BeforeSave();
           var arg = "SaveData"+ParSeparator+GetDetail();
           <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveBooking", "context")%>;
          }
      else{
           if(intFlag) {NewDetail(1);}
           else {window.close();}
          }
}
function SaveBooking(result,context)
{
    AfterSave();
    var strResult=result.split(ParSeparator);

            if (strResult[0]==RtnOk) 
            {
                    if(context==1)
                    {
                        blChanged=true;
                        NewDetail(context);
                        // CloseWindow();
                    }
                    else if(context==2)
                    {
                        blChanged=true;
                        if(strResult[2]!="-1"){document.getElementById("fldId").value=strResult[2];}
                        alert(strResult[1]);
                       //  CloseWindow();
                    }
                   else if(context==3){
                        blChanged=true;
                        if(strResult[2]!="-1"){document.getElementById("fldId").value=strResult[2];}
                      //  CloseWindow();
                   }
            }
        else {
            window.alert(strResult[1]);
            if (strResult[0]==RtnTimeOut) {CloseWindow();}
             }
}
//ConfirmSaveBooking
function ConfirmSaveBooking(strTitle,intFlag)
{
//    strInfo="Are you sure Confirm current {0}?";
//    if (window.confirm(strInfo.replace("{0}","Booking"))) 
//    {
        if (!CanSave()) 
        {
            return;
        }
        context=document.getElementById("txtOrderNo");
        BeforeSave();
        var strOrderType=document.getElementById("txtOrderType").value;
        var arg = "SaveConfirmData"+ParSeparator+GetDetail()+ParSeparator+strOrderType;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "setConfirmSaveBooking", "context")%>;
//    }
}
function setConfirmSaveBooking(result,context)
{
    AfterSave();
    var strResult=result.split(ParSeparator);
    blChanged=true;
            if (strResult[0]==RtnOk) 
            {
                if(strResult[1]!="-1"){document.getElementById("fldId").value=strResult[1];}
                context.value = strResult[2];
                divbtnConfirmOrder.innerHTML = strResult[3];
                document.getElementById("divIssue").innerHTML=strResult[4];
                OrderNoBarCode=strResult[5];
                document.getElementById("divScan").innerHTML=strResult[7];                
            }
            else { alert(strResult[1]);
              document.getElementById("fldId").value=strResult[2];
            }
}
</script>